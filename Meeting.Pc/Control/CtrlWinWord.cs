using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using CNS.OFFICE.MyWord;


namespace Meeting.Pc.Control
{
    /// <summary>
    /// WinWordControl allows you to load doc-Files to your
    /// own application without any loss, because it uses 
    /// the real WinWord.
    /// </summary>
    public class CtrlWinWord : System.Windows.Forms.UserControl
    {


        #region "API usage declarations"

        [DllImport("user32.dll")]
        public static extern int FindWindow(string strclassName, string strWindowName);

        [DllImport("user32.dll")]
        static extern int SetParent(int hWndChild, int hWndNewParent);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        static extern bool SetWindowPos(
            int hWnd,               // handle to window
            int hWndInsertAfter,    // placement-order handle
            int X,                  // horizontal position
            int Y,                  // vertical position
            int cx,                 // width
            int cy,                 // height
            uint uFlags             // window-positioning options
            );

        [DllImport("user32.dll", EntryPoint = "MoveWindow")]
        static extern bool MoveWindow(
            int Wnd,
            int X,
            int Y,
            int Width,
            int Height,
            bool Repaint
            );

        [DllImport("user32.dll", EntryPoint = "DrawMenuBar")]
        static extern Int32 DrawMenuBar(
            Int32 hWnd
            );

        [DllImport("user32.dll", EntryPoint = "GetMenuItemCount")]
        static extern Int32 GetMenuItemCount(
            Int32 hMenu
            );

        [DllImport("user32.dll", EntryPoint = "GetSystemMenu")]
        static extern Int32 GetSystemMenu(
            Int32 hWnd,
            bool Revert
            );

        [DllImport("user32.dll", EntryPoint = "RemoveMenu")]
        static extern Int32 RemoveMenu(
            Int32 hMenu,
            Int32 nPosition,
            Int32 wFlags
            );


        private const int MF_BYPOSITION = 0x400;
        private const int MF_REMOVE = 0x1000;


        const int SWP_DRAWFRAME = 0x20;
        const int SWP_NOMOVE = 0x2;
        const int SWP_NOSIZE = 0x1;
        const int SWP_NOZORDER = 0x4;

        #endregion



        /* I was testing wheater i could fix some exploid bugs or not.
		 * I left this stuff in here for people who need to know how to 
		 * interface the Win32-API

		[StructLayout(LayoutKind.Sequential)]
			public struct RECT 
		{
			public int left;
			public int top;
			public int right;
			public int bottom;
		}
		
		[DllImport("user32.dll")]
		public static extern int GetWindowRect(int hwnd, ref RECT rc);
		
		[DllImport("user32.dll")]
		public static extern IntPtr PostMessage(
			int hWnd, 
			int msg, 
			int wParam, 
			int lParam
		);
		*/


        /// <summary>
        /// Change. Made the following variables public.
        /// </summary>

        public Word.Document WordDoc;
        public Word.ApplicationClass WordApplication = null;
        public int WordWnd = 0;
        public string FileName = null;
        private bool deactivateevents = false;
        List<int> OldWordProcess = null;
        List<int> NewWordProcess = null;
        private Panel plApplyName;
        public event EventHandler ReSet;
        /// <summary>
        /// 供应商名称
        /// </summary>
        //public string ApplyName
        //{
        //    get { return this.lblApplyName.Text; }
        //    set { this.lblApplyName.Text = value; }
        //}

        /// <summary>
        /// needed designer variable
        /// </summary>
        private System.ComponentModel.Container components = null;

        public CtrlWinWord()
        {
            InitializeComponent();
            OldWordProcess = new List<int>();
            NewWordProcess = new List<int>();
        }

        /// <summary>
        /// cleanup Ressources
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            CloseControl();
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary>
        /// !do not alter this code! It's designer code
        /// </summary>
        private void InitializeComponent()
        {
            this.plApplyName = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // plApplyName
            // 
            this.plApplyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plApplyName.Location = new System.Drawing.Point(0, 20);
            this.plApplyName.Name = "plApplyName";
            this.plApplyName.Size = new System.Drawing.Size(440, 316);
            this.plApplyName.TabIndex = 0;
            // 
            // CtrlWinWord
            // 
            this.Controls.Add(this.plApplyName);
            this.Name = "CtrlWinWord";
            this.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.Size = new System.Drawing.Size(440, 336);
            this.Resize += new System.EventHandler(this.OnResize);
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// Preactivation
        /// It's usefull, if you need more speed in the main Program
        /// so you can preload Word.
        /// </summary>
        public void PreActivate()
        {
            if (WordApplication == null) WordApplication = new Word.ApplicationClass();
        }

        /// <summary>
        /// Close the current Document in the control --> you can 
        /// load a new one with LoadDocument
        /// </summary>
        public void CloseControl()
        {
            /*
            * this code is to reopen Word.
            */
            try
            {
                deactivateevents = true;
                object dummy = null;
                object dummy2 = (object)false;
                WordDoc.Close(ref dummy, ref dummy, ref dummy);
                // Change the line below.
                WordApplication.Quit(ref dummy2, ref dummy, ref dummy);
                deactivateevents = false;
            }
            catch (Exception ex)
            {
                String strErr = ex.Message;
            }
            finally
            {
                this.KillWordProcess(OldWordProcess, NewWordProcess);
            }
        }

        /// <summary>
        /// catches Word's close event 
        /// starts a Thread that send a ESC to the word window ;)
        /// </summary>
        /// <param name="pDoc"></param>
        /// <param name="test"></param>
        private void OnClose(Word.Document pDoc, ref bool pCancel)
        {
            if (!deactivateevents)
            {
                pCancel = true;
            }
        }

        /// <summary>
        /// catches Word's open event
        /// just close
        /// </summary>
        /// <param name="pDoc"></param>
        private void OnOpenDoc(Word.Document pDoc)
        {
            OnNewDoc(pDoc);
        }

        /// <summary>
        /// catches Word's newdocument event
        /// just close
        /// </summary>
        /// <param name="pDoc"></param>
        private void OnNewDoc(Word.Document pDoc)
        {
            if (!deactivateevents)
            {
                deactivateevents = true;
                object dummy = null;
                pDoc.Close(ref dummy, ref dummy, ref dummy);
                deactivateevents = false;
            }
        }

        /// <summary>
        /// catches Word's quit event
        /// normally it should not fire, but just to be shure
        /// safely release the internal Word Instance 
        /// </summary>
        private void OnQuit()
        {
            //wd=null;
        }

        /// <summary>
        /// Loads a document into the control
        /// </summary>
        /// <param name="pFileName">path to the file (every type word can handle)</param>
        public void LoadDocument(string pFileName)
        {
            this.SaveWordProcess(OldWordProcess);
            try
            {
                deactivateevents = true;
                FileName = pFileName;

                if (WordApplication == null) WordApplication = new Word.ApplicationClass();
                try
                {
                    WordApplication.CommandBars.AdaptiveMenus = false;
                    WordApplication.DocumentBeforeClose += new Word.ApplicationEvents2_DocumentBeforeCloseEventHandler(OnClose);
                    WordApplication.NewDocument += new Word.ApplicationEvents2_NewDocumentEventHandler(OnNewDoc);
                    WordApplication.DocumentOpen += new Word.ApplicationEvents2_DocumentOpenEventHandler(OnOpenDoc);
                    WordApplication.ApplicationEvents2_Event_Quit += new Word.ApplicationEvents2_QuitEventHandler(OnQuit);

                }
                catch { }

                if (WordDoc != null)
                {
                    try
                    {
                        object dummy = null;
                        WordApplication.Documents.Close(ref dummy, ref dummy, ref dummy);
                    }
                    catch { }
                }

                if (WordWnd == 0) WordWnd = FindWindow("Opusapp", null);
                if (WordWnd != 0)
                {

                    SetParent(WordWnd, this.plApplyName.Handle.ToInt32());

                    object fileName = FileName;
                    object newTemplate = false;
                    object docType = 0;
                    object readOnly = true;
                    object isVisible = true;
                    object missing = System.Reflection.Missing.Value;

                    try
                    {
                        if (WordApplication == null)
                        {
                            throw new WordInstanceException();
                        }

                        if (WordApplication.Documents == null)
                        {
                            throw new DocumentInstanceException();
                        }

                        if (WordApplication != null && WordApplication.Documents != null)
                        {
                            WordDoc = WordApplication.Documents.Add(ref fileName, ref newTemplate, ref docType, ref isVisible);
                        }

                        if (WordDoc == null)
                        {
                            throw new ValidDocumentException();
                        }
                    }
                    catch { }

                    try
                    {
                        WordApplication.ActiveWindow.DisplayRightRuler = false;
                        WordApplication.ActiveWindow.DisplayScreenTips = false;
                        WordApplication.ActiveWindow.DisplayVerticalRuler = false;
                        WordApplication.ActiveWindow.DisplayRightRuler = false;
                        WordApplication.ActiveWindow.ActivePane.DisplayRulers = false;
                        //修改word显示方式  页面视图方式显示
                        WordApplication.ActiveWindow.ActivePane.View.Type = Word.WdViewType.wdPrintView;
                    }
                    catch { }

                    int counter = WordApplication.ActiveWindow.Application.CommandBars.Count;
                    for (int i = 1; i <= counter; i++)
                    {
                        try
                        {

                            String nm = WordApplication.ActiveWindow.Application.CommandBars[i].Name;
                            if (nm == "Standard")
                            {
                                int count_control = WordApplication.ActiveWindow.Application.CommandBars[i].Controls.Count;
                                for (int j = 1; j <= 2; j++)
                                {
                                    WordApplication.ActiveWindow.Application.CommandBars[i].Controls[j].Enabled = false;
                                }
                            }

                            if (nm == "Menu Bar")
                            {
                                WordApplication.ActiveWindow.Application.CommandBars[i].Enabled = false;
                            }
                            nm = "";
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }

                    try
                    {
                        WordApplication.Visible = true;
                        WordApplication.Activate();
                        SetWindowPos(WordWnd, this.plApplyName.Handle.ToInt32(), 0, 0, this.Bounds.Width, this.Bounds.Height, SWP_NOZORDER | SWP_NOMOVE | SWP_DRAWFRAME | SWP_NOSIZE);
                        //OnResize();
                    }
                    catch
                    {
                        //MessageBox.Show("Error: do not load the document into the control until the parent window is shown!");
                    }

                    try
                    {
                        int hMenu = GetSystemMenu(WordWnd, false);
                        if (hMenu > 0)
                        {
                            int menuItemCount = GetMenuItemCount(hMenu);
                            RemoveMenu(hMenu, menuItemCount - 1, MF_REMOVE | MF_BYPOSITION);
                            RemoveMenu(hMenu, menuItemCount - 2, MF_REMOVE | MF_BYPOSITION);
                            RemoveMenu(hMenu, menuItemCount - 3, MF_REMOVE | MF_BYPOSITION);
                            RemoveMenu(hMenu, menuItemCount - 4, MF_REMOVE | MF_BYPOSITION);
                            RemoveMenu(hMenu, menuItemCount - 5, MF_REMOVE | MF_BYPOSITION);
                            RemoveMenu(hMenu, menuItemCount - 6, MF_REMOVE | MF_BYPOSITION);
                            DrawMenuBar(WordWnd);
                        }
                    }
                    catch { };
                    if (this.Parent != null)
                        this.Parent.Focus();
                }
                deactivateevents = false;
            }
            finally
            {
                this.SaveWordProcess(NewWordProcess);
            }
        }

        public void CreateWord(string pFileName)
        {
            deactivateevents = true;
            FileName = pFileName;
            if (WordApplication == null) WordApplication = new Word.ApplicationClass();
            try
            {
                WordApplication.CommandBars.AdaptiveMenus = false;
                WordApplication.DocumentBeforeClose += new Word.ApplicationEvents2_DocumentBeforeCloseEventHandler(OnClose);
                WordApplication.NewDocument += new Word.ApplicationEvents2_NewDocumentEventHandler(OnNewDoc);
                WordApplication.DocumentOpen += new Word.ApplicationEvents2_DocumentOpenEventHandler(OnOpenDoc);
                WordApplication.ApplicationEvents2_Event_Quit += new Word.ApplicationEvents2_QuitEventHandler(OnQuit);

            }
            catch { }

            if (WordDoc != null)
            {
                try
                {
                    object dummy = null;
                    WordApplication.Documents.Close(ref dummy, ref dummy, ref dummy);
                }
                catch { }
            }

            if (WordWnd == 0) WordWnd = FindWindow("Opusapp", null);
            if (WordWnd != 0)
            {
                SetParent(WordWnd, this.plApplyName.Handle.ToInt32());

                object fileName = FileName;
                object newTemplate = false;
                object docType = 0;
                object readOnly = true;
                object isVisible = true;
                object missing = System.Reflection.Missing.Value;

                try
                {
                    if (WordApplication == null)
                    {
                        throw new WordInstanceException();
                    }

                    if (WordApplication.Documents == null)
                    {
                        throw new DocumentInstanceException();
                    }

                    if (WordApplication != null && WordApplication.Documents != null)
                    {
                        WordDoc = WordApplication.Documents.Add(ref fileName, ref newTemplate, ref docType, ref isVisible);
                    }

                    if (WordDoc == null)
                    {
                        throw new ValidDocumentException();
                    }
                }
                catch
                {
                }

                try
                {
                    WordApplication.ActiveWindow.DisplayRightRuler = false;
                    WordApplication.ActiveWindow.DisplayScreenTips = false;
                    WordApplication.ActiveWindow.DisplayVerticalRuler = false;
                    WordApplication.ActiveWindow.DisplayRightRuler = false;
                    WordApplication.ActiveWindow.ActivePane.DisplayRulers = false;
                    WordApplication.ActiveWindow.ActivePane.View.Type = Word.WdViewType.wdWebView;
                }
                catch { }
                int counter = WordApplication.ActiveWindow.Application.CommandBars.Count;
                for (int i = 1; i <= counter; i++)
                {
                    try
                    {

                        String nm = WordApplication.ActiveWindow.Application.CommandBars[i].Name;
                        if (nm == "Standard")
                        {
                            int count_control = WordApplication.ActiveWindow.Application.CommandBars[i].Controls.Count;
                            for (int j = 1; j <= 2; j++)
                            {
                                WordApplication.ActiveWindow.Application.CommandBars[i].Controls[j].Enabled = false;
                            }
                        }

                        if (nm == "Menu Bar")
                        {
                            //To disable the menubar, use the following (1) line
                            WordApplication.ActiveWindow.Application.CommandBars[i].Enabled = false;
                        }

                        nm = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }



                // Show the word-document
                try
                {
                    WordApplication.Visible = true;
                    WordApplication.Activate();

                    SetWindowPos(WordWnd, this.plApplyName.Handle.ToInt32(), 0, 0, this.Bounds.Width, this.Bounds.Height, SWP_NOZORDER | SWP_NOMOVE | SWP_DRAWFRAME | SWP_NOSIZE);

                    //Call onresize--I dont want to write the same lines twice
                    //OnResize();
                }
                catch
                {
                    MessageBox.Show("Error: do not load the document into the control until the parent window is shown!");
                }
                /// We want to remove the system menu also. The title bar is not visible, but we want to avoid accidental minimize, maximize, etc ..by disabling the system menu(Alt+Space)
                try
                {
                    int hMenu = GetSystemMenu(WordWnd, false);
                    if (hMenu > 0)
                    {
                        int menuItemCount = GetMenuItemCount(hMenu);
                        RemoveMenu(hMenu, menuItemCount - 1, MF_REMOVE | MF_BYPOSITION);
                        RemoveMenu(hMenu, menuItemCount - 2, MF_REMOVE | MF_BYPOSITION);
                        RemoveMenu(hMenu, menuItemCount - 3, MF_REMOVE | MF_BYPOSITION);
                        RemoveMenu(hMenu, menuItemCount - 4, MF_REMOVE | MF_BYPOSITION);
                        RemoveMenu(hMenu, menuItemCount - 5, MF_REMOVE | MF_BYPOSITION);
                        RemoveMenu(hMenu, menuItemCount - 6, MF_REMOVE | MF_BYPOSITION);
                        DrawMenuBar(WordWnd);
                    }
                }
                catch { }
                if (this.Parent != null)
                {
                    this.Parent.Focus();
                }

            }
            deactivateevents = false;
        }

        /// <summary>
        /// restores Word.
        /// If the program crashed somehow.
        /// Sometimes Word saves it's temporary settings :(
        /// </summary>
        public void RestoreWord()
        {
            try
            {
                int counter = WordApplication.ActiveWindow.Application.CommandBars.Count;
                for (int i = 0; i < counter; i++)
                {
                    try
                    {
                        WordApplication.ActiveWindow.Application.CommandBars[i].Enabled = true;
                    }
                    catch
                    {

                    }
                }
            }
            catch { };

        }

        /// <summary>
        /// internal resize function
        /// utilizes the size of the surrounding control
        /// 
        /// optimzed for Word2000 but it works pretty good with WordXP too.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnResize()
        {
            //The original one that I used is shown below. Shows the complete window, but its buttons (min, max, restore) are disabled
            //// MoveWindow(wordWnd,0,0,this.Bounds.Width,this.Bounds.Height,true);


            ///Change below
            ///The following one is better, if it works for you. We donot need the title bar any way. Based on a suggestion.
            int borderWidth = SystemInformation.Border3DSize.Width;
            int borderHeight = SystemInformation.Border3DSize.Height;
            int captionHeight = SystemInformation.CaptionHeight;
            int statusHeight = SystemInformation.ToolWindowCaptionHeight;
            MoveWindow(
                WordWnd,
                -2 * borderWidth,
                -2 * borderHeight - captionHeight - 5,
                this.Bounds.Width + 4 * borderWidth,
                this.Bounds.Height + captionHeight + 4 * borderHeight + statusHeight - 10,
                true);

        }

        private void OnResize(object sender, System.EventArgs e)
        {
            OnResize();
        }
        public void OnResizeNew()
        {
            if (WordWnd == 0) WordWnd = FindWindow("Opusapp", null);
            SetParent(WordWnd, this.plApplyName.Handle.ToInt32());
            SetWindowPos(WordWnd, this.plApplyName.Handle.ToInt32(), 0, 0, this.Bounds.Width, this.Bounds.Height, SWP_NOZORDER | SWP_NOMOVE | SWP_DRAWFRAME | SWP_NOSIZE);
            int borderWidth = SystemInformation.Border3DSize.Width;
            int borderHeight = SystemInformation.Border3DSize.Height;
            int captionHeight = SystemInformation.CaptionHeight;
            int statusHeight = SystemInformation.ToolWindowCaptionHeight;
            MoveWindow(
                WordWnd,
                -2 * borderWidth,
                -2 * borderHeight - captionHeight - 5,
                this.Bounds.Width + 4 * borderWidth,
                this.Bounds.Height + captionHeight + 4 * borderHeight + statusHeight - 10,
                true);
        }

        /// Required. 
        /// Without this, the command bar buttons that have been disabled 
        /// will remain disabled permanently (does not occur at every machine or every time)
        public void RestoreCommandBars()
        {
            try
            {
                int counter = WordApplication.ActiveWindow.Application.CommandBars.Count;
                for (int i = 1; i <= counter; i++)
                {
                    try
                    {

                        String nm = WordApplication.ActiveWindow.Application.CommandBars[i].Name;
                        if (nm == "Standard")
                        {
                            int count_control = WordApplication.ActiveWindow.Application.CommandBars[i].Controls.Count;
                            for (int j = 1; j <= 2; j++)
                            {
                                WordApplication.ActiveWindow.Application.CommandBars[i].Controls[j].Enabled = true;
                            }
                        }
                        if (nm == "Menu Bar")
                        {
                            WordApplication.ActiveWindow.Application.CommandBars[i].Enabled = true;
                        }
                        nm = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch { }

        }

        /// <summary>
        /// 获取Word进程
        /// </summary>
        /// <param name="pProcess"></param>
        protected void SaveWordProcess(List<int> pProcess)
        {
            if (pProcess == null)
            {
                pProcess = new List<int>();
            }
            Process[] tProcess = Process.GetProcessesByName("WINWORD");
            foreach (Process p in tProcess)
            {
                pProcess.Add(p.Id);
            }
        }

        /// <summary>
        /// 关闭wrod进程
        /// </summary>
        protected void KillWordProcess(List<int> pOldProcess, List<int> pNewProcess)
        {
            try
            {
                foreach (int pid in pNewProcess)
                {
                    if (!pOldProcess.Exists(delegate(int p) { return p == pid; }))
                    {
                        Process ps = Process.GetProcessById(pid);
                        ps.Kill();
                        GC.Collect();
                    }
                }
                pOldProcess.Clear();
                pNewProcess.Clear();
            }
            catch
            {
            }
        }

        public void GoToBookMark(string pMarkName)
        {
            if (this.WordDoc == null || string.IsNullOrEmpty(pMarkName))
            {
                return;
            }

            if (this.WordDoc.Bookmarks.Exists(pMarkName))
            {
                object tBookMarkName = pMarkName;
                object tOperator = Microsoft.Office.Interop.Word.WdGoToItem.wdGoToBookmark;
                object tNothing = Missing.Value;
                this.WordDoc.ActiveWindow.Selection.GoTo(ref tOperator, ref tNothing, ref tNothing, ref tBookMarkName);
            }
        }

        public IList<string> FindBookMarks(string pBeginFilter, string pEndFilter)
        {
            IList<string> tMarks = new List<string>();
            if (this.WordDoc == null)
            {
                return tMarks;
            }

            string tMarkName = string.Empty;
            foreach (Microsoft.Office.Interop.Word.Bookmark mark in this.WordDoc.Bookmarks)
            {
                tMarkName = mark.Name;
                if (!string.IsNullOrEmpty(pBeginFilter) && !string.IsNullOrEmpty(pEndFilter))
                {
                    if (tMarkName.StartsWith(pBeginFilter) && tMarkName.EndsWith(pEndFilter))
                    {
                        tMarks.Add(tMarkName);
                    }
                }
                else if (!string.IsNullOrEmpty(pBeginFilter))
                {
                    if (tMarkName.StartsWith(pBeginFilter))
                    {
                        tMarks.Add(tMarkName);
                    }
                }
                else if (!string.IsNullOrEmpty(pEndFilter))
                {
                    if (tMarkName.EndsWith(pEndFilter))
                    {
                        tMarks.Add(tMarkName);
                    }
                }
                else
                {
                    tMarks.Add(tMarkName);
                }
            }
            return tMarks;
        }

        /// <summary>
        /// 姚龙生  只读模式方式
        /// </summary>
        /// <param name="password"></param>
        public void LockDocument(string password)
        {
            if (WordDoc != null)
            {
                object pw = password;
                WordDoc.Protect(Word.WdProtectionType.wdAllowOnlyComments, ref MissingType.NoReset_False, ref pw);
            }
        }

        public void Save(string path) 
        {
            if (WordDoc != null) 
            {
                WordDoc.SaveAs(path);
                //Process[] tProcess = Process.GetProcessesByName("WINWORD");
                //foreach (var pid in tProcess) 
                //{
                //    Process ps = Process.GetProcessById(pid.Id);
                //    ps.Kill();
                //}

            }
        }

        private void btn_OpenDocument_Click(object sender, EventArgs e)
        {
            //this.btn_OpenDocument.Visible = false;
            //FrmRatingFile frmRatingFile = new FrmRatingFile(this);
            //if (DialogResult.OK != frmRatingFile.ShowDialog())
            //{
            //    this.btn_OpenDocument.Visible = true;
            //    if (ReSet != null) ReSet(null, null);     //复位事件   使打开的word能恢复到之前的窗口中   不加的话新窗口打开的word关闭后不会显示到之前的窗口中
            //}
        }
    }

    public class DocumentInstanceException : Exception
    { }

    public class ValidDocumentException : Exception
    { }

    public class WordInstanceException : Exception
    { }


}

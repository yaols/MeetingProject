using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Meeting.Pc
{
    [ToolboxBitmap(typeof(TextBox))]
    public class WatermarkTextBox : TextBox
    {

        public WatermarkTextBox()
        {
            this.BorderStyle = BorderStyle.FixedSingle;
        }


        private Color _borderColor = Color.Red;
        private string _watermarkTitle;
        private Color _watermarkColor = Color.DarkGray;

        /// <summary>
        /// 水印字体提示
        /// </summary>
        public string WatermarkTitle
        {
            get { return _watermarkTitle; }
            set
            {
                _watermarkTitle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// 边框颜色
        /// </summary>
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// 水印颜色
        /// </summary>
        public Color WatermarkColor
        {
            get { return _watermarkColor; }
            set
            {
                _watermarkColor = value;
                Invalidate();
            }
        }

        protected override void WndProc(ref Message m)
        {

            base.WndProc(ref m);
            if (m.Msg == 0xf || m.Msg == 0x14 || m.Msg == 0x85)
            {
                if (this.BorderStyle == BorderStyle.FixedSingle)
                {
                    using (Graphics g = Graphics.FromHwnd(this.Handle))
                    {
                        using (var pen = new Pen(_borderColor))
                        {
                            g.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
                            WmPaint(ref m);
                        }
                    }
                }
            }
        }

        private void WmPaint(ref Message m)
        {
            using (Graphics graphics = Graphics.FromHwnd(base.Handle))
            {
                if (Text.Length == 0
                    && !string.IsNullOrEmpty(_watermarkTitle)
                    && !Focused)
                {
                    TextFormatFlags format =
                        TextFormatFlags.EndEllipsis |
                        TextFormatFlags.VerticalCenter;

                    if (RightToLeft == RightToLeft.Yes)
                    {
                        format |= TextFormatFlags.RightToLeft | TextFormatFlags.Right;
                    }

                    TextRenderer.DrawText(
                        graphics,
                        _watermarkTitle,
                        Font,
                        base.ClientRectangle,
                        _watermarkColor,
                        format);
                }
            }
        }
    }
}

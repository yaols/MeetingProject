$(document).ready(function () {
    var myDate = new Date();

    $('#datetimepicker1').datetimepicker({
        dayOfWeekStart: 1,
        lang: 'en',
        disabledDates: ['1986/01/08', '1986/01/09', '1986/01/10'],
        startDate: getNowFormatDate()
    });

    $('#datetimepicker2').datetimepicker({
        dayOfWeekStart: 1,
        lang: 'en',
        disabledDates: ['1986/01/08', '1986/01/09', '1986/01/10'],
        startDate: getNowFormatDate()
    });

    $('#datetimepicker1').datetimepicker({ value: myDate.toLocaleTimeString(), step: 10 });
    $('#datetimepicker2').datetimepicker({ value: myDate.toLocaleTimeString(), step: 10 });



        //$('#file_upload').uploadify({
        //    'swf': '/Scripts/uploadify/uploadify.swf',
        //    'uploader': '/Upload/Index',
        //    'onUploadStart': function (file) {
        //        var htmlString = '<li class="create-ul-li"><div class="create-li-img">';
        //        if (file.type == '.txt' || file.type == '.doc' || file.type == '.docx') {
        //            htmlString += '<img src="/Images/文本资料.png" /></div>';
        //        } else if (file.type == '.png' || file.type == '.jpg' || file.type == '.gif' || file.type == '.bmp' || file.type == '.jpeg') {
        //            htmlString += '<img src="/Images/图片资料.png" /></div>';
        //        } else if (file.type == '.mp4' || file.type == '.wmv' || file.type == '.amv' || file.type == '.mp3') {
        //            htmlString += '<img src="/Images/视频资料.png" /></div>';
        //        } else if (file.type == '.mp3') {
        //            htmlString += '<img src="/Images/音频资料.png" /></div>';
        //        } else {
        //            htmlString += '<img src="/Images/文本资料.png" /></div>';
        //        }

        //        htmlString += '<div class="create-li-btnDel" onclick="CreateDel(this,\'' + file.name + '\')">删除</div>';
        //        htmlString += '<span style="display: inline-block;">' + file.name + '</span></li>';

        //        $("#imgul").append(htmlString);
        //        lhgdialog.masklayer();
        //    }
    //});

        $(".upload-img1").InitUploader({
        filesize: "10240",
        sendurl: "/Upload/Index",
        swf: "/scripts/webuploader/uploader.swf",
        water: true,
        filetypes: "",
        uploadSuccess: function (file) {
            console.log(file);
            var htmlString = '<li class="create-ul-li"><div class="create-li-img">';
            if (file.type == '.txt' || file.type == '.doc' || file.type == '.docx') {
                htmlString += '<img src="/Images/文本资料.png" /></div>';
            } else if (file.type == '.png' || file.type == '.jpg' || file.type == '.gif' || file.type == '.bmp' || file.type == '.jpeg') {
                htmlString += '<img src="/Images/图片资料.png" /></div>';
            } else if (file.type == '.mp4' || file.type == '.wmv' || file.type == '.amv' || file.type == '.mp3') {
                htmlString += '<img src="/Images/视频资料.png" /></div>';
            } else if (file.type == '.mp3') {
                htmlString += '<img src="/Images/音频资料.png" /></div>';
            } else {
                htmlString += '<img src="/Images/文本资料.png" /></div>';
            }

            htmlString += '<div class="create-li-btnDel" onclick="CreateDel(this,\'' + file.name + '\')">删除</div>';
            htmlString += '<span style="display: inline-block;">' + file.name + '</span></li>';

            $("#imgul").append(htmlString);
            lhgdialog.masklayer();
        }
    });

        $('#file_upload-button').removeClass("uploadify-button");
        $("#file_upload-button").removeAttr("style");
        $('#file_upload-button').addClass("create-button2");

})

var config = {
    '.chosen-select': {},
    '.chosen-select-deselect': { allow_single_deselect: true },
    '.chosen-select-no-single': { disable_search_threshold: 10 },
    '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
    '.chosen-select-width': { width: "95%" }
}
for (var selector in config) {
    $(selector).chosen(config[selector]);
}

function returnTop() {
    location.href = "/Home/Index?pageindex=" + 1;
}


function CreateDel(Id, name) {
    lhgdialog.masklayer('loading.gif');
    $.post('/MeetingInfo/DelCreate',
       {
           filename: name
       }, function (data) {
           if (data.Result == 0) {
               $(Id).parent().remove();
           }
           mh_dialogShow('mh_success', data.Msg, 1, true);
           lhgdialog.masklayer();
       });
}

//保存数据
function PostCreateMeeting() {
    var model = new Object();
    model.year = $("#year").val();
    model.count = $("#count").val();
    model.numcount = $("#numcount").val();
    model.datetimepicker1 = $("#datetimepicker1").val();
    model.datetimepicker2 = $("#datetimepicker2").val();


    var begin = new Date(model.datetimepicker1.replace(/-/g, "/"));
    var end = new Date(model.datetimepicker2.replace(/-/g, "/"));
    //js判断日期
    if (begin - end > 0) {
        alert("开始日期不能大于结束日期!");
        return false;
    }


    model.address = $("#address").val();
    model.hoseUser = $("#hoseUser").find("option:selected").attr("id");
    model.record = $("#recorder").find("option:selected").attr("id");
    model.secretary = $("#secretary").find("option:selected").attr("id");

    //参会委员
    model.people = "";
    $('#meetingPeople_chosen .search-choice').each(function (i, data) {
        model.people = model.people + $(this).attr("data-value") + ",";
    });

    //请假者
    model.leavePeople = "";
    $('#leavePeople_chosen .search-choice').each(function (i, data) { 
        model.leavePeople = model.leavePeople + $(this).attr("data-value") + ",";
    });

    //列席者
    model.attendPeople = "";
    $('#attendPeople_chosen .search-choice').each(function (i, data) {
        model.attendPeople = model.attendPeople + $(this).attr("data-value") + ",";
    });

    model.filearray = "";
    $('.create-ul-li').each(function (i, data) {
        model.filearray = model.filearray + $(this).text().replace('删除', '') + ",";
    });

    model.issue = $("#issue").val();
    //model.depart = $("#depart").find("option:selected").attr("id");
    model.report = $("#report").find("option:selected").attr("id");
    model.newDepartName = $("#newDepartName").val();

    lhgdialog.masklayer('loading.gif');
    $.post('/MeetingInfo/MeetingCreate',
        {
            json: JSON.stringify(model)
        }, function (data) {
            if (data.Result == 0)
                location.href = "/Home/Index?pageindex=" + 1;
            mh_dialogShow('mh_success', data.Msg, 1, true);
            lhgdialog.masklayer();
        });
}

//获取当前时间
function getNowFormatDate() {
    var date = new Date();
    var seperator1 = "-";
    var seperator2 = ":";
    var month = date.getMonth() + 1;
    var strDate = date.getDate();
    if (month >= 1 && month <= 9) {
        month = "0" + month;
    }
    if (strDate >= 0 && strDate <= 9) {
        strDate = "0" + strDate;
    }
    var currentdate = date.getFullYear() + seperator1 + month + seperator1 + strDate
            + " " + date.getHours() + seperator2 + date.getMinutes()
            + seperator2 + date.getSeconds();
    return currentdate;
}
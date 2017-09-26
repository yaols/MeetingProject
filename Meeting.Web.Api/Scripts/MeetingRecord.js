$(document).ready(function () {
    //参会委员
    var committee = $("input[name='committee']").val();
    //请假人员
    var leave = $("input[name='leave']").val();
    //出席者
    var attend = $("input[name='attend']").val();

    chose_mult_set_ini('#meetingPeople',committee);
    $("#meetingPeople").chosen();
    chose_mult_set_ini('#leavePeople', leave);
    $("#leavePeople").chosen();
    chose_mult_set_ini('#attendPeople', attend);
    $("#attendPeople").chosen();

  

    $('#datetimepicker1').datetimepicker({
        dayOfWeekStart: 1,
        lang: 'en',
        disabledDates: ['1986/01/08', '1986/01/09', '1986/01/10'],
    });

    $('#datetimepicker2').datetimepicker({
        dayOfWeekStart: 1,
        lang: 'en',
        disabledDates: ['1986/01/08', '1986/01/09', '1986/01/10'],
    });



    var editor = new wangEditor('editor');
    editor.create();

    var meetingId=$("input[name='meetingId']").val();

    //保存单机事件
    $("#recordSave").click(function () {
        PostCreateMeeting(editor.$txt.html(), meetingId);
    })

    $("#preview").click(function () {
        location.href = "/MeetingInfo/MeetingPreview?MeetingId=" + meetingId;
    })
    
    $("#refresh").click(function () {
        lhgdialog.masklayer('loading.gif');
        $.get("/MeetingInfo/GetMeetingOpinion", { meetingId: meetingId }, function (data) {
            if (data != null) {
                var str = '';
                var msg = "";
                for (var i = 0; i < data.length; i++) {
                    if (data[i].OpinionAction == 0) {
                        msg = "未处理";
                    }
                    else if (data[i].OpinionAction == 1) {
                        msg = "同意";
                    }
                    else {
                        msg = "不同意";
                    }
                    str += '<div style="margin: 5px 10px 0 10px;">';
                    str += '<div style="display: inline-block; width:100px;">委员：' + data[i].UserName + '</div>';
                    str += '<div style="display: inline-block; padding-left:15px;">审批意见：' + msg + '</div>';
                    str += '<textarea style="width:980px;height:120px;" disabled="disabled">' + data[i].OpinionMsg + '</textarea>';
                    str += '</div>';
                }
                $("#operation").empty();
                $("#operation").append(str);
                mh_dialogShow('mh_success',"刷新成功", 1, true);
                lhgdialog.masklayer();
            }
        });

    
    })

});


// 多选 select 数据初始化
function chose_mult_set_ini(select, values) {
    var arr = values.split(',');
    var length = arr.length;
    var value = '';
    for (i = 0; i < length; i++) {
        value = arr[i];
        $(select + " option[value='" + value + "']").attr('selected', 'selected');
    }
    $(select).trigger("liszt:updated");
}

//链接跳转
function retrunBtn(url) {
    location.href = url;
}


//保存数据
function PostCreateMeeting(htmlContent, meetingId) {
    var model = new Object();
    model.year = $("#year").val();
    model.count = $("#count").val();
    model.numcount = $("#numcount").val();
    model.datetimepicker1 = $("#datetimepicker1").val();
    model.datetimepicker2 = $("#datetimepicker2").val();
    model.meetingId = meetingId;

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

    model.editor = htmlContent;

    console.log(JSON.stringify(model));

    lhgdialog.masklayer('loading.gif');
    $.post('/MeetingInfo/MeetingRecord',
        {
            json:JSON.stringify(model)
        }, function (data) {
            if (data.Result == 0) {
              
                location.href = "/MeetingInfo/Index?MeetingId=" + model.meetingId;
            }
                
            mh_dialogShow('mh_success', data.Msg, 1, true);
            lhgdialog.masklayer();
        });


}
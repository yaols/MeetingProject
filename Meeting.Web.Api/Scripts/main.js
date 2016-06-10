/*登陆*/
function Login() {
    var username = $("#username");
    var userpass = $("#userpass");

    if (username.val() == '') {
        alert("用户名不能为空！");
        username.focus();
        return;
    }

    if (userpass.val() == '') {
        alert("用户名不能为空！");
        userpass.focus();
        return;
    }

    $.post("/Login/UserLogin",
        {
            UserName: username.val(),
            UserPass: userpass.val()
        },
        function (data) {
            alert(data.Msg);
            if (data.Result == 0)
                location.href = "/home/index?pageindex="+1;
        });
}


/*开始会议*/
function startMeeting() {
    $("#startMeeting").css("background-color", "#ffcc66");
    $("#endMeeting").css("background-color", "#ffffff");
    $("#createMeeting").css("background-color", "#ffffff");
    clickMeeting(1,0);
}

/*鼠标移动事件*/
function mouseoverMeeting(type) {
    if (type == 1)
    {
        $("#startMeeting").css("background-color", '#ffcc66');
        $("#startMeeting").css("font-weight", 'bold');
        $("#startMeeting").css("color", 'black');

        $("#endMeeting").css("background-color", '#ffffff');
        $("#endMeeting").css("font-weight", 'none');
        $("#endMeeting").css("color", '#7d7d7d');

        $("#createMeeting").css("background-color", '#ffffff');
        $("#createMeeting").css("font-weight", 'none');
        $("#createMeeting").css("color", '#7d7d7d');
    }
    else if (type == 2)
    {
        $("#startMeeting").css("background-color", 'ffffff');
        $("#startMeeting").css("font-weight", 'none');
        $("#startMeeting").css("color", '#7d7d7d');

        $("#endMeeting").css("background-color", '#ffcc66');
        $("#endMeeting").css("font-weight", 'bold');
        $("#endMeeting").css("color", 'black');

        $("#createMeeting").css("background-color", '#ffffff');
        $("#createMeeting").css("font-weight", 'none');
        $("#createMeeting").css("color", '#7d7d7d');
    }
    else if (type == 3)
    {
        $("#startMeeting").css("background-color", 'ffffff');
        $("#startMeeting").css("font-weight", 'none');
        $("#startMeeting").css("color", '#7d7d7d');

        $("#endMeeting").css("background-color", '#ffffff');
        $("#endMeeting").css("font-weight", 'none');
        $("#endMeeting").css("color", '#7d7d7d');

        $("#createMeeting").css("background-color", '#ffcc66');
        $("#createMeeting").css("font-weight", 'bold');
        $("#createMeeting").css("color", 'black');
    }
}

/*结束会议*/
function endMeeting() {

    clickMeeting(1,1);
}

/*创建会议*/
function createMeeting() {

}

function clickMeeting(pageIndex,meetingType) {
    $.post("/Home/Index", { PageIndex: "" + pageIndex + "", pageType: 1, MeetingType: meetingType }, function (data) {
        $('#home-main').empty();
        $('#home-main').append(data);
    });
}
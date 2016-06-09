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
                location.href = "/home/index";
        });
}
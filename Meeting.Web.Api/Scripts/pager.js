//首页分页点击事件
function firstClick() {
    clickPage(1);
}

//上一页分页点击事件
function lastClick() {
    var pageIndex = $('#hidPageIndex').attr('value'); //当前索引
    if (parseInt(pageIndex) - 1 <= 0) return;
    clickPage(parseInt(pageIndex) - 1);
}

//下一页分页点击事件
function nextClick() {
    var pageIndex = $('#hidPageIndex').attr('value'); //当前索引
    var pagesize = $('#hidPageSize').attr('value');//总页数
    if (parseInt(pageIndex) + 1 > parseInt(pagesize)) return;
    clickPage(parseInt(pageIndex) + 1);
}

//尾页分页点击事件
function endClick() {
    var pagesize = $('#hidPageSize').attr('value');//总页数
    clickPage(parseInt(pagesize));
}

//分页点击事件
function clickPage(pageIndex) {
    $.post(ClickPageUrl, { PageIndex: "" + pageIndex + "", Id: "" + $('#pagerId').attr('value') + "" }, function (data) {
        $('#home-main').empty();
        $('#home-main').append(data);
    });
}

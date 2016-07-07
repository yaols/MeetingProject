/*
*作者：李凯
*日期：2013-04-23
名称：
    1、类别选择弹出框
    2、遮罩层
注释:依赖jquery1.4.4以上版本库、lhgdialog.min.js弹出库插件
*/
/*1、类别选择弹出框*/
(function ($) {
    $.fn.categoryDialog = function (options) {
        $.fn.categoryDialog.defaults = {
            moduleType: 1,
            subLib: 'CHL',
            property: '',
            title: '类别维护',
            width: 400,
            height: 300,
            url: '',
            close:""
        };
        var opts = $.extend({}, $.fn.categoryDialog.defaults, options);
        if (typeof (opts.moduleType) == "undefined" || typeof (opts.subLib) == "undefined" || typeof (opts.property) == "undefined") {
            alert('参数初始化失败');
            return false;
        }

        var url = opts.url + "?lib=" + opts.subLib + "&property=" + opts.property + "&timespan=" + new Date();
        $.dialog({ id: 'CategoryDialog', title: opts.title, width: opts.width, height: opts.height, lock: true, max: false, min: false,
            content: 'url:' + url,close: function() {
                opts.close();
            }
        });
    };

    /*2、遮罩层
    调用方法：
    显示遮罩：$.lhgdialog.masklayer('loading.gif');
    （loading.gif存放在lhgdialog/skins/icons/目录下）
    移除遮罩：$.lhgdialog.masklayer();
    */

    var _zIndex = function () {
        return lhgdialog.setting.zIndex;
    };
    lhgdialog.masklayer = function (icon) {
        var showOrNot = icon ?
        function () {
            return lhgdialog({
                id: 'marklayer',
                zIndex: _zIndex(),
                title: false,
                cancel: false,
                fixed: true,
                lock: true,
                resize: false
            }).content("数据加载中...").time(null, function () {
                this.DOM.icon[0].innerHTML = '<img src="' + this.config.path + 'skins/icons/' + icon + '" class="ui_icon_bg"/>';
                this.DOM.icon[0].style.display = '';
            });
        } : function () {
            if (lhgdialog.list["marklayer"] != null) {
                lhgdialog.list["marklayer"].close();
            }
        };
        showOrNot();
    };
})(jQuery);
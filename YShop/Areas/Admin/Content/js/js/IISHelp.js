var siteName = "Web";

function getUrl() {
    var url = "?navtypeid=" + navtypeid + "&menu=" + menu + "&Source=" + Source + "&siteName=" + siteName;
    window.location.href = "/SiteIISSettings/index" + url;
}

$(function () {
    $("#Sel_SiteName").change(function () {
        siteName = $.trim($(this).val())
        getUrl();
    });

    $("#Btn_Save").click(function () {
        var site = $.trim($("#Sel_SiteName").val());
        var urlList = $.trim($("#Txt_WebUrl").val());
        $.ajax({
            url: "/SiteIISSettings/UpdateIndex",
            type: "post",
            data: {siteName:site,urlList:urlList},
            success:function (d)
            {
                alert(d)
                if (d == "修改成功")
                {
                    window.location.reload();
                }
            }
        })
    });
});
function btnGotoPage(url, Target) {
    var menupid = $("#menupid_Laout").val();
    var menuid = $("#menuid_Laout").val();
    if (url.indexOf("?") > 0) {
        url += "&menupid=" + menupid + "&menuid=" + menuid;
    }
    else {
        url += "?menupid=" + menupid + "&menuid=" + menuid;
    }
    if (Target == "_blank") {
        window.open(url,"_blank");
    }
    else {
        location.href = url;
    }
    
}
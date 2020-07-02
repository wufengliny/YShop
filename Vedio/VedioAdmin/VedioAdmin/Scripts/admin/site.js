function CheckSafeCode(code) {
    var flag = false;
    $.ajax({
        type: 'POST',
        url: '/user/CheckSafeCode',
        data: { SafeCode: code },
        async:false,
        success: function (data) {
            if ("success" == data) {
                flag = true;
            }
            else {
                alert(data);
                flag = false;
            }
        }
    });
    return flag;
}
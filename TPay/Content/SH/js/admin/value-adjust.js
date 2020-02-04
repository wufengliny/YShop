/********************修改所有text begin********************/
function Raise() {
    $('input[type=text]', 'form').each(function (index, item) {
        $(item).val(Number($(item).val()) + Number($('#texRate').val()));
    });
}
function Lowered() {
    $('input[type=text]', 'form').each(function (index, item) {
        var value = Number($(item).val()) - Number($('#texRate').val());
        if (value < 0)
            value = 0
        $(item).val(value);
    });
}
function Unity() {
    $('input[type=text]', 'form').each(function (index, item) {
        $(item).val(Number($('#texRate').val()));
    });
}
/********************修改所有text end********************/
/********************修改选中的text begin********************/
function RaiseCheck() {//增加
    //if ($("input[type='checkbox']").is(":checked") == false) {
    //    alert("请勾选调高的项");
    //}
    $('input[type=text]', 'form').each(function (index, item) {
        if ($(item).attr("id") != undefined && $('#' + $(item).attr("id").replace("textbox", "check")).is(":checked")) {
            $(item).val(Number($(item).val()) + Number($('#texRate').val()));
        }
    });
}
function LoweredCheck() {//减少
    $('input[type=text]', 'form').each(function (index, item) {
        if ($(item).attr("id") != undefined && $('#' + $(item).attr("id").replace("textbox", "check")).is(":checked")) {
            var value = Number($(item).val()) - Number($('#texRate').val());
            if (value < 0)
                value = 0
            $(item).val(value);
        }
    });
}
function UnityCheck() {//统一
    $('input[type=text]', 'form').each(function (index, item) {
        if ($(item).attr("id") != undefined && $('#' + $(item).attr("id").replace("textbox", "check")).is(":checked")) {
            $(item).val(Number($('#texRate').val()));
        }
    });
}
/********************修改选中的text end********************/


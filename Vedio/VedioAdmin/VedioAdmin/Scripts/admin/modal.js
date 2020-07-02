$(function () {
    Showdialog();
});
function Showdialog() {
    
    $(".ht-dialog-div").hide();
    $('.ht-dialog-div').css({ index: '10000', top: '50%', position: 'fixed', left: '50%', margin: '-' + ($('.ht-dialog-div').height() / 2) + 'px 0 0 -' + ($('.ht-dialog-div').width() / 2) + 'px' });
    $('.ht-dialog-main').css({ index: '10000', top: '50%', position: 'fixed', left: '50%', margin: '-' + ($('#ht-dialog-main').height() / 2) + 'px 0 0 -' + ($('#ht-dialog-main').width() / 2) + 'px' });
    $('#myDaMaLiang').css({ index: '10000', top: '20%', position: 'absolute', left: '50%', margin: '-' + ($('#myDaMaLiang').height() / 2) + 'px 0 0 -' + ($('#myDaMaLiang').width() / 2) + 'px' });
    $('#resultModal').css({ index: '10000', top: '20%', position: 'fixed', left: '50%', margin: '-' + ($('#resultModal').height() / 2) + 'px 0 0 -' + ($('#resultModal').width() / 2) + 'px' });
}
function Modal(value) {
    if (value == "show") {
        $(".ht-dialog-div").show();
    }
    else if (value == "hide") {
        $(".ht-dialog-div").hide();
    }

}

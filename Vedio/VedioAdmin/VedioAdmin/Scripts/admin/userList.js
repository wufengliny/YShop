function UpdState(sender, ID, Account, enable) {
    var result = window.confirm('确定' + (enable == 1 ? '启用' : '禁用') + '会员：' + Account + '?');
    if (result === true) {
        if (enable == 1) {
            //启用无需备注
            $.ajax({
                type: 'POST',
                url: '/user/delete',
                data: { id: ID, enable: enable },
                success: function (data) {
                    if ("success" == data) {
                        $("#EB" + ID).html("<font color=green>正常</font>");
                        $("#EBA" + ID).attr("onclick", "UpdState(this," + ID + ",'" + Account + "',0)");
                    }
                    else {
                        alert(data);
                    }
                }
            });
        } else {
            $("#userID").val(ID);
            $("#userAccount").val(Account);
            $("#updMemo").show();
        }
    }
}

function UserModalClose() {
    $("#myDaMaLiang").hide();
}
function myModalresetClose() {
    $("#resetresult").html();
    $('#myModalreset').hide();
}
function StatBet(ID) {
    $('#myModalLabel').html("打码量");
    $('#ModalContent').load("/Bet/BetStat?UserID=" + ID);
    $("#myDaMaLiang").show();
}

function ShowResetPass(id, account) {

    $("#resetaccount").html(account);
    $("#resetpassuserid").val(id);
    $(":checked").attr("checked", false);
    $("#ChangeLoginPass").val($("#hidDefaultLoginPass").val());
    $("#ChangeMoneyPass").val($("#hidDefaultChangeMoneyPass").val());
    $("#ChangeLoginPass").attr("disabled", true);
    $("#ChangeMoneyPass").attr("disabled", true);
    $("#resetresult").html();
    $("#myModalreset").show();
}




function PassDisableInput(sender, txtpass) {
    if ($(sender).is(':checked')) {
        $("#" + txtpass).attr("disabled", false);
    }
    else {
        $("#" + txtpass).attr("disabled", true);
    }
}

function UpdUserMemo() {
    if ($("#enableMemo").val() == "") {
        alert("请输入禁用备注");
    } else {
        $("#updMemo").hide();
        $.ajax({
            type: 'POST',
            url: '/user/delete',
            data: { id: $("#userID").val(), enable: 0, memo: $("#enableMemo").val() },
            success: function (data) {
                if (data == "success") {
                    $("#EB" + $("#userID").val()).html("<font color=red>禁用</font>");
                    //$("#EBA" + $("#userID").val()).attr("class", "icon-qd");
                    $("#EBA" + $("#userID").val()).attr("onclick", "UpdState(this," + $("#userID").val() + ",'" + $("#userAccount").val() + "',1)");
                } else {
                    alert(data);
                }
                $("#updMemo").hide();
            }
        });
    }
}
function CloseUserMemo() {
    $("#updMemo").hide();
}

function SendMoney(id, account) {
    if (confirm("确定要为【" + account + "】派送彩金吗？")) {
        $.ajax({
            type: 'POST',
            url: '/Deposit/SendMoney',
            data: { id: id, account: account },
            success: function (result) {
                if ("success" == result) {
                    alert("操作成功");
                    location = location;
                }
                else {
                    alert(result);
                }
            }
        });
    }
}
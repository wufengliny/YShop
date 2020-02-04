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

function ResetPass() {
    if ($("#IsChangeLoginPass").is(":checked") || $("#IsChangeMoneyPass").is(":checked")) {
        if (confirm("重置后请及时告知相关会员,确定重置密码?")) {
            $.ajax({
                type: 'POST',
                url: '/user/ResetPass',
                data: {
                    id: $("#resetpassuserid").val(),
                    account: $("#resetaccount").html(),
                    IsChangeLoginPass: $("#IsChangeLoginPass").is(":checked"), LoginPass: $("#ChangeLoginPass").val(),
                    IsChangeMoneyPass: $("#IsChangeMoneyPass").is(":checked"), MoneyPass: $("#ChangeMoneyPass").val()
                },
                success: function (data) {
                    if ("success" == data) {
                        $("#resetresult").html("重置成功");
                    }
                    else {
                        $("#resetresult").html(data);
                    }
                }
            });
        }
    }
    else {
        alert("请选择要重置的密码类型");
    }
}


function PassDisableInput(sender, txtpass) {
    if ($(sender).is(':checked')) {
        $("#" + txtpass).attr("disabled", false);
    }
    else {
        $("#" + txtpass).attr("disabled", true);
    }
}
function UpdateUserActiveTime() {
    $.ajax({
        type: 'GET',
        url: '/user/UpdateUserActiveTime',
        success: function (data) {
            if ("success" == data) {
                alert("更新用户状态成功");
            }
        }
    });
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
function CheckInfo(ID) {
    $('#myModalLabel').html("检查重复");
    $('#ModalContent').load("/user/CheckInfo?id=" + ID);
    $("#myDaMaLiang").show();
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
/*********************************************************
* 弹出角色选择窗口
* 返回选择的行的对象集合
* 用法：$.selectUsers({ singleSelect: false }, function (data) {});
* *******************************************************/

$.selectUsers = function (options, callback) {
    var settings = $.extend({
        singleSelect: true,
        selections: null
    }, options || {});

    //添加DOM
    var html = "<div id='create_dialog'>";
    html += "<table id='create_grid'></table>";
    html += "<div id='create_toolbur'>";
    html += "<table>";
    html += "<tr><td>公司：<input id='create_company' hidId='0' style='width:135px' /></td><td>部门：<input id='create_department'/></td><td><a id='create_clear' href='javascript:void(0)'>清空</a></td></tr>";
    html += "<tr><td>班组：<input id='create_class' hidId='0' style='width:135px' /></td><td title=\"姓名支持拼音首字母缩写查询,如：张三 输入zs就可以查询出来\">姓名：<input title=\"姓名支持拼音首字母缩写查询,如：张三 输入zs就可以查询出来\" id='create_name' style='width:135px'/></td><td><a id='create_search' href='javascript:void(0)'>查询</a></td></tr>";
    html += "</table>";
    html += "</div>";
    $("body").append(html);

    //弹出层
    $('#create_dialog').dialog({
        width: 485,
        height: 408,
        title: '用户列表',
        toolbar: '#create_toolbur',
        modal: true,
        closable: false,
        collapsible: false,
        minimizable: false,
        maximizable: false,
        border: false,
        buttons: [{
            text: '确定',
            handler: function () {
                var selected = $("#create_grid").datagrid('getSelections');
                callback($("#create_grid").datagrid('getSelections'));
                $('#create_dialog').dialog('destroy');
            }
        }, {
            text: '取消',
            handler: function () {
                $('#create_dialog').dialog('destroy');
            }
        }
        ]
    }).dialog('open');

    //列表
    $("#create_grid").datagrid({
        url: '/SYS/Handler/UserList/UserList.ashx',
        idField: 'ID',
        rownumbers: true,
        singleSelect: settings.singleSelect,
        fitColumns: true,
        fit: true,
        border: false,
        pagination: true,
        pageSize: 20,
        autoRowHeight: false,
        columns: [[{
            field: 'ID',
            checkbox: true
        }, {
            field: 'Name',
            title: '姓名',
            width: 35
        }, {
            field: 'CompanyName',
            title: '公司',
            width: 100
        }, {
            field: 'ClassName',
            title: '班组',
            width: 65
        }
        ]]
    });

    //查询部门
    $("#create_department").combobox({
        url: '/SYS/Handler/Department/Combobox.ashx',
        textField: 'Name',
        valueField: 'ID',
        editable: false,
        width: 135
    });

    //查询
    $("#create_search").click(function () {
        $("#create_grid").datagrid('load', {
            CompanyName: $("#create_company").val(),
            DepartmentID: $("#create_department").combobox('getValue'),
            ClassName: $("#create_class").val(),
            Name: $("#create_name").val()
        });
    }).linkbutton({
        iconCls: 'icon-search'
    });

    //清空
    $("#create_clear").click(function () {
        $("#create_department").combobox('clear');
        $("#create_company,#create_class,#create_name").val("");
        $("#create_grid").datagrid('load', {});
    }).linkbutton();

    //$("#create_grid").datagrid('load', { Name: value, GroupID: $("#create_group").combobox('getValue') });
}
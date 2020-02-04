//全选 全不选
function kaycheckAll(obj, classname)
{
    if ($(obj).prop("checked"))
    {
        $("." + classname).prop("checked", "checked")
    }
    else {
        $("."+ classname).prop("checked", "")
    }
}

//obj 当前点击的复选框对象  classname：父级复选框   childClassname：当前点击的复选框的classname
//自己点有选择  父节点必须跟着选择  自己点一个都没有选择 父节点取消选择
function KayCheckParent(obj, classname,childClassname)
{
    if ($(obj).prop("checked"))
    {
        $("." + classname).prop("checked", "checked");
    }
    var isnochek = true;
    $("." + childClassname).each(function () {
        if ($(this).prop("checked"))
        {
            isnochek = false;
        }
    })
    if(isnochek)
    {
        $("." + classname).prop("checked", "")
    }
}
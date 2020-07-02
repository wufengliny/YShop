function CreateSelect(ID,Name,Url,SelectID,Change)
{
    var html = "";
    $.ajax({
        url: Url,
        type: "GET",
        async: false,
        success: function (data) {
            html = " <select name='" + Name + "' onchange='" + Change + "'>";
            html = html + "<option>==请选择==</option>";
            for (var i = 0; i < data.Count; i++)
            {
                if (data.Rows[i].ID == SelectID) {
                    html = html + "<option selected='selected' value='" + data.Rows[i].ID + "'>" + data.Rows[i].Name + "</option>";
                }
                else {
                    html = html + "<option value='" + data.Rows[i].ID + "'>" + data.Rows[i].Name + "</option>";
                }
            }
            html = html + "</select>";
            $('#' + ID).html(html);
        }
    });
}
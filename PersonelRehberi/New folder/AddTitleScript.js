function addTitle() {
    var TitleName = $("#TitleName1").val();
    var TitleDescription = $("#TitleDescription").val();
    $.ajax({
        type: "POST",
        url: "CreateTitle",
        data: "{TitleName:'" + TitleName +
            "',TitleDescription:'" + TitleDescription +
             "'}",
        contentType: "application/json; charset=utf-8",
        datatype: "jsondata",
        async: "true",
        success: function (response) {
            $(".errMsg ul").remove();
            
            var myObject = eval('(' + response.d + ')');

            if (myObject > 0) {
                bindData();
                $('#tgrid').jqxGrid('updatebounddata');
                $(".errMsg").append("<ul><li>Data saved successfully</li></ul>");
            }
            else {
                $(".errMsg").append("<ul><li>Opppps something went wrong.</li></ul>");
            }
            $("#popupWindowTitle").jqxWindow('hide');
            $(".errMsg").show("slow");
        },
        error: function (response) {
            alert(response.status + ' ' + response.statusText);
        }
    });


}
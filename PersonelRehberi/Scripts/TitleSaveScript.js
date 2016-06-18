function titlesaveData() {

    //==== Call validateData() Method to perform validation. This method will return 0 
    //==== if validation pass else returns number of validations fails.

    // var errCount = validateData();
    //==== If validation pass save the data.

    var TitleId = $("#TitleId").val();
    var TitleName = $("#TitleName1").val();
    var TitleDescription = $("#TitleDescription").val();
    $.ajax({
        type: "POST",
        url: "saveDataTitle",
        data: "{TitleId:'" + TitleId +
            "',TitleName:'" + TitleName +
            "',TitleDescription:'" + TitleDescription +
             "'}",
        contentType: "application/json; charset=utf-8",
        datatype: "jsondata",
        async: "true",
        success: function (response) {
            $(".errMsg ul").remove();
            //var dataAdapter = new $.jqx.dataAdapter(source);
            //('#jqxgrid').jqxgrid.({source,dataAdapter});
            var row = {
                TitleId: $("#TitleId").val(),
                TitleName: $("#TitleName1").val(),
                TitleDescription: $("#TitleDescription").val(),
            }

            var myObject = eval('(' + response.d + ')');

            if (myObject > 0) {
                bindData();
               $('#tgrid').jqxGrid('updatebounddata');

                //var rowID = $('#grid').jqxGrid('getrowid', editrow);

                $(".errMsg").append("<ul><li>Data saved successfully</li></ul>");
            }
            else {
                $(".errMsg").append("<ul><li>Opppps something went wrong.</li></ul>");
            }
            //$('#grid').jqxGrid('updaterow', rowID, row);

            $("#popupWindowTitle").jqxWindow('hide');
            $(".errMsg").show("slow");
            //myObject.clear();
        },
        error: function (response) {
            alert(response.status + ' ' + response.statusText);
        }
    });

}
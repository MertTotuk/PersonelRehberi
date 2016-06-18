function departmentsaveData() {

    //==== Call validateData() Method to perform validation. This method will return 0 
    //==== if validation pass else returns number of validations fails.

    // var errCount = validateData();
    //==== If validation pass save the data.

    var DepartmentId = $("#DepartmentId").val();
    var DepartmentName = $("#DepartmentName1").val();
    var DepartmentDescription = $("#DepartmentDescription").val();
    $.ajax({
        type: "POST",
        url: "saveDataDepartment",
        data: "{DepartmentId:'" + DepartmentId +
            "',DepartmentName:'" + DepartmentName +
            "',DepartmentDescription:'" + DepartmentDescription +
             "'}",
        contentType: "application/json; charset=utf-8",
        datatype: "jsondata",
        async: "true",
        success: function (response) {
            $(".errMsg ul").remove();
            //var dataAdapter = new $.jqx.dataAdapter(source);
            //('#jqxgrid').jqxgrid.({source,dataAdapter});
            var row = {
                TitleId: $("#DepartmentId").val(),
                TitleName: $("#DepartmentName").val(),
                TitleDescription: $("#DepartmentDescription").val(),
            }

            var myObject = eval('(' + response.d + ')');

            if (myObject > 0) {
                bindData();
                $('#dgrid').jqxGrid('updatebounddata');

                //var rowID = $('#grid').jqxGrid('getrowid', editrow);

                $(".errMsg").append("<ul><li>Data saved successfully</li></ul>");
            }
            else {
                $(".errMsg").append("<ul><li>Opppps something went wrong.</li></ul>");
            }
            //$('#grid').jqxGrid('updaterow', rowID, row);

            $("#popupWindowDepartment").jqxWindow('hide');
            $(".errMsg").show("slow");
            //myObject.clear();
        },
        error: function (response) {
            alert(response.status + ' ' + response.statusText);
        }
    });

}
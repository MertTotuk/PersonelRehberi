function addDepartment() {
    var DepartmentName = $("#DepartmentName1").val();
    var DepartmentDescription = $("#DepartmentDescription").val();
    $.ajax({
        type: "POST",
        url: "CreateDepartment",
        data: "{DepartmentName:'" + DepartmentName +
            "',DepartmentDescription:'" + DepartmentDescription +
             "'}",
        contentType: "application/json; charset=utf-8",
        datatype: "jsondata",
        async: "true",
        success: function (response) {
            $(".errMsg ul").remove();
            var myObject = eval('(' + response.d + ')');

            if (myObject > 0) {
                bindData();
                $('#dgrid').jqxGrid('updatebounddata');
                $(".errMsg").append("<ul><li>Data saved successfully</li></ul>");
            }
            else {
                $(".errMsg").append("<ul><li>Opppps something went wrong.</li></ul>");
            }
           
            $("#popupWindowDepartment").jqxWindow('hide');
            $(".errMsg").show("slow");
           
        },
        error: function (response) {
            alert(response.status + ' ' + response.statusText);
        }
    });

}
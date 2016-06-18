function addPerson(srcDeneme) {
    var PersonName = $("#PersonName").val();
    var PersonSurname = $("#PersonSurname").val();
    var Birthdate = $("#Birthdate").val();
    var Email = $("#Email").val();
    var PhoneNumber1 = $("#PhoneNumber1").val();
    var PhoneNumber2 = $("#PhoneNumber2").val();
    var HireDate = $("#HireDate").val();
    var TitleId = $("#TitleName").jqxDropDownList('getSelectedItem').value;
    var DepartmentId = $("#DepartmentName").jqxDropDownList('getSelectedItem').value;
    var picture = srcDeneme;

    var postData = {
        PersonName: PersonName,
        PersonSurname: PersonSurname,
        Birthdate: Birthdate,
        Email: Email,
        PhoneNumber1: PhoneNumber1,
        PhoneNumber2: PhoneNumber2,
        HireDate: HireDate,
        TitleId: TitleId,
        DepartmentId: DepartmentId,
        Picture: picture
    };

    $.ajax({
        type: "POST",
        url: "Create",
        data: JSON.stringify(postData),
        contentType: "application/json; charset=utf-8",
        datatype: "jsondata",
        async: "true",
        success: function (response) {
            $(".errMsg ul").remove();
            var myObject = eval('(' + response.d + ')');

            if (myObject > 0) {
                bindData();
                $('#grid').jqxGrid('updatebounddata');
                $(".errMsg").append("<ul><li>Data saved successfully</li></ul>");
            }
            else {
                $(".errMsg").append("<ul><li>Opppps something went wrong.</li></ul>");
            }
            $("#popupWindow").jqxWindow('hide');
            $(".errMsg").show("slow");
            $('#grid').jqxGrid('refreshdata');
        },
        error: function (response) {
            alert(response.status + ' ' + response.statusText);
        }
    });

}
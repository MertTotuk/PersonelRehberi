//==== Method to save data into database.
function saveData() {

    //==== Call validateData() Method to perform validation. This method will return 0 
    //==== if validation pass else returns number of validations fails.

   // var errCount = validateData();
    //==== If validation pass save the data.
    
        var Identity= $("#Identity").val();
        var PersonName= $("#PersonName").val();
        var PersonSurname= $("#PersonSurname").val();
        var Birthdate = $("#Birthdate").val();
        var Email= $("#Email").val();
        var PhoneNumber1= $("#PhoneNumber1").val();
        var PhoneNumber2= $("#PhoneNumber2").val();
        var HireDate = $("#HireDate").val();
        var TitleId = $('#TitleName').jqxDropDownList('getSelectedItem');
        var DepartmentId = $('#DepartmentName').jqxDropDownList('getSelectedItem');
        $.ajax({
            type: "POST",
            url: "saveData",
            data: "{Identity:'" + Identity +
                "',PersonName:'" + PersonName +
                "',PersonSurname:'" + PersonSurname +
                "',Birthdate:'" + Birthdate +
                "',Email:'" + Email +
                "',PhoneNumber1:'" + PhoneNumber1 +
                "',PhoneNumber2:'" + PhoneNumber2 +
                "',HireDate:'" + HireDate +
                "',TitleId:'" + TitleId + "'}",
            contentType: "application/json; charset=utf-8",
            datatype: "jsondata",
            async: "true",
            success: function (response) {
                $(".errMsg ul").remove();
                //var dataAdapter = new $.jqx.dataAdapter(source);
                //('#jqxgrid').jqxgrid.({source,dataAdapter});
                var row = {
                    Identity: $("#Identity").val(),
                    PersonName: $("#PersonName").val(),
                    PersonSurname: $("#PersonSurname").val(),
                    Birthdate: $("#Birthdate").val(),
                    Email: $("#Email").val(),
                    PhoneNumber1: $("#PhoneNumber1").val(),
                    PhoneNumber2: $("#PhoneNumber2").val(),
                    HireDate: $("#HireDate").val()
                    
                }
                var myObject = eval('(' + response.d + ')');

                if (myObject > 0) {
                    bindData();
                    $('#grid').jqxGrid('updatebounddata');
                    
                    //var rowID = $('#grid').jqxGrid('getrowid', editrow);
                   
                    $(".errMsg").append("<ul><li>Data saved successfully</li></ul>");
                }
                else {
                    $(".errMsg").append("<ul><li>Opppps something went wrong.</li></ul>");
                }
                //$('#grid').jqxGrid('updaterow', rowID, row);

                $("#popupWindow").jqxWindow('hide');
                
                $(".errMsg").show("slow");
                //myObject.clear();
            },
            error: function (response) {
                alert(response.status + ' ' + response.statusText);
            }
        });
   
}


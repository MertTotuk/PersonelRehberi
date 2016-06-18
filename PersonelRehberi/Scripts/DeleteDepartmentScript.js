function deleteDepartmentData() {
    var selectedrowindex = $("#dgrid").jqxGrid('getselectedrowindex');
    var Identity = $("#dgrid").jqxGrid('getrowid', selectedrowindex);
    alert(Identity + "'idli alanı silmek istediğinize emin misiniz?");
    $.ajax({
        dataType: 'json',
        cache: false,
        url: 'DeleteDepartment',
        data: { id: Identity },
        type: "POST",
        success: function (data, status, xhr) {
            alert("oldu bea");
            $('#dgrid').jqxGrid('updatebounddata');

            //commit(true);
            //TODO: Gridin refreshData  metodu çağırılacak
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("hataliyim");
            //commit(false);
        }
    });
}

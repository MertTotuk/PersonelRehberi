function deleteTitleData() {
    var selectedrowindex = $("#tgrid").jqxGrid('getselectedrowindex');
    var Identity = $("#tgrid").jqxGrid('getrowid', selectedrowindex);
    alert(Identity+"'idli alanı silmek istediğinize emin misiniz?");
    $.ajax({
        dataType: 'json',
        cache: false,
        url: 'DeleteTitle',
        data: { id: Identity },
        type: "POST",
        success: function (data, status, xhr) {

            alert("oldu bea");
            $('#tgrid').jqxGrid('updatebounddata');

            //commit(true);
            //TODO: Gridin refreshData  metodu çağırılacak
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("hataliyim");
            //commit(false);
        }
    });
}

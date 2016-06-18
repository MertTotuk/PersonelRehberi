function deleteData() {
    var selectedrowindex = $("#grid").jqxGrid('getselectedrowindex');
    var Identity = $("#grid").jqxGrid('getrowid', selectedrowindex);
    alert(Identity);
    $.ajax({
        dataType: 'json',
        cache: false,
        url: 'Delete',
        data: { id: Identity },
        type: "POST",
        success: function (data, status, xhr) {
            alert("oldu bea");
            $('#grid').jqxGrid('updatebounddata');
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("hataliyim" + jqXHR.statusText);
        }
    });
}

function PagCoDi(referencia, monto) {
//    var referencia = $('#<%= lblReferencia_l.ClientID %>').val();
    $.ajax({
        type: "GET",
        cache: false,
        url: "https://sysweb.unach.mx/ApiCodi/SolicitudPago",
        data: { des: referencia, amo: monto },
        dataType: 'json',
        success: function (data) {
            var items = [];
            $.each(data, function (key, val) {
                items.push('<li id="' + key + '">' + val + '</li>');
            });
        }
    });
};

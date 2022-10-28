////paypal.Buttons({
////    createOrder: function (data, actions) {
////        return actions.order.create({
////            purchase_units: [{
////                amount: {
////                    value: 128.89
////                }
////            }]
////        });
////    },
////    onApprove: function (data, actions) {
////        // This function captures the funds from the transaction.
////        return actions.order.capture().then(function (details) {
////            // This function shows a transaction success message to your buyer.
////            window.location.href = "../Form/RespuestaPagoPayPal.aspx";
////        });
////    },
////    onCancel: function (data) {
////        //window.location.href = "https://sysweb.unach.mx/DSIA/";
////        alert("Pago cancelado");
////    },
////    onError: function (err) {
////        window.location.href = "PagoPayPal.aspx";
////    },

////}).render('#paypal-button-container');
function PagBancomer() {
    $('#<%= mp_account.ClientID %>').attr("name", "mp_account");
    $('#<%= mp_product.ClientID %>').attr("name", "mp_product");
    $('#<%= mp_order.ClientID %>').attr("name", "mp_order");
    $('#<%= mp_reference.ClientID %>').attr("name", "mp_reference");
    $('#<%= mp_node.ClientID %>').attr("name", "mp_node");
    $('#<%= mp_concept.ClientID %>').attr("name", "mp_concept");
    $('#<%= mp_order.ClientID %>').attr("name", "mp_order");
    $('#<%= mp_amount.ClientID %>').attr("name", "mp_amount");
    $('#<%= mp_customername.ClientID %>').attr("name", "mp_customername");
    $('#<%= mp_currency.ClientID %>').attr("name", "mp_currency");
    $('#<%= mp_signature.ClientID %>').attr("name", "mp_signature");
    $('#<%= mp_urlsuccess.ClientID%>').attr("name", "mp_urlsuccess");
    $('#<%= mp_urlfailure.ClientID %>').attr("name", "mp_urlfailure");
    //document.getElementById("form1").action = "//mgg.unach.mx/pruebas_bancomer.php"; //Setting form action to "success.php" page        
    //document.getElementById("form1").action = "ttps://prepro.adquiracloud.mx/clb/endpoint/unach/";
    document.getElementById('<%= Master.Page.Controls[0].FindControl("form1").ClientID %>').action = "https://www.adquiramexico.com.mx/clb/endpoint/unach/";
    document.getElementById('<%= Master.Page.Controls[0].FindControl("form1").ClientID %>').method = "POST";
    document.getElementById('<%= Master.Page.Controls[0].FindControl("form1").ClientID %>').submit();
};

function Pago_Paypal(tk) {
    $("#loadFormasPago").show();
    $.ajax({
        url: "https://sysweb.unach.mx/ApiPagos/PayPal/Order?tk=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJSZWZlcmVuY2lhIjoiNDExMDEwQTEyMDEwMlgyNjk1MzY1NDUyMzYiLCJJZFJlZmVyZW5jaWEiOjI1NDI2OTUsIlRvdGFsIjoxMTUsIkNsaWVudGUiOiJvRElBTkEgQkVSRU5JQ0UgVkFaUVVFWiBNT1JBTEVTIn0.-jzLX5V5jkF8pk0HOGhbBIcJ27dPxWAeMzw606qJaZY",
        type: "POST",
        //data: jQuery.param({ Precio: "99", Referencia: "41929292" }),
        //async: false,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            console.log(data);
            if (data.status) {
                var jsonresult = JSON.parse(data.respuesta);
                console.log(jsonresult);
                var links = jsonresult.links;
                var resultado = links.find(item => item.rel === "approve");
                window.location.href = resultado.href
            }
            else {
                alert("Intentalo más tarde");
            }
            $("#loadFormasPago").hide();
        }
    });

};
function PagPaypal(monto, referencia, nombre) {
    $("#loadFormasPago").show();

    $.ajax({
        url: "https://sysweb.unach.mx/ApiPagos/PayPal/Order?precio=" + monto + "&referencia=" + referencia + "&nombre=" + nombre+"",
        type: "POST",
        //data: jQuery.param({ Precio: "99", Referencia: "41929292" }),
        //async: false,
        dataType: "json",
        contentType:"application/json; charset=utf-8",
        success: function (data) {
            console.log(data);
             if (data.status) {
                var jsonresult = JSON.parse(data.respuesta);
                console.log(jsonresult);
                var links = jsonresult.links;
                 var resultado = links.find(item => item.rel === "approve");
                 window.location.href = resultado.href
            }
            else {
                alert("Intentalo más tarde");
            }
            $("#loadFormasPago").hide();
        }
    });

};

function PagCoDi(referencia, monto) {
    //    var referencia = $('#<%= lblReferencia_l.ClientID %>').val();
    $.ajax({
        type: "GET",
        cache: false,
        url: "https://sysweb.unach.mx/ApiPagos/CoDi",
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



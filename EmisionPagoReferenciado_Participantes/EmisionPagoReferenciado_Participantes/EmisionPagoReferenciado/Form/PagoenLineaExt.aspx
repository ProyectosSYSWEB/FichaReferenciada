<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PagoenLineaExt.aspx.cs" Inherits="EmisionPagoReferenciado.Form.PagoenLineaExt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
        <script language="javascript" type="text/javascript">
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
            document.getElementById('<%= Master.Page.Controls[0].FindControl("form1").ClientID %>').action = "https://www.adquiramexico.com.mx/clb/endpoint/unach/";
            document.getElementById('<%= Master.Page.Controls[0].FindControl("form1").ClientID %>').method = "POST";
            document.getElementById('<%= Master.Page.Controls[0].FindControl("form1").ClientID %>').submit();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="mp_account" runat="server" Value="MPACCO" />
    <asp:HiddenField ID="mp_product" runat="server" Value="mpproduct" />
    <asp:HiddenField ID="mp_order" runat="server" Value="mporder" />
    <asp:HiddenField ID="mp_reference" runat="server" Value="mpreference" />
    <asp:HiddenField ID="mp_node" runat="server" Value="mpnode" />
    <asp:HiddenField ID="mp_concept" runat="server" Value="mpconcept" />
    <asp:HiddenField ID="mp_amount" runat="server" Value="mpamount" />
    <asp:HiddenField ID="mp_customername" runat="server" Value="mpcustomername" />
    <asp:HiddenField ID="mp_currency" runat="server" />
    <asp:HiddenField ID="mp_signature" runat="server" />
    <asp:HiddenField ID="mp_urlsuccess" runat="server" />
    <asp:HiddenField ID="mp_urlfailure" runat="server" />



</asp:Content>

﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisualizadorCrystal.aspx.cs" Inherits="EmisionPagoReferenciado.VisualizadorCrystal" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ OutputCache Duration="3" VaryByParam="none" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>

<body>
    <form runat="server">
    <asp:scriptmanager ID="Scriptmanager1" runat="server"></asp:scriptmanager>
    <div>
        <CR:CrystalReportViewer ID="CR_Reportes" runat="server" AutoDataBind="true" />
    </div>
    </form>
</body>
</html>

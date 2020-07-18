<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmAlumnos.aspx.cs" 
Inherits="EmisionPagoReferenciado.Form.FrmAlumnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
    {
        }
    .style2
    {
        height: 21px;
    }
    .style5
    {
    }
    .style6
    {
    }
    .style7
    {
    }
    .style8
    {
        width: 49px;
    }
    .style10
    {
        width: 147px;
    }
    .style11
    {
        width: 107px;
    }
        .style14
        {
            width: 411px;
        }
        .style17
        {
            width: 160px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table align="right" style="width: 95%;">
    <tr>
        <td>
           
            <asp:Label ID="lblNombre_Formulario" runat="server" CssClass="titulo" 
                Text="ALUMNOS"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pnlPrincipal" runat="server">
                        <table width="100%">
                            <tr>
                                <td class="style17" align="right">
                                    <asp:Label ID="lblDependencia" runat="server" Text="Dependencia:"></asp:Label>
                                </td>
                                <td class="style14">
                                    <asp:DropDownList ID="ddlDependencia" runat="server" Width="350px" 
                                        AutoPostBack="True" 
                                        onselectedindexchanged="ddlDependencia_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td class="style14">
                                    <asp:Button ID="btnNuevo" runat="server" CssClass="boton2" Height="36px" 
                                        onclick="btnNuevo_Click" Text="NUEVO" Width="70px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style17" align="right">
                                    <asp:Label ID="lblNivel" runat="server" Text="Nivel de Estudios:"></asp:Label>
                                </td>
                                <td class="style14">
                                    <asp:DropDownList ID="ddlNivel" runat="server" Width="350px" 
                                        AutoPostBack="True" onselectedindexchanged="ddlNivel_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td class="style14">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style17">
                                    &nbsp;</td>
                                <td class="style14">
                                    &nbsp;</td>
                                <td class="style14">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="3" align="center">
                                    <asp:Label ID="lblMsj" runat="server" Text="" ForeColor="GrayText" Font-Bold="true"></asp:Label>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style1" align="center" colspan="3">
                                    <asp:GridView ID="grvAlumnos" runat="server" AllowPaging="True" 
                                        AutoGenerateColumns="False" CellPadding="4" Font-Names="Calibri" 
                                        ForeColor="#333333" GridLines="None" 
                                        onpageindexchanging="grvAlumnos_PageIndexChanging" 
                                        onselectedindexchanging="grvAlumnos_SelectedIndexChanging">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="Matricula" HeaderText="Matricula" />
                                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                            <asp:BoundField DataField="DescCarrera" HeaderText="Carrera" />
                                            <asp:BoundField DataField="Semestre" HeaderText="Semestre" />
                                            <asp:BoundField DataField="Grupo" HeaderText="Grupo" />
                                             <asp:BoundField DataField="StatusMatricula" HeaderText="Estatus" />
                                          <%--  <asp:CommandField ShowSelectButton="True" SelectText="Editar" />--%>
                                        </Columns>
                                        <EditRowStyle BackColor="#7C6F57" />
                                        <FooterStyle BackColor="#3166A2" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#3166A2" Font-Bold="True" Font-Names="Calibri" 
                                            ForeColor="White" />
                                        <PagerStyle BackColor="#3166A2" Font-Names="Calibri" ForeColor="White" 
                                            HorizontalAlign="Center" />
                                        <RowStyle BackColor="#E3EAEB" />
                                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td class="style17">
                                    &nbsp;</td>
                                <td class="style14">
                                    <asp:Button ID="Button1" runat="server" CssClass="boton2" 
                                        PostBackUrl="~/Form/Registro_Participantes.aspx" Text="REGRESAR" />
                                </td>
                                <td class="style14">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="style2">
        </td>
    </tr>
    <tr>
        <td>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pnlDatos_Alumno" runat="server" Visible="False">
                        <table style="width: 100%;">
                            <tr>
                                <td class="style10">
                                    &nbsp;</td>
                                <td class="style11">
                                    &nbsp;</td>
                                <td class="style8">
                                    &nbsp;</td>
                                <td colspan="2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style10" align="right">
                                    <asp:Label ID="lblDependencia_D" runat="server" Text="Dependencia:"></asp:Label>
                                </td>
                                <td class="style7" colspan="4">
                                    <asp:DropDownList ID="ddlDependencia_D" runat="server" Width="350px"
                                        ClientIDMode="Predictable">
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="guardar" runat="server" 
                                     ControlToValidate="ddlDependencia_D" ErrorMessage="*Requerido"  CssClass="MsjError" InitialValue="00000">
                                     </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style10" align="right">
                                    <asp:Label ID="lblNivel_D" runat="server" Text="Nivel de Estudio:"></asp:Label>
                                </td>
                                <td class="style7" colspan="4">
                                    <asp:DropDownList ID="ddlNivel_D" runat="server" Width="350px"> 
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style10" align="right">
                                    <asp:Label ID="lblMatricula" runat="server" Text="Matricula:"></asp:Label>
                                </td>
                                <td class="style7" colspan="4">
                                    <asp:TextBox ID="txtMatricula" runat="server" CssClass="box"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style10" align="right">
                                    <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
                                </td>
                                <td class="style6" colspan="4">
                                    <asp:TextBox ID="txtNombre" runat="server" Width="345px" CssClass="box"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style10" align="right">
                                    <asp:Label ID="lblCarrera" runat="server" Text="Carrera:"></asp:Label>
                                </td>
                                <td class="style11">
                                    <asp:DropDownList ID="ddlCarrera" runat="server" 
                                        onselectedindexchanged="ddlCarrera_SelectedIndexChanged" AutoPostBack="true"
                                        ClientIDMode="Predictable" Width="350px">
                                    </asp:DropDownList>
                                </td>
                                <td  class="style8" align="right">
                                <asp:Label ID="lblOtraCarrera"  Visible="false" runat="server" Text="Otra:"></asp:Label>
                                   </td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtCarrera" Visible="false" runat="server" CssClass="box" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style10" align="right">
                                    <asp:Label ID="lblSemestre" runat="server" Text="Semestre:"></asp:Label>
                                </td>
                                <td class="style11">
                                    <asp:TextBox ID="txtSemestre" runat="server" Width="100px" CssClass="box"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                        ControlToValidate="txtSemestre" CssClass="MsjError" 
                                        ErrorMessage="* Solo Números" ValidationExpression="\d+" 
                                        ValidationGroup="guardar"></asp:RegularExpressionValidator>
                                </td>
                                <td class="style8" align="right">
                                    <asp:Label ID="lblGrupo" runat="server" Text="Grupo:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtGrupo" runat="server" Width="50px" CssClass="box"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style10"  align="right">
                                    <asp:Label ID="lblActivo" runat="server" Text="Activo:"></asp:Label>
                                </td>
                                <td class="style11">
                                    <asp:CheckBox ID="chkActivo" Checked="true" runat="server" />
                                </td>
                                <td class="style8">
                                    Genero:</td>
                                <td  align="left">
                                   <asp:RadioButtonList ID="rdoGenero" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="F">Femenino</asp:ListItem>
                                            <asp:ListItem Value="M" Selected="True">Masculino</asp:ListItem>
                                        </asp:RadioButtonList>  
                                    
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                    ControlToValidate="rdoGenero" ErrorMessage="*Requerido" ForeColor="Red" 
                                    ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                    </td>
                            </tr>
                            <tr>
                                <td class="style10" align="right">
                                    Correo:</td>
                                <td class="style11">
                                    <asp:TextBox ID="txtCorreo" runat="server" CssClass="box" Width="345px"></asp:TextBox>
                                </td>
                                <td class="style8">
                                    &nbsp;</td>
                                <td colspan="2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style10">
                                    &nbsp;</td>
                                <td class="style11">
                                    &nbsp;</td>
                                <td class="style8">
                                    &nbsp;</td>
                                <td colspan="2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" class="style5" colspan="5">
                                    <asp:Button ID="btnGuardar" runat="server" CssClass="boton2" Height="45px" 
                                        Text="GUARDAR" Width="70px" onclick="btnGuardar_Click" 
                                        ValidationGroup="guardar" />
                                    &nbsp;<asp:Button ID="btnCancelar" runat="server" CssClass="boton2" Height="45px" 
                                        Text="CANCELAR" Width="75px" onclick="btnCancelar_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style10">
                                    &nbsp;</td>
                                <td class="style11">
                                    &nbsp;</td>
                                <td class="style8">
                                    &nbsp;</td>
                                <td colspan="2">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

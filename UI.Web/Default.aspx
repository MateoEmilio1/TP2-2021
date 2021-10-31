<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UI.Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
        <asp:Label ID="Label1" runat="server" Text="Bienvenido, " Font-Bold="True" Font-Size="XX-Large"></asp:Label>
        <asp:Label ID="lblNombre" runat="server" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text=" " ></asp:Label>
        <asp:Label ID="lblApellido" runat="server"  Font-Bold="True" Font-Size="XX-Large"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text=" - " Font-Bold="True" Font-Size="XX-Large"></asp:Label>
        <asp:Label ID="lblTipo" runat="server" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
    </asp:Panel>
    

</asp:Content>
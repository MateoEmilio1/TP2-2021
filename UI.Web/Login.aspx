<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Panel ID="panelLogin" runat="server" HorizontalAlign="Center">
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label>
        <br />
        <asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>
        <br />
        <asp:TextBox ID="txtClave" TextMode="Password" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnAceptar" runat="server" Text="Ingresar" OnClick="btnAceptar_Click" />
        <br />
        <asp:Label ID="lblIncorrecto" runat="server" 
            Text="Usuario o contraseña incorrectas" ForeColor="#FF3300" Visible="False"></asp:Label>
        <asp:Label ID="lblInhabilitado" runat="server" 
            Text="Usuario inhabilitado" ForeColor="#FF3300" Visible="False"></asp:Label>
        
        <br />
        
    </asp:Panel>
    </form>
</body>
</html>

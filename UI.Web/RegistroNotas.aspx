<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="RegistroNotas.aspx.cs" Inherits="UI.Web.RegistroNotas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="gridPanelAlumos" runat="server">
        <asp:GridView ID="gridAlumnos" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" HorizontalAlign="Center" OnSelectedIndexChanged="gridAlumnos_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Nota" HeaderText="Nota" />
                <asp:BoundField DataField="Condicion" HeaderText="Condicion" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <br />
    </asp:Panel>
    <asp:Panel ID="gridActionsPanelAlumos" runat="server">
    </asp:Panel>
    </asp:Content>

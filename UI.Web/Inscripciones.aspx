<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inscripciones.aspx.cs" Inherits="UI.Web.Inscripciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     

    <br />
    <br />
    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
        <br />
        <asp:Label ID="Label1" runat="server" Text="Inscripciones"></asp:Label>
        <br />
        <asp:GridView ID="gridInscripciones" runat="server" DataKeyNames="ID" HorizontalAlign="Center" AutoGenerateColumns="False" OnSelectedIndexChanged="gridInscripciones_SelectedIndexChanged" >
            <Columns>
                <asp:BoundField HeaderText="Materia" DataField="Curso.Materia.Descripcion" />
                <asp:BoundField HeaderText="Comision" DataField="Curso.Comision.Descripcion" />
                <asp:BoundField HeaderText="Condicion" DataField="Condicion" />
                <asp:BoundField HeaderText="Nota" DataField="Nota" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
            <SelectedRowStyle BackColor="#336699" />
        </asp:GridView>
        <br />
        <br />
        <asp:Panel ID="gridActionsPanel" runat="server">
                &nbsp;
                <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click" CausesValidation="False">Eliminar</asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" CausesValidation="False">Nuevo</asp:LinkButton>
            </asp:Panel>
    </asp:Panel>
        <asp:Panel ID="formPanel" Visible="False" runat="server" HorizontalAlign="Center">
            
            <br />
            <asp:Label ID="Label2" runat="server" Text="Materias"></asp:Label>
            <br />
            <asp:GridView ID="gridForm" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" HorizontalAlign="Center" OnSelectedIndexChanged="gridForm_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="Materia.Descripcion" HeaderText="Materia" />
                    <asp:BoundField DataField="Comision.Descripcion" HeaderText="Comision" />
                    <asp:BoundField DataField="AnioCalendario" HeaderText="Año" />
                    <asp:BoundField DataField="Cupo" HeaderText="Cupo" />
                    <asp:CommandField SelectText="Inscribirse" ShowSelectButton="True" />
                </Columns>
            <SelectedRowStyle BackColor="#336699" />
            </asp:GridView>
            <br />
            <br />
            
            
            </asp:Panel>
        <asp:Panel ID="formActionsPanel" runat="server" HorizontalAlign="Center" Visible="False">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            &nbsp;
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" CausesValidation="False">Cancelar</asp:LinkButton>
              </asp:Panel>


</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    

    <br />
    <br />
    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
        <asp:GridView ID="gridCursos" runat="server" DataKeyNames="ID" HorizontalAlign="Center" AutoGenerateColumns="False" OnSelectedIndexChanged="gridView_SelectedIndexChanged" >
            <Columns>
                <asp:BoundField HeaderText="Año" DataField="AnioCalendario" />
                <asp:BoundField HeaderText="ID Comisión" DataField="IDComision" />
                <asp:BoundField HeaderText="ID Materia" DataField="IDMateria" />
                <asp:BoundField HeaderText="Cupo" DataField="Cupo" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <asp:Panel ID="gridActionsPanel" runat="server">
                <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
            </asp:Panel>
    </asp:Panel>
        <asp:Panel ID="formPanel" Visible="False" runat="server" HorizontalAlign="Left">
            
            <br />
            <br />
            <table style="width:100%;">
                <tr>
                    <td style="width: 468px">&nbsp;</td>
                    <td style="width: 103px">
                        <asp:Label ID="IDComisionLabel" runat="server" Text="IDComision"></asp:Label>
                    </td>
                    <td dir="ltr" style="width: 312px">
                        <asp:TextBox ID="IDComisionTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="IDComisionTextBox" ErrorMessage="Ingrese un número entero" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" Operator="DataTypeCheck" ControlToValidate="IDComisionTextBox" ErrorMessage="Ingrese un número entero para la comisión" ForeColor="Red" Type="Integer">*</asp:CompareValidator>
                        <asp:Label ID="lblComisionInexistente" runat="server" ForeColor="Red" Text="Comisión Inexistente" Visible="False"></asp:Label>
                    </td>
                    <td dir="ltr">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 468px">&nbsp;</td>
                    <td style="width: 103px">
                        <asp:Label ID="IDMateriaLabel" runat="server" Text="IDMateria: "></asp:Label>
                    </td>
                    <td dir="ltr" style="width: 312px">
                        <asp:TextBox ID="IDMateriaTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="IDMateriaTextBox" ErrorMessage="Ingrese un número entero" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" Operator="DataTypeCheck" ControlToValidate="IDMateriaTextBox" ErrorMessage="Ingrese un número entero para la materia" ForeColor="Red" Type="Integer">*</asp:CompareValidator>
                        <asp:Label ID="lblMatInexistente" runat="server" ForeColor="Red" Text="Materia Inexistente" Visible="False"></asp:Label>
                    </td>
                    <td dir="ltr">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 468px">&nbsp;</td>
                    <td style="width: 103px">
                        <asp:Label ID="cupoLabel" runat="server" Text="Cupo: "></asp:Label>
                    </td>
                    <td style="width: 312px">
                        <asp:TextBox ID="CupoTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="CupoTextBox" ErrorMessage="Ingrese un número entero" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator4" runat="server" Operator="DataTypeCheck" ControlToValidate="CupoTextBox" ErrorMessage="Ingrese un número entero para el cupo" ForeColor="Red" Type="Integer">*</asp:CompareValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 468px">&nbsp;</td>
                    <td style="width: 103px">
                        <asp:Label ID="anioLabel" runat="server" Text="Año: "></asp:Label>
                    </td>
                    <td style="width: 312px">
                        <asp:TextBox ID="AñoTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="AñoTextBox" ErrorMessage="Ingrese un número entero" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" Operator="DataTypeCheck" ControlToValidate="AñoTextBox" ErrorMessage="Ingrese un número entero para el año" ForeColor="Red" Type="Integer">*</asp:CompareValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
            
            <asp:Panel ID="formActionsPanel" runat="server" HorizontalAlign="Center">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" style="margin-top: 19px" />
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            &nbsp;
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
              </asp:Panel>
            </asp:Panel>
        
</asp:Content>

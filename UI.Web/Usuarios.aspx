<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div>
        </div>
        <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" HorizontalAlign="Center">
            <Columns>
                <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                <asp:BoundField HeaderText="ID Persona" DataField="IDPersona" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
            <SelectedRowStyle BackColor="#000099" ForeColor="White" />
            </asp:GridView>
            <br />
            <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click" CausesValidation="False">Editar</asp:LinkButton>
            &nbsp;
            <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click" CausesValidation="False">Eliminar</asp:LinkButton>
            &nbsp;
            <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" CausesValidation="False">Nuevo</asp:LinkButton>
            <br />
        </asp:Panel>
        <asp:Panel ID="formPanel" Visible="False" runat="server" HorizontalAlign="Left">
            <table style="width: 100%; height: 40px;">
                <tr>
                    <td style="width: 397px">&nbsp;</td>
                    <td style="width: 149px">
                        <asp:Label ID="Label1" runat="server" Text="ID Persona: "></asp:Label>
                    </td>
                    <td style="width: 332px">
                        <asp:TextBox ID="idPersonaTextBox" runat="server"></asp:TextBox>
                        <asp:Button ID="BuscarPersona" runat="server"   Text="Buscar" OnClick="BuscarPersona_Click" CausesValidation="False" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="nombreTextBox" EnableViewState="False" ErrorMessage="Debe ingresar una persona" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 397px">&nbsp;</td>
                    <td style="width: 149px">
                        <asp:Label ID="nombreLabel" runat="server" Text="Nombre:"></asp:Label>
                    </td>
                    <td style="width: 332px">
                        <asp:TextBox ID="nombreTextBox" Enabled = false runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 397px">&nbsp;</td>
                    <td style="width: 149px">
                        <asp:Label ID="apellidoLabel" runat="server" Text="Apellido:"></asp:Label>
                    </td>
                    <td style="width: 332px">
                        <asp:TextBox ID="apellidoTextBox" Enabled = false runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 397px; height: 26px;"></td>
                    <td style="width: 149px; height: 26px;">
                        <asp:Label ID="emailLabel" runat="server" Text="EMail:"></asp:Label>
                    </td>
                    <td style="width: 332px; height: 26px;">
                        <asp:TextBox ID="emailTextBox" Enabled = false runat="server"></asp:TextBox>
                    </td>
                    <td style="height: 26px"></td>
                </tr>
                <tr>
                    <td style="width: 397px">&nbsp;</td>
                    <td style="width: 149px">
                        <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado:"></asp:Label>
                    </td>
                    <td style="width: 332px">
                        <asp:CheckBox ID="habilitadoCheckBox" runat="server" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 397px; height: 30px;"></td>
                    <td style="width: 149px; height: 30px;">
                        <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario:"></asp:Label>
                    </td>
                    <td style="width: 332px; height: 30px;">
                        <asp:TextBox ID="nombreUsuarioTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="nombreUsuarioTextBox" Display="Dynamic" ErrorMessage="El nombre de usuario no puede estar vacio" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                    <td style="height: 30px"></td>
                </tr>
                <tr>
                    <td style="width: 397px">&nbsp;</td>
                    <td style="width: 149px">
                        <asp:Label ID="claveLabel" runat="server" Text="Clave:"></asp:Label>
                    </td>
                    <td style="width: 332px">
                        <asp:TextBox ID="claveTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="claveTextBox" EnableViewState="False" ErrorMessage="La clave no puede estar vacia" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="claveTextBox" ErrorMessage="La clave debe tener mas de 8 caracteres" ForeColor="Red" ValidationExpression=".{8,}$">*</asp:RegularExpressionValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 397px; height: 30px;"></td>
                    <td style="width: 149px; height: 30px;">
                        <asp:Label ID="repetirClaveLabel" runat="server" Text="Repetir Clave:"></asp:Label>
                    </td>
                    <td style="width: 332px; height: 30px;">
                        <asp:TextBox ID="repetirClaveTextBox" runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="claveTextBox" ControlToValidate="repetirClaveTextBox" ErrorMessage="Las claves no coinciden" ForeColor="Red">*</asp:CompareValidator>
                    </td>
                    <td style="height: 30px"></td>
                </tr>
            </table>
            <br />
            <asp:Panel ID="formActionsPanel" runat="server" HorizontalAlign="Center">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
                &nbsp;
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" CausesValidation="False">Cancelar</asp:LinkButton>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
        </asp:Panel>
            
            </asp:Panel>
        <asp:Panel ID="gridActionsPanel" runat="server">
        </asp:Panel>
        
   </asp:Content>
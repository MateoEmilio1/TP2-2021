<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div>
        </div>
        <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" HorizontalAlign="Center">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="Email" DataField="Email" />
                <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
            </asp:GridView>
            <br />
            <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
            &nbsp;
            <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
            &nbsp;
            <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
        </asp:Panel>
        <asp:Panel ID="formPanel" Visible="False" runat="server" HorizontalAlign="Center">
            <table style="width: 100%; height: 40px;">
                <tr>
                    <td style="width: 397px">&nbsp;</td>
                    <td style="width: 149px">
                        <asp:Label ID="nombreLabel" runat="server" Text="Nombre:"></asp:Label>
                    </td>
                    <td style="width: 247px">
                        <asp:TextBox ID="nombreTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="nombreTextBox" EnableViewState="False" ErrorMessage="El nombre no puede estar vacio" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 397px">&nbsp;</td>
                    <td style="width: 149px">
                        <asp:Label ID="apellidoLabel" runat="server" Text="Apellido:"></asp:Label>
                    </td>
                    <td style="width: 247px">
                        <asp:TextBox ID="apellidoTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="apellidoTextBox" ErrorMessage="El apellido no puede estar vacío" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 397px">&nbsp;</td>
                    <td style="width: 149px">
                        <asp:Label ID="emailLabel" runat="server" Text="EMail:"></asp:Label>
                    </td>
                    <td style="width: 247px">
                        <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="emailTextBox" ErrorMessage="El email es invalido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="emailTextBox" EnableViewState="False" ErrorMessage="El email no puede estar vacio" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 397px">&nbsp;</td>
                    <td style="width: 149px">
                        <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado:"></asp:Label>
                    </td>
                    <td style="width: 247px">
                        <asp:CheckBox ID="habilitadoCheckBox" runat="server" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 397px">&nbsp;</td>
                    <td style="width: 149px">
                        <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario:"></asp:Label>
                    </td>
                    <td style="width: 247px">
                        <asp:TextBox ID="nombreUsuarioTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="nombreUsuarioTextBox" Display="Dynamic" ErrorMessage="El nombre de usuario no puede estar vacio" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 397px">&nbsp;</td>
                    <td style="width: 149px">
                        <asp:Label ID="claveLabel" runat="server" Text="Clave:"></asp:Label>
                    </td>
                    <td style="width: 247px">
                        <asp:TextBox ID="claveTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="claveTextBox" EnableViewState="False" ErrorMessage="La clave no puede estar vacia" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="claveTextBox" ErrorMessage="La clave debe tener mas de 8 caracteres" ForeColor="Red" ValidationExpression=".{8,}$">*</asp:RegularExpressionValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 397px">&nbsp;</td>
                    <td style="width: 149px">
                        <asp:Label ID="repetirClaveLabel" runat="server" Text="Repetir Clave:"></asp:Label>
                    </td>
                    <td style="width: 247px">
                        <asp:TextBox ID="repetirClaveTextBox" runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="claveTextBox" ControlToValidate="repetirClaveTextBox" ErrorMessage="Las claves no coinciden" ForeColor="Red">*</asp:CompareValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 397px">&nbsp;</td>
                    <td style="width: 149px">Persona</td>
                    <td style="width: 247px">
                        <asp:DropDownList ID="DDLPersonasSinUsuario" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
            <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
                &nbsp;
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
        </asp:Panel>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            
            </asp:Panel>
        <asp:Panel ID="gridActionsPanel" runat="server">
        </asp:Panel>
        
   </asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div>
        </div>
        <asp:Panel ID="usuariosPanel" runat="server">
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
        </asp:Panel>
        <asp:Panel ID="formPanel" Visible="False" runat="server" HorizontalAlign="Center">
            <asp:Label ID="nombreLabel" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="nombreTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="nombreTextBox" ErrorMessage="El nombre no puede estar vacio" ForeColor="Red" SetFocusOnError="True" EnableViewState="False">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="apellidoLabel" runat="server" Text="Apellido:"></asp:Label>
            <asp:TextBox ID="apellidoTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="apellidoTextBox" ErrorMessage="El apellido no puede estar vacío" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="tipoLabel" runat="server" Text="Tipo Persona:"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="emailLabel" runat="server" Text="EMail:"></asp:Label>
            <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="emailTextBox" ErrorMessage="El email es invalido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="emailTextBox" EnableViewState="False" ErrorMessage="El email no puede estar vacio" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado:"></asp:Label>
            <asp:CheckBox ID="habilitadoCheckBox" runat="server" />
            <br />
            <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario:"></asp:Label>
            <asp:TextBox ID="nombreUsuarioTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="nombreUsuarioTextBox" Display="Dynamic" ErrorMessage="El nombre de usuario no puede estar vacio" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="claveLabel" runat="server" Text="Clave:"></asp:Label>
            <asp:TextBox ID="claveTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="claveTextBox" EnableViewState="False" ErrorMessage="La clave no puede estar vacia" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="claveTextBox" ErrorMessage="La clave debe tener mas de 8 caracteres" ForeColor="Red" ValidationExpression=".{8,}$">*</asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="repetirClaveLabel" runat="server" Text="Repetir Clave:"></asp:Label>
            <asp:TextBox ID="repetirClaveTextBox" runat="server"></asp:TextBox>
            
            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="claveTextBox" ControlToValidate="repetirClaveTextBox" ErrorMessage="Las claves no coinciden" ForeColor="Red">*</asp:CompareValidator>
            
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            
            </asp:Panel>
        <asp:Panel ID="gridActionsPanel" runat="server">
            <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
            <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
            <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
        </asp:Panel>
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server">
            <asp:Label ID="Label1" runat="server" Text="Habilitado: "></asp:Label>
            <asp:CheckBox ID="CheckBox1" runat="server" />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Nombre de Usuario: "></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" Height="15px" Width="200px"></asp:TextBox>
            <br />
            <asp:LinkButton ID="seleccionarPersonaLabel" runat="server" CausesValidation="False" OnClick="seleccionarPersonaLabel_Click">Seleccionar Persona  </asp:LinkButton>
            <asp:TextBox ID="personaTextBox" runat="server" Width="164px">--Persona no seleccionada--</asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Clave: "></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" Height="15px" Width="200px"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Repetir Clave: "></asp:Label>
            <asp:TextBox ID="TextBox3" TextMode="Password" runat="server" Height="15px" Width="200px"></asp:TextBox>
            <asp:Panel ID="personasPanel" runat="server" Visible="False">
                <asp:GridView ID="dgvPersonas" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" HorizontalAlign="Center" onselectedindexchanged="dgvPersonas_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="TipoPersona" HeaderText="Tipo Persona" />
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </asp:Panel>
        <asp:Panel ID="personasSelecPanel" runat="server">
            <asp:LinkButton ID="lbSeleccionar" runat="server" OnClick="lbSeleccionar_Click">Seleccionar</asp:LinkButton>
            <asp:LinkButton ID="lbCancelar" runat="server" OnClick="lbCancelar_Click">Cancelar</asp:LinkButton>
        </asp:Panel>
   </asp:Content>

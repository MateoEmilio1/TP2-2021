<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="UI.Web.Personas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <h2>Personas:</h2><br />
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" 
            onselectedindexchanged="gridView_SelectedIndexChanged" DataKeyNames="ID">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                <asp:BoundField DataField="Email" HeaderText="E-Mail" />
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" />
                <asp:BoundField DataField="Legajo" HeaderText="Legajo" />
                <asp:BoundField DataField="TipoPersona" HeaderText="Tipo" />
                <asp:BoundField DataField="DescPlan" HeaderText="Plan" />
                <asp:BoundField DataField="DescEspecialidad" HeaderText="Especialidad" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <HeaderStyle BackColor="#CF7500" BorderColor="Black" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F4F4F4" BorderColor="Black" />
            <SelectedRowStyle BackColor="#F0A500" ForeColor="White" />
        </asp:GridView>
        <asp:Panel ID="gridActionsPanel" runat="server">
            <asp:LinkButton ID="lbEditar" runat="server" CausesValidation="False" 
                onclick="editarLinkButton_Click">Editar</asp:LinkButton>
            <asp:LinkButton ID="lbEliminar" runat="server" CausesValidation="False" 
                onclick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
            <asp:LinkButton ID="lbNuevo" runat="server" CausesValidation="False" 
                onclick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
                </asp:Panel>
            <asp:Panel ID="formPanel" Visible="False" runat="server">
                <asp:Label ID="lblApellido" runat="server" Text="Apellido: "></asp:Label>
                <asp:TextBox ID="txtApellido" runat="server" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtApellido" ErrorMessage="El campo Apellido es obligatorio" 
                    ForeColor="#FF3300">*  </asp:RequiredFieldValidator>
                <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtNombre" ErrorMessage="El campo Nombre es obligatorio" 
                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="lblLegajo" runat="server" Text="Legajo: "></asp:Label>
                <asp:TextBox ID="txtLegajo" runat="server" Width="120px"></asp:TextBox>   
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtLegajo" ErrorMessage="El campo Legajo es obligatorio " 
                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                <br />  
                <asp:Label ID="lblDireccion" runat="server" Text="Dirección: "></asp:Label>
                <asp:TextBox ID="txtDireccion" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtDireccion" 
                    ErrorMessage="El campo Dirección es obligatorio" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="lblTelefono" runat="server" Text="Teléfono: "></asp:Label>
                <asp:TextBox ID="txtTelefono" runat="server" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtTelefono" ErrorMessage="El campo Teléfono es obligatorio" 
                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="lblEmail" runat="server" Text="E-Mail: "></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="txtEmail" ErrorMessage="El campo Email es obligatorio" 
                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento: "></asp:Label>
                <asp:TextBox ID="txtDia" runat="server" Width="40px">dd</asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="txtDia" 
                    ErrorMessage="El campo Día de nacimiento es obligatorio" ForeColor="#FF3300">* </asp:RequiredFieldValidator>
                <asp:TextBox ID="txtMes" runat="server" Width="40px">mm</asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="txtMes" 
                    ErrorMessage="El campo Mes de nacimiento es obligatorio" ForeColor="#FF3300">* </asp:RequiredFieldValidator>
                <asp:TextBox ID="txtAnio" runat="server" Width="50px">aaaa</asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                    ControlToValidate="txtAnio" 
                    ErrorMessage="El campo Año de nacimiento es obligatorio" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="lblTipoPersona" runat="server" Text="Tipo de Persona: "></asp:Label>
                <asp:DropDownList ID="ddlTipoPersona" runat="server" Width="150px">
                    <asp:ListItem>Alumno</asp:ListItem>
                    <asp:ListItem>Docente</asp:ListItem>
                    <asp:ListItem Value="No docente">No Docente</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                    ControlToValidate="ddlTipoPersona" 
                    ErrorMessage="El campo Tipo de Persona es obligatorio" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad: "></asp:Label>
                <asp:DropDownList ID="ddlEspecialidades" runat="server" Height="22px" 
                    Width="200px" 
                    onselectedindexchanged="ddlEspecialidades_SelectedIndexChanged" 
                    AutoPostBack="True">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                    ControlToValidate="ddlEspecialidades" 
                    ErrorMessage="El campo Especialidad es obligatorio" ForeColor="#FF3300">* </asp:RequiredFieldValidator>
                <asp:Label ID="lblPlan" runat="server" Text="Plan: "></asp:Label>
                <asp:DropDownList ID="ddlPlanes" runat="server" Width="150px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                    ControlToValidate="ddlPlanes" ErrorMessage="El campo Plan es obligatorio" 
                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                <asp:Panel ID="formActionsPanel" runat="server">
                    <asp:LinkButton ID="lbAceptar" runat="server" onclick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
                    <asp:LinkButton ID="lbCancelar" runat="server" CausesValidation="False" 
                        onclick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
                    <asp:ValidationSummary ID="ValidationSummary" runat="server" 
                        ForeColor="#FF3300" />
                </asp:Panel>
            </asp:Panel>
        
    </asp:Panel>
    </asp:Content>



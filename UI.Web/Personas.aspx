<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="UI.Web.Personas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:Panel ID="Panel2" runat="server">
        </asp:Panel>
        <asp:GridView ID="gridPersonas" runat="server" HorizontalAlign="Center" DataKeyNames="ID" OnSelectedIndexChanged="gridPersonas_SelectedIndexChanged" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Direccion" DataField="Direccion" />
                <asp:BoundField HeaderText="E-Mail" DataField="Email" />
                <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                <asp:BoundField HeaderText="Fecha de Nacimiento" DataField="FechaNacimiento" />
                <asp:BoundField HeaderText="Legajo" DataField="Legajo" />
                <asp:BoundField HeaderText="Tipo" DataField="TipoPersona" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <asp:Panel ID="gridActionsPanel" runat="server" Height="21px" Width="1170px">
            <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
            <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
            <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
            <br />
            <asp:Panel ID="formPanel" runat="server">
                <table style="width:100%;">
                    <tr>
                        <td style="width: 347px; height: 30px;"></td>
                        <td style="width: 103px; height: 30px;">
                            <asp:Label ID="lblApellido" runat="server" Text="Apellido: "></asp:Label>
                        </td>
                        <td dir="ltr" style="width: 216px; height: 30px;">
                            <asp:TextBox ID="txtApellido" runat="server" Width="120px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtApellido" ErrorMessage="El campo Apellido es obligatorio" ForeColor="#FF3300">*  </asp:RequiredFieldValidator>
                        </td>
                        <td dir="ltr" style="height: 30px">
                            <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
                            <asp:TextBox ID="txtNombre" runat="server" Width="104px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombre" ErrorMessage="El campo Nombre es obligatorio" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 347px">&nbsp;</td>
                        <td style="width: 103px">
                            <asp:Label ID="lblLegajo" runat="server" Text="Legajo: "></asp:Label>
                        </td>
                        <td dir="ltr" style="width: 216px">
                            <asp:TextBox ID="txtLegajo" runat="server" Width="120px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLegajo" ErrorMessage="El campo Legajo es obligatorio " ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                        </td>
                        <td dir="ltr">
                            <asp:Label ID="lblDireccion" runat="server" Text="Dirección: "></asp:Label>
                            <asp:TextBox ID="txtDireccion" runat="server" Width="225px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDireccion" ErrorMessage="El campo Dirección es obligatorio" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 347px">&nbsp;</td>
                        <td style="width: 103px">
                            <asp:Label ID="lblTelefono" runat="server" Text="Teléfono: "></asp:Label>
                        </td>
                        <td style="width: 216px">
                            <asp:TextBox ID="txtTelefono" runat="server" Width="120px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTelefono" ErrorMessage="El campo Teléfono es obligatorio" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Label ID="lblEmail" runat="server" Text="E-Mail: "></asp:Label>
                            <asp:TextBox ID="txtEmail" runat="server" Width="205px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtEmail" ErrorMessage="El campo Email es obligatorio" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 347px">&nbsp;</td>
                        <td style="width: 103px">
                            <asp:Label ID="lblTipoPersona" runat="server" Text="Tipo de Persona: "></asp:Label>
                        </td>
                        <td style="width: 216px">
                            <asp:DropDownList ID="ddlTipoPersona" runat="server" Width="150px">
                                <asp:ListItem>Alumno</asp:ListItem>
                                <asp:ListItem>Docente</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlTipoPersona" ErrorMessage="El campo Tipo de Persona es obligatorio" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento: "></asp:Label>
                            <asp:TextBox ID="txtDia" runat="server" Width="40px">dd</asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtDia" ErrorMessage="El campo Día de nacimiento es obligatorio" ForeColor="#FF3300">* </asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtMes" runat="server" Width="40px">mm</asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtMes" ErrorMessage="El campo Mes de nacimiento es obligatorio" ForeColor="#FF3300">* </asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtAnio" runat="server" Width="50px">aaaa</asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtAnio" ErrorMessage="El campo Año de nacimiento es obligatorio" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="width: 347px">&nbsp;</td>
                        <td style="width: 103px">
                            <asp:Label ID="lblIDPlan" runat="server" Text="ID Plan:"></asp:Label>
                        </td>
                        <td style="width: 216px">
                            
                            <asp:DropDownList ID="ddlIDPlan" runat="server" DataSourceID="SqlDataSource1" DataTextField="id_plan" DataValueField="id_plan">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStringLocal %>" SelectCommand="SELECT [id_plan] FROM [planes]"></asp:SqlDataSource>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="formActionsPanel" runat="server">
                <asp:LinkButton ID="lbAceptar" runat="server" onclick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
                <asp:LinkButton ID="lbCancelar" runat="server" CausesValidation="False" onclick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
            </asp:Panel>
            <br />
            <br />
        </asp:Panel>
    </asp:Panel>
    </asp:Content>

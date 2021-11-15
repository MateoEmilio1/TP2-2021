<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="UI.Web.Personas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     

    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
        
        <br />
        
        Personas<br />
        
    <br />

        <asp:GridView ID="gridPersonas" runat="server" DataKeyNames="ID" HorizontalAlign="Center" AutoGenerateColumns="False" OnSelectedIndexChanged="gridView_SelectedIndexChanged" >
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
                <asp:BoundField HeaderText="Plan" DataField="Plan.Descripcion" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
            <SelectedRowStyle BackColor="#336699" />
        </asp:GridView>
        <br />
        <br />
        <asp:Panel ID="gridActionsPanel" runat="server">
                <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click" CausesValidation="False">Editar</asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click" CausesValidation="False">Eliminar</asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" CausesValidation="False">Nuevo</asp:LinkButton>
            </asp:Panel>
    </asp:Panel>
        <asp:Panel ID="formPanel" Visible="False" runat="server" HorizontalAlign="Left">
            
            <br />
            <br />
            <table style="width:100%;">
                <tr>
                    <td style="width: 468px">
                        &nbsp;</td>
                    <td style="width: 276px">
                        <asp:Label ID="lblApellido" runat="server" Text="Apellido: "></asp:Label>
                    </td>
                    <td style="width: 103px">
                        <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtApellido" EnableViewState="False" ErrorMessage="El apellido no puede estar vacío" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                    <td style="width: 103px">
                        <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
                    </td>
                    <td dir="ltr" style="width: 249px">
                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtNombre" EnableViewState="False" ErrorMessage="El nombre no puede estar vacío" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                    <td dir="ltr">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 468px">
                        &nbsp;</td>
                    <td style="width: 276px">
                        <asp:Label ID="lblLegajo" runat="server" Text="Legajo: "></asp:Label>
                    </td>
                    <td style="width: 103px">
                        <asp:TextBox ID="txtLegajo" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtLegajo" EnableViewState="False" ErrorMessage="El legajo no puede estar vacío" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtTelefono" ErrorMessage="Ingrese un número entero para el legajo" ForeColor="Red" Operator="DataTypeCheck" Type="Integer">*</asp:CompareValidator>
                    </td>
                    <td style="width: 103px">
                        <asp:Label ID="lblDireccion" runat="server" Text="Dirección: "></asp:Label>
                    </td>
                    <td dir="ltr" style="width: 249px">
                        <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtDireccion" EnableViewState="False" ErrorMessage="La dirección no puede estar vacío" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                    <td dir="ltr">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 468px">
                        &nbsp;</td>
                    <td style="width: 276px">
                        <asp:Label ID="lblTelefono" runat="server" Text="Teléfono: "></asp:Label>
                    </td>
                    <td style="width: 103px">
                        <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTelefono" EnableViewState="False" ErrorMessage="El telefono no puede estar vacío" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                    <td style="width: 103px">
                        <asp:Label ID="lblEmail" runat="server" Text="E-Mail: "></asp:Label>
                    </td>
                    <td style="width: 249px">
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtEmail" EnableViewState="False" ErrorMessage="El email no puede estar vacío" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email inválido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 468px; height: 26px;">
                        </td>
                    <td style="width: 276px; height: 26px;">
                        <asp:Label ID="lblTipoPersona" runat="server" Text="Tipo de Persona: "></asp:Label>
                    </td>
                    <td style="width: 103px; height: 26px;">
                        <asp:DropDownList ID="ddlTipoPersona" runat="server" DataSourceID="DSTipo" DataTextField="valor" DataValueField="valor" >
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="DSTipo" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStringLocal %>" SelectCommand="SELECT 'Alumno' valor union select 'Docente' valor"></asp:SqlDataSource>
                    </td>
                    <td style="width: 103px; height: 26px;">
                        </td>
                    <td style="width: 249px; height: 26px;">
                        </td>
                    <td style="height: 26px"></td>
                </tr>
                <tr>
                    <td style="width: 468px">
                        &nbsp;</td>
                    <td style="width: 276px">
                        <asp:Label ID="lblIDPlan" runat="server" Text="Plan:"></asp:Label>
                    </td>
                    <td style="width: 103px">
                        <asp:DropDownList ID="ddlIDPlan" runat="server" DataSourceID="DSIDPlan" DataTextField="desc_plan" DataValueField="id_plan">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="DSIDPlan" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStringLocal %>" SelectCommand="SELECT [id_plan],desc_plan FROM [planes]"></asp:SqlDataSource>
                    </td>
                    <td style="width: 103px">
                        <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento: "></asp:Label>
                    </td>
                    <td style="width: 249px">
                        <asp:Calendar ID="calFechaNac" runat="server"></asp:Calendar>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 468px">&nbsp;</td>
                    <td style="width: 276px">&nbsp;</td>
                    <td style="width: 103px">&nbsp;</td>
                    <td style="width: 103px">&nbsp;</td>
                    <td style="width: 249px">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
            
            <asp:Panel ID="formActionsPanel" runat="server" HorizontalAlign="Center">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" style="margin-top: 19px" />
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            &nbsp;
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" CausesValidation="False">Cancelar</asp:LinkButton>
              </asp:Panel>
            </asp:Panel>
        


</asp:Content>

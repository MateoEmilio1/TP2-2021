<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    

    <br />
    <br />
    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
        <br />
        Cursos<br />
        <asp:GridView ID="gridCursos" runat="server" DataKeyNames="ID" HorizontalAlign="Center" AutoGenerateColumns="False" OnSelectedIndexChanged="gridView_SelectedIndexChanged" >
            <Columns>
                <asp:BoundField HeaderText="Año" DataField="AnioCalendario" />
                <asp:BoundField HeaderText="Comision" DataField="Comision.Descripcion" />
                <asp:BoundField HeaderText="Materia" DataField="Materia.Descripcion" />
                <asp:BoundField HeaderText="Cupo" DataField="Cupo" />
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
                    <td style="width: 468px">&nbsp;</td>
                    <td style="width: 103px">
                        <asp:Label ID="IDComisionLabel" runat="server" Text="Comision"></asp:Label>
                    </td>
                    <td dir="ltr" style="width: 249px">
                        <asp:DropDownList ID="IDComisionDDL" runat="server" DataSourceID="DSIDComision" DataTextField="desc_comision" DataValueField="id_comision">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="DSIDComision" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStringLocal %>" SelectCommand="SELECT [id_comision], [desc_comision] FROM [comisiones]"></asp:SqlDataSource>
                    </td>
                    <td dir="ltr">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 468px">&nbsp;</td>
                    <td style="width: 103px">
                        <asp:Label ID="IDMateriaLabel" runat="server" Text="Materia: "></asp:Label>
                    </td>
                    <td dir="ltr" style="width: 249px">
                        <asp:DropDownList ID="IDMateriaDDL" runat="server" DataSourceID="DSIDMateria" DataTextField="desc_materia" DataValueField="id_materia">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="DSIDMateria" runat="server" ConnectionString="<%$ ConnectionStrings:ConnStringLocal %>" SelectCommand="SELECT [id_materia], [desc_materia] FROM [materias]"></asp:SqlDataSource>
                    </td>
                    <td dir="ltr">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 468px">&nbsp;</td>
                    <td style="width: 103px">
                        <asp:Label ID="cupoLabel" runat="server" Text="Cupo: "></asp:Label>
                    </td>
                    <td style="width: 249px">
                        <asp:TextBox ID="CupoTextBox" runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator4" runat="server" Operator="DataTypeCheck" ControlToValidate="CupoTextBox" ErrorMessage="Ingrese un número entero para el cupo" ForeColor="Red" Type="Integer">*</asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="CupoTextBox" EnableViewState="False" ErrorMessage="El cupo no puede estar vacío" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 468px">&nbsp;</td>
                    <td style="width: 103px">
                        <asp:Label ID="anioLabel" runat="server" Text="Año: "></asp:Label>
                    </td>
                    <td style="width: 249px">
                        <asp:TextBox ID="AñoTextBox" runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" Operator="DataTypeCheck" ControlToValidate="AñoTextBox" ErrorMessage="Ingrese un número entero para el año" ForeColor="Red" Type="Integer">*</asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="AñoTextBox" EnableViewState="False" ErrorMessage="El año no puede estar vacío" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </td>
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
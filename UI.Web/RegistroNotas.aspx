<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroNotas.aspx.cs" Inherits="UI.Web.RegistroNotas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     

    <br />
    <br />
    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
        Cursos:<br />
        <asp:GridView ID="gridCursos" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" HorizontalAlign="Center" OnSelectedIndexChanged="gridCursos_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Materia.Descripcion" HeaderText="Materia" />
                <asp:BoundField DataField="Comision.Descripcion" HeaderText="Comision" />
                <asp:BoundField DataField="AnioCalendario" HeaderText="Año" />
                <asp:BoundField DataField="Cupo" HeaderText="Cupo" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
            <SelectedRowStyle BackColor="#336699" />
        </asp:GridView>
        <br />
        
    </asp:Panel>
        <asp:Panel ID="formPanel" Visible="False" runat="server" HorizontalAlign="Center">
            
            <asp:Label ID="lblAlumnos" runat="server" Text="Alumnos: "></asp:Label>
            
            <br />
            <asp:Panel ID="Panel3" runat="server" HorizontalAlign="Center">
                <asp:GridView ID="gridAlumnos" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="ObjectDataSource1" HorizontalAlign="Center" OnSelectedIndexChanged="gridAlumnos_SelectedIndexChanged" style="margin-right: 4px">
        
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" InsertVisible="False" ReadOnly="True" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" InsertVisible="False" ReadOnly="True" />
                        <asp:BoundField DataField="Legajo" HeaderText="Legajo" InsertVisible="False" ReadOnly="True" />
                        <asp:TemplateField HeaderText="Nota">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNota" runat="server" Text='<%# Bind("Nota") %>'></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtNota" ErrorMessage="Ingrese un número entero para la nota" ForeColor="Red" Operator="DataTypeCheck" Type="Integer">*</asp:CompareValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNota" EnableViewState="False" ErrorMessage="La nota no puede estar vacía" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Nota") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Condicion">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtCondicion" runat="server" Text='<%# Bind("Condicion") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCondicion" EnableViewState="False" ErrorMessage="La condición no puede estar vacía" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Condicion") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField CancelText="Cancelar" EditText="Editar" ShowEditButton="True" UpdateText="Guardar" />
                    </Columns>
                    <SelectedRowStyle BackColor="#336699" />
                </asp:GridView>
            </asp:Panel>
            
            
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAlumnosCurso" TypeName="Business.Logic.AlumnoInscripcionLogic" UpdateMethod="GuardarNota">
                <SelectParameters>
                    <asp:Parameter DbType="Int32" DefaultValue="0" Name="id_curso" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
            
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            <br />
            <br />
            <br />
            <br />
            </asp:Panel>
        

</asp:Content>

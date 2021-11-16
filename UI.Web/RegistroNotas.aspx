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
            <asp:GridView ID="gridAlumnos" runat="server" DataKeyNames="ID" AutoGenerateColumns="False" HorizontalAlign="Left" OnSelectedIndexChanged="gridAlumnos_SelectedIndexChanged" DataSourceID="ObjectDataSource1" style="margin-right: 4px">
                <Columns>
                    <asp:CommandField ShowEditButton="True" UpdateText="Guardar" CancelText="Cancelar" EditText="Editar" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" ReadOnly="True" InsertVisible="False" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" ReadOnly="True" InsertVisible="False"  />
                    <asp:BoundField DataField="Legajo" HeaderText="Legajo" ReadOnly="True" InsertVisible="False"  />
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
                    
                </Columns>
                <SelectedRowStyle BackColor="#336699" />
            </asp:GridView>
            
            
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAlumnosCurso" TypeName="Business.Logic.AlumnoInscripcionLogic" UpdateMethod="GuardarNota">
                <SelectParameters>
                    <asp:Parameter DbType="Int32" DefaultValue="0" Name="id_curso" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
            
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            <br />
            <br />
            <asp:Label ID="lblNota" runat="server">Nota:</asp:Label>
            <asp:DropDownList ID="ddlNota" runat="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="lblCondicion" runat="server">Condición:</asp:Label>
            <asp:DropDownList ID="ddlCondicion" runat="server">
                <asp:ListItem>Aprobado</asp:ListItem>
                <asp:ListItem>Libre</asp:ListItem>
                <asp:ListItem>Recupera</asp:ListItem>
            </asp:DropDownList>
            <br />
            </asp:Panel>
        <asp:Panel ID="formActionsPanel" runat="server" HorizontalAlign="Center" Visible="False">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            &nbsp;<asp:LinkButton ID="borrarNotaLinkButton" runat="server" OnClick="borrarNotaLinkButton_Click">Borrar Nota</asp:LinkButton>
&nbsp;<asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" CausesValidation="False">Cancelar</asp:LinkButton>
              </asp:Panel>


</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistroNotas.aspx.cs" Inherits="UI.Web.RegistroNotas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .modalContainer {
            display: block;
            position: absolute;
            z-index: 2;
            padding-top: 100px;
            padding-bottom: 1%;
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
            overflow-x: auto;
            background-color: rgb(0,0,0);
            background-color: rgba(0,0,0,0.4);
        }

        .modalContainer .modal-content {
            background-color: #fefefe;
            margin: auto;
            border: 1px solid lightgray;
            padding: 1%;
        }

        @media (min-width: 991.5px) {
			.modalContainer .modal-content {
				width: 50%;
			}

            .alerta{
                width: 25%;
            }
		}

		@media (max-width: 991.5px) {
			.modalContainer .modal-content {
                width: 96%;
			}

            .alerta{
                width: 40%;
            }
		}

        .alerta{
            top: auto; 
            bottom: 0; 
            right: 0; 
            left: auto; 
            position: fixed; 
            z-index: 3;
            height: auto;
            color: white
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav class="navbar navbar-expand-lg navbar-light bg-light" style="top: 85px; position: fixed; z-index: 1; width: 100%; height: 60px;">
        <asp:Panel ID="gridActionsPanel" runat="server" Font-Size="X-Large" style="margin: auto;" HorizontalAlign="Center">
            <asp:LinkButton ID="guardarLinkButton" runat="server" CausesValidation="False" OnClick="guardarLinkButton_Click" Visible="false"><i class="fas fa-save"></i>&nbsp;Guardar</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="habilitarEdicionLinkButton" runat="server" CausesValidation="False" OnClick="habilitarEdicionLinkButton_Click"><i class="fas fa-edit"></i>&nbsp;Habilitar Edición</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="cancelarEdicionLinkButton" runat="server" CausesValidation="False" OnClick="cancelarEdicionLinkButton_Click" Visible="false"><i class="fas fa-window-close"></i>&nbsp;Cancelar Edición</asp:LinkButton>&nbsp;
        </asp:Panel>
    </nav>

    <div class="alert alert-dismissible fade show alerta" role="alert" id="alerta" runat="server" visible="false">
  	    <h5 id='textoAlerta' runat="server"></h5>
        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
            <span aria-hidden="true">&times;</span>
        </button>
    </div>

    <asp:Panel ID="gridPanel" runat="server" style="margin-top: 160px;">
        <asp:Label ID="lblCurso" runat="server" style="margin-left: 5%;" Font-Size="X-Large" Font-Bold="True" Text="Seleccione un curso"></asp:Label>&nbsp;
        <asp:DropDownList ID="DropDownListCursos" runat="server"></asp:DropDownList>&nbsp;
        <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
        <hr />
        <asp:Label ID="lblCursoSeleccionado" runat="server" Text="Curso: " style="margin-left: 5%;" Font-Size="X-Large" Font-Bold="True" Visible="False"></asp:Label>
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" 
            SelectedRowStyle-BackColor="black" SelectedRowStyle-ForeColor="White" 
            DataKeyNames="ID"  Width="90%" Font-Size="Medium" 
            Style="text-align: center; margin-left: auto; margin-right: auto; margin-bottom: auto;" 
            CellPadding="4" ForeColor="#333333" CssClass="auto-style2">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblID" name="lblID" runat="server" Text='<% # Bind("ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Legajo" DataField="LegajoAlumno" ReadOnly="True" />
                <asp:BoundField HeaderText="Nombre" DataField="NombreAlumno" ReadOnly="True" />
                <asp:BoundField HeaderText="Apellido" DataField="ApellidoAlumno" ReadOnly="True" />
                <asp:TemplateField HeaderText="Nota">
                    <ItemTemplate>
                        <asp:TextBox ID="txtNota" name="txtNota" runat="server" Text='<% # Bind("Nota") %>' Enabled="False"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </asp:Panel>
</asp:Content>

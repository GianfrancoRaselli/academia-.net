<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="InscripcionCursos.aspx.cs" Inherits="UI.Web.InscripcionCursos" %>
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
            <asp:LinkButton ID="verComisionesLinkButtontton" runat="server" OnClick="verComisionesLinkButton_Click" CausesValidation="False"><i class="fas fa-book-open"></i>&nbsp;Ver Comisiones</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="verMateriasCorrelativasLinkButtontton" runat="server" OnClick="verMateriasCorrelativasLinkButton_Click" CausesValidation="False"><i class="fas fa-book-open"></i>&nbsp;Ver Materias Correlativas</asp:LinkButton>&nbsp;
        </asp:Panel>
    </nav>

    <div class="alert alert-dismissible fade show alerta" role="alert" id="alerta" runat="server" visible="false">
  	    <h5 id='textoAlerta' runat="server"></h5>
        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
            <span aria-hidden="true">&times;</span>
        </button>
    </div>

    <asp:Panel ID="gridPanel" runat="server" style="margin-top: 160px;">
        <asp:Label ID="lblPlan" runat="server" Text="Materias" style="margin-left: 5%;" Font-Size="X-Large" Font-Bold="True"></asp:Label>
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" 
            SelectedRowStyle-BackColor="black" SelectedRowStyle-ForeColor="White" 
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" 
            Width="90%" Font-Size="Medium" Style="margin: auto; text-align: center" 
            CellPadding="4" ForeColor="#333333">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField HeaderText="Materia" DataField="Descripcion" />
                <asp:BoundField HeaderText="Horas Semanales" DataField="HsSemanales" />
                <asp:BoundField HeaderText="Horas Totales" DataField="HsTotales" />
                <asp:BoundField HeaderText="Condición" DataField="CondicionAlumno" />
                <asp:BoundField HeaderText="Nota" DataField="NotaAlumno" />
                <asp:CommandField HeaderText="Acción" SelectText="Seleccionar" ShowSelectButton="True" />
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
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ComisionesDisponibles.aspx.cs" Inherits="UI.Web.ComisionesDisponibles" %>
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
            <asp:LinkButton ID="volverLinkButtontton" runat="server" OnClick="volverLinkButton_Click" CausesValidation="False"><i class="fas fa-arrow-alt-circle-left"></i>&nbsp;Volver a Inscripción</asp:LinkButton>&nbsp;
        </asp:Panel>
    </nav>

    <div class="alert alert-dismissible fade show alerta" role="alert" id="alerta" runat="server" visible="false">
  	    <h5 id='textoAlerta' runat="server"></h5>
        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
            <span aria-hidden="true">&times;</span>
        </button>
    </div>

    <asp:Panel ID="gridPanel" runat="server" style="margin-top: 160px;">
        <asp:Label ID="lblMateria" runat="server" Text="Materia: " style="margin-left: 5%;" Font-Size="XX-Large" Font-Bold="True"></asp:Label>
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" 
            SelectedRowStyle-BackColor="black" SelectedRowStyle-ForeColor="White" 
            DataKeyNames="ID" Width="90%" Font-Size="Medium" Style="margin: auto; text-align: center" 
            CellPadding="4" ForeColor="#333333" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField HeaderText="Comisión" DataField="DescComision" />
                <asp:BoundField HeaderText="Año" DataField="AnioCalendario" />
                <asp:BoundField HeaderText="Cupos Totales" DataField="Cupos" />
                <asp:BoundField HeaderText="Cupos Disponibles" DataField="CuposDisponibles" />
                <asp:BoundField HeaderText="Cuatrimestre" DataField="TipoCuatrimestre" />
                <asp:BoundField HeaderText="Condición" DataField="CondicionAlumno" />
                <asp:CommandField HeaderText="Acción" SelectText="Inscribirse / Darse de baja" ShowSelectButton="True" />
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

    <asp:Panel runat="server" class="modalContainer" id="modal" Visible="false">
        <asp:Panel class="modal-content" id="modalContent" runat="server" BackColor="#CCCCCC" Font-Size="Medium">
            <asp:Label runat="server" ID="IdLabel" Text="Materia: " Font-Bold="False" Font-Size="X-Large" Visible="False"></asp:Label>

            <div class="form-group" style="margin-bottom: 1%;">
                <asp:Label runat="server" ID="materiaLabel" Text="Materia: " Font-Bold="False" Font-Size="X-Large"></asp:Label>
             </div>  
            
            <div class="form-group" style="margin-bottom: 1%">
                <asp:Label runat="server" ID="comisionLabel" Text="Comisión: " Font-Bold="False" Font-Size="X-Large"></asp:Label>
            </div>
            
            <div class="form-group" style="margin-bottom: 1%;">
                <asp:Label runat="server" ID="anioCalendarioLabel" Text="Año Especialidad: " Font-Bold="False" Font-Size="X-Large"></asp:Label>
            </div>

            <div class="form-group" style="margin-bottom: 1%;">
                <asp:Label runat="server" ID="cuatrimestreLabel" Text="Cuatrimestre: " Font-Bold="False" Font-Size="X-Large"></asp:Label>
            </div>

            <div class="form-group" style="margin-bottom: 2%;">
                <asp:Label runat="server" ID="condicionAlumnoLabel" Text="Estado: " Font-Bold="False" Font-Size="X-Large"></asp:Label>
            </div>

            <asp:Panel ID="formActionsPanel" runat="server" Font-Size="Medium">
                <div class="row">
                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" style="display: block; margin-left: auto; width: 30%;" CausesValidation="False" class="btn btn-success" OnClick="btnAceptar_Click"/>&nbsp;
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" style="display: block; margin-right: auto; width: 30%;" CausesValidation="False" class="btn btn-danger" OnClick="btnCancelar_Click"/>
                </div>
            </asp:Panel>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
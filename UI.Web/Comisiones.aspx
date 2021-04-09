<%@ Page Title="Comisiones" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="UI.Web.Comisiones" %>
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
            <asp:LinkButton ID="agregarLinkButton" runat="server" CausesValidation="False" OnClick="agregarLinkButton_Click"><i class="fas fa-plus-circle"></i>&nbsp;Agregar</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="editarLinkButton" runat="server" CausesValidation="False" OnClick="editarLinkButton_Click"><i class="fas fa-edit"></i>&nbsp;Editar</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="eliminarLinkButton" runat="server" CausesValidation="False" OnClick="eliminarLinkButton_Click"><i class="fas fa-minus-circle"></i>&nbsp;Eliminar</asp:LinkButton>
        </asp:Panel>
    </nav>

    <div class="alert alert-dismissible fade show alerta" role="alert" id="alerta" runat="server" visible="false">
  	    <h5 id='textoAlerta' runat="server"></h5>
        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
            <span aria-hidden="true">&times;</span>
        </button>
    </div>

    <asp:Panel ID="gridPanel" runat="server" style="margin-top: 160px;">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" 
            SelectedRowStyle-BackColor="black" SelectedRowStyle-ForeColor="White" DataKeyNames="ID"  Width="90%" Font-Size="Medium" Style="text-align: center; margin-left: auto; margin-right: auto; margin-bottom: auto;" CellPadding="4" ForeColor="#333333" CssClass="auto-style2" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField HeaderText="ID Comisión" DataField="ID" />
                <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                <asp:BoundField HeaderText="Año Especialidad" DataField="AnioEspecialidad" />
                <asp:BoundField HeaderText="Descripción Plan" DataField="Plan" />
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

    <asp:Panel runat="server" class="modalContainer" id="modal" Visible="false">
        <asp:Panel class="modal-content" id="modalContent" runat="server" BackColor="#CCCCCC" Font-Size="Medium">
            <asp:Label ID="labelForm" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Label" Font-Overline="False" Font-Underline="True" style="text-align: center;"></asp:Label>
            
            <div class="form-group row" style="margin-bottom: 1%; margin-top: 2%;">
                <asp:Label runat="server" ID="idComisionLabel" Text="ID Comision: " Font-Bold="True" Font-Size="Large" class="col-3"></asp:Label>
                <asp:TextBox runat="server" ID="idComisionTextbox" class="form-control col-8" ReadOnly="True"></asp:TextBox>
             </div>  
            
            <div class="form-group row" style="margin-bottom: 1%">
                <asp:Label runat="server" ID="descripcionLabel" Text="Descripcion: " Font-Bold="True" Font-Size="Large" class="col-3"></asp:Label> 
                <asp:TextBox runat="server" ID="descripcionTextBox" class="form-control col-8"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDescripcion" runat="server" class="col-1" ControlToValidate="descripcionTextBox" ErrorMessage="Descipción requerida" ForeColor="Red">*</asp:RequiredFieldValidator> 
            </div>
            
            <div class="form-group row" style="margin-bottom: 1%;">
                <asp:Label runat="server" ID="anioEspecialidadLabel" Text="Año Especialidad: " Font-Bold="True" Font-Size="Large" class="col-3"></asp:Label>
                <asp:TextBox runat="server" ID="anioEspecialidadTexBox" class="form-control col-8"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDireccion" runat="server" class="col-1" ControlToValidate="anioEspecialidadTexBox" ErrorMessage="Año especialidad requerido" ForeColor="Red">*</asp:RequiredFieldValidator> 
            </div>
            
            <div class="form-group row" style="margin-bottom: 2%">
                <asp:Label ID="planLabel" runat="server" Text="Plan: " Font-Bold="True" Font-Size="Large" class="col-3"></asp:Label>
                <asp:DropDownList ID="DropDownListPlan" runat="server" class="form-control col-8"></asp:DropDownList>
            </div>

            <asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor="Red" />
            
            <asp:Panel ID="formActionsPanel" runat="server" Font-Size="Medium">
                <div class="row">
                    <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" style="display: block; margin-left: auto; width: 30%;" class="btn btn-success" OnClick="ButtonAceptar_Click"/>&nbsp;
                    <asp:Button ID="ButtonCancelar" runat="server" Text="Cancelar" style="display: block; margin-right: auto; width: 30%;" CausesValidation="False" class="btn btn-danger" OnClick="ButtonCancelar_Click"/>
                </div>
            </asp:Panel>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
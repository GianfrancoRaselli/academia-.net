<%@ Page Title="Personas" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="UI.Web.Personas" %>
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
            <asp:LinkButton ID="agregarLinkButtontton" runat="server" OnClick="agregarLinkButton_Click" CausesValidation="False"><i class="fas fa-plus-circle"></i>&nbsp;Agregar</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click" CausesValidation="False"><i class="fas fa-edit"></i>&nbsp;Editar</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click" CausesValidation="False"><i class="fas fa-minus-circle"></i>&nbsp;Eliminar</asp:LinkButton>
        </asp:Panel>
    </nav>

    <div class="alert alert-dismissible fade show alerta" role="alert" id="alerta" runat="server" visible="false">
  	    <h5 id='textoAlerta' runat="server"></h5>
        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
            <span aria-hidden="true">&times;</span>
        </button>
    </div>

    <asp:Panel ID="gridPanel" runat="server" style="margin-top: 160px;">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" 
            SelectedRowStyle-BackColor="black" SelectedRowStyle-ForeColor="White" 
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" 
            Width="90%" Font-Size="Medium" Style="margin: auto; text-align: center" 
            CellPadding="4" ForeColor="#333333">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField HeaderText="Legajo" DataField="Legajo" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="Fecha Nacimiento" DataField="FechaNacimientoConFormato" />
                <asp:BoundField HeaderText="Edad" DataField="Edad" />
                <asp:BoundField HeaderText="Teléfono" DataField="Telefono" />
                <asp:BoundField HeaderText="EMail" DataField="Email" />
                <asp:BoundField HeaderText="Dirección" DataField="Direccion" />
                <asp:BoundField HeaderText="Tipo Persona" DataField="TipoPersona" />
                <asp:BoundField HeaderText="Plan" DataField="Plan" />
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
		            <asp:Label ID="legajoLabel" runat="server" Text="Legajo: " Font-Bold="True" Font-Size="Large" class="col-3"></asp:Label>
                    <asp:TextBox ID="legajoTextBox" runat="server" class="form-control col-8" ReadOnly="True"></asp:TextBox>	
  		        </div>

                <div class="form-group row" style="margin-bottom: 1%">
		            <asp:Label ID="nombreLabel" runat="server" Text="Nombre: " Font-Bold="True" Font-Size="Large" class="col-3"></asp:Label>
                    <asp:TextBox ID="nombreTextBox" runat="server" class="form-control col-8"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorNombre" runat="server" class="col-1" ControlToValidate="nombreTextBox" ErrorMessage="Nombre requerido" ForeColor="Red">*</asp:RequiredFieldValidator>
  		        </div>

                <div class="form-group row" style="margin-bottom: 1%">
		            <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: " Font-Bold="True" Font-Size="Large" class="col-3"></asp:Label>
                    <asp:TextBox ID="apellidoTextBox" runat="server" class="form-control col-8"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorApellido" runat="server" class="col-1" ControlToValidate="apellidoTextBox" ErrorMessage="Apellido requerido" ForeColor="Red">*</asp:RequiredFieldValidator>               
                </div>

                <div class="form-group row" style="margin-bottom: 1%">
		            <asp:Label ID="fechaNacimientoLabel" runat="server" Text="Fecha nacimiento: " Font-Bold="True" Font-Size="Large" class="col-3"></asp:Label>
                    <asp:Calendar ID="fechaNacimientoCalendar" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" class="col-8">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>                  
                </div>
   
                <div class="form-group row" style="margin-bottom: 1%">
		            <asp:Label ID="telefonoLabel" runat="server" Text="Teléfono: " Font-Bold="True" Font-Size="Large" class="col-3"></asp:Label>
                    <asp:TextBox ID="telefonoTextBox" runat="server" class="form-control col-8"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTelefono" runat="server" class="col-1" ControlToValidate="telefonoTextBox" ErrorMessage="Teléfono requerido" ForeColor="Red">*</asp:RequiredFieldValidator>    
                </div>

                <div class="form-group row" style="margin-bottom: 1%">
		            <asp:Label ID="emailLabel" runat="server" Text="EMail: " Font-Bold="True" Font-Size="Large" class="col-3"></asp:Label>
                    <asp:TextBox ID="emailTextBox" runat="server" class="form-control col-8"></asp:TextBox>
                    <div class="col-1">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ControlToValidate="emailTextBox" ErrorMessage="EMail requerido" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ControlToValidate="emailTextBox" ErrorMessage="EMail invalido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>      
                    </div>
                </div>

                <div class="form-group row" style="margin-bottom: 1%">
		            <asp:Label ID="direccionLabel" runat="server" Text="Dirección: " Font-Bold="True" Font-Size="Large" class="col-3"></asp:Label>
                    <asp:TextBox ID="direccionTextBox" runat="server" class="form-control col-8"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDireccion" runat="server" class="col-1" ControlToValidate="direccionTextBox" ErrorMessage="Dirección requerida" ForeColor="Red">*</asp:RequiredFieldValidator>    
                </div>

                <div class="form-group row" style="margin-bottom: 1%">
		            <asp:Label ID="tipoPersonaLabel" runat="server" Text="Tipo persona: " Font-Bold="True" Font-Size="Large" class="col-3"></asp:Label>
                    <asp:RadioButtonList ID="RadioButtonListTipoPersona" runat="server">
                        <asp:ListItem Text="&nbsp;Administrativo" Value="0"></asp:ListItem>
                        <asp:ListItem Text="&nbsp;Docente" Value="1"></asp:ListItem>
                        <asp:ListItem Text="&nbsp;Alumno" Value="2" Selected="True"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>

                <div class="form-group row" style="margin-bottom: 2%">
		            <asp:Label ID="planLabel" runat="server" Text="Plan: " Font-Bold="True" Font-Size="Large" class="col-3"></asp:Label>
                    <asp:DropDownList ID="DropDownListPlan" runat="server" class="form-control col-8"></asp:DropDownList>
                </div>
         
                <asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor="Red" />
    
                <asp:Panel ID="formActionsPanel" runat="server" Font-Size="Medium">
                    <div class="row">
                        <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" style="display: block; margin-left: auto; width: 30%;" class="btn btn-success" OnClick="ButtonAceptar_Click" />&nbsp;&nbsp;
                        <asp:Button ID="ButtonCancelar" runat="server" Text="Cancelar" style="display: block; margin-right: auto; width: 30%;" CausesValidation="False" class="btn btn-danger" OnClick="ButtonCancelar_Click" />
                    </div>
                </asp:Panel>
            </asp:Panel>    
	    </asp:Panel>
</asp:Content>


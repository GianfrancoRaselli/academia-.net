<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
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
        <asp:Panel ID="gridActionPanel" runat="server" Font-Size="X-Large" style="margin: auto;" HorizontalAlign="Center">
            <asp:LinkButton ID="nuevoLinkButton" OnClick="nuevoLinkButton_Click" runat="server" CausesValidation="false" ><i class="fas fa-plus-circle"></i>&nbsp;Agregar</asp:LinkButton>    
            <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click" CausesValidation="False"><i class="fas fa-edit"></i>&nbsp;Editar</asp:LinkButton>
            <asp:LinkButton ID="eliminarLinkButton" OnClick="eliminarLinkButton_Click" runat="server" CausesValidation="false"><i class="fas fa-minus-circle"></i>&nbsp;Eliminar</asp:LinkButton>
        </asp:Panel>
     </nav>

     <div class="alert alert-dismissible fade show alerta" role="alert" id="alerta" runat="server" visible="false">
  	    <h5 id='textoAlerta' runat="server"></h5>
        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
            <span aria-hidden="true">&times;</span>
        </button>
    </div>

    <asp:Panel ID="gridPanel" runat="server" style="margin-top: 160px;">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" SelectedRowStyle-BackColor="black" SelectedRowStyle-ForeColor="White"  Width="90%" Font-Size="Medium" Style="margin: auto; text-align: center" CellPadding="4" ForeColor="#333333">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID Usuario" />
                <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre Usuario" />
                <asp:BoundField DataField="Habilitado" HeaderText="Habilitado" />
                <asp:BoundField DataField="CambiaClave" HeaderText="Cambia Clave" />
                <asp:BoundField DataField="Persona.TipoPersona" HeaderText="Tipo Persona" />
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
                <asp:Label ID="idLabel" runat="server" Text="ID Usuario: " Font-Bold="True" Font-Size="Large" class="col-3"></asp:Label>
                <asp:TextBox ID="idTextbox" runat="server" class="form-control col-8" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="form-group row" style="margin-bottom: 1%">
                <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Nombre Usuario: " Font-Bold="True" Font-Size="Large" class="col-3"></asp:Label>
                <asp:TextBox ID="nombreUsuarioTextbox" runat="server" class="form-control col-8"></asp:TextBox>
            </div>
            <div class="form-group row" style="margin-bottom: 1%">
                <asp:Label ID="claveLabel" runat="server" Text="Clave: " Font-Bold="True" Font-Size="Large" class="col-3"></asp:Label>
                <asp:TextBox ID="claveTextBox" runat="server" type="password" minlength="8" class="form-control col-8"></asp:TextBox>
            </div>
            <div class="form-group row" style="margin-bottom: 1%">
                <asp:Label ID="confirmaClaveLabel" runat="server" Text="Confirma Clave: " Font-Bold="True" Font-Size="Large" class="col-3"></asp:Label>
                <asp:TextBox ID="confirmaClaveTextBox" runat="server" TextMode="Password" minlength="8" class="form-control col-8" ></asp:TextBox>
            </div>
            <div class="form-group row" style="margin-bottom: 1%">
                <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado: " Font-Bold="True" Font-Size="Large" class="col-3"></asp:Label>
                <asp:CheckBox ID="habilitadoCheckbox" runat="server" />
            </div>
            <div class="form-group row" style="margin-bottom: 1%">
                <asp:Label ID="cambiaClaveLabel" runat="server" Text="Cambia Clave: " Font-Bold="True" Font-Size="Large" class="col-3"></asp:Label>
                <asp:CheckBox ID="cambiaClaveCheckbox" runat="server" />
            </div>
            <div class="form-group row" style="margin-bottom: 1%">
                <asp:Label ID="PersonasLabel" runat="server" Text="Persona: " Font-Bold="True" Font-Size="Large" class="col-3"></asp:Label>
                <asp:DropDownList ID="DropDownListUsuarios" runat="server" class="form-control col-8">
                </asp:DropDownList>

            </div>
           
            
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor="Red" />

            <asp:Panel ID="formActionsPanel" runat="server" Font-Size="Medium">
                <div class="row" >
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="aceptarLinkButton_Click" Text="Aceptar" style="display: block; margin-left: auto; width: 30%;" class="btn btn-success"/>&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton2" runat="server" Text="Cancelar" Onclick="cancelarLinkButton_Click" style="display: block; margin-right: auto; width: 30%;" CausesValidation="False" class="btn btn-danger"/>
                </div>
            </asp:Panel>
        </asp:Panel>
    </asp:Panel>
    
</asp:Content>


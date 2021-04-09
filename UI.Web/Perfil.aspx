<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="UI.Web.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        @media (min-width: 991.5px) {
            .alerta{
                width: 25%;
            }
		}

		@media (max-width: 991.5px) {
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
    <div class="alert alert-dismissible fade show alerta" role="alert" id="alerta" runat="server" visible="false">
  	    <h5 id='textoAlerta' runat="server"></h5>
        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
            <span aria-hidden="true">&times;</span>
        </button>
    </div>

    <asp:Panel runat="server" style="margin-top: 6%; margin-bottom: 3%; padding-left: 20%; padding-right: 20%;">
        <div style="text-align: center;"><asp:Label ID="lblTitulo" runat="server" Text="Información Personal" Font-Underline="True" Font-Size="XX-Large" Font-Bold="True"></asp:Label></div>
        <br />
        <div class="row">
            <div class="col-4"><asp:Label ID="lbl1" runat="server" Text="Legajo" Font-Bold="True"></asp:Label></div>
            <div class="col-7"><asp:Label ID="lblLegajo" runat="server" Text="Label"></asp:Label></div>
            <div class="col-1"></div>
        </div>
        <hr />

        <div class="row">
            <div class="col-4"><asp:Label ID="lbl2" runat="server" Text="Nombre" Font-Bold="True"></asp:Label></div>
            <div class="col-7"><asp:Label ID="lblNombre" runat="server" Text="Label"></asp:Label></div>
            <div class="col-1"></div>
        </div>
        <hr />

        <div class="row">
            <div class="col-4"><asp:Label ID="lbl3" runat="server" Text="Apellido" Font-Bold="True"></asp:Label></div>
            <div class="col-7"><asp:Label ID="lblApellido" runat="server" Text="Label"></asp:Label></div>
            <div class="col-1"></div>
        </div>
        <hr />

        <div class="row">
            <div class="col-4"><asp:Label ID="lbl4" runat="server" Text="Fecha Nacimiento" Font-Bold="True"></asp:Label></div>
            <div class="col-7"><asp:Label ID="lblFechaNacimiento" runat="server" Text="Label"></asp:Label></div>
            <div class="col-1"></div>
        </div>
        <hr />

        <div class="row">
            <div class="col-4"><asp:Label ID="lb5" runat="server" Text="Edad" Font-Bold="True"></asp:Label></div>
            <div class="col-7"><asp:Label ID="lblEdad" runat="server" Text="Label"></asp:Label></div>
            <div class="col-1"></div>
        </div>
        <hr />

        <div class="row">
            <div class="col-4"><asp:Label ID="lbl6" runat="server" Text="Dirección" Font-Bold="True"></asp:Label></div>
            <div class="col-7">
                <asp:Label ID="lblDireccion" runat="server" Text="Label"></asp:Label>
                <asp:TextBox ID="txtDireccion" runat="server" Visible="False"></asp:TextBox>
            </div>
            <div class="col-1">
                <asp:LinkButton ID="LinkButtonEditarDireccion" runat="server" Font-Size="Small" OnClick="LinkButtonEditar_Click">Editar</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonGuardarDireccion" runat="server" Visible="false" OnClick="LinkButtonGuardar_Click">Guardar</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonCancelarDireccion" runat="server" Visible="false" OnClick="LinkButtonCancelar_Click">Cancelar</asp:LinkButton>
            </div>
        </div>
        <hr />

        <div class="row">
            <div class="col-4"><asp:Label ID="lbl7" runat="server" Text="Teléfono" Font-Bold="True"></asp:Label></div>
            <div class="col-7">
                <asp:Label ID="lblTelefono" runat="server" Text="Label"></asp:Label>
                <asp:TextBox ID="txtTelefono" runat="server" Visible="false"></asp:TextBox>
            </div>
            <div class="col-1">
                <asp:LinkButton ID="LinkButtonEditarTelefono" runat="server" Font-Size="Small" OnClick="LinkButtonEditar_Click">Editar</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonGuardarTelefono" runat="server" Visible="false" OnClick="LinkButtonGuardar_Click">Guardar</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonCancelarTelefono" runat="server" Visible="false" OnClick="LinkButtonCancelar_Click">Cancelar</asp:LinkButton>
            </div>
        </div>
        <hr />

        <div class="row">
            <div class="col-4"><asp:Label ID="lbl8" runat="server" Text="EMail" Font-Bold="True"></asp:Label></div>
            <div class="col-7">
                <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" Visible="False"></asp:TextBox>
            </div>
            <div class="col-1">
                <asp:LinkButton ID="LinkButtonEditarEmail" runat="server" Font-Size="Small" OnClick="LinkButtonEditar_Click">Editar</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonGuardarEmail" runat="server" Visible="false" OnClick="LinkButtonGuardar_Click">Guardar</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonCancelarEmail" runat="server" Visible="false" OnClick="LinkButtonCancelar_Click">Cancelar</asp:LinkButton>
            </div>
        </div>
        <hr />

        <div class="row">
            <div class="col-4"><asp:Label ID="lbl9" runat="server" Text="Nombre Usuario" Font-Bold="True"></asp:Label></div>
            <div class="col-7">
                <asp:Label ID="lblNombreUsuario" runat="server" Text="Label"></asp:Label>
                <asp:TextBox ID="txtNombreUsuario" runat="server" Visible="False"></asp:TextBox>
            </div>
            <div class="col-1">
                <asp:LinkButton ID="LinkButtonEditarNombreUsuario" runat="server" Font-Size="Small" OnClick="LinkButtonEditar_Click">Editar</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonGuardarNombreUsuario" runat="server" Visible="false" OnClick="LinkButtonGuardar_Click">Guardar</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonCancelarNombreUsuario" runat="server" Visible="false" OnClick="LinkButtonCancelar_Click">Cancelar</asp:LinkButton>
            </div>
        </div>
        <hr />

        <div class="row">
            <div class="col-4"><asp:Label ID="lbl10" runat="server" Text="Clave" Font-Bold="True"></asp:Label></div>
            <div class="col-7">
                <asp:Label ID="lblClave" runat="server" Text="Label"></asp:Label>
                <asp:TextBox ID="txtClave" runat="server" Visible="False"></asp:TextBox>
            </div>
            <div class="col-1">
                <asp:LinkButton ID="LinkButtonEditarClave" runat="server" Font-Size="Small" OnClick="LinkButtonEditar_Click">Editar</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonGuardarClave" runat="server" Visible="false" OnClick="LinkButtonGuardar_Click">Guardar</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonCancelarClave" runat="server" Visible="false" OnClick="LinkButtonCancelar_Click">Cancelar</asp:LinkButton>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
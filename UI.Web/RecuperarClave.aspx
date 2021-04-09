<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperarClave.aspx.cs" Inherits="UI.Web.RecuperarClave" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<link href="style/bootstrap.min.css" rel="stylesheet" />
    <link href="style/login.css" rel="stylesheet" />
	<script src="https://kit.fontawesome.com/5520773c7b.js" crossorigin="anonymous"></script>
    <title>Recuperar clave</title>
</head>
<body>
	<form id="form1" runat="server">
		<asp:Panel runat="server" ID="panelLegajo">
			<div class="login">
				<div class="login-screen">
					<div class="app-title">
						<h1>Recuperar Usuario</h1>
					</div>
		
					<div class="login-form">
						<div class="control-group">
							<asp:TextBox ID="txtLegajo" runat="server" class="login-field" placeholder="Legajo" required="true"></asp:TextBox>
							<asp:Label ID="lblErrorLegajo" runat="server" Text="" class="login-field-icon fui-user" style="color: red;"></asp:Label>
						</div>
						
						<asp:Button ID="btnBuscar" runat="server" Text="Buscar Persona" OnClick="btnBuscar_Click" class="btn btn-primary btn-large btn-block"/>

						<div style="margin-top: 4%;"><asp:LinkButton ID="lnkVolverInicioSesion" runat="server" Text="Volver a Inicio de Sesión" type="buttom" OnClick="lnkVolverInicioSesion_Click"></asp:LinkButton></div>
					</div>

					<div style="color: red; margin-top: 6%; text-align: center;">
						<asp:Label ID="lblError" runat="server" Text=""></asp:Label>
					</div>
				</div>
			</div>
		</asp:Panel>

		<asp:Panel runat="server" ID="panelCorreo" Visible="false">
			<div class="login">
				<div class="login-screen">
					<div class="app-title">
						<h1>Recuperar Usuario</h1>
					</div>
		
					<div class="login-form">
                        <asp:Label ID="lblCorreo" runat="server" Text="Label"></asp:Label>

						<asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" class="btn btn-primary btn-large btn-block"/>

						<div style="margin-top: 4%;"><asp:LinkButton ID="lnkVolver" runat="server" Text="Volver" type="buttom" OnClick="lnkVolver_Click"></asp:LinkButton></div>
					</div>
				</div>
			</div>
		</asp:Panel>
	</form>
</body>
</html>
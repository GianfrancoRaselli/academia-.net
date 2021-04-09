<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="style/bootstrap.min.css" rel="stylesheet" />
    <link href="style/login.css" rel="stylesheet" />
	<script src="https://kit.fontawesome.com/5520773c7b.js" crossorigin="anonymous"></script>
    <title>Inicio Sesión</title>
</head>
<body>
	<form id="form1" runat="server" name="login">
		<h1 style="text-align: center;"><asp:Label ID="lblBienvenido" runat="server" Text="¡Bienvenido al Sistema!" style="font-size: xx-large; font-weight: 700;"></asp:Label></h1>

		<div class="login">
			<div class="login-screen">
				<div class="app-title">
					<h1>Inicio sesión</h1>
				</div>
		
				<div class="login-form">
					<div class="control-group">
                        <asp:TextBox ID="txtUsuario" runat="server" class="login-field" placeholder="Nombre de usuario" required="true" minlength="6"></asp:TextBox>
						<asp:Label ID="lblErrorNombreUsuario" runat="server" Text="" class="login-field-icon fui-user" style="color: red;"></asp:Label>
                    </div>
		
					<div class="control-group">
                        <asp:TextBox ID="txtClave" runat="server" type="password" class="login-field" placeholder="Clave" required="true" minlength="8"></asp:TextBox>
						<asp:Label ID="lblErrorContrasenia" runat="server" Text="" class="login-field-icon fui-lock" style="color: red;"></asp:Label>
					</div>
						
					<asp:Button ID="btnIngresar" runat="server" Text="Iniciar sesión" OnClick="btnIngresar_Click" class="btn btn-primary btn-large btn-block"/>
						
					<div style="margin-top: 4%;"><asp:LinkButton ID="lnkRecordarClave" runat="server" Text="Olvidé mi Clave" type="buttom" OnClick="lnkRecordarClave_Click"></asp:LinkButton></div>
				</div>

				<div style="color: red; margin-top: 6%; text-align: center;">
                    <asp:Label ID="lblErrorInicioSesion" runat="server" Text=""></asp:Label>
				</div>
			</div>
		</div>
	</form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Correo.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous"/>
	<script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js" integrity="sha384-IQsoLXl5PILFhosVNubq5LC7Qb9DXgDA9i+tQ8Zj3iwWAwPtgFTxbJ8NT4GN1R8p" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.min.js" integrity="sha384-cVKIPhGWiC2Al4u+LWgxfKTRIcfu0JTxR+EQDz/bgldoEyl4H0zUF0QKbrJ0EcQF" crossorigin="anonymous"></script>
	<link href="StyleSheet1.css" rel="stylesheet" />
   
    
	<title>Login</title>
</head>
<body>
    <form id="form1" runat="server">

        <div>
			<div class="login-wrap">
	<div class="login-html">
		<input id="tab-1" type="radio" name="tab" class="sign-in" checked><label for="tab-1" class="tab">Ingresar</label>
		<input id="tab-2" type="radio" name="tab" class="sign-up"><label for="tab-2" class="tab">Registrarse</label>
		<div class="login-form">
			<div class="sign-in-htm">
				<div class="group">
					<label for="user" class="label">Email</label>
					<asp:TextBox ID="TextBoxemail" CssClass="input" runat="server"></asp:TextBox>
				</div>
				<div class="group">
					<label for="pass" class="label">Contraseña</label>
				    <asp:TextBox ID="TextBoxpass" CssClass="input" runat="server"></asp:TextBox>
				</div>
				<div class="group">
					<input id="check" type="checkbox" class="check" >
					<label for="check"><span class="icon"></span> Keep me Signed in</label>
				</div>
				<div class="group">
				<asp:Button ID="ButtonSignIn" CssClass="button" runat="server" Text="Sign In" OnClick="ButtonSignIn_Click" />
&nbsp;</div>
				<div class="hr"></div>
				<div class="foot-lnk">
					<a href="#forgot">Forgot Password?</a>
				</div>
			</div>
			<div class="sign-up-htm">
				<div class="group">
					<label for="user" class="label">Nombre</label>
					<asp:TextBox ID="TBuser" CssClass="input" runat="server"></asp:TextBox>
				<div class="group">
					<label for="pass" class="label">Apellido</label>
					<asp:TextBox ID="TBapellido" CssClass="input" runat="server"></asp:TextBox>
				</div>
				</div>
				<div class="group">
					<label for="pass" class="label">Contraseña</label>
					<asp:TextBox ID="TBpassword" CssClass="input" runat="server"></asp:TextBox>
				</div>
				<div class="group">
					<label for="pass" class="label">Confirme Contraseña</label>
					<asp:TextBox ID="TBpasswordconfirm" CssClass="input" runat="server"></asp:TextBox>
				</div>
				<div class="group">
					<label for="pass" class="label">Email</label>
                    <div class="input-group">
						<asp:TextBox ID="TBcorreo" CssClass="input w-auto" runat="server"></asp:TextBox>
						<span class="input-group-text input w-auto">@lake.com</span>
			
					</div>
				</div>
				<div class="group">
					<label for="pass" class="label">Fecha de nacimiento</label>
					<asp:TextBox ID="TBfecha" CssClass="input" runat="server" TextMode="Date"></asp:TextBox>
				</div>
				<div class="group">
					<asp:Button ID="BTSubmit" cssclass="button" runat="server" Text="Submit" OnClick="BTSubmit_Click" />
				</div>
				<div class="hr"></div>
				<div class="foot-lnk">
					<label for="tab-1">Already Member?<label/>
				</div>
			</div>
		</div>
	</div>
</div>
        </div>
    </form>
</body>
</html>

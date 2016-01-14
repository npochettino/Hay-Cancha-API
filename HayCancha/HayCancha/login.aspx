<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="HayCancha.login" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<!DOCTYPE html>
<html dir="ltr" lang="en-US">
<head>

    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta name="author" content="SempaIT" />

    <!-- Stylesheets
	============================================= -->
    <link href="http://fonts.googleapis.com/css?family=Lato:300,400,400italic,600,700|Raleway:300,400,500,600,700|Crete+Round:400italic" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="css/bootstrap.css" type="text/css" />
    <link rel="stylesheet" href="css/style.css" type="text/css" />
    <link rel="stylesheet" href="css/dark.css" type="text/css" />
    <link rel="stylesheet" href="css/font-icons.css" type="text/css" />
    <link rel="stylesheet" href="css/animate.css" type="text/css" />
    <link rel="stylesheet" href="css/magnific-popup.css" type="text/css" />

    <link rel="stylesheet" href="css/responsive.css" type="text/css" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!--[if lt IE 9]>
		<script src="http://css3-mediaqueries-js.googlecode.com/svn/trunk/css3-mediaqueries.js"></script>
	<![endif]-->

    <!-- External JavaScripts
	============================================= -->
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/plugins.js"></script>

    <!-- Document Title
	============================================= -->
    <title>Hay Cancha | Login</title>

    <link rel="shortcut icon" href="images/hayCancha/favicon.png">
</head>

<body class="stretched">
    <form runat="server">
        <!-- Document Wrapper
	============================================= -->
        <div id="wrapper" class="clearfix">

            <!-- Content
		============================================= -->
            <section id="content">

                <div class="content-wrap nopadding">

                    <div class="section nopadding nomargin" style="width: 100%; height: 100%; position: fixed; left: 0; top: 0; background: url('images/parallax/home/1.jpg') center center no-repeat; background-size: cover;"></div>

                    <div class="section nobg full-screen nopadding nomargin">
                        <div class="container vertical-middle divcenter clearfix">

                            <div class="row center">
                                <a href="index.aspx">
                                    <img src="images/hayCancha/hay_cancha_login.png" alt="HayCancha!" class="logo-default"></a>
                            </div>

                            <div class="panel panel-default divcenter noradius noborder" style="max-width: 400px; background-color: rgba(255,255,255,0.93);">
                                <div class="panel-body" style="padding: 40px;">
                                    <form id="login-form" name="login-form" class="nobottommargin" action="#" method="post">
                                        <div id="divLogin" runat="server">
                                            <section id="form-login" style="display: block">
                                                <h3>Ingresa a tu cuenta</h3>
                                                <div class="col_full">
                                                    <label id="lblErrorLogin" runat="server" class="errormsg" style="display: none">Email o Contraseña incorrecta!</label>
                                                </div>
                                                <div class="col_full">
                                                    <label for="login-form-username">Email:</label>
                                                    <input type="text" id="txtEmail" runat="server" name="login-form-username" value="" class="form-control not-dark" />
                                                </div>

                                                <div class="col_full">
                                                    <label for="login-form-password">Contraseña:</label>
                                                    <input type="password" id="txtContraseña" runat="server" name="login-form-password" value="" class="form-control not-dark" />
                                                </div>

                                                <div class="col_full nobottommargin">
                                                    <asp:Button class="button button-3d button-black nomargin" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" name="login-form-submit" value="login" />
                                                    <a href="#" class="fright" onclick="showForgotPassword()">Recuperar Contraseña?</a>
                                                    <br />
                                                    <a href="registro.aspx" class="fright">Registrate</a>
                                                </div>
                                            </section>
                                        </div>
                                        <div id="divForgotPass" runat="server">
                                            <section id="form-reset-password" style="display: none">
                                                <h3>Recuperar contraseña</h3>
                                                <div class="col_full">
                                                    <label id="lblErrorForgotPass" runat="server" class="errormsg" style="display: none">Email incorrecto!</label>
                                                    <label id="lblOkForgotPass" runat="server" class="msgtitle" style="display: none">Email enviado correctamente!</label>
                                                </div>
                                                <div class="col_full">
                                                    <label for="login-form-username">Email:</label>
                                                    <input type="text" runat="server" id="txtMailOlvidaPass" name="login-form-username" value="" class="form-control not-dark" />
                                                </div>
                                                <div class="col_full nobottommargin">
                                                    <asp:Button class="button button-3d button-black nomargin" ID="btnForgotPassword" runat="server" Text="Enviar" OnClick="btnForgotPassword_Click" value="Enviar" />
                                                    <a href="#" class="fright" onclick="showFormLogin()">Volver</a>
                                                </div>
                                            </section>
                                        </div>
                                    </form>
                                </div>
                            </div>

                            <div class="row center dark"><small>Copyrights &copy; All Rights Reserved by SempaIT</small></div>

                        </div>
                    </div>

                </div>

            </section>
            <!-- #content end -->

        </div>
        <!-- #wrapper end -->

        <!-- Go To Top
	============================================= -->
        <div id="gotoTop" class="icon-angle-up"></div>

        <!-- Footer Scripts
	============================================= -->
        <script type="text/javascript" src="js/functions.js"></script>
        <script type="text/javascript">
            function showForgotPassword() {
                document.getElementById("form-reset-password").style.display = "block";
                document.getElementById("form-login").style.display = "none";
            }
            function showFormLogin() {
                document.getElementById("form-reset-password").style.display = "none";
                document.getElementById("form-login").style.display = "block";
            }
        </script>
    </form>
</body>
</html>

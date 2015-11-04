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

                            <div class="row center" >
                                <a href="index.aspx">
                                    <img src="images/logo-dark.png" alt="Hay Cancha Logo"></a>
                            </div>

                            <div class="panel panel-default divcenter noradius noborder" style="max-width: 400px; background-color: rgba(255,255,255,0.93);">
                                <div class="panel-body" style="padding: 40px;">
                                    <form id="login-form" name="login-form" class="nobottommargin" action="#" method="post">
                                        <section id="form-login" style="display: block">
                                            <h3>Ingresa a tu cuenta</h3>
                                            <div class="col_full">
                                                <label id="lblErrorLogin" runat="server" class="errormsg" style="display: none">Email o Contraseña incorrecta!</label></div>
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
                                            </div>

                                            <div class="line line-sm"></div>

                                            <div class="center">
                                                <h4 style="margin-bottom: 15px;">o Ingresa con:</h4>
                                                <a href="#" class="button button-rounded si-facebook si-colored">Facebook</a>
                                            </div>

                                        </section>
                                        <section id="form-reset-password" style="display: none">
                                            <h3>Recuperar contraseña</h3>
                                            <div class="col_full">
                                                <label id="lblErrorForgotPass" runat="server" class="errormsg" style="display: none">Email incorrecto!</label></div>
                                            <div class="col_full">
                                                <label for="login-form-username">Email:</label>
                                                <input type="text" id="Text1" name="login-form-username" value="" class="form-control not-dark" />
                                            </div>
                                            <div class="col_full nobottommargin">
                                                <asp:Button class="button button-3d button-black nomargin" ID="btnForgotPassword" UseSubmitBehavior="false" runat="server" Text="Enviar" OnClick="btnForgotPassword_Click" value="Enviar" />
                                                <a href="#" class="fright" onclick="showFormLogin()">Volver</a>
                                            </div>
                                        </section>
                                    </form>
                                </div>
                            </div>

                           
                                <%--<div class="accordion accordion-lg divcenter nobottommargin clearfix" style="max-width: 550px;">

                                    <div class="acctitle"><i class="acc-closed icon-lock3"></i><i class="acc-open icon-unlock"></i>Login to your Account</div>
                                    <div class="acc_content clearfix">
                                        <form id="login-form" name="login-form" class="nobottommargin" action="#" method="post">
                                            <div class="col_full">
                                                <label for="login-form-username">Username:</label>
                                                <input type="text" id="login-form-username" name="login-form-username" value="" class="form-control" />
                                            </div>

                                            <div class="col_full">
                                                <label for="login-form-password">Password:</label>
                                                <input type="password" id="login-form-password" name="login-form-password" value="" class="form-control" />
                                            </div>

                                            <div class="col_full nobottommargin">
                                                <button class="button button-3d button-black nomargin" id="login-form-submit" name="login-form-submit" value="login">Login</button>
                                                <a href="#" class="fright">Forgot Password?</a>
                                            </div>
                                        </form>
                                    </div>

                                    <div class="acctitle"><i class="acc-closed icon-user4"></i><i class="acc-open icon-ok-sign"></i>New Signup? Register for an Account</div>
                                    <div class="acc_content clearfix">
                                        <form id="register-form" name="register-form" class="nobottommargin" action="#" method="post">
                                            <div class="col_full">
                                                <label for="register-form-email">Email Address:</label>
                                                <input type="text" id="register-form-email" name="register-form-email" value="" class="form-control" />
                                            </div>

                                            <div class="col_full">
                                                <label for="register-form-password">Choose Password:</label>
                                                <input type="password" id="register-form-password" name="register-form-password" value="" class="form-control" />
                                            </div>

                                            <div class="col_full">
                                                <label for="register-form-repassword">Re-enter Password:</label>
                                                <input type="password" id="register-form-repassword" name="register-form-repassword" value="" class="form-control" />
                                            </div>

                                            <div class="col_full nobottommargin">
                                                <button class="button button-3d button-black nomargin" id="register-form-submit" name="register-form-submit" value="register">Register Now</button>
                                            </div>
                                        </form>
                                    </div>

                                </div>

                           --%>

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

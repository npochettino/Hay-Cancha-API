<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registro.aspx.cs" Inherits="HayCancha.registro" %>

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
    <title>Hay Cancha</title>

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
                                <%--<a href="index.html">
                                    <img src="images/hay_cancha.png" alt="Canvas Logo"></a>--%>
                            </div>

                            <div class="panel panel-default divcenter noradius noborder" style="max-width: 400px; background-color: rgba(255,255,255,0.93);">
                                <div class="panel-body" style="padding: 40px;">
                                    <form id="login-form" name="login-form" class="nobottommargin" action="#" method="post">
                                        <%--<h3>Formulario de Registro</h3>--%>
                                        <div class="col_full">
                                            <label for="register-form-email">Email:</label>
                                            <input type="text" id="txtEmail" name="register-form-email" runat="server" value="" class="form-control" />
                                        </div>
                                        <div class="col_full">
                                            <label for="register-form-password">Choose Password:</label>
                                            <input type="password" id="txtContraseña" runat="server" name="register-form-password" value="" class="form-control" />
                                        </div>
                                        <div class="col_full">
                                            <label for="register-form-repassword">Re-enter Password:</label>
                                            <input type="password" id="txtReContraseña" runat="server" name="register-form-repassword" value="" class="form-control" />
                                        </div>
                                        <div class="col_full nobottommargin">
                                            <asp:Button class="button button-3d button-black nomargin" ID="btnRegistro" runat="server" Text="Registrar" OnClick="btnRegistro_Click" name="login-form-submit" value="registrar" />
                                        </div>

                                        <div class="line line-sm"></div>

                                        <div class="center">
                                            <h4 style="margin-bottom: 5px;">o Registrate con:</h4>
                                            <a href="#" class="button button-rounded si-facebook si-colored">Facebook</a>
                                            <%--<span class="hidden-xs">or</span>
                                            <a href="#" class="button button-rounded si-twitter si-colored">Twitter</a>--%>
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
    </form>
</body>
</html>

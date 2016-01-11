<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="HayCancha.index" %>

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

    <link rel="shortcut icon" href="images/hayCancha/favicon.png">

</head>

<%--<body class="stretched">--%>
    <body class="stretched" data-loader="1" data-loader-timeout="8000" data-animation-in="fadeIn" data-speed-in="1500" data-animation-out="fadeOut" data-speed-out="800">
    <form runat="server">
        <!-- Document Wrapper
	============================================= -->
        <div id="wrapper" class="clearfix">

            <!-- Header
		============================================= -->
            <header id="header" class="full-header">

                <div id="header-wrap">
                    <div class="container clearfix">
                        <div id="primary-menu-trigger"><i class="icon-reorder"></i></div>
                        <!-- Logo
					============================================= -->
                        <div id="logo">
                            <a href="index.aspx" class="standard-logo" data-dark-logo="images/hayCancha/logo-dark.png">
                                <img src="images/hayCancha/hay_cancha.png" alt="Hay Cancha Logo"></a>
                            <a href="index.aspx" class="retina-logo" data-dark-logo="images/hayCancha/logo-dark@2x.png">
                                <img src="images/hayCancha/hay_cancha.png" alt="Hay Cancha Logo"></a>
                        </div>
                        <!-- #logo end -->
                        <!-- Primary Navigation
					============================================= -->
                        <nav id="primary-menu">
                            <ul>
                                <li class="current"><a href="index.html">
                                    <div>Inicio</div>
                                </a></li>
                                <li class="mega-menu"><a href="registro.aspx">
                                    <div>Crea tu cuenta</div>
                                </a></li>
                                <li class="mega-menu"><a href="login.aspx">
                                    <div>Ingresa</div>
                                </a></li>
                            </ul>
                        </nav>
                        <!-- #primary-menu end -->
                    </div>
                </div>
            </header>
            <!-- #header end -->

            <section id="slider" class="slider-parallax full-screen">
                <div class="full-screen" style="height: 513px; background: url('images/appshowcase/1.jpg'); background-size: cover;">
                    <div class="container clearfix">

                        <img src="images/hayCancha/img_index_1.png" alt="Image" class="hidden-sm hidden-xs" style="padding-top: 100px" data-style-lg="position: absolute; left: 0; bottom: 0; height: auto;padding-top" data-style-md="position: absolute; left: 0; bottom: 0; height: 450px;">

                        <div class="vertical-middle no-fade">
                            <div class="col-md-6 dark fright nobottommargin" data-animate="fadeIn">

                                <div class="emphasis-title">
                                    <h1 data-style-lg="font-size: 52px;" data-style-md="font-size: 44px;">La nueva forma de reservar tu cancha. Usá <strong>Hay Cancha</strong>.</h1>
                                </div>

                                <div class="hidden-xs">
                                    <a href="#" class="button button-desc button-border button-light button-rounded nomargin"><i class="icon-android"></i>
                                        <div>Descarga la App<span>Google Play</span></div>
                                    </a>
                                </div>

                                <div class="visible-xs">
                                    <a href="#" class="button button-light button-xlarge button-rounded nomargin"><i class="icon-android"></i>Descarga la App</a>
                                </div>

                            </div>
                        </div>

                    </div>
                </div>
            </section>

            <!-- Content
		============================================= -->
            <section id="content">

                <div class="content-wrap">

                    

                    <div class="section notopmargin nobottommargin">
                        <div class="container clearfix">

                            <div class="col_half nobottommargin topmargin-lg">

                                <img src="images/hayCancha/img_index_2.png" alt="Image" class="center-block">
                            </div>

                            <div class="col_half nobottommargin topmargin-lg col_last">

                                <div class="heading-block topmargin-lg">
                                    <h2>Reserva tu Cancha</h2>
                                    <span>Usá Hay Cancha para reservar tu cancha.</span>
                                </div>

                                <p>Hay Cancha es la nueva forma de reservar tu cancha.</p>

                                <a href="#" class="button button-border button-rounded button-large button-dark noleftmargin">Descarga la App</a>

                            </div>

                        </div>
                    </div>

                    

                    <div id="registrate" class="container clearfix">

                        <div class="heading-block center">
                            <h3>Tenes un complejo?</h3>
                            <span>Contactate con el equipo de Hay Cancha</span>
                        </div>

                        
                        <div class="col_full center topmargin nobottommargin">

                        <div id="widget-subscribe-form2-result" data-notify-type="success" data-notify-msg=""></div>
                        <form id="widget-subscribe-form2" action="include/subscribe.php" role="form" method="post" class="nobottommargin">
                            <div class="input-group input-group-lg divcenter" style="max-width: 600px;">
                                <span class="input-group-addon"><i class="icon-user"></i></span>
                                <input type="email" name="widget-subscribe-form-email" class="form-control required email" placeholder="Ingresa el Nombre de tu Complejo">
                            </div>
                            <div class="input-group input-group-lg divcenter" style="max-width: 600px;">
                                <span class="input-group-addon"><i class="icon-email2"></i></span>
                                <input type="email" name="widget-subscribe-form-email" class="form-control required email" placeholder="Ingresa tu Email">
                            </div>
                            <div class="input-group input-group-lg divcenter" style="max-width: 600px;">
                                <span class="input-group-addon"><i class="icon-calculator"></i></span>
                                <input type="password" name="widget-subscribe-form-email" class="form-control required password" placeholder="Ingresa tu Teléfono">
                            </div>
                            <hr />
                            <div class="input-group input-group-lg divcenter" style="max-width: 600px;">
                                <button class="button button-light button-xlarge button-rounded nomargin" type="submit">Enviar</button>
                            </div>
                        </form>

                        <script>
                            $("#widget-subscribe-form2").validate({
                                submitHandler: function (form) {
                                    $(form).find('.input-group-addon').find('.icon-email2').removeClass('icon-email2').addClass('icon-line-loader icon-spin');
                                    $(form).ajaxSubmit({
                                        target: '#widget-subscribe-form2-result',
                                        success: function () {
                                            $(form).find('.input-group-addon').find('.icon-line-loader').removeClass('icon-line-loader icon-spin').addClass('icon-email2');
                                            $('#widget-subscribe-form2').find('.form-control').val('');
                                            $('#widget-subscribe-form2-result').attr('data-notify-msg', $('#widget-subscribe-form2-result').html()).html('');
                                            SEMICOLON.widget.notifications($('#widget-subscribe-form2-result'));
                                        }
                                    });
                                }
                            });
                        </script>

                    </div>

                </div>

            </section>
            <!-- #content end -->

            <!-- Footer
		============================================= -->
            <footer id="footer" class="dark">


                <!-- Copyrights
			============================================= -->
                <div id="copyrights">

                    <div class="container clearfix">

                        <div class="col_half">
                            Copyrights &copy; <% DateTime.Now.Year.ToString();  %> All Rights Reserved by SempaIT<br>
                            <div class="copyright-links"><a href="#">Terms of Use</a> / <a href="#">Privacy Policy</a></div>
                        </div>

                        <div class="col_half col_last tright">
                            <%--<div class="fright clearfix">
                                <a href="#" class="social-icon si-small si-borderless si-facebook">
                                    <i class="icon-facebook"></i>
                                    <i class="icon-facebook"></i>
                                </a>

                                <a href="#" class="social-icon si-small si-borderless si-twitter">
                                    <i class="icon-twitter"></i>
                                    <i class="icon-twitter"></i>
                                </a>

                                <a href="#" class="social-icon si-small si-borderless si-gplus">
                                    <i class="icon-gplus"></i>
                                    <i class="icon-gplus"></i>
                                </a>

                                <a href="#" class="social-icon si-small si-borderless si-pinterest">
                                    <i class="icon-pinterest"></i>
                                    <i class="icon-pinterest"></i>
                                </a>

                                <a href="#" class="social-icon si-small si-borderless si-vimeo">
                                    <i class="icon-vimeo"></i>
                                    <i class="icon-vimeo"></i>
                                </a>

                                <a href="#" class="social-icon si-small si-borderless si-github">
                                    <i class="icon-github"></i>
                                    <i class="icon-github"></i>
                                </a>

                                <a href="#" class="social-icon si-small si-borderless si-instagram">
                                    <i class="icon-instagram"></i>
                                    <i class="icon-instagram"></i>
                                </a>
                            </div>--%>

                            <div class="clear"></div>

                            <i class="icon-envelope2"></i>haycancha@sempait.com.ar <span class="middot">&middot;</span> <i class="icon-headphones"></i>+54-341-3122339 <span class="middot">&middot;</span> <i class="icon-skype2"></i>HayCanchaOnSkype
                        </div>

                    </div>

                </div>
                <!-- #copyrights end -->

            </footer>
            <!-- #footer end -->

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

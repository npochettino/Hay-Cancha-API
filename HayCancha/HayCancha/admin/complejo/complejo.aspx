<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminMaster.Master" AutoEventWireup="true" CodeBehind="complejo.aspx.cs" Inherits="HayCancha.admin.complejo.complejo" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxFileManager" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxUploadControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxImageSlider" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <!-- BEGIN PAGE LEVEL STYLES -->
    <link href="../../admin/assets/global/plugins/bootstrap-fileinput/bootstrap-fileinput.css" rel="stylesheet" type="text/css" />
    <link href="../../admin/assets/admin/pages/css/profile.css" rel="stylesheet" type="text/css" />
    <link href="../../admin/assets/admin/pages/css/tasks.css" rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL STYLES -->


    <!-- BEGIN PAGE LEVEL STYLES -->
    <link href="../../admin/assets/global/plugins/bootstrap-modal/css/bootstrap-modal-bs3patch.css" rel="stylesheet" type="text/css" />
    <link href="../../admin/assets/global/plugins/bootstrap-modal/css/bootstrap-modal.css" rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL STYLES -->

    <div class="page-container">
        <!-- BEGIN PAGE HEAD -->
        <div class="page-head">
            <div class="container-fluid">
                <!-- BEGIN PAGE TITLE -->
                <div class="page-title">
                    <h1>Complejo <small>ingrese los datos del complejo</small></h1>
                </div>
                <!-- END PAGE TITLE -->
            </div>
        </div>
        <!-- BEGIN PAGE CONTENT -->
        <div class="page-content">
            <div class="container-fluid">
                <!-- BEGIN PAGE BREADCRUMB -->
                <ul class="page-breadcrumb breadcrumb">
                    <li>
                        <a href="index.aspx">Inicio</a><i class="fa fa-circle"></i>
                    </li>
                    <li class="active">Mi Complejo
                    </li>
                </ul>
                <!-- END PAGE BREADCRUMB -->
                <!-- BEGIN PAGE CONTENT INNER -->
                <div class="row margin-top-10">
                    <div class="col-md-12">
                        <!-- BEGIN PROFILE SIDEBAR -->
                        <div class="profile-sidebar" style="width: 350px;">
                            <!-- PORTLET MAIN -->
                            <div class="portlet light ">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="fa fa-cogs font-green-sharp"></i>
                                        <span class="caption-subject font-green-sharp bold uppercase">Logo</span>
                                    </div>
                                </div>
                                <div class="portlet-body form">
                                    <div class="form-body">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <dx:ASPxImageSlider ID="isLogoComplejo" runat="server" EnableTheming="False" Height="30px" Width="150px" BackgroundImage-HorizontalPosition="center">
                                                </dx:ASPxImageSlider>
                                            </div>
                                        </div>
                                        <hr />
                                        <asp:FileUpload ID="fuLogo" runat="server" />
                                        <hr />
                                        <asp:Button ID="btnCargarLogo" runat="server" UseSubmitBehavior="false" CssClass="btn blue" Text="Cargar Logo" OnClick="btnCargarLogo_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- END BEGIN PROFILE SIDEBAR -->
                        <!-- BEGIN PROFILE CONTENT -->
                        <div class="profile-content">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="portlet light">
                                        <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-cogs font-green-sharp"></i>
                                                <span class="caption-subject font-green-sharp bold uppercase">Datos de Complejo</span>
                                            </div>
                                        </div>
                                        <div class="portlet-body form">
                                            <form role="form">
                                                <div class="form-body">
                                                    <div class="form-group">
                                                        <label>Nombre del Complejo</label>
                                                        <asp:TextBox type="text" class="form-control" placeholder="Nombre del Complejo" runat="server" ID="txtNombreComplejo"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Teléfono</label>
                                                        <asp:TextBox type="text" class="form-control" placeholder="Telefono" runat="server" ID="txtTelefono"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Mail Complejo</label>
                                                        <asp:TextBox type="text" class="form-control" placeholder="Mail Complejo" runat="server" ID="txtMailComplejo"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleInputPassword1">Dirección</label>
                                                        <div class="input-group">
                                                            <asp:TextBox type="text" class="form-control" ID="txtPlaces" runat="server" placeholder="Dirección en Google Maps"></asp:TextBox>
                                                            <span class="input-group-addon">
                                                                <i class="fa fa-map-marker"></i>
                                                            </span>
                                                        </div>
                                                    </div>
                                                    <div style="display: none" class="form-group">
                                                        <label>Latitud</label>
                                                        <asp:TextBox type="text" class="form-control" placeholder="Mail Complejo" runat="server" ID="txtLatitud"></asp:TextBox>
                                                    </div>
                                                    <div style="display: none" class="form-group">
                                                        <label>Longitud</label>
                                                        <asp:TextBox type="text" class="form-control" placeholder="Mail Complejo" runat="server" ID="txtLongitud"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Hora Apertura</label>
                                                        <asp:DropDownList ID="ddlHoraApertura" class="form-control" runat="server">
                                                            <asp:ListItem Value="10" Text="10:00"></asp:ListItem>
                                                            <asp:ListItem Value="11" Text="11:00"></asp:ListItem>
                                                            <asp:ListItem Selected="True" Value="12" Text="12:00"></asp:ListItem>
                                                            <asp:ListItem Value="13" Text="13:00"></asp:ListItem>
                                                            <asp:ListItem Value="14" Text="14:00"></asp:ListItem>
                                                            <asp:ListItem Value="15" Text="15:00"></asp:ListItem>
                                                            <asp:ListItem Value="16" Text="16:00"></asp:ListItem>
                                                            <asp:ListItem Value="17" Text="17:00"></asp:ListItem>
                                                            <asp:ListItem Value="18" Text="18:00"></asp:ListItem>
                                                            <asp:ListItem Value="19" Text="19:00"></asp:ListItem>
                                                            <asp:ListItem Value="20" Text="20:00"></asp:ListItem>
                                                            <asp:ListItem Value="21" Text="21:00"></asp:ListItem>
                                                            <asp:ListItem Value="22" Text="22:00"></asp:ListItem>
                                                            <asp:ListItem Value="23" Text="23:00"></asp:ListItem>
                                                            <asp:ListItem Value="0" Text="00:00"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="01:00"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Hora Cierre</label>
                                                        <asp:DropDownList ID="ddlHoraCierre" class="form-control" runat="server">
                                                            <asp:ListItem Value="10" Text="10:00"></asp:ListItem>
                                                            <asp:ListItem Value="11" Text="11:00"></asp:ListItem>
                                                            <asp:ListItem Value="12" Text="12:00"></asp:ListItem>
                                                            <asp:ListItem Value="13" Text="13:00"></asp:ListItem>
                                                            <asp:ListItem Value="14" Text="14:00"></asp:ListItem>
                                                            <asp:ListItem Value="15" Text="15:00"></asp:ListItem>
                                                            <asp:ListItem Value="16" Text="16:00"></asp:ListItem>
                                                            <asp:ListItem Value="17" Text="17:00"></asp:ListItem>
                                                            <asp:ListItem Value="18" Text="18:00"></asp:ListItem>
                                                            <asp:ListItem Value="19" Text="19:00"></asp:ListItem>
                                                            <asp:ListItem Value="20" Text="20:00"></asp:ListItem>
                                                            <asp:ListItem Value="21" Text="21:00"></asp:ListItem>
                                                            <asp:ListItem Value="22" Text="22:00"></asp:ListItem>
                                                            <asp:ListItem Value="23" Text="23:00"></asp:ListItem>
                                                            <asp:ListItem Selected="True" Value="0" Text="00:00"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="01:00"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="form-actions">
                                                    <asp:Button type="submit" class="btn blue" ID="btnGuardar" OnClientClick="return validateForm()" UseSubmitBehavior="true" OnClick="btnGuardar_Click" runat="server" Text="Guardar" />
                                                    <button type="button" onclick="location.href='complejo.aspx'" class="btn default">Cancelar</button>
                                                </div>
                                            </form>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>


                    </div>
                </div>
            </div>
        </div>


    </div>





    <script type="text/javascript">
        function beginPost() {
            uploadImage.SetContentHtml("");
            uploadImage.PerformCallback(document.getElementById('ContentPlaceHolder1_fileUploadImagenes'));
        }
        function showPcImagenes() {
            alert('aaala');
            pcImagenesComplejo.Show();
        }
    </script>

    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false&libraries=places"></script>
    <script type="text/javascript">
        google.maps.event.addDomListener(window, 'load', function () {
            var places = new google.maps.places.Autocomplete(document.getElementById('ContentPlaceHolder1_txtPlaces'));
            google.maps.event.addListener(places, 'place_changed', function () {
                var place = places.getPlace();
                var address = place.formatted_address;
                var latitude = place.geometry.location.lat();
                var longitude = place.geometry.location.lng();
                var mesg = "Address: " + address;
                mesg += "\nLatitude: " + latitude;
                mesg += "\nLongitude: " + longitude;
                //alert(mesg);
                document.getElementById("ContentPlaceHolder1_txtLatitud").value = latitude;
                document.getElementById("ContentPlaceHolder1_txtLongitud").value = longitude;

            });
        });
    </script>


    <script type="text/javascript">
        function validateForm() {
            if (document.getElementById("ContentPlaceHolder1_txtNombreComplejo").value == "")
            { alert("Debe Ingresar el nombre del complejo"); return false; }
            return true;
        }

        function showGoogleMapsModal() {
            alert("Show Modal Google Maps......");
        }

    </script>


    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <script src="../../admin/assets/global/plugins/bootstrap-fileinput/bootstrap-fileinput.js" type="text/javascript"></script>
    <script src="../../admin/assets/global/plugins/jquery.sparkline.min.js" type="text/javascript"></script>
    <!-- END PAGE LEVEL PLUGINS -->
    <script src="../../admin/assets/global/plugins/jquery.min.js" type="text/javascript"></script>
    <script src="../../admin/assets/global/plugins/jquery-migrate.min.js" type="text/javascript"></script>
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <script src="../../admin/assets/global/plugins/bootstrap-modal/js/bootstrap-modalmanager.js" type="text/javascript"></script>
    <script src="../../admin/assets/global/plugins/bootstrap-modal/js/bootstrap-modal.js" type="text/javascript"></script>
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN PAGE LEVEL SCRIPTS -->
    <script src="../../admin/assets/admin/pages/scripts/ui-extended-modals.js"></script>
    <!-- END PAGE LEVEL SCRIPTS -->
    <script>
        jQuery(document).ready(function () {
            UIExtendedModals.init();
        });
    </script>
    <!-- END JAVASCRIPTS -->
</asp:Content>

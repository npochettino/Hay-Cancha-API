<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminMaster.Master" AutoEventWireup="true" CodeBehind="complejo.aspx.cs" Inherits="HayCancha.admin.complejo" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


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
        <!-- END PAGE HEAD -->
        <!-- BEGIN PAGE CONTENT -->
        <div class="page-content">
            <div class="container-fluid">
                <!-- BEGIN PAGE BREADCRUMB -->
                <ul class="page-breadcrumb breadcrumb">
                    <li>
                        <a href="index.aspx">Inicio</a><i class="fa fa-circle"></i>
                    </li>
                    <li class="active">Complejo
                    </li>
                </ul>
                <!-- END PAGE BREADCRUMB -->
                <!-- BEGIN PAGE CONTENT INNER -->
                <div class="row">
                    <div class="col-md-12 ">
                        <!-- BEGIN SAMPLE FORM PORTLET-->
                        <div class="portlet light">
                            <div class="portlet-title">
                                <div class="caption">
                                    <i class="fa fa-cogs font-green-sharp"></i>
                                    <span class="caption-subject font-green-sharp bold uppercase">Datos de Complejo</span>
                                </div>
                                <div class="tools">
                                    <a href="javascript:;" class="collapse"></a>
                                </div>
                            </div>
                            <div class="portlet-body form">
                                <form role="form">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label>Nombre del Complejo</label>
                                            <asp:TextBox  type="text" class="form-control" placeholder="Nombre del Complejo"  runat="server" id="txtNombreComplejo"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Teléfono</label>
                                            <asp:TextBox type="text" class="form-control" placeholder="Telefono" runat="server" id="txtTelefono"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Mail Complejo</label>
                                            <asp:TextBox type="text" class="form-control" placeholder="Mail Complejo" runat="server" id="txtMailComplejo"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label for="exampleInputPassword1">Dirección</label>
                                            <div class="input-group">
                                                <asp:TextBox type="text" class="form-control" id="txtDireccion" runat="server" placeholder="Dirección en Google Maps"></asp:TextBox>
                                                <span onclick="showGoogleMapsModal()" class="input-group-addon">
                                                    <i class="fa fa-map-marker"></i>
                                                </span>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label>Hora Apertura</label>
                                            <asp:TextBox type="text" class="form-control" runat="server" id="txtHoraApertura" placeholder="Hora Apertura"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Hora Cierre</label>
                                            <asp:TextBox type="text" class="form-control" runat="server" id="txtHoraCierre" placeholder="Hora Cierre"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-actions">
                                        <asp:Button type="submit" class="btn blue" ID="btnGuardar" OnClientClick="return validateForm()" OnClick="btnGuardar_Click" runat="server" Text="Guardar" />
                                        <button type="button" class="btn default">Cancelar</button>
                                    </div>
                                </form>
                            </div>
                        </div>
                        <!-- END SAMPLE FORM PORTLET-->
                    </div>
                </div>
                <!-- END PAGE CONTENT -->
            </div>
        </div>
    </div>

    <%--<object type="text/html" data="../template/google.html" style="overflow:hidden;" width="800" height="600"></object>--%>

    <script type="text/javascript">
        function validateForm() {
            if (document.getElementById("ContentPlaceHolder1_txtNombreComplejo").value == "")
                {alert("Debe Ingresar el nombre del complejo"); return false;}
            return true;
        }

        function showGoogleMapsModal() {
            alert("Show Modal Google Maps......");
        }

    </script>
    <!-- BEGIN JAVASCRIPTS(Load javascripts at bottom, this will reduce page load time) -->
    <!-- BEGIN CORE PLUGINS -->
    <!--[if lt IE 9]>
    <script src="assets/global/plugins/respond.min.js"></script>
    <script src="assets/global/plugins/excanvas.min.js"></script> 
    <![endif]-->
    <script src="assets/global/plugins/jquery.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/jquery-migrate.min.js" type="text/javascript"></script>
    <!-- IMPORTANT! Load jquery-ui.min.js before bootstrap.min.js to fix bootstrap tooltip conflict with jquery ui tooltip -->
    <script src="assets/global/plugins/jquery-ui/jquery-ui.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/jquery.blockui.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/jquery.cokie.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
    <!-- END CORE PLUGINS -->

    <!-- BEGIN PAGE LEVEL SCRIPTS -->
    <script src="assets/global/scripts/metronic.js" type="text/javascript"></script>
    <script src="assets/admin/layout3/scripts/layout.js" type="text/javascript"></script>
    <script src="assets/admin/layout3/scripts/demo.js" type="text/javascript"></script>
    <!-- END PAGE LEVEL SCRIPTS -->
    <script>
        jQuery(document).ready(function () {
            Metronic.init(); // init metronic core components
            Layout.init(); // init current layout
            Demo.init(); // init demo features
        });
    </script>
    <!-- END JAVASCRIPTS -->
</asp:Content>

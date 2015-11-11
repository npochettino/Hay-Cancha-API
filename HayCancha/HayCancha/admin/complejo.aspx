<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminMaster.Master" AutoEventWireup="true" CodeBehind="complejo.aspx.cs" Inherits="HayCancha.admin.complejo" %>

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
                                                <asp:TextBox type="text" class="form-control" ID="txtDireccion" runat="server" placeholder="Dirección en Google Maps"></asp:TextBox>
                                                <span onclick="showGoogleMapsModal()" class="input-group-addon">
                                                    <i class="fa fa-map-marker"></i>
                                                </span>
                                            </div>
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
            { alert("Debe Ingresar el nombre del complejo"); return false; }
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

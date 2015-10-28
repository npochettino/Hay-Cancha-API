<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Site1.Master" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="HayCancha.admin.perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-container">
        <!-- BEGIN PAGE HEAD -->
        <div class="page-head">
            <div class="container-fluid">
                <!-- BEGIN PAGE TITLE -->
                <div class="page-title">
                    <h1>Mi Cuenta <small>cuenta del usuario</small></h1>
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
                        <a href="#">Inicio</a><i class="fa fa-circle"></i>
                    </li>
                    <li class="active">Mi Perfil
                    </li>
                </ul>
                <!-- END PAGE BREADCRUMB -->
                <!-- BEGIN PAGE CONTENT INNER -->
                <div class="row margin-top-10">
                    <div class="col-md-12">
                        <!-- BEGIN PROFILE SIDEBAR -->
                        <div class="profile-sidebar" style="width: 250px;">
                            <!-- PORTLET MAIN -->
                            <div class="portlet light profile-sidebar-portlet">
                                <!-- SIDEBAR USERPIC -->
                                <div class="profile-userpic">
                                    <img src="assets/admin/pages/media/profile/profile_user.jpg" class="img-responsive" alt="">
                                </div>
                                <!-- END SIDEBAR USERPIC -->
                                <!-- SIDEBAR USER TITLE -->
                                <div class="profile-usertitle">
                                    <div class="profile-usertitle-name">
                                        Complejo Tifossi
                                    </div>
                                    
                                </div>
                                <!-- END SIDEBAR USER TITLE -->

                            </div>
                            <!-- END PORTLET MAIN -->
                        </div>
                        <!-- END BEGIN PROFILE SIDEBAR -->
                        <!-- BEGIN PROFILE CONTENT -->
                        <div class="profile-content">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="portlet light">
                                        <div class="portlet-title tabbable-line">
                                            <div class="caption caption-md">
                                                <i class="icon-globe theme-font hide"></i>
                                                <span class="caption-subject font-blue-madison bold uppercase">Cuenta de usuario</span>
                                            </div>
                                            <ul class="nav nav-tabs">
                                                <li class="active">
                                                    <a href="#tab_1_1" data-toggle="tab">Info Personal</a>
                                                </li>
                                                <li>
                                                    <a href="#tab_1_2" data-toggle="tab">Cambiar Imagen</a>
                                                </li>
                                                <li>
                                                    <a href="#tab_1_3" data-toggle="tab">Cambiar Contraseña</a>
                                                </li>
                                            </ul>
                                        </div>
                                        <div class="portlet-body">
                                            <div class="tab-content">
                                                <!-- PERSONAL INFO TAB -->
                                                <div class="tab-pane active" id="tab_1_1">
                                                    <form role="form" action="#">
                                                        <div class="form-group">
                                                            <label class="control-label">Nombre</label>
                                                            <input type="text" placeholder="Lio" class="form-control" />
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Apellido</label>
                                                            <input type="text" placeholder="Messi" class="form-control" />
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Correo</label>
                                                            <input type="text" placeholder="haycancha@sempait.com.ar" class="form-control" />
                                                        </div>
                                                        <div class="margiv-top-10">
                                                            <a href="javascript:;" class="btn green-haze">Guardar Cambios </a>
                                                            <a href="javascript:;" class="btn default">Cancelar </a>
                                                        </div>
                                                    </form>
                                                </div>
                                                <!-- END PERSONAL INFO TAB -->
                                                <!-- CHANGE AVATAR TAB -->
                                                <div class="tab-pane" id="tab_1_2">
                                                    <p>
                                                        Recuerde que la siguiente imagen será visible en la aplicación mobil de Hay Cancha.
                                                    </p>
                                                    <form action="#" role="form">
                                                        <div class="form-group">
                                                            <div class="fileinput fileinput-new" data-provides="fileinput">
                                                                <div class="fileinput-new thumbnail" style="width: 200px; height: 150px;">
                                                                    <img src="http://www.placehold.it/200x150/EFEFEF/AAAAAA&amp;text=no+image" alt="" />
                                                                </div>
                                                                <div class="fileinput-preview fileinput-exists thumbnail" style="max-width: 200px; max-height: 150px;">
                                                                </div>
                                                                <div>
                                                                    <span class="btn default btn-file">
                                                                        <span class="fileinput-new">Seleccionar imagen </span>
                                                                        <span class="fileinput-exists">Cambiar </span>
                                                                        <input type="file" name="...">
                                                                    </span>
                                                                    <a href="javascript:;" class="btn default fileinput-exists" data-dismiss="fileinput">Remove </a>
                                                                </div>
                                                            </div>
                                                            <div class="clearfix margin-top-10">
                                                                <span class="label label-danger">NOTA! </span>
                                                                <span>Acción soportada por la última versión de Firefox, Chrome, Opera, Safari e Internet Explorer 10. </span>
                                                            </div>
                                                        </div>
                                                        <div class="margin-top-10">
                                                            <a href="javascript:;" class="btn green-haze">Guardar </a>
                                                            <a href="javascript:;" class="btn default">Cancelar </a>
                                                        </div>
                                                    </form>
                                                </div>
                                                <!-- END CHANGE AVATAR TAB -->
                                                <!-- CHANGE PASSWORD TAB -->
                                                <div class="tab-pane" id="tab_1_3">
                                                    <form action="#">
                                                        <div class="form-group">
                                                            <label class="control-label">Contraseña Actual</label>
                                                            <input type="password" class="form-control" />
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Nueva Contraseña</label>
                                                            <input type="password" class="form-control" />
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Repita Nueva Contraseña</label>
                                                            <input type="password" class="form-control" />
                                                        </div>
                                                        <div class="margin-top-10">
                                                            <a href="javascript:;" class="btn green-haze">Cambiar Contraseña </a>
                                                            <a href="javascript:;" class="btn default">Cancelar </a>
                                                        </div>
                                                    </form>
                                                </div>
                                                <!-- END CHANGE PASSWORD TAB -->
                                                <!-- PRIVACY SETTINGS TAB -->
                                                <div class="tab-pane" id="tab_1_4">
                                                    <form action="#">
                                                        <table class="table table-light table-hover">
                                                            <tr>
                                                                <td>Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus..
                                                                </td>
                                                                <td>
                                                                    <label class="uniform-inline">
                                                                        <input type="radio" name="optionsRadios1" value="option1" />
                                                                        Yes
                                                                    </label>
                                                                    <label class="uniform-inline">
                                                                        <input type="radio" name="optionsRadios1" value="option2" checked />
                                                                        No
                                                                    </label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Enim eiusmod high life accusamus terry richardson ad squid wolf moon
                                                                </td>
                                                                <td>
                                                                    <label class="uniform-inline">
                                                                        <input type="checkbox" value="" />
                                                                        Yes
                                                                    </label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Enim eiusmod high life accusamus terry richardson ad squid wolf moon
                                                                </td>
                                                                <td>
                                                                    <label class="uniform-inline">
                                                                        <input type="checkbox" value="" />
                                                                        Yes
                                                                    </label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Enim eiusmod high life accusamus terry richardson ad squid wolf moon
                                                                </td>
                                                                <td>
                                                                    <label class="uniform-inline">
                                                                        <input type="checkbox" value="" />
                                                                        Yes
                                                                    </label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <!--end profile-settings-->
                                                        <div class="margin-top-10">
                                                            <a href="javascript:;" class="btn green-haze">Save Changes </a>
                                                            <a href="javascript:;" class="btn default">Cancel </a>
                                                        </div>
                                                    </form>
                                                </div>
                                                <!-- END PRIVACY SETTINGS TAB -->
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- END PROFILE CONTENT -->
                    </div>
                </div>
                <!-- END PAGE CONTENT INNER -->
            </div>
        </div>
        <!-- END PAGE CONTENT -->
    </div>
</asp:Content>

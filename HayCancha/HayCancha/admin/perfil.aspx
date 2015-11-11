<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminMaster.Master" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="HayCancha.admin.perfil" %>

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
                                        <asp:Label ID="lblNombreDelComplejo" runat="server" Text="Complejo Tifossi"></asp:Label>
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
                                                <%--<li>
                                                    <a href="#tab_1_2" data-toggle="tab">Cambiar Imagen</a>
                                                </li>
                                                <li>
                                                    <a href="#tab_1_3" data-toggle="tab">Cambiar Contraseña</a>
                                                </li>--%>
                                            </ul>
                                        </div>
                                        <div class="portlet-body">
                                            <div class="tab-content">
                                                <!-- PERSONAL INFO TAB -->
                                                <div class="tab-pane active" id="tab_1_1">
                                                    <form role="form" action="#">
                                                        <div class="form-group">
                                                            <label class="control-label">Nombre</label>
                                                            <asp:TextBox type="text" placeholder="Lio" class="form-control" ID="txtNombreUsuario" runat="server"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Apellido</label>
                                                            <asp:TextBox type="text" placeholder="Messi" class="form-control" ID="txtApellidoUsuario" runat="server"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Correo</label>
                                                            <asp:TextBox type="text" placeholder="haycancha@sempait.com.ar" ReadOnly="true" class="form-control" ID="txtMailUsuario" runat="server"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Contraseña Actual</label>
                                                            <asp:TextBox type="password" class="form-control" ID="txtPasswordUsuario" runat="server"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Nueva Contraseña</label>
                                                            <asp:TextBox ID="txtNewPasswordUsuario" runat="server" type="password" class="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label class="control-label">Repita Nueva Contraseña</label>
                                                            <asp:TextBox type="password" class="form-control" ID="txtRepeatNewPasswordUsuario" runat="server"></asp:TextBox>
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
                                                    </form>
                                                </div>
                                                <!-- END CHANGE AVATAR TAB -->
                                                <!-- CHANGE PASSWORD TAB -->
                                                <div class="tab-pane" id="tab_1_3">
                                                    <form action="#">
                                                        
                                                    </form>
                                                </div>
                                                <!-- END CHANGE PASSWORD TAB -->
                                            </div>
                                            <div class="margin-top-10">
                                                <asp:Button class="btn green-haze" ID="btnGuardar" OnClientClick="return validateForm()" OnClick="btnGuardar_Click" runat="server" Text="Guardar" />
                                                <a href="javascript:;" class="btn default">Cancelar </a>
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

       <script type="text/javascript">

           //document.getElementById("ContentPlaceHolder1_txtMailUsuario").disabled = true;

           function validateForm() {
               if (document.getElementById("ContentPlaceHolder1_txtNewPasswordUsuario").value == "")
               { alert("Debe Ingresar una contraseña"); return false; }
               if (document.getElementById("ContentPlaceHolder1_txtRepeatNewPasswordUsuario").value == "")
               { alert("Debe Ingresar una contraseña"); return false; }
               if (document.getElementById("ContentPlaceHolder1_txtNewPasswordUsuario").value != document.getElementById("ContentPlaceHolder1_txtRepeatNewPasswordUsuario").value)
               { alert("Las contraseñas no coinciden"); $("#ContentPlaceHolder1_txtNewPasswordUsuario").focus(); return false; }
               return true;
           }

    </script>
</asp:Content>

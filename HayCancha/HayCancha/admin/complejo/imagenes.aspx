<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminMaster.Master" AutoEventWireup="true" CodeBehind="imagenes.aspx.cs" Inherits="HayCancha.admin.complejo.imagenes" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxImageSlider" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:scriptmanager id="ScriptManager1" runat="server"></asp:scriptmanager>
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
        <!-- END PAGE HEAD -->

        <!--Init Modal Form Google Maps
                            ============================================-->
        <div class="page-content">
            <div class="container-fluid">
                <div class="row">
                    <form>
                        <div class="col-md-12">
                            <!-- BEGIN SAMPLE FORM PORTLET-->
                            <div class="portlet light">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="fa fa-cogs font-green-sharp"></i>
                                        <span class="caption-subject font-green-sharp bold uppercase">Imagenes del Complejo</span>
                                    </div>
                                </div>
                                <div class="modal-header">
                                    <div class="form-actions">
                                        <asp:Button runat="server" ID="btnEliminarImagen" Text="Eliminar" CssClass="btn red" OnClick="btnEliminarImagen_Click"/>
                                    </div>
                                </div>
                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <dx:aspximageslider id="isImagenesComplejo" enabletheming="false" runat="server">
                                                                </dx:aspximageslider>                                            
                                        </div>
                                    </div>
                                </div>
                                
                                <div class="modal-footer">
                                    <asp:fileupload id="fileUploadImagenes" runat="server" />
                                    <asp:Button ID="btnFileUploadImages" runat="server" UseSubmitBehavior="false" Text="Cargar Imagen" OnClick="btnSubirImagenes_Click" />
                                    <dx:aspxbutton id="btnSubirImagenes" runat="server" text="Subir Imagenes DX" onclick="btnSubirImagenes_Click">
                                                        </dx:aspxbutton>
                                  
                                    <hr />
                                </div>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>



</asp:Content>

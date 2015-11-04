<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Site1.Master" AutoEventWireup="true" CodeBehind="complejo.aspx.cs" Inherits="HayCancha.admin.complejo" %>

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
                                            <input type="text" class="form-control" placeholder="Nombre del Complejo">
                                        </div>
                                        <div class="form-group">
                                            <label>Teléfono</label>
                                            <input type="text" class="form-control" placeholder="Telefono">
                                        </div>
                                        <div class="form-group">
                                            <label for="exampleInputPassword1">Dirección</label>
                                            <div class="input-group">
                                                <input type="text" class="form-control" id="exampleInputPassword1" placeholder="Dirección en Google Maps">
                                                <span class="input-group-addon">
                                                    <i onclick="showGoogleMapsModal" class="fa fa-map-marker"></i>
                                                </span>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label>Hora Apertura</label>
                                            <input type="text" class="form-control" placeholder="Hora Apertura">
                                        </div>
                                        <div class="form-group">
                                            <label>Hora Cierre</label>
                                            <input type="text" class="form-control" placeholder="Hora Cierre">
                                        </div>

                                    </div>
                                    <div class="form-actions">
                                        <button type="submit" class="btn blue">Guardar</button>
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

            <div class="row">
                <div class="col-md-6">
                    <!-- BEGIN GEOCODING PORTLET-->
                    <div class="portlet light">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-gift"></i>Geocoding
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="collapse"></a>
                                <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                <a href="javascript:;" class="reload"></a>
                                <a href="javascript:;" class="remove"></a>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <form class="form-inline margin-bottom-10" action="javascript:;">
                                <div class="input-group">
                                    <input type="text" class="form-control" id="gmap_geocoding_address" placeholder="address...">
                                    <span class="input-group-btn">
                                        <button class="btn blue" id="gmap_geocoding_btn">
                                            <i class="fa fa-search"></i>
                                    </span>
                                </div>
                            </form>
                            <div id="gmap_geocoding" class="gmaps">
                            </div>
                        </div>
                    </div>
                    <!-- END GEOCODING PORTLET-->
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <!-- BEGIN MARKERS PORTLET-->
                    <div class="portlet light">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-gift"></i>Markers
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="collapse"></a>
                                <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                <a href="javascript:;" class="reload"></a>
                                <a href="javascript:;" class="remove"></a>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div id="gmap_marker" class="gmaps">
                            </div>
                        </div>
                    </div>
                    <!-- END MARKERS PORTLET-->
                </div>
            </div>
</asp:Content>

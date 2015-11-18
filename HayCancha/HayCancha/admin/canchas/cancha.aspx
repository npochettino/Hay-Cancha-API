<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminMaster.Master" AutoEventWireup="true" CodeBehind="cancha.aspx.cs" Inherits="HayCancha.admin.canchas.cancha" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-container">
        <!-- BEGIN PAGE HEAD -->
        <div class="page-head">
            <div class="container-fluid">
                <!-- BEGIN PAGE TITLE -->
                <div class="page-title">
                    <h1>Cancha <small>ingrese los datos de la cancha</small></h1>
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
                        <a href="../../admin/index.aspx">Inicio</a><i class="fa fa-circle"></i>
                    </li>
                    <li class="active">Cancha
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
                                    <span class="caption-subject font-green-sharp bold uppercase">Datos de la Cancha</span>
                                </div>
                                <div class="tools">
                                    <a href="javascript:;" class="collapse"></a>
                                </div>
                            </div>
                            <div class="portlet-body form">
                                <form role="form">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label>Descripción</label>
                                            <asp:TextBox type="text" class="form-control" placeholder="Descripcion" runat="server" ID="txtDescripcion"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Precio Mañana</label>
                                            <asp:TextBox type="text" class="form-control" placeholder="Precio Mañana" runat="server" ID="txtPrecioMañana"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Precio Tarde</label>
                                            <asp:TextBox type="text" class="form-control" placeholder="Precio Tarde" runat="server" ID="txtPrecioTarde"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Precio Noche</label>
                                            <asp:TextBox type="text" class="form-control" placeholder="Precio Noche" runat="server" ID="txtPrecioNoche"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Tipo de Cancha</label>
                                            <dx:ASPxComboBox ID="cbTipoCancha" runat="server" DropDownStyle="DropDown" CssClass="form-control"
                                                    ValueField="codigo" TextField="descripcion" IncrementalFilteringMode="Contains" ValueType="System.Int32" Width="100%" 
                                                EnableTheming="True" Theme="Metropolis" AutoPostBack="false">
                                                <CaptionSettings ShowColon="false" RequiredMarkDisplayMode="Hidden" />
                                                <%--<Columns>
                                                        <dx:ListBoxColumn FieldName="codigo" Visible="false" Width="30%" />
                                                        <dx:ListBoxColumn FieldName="descripcion" Caption="" />
                                                </Columns>    --%>
                                            </dx:ASPxComboBox>
                                        </div>
                                    </div>
                                    <div class="form-actions">
                                        <asp:Button type="submit" class="btn blue" ID="btnGuardar" OnClientClick="return validateForm()" OnClick="btnGuardar_Click" runat="server" Text="Guardar" />
                                        <button type="button" onclick="location.href='listado.aspx'" class="btn default">Cancelar</button>
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


</asp:Content>

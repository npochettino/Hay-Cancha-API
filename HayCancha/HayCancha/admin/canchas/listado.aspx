<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminMaster.Master" AutoEventWireup="true" CodeBehind="listado.aspx.cs" Inherits="HayCancha.admin.canchas.listado" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-container">
        <!-- BEGIN PAGE HEAD -->
        <div class="page-head">
            <div class="container-fluid">
                <!-- BEGIN PAGE TITLE -->
                <div class="page-title">
                    <h1>Canchas <small>listado de canchas</small></h1>
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
                    <li class="active">Canchas
                    </li>
                </ul>
                <!-- END PAGE BREADCRUMB -->
                <!-- BEGIN PAGE CONTENT INNER -->
                <div class="row">
                    <div class="col-md-12 ">
                        <!-- BEGIN SAMPLE FORM PORTLET-->
                        <div class="portlet light">
                            <div class="portlet-title">
                                <div class="form-actions">
                                    <asp:Button type="submit" class="btn blue" ID="btnNuevo" OnClick="btnNuevo_Click" runat="server" Text="Nuevo" />
                                    <asp:Button type="submit" class="btn yellow" ID="btnEditar" OnClick="btnEditar_Click" runat="server" Text="Editar" />
                                    <asp:Button type="submit" class="btn red" ID="btnEliminar" OnClick="btnEliminar_Click" runat="server" Text="Eliminar" />
                                    <%--<asp:Button type="submit" class="btn green" ID="btnConsultar" OnClick="btnConsultar_Click" runat="server" Text="Consulta" />--%>
                                </div>
                            </div>
                            <div class="portlet-body form">
                                <dx:ASPxGridView ID="gvCanchas" runat="server" Width="100%" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="codigoCancha" Theme="Metropolis">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="codigoCancha" ReadOnly="True" Visible="False" VisibleIndex="0">
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataDateColumn FieldName="codigoComplejo" Visible="false" VisibleIndex="1" Caption="Codigo Complejo">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataDateColumn FieldName="descripcion" VisibleIndex="1" Caption="Descripción">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataDateColumn FieldName="precioMañana" VisibleIndex="1" Caption="Precio Mañana">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataDateColumn FieldName="precioTarde" VisibleIndex="1" Caption="Precio Tarde">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataDateColumn FieldName="precioNoche" VisibleIndex="1" Caption="Precio Noche">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataDateColumn FieldName="codigoTipoCancha" Visible="false" VisibleIndex="1" Caption="Cod. Tipo Cancha">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataDateColumn FieldName="descripcionTipoCancha" VisibleIndex="1" Caption="Tipo Cancha">
                                            <Settings AllowSort="True" AutoFilterCondition="Contains" />
                                        </dx:GridViewDataDateColumn>
                                    </Columns>
                                    <SettingsBehavior ColumnResizeMode="Control" AllowSort="false" />
                                    <SettingsBehavior AllowFocusedRow="True" />
                                    <Settings ShowFilterRow="True" />
                                    <SettingsPager PageSize="10">
                                    </SettingsPager>
                                </dx:ASPxGridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- END PAGE CONTENT -->
        </div>
</asp:Content>

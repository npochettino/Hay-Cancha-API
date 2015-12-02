<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminMaster.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="index.aspx.cs" Inherits="HayCancha.admin.index" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxMenu" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">

        var keyValue = new Array();
        function ShowEditPopup(element, FieldName, ticketId, isMultipleSelected) {
            callbackPanel.SetContentHtml("");
            pcTurno.ShowAtElement(eval(element));
            keyValue[0] = FieldName;
            keyValue[1] = ticketId;
            keyValue[2] = isMultipleSelected;
        }
        function pcTurno_Shown(s, e) {
            callbackPanel.PerformCallback(keyValue);
        }

        function OnInit(s, e) {
            ASPxClientUtils.AttachEventToElement(s.GetInputElement(), "click", function (event) {
                s.ShowDropDown();
            });
        }
        
    </script>

    <div class="page-container">
        <!-- BEGIN PAGE HEAD -->
        <div class="page-head">
            <div class="container-fluid">
                <!-- BEGIN PAGE TITLE -->
                <div class="page-title">
                    <h1>Turnos <small>turnos de las canchas</small></h1>
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
                        <a href="#">Home</a><i class="fa fa-circle"></i>
                    </li>
                    <li class="active">Dashboard
                    </li>
                </ul>
                <!-- END PAGE BREADCRUMB -->
                <!-- BEGIN PAGE CONTENT INNER -->
                <div class="row margin-top-10">
                    <div class="col-md-12 col-sm-12">
                        <!-- BEGIN PORTLET-->
                        <div class="portlet light ">
                            <div class="portlet-title">
                                <div class="portlet-title">
                                    <div class="form-actions">
                                        
                                    </div>
                                </div>
                                <div class="caption caption-md">
                                    <i class="icon-bar-chart theme-font hide"></i>
                                    <span class="caption-subject theme-font bold uppercase">Turnos</span>
                                    <span class="caption-helper hide">turnos del día...</span>
                                </div>
                                <div class="actions">
                                    <div class="btn-group btn-group-devided" data-toggle="buttons">
                                        <%--<label class="btn btn-transparent grey-salsa btn-circle btn-sm ">
                                            <input type="radio" name="options" onclick="setPreviosDate()" class="toggle" id="Radio2">Anterior</label>
                                        <label class="btn btn-transparent grey-salsa btn-circle btn-sm active">
                                            <input type="radio" name="options" onclick="setCurrentDate()" class="toggle" id="Radio3">Hoy</label>
                                        <label class="btn btn-transparent grey-salsa btn-circle btn-sm">
                                            <input type="radio" name="options" onclick="setNextDate()" class="toggle" id="Radio4">Siguiente</label>--%>
                                        <dx:ASPxDateEdit ID="txtFechaGrillaTurnos" runat="server" CssClass="form-control" ClientInstanceName="txtFechaGrillaTurnos" 
                                            DropDownStyle="DropDownList" EnableTheming="True" Theme="Metropolis" Width="100%" 
                                            EditFormat="Date" AutoPostBack="true" OnDateChanged="txtFechaGrillaTurnos_DateChanged">
                                            <ClientSideEvents Init="OnInit" />
                                            <TimeSectionProperties Visible="false">
                                            </TimeSectionProperties>
                                        </dx:ASPxDateEdit>
                                    </div>
                                </div>
                            </div>
                            <div class="portlet-body">
                                <div class="table-scrollable table-scrollable-borderless">
                                    <dx:ASPxGridView ID="gvTurnos" runat="server" KeyFieldName="Hora" Width="100%" EnableTheming="True"
                                        Theme="Metropolis" OnHtmlDataCellPrepared="gridView_HtmlDataCellPrepared">

                                        <SettingsBehavior AllowFocusedRow="True" />
                                        <SettingsPager Mode="ShowAllRecords">
                                        </SettingsPager>
                                        <SettingsEditing Mode="Inline" />
                                        <Styles>
                                            <FocusedRow BackColor="#C0FFC0" ForeColor="Black">
                                            </FocusedRow>
                                        </Styles>
                                    </dx:ASPxGridView>


                                    <!-- BEGIN POPUP ELIMINAR ARTICULO -->
                                    <dx:ASPxPopupControl ID="pcTurno" runat="server" CloseAction="OuterMouseClick" CloseOnEscape="true"
                                        PopupHorizontalAlign="WindowCenter" ClientInstanceName="pcTurno"
                                        HeaderText="Turno" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="800" Height="600"
                                        EnableViewState="False" Theme="Metropolis">
                                        <ClientSideEvents Shown="pcTurno_Shown" />
                                        <ContentCollection>
                                            <dx:PopupControlContentControl ID="PopupControlContentControl3" runat="server">
                                                <dx:ASPxCallbackPanel ID="ASPxCallbackPanel1" runat="server" ClientInstanceName="callbackPanel"
                                                    OnCallback="ASPxCallbackPanel1_Callback1">
                                                    <PanelCollection>
                                                        <dx:PanelContent ID="PanelContent3" runat="server">
                                                            <div class="page-content">
                                                                <div class="container-fluid">
                                                                    <div class="row margin-top-10">
                                                                        <div class="col-md-12">
                                                                            <!-- BEGIN PROFILE SIDEBAR -->
                                                                            <div class="profile-sidebar" style="width: 200px;">
                                                                                <!-- PORTLET MAIN -->
                                                                                <div class="portlet light profile-sidebar-portlet">
                                                                                    <!-- SIDEBAR USERPIC -->
                                                                                    <div class="profile-userpic">
                                                                                        <img src="assets/admin/pages/media/profile/profile_user.jpg" runat="server" id="imgProfileUserApp" class="img-responsive" alt="">
                                                                                    </div>
                                                                                    <!-- END SIDEBAR USERPIC -->
                                                                                    <!-- SIDEBAR USER TITLE -->
                                                                                    <div class="profile-usertitle">
                                                                                        <div class="profile-usertitle-name">
                                                                                            <asp:Label ID="lblNombreDelUsuario" runat="server" Text="Usuario"></asp:Label>
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

                                                                                                <ul class="nav nav-tabs">
                                                                                                    <li class="active">
                                                                                                        <a href="#tab_1_1" data-toggle="tab">Info del Turno</a>
                                                                                                    </li>
                                                                                                </ul>
                                                                                            </div>
                                                                                            <div class="portlet-body">
                                                                                                <div class="tab-content">
                                                                                                    <!-- PERSONAL INFO TAB -->
                                                                                                    <div class="tab-pane active" id="tab_1_1">
                                                                                                        <form role="form" action="#">
                                                                                                            <div class="form-group">
                                                                                                                <label class="control-label"><strong>Nombre: </strong></label>
                                                                                                                <asp:TextBox type="text" placeholder="Lio" class="form-control" ID="txtNombreUsuario" runat="server"></asp:TextBox>
                                                                                                            </div>
                                                                                                            <div class="form-group">
                                                                                                                <label class="control-label"><strong>Apellido: </strong></label>
                                                                                                                <asp:TextBox type="text" placeholder="Lio" class="form-control" ID="txtApellidoUsuario" runat="server"></asp:TextBox>
                                                                                                            </div>
                                                                                                            <div class="form-group">
                                                                                                                <label class="control-label"><strong>Direccion: </strong></label>
                                                                                                                <asp:TextBox type="text" placeholder="Lio" class="form-control" ID="txtDireccionUsuario" runat="server"></asp:TextBox>
                                                                                                            </div>
                                                                                                            <div class="form-group">
                                                                                                                <label class="control-label"><strong>Telefono: </strong></label>
                                                                                                                <asp:TextBox type="text" placeholder="Lio" class="form-control" ID="txtTelefono" runat="server"></asp:TextBox>
                                                                                                            </div>
                                                                                                            <div class="form-group">
                                                                                                                <label class="control-label"><strong>Fecha del Turno: </strong></label>
                                                                                                                <dx:ASPxDateEdit CssClass="form-control" ID="txtFechaDelTurno" runat="server"></dx:ASPxDateEdit>
                                                                                                            </div>
                                                                                                            <div class="form-group">
                                                                                                                <label class="control-label"><strong>Hora Desde: </strong></label>
                                                                                                                <asp:DropDownList ID="ddlHoraDesde" class="form-control" runat="server">
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
                                                                                                                    <asp:ListItem Value="0" Text="00:00"></asp:ListItem>
                                                                                                                    <asp:ListItem Value="1" Text="01:00"></asp:ListItem>
                                                                                                                </asp:DropDownList>
                                                                                                            </div>
                                                                                                            <div class="form-group">
                                                                                                                <label class="control-label"><strong>Hora Hasta: </strong></label>
                                                                                                                <asp:DropDownList ID="ddlHoraHasta" class="form-control" runat="server">
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
                                                                                                                    <asp:ListItem Value="0" Text="00:00"></asp:ListItem>
                                                                                                                    <asp:ListItem Value="1" Text="01:00"></asp:ListItem>
                                                                                                                </asp:DropDownList>
                                                                                                            </div>
                                                                                                            <div class="modal-footer">
                                                                                                                <asp:Button ID="btnCerrar" OnClientClick="pcTurno.Hide();" runat="server" UseSubmitBehavior="false" CssClass="btn btn-default" Text="Cerrar" />
                                                                                                                <asp:Button ID="btnAceptar" OnClick="btnAceptar_Click" UseSubmitBehavior="false" runat="server" CssClass="btn green" Text="Aceptar" />
                                                                                                                <asp:Button ID="btnRechazar" OnClick="btnRechazar_Click" UseSubmitBehavior="false" runat="server" CssClass="btn red" Text="Rechazar" />
                                                                                                                <asp:Button ID="btnGuardarTurno" UseSubmitBehavior="false" runat="server" CssClass="btn blue" Text="Guardar Turno" />
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
                                                            </div>
                                                        </dx:PanelContent>
                                                    </PanelCollection>
                                                </dx:ASPxCallbackPanel>
                                            </dx:PopupControlContentControl>
                                        </ContentCollection>
                                    </dx:ASPxPopupControl>
                                    <!--END POPUP-->

                                </div>
                            </div>
                        </div>
                        <!-- END PORTLET-->
                    </div>
                </div>
                <!-- END PAGE CONTENT INNER -->
            </div>
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminMaster.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="HayCancha.admin.index" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxMenu" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>

    <script type="text/javascript">
        function onCellClick(rowIndex, fieldName, cell) {
            grid.PerformCallback(rowIndex + '|' + fieldName + '|' + cell);
            setTimeout(function () { pcTurno.Show(); }, 3000);
            //PageMethods.ProcessPopUp(rowIndex,fieldName,cell);//, onSucess, onError);

        }
        function onSucess(result) {
            alert(result);
        }
        function onError(result) {
            alert('Something wrong.');
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
                                <div class="caption caption-md">
                                    <i class="icon-bar-chart theme-font hide"></i>
                                    <span class="caption-subject theme-font bold uppercase">Turnos</span>
                                    <span class="caption-helper hide">turnos del día...</span>
                                </div>
                                <div class="actions">
                                    <div class="btn-group btn-group-devided" data-toggle="buttons">
                                        <label class="btn btn-transparent grey-salsa btn-circle btn-sm ">
                                            <input type="radio" name="options" class="toggle" id="Radio2">Anterior</label>
                                        <label class="btn btn-transparent grey-salsa btn-circle btn-sm active">
                                            <input type="radio" name="options" class="toggle" id="Radio3">Hoy</label>
                                        <label class="btn btn-transparent grey-salsa btn-circle btn-sm">
                                            <input type="radio" name="options" class="toggle" id="Radio4">Siguiente</label>
                                    </div>
                                </div>
                            </div>
                            <div class="portlet-body">
                                <div class="table-scrollable table-scrollable-borderless">
                                    <dx:ASPxGridView ID="gvTurnos" runat="server" KeyFieldName="Id" Width="100%" EnableTheming="True" Theme="Metropolis"
                                        OnCustomCallback="gridView_CustomCallback" ClientInstanceName="grid"
                                        OnHtmlDataCellPrepared="gridView_HtmlDataCellPrepared">
                                        <%--OnHtmlDataCellPrepared="gvTurnos_HtmlDataCellPrepared" OnCustomJSProperties="gvTurnos_CustomJSProperties"--%>

                                        <SettingsPager Mode="ShowAllRecords">
                                        </SettingsPager>
                                        <SettingsEditing Mode="Inline" />
                                        <SettingsBehavior AllowFocusedRow="True" />
                                        <Styles>
                                            <FocusedRow BackColor="#C0FFC0" ForeColor="Black">
                                            </FocusedRow>
                                        </Styles>
                                    </dx:ASPxGridView>

                                    <dx:ASPxPopupMenu ID="ASPxPopupMenu1" runat="server" ClientInstanceName="ASPxPopupMenuClientControl"
                                        PopupElementID="ImgButton1" ShowPopOutImages="True" AutoPostBack="True" OnItemClick="ASPxPopupMenu1_ItemClick"
                                        PopupHorizontalAlign="OutsideRight" PopupVerticalAlign="TopSides" PopupAction="LeftMouseClick">
                                        <Items>
                                            <dx:MenuItem Text="Ver Turno" Name="Ver Turno">
                                            </dx:MenuItem>
                                        </Items>
                                        <ClientSideEvents Init="InitPopupMenuHandler" />
                                        <ItemStyle Width="143px"></ItemStyle>
                                    </dx:ASPxPopupMenu>


                                    <!-- BEGIN POPUP ELIMINAR ARTICULO -->
                                    <dx:ASPxPopupControl ID="pcTurno" runat="server" CloseAction="OuterMouseClick" CloseOnEscape="true"
                                        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcTurno"
                                        HeaderText="Turno" AllowDragging="True" Modal="True" PopupAnimationType="Fade" Width="800" Height="600"
                                        EnableViewState="False" Theme="Metropolis" OnPreRender="pcTurno_PreRender">
                                        <ContentCollection>
                                            <dx:PopupControlContentControl ID="PopupControlContentControl3" runat="server">
                                                <dx:ASPxPanel ID="ASPxPanel1" runat="server" DefaultButton="">
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
                                                                                        <img src="assets/admin/pages/media/profile/profile_user.jpg" class="img-responsive" alt="">
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
                                                                                                                <asp:TextBox type="text" placeholder="Lio" class="form-control" ID="TextBox1" runat="server"></asp:TextBox>
                                                                                                            </div>
                                                                                                            <div class="form-group">
                                                                                                                <label class="control-label"><strong>Direccion: </strong></label>
                                                                                                                <asp:TextBox type="text" placeholder="Lio" class="form-control" ID="TextBox2" runat="server"></asp:TextBox>
                                                                                                            </div>
                                                                                                            <div class="form-group">
                                                                                                                <label class="control-label"><strong>Telefono: </strong></label>
                                                                                                                <asp:TextBox type="text" placeholder="Lio" class="form-control" ID="TextBox3" runat="server"></asp:TextBox>
                                                                                                            </div>
                                                                                                            <div class="form-group">
                                                                                                                <label class="control-label"><strong>Fecha del Turno: </strong></label>
                                                                                                                <dx:ASPxDateEdit CssClass="form-control" ID="txtFechaDelTurno" runat="server"></dx:ASPxDateEdit>
                                                                                                            </div>
                                                                                                            <div class="form-group">
                                                                                                                <label class="control-label"><strong>Hora Desde: </strong></label>
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
                                                                                                                    <asp:ListItem Value="0" Text="00:00"></asp:ListItem>
                                                                                                                    <asp:ListItem Value="1" Text="01:00"></asp:ListItem>
                                                                                                                </asp:DropDownList>
                                                                                                            </div>
                                                                                                            <div class="form-group">
                                                                                                                <label class="control-label"><strong>Hora Hasta: </strong></label>
                                                                                                                <asp:DropDownList ID="DropDownList1" class="form-control" runat="server">
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
                                                                                                                <button type="button" data-dismiss="modal" class="btn btn-default">Cerrar</button>
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
                                                </dx:ASPxPanel>
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

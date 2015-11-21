<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminMaster.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="HayCancha.admin.index" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxMenu" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        function grid_ContextMenu(s, e) {
            if (e.objectType == "row")
                pmRowMenu.ShowAtPos(ASPxClientUtils.GetEventX(e.htmlEvent), ASPxClientUtils.GetEventY(e.htmlEvent));
        }
    </script>

    <script type="text/javascript">
        function InitPopupMenuHandler(s, e) {
            var gridCell = document.getElementById('ContentPlaceHolder1_gvTurnos');
            ASPxClientUtils.AttachEventToElement(gridCell, 'contextmenu', OnGridContextMenu);
            var imgButton = document.getElementById('ImgButton1');
            ASPxClientUtils.AttachEventToElement(imgButton, 'contextmenu', OnPreventContextMenu);
        }
        function OnGridContextMenu(evt) {
            ASPxPopupMenuClientControl.ShowAtPos(evt.clientX + ASPxClientUtils.GetDocumentScrollLeft(), evt.clientY + ASPxClientUtils.GetDocumentScrollTop());
            return OnPreventContextMenu(evt);
        }
        function OnPreventContextMenu(evt) {
            return ASPxClientUtils.PreventEventAndBubble(evt);
        }
    </script>
    <script type="text/javascript">
        var doProcessClick;
        var visibleIndex;
        function ProcessClick() {
            if (doProcessClick) {
                alert("Here is the RowClick action in the " + visibleIndex.toString() + "-th row");
            }
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
                                         OnBeforeGetCallbackResult="GridView1_PreRender" OnPreRender="GridView1_PreRender">

                                        <SettingsPager Mode="ShowAllRecords">
                                        </SettingsPager>

                                        <SettingsEditing Mode="Inline" />
                                        <settingsbehavior AllowFocusedRow="True" />
                                            <clientsideevents RowClick="function(s, e) {
                                                 doProcessClick = true;
                                                 visibleIndex = e.visibleIndex+1;
                                                 window.setTimeout(ProcessClick,500);
                                                        }" RowDblClick="function(s, e) {
                                                doProcessClick = false;
                                                var key = s.GetRowKey(e.visibleIndex);
                                                alert('Here is the RowDoubleClick action in a row with the Key = '+key);
                                                        }" />
                                            <styles>
                                                <focusedrow BackColor="#C0FFC0" ForeColor="Black">
                                                </focusedrow>
                                            </styles>
                                    </dx:ASPxGridView>
                                   
                                     <dx:ASPxPopupMenu ID="pmRowMenu" runat="server" ClientInstanceName="pmRowMenu">
                                        <Items>
                                            <dx:MenuItem Text="Ver" Name="cmdExport">
                                            </dx:MenuItem>
                                        </Items>
                                        <ClientSideEvents ItemClick="function(s, e) {
	                                        if(e.item.name == 'cmdExport')
                                                alert('Export simulation.');
                                        }" />
                                      </dx:ASPxPopupMenu>
                                        
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

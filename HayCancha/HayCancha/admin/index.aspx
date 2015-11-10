<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminMaster.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="HayCancha.admin.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                                    <span class="caption-subject theme-font bold uppercase">Member Activity</span>
                                    <span class="caption-helper hide">weekly stats...</span>
                                </div>
                                <div class="actions">
                                    <div class="btn-group btn-group-devided" data-toggle="buttons">
                                        <label class="btn btn-transparent grey-salsa btn-circle btn-sm active">
                                            <input type="radio" name="options" class="toggle" id="Radio2">Today</label>
                                        <label class="btn btn-transparent grey-salsa btn-circle btn-sm">
                                            <input type="radio" name="options" class="toggle" id="Radio3">Week</label>
                                        <label class="btn btn-transparent grey-salsa btn-circle btn-sm">
                                            <input type="radio" name="options" class="toggle" id="Radio4">Month</label>
                                    </div>
                                </div>
                            </div>
                            <div class="portlet-body">
                                <div class="row number-stats margin-bottom-30">
                                    <div class="col-md-6 col-sm-6 col-xs-6">
                                        <div class="stat-left">
                                            <div class="stat-chart">
                                                <!-- do not line break "sparkline_bar" div. sparkline chart has an issue when the container div has line break -->
                                                <div id="sparkline_bar"></div>
                                            </div>
                                            <div class="stat-number">
                                                <div class="title">
                                                    Total
                                                </div>
                                                <div class="number">
                                                    2460
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-xs-6">
                                        <div class="stat-right">
                                            <div class="stat-chart">
                                                <!-- do not line break "sparkline_bar" div. sparkline chart has an issue when the container div has line break -->
                                                <div id="sparkline_bar2"></div>
                                            </div>
                                            <div class="stat-number">
                                                <div class="title">
                                                    New
                                                </div>
                                                <div class="number">
                                                    719
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="table-scrollable table-scrollable-borderless">
                                    <table class="table table-hover table-light">
                                        <thead>
                                            <tr class="uppercase">
                                                <th colspan="2">MEMBER
                                                </th>
                                                <th>Earnings
                                                </th>
                                                <th>CASES
                                                </th>
                                                <th>CLOSED
                                                </th>
                                                <th>RATE
                                                </th>
                                            </tr>
                                        </thead>
                                        <tr>
                                            <td class="fit">
                                                <img class="user-pic" src="assets/admin/layout3/img/avatar4.jpg">
                                            </td>
                                            <td>
                                                <a href="javascript:;" class="primary-link">Brain</a>
                                            </td>
                                            <td>$345
                                            </td>
                                            <td>45
                                            </td>
                                            <td>124
                                            </td>
                                            <td>
                                                <span class="bold theme-font">80%</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="fit">
                                                <img class="user-pic" src="assets/admin/layout3/img/avatar5.jpg">
                                            </td>
                                            <td>
                                                <a href="javascript:;" class="primary-link">Nick</a>
                                            </td>
                                            <td>$560
                                            </td>
                                            <td>12
                                            </td>
                                            <td>24
                                            </td>
                                            <td>
                                                <span class="bold theme-font">67%</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="fit">
                                                <img class="user-pic" src="assets/admin/layout3/img/avatar6.jpg">
                                            </td>
                                            <td>
                                                <a href="javascript:;" class="primary-link">Tim</a>
                                            </td>
                                            <td>$1,345
                                            </td>
                                            <td>450
                                            </td>
                                            <td>46
                                            </td>
                                            <td>
                                                <span class="bold theme-font">98%</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="fit">
                                                <img class="user-pic" src="assets/admin/layout3/img/avatar7.jpg">
                                            </td>
                                            <td>
                                                <a href="javascript:;" class="primary-link">Tom</a>
                                            </td>
                                            <td>$645
                                            </td>
                                            <td>50
                                            </td>
                                            <td>89
                                            </td>
                                            <td>
                                                <span class="bold theme-font">58%</span>
                                            </td>
                                        </tr>
                                    </table>
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

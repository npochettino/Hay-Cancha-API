<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminMaster.Master" AutoEventWireup="true" CodeBehind="complejo.aspx.cs" Inherits="HayCancha.admin.complejo.complejo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <style>
        html, body
        {
            height: 100%;
            margin: 0;
            padding: 0;
        }

        #map
        {
            height: 100%;
        }

        .controls
        {
            margin-top: 10px;
            border: 1px solid transparent;
            border-radius: 2px 0 0 2px;
            box-sizing: border-box;
            -moz-box-sizing: border-box;
            height: 32px;
            outline: none;
            box-shadow: 0 2px 6px rgba(0, 0, 0, 0.3);
        }

        #pac-input
        {
            background-color: #fff;
            font-family: Roboto;
            font-size: 15px;
            font-weight: 300;
            margin-left: 12px;
            padding: 0 11px 0 13px;
            text-overflow: ellipsis;
            width: 300px;
        }

            #pac-input:focus
            {
                border-color: #4d90fe;
            }

        .pac-container
        {
            font-family: Roboto;
        }

        #type-selector
        {
            color: #fff;
            background-color: #4d90fe;
            padding: 5px 11px 0px 11px;
        }

            #type-selector label
            {
                font-family: Roboto;
                font-size: 13px;
                font-weight: 300;
            }
    </style>
    <style>
        #target
        {
            width: 345px;
        }
    </style>


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
        <!-- BEGIN PAGE CONTENT -->
        <div class="page-content">
            <div class="container-fluid">
                <!-- BEGIN PAGE BREADCRUMB -->
                <ul class="page-breadcrumb breadcrumb">
                    <li>
                        <a href="../../admin/index.aspx">Inicio</a><i class="fa fa-circle"></i>
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
                                            <asp:TextBox type="text" class="form-control" placeholder="Nombre del Complejo" runat="server" ID="txtNombreComplejo"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Teléfono</label>
                                            <asp:TextBox type="text" class="form-control" placeholder="Telefono" runat="server" ID="txtTelefono"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Mail Complejo</label>
                                            <asp:TextBox type="text" class="form-control" placeholder="Mail Complejo" runat="server" ID="txtMailComplejo"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label for="exampleInputPassword1">Dirección</label>
                                            <div class="input-group">
                                                <asp:TextBox type="text" class="form-control" ID="txtDireccion" runat="server" placeholder="Dirección en Google Maps"></asp:TextBox>
                                                <span onclick="showGoogleMapsModal()" class="input-group-addon">
                                                    <i class="fa fa-map-marker"></i>
                                                </span>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label>Hora Apertura</label>
                                            <asp:DropDownList ID="ddlHoraApertura" class="form-control" runat="server">
                                                <asp:ListItem Value="10" Text="10:00"></asp:ListItem>
                                                <asp:ListItem Value="11" Text="11:00"></asp:ListItem>
                                                <asp:ListItem Selected="True" Value="12" Text="12:00"></asp:ListItem>
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
                                            <label>Hora Cierre</label>
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
                                                <asp:ListItem Selected="True" Value="0" Text="00:00"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="01:00"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-actions">
                                        <asp:Button type="submit" class="btn blue" ID="btnGuardar" OnClientClick="return validateForm()" OnClick="btnGuardar_Click" runat="server" Text="Guardar" />
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
        </div>
    </div>

    <%--<object type="text/html" data="../template/google.html" style="overflow:hidden;" width="800" height="600"></object>--%>

    <!--Init Modal Form Google Maps
      ============================================-->

    <input id="pac-input" class="controls" type="text" placeholder="Search Box">
    
    <label id="direccion"></label>
    <div id="map"></div>
    <script>
        // This example adds a search box to a map, using the Google Place Autocomplete
        // feature. People can enter geographical searches. The search box will return a
        // pick list containing a mix of places and predicted search terms.

        function initAutocomplete() {
            var map = new google.maps.Map(document.getElementById('map'), {
                center: { lat: -32.9522253, lng: -60.8382453 },
                zoom: 10,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            });

            // Create the search box and link it to the UI element.
            var input = document.getElementById('pac-input');
            var searchBox = new google.maps.places.SearchBox(input);
            map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);

            // Bias the SearchBox results towards current map's viewport.
            map.addListener('bounds_changed', function () {
                searchBox.setBounds(map.getBounds());
            });

            var markers = [];
            // [START region_getplaces]
            // Listen for the event fired when the user selects a prediction and retrieve
            // more details for that place.
            searchBox.addListener('places_changed', function () {
                var places = searchBox.getPlaces();

                if (places.length == 0) {
                    return;
                }

                // Clear out the old markers.
                markers.forEach(function (marker) {
                    marker.setMap(null);
                });
                markers = [];

                // For each place, get the icon, name and location.
                var bounds = new google.maps.LatLngBounds();
                places.forEach(function (place) {
                    var icon = {
                        url: place.icon,
                        size: new google.maps.Size(71, 71),
                        origin: new google.maps.Point(0, 0),
                        anchor: new google.maps.Point(17, 34),
                        scaledSize: new google.maps.Size(25, 25)
                    };

                    // Create a marker for each place.
                    markers.push(new google.maps.Marker({
                        map: map,
                        icon: icon,
                        title: place.name,
                        position: place.geometry.location,
                    }));

                    if (place.geometry.viewport) {
                        // Only geocodes have viewport.
                        bounds.union(place.geometry.viewport);
                    } else {
                        bounds.extend(place.geometry.location);
                    }
                });
                map.fitBounds(bounds);
            });
            // [END region_getplaces]
        }


    </script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBzdnFhHd9eZW0l8Z_MVRacUMk6Janm9ls&libraries=places&callback=initAutocomplete" async defer></script>






    <!--  Init Modal Form Google Maps
      ============================================-->



    <script type="text/javascript">
        function validateForm() {
            if (document.getElementById("ContentPlaceHolder1_txtNombreComplejo").value == "")
            { alert("Debe Ingresar el nombre del complejo"); return false; }
            return true;
        }

        function showGoogleMapsModal() {
            alert("Show Modal Google Maps......");
        }

    </script>

    <script src="../../admin/assets/global/plugins/jquery.min.js" type="text/javascript"></script>
    <script src="../../admin/assets/global/plugins/jquery-migrate.min.js" type="text/javascript"></script>
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <script src="../../admin/assets/global/plugins/bootstrap-modal/js/bootstrap-modalmanager.js" type="text/javascript"></script>
    <script src="../../admin/assets/global/plugins/bootstrap-modal/js/bootstrap-modal.js" type="text/javascript"></script>
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN PAGE LEVEL SCRIPTS -->
    <script src="../../admin/assets/admin/pages/scripts/ui-extended-modals.js"></script>
    <!-- END PAGE LEVEL SCRIPTS -->
    <script>
        jQuery(document).ready(function () {
            UIExtendedModals.init();
        });
    </script>
    <!-- END JAVASCRIPTS -->
</asp:Content>

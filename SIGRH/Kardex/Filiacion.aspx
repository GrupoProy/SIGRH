<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="Filiacion.aspx.cs" Inherits="Kardex_Filiacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Filiación Funcionario</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid mt--7">
        <div class="ct-example  card" style="padding-bottom: unset">
            <div class="card-header">
                <h3 class="h2 text d-inline-block mb-0"><i class="fas fa-id-card-alt mr-2"></i>Datos funcionario</h3>
                <asp:LinkButton ID="btn_estado" OnClick="btn_estado_Click" Text="File Virtual" class="btn btn-sm btn-success float-right" runat="server" />
            </div>
            <div class="card-body">
                <div class="media align-items-center">
                    <asp:Image ID="imgFun" class="avatar-xll img-thumbnail mr-4" runat="server" />
                    <div class="media-body">

                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <h6 class="heading-small text-muted">DATOS PERSONALES</h6>
                                <div class="row">
                                    <div class="col-lg-2">
                                        <div class="content-text-label">Cód. Funcionario</div>
                                        <div class="h5 font-weight-400 content-text content-text">
                                            <asp:Literal ID="ltl_cod_fun" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="content-text-label">CI</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_num_doc" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <div class="content-text-label">Nombre funcionario</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_nombre_fun" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="content-text-label">Estado civil</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_estado_civil" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="content-text-label">Sexo</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_genero" runat="server" />
                                        </div>
                                    </div>
                                </div>

                                <hr class="my-2">
                                <h6 class="heading-small text-muted">Fecha y lugar de nacimiento</h6>
                                <div class="row">
                                    <div class="col-lg-2">
                                        <div class="content-text-label">Fecha de nacimiento</div>
                                        <div class="h5 font-weight-400 content-text content-text">
                                            <asp:Literal ID="ltl_fecha_nac" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="content-text-label">País</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_pais" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="content-text-label">Departamento</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_departamento" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="content-text-label">Provincia</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_provincia" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="content-text-label">Localidad</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_localidad" runat="server" />
                                        </div>
                                    </div>

                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>

            </div>

            <div class="tab-content">
                <div id="nav-pills-tabs-component" class="tab-pane tab-example-result fade active show" role="tabpanel" aria-labelledby="nav-pills-tabs-component-tab">
                    <div class="nav-wrapper">
                        <ul class="nav nav-pills nav-fill flex-column flex-md-row" id="tabs-icons-text" role="tablist">
                            <li class="nav-item">
                                <a class="nav-link mb-sm-3 mb-md-0 active" id="tabs-icons-text-1-tab" data-toggle="tab" href="#tabs-icons-text-1" role="tab" aria-controls="tabs-icons-text-1" aria-selected="true"><i class="fas fa-address-card mr-2"></i>DATOS PERSONALES </a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link mb-sm-3 mb-md-0" id="tabs-icons-text-2-tab" data-toggle="tab" href="#tabs-icons-text-2" role="tab" aria-controls="tabs-icons-text-2" aria-selected="false"><i class="fas fa-user-tag mr-2"></i>FAMILIARES</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link mb-sm-3 mb-md-0" id="tabs-icons-text-3-tab" data-toggle="tab" href="#tabs-icons-text-3" role="tab" aria-controls="tabs-icons-text-3" aria-selected="false"><i class="fas fa-list-ol mr-2"></i>REQUISITOS</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link mb-sm-3 mb-md-0" id="tabs-icons-text-4-tab" data-toggle="tab" href="#tabs-icons-text-4" role="tab" aria-controls="tabs-icons-text-4" aria-selected="false"><i class="fas fa-user-graduate mr-2"></i>EDUCACIÓN FORMAL</a>
                            </li>
                        </ul>
                    </div>
                    <div class="card shadow">
                        <div class="card-body">
                            <div class="tab-content" id="myTabContent">
                                <div class="tab-pane fade show active" id="tabs-icons-text-1" role="tabpanel" aria-labelledby="tabs-icons-text-1-tab">


                                    <div class="row" runat="server" visible="false">
                                        <%--<input id="searchTextField" type="text" placeholder="Enter a location">--%>
                                        <input id="pac-input"  class="controls form-control" style="width: 440px" type="text" placeholder="Buscar Dirección">
                                    </div>
                                    <div class="row">
                                        <div class="col-xl-12">
                                            <div class="card-body" style="padding-top: unset;">
                                                <!-- Form groups used in grid -->
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <div class="row" runat="server"  >
<%--                                                            <div class="col-md-10">
                                                                <label class="form-control-label">&nbsp</label>
                                                                <p>En el mapa marque la dirección domiciliaria del funcionario, seguido registre los datos mostrados en el siguiente formulario.</p>
                                                            </div>--%>

                                                            <div class="col-md-2">
                                                                <div class="form-group">
                                                                    <label class="form-control-label">Código de File</label>

                                                                    <div class="input-group input-group-merge">
                                                                        <div class="input-group-prepend">
                                                                            <span class="input-group-text"><i class="fas fa-barcode"></i></span>
                                                                        </div>
                                                                        <asp:TextBox ID="txt_codigo_file" CssClass="form-control input-text-bold numero" runat="server" />
                                                                    </div>
                                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_codigo_file" ValidationGroup="addGuardarDatosPersonales" runat="server" />

                                                                </div>
                                                            </div>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>



                                                <div class="row" runat="server" id="DivMap" visible="false">
                                                    <div id="map_kd" style="width: 100%; height: 440px; margin-bottom: 15px;"></div>

                                                    <script>
                                                        var map;

                                                        function initMap() {
                                                            var myLatlng
                                                            if (hf_coordenadas.value !== undefined && hf_coordenadas.value !== null && hf_coordenadas.value !== "") {
                                                                let domcicilio = JSON.parse(hf_coordenadas.value);
                                                                myLatlng = { lat: parseFloat(domcicilio.lat), lng: parseFloat(domcicilio.lng) };
                                                            } else {
                                                                myLatlng = { lat: parseFloat(-16.500303), lng: parseFloat(-68.134189) };
                                                            }

                                                            //var input = document.getElementById('searchTextField');

                                                            map = new google.maps.Map(document.getElementById('map_kd'), {
                                                                center: myLatlng,
                                                                zoom: 17
                                                            });
                                                            var marker = new google.maps.Marker({
                                                                position: myLatlng,
                                                                map: map
                                                            });

                                                            var contentString = '<h1 id="firstHeading" class="firstHeading">Domicilio</h1>';
                                                            var infowindow = new google.maps.InfoWindow({
                                                                content: contentString
                                                            });
                                                            marker.addListener('click', function () {
                                                                infowindow.open(map, marker);
                                                            });
                                                            infowindow.open(map, marker);

                                                            google.maps.event.addListener(map, 'click', function (event) {
                                                                marker.setPosition(event.latLng);
                                                                console.log('coords', event.latLng.lat(), event.latLng.lng())

                                                                let latitud = event.latLng.lat();
                                                                let longitud = event.latLng.lng();

                                                                let coords = { lat: latitud.toFixed(6), lng: longitud.toFixed(6) }
                                                                hf_coordenadas.value = JSON.stringify(coords);
                                                                console.log('hf_coordenadas.value', hf_coordenadas.value);

                                                                infowindow.open(map, marker);
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
                                                                console.log('resultadosBusqueda', bounds);
                                                                places.forEach(function (place) {
                                                                    if (!place.geometry) {
                                                                        console.log("Returned place contains no geometry");
                                                                        return;
                                                                    }

                                                                    // Create a marker for each place.
                                                                    //markers.push(new google.maps.Marker({
                                                                    //    map: map,
                                                                    //    title: place.name,
                                                                    //    position: place.geometry.location
                                                                    //}));

                                                                    if (place.geometry.viewport) {
                                                                        // Only geocodes have viewport.
                                                                        bounds.union(place.geometry.viewport);
                                                                    } else {
                                                                        bounds.extend(place.geometry.location);
                                                                    }
                                                                });
                                                                console.log('resultadosBusquedaBefore', bounds, JSON.stringify(map.center));
                                                                map.fitBounds(bounds);
                                                                console.log('resultadosBusquedaAfter', bounds, JSON.stringify(map.center));

                                                                marker.setPosition(map.center);
                                                                infowindow.open(map, marker);

                                                                let latitud = map.center.lat();
                                                                let longitud = map.center.lng();
                                                                let coords = { lat: latitud.toFixed(6), lng: longitud.toFixed(6) }
                                                                hf_coordenadas.value = JSON.stringify(coords);
                                                            });
                                                        }

                                                    </script>
                                                    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyASEYwuLS1HDI3YAZ6w2gzVmZ8M-wUOG2M&libraries=places&callback=initMap" async defer></script>

                                                  
                                                </div>
                                                <asp:UpdatePanel ID="up_guardar_per_dom" runat="server">
                                                    <ContentTemplate>
                                                        <asp:HiddenField ID="hf_coordenadas" runat="server" ClientIDMode="Static" />
                                                        <asp:HiddenField ID="hf_perd_id" runat="server" ClientIDMode="Static" />
                                                        <asp:HiddenField ID="hf_pf_id" runat="server" ClientIDMode="Static" />



                                                        <div class="row">
                                                            <div class="col-md-3">
                                                                <div class="form-group">
                                                                    <label class="form-control-label">Ciudad/Localidad</label>
                                                                    <asp:DropDownList ID="ddl_perd_ciudad_residencia" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_perd_ciudad_residencia" Display="Dynamic" ValidationGroup="addGuardarDatosPersonales" InitialValue="0" runat="server" />

                                                                </div>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <div class="form-group">
                                                                    <label class="form-control-label">Zona</label>
                                                                    <asp:DropDownList ID="ddl_perd_zona" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_perd_zona" Display="Dynamic" ValidationGroup="addGuardarDatosPersonales" InitialValue="0" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <div class="form-group">
                                                                    <label class="form-control-label">Tipo Vía</label>
                                                                    <asp:DropDownList ID="ddl_perd_tipo_via" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_perd_tipo_via" Display="Dynamic" ValidationGroup="addGuardarDatosPersonales" InitialValue="0" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <div class="form-group">
                                                                    <label class="form-control-label">Nombre Vía</label>

                                                                    <div class="input-group input-group-merge">
                                                                        <div class="input-group-prepend">
                                                                            <span class="input-group-text"><i class="fas fa-home"></i></span>
                                                                        </div>
                                                                        <asp:TextBox ID="txt_nombre_via" class="form-control" runat="server" />
                                                                    </div>
                                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_nombre_via" ValidationGroup="addGuardarDatosPersonales" runat="server" />

                                                                </div>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <div class="form-group">
                                                                    <label class="form-control-label">Número</label>

                                                                    <div class="input-group input-group-merge">
                                                                        <div class="input-group-prepend">
                                                                            <span class="input-group-text"><i class="fas fa-home"></i></span>
                                                                        </div>
                                                                        <asp:TextBox ID="txt_numero_casa" class="form-control" runat="server" />
                                                                    </div>
                                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_numero_casa" ValidationGroup="addGuardarDatosPersonales" runat="server" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-6 col-md-3">
                                                                <div class="form-group">
                                                                    <label class="form-control-label">Edificio</label>

                                                                    <div class="input-group input-group-merge">
                                                                        <div class="input-group-prepend">
                                                                            <span class="input-group-text"><i class="fas fa-home"></i></span>
                                                                        </div>
                                                                        <asp:TextBox ID="txt_edificio" class="form-control" runat="server" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-6 col-md-3">
                                                                <div class="form-group">
                                                                    <label class="form-control-label" for="example4cols2Input">Bloque</label>

                                                                    <div class="input-group input-group-merge">
                                                                        <div class="input-group-prepend">
                                                                            <span class="input-group-text"><i class="fas fa-home"></i></span>
                                                                        </div>
                                                                        <asp:TextBox ID="txt_bloque" class="form-control" runat="server" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-6 col-md-3">
                                                                <div class="form-group">
                                                                    <label class="form-control-label">Piso</label>

                                                                    <div class="input-group input-group-merge">
                                                                        <div class="input-group-prepend">
                                                                            <span class="input-group-text"><i class="fas fa-home"></i></span>
                                                                        </div>
                                                                        <asp:TextBox ID="txt_piso" class="form-control" runat="server" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-6 col-md-3">
                                                                <div class="form-group">
                                                                    <label class="form-control-label">Departamento</label>

                                                                    <div class="input-group input-group-merge">
                                                                        <div class="input-group-prepend">
                                                                            <span class="input-group-text"><i class="fas fa-home"></i></span>
                                                                        </div>
                                                                        <asp:TextBox ID="txt_departamento" class="form-control" runat="server" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-6 col-md-3">
                                                                <div class="form-group">
                                                                    <label class="form-control-label">Teléfono</label>

                                                                    <div class="input-group input-group-merge">
                                                                        <div class="input-group-prepend">
                                                                            <span class="input-group-text"><i class="fas fa-mobile-alt"></i></span>
                                                                        </div>
                                                                        <asp:TextBox ID="txt_telefono" class="form-control" runat="server" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-6 col-md-3">
                                                                <div class="form-group">
                                                                    <label class="form-control-label" for="example4cols2Input">Celular</label>

                                                                    <div class="input-group input-group-merge">
                                                                        <div class="input-group-prepend">
                                                                            <span class="input-group-text"><i class="fas fa-mobile-alt"></i></span>
                                                                        </div>
                                                                        <asp:TextBox ID="txt_celular" class="form-control" runat="server" />
                                                                    </div>
                                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_celular" ValidationGroup="addGuardarDatosPersonales" runat="server" />
                                                                </div>

                                                            </div>
                                                            <div class="col-sm-6 col-md-3">
                                                                <div class="form-group">
                                                                    <label class="form-control-label">Email Trabajo</label>

                                                                    <div class="input-group input-group-merge">
                                                                        <div class="input-group-prepend">
                                                                            <span class="input-group-text"><i class="fas fa-envelope"></i></span>
                                                                        </div>
                                                                        <asp:TextBox ID="txt_email_trabajo" class="form-control" runat="server" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-6 col-md-3">
                                                                <div class="form-group">
                                                                    <label class="form-control-label">Email Personal</label>

                                                                    <div class="input-group input-group-merge">
                                                                        <div class="input-group-prepend">
                                                                            <span class="input-group-text"><i class="fas fa-envelope"></i></span>
                                                                        </div>
                                                                        <asp:TextBox ID="txt_email_personal" class="form-control" runat="server" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">

                                                            <div class="col-md-3">
                                                                <div class="form-group">
                                                                    <label class="form-control-label text-info">En caso de Emergencia llamar</label>

                                                                    <div class="input-group input-group-merge">
                                                                        <div class="input-group-prepend">
                                                                            <span class="input-group-text border-info" style="color: #11cdef"><i class="fas fa-ambulance"></i></span>
                                                                        </div>
                                                                        <asp:TextBox ID="txt_en_caso_emer" class="form-control border-info" runat="server" />

                                                                    </div>
                                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_en_caso_emer" ValidationGroup="addGuardarDatosPersonales" runat="server" />

                                                                </div>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <div class="form-group">
                                                                    <label class="form-control-label text-info">Dirección de Emergencia</label>

                                                                    <div class="input-group input-group-merge">
                                                                        <div class="input-group-prepend">
                                                                            <span class="input-group-text border-info" style="color: #11cdef"><i class="fas fa-map-marker-alt"></i></span>
                                                                        </div>
                                                                        <asp:TextBox ID="txt_direccion_emer" class="form-control border-info" runat="server" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <div class="form-group">
                                                                    <label class="form-control-label text-info">Teléfono de Emergencia</label>

                                                                    <div class="input-group input-group-merge">
                                                                        <div class="input-group-prepend">
                                                                            <span class="input-group-text border-info" style="color: #11cdef"><i class="fas fa-mobile-alt"></i></span>
                                                                        </div>
                                                                        <asp:TextBox ID="txt_telf_emer" class="form-control border-info" runat="server" />

                                                                    </div>
                                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_telf_emer" ValidationGroup="addGuardarDatosPersonales" runat="server" />

                                                                </div>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <div class="form-group">
                                                                    <label class="form-control-label">Nº Libreta de servicio militar</label>
                                                                    <div class="input-group input-group-merge">
                                                                        <div class="input-group-prepend">
                                                                            <span class="input-group-text border-default-2"><i class="fas fa-edit"></i></span>
                                                                        </div>
                                                                        <asp:TextBox ID="txt_nro_lib" class="form-control border-default-2" runat="server" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-9">
                                                            </div>
                                                            <div class="col-md-3">
                                                                <label class="form-control-label">&nbsp</label>
                                                                <asp:LinkButton ID="btn_guardar_datos_personales" CssClass="btn btn-success btn-block" Text="<i class='fas fa-save'></i> Guardar" ValidationGroup="addGuardarDatosPersonales" OnClick="btn_guardar_datos_personales_Click" runat="server" />
                                                            </div>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="tab-pane fade" id="tabs-icons-text-2" role="tabpanel" aria-labelledby="tabs-icons-text-2-tab">
                                    <div class="row">
                                        <div class="col-xl-12">
                                            <div class="card-body">
                                                <div class="table-responsive">
                                                    <asp:UpdatePanel ID="up_gv_familiares" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="gv_familiares" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_familiares_PreRender" OnRowCommand="gv_familiares_RowCommand" DataKeyNames="pf_id" runat="server">
                                                                <Columns>
                                                                    <asp:BoundField DataField="tipo_parentesco" HeaderText="Tipo parentesco" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                    <asp:BoundField DataField="pf_paterno" HeaderText="Apellido Paterno" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                    <asp:BoundField DataField="pf_materno" HeaderText="Apellido Materno" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                    <asp:BoundField DataField="pf_nombres" HeaderText="Nombre(s)" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                    <asp:BoundField DataField="pf_ap_esposo" HeaderText="Apellido Esposo" HeaderStyle-CssClass="text-center" />
                                                                    <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="130px">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton CommandName="GetEdit" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-warning btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-edit fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Editar' runat="server" />
                                                                            <asp:LinkButton CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-google-plus btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Eliminar' runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <div id="block_familia" runat="server">
                                                            <span class="badge badge-pill badge-info">El funcionario no tiene familiares registrados.</span>
                                                        </div>
                                                        <div class="col-lg-6 col-5 text-right">
                                                            <asp:LinkButton ID="btn_nuevo_familiar" CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-inst1 text-white rounded-circle shadow" Text="<i class='fas fa-plus'></i>" data-toggle="tooltip" data-original-title="Adicionar Nuevo Familiar" OnClick="btn_nuevo_familiar_Click" runat="server" />
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="tabs-icons-text-3" role="tabpanel" aria-labelledby="tabs-icons-text-3-tab">
                                    <div class="row">
                                        <div class="col-xl-12">
                                            <div class="card-body">
                                                <p style="margin-bottom: 2rem">Registre los requisitos presentados por el funcionario </p>
                                                <asp:UpdatePanel ID="up_requisitos" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Panel ID="pnlDinamico" runat="server">
                                                        </asp:Panel>
                                                        <asp:HiddenField ID="hf_nro_requisitos" runat="server" />
                                                        <div class="row">
                                                            <div class="col-sm-6 col-md-9">
                                                            </div>

                                                            <div class="col-sm-6 col-md-3">
                                                                <div class="form-group">
                                                                    <label class="form-control-label">&nbsp</label>
                                                                    <asp:LinkButton ID="btn_guardar_requisitos" CssClass="btn btn-success btn-block" Text="<i class='fas fa-save'></i> Guardar" ValidationGroup="addGuardarRequisitos" OnClick="btn_guardar_requisitos_Click" runat="server" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="tabs-icons-text-4" role="tabpanel" aria-labelledby="tabs-icons-text-4-tab">
                                    <div class="row">
                                        <div class="col-xl-12">
                                            <div class="card-body">
                                                <div class="table-responsive py-4">
                                                    <asp:UpdatePanel ID="up_gv_educacion_formal" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="gv_educacion_formal" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_educacion_formal_PreRender" OnRowCommand="gv_educacion_formal_RowCommand" DataKeyNames="ef_id" runat="server">
                                                                <Columns>
                                                                    <asp:BoundField DataField="nivel_instruccion" HeaderText="Nivel de instrucción" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                    <asp:BoundField DataField="centro_form" HeaderText="Centro de formación" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                    <asp:BoundField DataField="carrera_especialidad" HeaderText="Carrera/Especialidad" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                    <asp:BoundField DataField="ef_anios_estudio" HeaderText="Años de estudio" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                    <asp:BoundField DataField="titulo_obtenido" HeaderText="Titulo obtenido" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-bold" />
                                                                    <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="130px">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton CommandName="GetEdit" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-warning btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-edit fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Editar' runat="server" />
                                                                            <asp:LinkButton CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-google-plus btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Eliminar' runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <div id="block_formacion" runat="server">
                                                            <span class="badge badge-pill badge-info">El funcionario no tiene formaciones registrados.</span>
                                                        </div>
                                                        <div class="col-lg-6 col-5 text-right">
                                                            <asp:LinkButton ID="btn_nuevo_foramcion" CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-inst text-white rounded-circle shadow" Text="<i class='fas fa-plus'></i>" data-toggle="tooltip" data-original-title="Adicionar Nueva Formación" OnClick="btn_nuevo_foramcion_Click" runat="server" />
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="modal fade" id="modalNuevoFamiliar" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
                <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                    <div class="modal-content">

                        <div class="modal-body p-0">
                            <div class="card bg-secondary border-0 mb-0">
                                <div class="card-header">
                                    <div class="text-muted text-center mt-2 mb-3"><small>REGISTRO FAMILIAR</small></div>
                                </div>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="card-body px-lg-5 py-lg-5">
                                            <div class="pb-5 text-center">
                                                <a href="javascript:;">
                                                    <img src="../Content/img/theme/fam4.png" alt="Circle image" class="img-fluid rounded-circle shadow" style="width: 100px;">
                                                </a>
                                            </div>
                                            <p class="description">En el siguiente formulario registre los datos requeridos.</p>
                                            <div class="row">

                                                <div class="col-sm-6 col-md-4">
                                                    <div class="form-group">
                                                        <label class="form-control-label" for="example4cols2Input">Apellido Paterno</label>
                                                        <div class="input-group input-group-merge">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text"><i class="fas fa-pen"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt_ap_paterno_fam" class="form-control letras" runat="server" />
                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="col-sm-6 col-md-4">
                                                    <div class="form-group">
                                                        <label class="form-control-label">Apellido Materno</label>
                                                        <div class="input-group input-group-merge">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text"><i class="fas fa-pen"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt_ap_materno_fam" class="form-control letras" runat="server" />
                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">

                                                        <label class="form-control-label">Nombres</label>
                                                        <div class="input-group input-group-merge">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text"><i class="fas fa-pen"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt_nombres_fam" class="form-control letras" runat="server" />
                                                        </div>
                                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_nombres_fam" ValidationGroup="addFamiliar" runat="server" />

                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="form-control-label">Apellido Esposo</label>
                                                        <div class="input-group input-group-merge">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text"><i class="fas fa-pen"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt_ap_esposo_fam" class="form-control letras" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label class="form-control-label">Fecha Nacimiento</label>
                                                        <div class="input-group input-group-merge">
                                                            <div class="input-group-prepend  ">
                                                                <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt_fecha_nac_fam" class="form-control datepickerDefault" runat="server" />
                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="col-sm-6 col-md-4">
                                                    <div class="form-group">
                                                        <label class="form-control-label">Tipo de Parentesco</label>
                                                        <asp:DropDownList ID="ddl_pf_tipo_parentesco" CssClass="form-control select2" AppendDataBoundItems="true" data-minimum-results-for-search="Infinity" runat="server" />
                                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_pf_tipo_parentesco" Display="Dynamic" ValidationGroup="addFamiliar" InitialValue="0" runat="server" />

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="form-group text-center">
                                    <asp:UpdatePanel ID="up_adicionar_familiar" runat="server">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="btn_adicionar_familiar" Text="<i class='fas fa-save mr-2'></i>Guardar" ValidationGroup="addFamiliar" CssClass="btn btn-success" OnClick="btn_adicionar_familiar_Click" runat="server" />
                                            <asp:LinkButton ID="btn_cancelar_familiar" CssClass="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i>Cancelar" OnClick="btn_cancelar_familiar_Click" runat="server" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
            <div class="modal fade" id="eliminarFamiliar" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                    <div class="modal-content bg-gradient-dark6">
                        <div class="modal-header">
                        </div>
                        <asp:UpdatePanel ID="up_eliminar_familiar" runat="server">
                            <ContentTemplate>
                                <div class="modal-body">
                                    <div class="py-3 text-center">
                                        <i class="ni ni-fat-remove ni-3x"></i>
                                        <h4 class="heading text-dark mt-4">¿Esta seguro de eliminar al familiar?</h4>
                                    </div>
                                </div>
                                <div class="form-group text-center">
                                    <asp:LinkButton ID="btn_eliminar_familiar" OnClick="btn_eliminar_familiar_Click" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" runat="server" />
                                    <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <div class="modal fade" id="modalNuevoFormacion" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
                <div class="modal-dialog modal- modal-dialog-centered modal-xl" role="document">
                    <div class="modal-content">

                        <div class="modal-body p-0">
                            <div class="card bg-secondary border-0 mb-0">
                                <div class="card-header">
                                    <div class="text-muted text-center mt-2 mb-3"><small>REGISTRO FORMACIÓN</small></div>
                                </div>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="card-body px-lg-5 py-lg-5">

                                            <div class="pb-5 text-center">
                                                <a href="javascript:;">
                                                    <img src="../Content/img/theme/student1.png" alt="Circle image" class="img-fluid rounded-circle shadow" style="width: 100px;">
                                                </a>
                                            </div>
                                            <p class="description">En el siguiente formulario registre los datos de la formación.</p>
                                            <div class="row">
                                                <div class="col-sm-6 col-md-4">
                                                    <div class="form-group">
                                                        <label class="form-control-label">Nivel de Instrucción</label>
                                                        <asp:DropDownList ID="ddl_nivel_instruccion" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_nivel_instruccion" Display="Dynamic" ValidationGroup="addFormacion" InitialValue="0" runat="server" />

                                                    </div>
                                                </div>
                                                <div class="col-sm-6 col-md-4">
                                                    <div class="form-group">
                                                        <label class="form-control-label" for="example4cols2Input">Centro de Formación</label>
                                                        <asp:DropDownList ID="ddl_centro_form" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_centro_form" Display="Dynamic" ValidationGroup="addFormacion" InitialValue="0" runat="server" />

                                                    </div>
                                                </div>
                                                <div class="col-sm-6 col-md-4">
                                                    <div class="form-group">
                                                        <label class="form-control-label">Carrera /especialidad	</label>
                                                        <asp:DropDownList ID="ddl_carrera" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_carrera" Display="Dynamic" ValidationGroup="addFormacion" InitialValue="0" runat="server" />

                                                    </div>
                                                </div>

                                            </div>
                                            <div class="row">
                                                <div class="col-sm-6 col-md-4">
                                                    <div class="form-group">
                                                        <label class="form-control-label">Titulo obtenido</label>
                                                        <asp:DropDownList ID="ddl_titulos" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_titulos" Display="Dynamic" ValidationGroup="addFormacion" InitialValue="0" runat="server" />

                                                    </div>
                                                </div>
                                                <div class="col-sm-6 col-md-4">
                                                    <div class="form-group">
                                                        <label class="form-control-label">Nº titulo</label>
                                                        <div class="input-group input-group-merge">
                                                            <div class="input-group-prepend  ">
                                                                <span class="input-group-text"><i class="fas fa-pen"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt_nro_titulo" class="form-control" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-sm-6 col-md-4">
                                                    <div class="form-group">
                                                        <label class="form-control-label" for="example4cols2Input">Fecha del Título Obtenido</label>
                                                        <div class="input-group input-group-merge">
                                                            <div class="input-group-prepend  ">
                                                                <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt_fecha_titulo" CssClass="form-control datepickerDefault" runat="server" />
                                                        </div>

                                                    </div>
                                                </div>

                                            </div>
                                            <div class="row">
                                                <div class="col-sm-6 col-md-4">
                                                    <div class="form-group">
                                                        <label class="form-control-label">Fecha de Inicio</label>
                                                        <div class="input-group input-group-merge">
                                                            <div class="input-group-prepend  ">
                                                                <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt_fecha_inicio" CssClass="form-control datepickerDefault" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-sm-6 col-md-4">
                                                    <div class="form-group">
                                                        <label class="form-control-label">Fecha final</label>
                                                        <div class="input-group input-group-merge">
                                                            <div class="input-group-prepend  ">
                                                                <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt_fecha_fin" CssClass="form-control datepickerDefault" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-sm-6 col-md-4">
                                                    <div class="form-group">
                                                        <label class="form-control-label">Años de Estudio</label>
                                                        <div class="input-group input-group-merge">
                                                            <div class="input-group-prepend  ">
                                                                <span class="input-group-text"><i class="fas fa-clock"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt_anios_estudio" CssClass="form-control numero" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>


                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="form-group text-center">
                                    <asp:UpdatePanel ID="up_adicionar_formacion" runat="server">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="btn_adicionar_formacion" Text="<i class='fas fa-save mr-2'></i>Guardar" ValidationGroup="addFormacion" CssClass="btn btn-success" OnClick="btn_adicionar_formacion_Click" runat="server" />
                                            <asp:LinkButton ID="btn_cancelar_formacion" class="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i>Cancelar" OnClick="btn_cancelar_formacion_Click" runat="server" />
                                            <asp:HiddenField ID="hf_ef_id" runat="server" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
            <div class="modal fade" id="eliminarFormacion" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                    <div class="modal-content bg-gradient-dark6">
                        <div class="modal-header">
                        </div>
                        <asp:UpdatePanel ID="up_eliminar_formacion" runat="server">
                            <ContentTemplate>
                                <div class="modal-body">
                                    <div class="py-3 text-center">
                                        <i class="ni ni-fat-remove ni-3x"></i>
                                        <h4 class="heading text-dark mt-4">¿Está seguro de eliminar la formación?</h4>
                                    </div>
                                </div>
                                <div class="form-group text-center">
                                    <asp:LinkButton ID="btn_eliminar_formacion" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btn_eliminar_formacion_Click" runat="server" />
                                    <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
        <asp:UpdateProgress ID="up1" AssociatedUpdatePanelID="up_guardar_per_dom" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up2" AssociatedUpdatePanelID="up_adicionar_familiar" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up3" AssociatedUpdatePanelID="up_requisitos" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up4" AssociatedUpdatePanelID="up_adicionar_formacion" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up5" AssociatedUpdatePanelID="up_eliminar_familiar" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up6" AssociatedUpdatePanelID="up_eliminar_formacion" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up7" AssociatedUpdatePanelID="up_gv_familiares" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="u8" AssociatedUpdatePanelID="up_gv_educacion_formal" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
</asp:Content>


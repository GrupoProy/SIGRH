<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ConsultaFuncionario.aspx.cs" Inherits="MovimientoPersonal_ConsultaFuncionario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Consulta Funcionario</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid mt--7">
        <div class="ct-example  card" style="padding-bottom: unset">
            <div class="card-body">
                <div class="card bg-default mb-4">
                    <div class="row justify-content-center">
                        <div class="col-lg-3 order-lg-2">
                            <div class="card-profile-image">
                                <a href="#">
                                    <asp:Image ID="imgFun" class="rounded-circle" runat="server" />
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="card-header bg-default text-center border-0 pt-8 pt-md-4 pb-0 pb-md-4">
                        <h3 class="h2 text-white d-inline-block float-left mb-0"><i class="fas fa-id-card-alt mr-2"></i>Datos funcionario</h3>
                        <asp:LinkButton ID="btn_estado" class="btn btn-sm btn-info float-right" runat="server" />
                    </div>
                    <div class="card-body">
                        <div class="media align-items-center">
                            <div class="media-body">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-xl-6 col-md-6">
                                                <div class="card card-stats">
                                                    <div class="card-body">
                                                        <div class="row">
                                                            <div class="col">
                                                                <h5 class="card-title text-uppercase text-muted mb-0">Datos personales</h5>
                                                                <span class="h5">&nbsp</span>
                                                            </div>
                                                            <div class="col-auto">
                                                                <div class="icon icon-shape bg-gradient-red text-white rounded-circle shadow">
                                                                    <i class="ni ni-single-02"></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-lg-3">
                                                                <div class="content-text-label">Cód. Funcionario</div>
                                                                <div class="h5 font-weight-400 content-text content-text">
                                                                    <asp:Literal ID="ltl_cod_fun" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-3">
                                                                <div class="content-text-label">CI</div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_num_doc" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-6">
                                                                <div class="content-text-label">Nombre funcionario</div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_nombre_fun" runat="server" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-lg-6">
                                                                <div class="content-text-label">Estado civil</div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_estado_civil" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-6">
                                                                <div class="content-text-label">Sexo</div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_genero" runat="server" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-xl-6 col-md-6">
                                                <div class="card card-stats">
                                                    <div class="card-body">
                                                        <div class="row">
                                                            <div class="col">
                                                                <h5 class="card-title text-uppercase text-muted mb-0">Fecha de nacimiento y domicilio</h5>
                                                                <span class="h5">&nbsp</span>
                                                            </div>
                                                            <div class="col-auto">
                                                                <div class="icon icon-shape bg-gradient-orange text-white rounded-circle shadow">
                                                                    <i class="ni ni-badge"></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-lg-4">
                                                                <div class="content-text-label">Fecha de nacimiento</div>
                                                                <div class="h5 font-weight-400 content-text content-text">
                                                                    <asp:Literal ID="ltl_fecha_nac" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-3">
                                                                <div class="content-text-label">País</div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_pais" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-5">
                                                                <div class="content-text-label">Cuidad/Localidad</div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_localidad" runat="server" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-lg-4">
                                                                <div class="content-text-label">Zona</div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_zona" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-4">
                                                                <div class="content-text-label">Nombre Vía</div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_nombre_via" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-4">
                                                                <div class="content-text-label">Número</div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_numero" runat="server" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
<%--                                            <div class="col-xl-6 col-md-6">--%>
                                            <div class="col-xl-12 col-md-12">
                                                <div class="card card-stats">
                                                    <div class="card-body">
                                                        <div class="row">
                                                            <div class="col">
                                                                <h5 class="card-title text-uppercase text-muted mb-0">Datos Lugar de Trabajo</h5>
                                                                <span class="h5">&nbsp</span>
                                                            </div>
                                                            <div class="col-auto">
                                                                <div class="icon icon-shape bg-gradient-green text-white rounded-circle shadow">
                                                                    <i class="ni ni-money-coins"></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-lg-2">
                                                                <div class="content-text-label">Ítem</div>
                                                                <div class="h5 font-weight-400 content-text content-text">
                                                                    <asp:Literal ID="ltl_item" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <div class="content-text-label">Haber Básico</div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_haber_basico" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-3">
                                                                <div class="content-text-label">Cargo</div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_cargo" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-5">
                                                                <div class="content-text-label">Puesto</div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_puesto" runat="server" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-lg-6">
                                                                <div class="content-text-label">Unidad de Trabajo</div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_ubicacion" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-3">
                                                                <div class="content-text-label">Fecha Asignación</div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_fecha_inicio" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-3">
                                                                <div class="content-text-label">Fecha Baja</div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_fecha_fin" runat="server" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                        <div class="col-md-12">
                                                                <div class="content-text-label">TIPO DE JORNADA:</div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_jornada" runat="server" />
                                                                </div>
                                                        </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-xl-6 col-md-6" runat="server" visible="false">
                                                <div class="card card-stats">
                                                    <div class="card-body">
                                                        <div class="row">
                                                            <div class="col">
                                                                <h5 class="card-title text-uppercase text-muted mb-0">Datos asignación seguro</h5>
                                                                <span class="h5">&nbsp</span>
                                                            </div>
                                                            <div class="col-auto">
                                                                <div class="icon icon-shape bg-gradient-info text-white rounded-circle shadow">
                                                                    <i class="ni ni-ambulance"></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-lg-6">
                                                                <div class="content-text-label">Caja Aseguradora</div>
                                                                <div class="h5 font-weight-400 content-text content-text">
                                                                    <asp:Literal ID="ltl_caja_afiliado" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-3">
                                                                <div class="content-text-label">Fecha Afiliación</div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_fecha_afiliacion" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-3">
                                                                <div class="content-text-label">Estado</div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_estado_afiliacion" runat="server" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-lg-6">
                                                                <div class="content-text-label">Policlínico</div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_policlinico" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-6">
                                                                <div class="content-text-label">Número Asegurado</div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_numero_afiliado" runat="server" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <div class="card">

                            <div class="tab-content">
                                <div id="nav-pills-tabs-component" class="tab-pane tab-example-result fade active show" role="tabpanel" aria-labelledby="nav-pills-tabs-component-tab">
                                    <div class="nav-wrapper">
                                        <ul class="nav nav-pills nav-fill flex-column flex-md-row" id="tabs-icons-text" role="tablist">
                                            <li class="nav-item">
                                                <a class="nav-link mb-sm-3 mb-md-0 active" id="tabs-icons-text-1-tab" data-toggle="tab" href="#tabs-icons-text-1" role="tab" aria-controls="tabs-icons-text-1" aria-selected="true"><i class="fas fa-address-card mr-2"></i>ADMINISTRATIVO (<asp:Literal ID="litTotalFilas" runat="server"></asp:Literal>) </a>
                                            </li>
                                            <li class="nav-item">
                                                <a class="nav-link mb-sm-3 mb-md-0" id="tabs-icons-text-2-tab" data-toggle="tab" href="#tabs-icons-text-2" role="tab" aria-controls="tabs-icons-text-2" aria-selected="false"><i class="fas fa-user-tag mr-2"></i>DOCENTE (<asp:Literal ID="litfilasD" runat="server"></asp:Literal>) </a>
                                            </li>
                                            <li class="nav-item">
                                                <a class="nav-link mb-sm-3 mb-md-0" id="tabs-icons-text-3-tab" data-toggle="tab" href="#tabs-icons-text-3" role="tab" aria-controls="tabs-icons-text-3" aria-selected="false"><i class="fas fa-list-ol mr-2"></i>CONSULTOR EN LINEA (<asp:Literal ID="litfilasCon" runat="server"></asp:Literal>) </a>
                                            </li>
                                        </ul>
                                    </div>
                    
                    <div class="card shadow">
                        <div class="card-body">
                            <%-- ADMINISTRATIVO --%>
                            <div class="tab-content" id="myTabContent">
                                <div class="tab-pane fade show active" id="tabs-icons-text-1" role="tabpanel" aria-labelledby="tabs-icons-text-1-tab">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="card">
                                                <div class=" ct-page-title">
                                                    <h3 class="mb-0">Histórico de asignaciones</h3>
                                                    <p class="text-sm mb-0">
                                                        Detalle de todas las asignaciones obtenidas del funcionario seleccionado.
                                                    </p>
                                                </div>
                                            </div>
                                            <div class="table-responsive py-4">
                                                <asp:UpdatePanel ID="panelGvHistoricoAsig" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="gv_historicoAsig" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_historicoAsig_PreRender" DataKeyNames="as_id" runat="server">
                                                            <Columns>
                                                                <asp:BoundField DataField="as_fecha_inicio" HeaderText="Fecha Asignación" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="as_fecha_fin" HeaderText="Fecha Baja" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="as_estado" HeaderText="Estado" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="item" HeaderText="Nro. Ítem" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="ubicacion" HeaderText="Ubicación" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="cargo" HeaderText="Cargo" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="HBASICO" HeaderText="Haber Basico" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="PUESTO" HeaderText="Puesto" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="as_tipo_baja" HeaderText="Motivo de Baja" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <div class="col-md-12">
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <div id="block_HisAsignaciones" runat="server">
                                                                <span class="badge badge-pill badge-info">El funcionario no tiene asignaciones como administrativo.</span>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <%-- DOCENTE --%>
                                <div class="tab-pane fade" id="tabs-icons-text-2" role="tabpanel" aria-labelledby="tabs-icons-text-2-tab">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="card">
                                                <div class=" ct-page-title">
                                                    <h3 class="mb-0">Histórico de asignaciones</h3>
                                                    <p class="text-sm mb-0">
                                                        Detalle de todas las asignaciones obtenidas del funcionario seleccionado.
                                                    </p>
                                                </div>
                                            </div>
                                            <div class="table-responsive py-4">
                                                <asp:UpdatePanel ID="up2" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="gv_doc" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_doc_PreRender" DataKeyNames="as_id" runat="server">
                                                            <Columns>
                                                                <asp:BoundField DataField="as_fecha_inicio" HeaderText="Fecha Asignación" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="as_fecha_fin" HeaderText="Fecha Baja" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="as_estado" HeaderText="Estado" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="item" HeaderText="Nro. Ítem" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="ubicacion" HeaderText="Ubicación" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="cargo" HeaderText="Cargo" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="HBASICO" HeaderText="Haber Basico" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="PUESTO" HeaderText="Puesto" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="as_tipo_baja" HeaderText="Motivo de Baja" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <div class="col-md-12">
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <div id="bloque_doc" runat="server">
                                                                <span class="badge badge-pill badge-info">El funcionario no tiene asignaciones como docente.</span>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <%-- CONSULTOR --%>
                                <div class="tab-pane fade" id="tabs-icons-text-3" role="tabpanel" aria-labelledby="tabs-icons-text-3-tab">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="card">
                                                <div class=" ct-page-title">
                                                    <h3 class="mb-0">Histórico de asignaciones</h3>
                                                    <p class="text-sm mb-0">
                                                        Detalle de todas las asignaciones obtenidas del funcionario seleccionado.
                                                    </p>
                                                </div>
                                            </div>
                                            <div class="table-responsive py-4">
                                                <asp:UpdatePanel ID="up3" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="gv_cons" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_cons_PreRender" DataKeyNames="as_id" runat="server">
                                                            <Columns>
                                                                <asp:BoundField DataField="as_fecha_inicio" HeaderText="Fecha Asignación" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="as_fecha_fin" HeaderText="Fecha Baja" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="as_estado" HeaderText="Estado" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="item" HeaderText="Nro. Ítem" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="ubicacion" HeaderText="Ubicación" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="cargo" HeaderText="Cargo" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="HBASICO" HeaderText="Haber Basico" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="PUESTO" HeaderText="Puesto" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="as_tipo_baja" HeaderText="Motivo de Baja" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <div class="col-md-12">
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <div id="bloque_cons" runat="server">
                                                                <span class="badge badge-pill badge-info">El funcionario no tiene asignaciones como consultor en linea.</span>
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
            </div>


















                        </div>
                    </div>
                </div>
                <div class="row" runat="server" visible="false">
                    <div class="col-lg-6">
                        <div class="card">
                            <div class="card-header">
                                <div class=" ct-page-title2">
                                    <h3 class="mb-0">Filiación</h3>
                                    <p class="text-sm mb-0">
                                        Detalle de los requisitos presentados para la afiliación en Kardex del funcionario seleccionado.
                                    </p>
                                </div>
                            </div>
                            <div class="table-responsive py-4">
                                <asp:UpdatePanel ID="panelGvFiliacion" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="gv_filiacion" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_filiacion_PreRender" DataKeyNames="rp_id" runat="server">
                                            <Columns>
                                                <asp:BoundField DataField="rq_descripcion" HeaderText="Requisito" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-left" />
                                                <asp:BoundField DataField="rc_desc" HeaderText="Estado  " HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-left" />
                                                <asp:BoundField DataField="rp_fecha_presentado" HeaderText="Fecha presentación" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="card">
                            <div class="card-header">
                                <div class=" ct-page-title">
                                    <h3 class="mb-0">Asignación de Vacaciones</h3>
                                    <p class="text-sm mb-0">
                                        Detalle de los días y horas asignados para sacar una solicitud de vacación.
                                    </p>
                                </div>
                            </div>
                            <div class="table-responsive py-4">
                                <asp:UpdatePanel ID="panelGvVacacionDisponible" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="gv_dias_vacacion_disp" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_dias_vacacion_disp_PreRender" DataKeyNames="va_id, va_per_id" runat="server">
                                            <Columns>
                                                <asp:BoundField DataField="va_gestion" HeaderText="Gestión" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                <asp:BoundField DataField="va_dias_ley" HeaderText="Días ley" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                <asp:BoundField DataField="va_dias_restantes" HeaderText="Saldo en días" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                <asp:BoundField DataField="va_horas_restantes" HeaderText="Saldo en horas" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                <asp:BoundField DataField="va_fecha_ingreso" HeaderText="Fecha ingreso" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                <asp:BoundField DataField="va_estado" HeaderText="Estado" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="col-md-12">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <div id="block_asigVacaciones" runat="server">
                                                <span class="badge badge-pill badge-info">El funcionario no tiene vacaciones asignadas.</span>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="col-lg-6">
                        <div class="card">
                            <div class="card-header">
                                <div class=" ct-page-title3">
                                    <h3 class="mb-0">Familiares</h3>
                                    <p class="text-sm mb-0">
                                        Detalle de todos los familiares registrados del funcionario seleccionado.
                                    </p>
                                </div>
                            </div>
                            <div class="table-responsive py-4">
                                <asp:UpdatePanel ID="up_gv_familiares" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="gv_familiares" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_familiares_PreRender" DataKeyNames="pf_id" runat="server">
                                            <Columns>
                                                <asp:BoundField DataField="tipo_parentesco" HeaderText="Tipo parentesco" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                <asp:BoundField DataField="pf_paterno" HeaderText="Apellido Paterno" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                <asp:BoundField DataField="pf_materno" HeaderText="Apellido Materno" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                <asp:BoundField DataField="pf_nombres" HeaderText="Nombre(s)" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                <asp:BoundField DataField="pf_ap_esposo" HeaderText="Apellido Esposo" HeaderStyle-CssClass="text-center" />
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="col-md-12">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <div id="block_familia" runat="server">
                                                <span class="badge badge-pill badge-info">El funcionario no tiene familiares registrados.</span>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                        <div class="card">
                            <div class="card-header">
                                <div class=" ct-page-title4">
                                    <h3 class="mb-0">Beneficios</h3>
                                    <p class="text-sm mb-0">
                                        Detalle de los beneficios asignados al funcionario seleccionado. 
                                    </p>
                                </div>
                            </div>
                            <div class="table-responsive py-4">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="gv_asignacion_beneficios" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_asignacion_beneficios_PreRender" DataKeyNames="ab_id" runat="server">
                                            <Columns>
                                                <asp:BoundField DataField="pf_tipo_parentesco" HeaderText="Tipo parentesco" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                <asp:BoundField DataField="pf_paterno" HeaderText="Apellido Paterno" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                <asp:BoundField DataField="pf_materno" HeaderText="Apellido Materno" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                <asp:BoundField DataField="pf_nombres" HeaderText="Nombre(s)" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                <asp:BoundField DataField="fa_descripcion" HeaderText="Subsidio" HeaderStyle-CssClass="text-center" />
                                                <asp:BoundField DataField="ab_fecha_inicio" HeaderText="A partir" HeaderStyle-CssClass="text-center" />
                                                <asp:BoundField DataField="ab_fecha_fin" HeaderText="Hasta" HeaderStyle-CssClass="text-center" />
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="col-md-12">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <div id="block_beneficios" runat="server">
                                                <span class="badge badge-pill badge-info">El funcionario no tiene beneficios asignados.</span>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                        <div class="card">
                            <div class="card-header">
                                <div class=" ct-page-title2">
                                    <h3 class="mb-0">Vacaciones Utilizadas</h3>
                                    <p class="text-sm mb-0">
                                        Detalle de las vacaciones anuales solicitadas por el funcionario seleccionado.
                                    </p>
                                </div>
                            </div>
                            <div class="table-responsive py-4">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="gv_Hvacaciones" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_Hvacaciones_PreRender" DataKeyNames="vac_id, vac_per_id" runat="server">
                                            <Columns>
                                                <asp:BoundField DataField="vac_fecha_creacion" HeaderText="Fecha Solicitud" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                <asp:BoundField DataField="vac_nro_dias_vacacion" HeaderText="Nro. Días" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                <asp:BoundField DataField="vac_a_partir" HeaderText="A Partir" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                <asp:BoundField DataField="vac_hasta" HeaderText="Hasta" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                <asp:BoundField DataField="vac_correspondiente_gestion" HeaderText="Gestión" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="80px" />
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="col-md-12">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <div id="block_vacacionAnual" runat="server">
                                                <span class="badge badge-pill badge-info">El funcionario no tiene vacaciones registradas.</span>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row" runat="server" visible="false">
                    <div class="col-lg-12">
                        <div class="card">
                            <div class="card-header">
                                <div class=" ct-page-title3">
                                    <h3 class="mb-0">Educación</h3>
                                    <p class="text-sm mb-0">
                                        Detalle de los títulos obtenidos del funcionario seleccionado.
                                    </p>
                                </div>
                            </div>
                            <div class="table-responsive py-4">
                                <asp:UpdatePanel ID="up_gv_educacion_formal" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="gv_educacion_formal" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_educacion_formal_PreRender" DataKeyNames="ef_id" runat="server">
                                            <Columns>
                                                <asp:BoundField DataField="nivel_instruccion" HeaderText="Nivel de instrucción" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                <asp:BoundField DataField="centro_form" HeaderText="Centro de formación" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                <asp:BoundField DataField="carrera_especialidad" HeaderText="Carrera/Especialidad" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                <asp:BoundField DataField="ef_anios_estudio" HeaderText="Años de estudio" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                <asp:BoundField DataField="titulo_obtenido" HeaderText="Titulo obtenido" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-bold" />
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="col-md-12">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <div id="block_formacion" runat="server">
                                                <span class="badge badge-pill badge-info">El funcionario no tiene formaciones registrados.</span>
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
</asp:Content>


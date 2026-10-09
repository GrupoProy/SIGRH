<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="RegistroVacaciones.aspx.cs" Inherits="Kardex_RegistroVacaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Registro de Vacaciones</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid mt--7">
        <div class="card">
            <div class="card-header">
                <h3 class="h2 text d-inline-block mb-0"><i class="fas fa-id-card-alt mr-2"></i>Datos funcionario</h3>
            </div>
            <div>
                <div class="card-body">
                    <div class="media align-items-center">
                        <asp:Image ID="imgFun" class="avatar-xll img-thumbnail mr-4" runat="server" />
                        <div class="card-body pt-0">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-lg-3">
                                            <h5 class="h3 text-uppercase text-left">
                                                <asp:Literal ID="ltl_nombre_fun" runat="server" />
                                            </h5>
                                            <div class="h5 font-weight-400  text-left">
                                                <strong class="h5">CI: </strong>
                                                <asp:Literal ID="ltl_ci" runat="server" />
                                                <strong class="h5">COD. FUN:</strong>
                                                <asp:Literal ID="ltl_cod_fun" runat="server" />
                                                <strong class="h5">ÍTEM:</strong>
                                                <asp:Literal ID="ltl_item" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="content-text-label">Cargo</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_cargo" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="content-text-label">Puesto</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_puesto" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="content-text-label">Ubicación</div>
                                            <div class="h5 font-weight-400 content-text content-text">
                                                <asp:Literal ID="ltl_ubicacion" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%-- TAB 2 --%>
        <div class="ct-example  card" style="padding-bottom: unset">
            <div class="tab-content">
                <div id="nav-pills-tabs-component2" class="tab-pane tab-example-result fade active show" role="tabpanel" aria-labelledby="nav-pills-tabs-component-tab">
                    <div class="nav-wrapper">
                        <ul class="nav nav-pills nav-fill flex-column flex-md-row" id="tabs-icons-text2" role="tablist">
                            <li class="nav-item">
                                <a class="nav-link mb-sm-3 mb-md-0 active" id="tabs-icons-text-5-tab" data-toggle="tab" href="#tabs-icons-text-5" role="tab" aria-controls="tabs-icons-text-5" aria-selected="true"><i class="fas fa-book mr-2"></i>DÍAS DE VACACIÓN DISPONIBLE</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link mb-sm-3 mb-md-0" id="tabs-icons-text-6-tab" data-toggle="tab" href="#tabs-icons-text-6" role="tab" aria-controls="tabs-icons-text-6" aria-selected="false"><i class="fas fa-user-friends mr-2"></i>HISTÓRICO ASIGNACIONES</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link mb-sm-3 mb-md-0" id="tabs-icons-text-7-tab" data-toggle="tab" href="#tabs-icons-text-7" role="tab" aria-controls="tabs-icons-text-7" aria-selected="false"><i class="fas fa-user-graduate mr-2"></i>FILIACIÓN</a>
                            </li>
                        </ul>
                    </div>
                    <div class="card shadow">
                        <div class="card-body">
                            <div class="tab-content" id="myTabContent2">
                                <div class="tab-pane fade show active" id="tabs-icons-text-5" role="tabpanel" aria-labelledby="tabs-icons-text-5-tab">
                                    <div class="row">
                                        <div class="col-xl-12">
                                            <div class="card-header">
                                                <div class=" ct-page-title">
                                                    <p class="text-sm mb-0">
                                                        Detalle de los días y horas disponibles para sacar una solicitud de vacación. 
                                                    </p>
                                                </div>
                                            </div>
                                            <div class="table-responsive py-4" runat="server" visible="false">
                                                <asp:UpdatePanel ID="panelGvVacacionDisponible" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="gv_dias_vacacion_disp" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_dias_vacacion_disp_PreRender" DataKeyNames="va_id, va_per_id" runat="server">
                                                            <Columns>
                                                                <asp:BoundField DataField="va_gestion" HeaderText="Gestión" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="va_dias_ley" HeaderText="Días ley" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="va_dias_restantes" HeaderText="Saldo en días" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center display-2 dt-sub-title" />
                                                                <asp:BoundField DataField="va_horas_restantes" Visible="false" HeaderText="Saldo en horas" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="va_fecha_ingreso" HeaderText="Fecha ingreso" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="va_estado" HeaderText="Estado" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                            <div class="table-responsive py-4">
                                                <asp:UpdatePanel ID="panelActualizar" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="gvActualizarSaldos" OnRowCancelingEdit="gvActualizarSaldos_RowCancelingEdit" OnRowEditing="gvActualizarSaldos_RowEditing" OnRowUpdating="gvActualizarSaldos_RowUpdating" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_dias_vacacion_disp_PreRender" DataKeyNames="va_id, va_per_id" runat="server">
                                                            <Columns>
                                                                <asp:TemplateField >
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btn_Edit" runat="server" Text="Editar" CssClass="btn btn-info" CommandName="Edit" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>  
                                                                        <asp:Button ID="btn_Update" runat="server" Text="Actualizar" CssClass="btn btn-success" CommandName="Update"/>  
                                                                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancelar" CssClass="btn btn-warning" CommandName="Cancel"/>  
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="GESTION">  
                                                                    <ItemTemplate>  
                                                                        <asp:Label ID="lbl_gestion" runat="server" Text='<%#Eval("va_gestion") %>'></asp:Label>  
                                                                    </ItemTemplate>  
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="DIAS LEY">  
                                                                    <ItemTemplate>  
                                                                        <asp:Label ID="lbl_dias" runat="server" Text='<%#Eval("va_dias_ley") %>'></asp:Label>  
                                                                    </ItemTemplate>  
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="SALDO EN DIAS">  
                                                                    <ItemTemplate>  
                                                                        <asp:Label ID="lbl_saldo" runat="server" Text='<%#Eval("va_dias_restantes") %>'></asp:Label>  
                                                                    </ItemTemplate>  
                                                                    <EditItemTemplate>  
                                                                        <asp:TextBox ID="txt_saldo" runat="server" Text='<%#Eval("va_dias_restantes") %>'></asp:TextBox>  
                                                                    </EditItemTemplate>  
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="FECHA INGRESO">  
                                                                    <ItemTemplate>  
                                                                        <asp:Label ID="lbl_ingreso" runat="server" Text='<%#Eval("va_fecha_ingreso") %>'></asp:Label>  
                                                                    </ItemTemplate>  
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ESTADO">  
                                                                    <ItemTemplate>  
                                                                        <asp:Label ID="lbl_estado" runat="server" Text='<%#Eval("va_estado") %>'></asp:Label>  
                                                                    </ItemTemplate>  
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="tabs-icons-text-6" role="tabpanel" aria-labelledby="tabs-icons-text-6-tab">
                                    <div class="row">
                                        <div class="col-xl-12">
                                            <div class="card-header">
                                                <div class=" ct-page-title">
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
                                                                <asp:BoundField DataField="as_tipo_baja" HeaderText="Motivo de Baja" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="tabs-icons-text-7" role="tabpanel" aria-labelledby="tabs-icons-text-7-tab">
                                    <div class="row">
                                        <div class="card-header">
                                            <div class=" ct-page-title">
                                                <p class="text-sm mb-0">
                                                    Detalle de los requisitos presentados para la afiliación en Kardex del funcionario seleccionado.
                                                </p>
                                            </div>
                                        </div>
                                        <div class="col-xl-12">
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
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%-- TAB 1--%>
        <div class="ct-example  card" style="padding-bottom: unset">
            <div class="tab-content">
                <div id="nav-pills-tabs-component" class="tab-pane tab-example-result fade active show" role="tabpanel" aria-labelledby="nav-pills-tabs-component-tab">
                    <div class="nav-wrapper">
                        <ul class="nav nav-pills nav-fill flex-column flex-md-row" id="tabs-icons-text" role="tablist">
                            <li class="nav-item">
                                <a class="nav-link mb-sm-3 mb-md-0 active" id="tabs-icons-text-1-tab" data-toggle="tab" href="#tabs-icons-text-1" role="tab" aria-controls="tabs-icons-text-1" aria-selected="true"><i class="fas fa-book mr-2"></i>VACACIÓN ANUAL</a>
                            </li>
                            <li runat="server"  visible="false" class="nav-item">
                                <a class="nav-link mb-sm-3 mb-md-0" id="tabs-icons-text-2-tab" data-toggle="tab" href="#tabs-icons-text-2" role="tab" aria-controls="tabs-icons-text-2" aria-selected="false"><i class="fas fa-calendar-plus mr-2"></i>LICENCIA CON CARGO A VACACIÓN</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link mb-sm-3 mb-md-0" id="tabs-icons-text-3-tab" data-toggle="tab" href="#tabs-icons-text-3" role="tab" aria-controls="tabs-icons-text-3" aria-selected="false"><i class="fas fa-calendar-alt mr-2"></i>GESTIÓN PRESCRITO</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link mb-sm-3 mb-md-0" id="tabs-icons-text-4-tab" data-toggle="tab" href="#tabs-icons-text-4" role="tab" aria-controls="tabs-icons-text-4" aria-selected="false"><i class="fas fa-calendar-check mr-2"></i>REGISTRO CAS</a>
                            </li>
                        </ul>
                    </div>
                    <div class="card shadow">
                        <div class="card-body">
                            <div class="tab-content" id="myTabContent">
                                <div class="tab-pane fade show active" id="tabs-icons-text-1" role="tabpanel" aria-labelledby="tabs-icons-text-1-tab">
                                    <div class="row">
                                        <div class="col-xl-12">
                                            <div class="card-header">
                                                <div class=" ct-page-title">
                                                    <p class="text-sm mb-0">
                                                        Detalle de las vacaciones anuales solicitadas por el funcionario seleccionado.
                                                    </p>
                                                </div>
                                            </div>
                                            <div class="table-responsive py-4">
                                                <asp:UpdatePanel ID="panelGvVacacionAnual" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="gv_Hvacaciones" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_Hvacaciones_PreRender" OnRowCommand="gv_Hvacaciones_RowCommand" DataKeyNames="vac_id, vac_per_id" runat="server">
                                                            <Columns>
                                                                <asp:BoundField DataField="vac_fecha_creacion" HeaderText="Solicitud" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="40px" />
                                                                <asp:BoundField DataField="vac_nro_dias_vacacion" HeaderText="Días" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"  HeaderStyle-Width="60px" />
                                                                <asp:BoundField DataField="vac_a_partir" HeaderText="A Partir" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"  HeaderStyle-Width="40px" />
                                                                <asp:BoundField DataField="vac_hasta" HeaderText="Hasta" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"  HeaderStyle-Width="40px"/>
                                                                <asp:BoundField DataField="vac_correspondiente_gestion" HeaderText="Gestión" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="80px" />
                                                                <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="130px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton CommandName="Print" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-info btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-print fa-lg'></i>Imprimir</span>" data-toggle='tooltip' data-placement='top' title='Imprimir' runat="server" />
                                                                        <asp:LinkButton CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-google-plus btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Eliminar' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
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
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <div class="col-lg-6 col-5 text-right">
                                                        <asp:LinkButton ID="btn_nueva_vacacion" CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-inst1 text-white rounded-circle shadow" Text="<i class='fas fa-plus'></i>" data-toggle="tooltip" data-original-title="Adicionar Nueva Vacación" OnClick="btn_nueva_vacacion_Click" runat="server" />
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="tabs-icons-text-2" role="tabpanel" aria-labelledby="tabs-icons-text-2-tab">
                                    <div class="row">
                                        <div class="col-xl-12">
                                            <div class="card-header">
                                                <div class=" ct-page-title">
                                                    <p class="text-sm mb-0">
                                                        Detalle de las licencias con cargo a vacación solicitadas por el funcionario seleccionado.
                                                    </p>
                                                </div>
                                            </div>
                                            <div class="table-responsive py-4">
                                                <asp:UpdatePanel ID="panelGvLicenciaVacacion" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="gv_licenciaVacacion" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_licenciaVacacion_PreRender" OnRowCommand="gv_licenciaVacacion_RowCommand" DataKeyNames="lj_id, lj_per_id" runat="server">
                                                            <Columns>
                                                                <asp:BoundField DataField="lj_id" HeaderText="Nro. Papeleta" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="lj_fecha_inicial" HeaderText="A partir" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="lj_fecha_final" HeaderText="Hasta" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="lj_hora_salida" HeaderText="Hora Inicio" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="lj_hora_retorno" HeaderText="Hora Fin" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="130px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-google-plus btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Eliminar' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <div class="col-md-12">
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <div id="block_licenciaVacacion" runat="server">
                                                                <span class="badge badge-pill badge-info">El funcionario no tiene licencia con cargo a vacación registradas.</span>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <div class="col-lg-6 col-5 text-right">
                                                        <asp:LinkButton ID="btn_nueva_licencia" CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-inst1 text-white rounded-circle shadow" Text="<i class='fas fa-plus'></i>" data-toggle="tooltip" data-original-title="Adicionar Nueva Licencia" OnClick="btn_nueva_licencia_Click" runat="server" />
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="tabs-icons-text-3" role="tabpanel" aria-labelledby="tabs-icons-text-3-tab">
                                    <div class="row">
                                        <div class="col-xl-12">
                                            <div class="card-header">
                                                <div class=" ct-page-title">
                                                    <p class="text-sm mb-0">
                                                        Detalle de las gestiones disponibles para prescribir del funcionario seleccionado.
                                                    </p>
                                                </div>
                                            </div>
                                            <div class="table-responsive py-4">
                                                <asp:UpdatePanel ID="panelGvGestionPrescrito" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="gv_gestion_prescrito" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_gestion_prescrito_PreRender" OnRowCommand="gv_gestion_prescrito_RowCommand" DataKeyNames="va_id" runat="server">
                                                            <Columns>
                                                                <asp:BoundField DataField="va_gestion" HeaderText="Gestión" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="va_dias_ley" HeaderText="Días Ley" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="va_dias_restantes" HeaderText="Días restantes" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="va_horas_restantes" HeaderText="Horas restantes" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="130px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton CommandName="GetEdit" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-warning btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-edit fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Habilitar Gestión Prescrito' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <div class="col-md-12">
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <div id="block_gestionPrescrito" runat="server">
                                                                <span class="badge badge-pill badge-info">El funcionario no tiene gestiones para prescribir.</span>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="tabs-icons-text-4" role="tabpanel" aria-labelledby="tabs-icons-text-4-tab">
                                    <div class="row">
                                        <div class="col-xl-12">
                                            <div class="card-header">
                                                <div class=" ct-page-title">
                                                    <p class="text-sm mb-0">
                                                        Detalle de los registros CAS – MU del funcionario seleccionado.
                                                    </p>
                                                </div>
                                            </div>
                                            <div class="table-responsive py-4">
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="gv_doc_cas" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_doc_cas_PreRender" OnRowCommand="gv_doc_cas_RowCommand" DataKeyNames="cs_id" runat="server">
                                                            <Columns>
                                                                <asp:BoundField DataField="cs_nro_cas" HeaderText="Número CAS" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="cs_fecha_cas" HeaderText="Fecha" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="cat_descripcion" HeaderText="Tipo CAS" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="cs_anios_calif" HeaderText="Años" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="cs_meses_calif" HeaderText="Meses" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="cs_dias_calif" HeaderText="Días" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="130px">
                                                                    <ItemTemplate>
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
                                                    <div class="col-lg-6 col-5 text-right">
                                                        <asp:LinkButton ID="btn_nuevo_docCAS" CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-inst1 text-white rounded-circle shadow" Text="<i class='fas fa-plus'></i>" data-toggle="tooltip" data-original-title="Adicionar Nuevo Registro CAS" OnClick="btn_nuevo_docCAS_Click" runat="server" />
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

        <%-- Modal nuevo Vacación anual --%>
        <div class="modal fade" id="modalNuevaVacacion"  role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-body p-0">
                        <div class="card bg-secondary border-0 mb-0">
                            <div class="card-header">
                                <div class="text-muted text-center mt-2 mb-3"><h4 class="header-modal">REGISTRO VACACIÓN ANUAL</h4></div>
                            </div>

                            <asp:UpdatePanel ID="panelModalVacacionAnual" runat="server">
                                <ContentTemplate>
                                    <div class="card-body px-lg-5 py-lg-5">
                                        <div class="pb-5 text-center">
                                            <a href="javascript:;">
                                                <img src="../Content/img/theme/calendar.png" alt="Circle image" class="img-fluid rounded-circle shadow" style="width: 100px;">
                                            </a>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-6 col-md-6">
                                                <div class="">
                                                    <label class="form-control-label" for="exampleFormControlSelect1">Tipo licencia</label>
                                                    <asp:DropDownList ID="ddl_tipo_licencia" AppendDataBoundItems="true" CssClass="form-control select2" runat="server"></asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-sm-6 col-md-6">
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <div class="form-group">
                                                            <label class="form-control-label">Total Días</label>
                                                            <asp:TextBox ID="txt_dias_autorizados" class="form-control"  disabled  runat="server" />
                                                        </div>
                                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_dias_autorizados" Display="Dynamic" ValidationGroup="btn_guardar_vacacion" runat="server" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-6 col-md-6">
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <div class="form-group">
                                                            <label class="form-control-label">A partir del:</label>
                                                            <div class="input-group input-group-merge">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt_a_partir" AutoComplete="off" class="form-control datepickerDefault" OnTextChanged="txt_a_partir_TextChanged" AutoPostBack="true" runat="server" />
                                                            </div>
                                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_a_partir" Display="Dynamic" ValidationGroup="btn_guardar_vacacion" runat="server" />
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                            <div class="col-sm-6 col-md-6">
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <div class="form-group">
                                                            <label class="form-control-label">Hasta el:</label>
                                                            <div class="input-group input-group-merge">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt_hasta" AutoComplete="off" class="form-control datepickerDefault" OnTextChanged="txt_hasta_TextChanged" AutoPostBack="true" runat="server" />
                                                            </div>
                                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_hasta" Display="Dynamic" ValidationGroup="btn_guardar_vacacion" runat="server" />
                                                        </div>
                                                        <asp:HiddenField ID="aux_suma_dias" runat="server" />
                                                        <asp:HiddenField ID="aux_suma_horas" runat="server" />
                                                        <asp:HiddenField ID="aux_vac_id" runat="server" />
                                                        <asp:HiddenField ID="aux_lj_id" runat="server" />
                                                        <asp:HiddenField ID="aux_nro_dias_restantes" runat="server" />
                                                        <asp:HiddenField ID="aux_gestion" runat="server" />
                                                        <asp:HiddenField ID="aux_cs_id" runat="server" />
                                                        <asp:HiddenField ID="aux_va_id" runat="server" />
                                                        <asp:HiddenField ID="aux_per_id" runat="server" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-6 col-md-12">
                                                <div class="form-group text-center">
                                                    <label class="form-control-label" for="exampleFormControlSelect1">Observaciones</label>
                                                    <div class="input-group">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_observacion" TextMode="multiline" Rows="2" class="form-control" runat="server" />
                                                    </div>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_observacion" Display="Dynamic" ValidationGroup="btn_guardar_vacacion" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-6 col-md-6 mt-3">
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <div class="tag-label mt-2">
                                                            <span>Total días de vacación disponible:<span class="tag-label-content"><asp:Literal ID="txt_total_dias_vacacion" runat="server" /></span></span>
                                                        </div>
                                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_dias_autorizados_lv" Display="Dynamic" ValidationGroup="btn_guardar_licencia" runat="server" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                           <div class="col-sm-6 col-md-6">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="ddlVacacionAnual_Autoriza">Inmediato superior </label>
                                                <asp:DropDownList ID="ddlVacacionAnual_Autoriza"  CssClass="form-control select2"  runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <div class="form-group text-center">
                                <asp:UpdatePanel ID="panelGuardarVacacionAnual" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="btn_guardar_vacacion_LicEspecial" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Guardar" OnClick="btn_guardar_vacacion_LicEspecial_Click" ValidationGroup="btn_guardar_vacacion" runat="server" />
                                        <asp:LinkButton ID="btn_cancelar_vacacion" class="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i>Cancelar" OnClick="btn_cancelar_vacacion_Click" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%-- Eliminar Vacación Anual --%>
        <div class="modal fade" id="eliminarVacacion"  role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
            <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                <div class="modal-content bg-gradient-dark6">
                    <div class="modal-header">
                    </div>
                    <asp:UpdatePanel ID="panelEliminarVacacion" runat="server">
                        <ContentTemplate>
                            <div class="modal-body">
                                <div class="text-center">
                                    <i class="ni ni-scissors ni-3x"></i>
                                    <h4 class="heading text-dark mt-4">¿Está seguro de Eliminar la Vacación?</h4>
                                </div>
                            </div>
                            <div class="card-body px-lg-5 ">
                                <hr class="my-3">
                                <h6 class="heading-small text-muted">Datos de la Vacación</h6>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class="content-text-label">Fecha Solicitud</div>
                                        <div class="h5 font-weight-400 content-text content-text">
                                            <asp:Literal ID="ltl_fecha_solicitud" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="content-text-label">Nro. Dias</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_nro_dias" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class="content-text-label">A partir</div>
                                        <div class="h5 font-weight-400 content-text content-text">
                                            <asp:Literal ID="ltl_a_partir" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="content-text-label">Hasta</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_hasta" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <hr class="my-3">
                                <div class="form-group text-center">
                                    <label class="form-control-label" for="exampleFormControlSelect1">Motivo</label>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                        </div>
                                        <asp:TextBox ID="txt_motivo" TextMode="multiline" Rows="3" class="form-control" runat="server" />
                                    </div>
                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_motivo" Display="Dynamic" ValidationGroup="eliminarVacacion" runat="server" />
                                </div>
                            </div>
                            <%--<div class="card-body px-lg-5" style="padding-top: unset;">
                                <hr class="my-3">
                                <div class="form-group text-center">
                                    <label class="form-control-label" for="exampleFormControlSelect1">Motivo</label>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                        </div>
                                        <asp:TextBox ID="txt_motivo" TextMode="multiline" Rows="3" class="form-control" runat="server" />
                                    </div>
                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_motivo" Display="Dynamic" ValidationGroup="eliminarVacacion" runat="server" />
                                </div>
                            </div>--%>
                            <div class="form-group text-center">
                                <asp:LinkButton ID="btn_eliminar_vacacion" OnClick="btn_eliminar_vacacion_Click" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" ValidationGroup="eliminarVacacion" runat="server" />
                                <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

        <%-- Modal nuevo Licencia con cargo a vacación --%>
        <div class="modal fade" id="modalNuevaLicencia"  role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-body p-0">
                        <div class="card bg-secondary border-0 mb-0">
                            <div class="card-header">
                                <div class="text-muted text-center mt-2 mb-3"><h4 class="header-modal">REGISTRO LICENCIA CON CARGO A VACACIÓN</h4></div>
                            </div>
                            <asp:UpdatePanel ID="panelModalLicenciaVacacion" runat="server">
                                <ContentTemplate>
                                    <div class="card-body px-lg-5 py-lg-5">
                                        <div class="pb-5 text-center">
                                            <a href="javascript:;">
                                                <img src="../Content/img/theme/clock.png" alt="Circle image" class="img-fluid rounded-circle shadow" style="width: 100px;">
                                            </a>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-6 col-md-4">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="exampleFormControlSelect1">A partir</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_a_partir_lv" AutoComplete="off" class="form-control datepickerDefault" OnTextChanged="txt_a_partir_lv_TextChanged" AutoPostBack="true" runat="server" />
                                                    </div>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_a_partir_lv" ValidationGroup="btn_guardar_licencia" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-sm-6 col-md-4">
                                                <div class="form-group input-group-merge">
                                                    <label class="form-control-label" for="exampleFormControlSelect1">Hasta el</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_hasta_el_lv" AutoComplete="off" class="form-control datepickerDefault" OnTextChanged="txt_hasta_el_lv_TextChanged" AutoPostBack="true" runat="server" />
                                                    </div>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_hasta_el_lv" ValidationGroup="btn_guardar_licencia" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-sm-6 col-md-4">
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <div class="form-group">
                                                            <label class="form-control-label">Total Días</label>
                                                            <asp:TextBox ID="txt_dias_autorizados_lv" class="form-control"  Enabled="false" runat="server" />
                                                        </div>
                                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_dias_autorizados_lv" Display="Dynamic" ValidationGroup="btn_guardar_licencia" runat="server" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-6 col-md-3">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="exampleFormControlSelect1">Hora salida</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="far fa-clock"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_hora_salida_lv" class="form-control" type="time" runat="server" />
                                                    </div>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_hora_salida_lv" ValidationGroup="btn_guardar_licencia" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-sm-6 col-md-3">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="exampleFormControlSelect1">Hora retorno</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="far fa-clock"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_hora_retorno_lv" class="form-control" type="time" runat="server" />
                                                    </div>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_hora_retorno_lv" ValidationGroup="btn_guardar_licencia" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-sm-6 col-md-6">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="example4cols1Input">Inmediato superior </label>
                                                    <asp:DropDownList ID="ddl_inmediato_superior" AppendDataBoundItems="true" CssClass="form-control" data-minimum-results-for-search="Infinity" runat="server"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_inmediato_superior" InitialValue="0" Display="Dynamic" ValidationGroup="btn_guardar_licencia" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="form-group text-center">
                                <asp:UpdatePanel ID="panelGuardarLicenciaVacacion" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="btn_guardar_licencia" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Guardar" OnClick="btn_guardar_licencia_Click" ValidationGroup="btn_guardar_licencia" runat="server" />
                                        <asp:LinkButton ID="btn_cancelar_licencia" class="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i>Cancelar" OnClick="btn_cancelar_licencia_Click" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%-- Eliminar Licencia con cargo a Vacación --%>
        <div class="modal fade" id="eliminarLicenciaVacacion"  role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
            <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                <div class="modal-content bg-gradient-dark6">
                    <div class="modal-header">
                    </div>
                    <asp:UpdatePanel ID="panelEliminarLicenciaVacacion" runat="server">
                        <ContentTemplate>
                            <div class="modal-body">
                                <div class="py-3 text-center">
                                    <i class="ni ni-fat-remove ni-3x"></i>
                                    <h4 class="heading text-dark mt-4">¿Esta seguro de eliminar la Licencia con cargo a Vacación?</h4>
                                </div>
                            </div>
                            <div class="card-body px-lg-5 ">
                                <hr class="my-3">
                                <h6 class="heading-small text-muted">Datos de la Licencia con Cargo a Vacación</h6>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class="content-text-label">A Partir</div>
                                        <div class="h5 font-weight-400 content-text content-text">
                                            <asp:Literal ID="ltl_a_partir_lic" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="content-text-label">Hasta el</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_hasta_lic" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class="content-text-label">Hora Inicio</div>
                                        <div class="h5 font-weight-400 content-text content-text">
                                            <asp:Literal ID="ltl_hora_inicio_lic" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="content-text-label">Hora Fin</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_hora_fin_lic" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group text-center">
                                <asp:LinkButton ID="btn_eliminar_licenciaVacacion" OnClick="btn_eliminar_licenciaVacacion_Click" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" runat="server" />
                                <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

        <%-- Modal nuevo Gestión Prescrito --%>
        <div class="modal fade" id="modalHabilitarGestionPrescrito"  role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-body p-0">
                        <div class="card bg-secondary border-0 mb-0">
                            <div class="card-header">
                                <div class="text-muted text-center mt-2 mb-3">HABILITAR GESTIÓN PRESCRITO</div>
                            </div>
                            <asp:UpdatePanel ID="panelModalGestionPrescrito" runat="server">
                                <ContentTemplate>
                                    <div class="card-body px-lg-5 py-lg-5">
                                        <div class="pb-5 text-center">
                                            <a href="javascript:;">
                                                <img src="../Content/img/theme/folder.png" alt="Circle image" class="img-fluid rounded-circle shadow" style="width: 100px;">
                                            </a>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-6 col-md-6">
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <div class="form-group">
                                                            <label class="form-control-label">Gestión</label>
                                                            <asp:TextBox ID="txt_gestion_prescrito" class="form-control" disabled runat="server" />
                                                        </div>
                                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_gestion_prescrito" Display="Dynamic" ValidationGroup="btn_guardar_gestionPre" runat="server" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                            <div class="col-sm-6 col-md-6">
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <div class="form-group">
                                                            <label class="form-control-label" for="example4cols2Input">Número Documento</label>
                                                            <div class="input-group input-group-merge">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt_nro_documento" CssClass="form-control" runat="server" />
                                                            </div>
                                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_nro_documento" Display="Dynamic" ValidationGroup="btn_guardar_gestionPre" runat="server" />
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-6 col-md-6">
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <div class="form-group">
                                                            <label class="form-control-label">Fecha Habilitación</label>
                                                            <div class="input-group input-group-merge">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt_fecha_habilitacion" AutoComplete="off" class="form-control datepickerDefault" runat="server" />
                                                            </div>
                                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_fecha_habilitacion" Display="Dynamic" ValidationGroup="btn_guardar_gestionPre" runat="server" />
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                            <div class="col-sm-6 col-md-6">
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <div class="form-group">
                                                            <label class="form-control-label">Fecha Límite de Validez</label>
                                                            <div class="input-group input-group-merge">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt_fecha_validez" AutoComplete="off" class="form-control datepickerDefault" runat="server" />
                                                            </div>
                                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_fecha_validez" Display="Dynamic" ValidationGroup="btn_guardar_gestionPre" runat="server" />
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-6 col-md-12">
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <div class="form-group">
                                                            <label class="form-control-label" for="example4cols2Input">Autorizado por</label>
                                                            <div class="input-group input-group-merge">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt_autorizado_por" CssClass="form-control" runat="server" />
                                                            </div>
                                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_autorizado_por" Display="Dynamic" ValidationGroup="btn_guardar_gestionPre" runat="server" />
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="form-group text-center">
                                <asp:UpdatePanel ID="panelGuadarGestionPrescrito" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="btn_guardar_gestion_prescrito" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Guardar" OnClick="btn_guardar_gestion_prescrito_Click" ValidationGroup="btn_guardar_gestionPre" runat="server" />
                                        <asp:LinkButton ID="btn_cancelar_gestion_prescrito" class="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i>Cancelar" OnClick="btn_cancelar_gestion_prescrito_Click" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%-- Modal nuevo Registro CAS --%>
        <div class="modal fade" id="modalNuevoRegistroCAS"  role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-body p-0">
                        <div class="card bg-secondary border-0 mb-0">
                            <div class="card-header">
                                <div class="text-muted text-center mt-2 mb-3">REGISTRO CAS</div>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="card-body px-lg-5 py-lg-5">
                                        <div class="pb-5 text-center">
                                            <a href="javascript:;">
                                                <img src="../Content/img/theme/note.png" alt="Circle image" class="img-fluid rounded-circle shadow" style="width: 100px;">
                                            </a>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-6 col-md-4">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="exampleFormControlSelect1">Tipo CAS</label>
                                                    <asp:DropDownList ID="ddl_tipo_cas" AppendDataBoundItems="true" CssClass="form-control" data-minimum-results-for-search="Infinity" runat="server"></asp:DropDownList>
                                                </div>
                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_tipo_cas" InitialValue="0" Display="Dynamic" ValidationGroup="btn_guardar_docCas" runat="server" />
                                            </div>
                                            <div class="col-sm-6 col-md-4">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="example4cols2Input">Número CAS</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_nro_cas" CssClass="form-control" runat="server" />
                                                    </div>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_nro_cas" Display="Dynamic" ValidationGroup="btn_guardar_docCas" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-sm-6 col-md-4">
                                                <div class="form-group">
                                                    <label class="form-control-label">Fecha CAS</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_fecha_cas" AutoComplete="off" class="form-control datepickerDefault" runat="server" />
                                                    </div>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_fecha_cas" Display="Dynamic" ValidationGroup="btn_guardar_docCas" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-6 col-md-4">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="example4cols2Input">Años</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_anio_cas" CssClass="form-control" type="number" runat="server" />
                                                    </div>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_anio_cas" Display="Dynamic" ValidationGroup="btn_guardar_docCas" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-sm-6 col-md-4">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="example4cols2Input">Meses</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_meses_cas" CssClass="form-control" type="number" runat="server" />
                                                    </div>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_meses_cas" Display="Dynamic" ValidationGroup="btn_guardar_docCas" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-sm-6 col-md-4">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="example4cols2Input">Días</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_dias_cas" CssClass="form-control" type="number" runat="server" />
                                                    </div>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_dias_cas" Display="Dynamic" ValidationGroup="btn_guardar_docCas" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="form-group text-center">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="btn_guardar_docCas" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Guardar" OnClick="btn_guardar_docCas_Click" ValidationGroup="btn_guardar_docCas" runat="server" />
                                        <asp:LinkButton ID="btn_cancelar_docCas" class="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i>Cancelar" OnClick="btn_cancelar_docCas_Click" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%-- Eliminar Registro CAS --%>
        <div class="modal fade" id="eliminarDocumentoCAS"  role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
            <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                <div class="modal-content bg-gradient-dark6">
                    <div class="modal-header">
                    </div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="modal-body">
                                <div class="py-3 text-center">
                                    <i class="ni ni-fat-remove ni-3x"></i>
                                    <h4 class="heading text-dark mt-4">¿Esta seguro de eliminar el Registro CAS?</h4>
                                </div>
                            </div>
                            <div class="form-group text-center">
                                <asp:LinkButton ID="btn_eliminar_registroCas" OnClick="btn_eliminar_registroCas_Click" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" runat="server" />
                                <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

        <asp:UpdateProgress ID="up1" AssociatedUpdatePanelID="panelModalVacacionAnual" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up2" AssociatedUpdatePanelID="panelGuardarVacacionAnual" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up3" AssociatedUpdatePanelID="panelEliminarVacacion" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up4" AssociatedUpdatePanelID="panelModalLicenciaVacacion" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up5" AssociatedUpdatePanelID="panelGuardarLicenciaVacacion" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up6" AssociatedUpdatePanelID="panelEliminarLicenciaVacacion" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up7" AssociatedUpdatePanelID="panelModalGestionPrescrito" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up8" AssociatedUpdatePanelID="panelGuadarGestionPrescrito" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up9" AssociatedUpdatePanelID="panelGvVacacionDisponible" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up10" AssociatedUpdatePanelID="panelGvHistoricoAsig" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up11" AssociatedUpdatePanelID="panelGvFiliacion" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up12" AssociatedUpdatePanelID="panelGvVacacionAnual" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up13" AssociatedUpdatePanelID="panelGvLicenciaVacacion" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up14" AssociatedUpdatePanelID="panelGvGestionPrescrito" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
</asp:Content>


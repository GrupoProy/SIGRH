<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="PlanillaValidacion.aspx.cs" Inherits="Precontratacion_PlanillaValidacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Validación de Planilla(s)</h6>
                    </div>
                    <div class="col-lg-6 col-5 text-right">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid mt--6">
        <div class="row">
            <div class="col">
                <div class="card">
                    <div class="card-header d-flex align-items-center border-0">
                        <div class="d-flex align-items-center">
                            <div class="text-dark font-weight-600 text-sm">
                    <h3 class="mb-0" style="display: inline-flex; color: #727b87"><i class="fas fa-list-alt icon-h" style="font-size: 27px; min-width: 2.4rem;"></i> Detalle Planilla</h3>
                            </div>
                        </div>
                        <div class="text-right ml-auto">
                            <asp:UpdatePanel ID="up_btn_enviar_planilla" runat="server">
                                <ContentTemplate>

                                    <asp:LinkButton ID="btn_ajustar" CssClass="btn btn-warning btn-round btn-icon disabled" data-toggle="tooltip" data-original-title="Ajustar Planilla" Text="<span class='btn-inner--icon'><i class='fas fa-wrench'></i></span><span class='btn-inner--text'>Ajustar</span>" Visible="false" OnClick="btn_ajustar_Click" runat="server" />
                                    <asp:LinkButton ID="btn_aprobar" CssClass="btn btn-vimeo btn-round btn-icon disabled" data-toggle="tooltip" data-original-title="Validar Planilla" Text="<span class='btn-inner--icon'><i class='fas fa-check'></i></span><span class='btn-inner--text'>Validar</span>" Visible="false" OnClick="btn_aprobar_Click" runat="server" />

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="card-body" style="padding-bottom: unset; padding-top: unset;">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>

                                <div class="row "  style="padding-left: 2.4rem;">
                                    <div class="col-lg-2">
                                        <div class="content-text-label">Planilla</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_pl_correlativo" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <div class="content-text-label">Unidad ejecutora</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_pl_ue" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="content-text-label">Estado</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_pl_estado" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="content-text-label">Fecha creación</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_pl_fecha" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <hr class="my-1">
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="table-responsive py-4">
                      <asp:UpdatePanel ID="up_gv_planilla" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gv_planilla" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" OnPreRender="gv_planilla_PreRender" OnRowCommand="gv_planilla_RowCommand" DataKeyNames="pre_id, fr_id, fr_cp_id" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="ci_x" HeaderText="CI" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                        <asp:TemplateField HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                            <HeaderTemplate>
                                                AP. Paterno
                                                <asp:DropDownList ID="ddl_gv_planilla_paterno" CssClass="custom-select custom-select-sm form-control form-control-sm" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="ddl_gv_planilla_cargo_SelectedIndexChanged" runat="server" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                               <%-- <%# Eval("ap_paterno_x") %>--%>
                                                 <asp:Label ID="lbl_gv_planilla_ap_paterno_x" CssClass="grid-font-size" Text=' <%# Eval("ap_paterno_x") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ap_materno_x" HeaderText="AP. Materno" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                        <asp:BoundField DataField="nombres_x" HeaderText="Nombre(s)" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                        <asp:BoundField DataField="ap_casada_x" HeaderText="AP. Casada" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                        <asp:TemplateField HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                            <HeaderTemplate>
                                                CARGO
                                                <asp:DropDownList ID="ddl_gv_planilla_cargo" CssClass="custom-select custom-select-sm form-control form-control-sm" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="ddl_gv_planilla_cargo_SelectedIndexChanged" runat="server" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                               <%-- <%# Eval("es_descripcion") %>--%>
                                                       <asp:Label ID="lbl_gv_planilla_cargo" CssClass="grid-font-size " Text=' <%# Eval("es_descripcion") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="haber_basico" HeaderText="Haber Básico (Bs)" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right grid-font-size" DataFormatString="{0:0.00}" />
                                        <asp:BoundField DataField="pu_descripcion" HeaderText="Puesto" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                        <asp:BoundField DataField="pre_presenta_djbr" HeaderText="Presenta DJBR" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                        <asp:BoundField DataField="pre_fecha_inicio" HeaderText="Fecha inicio" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                        <asp:BoundField DataField="pre_fecha_fin" HeaderText="Fecha Fin" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                        <asp:BoundField DataField="pre_tiempo" HeaderText="Tiempo (meses)" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                        <asp:BoundField DataField="fr_tipo_jornada" HeaderText="Tipo jornada" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                        <asp:BoundField DataField="ue" HeaderText="Categoría programática" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                        <asp:BoundField DataField="pre_estado" HeaderText="Estado" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />

                                        <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="40px">
                                            <ItemTemplate>
                                                <asp:LinkButton CommandName="GetEditP" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-outline-github btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-briefcase fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Ver Puesto y Tareas' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div id="no_existe_prec" class="card-body" runat="server">
                                <div class="row">
                                    <div class="col-md-12">
                                        <p class="text-sm grid-notify-success">No existen datos registrados. </p>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div id="existe_anulado" class="card" runat="server">
                    <div class="card-header d-flex align-items-center">
                        <div class="d-flex align-items-center">
                            <div class="text-dark font-weight-600 text-sm">
                                <div class=" ct-page-title">
                                    <h3 class="mb-0">Pre-Contratados Anulados</h3>
                                </div>
                            </div>
                        </div>

                    </div>

                    <div class="table-responsive">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gv_anulados" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" OnPreRender="gv_anulados_PreRender" DataKeyNames="pre_id" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="ci_x" HeaderText="CI" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="ap_paterno_x" HeaderText="AP. Materno" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="ap_materno_x" HeaderText="AP. Materno" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="nombres_x" HeaderText="Nombre(s)" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="ap_casada_x" HeaderText="AP. Casada" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="pre_fecha_inicio" HeaderText="Fecha inicio" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="pre_fecha_fin" HeaderText="Fecha Fin" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="pre_tiempo" HeaderText="Tiempo (meses)" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div id="no_existe_anulados" class="card-body" runat="server">
                                <div class="row">
                                    <div class="col-md-12">
                                        <p class="text-sm grid-notify-success">No existen datos registrados. </p>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
          <div class="modal fade" id="modalPuesto" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-body p-0">
                        <div class="card card-project" style="margin-bottom: unset; min-height: 250px;">
                            <a href="javascript:;">
                                <div class="icon icon-lg icon-shape icon-shape-info shadow rounded-circle mx-auto" style="background-color: #495057; color: #fff;">
                                    <i class="fas fa-briefcase"></i>
                                </div>
                            </a>
                            <asp:UpdatePanel ID="up_cancelar_puesto" runat="server">
                                <ContentTemplate>
                                    <div class="card-body text-justify">
                                        <%-- <h6 class="heading-small text-muted mt-5 ">Datos de la Pre-contratación </h6>--%>
                                        <div class="text-center">
                                            <h5 class="h2 card-title  mt-5 mb-2">Datos de la Pre-contratación</h5>
                                        </div>

                                        <div class="row">
                                            <div class="col-sm-6 col-md-12">
                                                <p class="mt-3 mb-0 text-sm">
                                                    <span class="text-success mr-2"><i class="fa fa-briefcase"></i></span>
                                                    <span class="content-text-label">Puesto</span>
                                                </p>
                                                <div class="h5 font-weight-400 content-text mt-1">
                                                    <asp:Literal ID="ltl_puesto" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-6 col-md-12">
                                                <p class="mt-3 mb-0 text-sm">
                                                    <span class="text-success mr-2"><i class="fa fa-pencil-alt"></i></span>
                                                    <span class="content-text-label">Objetivo</span>
                                                </p>
                                                <div class="h5 font-weight-400 content-text mt-1">
                                                    <asp:Literal ID="ltl_objetivo" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-6 col-md-12">
                                                <p class="mt-3 mb-0 text-sm">
                                                    <span class="text-success mr-2"><i class="fa fa-pencil-alt"></i></span>
                                                    <span class="content-text-label">Tareas</span>
                                                </p>
                                                <div class="h5 font-weight-400 content-text mt-1">
                                                    <asp:Literal ID="lbl_tareas" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="text-right mt-4">
                                            <asp:LinkButton ID="btn_cancelar_puesto" class="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i>Cerrar" OnClick="btn_cancelar_puesto_Click" runat="server" />
                                            <asp:HiddenField ID="hf_fr_id" runat="server" />
                                            <asp:HiddenField ID="hf_pre_id" runat="server" />
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                    </div>
                </div>
            </div>

        </div>
        <div class="modal fade" id="modalAjustarPr" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
            <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                <div class="modal-content bg-gradient-warning2">
                    <div class="modal-header">
                    </div>

                    <asp:UpdatePanel ID="up_confirmar_ajuste" runat="server">
                        <ContentTemplate>
                            <div class="modal-body">
                                <div class="pt-3 text-center">
                                    <i class="ni ni-settings ni-3x"></i>
                                    <h4 class="heading text-dark mt-4" style="margin-bottom: unset">Está solicitando ajustes a la Planilla</h4>
                                    <p>Por favor ingrese sus observaciones</p>
                                    <div class="row">
                                        <div class="col-sm-6 col-md-12">
                                            <div class="form-group">
                                                <div class="input-group input-group-merge">
                                                    <div class="input-group-prepend  ">
                                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                    </div>
                                                    <asp:TextBox ID="txt_observaciones" class="form-control" TextMode="multiline" Rows="5" runat="server" />
                                                </div>
                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_observaciones" Display="Dynamic" ValidationGroup="ajustarPr" runat="server" />

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group text-center">
                                <asp:LinkButton ID="btn_confirmar_ajuste" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-slack" OnClick="btn_confirmar_ajuste_Click" ValidationGroup="ajustarPr" runat="server" />
                                <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div class="modal fade" id="modalEnviar" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog modal-dialog-centered modal-sm" role="document">
                <div class="modal-content">
                    <div class="modal-body p-0">
                        <div class="card card-project" style="margin-bottom: unset; min-height: 250px;">
                            <a href="javascript:;">
                                <div class="icon icon-lg icon-shape icon-shape-info shadow rounded-circle mx-auto" style="background-color: #495057; color: #fff;">
                                    <i class="fas fa-share-alt"></i>
                                </div>
                            </a>
                            <div class="card-body">
                                <p class="text-sm mb-0 mt-5 mb-3">Por favor seleccione al usuario a enviar la planilla. </p>
                                <asp:UpdatePanel ID="up_btn_confirmar_envio" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label class="form-control-label">Gestión</label>
                                                    <asp:DropDownList ID="ddl_usuarios" CssClass="form-control select2" AppendDataBoundItems="true" data-minimum-results-for-search="Infinity" runat="server"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row mt-2">
                                            <div class="col-md-6">
                                                <asp:LinkButton ID="btn_confirmar_envio" CssClass="btn btn-block btn-success btn-round btn-icon" Text="<span class='btn-inner--icon'><i class='fas fa-check'></i></span><span class='btn-inner--text'>Aceptar</span>" OnClick="btn_confirmar_envio_Click" runat="server" />
                                            </div>
                                            <div class="col-md-6">
                                                <asp:LinkButton ID="btn_cancelar_envio" CssClass="btn btn-block btn-outline-github btn-round btn-icon" Text="<span class='btn-inner--icon'><i class='fas fa-times'></i></span><span class='btn-inner--text'>Cancelar</span>" OnClick="btn_cancelar_envio_Click" runat="server" />
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <div class="modal fade" id="modalAjusteFecha" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog modal- modal-dialog-centered modal-xl" role="document">
                <div class="modal-content">
                    <div class="modal-body p-0">
                        <div class="card bg-secondary border-0 mb-0">
                            <div class="card-header">
                                <div class="text-muted text-center mt-2 mb-3"><small>DETALLE PLANILLA</small></div>
                            </div>
                            <div class="card-body py-lg-5">
                                <div id="no_existe_frec_t" class="ct-page-title" runat="server">
                                    <h4 class="h3 text-uppercase" style="margin-bottom: unset;">Ajuste de fechas</h4>
                                    <p class="description" style="margin-bottom: 0.5rem;">Los datos mostrados en la siguiente tabla son los que se procederá al recalculo del tiempo de las solicitudes de contratación, reemplazando la fecha de inicio con la fecha de validación según COMUNICADO <strong>D.G.R.H. Nº 050/2018</strong></p>
                                </div>
                                <div class="table-responsive">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gv_planilla_ajuste" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_planilla_ajuste_PreRender" DataKeyNames="pre_id" runat="server">
                                                <Columns>
                                                    <asp:BoundField DataField="ci_x" HeaderText="CI" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                                    <asp:BoundField DataField="ap_paterno_x" HeaderText="AP. Paterno" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                                    <asp:BoundField DataField="ap_materno_x" HeaderText="AP. Materno" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                                    <asp:BoundField DataField="nombres_x" HeaderText="Nombre(s)" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                                    <asp:BoundField DataField="ap_casada_x" HeaderText="AP. Casada" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                                    <asp:BoundField DataField="es_descripcion" HeaderText="Cargo" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                                    <asp:BoundField DataField="pre_fecha_inicio" HeaderText="Fecha inicio" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                                    <asp:BoundField DataField="pre_fecha_fin" HeaderText="Fecha Fin" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                                    <asp:BoundField DataField="pre_tiempo" HeaderText="Tiempo (meses)" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                                    <asp:BoundField DataField="fr_tipo_jornada" HeaderText="Tipo jornada" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                                    <asp:BoundField DataField="pre_fecha_inicio_a" HeaderText="FECHA INICIO AJUSTADO" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-bold text-danger" />
                                                    <asp:BoundField DataField="pre_tiempo_a" HeaderText="Tiempo (meses) AJUSTADO" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-bold text-danger" />
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="form-group text-center">
                                <asp:UpdatePanel ID="up_gv_item_hist" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="btn_aceptar_ajuste" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btn_aceptar_ajuste_Click" runat="server" />
                                        <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="modalConfirmacionV" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                <div class="modal-content bg-gradient-success">
                    <div class="modal-header">
                    </div>

                    <asp:UpdatePanel ID="up_confirmar_val" runat="server">
                        <ContentTemplate>
                            <div class="modal-body">
                                <div class="py-3 text-center">
                                    <i class="ni ni-check-bold ni-3x"></i>
                                    <h4 class="heading text-dark mt-4">¿Está seguro de validar la Planilla?</h4>
                                </div>
                            </div>
                            <div class="form-group text-center">
                                <asp:LinkButton ID="btn_confirmar_val" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-vimeo" OnClick="btn_confirmar_val_Click" runat="server" />
                                <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <asp:UpdateProgress ID="up" AssociatedUpdatePanelID="up_btn_enviar_planilla" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up1" AssociatedUpdatePanelID="up_gv_planilla" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up2" AssociatedUpdatePanelID="up_btn_confirmar_envio" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up3" AssociatedUpdatePanelID="up_confirmar_ajuste" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up4" AssociatedUpdatePanelID="up_confirmar_val" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
</asp:Content>


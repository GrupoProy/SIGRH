<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ValidacionDoc.aspx.cs" Inherits="Precontratacion_ValidacionDoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Validación Documentaria</h6>
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

                                <h3 class="mb-0" style="display: inline-flex; color: #727b87"><i class="fas fa-list-alt icon-h" style="font-size: 27px; min-width: 2.4rem;"></i>Detalle Planilla</h3>
                            </div>
                        </div>
                        <div class="text-right ml-auto">
                            <asp:UpdatePanel ID="up_devolver_planilla" runat="server">
                                <ContentTemplate>
                                    <asp:LinkButton ID="btn_devolver" CssClass="btn btn-warning btn-round btn-icon disabled" Text="<span class='btn-inner--icon'><i class='fas fa-reply'></i></span><span class='btn-inner--text'>DEVOLVER PLANILLA</span>" Visible="false" OnClick="btn_devolver_Click" runat="server" />
                                    <asp:LinkButton ID="btn_validar_planilla" CssClass="btn btn-vimeo btn-round btn-icon disabled" Text="<span class='btn-inner--icon'><i class='fas fa-check'></i></span><span class='btn-inner--text'>VALIDAR PLANILLA</span>" Visible="false" OnClick="btn_validar_planilla_Click" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                    </div>
                    <div class="card-body" style="padding-bottom: unset; padding-top: unset;">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>

                                <div class="row" style="padding-left: 2.4rem;">
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
                                <asp:GridView ID="gv_planilla" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" OnPreRender="gv_planilla_PreRender" OnRowCommand="gv_planilla_RowCommand" DataKeyNames="pre_id, fr_id, fr_cp_id, pre_estado_x" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="ci_x" HeaderText="CI" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                        <asp:TemplateField HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                            <HeaderTemplate>
                                                AP. Paterno
                                                <asp:DropDownList ID="ddl_gv_planilla_paterno" CssClass="custom-select custom-select-sm form-control form-control-sm" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="ddl_gv_planilla_cargo_SelectedIndexChanged" runat="server" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%--  <%# Eval("ap_paterno_x") %>--%>
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
                                                <%--     <%# Eval("es_descripcion") %>--%>
                                                <asp:Label ID="lbl_gv_planilla_cargo" CssClass="grid-font-size " Text=' <%# Eval("es_descripcion") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="haber_basico" HeaderText="Haber Básico (Bs)" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right grid-font-size" DataFormatString="{0:0.00}" />
                                        <asp:BoundField DataField="pu_descripcion" HeaderText="Puesto" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                        <asp:BoundField DataField="pre_presenta_djbr" HeaderText="Presenta DJBR" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size grid-bold" />
                                        <asp:BoundField DataField="afp_x" HeaderText="afp" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size grid-bold" />
                                        <asp:BoundField DataField="pre_fecha_inicio" HeaderText="Fecha inicio" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                        <asp:BoundField DataField="pre_fecha_fin" HeaderText="Fecha Fin" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                        <asp:BoundField DataField="pre_tiempo" HeaderText="Tiempo (meses)" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                        <asp:BoundField DataField="fr_tipo_jornada" HeaderText="Tipo jornada" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                        <asp:BoundField DataField="ue" HeaderText="Categoría programática" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                        <asp:BoundField DataField="pre_estado" HeaderText="Estado" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />

                                        <asp:TemplateField HeaderText="<i class='ni ni-settings-gear-65 ni-2x'></i>" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="40px">
                                            <ItemTemplate>
                                                <div class="dropdown">
                                                    <a class="btn btn-outline-github btn-sm btn-icon-only " href="#" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                        <i class="fas fa-ellipsis-v"></i>
                                                    </a>
                                                    <div class="dropdown-menu dropdown-menu-right dropdown-menu-arrow" style="">
                                                        <asp:LinkButton CommandName="GetAssign" CommandArgument="<%# Container.DataItemIndex %>" CssClass="dropdown-item" Text="<i class='fas fa-tasks'></i><span>Validar Documentos</span>" Visible='<%# Eval("pre_estado_x").ToString().Trim() != "O" ? true : false %>' runat="server" />
                                                        <asp:LinkButton CommandName="GetEditPersona" CommandArgument="<%# Container.DataItemIndex %>" CssClass="dropdown-item" Text="<i class='fas fa-address-card'></i><span>Modificar Datos Personales</span>" runat="server" />
                                                        <asp:LinkButton CommandName="GetEditP" CommandArgument="<%# Container.DataItemIndex %>" CssClass="dropdown-item" Text="<i class='fas fa-briefcase'></i><span>Ver Detalle Puesto</span>" runat="server" />

                                                        <hr class="my-2">
                                                        <asp:LinkButton CommandName="GetAnularObs" CommandArgument="<%# Container.DataItemIndex %>" CssClass="dropdown-item" Text="<i class='fas fa-eye-slash'></i><span>Anular Observación</span>" Visible='<%# Eval("pre_estado_x").ToString().Trim() != "O" ? false : true %>' runat="server" />
                                                        <asp:LinkButton CommandName="GetObservar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="dropdown-item" Text="<i class='fas fa-eye'></i><span>Observar Pre-Contratado</span>" Visible='<%# (Eval("pre_estado_x").ToString().Trim() == "V" || Eval("pre_estado_x").ToString().Trim() == "VR") ? true : false %>' runat="server" />
                                                    </div>
                                                </div>

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

            </div>
        </div>

        <div class="modal fade" id="modalModificarPuesto" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-body p-0">
                        <div class="card card-project" style="margin-bottom: unset; min-height: 250px;">
                            <a href="javascript:;">
                                <div class="icon icon-lg icon-shape icon-shape-info shadow rounded-circle mx-auto" style="background-color: #495057; color: #fff;">
                                    <i class="fas fa-briefcase"></i>
                                </div>
                            </a>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
                                            <asp:HiddenField ID="hf_cp_id" runat="server" />
                                            <asp:HiddenField ID="hf_pre_id" runat="server" />
                                            <asp:HiddenField ID="hf_pre_estado" runat="server" />
                                            <asp:HiddenField ID="hf_masivo" runat="server" />
                                            <asp:HiddenField ID="hf_pre_per_id" runat="server" />
                                            <asp:HiddenField ID="hf_pre_fr_id" runat="server" />
                                            <asp:HiddenField ID="hf_pre_editar" runat="server" />
                                            <asp:HiddenField ID="hf_tmp_id" runat="server" />
                                            <asp:HiddenField ID="hf_rq_id" runat="server" />
                                            <asp:HiddenField ID="hf_nro_requisitos" runat="server" />
                                            <asp:HiddenField ID="hf_val_rrhh" runat="server" />
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                    </div>
                </div>
            </div>

        </div>
        <div class="modal fade" id="modalVerificarDoc" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-body p-0">
                        <div class="card card-project" style="margin-bottom: unset; min-height: 250px;">
                            <a href="javascript:;">
                                <div class="icon icon-lg icon-shape icon-shape-info shadow rounded-circle mx-auto" style="background-color: #495057; color: #fff;">
                                    <i class="fas fa-tasks"></i>
                                </div>
                            </a>
                            <asp:UpdatePanel ID="up_guardar_requisitos" runat="server">
                                <ContentTemplate>
                                    <div class="card-body ">
                                        <h6 class="heading-small text-muted mt-5 " style="color: #727b87 !important">Datos de la Pre-contratación </h6>
                                        <div class="row row-content">
                                            <div class="col-lg-3">
                                                <div class="row align-items-center">
                                                    <div class="col-auto">
                                                        <div class="content-icon2">
                                                            <i class="fas fa-id-card"></i>
                                                        </div>
                                                    </div>
                                                    <div class="col ml--2">
                                                        <div class="h5 font-weight-400 content-text content-text2">
                                                            <asp:Literal ID="ltl_ci_val" runat="server" />
                                                        </div>
                                                        <span class="content-text-label2 mb-0">Cedula de Identidad</span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="row align-items-center">
                                                    <div class="col-auto">
                                                        <div class="content-icon2">
                                                            <i class="ni ni-circle-08"></i>
                                                        </div>
                                                    </div>
                                                    <div class="col ml--2">
                                                        <div class="h5 font-weight-400 content-text content-text2">
                                                            <asp:Literal ID="ltl_nombres_val" runat="server" />
                                                        </div>
                                                        <span class="content-text-label2 mb-0">Apellidos y Nombres</span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="row align-items-center">
                                                    <div class="col-auto">
                                                        <div class="content-icon2">
                                                            <i class="ni ni-circle-08"></i>
                                                        </div>
                                                    </div>
                                                    <div class="col ml--2">
                                                        <div class="h5 font-weight-400 content-text content-text2">
                                                            <asp:Literal ID="ltl_genero_val" runat="server" />
                                                        </div>
                                                        <span class="content-text-label2 mb-0">Sexo/Género</span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row row-content">
                                            <div class="col-lg-3">
                                                <div class="row align-items-center">
                                                    <div class="col-auto">
                                                        <div class="content-icon2">
                                                            <i class="fas fa-file-alt"></i>
                                                        </div>
                                                    </div>
                                                    <div class="col ml--2">
                                                        <div class="h5 font-weight-400 content-text content-text2">
                                                            <asp:Literal ID="ltl_djbr_val" runat="server" />
                                                        </div>
                                                        <span class="content-text-label2 mb-0">Presenta DJBR</span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="row align-items-center">
                                                    <div class="col-auto">
                                                        <div class="content-icon2">
                                                            <i class="ni ni-briefcase-24"></i>
                                                        </div>
                                                    </div>
                                                    <div class="col ml--2">
                                                        <div class="h5 font-weight-400 content-text content-text2">
                                                            <asp:Literal ID="ltl_cargo_val" runat="server" />
                                                        </div>
                                                        <span class="content-text-label2 mb-0">Cargo</span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="row align-items-center">
                                                    <div class="col-auto">
                                                        <div class="content-icon2">
                                                            <i class="fas fa-user-check"></i>
                                                        </div>
                                                    </div>
                                                    <div class="col ml--2">
                                                        <div class="h5 font-weight-400 content-text content-text2">
                                                            <asp:Literal ID="ltl_estado_fun" runat="server" />
                                                        </div>
                                                        <span class="content-text-label2 mb-0">Estado funcionario</span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <hr style="margin-top: unset; margin-bottom: 1rem;" />
                                        <p class="text-sm mb-0 mb-3 pb-2 text-justify" style="font-size: 0.875rem;">En el siguiente <strong>Checklist</strong>, registre todos los documentos presentados por el interesado.</p>
                                        <asp:Panel ID="pnlDinamico" runat="server">
                                        </asp:Panel>

                                        <div class="row pt-3">
                                            <div class="col-lg-6">
                                                <asp:LinkButton ID="btn_guardar_requisitos" Text="<i class='fas fa-save mr-2'></i>Guardar" CssClass="btn btn-success btn-block" OnClick="btn_guardar_requisitos_Click" runat="server" />
                                            </div>
                                            <div class="col-lg-6">
                                                <asp:LinkButton ID="btn_cerrar" Text="<i class='fas fa-times mr-2'></i>Cancelar" CssClass="btn btn-outline-github btn-block" OnClick="btn_cerrar_Click" runat="server" />

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
        <div class="modal fade" id="modalPersona" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
                <div class="modal-content" style="margin-top: 40px">
                    <div class="modal-body p-0">
                        <div class="card card-profile" style="margin-bottom: unset;">
                            <div class="row justify-content-center">
                                <div class="col-lg-3 order-lg-2">
                                    <div class="card-profile-image">
                                        <a href="#">
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <asp:Image ID="imgFun_int" class="rounded-circle" runat="server" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="card-header text-center border-0 pt-8 pt-md-4 pb-0">
                                <div class="d-flex justify-content-between">
                                    <div style="visibility: hidden">
                                        <a href="#" class="btn btn-sm btn-info mr-4 ">Connect</a>
                                    </div>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="btn_limpiar" Text="Limpiar" CssClass="btn btn-sm btn-default float-right" Visible="false" runat="server" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="card-body pt-0">
                                <asp:UpdatePanel ID="up_datos_personales" runat="server">
                                    <ContentTemplate>
                                        <div class="text-center pt-3">
                                        </div>

                                        <h6 class="heading-small text-muted mb-2">Datos personales</h6>
                                        <div class="row">
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label class="form-control-label">carnet de identidad</label>
                                                    <asp:TextBox ID="txt_ci" CssClass="form-control form-control-sm" runat="server" />
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_ci" ValidationGroup="addFuncionario" runat="server" />

                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label class="form-control-label">Ap. Paterno</label>
                                                    <asp:TextBox ID="txt_pre_paterno" CssClass="form-control form-control-sm" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label class="form-control-label">Ap. Materno</label>
                                                    <asp:TextBox ID="txt_pre_materno" CssClass="form-control form-control-sm" runat="server" />
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_pre_materno" ValidationGroup="addFuncionario" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label class="form-control-label">Nombre(s)</label>
                                                    <asp:TextBox ID="txt_pre_nombres" CssClass="form-control form-control-sm" runat="server" />
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_pre_nombres" ValidationGroup="addFuncionario" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label class="form-control-label">Ap. Casada</label>
                                                    <asp:TextBox ID="txt_pre_ap_casada" CssClass="form-control form-control-sm" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label class="form-control-label">Sexo / Género</label>
                                                    <asp:DropDownList ID="ddl_pre_genero" CssClass="form-control form-control-sm select2" AppendDataBoundItems="true" data-minimum-results-for-search="Infinity" Enabled="false" runat="server" />
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_pre_genero" Display="Dynamic" ValidationGroup="addFuncionario" InitialValue="0" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label class="form-control-label">AFP</label>
                                                    <asp:DropDownList ID="ddl_afp" CssClass="form-control form-control-sm select2 " AppendDataBoundItems="true" data-minimum-results-for-search="Infinity" runat="server" />
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_afp" Display="Dynamic" ValidationGroup="addFuncionario" InitialValue="0" runat="server" />
                                                </div>
                                            </div>


                                        </div>

                                        <div class="row mt-3">
                                            <div class="col-lg-6">
                                                <asp:LinkButton ID="btn_adicionar_funcionario" Text="<i class='fas fa-save mr-2'></i>Guardar" ValidationGroup="addFuncionario" CssClass="btn btn-success btn-block" OnClick="btn_adicionar_funcionario_Click" runat="server" />
                                            </div>
                                            <div class="col-lg-6">
                                                <asp:LinkButton ID="btn_cancelar_persona" class="btn btn-outline-github btn-block" Text="<i class='fas fa-times mr-2'></i>Cancelar" OnClick="btn_cancelar_persona_Click" runat="server" />
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

        <div class="modal fade" id="modalDevolver" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
            <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                <div class="modal-content bg-gradient-warning2">
                    <div class="modal-header">
                    </div>

                    <asp:UpdatePanel ID="up_confirmar_ajuste" runat="server">
                        <ContentTemplate>
                            <div class="modal-body">
                                <div class="pt-3 text-center">
                                    <i class="ni ni-settings ni-3x"></i>
                                    <h4 class="heading text-dark mt-4" style="margin-bottom: unset">Usted está observando la planilla</h4>
                                    <p>Por favor ingrese sus observaciones</p>
                                    <div class="row">
                                        <div class="col-sm-6 col-md-12">
                                            <div class="form-group">
                                                <div class="input-group input-group-merge">
                                                    <div class="input-group-prepend  ">
                                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                    </div>
                                                    <asp:TextBox ID="txt_observaciones" class="form-control" TextMode="multiline" Rows="7" runat="server" />
                                                </div>
                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_observaciones" Display="Dynamic" ValidationGroup="ajustarPr" runat="server" />

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group text-center">
                                <asp:LinkButton ID="btn_confirmar_ajuste" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-slack" ValidationGroup="ajustarPr" OnClick="btn_confirmar_ajuste_Click" runat="server" />
                                <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
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
                                <asp:LinkButton ID="btn_cancelar_val" Text="<i class='fas fa-times mr-2'></i>Cancelar" CssClass="btn btn-outline-github" OnClick="btn_cancelar_val_Click" runat="server" />
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div class="modal fade" id="modalGlosa" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                <div class="modal-content">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="modal-body p-0">
                                <div class="card bg-secondary border-0 mb-0">
                                    <div class="card-header">
                                        <div class="text-muted text-center mt-2 mb-3">
                                            <h4 class="header-modal">GLOSA</h4>
                                        </div>
                                    </div>
                                    <div class="card-body px-lg-5 py-lg-5">
                                        <div class="row">
                                            <div id="d_tipo_doc" class="col-md-6" runat="server">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="exampleFormControlSelect1">Tipo Documento</label>
                                                    <asp:DropDownList ID="ddl_tipo_documento" AppendDataBoundItems="true" CssClass="form-control select2" OnSelectedIndexChanged="ddl_tipo_documento_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_tipo_documento" Display="Dynamic" ValidationGroup="addGlosa" InitialValue="0" runat="server" />
                                                </div>
                                            </div>
                                            <div id="d_num_doc" class="col-md-4" visible="false" runat="server">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="exampleFormControlSelect1">Número de documento</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_num_doc" class="form-control numero" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="d_fecha_doc" class="col-md-6" runat="server">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="exampleFormControlSelect1">Fecha Documento</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_fechaMov" AutoComplete="off" class="form-control datepickerDefault" runat="server" />
                                                    </div>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_fechaMov" Display="Dynamic" ValidationGroup="addGlosa" runat="server" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="example3cols1Input">Descripción </label>

                                                    <asp:TextBox ID="txt_descripcion_add" CssClass="form-control" placeholder="Descripción" TextMode="multiline" Rows="4" runat="server" />
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_descripcion_add" Display="Dynamic" ValidationGroup="addGlosa" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row pt-3">
                                            <div class="col-md-6">
                                                <asp:LinkButton ID="btn_adicionar_glosa" Text="<i class='fas fa-check mr-2'></i>Guardar" OnClick="btn_adicionar_glosa_Click" OnClientClick="if (Page_ClientValidate('addGlosa')) { MostrarMascara(true); }" ValidationGroup="addGlosa" CssClass="btn btn-success btn-block" runat="server" />
                                            </div>
                                            <div class="col-md-6">
                                                <asp:LinkButton ID="btn_cancelar_glosa" class="btn btn-outline-github btn-block" Text="<i class='fas fa-times mr-2'></i>Cancelar" OnClick="btn_cancelar_glosa_Click" runat="server" />
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
        <asp:UpdateProgress ID="up" AssociatedUpdatePanelID="up_gv_planilla" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up1" AssociatedUpdatePanelID="up_devolver_planilla" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up3" AssociatedUpdatePanelID="up_guardar_requisitos" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up4" AssociatedUpdatePanelID="up_confirmar_ajuste" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up5" AssociatedUpdatePanelID="up_datos_personales" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>

    </div>
</asp:Content>


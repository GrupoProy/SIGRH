<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="PlanillaContrato.aspx.cs" Inherits="MovimientoPersonal_PlanillaContrato" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Planilla para Contratación de Personal </h6>
                    </div>
                                        <div class="col-lg-6 col-5 text-right">
                        <asp:UpdatePanel ID="up_btn_adic_nueva_frec" runat="server">
                            <ContentTemplate>
                                <asp:LinkButton ID="btn_contratos_ejec" CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-inst text-white rounded-circle shadow" Text="<i class='fas fa-users'></i>" data-toggle="tooltip" data-original-title="Ver Contratos Ejecutados" OnClick="btn_contratos_ejec_Click"  runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid mt--6">
        <div class="row">
            <div class="col-xl-8">
            </div>
            <div class="col-xl-4">
                <div class="card">
                    <div class="card-header">
                        <h3 class="mb-0">Resumen Planilla</h3>
                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel ID="up_resumen_planilla" runat="server">
                            <ContentTemplate>
                                <div class="row pb-4">
                                    <div class="col-lg-6 text-center">

                                        <div class="display-2 " style="color: #4385b1">
                                            <asp:Literal ID="ltl_cantidad_pre_cont" runat="server" />
                                        </div>
                                        <span class="pt-4 " style="color: #909090">
                                            <asp:Literal ID="ltl_desc_pre_cont" runat="server" />
                                        </span>

                                    </div>
                                    <div class="col-lg-6 text-center">

                                        <div class="display-2 " style="color: #4385b1">
                                            <asp:Literal ID="ltl_cantidad_cont" runat="server" />
                                        </div>
                                        <span class="pt-4 " style="color: #909090">
                                            <asp:Literal ID="ltl_desc_cont" runat="server" />
                                        </span>

                                    </div>
                                </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>

        </div>
        <div class="row">
            <div class="col">
                <div class="card">
                    <div class="card-header d-flex align-items-center">
                        <div class="d-flex align-items-center">
                            <div class="text-dark font-weight-600 text-sm">
                                <div class=" ct-page-title">
                                    <h3 class="mb-0">Detalle Planilla</h3>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="card-body" style="padding-bottom: unset">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>

                                <div class="row">
                                    <div class="col-lg-3">
                                        <div class="content-text-label">Planilla</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_pl_correlativo" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
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
                                <hr class="my-1 pb-3">
                                <div class="row">
                                    <div class="col-md-6">
                                    </div>
                                    <div class="col-md-6">
                                        <asp:LinkButton ID="btn_contratar" CssClass="btn btn-vimeo btn-round btn-icon pull-right" Text="<span class='btn-inner--icon'><i class='fas fa-briefcase'></i></span><span class='btn-inner--text'>Contratar</span>" OnClick="btn_contratar_Click" runat="server" />
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="table-responsive py-4">
                        <asp:UpdatePanel ID="up_gv_planilla" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gv_planilla" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" OnPreRender="gv_planilla_PreRender" OnRowCommand="gv_planilla_RowCommand" DataKeyNames="pre_id, fr_id, fr_cp_id, fr_es_id, estado_fun, per_id" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="ci_x" HeaderText="CI" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size grid-bold" />
                                        <asp:TemplateField HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                            <HeaderTemplate>
                                                AP. Paterno
                                                <asp:DropDownList ID="ddl_gv_planilla_paterno" CssClass="custom-select custom-select-sm form-control form-control-sm" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="ddl_gv_planilla_cargo_SelectedIndexChanged" runat="server" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
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
                                                <asp:Label ID="lbl_gv_planilla_cargo" CssClass="grid-font-size grid-bold" Text=' <%# Eval("es_descripcion") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="haber_basico" HeaderText="Haber Básico (Bs)" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right grid-font-size" DataFormatString="{0:0.00}" />
                                        <%--                                       <asp:BoundField DataField="pu_descripcion" HeaderText="Puesto" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                        <asp:BoundField DataField="pre_presenta_djbr" HeaderText="Presenta DJBR" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size grid-bold" />--%>
                                        <asp:BoundField DataField="afp_x" HeaderText="afp" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size grid-bold" />
                                        <asp:BoundField DataField="pre_fecha_inicio" HeaderText="Fecha inicio" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                        <asp:BoundField DataField="pre_fecha_fin" HeaderText="Fecha Fin" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                        <%--<asp:BoundField DataField="pre_tiempo" HeaderText="Tiempo (meses)" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />--%>
                                        <asp:BoundField DataField="fr_tipo_jornada" HeaderText="Tipo jornada" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                        <asp:BoundField DataField="ue" HeaderText="Categoría programática" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-font-size" />
                                        <asp:TemplateField HeaderText="" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="40px">
                                            <ItemTemplate>
                                                <asp:LinkButton CommandName="GetAssign" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-success btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-user-plus fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Registrar funcionario' Visible='<%# Eval("estado_fun").ToString().Trim() != "NUEVO" ? false : true %>' runat="server" />
                                                <asp:LinkButton CommandName="GetAssignFam" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-info btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-users fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Registrar familiares' Visible='<%# (Convert.ToInt32(Eval("cantidad_fam").ToString().Trim()) != 0) ? false : (Eval("per_id").ToString().Trim() != "0") ? true : false %>' runat="server" />
                                                <asp:LinkButton CommandName="GetDetail" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-outline-github btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-info fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Ver Detalle' Visible='<%# (Eval("estado_fun").ToString().Trim() == "NUEVO") ? false : (Eval("cantidad_fam").ToString().Trim() != "0" &&  Eval("incompatibilidad").ToString().Trim() == "0" && Eval("bloqueo").ToString().Trim() == "0") ? false : true %>' runat="server" />

                                                <div id="val_asig_correcto" class="badge badge-circle badge-success2" visible='<%# (Eval("cantidad_fam").ToString().Trim() != "0" &&  Eval("incompatibilidad").ToString().Trim() == "0" && Eval("bloqueo").ToString().Trim() == "0") ? true : false %>' runat="server">
                                                    <i class="ni ni-check-bold text-white"></i>
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
                            <asp:HiddenField ID="hf_pre_id" runat="server" />
                            <asp:HiddenField ID="hf_per_id" runat="server" />
                            <asp:HiddenField ID="hf_fr_id" runat="server" />
                            <asp:HiddenField ID="hf_fr_cp_id" runat="server" />
                            <asp:HiddenField ID="hf_fr_es_id" runat="server" />
                            <asp:HiddenField ID="hf_cp_id" runat="server" />
                            <asp:HiddenField ID="hf_eo_id" runat="server" />
                            <asp:HiddenField ID="hf_es_id" runat="server" />
                            <asp:HiddenField ID="hf_fr_tipo_jornada" runat="server" />
                            <asp:HiddenField ID="hf_cantidad_requerida" runat="server" />
                            <asp:HiddenField ID="hf_haber_basico" runat="server" />
                            <asp:HiddenField ID="hf_ca_id" runat="server" />
                            <asp:HiddenField ID="hf_tipo_abm" runat="server" />
                            <asp:HiddenField ID="hf_pf_id_p" runat="server" />
                            <asp:HiddenField ID="hf_pf_id_m" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
           
            </div>
        </div>

<%--        <div class="modal fade" id="modalGlosa" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                <div class="modal-content">
                    <asp:UpdatePanel ID="up_adicionar_cargo" runat="server">
                        <ContentTemplate>
                            <div class="modal-body p-0">
                                <div class="card bg-secondary border-0 mb-0">
                                    <div class="card-header">
                                        <div class="text-muted text-center mt-2 mb-3"><h4 class="header-modal">GLOSA</h4></div>
                                    </div>
                                    <div class="card-body px-lg-5 py-lg-5">
                                        <div class="row">
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="exampleFormControlSelect1">Tipo Documento</label>
                                                    <asp:DropDownList ID="ddl_tipo_documento" AppendDataBoundItems="true" CssClass="form-control select2" runat="server"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_tipo_documento" Display="Dynamic" ValidationGroup="addGlosa" InitialValue="0" runat="server" />
                                                </div>
                                            </div>
                                                                            <div class="col-md-4">
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
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="exampleFormControlSelect1">Fecha Documento</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_fechaMov" class="form-control datepickerDefault" runat="server" />
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
                                    </div>

                                    <div class="form-group text-center">
                                        <asp:LinkButton ID="btn_adicionar_cargo" Text="<i class='fas fa-check mr-2'></i>Guardar" OnClick="btn_adicionar_cargo_Click" OnClientClick="if (Page_ClientValidate('addGlosa')) { MostrarMascara(true); }" ValidationGroup="addGlosa" CssClass="btn btn-success" runat="server" />
                                        <asp:LinkButton ID="btn_cancelar_glosa" class="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i>Cancelar" OnClick="btn_cancelar_glosa_Click" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>--%>

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

        <div class="modal fade" id="modalPersona" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none; overflow-y: auto" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog modal-dialog-centered modal-xl" role="document">
                <div class="modal-content">
                    <div class="modal-body p-0">
                        <div class="card card-project" style="margin-bottom: unset; min-height: 250px;">
                            <a href="javascript:;">
                                <div class="icon icon-lg icon-shape icon-shape-info shadow rounded-circle mx-auto" style="background-color: #495057; color: #fff;">
                                    <i class="fas fa-user"></i>
                                </div>
                            </a>
                            <div class="card-body">
                                <p class="text-sm mb-0 mt-5 mb-3">Para realizar la asignación, por favor llene el siguiente formulario. </p>
                                <asp:UpdatePanel ID="up_guardar_fun_nuevo" runat="server">
                                    <ContentTemplate>

                                        <h6 class="heading-small text-muted mb-2">Datos personales</h6>
                                        <div class="row">
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label class="form-control-label">Tipo de documento</label>
                                                    <asp:DropDownList ID="ddl_tipo_doc" CssClass="form-control form-control-sm select2" AppendDataBoundItems="true" data-minimum-results-for-search="Infinity" runat="server" />
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_tipo_doc" Display="Dynamic" ValidationGroup="addFunNuevo" InitialValue="0" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label class="form-control-label">Número de documento</label>
                                                    <asp:TextBox ID="txt_ci" CssClass="form-control form-control-sm" runat="server" />
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_ci" ValidationGroup="addFunNuevo" runat="server" />

                                                </div>
                                            </div>

                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label class="form-control-label">Lugar expedido </label>
                                                    <asp:DropDownList ID="ddl_lugar_exp" CssClass="form-control form-control-sm select2" AppendDataBoundItems="true" data-minimum-results-for-search="Infinity" runat="server" />
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_estado_civil" Display="Dynamic" ValidationGroup="addFunNuevo" InitialValue="0" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label class="form-control-label">Fecha de nacimiento</label>
                                                    <asp:TextBox ID="txt_fecha_nac" CssClass="form-control form-control-sm datepickerDefault" runat="server" />
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_fecha_nac" ValidationGroup="addFunNuevo" runat="server" />

                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label class="form-control-label">Ap. Paterno</label>
                                                    <asp:TextBox ID="txt_pre_paterno" CssClass="form-control form-control-sm letras" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label class="form-control-label">Ap. Materno</label>
                                                    <asp:TextBox ID="txt_pre_materno" CssClass="form-control form-control-sm" runat="server" />
                                                   <%-- <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_pre_materno" ValidationGroup="addFunNuevo" runat="server" />--%>
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label class="form-control-label">Nombre(s)</label>
                                                    <asp:TextBox ID="txt_pre_nombres" CssClass="form-control form-control-sm" runat="server" />
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_pre_nombres" ValidationGroup="addFunNuevo" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label class="form-control-label">Ap. Casada</label>
                                                    <asp:TextBox ID="txt_pre_ap_casada" CssClass="form-control form-control-sm" runat="server" />
                                                </div>
                                            </div>

                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label class="form-control-label">Sexo / Género</label>
                                                    <asp:DropDownList ID="ddl_genero" CssClass="form-control form-control-sm select2" AppendDataBoundItems="true" data-minimum-results-for-search="Infinity" runat="server" />
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_genero" Display="Dynamic" ValidationGroup="addFunNuevo" InitialValue="0" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label class="form-control-label">Estado Civil</label>
                                                    <asp:DropDownList ID="ddl_estado_civil" CssClass="form-control form-control-sm select2" AppendDataBoundItems="true" data-minimum-results-for-search="Infinity" runat="server" />
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_estado_civil" Display="Dynamic" ValidationGroup="addFunNuevo" InitialValue="0" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label class="form-control-label">Nacionalidad</label>
                                                    <asp:DropDownList ID="ddl_nacionalidad" CssClass="form-control form-control-sm select2 " AppendDataBoundItems="true" OnSelectedIndexChanged="ddl_nacionalidad_SelectedIndexChanged" AutoPostBack="true" runat="server" />
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_nacionalidad" Display="Dynamic" ValidationGroup="addFunNuevo" InitialValue="0" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label class="form-control-label">Lugar de nacimiento</label>
                                                    <asp:DropDownList ID="ddl_lugar_nac" CssClass="form-control form-control-sm select2 " AppendDataBoundItems="true" runat="server" />
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_lugar_nac" Display="Dynamic" ValidationGroup="addFunNuevo" InitialValue="0" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label class="form-control-label">Ciudad de residencia</label>
                                                    <asp:DropDownList ID="ddl_ciudad_residencia" CssClass="form-control form-control-sm select2 " AppendDataBoundItems="true" runat="server" />
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_ciudad_residencia" Display="Dynamic" ValidationGroup="addFunNuevo" InitialValue="0" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label class="form-control-label">Nº de Celular</label>
                                                    <asp:TextBox ID="txt_celular" CssClass="form-control form-control-sm numero" runat="server" />
                                                </div>
                                            </div>

                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label class="form-control-label">Nº de libreta de serv. militar </label>
                                                    <asp:TextBox ID="txt_nro_libreta" CssClass="form-control form-control-sm" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label class="form-control-label">AFP</label>
                                                    <asp:DropDownList ID="ddl_afp" CssClass="form-control form-control-sm select2 " AppendDataBoundItems="true" data-minimum-results-for-search="Infinity" runat="server" />
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_afp" Display="Dynamic" ValidationGroup="addFunNuevo" InitialValue="0" runat="server" />
                                                </div>
                                            </div>

                                        </div>
                                        <div class="mt-4 text-right">

                                            <asp:LinkButton ID="btn_guardar_fun_nuevo" Text="<i class='fas fa-save mr-2'></i>Guardar" CssClass="btn btn-success" OnClientClick="if (Page_ClientValidate('addFunNuevo')) { MostrarMascara(true); }" ValidationGroup="addFunNuevo" OnClick="btn_guardar_fun_nuevo_Click" runat="server" />
                                            <asp:LinkButton ID="btn_cancelar_fun_nuevo" class="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i>Cancelar" OnClick="btn_cancelar_fun_nuevo_Click" runat="server" />

                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <div class="modal fade" id="modalFamiliar" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none; overflow-y: auto" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-body p-0">
                        <div class="card card-project" style="margin-bottom: unset; min-height: 250px;">
                            <a href="javascript:;">
                                <div class="icon icon-lg icon-shape icon-shape-info shadow rounded-circle mx-auto" style="background-color: #495057; color: #fff;">
                                    <i class="fas fa-users"></i>
                                </div>
                            </a>
                            <div class="card-body">
                                <p class="text-sm mb-0 mt-5 mb-3">Para realizar la asignación, por favor llene el siguiente formulario. </p>
                                <asp:UpdatePanel ID="up_adicionar_fam" runat="server">
                                    <ContentTemplate>

                                        <h6 class="heading-small text-muted mb-2">Registro de Datos Familiares</h6>
                                        <div class="row">
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label class="form-control-label">Tipo de parentesco</label>
                                                    <asp:DropDownList ID="ddl_tipo_paren_p" CssClass="form-control form-control-sm select2" AppendDataBoundItems="true" data-minimum-results-for-search="Infinity" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label class="form-control-label">Ap. Paterno</label>
                                                    <asp:TextBox ID="txt_ap_paterno_p" CssClass="form-control form-control-sm" runat="server" />

                                                </div>
                                            </div>

                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label class="form-control-label">Ap. Materno</label>
                                                    <asp:TextBox ID="txt_ap_materno_p" CssClass="form-control form-control-sm" runat="server" />

                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label class="form-control-label">Nombre(s)</label>
                                                    <asp:TextBox ID="txt_nombres_p" CssClass="form-control form-control-sm" runat="server" />

                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label class="form-control-label">Tipo de parentesco</label>
                                                    <asp:DropDownList ID="ddl_tipo_paren_m" CssClass="form-control form-control-sm select2" AppendDataBoundItems="true" data-minimum-results-for-search="Infinity" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label class="form-control-label">Ap. Paterno</label>
                                                    <asp:TextBox ID="txt_ap_paterno_m" CssClass="form-control form-control-sm" runat="server" />

                                                </div>
                                            </div>

                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label class="form-control-label">Ap. Materno</label>
                                                    <asp:TextBox ID="txt_ap_materno_m" CssClass="form-control form-control-sm" runat="server" />

                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label class="form-control-label">Nombre(s)</label>
                                                    <asp:TextBox ID="txt_nombres_m" CssClass="form-control form-control-sm" runat="server" />

                                                </div>
                                            </div>
                                        </div>
                                                      <div class="row">
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label class="form-control-label">Tipo de parentesco</label>
                                                    <asp:DropDownList ID="ddl_tipo_paren_e" CssClass="form-control form-control-sm select2" AppendDataBoundItems="true" data-minimum-results-for-search="Infinity" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label class="form-control-label">Ap. Paterno</label>
                                                    <asp:TextBox ID="txt_ap_paterno_e" CssClass="form-control form-control-sm" runat="server" />

                                                </div>
                                            </div>

                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label class="form-control-label">Ap. Materno</label>
                                                    <asp:TextBox ID="txt_ap_materno_e" CssClass="form-control form-control-sm" runat="server" />

                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label class="form-control-label">Nombre(s)</label>
                                                    <asp:TextBox ID="txt_nombres_e" CssClass="form-control form-control-sm" runat="server" />

                                                </div>
                                            </div>
                                        </div>
                                        <div class="mt-4 text-right">
                                            <asp:LinkButton ID="btn_adicionar_fam" Text="<i class='fas fa-save mr-2'></i>Guardar" CssClass="btn btn-success" OnClientClick="if (Page_ClientValidate('addFamNuevo')) { MostrarMascara(true); }" ValidationGroup="addFamNuevo" OnClick="btn_adicionar_fam_Click" runat="server" />
                                            <asp:LinkButton ID="btn_cancelar_fam" class="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i>Cancelar" OnClick="btn_cancelar_fam_Click" runat="server" />
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <div class="modal fade" id="modalContratados" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none; overflow-y: auto" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog modal-dialog-centered modal-xl" role="document">
                <div class="modal-content">
                    <div class="modal-body p-0">
                        <div class="card card-project" style="margin-bottom: unset; min-height: 250px;">
                            <a href="javascript:;">
                                <div class="icon icon-lg icon-shape icon-shape-info shadow rounded-circle mx-auto" style="background-color: #495057; color: #fff;">
                                    <i class="fas fa-users"></i>
                                </div>
                            </a>
                            <div class="card-body">
                                <div class="text-center">
                                    <h5 class="h2 card-title  mt-5 mb-2">Datos registrados</h5>
                                </div>
                   
                                <div class="table-responsive py-4">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvFuncionario" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gvFuncionario_PreRender" DataKeyNames="per_id" runat="server">
                                                <Columns>
                                            
                                                    <asp:BoundField DataField="ciFunc" HeaderText="CI" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField DataField="nombreFunc" HeaderText="Funcionario" HeaderStyle-CssClass="text-center" />
                                                    <asp:BoundField DataField="es_descripcion" HeaderText="Cargo" HeaderStyle-CssClass="text-center"  />
                                                    <asp:BoundField DataField="item" HeaderText="Ítem" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-bold" />
                                                    <asp:BoundField DataField="as_fecha_inicio" HeaderText="Fecha Inicio" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                    <asp:BoundField DataField="as_fecha_fin" HeaderText="Fecha Fin" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                    <asp:BoundField DataField="eo_descripcion" HeaderText="Ubicación Actual" HeaderStyle-CssClass="text-center" />

                                                </Columns>
                                            </asp:GridView>
                                            <asp:HiddenField ID="hf_cod_tenor" runat="server" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <asp:UpdatePanel ID="up_cancelar_impresion" runat="server">
                                    <ContentTemplate>
                                        <div class="mt-3 text-right">
                                            <asp:LinkButton ID="btn_cancelar_impresion" class="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i>Cerrar" OnClick="btn_cancelar_impresion_Click" runat="server" />
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <asp:UpdateProgress ID="up" AssociatedUpdatePanelID="up_gv_planilla" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>

        <asp:UpdateProgress ID="up2" AssociatedUpdatePanelID="up_guardar_fun_nuevo" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up3" AssociatedUpdatePanelID="up_adicionar_fam" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up6" AssociatedUpdatePanelID="up_cancelar_impresion" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>

    </div>
</asp:Content>


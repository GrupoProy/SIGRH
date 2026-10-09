<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="PlanillaObservadas.aspx.cs" Inherits="Precontratacion_PlanillaObservadas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Creación de Pre-Contrato(s)</h6>
                    </div>

                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid mt--6">
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
                        <div class="text-right ml-auto">
                            <asp:UpdatePanel ID="up_btn_enviar_planilla" runat="server">
                                <ContentTemplate>
                                    <asp:LinkButton ID="btn_enviar_planilla" CssClass="btn btn-slack btn-round btn-icon disabled" data-toggle="tooltip" data-original-title="Enviar Planilla" Text="<span class='btn-inner--icon'><i class='fas fa-share-alt'></i></span><span class='btn-inner--text'>Enviar</span>" OnClick="btn_enviar_planilla_Click" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
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
                                <hr class="my-1">
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="table-responsive py-4">
                        <asp:UpdatePanel ID="up_gv_planilla" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gv_planilla" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" OnPreRender="gv_planilla_PreRender" OnRowCommand="gv_planilla_RowCommand" DataKeyNames="pre_id, fr_id, fr_cp_id, fr_es_id" runat="server">
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

                                                <asp:LinkButton CommandName="GetEditP" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-outline-github btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-briefcase fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Editar Puesto' Visible='<%# (Eval("pre_estado_x").ToString().Trim() == "O") ? true : false %>' runat="server" />
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
            <div class="modal-dialog modal- modal-dialog-centered modal-xl" role="document">
                <div class="modal-content">
                    <div class="modal-body p-0">
                        <div class="card bg-secondary border-0 mb-0">
                            <div class="card-header">
                                <div class="text-muted text-center mt-2 mb-3"><small>EDICIÓN DE PUESTO</small></div>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="card-body px-lg-5 pb-lg-5">

                                        <h6 class="heading-small text-muted">Datos de la Pre-Contratación</h6>
                                                <div class="row">
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label class="form-control-label">AFP</label>
                                                    <asp:DropDownList ID="ddl_afp" CssClass="form-control select2 " AppendDataBoundItems="true" data-minimum-results-for-search="Infinity" runat="server" />
                                                 <%--   <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_afp" Display="Dynamic" ValidationGroup="addPuesto" InitialValue="0" runat="server" />--%>
                                                </div>
                                            </div>

                                            <div class="col-lg-4">
                                                <div class="form-group text-center">
                                                    <label class="form-control-label pb-2">¿Presenta DJBR?</label>
                                                    <div>
                                                        <label class="custom-toggle custom-toggle-info">
                                                            <asp:CheckBox ID="chk_pre_djbr" Checked="false" runat="server" />
                                                            <span class="custom-toggle-slider rounded-circle" data-label-off="No" data-label-on="Si"></span>
                                                        </label>
                                                    </div>
                                                </div>
                                            </div>
                                        
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-6 col-md-4">
                                                <div class="form-group">
                                                    <label class="form-control-label">Puesto</label>
                                                    <asp:DropDownList ID="ddl_puesto_modificar" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_puesto_modificar" Display="Dynamic" ValidationGroup="addPuesto" InitialValue="0" runat="server" />

                                                </div>
                                            </div>
                                            <div class="col-sm-6 col-md-8">
                                                <div class="form-group">
                                                    <label class="form-control-label">Objetivo</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend  ">
                                                            <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_objetivo_modificar" class="form-control" runat="server" />
                                                    </div>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_objetivo_modificar" Display="Dynamic" ValidationGroup="addPuesto" runat="server" />

                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-sm-6 col-md-12">
                                                <div class="form-group">
                                                    <label class="form-control-label">Tareas</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend  ">
                                                            <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_tareas_modificar" class="form-control" TextMode="multiline" Rows="8" runat="server" />
                                                    </div>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_tareas_modificar" Display="Dynamic" ValidationGroup="addPuesto" runat="server" />

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <asp:HiddenField ID="hf_fr_id" runat="server" />
                                    <asp:HiddenField ID="hf_fr_es_id" runat="server" />
                                    <asp:HiddenField ID="hf_cp_id" runat="server" />
                                    <asp:HiddenField ID="hf_pre_id" runat="server" />
                                    <asp:HiddenField ID="hf_masivo" runat="server" />
                                    <asp:HiddenField ID="hf_pre_per_id" runat="server" />
                                    <asp:HiddenField ID="hf_pre_fr_id" runat="server" />
                                    <asp:HiddenField ID="hf_pre_editar" runat="server" />
                                    <asp:HiddenField ID="hf_tmp_id" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="form-group text-right" style="padding-right: 2rem">
                                <asp:UpdatePanel ID="up_btn_modificar_puesto" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="btn_modificar_puesto" Text="<i class='fas fa-save mr-2'></i>Guardar" ValidationGroup="addPuesto" CssClass="btn btn-success" OnClick="btn_modificar_puesto_Click" runat="server" />
                                        <asp:LinkButton ID="btn_cancelar_puesto" class="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i>Cancelar" OnClick="btn_cancelar_puesto_Click" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>

        <div class="modal fade" id="modalConfirmacionV" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
            <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                <div class="modal-content bg-gradient-success">
                    <div class="modal-header">
                    </div>

                    <asp:UpdatePanel ID="up_confirmar_val" runat="server">
                        <ContentTemplate>
                            <div class="modal-body">
                                <div class="py-3 text-center">
                                    <i class="ni ni-check-bold ni-3x"></i>
                                    <h4 class="heading text-dark mt-4">¿Está seguro de enviar la planilla?</h4>
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

        <asp:UpdateProgress ID="up" AssociatedUpdatePanelID="up_gv_planilla" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up1" AssociatedUpdatePanelID="up_btn_enviar_planilla" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>

        <asp:UpdateProgress ID="up3" AssociatedUpdatePanelID="up_btn_modificar_puesto" runat="server">
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


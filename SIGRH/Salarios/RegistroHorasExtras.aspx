<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="RegistroHorasExtras.aspx.cs" Inherits="Salarios_Registro_Horas_Extras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Registro de Horas Extras</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid mt--6">
        <div class="row">
            <div class="col-lg-7">
                <div class="card-wrapper">
                    <div class="card">
                        <div class="card-header">
                            <div class=" ct-page-title">
                                <h3 class="mb-0">Datos de la Transacción</h3>
                                <p class="text-sm mb-0">
                                    Detalle de las horas extras que asignará al funcionario seleccionado.
                                </p>
                            </div>
                        </div>
                        <div class="card-body">
                            <asp:Panel DefaultButton="btn_guardar" runat="server">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="row" style="background-color: #D2EEE0; border-radius: .375rem; padding-left: 17px; padding-bottom: 10px; padding-top: 11px;">
                                            <div class="col-lg-4">
                                                <div class="content-text-label">Tipo Transacción</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="txt_tipo_transaccion" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="content-text-label">Máximo Horas/Mes</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="txt_maximo_horas" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="content-text-label">Mes</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="txt_mes" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="example4cols2Input">Horas</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="far fa-clock"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_horas" CssClass="form-control" type="number" runat="server" />
                                                    </div>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_horas" Display="Dynamic" ValidationGroup="addGuardar" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <label class="form-control-label" for="example3cols1Input">&nbsp</label>
                                                            <asp:LinkButton ID="btn_guardar" CssClass="btn btn-success btn-block btn-icon" Text="<span class='btn-inner--icon'><i class='fas fa-save'></i></span><span class='btn-inner--text'>Guardar</span>" OnClick="btn_guardar_Click" ValidationGroup="addGuardar" runat="server" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </asp:Panel>
                        </div>
                    </div>

                    <!-- Grilla Asignación Horas Extras-->
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <div class=" ct-page-title">
                                        <h3 class="mb-0">Horas Extras del Funcionario</h3>
                                        <p class="text-sm mb-0">
                                            Detalle de las horas extra asignada al funcionario seleccionado.
                                        </p>
                                    </div>
                                </div>
                                <div class="table-responsive py-4">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gv_horas_extras" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_horas_extras_PreRender" OnRowCommand="gv_horas_extras_RowCommand" DataKeyNames="tr_id" runat="server">
                                                <Columns>
                                                    <asp:BoundField DataField="fa_descripcion" HeaderText="Descripción del factor" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                    <asp:BoundField DataField="tr_monto" HeaderText="Nro. Horas" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                    <asp:BoundField DataField="tr_fecha_creacion" HeaderText="Fecha Registro" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                    <asp:BoundField DataField="tr_pc_id" HeaderText="Código proceso" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
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
                                            <div id="block_gv_horasExtras" runat="server">
                                                <span class="badge badge-pill badge-info">El funcionario no tiene horas extras asignadas.</span>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- Modal Datos Presupuestarios -->
                    <div class="modal fade" id="datosPresupuestarios" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
                        <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                            <div class="modal-content">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="modal-body p-0">
                                            <div class="card bg-secondary border-0 mb-0">
                                                <div class="card-header">
                                                    <div class="text-muted text-center mt-2 mb-3">
                                                        <h4 class="header-modal">DATOS PRESUPUESTARIOS</h4>
                                                    </div>
                                                </div>
                                                <div class="card-body px-lg-5 py-lg-5">
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <div class="form-group">
                                                                <label class="form-control-label" for="example3cols1Input">Categoría</label>
                                                                <asp:TextBox ID="txt_categoria_prog" CssClass="form-control" disabled runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <div class="form-group">
                                                                <label class="form-control-label" for="example3cols1Input">Descripción </label>
                                                                <asp:TextBox ID="txt_descripcion" CssClass="form-control" TextMode="multiline" Rows="2" disabled runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label class="form-control-label" for="example3cols1Input">Presupuesto</label>
                                                                <asp:TextBox ID="txt_presupuesto" CssClass="form-control" disabled runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label class="form-control-label" for="example3cols1Input">Pagado o Devengado</label>
                                                                <asp:TextBox ID="txt_pagado_devengado" CssClass="form-control" disabled runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label class="form-control-label" for="example3cols1Input">Comprometido</label>
                                                                <asp:TextBox ID="txt_comprometido" CssClass="form-control" disabled runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label class="form-control-label" for="example3cols1Input">Saldo</label>
                                                                <asp:TextBox ID="txt_saldo" CssClass="form-control" disabled runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div style="display: none">
                                                        <asp:HiddenField ID="aux_cat_id" runat="server" />
                                                        <asp:HiddenField ID="aux_cat_abreviacion" runat="server" />
                                                        <asp:HiddenField ID="aux_per_id" runat="server" />
                                                        <asp:HiddenField ID="aux_tipo_transaccion" runat="server" />
                                                        <asp:HiddenField ID="aux_es_id" runat="server" />
                                                        <asp:HiddenField ID="aux_eo_id" runat="server" />
                                                        <asp:HiddenField ID="aux_cp_id" runat="server" />
                                                        <asp:HiddenField ID="aux_tr_id" runat="server" />
                                                        <asp:HiddenField ID="aux_fecha_creacion_nro" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="form-group text-center">
                                                    <asp:LinkButton ID="btn_cancelar_buscar" class="btn btn-google-plus" Text="<i class='fas fa-times mr-2'></i>Cerrar" OnClick="btn_cancelar_buscar_Click" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>

                    <!-- Modal Glosa -->
                    <div class="modal fade" id="modalGlosa" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
                        <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                            <div class="modal-content">
                                <asp:UpdatePanel ID="up_adicionar_cargo" runat="server">
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
                                                        <div id="d_tipo_doc" class="col-md-4" runat="server">
                                                            <div class="form-group">
                                                                <label class="form-control-label" for="exampleFormControlSelect1">Tipo Documento</label>
                                                                <asp:DropDownList ID="ddl_tipo_documento" AppendDataBoundItems="true" CssClass="form-control select2" disabled AutoPostBack="true" runat="server"></asp:DropDownList>
                                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_tipo_documento" Display="Dynamic" ValidationGroup="addGlosa" InitialValue="0" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4" runat="server">
                                                            <div class="form-group">
                                                                <label class="form-control-label" for="exampleFormControlSelect1">Número de documento</label>
                                                                <div class="input-group input-group-merge">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                                    </div>
                                                                    <asp:TextBox ID="txt_num_doc" class="form-control numero" runat="server" />
                                                                </div>
                                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_num_doc" Display="Dynamic" ValidationGroup="addGlosa" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div id="d_fecha_doc" class="col-md-4" runat="server">
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

                    <!-- Modal Eliminar Registro -->
                    <div class="modal fade" id="eliminarItem" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                        <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                            <div class="modal-content bg-gradient-dark6">
                                <asp:UpdatePanel ID="panelEliminarRegistro" runat="server">
                                    <ContentTemplate>
                                        <div class="modal-body">
                                            <div class="py-3 text-center">
                                                <i class="ni ni-fat-remove ni-3x"></i>
                                                <h4 class="heading text-dark mt-4">¿Esta seguro de eliminar el registro?</h4>
                                            </div>
                                        </div>
                                        <div class="form-group text-center">
                                            <asp:LinkButton ID="btnEliminarResultado" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btnEliminarResultado_Click" runat="server" />
                                            <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-5">
                <div class="card-wrapper">
                    <div class="card card-profile">
                        <div class="row justify-content-center">
                            <div class="col-lg-3 order-lg-2">
                                <div class="card-profile-image">
                                    <a href="#">
                                        <asp:Image ID="imgFun" class="rounded-circle" runat="server" />
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="card-header text-center border-0 pt-8 pt-md-4 pb-0 pb-md-4">
                            <asp:LinkButton ID="btn_estado" class="btn btn-sm btn-info float-right" runat="server" />
                        </div>
                        <div class="card-body pt-0">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div>
                                        <h5 class="h3 text-uppercase text-center">
                                            <asp:Literal ID="ltl_apellido_fun" runat="server" />
                                            <asp:Literal ID="ltl_nombre_fun" runat="server" />
                                        </h5>
                                        <div class="h5 font-weight-400  text-center">
                                            <strong class="h5">CI: </strong>
                                            <asp:Literal ID="ltl_ci" runat="server" />
                                            <strong class="h5">COD. FUN:</strong>
                                            <asp:Literal ID="ltl_cod_fun" runat="server" />
                                        </div>
                                        <hr class="my-2">
                                        <h6 class="heading-small text-muted">Información adicional </h6>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Ítem</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_item" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Cargo</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_cargo" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Fecha asignación</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_fecha_inicio" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Fecha baja</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_fecha_fin" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <hr class="my-2">
                                        <h6 class="heading-small text-muted">Escalafón </h6>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Puesto</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_puesto" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Haber Básico (Bs)</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_haber_basico" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div class="content-text-label">Ubicación</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_ubicacion" runat="server" />
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
        </div>
    </div>
    <asp:UpdateProgress ID="up1" AssociatedUpdatePanelID="panelEliminarRegistro" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>


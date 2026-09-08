<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="AsignacionDocente.aspx.cs" Inherits="Docentes_AsignacionDocente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel runat="server" ID="PanelAsignacionMateria">
        <contenttemplate>
            <!-- Header -->
            <div class="header pb-6" style="margin-top: -4em; margin-left: 3em; width: 81%">
                <div class="container-fluid">
                    <div class="header-body">
                        <div class="row align-items-center py-4">
                            <div class="col-lg-6 col-7">
                                <h6 class="h2 text-light d-inline-block mb-0">Asignacion Docente - Materia</h6>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Page content -->
            <div class="container-fluid mt--6">
                <div class="card">
                    <div class="card-header border-bottom">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Búsqueda de Personal</h3>
                            <p class="text-sm mb-0">En el siguiente formulario puede buscar un registro correspondiente a los parámetros ingresados.</p>
                        </div>
                    </div>
                    <asp:Panel CssClass="card-body" DefaultButton="BtnBuscar" runat="server">
                        <asp:HiddenField ID="Hf_as_id" runat="server" />
                        <asp:HiddenField ID="Hf_as_ca_id" runat="server" />
                        <asp:HiddenField ID="Hf_as_per_id" runat="server" />
                        <asp:HiddenField ID="Hf_ti_tipo_ig" runat="server" />
                        <div class="row">
                            <!-- per_ap_paterno -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_per_ap_paterno_b">Apellido Paterno</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_ap_paterno_b" CssClass="form-control letras" runat="server" />
                                </div>
                            </div>
                            <!-- per_ap_materno -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_per_ap_materno_b">Apellido Materno</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_ap_materno_b" CssClass="form-control letras" runat="server" />
                                </div>
                            </div>
                            <!-- per_nombres -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_per_nombres_b">Nombre(s)</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_nombres_b" CssClass="form-control letras" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <!-- per_num_doc -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_per_num_doc_b">Carnet de Identidad</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_num_doc_b" CssClass="form-control numero" TextMode="Number" runat="server" />
                                </div>
                            </div>
                            <!-- per_id -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_per_id_b">Código de Funcionario</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_id_b" CssClass="form-control numero" TextMode="Number" runat="server" />
                                </div>
                            </div>
                            <!-- BtnBuscar -->
                            <div class="form-group col-md-3 offset-md-3 align-self-end">
                                <asp:LinkButton ID="BtnBuscar" CssClass="btn btn-info btn-block" Text="<i class='fas fa-search mr-2'></i> Buscar" OnClick="BtnBuscar_Click" runat="server" />
                            </div>
                        </div>
                    </asp:Panel>
                </div>

                <!--Result Record Starts here -->
                <asp:Panel ID="P_result" CssClass="card" Visible="false" runat="server">
                    <div class="card-header border-bottom">
                        <h3 class="mb-0">Resultado Búsqueda</h3>
                    </div>
                    <div class="card-body">
                        <!-- Placing GridView in UpdatePanel -->
                        <asp:GridView ID="GvLista" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="per_id" OnPreRender="GvLista_PreRender" OnRowDataBound="GvLista_RowDataBound" OnRowCommand="GvLista_RowCommand" runat="server">
                            <columns>
                                <asp:BoundField DataField="per_id" HeaderText="Código" />
                                <asp:BoundField DataField="per_ap_paterno" HeaderText="Apellido Paterno" />
                                <asp:BoundField DataField="per_ap_materno" HeaderText="Apellido Materno" />
                                <asp:BoundField DataField="per_nombres" HeaderText="Nombre(s)" />
                                <asp:BoundField DataField="per_ap_casada" HeaderText="Apellido Casada" />
                                <asp:BoundField DataField="per_num_doc" HeaderText="C.I." />

                                <asp:TemplateField HeaderText="Controles" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                    <itemtemplate>
                                        <asp:LinkButton ID="BtnAsig" CommandName="GetAsig" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-success btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-user-plus'></i></span>" data-toggle='tooltip' data-placement='top' title='Asignar Materia' runat="server" />
                                        <asp:LinkButton ID="BtnBaja" CommandName="GetBaja" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-user-minus'></i></span>" data-toggle='tooltip' data-placement='top' title='Baja Materia' runat="server" />
                                    </itemtemplate>
                                </asp:TemplateField>
                            </columns>
                        </asp:GridView>
                    </div>
                </asp:Panel>
                <!--Result Record Ends here -->
            </div>

            <div class="modal fade" id="modificarAsig" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
                <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                    <div class="modal-content">
                        <div class="modal-body p-0">
                            <div class="card bg-secondary border-0 mb-0">
                                <div class="col-lg-12">
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

                                            <!-- Materia -->
                                            <div class="card-body pt-0">
                                                <div class=" ct-page-title">
                                                    <h3 class="mb-0 text-org2">Información de Materia</h3>
                                                    <div class="row">
                                                        <div class="col-lg-5">
                                                            <div class="content-text-label">Area</div>
                                                            <div class="h5 font-weight-400 content-text">
                                                                <asp:DropDownList ID="ddl_area" AutoPostBack="true" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-5">
                                                            <div class="content-text-label">Carrera</div>
                                                            <div class="h5 font-weight-400 content-text">
                                                                <asp:DropDownList ID="ddl_carrera" AutoPostBack="true" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-5">
                                                            <div class="content-text-label">Plan</div>
                                                            <div class="h5 font-weight-400 content-text">
                                                                <asp:DropDownList ID="ddl_plan" AutoPostBack="true" OnSelectedIndexChanged="ddl_plan_SelectedIndexChanged" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-5">
                                                            <div class="content-text-label">Materia</div>
                                                            <div class="h5 font-weight-400 content-text">
                                                                <asp:DropDownList ID="ddl_materia" AutoPostBakc="true" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <!-- Docente -->
                                <div class="col-lg-12">
                                    <div class="card-wrapper">
                                        <div class="card card-profile">
                                            <div class="card-body pt-0">
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
                                                <div class="row">
                                                    <div class="form-group col-md-12">
                                                        <label class="form-control-label" for="ddl_asignacion_edit">Asignaciones:</label>
                                                        <asp:DropDownList ID="ddl_asignacion_edit" AutoPostBack="true" OnSelectedIndexChanged="ddl_asignacion_edit_SelectedIndexChanged" CssClass="form-control" data-minimum-results-for-search="Infinity" AppendDataBoundItems="true" runat="server" />
                                                    </div>
                                                </div>
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
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group text-center">
                                    <asp:LinkButton ID="btnModificarAsignacion" Text="<i class='fas fa-check mr-2'></i>Guardar" ValidationGroup="sancion" CssClass="btn btn-success" runat="server" />
                                    <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Baja Record Modal Starts here -->
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div id="bajaModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="bajaTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false" style="overflow-y: auto;">
                    <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
                        <div class="modal-content" style="margin-top: 50px;">
                            <div class="modal-body p-0">
                                <div class="card bg-secondary border-0 mb-0">
                                    <div class="row justify-content-center">
                                        <div class="col-lg-3 order-lg-2">
                                            <div class="card-profile-image">
                                                <!-- fp_foto -->
                                                <asp:Image ID="Img_fp_foto" CssClass="rounded-circle" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card-header text-center border-0 pt-8 pt-md-4 pb-0 pb-md-4">
                                        <!-- as_estado -->
                                        <asp:Label ID="Lbl_as_estado" CssClass="btn btn-sm btn-info float-right" runat="server" />
                                    </div>
                                    <div class="card-body px-lg-5 py-lg-3">
                                        <h5 class="h3 text-center">
                                            <!-- per_nombres -->
                                            <asp:Literal ID="Lt_per_nombres" runat="server" />
                                        </h5>
                                        <div class="h5 font-weight-400 text-center">
                                            <!-- per_num_doc -->
                                            <strong class="h5">CI:</strong>
                                            <asp:Literal ID="Lt_per_num_doc" runat="server" />
                                            <!-- per_id -->
                                            <strong class="h5">CÓDIGO:</strong>
                                            <asp:Literal ID="Lt_per_id" runat="server" />
                                            <!-- ca_num_item -->
                                            <strong class="h5">ÍTEM:</strong>
                                            <asp:Literal ID="Lt_ca_num_item" runat="server" />
                                        </div>
                                        <div class="row">
                                            <div class="form-group col-md-12">
                                                <label class="form-control-label" for="ddl_asignacion">Asignaciones:</label>
                                                <asp:DropDownList ID="ddl_asignacion" AutoPostBack="true" CssClass="form-control" data-minimum-results-for-search="Infinity" AppendDataBoundItems="true" runat="server" />
                                            </div>
                                        </div>
                                        <hr class="my-3" />
                                        <h6 class="heading-small text-muted">Escalafón</h6>
                                        <div class="row">
                                            <div class="col-lg-4">
                                                <!-- es_descripcion -->
                                                <div class="content-text-label">Cargo</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_es_descripcion" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <!-- p_descripcion -->
                                                <div class="content-text-label">Puesto</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_p_descripcion" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <!-- ca_basico_calculado -->
                                                <div class="content-text-label">Haber Básico (Bs)</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_ca_basico_calculado" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <!-- es_escalafon -->
                                                <div class="content-text-label">Código Escalafón</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_es_escalafon" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <!-- ns_clase -->
                                                <div class="content-text-label">Clase</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_ns_clase" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <!-- ns_nivel -->
                                                <div class="content-text-label">Nivel Salarial</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_ns_nivel" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <hr class="my-3" />
                                        <h6 class="heading-small text-muted">Información Fecha Asignación</h6>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <!-- as_fecha_inicio -->
                                                <div class="content-text-label">Fecha Alta</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_as_fecha_inicio" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <!-- as_fecha_fin -->
                                                <div class="content-text-label">Fecha Baja</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_as_fecha_fin" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <hr class="my-3" />
                                        <h6 class="heading-small text-muted">Categoría Administrativa</h6>
                                        <div class="row">
                                            <div class="col-lg-8">
                                                <!-- eo_descripcion -->
                                                <div class="content-text-label">Ubicación</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_eo_descripcion" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <!-- eo_prog -->
                                                <div class="content-text-label">Categoría</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_eo_prog" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <hr class="my-3" />
                                        <h6 class="heading-small text-muted">Categoría Programática</h6>
                                        <div class="row">
                                            <div class="col-lg-8">
                                                <!-- cp_descripcion -->
                                                <div class="content-text-label">Ubicación</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_cp_descripcion" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <!-- cp_da -->
                                                <div class="content-text-label">Categoría</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_cp_da" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <hr class="my-3" />
                                        <div class="row">
                                            <!-- as_tipo_baja -->
                                            <div class="form-group col-md-4">
                                                <label class="form-control-label" for="Ddl_as_tipo_baja">Tipo de Movimiento</label>
                                                <asp:DropDownList ID="Ddl_as_tipo_baja" CssClass="form-control" AppendDataBoundItems="true" runat="server" />
                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_as_tipo_baja" ValidationGroup="Baja_as" InitialValue="0" Display="Dynamic" runat="server" />
                                            </div>
                                            <!-- as_fecha_fin (proceso) DB -->
                                            <div class="form-group col-md-4">
                                                <label class="form-control-label" for="Txt_as_fecha_fin_p">Fecha del Movimiento (Proceso)</label>
                                                <div class="input-group input-group-merge">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text">
                                                            <i class="far fa-calendar-alt"></i>
                                                        </span>
                                                    </div>
                                                    <asp:TextBox ID="Txt_as_fecha_fin_p" CssClass="form-control datepickerDefault" runat="server" />
                                                </div>
                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_as_fecha_fin_p" ValidationGroup="Baja_as" Display="Dynamic" runat="server" />
                                            </div>
                                            <!-- as_fecha_fin (memo) -->
                                            <div class="form-group col-md-4">
                                                <label class="form-control-label" for="Txt_as_fecha_fin_m">Fecha del Movimiento (Memo)</label>
                                                <div class="input-group input-group-merge">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text">
                                                            <i class="far fa-calendar-alt"></i>
                                                        </span>
                                                    </div>
                                                    <asp:TextBox ID="Txt_as_fecha_fin_m" CssClass="form-control datepickerDefault" runat="server" />
                                                </div>
                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_as_fecha_fin_m" ValidationGroup="Baja_as" Display="Dynamic" runat="server" />
                                            </div>
                                            <asp:Panel ID="P_as_defuncion" CssClass="row col-md-12" Visible="false" runat="server">
                                                <!-- as_defuncion -->
                                                <div class="form-group col-md-4">
                                                    <label class="form-control-label" for="Txt_as_defuncion">Nº Cartificado Defunción</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text">
                                                                <i class="fas fa-edit"></i>
                                                            </span>
                                                        </div>
                                                        <asp:TextBox ID="Txt_as_defuncion" CssClass="form-control" runat="server" />
                                                    </div>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_as_defuncion" ValidationGroup="Baja_as" Display="Dynamic" runat="server" />
                                                </div>
                                                <!-- as_fec_cert_defuncion -->
                                                <div class="form-group col-md-4">
                                                    <label class="form-control-label" for="Txt_as_fec_defuncion">Fecha Defunción</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text">
                                                                <i class="far fa-calendar-alt"></i>
                                                            </span>
                                                        </div>
                                                        <asp:TextBox ID="Txt_as_fec_defuncion" CssClass="form-control datepickerDefault" runat="server" />
                                                    </div>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_as_fec_defuncion" ValidationGroup="Baja_as" Display="Dynamic" runat="server" />
                                                </div>
                                            </asp:Panel>
                                        </div>
                                    </div>
                                    <div class="form-group text-center">
                                        <asp:LinkButton ID="BtnGuardarB" CssClass="btn btn-success" Text="<i class='fas fa-save mr-2'></i> Guardar" ValidationGroup="Baja_as" <%--OnClick="BtnGuardarB_Click"--%> runat="server" />
                                        <asp:LinkButton ID="BtnCancelarB" CssClass="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i> Cancelar"<%-- OnClick="BtnCancelarB_Click"--%> runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddl_asignacion" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
        <!-- Baja Record Modal Ends here -->


        </contenttemplate>
        <triggers>
            <asp:AsyncPostBackTrigger ControlID="btnModificarAsignacion" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ddl_asignacion_edit" EventName="SelectedIndexChanged" />
        </triggers>
    </asp:UpdatePanel>

    <asp:UpdateProgress AssociatedUpdatePanelID="PanelAsignacionMateria" runat="server">
        <progresstemplate>
            <div class="load"></div>
        </progresstemplate>
    </asp:UpdateProgress>
</asp:Content>
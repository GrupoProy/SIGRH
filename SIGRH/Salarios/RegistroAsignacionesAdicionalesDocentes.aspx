<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="RegistroAsignacionesAdicionalesDocentes.aspx.cs" Inherits="Salarios_RegistroAsignacionesAdicionalesDocentes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Asignación de Cursos de Temporada y/o Examenes de Mesa</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid mt--6">
        <div class="row">
            <div class="col-lg-7">
                <div class="card">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Datos de la Asignación</h3>
                            <p class="text-sm mb-0">Ingrese los datos solicitados para asignar</p>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="Up_form" runat="server">
                        <ContentTemplate>
                            <div class="card-body">
                                <asp:HiddenField ID="Hf_cs_id" runat="server" />
                                <div class="row">
                            <!-- área académica -->
                                    <div class="form-group col-md-12">
                                        <label class="form-control-label" for="txtAreaAcademica">Área Académica:</label>
                                        <div class="input-group input-group-merge">
                                       <asp:LinkButton ID="btnAbrirArbol" CssClass="btn btn-info" Text="<i class='fas fa-list mr-2'></i> Elegir..."  OnClick="btnAbrirArbol_Click" runat="server" />
                                        <div class="col-md-1"></div>
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-edit"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="txtAreaAcademica" CssClass="form-control"  Enabled="false" runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtAreaAcademica" ValidationGroup="add" Display="Dynamic" runat="server" />
                                    </div>      
                                    <asp:HiddenField   ID="hdf_eo_id" runat="server"  />
                                    
                            <!-- Tipo Asignación -->
                            <div class="form-group col-md-4">
                                <label class="form-control-label" for="ddlAsignacion">Asignación Curso/Examen:</label>
                                <asp:DropDownList ID="ddlAsignacion" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlAsignacion" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                            </div>

                                    <!-- Horas -->
                                    <div class="form-group col-md-4">
                                        <label class="form-control-label" for="txtHoras">Horas:</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-edit"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="txtHoras" CssClass="form-control" placeholder="Hrs." runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtHoras" ValidationGroup="add" Display="Dynamic" runat="server" />
                                    </div>
                                    <!-- Total Ganado-->
                                    <div class="form-group col-md-4">
                                        <label class="form-control-label" for="txtTotalGanado">Total Ganado:</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-edit"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="txtTotalGanado" CssClass="form-control" OnTextChanged="txtTotalGanado_TextChanged" AutoPostBack="true" placeholder="Bs." runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Oblogatorio" ControlToValidate="txtTotalGanado" ValidationGroup="add" Display="Dynamic" runat="server" />
                                    </div>
                                    <!-- Fecha ini -->
                                    <div class="form-group col-md-4">
                                        <label class="form-control-label" for="txtFechaInicio">Fecha Inicio:</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-calendar-alt"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="txtFechaInicio" CssClass="form-control datepickerD" runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtFechaInicio" ValidationGroup="add" Display="Dynamic" runat="server" />
                                    </div>
                                    <!-- Fecha fin -->
                                    <div class="form-group col-md-4">
                                        <label class="form-control-label" for="txtFechaFin">Fecha Fin:</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-calendar-alt"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="txtFechaFin" CssClass="form-control datepickerD" runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtFechaFin" ValidationGroup="add" Display="Dynamic" runat="server" />
                                    </div>
<%--                                    <!-- cs_meses -->
                                    <div class="form-group col-md-4">
                                        <label class="form-control-label" for="Txt_cs_meses">Meses</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-calendar-alt"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="Txt_cs_meses" CssClass="form-control numero" TextMode="Number" OnTextChanged="Txt_cs_meses_TextChanged" AutoPostBack="true" Enabled="false" runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_cs_meses" ValidationGroup="add" Display="Dynamic" runat="server" />
                                    </div>--%>
                                    <!-- IUE -->
                                    <div class="form-group col-md-4">
                                        <label class="form-control-label" for="txtIUE">IUE (12.5%)</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-edit"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="txtIUE" CssClass="form-control numero" TextMode="Number" Enabled="false" runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtIUE" ValidationGroup="add" Display="Dynamic" runat="server" />
                                    </div>
                                    <!-- Descuento Asistencia -->
                                    <div class="form-group col-md-4">
                                        <label class="form-control-label" for="txtDescuentosAsistencia">Descuentos de Asistencia:</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-edit"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="txtDescuentosAsistencia" CssClass="form-control" placeholder="Bs."  runat="server" />
                                        </div>
<%--                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtDescuentosAsistencia" ValidationGroup="add" Display="Dynamic" runat="server" />--%>
                                    </div>
                                    <!-- Otros Descuentos -->
                                    <div class="form-group col-md-4">
                                        <label class="form-control-label" for="txtOtrosDescuentos">Otros descuentos:</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-edit"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="txtOtrosDescuentos" CssClass="form-control" placeholder="Bs."  runat="server" />
                                        </div>
<%--                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtOtrosDescuentos" ValidationGroup="add" Display="Dynamic" runat="server" />--%>
                                    </div>
                                    <!-- Periodo -->
                            <!-- Tipo Asignación -->
                            <div class="form-group col-md-4">
                                <label class="form-control-label" for="ddlPeriodo">Asignación Curso/Examen:</label>
                                <asp:DropDownList ID="ddlPeriodo" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlPeriodo" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                            </div>
<%--                                    <div class="form-group col-md-4">
                                        <label class="form-control-label" for="txtPeriodo">Periodo:</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-edit"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="txtPeriodo" CssClass="form-control" placeholder="Ej.: II/2020"  runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtPeriodo" ValidationGroup="add" Display="Dynamic" runat="server" />
                                    </div>--%>
                                    <!-- Periodo -->
                                    <div class="form-group col-md-9">
                                        <label class="form-control-label" for="txtGlosa">Documento de Autorización:</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-check"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="txtGlosa" CssClass="form-control"  runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtGlosa" ValidationGroup="add" Display="Dynamic" runat="server" />
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="offset-lg-6 col-lg-6">
                                        <asp:LinkButton ID="BtnGuardar" CssClass="btn btn-success btn-block" OnClick="BtnGuardar_Click" Text="<i class='fas fa-save'></i> Guardar" ValidationGroup="add"  runat="server" />
                                    </div>
<%--                                    <div class="col-lg-6">
                                        <asp:LinkButton ID="BtnEditar" CssClass="btn btn-warning btn-block" Text="<i class='fas fa-edit'></i> Actualizar" ValidationGroup="add" Visible="false" OnClick="BtnEditar_Click" runat="server" />
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:LinkButton ID="BtnCancelar" CssClass="btn btn-google-plus btn-block" Text="<i class='fas fa-times'></i> Cancelar" Visible="false" OnClick="BtnCancelar_Click" runat="server" />
                                    </div>--%>
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnAbrirArbol" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="txtTotalGanado" EventName="TextChanged" />
                            <asp:AsyncPostBackTrigger ControlID="BtnGuardar" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
                <asp:UpdatePanel ID="Up_list" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="P_lista" CssClass="card" Visible="false" runat="server">
                            <div class="card-header">
                                <div class="ct-page-title">
                                    <h3 class="mb-0">Listado histórico de asignaciones</h3>
                                    <p class="text-sm mb-0"></p>
                                </div>
                            </div>
                            <div class="card-body">
                                <asp:GridView ID="GvLista" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="td_id" OnPreRender="GvLista_PreRender"  OnRowCommand="GvLista_RowCommand" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="td_per_id" HeaderText="Cófigo Func." />
                                        <asp:BoundField DataField="td_tipo_docente" HeaderText="Tipo" />
                                        <asp:BoundField DataField="td_carrera" HeaderText="Carrera"  />
                                        <asp:BoundField DataField="td_fecha_inicio" HeaderText="Inicio" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField DataField="td_fecha_fin" HeaderText="Fin" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:TemplateField HeaderText="Controles" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnDelete" CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-warning btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash'></i></span>" data-toggle="tooltip" data-placement="top" title="Eliminar" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <div class="col-lg-5">
                <asp:UpdatePanel ID="Up_info" runat="server">
                    <ContentTemplate>

                        <div class="card card-profile text-uppercase"  runat="server" id="DivInfo" Visible="true">
                            <div class="row justify-content-center">
                                <div class="col-lg-3 order-lg-2">
                                    <div class="card-profile-image">
                                        <!-- fp_foto -->
                                        <a href="#">
                                            <asp:Image ID="Img_fp_foto" CssClass="rounded-circle" runat="server" />
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <!-- jornada de trabajo -->
                            <div class="col-4">
                                    <span><strong class="h5">TIPO JORNADA: </strong><h6><asp:Literal ID="ltl_jornada" runat="server"/></h6></span>
                            </div>

                            <div class="card-header text-center border-0 pt-8 pt-md-4 pb-0 pb-md-4">
                                <!-- as_estado -->
                                <asp:Label ID="Lbl_as_estado" CssClass="btn btn-sm btn-info float-right" runat="server" />
                            </div>
                            <div class="card-body pt-0">
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
                                <hr class="my-3">
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
                                <hr class="my-3">
                                <h6 class="heading-small text-muted">Categoría Administrativa</h6>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <!-- eo_descripcion -->
                                        <div class="content-text-label">Ubicación</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="Lt_eo_descripcion" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <!-- eo_prog -->
                                        <div class="content-text-label">Categoría</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="Lt_eo_prog" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <hr class="my-3">
                                <h6 class="heading-small text-muted">Categoría Programática</h6>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <!-- cp_descripcion -->
                                        <div class="content-text-label">Ubicación</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="Lt_cp_descripcion" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <!-- cp_da -->
                                        <div class="content-text-label">Categoría</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="Lt_cp_da" runat="server" />
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
    <div id="itemModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="itemTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="modal-body p-0">
                            <div class="card bg-secondary border-0 mb-0">
                                <div class="card-header">
<%--                                    <div class="text-muted text-center mt-2 mb-3"><small>ITEM</small></div>--%>
                    <div class="card-header border-bottom">
                        <div class="ct-page-title">

                            <h3 class="mb-0">Asignación Área Académica</h3>
<%--                            <p class="text-sm mb-0">Seleccione el </p>--%>
                            </div>
                        </div>
                                </div>
                            </div>
                            <div class="card-body px-lg-5 py-lg-5">
                                <div class="row">
                                    <!-- Treeview -->
                                    <asp:TreeView ID="Tv_nivelOrg" ImageSet="Arrows" CssClass="treeView" AutoGenerateDataBindings="true" OnSelectedNodeChanged="tv_nivelOrg_SelectedNodeChanged" runat="server">
                                        <NodeStyle Font-Size=".875em" ForeColor="#525f7f" HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px"></NodeStyle>
                                        <SelectedNodeStyle CssClass="SelectedNodeTreeView" />
                                        <HoverNodeStyle CssClass="HoverTreeView" />
                                    </asp:TreeView>
                                </div>
                            </div>
                            <div class="form-group text-center">
                                <asp:LinkButton ID="btnEscogerAreaAcademica" CssClass="btn btn-success" Text="<i class='fas fa-check mr-2'></i> Escoger"  OnClick="btnEscogerAreaAcademica_Click" runat="server" />
                                <asp:LinkButton ID="BtnCancelarI" CssClass="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i> Cancelar" OnClick="BtnCancelarI_Click" runat="server" />
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnEscogerAreaAcademica" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
                    <%-- Eliminar Asignación Adicional --%>
    <div class="modal fade" id="eliminarAsignacionAdicional" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
        <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
            <div class="modal-content bg-gradient-dark6">
                <div class="modal-header">
                </div>
                <asp:UpdatePanel ID="panelEliminarAporte" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div class="py-3 text-center">
                                <i class="ni ni-fat-remove ni-3x"></i>
                                <h4 class="heading text-dark mt-4">¿Esta seguro de eliminar la asignación?</h4>
                            </div>
                        </div>
                        <div class="form-group text-center">
                            <asp:LinkButton ID="btnEliminarAsignacionAdicional" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success"  OnClick="btnEliminarAsignacionAdicional_Click" runat="server" />
                            <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                            <asp:HiddenField ID="hdf_td_id" runat="server" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnEliminarAsignacionAdicional" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>


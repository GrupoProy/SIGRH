<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="HorariosAlta.aspx.cs" Inherits="ControlPersonal_Horarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Header -->
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Administración de Horarios</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page content -->
    <div class="container-fluid mt--6">
        <asp:UpdatePanel ID="Up_info" runat="server">
            <ContentTemplate>
                <div class="card card-profile text-uppercase">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-lg-3">
                                <div class="row justify-content-center">
                                    <div class="col-lg-3 order-lg-2">
                                        <div class="card-profile-image pt-7">
                                            <!-- fp_foto -->
                                            <asp:Image ID="Img_fp_foto" CssClass="rounded-circle" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="card-header text-center border-0 pt-8 pt-md-4 pb-0 pb-md-6 pr-0">
                                    <!-- as_estado -->
                                    <asp:Label ID="Lbl_as_estado" CssClass="btn btn-sm btn-info float-right" runat="server" />
                                </div>
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
                            </div>
                            <div class="col-lg-9">
                                <hr class="my-3" />
                                <div class="row">
                                    <div class="col-lg-6">
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
                                    </div>
                                    <div class="col-lg-6">
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
                                    </div>
                                </div>
                                <hr class="my-3" />
                                <div class="row">
                                    <div class="col-lg-6">
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
                                    </div>
                                    <div class="col-lg-6">
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
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="Up_list" runat="server">
            <ContentTemplate>
                <asp:Panel ID="P_lista" class="card" Visible="false" runat="server">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Historial de Registros</h3>
                            <p class="text-sm mb-0"></p>
                        </div>
                    </div>
                    <div class="card-body">
                        <asp:GridView ID="GvListaH" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="ah_id" OnPreRender="GvListaH_PreRender" OnRowCommand="GvListaH_RowCommand" runat="server">
                            <Columns>
                                <asp:BoundField DataField="cat_descripcion" HeaderText="Tipo Horario" />
                                <asp:BoundField DataField="ah_fecha_inicial" HeaderText="Fecha Inicio" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="ah_fecha_final" HeaderText="Fecha Fin" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="ah_estado" HeaderText="Estado" ItemStyle-CssClass="text'center"/>
                                <asp:TemplateField HeaderText="Controles" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:LinkButton CommandName="BtnVerHorario" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-success btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-calendar-alt'></i></span>" data-toggle="tooltip" data-original-title="Ver Horario" runat="server" />
                                        <asp:LinkButton CommandName="BtnGlosa" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-info btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-eye'></i></span>" data-toggle="tooltip" data-original-title="Glosa" runat="server" />
                                        <%--<asp:LinkButton CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash'></i></span>" data-toggle='tooltip' data-original-title='Anular' runat="server" />--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>

        <!-- Diseño para el botón nuevo registro -->
        <div class="col-lg-6 col-5 text-right">
            <asp:UpdatePanel ID="Up_nuevo" runat="server">
                <ContentTemplate>
                    <asp:LinkButton ID="BtnNuevo" CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-inst text-white rounded-circle shadow" Text="<i class='fas fa-plus'></i>" data-toggle="tooltip" data-original-title="Nuevo Registro" OnClick="BtnNuevo_Click" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <!-- Diseño para el botón ver registro -->
        <div class="col-lg-6 col-5 text-right">
            <asp:UpdatePanel ID="Up_ver" runat="server">
                <ContentTemplate>
                    <asp:LinkButton ID="BtnVerHorario" CssClass="btn btn-circle sticky-top-btn2 icon-prs icon-shape-prs bg-gradient-dark4 text-white rounded-circle shadow" Text="<i class='far fa-calendar-alt'></i>" data-toggle="tooltip" data-original-title="Ver Horario" OnClick="BtnVerHorario_Click" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <asp:UpdatePanel ID="Up_calendario" runat="server">
            <ContentTemplate>
                <asp:Panel ID="P_calendario" CssClass="card" Visible="false" runat="server">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Calendario</h3>
                            <p class="text-sm mb-0"></p>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-lg-12 text-center">
                                <h6 class="heading-small text-muted">Datos Horario</h6>
                                <div class="row">
                                    <!-- ah_tipo_horario -->
                                    <asp:HiddenField ID="Hf_ah_tipo_horario" runat="server" />
                                    <div class="col-lg-4">
                                        <!-- ah_tipo_horario -->
                                        <div class="content-text-label">Tipo Horario</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="Lt_ah_tipo_horario" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <!-- ah_fecha_inicial -->
                                        <div class="content-text-label">Fecha Inicio</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="Lt_ah_fecha_inicial" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <!-- ah_fecha_final -->
                                        <div class="content-text-label">Fecha Fin</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="Lt_ah_fecha_final" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <hr class="my-3" />
                            </div>
                        </div>
                        <asp:Panel ID="P_datos_horario" CssClass="row" runat="server">
                            <div class="form-group col-md-3">
                                <asp:LinkButton ID="BtnLlenarH" CssClass="btn btn-primary btn-block" Text="<i class='far fa-calendar-plus mr-2'></i> Llenar Horario" OnClick="BtnLlenarH_Click" runat="server" />
                            </div>
                            <div class="form-group col-md-3">
                                <asp:LinkButton ID="BtnLimpiarH" CssClass="btn btn-secondary btn-block" Text="<i class='far fa-calendar-times mr-2'></i> Limpiar Horario" OnClick="BtnLimpiarH_Click" runat="server" />
                            </div>
                            <div class="form-group col-md-3">
                                <label class="form-control-label pb-3" for="Chk_habilitar_c">¿Habilitar Casillas?</label>
                                <div>
                                    <label class="custom-toggle custom-toggle-warning">
                                        <asp:CheckBox ID="Chk_habilitar_c" AutoPostBack="true" OnCheckedChanged="Chk_habilitar_c_CheckedChanged" runat="server" />
                                        <span class="custom-toggle-slider rounded-circle" data-label-off="No" data-label-on="Si"></span>
                                    </label>
                                </div>
                            </div>
                        </asp:Panel>
                        <div class="row">
                            <div class="form-group col-md-3">
                                <asp:LinkButton ID="BtnCancelar" CssClass="btn btn-outline-github btn-block" Text="<i class='fas fa-times mr-2'></i> Cancelar" OnClick="BtnCancelar_Click" runat="server" />
                            </div>
                            <div class="form-group col-md-3">
                                <asp:LinkButton ID="BtnGuardar" CssClass="btn btn-success btn-block" Text="<i class='fas fa-save mr-2'></i> Guardar" Visible="false" OnClick="BtnGuardar_Click" runat="server" />
                            </div>
                            <div class="form-group offset-md-2 col-md-4">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div runat="server" visible="false" class="content-text-label badge badge-pill badge-danger2">Horario No Presencial</div>
                                    </div>
                                    <div class="col-md-6">
                                        <div runat="server" visible="false" class="content-text-label badge badge-pill badge-warning2">Sin Tolerancia Horaria</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- Diseño para el calendario -->
                    <div class="card-body">
                        <asp:GridView ID="Gv_calendario" CssClass="calendar-asp table-bordered2" AutoGenerateColumns="false" OnRowDataBound="Gv_calendario_RowDataBound" runat="server">
                            <Columns>
                                <asp:TemplateField HeaderText="Nº SEM." HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <div class="text-center">
                                            <asp:LinkButton ID="Lnk_tds_sem" CommandArgument='<%# Bind("tds_semana") %>' Text='<%# Bind("tds_mes") %>' runat="server" />
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="LUNES" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <div class="data-day">
                                            <div class="text-right">
                                                <asp:LinkButton ID="Lnk_tds_lun" CommandArgument='<%# Bind("tds_semana") %>' Text='<%# Bind("tds_lunes") %>' OnClick="HorarioModal_Click" runat="server" />
                                            </div>
                                            <asp:Panel ID="P_chk_tds_lun" CssClass="text-center" Visible="false" runat="server">
                                                <div class="custom-control custom-checkbox">
                                                    <asp:CheckBox ID="Chk_tds_lun" runat="server" />
                                                </div>
                                            </asp:Panel>
                                            <asp:Panel ID="P_gv_tds_lun" CssClass="text-center" Visible="false" runat="server">
                                                <asp:GridView ID="Gv_tds_lun" CssClass="sub-calendar-asp text-center" AutoGenerateColumns="false" runat="server">
                                                    <Columns>
                                                        <asp:BoundField DataField="th_ing" HeaderText="ING" DataFormatString="{0:hh\:mm}" />
                                                        <asp:BoundField DataField="th_sal" HeaderText="SAL" DataFormatString="{0:hh\:mm}" />
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MARTES" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <div class="data-day">
                                            <div class="text-right">
                                                <asp:LinkButton ID="Lnk_tds_mar" CommandArgument='<%# Bind("tds_semana") %>' Text='<%# Bind("tds_martes") %>' OnClick="HorarioModal_Click" runat="server" />
                                            </div>
                                            <asp:Panel ID="P_chk_tds_mar" CssClass="text-center" Visible="false" runat="server">
                                                <div class="custom-control custom-checkbox">
                                                    <asp:CheckBox ID="Chk_tds_mar" runat="server" />
                                                </div>
                                            </asp:Panel>
                                            <asp:Panel ID="P_gv_tds_mar" CssClass="text-center" Visible="false" runat="server">
                                                <asp:GridView ID="Gv_tds_mar" CssClass="sub-calendar-asp" AutoGenerateColumns="false" runat="server">
                                                    <Columns>
                                                        <asp:BoundField DataField="th_ing" HeaderText="ING" DataFormatString="{0:hh\:mm}" />
                                                        <asp:BoundField DataField="th_sal" HeaderText="SAL" DataFormatString="{0:hh\:mm}" />
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MIÉRCOLES" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <div class="data-day">
                                            <div class="text-right">
                                                <asp:LinkButton ID="Lnk_tds_mie" CommandArgument='<%# Bind("tds_semana") %>' Text='<%# Bind("tds_miercoles") %>' OnClick="HorarioModal_Click" runat="server" />
                                            </div>
                                            <asp:Panel ID="P_chk_tds_mie" CssClass="text-center" Visible="false" runat="server">
                                                <div class="custom-control custom-checkbox">
                                                    <asp:CheckBox ID="Chk_tds_mie" runat="server" />
                                                </div>
                                            </asp:Panel>
                                            <asp:Panel ID="P_gv_tds_mie" CssClass="text-center" Visible="false" runat="server">
                                                <asp:GridView ID="Gv_tds_mie" CssClass="sub-calendar-asp" AutoGenerateColumns="false" runat="server">
                                                    <Columns>
                                                        <asp:BoundField DataField="th_ing" HeaderText="ING" DataFormatString="{0:hh\:mm}" />
                                                        <asp:BoundField DataField="th_sal" HeaderText="SAL" DataFormatString="{0:hh\:mm}" />
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="JUEVES" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <div class="data-day">
                                            <div class="text-right">
                                                <asp:LinkButton ID="Lnk_tds_jue" CommandArgument='<%# Bind("tds_semana") %>' Text='<%# Bind("tds_jueves") %>' OnClick="HorarioModal_Click" runat="server" />
                                            </div>
                                            <asp:Panel ID="P_chk_tds_jue" CssClass="text-center" Visible="false" runat="server">
                                                <div class="custom-control custom-checkbox">
                                                    <asp:CheckBox ID="Chk_tds_jue" runat="server" />
                                                </div>
                                            </asp:Panel>
                                            <asp:Panel ID="P_gv_tds_jue" CssClass="text-center" Visible="false" runat="server">
                                                <asp:GridView ID="Gv_tds_jue" CssClass="sub-calendar-asp" AutoGenerateColumns="false" runat="server">
                                                    <Columns>
                                                        <asp:BoundField DataField="th_ing" HeaderText="ING" DataFormatString="{0:hh\:mm}" />
                                                        <asp:BoundField DataField="th_sal" HeaderText="SAL" DataFormatString="{0:hh\:mm}" />
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="VIERNES" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <div class="data-day">
                                            <div class="text-right">
                                                <asp:LinkButton ID="Lnk_tds_vie" CommandArgument='<%# Bind("tds_semana") %>' Text='<%# Bind("tds_viernes") %>' OnClick="HorarioModal_Click" runat="server" />
                                            </div>
                                            <asp:Panel ID="P_chk_tds_vie" CssClass="text-center" Visible="false" runat="server">
                                                <div class="custom-control custom-checkbox">
                                                    <asp:CheckBox ID="Chk_tds_vie" runat="server" />
                                                </div>
                                            </asp:Panel>
                                            <asp:Panel ID="P_gv_tds_vie" CssClass="text-center" Visible="false" runat="server">
                                                <asp:GridView ID="Gv_tds_vie" CssClass="sub-calendar-asp" AutoGenerateColumns="false" runat="server">
                                                    <Columns>
                                                        <asp:BoundField DataField="th_ing" HeaderText="ING" DataFormatString="{0:hh\:mm}" />
                                                        <asp:BoundField DataField="th_sal" HeaderText="SAL" DataFormatString="{0:hh\:mm}" />
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SÁBADO" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <div class="data-day">
                                            <div class="text-right">
                                                <asp:LinkButton ID="Lnk_tds_sab" CommandArgument='<%# Bind("tds_semana") %>' Text='<%# Bind("tds_sabado") %>' OnClick="HorarioModal_Click" runat="server" />
                                            </div>
                                            <asp:Panel ID="P_chk_tds_sab" CssClass="text-center" Visible="false" runat="server">
                                                <div class="custom-control custom-checkbox">
                                                    <asp:CheckBox ID="Chk_tds_sab" runat="server" />
                                                </div>
                                            </asp:Panel>
                                            <asp:Panel ID="P_gv_tds_sab" CssClass="text-center" Visible="false" runat="server">
                                                <asp:GridView ID="Gv_tds_sab" CssClass="sub-calendar-asp" AutoGenerateColumns="false" runat="server">
                                                    <Columns>
                                                        <asp:BoundField DataField="th_ing" HeaderText="ING" DataFormatString="{0:hh\:mm}" />
                                                        <asp:BoundField DataField="th_sal" HeaderText="SAL" DataFormatString="{0:hh\:mm}" />
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DOMINGO" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <div class="data-day">
                                            <div class="text-right">
                                                <asp:LinkButton ID="Lnk_tds_dom" CommandArgument='<%# Bind("tds_semana") %>' Text='<%# Bind("tds_domingo") %>' OnClick="HorarioModal_Click" runat="server" />
                                            </div>
                                            <asp:Panel ID="P_chk_tds_dom" CssClass="text-center" Visible="false" runat="server">
                                                <div class="custom-control custom-checkbox">
                                                    <asp:CheckBox ID="Chk_tds_dom" runat="server" />
                                                </div>
                                            </asp:Panel>
                                            <asp:Panel ID="P_gv_tds_dom" CssClass="text-center" Visible="false" runat="server">
                                                <asp:GridView ID="Gv_tds_dom" CssClass="sub-calendar-asp" AutoGenerateColumns="false" runat="server">
                                                    <Columns>
                                                        <asp:BoundField DataField="th_ing" HeaderText="ING" DataFormatString="{0:hh\:mm}" />
                                                        <asp:BoundField DataField="th_sal" HeaderText="SAL" DataFormatString="{0:hh\:mm}" />
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <!-- Modal component -->
    <!-- Fecha Horario Record Modal Starts here -->
    <div id="fechaHorarioModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="fechaHorarioTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="Up_form_h" runat="server">
                    <ContentTemplate>
                        <div class="modal-body p-0">
                            <div class="card bg-secondary border-0 mb-0">
                                <div class="card-header">
                                    <div class="text-muted text-center mt-2 mb-3"><small>DATOS HORARIO</small></div>
                                </div>
                                <div class="card-body px-lg-5 py-lg-5">
                                    <div class="row">
                                        <!-- ah_tipo_horario -->
                                        <asp:Panel ID="P_ah_tipo_horario" CssClass="form-group col-md-12" runat="server">
                                            <label class="form-control-label" for="Ddl_ah_tipo_horario">Tipo de Horario</label>
                                            <asp:DropDownList ID="Ddl_ah_tipo_horario" CssClass="form-control select2" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="Ddl_ah_tipo_horario_SelectedIndexChanged" runat="server" />
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_ah_tipo_horario" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                                        </asp:Panel>
                                        <!-- ah_fecha_inicial -->
                                        <div class="form-group col-md-6">
                                            <label class="form-control-label" for="Txt_ah_fecha_inicial">Fecha Inicio</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">
                                                        <i class="fas fa-calendar-alt"></i>
                                                    </span>
                                                </div>
                                                <asp:TextBox ID="Txt_ah_fecha_inicial" CssClass="form-control datepickerDefault" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_ah_fecha_inicial" ValidationGroup="add" Display="Dynamic" runat="server" />
                                        </div>
                                        <!-- ah_fecha_final -->
                                        <div class="form-group col-md-6">
                                            <label class="form-control-label" for="Txt_ah_fecha_final">Fecha Fin</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">
                                                        <i class="fas fa-calendar-alt"></i>
                                                    </span>
                                                </div>
                                                <asp:TextBox ID="Txt_ah_fecha_final" CssClass="form-control datepickerDefault" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_ah_fecha_final" ValidationGroup="add" Display="Dynamic" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group text-center">
                                    <asp:LinkButton ID="BtnGuardarN" CssClass="btn btn-success" Text="<i class='fas fa-plus mr-2'></i> Generar Calendario" ValidationGroup="add" OnClick="BtnGuardarN_Click" runat="server" />
                                    <asp:LinkButton ID="BtnCancelarN" CssClass="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i> Cancelar" OnClick="BtnCancelarN_Click" runat="server" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- Fecha Horario Record Modal Ends here -->

    <!-- Horario Record Modal Starts here -->
    <div id="horarioModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="horarioTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="Up_horario" runat="server">
                    <ContentTemplate>
                        <div class="modal-body p-0">
                            <div class="card bg-secondary border-0 mb-0">
                                <div class="card-header">
                                    <div class="text-muted text-center mt-2 mb-3"><small>HORARIO</small></div>
                                </div>
                                <div class="card-body px-lg-5 py-lg-5">
                                    <asp:HiddenField ID="Hf_modal_hd" runat="server" />
                                    <asp:HiddenField ID="Hf_modal_hd_sem" runat="server" />
                                    <asp:HiddenField ID="Hf_modal_hd_dia" runat="server" />
                                    <asp:HiddenField ID="Hf_marc_tolr" runat="server" />
                                    <div class="row">
                                        <!-- th_tolr_ing1 -->
                                        <asp:Panel ID="P_tol1" CssClass="form-group col-md-4" runat="server">
                                            <label class="form-control-label pb-3" for="Chk_th_tolr_ing1">¿Tiene Tolerancia?</label>
                                            <div>
                                                <label class="custom-toggle custom-toggle-warning">
                                                    <asp:CheckBox ID="Chk_th_tolr_ing1" Checked="true" runat="server" />
                                                    <span class="custom-toggle-slider rounded-circle" data-label-off="No" data-label-on="Si"></span>
                                                </label>
                                            </div>
                                        </asp:Panel>
                                        <!-- th_ing1 -->
                                        <div class="form-group col-md-4">
                                            <label class="form-control-label" for="Txt_th_ing1">Ingreso 1</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">
                                                        <i class="fas fa-calendar-alt"></i>
                                                    </span>
                                                </div>
                                                <asp:TextBox ID="Txt_th_ing1" CssClass="form-control timepickerD" runat="server" />
                                            </div>
                                            <%--<asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_th_ing1" ValidationGroup="add_h" Display="Dynamic" runat="server" />--%>
                                        </div>
                                        <!-- th_sal1 -->
                                        <div class="form-group col-md-4">
                                            <label class="form-control-label" for="Txt_th_sal1">Salida 1</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">
                                                        <i class="fas fa-calendar-alt"></i>
                                                    </span>
                                                </div>
                                                <asp:TextBox ID="Txt_th_sal1" CssClass="form-control timepickerD" runat="server" />
                                            </div>
                                            <%--<asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_th_sal1" ValidationGroup="add_h" Display="Dynamic" runat="server" />--%>
                                        </div>
                                        <asp:Panel ID="P_is_2" CssClass="col-md-12" runat="server">
                                            <div class="row">
                                                <!-- th_tolr_ing2 -->
                                                <asp:Panel ID="P_tol2" CssClass="form-group col-md-4" runat="server">
                                                    <label class="form-control-label pb-3" for="Chk_th_tolr_ing2">¿Tiene Tolerancia?</label>
                                                    <div>
                                                        <label class="custom-toggle custom-toggle-warning">
                                                            <asp:CheckBox ID="Chk_th_tolr_ing2" Checked="true" runat="server" />
                                                            <span class="custom-toggle-slider rounded-circle" data-label-off="No" data-label-on="Si"></span>
                                                        </label>
                                                    </div>
                                                </asp:Panel>
                                                <!-- th_ing2 -->
                                                <div class="form-group col-md-4">
                                                    <label class="form-control-label" for="Txt_th_ing2">Ingreso 2</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text">
                                                                <i class="fas fa-calendar-alt"></i>
                                                            </span>
                                                        </div>
                                                        <asp:TextBox ID="Txt_th_ing2" CssClass="form-control timepickerD" runat="server" />
                                                    </div>
                                                    <%--<asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_th_ing2" ValidationGroup="add_h" Display="Dynamic" runat="server" />--%>
                                                </div>
                                                <!-- th_sal2 -->
                                                <div class="form-group col-md-4">
                                                    <label class="form-control-label" for="Txt_th_sal2">Salida 2</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text">
                                                                <i class="fas fa-calendar-alt"></i>
                                                            </span>
                                                        </div>
                                                        <asp:TextBox ID="Txt_th_sal2" CssClass="form-control timepickerD" runat="server" />
                                                    </div>
                                                    <%--<asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_th_sal2" ValidationGroup="add_h" Display="Dynamic" runat="server" />--%>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                        <asp:Panel ID="P_grupo_sd" CssClass="col-md-12" runat="server">
                                            <div class="row">
                                                <!-- th_tipo -->
                                                <div class="form-group col-md-12 text-center">
                                                    <div class="custom-control custom-radio">
                                                        <asp:RadioButtonList ID="Rbl_th_tipo" CssClass="radios" RepeatDirection="Horizontal" OnSelectedIndexChanged="Rbl_th_tipo_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                                            <asp:ListItem Value="1" Selected="True" Text="Por Semana" />
                                                            <asp:ListItem Value="2" Text="Por Días" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                                <!-- th_semana -->
                                                <asp:Panel ID="P_tipo_sem" class="form-group col-md-12 text-center" runat="server">
                                                    <div class="custom-control custom-radio">
                                                        <asp:RadioButtonList ID="Rbl_th_semana" CssClass="radios" RepeatDirection="Horizontal" runat="server">
                                                            <asp:ListItem Value="3" Selected="True" Text="Todas las Semanas" />
                                                            <asp:ListItem Value="2" Text="Semanas Pares" />
                                                            <asp:ListItem Value="1" Text="Semanas Impares" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </asp:Panel>
                                                <!-- th_dia -->
                                                <asp:Panel ID="P_tipo_dia_sem" class="form-group col-md-12 text-center" runat="server">
                                                    <div class="custom-control custom-checkbox">
                                                        <asp:CheckBoxList ID="Cbl_th_dia" CssClass="checks" RepeatDirection="Horizontal" runat="server">
                                                            <asp:ListItem Selected="True" Text="Lunes" />
                                                            <asp:ListItem Selected="True" Text="Martes" />
                                                            <asp:ListItem Selected="True" Text="Miércoles" />
                                                            <asp:ListItem Selected="True" Text="Jueves" />
                                                            <asp:ListItem Selected="True" Text="Viernes" />
                                                            <asp:ListItem Text="Sábado" />
                                                            <asp:ListItem Text="Domingo" />
                                                        </asp:CheckBoxList>
                                                    </div>
                                                </asp:Panel>
                                                <!-- th_tipo_dia -->
                                                <asp:Panel ID="P_tipo_dia" class="form-group col-md-12 text-center" Visible="false" runat="server">
                                                    <div class="custom-control custom-radio">
                                                        <asp:RadioButtonList ID="Rbl_th_tipo_dia" CssClass="radios" RepeatDirection="Horizontal" runat="server">
                                                            <asp:ListItem Value="1" Selected="True" Text="Impares" />
                                                            <asp:ListItem Value="2" Text="Pares" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </asp:Panel>
                                            </div>
                                        </asp:Panel>
                                        <!-- th_presencial -->
                                        <div class="form-group col-md-12 text-center">
                                            <label class="form-control-label pb-3" for="Chk_th_presencial">¿Horario Presencial?</label>
                                            <div>
                                                <label class="custom-toggle custom-toggle-warning">
                                                    <asp:CheckBox ID="Chk_th_presencial" Checked="true" runat="server" />
                                                    <span class="custom-toggle-slider rounded-circle" data-label-off="No" data-label-on="Si"></span>
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group text-center">
                                    <asp:LinkButton ID="BtnGuardarH" CssClass="btn btn-success" Text="<i class='fas fa-check mr-2'></i> Aceptar" ValidationGroup="add_h" OnClick="BtnGuardarH_Click" runat="server" />
                                    <asp:LinkButton ID="BtnCancelarH" CssClass="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i> Cancelar" OnClick="BtnCancelarH_Click" runat="server" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- Horario Record Modal Ends here -->

    <!-- Glosa Record Modal Starts here -->
    <div id="glosaModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="glosaTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="Up_glosa" runat="server">
                    <ContentTemplate>
                        <div class="modal-body p-0">
                            <div class="card bg-secondary border-0 mb-0">
                                <div class="card-header">
                                    <div class="text-muted text-center mt-2 mb-3"><small>GLOSA</small></div>
                                </div>
                                <div class="card-body px-lg-5 py-lg-5">
                                    <div class="row">
                                        <!-- gl_tipo_doc -->
                                        <div id="D_gl_tipo_doc" class="form-group col-md-6">
                                            <label class="form-control-label" for="Ddl_gl_tipo_doc">Tipo Documento</label>
                                            <asp:DropDownList ID="Ddl_gl_tipo_doc" CssClass="form-control select2" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="Ddl_gl_tipo_doc_SelectedIndexChanged" runat="server" />
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_gl_tipo_doc" ValidationGroup="glosa" InitialValue="0" Display="Dynamic" runat="server" />
                                        </div>
                                        <!-- gl_numero_doc -->
                                        <asp:Panel ID="P_gl_numero_doc" CssClass="form-group col-md-4" Visible="false" runat="server">
                                            <label class="form-control-label" for="Txt_gl_numero_doc">Número Documento</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">
                                                        <i class="fas fa-edit"></i>
                                                    </span>
                                                </div>
                                                <asp:TextBox ID="Txt_gl_numero_doc" CssClass="form-control" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_gl_numero_doc" ValidationGroup="glosa" Display="Dynamic" runat="server" />
                                        </asp:Panel>
                                        <!-- gl_fecha_doc -->
                                        <div id="D_gl_fecha_doc" class="form-group col-md-6">
                                            <label class="form-control-label" for="Txt_gl_fecha_doc">Fecha Documento</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">
                                                        <i class="fas fa-calendar-alt"></i>
                                                    </span>
                                                </div>
                                                <asp:TextBox ID="Txt_gl_fecha_doc" class="form-control datepickerDefault" ClientIDMode="Static" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_gl_fecha_doc" ValidationGroup="glosa" Display="Dynamic" runat="server" />
                                        </div>
                                        <!-- gl_glosa -->
                                        <div class="form-group col-md-12">
                                            <label class="form-control-label" for="Txt_gl_glosa">Descripción</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">
                                                        <i class="fas fa-edit"></i>
                                                    </span>
                                                </div>
                                                <asp:TextBox ID="Txt_gl_glosa" CssClass="form-control" TextMode="multiline" Rows="4" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_gl_glosa" ValidationGroup="glosa" Display="Dynamic" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group text-center">
                                    <asp:LinkButton ID="BtnGuardarG" CssClass="btn btn-success" Text="<i class='fas fa-save mr-2'></i> Guardar" ValidationGroup="glosa" OnClick="BtnGuardarG_Click" runat="server" />
                                    <asp:LinkButton ID="BtnCancelarG" CssClass="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i> Cancelar" OnClick="BtnCancelarG_Click" runat="server" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- Glosa Record Modal Ends here -->

    <asp:UpdateProgress AssociatedUpdatePanelID="Up_info" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_h" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_list" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_nuevo" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_ver" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_calendario" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_horario" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_glosa" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

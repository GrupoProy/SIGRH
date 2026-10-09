<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ProcesamientoDatos.aspx.cs" Inherits="ControlPersonal_ProcesamientoDatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Header -->
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Administración de Datos (Procesamiento)</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page Content -->
    <div class="container-fluid mt--6">
        <div class="row">
            <div class="col-lg-6">
                <div class="card">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Rango de Fechas</h3>
                            <p class="text-sm mb-0"></p>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="Up_form_d" runat="server">
                        <ContentTemplate>
                            <asp:HiddenField ID="Hf_cp_ue" runat="server" />
                            <asp:HiddenField ID="Hf_modal_hd" runat="server" />
                            <asp:HiddenField ID="Hf_modal_hd_sem" runat="server" />
                            <asp:HiddenField ID="Hf_modal_hd_dia" runat="server" />
                            <asp:HiddenField ID="Hf_marc_tolr" runat="server" />
                            <asp:HiddenField ID="Hf_dia" runat="server" />
                            <div class="card-body">
                                <div class="row">
                                    <!-- ah_fecha_inicial -->
                                    <div class="form-group col-md-6">
                                        <label class="form-control-label" for="Txt_ah_fecha_inicial">Fecha Inicio</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-calendar"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="Txt_ah_fecha_inicial" CssClass="form-control datepickerDefault" runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_ah_fecha_inicial" ValidationGroup="proc_datos" Display="Dynamic" runat="server" />
                                    </div>
                                    <!-- ah_fecha_final -->
                                    <div class="form-group col-md-6">
                                        <label class="form-control-label" for="Txt_ah_fecha_final">Fecha Fin</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-calendar"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="Txt_ah_fecha_final" CssClass="form-control datepickerDefault" runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_ah_fecha_final" ValidationGroup="proc_datos" Display="Dynamic" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="card">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Procesos</h3>
                            <p class="text-sm mb-0"></p>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="Up_form_pr" runat="server">
                        <ContentTemplate>
                            <div class="card-body">
                                <!-- tipo_proc -->
                                <div class="form-group">
                                    <label class="form-control-label" for="">Procesos</label>
                                    <asp:DropDownList ID="Ddl_tipo_proc" CssClass="form-group select2" data-minimum-results-for-search="Infinity" AppendDataBoundItems="true" OnSelectedIndexChanged="Ddl_tipo_proc_SelectedIndexChanged" AutoPostBack="true" runat="server" />
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="col-lg-4">
                <asp:UpdatePanel ID="Up_form_u" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="P_form_u" CssClass="card" runat="server">
                            <div class="card-header">
                                <div class="ct-page-title">
                                    <h3 class="mb-0">Ubicación</h3>
                                    <p class="text-sm mb-0"></p>
                                </div>
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <!-- ei_todos -->
                                    <div class="form-group col-md-5">
                                        <label class="form-control-label" for="Chk_ei_todos">Seleccionar Todo</label>
                                        <div>
                                            <label class="custom-toggle custom-toggle-primary">
                                                <asp:CheckBox ID="Chk_ei_todos" OnCheckedChanged="Chk_ei_todos_CheckedChanged" AutoPostBack="true" runat="server" />
                                                <span class="custom-toggle-slider rounded-circle" data-label-on="SI" data-label-off="NO"></span>
                                            </label>
                                        </div>
                                    </div>
                                    <div class="form-group col-md-7 align-self-end">
                                        <asp:LinkButton ID="BtnAdicionarU" CssClass="btn bg-gradient-inst text-white btn-block" Text="<i class='fas fa-plus mr-2'></i> Adicionar Edificio" ValidationGroup="proc_datos" OnClick="BtnAdicionarU_Click" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <asp:Panel ID="P_gv_lista_u" CssClass="card-body" Visible="false" runat="server">
                                <asp:GridView ID="Gv_lista_u" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="prma_id" OnPreRender="Gv_lista_u_PreRender" OnRowCommand="Gv_lista_u_RowCommand" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="prma_id" HeaderText="Código" />
                                        <asp:BoundField DataField="prma_descripcion" HeaderText="Edificio" />
                                        <asp:TemplateField HeaderText="Controles" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:LinkButton CommandName="BtnEliminar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash'></i></span>" data-toggle="tooltip" data-original-title="Eliminar" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:LinkButton ID="BtnLimpiarU" CssClass="btn btn-secondary btn-block" Text="<i class='fas fa-times mr-2'></i> Borrar Todo" OnClick="BtnLimpiarU_Click" runat="server" />
                            </asp:Panel>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-lg-4">
                <asp:UpdatePanel ID="Up_form_p" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="P_form_p" CssClass="card" runat="server">
                            <div class="card-header">
                                <div class="ct-page-title">
                                    <h3 class="mb-0">Funcionarios</h3>
                                    <p class="text-sm mb-0"></p>
                                </div>
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <!-- df_todos -->
                                    <div class="form-group col-md-5">
                                        <label class="form-control-label" for="">Seleccionar Todo</label>
                                        <div>
                                            <label class="custom-toggle custom-toggle-primary">
                                                <asp:CheckBox ID="Chk_df_todos" OnCheckedChanged="Chk_df_todos_CheckedChanged" AutoPostBack="true" runat="server" />
                                                <span class="custom-toggle-slider rounded-circle" data-label-on="SI" data-label-off="NO"></span>
                                            </label>
                                        </div>
                                    </div>
                                    <div class="form-group col-md-7 align-self-end">
                                        <asp:LinkButton ID="BtnAdicionarP" CssClass="btn bg-gradient-inst text-white btn-block" Text="<i class='fas fa-plus mr-2'></i> Adicionar Individual" ValidationGroup="proc_datos" OnClick="BtnAdicionarP_Click" runat="server" />
                                        <asp:LinkButton ID="BtnAdicionarUE" CssClass="btn bg-gradient-inst text-white btn-block" Text="<i class='fas fa-plus mr-2'></i> Adicionar Por UE" ValidationGroup="proc_datos" OnClick="BtnAdicionarUE_Click" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <asp:Panel ID="P_gv_lista_f" CssClass="card-body" Visible="false" runat="server">
                                <asp:GridView ID="Gv_lista_f" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="prma_id" OnPreRender="Gv_lista_f_PreRender" OnRowCommand="Gv_lista_f_RowCommand" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="prma_id" HeaderText="Código" />
                                        <asp:BoundField DataField="prma_descripcion" HeaderText="Funcionario" />
                                        <asp:TemplateField HeaderText="Controles" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:LinkButton CommandName="BtnEliminar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash'></i></span>" data-toggle="tooltip" data-original-title="Eliminar" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:LinkButton ID="BtnLimpiarF" CssClass="btn btn-secondary btn-block" Text="<i class='fas fa-times mr-2'></i> Borrar Todo" OnClick="BtnLimpiarF_Click" runat="server" />
                            </asp:Panel>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-lg-4">
                <asp:UpdatePanel ID="Up_form_i" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="P_form_i" CssClass="card" runat="server">
                            <div class="card-header">
                                <div class="ct-page-title">
                                    <h3 class="mb-0">Items</h3>
                                    <p class="text-sm mb-0"></p>
                                </div>
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <!-- ti_todos -->
                                    <div class="form-group col-md-5">
                                        <label class="form-control-label" for="">Seleccionar Todo</label>
                                        <div>
                                            <label class="custom-toggle custom-toggle-primary">
                                                <asp:CheckBox ID="Chk_ti_todos" OnCheckedChanged="Chk_ti_todos_CheckedChanged" AutoPostBack="true" runat="server" />
                                                <span class="custom-toggle-slider rounded-circle" data-label-on="SI" data-label-off="NO"></span>
                                            </label>
                                        </div>
                                    </div>
                                    <div class="form-group col-md-7 align-self-end">
                                        <asp:LinkButton ID="BtnAdicionarI" CssClass="btn bg-gradient-inst text-white btn-block" Text="<i class='fas fa-plus mr-2'></i> Adicionar Tipo Item" ValidationGroup="proc_datos" OnClick="BtnAdicionarI_Click" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <asp:Panel ID="P_gv_lista_i" CssClass="card-body" Visible="false" runat="server">
                                <asp:GridView ID="Gv_lista_i" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="prma_id" OnPreRender="Gv_lista_i_PreRender" OnRowCommand="Gv_lista_i_RowCommand" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="prma_id" HeaderText="Código" />
                                        <asp:BoundField DataField="prma_descripcion" HeaderText="Tipo Ítem" />
                                        <asp:TemplateField HeaderText="Controles" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:LinkButton CommandName="BtnEliminar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash'></i></span>" data-toggle="tooltip" data-original-title="Eliminar" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:LinkButton ID="BtnLimpiarI" CssClass="btn btn-secondary btn-block" Text="<i class='fas fa-times mr-2'></i> Borrar Todo" OnClick="BtnLimpiarI_Click" runat="server" />
                            </asp:Panel>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

        <asp:UpdatePanel ID="Up_procesamiento_datos" runat="server">
            <ContentTemplate>
                <asp:Panel ID="P_procesamiento_datos" CssClass="card" Visible="false" runat="server">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">
                                <asp:Literal ID="Lt_pd_titulo" runat="server" /></h3>
                            <p class="text-sm mb-0"></p>
                        </div>
                    </div>
                    <div class="card-body row">
                        <div class="col-lg-12 text-center">
                            <h6 class="heading-small text-muted">Datos Horario</h6>
                            <div class="row">
                                <!-- he_tipo_horario -->
                                <asp:HiddenField ID="Hf_pd_tipo_horario" runat="server" />
                                <div class="col-lg-4">
                                    <!-- he_tipo_horario -->
                                    <div class="content-text-label">
                                        <asp:Literal ID="Lt_pd_titulo_hl" runat="server" />
                                    </div>
                                    <div class="h5 font-weight-400 content-text">
                                        <asp:Literal ID="Lt_pd_tipo_hl" runat="server" />
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <!-- he_fecha_inicial -->
                                    <div class="content-text-label">Fecha Inicio</div>
                                    <div class="h5 font-weight-400 content-text">
                                        <asp:Literal ID="Lt_pd_fecha_inicial" runat="server" />
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <!-- he_fecha_final -->
                                    <div class="content-text-label">Fecha Fin</div>
                                    <div class="h5 font-weight-400 content-text">
                                        <asp:Literal ID="Lt_pd_fecha_final" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <hr class="my-3" />
                        </div>
                    </div>
                    <!---------------------------->
                    <!----- HORARIO ESPECIAL ----->
                    <!---------------------------->
                    <asp:Panel ID="P_horario_especial" CssClass="card-body" Visible="false" runat="server">
                        <div class="row">
                            <!-- he_tipo_marc -->
                            <div class="form-group col-md-6">
                                <label class="form-control-label mb-3" for="Rbl_he_tipo_marc">Tipo Marcado</label>
                                <div class="custom-control custom-radio">
                                    <asp:RadioButtonList ID="Rbl_he_tipo_marc" CssClass="radios" RepeatDirection="Horizontal" runat="server">
                                        <asp:ListItem Value="T" Selected="True" Text="Todos" />
                                        <asp:ListItem Value="D" Text="Dos" />
                                        <asp:ListItem Value="C" Text="Cuatro" />
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="row">
                                    <!-- he_ing1 -->
                                    <div class="form-group col-md-6">
                                        <label class="form-control-label" for="Txt_he_ing1">Ingreso 1</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-edit"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="Txt_he_ing1" CssClass="form-control timepickerD" runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_he_ing1" ValidationGroup="hora_esp" Display="Dynamic" runat="server" />
                                    </div>
                                    <!-- he_sal1 -->
                                    <div class="form-group col-md-6">
                                        <label class="form-control-label" for="Txt_he_sal1">Salida 1</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-edit"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="Txt_he_sal1" CssClass="form-control timepickerD" runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_he_sal1" ValidationGroup="hora_esp" Display="Dynamic" runat="server" />
                                    </div>
                                    <!-- he_ing2_sal2 -->
                                    <asp:Panel ID="P_he_is_2" CssClass="col-md-12" runat="server">
                                        <div class="row">
                                            <!-- he_ing2 -->
                                            <div class="form-group col-md-6">
                                                <label class="form-control-label" for="Txt_he_ing2">Ingreso 2</label>
                                                <div class="input-group input-group-merge">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text">
                                                            <i class="fas fa-edit"></i>
                                                        </span>
                                                    </div>
                                                    <asp:TextBox ID="Txt_he_ing2" CssClass="form-control timepickerD" runat="server" />
                                                </div>
                                            </div>
                                            <!-- he_sal2 -->
                                            <div class="form-group col-md-6">
                                                <label class="form-control-label" for="Txt_he_sal2">Salida 2</label>
                                                <div class="input-group input-group-merge">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text">
                                                            <i class="fas fa-edit"></i>
                                                        </span>
                                                    </div>
                                                    <asp:TextBox ID="Txt_he_sal2" CssClass="form-control timepickerD" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="offset-md-3 col-md-3">
                                <asp:LinkButton ID="BtnGuardarHE" CssClass="btn btn-success btn-block" Text="<i class='fas fa-save mr-2'></i> Procesar Datos" ValidationGroup="hora_esp" OnClick="BtnGuardarHE_Click" runat="server" />
                            </div>
                            <div class="col-md-3">
                                <asp:LinkButton ID="BtnCancelarHE" CssClass="btn btn-outline-github btn-block" Text="<i class='fas fa-times mr-2'></i> Cancelar" OnClick="BtnCancelarHE_Click" runat="server" />
                            </div>
                        </div>
                    </asp:Panel>
                    <!-------------------------->
                    <!----- HORARIO MASIVO ----->
                    <!-------------------------->
                    <asp:Panel ID="P_horario_masivo" Visible="false" runat="server">
                        <div class="card-body">
                            <div class="row">
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
                            </div>
                            <div class="row">
                                <div class="form-group col-md-3">
                                    <asp:LinkButton ID="BtnCancelar" CssClass="btn btn-outline-github btn-block" Text="<i class='fas fa-times mr-2'></i> Cancelar" OnClick="BtnCancelar_Click" runat="server" />
                                </div>
                                <div class="form-group col-md-3">
                                    <asp:LinkButton ID="BtnGuardar" CssClass="btn btn-success btn-block" Text="<i class='fas fa-save mr-2'></i> Procesar Datos" Visible="false" OnClick="BtnGuardar_Click" runat="server" />
                                </div>
                                <div class="form-group offset-md-2 col-md-4">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="content-text-label badge badge-pill badge-danger2">Horario No Presencial</div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="content-text-label badge badge-pill badge-warning2">Sin Tolerancia Horaria</div>
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
                    <!-------------------------------->
                    <!----- LICENCIA JUSTIFICADA ----->
                    <!-------------------------------->
                    <asp:Panel ID="P_licencia_justificada" CssClass="card-body" Visible="false" runat="server">
                        <div class="row">
                            <!-- lj_tipo_licencia -->
                            <div class="form-group col-md-6">
                                <label class="form-control-label" for="Ddl_lj_tipo_licencia">Tipo Licencia</label>
                                <asp:DropDownList ID="Ddl_lj_tipo_licencia" CssClass="form-control select2" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="Ddl_lj_tipo_licencia_SelectedIndexChanged" runat="server" />
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_lj_tipo_licencia" ValidationGroup="licen_just" InitialValue="0" Display="Dynamic" runat="server" />
                            </div>
                            <!-- lj_tipo_funcionario -->
                            <div class="form-group col-md-6">
                                <label class="form-control-label mb-3" for="Rbl_lj_tipo_funcionario">Tipo Funcionario</label>
                                <div class="custom-control custom-radio">
                                    <asp:RadioButtonList ID="Rbl_lj_tipo_funcionario" CssClass="radios" RepeatDirection="Horizontal" runat="server">
                                        <asp:ListItem Value="T" Selected="True" Text="Todos" />
                                        <asp:ListItem Value="F" Text="Mujeres" />
                                        <asp:ListItem Value="V" Text="Varones" />
                                        <asp:ListItem Value="M" Text="Mamás" />
                                        <asp:ListItem Value="P" Text="Papás" />
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <!-- lj_motivo -->
                            <div class="form-group col-md-6">
                                <label class="form-control-label" for="Txt_lj_motivo">Motivo</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_lj_motivo" CssClass="form-control" TextMode="MultiLine" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_lj_motivo" ValidationGroup="licen_just" Display="Dynamic" runat="server" />
                            </div>
                            <!-- lj_lugar -->
                            <div class="form-group col-md-6">
                                <label class="form-control-label" for="Txt_lj_lugar">Lugar</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_lj_lugar" CssClass="form-control" TextMode="MultiLine" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_lj_lugar" ValidationGroup="licen_just" Display="Dynamic" runat="server" />
                            </div>
                            <!-- lj_hora_salida -->
                            <div class="form-group col-md-5">
                                <label class="form-control-label" for="Txt_lj_hora_salida">Hora Salida</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-calendar-alt"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_lj_hora_salida" CssClass="form-control timepickerD" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_lj_hora_salida" ValidationGroup="licen_just" Display="Dynamic" runat="server" />
                            </div>
                            <!-- lj_hora_retorno -->
                            <div class="form-group col-md-5">
                                <label class="form-control-label" for="Txt_lj_hora_retorno">Hora Retorno</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-calendar-alt"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_lj_hora_retorno" CssClass="form-control timepickerD" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_lj_hora_retorno" ValidationGroup="licen_just" Display="Dynamic" runat="server" />
                            </div>
                            <!-- lj_dia -->
                            <div class="form-group col-md-2">
                                <label class="form-control-label mb-3" for="Chk_lj_dia">Todo El Día</label>
                                <div>
                                    <label class="custom-toggle custom-toggle-warning">
                                        <asp:CheckBox ID="Chk_lj_dia" AutoPostBack="true" OnCheckedChanged="Chk_lj_dia_CheckedChanged" runat="server" />
                                        <span class="custom-toggle-slider rounded-circle" data-label-off="No" data-label-on="Si"></span>
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="offset-md-3 col-md-3">
                                <asp:LinkButton ID="BtnGuardarLJ" CssClass="btn btn-success btn-block" Text="<i class='fas fa-save mr-2'></i> Procesar Datos" ValidationGroup="licen_just" OnClick="BtnGuardarLJ_Click" runat="server" />
                            </div>
                            <div class="col-md-3">
                                <asp:LinkButton ID="BtnCancelarLJ" CssClass="btn btn-outline-github btn-block" Text="<i class='fas fa-times mr-2'></i> Cancelar" OnClick="BtnCancelarLJ_Click" runat="server" />
                            </div>
                        </div>
                    </asp:Panel>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <!-- Modal component -->
    <!-- Ubicación Record Modal Starts here -->
    <div id="ubicacionModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="locationTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="Up_ubicacion" runat="server">
                    <ContentTemplate>
                        <div class="modal-body p-0">
                            <div class="card bg-secondary border-0 mb-0">
                                <div class="card-header">
                                    <div class="text-muted text-center mt-2 mb-3"><small>UBICACIÓN</small></div>
                                </div>
                                <div class="card-body px-lg-5 py-lg-5">
                                    <!-- cat_descripcion_ei -->
                                    <div class="form-group">
                                        <label class="form-control-label" for="Ddl_cat_descripcion_ei">Edificios</label>
                                        <asp:DropDownList ID="Ddl_cat_descripcion_ei" CssClass="form-group select2" AppendDataBoundItems="true" OnSelectedIndexChanged="Ddl_cat_descripcion_ei_SelectedIndexChanged" AutoPostBack="true" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group text-center">
                                    <asp:LinkButton ID="BtnCancelarU" CssClass="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i> Cancelar" OnClick="BtnCancelarU_Click" runat="server" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- Ubicación Record Modal Ends here -->

    <!-- Búsqueda Record Modal Starts here -->
    <div id="busquedaModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="busquedaTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="Up_busqueda" runat="server">
                    <ContentTemplate>
                        <div class="modal-body p-0">
                            <div class="card bg-secondary border-0 mb-0">
                                <div class="card-header">
                                    <div class="text-muted text-center mt-2 mb-3"><small>BÚSQUEDA</small></div>
                                </div>
                                <asp:Panel CssClass="card-body px-lg-5" DefaultButton="BtnBuscar" runat="server">
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
                                        <div class="form-group offset-md-3 col-md-3 align-self-end">
                                            <asp:LinkButton ID="BtnBuscar" CssClass="btn btn-info btn-block" Text="<i class='fas fa-search'></i> Buscar" OnClick="BtnBuscar_Click" runat="server" />
                                        </div>
                                    </div>
                                </asp:Panel>

                                <!-- Result Record Starts here -->
                                <asp:Panel ID="P_result" CssClass="card-body px-lg-5 pb-lg-5" Visible="false" runat="server">
                                    <!-- Placing GridView in UpdatePanel -->
                                    <asp:GridView ID="Gv_lista_p" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="per_id" OnPreRender="Gv_lista_p_PreRender" OnRowCommand="Gv_lista_p_RowCommand" runat="server">
                                        <Columns>
                                            <asp:BoundField DataField="per_id" HeaderText="Código" />
                                            <asp:BoundField DataField="per_ap_paterno" HeaderText="Apellido Paterno" />
                                            <asp:BoundField DataField="per_ap_materno" HeaderText="Apellido Materno" />
                                            <asp:BoundField DataField="per_nombres" HeaderText="Nombre(s)" />
                                            <asp:BoundField DataField="per_ap_casada" HeaderText="Apellido Casada" />
                                            <asp:BoundField DataField="per_num_doc" HeaderText="C.I." />
                                            <asp:TemplateField HeaderText="Controles" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                                <ItemTemplate>
                                                    <asp:LinkButton CommandName="BtnSeleccionar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-primary btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-angle-double-right'></i></span>" data-toggle="tooltip" data-placement="top" title="Agregar Registro" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                                <!-- Result Record Ends here -->

                                <div class="form-group text-center">
                                    <asp:LinkButton ID="BtnCancelarP" CssClass="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i> Cancelar" OnClick="BtnCancelarP_Click" runat="server" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- Búsqueda Record Modal Ends here -->

    <!-- Unidad Organizacional Record Modal Starts here -->
    <div id="unidadOrganizacionalModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="unidadOrganizacionalTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="Up_unidad_organizacional" runat="server">
                    <ContentTemplate>
                        <div class="modal-body p-0">
                            <div class="card bg-secondary border-0 mb-0">
                                <div class="card-header">
                                    <div class="text-muted text-center mt-2 mb-3"><small>UNIDAD ORGANIZACIONAL</small></div>
                                </div>
                                <div class="card-body px-lg-5 py-lg-5">
                                    <!-- Treeview -->
                                    <asp:TreeView ID="Tv_nivelOrg" ImageSet="Arrows" CssClass="treeView" AutoGenerateDataBindings="true" OnSelectedNodeChanged="Tv_nivelOrg_SelectedNodeChanged" runat="server">
                                        <NodeStyle Font-Size=".875em" ForeColor="#525f7f" NodeSpacing="0px" VerticalPadding="2px"></NodeStyle>
                                        <SelectedNodeStyle CssClass="SelectedNodeTreeView" />
                                        <HoverNodeStyle CssClass="HoverTreeView" />
                                    </asp:TreeView>
                                </div>
                                <div class="form-group text-center">
                                    <asp:LinkButton ID="BtnCancelarUE" CssClass="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i> Cancelar" OnClick="BtnCancelarUE_Click" runat="server" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- Unidad Organizacional Record Modal Ends here -->

    <!-- Tipo Ítem Record Modal Starts here -->
    <div id="tipoItemModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="tipoItemTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="Up_tipo_item" runat="server">
                    <ContentTemplate>
                        <div class="modal-body p-0">
                            <div class="card bg-secondary border-0 mb-0">
                                <div class="card-header">
                                    <div class="text-muted text-center mt-2 mb-3"><small>ITEM</small></div>
                                </div>
                                <div class="card-body px-lg-5 py-lg-5">
                                    <!-- cat_descripcion_ti -->
                                    <div class="form-group">
                                        <label class="form-control-label" for="">Tipo Item</label>
                                        <asp:DropDownList ID="Ddl_cat_descripcion_ti" CssClass="form-group select2" AppendDataBoundItems="true" OnSelectedIndexChanged="Ddl_cat_descripcion_ti_SelectedIndexChanged" AutoPostBack="true" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group text-center">
                                    <asp:LinkButton ID="BtnCancelarI" CssClass="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i> Cancelar" OnClick="BtnCancelarI_Click" runat="server" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- Tipo Ítem Record Modal Ends here -->

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
                                        <div class="form-group col-md-12">
                                            <label class="form-control-label" for="Ddl_ah_tipo_horario">Tipo de Horario</label>
                                            <asp:DropDownList ID="Ddl_ah_tipo_horario" CssClass="form-control select2" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="Ddl_ah_tipo_horario_SelectedIndexChanged" runat="server" />
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_ah_tipo_horario" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group text-center">
                                    <asp:LinkButton ID="BtnGuardarN" CssClass="btn btn-success" Text="<i class='fas fa-plus mr-2'></i> Generar Calendario" ValidationGroup="tipo_horario" OnClick="BtnGuardarN_Click" runat="server" />
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
                                            <%--<asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_th_ing1" ValidationGroup="horario" Display="Dynamic" runat="server" />--%>
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
                                            <%--<asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_th_sal1" ValidationGroup="horario" Display="Dynamic" runat="server" />--%>
                                        </div>
                                        <asp:Panel ID="P_hm_is_2" CssClass="col-md-12" runat="server">
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
                                                    <%--<asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_th_ing2" ValidationGroup="horario" Display="Dynamic" runat="server" />--%>
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
                                                    <%--<asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_th_sal2" ValidationGroup="horario" Display="Dynamic" runat="server" />--%>
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
                                    <asp:LinkButton ID="BtnGuardarH" CssClass="btn btn-success" Text="<i class='fas fa-check mr-2'></i> Aceptar" ValidationGroup="horario" OnClick="BtnGuardarH_Click" runat="server" />
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

    <!-- Licencias Record Modal Starts here -->
    <div id="licenciaModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="licenciaTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="Up_list_l" runat="server">
                    <ContentTemplate>
                        <div class="modal-body p-0">
                            <div class="card bg-secondary border-0 mb-0">
                                <div class="card-header">
                                    <div class="text-muted text-center mt-2 mb-3"><small>LISTA DE FUNCIONARIOS</small></div>
                                </div>
                                <div class="card-body px-lg-5 py-lg-5">
                                    <asp:GridView ID="Gv_lista_l" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="prma_id" OnPreRender="Gv_lista_l_PreRender" runat="server">
                                        <Columns>
                                            <asp:BoundField DataField="prma_id" HeaderText="Código" />
                                            <asp:BoundField DataField="prma_descripcion" HeaderText="Funcionario" />
                                            <%--<asp:TemplateField HeaderText="Controles" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                                <ItemTemplate>
                                                    <asp:LinkButton CommandName="BtnEliminar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash'></i></span>" data-toggle="tooltip" data-original-title="Eliminar" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div class="form-group text-center">
                                    <asp:LinkButton ID="BtnCancelarLLJ" CssClass="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i> Cancelar" OnClick="BtnCancelarLLJ_Click" runat="server" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- Licencias Record Modal Ends here -->

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
                                                <asp:TextBox ID="Txt_gl_fecha_doc" class="form-control datepickerDefault" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_gl_fecha_doc" ValidationGroup="glosa" Display="Dynamic" runat="server" />
                                        </div>
                                        <!--hl_autoriza -->
                                        <div class="form-group col-md-12">
                                            <label class="form-control-label" for="Txt_hl_autoriza">Autorizado Por</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">
                                                        <i class="fas fa-edit"></i>
                                                    </span>
                                                </div>
                                                <asp:TextBox ID="Txt_hl_autoriza" CssClass="form-control" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_hl_autoriza" ValidationGroup="glosa" Display="Dynamic" runat="server" />
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

    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_d" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_u" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_p" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_i" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_pr" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_ubicacion" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_busqueda" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_unidad_organizacional" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_tipo_item" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_h" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_procesamiento_datos" runat="server">
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

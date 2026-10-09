<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="FrecuenciaInicio.aspx.cs" Inherits="Precontratacion_FrecuenciaInicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Formulación de Frecuencias</h6>
                    </div>
                    <div class="col-lg-6 col-5 text-right">

                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:LinkButton ID="btn_nueva_frecuencia" CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-inst text-white rounded-circle shadow" Text="<i class='fas fa-plus'></i>" data-toggle="tooltip" data-original-title="Crear Frecuencia(s)" OnClick="btn_nueva_frecuencia_Click" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
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
                                    <h3 class="mb-0">Lista Frecuencias</h3>
                                    <p class="text-sm mb-0">En la tabla se muestra todas las frecuencias que le corresponde a la categoría anteriormente seleccionada.</p>
                                </div>
                            </div>

                        </div>
                        <div class="text-right ml-auto">
                            <asp:UpdatePanel ID="up_btn_enviar_planilla" runat="server">
                                <ContentTemplate>
                                    <asp:LinkButton ID="btn_enviar_categoria" CssClass="btn btn-slack btn-round btn-icon disabled" data-toggle="tooltip" data-original-title="Enviar" Text="<span class='btn-inner--icon'><i class='fas fa-share-alt'></i></span><span class='btn-inner--text'>Enviar</span>" OnClick="btn_enviar_categoria_Click" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-lg-8">
                                        <div class="content-text-label">DESCRIPCIÓN PRESUPUESTO</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_desc" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-1">
                                        <div class="content-text-label">DA</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_da" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-1">
                                        <div class="content-text-label">UE</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_ue" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-1">
                                        <div class="content-text-label">Fuente</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_fuente" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-1">
                                        <div class="content-text-label">Organismo</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_org" runat="server" />
                                        </div>
                                    </div>

                                </div>
                                <hr class="my-1">
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="table-responsive pb-4">
                        <asp:UpdatePanel ID="up_gv_frecuencias" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gv_frecuencias" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" OnPreRender="gv_frecuencias_PreRender" OnRowCommand="gv_frecuencias_RowCommand" DataKeyNames="fr_id" runat="server">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                            <HeaderTemplate>
                                                CARGO
                                                <asp:DropDownList ID="ddl_gv_frec_cargo" CssClass="custom-select custom-select-sm form-control form-control-sm" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="ddl_gv_frec_cargo_SelectedIndexChanged" runat="server" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%# Eval("es_descripcion") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="haber_basico" HeaderText="Haber básico (Bs)" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:0.00}" />
                                        <asp:BoundField DataField="fr_fecha_inicio" HeaderText="Fecha Inicio" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="fr_fecha_fin" HeaderText="Fecha Fin" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:TemplateField HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                            <HeaderTemplate>
                                                Tiempo (Meses)
                                                <asp:DropDownList ID="ddl_gv_frec_tiempo" CssClass="custom-select custom-select-sm form-control form-control-sm" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="ddl_gv_frec_cargo_SelectedIndexChanged" runat="server" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%# Eval("fr_tiempo") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="fr_tipo_jornada" HeaderText="Tipo jornada" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="fr_pu_id" HeaderText="Puesto" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="estado" HeaderText="Estado" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <%--             <asp:TemplateField HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                            <HeaderTemplate>
                                                Estado
                                                <asp:DropDownList ID="ddl_gv_frec_estado" CssClass="custom-select custom-select-sm form-control form-control-sm" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="ddl_gv_frec_cargo_SelectedIndexChanged" runat="server" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_gv_frec_estado" Text='<%# Eval("estado") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <%--<asp:BoundField DataField="fr_observaciones" HeaderText="Observaciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />--%>
                                        <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:LinkButton CommandName="GetEdit" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-warning btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-edit fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Editar Frecuencia' Visible='<%# (Eval("estado").ToString() != "LIBRE" && Eval("estado").ToString() != "OCUPADO") ? false : true %>' runat="server" />
                                                <asp:LinkButton CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-google-plus btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Eliminar Frecuencia' Visible='<%# (Eval("estado").ToString() != "LIBRE" && Eval("estado").ToString() != "OCUPADO") ? false : true %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="card-body" id="d_gv_frecuencias" style="padding-top: unset;" runat="server">
                                <div class="row">
                                    <div class="col-md-12">
                                        <p class="text-sm grid-notify-success">No existen frecuencias con la categoría seleccionada. </p>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

            </div>
        </div>
        <div class="row">
            <div class="col-lg-7">
                <div class="card-wrapper">
                    <div class="card">
                        <div class="card-header">
                            <div class=" ct-page-title">
                                <h3 class="mb-0">Resumen Frecuencias</h3>
                            </div>
                        </div>

                        <div class="table-responsive py-4">
                            <asp:UpdatePanel ID="up_gv_fracuencias_resumen" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gv_fracuencias_resumen" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" OnPreRender="gv_fracuencias_resumen_PreRender" OnRowCommand="gv_fracuencias_resumen_RowCommand" DataKeyNames="fr_es_id, fr_pu_descripcion, fr_tipo_jornada, fr_fecha_inicio, fr_fecha_fin, fr_tiempo" runat="server">
                                        <Columns>
                                            <asp:BoundField DataField="es_descripcion" HeaderText="Cargo" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="fr_pu_descripcion" HeaderText="Puesto" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="fr_tipo_jornada" HeaderText="Tipo jornada" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="fr_fecha_inicio" HeaderText="Fecha inicio" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="fr_fecha_fin" HeaderText="Fecha Fin" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="fr_tiempo" HeaderText="Tiempo (Meses)" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center " />
                                            <asp:BoundField DataField="cantidad" HeaderText="Cantidad" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center display-2 dt-sub-title" />
                                            <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="120px">
                                                <ItemTemplate>
                                                    <asp:LinkButton CommandName="GetAdd" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-outline-github btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-plus fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Adicionar' runat="server" />
                                                    <asp:LinkButton CommandName="GetDel" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-outline-github btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-minus fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Eliminar' Visible="false" runat="server" />
                                                    <asp:LinkButton CommandName="GetDeleteAll" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-google-plus btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash-alt fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Eliminar Frecuencia(s)' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="card-body" id="d_gv_fracuencias_resumen" style="padding-top: unset;" runat="server">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <p class="text-sm grid-notify-success">No existen frecuencias con la categoría seleccionada. </p>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <div class="col-lg-5">
                <div class="card-wrapper">
                    <div class="card">
                        <div class="card-header" style="border: none !important">
                            <div class=" ct-page-title">
                                <h3 class="mb-0">Comprometido por Operación</h3>
                            </div>
                        </div>
                        <div class="table-responsive py-2">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gv_resumen_presup" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" OnPreRender="gv_resumen_presup_PreRender" OnRowCommand="gv_resumen_presup_RowCommand" DataKeyNames="PARTIDA" runat="server">
                                        <Columns>
                                            <asp:BoundField DataField="PARTIDA" HeaderText="Partida Presupuestaria" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="MONTO" HeaderText="Comprometido (Bs)" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:N2}" />
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="card-header" style="border: none !important">
                            <div class=" ct-page-title">
                                <h3 class="mb-0">Resumen Presupuestario General</h3>
                            </div>
                        </div>
                        <div class="table-responsive py-2">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gv_resumen_presup_gral" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" OnPreRender="gv_resumen_presup_gral_PreRender" DataKeyNames="PARTIDA" runat="server">
                                        <Columns>
                                            <asp:BoundField DataField="PARTIDA" HeaderText="Partida Presupuestaria" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="MONTO" HeaderText="Presupuesto (Bs)" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:N2}" />
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal fade" id="modalNuevaFrec" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
                <div class="modal-dialog modal- modal-dialog-centered modal-xl" role="document">
                    <div class="modal-content">
                        <div class="modal-body p-0">
                            <div class="card bg-secondary border-0 mb-0">
                                <div class="card-header">
                                    <div class="text-muted text-center mt-2 mb-3">
                                        <h4 class="header-modal">REGISTRO DE FRECUENCIA</h4>
                                    </div>
                                </div>
                                <asp:UpdatePanel ID="up_nuevaFrec" runat="server">
                                    <ContentTemplate>
                                        <div class="card-body px-lg-5 py-lg-5">
                                            <div class="pb-5 text-center">
                                                <a href="javascript:;">
                                                    <img src="../Content/img/theme/briefcase.png" alt="Circle image" class="img-fluid rounded-circle shadow" style="width: 100px;">
                                                </a>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-6 col-md-4">
                                                    <div class="form-group">
                                                        <label class="form-control-label">Cargo</label>
                                                        <%--<asp:DropDownList ID="ddl_cargo" CssClass="form-control select2" AppendDataBoundItems="true" OnSelectedIndexChanged="ddl_cargo_SelectedIndexChanged" AutoPostBack="true" runat="server" />--%>
                                                        <asp:DropDownList ID="ddl_cargo" AppendDataBoundItems="true" CssClass="form-control select2" OnSelectedIndexChanged="ddl_cargo_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_cargo" Display="Dynamic" ValidationGroup="addFrecuencia" InitialValue="0" runat="server" />

                                                    </div>
                                                </div>
                                                <div class="col-sm-6 col-md-4">
                                                    <div class="form-group">
                                                        <label class="form-control-label" for="exampleFormControlSelect1">Tipo Jornada</label>
                                                        <asp:DropDownList ID="ddl_tipo_jornada" AppendDataBoundItems="true" CssClass="form-control select2" data-minimum-results-for-search="Infinity" OnSelectedIndexChanged="ddl_tipo_jornada_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                                            <asp:ListItem Text="TIEMPO COMPLETO" Value="TC" />
                                                            <asp:ListItem Text="MEDIO TIEMPO" Value="MT" />
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_tipo_jornada" Display="Dynamic" ValidationGroup="addFrecuencia" runat="server" />

                                                    </div>
                                                </div>
                                                <div class="col-sm-6 col-md-4">
                                                    <div class="content-text-label text-green2">Haber básico (Bs)</div>
                                                    <div class="h5 font-weight-400 content-text pt-3">
                                                        <asp:Literal ID="ltl_haber_basico" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-6 col-md-4">
                                                    <div class="form-group">
                                                        <label class="form-control-label">Fecha inicio </label>
                                                        <div class="input-group input-group-merge">
                                                            <div class="input-group-prepend  ">
                                                                <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt_fecha_inicio" AutoComplete="off" class="form-control datepickerDefault" OnTextChanged="txt_fecha_inicio_TextChanged" AutoPostBack="true" runat="server" />
                                                        </div>
                                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_fecha_inicio" Display="Dynamic" ValidationGroup="addFrecuencia" runat="server" />


                                                    </div>
                                                </div>
                                                <div class="col-sm-6 col-md-4">
                                                    <div class="form-group">
                                                        <label class="form-control-label">Fecha fin</label>
                                                        <div class="input-group input-group-merge">
                                                            <div class="input-group-prepend ">
                                                                <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt_fecha_fin" AutoComplete="off" class="form-control datepickerDefault" OnTextChanged="txt_fecha_fin_TextChanged" AutoPostBack="true" runat="server" />
                                                        </div>
                                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_fecha_fin" Display="Dynamic" ValidationGroup="addFrecuencia" runat="server" />

                                                    </div>
                                                </div>

                                                <div class="col-sm-6 col-md-2">
                                                    <div class="content-text-label">Tiempo Estimado (Meses)</div>
                                                    <div class="h5 font-weight-400 content-text pt-3">
                                                        <asp:Literal ID="ltl_tiempo_estimado" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-sm-6 col-md-2">
                                                    <div class="form-group">
                                                        <label class="form-control-label" for="example4cols2Input">Cantidad</label>
                                                        <div class="input-group input-group-merge">
                                                            <div class="input-group-prepend  ">
                                                                <span class="input-group-text"><i class="fas fa-hashtag"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt_cantidad" class="form-control numero" runat="server" />
                                                        </div>
                                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_cantidad" Display="Dynamic" ValidationGroup="addFrecuencia" runat="server" />

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-6 col-md-4">
                                                    <div class="form-group">
                                                        <label class="form-control-label">Puesto</label>
                                                        <asp:DropDownList ID="ddl_puesto" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_puesto" Display="Dynamic" ValidationGroup="addFrecuencia" InitialValue="0" runat="server" />

                                                    </div>
                                                </div>
                                                <div class="col-sm-6 col-md-8">
                                                    <div class="form-group">
                                                        <label class="form-control-label">Objetivo</label>
                                                        <div class="input-group input-group-merge">
                                                            <div class="input-group-prepend  ">
                                                                <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt_objetivo" class="form-control" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row pt-3">
                                                <div class="col-sm-6 col-md-6">
                                                    <asp:LinkButton ID="btn_adicionar_frecuencia" Text="<i class='fas fa-save mr-2'></i>Guardar" ValidationGroup="addFrecuencia" CssClass="btn btn-success btn-block" OnClick="btn_adicionar_frecuencia_Click" runat="server" />
                                                </div>
                                                <div class="col-sm-6 col-md-6">
                                                    <asp:LinkButton ID="btn_cancelar_frecuencia" class="btn btn-outline-github btn-block" Text="<i class='fas fa-times mr-2'></i>Cancelar" OnClick="btn_cancelar_frecuencia_Click" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <asp:HiddenField ID="hf_haber_basico" runat="server" />
                                        <asp:HiddenField ID="hf_fr_id" runat="server" />
                                        <asp:HiddenField ID="hf_editar_fr" runat="server" />
                                        <asp:HiddenField ID="hf_tipo_jornada_edit" runat="server" />
                                        <asp:HiddenField ID="hf_tiempo_edit" runat="server" />
                                        <asp:HiddenField ID="hf_hb_edit" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="eliminarFrecuencia" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
        <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
            <div class="modal-content bg-gradient-dark6">
                <div class="modal-header">
                </div>

                <asp:UpdatePanel ID="up_eilminar_frec" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div class="py-3 text-center">
                                <i class="ni ni-fat-remove ni-3x"></i>
                                <h4 class="heading text-dark mt-4">¿Esta seguro de eliminar la Frecuencia?</h4>
                            </div>
                        </div>
                        <div class="form-group text-center">
                            <asp:LinkButton ID="btn_eilminar_frec" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btn_eilminar_frec_Click" runat="server" />
                            <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div class="modal fade" id="objetivoFrecuencia" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
        <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
            <div class="modal-content bg-gradient-dark6">
                <div class="modal-header">
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div class="py-3 text-center">
                                <i class="ni ni-single-copy-04 ni-3x"></i>
                                <h4 class="heading text-dark mt-4">Replicar Frecuencia</h4>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 col-md-12">
                                    <div class="form-group">
                                        <label class="form-control-label">Objetivo</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend  ">
                                                <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                            </div>
                                            <asp:TextBox ID="txt_obj" TextMode="multiline" Rows="4" class="form-control" runat="server" />
                                        </div>
                                         <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_obj" Display="Dynamic" ValidationGroup="repFrecuencia" runat="server" />
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="form-group text-center">
                            <asp:LinkButton ID="btn_confirmar_replica" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btn_confirmar_replica_Click" ValidationGroup="repFrecuencia" runat="server" />
                            <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div class="modal fade" id="eliminarFrecuenciaAll" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
        <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
            <div class="modal-content bg-gradient-dark6">
                <div class="modal-header">
                </div>

                <asp:UpdatePanel ID="up_eliminar_frec_all" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div class="py-3 text-center">
                                <i class="ni ni-fat-remove ni-3x"></i>
                                <h4 class="heading text-dark mt-4">¿Esta seguro de eliminar la(s) Frecuencia(s)?</h4>
                            </div>
                        </div>
                        <div class="form-group text-center">
                            <asp:LinkButton ID="btn_eliminar_frec_all" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btn_eliminar_frec_all_Click" runat="server" />
                            <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                        </div>
                        <asp:HiddenField ID="hf_fr_es_id" runat="server" />
                        <asp:HiddenField ID="hf_fr_pu_id" runat="server" />
                        <asp:HiddenField ID="hf_fr_tipo_jornada" runat="server" />
                        <asp:HiddenField ID="hf_fr_fecha_inicio" runat="server" />
                        <asp:HiddenField ID="hf_fr_fecha_fin" runat="server" />
                        <asp:HiddenField ID="hf_fr_tiempo" runat="server" />
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
                            <p class="text-sm mb-0 mt-5 mb-3">Por favor seleccione al usuario que desea enviar las frecuencias creadas. </p>
                            <asp:UpdatePanel ID="up_btn_confirmar_envio" runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label class="form-control-label">Usuario</label>
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
    <asp:UpdateProgress ID="up" AssociatedUpdatePanelID="up_gv_frecuencias" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress ID="up2" AssociatedUpdatePanelID="up_eilminar_frec" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress ID="up3" AssociatedUpdatePanelID="up_gv_fracuencias_resumen" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress ID="up4" AssociatedUpdatePanelID="up_btn_confirmar_envio" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress ID="up5" AssociatedUpdatePanelID="up_eliminar_frec_all" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress ID="up6" AssociatedUpdatePanelID="up_nuevaFrec" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress ID="up7" AssociatedUpdatePanelID="up_btn_enviar_planilla" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>


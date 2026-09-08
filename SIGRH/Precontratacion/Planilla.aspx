<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="Planilla.aspx.cs" Inherits="Precontrataciones_Planilla" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Creación de Pre-Contratos</h6>
                    </div>
                    <div class="col-lg-6 col-5 text-right">
                        <asp:UpdatePanel ID="up_btn_adic_nueva_frec" runat="server">
                            <ContentTemplate>
                                <asp:LinkButton ID="btn_adic_nueva_frec" CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-inst text-white rounded-circle shadow" Text="<i class='fas fa-business-time'></i>" data-toggle="tooltip" data-original-title="Adicionar Frecuencia" OnClick="btn_adic_nueva_frec_Click" runat="server" />
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
                    <div class="card-header d-flex align-items-center border-0">
                        <div class="d-flex align-items-center">
                            <div class="text-dark font-weight-600 text-sm">
                            
                           <h3 class="mb-0" style="display: inline-flex; color: #727b87"><i class="fas fa-list-alt icon-h" style="font-size: 27px; min-width: 2.4rem;"></i> Detalle Planilla</h3>
                         
                            </div>
                        </div>
                        <div class="text-right ml-auto">
                            <asp:UpdatePanel ID="up_btn_enviar_planilla" runat="server">
                                <ContentTemplate>
                                    <asp:LinkButton ID="btn_enviar_planilla" CssClass="btn btn-slack btn-round btn-icon" data-toggle="tooltip" data-original-title="Enviar Planilla" Text="<span class='btn-inner--icon'><i class='fas fa-share-alt'></i></span><span class='btn-inner--text'>Enviar</span>" OnClick="btn_enviar_planilla_Click" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="card-body" style="padding-bottom: unset; padding-top: unset;">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="row" style="padding-left: 2.4rem;">
                                    <div class="col-lg-2">
                                        <div class="content-text-label">Código</div>
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
                    <div class="table-responsive pt-4 pb-5">
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
                                        <asp:TemplateField HeaderText="<i class='ni ni-settings-gear-65 ni-2x'></i>" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="40px">
                                            <ItemTemplate>
                                                <div class="dropdown">
                                                    <a class="btn btn-outline-github btn-sm btn-icon-only " href="#" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                        <i class="fas fa-ellipsis-v"></i>
                                                    </a>
                                                    <div class="dropdown-menu dropdown-menu-right dropdown-menu-arrow" style="">
                                                        <asp:LinkButton CommandName="GetAssign" CommandArgument="<%# Container.DataItemIndex %>" CssClass="dropdown-item" Text="<i class='fas fa-user-edit'></i><span>Asignar</span>" Visible='<%# Eval("acefalo").ToString() != "0" ? true : false %>' runat="server" />
                                                        <asp:LinkButton CommandName="GetEdit" CommandArgument="<%# Container.DataItemIndex %>" CssClass="dropdown-item" Text="<i class='fas fa-user-edit'></i><span>Modificar Asignación</span>" Visible='<%# Eval("acefalo").ToString() != "0" ? false : true %>' runat="server" />
                                                           <asp:LinkButton CommandName="GetEditP" CommandArgument="<%# Container.DataItemIndex %>" CssClass="dropdown-item" Text="<i class='fas fa-briefcase'></i><span>Editar Puesto</span>" runat="server" />
                                                        <asp:LinkButton CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="dropdown-item" Text="<i class='fas fa-trash-alt'></i><span>Eliminar Pre-Contrato</span>" runat="server" />
                                                     
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
        <div class="modal fade" id="modalAdicionarFrec" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none; overflow-y: auto" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog modal- modal-dialog-centered modal-xl" role="document">
                <div class="modal-content">

                    <div class="modal-body p-0">
                        <div class="card bg-secondary border-0 mb-0">
                            <div class="card-header">
                                <div class="text-muted text-center mt-2 mb-3">
                                    <h4 class="header-modal">ADICIÓN DE FRECUENCIA</h4>
                                </div>

                            </div>
                            <div class="card-body py-lg-4">

                                <div class="ct-page-title">
                                    <h4 class="h3 text-uppercase" style="margin-bottom: unset;">Categorías</h4>
                                    <p class="description" style="margin-bottom: 0.5rem;">Las categorías mostradas pertenecen a la Unidad Ejecutora, seleccione para ver las frecuencias libres.</p>
                                </div>
                                <div class="table-responsive py-2">
                                    <asp:UpdatePanel ID="up_gv_categorias" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gv_categorias" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_categorias_PreRender" OnRowCommand="gv_categorias_RowCommand" DataKeyNames="cp_id" runat="server">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                                        <ItemTemplate>
                                                            <label class="custom-toggle custom-toggle-yout">
                                                                <asp:CheckBox ID="chk_cp" OnCheckedChanged="chk_cp_CheckedChanged" AutoPostBack="true" runat="server" />
                                                                <span class="custom-toggle-slider rounded-circle" data-label-off="No" data-label-on="Si" data-toggle='tooltip' data-placement='top' title='Ver Frecuencias Libres'></span>
                                                            </label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="cp_da" HeaderText="DA" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" />
                                                    <asp:BoundField DataField="cp_ue" HeaderText="UE" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" />
                                                    <asp:BoundField DataField="cp_programa" HeaderText="PROG" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" />
                                                    <asp:BoundField DataField="cp_proyecto" HeaderText="PROY" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" />
                                                    <asp:BoundField DataField="cp_actividad" HeaderText="ACT" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" />
                                                    <asp:BoundField DataField="cp_descripcion" HeaderText="DESCRIPCIÓN PRESUPUESTO" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-left" />
                                                    <asp:BoundField DataField="cp_fuente" HeaderText="FUENTE" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" />
                                                    <asp:BoundField DataField="cp_organismo" HeaderText="ORIGEN" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" />
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div id="no_existe_cat" class="row" runat="server">
                                            <div class="col-md-12">
                                                <p class="text-sm grid-notify-success">No existe categorías disponibles.</p>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <asp:UpdatePanel ID="up_btn_adicionar_fr_masivo" runat="server">
                                    <ContentTemplate>
                                        <div id="no_existe_frec_t" class="ct-page-title" runat="server">
                                            <h4 class="h3 text-uppercase" style="margin-bottom: unset;">Frecuencias libres</h4>
                                            <p class="description" style="margin-bottom: 0.5rem;">Frecuencias libres de la categoría seleccionada.</p>
                                        </div>

                                        <div id="masivo_frec" class="row" runat="server">
                                            <div class="col-lg-7">
                                            </div>

                                            <div class="col-lg-3 text-center">
                                                <div class="display-2 " style="color: #525252">
                                                    <asp:Literal ID="ltl_cantidad" runat="server" />
                                                </div>
                                                <span class="pt-4 " style="color: #909090">
                                                    <asp:Literal ID="ltl_cantidad_desc" runat="server" />

                                                </span>
                                            </div>

                                            <div class="col-lg-2">
                                                <div class="form-group">
                                                    <label class="form-control-label">&nbsp</label>
                                                    <asp:LinkButton ID="btn_adicionar_fr_masivo" CssClass="btn btn-slack btn-block" Text="<i class='fas fa-share'></i> Adicionar" OnClick="btn_adicionar_fr_masivo_Click" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="table-responsive py-2">
                                    <asp:UpdatePanel ID="up_gv_frecuencias" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gv_frecuencias" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_frecuencias_PreRender" OnRowCommand="gv_frecuencias_RowCommand" DataKeyNames="fr_id, fr_es_id" runat="server">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-CssClass="text-center">
                                                        <HeaderTemplate>
                                                            <span class="badge badge-lg badge-darkerw">Todos</span>
                                                            <label class="custom-toggle custom-toggle-dark">
                                                                <asp:CheckBox ID="chk_frec_all" OnCheckedChanged="chk_frec_all_CheckedChanged" AutoPostBack="true" runat="server" />
                                                                <span class="custom-toggle-slider rounded-circle" data-label-off="No" data-label-on="Si" data-toggle='tooltip' data-placement='top' title='Marcar todos'></span>
                                                            </label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <label class="custom-toggle custom-toggle-yout">
                                                                <asp:CheckBox ID="chk_frec" OnCheckedChanged="chk_frec_CheckedChanged" AutoPostBack="true" runat="server" />
                                                                <span class="custom-toggle-slider rounded-circle" data-label-off="No" data-label-on="Si" data-toggle='tooltip' data-placement='top' title='Marcar'></span>
                                                            </label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                          <asp:BoundField DataField="fr_id" HeaderText="Cod. Frec." HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                                        <HeaderTemplate>
                                                            CARGO
                                                             <asp:DropDownList ID="ddl_gv_frec_cargo" CssClass="custom-select custom-select-sm form-control form-control-sm" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="ddl_gv_frec_cargo_SelectedIndexChanged" runat="server" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%# Eval("es_descripcion") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                                        <HeaderTemplate>
                                                            Puesto
                                                             <asp:DropDownList ID="ddl_gv_frec_puesto" CssClass="custom-select custom-select-sm form-control form-control-sm" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="ddl_gv_frec_puesto_SelectedIndexChanged" runat="server" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%# Eval("pu_descripcion") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="haber_basico" HeaderText="Haber básico (Bs)" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:0.00}" />
                                                    <asp:BoundField DataField="fr_fecha_inicio" HeaderText="Fecha inicio" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                    <asp:BoundField DataField="fr_fecha_fin" HeaderText="Fecha fin" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-bold">
                                                        <HeaderTemplate>
                                                            Tiempo Disponible (Meses)
                                                             <asp:DropDownList ID="ddl_gv_frec_tiempo" CssClass="custom-select custom-select-sm form-control form-control-sm" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="ddl_gv_frec_tiempo_SelectedIndexChanged" runat="server" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%# Eval("tiempo") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="fr_tipo_jornada" HeaderText="Tipo Jornada" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />

                                                    <asp:TemplateField HeaderText="" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                                        <ItemTemplate>
                                                            <asp:LinkButton CommandName="GetAssign" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-success btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-share fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Adicionar Frecuencia' runat="server" />

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div id="no_existe_frec" class="row" runat="server">
                                            <div class="col-md-12">
                                                <p class="text-sm grid-notify-success">
                                                    <asp:Literal ID="ltl_msj_no_existe_frec" runat="server" />
                                                </p>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>

                            <div class="form-group text-center">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="btn_cerrar_categorias" OnClick="btn_cerrar_categorias_Click" Text="<i class='fas fa-times mr-2'></i>Cancelar" CssClass="btn btn-outline-github" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>


                </div>
            </div>
        </div>
        <div class="modal fade" id="modalAdicionarFrecPost" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none; overflow-y: auto;" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog modal- modal-dialog-centered modal-xl" role="document">
                <div class="modal-content">
                    <div class="modal-body p-0">
                        <div class="card bg-secondary border-0 mb-0">
                            <div class="card-header">
                                <div class="text-muted text-center mt-2 mb-3">
                                    <h4 class="header-modal">ADICIÓN DE FRECUENCIA A PLANILLA</h4>
                                </div>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="card-body px-lg-5 pb-lg-5">
                                        <div class="row pb-4">

                                            <div class="col-lg-12 text-center">
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <div class="display-2 " style="color: #4385b1">
                                                            <asp:Literal ID="ltl_cantidad_post" runat="server" />
                                                        </div>
                                                        <span class="pt-4 " style="color: #909090">
                                                            <asp:Literal ID="ltl_cantidad_desc_post" runat="server" />
                                                        </span>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>

                                        <h6 class="heading-small text-muted d-inline-flex icon-title-h"><i class="fas fa-briefcase icon-h"></i>Datos de la Frecuencia</h6>
                                        <div class="icon-content-h">
                                            <div class="row">
                                                <div class="col-lg-3">
                                                    <div class="content-text-label">Cargo</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_cargo" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="content-text-label text-green2">Haber básico (Bs)</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_hb" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="content-text-label">Tiempo (Meses)</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_tiempo" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="content-text-label">Tipo Jornada</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_tipo_jornada" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-7">
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
                                                    <div class="content-text-label">PROG</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_prog" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-1">
                                                    <div class="content-text-label">PROY</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_proy" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-1">
                                                    <div class="content-text-label">ACT</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_act" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <hr class="mt-3 mb-3">
                                        <h6 class="heading-small text-muted d-inline-flex icon-title-h"><i class="fas fa-bookmark icon-h"></i>Datos de la Pre-Contratación</h6>
                                        <div class="icon-content-h">
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
                                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_objetivo" Display="Dynamic" ValidationGroup="addFrecuencia" runat="server" />

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
                                                            <asp:TextBox ID="txt_tareas" class="form-control" TextMode="multiline" Rows="7" runat="server" />
                                                        </div>
                                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_tareas" Display="Dynamic" ValidationGroup="addFrecuencia" runat="server" />

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row pt-3">
                                                <div class="col-sm-6 col-md-6">
                                                    <asp:LinkButton ID="btn_adicionar_frecuencia" CssClass="btn btn-success btn-block" Text="<i class='fas fa-file-import mr-2'></i>Adicionar a Planilla" ValidationGroup="addFrecuencia" OnClick="btn_adicionar_frecuencia_Click" OnClientClick="if (Page_ClientValidate('addFrecuencia')) { MostrarMascara(true); }" runat="server" />
                                                </div>
                                                <div class="col-sm-6 col-md-6">
                                                    <asp:LinkButton ID="btn_cancelar_frecuencia" class="btn btn-outline-github btn-block" Text="<i class='fas fa-times mr-2'></i>Cancelar" OnClick="btn_cancelar_frecuencia_Click" OnClientClick="MostrarMascara(true)" runat="server" />
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

                        </div>
                    </div>

                </div>
            </div>
        </div>

        <div class="modal fade" id="modalModificarPuesto" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog modal- modal-dialog-centered modal-xl" role="document">
                <div class="modal-content">
                    <div class="modal-body p-0">
                        <div class="card bg-secondary border-0 mb-0">
                            <div class="card-header">
                                <div class="text-muted text-center mt-2 mb-3"> <h4 class="header-modal">EDICIÓN DE PUESTO</h4></div>
                            </div>
                            <asp:UpdatePanel ID="up_btn_modificar_puesto" runat="server">
                                <ContentTemplate>
                                    <div class="card-body px-lg-5 pb-lg-5">

                                                       <h6 class="heading-small text-muted d-inline-flex icon-title-h"><i class="fas fa-bookmark icon-h"></i>Datos de la Pre-Contratación</h6>
                                        <div class="icon-content-h">
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
                                                                       <div class="row pt-3">
                                                <div class="col-sm-6 col-md-6">
                                                     <asp:LinkButton ID="btn_modificar_puesto" Text="<i class='fas fa-save mr-2'></i>Guardar" ValidationGroup="addPuesto" CssClass="btn btn-success btn-block" OnClick="btn_modificar_puesto_Click" runat="server" />
                                                </div>
                                                <div class="col-sm-6 col-md-6">
                                                                            <asp:LinkButton ID="btn_cancelar_puesto" class="btn btn-outline-github btn-block" Text="<i class='fas fa-times mr-2'></i>Cancelar" OnClick="btn_cancelar_puesto_Click" runat="server" />
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
        <div class="modal fade" id="anularAsignacion" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
            <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                <div class="modal-content bg-gradient-dark6">
                    <div class="modal-header">
                    </div>

                    <asp:UpdatePanel ID="up_anular_asig" runat="server">
                        <ContentTemplate>
                            <div class="modal-body">
                                <div class="py-3 text-center">
                                    <i class="ni ni-fat-remove ni-3x"></i>
                                    <h4 class="heading text-dark mt-4">¿Está seguro de anular la asignación?</h4>
                                </div>
                            </div>
                            <div class="form-group text-center">
                                <asp:LinkButton ID="btn_anular_asig" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btn_anular_asig_Click" runat="server" />
                                <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div class="modal fade" id="eliminarPrecontrato" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
            <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                <div class="modal-content bg-gradient-dark6">
                    <div class="modal-header">
                    </div>

                    <asp:UpdatePanel ID="up_btn_eilminar_pre" runat="server">
                        <ContentTemplate>
                            <div class="modal-body">
                                <div class="py-3 text-center">
                                    <i class="ni ni-fat-remove ni-3x"></i>
                                    <h4 class="heading text-dark mt-4">¿Esta seguro de eliminar el Pre-Contrato?</h4>
                                </div>
                            </div>
                            <div class="form-group text-center">
                                <asp:LinkButton ID="btn_eilminar_pre" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btn_eilminar_pre_Click" runat="server" />
                                <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
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
                                            <asp:LinkButton ID="btn_limpiar" Text="Limpiar" CssClass="btn btn-sm btn-default float-right" OnClick="btn_limpiar_Click" runat="server" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="card-body pt-0">
                                <asp:UpdatePanel ID="up_datos_personales" runat="server">
                                    <ContentTemplate>
                                        <div class="text-center pt-4">
                                            <h5 class="h3" style="margin-bottom: unset; color: #030303 !important">
                                                <asp:Literal ID="ltl_cargo_ocupado" runat="server" />
                                            </h5>
                                            <small class="text-muted font-weight-bold text-uppercase">Cargo</small>
                                        </div>
                                        <div class="mb-1">
                                            <div class="media media-comment" style="margin-top: 0.8rem">

                                                <div class="media-body">
                                                    <div class="media-comment-text" style="padding-left: 1.25rem; background-color: #E5FAFC;">
                                                        <h6 class="heading-small text-muted mb-2">Datos de la Frecuencia</h6>
                                                        <div class="row">
                                                            <div class="col-lg-5">
                                                                <div class="content-text-label">Puesto</div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_puesto_ocupado" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-3">
                                                                <div class="content-text-label">Tipo Jornada</div>
                                                                <div class="h5 font-weight-400 content-text text-uppercase">
                                                                    <asp:Literal ID="ltl_tipo_jornada_ocupado" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-4">
                                                                <div class="content-text-label">Tiempo Disponible (meses)</div>
                                                                <p class="text-sm">
                                                                    <span class="text-success mr-2"><i class="fas fa-calendar-alt"></i></span>
                                                                    <span class="text-nowrap font-weight-bold">
                                                                        <asp:Literal ID="ltl_tiempo_libre" runat="server" /></span>
                                                                </p>
                                                            </div>
                                                        </div>
                                                        <div class="row" style="display: none">
                                                            <div class="col-lg-4">
                                                                <div class="content-text-label">Fecha Inicio</div>
                                                                <p class="text-sm">
                                                                    <span class="text-success mr-2"><i class="fas fa-calendar-check"></i></span>
                                                                    <span class="text-nowrap font-weight-bold">
                                                                        <asp:Literal ID="ltl_fr_tiempo_inicio" runat="server" /></span>
                                                                </p>
                                                            </div>
                                                            <div class="col-lg-4">
                                                                <div class="content-text-label">Fecha Fin</div>

                                                                <p class="text-sm">
                                                                    <span class="text-success mr-2"><i class="fas fa-calendar-check"></i></span>
                                                                    <span class="text-nowrap font-weight-bold">
                                                                        <asp:Literal ID="ltl_fr_tiempo_fin" runat="server" /></span>
                                                                </p>
                                                            </div>


                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="table-responsive py-2">
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="gv_persona" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_persona_PreRender" OnRowCommand="gv_persona_RowCommand" DataKeyNames="per_id" runat="server">
                                                        <Columns>
                                                            <asp:BoundField DataField="per_ap_paterno" HeaderText="Ap. Paterno" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-left" />
                                                            <asp:BoundField DataField="per_ap_materno" HeaderText="Ap. Materno" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-left" />
                                                            <asp:BoundField DataField="per_nombres" HeaderText="Nombre(s)" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-left" />
                                                            <asp:BoundField DataField="per_ap_casada" HeaderText="Ap. Casada" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-left" />
                                                            <asp:BoundField DataField="per_num_doc" HeaderText="CI" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                            <asp:TemplateField HeaderText="" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton CommandName="GetAssign" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-success btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-hand-point-left fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Elegir' runat="server" />

                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <h6 class="heading-small text-muted mb-2">Datos personales</h6>
                                        <div class="row">
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label class="form-control-label">carnet de identidad</label>
                                                    <asp:TextBox ID="txt_ci" AutoComplete="off" CssClass="form-control form-control-sm" OnTextChanged="txt_ci_TextChanged" AutoPostBack="true" runat="server" />
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_ci" ValidationGroup="addFuncionario" runat="server" />

                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label class="form-control-label">Ap. Paterno</label>
                                                    <asp:TextBox ID="txt_pre_paterno" AutoComplete="off" CssClass="form-control form-control-sm" OnTextChanged="txt_pre_paterno_TextChanged" AutoPostBack="true" runat="server" />
                                                    <%--<asp:RequiredFieldValidator ID="rfv_txt_pre_paterno" CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_pre_paterno" ValidationGroup="addFuncionario" runat="server" />--%>
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label class="form-control-label">Ap. Materno</label>
                                                    <asp:TextBox ID="txt_pre_materno" AutoComplete="off" CssClass="form-control form-control-sm" OnTextChanged="txt_pre_paterno_TextChanged" AutoPostBack="true" runat="server" />
                                                    <%--<asp:RequiredFieldValidator ID="rfv_txt_pre_materno" CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_pre_materno" ValidationGroup="addFuncionario" runat="server" />--%>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label class="form-control-label">Nombre(s)</label>
                                                    <asp:TextBox ID="txt_pre_nombres" AutoComplete="off" CssClass="form-control form-control-sm" OnTextChanged="txt_pre_paterno_TextChanged" AutoPostBack="true" runat="server" />
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_pre_nombres" ValidationGroup="addFuncionario" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label class="form-control-label">Ap. Casada</label>
                                                    <asp:TextBox ID="txt_pre_ap_casada" AutoComplete="off" CssClass="form-control form-control-sm" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label class="form-control-label">Sexo / Género</label>
                                                    <asp:DropDownList ID="ddl_pre_genero" CssClass="form-control form-control-sm select2" AppendDataBoundItems="true" data-minimum-results-for-search="Infinity" runat="server" />
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
                                      
                                                                                    <div id="d_tipo_item_1" class="col-lg-4" runat="server">
                                                <div class="form-group">
                                                    <label class="form-control-label">Fecha validez djbr</label>
                                                    <asp:TextBox ID="txt_fecha_djbr" AutoComplete="off" class="form-control form-control-sm datepickerDefault" runat="server" />
                                                </div>
                                            </div>
                                  
                                        </div>
                                        <h6 class="heading-small text-muted mt-4 mb-2">Datos Pre-contratación </h6>
                                        <div class="row">
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label class="form-control-label">Fecha Inicio</label>
                                                    <asp:TextBox ID="txt_pre_fecha_asig" AutoComplete="off" class="form-control form-control-sm datepickerDefault" OnTextChanged="txt_pre_fecha_asig_TextChanged" AutoPostBack="true" runat="server" />
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_pre_fecha_asig" ValidationGroup="addFuncionario" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label class="form-control-label">Fecha Fin</label>
                                                    <asp:TextBox ID="txt_pre_fecha_baja" AutoComplete="off" class="form-control form-control-sm datepickerDefault" OnTextChanged="txt_pre_fecha_baja_TextChanged" AutoPostBack="true" runat="server" />
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_pre_fecha_baja" ValidationGroup="addFuncionario" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4 text-info">
                                                <div class="content-text-label pt-2">Tiempo calculado (MESES) </div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_pre_tiempo_calculo" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div id="d_tipo_item" class="row" runat="server">
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label class="form-control-label">Tipo de ítem</label>
                                                    <asp:DropDownList ID="ddl_tipo_item" CssClass="form-control form-control-sm select2" AppendDataBoundItems="true" data-minimum-results-for-search="Infinity" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label class="form-control-label">Número ítem</label>
                                                    <asp:TextBox ID="txt_pre_numero_item" CssClass="form-control form-control-sm numero" runat="server" />
                                                </div>
                                            </div>
                                                                               <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label class="form-control-label">Fecha validez sippase</label>
                                                    <asp:TextBox ID="txt_fecha_sipasse" AutoComplete="off" class="form-control form-control-sm datepickerDefault" runat="server" />
                                                </div>
                                            </div>

                                        </div>
                                        <div class="row mt-2">
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
                                                    <label class="form-control-label">Usuario</label>
                                                    <asp:DropDownList ID="ddl_usuarios" CssClass="form-control select2" AppendDataBoundItems="true" data-minimum-results-for-search="Infinity" runat="server"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_usuarios" Display="Dynamic" ValidationGroup="addEnvio" InitialValue="0" runat="server" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row mt-2">
                                            <div class="col-md-6">
                                                <asp:LinkButton ID="btn_confirmar_envio" CssClass="btn btn-block btn-success btn-round btn-icon" Text="<span class='btn-inner--icon'><i class='fas fa-check'></i></span><span class='btn-inner--text'>Aceptar</span>" OnClick="btn_confirmar_envio_Click" ValidationGroup="addEnvio" runat="server" />
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

        <asp:UpdateProgress ID="up" AssociatedUpdatePanelID="up_btn_adic_nueva_frec" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up1" AssociatedUpdatePanelID="up_gv_categorias" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>

        <asp:UpdateProgress ID="up2" AssociatedUpdatePanelID="up_btn_adicionar_fr_masivo" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up3" AssociatedUpdatePanelID="up_gv_frecuencias" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>

        <asp:UpdateProgress ID="up5" AssociatedUpdatePanelID="up_gv_planilla" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up6" AssociatedUpdatePanelID="up_btn_eilminar_pre" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up7" AssociatedUpdatePanelID="up_datos_personales" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up8" AssociatedUpdatePanelID="up_btn_enviar_planilla" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up9" AssociatedUpdatePanelID="up_btn_confirmar_envio" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up10" AssociatedUpdatePanelID="up_anular_asig" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up11" AssociatedUpdatePanelID="up_btn_modificar_puesto" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up12" AssociatedUpdatePanelID="up_confirmar_val" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>

</asp:Content>


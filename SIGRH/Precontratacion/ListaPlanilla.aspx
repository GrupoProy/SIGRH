<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ListaPlanilla.aspx.cs" Inherits="Precontratacion_ListaPlanilla" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Creación de Planilla(s)</h6>
                    </div>
                    <div class="col-lg-6 col-5 text-right">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:LinkButton ID="btn_nueva_planilla" OnClick="btn_nueva_planilla_Click" CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-inst text-white rounded-circle shadow" Text="<i class='fas fa-plus'></i>" data-toggle="tooltip" data-original-title="Crear Planilla" runat="server" />

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid mt--6">
        <div class="row justify-content-center">
            <div class="col-lg-9 card-wrapper ct-example">
                <div class="card">
                    <div class="card-header d-flex align-items-center">
                        <div class="d-flex align-items-center">
                            <div class="text-dark font-weight-600 text-sm">
                                <div class=" ct-page-title">
                                    <h3 class="mb-0">Lista de planillas</h3>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <p class="text-sm mb-0">
                                                <asp:Literal ID="ltl_desc_gestion" Text="" runat="server" />
                                            </p>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <!-- Form groups used in grid -->
                        <asp:UpdatePanel ID="panelBuscar" runat="server">
                            <ContentTemplate>
                                <asp:Panel DefaultButton="btn_buscar_planilla" runat="server">

                                    <div class="row">
                                        <div class="col-sm-6 col-md-3">
                                            <div class="form-group">
                                                <label class="form-control-label">Código Planilla</label>
                                                <div class="input-group input-group-merge">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text"><i class="fas fa-file-alt"></i></span>
                                                    </div>
                                                    <asp:TextBox ID="txt_cod" class="form-control numero" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6 col-md-3">
                                            <div class="form-group">
                                                <label class="form-control-label" for="example4cols2Input">UE</label>
                                                <small>(Unidad Ejecutora)</small>
                                                <div class="input-group input-group-merge">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text"><i class="fas fa-layer-group"></i></span>
                                                    </div>
                                                    <asp:TextBox ID="txt_ue" class="form-control numero" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6 col-md-3">
                                            <div class="form-group">
                                                <label class="form-control-label">Estado</label>
                                                <asp:DropDownList ID="ddl_estado" CssClass="form-control select2" AppendDataBoundItems="true" data-minimum-results-for-search="Infinity" runat="server" />

                                            </div>
                                        </div>
                                        <div class="col-sm-6 col-md-3">
                                            <div class="form-group">
                                                <label class="form-control-label">&nbsp</label>
                                                <asp:LinkButton ID="btn_buscar_planilla" CssClass="btn btn-info btn-block" Text="<i class='fas fa-search'></i> Buscar" OnClick="btn_buscar_planilla_Click" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <%--                    <div class="table-responsive py-4" id="grillaPlanillas">
                        <asp:UpdatePanel ID="up_gv_items" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gv_planillas" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_planillas_PreRender" OnRowCommand="gv_planillas_RowCommand" DataKeyNames="pl_id" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="pl_ue" HeaderText="UE" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="pl_id" HeaderText="Código Planilla" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="pc_estado" HeaderText="Estado" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="pl_observaciones" HeaderText="Observaciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="cantidad" HeaderText="Cantidad Pre-contratados" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" />
                                        <asp:BoundField DataField="fecha_creacion" HeaderText="Fecha Creación" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />

                                        <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:LinkButton CommandName="GetAssign" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-warning btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-sign-in-alt fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Ver detalle Planilla' runat="server" />
                                                <asp:LinkButton CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-google-plus btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Eliminar Planilla' runat="server" />

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>--%>



                    <div class="card-body" style="padding-top: unset">
                        <!-- List group -->
                        <ul class="list-group list-group-flush list my--3">
                            <asp:UpdatePanel ID="up_lv_planilla" runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-12 text-center">
                                            <div class="list-view-item-title-cont">
                                                Nro. de registros:
                                                <asp:Literal ID="ltl_total_reg" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                    </div>
                                    <asp:ListView ID="lv_planilla" ClientIDMode="AutoID" OnItemCommand="lv_planilla_ItemCommand" DataKeyNames="pl_id, pl_ue, pl_estado" runat="server">
                                        <ItemTemplate>

                                            <li class="list-group-item px-0 lv-item" style="margin-bottom: 0px" runat="server">
                                                <div class="row align-items-center px-3">

                                                    <div class="col-12 ml--2">
                                                        <asp:LinkButton ID="tDatail" CommandName="GetAssign" CommandArgument="<%# Container.DataItemIndex %>" runat="server">
                                                        <h2 class="mb-0 list-view-item-title-i">Planilla <%# Eval("pl_id") %> </h2>
                                                        </asp:LinkButton>
                                                    </div>

                                                </div>
                                                <div class="row align-items-center px-3">
                                                    <div class="col-10">
                                                        <asp:LinkButton ID="tDatail1" CommandName="GetAssign" CommandArgument="<%# Container.DataItemIndex %>" data-toggle='tooltip' data-placement='top' title='Ver Planilla' runat="server">
                                                            <%--                            <div class="row ">
                                                            <div class="col-8">
                                                                <div class="row mt-2">
                                                                    <div class="col-5 list-view-item-title">Cantidad Pre-Contratados:</div>
                                                                    <div class="col-7">
                                                                        <small class="list-view-item-desc"><%# Eval("cantidad") %></small>
                                                                    </div>
                                                                </div>
                                             
                                                                <div class="row">
                                                                    <div class="col-5 list-view-item-title">Unidad Ejecutora:</div>
                                                                    <div class="col-7">
                                                                        <small class="list-view-item-desc"><%# Eval("ue") %></small>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-4">
                                                                <div class="row mt-2">
                                                                    <div class="col-6 list-view-item-title">Fecha creación:</div>
                                                                    <div class="col-6 list-view-item-desc">
                                                                        <small class="list-view-item-desc"><%# Eval("fecha_creacion") %></small>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-6 list-view-item-title">Estado: </div>
                                                                    <div class="col-6">
                                                                        <small class="list-view-item-desc"><%# Eval("pc_estado") %></small>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>--%>
                                                            <div class="row flex-nowrap">
                                                                <div class="list-view-item-title" style="color: #0090C5;">Cantidad Pre-Contratados: </div>
                                                                <div class="list-view-item-desc"><%# Eval("cantidad") %></div>
                                                            <%--     <span class="badge badge-list-view badge-pill"><%# Eval("cantidad") %></span>--%>
                                                            </div>
                                                            <div class="row flex-nowrap">
                                                                <div class="list-view-item-title">Unidad Ejecutora: </div>
                                                                <div class="list-view-item-desc"><%# Eval("pl_ue") + " - " + Eval("ue") %></div>
                                                            </div>
                                                            <div class="row flex-nowrap">
                                                                <div class="list-view-item-title">Fecha Creación: </div>
                                                                <div class="list-view-item-desc"><%# Eval("fecha_creacion") %></div>
                                                            </div>
                                                            <div class="row flex-nowrap">
                                                                <div class="list-view-item-title">Estado: </div>
                                                                <%--<div  class="list-view-item-desc"><%# Eval("pl_estado") %></div>--%>
                                                                <div class="list-view-item-desc">
                                                                    <asp:Label ID="ltl_estado" CssClass='<%# (Eval("pl_estado").ToString() == "ENVIADO") ? "text-info font-weight-bold" : (Eval("pl_estado").ToString() == "APROBADO") ? "text-success font-weight-bold" :  (Eval("pl_estado").ToString() == "VALIDADO") ? "text-vimeo font-weight-bold" : (Eval("pl_estado").ToString() == "AJUSTAR") ? "text-warning font-weight-bold" : (Eval("pl_estado").ToString() == "ANULADO") ? "text-light4 font-weight-bold" :"list-view-item-desc" %>' Text='<%# Eval("pl_estado") %>' runat="server" />
                                                                </div>
                                                            </div>
                                                        </asp:LinkButton>
                                                    </div>
                                                    <div class="col-2 text-center">
                                                        <asp:LinkButton ID="tDescripP" CommandName="GetDetailPuestos" CommandArgument="<%# Container.DataItemIndex %>" CssClass="table-action table-action-dark2 lv-action" Text=" <i class='fas fa-book'></i>" data-toggle='tooltip' data-original-title='Descriptor de Puestos' Visible='<%# Eval("pl_estado").ToString() != "ANULADO" ? true : false %>' runat="server" />
                                                        <asp:LinkButton ID="tPrint" CommandName="GetPrint" CommandArgument="<%# Container.DataItemIndex %>" CssClass="table-action table-action-dark2 lv-action" Text=" <i class='fas fa-print'></i>" data-toggle='tooltip' data-original-title='Imprimir Planilla' Visible='<%# Eval("pl_estado").ToString() != "ANULADO" ? true : false %>' runat="server" />
                                                        <asp:LinkButton ID="tDetailPla" CommandName="GetDetailPla" CommandArgument="<%# Container.DataItemIndex %>" CssClass="table-action table-action-dark2 lv-action" Text=" <i class='fas fa-paper-plane'></i>" data-toggle='tooltip' data-original-title='Ver Estado Planilla' runat="server" />
                                                        <asp:LinkButton ID="tDelete" CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="table-action table-action-delete lv-action" Text=" <i class='fas fa-trash-alt'></i>" data-toggle='tooltip' data-original-title='Eliminar Planilla' Visible='<%# (Eval("pl_estado").ToString() == "VALIDADO" || Eval("pl_estado").ToString() == "ANULADO") ? false : true %>' runat="server" />
                                                    </div>
                                                </div>
                                            </li>
                                        </ItemTemplate>

                                    </asp:ListView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="lv_planilla" EventName="ItemCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </ul>
                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div id="no_existe_pla" class="row" runat="server">
                                    <div class="col-md-12">
                                        <p class="text-sm grid-notify-success">No existen planillas registradas. </p>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>
                    <div class="modal fade" id="modalNuevaPlanilla" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                        <div class="modal-dialog modal- modal-dialog-centered modal-xl" role="document">
                            <div class="modal-content">

                                <div class="modal-body p-0">
                                    <div class="card bg-secondary border-0 mb-0">
                                        <div class="card-header">
                                            <div class="text-muted text-center mt-2 mb-3"><small>REGISTRO PLANILLA</small></div>
                                        </div>
                                        <div class="card-body py-lg-2">
                                            <p class="text-sm">Para crear una planilla, seleccione la Unidad Ejecutora asignada a su usuario</p>
                                            <div class="table-responsive py-4">
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="gv_ue" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_ue_PreRender" OnRowCommand="gv_ue_RowCommand" DataKeyNames="cp_ue" runat="server">
                                                            <Columns>
                                                                <asp:BoundField DataField="cp_ue" HeaderText="UE" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-bold" />
                                                                <asp:BoundField DataField="cp_ue_descripcion" HeaderText="Descripción" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="cp_da_descripcion" HeaderText="Dirección Administrativa" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />

                                                                <asp:TemplateField HeaderText="" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="50px">
                                                                    <ItemTemplate>
                                                                        <label class="custom-toggle custom-toggle-yout grid-check-item">
                                                                            <asp:CheckBox ID="chk_ue" OnCheckedChanged="chk_ue_CheckedChanged" AutoPostBack="true" runat="server" />
                                                                            <span class="custom-toggle-slider rounded-circle" data-label-off="No" data-label-on="Si" data-toggle='tooltip' data-placement='top' title='Elegir'></span>
                                                                        </label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>

                                        <div class="form-group text-center">
                                            <asp:UpdatePanel ID="up_guardar_p" runat="server">
                                                <ContentTemplate>

                                                    <asp:LinkButton ID="btn_crear_planilla" Text="<i class='fas fa-check mr-2'></i>Crear Planilla" ValidationGroup="addGlosa" OnClick="btn_crear_planilla_Click" CssClass="btn btn-success" runat="server" />
                                                    <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                                    <asp:HiddenField ID="hf_ue" runat="server" />
                                                    <asp:HiddenField ID="hf_pl_id" runat="server" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal fade" id="eliminarPlanilla" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                        <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                            <div class="modal-content bg-gradient-dark6">
                                <div class="modal-header">
                                </div>

                                <asp:UpdatePanel ID="up_eliminar_p" runat="server">
                                    <ContentTemplate>
                                        <div class="modal-body">
                                            <div class="py-3 text-center">
                                                <i class="ni ni-fat-remove ni-3x"></i>
                                                <h4 class="heading text-dark mt-4">¿Esta seguro de eliminar la Planilla?</h4>
                                            </div>
                                        </div>
                                        <div class="form-group text-center">
                                            <asp:LinkButton ID="btn_eilminar_planilla" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btn_eilminar_planilla_Click" runat="server" />
                                            <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <div class="modal fade" id="modalEstados" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none; overflow-y: auto" aria-hidden="true">
                        <div class="modal-dialog modal- modal-dialog-centered modal-xl" role="document">
                            <div class="modal-content">

                                <div class="modal-body p-0">
                                    <div class="card bg-secondary border-0 mb-0">
                                        <div class="card-header">
                                            <div class="text-muted text-center mt-2 mb-3"><small>ESTADO PLANILLA</small></div>
                                        </div>
                                        <div class="card-body py-lg-4">

                                            <div class="table-responsive py-2">
                                                <asp:UpdatePanel ID="up_gv_categorias" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="gv_estado" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" OnPreRender="gv_estado_PreRender" DataKeyNames="seg_id" runat="server">
                                                            <Columns>
                                                                <asp:BoundField DataField="remitente" HeaderText="Remitente" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="seg_accion" HeaderText="Estado" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center display-3 dt-sub-title" />
                                                                <asp:BoundField DataField="recepcion" HeaderText="Receptor" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="seg_observaciones" HeaderText="Observaciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="seg_fecha" HeaderText="Fecha" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />

                                                            </Columns>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>

                                        </div>

                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <div id="no_existe_acciones" class="card-body pb-4" runat="server">
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <p class="text-sm grid-notify-success">No existen registros por mostrar. </p>
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
            </div>
        </div>

        <asp:UpdateProgress ID="up" AssociatedUpdatePanelID="up_lv_planilla" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up1" AssociatedUpdatePanelID="up_eliminar_p" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up2" AssociatedUpdatePanelID="up_guardar_p" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up3" AssociatedUpdatePanelID="panelBuscar" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>

    </div>
</asp:Content>


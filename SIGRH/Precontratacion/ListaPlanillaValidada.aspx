<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ListaPlanillaValidada.aspx.cs" Inherits="Precontratacion_ListaPlanillaValidada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Planillas</h6>

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
                                    <p class="text-sm mb-0">
                                        Busque planillas mediante el número o la unidad ejecutora.
                                    </p>
                                    <asp:updatepanel runat="server">
                                        <ContentTemplate>
                                            <p class="text-sm mb-0">
                                                <asp:Literal ID="ltl_desc_gestion" Text="" runat="server" />
                                            </p>
                                        </ContentTemplate>
                                    </asp:updatepanel>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <!-- Form groups used in grid -->
                        <asp:updatepanel id="panelBuscar" runat="server">
                            <ContentTemplate>
                                <asp:Panel DefaultButton="btn_buscar_planilla" runat="server">

                                    <div class="row">
                                        <div class="col-sm-6 col-md-4">
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
                                        <div class="col-sm-6 col-md-4">
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
                          
                                        <div class="col-sm-6 col-md-4">
                                            <div class="form-group">
                                                <label class="form-control-label">&nbsp</label>
                                                <asp:LinkButton ID="btn_buscar_planilla" CssClass="btn btn-info btn-block" Text="<i class='fas fa-search'></i> Buscar" OnClick="btn_buscar_planilla_Click" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:updatepanel>
                    </div>

                    <div class="card-body" style="padding-top: unset">
                        <!-- List group -->
                        <ul class="list-group list-group-flush list my--3">
                            <asp:updatepanel id="up_lv_planilla" runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-12 text-center">
                                            <div class="list-view-item-title-cont">
                                                Nro. de registros:
                                                <asp:Literal ID="ltl_total_reg" Text="0" runat="server"></asp:Literal>
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
                                      
                                                            <div class="row flex-nowrap">
                                                                <div class="list-view-item-title" style="color: #0090C5;">Cantidad Pre-Contratados: </div>
                                                                <div class="list-view-item-desc"><%# Eval("cantidad") %></div>
                                                            </div>
                                                            <div class="row flex-nowrap">
                                                                <div class="list-view-item-title">Unidad Ejecutora: </div>
                                                                <div class="list-view-item-desc"><%# Eval("pl_ue") + " - " + Eval("ue") %></div>
                                                            </div>
                                                            <div class="row flex-nowrap">
                                                                <div class="list-view-item-title">Fecha Validación: </div>
                                                                <div class="list-view-item-desc"><%# Eval("pl_fecha_validacion") %></div>
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
                                                        <asp:LinkButton ID="tDelete" CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="table-action table-action-delete lv-action" Text=" <i class='fas fa-trash-alt'></i>" data-toggle='tooltip' data-original-title='Eliminar Planilla' Visible='<%# (Eval("pl_estado").ToString() == "ANULADO") ? false : true %>' runat="server" />
                                                    </div>
                                                </div>
                                            </li>
                                        </ItemTemplate>

                                    </asp:ListView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="lv_planilla" EventName="ItemCommand" />
                                </Triggers>
                            </asp:updatepanel>
                        </ul>
                    </div>
                    <div class="card-body">
                        <asp:updatepanel runat="server">
                            <ContentTemplate>
                                <div id="no_existe_pla" class="row" runat="server">
                                    <div class="col-md-12">
                                        <p class="text-sm grid-notify-success"> <asp:Literal ID="ltl_no_existe" Text="Por favor ingresé los parámetros de búsqueda." runat="server" /> </p>
                                    </div>
                                </div>
                                <asp:HiddenField ID="hf_pl_id" runat="server" />
                            </ContentTemplate>
                        </asp:updatepanel>

                    </div>
        
                    <div class="modal fade" id="eliminarPlanilla" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                        <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                            <div class="modal-content bg-gradient-dark6">
                                <div class="modal-header">
                                </div>

                                <asp:updatepanel id="up_eliminar_p" runat="server">
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
                                </asp:updatepanel>
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
                                                <asp:updatepanel id="up_gv_categorias" runat="server">
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
                                                </asp:updatepanel>
                                            </div>

                                        </div>

                                        <asp:updatepanel runat="server">
                                            <ContentTemplate>
                                                <div id="no_existe_acciones" class="card-body pb-4" runat="server">
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <p class="text-sm grid-notify-success">No existen registros por mostrar. </p>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:updatepanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <asp:updateprogress id="up" associatedupdatepanelid="up_lv_planilla" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:updateprogress>
        <asp:updateprogress id="up1" associatedupdatepanelid="up_eliminar_p" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:updateprogress>
  
        <asp:updateprogress id="up3" associatedupdatepanelid="panelBuscar" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:updateprogress>

    </div>
</asp:Content>


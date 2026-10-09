<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ListaFrecuenciaValidacion.aspx.cs" Inherits="Precontratacion_ListaFrecuenciaValidacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Validación de Frecuencias</h6>
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
                                    <h3 class="mb-0">Lista de Categorías</h3>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel ID="panelBuscar" runat="server">
                            <ContentTemplate>
                                <asp:Panel DefaultButton="btn_buscar_cat" runat="server">

                                    <div class="row">
                                        <div class="col-sm-6 col-md-4">
                                            <div class="form-group">
                                                <label class="form-control-label" for="example4cols1Input">DA</label>
                                                <small>(Dirección Administrativa)</small>
                                                <div class="input-group input-group-merge">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text"><i class="fas fa-layer-group"></i></span>
                                                    </div>
                                                    <asp:TextBox ID="txt_da" class="form-control numero" runat="server" />
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
                                                <asp:LinkButton ID="btn_buscar_cat" CssClass="btn btn-info btn-block" Text="<i class='fas fa-search'></i> Buscar" OnClick="btn_buscar_cat_Click" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>


                    <div class="card-body">
                        <!-- List group -->
                        <ul class="list-group list-group-flush list my--3">
                            <asp:UpdatePanel ID="up_lv_categorias" runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-12 text-center">
                                            <div class="list-view-item-title">
                                                Nro. de registros:
                                                <asp:Literal ID="ltl_total_reg" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                    </div>
                                    <%--<asp:Timer ID="tr_lv_categorias" runat="server" OnTick="tr_lv_categorias_Tick" Interval="1000" />--%>
                                    <asp:ListView ID="lv_categorias" ClientIDMode="AutoID" OnItemCommand="lv_categorias_ItemCommand" DataKeyNames="cp_id, cod_poa" runat="server">
                                        <ItemTemplate>

                                            <li class="list-group-item px-0 lv-item" style="margin-bottom: 0px" runat="server">
                                                <div class="row align-items-center px-3">

                                                    <div class="col-12 ml--2">
                                                        <asp:LinkButton ID="tDatail" CommandName="GetAssign" CommandArgument="<%# Container.DataItemIndex %>" runat="server">
                                                        <h2 class="mb-0 list-view-item-title-i2"><%# Eval("cp_descripcion") %> </h2>
                                                        </asp:LinkButton>
                                                    </div>

                                                </div>
                                                <div class="row align-items-center px-3">
                                                    <div class="col-10">
                                                        <asp:LinkButton ID="tDatail1" CommandName="GetAssign" CommandArgument="<%# Container.DataItemIndex %>" data-toggle='tooltip' data-placement='right' title='Ver Frecuencias' runat="server">

                                                            <div class="row ">
                                                                <div class="list-view-item-title" style="color: #0090C5;">Cantidad Frecuencias: </div>
                                                                <div class="list-view-item-desc"><%# Eval("cantidad") %></div>
                                                            </div>
                                                            <div class="row ">
                                                                <div class="list-view-item-title">DA: </div>
                                                                <div class="list-view-item-desc"><%# Eval("cp_da") %> - <%# Eval("cp_da_descripcion") %>   </div>
                                                            </div>
                                                            <div class="row ">
                                                                <div class="list-view-item-title">UE: </div>
                                                                <div class="list-view-item-desc"><%# Eval("cp_ue") %> - <%# Eval("cp_ue_descripcion") %>   </div>
                                                            </div>
                                                            <div class="row ">
                                                                <div class="list-view-item-title">Fuente - Organismo: </div>
                                                                <div class="list-view-item-desc"><%# Eval("cp_fu_org") %> </div>
                                                            </div>
                                                            <%--               <div class="row ">
                                                            <div class="list-view-item-title">Cod. POA: </div>
                                                            <div  class="list-view-item-desc"><%# Eval("cod_poa") %></div>
                                                        </div>--%>

                                                            <div class="row ">
                                                                <div class="list-view-item-title">Estado: </div>
                                                                <div class="list-view-item-desc">
                                                                    <asp:Label ID="ltl_estado" CssClass='<%# (Eval("cat_estado").ToString() == "ENVIADO") ? "text-info font-weight-bold" : (Eval("cat_estado").ToString() == "VALIDADO") ? "text-success font-weight-bold" :  (Eval("cat_estado").ToString() == "OBSERVADO") ? "text-warning font-weight-bold" : "list-view-item-desc" %>' Text='<%# Eval("cat_estado") %>' runat="server" /></div>
                                                            </div>
                                                        </asp:LinkButton>
                                                    </div>
                                                    <div class="col-2 text-center">
                                                        <asp:LinkButton ID="tPrint" CommandName="GetPrint" CommandArgument="<%# Container.DataItemIndex %>" CssClass="table-action table-action-dark2 lv-action" Text=" <i class='fas fa-print'></i>" data-toggle='tooltip' data-original-title='Imprimir' runat="server" />
                                                        <asp:LinkButton ID="tDetailCat" CommandName="GetDetailCat" CommandArgument="<%# Container.DataItemIndex %>" CssClass="table-action table-action-dark2 lv-action" Text=" <i class='fas fa-paper-plane'></i>" data-toggle='tooltip' data-original-title='Ver Detalle' runat="server" />
                                                    </div>
                                                </div>
                                            </li>
                                        </ItemTemplate>

                                    </asp:ListView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="lv_categorias" EventName="ItemCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </ul>
                                                <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div id="no_existe_cat" class="row" runat="server">
                                    <div class="col-md-12">
                                        <p class="text-sm grid-notify-success">
                                            No existen categorías por mostrar, consulte al administrador.
                                        </p>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div class="modal fade" id="modalEstados" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none; overflow-y: auto" aria-hidden="true">
                        <div class="modal-dialog modal- modal-dialog-centered modal-xl" role="document">
                            <div class="modal-content">

                                <div class="modal-body p-0">
                                    <div class="card bg-secondary border-0 mb-0">
                                        <div class="card-header">
                                            <div class="text-muted text-center mt-2 mb-3"><small>ESTADO CATEGORÍA</small></div>
                                        </div>
                                        <div class="card-body py-lg-4">

                                            <div class="table-responsive py-2">
                                                <asp:UpdatePanel ID="up_gv_categorias" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="gv_estado" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_estado_PreRender" DataKeyNames="seg_id" runat="server">
                                                            <Columns>
                                                                <asp:BoundField DataField="remitente" HeaderText="Remitente" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="seg_accion" HeaderText="Estado" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center display-3 dt-sub-title" />
                                                                <asp:BoundField DataField="seg_fecha" HeaderText="Fecha" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="recepcion" HeaderText="Receptor" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="seg_observaciones" HeaderText="Observaciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                
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
        <asp:UpdateProgress ID="up" AssociatedUpdatePanelID="up_lv_categorias" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up1" AssociatedUpdatePanelID="panelBuscar" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
</asp:Content>


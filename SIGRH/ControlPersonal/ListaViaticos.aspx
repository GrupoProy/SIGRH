<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ListaViaticos.aspx.cs" Inherits="ControlPersonal_ListaViaticos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="header pb-6" style="margin-top: -4em; margin-left: 3em; width: 60%">
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Planillas de Viaticos</h6>
                    </div>
                    <div class="col-lg-6 col-5 text-right">
                        <asp:LinkButton ID="btn_nuevo_viatico" CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-inst text-white rounded-circle shadow" Text="<i class='fas fa-plus'></i>" data-toggle="tooltip" data-original-title="Crear Viatico" OnClick="btn_nuevo_viatico_Click" runat="server" />
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
                                                <label class="form-control-label" for="example4cols1Input">MES</label>
                                                <asp:DropDownList ID="ddl_mes" AutoPostBack="true" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-sm-6 col-md-4">
                                            <div class="form-group invisible" hidden="hidden">
                                                <label class="form-control-label" for="example4cols2Input">?</label>
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
                                                <asp:LinkButton ID="btn_buscar_cat" OnClick="btn_buscar_cat_Click" CssClass="btn btn-info btn-block" Text="<i class='fas fa-search'></i> Buscar" runat="server" />
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
                                    <asp:ListView ID="lv_viaticos" ClientIDMode="AutoID" OnItemCommand="lv_viaticos_ItemCommand" DataKeyNames="vi_nro_planilla" runat="server">
                                        <ItemTemplate>
                                            <li class="list-group-item px-0 lv-item" style="margin-bottom: 0px" runat="server">
                                                <div class="row align-items-center px-3">

                                                    <div class="col-12 ml--2">
                                                        <asp:LinkButton ID="tDatail" CommandName="Ver" CommandArgument="<%# Container.DataItemIndex %>" runat="server">
                                                        <h2 class="mb-0 list-view-item-title-i2"><%# Eval("nro_planilla") %> </h2>
                                                        </asp:LinkButton>
                                                    </div>

                                                </div>
                                                <div class="row align-items-center px-3">
                                                    <div class="col-10">

                                                            <div class="row ">
                                                                <div class="list-view-item-title" style="color: #0090C5;">Cantidad de personas: </div>
                                                                <div class="list-view-item-desc"><%# Eval("personas") %></div>
                                                            </div>
                                                            <div class="row ">
                                                                <div class="list-view-item-title">Fechas: </div>
                                                                <div class="list-view-item-desc"><%# Convert.ToDateTime(Eval("fecha_inicio")).ToString("yyyy/MM/dd") %> - <%# Convert.ToDateTime(Eval("fecha_fin")).ToString("yyyy/MM/dd") %>   </div>
                                                            </div>
                                                            <div class="row ">
                                                                <div class="list-view-item-title">Total viaticos: </div>
                                                                <div class="list-view-item-desc"><%# String.Format("{0:N2}", Eval("Total_viatico")) %></div>
                                                            </div>
                                                            <div class="row ">
                                                                <div class="list-view-item-title">Elaborado por: </div>
                                                                <div class="list-view-item-desc"><%# Eval("usuario") %> </div>
                                                            </div>

                                                            <%--<div class="row ">
                                                                <div class="list-view-item-title">Estado: </div>
                                                                <div class="list-view-item-desc">
                                                                    <asp:Label ID="ltl_estado" CssClass='<%# (Eval("cat_estado").ToString() == "ENVIADO") ? "text-info font-weight-bold" : (Eval("cat_estado").ToString() == "VALIDADO") ? "text-success font-weight-bold" :  (Eval("cat_estado").ToString() == "OBSERVADO") ? "text-warning font-weight-bold" : "list-view-item-desc" %>' Text='<%# Eval("cat_estado") %>' runat="server" /></div>
                                                            </div>--%>
                                                    </div>
                                                    <div class="col-2 text-center">
                                                        <asp:LinkButton ID="tPrint" CommandName="Imprimir" CommandArgument="<%# Container.DataItemIndex %>" CssClass="table-action table-action-dark2 lv-action" Text=" <i class='fas fa-print'></i>" data-toggle='tooltip' data-original-title='Imprimir' runat="server" />
                                                        <asp:LinkButton ID="tDetailCat" CommandName="Detalles" CommandArgument="<%# Container.DataItemIndex %>" CssClass="table-action table-action-dark2 lv-action" Text=" <i class='fas fa-paper-plane'></i>" data-toggle='tooltip' data-original-title='Ver Detalle' runat="server" />
                                                        <asp:LinkButton ID="btnEliminar" CommandName="Eliminar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="table-action table-action-dark2 lv-action" Text=" <i class='fas fa-times'></i>" data-toggle='tooltip' data-original-title='Reprobar planilla' runat="server" />
                                                    </div>
                                                </div>
                                            </li>
                                        </ItemTemplate>

                                    </asp:ListView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="lv_viaticos" EventName="ItemCommand" />
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
                                            <div class="text-muted text-center mt-2 mb-3">DETALLES DE PLANILLA</div>
                                        </div>
                                        <div class="card-body py-lg-4">
                                            <div class="table-responsive py-2">
                                                <asp:UpdatePanel ID="up_gv_categorias" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="gv_planilla" CssClass="table table-bordered table-hover table-striped" OnPreRender="gv_planilla_PreRender" AutoGenerateColumns="false" runat="server">
                                                            <Columns>
                                                                <asp:BoundField DataField="nombreFunc" HeaderText="Nombre Funcionario" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="ciFunc" HeaderText="CI" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="es_descripcion" HeaderText="Cargo" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="eo_descripcion" HeaderText="UNIDAD" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="vi_fecha_ini" HeaderText="Fecha Inicio" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" DataFormatString="{0:yyyy/MM/dd}" />
                                                                <asp:BoundField DataField="vi_fecha_fin" HeaderText="Fecha Fin" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" DataFormatString="{0:yyyy/MM/dd}" />
                                                                <asp:BoundField DataField="ev_cat" HeaderText="Categoria" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="ev_destino" HeaderText="Destino" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="vi_dias" HeaderText="Dias" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
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

                    <div class="modal fade" id="eliminarViatico" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                        <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                            <div class="modal-content bg-gradient-dark6">
                                <div class="modal-header">
                                </div>
                                <asp:UpdatePanel ID="up_eliminar_p" runat="server">
                                    <ContentTemplate>
                                        <div class="modal-body">
                                            <div class="py-3 text-center">
                                                <i class="ni ni-fat-remove ni-3x"></i>
                                                <h4 class="heading text-dark mt-4">¿Esta seguro de eliminar la Planilla de viatico?</h4>
                                            </div>
                                        </div>
                                        <div class="form-group text-center">
                                            <asp:LinkButton ID="btn_eliminar_planilla" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btn_eliminar_planilla_Click" runat="server" />
                                            <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
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


<%@ Page Title="Manual de Puestos" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ItemBusqueda.aspx.cs" Inherits="ManualPuestos_frmPuestos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header bg-org2 pb-6" style="min-height: 170px; background-image: url(../Content/img/fondo_uap1.png); background-size: cover; background-position: center top;">
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h4 class="h2 text-bluedark d-inline-block mb-0"><i class="fas fa-table mr-3"></i>Administración de POAI</h4>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page content -->
    <div class="container-fluid mt--6">

        <div class="card mb-4">
            <!-- Card header -->
            <div class="card-header">
                <div class=" ct-page-title">
                    <h3 class="mb-0">Especifique criterio de búsqueda </h3>
                    <p class="text-sm mb-0">
                        Use los filtros mostrados en la parte inferior.
                    </p>
                </div>
            </div>
            <!-- Card body -->
            <asp:Panel runat="server" DefaultButton="btnFiltrar">
                <div class="card-body">

                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="row">
                               <div class="col-md-2">
                                    <div class="form-group">
                                        <div class="form-group">
                                            <label class="form-control-label">Gestión</label>
                                            <asp:DropDownList ID="ddl_gestion" CssClass="form-control is-valid select2" OnSelectedIndexChanged="ddl_gestion_SelectedIndexChanged" AutoPostBack="true" data-minimum-results-for-search="Infinity" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group text-center">
                                                <label class="form-control-label form-control-label-prs pb-3">¿Por Intervalo?</label>
                                                <asp:UpdatePanel ID="panelNroItem" runat="server">
                                                    <ContentTemplate>
                                                        <label class="custom-toggle custom-toggle-yout">
                                                            <asp:CheckBox ID="chk_intervalo" AutoPostBack="true" OnCheckedChanged="chk_intervalo_CheckedChanged" Checked="false" runat="server" />
                                                            <span class="custom-toggle-slider rounded-circle" data-label-off="No" data-label-on="Si"></span>
                                                        </label>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>

                                        <div id="blockItem" class="col-md-8">
                                            <div class="form-group">
                                                <label class="form-control-label form-control-label-prs">Ítem</label>
                                                <asp:TextBox ID="txt_item" CssClass="form-control numero" placeholder="Item" runat="server" />
                                            </div>
                                        </div>
                                        <div id="blockHastaItem" class="col-md-4" style="display: none">
                                            <div class="form-group">
                                                <label class="form-control-label form-control-label-prs">Hasta Ítem</label>
                                                <asp:TextBox ID="txt_hasta_item" CssClass="form-control numero" placeholder="Hasta Item" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-5">
                                    <div class="form-group">
                                        <div class="form-group">
                                            <label class="form-control-label">Cargo</label>
                                            <asp:DropDownList ID="ddl_cargo" AppendDataBoundItems="true" CssClass="form-control select2" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-md-8">
                                    <div class="form-group">
                                        <div class="form-group">
                                            <label class="form-control-label">Unidad Organizacional</label>
                                            <asp:DropDownList ID="ddl_unidad_organizacional" AppendDataBoundItems="true" CssClass="form-control select2" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4" hidden="True" >
                                    <div class="form-group">
                                        <div class="form-group">
                                            <label class="form-control-label">Unidad Ejecutora</label>
                                            <asp:DropDownList ID="ddl_unidad_ejecutiva" AppendDataBoundItems="true" CssClass="form-control select2" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4" hidden="True">
                                    <div class="form-group">
                                        <div class="form-group">
                                            <label class="form-control-label">Dirección Administrativa</label>
                                            <asp:DropDownList ID="ddl_direccion_administrativa" AppendDataBoundItems="true" CssClass="form-control select2" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="row">
                        <div class="col-md-8">
                            <div class="form-group text-right">
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group text-right">
                                <asp:UpdatePanel ID="up_limpliar" runat="server">
                                    <ContentTemplate>
                                        <label class="form-control-label">&nbsp</label>
                                        <asp:LinkButton ID="btnLimpiar" CssClass="btn btn-outline-github btn-block" Text="<i class='fas fa-eraser'></i> Limpiar" OnClick="btnLimpiar_Click" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>

                        <div class="col-md-2">
                            <div class="form-group text-right">
                                <asp:UpdatePanel ID="up_filtrar" runat="server">
                                    <ContentTemplate>
                                        <label class="form-control-label">&nbsp</label>
                                        <asp:LinkButton ID="btnFiltrar" CssClass="btn btn-vimeo btn-block" Text="<i class='fas fa-search'></i> Filtrar" OnClick="btnFiltrar_Click" ValidationGroup="buscar_item" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>
        <div id="grillaPuestos" class="card" style="display: none">
            <!-- Card header -->
            <div class="card-header">
                <div class="row">
                </div>
                <div class=" ct-page-title">
                    <h3 class="mb-0">Listado de Ítem(s)</h3>
                    <p class="text-sm mb-0">
                        Detalle de los resultados de la búsqueda.
                    </p>
                </div>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:UpdatePanel ID="up_gvPuesto" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="gvPuesto" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gvPuesto_PreRender" OnRowCommand="gvPuesto_RowCommand" DataKeyNames="idFicha, poai_ca_id, item" runat="server">
                                <Columns>
                                    <asp:BoundField DataField="itemC" HeaderStyle-CssClass="text-center" HeaderText="Ítem" ItemStyle-CssClass="text-center" />
                                    <asp:BoundField DataField="cargo" HeaderStyle-CssClass="text-center" HeaderText="Cargo" />
                                    <asp:BoundField DataField="puesto" HeaderStyle-CssClass="text-center" HeaderText="Puesto" />
                                    <asp:BoundField DataField="est_org" HeaderStyle-CssClass="text-center" HeaderText="Unidad Organizacional" />

                                    <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:LinkButton CommandName="GetDetail" CssClass="table-action" data-toggle='tooltip' data-original-title='Ver POAI' Text=" <i class='fas fa-file'></i>" CommandArgument="<%# Container.DataItemIndex %>" runat="server" />
                                            <asp:LinkButton CommandName="GetDetailReport" CssClass="table-action" data-toggle='tooltip' data-original-title='Ver Reporte PDF' Text=" <i class='fas fa-print'></i>" CommandArgument="<%# Container.DataItemIndex %>" OnClientClick="document.forms[0].target = '_blank';" runat="server" />
                                            <asp:LinkButton CommandName="GetItemNow" CssClass="table-action" data-toggle='tooltip' data-original-title='Ver Histórico Ítem' Text=" <i class='fas fa-users-cog'></i>" CommandArgument="<%# Container.DataItemIndex %>" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <div class="modal fade" id="modalHistoricoItem" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
                    <div class="modal-dialog modal- modal-dialog-centered modal-xl" role="document">
                        <div class="modal-content">
                            <div class="modal-body p-0">
                                <div class="card bg-secondary border-0 mb-0">
                                    <div class="card-header">
                                        <div class="text-muted text-center mt-2 mb-3"><small>HISTÓRICO ÍTEM</small></div>
                                    </div>
                                    <div class="card-body px-lg-5 py-lg-5">
                                        <div class="table-responsive">
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="gv_item_hist" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_item_hist_PreRender" OnRowCommand="gv_item_hist_RowCommand" DataKeyNames="poai_id" runat="server">
                                                        <Columns>
                                                            <asp:BoundField DataField="nombre_fun" HeaderStyle-CssClass="text-center" HeaderText="Nombre funcionario" ItemStyle-CssClass="text-center" />
                                                            <asp:BoundField DataField="cargo" HeaderStyle-CssClass="text-center" HeaderText="Cargo" />
                                                            <asp:BoundField DataField="puesto" HeaderStyle-CssClass="text-center" HeaderText="Puesto" />
                                                            <asp:BoundField DataField="item" HeaderStyle-CssClass="text-center" HeaderText="Ítem" />
                                                            <asp:BoundField DataField="fecha_inicio" HeaderStyle-CssClass="text-center" HeaderText="Fecha Inicio Asignación" />
                                                            <asp:BoundField DataField="fecha_fin" HeaderStyle-CssClass="text-center" HeaderText="Fecha Fin Asignación" />
                                                            <asp:BoundField DataField="estado" HeaderStyle-CssClass="text-center" HeaderText="Estado" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="form-group text-center">
                                        <asp:UpdatePanel ID="up_gv_item_hist" runat="server">
                                            <ContentTemplate>
                                                <asp:LinkButton ID="btn_cerrar_hitorico" Text="<i class='fas fa-times mr-2'></i>Cerrar" ValidationGroup="addFamiliar" CssClass="btn btn-github" OnClick="btn_cerrar_hitorico_Click" runat="server" />
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
        <asp:UpdateProgress ID="up1" runat="server" AssociatedUpdatePanelID="up_limpliar">
            <ProgressTemplate>
                <div id="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up2" runat="server" AssociatedUpdatePanelID="up_filtrar">
            <ProgressTemplate>
                <div id="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up4" runat="server" AssociatedUpdatePanelID="up_gvPuesto">
            <ProgressTemplate>
                <div id="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up5" runat="server" AssociatedUpdatePanelID="up_gv_item_hist">
            <ProgressTemplate>
                <div id="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
</asp:Content>


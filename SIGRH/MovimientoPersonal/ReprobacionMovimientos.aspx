<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ReprobacionMovimientos.aspx.cs" Inherits="MovimientoPersonal_ReprobacionMovimientos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Reprobación de Movimientos</h6>
                    </div>
                     <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div id="block_ver_movRep" class="col-lg-6 col-5 text-right" style="display: block">
                                <asp:LinkButton ID="btn_ver_movRep" CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-inst text-white rounded-circle shadow" Text="<i class='fas fa-user-times'></i>" data-toggle="tooltip" data-placement='top' data-original-title="Ver Movimientos Reprobados" OnClick="btn_ver_movRep_Click" OnClientClick="MostrarMascara(true);" runat="server" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <asp:UpdatePanel ID="updateReprobaciones" runat="server">
        <ContentTemplate>
    <div class="container-fluid mt--6">
        <div class="card">
            <div class="card-header border-bottom">
                <div class="ct-page-title">
                    <h3 class="mb-0">Búsqueda de Personal</h3>
                    <p class="text-sm mb-0">En el siguiente formulario puede buscar un registro correspondiente a los parámetros ingresados.</p>
                </div>
            </div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:Panel CssClass="card-body" DefaultButton="BtnBuscar" runat="server">
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
                            <div class="form-group col-md-3">
                                <asp:LinkButton ID="BtnBuscar" CssClass="btn btn-info btn-block top-4" Text="<i class='fas fa-search'></i> Buscar" OnClick="btnFiltrar_Click" runat="server" />
                            </div>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>


        <div id="grillaMov" class="card" style="display: none;">
            <div class="card-header d-flex align-items-center">
                <div class="d-flex align-items-center">
                    <div class="ct-page-title">
                        <h3 class="mb-0">Resultados de la Búsqueda</h3>
                        <p class="text-sm mb-0">Seleccione al funcionario para la reprobación o modificación de su asignación.</p>
                    </div>
                </div>
            </div>
            <div class="table-responsive py-4">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gv_reprobar_mov" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_reprobar_mov_PreRender" OnRowCommand="gv_reprobar_mov_RowCommand" DataKeyNames="as_id, per_id, ca_id" runat="server">
                            <Columns>
                                <asp:BoundField DataField="per_id" HeaderText="Cód. Fun." HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                <asp:BoundField DataField="nombre_fun" HeaderText="Nombre funcionario" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-left" />
                                <asp:BoundField DataField="ci" HeaderText="Carnet de identidad" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-bold" />
                                <asp:BoundField DataField="item" HeaderText="Ítem" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                <asp:BoundField DataField="ubicacion" HeaderText="Unidad organizacional" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                <asp:BoundField DataField="as_fecha_inicio" HeaderText="Fecha asignación" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="130px">
                                    <ItemTemplate>
                                        <asp:LinkButton CommandName="GetAssig" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-info text-white btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-info fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Ver Detalle' OnClientClick="MostrarMascara(true);" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:HiddenField ID="hf_as_id" runat="server" />
                        <asp:HiddenField ID="hf_per_id" runat="server" />
                        <asp:HiddenField ID="hf_ca_id" runat="server" />
                        <asp:HiddenField ID="hf_ti_item" runat="server" />
                        <asp:HiddenField ID="hf_ti_tipo" runat="server" />
                        <asp:HiddenField ID="hf_as_tipo_mov" runat="server" />
                        <asp:HiddenField ID="hf_as_tipo_reg" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div id="no_existe_mov" class="card-body" runat="server">
                        <div class="row">
                            <div class="col-md-12">
                                <p class="text-sm grid-notify-success">No existen datos por mostrar. </p>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <%--Modal Información del movimiento--%>
        <div class="modal fade" id="modalDetalleMovimiento" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
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
                                                    <asp:Image ID="imgFun" class="rounded-circle" runat="server" />
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
                                            <asp:LinkButton ID="btn_estado" CssClass="btn btn-sm btn-default float-right" OnClick="btn_estado_Click" runat="server" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="card-body pt-4">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div>
                                            <h5 class="h3 text-uppercase text-center">
                                                <asp:Literal ID="ltl_nombre_fun" runat="server" />
                                            </h5>
                                            <div class="h5 font-weight-400  text-center">
                                                <strong class="h5">CI: </strong>
                                                <asp:Literal ID="ltl_ci" runat="server" />
                                                <strong class="h5">COD. FUN:</strong>
                                                <asp:Literal ID="ltl_cod_fun" runat="server" />
                                                <strong class="h5">ÍTEM:</strong>
                                                <asp:Literal ID="ltl_item" runat="server" />
                                            </div>
                                            <hr class="my-2">
                                            <h6 class="heading-small text-muted d-inline-flex icon-title-h"><i class="fas fa-briefcase icon-h"></i>Escalafón</h6>
                                            <div class="icon-content-h">
                                                <div class="row">
                                                    <div class="col-lg-4">
                                                        <div class="content-text-label">Cargo</div>
                                                        <div class="h5 font-weight-400 content-text">
                                                            <asp:Literal ID="ltl_cargo" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <div class="content-text-label">Puesto</div>
                                                        <div class="h5 font-weight-400 content-text">
                                                            <asp:Literal ID="ltl_puesto" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <div class="content-text-label">Haber Básico (Bs)</div>
                                                        <div class="h5 font-weight-400 content-text">
                                                            <asp:Literal ID="ltl_haber_basico" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-4">
                                                        <div class="content-text-label">Código Escalafón</div>
                                                        <div class="h5 font-weight-400 content-text">
                                                            <asp:Literal ID="ltl_cod_esc" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <div class="content-text-label">Clase</div>
                                                        <div class="h5 font-weight-400 content-text">
                                                            <asp:Literal ID="ltl_clase" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4">
                                                        <div class="content-text-label">Nivel Salarial</div>
                                                        <div class="h5 font-weight-400 content-text">
                                                            <asp:Literal ID="ltl_nivel_salarial" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <hr class="my-2">
                                            <h6 class="heading-small text-muted d-inline-flex icon-title-h"><i class="fas fa-calendar icon-h"></i>Información fecha asignación</h6>
                                            <div class="icon-content-h">
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <div class="content-text-label">Fecha asignación</div>
                                                        <div class="h5 font-weight-400 content-text">
                                                            <asp:Literal ID="ltl_fecha_inicio" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <div class="content-text-label">Fecha baja</div>
                                                        <div class="h5 font-weight-400 content-text">
                                                            <asp:Literal ID="ltl_fecha_fin" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <hr class="my-3">
                                            <h6 class="heading-small text-muted d-inline-flex icon-title-h"><i class="fas fa-building icon-h"></i>Categoría administrativa</h6>
                                            <div class="icon-content-h">
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <div class="content-text-label">Ubicación</div>
                                                        <div class="h5 font-weight-400 content-text content-text">
                                                            <asp:Literal ID="ltl_ubicacion" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <div class="content-text-label">Categoría Administrativa</div>
                                                        <div class="h5 font-weight-400 content-text">
                                                            <asp:Literal ID="ltl_programatica" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <hr class="my-3">
                                            <h6 class="heading-small text-muted d-inline-flex icon-title-h"><i class="fas fa-building icon-h"></i>Categoría programática</h6>
                                            <div class="icon-content-h">
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <div class="content-text-label">Ubicación</div>
                                                        <div class="h5 font-weight-400 content-text content-text">
                                                            <asp:Literal ID="ltl_cat_ubicacion" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <div class="content-text-label">Categoría Programática</div>
                                                        <div class="h5 font-weight-400 content-text">
                                                            <asp:Literal ID="ltl_cat_programatica" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row mt-2">
                                                <div class="col-lg-4">
                                                    <asp:LinkButton ID="btn_reprobar" Text="<i class='fas fa-trash mr-2'></i>Reprobar" ValidationGroup="addFuncionario" CssClass="btn btn-danger btn-block" OnClick="btn_reprobar_Click" runat="server" />
                                                </div>
                                                <div class="col-lg-4">
                                                    <asp:LinkButton ID="btn_modificar" class="btn btn-warning btn-block" Text="<i class='fas fa-edit mr-2'></i>Modificar" OnClick="btn_modificar_Click" runat="server" />
                                                </div>
                                                <div class="col-lg-4">
                                                    <button type="button" class="btn btn-outline-github btn-block" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
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

        <!-- Modal Reprobar Movimiento -->
        <div class="modal fade" id="reprobarMov" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
            <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                <div class="modal-content bg-gradient-dark6">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="modal-body">
                                <div class="py-3 text-center">
                                    <i class="ni ni-fat-remove ni-3x"></i>
                                    <h4 class="heading text-dark mt-4">¿Está seguro de reprobar el registro, este se eliminara definitivamente?</h4>
                                    <p>Si corresponde, el registro tambien se anulara en pre-contrataciones.</p>
                                </div>
                            </div>
                            <div class="form-group text-center">
                                <asp:LinkButton ID="btn_reprobar_mov" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btn_reprobar_mov_Click" runat="server" />
<%--                                <button type="button"   class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>--%>
                                <asp:LinkButton ID="btn_cancelar" Text="<i class='fas fa-times mr-2'></i>Cancelar" CssClass="btn btn-info" OnClick="btn_cancelar_Click" runat="server" />

                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

        <!-- Modal Modificar Movimiento -->
        <div class="modal fade" id="modificarMov" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
            <div class="modal-dialog modal- modal-dialog-centered modal-" role="document">
                <div class="modal-content">
                    <div class="card bg-secondary border-0 mb-0">
                        <div class="modal-header">
                        </div>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="modal-body">
                                    <div class="text-center">
                                        <a href="javascript:;">
                                            <img src="../Content/img/theme/pencil.png" alt="Circle image" class="img-fluid rounded-circle shadow" style="width: 100px;"><br />
                                            <h4 class="heading text-dark mt-4">¿Está seguro de modificar el registro?</h4>
                                        </a>
                                    </div>
                                </div>
                                <div class="card-body px-lg-5 ">
                                    <h6 class="heading-small text-muted">Datos de la fecha asignación</h6>
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label class="form-control-label" for="exampleFormControlSelect1">Fecha Inicio</label>
                                                <div class="input-group input-group-merge">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                    </div>
                                                    <asp:TextBox ID="txt_fecha_inicio" AutoComplete="off" CssClass="form-control datepickerDefault" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label class="form-control-label" for="exampleFormControlSelect1">Fecha Fin</label>
                                                <div class="input-group input-group-merge">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                    </div>
                                                    <asp:TextBox ID="txt_fecha_fin" AutoComplete="off" CssClass="form-control datepickerDefault" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group text-center">
                                    <asp:LinkButton ID="btn_modificar_mov" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btn_modificar_mov_Click" runat="server" />
<%--                                    <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>--%>
                                    <asp:LinkButton ID="btn_cancelar_update" Text="<i class='fas fa-times mr-2'></i>Cancelar" CssClass="btn btn-info"  OnClick="btn_cancelar_update_Click" runat="server" />

                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>

         <%-- Modal Grilla Movimientos Reprobados --%>
        <div class="modal fade" id="modalMovReprobados" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-body p-0">
                        <div class="card bg-secondary border-0 mb-0">
                            <div class="card-header">
                                <div class="text-muted text-center mt-2 mb-3">
                                    <h4 class="header-modal">MOVIMIENTOS REPROBADOS</h4>
                                </div>
                            </div>
                            <div class="card-body px-lg-4 py-lg-4">
                                <div class="card">
                                    <div class="card-header">
                                        <div class=" ct-page-title">
                                            <h3 class="mb-0">Listado de los movimientos reprobados</h3>
                                            <p class="text-sm mb-0">
                                                Detalle de los registros reprobados ya sea por Alta, Baja o Rem/Prom/Transf. Acefalia.
                                            </p>
                                        </div>
                                    </div>
                                    <div class="table-responsive py-4">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="gv_mov_rep" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_mov_rep_PreRender" DataKeyNames="per_id" runat="server">
                                                    <Columns>
                                                        <asp:BoundField DataField="per_id" HeaderText="cod. Fun" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                        <asp:BoundField DataField="nombre_fun" HeaderText="Nombre Funcionario" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                        <asp:BoundField DataField="ci" HeaderText="Carnet de Identidad" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                        <asp:BoundField DataField="cargo" HeaderText="Cargo" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                        <asp:BoundField DataField="as_fecha_inicio" HeaderText="Fecha Inicio" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                        <asp:BoundField DataField="as_fecha_fin" HeaderText="Fecha Fin" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="col-md-12">
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <div id="block_repMov" runat="server">
                                                        <span class="badge badge-pill badge-info">No existen registros reprobados.</span>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group text-center">
                                    <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
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


        <asp:UpdateProgress ID="up1" AssociatedUpdatePanelID="updateReprobaciones" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
</asp:Content>

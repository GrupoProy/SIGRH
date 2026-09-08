<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="BuscadorFuncionario.aspx.cs" Inherits="MovimientoPersonal_BuscadorFuncionario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Asignación Comisión e Interinato</h6>
                    </div>
                    <div class="col-lg-6 col-5 text-right">
                        <%--        <asp:LinkButton ID="btn_nuevo_item" CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-inst text-white rounded-circle shadow" Text="<i class='fas fa-plus'></i>" data-toggle="tooltip" data-original-title="Crear Ítem" OnClick="btn_nuevo_item_Click" runat="server" />
                        --%>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid mt--6">
        <div class="card mb-4">
            <!-- Card header -->
            <div class="card-header">
                <div class=" ct-page-title">
                    <h3 class="mb-0">Especifique criterio de búsqueda </h3>
                    <p class="text-sm mb-0">
                        Para su búsqueda,  puede usar las siguientes opciones mostrados en la parte inferior.
                    </p>
                </div>
            </div>
            <!-- Card body -->
            <div class="card-body">
                <!-- Form groups used in grid -->
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:Panel CssClass="card-body" DefaultButton="BtnBuscar" runat="server">
                            <div class="row">
                                <div class="col-sm-6 col-md-3">
                                    <div class="form-group">
                                        <label class="form-control-label" for="example4cols2Input">Apellido Paterno</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                            </div>
                                            <asp:TextBox ID="Txt_per_ap_paterno_b" CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-3">
                                    <div class="form-group">
                                        <label class="form-control-label" for="example4cols3Input">Apellido Materno</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                            </div>
                                            <asp:TextBox ID="Txt_per_ap_materno_b" CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-3">
                                    <div class="form-group">
                                        <label class="form-control-label" for="example4cols4Input">Nombre (s)</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                            </div>
                                            <asp:TextBox ID="Txt_per_nombres_b" CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-3">
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6 col-md-3">
                                    <div class="form-group">
                                        <label class="form-control-label" for="example4cols5Input">Apellido del Esposo</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                            </div>
                                            <asp:TextBox ID="Txt_per_ap_casada_b" CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-3">
                                    <div class="form-group">
                                        <label class="form-control-label" for="example4cols1Input">Carnet Identidad</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                            </div>
                                            <asp:TextBox ID="Txt_per_num_doc_b" CssClass="form-control" type="number" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-3">
                                    <div class="form-group">
                                        <label class="form-control-label" for="example4cols6Input">Código del Funcionario</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                            </div>
                                            <asp:TextBox ID="Txt_per_id_b" CssClass="form-control numero" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-3">
                                    <div class="form-group">
                                        <label class="form-control-label" for="example4cols7Input">&nbsp</label>
                                        <asp:LinkButton ID="BtnBuscar" CssClass="btn btn-info btn-block" Text="<i class='fas fa-search'></i> Buscar" OnClick="BtnBuscar_Click" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div id="blockResultados" class="row" style="display: none">
            <div class="col">
                <div class="card">
                    <div class="card-header">
                        <div class=" ct-page-title">
                            <h3 class="mb-0">Listado de Ítem(s)</h3>
                            <p class="text-sm mb-0">
                                Detalle de los resultados de la búsqueda.
                            </p>
                        </div>
                    </div>
                    <div class="table-responsive py-4">
                        <asp:UpdatePanel ID="up_gv_items" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gv_items" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_items_PreRender" OnRowCommand="gv_items_RowCommand" DataKeyNames="as_per_id, per_num_doc, ci_id" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="as_per_id" HeaderText="Código" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="per_ap_paterno" HeaderText="Apellido Paterno" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="per_ap_materno" HeaderText="Apellido Materno" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="per_nombres" HeaderText="Nombre (s)" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="per_ap_casada" HeaderText="Apellido de Casada " HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="per_num_doc" HeaderText="C.I." HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="130px">
                                            <ItemTemplate>
                                                <asp:LinkButton CommandName="GetAssign" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn bg-gradient-inst text-white btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-plus fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Asignar Comisión/Interinato' Visible='<%# Eval("ci_id").ToString() != "" ? false : true %>' runat="server" />

                                                <asp:LinkButton CommandName="GetEdit" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-warning btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-edit fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Finalizar Comisión/Interinato' Visible='<%# Eval("ci_id").ToString() != "" ? true : false %>' runat="server" />
                                                <asp:LinkButton CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-times fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Anular Comisión/Interinato' Visible='<%# Eval("ci_id").ToString() != "" ? true : false %>' runat="server" />

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div class="modal fade" id="finalizarAsignacion" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                        <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                            <div class="modal-content bg-gradient-dark6">
                                <div class="modal-header">
                                </div>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="modal-body">
                                            <div class="text-center">
                                                <i class="ni ni-scissors ni-3x"></i>
                                                <h4 class="heading text-dark mt-4">¿Está seguro de Finalizar la Asignación?</h4>
                                            </div>
                                        </div>

                                        <div class="card-body px-lg-5 ">
                                            <hr class="my-3">
                                            <h6 class="heading-small text-muted">Datos Comisión/Interinato </h6>
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Nombre funcionario</div>
                                                    <div class="h5 font-weight-400 content-text content-text">
                                                        <asp:Literal ID="ltl_nombre_fun" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Código funcionario</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_cod_fun" runat="server" />
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Tipo asignación</div>
                                                    <div class="h5 font-weight-400 content-text content-text">
                                                        <asp:Literal ID="ltl_tipo_asig" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Ítem</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_item" runat="server" />
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Fecha inicio</div>
                                                    <div class="h5 font-weight-400 content-text content-text">
                                                        <asp:Literal ID="ltl_fecha_inicio" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Fecha fin</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_fecha_fin" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                            <hr class="my-3">

                                            <div class="form-group text-center">
                                                <label class="form-control-label" for="exampleFormControlSelect1">Nueva Fecha fin </label>
                                                <div class="input-group">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                    </div>
                                                    <asp:TextBox ID="txt_fin_asignacion" class="form-control datepickerDefault" runat="server" />
                                                </div>
                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_fin_asignacion" Display="Dynamic" ValidationGroup="finalizarCI" runat="server" />

                                            </div>

                                        </div>

                                        <div class="form-group text-center">
                                            <asp:LinkButton ID="btnFinalizarAsignacion" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btnFinalizarAsignacion_Click" ValidationGroup="finalizarCI" runat="server" />
                                            <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <div class="modal fade" id="modalGlosa" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
                        <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                            <div class="modal-content">

                                <div class="modal-body p-0">
                                    <div class="card bg-secondary border-0 mb-0">
                                        <div class="card-header">
                                            <div class="text-muted text-center mt-2 mb-3"><small>GLOSA</small></div>
                                        </div>
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <div class="card-body px-lg-5 py-lg-5">
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label class="form-control-label" for="exampleFormControlSelect1">Tipo Documento</label>
                                                                <asp:DropDownList ID="ddl_tipo_documento" AppendDataBoundItems="true" CssClass="form-control select2" runat="server"></asp:DropDownList>
                                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_tipo_documento" ValidationGroup="addGlosa" InitialValue="0" runat="server" />

                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label class="form-control-label" for="exampleFormControlSelect1">Fecha Documento</label>
                                                                <div class="input-group input-group-merge">

                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                                    </div>
                                                                    <asp:TextBox ID="txt_fechaMov" class="form-control datepickerDefault" runat="server" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <div class="form-group">
                                                                <label class="form-control-label" for="example3cols1Input">Descripción </label>

                                                                <asp:TextBox ID="txt_descripcion_add" CssClass="form-control" placeholder="Descripción" TextMode="multiline" Rows="4" runat="server" />
                                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_descripcion_add" Display="Dynamic" ValidationGroup="addGlosa" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="form-group text-center">
                                            <asp:UpdatePanel ID="panelGuardar" runat="server">
                                                <ContentTemplate>
                                                    <asp:LinkButton ID="btnGuardar" Text="<i class='fas fa-check mr-2'></i>Aceptar" ValidationGroup="addGlosa" CssClass="btn btn-success" OnClick="btnGuardar_Click" runat="server" />
                                                    <asp:LinkButton ID="btn_cancelar" class="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i>Cancelar" OnClick="btn_cancelar_Click" runat="server" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>

                                        </div>
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
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:HiddenField ID="hf_per_id" runat="server" />
                                        <asp:HiddenField ID="hf_ci_id" runat="server" />
                                        <div class="modal-body">
                                            <div class="py-3 text-center">
                                                <i class="ni ni-fat-remove ni-3x"></i>
                                                <h4 class="heading text-dark mt-4">¿Está seguro de anular la Asignación?</h4>
                                            </div>
                                        </div>
                                        <div class="form-group text-center">
                                            <asp:LinkButton ID="btnEliminarAsig" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btnEliminarAsig_Click" runat="server" />
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
    </div>
</asp:Content>


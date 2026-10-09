<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="Requisitos.aspx.cs" Inherits="Configuraciones_Requisitos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Administración de Requisitos</h6>

                    </div>
                    <div class="col-lg-6 col-5 text-right">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:LinkButton ID="btn_nuevo_requisito" CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-inst text-white rounded-circle shadow" Text="<i class='fas fa-plus'></i>" data-toggle="tooltip" data-original-title="Crear Requisito" OnClick="btn_nuevo_requisito_Click" runat="server" />

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
                                <h3 class="mb-0">Listado de Requisitos</h3>

                            </div>
                        </div>
                        <div class="text-right ml-auto">
                            <asp:UpdatePanel ID="panelMasivo" runat="server">
                                <ContentTemplate>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="table-responsive py-4">
                        <asp:UpdatePanel ID="up_gv_requisitos" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gv_requisitos" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_requisitos_PreRender" OnRowCommand="gv_requisitos_RowCommand" DataKeyNames="rq_id" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="rq_descripcion" HeaderText="Descripción del Requisito" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-left" />
                                        <asp:BoundField DataField="rq_categoria" HeaderText="Categoría" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="rq_fecha_creacion" HeaderText="Fecha Creación" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="130px">
                                            <ItemTemplate>
                                                <asp:LinkButton CommandName="GetAssign" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-success btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-tasks fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Adicionar Respuestas' runat="server" />
                                                <asp:LinkButton CommandName="GetEdit" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-warning btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-edit fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Editar Requisito' runat="server" />
                                                <asp:LinkButton CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-google-plus btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Eliminar Requisito' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="modal fade" id="modalAdicionarReq" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none; overflow-y: auto" aria-hidden="true" data-backdrop="static">
                        <div class="modal-dialog modal- modal-dialog-centered modal-xl" role="document">
                            <div class="modal-content">

                                <div class="modal-body p-0">
                                    <div class="card bg-secondary border-0 mb-0">
                                        <div class="card-header">
                                            <div class="text-muted text-center mt-2 mb-3"><small>REGISTRO DE REQUISITO</small></div>
                                        </div>
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <div class="card-body py-lg-4">
                                                    <div class="pb-5 text-center">
                                                        <a href="javascript:;">
                                                            <img src="../Content/img/theme/list.png" alt="Circle image" class="img-fluid rounded-circle shadow" style="width: 100px;">
                                                        </a>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-6 col-md-6">
                                                            <div class="form-group">
                                                                <label class="form-control-label">Descripción </label>
                                                                <div class="input-group input-group-merge">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text"><i class="fas fa-pen"></i></span>
                                                                    </div>
                                                                    <asp:TextBox ID="txt_descripcion" CssClass="form-control" runat="server" />
                                                                </div>
                                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_descripcion" ValidationGroup="addRequisito" runat="server" />

                                                            </div>
                                                        </div>
                                                        <div class="col-sm-6 col-md-3">
                                                            <div class="form-group">
                                                                <label class="form-control-label" for="exampleFormControlSelect1">Categoría</label>
                                                                <asp:DropDownList ID="ddl_categoria" AppendDataBoundItems="true" CssClass="form-control select2" data-minimum-results-for-search="Infinity" OnSelectedIndexChanged="ddl_categoria_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" InitialValue="0" ControlToValidate="ddl_categoria" Display="Dynamic" ValidationGroup="addRequisito" runat="server" />

                                                            </div>
                                                        </div>
                                                        <div id="nuevo_cat" class="col-sm-6 col-md-3" runat="server">
                                                            <div class="form-group">
                                                                <label class="form-control-label text-vimeo">Descripción Categoría </label>
                                                                <asp:Label Text="Descripción Categoría" CssClass="form-control-label text-vimeo" runat="server" />
                                                                <div class="input-group input-group-merge">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text"><i class="fas fa-pen"></i></span>
                                                                    </div>
                                                                    <asp:TextBox ID="txt_desc_categoria" CssClass="form-control letras" runat="server" />
                                                                </div>
                                                                <asp:RequiredFieldValidator ID="rf_desc_categoria" CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_desc_categoria" ValidationGroup="addRequisito" runat="server" />

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="form-group text-right pt-3">
                                                        <asp:LinkButton ID="btn_adicionar_requisito" Text="<i class='fas fa-save mr-2'></i>Guardar" ValidationGroup="addRequisito" CssClass="btn btn-success" OnClick="btn_adicionar_requisito_Click" runat="server" />
                                                        <asp:LinkButton ID="btn_cerrar" Text="<i class='fas fa-times mr-2'></i>Cancelar" CssClass="btn btn-outline-github" OnClick="btn_cerrar_Click" runat="server" />
                                                        <asp:HiddenField ID="hf_rq_id" runat="server" />
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal fade" id="modalAdicionarResp" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none; overflow-y: auto" aria-hidden="true" data-backdrop="static">
                        <div class="modal-dialog modal- modal-dialog-centered modal-xl" role="document">
                            <div class="modal-content">

                                <div class="modal-body p-0">
                                    <div class="card bg-secondary border-0 mb-0">
                                        <div class="card-header">
                                            <div class="text-muted text-center mt-2 mb-3"><small>REGISTRO DE RESPUESTAS</small></div>
                                        </div>
                                        <div class="card-body py-lg-4">

                                            <div class="ct-page-title">
                                                <h4 class="h3 text-uppercase" style="margin-bottom: unset;">Categorías</h4>
                                                <p class="description" style="margin-bottom: 0.5rem;">Las categorías mostradas pertenecen a la Unidad Ejecutora de la planilla creada.</p>
                                            </div>
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <div class="row">
                                                        <div class="col-sm-6 col-md-4">
                                                            <div class="form-group">
                                                                <label class="form-control-label">Descripción </label>
                                                                <div class="input-group input-group-merge">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text"><i class="fas fa-pen"></i></span>
                                                                    </div>
                                                                    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" />
                                                                </div>
                                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_descripcion" ValidationGroup="addRequisito" runat="server" />

                                                            </div>
                                                        </div>
                                                        <div class="col-sm-6 col-md-4">
                                                            <div class="form-group">
                                                                <label class="form-control-label" for="exampleFormControlSelect1">Categoría</label>
                                                                <asp:DropDownList ID="DropDownList1" AppendDataBoundItems="true" CssClass="form-control select2" data-minimum-results-for-search="Infinity" OnSelectedIndexChanged="ddl_categoria_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" InitialValue="0" ControlToValidate="ddl_categoria" Display="Dynamic" ValidationGroup="addRequisito" runat="server" />

                                                            </div>
                                                        </div>
                                                        <div id="Div1" class="col-sm-6 col-md-4" runat="server">
                                                            <div class="form-group">
                                                                <label class="form-control-label text-vimeo">Descripción Categoría </label>
                                                                <asp:Label Text="Descripción Categoría" CssClass="form-control-label text-vimeo" runat="server" />
                                                                <div class="input-group input-group-merge">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text"><i class="fas fa-pen"></i></span>
                                                                    </div>
                                                                    <asp:TextBox ID="TextBox2" CssClass="form-control letras" runat="server" />
                                                                </div>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_desc_categoria" ValidationGroup="addRequisito" runat="server" />

                                                            </div>
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <asp:UpdatePanel ID="up_btn_adicionar_fr_masivo" runat="server">
                                                <ContentTemplate>
                                                    <%--                                                    <div id="no_existe_frec_t" class="ct-page-title" runat="server">
                                                        <h4 class="h3 text-uppercase" style="margin-bottom: unset;">Frecuencias libres</h4>
                                                        <p class="description" style="margin-bottom: 0.5rem;">En la siguiente tabla se muestra las frecuencias libres de la categoría seleccionada.</p>
                                                    </div>--%>

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
                                                                <asp:LinkButton ID="btn_adicionar_fr_masivo" CssClass="btn btn-slack btn-block" Text="<i class='fas fa-share'></i> Adicionar" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <%--                                <div class="table-responsive py-2">
                                                <asp:UpdatePanel ID="up_gv_frecuencias" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="gv_resp_requisitos" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_resp_requisitos_PreRender" OnRowCommand="gv_resp_requisitos_RowCommand" DataKeyNames="fr_id" runat="server">
                                                            <Columns>
                                                                <asp:BoundField DataField="haber_basico" HeaderText="Descripción" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:0.00}" />
                                                                <asp:BoundField DataField="fr_fecha_inicio" HeaderText="Fecha inicio" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="fr_fecha_fin" HeaderText="Fecha fin" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
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
                                            </div>--%>
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
                                                    <asp:LinkButton ID="LinkButton1" Text="<i class='fas fa-save mr-2'></i>Guardar" ValidationGroup="addRequisito" CssClass="btn btn-success" OnClick="btn_adicionar_requisito_Click" runat="server" />
                                                    <asp:LinkButton ID="LinkButton2" Text="<i class='fas fa-times mr-2'></i>Cancelar" CssClass="btn btn-outline-github" OnClick="btn_cerrar_Click" runat="server" />
                                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal fade" id="eliminarRequisito" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                        <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                            <div class="modal-content bg-gradient-dark6">
                                <div class="modal-header">
                                </div>

                                <asp:UpdatePanel ID="up_btn_eilminar_req" runat="server">
                                    <ContentTemplate>
                                        <div class="modal-body">
                                            <div class="py-3 text-center">
                                                <i class="ni ni-fat-remove ni-3x"></i>
                                                <h4 class="heading text-dark mt-4">¿Esta seguro de eliminar el Requisito?</h4>
                                            </div>
                                        </div>
                                        <div class="form-group text-center">
                                            <asp:LinkButton ID="btn_eilminar_req" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btn_eilminar_req_Click" runat="server" />
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
</asp:Content>


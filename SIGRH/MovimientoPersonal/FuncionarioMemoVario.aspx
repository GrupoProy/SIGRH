<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="FuncionarioMemoVario.aspx.cs" Inherits="MovimientoPersonal_FuncionarioMemoVario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Asignación de Memorándum</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid mt--6">
        <div class="row">
            <div class="col-lg-7">
                <div class="card-wrapper">
                    <!-- Form controls -->
                    <div class="card">
                        <div class="card-header">
                            <div class="row align-items-center">
                                <div class="col-8">
                                    <div class=" ct-page-title">
                                        <h3 class="mb-0">Detalle Memorándum</h3>
                                        <p class="text-sm mb-0">
                                            Formulario para la generación del memorándum por asignar al funcionario.
                                        </p>
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="card-body">
                            <h6 class="heading-small text-muted d-inline-flex icon-title-h"><i class="fas fa-print icon-h"></i>Datos Memorándum Asignar</h6>
                            <div class="icon-content-h">

                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class="form-group">
                                            <label class="form-control-label">Tipo de Memorándum</label>
                                            <asp:DropDownList ID="ddl_tenor" AppendDataBoundItems="true" CssClass="form-control select2" runat="server"></asp:DropDownList>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_tenor" InitialValue="0" Display="Dynamic" ValidationGroup="addGuardar" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <label class="form-control-label">Fecha Inicio</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend  ">
                                                    <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                </div>
                                                <asp:TextBox ID="txt_fecha_inicio" class="form-control datepickerDefault" AutoComplete="off" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_fecha_inicio" ValidationGroup="addGuardar" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <label class="form-control-label">Fecha Fin</label>
                                            <div class="input-group input-group-merge">

                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                </div>
                                                <asp:TextBox ID="txt_fecha_fin" class="form-control datepickerDefault" AutoComplete="off" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="pt-2">


                                <h6 class="heading-small text-muted d-inline-flex icon-title-h"><i class="fas fa-newspaper icon-h"></i>Datos adicionales al tenor</h6>
                                <div class="icon-content-h">

                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label class="form-control-label">Texto adicional al tenor</label>
                                                <asp:TextBox ID="txt_adicional_tenor" class="form-control" AutoComplete="off" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-3">

                                            <div class="form-group">
                                                <label class="form-control-label">Nro. Memo Anterior</label>
                                                <div class="input-group input-group-merge">

                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text"><i class="fas fa-hashtag"></i></span>
                                                    </div>
                                                    <asp:TextBox ID="txt_nro_memo_ant" class="form-control" AutoComplete="off" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <label class="form-control-label">Fecha Memo Anterior</label>
                                                <div class="input-group input-group-merge">

                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                    </div>
                                                    <asp:TextBox ID="txt_fecha_memo_ant" class="form-control datepickerDefault" AutoComplete="off" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="icon-content-h">
                                <div class="row">

                                    <div class="col-lg-12">
                                        <div class="form-group text-right">
                                            <label class="form-control-label">&nbsp</label>
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <asp:LinkButton ID="btn_guardar_item" CssClass="btn btn-success btn-block" Text="<i class='fas fa-save'></i> Asignar Memorándum" OnClick="btn_guardar_item_Click" ValidationGroup="addGuardar" runat="server" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- HTML5 inputs -->
                    <div class="card" id="blockMemos">
                        <div class="card-header">
                            <div class=" ct-page-title">
                                <h3 class="mb-0">Memorándums asignados anteriormente</h3>
                                <p class="text-sm mb-0">
                                    Histórico de los memorándums asignados al funcionario.
                                </p>
                            </div>
                        </div>
                        <div class="table-responsive pt-3 pb-4">
                            <asp:UpdatePanel ID="panelGV_memos" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gv_memos" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_memos_PreRender" OnRowCommand="gv_memos_RowCommand" DataKeyNames="mv_id" runat="server">
                                        <Columns>
                                            <asp:BoundField DataField="mv_tipo" HeaderText="Descripción" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-bold" />
                                            <asp:BoundField DataField="mv_nro_memo" HeaderText="Nro. Memo" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="gl_glosa" HeaderText="Autorización" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="gl_fecha_doc" HeaderText="Fecha autorización" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="mv_fecha_inicio" HeaderText="Fecha emisión memorándum" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <%--                                            <asp:BoundField DataField="mv_fecha_fin" HeaderText="Fecha Fin" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="mv_texto_adicional_tenor" HeaderText="Texto adicional tenor" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />--%>
                                            <asp:BoundField DataField="estado" HeaderText="Estado" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="40px">
                                                <ItemTemplate>
                                                    <asp:LinkButton CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-times fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Anular' Visible='<%# Eval("estado").ToString() != "VALIDADO" ? true : false %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div id="no_existe_datos" class="card-body" runat="server">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <p class="text-sm grid-notify-success">No existen datos registrados. </p>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="modal fade" id="eliminarMemo" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                            <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                                <div class="modal-content bg-gradient-dark6">
                                    <div class="modal-header">
                                    </div>

                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:HiddenField ID="hf_mv_id" runat="server" />
                                            <div class="modal-body">
                                                <div class="py-3 text-center">
                                                    <i class="ni ni-fat-remove ni-3x"></i>
                                                    <h4 class="heading text-dark mt-4">¿Está seguro de anular el memorándum asignado?</h4>
                                                </div>
                                            </div>
                                            <div class="form-group text-center">
                                                <asp:LinkButton ID="btnEliminarTenor" OnClick="btnEliminarTenor_Click" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" runat="server" />
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
            <div class="col-lg-5">
                <div class="card-wrapper">
                    <!-- Sizes -->
                    <div class="card card-profile">
                        <div class="row justify-content-center">
                            <div class="col-lg-3 order-lg-2">
                                <div class="card-profile-image">
                                    <a href="#">
                                        <asp:Image ID="imgFun" class="rounded-circle" runat="server" />
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="card-header text-center border-0 pt-8 pt-md-4 pb-0 pb-md-4">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:LinkButton ID="btn_estado" class="btn btn-sm btn-info float-right" OnClick="btn_estado_Click" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                        <div class="card-body pt-0">
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
                                        </div>

                                        <hr class="my-3">
                                        <h6 class="heading-small text-muted d-inline-flex icon-title-h"><i class="fas fa-briefcase icon-h"></i>Datos laborales </h6>
                                        <div class="icon-content-h">
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Ítem</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_item" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Puesto</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_puesto" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
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
                                        <hr class="my-2">
                                        <h6 class="heading-small text-muted d-inline-flex icon-title-h"><i class="fas fa-money-bill-alt icon-h"></i>Escalafón </h6>
                                        <div class="icon-content-h">
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Cargo</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_cargo" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Haber Básico (Bs)</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_haber_basico" runat="server" />
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Código Escalafón</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_cod_esc" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="content-text-label">Clase</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_clase" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="content-text-label">Nivel Salarial</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_nivel_salarial" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <hr class="my-2">
                                        <h6 class="heading-small text-muted d-inline-flex icon-title-h"><i class="fas fa-building icon-h"></i>Estructura Programática</h6>
                                        <div class="icon-content-h">
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Ubicación</div>
                                                    <div class="h5 font-weight-400 content-text content-text">
                                                        <asp:Literal ID="ltl_ubicacion" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Categoría Programática</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_programatica" runat="server" />
                                                    </div>
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
        <div class="modal fade" id="modalGlosa" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                <div class="modal-content">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="modal-body p-0">
                                <div class="card bg-secondary border-0 mb-0">
                                    <div class="card-header">
                                        <div class="text-muted text-center mt-2 mb-3">
                                            <h4 class="header-modal">GLOSA</h4>
                                        </div>
                                    </div>
                                    <div class="card-body px-lg-5 py-lg-5">
                                        <div class="row">
                                            <div id="d_tipo_doc" class="col-md-6" runat="server">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="exampleFormControlSelect1">Tipo Documento</label>
                                                    <asp:DropDownList ID="ddl_tipo_documento" AppendDataBoundItems="true" CssClass="form-control select2" OnSelectedIndexChanged="ddl_tipo_documento_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_tipo_documento" Display="Dynamic" ValidationGroup="addGlosa" InitialValue="0" runat="server" />
                                                </div>
                                            </div>
                                            <div id="d_num_doc" class="col-md-4" visible="false" runat="server">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="exampleFormControlSelect1">Número de documento</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_num_doc" class="form-control numero" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="d_fecha_doc" class="col-md-6" runat="server">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="exampleFormControlSelect1">Fecha Documento</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_fechaMov" AutoComplete="off" class="form-control datepickerDefault" runat="server" />
                                                    </div>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_fechaMov" Display="Dynamic" ValidationGroup="addGlosa" runat="server" />
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
                                        <div class="row pt-3">
                                            <div class="col-md-6">
                                                <asp:LinkButton ID="btn_adicionar_glosa" Text="<i class='fas fa-check mr-2'></i>Guardar" OnClick="btn_adicionar_glosa_Click" OnClientClick="if (Page_ClientValidate('addGlosa')) { MostrarMascara(true); }" ValidationGroup="addGlosa" CssClass="btn btn-success btn-block" runat="server" />
                                            </div>
                                            <div class="col-md-6">
                                                <asp:LinkButton ID="btn_cancelar_glosa" class="btn btn-outline-github btn-block" Text="<i class='fas fa-times mr-2'></i>Cancelar" OnClick="btn_cancelar_glosa_Click" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <asp:UpdateProgress ID="up2" AssociatedUpdatePanelID="panelGV_memos" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
</asp:Content>


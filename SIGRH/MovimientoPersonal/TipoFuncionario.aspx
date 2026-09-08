<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="TipoFuncionario.aspx.cs" Inherits="MovimientoPersonal_TipoFuncionario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Asignación Tipo Funcionario</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid mt--6">

        <div class="row">
                     <div class="col-lg-7 mt-5">
                <div class="card-wrapper">
                    <!-- HTML5 inputs -->
                    <div class="card" id="blockMemos">
                        <div class="card-header">
                            <div class=" ct-page-title">
                                <h3 class="mb-0">Asignación situación funcionario</h3>
                                <p class="text-sm mb-0">
                                    Histórico de bloqueos al funcionario.
                                </p>
                            </div>
                        </div>
                        <div class="table-responsive py-4">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gv_situacion_fun" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_situacion_fun_PreRender" OnRowCommand="gv_situacion_fun_RowCommand" DataKeyNames="st_id" runat="server">
                                        <Columns>
                                            <asp:BoundField DataField="st_tipo_situacion" HeaderText="Tipo Fun." HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="cat_descripcion" HeaderText="Descripción" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="st_fecha_inicio" HeaderText="Fecha Inicio" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="st_fecha_fin" HeaderText="Fecha Fin" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />

                                            <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="130px">
                                                <ItemTemplate>
                                                    <asp:LinkButton CommandName="GetDelete" CssClass="table-action table-action-delete" data-toggle='tooltip' data-original-title='Anular' Text=" <i class='fas fa-trash'></i>" Visible='<%# Eval("st_tipo_situacion").ToString() != "TB" ? false : true %>' CommandArgument="<%# Container.DataItemIndex %>" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>

                            </asp:UpdatePanel>
                        </div>


                    </div>
                    <!-- Form controls -->
                    <div class="card">
                        <div class="card-header">
                            <div class="row align-items-center">
                                <div class="col-8">
                                    <div class=" ct-page-title">
                                        <h3 class="mb-0">Detalle situación funcionario</h3>
                                        <p class="text-sm mb-0">
                                            Formulario para asignar el bloqueo al funcionario seleccionado.
                                        </p>
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="card-body">
                            <%--           <div class="row">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label class="form-control-label">Tipo de Situación</label>
                                        <asp:DropDownList ID="ddl_situacion_persona" AppendDataBoundItems="true" CssClass="form-control select2" data-minimum-results-for-search="Infinity" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label class="form-control-label">Tipo de Situación</label>
                                        <asp:DropDownList ID="ddl_tipo_funcionario" AppendDataBoundItems="true" CssClass="form-control" data-minimum-results-for-search="Infinity" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>--%>
                            <div class="row">
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label class="form-control-label">Tipo de Situación</label>
                                        <asp:DropDownList ID="ddl_situacion_persona" AppendDataBoundItems="true" CssClass="form-control select2" data-minimum-results-for-search="Infinity" runat="server"></asp:DropDownList>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_situacion_persona" Display="Dynamic" ValidationGroup="asignarTB" runat="server" />

                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label class="form-control-label" for="exampleFormControlSelect1">Fecha inicio</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                            </div>
                                            <asp:TextBox ID="txt_fecha_inicio" class="form-control datepickerDefault" runat="server" />

                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_fecha_inicio" Display="Dynamic" ValidationGroup="asignarTB" runat="server" />

                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label class="form-control-label" for="exampleFormControlSelect1">Fecha fin </label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                            </div>
                                            <asp:TextBox ID="txt_fecha_fin" class="form-control datepickerDefault" runat="server" />
                                        </div>

                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-8">
                                </div>
                                <div class="col-lg-4">
                                    <asp:UpdatePanel ID="panelImpresion" runat="server">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="btnAsignar" CssClass="btn btn-success btn-block btn-round btn-icon" Text="<span class='btn-inner--icon'><i class='fas fa-users-cog'></i></span><span class='btn-inner--text'>Asignar</span>" ValidationGroup="asignarTB" OnClick="btnAsignar_Click" runat="server" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
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
                                                <asp:UpdatePanel ID="panelGuardar" runat="server">
                                                    <ContentTemplate>
                                                        <div class="card-body px-lg-5 py-lg-5">
                                                            <div class="row">
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label class="form-control-label" for="exampleFormControlSelect1">Tipo Documento</label>
                                                                        <asp:DropDownList ID="ddl_tipo_documento" AppendDataBoundItems="true" CssClass="form-control select2" data-minimum-results-for-search="Infinity" runat="server"></asp:DropDownList>
                                                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_tipo_documento" ValidationGroup="addGlosa" InitialValue="0" runat="server" />

                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label class="form-control-label" for="exampleFormControlSelect1">Fecha Documento</label>
                                                                        <div class="input-group">

                                                                            <div class="input-group-prepend">
                                                                                <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                                            </div>
                                                                            <asp:TextBox ID="txt_fechaMov" class="form-control datepicker" runat="server" />
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
                                                        <div class="form-group text-center">
                                                            <asp:LinkButton ID="btnGuardaritem" Text="<i class='fas fa-print mr-2'></i>Guardar" ValidationGroup="addGlosa" CssClass="btn btn-success" OnClick="btnGuardaritem_Click" runat="server" />
                                                            <asp:LinkButton ID="btn_cancelar" class="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i>Cancelar" OnClick="btn_cancelar_Click" runat="server" />
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <div class="modal fade" id="eliminarAsignacion" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                                <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                                    <div class="modal-content bg-gradient-dark6">
                                        <div class="modal-header">
                                        </div>
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:HiddenField ID="hf_st_id" runat="server" />
                                                <div class="modal-body">
                                                    <div class="py-3 text-center">
                                                        <i class="ni ni-fat-remove ni-3x"></i>
                                                        <h4 class="heading text-dark mt-4">¿Está seguro de eliminar la Asignación?</h4>
                                                    </div>
                                                </div>
                                                <div class="form-group text-center">
                                                    <asp:LinkButton ID="btnEliminarAsig" Text="<i class='fas fa-check-circle mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btnEliminarAsig_Click" runat="server" />
                                                    <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times-circle mr-2"></i>Cancelar</button>
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
            <div class="col-lg-5">
                <div class="card-wrapper mt-5 ">
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

                            <asp:LinkButton ID="btn_estado" class="btn btn-sm btn-info float-right" runat="server" />


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
                                        <h6 class="heading-small text-muted">Estructura Programática </h6>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Ubicación</div>
                                                <div class="h5 font-weight-400 content-text content-text">
                                                    <asp:Literal ID="ltl_ubicacion" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Categoría</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_programatica" runat="server" />
                                                </div>
                                            </div>
                                        </div>

                                        <hr class="my-2">
                                        <h6 class="heading-small text-muted">Escalafón </h6>
                                        <div class="content-text-label">Cargo</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_cargo" runat="server" />
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Código Escalafón</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_cod_esc" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Clase</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_clase" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Nivel Salarial</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_nivel_salarial" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Haber Básico (Bs)</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_haber_basico" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <hr class="my-2">
                                        <h6 class="heading-small text-muted">Información adicional </h6>

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
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>


                </div>
            </div>
   

        </div>


        <asp:UpdateProgress ID="up1" AssociatedUpdatePanelID="panelGuardar" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
</asp:Content>


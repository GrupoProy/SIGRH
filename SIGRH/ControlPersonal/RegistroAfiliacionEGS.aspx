<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="RegistroAfiliacionEGS.aspx.cs" Inherits="BienestarSocial_RegistroAfiliacionEGS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Afiliacion a Ente Gestor de Salud</h6>
                    </div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div id="block_nuevo_familiar" class="col-lg-6 col-5 text-right" style="display: block">
                                <asp:LinkButton ID="btn_nuevo_familiar" CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-inst text-white rounded-circle shadow" Text="<i class='fas fa-plus'></i>" data-toggle="tooltip" data-placement='top' data-original-title="Adicionar Nuevo Familiar" OnClick="btn_nuevo_familiar_Click" runat="server" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid mt--6">
        <div class="row">
            <div class="col-lg-7">
                <div class="card-wrapper">
                    <div class="card">
                        <div class="card-header">
                            <div class=" ct-page-title">
                                <h3 class="mb-0 text-org2">Datos Afiliación</h3>
                                <p class="text-sm mb-0">
                                    Detalle del Ente Gestor de Salud del funcionario seleccionado.
                                </p>
                            </div>
                        </div>
                        <div class="card-body" style="padding-bottom: unset">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-sm-6 col-md-4">
                                            <div class="form-group">
                                                <label class="form-control-label">Caja Aseguradora</label>
                                                <asp:TextBox ID="txt_nombre_caja_afiliado" CssClass="form-control letras" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-sm-6 col-md-4">
                                            <div class="form-group">
                                                <label class="form-control-label">Fecha Afiliación</label>
                                                <asp:TextBox ID="txt_fecha_afiliado" CssClass="form-control letras" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-sm-6 col-md-4">
                                            <div class="form-group">
                                                <label class="form-control-label">Número Asegurado</label>
                                                <asp:TextBox ID="txt_nro_afiliado" CssClass="form-control letras" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div id="block_policlinico" class="col-sm-6 col-md-6" runat="server">
                                            <div class="form-group">
                                                <label class="form-control-label" for="exampleFormControlSelect1">Policlínico</label>
                                                <asp:DropDownList ID="ddl_tipo_policlinico" AppendDataBoundItems="true" CssClass="form-control select2" AutoPostBack="true" OnSelectedIndexChanged="ddl_tipo_policlinico_SelectedIndexChanged" data-minimum-results-for-search="Infinity" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="form-control-label" for="example3cols1Input">&nbsp</label>
                                                <asp:LinkButton ID="btn_asigFamiliares" CssClass="btn btn-info btn-block btn-icon" Text="<span class='btn-inner--icon'><i class='fas fa-users'></i></span><span class='btn-inner--text'>Ver Familiares</span>" OnClick="btn_asigFamiliares_Click" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <asp:HiddenField ID="aux_per_id" runat="server" />
                                    <asp:HiddenField ID="aux_as_id" runat="server" />
                                    <asp:HiddenField ID="aux_ae_empleador" runat="server" />
                                    <asp:HiddenField ID="aux_ae_id" runat="server" />
                                    <asp:HiddenField ID="aux_pf_id" runat="server" />
                                    <asp:HiddenField ID="aux_aeb_id" runat="server" />
                                    <asp:HiddenField ID="aux_fa_id" runat="server" />
                                    <asp:HiddenField ID="aux_pf_fecha_nac" runat="server" />
                                    <asp:HiddenField ID="aux_pf_tipo_parentesco" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="table-responsive py-4" id="block_gvFamiliares" style="display: none">
                            <asp:UpdatePanel ID="panelGvFamiliares" runat="server">
                                <ContentTemplate>
                                    <h6 class="heading-small text-muted pl-3">Familiares Registrados</h6>
                                    <asp:GridView ID="gv_familiares" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_familiares_PreRender" OnRowCommand="gv_familiares_RowCommand" DataKeyNames="pf_id" runat="server">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-CssClass="text-center" HeaderStyle-Width="50px">
                                                <HeaderTemplate>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <label class="custom-toggle custom-toggle-warning">
                                                        <asp:CheckBox ID="chk_familiar" runat="server" />
                                                        <span class="custom-toggle-slider rounded-circle" data-label-off="No" data-label-on="Si"></span>
                                                    </label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="tipo_parentesco" HeaderText="Tipo parentesco" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="pf_paterno" HeaderText="Apellido Paterno" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="pf_materno" HeaderText="Apellido Materno" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="pf_nombres" HeaderText="Nombre(s)" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="pf_sexo_descripcion" HeaderText="Sexo/Género" HeaderStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="pf_fecha_nac" HeaderText="Fecha Nacimiento" HeaderStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="pf_estado_vivo_descripcion" HeaderText="Estado Vivo" HeaderStyle-CssClass="text-center" />
                                            <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="130px">
                                                <ItemTemplate>
                                                    <asp:LinkButton CommandName="GetEdit" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-warning btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-edit fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Editar Datos Familiar' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="card-body" style="padding-top: unset">
                            <asp:UpdatePanel ID="panelGuardarAfiliacion" runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <div id="block_tipo_avc" class="col-sm-6 col-md-6" style="display: none">
                                            <div class="form-group">
                                                <label class="form-control-label" for="exampleFormControlSelect1">Afiliado por</label>
                                                <asp:DropDownList ID="ddl_tipo_avc" AppendDataBoundItems="true" CssClass="form-control select2" data-minimum-results-for-search="Infinity" runat="server"></asp:DropDownList>
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="ddl_tipo_avc" ValidationGroup="addItem" runat="server" />
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="form-control-label" for="example3cols1Input">&nbsp</label>
                                                <asp:LinkButton ID="btn_guardar_afiliacion" CssClass="btn btn-success btn-block btn-icon" Text="<span class='btn-inner--icon'><i class='fas fa-save'></i></span><span class='btn-inner--text'>Guardar Afiliación</span>" OnClick="btn_guardar_afiliacion_Click" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        
                        <%-- Modal Editar Datos Familiares --%>
                        <div class="modal fade" id="modalEditarFamiliar" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
                            <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                                <div class="modal-content">
                                    <div class="modal-body p-0">
                                        <div class="card bg-secondary border-0 mb-0">
                                            <div class="card-header">
                                                <div class="text-muted text-center mt-2 mb-3">
                                                    <h4 class="header-modal">EDITAR DATOS FAMILIAR</h4>
                                                </div>
                                            </div>
                                            <asp:UpdatePanel ID="panelEditarFamiliar" runat="server">
                                                <ContentTemplate>
                                                    <div class="card-body px-lg-5 py-lg-5">
                                                        <div class="pb-5 text-center">
                                                            <a href="javascript:;">
                                                                <img src="../Content/img/theme/family.png" alt="Circle image" class="img-fluid rounded-circle shadow" style="width: 100px;">
                                                            </a>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-6 col-md-4">
                                                                <div class="form-group">
                                                                    <label class="form-control-label">Apellido Paterno</label>
                                                                    <div class="input-group input-group-merge">
                                                                        <div class="input-group-prepend">
                                                                            <span class="input-group-text"><i class="fas fa-user-tag"></i></span>
                                                                        </div>
                                                                        <asp:TextBox ID="txt_ap_paterno_fam" CssClass="form-control letras" runat="server" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-6 col-md-4">
                                                                <div class="form-group">
                                                                    <label class="form-control-label">Apellido Materno</label>
                                                                    <div class="input-group input-group-merge">
                                                                        <div class="input-group-prepend">
                                                                            <span class="input-group-text"><i class="fas fa-user-tag"></i></span>
                                                                        </div>
                                                                        <asp:TextBox ID="txt_ap_materno_fam" CssClass="form-control letras" runat="server" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label class="form-control-label">Nombres</label>
                                                                    <div class="input-group input-group-merge">
                                                                        <div class="input-group-prepend">
                                                                            <span class="input-group-text"><i class="fas fa-user-tag"></i></span>
                                                                        </div>
                                                                        <asp:TextBox ID="txt_nombres_fam" CssClass="form-control letras" runat="server" />
                                                                    </div>
                                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_nombres_fam" ValidationGroup="addFamiliar" runat="server" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label class="form-control-label">Apellido Esposo</label>
                                                                    <div class="input-group input-group-merge">
                                                                        <div class="input-group-prepend">
                                                                            <span class="input-group-text"><i class="fas fa-user-tag"></i></span>
                                                                        </div>
                                                                        <asp:TextBox ID="txt_ap_esposo_fam" CssClass="form-control letras" runat="server" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-6 col-md-4">
                                                                <div class="form-group">
                                                                    <label class="form-control-label" for="exampleFormControlSelect1">Tipo Parentesco</label>
                                                                    <asp:DropDownList ID="ddl_pf_tipo_parentesco" AppendDataBoundItems="true" CssClass="form-control select2" AutoPostBack="true" data-minimum-results-for-search="Infinity" runat="server"></asp:DropDownList>
                                                                </div>
                                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_pf_tipo_parentesco" InitialValue="0" Display="Dynamic" ValidationGroup="addFamiliar" runat="server" />
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label class="form-control-label">Género</label>
                                                                    <asp:DropDownList ID="ddl_tipo_genero" CssClass="form-control select2" AppendDataBoundItems="true" data-minimum-results-for-search="Infinity" runat="server" />
                                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_tipo_genero" Display="Dynamic" ValidationGroup="addFamiliar" InitialValue="0" runat="server" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label class="form-control-label">Fecha Nacimiento</label>
                                                                    <div class="input-group input-group-merge">
                                                                        <div class="input-group-prepend  ">
                                                                            <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                                        </div>
                                                                        <asp:TextBox ID="txt_fecha_nac_fam" AutoComplete="off" class="form-control datepickerDefault" runat="server" />
                                                                    </div>
                                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_fecha_nac_fam" Display="Dynamic" ValidationGroup="addFamiliar" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-6 col-md-4">
                                                                <div class="form-group">
                                                                    <label class="form-control-label">Estado Vivo</label>
                                                                    <asp:DropDownList ID="ddl_estado_vivo" CssClass="form-control select2" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddl_estado_vivo_SelectedIndexChanged" data-minimum-results-for-search="Infinity" runat="server" />
                                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_estado_vivo" Display="Dynamic" ValidationGroup="addFamiliar" InitialValue="0" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div id="block_fechaDefuncion" class="col-md-4" style="display: none">
                                                                <div class="form-group">
                                                                    <label class="form-control-label">Fecha Defunción</label>
                                                                    <div class="input-group input-group-merge">
                                                                        <div class="input-group-prepend  ">
                                                                            <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                                        </div>
                                                                        <asp:TextBox ID="txt_fecha_defuncion" AutoComplete="off" class="form-control datepickerDefault" runat="server" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <div class="form-group text-center">
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <asp:LinkButton ID="btn_guardar_familiar" Text="<i class='fas fa-check mr-2'></i>Guardar" ValidationGroup="addFamiliar" CssClass="btn btn-success" OnClick="btn_guardar_familiar_Click" OnClientClick="if (Page_ClientValidate('addFamiliar')) { MostrarMascara(true); }" runat="server" />
                                                        <asp:LinkButton ID="btn_cancelar_familiar" class="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i>Cancelar" OnClick="btn_cancelar_familiar_Click" runat="server" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card">
                        <div class="card-header">
                            <div class=" ct-page-title">
                                <h3 class="mb-0">Familiares Afiliados al Ente Gestor de Salud</h3>
                                <p class="text-sm mb-0">
                                    Detalle de los familiares afiliados al Ente Gestor de Salud del funcionario seleccionado.
                                </p>
                            </div>
                        </div>
                        <div class="table-responsive py-4">
                            <asp:UpdatePanel ID="panelGvAfiliacion" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gv_afiliacion_familiares" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_afiliacion_familiares_PreRender" OnRowCommand="gv_afiliacion_familiares_RowCommand" DataKeyNames="aeb_id" runat="server">
                                        <Columns>
                                            <asp:BoundField DataField="pf_tipo_parentesco" HeaderText="Tipo parentesco" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="pf_paterno" HeaderText="Apellido Paterno" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="pf_materno" HeaderText="Apellido Materno" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="pf_nombres" HeaderText="Nombre(s)" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="pf_fecha_nac" HeaderText="Fecha Nacimiento" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="aeb_fecha_afi" HeaderText="Fecha Afiliación" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="aeb_afi_por" HeaderText="Formulario Afiliación" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="130px">
                                                <ItemTemplate>
                                                    <asp:LinkButton CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-google-plus btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Eliminar Afiliación' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="col-md-12">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div id="block_familia" runat="server">
                                            <span class="badge badge-pill badge-info">El funcionario no tiene familiares afiliados.</span>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>

                    <%-- Eliminar Afiliación Familiar --%>
                    <div class="modal fade" id="eliminarAfiliacionFamiliar" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                        <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                            <div class="modal-content bg-gradient-dark6">
                                <asp:UpdatePanel ID="panelEliminarFamiliar" runat="server">
                                    <ContentTemplate>
                                        <div class="modal-body">
                                            <div class="py-3 text-center">
                                                <i class="ni ni-fat-remove ni-3x"></i>
                                                <h4 class="heading text-dark mt-4">¿Esta seguro de eliminar la afiliación?</h4>
                                            </div>
                                        </div>
                                        <div class="form-group text-center">
                                            <asp:LinkButton ID="btn_eliminar_afiliacion_familiar" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btn_eliminar_afiliacion_familiar_Click" runat="server" />
                                            <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-5">
                <div class="card-wrapper">
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
                                    <asp:LinkButton ID="btn_editar_domicilio" CssClass="btn btn-primary btn-sm float-left" OnClick="btn_editar_domicilio_Click" runat="server">Editar Domicilio</asp:LinkButton>
                                </ContentTemplate>
                            </asp:UpdatePanel>
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
                                        <h6 class="heading-small text-muted">Datos Personales</h6>
                                        <div class="row">
                                            <div class="col-lg-4">
                                                <div class="content-text-label">Fecha Nacimiento</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_fecha_nac" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="content-text-label">Estado civil</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_estado_civil" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="content-text-label">Sexo/Género</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_sexo" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-4">
                                                <div class="content-text-label">Teléfono</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_telefono" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="content-text-label">Celular</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_celular" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="content-text-label">País</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_pais" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <hr class="my-2">
                                        <h6 class="heading-small text-muted">Datos Domicilio</h6>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Cuidad/Localidad</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_cuidad_localidad" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Zona</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_zona" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-4">
                                                <div class="content-text-label">Tipo Vía</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_tipo_via" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="content-text-label">Nombre Vía</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_nombre_via" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="content-text-label">Número</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_numero" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <hr class="my-2">
                                        <h6 class="heading-small text-muted">Información adicional</h6>
                                        <div class="content-text-label">Cargo</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_cargo" runat="server" />
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Ítem</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_item" runat="server" />
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

                    <%-- Modal Editar Datos Domicilio --%>
                    <div class="modal fade" id="modalEditarDomicilio" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
                        <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                            <div class="modal-content">
                                <div class="modal-body p-0">
                                    <div class="card bg-secondary border-0 mb-0">
                                        <div class="card-header">
                                            <div class="text-muted text-center mt-2 mb-3">
                                                <h4 class="header-modal">EDITAR DOMICILIO</h4>
                                            </div>
                                        </div>
                                        <asp:UpdatePanel ID="panelEditarDomicilio" runat="server">
                                            <ContentTemplate>
                                                <div class="card-body px-lg-5 py-lg-5">
                                                    <div class="pb-5 text-center">
                                                        <a href="javascript:;">
                                                            <img src="../Content/img/theme/home.png" alt="Circle image" class="img-fluid rounded-circle shadow" style="width: 100px;">
                                                        </a>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label class="form-control-label">Ciudad/Localidad</label>
                                                                <asp:DropDownList ID="ddl_perd_ciudad_residencia" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_perd_ciudad_residencia" Display="Dynamic" ValidationGroup="addGuardarDomicilio" InitialValue="0" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label class="form-control-label">Zona</label>
                                                                <asp:DropDownList ID="ddl_perd_zona" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_perd_zona" Display="Dynamic" ValidationGroup="addGuardarDomicilio" InitialValue="0" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label class="form-control-label">Tipo Vía</label>
                                                                <asp:DropDownList ID="ddl_perd_tipo_via" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_perd_tipo_via" Display="Dynamic" ValidationGroup="addGuardarDomicilio" InitialValue="0" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-5">
                                                            <div class="form-group">
                                                                <label class="form-control-label">Nombre Vía</label>
                                                                <div class="input-group input-group-merge">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text"><i class="fas fa-home"></i></span>
                                                                    </div>
                                                                    <asp:TextBox ID="txt_nombre_via" class="form-control" runat="server" />
                                                                </div>
                                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_nombre_via" ValidationGroup="addGuardarDomicilio" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <label class="form-control-label">Número</label>
                                                                <div class="input-group input-group-merge">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text"><i class="fas fa-home"></i></span>
                                                                    </div>
                                                                    <asp:TextBox ID="txt_numero_casa" class="form-control" runat="server" />
                                                                </div>
                                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_numero_casa" ValidationGroup="addGuardarDomicilio" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="form-group text-center">
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <asp:LinkButton ID="btn_guardar_domicilio" Text="<i class='fas fa-check mr-2'></i>Guardar" ValidationGroup="addGuardarDomicilio" CssClass="btn btn-success" OnClick="btn_guardar_domicilio_Click" OnClientClick="if (Page_ClientValidate('addGuardarDomicilio')) { MostrarMascara(true); }" runat="server" />
                                                    <asp:LinkButton ID="btn_cancelar_domicilio" class="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i>Cancelar" OnClick="btn_cancelar_domicilio_Click" runat="server" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <%-- Modal Registro Nuevo Familiar --%>
                    <div class="modal fade" id="modalNuevoFamiliar" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
                        <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                            <div class="modal-content">
                                <div class="modal-body p-0">
                                    <div class="card bg-secondary border-0 mb-0">
                                        <div class="card-header">
                                            <div class="text-muted text-center mt-2 mb-3">
                                                <h4 class="header-modal">REGISTRO FAMILIAR</h4>
                                            </div>
                                        </div>
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <div class="card-body px-lg-5 py-lg-5">
                                                    <div class="pb-5 text-center">
                                                        <a href="javascript:;">
                                                            <img src="../Content/img/theme/children.jpg" alt="Circle image" class="img-fluid rounded-circle shadow" style="width: 100px;">
                                                        </a>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-6 col-md-4">
                                                            <div class="form-group">
                                                                <label class="form-control-label" for="example4cols2Input">Apellido Paterno</label>
                                                                <div class="input-group input-group-merge">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text"><i class="fas fa-user-tag"></i></span>
                                                                    </div>
                                                                    <asp:TextBox ID="txt_paterno_add" class="form-control letras" runat="server" />
                                                                </div>
                                                                <%--<asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_paterno_add" ValidationGroup="familiarAdd" runat="server" />--%>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-6 col-md-4">
                                                            <div class="form-group">
                                                                <label class="form-control-label">Apellido Materno</label>
                                                                <div class="input-group input-group-merge">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text"><i class="fas fa-user-tag"></i></span>
                                                                    </div>
                                                                    <asp:TextBox ID="txt_materno_add" class="form-control letras" runat="server" />
                                                                </div>
                                                                <%--<asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_materno_add" ValidationGroup="familiarAdd" runat="server" />--%>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label class="form-control-label">Nombres</label>
                                                                <div class="input-group input-group-merge">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text"><i class="fas fa-user-tag"></i></span>
                                                                    </div>
                                                                    <asp:TextBox ID="txt_nombre_add" class="form-control letras" runat="server" />
                                                                </div>
                                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_nombre_add" ValidationGroup="familiarAdd" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label class="form-control-label">Fecha Nacimiento</label>
                                                                <div class="input-group input-group-merge">
                                                                    <div class="input-group-prepend  ">
                                                                        <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                                    </div>
                                                                    <asp:TextBox ID="txt_fecha_nac_add" AutoComplete="off" class="form-control datepickerDefault" runat="server" />
                                                                </div>
                                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_fecha_nac_add" ValidationGroup="familiarAdd" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-6 col-md-4">
                                                            <div class="form-group">
                                                                <label class="form-control-label">Tipo de Parentesco</label>
                                                                <asp:DropDownList ID="ddl_tipo_parentesco_add" CssClass="form-control select2" AppendDataBoundItems="true" data-minimum-results-for-search="Infinity" runat="server" />
                                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_tipo_parentesco_add" Display="Dynamic" ValidationGroup="familiarAdd" InitialValue="0" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-6 col-md-4">
                                                            <div class="form-group">
                                                                <label class="form-control-label">Género</label>
                                                                <asp:DropDownList ID="ddl_tipo_genero_add" CssClass="form-control select2" AppendDataBoundItems="true" data-minimum-results-for-search="Infinity" runat="server" />
                                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_tipo_genero_add" Display="Dynamic" ValidationGroup="familiarAdd" InitialValue="0" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="form-group text-center">
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <asp:LinkButton ID="btn_adicionar_nuevoFamiliar" Text="<i class='fas fa-check mr-2'></i>Guardar" ValidationGroup="familiarAdd" CssClass="btn btn-success" OnClick="btn_adicionar_nuevoFamiliar_Click" OnClientClick="if (Page_ClientValidate('familiarAdd')) { MostrarMascara(true); }" runat="server" />
                                                    <asp:LinkButton ID="btn_cancelar_nuevoFamiliar" class="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i>Cancelar" OnClick="btn_cancelar_nuevoFamiliar_Click" runat="server" />
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
        </div>
    </div>
    <asp:UpdateProgress ID="up1" AssociatedUpdatePanelID="panelEditarFamiliar" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress ID="up2" AssociatedUpdatePanelID="panelGuardarAfiliacion" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress ID="up3" AssociatedUpdatePanelID="panelEditarDomicilio" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress ID="up4" AssociatedUpdatePanelID="panelEliminarFamiliar" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress ID="up5" AssociatedUpdatePanelID="panelGvFamiliares" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress ID="up6" AssociatedUpdatePanelID="panelGvAfiliacion" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>


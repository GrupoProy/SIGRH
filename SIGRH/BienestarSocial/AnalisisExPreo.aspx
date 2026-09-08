<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="AnalisisExPreo.aspx.cs" Inherits="BienestarSocial_AnalisisExPreo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Examen Preocupacional</h6>
                    </div>


                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid mt--6">
        <div class="row">
            <div class="col-lg-6">
                <div class="card">

                    <div class="card-header d-flex align-items-center">
                        <div class="d-flex align-items-center">
                            <div class="text-dark font-weight-600 text-sm">
                                <h3 class="mb-0">Patologías Frecuentes</h3>
                                <p class="text-sm mb-0">Registre los resultados del examen Preocupacional.</p>
                            </div>
                        </div>
                        <div class="text-right ml-auto">
                            <asp:UpdatePanel ID="panelImpresion" runat="server">
                                <ContentTemplate>
                                    <asp:LinkButton ID="btn_nueva_patologia" CssClass="btn btn-slack btn-round btn-icon btn-sm" data-toggle="tooltip" data-original-title="Imprimir" Text="<span class='btn-inner--icon'><i class='fas fa-plus'></i></span><span class='btn-inner--text'>Nueva patología</span>" OnClick="btn_nueva_patologia_Click" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="table-responsive pt-4 ">
                        <asp:UpdatePanel ID="up_gv_items" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gv_patologias" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_patologias_PreRender" OnRowCommand="gv_patologias_RowCommand" DataKeyNames="enfrec_id" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="enfrec_pat_id" HeaderText="Patología" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="enfrec_esp_id" HeaderText="Especialidad" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-bold" />
                                        <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="40px">
                                            <ItemTemplate>
                                                <asp:LinkButton CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-google-plus btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Eliminar' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-sm-6 col-md-6">
                                        <div class="form-group">
                                            <label class="form-control-label" for="exampleFormControlSelect1">Patologías </label>
                                            <asp:DropDownList ID="ddl_patologias" CssClass="form-control select2" OnSelectedIndexChanged="ddl_patologias_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" runat="server" />
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_patologias" Display="Dynamic" ValidationGroup="addExaPreo" InitialValue="0" runat="server" />

                                        </div>
                                    </div>
                                    <div class="col-sm-6 col-md-6">
                                        <div class="form-group">
                                            <label class="form-control-label" for="exampleFormControlSelect1">Especialidad</label>
                                            <asp:DropDownList ID="ddl_especialidad" CssClass="form-control select2" AppendDataBoundItems="true" data-minimum-results-for-search="Infinity" runat="server" Enabled="false" />
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_especialidad" Display="Dynamic" ValidationGroup="addExaPreo" InitialValue="0" runat="server" />

                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6 col-md-12">
                                        <div class="form-group">
                                            <label class="form-control-label" for="example4cols2Input">&nbsp</label>
                                            <asp:LinkButton ID="btn_adicionar_patologia" Text="<i class='fas fa-save mr-2'></i>Adicionar Patología" ValidationGroup="addExaPreo" CssClass="btn btn-success btn-block" OnClick="btn_adicionar_patologia_Click" runat="server" />
                                        </div>
                                    </div>

                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
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
                                            <strong class="h5">COD. FUN:</strong>
                                            <asp:Literal ID="ltl_cod_fun" runat="server" />
                                        </div>

                                        <hr class="my-3">
                                        <h6 class="heading-small text-muted">Datos Examen Preocupacional</h6>
                                        <div class="row">
                                            <div class="col-lg-2">
                                                <div class="content-text-label">Nº de autorización</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_nro_auto" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="content-text-label">Convenio</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_convenio" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="content-text-label">Lugar examen</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_lugar" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="content-text-label">Fecha examen Pr.</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_fecha_ex_pre" runat="server" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">

                                            <div class="col-lg-12">
                                                <div class="content-text-label">Diagnostico </div>
                                                <div class="h5 font-weight-400 content-text text-justify">
                                                    <asp:Literal ID="ltl_diagnostico" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">

                                            <div class="col-lg-12">
                                                <div class="content-text-label">Comentario </div>
                                                <div class="h5 font-weight-400 content-text text-justify">
                                                    <asp:Literal ID="ltl_comentario" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div class="content-text-label">Recomendaciones </div>
                                                <div class="h5 font-weight-400 content-text text-justify">
                                                    <asp:Literal ID="ltl_recomendaciones" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row pb-3">
                                            <div class="col-lg-12">
                                                <div class="content-text-label">Característica del puesto de trabajo </div>
                                                <div class="h5 font-weight-400 content-text text-justify">
                                                    <asp:Literal ID="ltl_carac_puesto" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <h4 style="text-transform: uppercase">Agentes a los que está expuesto el funcionario </h4>
                                        <div class="row">
                                            <div class="col-sm-6 col-md-12">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="exampleFormControlSelect1">Físico</label>
                                                    <asp:ListBox ID="lb_agente_fisico" class="form-control select2" SelectionMode="Multiple" runat="server"></asp:ListBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-6 col-md-12">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="exampleFormControlSelect1">Químico </label>
                                                    <asp:ListBox ID="lb_agente_quimico" class="form-control select2" SelectionMode="Multiple" runat="server"></asp:ListBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-6 col-md-12">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="exampleFormControlSelect1">Biológico</label>
                                                    <asp:ListBox ID="lb_agente_biologico" class="form-control select2" SelectionMode="Multiple" runat="server"></asp:ListBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-6 col-md-12">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="exampleFormControlSelect1">Psicosocial</label>
                                                    <asp:ListBox ID="lb_agente_psicosociales" class="form-control select2" SelectionMode="Multiple" runat="server"></asp:ListBox>
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
    </div>
    <div class="modal fade" id="analisisExamen" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
        <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
            <div class="modal-content bg-gradient-dark6">
                <div class="modal-header">
                </div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>

                        <div class="modal-body">
                            <div class="py-3 text-center">
                                <i class="ni ni-archive-2 ni-3x"></i>
                                <h4 class="heading text-dark mt-4">¿Está seguro de guardar los datos registrados?</h4>
                            </div>
                        </div>
                        <div class="form-group text-center">
                            <asp:LinkButton ID="btn_analisi_examen" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btn_analisi_examen_Click" runat="server" />
                            <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div class="modal fade" id="eliminarPatologia" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
        <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
            <div class="modal-content bg-gradient-dark6">
                <div class="modal-header">
                </div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:HiddenField ID="hf_enfrec_id" runat="server" />
                        <div class="modal-body">
                            <div class="py-3 text-center">
                                <i class="ni ni-fat-remove ni-3x"></i>
                                <h4 class="heading text-dark mt-4">¿Está seguro de eliminar la patología?</h4>
                            </div>
                        </div>
                        <div class="form-group text-center">
                            <asp:LinkButton ID="btn_eliminar_patologia" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btn_eliminar_patologia_Click" runat="server" />
                            <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div class="modal fade" id="nuevaPatologia" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
        <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="panel_nuevo_resultado" runat="server">
                    <ContentTemplate>
                        <div class="modal-body p-0">
                            <div class="card bg-secondary border-0 mb-0">
                                <div class="card-header">
                                    <div class="text-muted text-center mt-2 mb-3">
                                        <h4 class="header-modal">NUEVO REGISTRO</h4>
                                    </div>
                                </div>
                                <div class="card-body px-lg-5 py-lg-5">

                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="form-control-label" for="exampleFormControlSelect1">Patologías </label>
                                                <asp:DropDownList ID="ddl_especiadlidad_add" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_especiadlidad_add" Display="Dynamic" ValidationGroup="addPat" InitialValue="0" runat="server" />

                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="form-control-label" for="exampleFormControlSelect1">Patología</label>
                                                <div class="input-group input-group-merge">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                    </div>
                                                    <asp:TextBox ID="txt_patologia" class="form-control" runat="server" />
                                                </div>
                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_patologia" Display="Dynamic" ValidationGroup="addPat" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-6 col-md-6">
                                            <div class="form-group">
                                                <label class="form-control-label" for="example4cols2Input">&nbsp</label>
                                                <asp:LinkButton ID="btn_adicionar_patologia_ad" Text="<i class='fas fa-save mr-2'></i>Adicionar" ValidationGroup="addPat" CssClass="btn btn-success btn-block" OnClick="btn_adicionar_patologia_ad_Click" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-sm-6 col-md-6">
                                            <div class="form-group">
                                                <label class="form-control-label">&nbsp</label>
                                                <button type="button" class="btn btn-outline-github btn-block" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
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
</asp:Content>


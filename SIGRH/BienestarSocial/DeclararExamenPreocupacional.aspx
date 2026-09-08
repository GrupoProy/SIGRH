<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="DeclararExamenPreocupacional.aspx.cs" Inherits="BienestarSocial_DeclararExamenPreocupacional" %>

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
            <div class="col-lg-7">
                <div class="card">
                    <div class="card-header">
                        <div class=" ct-page-title">
                            <h3 class="mb-0">Declarar Examen</h3>
                            <p class="text-sm mb-0">
                                Registre los resultados del examen Preocupacional.
                            </p>
                        </div>
                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-sm-6 col-md-12">
                                        <div class="form-group">
                                            <label class="form-control-label" for="example4cols2Input">Diagnostico</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                </div>
                                                <asp:TextBox ID="txt_diagnostico" class="form-control" TextMode="multiline" Rows="1" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_diagnostico" Display="Dynamic" ValidationGroup="addDecExaPreo" runat="server" />
                                        </div>
                                    </div>

                                </div>
                                <div class="row">

                                    <div class="col-sm-6 col-md-12">
                                        <div class="form-group">
                                            <label class="form-control-label" for="example4cols2Input">Comentario</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                </div>
                                                <asp:TextBox ID="txt_comentario" class="form-control" TextMode="multiline" Rows="1" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_comentario" Display="Dynamic" ValidationGroup="addDecExaPreo" runat="server" />
                                        </div>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-sm-6 col-md-12">
                                        <div class="form-group">
                                            <label class="form-control-label" for="example4cols2Input">Recomendaciones</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                </div>
                                                <asp:TextBox ID="txt_recomendaciones" class="form-control" TextMode="multiline" Rows="1" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_recomendaciones" Display="Dynamic" ValidationGroup="addDecExaPreo" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="form-control-label">Fecha resultado medico</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend  ">
                                                    <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                </div>
                                                <asp:TextBox ID="txt_fecha_resultado_med" class="form-control datepickerDefault" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_fecha_resultado_med" Display="Dynamic" ValidationGroup="addDecExaPreo" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="form-control-label" for="example4cols2Input">Nombre medico</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><i class="fas fa-user"></i></span>
                                                </div>
                                                <asp:TextBox ID="txt_nombre_med" class="form-control" TextMode="multiline" Rows="1" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_nombre_med" Display="Dynamic" ValidationGroup="addDecExaPreo" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="form-control-label" for="example4cols2Input">Nº historia clínica</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><i class="fas fa-hashtag"></i></span>
                                                </div>
                                                <asp:TextBox ID="txt_nro_hist" class="form-control numero" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_nro_hist" Display="Dynamic" ValidationGroup="addDecExaPreo" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="form-control-label" for="exampleFormControlSelect1">Tipo sangre</label>
                                            <asp:DropDownList ID="ddl_tipo_sangre" AppendDataBoundItems="true" CssClass="form-control select2" runat="server"></asp:DropDownList>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_tipo_sangre" Display="Dynamic" ValidationGroup="addDecExaPreo" InitialValue="0" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row pb-2">
                                    <div class="col-sm-6 col-md-12">
                                        <div class="form-group">
                                            <label class="form-control-label" for="example4cols2Input">Característica del puesto de trabajo </label>
                                            <small>(Ej: demanda física, mental sensorial, social)</small>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                </div>
                                                <asp:TextBox ID="txt_caracteristica_p" class="form-control" TextMode="multiline" Rows="1" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_caracteristica_p" Display="Dynamic" ValidationGroup="addDecExaPreo" runat="server" />
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
                                <%--<select class="js-example-basic-hide-search-multi for" multiple="multiple" style="width: 100%"></select>--%>
                                <%--                             <div class="row">
                                    <div class="col-sm-6 col-md-3">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <asp:LinkButton ID="btn_cancelar_af" Text="<i class='ni ni-bold-up'></i>" CssClass="btn btn-outline-github btn-block btn-sm" OnClick="btn_cancelar_af_Click" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <asp:LinkButton ID="btn_adicionar_af" Text="<i class='ni ni-bold-down'></i>" CssClass="btn btn-outline-github btn-block btn-sm" OnClick="btn_adicionar_af_Click" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 col-md-3">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <asp:LinkButton ID="LinkButton3" Text="<i class='ni ni-bold-up'></i>" ValidationGroup="addDecExaPreo" CssClass="btn btn-outline-github btn-block btn-sm" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <asp:LinkButton ID="LinkButton4" Text="<i class='ni ni-bold-down '></i>" ValidationGroup="addDecExaPreo" CssClass="btn btn-outline-github btn-block btn-sm" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 col-md-3">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <asp:LinkButton ID="LinkButton5" Text="<i class='ni ni-bold-up'></i>" ValidationGroup="addDecExaPreo" CssClass="btn btn-outline-github btn-block btn-sm" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <asp:LinkButton ID="LinkButton6" Text="<i class='ni ni-bold-down '></i>" ValidationGroup="addDecExaPreo" CssClass="btn btn-outline-github btn-block btn-sm" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 col-md-3">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <asp:LinkButton ID="LinkButton7" Text="<i class='ni ni-bold-up'></i>" ValidationGroup="addDecExaPreo" CssClass="btn btn-outline-github btn-block btn-sm" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <asp:LinkButton ID="LinkButton8" Text="<i class='ni ni-bold-down '></i>" ValidationGroup="addDecExaPreo" CssClass="btn btn-outline-github btn-block btn-sm" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6 col-md-3">
                                        <div class="form-group">
                                            <label class="form-control-label" for="exampleFormControlSelect1">Físico</label>
                                            <asp:ListBox ID="lb_agente_fisico_asig" class="form-control"  runat="server"></asp:ListBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 col-md-3">
                                        <div class="form-group">
                                            <label class="form-control-label" for="exampleFormControlSelect1">Químico </label>
                                            <asp:ListBox ID="lb_agente_quimico_asig" class="form-control" runat="server"></asp:ListBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 col-md-3">
                                        <div class="form-group">
                                            <label class="form-control-label" for="exampleFormControlSelect1">Biológico</label>
                                            <asp:ListBox ID="lb_agente_biologico_asig" class="form-control" runat="server"></asp:ListBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 col-md-3">
                                        <div class="form-group">
                                            <label class="form-control-label" for="exampleFormControlSelect1">Psicosocial</label>
                                            <asp:ListBox ID="lb_agente_psicosociales_asig" class="form-control" runat="server"></asp:ListBox>
                                        </div>
                                    </div>
                                </div>--%>
                                <div class="row">

                                    <div class="col-sm-6 col-md-12">
                                        <div class="form-group">
                                            <label class="form-control-label" for="example4cols2Input">&nbsp</label>
                                            <asp:LinkButton ID="btn_adicionar_dec_ex" Text="<i class='fas fa-save mr-2'></i>Declarar examen" ValidationGroup="addDecExaPreo" CssClass="btn btn-success btn-block" OnClick="btn_adicionar_dec_ex_Click" runat="server" />
                                        </div>
                                    </div>
                                </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>
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

                                            <div class="col-lg-4">
                                                <div class="content-text-label">Telf. Oficina </div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_telf_of" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="content-text-label">Telf. Funcionario</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_telf_fun" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="content-text-label">Cel. Funcionario</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_cel_fun" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">

                                            <div class="col-lg-12">
                                                <div class="content-text-label">Unidad de trabajo </div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_unidad" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">

                                            <div class="col-lg-12">
                                                <div class="content-text-label">Actividad que realiza </div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_actividad" runat="server" />
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
    <div class="modal fade" id="declararExamen" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
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
                            <asp:LinkButton ID="btn_declarar_examen" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btn_declarar_examen_Click" runat="server" />
                            <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>


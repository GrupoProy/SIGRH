<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="AfiliacionAFP.aspx.cs" Inherits="BienestarSocial_AfiliacionAFP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Afiliación a la AFP</h6>
                    </div>
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
                            <div class="row align-items-center">
                                <div class="col-8"> 
                                    <div class=" ct-page-title">
                                        <h3 class="mb-0">Registro de AFP</h3>
                                        <p class="text-sm mb-0">
                                            Formulario para registrar los datos de la AFP del funcionario.
                                        </p>
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="card-body">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <label class="form-control-label">AFP</label>
                                                <asp:DropDownList ID="ddl_afp" AppendDataBoundItems="true" CssClass="form-control select2" runat="server"></asp:DropDownList>
                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_afp" InitialValue="0" Display="Dynamic" ValidationGroup="addGuardar" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <label class="form-control-label">NUA</label>
                                                <div class="input-group input-group-merge">
                                                    <div class="input-group-prepend  ">
                                                        <span class="input-group-text"><i class="fas fa-pen"></i></span>
                                                    </div>
                                                    <asp:TextBox ID="txt_nua" class="form-control numero" runat="server" />
                                                </div>
                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_nua" ValidationGroup="addGuardar" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <label class="form-control-label">Fecha filiación</label>
                                                <div class="input-group input-group-merge">

                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                    </div>
                                                    <asp:TextBox ID="txt_fecha_filiacion" class="form-control datepickerDefault" runat="server" />
                                                </div>
                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_fecha_filiacion" ValidationGroup="addGuardar" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <label class="form-control-label">Carnet de Registro</label>
                                                <asp:DropDownList ID="ddl_carnet_registro" AppendDataBoundItems="true" CssClass="form-control select2" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div id="d_motivo" class="row" runat="server">
                                        <div class="col-lg-12">
                                            <div class="form-group">
                                                <label class="form-control-label">Motivo de modificación</label>
                                                <asp:TextBox ID="txt_motivo" class="form-control" runat="server" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="form-group text-right">
                                                <label class="form-control-label">&nbsp</label>
                                                <asp:LinkButton ID="btn_guardar_afp" CssClass="btn btn-success btn-block" Text="<i class='fas fa-save'></i> Modificar afiliación" OnClick="btn_guardar_afp_Click" ValidationGroup="addGuardar" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <asp:HiddenField ID="hf_editar" runat="server" />
                                    <asp:HiddenField ID="hf_afp_id" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="card">
                        <div class="card-header">
                            <div class=" ct-page-title">
                                <h3 class="mb-0">Afiliaciones a la AFP del Funcionario</h3>
                                <p class="text-sm mb-0">
                                    Histórico de las afiliaciones de AFP del funcionario.
                                </p>
                            </div>
                        </div>
                        <div class="table-responsive py-4">
                            <asp:UpdatePanel ID="panelGV_memos" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gv_afp" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_afp_PreRender" DataKeyNames="afp_id" runat="server">
                                        <Columns>
                                            <asp:BoundField DataField="afp_previsora" HeaderText="AFP" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-bold" />
                                            <asp:BoundField DataField="afp_nua" HeaderText="NUA" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center " />
                                            <asp:BoundField DataField="afp_fecha_filiacion" HeaderText="Fecha filiación" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center " />
                                            <asp:BoundField DataField="afp_estado" HeaderText="Estado" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center " />
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="modal fade" id="modalAfiliacion" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                            <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                                <div class="modal-content bg-gradient-dark6">
                                    <div class="modal-header">
                                    </div>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>

                                            <div class="modal-body">
                                                <div class="py-3 text-center">
                                                    <i class="ni ni-archive-2 ni-3x"></i>
                                                    <h4 class="heading text-dark mt-4">¿Está seguro de registrar los datos del AFP al funcionario?</h4>
                                                </div>
                                            </div>
                                            <div class="form-group text-center">
                                                <asp:LinkButton ID="btn_confirmar_guardar" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btn_confirmar_guardar_Click" runat="server" />
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

                                    <h5 class="h3 text-uppercase text-center">
                                        <asp:Literal ID="ltl_nombre_fun" runat="server" />
                                    </h5>
                                    <hr class="my-3">
                                    <h6 class="heading-small text-muted d-inline-flex icon-title-h"><i class="fas fa-id-card icon-h"></i>Datos Personales</h6>
                                    <div class="icon-content-h">
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class="content-text-label">CI</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_ci" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="content-text-label">COD. FUN</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_cod_fun" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Estado civil</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_estado_civil" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Sexo/género</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_sexo" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <hr class="my-2">
                                    <h6 class="heading-small text-muted d-inline-flex icon-title-h"><i class="fas fa-globe-americas icon-h"></i>Fecha y lugar de nacimiento</h6>
                                    <div class="icon-content-h">
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Fecha</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_fecha_nac" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Edad</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_edad" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class="content-text-label">País</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_pais" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Departamento</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_departamento" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <hr class="my-2">
                                    <h6 class="heading-small text-muted d-inline-flex icon-title-h"><i class="fas fa-home icon-h"></i>Domicilio</h6>
                                    <div class="icon-content-h">
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Zona</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_zona" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Tipo vía</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_tipo_via" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Nombre vía</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_nombre_via" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Número</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_dom_nro" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <hr class="my-2">
                                    <h6 class="heading-small text-muted d-inline-flex icon-title-h"><i class="fas fa-briefcase icon-h"></i>Datos Laborales</h6>
                                    <div class="icon-content-h">
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Ítem</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_item" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Cargo</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_cargo" runat="server" />
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
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div class="content-text-label">Unidad organizacional</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_unidad_org" runat="server" />
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
</asp:Content>


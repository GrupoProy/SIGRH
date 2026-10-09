<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="AsignacionMateria.aspx.cs" Inherits="Docentes_AsignacionMateria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="header pb-6" style="margin-top: -4em; margin-left: 3em; width: 81%">
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Modulo Docente - Materia</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid mt--7">
        <div class="ct-example  card" style="padding-bottom: unset">
            <div class="card-header">
                <h3 class="h2 text d-inline-block mb-0"><i class="fas fa-id-card-alt mr-2"></i>Datos Docente</h3>
                <asp:LinkButton ID="btn_estado" Text="Documento Virtual" class="btn btn-sm btn-success float-right" runat="server" />
            </div>
            <div class="card-body">
                <div class="media align-items-center">
                    <asp:Image ID="imgFun" class="avatar-xll img-thumbnail mr-4" runat="server" />
                    <div class="media-body">
                        <!-- datos persona -->
                        <h6 class="heading-small text-muted">DATOS PERSONALES</h6>
                        <div class="row">
                            <div class="col-lg-2">
                                <asp:HiddenField ID="hf_per_id" runat="server" />
                                <div class="content-text-label">Cód. Funcionario</div>
                                <div class="h5 font-weight-400 content-text content-text">
                                    <asp:Literal ID="ltl_cod_fun" runat="server" />
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <div class="content-text-label">CI</div>
                                <div class="h5 font-weight-400 content-text">
                                    <asp:Literal ID="ltl_ci" runat="server" />
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="content-text-label">Nombre funcionario</div>
                                <div class="h5 font-weight-400 content-text">
                                    <asp:Literal ID="ltl_nombre_fun" runat="server" />
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <div class="content-text-label">Puesto</div>
                                <div class="h5 font-weight-400 content-text">
                                    <asp:Literal ID="ltl_puesto" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-2">
                                <div class="content-text-label">Cargo</div>
                                <div class="h5 font-weight-400 content-text">
                                    <asp:Literal ID="ltl_cargo" runat="server" />
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <div class="content-text-label">Ubicacion</div>
                                <div class="h5 font-weight-400 content-text">
                                    <asp:Literal ID="ltl_ubicacion" runat="server" />
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <div class="content-text-label">Haber Basico</div>
                                <div class="h5 font-weight-400 content-text">
                                    <asp:Literal ID="ltl_haber_basico" runat="server" />
                                </div>
                            </div>
                        </div>
                        <hr class="my-2">
                        <%-- datos materia --%>
                        <h6 class="heading-small text-muted">DATOS DE LA MATERIA</h6>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="form-group col-md-3">
                                        <div class="content-text-label">Area</div>
                                        <div class="h5 font-weight-400 content-text content-text">
                                            <asp:DropDownList ID="ddl_area" AutoPostBack="true" OnSelectedIndexChanged="ddl_area_SelectedIndexChanged" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_area" ValidationGroup="agregar" Display="Dynamic" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group col-md-3">
                                        <div class="content-text-label">Carrera</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:DropDownList ID="ddl_carrera" AutoPostBack="true" OnSelectedIndexChanged="ddl_carrera_SelectedIndexChanged" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_carrera" ValidationGroup="agregar" Display="Dynamic" runat="server" />
                                        </div>
                                    </div>

                                    <div class="form-group col-md-2">
                                        <div class="content-text-label">Plan</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:DropDownList ID="ddl_plan" AutoPostBack="true" OnSelectedIndexChanged="ddl_plan_SelectedIndexChanged" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_plan" ValidationGroup="agregar" Display="Dynamic" runat="server" />
                                        </div>
                                    </div>

                                    <div class="form-group col-md-4">
                                        <div class="form-group form-control-label">
                                            <label class="content-text-label">Carga Horaria</label>
                                        </div>
                                        <div class="form-check form-check-inline">
                                            <asp:RadioButton Text="Tiempo Completo" GroupName="rdTiempo" ID="rdCompleto" runat="server" />
                                        </div>
                                        <div class="form-check form-check-inline">
                                            <asp:RadioButton ID="rdMedio" GroupName="rdTiempo" Text="Por Hora" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddl_area" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="ddl_carrera" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="ddl_plan" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>

                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="form-group col-md-4">
                                        <div class="content-text-label">Materia</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:DropDownList ID="ddl_materia" AutoPostBack="true" OnSelectedIndexChanged="ddl_materia_SelectedIndexChanged" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_materia" ValidationGroup="agregar" Display="Dynamic" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label class="form-control-label">Horas Asignadas</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"></span>
                                            </div>
                                            <asp:TextBox ID="Txt_horas" CssClass="form-control numero" TextMode="Number" runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator ErrorMessage="(*) Campo Obligatorio" CssClass="text-danger display-5" ValidationGroup="agregar" Display="Dynamic" ControlToValidate="Txt_horas" runat="server" />
                                    </div>
                                    <div class="form-group col-md-2">
                                        <div class="form-group form-control-label">
                                            <label class="content-text-label">Tipo de Docencia</label>
                                        </div>
                                        <div class="form-check form-check-inline">
                                            <asp:RadioButton AutoPostBack="true" Checked="true" Text="Titular" OnCheckedChanged="rdTitu_CheckedChanged" GroupName="radios" ID="rdTitu" runat="server" />
                                        </div>
                                        <div class="form-check form-check-inline">
                                            <asp:RadioButton AutoPostBack="true" ID="rdEvent" OnCheckedChanged="rdEvent_CheckedChanged" GroupName="radios" Text="Eventual" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <div class="form-group form-control-label">
                                            <label class="content-text-label">Tipo de Ingreso</label>
                                        </div>
                                        <div class="form-check form-check-inline">
                                            <asp:RadioButton ID="rdInvi" GroupName="ingreso" Text="Invitación" runat="server" />
                                        </div>
                                        <div class="form-check form-check-inline">
                                            <asp:RadioButton ID="rdConcu" GroupName="ingreso" Text="Concurso de Merito" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="rdTitu" EventName="CheckedChanged" />
                                <asp:AsyncPostBackTrigger ControlID="rdEvent" EventName="CheckedChanged" />
                                <asp:AsyncPostBackTrigger ControlID="ddl_materia" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="form-group col-md-3">
                                        <div class="content-text-label">Estructura Organizacional</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:DropDownList ID="ddl_eo" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group col-md-3">
                                        <div class="content-text-label">Cargo Docente al que sera Asignado</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:DropDownList ID="ddl_docente" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <div class="content-text-label">Escalafon Docente</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:DropDownList ID="ddl_escalafon" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label class="form-control-label">Fecha Inicio:</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                            </div>
                                            <asp:TextBox ID="txt_fecha_inicio" AutoComplete="off" class="form-control datepickerDefault" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label class="form-control-label">Fecha Fin:</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                            </div>
                                            <asp:TextBox ID="txt_fecha_fin" class="form-control datepickerDefault" runat="server" />
                                        </div>
                                    </div>
                                </div>
                               
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddl_eo" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="ddl_docente" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <div class="row">
                            <div class="form-group col-md-2">
                                <asp:LinkButton ID="BtnAsig" CssClass="btn btn-success btn-block top-4" OnClick="BtnAsig_Click" ValidationGroup="agregar" Text="<i class='fas fa-save'>   </i> Asignar" data-toggle="tooltip" data-original-title="Asignar Materia" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="SancionesPlanilla.aspx.cs" Inherits="ControlPersonal_SancionesPlanilla" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Header -->
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Administración de Licencia Justificada</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page content -->
    <div class="container-fluid mt--6">
        <div class="row">
            <div class="col-lg-6">
                <div class="card">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Datos</h3>
                            <p class="text-sm mb-0">Seleccione los datos correspondientes</p>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="Up_form_d" runat="server">
                        <ContentTemplate>
                            <div class="card-body">
                                <div class="row">
                                    <!---->
                                    <div class="form-group col-md-12">
                                        <label class="form-control-label" for="Ddl_">Tipo de Reporte</label>
                                        <asp:DropDownList ID="Ddl_" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                                    </div>
                                    <!---->
                                    <div class="form-group col-md-12">
                                        <label class="form-control-label" for="Ddl__">Proceso</label>
                                        <asp:DropDownList ID="Ddl__" CssClass="form-control select2" data-minimum-results-for-search="Infinity" AppendDataBoundItems="true" runat="server" />
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl__" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                                    </div>
                                    <!---->
                                    <div class="form-group col-md-12">
                                        <label class="form-control-label" for="Ddl___">Categoría Programática</label>
                                        <asp:DropDownList ID="Ddl___" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl___" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="offset-lg-6 col-lg-6">
                                        <asp:LinkButton ID="BtnNuevo" CssClass="btn bg-gradient-inst text-white btn-block" Text="<i class='fas fa-plus mr-2'></i> Vista Previa" ValidationGroup="add" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="col-lg-6">
                <asp:UpdatePanel ID="Up_form_i" runat="server">
                    <ContentTemplate>
                        <div class="card card-profile text-uppercase">
                            <div class="card-body">
                                <h5 class="h3 text-center">Detalle de Categoría</h5>
                                <hr class="my-3">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="content-text-label">Categoría Programática</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="Lt" Text="(26 - 144 - 20 - 0 - 10) Fortalecimiento de Salud Municipal Hospital La Paz" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <hr class="my-3">
                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class="content-text-label">Fecha Inicial</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="Lt_" Text="16/08/2020" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="content-text-label">Fecha Final</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="Lt__" Text="15/09/2020" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <hr class="my-3">
                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class="content-text-label">Ingresos</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="Lt___" Text="0" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="content-text-label">Bajas</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="Lt____" Text="0" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <hr class="my-3" />
                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class="content-text-label">Tipo Item</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="Lt_____" Text="Contrato Hospital La Paz" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="content-text-label">Cantidad</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="Lt______" Text="14" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6">
                <div class="card">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Detalle de Horarios</h3>
                            <p class="text-sm mb-0"></p>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="Up_form_dh" runat="server">
                        <ContentTemplate>
                            <div class="card-body">
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="card">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Diferencia de días de Asignación VS días horarios</h3>
                            <p class="text-sm mb-0"></p>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="Up_form_dah" runat="server">
                        <ContentTemplate>
                            <div class="card-body">
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6">
                <div class="card">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Posibles errores de asignación de horario (minutos)</h3>
                            <p class="text-sm mb-0"></p>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="Up_form_eah" runat="server">
                        <ContentTemplate>
                            <div class="card-body">
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="card">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Personal con horario que les exime del marcado</h3>
                            <p class="text-sm mb-0"></p>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="Up_form_hm" runat="server">
                        <ContentTemplate>
                            <div class="card-body">
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6">
                <div class="card">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Personal con horario que les exime del marcado y marca con normalidad</h3>
                            <p class="text-sm mb-0"></p>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="Up_form_hmn" runat="server">
                        <ContentTemplate>
                            <div class="card-body">
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="card">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Personal que tiene más de dos días de falta</h3>
                            <p class="text-sm mb-0"></p>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="Up_form_df" runat="server">
                        <ContentTemplate>
                            <div class="card-body">
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6">
                <div class="card">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Personal con posibles errores de asignación de horarios (2 VS 4)</h3>
                            <p class="text-sm mb-0"></p>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="Up_form_eah24" runat="server">
                        <ContentTemplate>
                            <div class="card-body">
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="card">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Personal con posibles errores de asignación de horarios (4 VS 2)</h3>
                            <p class="text-sm mb-0"></p>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="Up_form_eah42" runat="server">
                        <ContentTemplate>
                            <div class="card-body">
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6">
                <div class="card">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Personal con días no procesados (asistencia)</h3>
                            <p class="text-sm mb-0"></p>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="Up_form_dp" runat="server">
                        <ContentTemplate>
                            <div class="card-body">
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="card">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Detalle de licencias registradas</h3>
                            <p class="text-sm mb-0"></p>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="Up_form_lr" runat="server">
                        <ContentTemplate>
                            <div class="card-body">
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6">
                <div class="card">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Licencias no validadas y anuladas</h3>
                            <p class="text-sm mb-0"></p>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="Up_form_va" runat="server">
                        <ContentTemplate>
                            <div class="card-body">
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="card">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Detalle de la descarga de marcaciones</h3>
                            <p class="text-sm mb-0"></p>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="Up_form_dm" runat="server">
                        <ContentTemplate>
                            <div class="card-body">
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6">
                <div class="card">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Sanciones</h3>
                            <p class="text-sm mb-0"></p>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="Up_form_s" runat="server">
                        <ContentTemplate>
                            <div class="card-body">
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="card">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Reporte</h3>
                            <p class="text-sm mb-0"></p>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="Up_form_r" runat="server">
                        <ContentTemplate>
                            <div class="card-body">
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>

    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_d" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_i" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_dh" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_dah" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_eah" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_hm" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_hmn" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_df" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_eah24" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_eah42" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_dp" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_lr" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_va" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_dm" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_s" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_r" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

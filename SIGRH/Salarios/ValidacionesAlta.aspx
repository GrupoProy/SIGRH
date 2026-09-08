<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ValidacionesAlta.aspx.cs" Inherits="Salarios_Validaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Validaciones</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid mt--6">
        <div class="row">
            <div class="col-lg-8">
                <div id="block_datos_funcionario" class="card-wrapper" style="display: none">
                    <div class="card card-profile">
                        <div class="row justify-content-center">
                            <div class="col-lg-3 order-lg-2">
                                <div class="card-profile-image">
                                    <a href="#">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:Image ID="imgFun" class="rounded-circle" runat="server" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="card-header text-center border-0 pt-8 pt-md-4 pb-0 pb-md-4">
                            <div class="d-flex justify-content-between">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="btn_estado" OnClick="btn_estado_Click" class="btn btn-sm btn-info  mr-4" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div id="block_aprobar" style="display: none">
                                    <asp:UpdatePanel ID="up_aprobar" runat="server">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="btn_guardar_validacion" CssClass="btn btn-success float-right" Text="<i class='fas fa-check'></i> Aprobar" OnClick="btn_guardar_validacion_Click" runat="server" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
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
                                        <hr class="my-2">
                                        <h6 class="heading-small text-muted d-inline-flex icon-title-h"><i class="fas fa-briefcase icon-h"></i>Datos de la Asignación</h6>
                                        <div class="icon-content-h">
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Carnet de Identidad</div>
                                                    <div class="h5 font-weight-400 content-text" style="font-size: 1.3rem !important; font-weight: bold !important;">
                                                        <asp:Literal ID="ltl_ci" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Ítem</div>
                                                    <div class="h5 font-weight-400 content-text" style="font-size: 1.3rem !important; font-weight: bold !important;">
                                                        <asp:Literal ID="ltl_item" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-3">
                                                    <div class="content-text-label">Cargo</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_cargo" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="content-text-label">Puesto</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_puesto" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="content-text-label">Haber Básico (Bs)</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_haber_basico" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="content-text-label">Escalafón</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_escalafon" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <hr class="my-2">
                                        <h6 class="heading-small text-muted d-inline-flex icon-title-h"><i class="fas fa-calendar icon-h"></i>Información fecha asignación</h6>
                                        <div class="icon-content-h">
                                            <div class="row">
                                                <div class="col-lg-3">
                                                    <div class="content-text-label">Fecha asignación</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_fecha_inicio" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="content-text-label">Fecha baja</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_fecha_fin" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="content-text-label">Tipo Jornada</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_tipo_jornada" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <hr class="my-3">
                                        <h6 class="heading-small text-muted d-inline-flex icon-title-h"><i class="fas fa-building icon-h"></i>Categoría administrativa</h6>
                                        <div class="icon-content-h">
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Ubicación</div>
                                                    <div class="h5 font-weight-400 content-text content-text">
                                                        <asp:Literal ID="ltl_ubicacion" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Categoría Administrativa</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_programatica" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <hr class="my-3">
                                        <h6 class="heading-small text-muted d-inline-flex icon-title-h"><i class="fas fa-building icon-h"></i>Categoría programática</h6>
                                        <div class="icon-content-h">
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Ubicación</div>
                                                    <div class="h5 font-weight-400 content-text content-text">
                                                        <asp:Literal ID="ltl_cat_ubicacion" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Categoría Programática</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_cat_programatica" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <%-- DATOS DEL FUNCIONARIO TITULAR PARA COMISIÓN INTERINATO --%>
                                        <div id="block_datos_fun_int" style="display: none; background-color: #D2EEE0; border-radius: .375rem; padding-left: 17px;">
                                            <hr class="my-3">
                                            <h6 class="heading-small text-muted">Datos
                                                <asp:Literal ID="ltl_tipo_int" runat="server" /></h6>

                                            <div id="block_datos_adicionales_int">
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <div class="content-text-label">Nombre Funcionario Titular</div>
                                                        <div class="h5 font-weight-400 content-text content-text">
                                                            <asp:Literal ID="ltl_nombre_fun_int" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <div class="content-text-label">Documento de identidad </div>
                                                        <div class="h5 font-weight-400 content-text content-text">
                                                            <asp:Literal ID="ltl_ci_int" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <div class="content-text-label">Nro. Memorándum </div>
                                                        <div class="h5 font-weight-400 content-text content-text">
                                                            <asp:Literal ID="ltl_memo_int" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-3">
                                                        <div class="content-text-label">Cargo</div>
                                                        <div class="h5 font-weight-400 content-text">
                                                            <asp:Literal ID="ltl_cargo_int" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <div class="content-text-label">Puesto</div>
                                                        <div class="h5 font-weight-400 content-text">
                                                            <asp:Literal ID="ltl_puesto_int" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <div class="content-text-label">Ítem</div>
                                                        <div class="h5 font-weight-400 content-text">
                                                            <asp:Literal ID="ltl_item_int" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <div class="content-text-label">Haber Básico (Bs)</div>
                                                        <div class="h5 font-weight-400 content-text">
                                                            <asp:Literal ID="ltl_haber_basico_int" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Fecha Inicio</div>
                                                    <div class="h5 font-weight-400 content-text content-text">
                                                        <asp:Literal ID="ltl_fecha_inicio_int" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Fecha fin</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_fecha_fin_int" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Ubicación</div>
                                                    <div class="h5 font-weight-400 content-text content-text">
                                                        <asp:Literal ID="ltl_ubicacion_int" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Categoría Programática</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_programatica_int" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <%-- DATOS DEL MEMORANDUM --%>
                                        <div id="block_datos_memo" style="display: none; background-color: #E0EED2; border-radius: .375rem; padding-left: 17px;">
                                            <hr class="my-3">
                                            <h6 class="heading-small text-muted">Datos de movimientos varios</h6>
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Descripción Memorándum</div>
                                                    <div class="h5 font-weight-400 content-text content-text">
                                                        <asp:Literal ID="ltl_descMovimiento_memo" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Número de memorándum</div>
                                                    <div class="h5 font-weight-400 content-text content-text">
                                                        <asp:Literal ID="ltl_num_memo" runat="server" />
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
            <div class="col-lg-12">
                <div id="block_gv_validar" class="card-wrapper">
                    <div class="card">
                        <div class="card-header d-flex align-items-center">
                            <div class=" ct-page-title">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <h3 class="mb-0">
                                            <asp:Literal ID="ltl_nombre_grilla" runat="server" />
                                            por Validar</h3>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <p class="text-sm mb-0">
                                    Listado de asignaciones.
                                </p>
                            </div>
                        </div>
                        <asp:HiddenField ID="aux_as_id" runat="server" />
                        <asp:HiddenField ID="HF_TI_TIPO" runat="server" />
                        <asp:HiddenField ID="hf_ti_item" runat="server" />
                        <asp:HiddenField ID="aux_as_per_id" runat="server" />
                        <asp:HiddenField ID="aux_validar_item" runat="server" />
                        <asp:HiddenField ID="aux_ci_id" runat="server" />
                        <asp:HiddenField ID="aux_mv_id" runat="server" />
                        <asp:HiddenField ID="aux_pr_id" runat="server" />
                        <asp:HiddenField ID="aux_tipo_validacion" runat="server" />
                        <div class="table-responsive py-4">
                            <asp:UpdatePanel ID="up_GvItems" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gv_validar_items" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_validar_items_PreRender" OnRowCommand="gv_validar_items_RowCommand" DataKeyNames="as_id, per_id, ca_id" runat="server">
                                        <Columns>
                                            <asp:BoundField DataField="per_id" HeaderText="Cód. Fun." HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="ci" HeaderText="Carnet de identidad" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-bold" />
                                            <asp:BoundField DataField="nombre_fun" HeaderText="Nombre funcionario" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-left" />
                                            <asp:BoundField DataField="item" HeaderText="Ítem" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="ubicacion" HeaderText="Unidad organizacional" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="as_fecha_inicio" HeaderText="Fecha asignación" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="haber_basico" HeaderText="Haber Basico" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:TemplateField HeaderText="" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                                <ItemTemplate>
                                                    <asp:LinkButton CommandName="Aprobar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-success btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-check fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Aprobar' runat="server" />
                                                    <asp:LinkButton CommandName="Reprobar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Reprobar' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:UpdateProgress ID="up_3" AssociatedUpdatePanelID="up_aprobar" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress ID="up4" AssociatedUpdatePanelID="up_GvItems" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>


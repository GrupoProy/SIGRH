<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ReprobarValidaciones.aspx.cs" Inherits="Salarios_ReprobarValidaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Reprobar Validaciones</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:UpdatePanel ID="updateReprobaciones" runat="server">
        <ContentTemplate>
    <div class="container-fluid mt--6">
        <div class="row">
            <div class="col-lg-6">
                <div class="card-wrapper">
                    <div class="card">
                        <div class="card-header">
                            <div class="row align-items-center">
                                <div class="col-12">
                                    <div class=" ct-page-title">
                                        <h3 class="mb-0">Búsqueda de Funcionario</h3>
                                        <p class="text-sm mb-0">
                                            Digite el carnet de identidad para buscar al funcionario.
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card-body">
                            <asp:Panel DefaultButton="btn_Buscar_ci" runat="server">
                                <div class="row">
                                    <div class="col-lg-12" runat="server" visible="false">
                                        <asp:UpdatePanel ID="validacion_combo" runat="server">
                                            <ContentTemplate>
                                                <div class="form-group">
                                                    <label class="form-control-label" for="exampleFormControlSelect1">Tipo de Validación</label>
                                                    <asp:DropDownList ID="ddl_validaMemo" AppendDataBoundItems="true" CssClass="form-control select2" AutoPostBack="true" OnSelectedIndexChanged="ddl_validaMemo_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_validaMemo" InitialValue="0" Display="Dynamic" ValidationGroup="buscar_validacion" runat="server" />
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-lg-8">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <div class="form-group">
                                                    <label class="form-control-label" for="example4cols1Input">Código de Funcionario</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_ci" CssClass="form-control" type="number" runat="server" />
                                                    </div>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_ci" Display="Dynamic" ValidationGroup="buscar_validacion" runat="server" />
                                                </div>
                                                <asp:HiddenField ID="aux_as_id" runat="server" />
                                                <asp:HiddenField ID="aux_as_per_id" runat="server" />
                                                <asp:HiddenField ID="aux_validar_item" runat="server" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-sm-6 col-md-4">
                                        <div class="form-group">
                                            <label class="form-control-label" for="example4cols7Input">&nbsp</label>
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <asp:LinkButton ID="btn_Buscar_ci" CssClass="btn btn-info btn-block" Text="<i class='fas fa-search'></i> Buscar" OnClick="btn_Buscar_ci_Click" ValidationGroup="buscar_validacion" runat="server" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                            <br />
                            <%--<h6 class="heading-small text-muted mb-1">Datos de la fecha asignación</h6>
                            <div class="pl-lg-12">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="exampleFormControlSelect1">Fecha Inicio</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_fecha_inicio" class="form-control datepickerDefault" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="exampleFormControlSelect1">Fecha Fin</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_fecha_fin" class="form-control datepickerDefault" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>--%>
                            <div class="row">
                                <div class="col-lg-6"></div>
                                <div id="block_reprobar" class="col-sm-6 col-md-6" style="display: none">
                                    <div class="form-group">
                                        <label class="form-control-label" for="example4cols3Input">&nbsp</label>
                                        <asp:UpdatePanel ID="up_reprobar" runat="server">
                                            <ContentTemplate>
                                                <asp:LinkButton ID="btn_reprobar_validacion" CssClass="btn btn-success btn-block" Text="<i class='fas fa-trash'></i> Reprobar" OnClick="btn_reprobar_validacion_Click" runat="server" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-lg-6">
                <div class="card-wrapper">
                    <div class="card">
                        <div class="card-header">
                            <div class="row align-items-center">
                                <div class="col-12">
                                    <div class=" ct-page-title">
                                        <h3 class="mb-0 text-org2">Cantidad de movimientos a validar </h3>
                                        <p class="text-sm mb-0">
                                            Detalle de los movimientos que aún quedan por validar.
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card-body">
                            <asp:UpdatePanel ID="up_cantidad_validar" runat="server">
                                <ContentTemplate>
                                    <div class="pl-lg-12">
                                        <div class="tag-label">
                                            <div class="row">
                                                <div class="col-lg-10">
                                                    <span>Validación alta:<span class="tag-label-content"><asp:Literal ID="ltl_valida_alta" runat="server" /></span></span>
                                                </div>
                                                <div class="col-lg-2">
                                                    <asp:LinkButton ID="btn_listar_altas" CssClass="btn btn-facebook btn-sm" Text="<i class='fas fa-list-ul'></i>" data-toggle='tooltip' data-placement='top'  OnClick="btn_listar_altas_Click" runat="server" />
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-10">
                                                    <span>Validación baja:<span class="tag-label-content"><asp:Literal ID="ltl_valida_baja" runat="server" /></span></span>
                                                </div>
                                                <div class="col-lg-2">
                                                    <asp:LinkButton ID="btn_listar_bajas" CssClass="btn btn-facebook btn-sm" Text="<i class='fas fa-list-ul'></i>" data-toggle='tooltip' data-placement='top'  OnClick="btn_listar_bajas_Click" runat="server" />
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-10">
                                                    <span>Validación Rem./ Prom./ Transf.:<span class="tag-label-content"><asp:Literal ID="ltl_valida_RPT" runat="server" /></span></span>
                                                </div>
                                                <div class="col-lg-2">
                                                    <asp:LinkButton ID="btn_listar_RPT" CssClass="btn btn-facebook  btn-sm" Text="<i class='fas fa-list-ul'></i>" data-toggle='tooltip' data-placement='top' OnClick="btn_listar_RPT_Click" runat="server" />
                                                </div>
                                            </div>
                                            <div class="row" runat="server" visible="false">
                                                <div class="col-lg-10">
                                                    <span>Validación alta comisión e interinato:<span class="tag-label-content"><asp:Literal ID="ltl_valida_altaCI" runat="server" /></span></span>
                                                </div>
                                                <div class="col-lg-2">
                                                    <asp:LinkButton ID="btn_listar_altasCI" CssClass="btn btn-facebook btn-sm" Text="<i class='fas fa-list-ul'></i>" data-toggle='tooltip' data-placement='top' title='Altas C/I' OnClick="btn_listar_altasCI_Click" runat="server" />
                                                </div>
                                            </div>
                                            <div class="row" runat="server" visible="false">
                                                <div class="col-lg-10">
                                                    <span>Validación baja comisión e interinato:<span class="tag-label-content"><asp:Literal ID="ltl_valida_bajaCI" runat="server" /></span></span>
                                                </div>
                                                <div class="col-lg-2">
                                                    <asp:LinkButton ID="btn_listar_bajasCI" CssClass="btn btn-facebook btn-sm" Text="<i class='fas fa-list-ul'></i>" data-toggle='tooltip' data-placement='top' title='Bajas C/I' OnClick="btn_listar_bajasCI_Click" runat="server" />
                                                </div>
                                            </div>
                                            <div class="row" runat="server" visible="false">
                                                <div class="col-lg-10">
                                                    <span>Validación memorándums varios :<span class="tag-label-content"><asp:Literal ID="ltl_valida_memosVarios" runat="server" /></span></span>
                                                </div>
                                                <div class="col-lg-2">
                                                    <asp:LinkButton ID="btn_listar_memosVarios" CssClass="btn btn-facebook btn-sm" Text="<i class='fas fa-list-ul'></i>" data-toggle='tooltip' data-placement='top' title='Memos Varios' OnClick="btn_listar_memosVarios_Click" runat="server" />
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
            <div class="container-fluid">
                <div class="row">
                    <div class="col-1"></div>
                    <div class="col-9">
                        <div id="block_gv_validar">
                <div class="card">
                    <div class="card-header border-bottom" id="colValidar" >
                        <div class=" ct-page-title">
                            <h3 class="mb-0">Listado de Ítem(s) para Reprobar </h3>
                            <p class="text-sm mb-0">
                               Seleccione la asignación a reprobar
                            </p>
                        </div>
                    </div>
                    <div id="collapseGrilla">
                        <asp:UpdatePanel ID="up_GvItems" runat="server">
                            <ContentTemplate>
                                <div class="card-body">
                                    <asp:GridView ID="gv_validar_items" OnRowCommand="gv_validar_items_RowCommand" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_validar_items_PreRender" DataKeyNames="as_id" runat="server">
                                        <Columns>
                                            <asp:BoundField DataField="per_id" HeaderText="Cod_Fun" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="item" HeaderText="Ítem" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="nombre_fun" HeaderText="Nombre funcionario" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="ci" HeaderText="CI" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="ubicacion" HeaderText="Unidad organizacional" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="as_fecha_inicio" HeaderText="Fecha asignación" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />

                                        <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="130px">
                                            <ItemTemplate>
                                                <%--<asp:LinkButton CommandName="GetAssign" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-facebook btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-user-plus fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Asignar' runat="server" />--%>
                                                <asp:LinkButton CommandName="Reprobar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn bg-gradient-inst text-white btn-sm" Text="<span class='btn-inner--icon'>Reprobar<i class='fas fa-delete'></i></span>" data-toggle='tooltip' data-placement='top' title='Asignar' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
                    </div>
                </div>
            </div>
            <div id="block_datos_funcionario" class="col-lg-8" style="display: none">
                <div class="card-wrapper">
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
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:LinkButton ID="btn_estado" class="btn btn-sm btn-info float-right" runat="server" />
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
                                            <strong class="h5">ÍTEM:</strong>
                                            <asp:Literal ID="ltl_item" runat="server" />
                                        </div>
                                        <hr class="my-2">
                                        <h6 class="heading-small text-muted">Escalafón </h6>
                                        <div class="row">
                                            <div class="col-lg-4">
                                                <div class="content-text-label">Cargo</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_cargo" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="content-text-label">Puesto</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_puesto" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="content-text-label">Haber Básico (Bs)</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_haber_basico" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-4">
                                                <div class="content-text-label">Código Escalafón</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_cod_esc" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="content-text-label">Clase</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_clase" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="content-text-label">Nivel Salarial</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_nivel_salarial" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <hr class="my-2">
                                        <h6 class="heading-small text-muted">Información fecha asignación</h6>
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
                                        <hr class="my-3">
                                        <h6 class="heading-small text-muted">Categoría administrativa</h6>
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
                                        <hr class="my-3">
                                        <h6 class="heading-small text-muted">Categoría programática</h6>
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
                                        <%-- DATOS DEL FUNCIONARIO TITULAR PARA COMISIÓN INTERINATO --%>
                                        <div id="block_datos_fun_int" style="display: none; background-color: #D2EEE0; border-radius: .375rem; padding-left: 17px;">
                                            <hr class="my-3">
                                            <h6 class="heading-small text-muted">Datos del funcionario titular</h6>
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Nombre Funcionario</div>
                                                    <div class="h5 font-weight-400 content-text content-text">
                                                        <asp:Literal ID="ltl_nombre_fun_int" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Documento de identidad </div>
                                                    <div class="h5 font-weight-400 content-text content-text">
                                                        <asp:Literal ID="ltl_ci_int" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Código de funcionario </div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_cod_fun_int" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Ítem</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_item_int" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <%-- DATOS ADICIONALES PARA COMISIÓN INTERINATO --%>
                                        <div id="block_datos_adicionales_int" style="display: none; background-color: #D2E0EE; border-radius: .375rem; padding-left: 17px;">
                                            <hr class="my-3">
                                            <h6 class="heading-small text-muted">Asignación comisión / interinato / a disposición  de personal</h6>
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
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Cargo</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_cargo_int" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Haber Básico (Bs)</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_haber_basico_int" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-4">
                                                    <div class="content-text-label">Código Escalafón</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_cod_esc_int" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-4">
                                                    <div class="content-text-label">Clase</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_clase_int" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-4">
                                                    <div class="content-text-label">Nivel Salarial</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_nivel_salarial_int" runat="server" />
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
                                                    <div class="content-text-label">Descripción movimiento</div>
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
        </div>
        <div class="row" runat="server" id="grid">
        </div>

        <asp:UpdateProgress ID="up_1" AssociatedUpdatePanelID="validacion_combo" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up_2" AssociatedUpdatePanelID="up_cantidad_validar" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up_3" AssociatedUpdatePanelID="up_reprobar" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up4" AssociatedUpdatePanelID="up_GvItems" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>


        </ContentTemplate>
    </asp:UpdatePanel>

        <asp:UpdateProgress ID="up1" AssociatedUpdatePanelID="updateReprobaciones" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>

</asp:Content>


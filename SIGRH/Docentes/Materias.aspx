<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="Materias.aspx.cs" Inherits="MovimientoPersonal_DocenteAgre" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Materias</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Header -->
    <div class="card">
        <div class="card-header border-bottom">
            <div class="ct-page-title">
                <h3 class="mb-0">Búsqueda de Plan de Estudio</h3>
                <p class="text-sm mb-0">Busque el plan para editar la información o cree un nuevo registro de plan</p>
            </div>
        </div>
        <asp:UpdatePanel ID="panelBusq" runat="server">
            <ContentTemplate>
                <asp:Panel CssClass="card-body" runat="server">
            <div class="row">
                <!-- plan_area -->
                <div class="form-group col-md-3">
                    <label class="form-control-label">Area</label>
                    <asp:DropDownList ID="ddl_area" AutoPostBack="true" OnSelectedIndexChanged="ddl_area_SelectedIndexChanged" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_area" ValidationGroup="search" Display="Dynamic" runat="server" />
                </div>
                <!-- plan_carrera_nombre -->
                <div class="form-group col-md-3">
                    <label class="form-control-label">Carrera</label>
                    <asp:DropDownList ID="Ddl_carrera_nombre" AutoPostBack="true" OnSelectedIndexChanged="Ddl_carrera_nombre_SelectedIndexChanged" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_carrera_nombre" ValidationGroup="search" Display="Dynamic" runat="server" />
                </div>
                <!-- plan Estudio Busqueda -->
                <div class="form-group col-md-3">
                    <label class="form-control-label">Plan de Estudio</label>
                    <asp:DropDownList ID="ddl_plan_bus" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_plan_bus" ValidationGroup="search" Display="Dynamic" runat="server" />
                </div>
            </div>
            <div class="row">
                <!-- Botones -->
                <div class="form-group col-md-3">
                    <asp:LinkButton ID="BtnBuscar" ValidationGroup="search" CssClass="btn btn-info btn-block top-4" OnClick="BtnBuscar_Click" Text="<i class='fas fa-search'></i> Buscar" runat="server" />
                </div>
                <div class="form-group col-md-3">
                    <asp:LinkButton ID="BtnNuevo" CssClass="btn btn-warning btn-block top-4" Text="<i class='fas fa-plus'>   Nuevo</i>" data-toggle="tooltip" OnClick="BtnNuevo_Click" data-original-title="Nuevo Registro" runat="server" />
                </div>
            </div>
        </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddl_area" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddl_plan_bus" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="Ddl_carrera_nombre" EventName="SelectedIndexChanged" />
                <%--<asp:AsyncPostBackTrigger ControlID="BtnBuscar" EventName="Click" />--%>
                <asp:PostBackTrigger ControlID="BtnBuscar" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    
     <!-- REGISTRO -->
    <asp:UpdatePanel ID="panelAgregar" runat="server">
        <ContentTemplate>
            <asp:Panel ID="mat_Agregar" CssClass="card" Visible="false" BackColor="Transparent" runat="server">
                <contenttemplate>

                    <div class="col-md-6">
                        <div class="card">
                            <div class="card-header border-bottom">
                                <div class="ct-page-title">
                                    <h3 class="mb-0">Materia</h3>
                                    <p class="text-sm mb-0">En el siguiente formulario puede ingresar los datos de la asignatura.</p>
                                </div>
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <!-- Area -->
                                    <div class="form-group col-md-8">
                                        <label class="form-control-label">Area</label>
                                        <asp:DropDownList ID="ddl_plan_area" AutoPostBack="true" OnSelectedIndexChanged="ddl_plan_area_SelectedIndexChanged" CssClass="form-control select2" data-minimum-results-for-search="Infinity" AppendDataBoundItems="true" runat="server" />
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_plan_area" ValidationGroup="add" Display="Dynamic" runat="server" />
                                    </div>
                                    <!-- Nivel -->
                                    <div class="form-group col-md-3">
                                        <label class="form-control-label">Nivel</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="far fa-calendar-alt"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="Txt_nivel" CssClass="form-control number" runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_nivel" ValidationGroup="add" Display="Dynamic" runat="server" />
                                    </div>
                                </div>
                                <div class="row">
                                    <!-- Carrera -->
                                    <div class="form-group col-md-8">
                                        <label class="form-control-label">Carrera</label>
                                        <asp:DropDownList ID="ddl_plan_carrera" AutoPostBack="true" OnSelectedIndexChanged="ddl_plan_carrera_SelectedIndexChanged" CssClass="form-control select2" data-minimum-results-for-search="Infinity" AppendDataBoundItems="true" runat="server" />
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_plan_carrera" ValidationGroup="add" Display="Dynamic" runat="server" />
                                    </div>
                                    <!-- Plan de estudio -->
                                    <div class="form-group col-md-3">
                                        <label class="form-control-label">Plan de estudio</label>
                                        <asp:DropDownList ID="ddl_plan" AutoPostBack="true" CssClass="form-control select2" data-minimum-results-for-search="Infinity" AppendDataBoundItems="true" runat="server" />
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_plan" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                                    </div>
                                </div>
                                <div class="row">
                                    <!-- Asignatura -->
                                    <div class="form-group col-md-8">
                                        <label class="form-control-label">Asignatura</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-book"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="Txt_mat_nombre" CssClass="form-control" runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_mat_nombre" ValidationGroup="add" Display="Dynamic" runat="server" />
                                    </div>
                                    <!-- Sigla -->
                                    <div class="form-group col-md-3">
                                        <label class="form-control-label">Sigla</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="far fa-calendar-alt"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="Txt_sigla" CssClass="form-control" runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_sigla" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                                    </div>
                                </div>
                                <div class="row">
                                    <!-- horas asignadas -->
                                    <div class="form-group col-md-8">
                                        <label class="form-control-label">Horas asignadas</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="far fa-clock"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="Txt_horas" CssClass="form-control" runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_horas" ValidationGroup="add" Display="Dynamic" runat="server" />
                                    </div>
                                    <!-- Grupo materia -->
                                    <div class="form-group col-md-3">
                                        <label class="form-control-label">Grupo de materia</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-users"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="Txt_grupo" CssClass="form-control" runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_grupo" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="card-body text-right">
                                <asp:LinkButton ID="BtnGuardar" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Guardar" ValidationGroup="add" OnClick="BtnGuardar_Click" runat="server" />
                            </div>
                        </div>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddl_plan" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddl_plan_carrera" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>

    <!-- Mostrar Materias -->
    <asp:UpdatePanel ID="panelMaterias" runat="server">
        <ContentTemplate>
            <asp:Panel ID="materia_result" CssClass="card" Visible="false" runat="server">
                <div class="card-header border-bottom">
                    <h3 class="mb-0">Resultado Búsqueda</h3>
                </div>
                <div class="card-body">
                    <!-- Placing GridView in UpdatePanel -->
                    <asp:GridView ID="GvLista" OnPreRender="GvLista_PreRender" EmptyDataText="No hay registros" CssClass="table table-bordered table-hover table-striped" OnRowCommand="GvLista_RowCommand" AutoGenerateColumns="false" DataKeyNames="mat_id, mat_plan_id" runat="server">
                        <Columns>
                            <asp:BoundField DataField="mat_estado" HeaderText="Estado"/>
                            <asp:BoundField DataField="mat_sigla" HeaderText="Sigla" />
                            <asp:BoundField DataField="mat_nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="mat_horas_plan" HeaderText="Horas Asignadas" />
                            <asp:BoundField DataField="mat_fecha_creacion" HeaderText="Fecha Creacion" />
                            <asp:BoundField DataField="mat_nivel" HeaderText="Nivel" />
                            <asp:BoundField DataField="mat_grupo" HeaderText="Grupo" />
                            <asp:TemplateField HeaderText="Cambiar Estado" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="BtnModificar" CommandName="Eliminar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-ban'></i></span>" data-toggle='tooltip' data-placement='top' title='Cambiar Estado' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <!-- Fin registro -->

</asp:Content>
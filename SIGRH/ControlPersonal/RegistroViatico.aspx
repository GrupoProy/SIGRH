<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="RegistroViatico.aspx.cs" Inherits="ControlPersonal_RegistroViatico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="header pb-6" style="margin-top: -4em; margin-left: 3em; width: 81%">
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Registro de Viatico por Persona</h6>
                    </div>
                    <div class="col-lg-6 col-5 text-right">
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:UpdatePanel runat="server" ID="PanelPersonal">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="row justify-content-center" style="margin-top: -2em">
                    <div class="col-lg-10 card-wrapper" runat="server" id="PanelBusqueda" visible="true">
                        <div class="card">
                            <div class="card-header" style="margin-top: -2em">
                                <div class=" ct-page-title">
                                    <h3 class="mb-0">Registro de datos del viatico: </h3>
                                </div>
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-sm-5 col-md-4">
                                        <div class="form-group">
                                            <label class="form-control-label">Destino: </label>
                                            <asp:DropDownList ID="ddl_destino" OnSelectedIndexChanged="ddl_destino_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-sm-3 col-md-2">
                                        <div class="form-group">
                                            <label class="form-control-label">Categoria: </label>
                                            <asp:DropDownList ID="ddl_categoria" OnSelectedIndexChanged="ddl_categoria_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-sm-2 col-md-2">
                                        <div class="form-group">
                                            <label class="form-control-label" for="exampleFormControlSelect1">Fecha Inicio</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                </div>
                                                <asp:TextBox ID="txt_fecha_inicio" AutoPostBack="true" OnTextChanged="txt_fecha_inicio_TextChanged" AutoComplete="off" CssClass="form-control datepickerDefault" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_fecha_inicio" ValidationGroup="Procesar" Display="Dynamic" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-sm-2 col-md-2">
                                        <div class="form-group">
                                            <label class="form-control-label" for="exampleFormControlSelect1">Fecha Fin</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                </div>
                                                <asp:TextBox ID="txt_fecha_fin" AutoPostBack="true" OnTextChanged="txt_fecha_fin_TextChanged" AutoComplete="off" CssClass="form-control datepickerDefault" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_fecha_fin" ValidationGroup="Procesar" Display="Dynamic" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-sm-2 col-md-2">
                                        <div class="form-group">
                                            <label class="form-control-label">Dias: </label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text border-default-2"><i class="ni ni-calendar-grid-58"></i></span>
                                                </div>
                                                <asp:TextBox ID="txtDias" class="form-control border-default-2" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <!-- gl_glosa -->
                                    <div class="col-sm-5 col-md-4">
                                        <label class="form-control-label" for="txtObjeto">Objeto</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-edit"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="txtObjeto" CssClass="form-control" TextMode="multiline" Rows="4" runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtObjeto" ValidationGroup="Procesar" Display="Dynamic" runat="server" />
                                    </div>
                                    <div class="col-sm-3 col-md-2">
                                        <div class="form-group">
                                            <label class="form-control-label">Monto Curso: </label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text border-default-2"><i class="fas fa-edit"></i></span>
                                                </div>
                                                <asp:TextBox ID="txtMontoCurso" class="form-control border-default-2" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-3 col-md-2">
                                        <div class="form-group">
                                            <label class="form-control-label">Cambio USD($): </label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text border-default-2"><i class="fas fa-edit"></i></span>
                                                </div>
                                                <asp:TextBox ID="txt_cambio" class="form-control border-default-2" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-3 col-md-2">
                                        <div class="form-group">
                                            <label class="form-control-label">CI</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text border-default-2"><i class="fas fa-edit"></i></span>
                                                </div>
                                                <asp:TextBox ID="txt_ci" class="form-control border-default-2" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-3 col-md-2">
                                        <div class="form-group text-right">
                                            <label class="form-control-label">&nbsp</label>
                                            <asp:LinkButton ID="btnFiltrar" OnClick="btnFiltrar_Click" CssClass="btn btn-vimeo btn-block" Text="<i class='fas fa-search'></i> Buscar" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="card">
                    <div id="GridPersonal" visible="false" runat="server" style="margin-top: -1em">
                        <!-- Card header -->
                        <div class="card-header d-flex align-items-center">
                            <div class="d-flex align-items-center">
                                <div class="text-dark font-weight-600 text-sm">
                                    <h3 class="mb-0">Seleccione la asignación que irá a la planilla adicional</h3>
                                </div>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive py-4" style="margin-top: -2em">
                                <asp:GridView ID="GvFuncionarios" OnRowCommand="GvFuncionarios_RowCommand" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="as_id, per_id" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="item" HeaderText="ITEM" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="as_fecha_inicio" HeaderText="FECHAS INICIO" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="as_fecha_fin" DataFormatString="{0:dd/MM/yyyy}" HeaderText="FECHA FIN" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="nombreFunc" HeaderText="NOMBRE" HeaderStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="ciFunc" HeaderText="CI" HeaderStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="eo_descripcion" HeaderText="UNIDAD" HeaderStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="es_descripcion" HeaderText="ESCALA SALARIAL" HeaderStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="fechas" HeaderText="FECHAS" HeaderStyle-CssClass="text-center" />
                                        <asp:TemplateField HeaderText="Elegir" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:LinkButton CommandName="Elegir" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-vimeo btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-check fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Elegir' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>


                <!-- GRID DE LOS NO IMPRESOS -->
                <div class="card">
                    <div id="GridPlanilla" visible="false" runat="server" style="margin-top: -1em">
                        <!-- Card header -->
                        <div class="card-header d-flex align-items-center">
                            <div class="d-flex align-items-center">
                                <div class="text-dark font-weight-600 text-sm">
                                    <h3 class="mb-0">Seleccione la asignación que irá a la planilla adicional</h3>
                                </div>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive py-4" style="margin-top: -2em">
                                <asp:GridView ID="GvNoImpreso" OnPreRender="GvNoImpreso_PreRender" OnRowCommand="GvNoImpreso_RowCommand" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="vi_id, per_id, ev_id" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="vi_nro_planilla" HeaderText="NRO DE PLANILLA" HeaderStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="nombreFunc" HeaderText="NOMBRE" HeaderStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="ciFunc" HeaderText="CI" HeaderStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="item" HeaderText="ITEM" HeaderStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="eo_descripcion" HeaderText="UNIDAD FUNCIONAL" HeaderStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="vi_fecha_ini" DataFormatString="{0:dd/MM/yyyy}" HeaderText="FECHA INICIO" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="vi_fecha_fin" DataFormatString="{0:dd/MM/yyyy}" HeaderText="FECHA FIN" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="vi_dias" HeaderText="DIAS DE VIATICO" HeaderStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="ev_cat" HeaderText="CATEGORIA" HeaderStyle-CssClass="text-center" />
                                        <asp:TemplateField HeaderText="Eliminar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:LinkButton CommandName="Eliminar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Eliminar' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <div class="row">
                                    <div class="col-sm-10 col-md-9">
                                    </div>
                                    <div class="col-sm-3 col-md-2">
                                        <div class="form-group text-right">
                                            <label class="form-control-label">&nbsp</label>
                                            <asp:LinkButton ID="btnProcesar" OnClick="btnProcesar_Click" CssClass="btn btn-vimeo btn-block" Text="<i class='fas fa-search'></i> Finalizar" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnFiltrar" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="txt_fecha_fin" EventName="TextChanged" />
            <asp:AsyncPostBackTrigger ControlID="txt_fecha_inicio" EventName="TextChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddl_destino" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddl_categoria" EventName="SelectedIndexChanged" />
        </Triggers>

    </asp:UpdatePanel>
</asp:Content>


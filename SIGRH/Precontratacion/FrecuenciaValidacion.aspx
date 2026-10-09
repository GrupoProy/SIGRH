<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="FrecuenciaValidacion.aspx.cs" Inherits="Precontratacion_FrecuenciaValidacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Validación de Frecuencias</h6>
                    </div>
                    <div class="col-lg-6 col-5 text-right">

                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:LinkButton ID="btn_imprimir" CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-inst text-white rounded-circle shadow" Text="<i class='fas fa-print'></i>" data-toggle="tooltip" data-original-title="Imprimir" OnClick="btn_imprimir_Click" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid mt--6">
        <div class="row">
            <div class="col">
                <div class="card">
                    <div class="card-header d-flex align-items-center">
                        <div class="d-flex align-items-center">
                            <div class="text-dark font-weight-600 text-sm">
                                <div class=" ct-page-title">
                                    <h3 class="mb-0">Lista Frecuencias</h3>
                                    <p class="text-sm mb-0">En la tabla se muestra todas las frecuencias que le corresponde a la categoría anteriormente seleccionada.</p>
                                </div>
                            </div>

                        </div>
                        <div class="text-right ml-auto">
                            <asp:UpdatePanel ID="up_btn_enviar_planilla" runat="server">
                                <ContentTemplate>
                                    <asp:LinkButton ID="btn_reprobar" CssClass="btn btn-warning btn-round btn-icon disabled" data-toggle="tooltip" data-original-title="Observar Frecuencias" Text="<span class='btn-inner--icon'><i class='fas fa-eye'></i></span><span class='btn-inner--text'>Observar</span>" OnClick="btn_reprobar_Click" runat="server" />
                                    <asp:LinkButton ID="btn_aprobar" CssClass="btn btn-slack btn-round btn-icon disabled" data-toggle="tooltip" data-original-title="Validar Frecuencias" Text="<span class='btn-inner--icon'><i class='fas fa-check'></i></span><span class='btn-inner--text'>Validar</span>" OnClick="btn_aprobar_Click" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-lg-8">
                                        <div class="content-text-label">DESCRIPCIÓN PRESUPUESTO</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_desc" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-1">
                                        <div class="content-text-label">DA</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_da" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-1">
                                        <div class="content-text-label">UE</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_ue" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-1">
                                        <div class="content-text-label">Fuente</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_fuente" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-1">
                                        <div class="content-text-label">Organismo</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_org" runat="server" />
                                        </div>
                                    </div>

                                </div>
                                <hr class="my-1">
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="table-responsive pb-4">
                        <asp:UpdatePanel ID="up_gv_frecuencias" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gv_frecuencias" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" OnPreRender="gv_frecuencias_PreRender" DataKeyNames="fr_id" runat="server">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                            <HeaderTemplate>
                                                CARGO
                                                <asp:DropDownList ID="ddl_gv_frec_cargo" CssClass="custom-select custom-select-sm form-control form-control-sm" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="ddl_gv_frec_cargo_SelectedIndexChanged" runat="server" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%# Eval("es_descripcion") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="haber_basico" HeaderText="Haber básico (Bs)" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:0.00}" />
                                        <asp:BoundField DataField="fr_fecha_inicio" HeaderText="Fecha Inicio" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="fr_fecha_fin" HeaderText="Fecha Fin" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:TemplateField HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                            <HeaderTemplate>
                                                Tiempo (Meses)
                                                <asp:DropDownList ID="ddl_gv_frec_tiempo" CssClass="custom-select custom-select-sm form-control form-control-sm" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="ddl_gv_frec_cargo_SelectedIndexChanged" runat="server" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%# Eval("fr_tiempo") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="fr_tipo_jornada" HeaderText="Tipo jornada" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <%--<asp:BoundField DataField="fr_pu_id" HeaderText="Puesto" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />--%>
                                        <asp:TemplateField HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                            <HeaderTemplate>
                                                Estado
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_gv_frec_estado" Text='<%# Eval("estado") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="card-body" id="d_gv_frecuencias" style="padding-top: unset;" runat="server">
                                <div class="row">
                                    <div class="col-md-12">
                                        <p class="text-sm grid-notify-success">No existen frecuencias con la categoría seleccionada. </p>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

            </div>
        </div>
        <div class="row">
            <div class="col-lg-7">
                <div class="card-wrapper">
                    <div class="card">
                        <div class="card-header">
                            <div class=" ct-page-title">
                                <h3 class="mb-0">Resumen Frecuencias</h3>
                            </div>
                        </div>

                        <div class="table-responsive py-4">
                            <asp:UpdatePanel ID="up_gv_fracuencias_resumen" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gv_fracuencias_resumen" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" OnPreRender="gv_fracuencias_resumen_PreRender" DataKeyNames="fr_es_id, fr_pu_descripcion, fr_tipo_jornada, fr_fecha_inicio, fr_fecha_fin, fr_tiempo" runat="server">
                                        <Columns>
                                            <asp:BoundField DataField="es_descripcion" HeaderText="Cargo" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="haber_basico" HeaderText="Haber básico (Bs)" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:0.00}" />
                                            <%--  <asp:BoundField DataField="fr_pu_id" HeaderText="Puesto" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="fr_tipo_jornada" HeaderText="Tipo jornada" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />--%>
                                            <asp:BoundField DataField="fr_fecha_inicio" HeaderText="Fecha inicio" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="fr_fecha_fin" HeaderText="Fecha Fin" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="fr_tiempo" HeaderText="Tiempo (Meses)" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center " />
                                            <asp:BoundField DataField="cantidad" HeaderText="Cantidad" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center display-2 dt-sub-title" />

                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="card-body" id="d_gv_fracuencias_resumen" style="padding-top: unset;" runat="server">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <p class="text-sm grid-notify-success">No existen frecuencias con la categoría seleccionada. </p>
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
                    <div class="card">
                        <div class="card-header">
                            <div class=" ct-page-title">
                                <h3 class="mb-0">Resumen Presupuestario</h3>
                            </div>
                        </div>
                        <div class="table-responsive py-4">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gv_resumen_presup" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" OnPreRender="gv_resumen_presup_PreRender" DataKeyNames="PARTIDA" runat="server">
                                        <Columns>
                                             <asp:BoundField DataField="PARTIDA" HeaderText="Partida Presupuestaria" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="MONTO" HeaderText="Comprometido (Bs)" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:N2}" />
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                                        <div class="card-header" style="border: none !important">
                            <div class=" ct-page-title">
                                <h3 class="mb-0">Resumen Presupuestario General</h3>
                            </div>
                        </div>
                        <div class="table-responsive py-2">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gv_resumen_presup_gral" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" OnPreRender="gv_resumen_presup_gral_PreRender" DataKeyNames="PARTIDA" runat="server">
                                        <Columns>
                                            <asp:BoundField DataField="PARTIDA" HeaderText="Partida Presupuestaria" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="MONTO" HeaderText="Presupuesto (Bs)" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:N2}" />
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

    <div class="modal fade" id="modalConfirmacionA" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
        <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
            <div class="modal-content bg-gradient-success">
                <div class="modal-header">
                </div>

                <asp:UpdatePanel ID="up_confirmar_aprob" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div class="py-3 text-center">
                                <i class="ni ni-check-bold ni-3x"></i>
                                <h4 class="heading text-dark mt-4">¿Está seguro de validar las frecuencias registradas?</h4>
                            </div>
                        </div>
                        <div class="form-group text-center">
                            <asp:LinkButton ID="btn_confirmar_aprob" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-info" OnClick="btn_confirmar_aprob_Click" runat="server" />
                            <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modalConformarR" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
        <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
            <div class="modal-content bg-gradient-dark6">
                <div class="modal-header">
                </div>

                <asp:UpdatePanel ID="up_confirmar_rep" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div class="py-3 text-center">
                                <i class="ni ni-folder-17 ni-3x"></i>
                                <h4 class="heading text-dark mt-4">Está observando la planilla de frecuencias</h4>
                                <p>Por favor ingrese sus observaciones</p>
                                <div class="row">
                                    <div class="col-sm-6 col-md-12">
                                        <div class="form-group">
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend  ">
                                                    <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                </div>
                                                <asp:TextBox ID="txt_observaciones" class="form-control" TextMode="multiline" Rows="4" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_observaciones" Display="Dynamic" ValidationGroup="reprobarFr" runat="server" />

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group text-center">
                            <asp:LinkButton ID="btn_confirmar_rep" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btn_confirmar_rep_Click" ValidationGroup="reprobarFr" runat="server" />
                            <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <asp:UpdateProgress ID="up" AssociatedUpdatePanelID="up_confirmar_rep" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress ID="up1" AssociatedUpdatePanelID="up_confirmar_aprob" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress ID="up2" AssociatedUpdatePanelID="up_btn_enviar_planilla" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>

</asp:Content>


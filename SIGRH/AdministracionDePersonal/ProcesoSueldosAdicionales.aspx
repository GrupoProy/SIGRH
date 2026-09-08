<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ProcesoSueldosAdicionales.aspx.cs" Inherits="AdministracionDePersonal_ProcesoSueldosAdicionales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel runat="server" ID="UpdateProcesoSueldo">
        <ContentTemplate>
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Proceso de Sueldos - ADICIONALES</h6>

                    </div>
                    <div class="col-lg-6 col-5 text-right">
                    </div>

                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid mt--6">
        <div class="row">
            <div class="col-lg-5" id="DivPanelActualizacion" runat="server">
                <div class="card-wrapper">
                    <div class="card">

                        <div class="card-body">
                                            <div class="col-lg-12">
                                                <div class="form-group">
                                                    <asp:Label class="form-control-label" Text="text" ID="lblMes" runat="server" />
                                                     <asp:TextBox ID="txt_pc_id" Visible="false"  class="form-control numero" runat="server"  Enabled="false"/>
                                                </div>
                                            </div>
                                    <hr />
                                    <h6 class="heading-small text-muted mb-2">Verificar salario mínimo nacional</h6>
                                    <div class="pl-lg-4">

                                        <div class="row">
                                            <div class="col-lg-5">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="input-country">Salario mínimo nacional (Bs)</label>
                                                    <asp:TextBox ID="txt_salario_minimo" class="form-control numero" runat="server" />
                                                </div>
                                            </div>

                                            <div class="col-lg-12">
                                            <hr class="my-4">
                                            </div>

                                    <div class="form-group col-lg-8">
                                        <div class="ct-page-title">
                                            <h3 class="mb-0">FNTUB</h3>
                                            <p class="text-sm mb-0">Descuento Federación Nacional de Trabajadores Universitarios de Bolivia</p>
                                        </div>
                                    </div>
                                    <div class="form-group col-lg-2">
                                            <label class="custom-toggle custom-toggle-warning">
                                                <asp:CheckBox ID="chkFntub" AutoPostBack="true" OnCheckedChanged="chkFntub_CheckedChanged"  runat="server" />
                                                <span class="custom-toggle-slider rounded-circle" data-label-off="No" data-label-on="Si"></span>
                                            </label>
                                    </div>
                                           <label runat="server" id="lblFNTUB" visible="false" class="form-control-label" for="input-country">Valor Descuento FNTUB en %:</label>
                                           <asp:TextBox ID="txtValorFntub" class="form-control" runat="server" Visible="false"/>



                                        </div>
                                    </div>  
                        </div>
                                            <div class="col-lg-12">
                                                <div class="form-group">
                                                    <asp:LinkButton ID="btn_guardar_mn" CssClass="btn btn-warning btn-block btn-round btn-icon" data-toggle="tooltip" data-original-title="Actualizar" Text="<span class='btn-inner--icon'><i class='fas fa-sync-alt'></i></span><span class='btn-inner--text'>Actualizar</span>" OnClick="btn_guardar_mn_Click" runat="server" />
                                                </div>
                                            </div>                            

                                        <div class="modal fade" id="coonfimarGuardarUFV" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                        <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                            <div class="modal-content bg-gradient-dark6">
                                <div class="modal-header">

                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                </div>

                                        <asp:HiddenField ID="hf_pc_id" runat="server" />
                                        <asp:HiddenField ID="hf_secuen" runat="server" />
                                        <asp:HiddenField ID="hf_pc" runat="server" />
                                        <asp:HiddenField ID="hf_sm_id" runat="server" />
                                        <asp:HiddenField ID="hf_sm_importe" runat="server" />
                                        <asp:HiddenField ID="hf_sm_operacion" runat="server" />
                                        <asp:HiddenField ID="hf_sm_fecha_vigencia" runat="server" />
                                        <asp:HiddenField ID="hf_sm_porcentaje_incremento" runat="server" />
                                        <asp:HiddenField ID="hf_sm_estado" runat="server" />
                                        <div class="modal-body">
                                            <div class="py-3 text-center">
                                                <i class="ni ni-fat-add ni-3x"></i>
                                                <h4 class="heading text-dark mt-4">¿Esta seguro de guardar el UFV?</h4>
                                            </div>
                                        </div>
                                        <div class="form-group text-center">
<%--                                            <asp:LinkButton ID="btn_confirm_guardar_ufv" OnClick="btn_confirm_guardar_ufv_Click" Text="<i class='fas fa-check-circle mr-2'></i>Aceptar" CssClass="btn btn-success" runat="server" />--%>
                                            <button type="button" class="btn btn-google-plus" data-dismiss="modal"><i class="fas fa-times-circle mr-2"></i>Cancelar</button>
                                        </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal fade" id="confimarGuardarSM" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                        <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                            <div class="modal-content bg-gradient-dark6">
                                <div class="modal-header">

                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                </div>

                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                        <asp:HiddenField ID="HiddenField2" runat="server" />
                                        <asp:HiddenField ID="HiddenField3" runat="server" />
                                        <asp:HiddenField ID="HiddenField4" runat="server" />
                                        <asp:HiddenField ID="HiddenField5" runat="server" />
                                        <asp:HiddenField ID="HiddenField6" runat="server" />
                                        <asp:HiddenField ID="HiddenField7" runat="server" />
                                        <div class="modal-body">
                                            <div class="py-3 text-center">
                                                <i class="ni ni-single-copy-04 ni-3x"></i>
                                                <h4 class="heading text-dark mt-4">¿Está seguro de actualizar el salario mínimo y el FNTUB?</h4>
                                            </div>
                                        </div>
                                        <div class="form-group text-center">
                                            <asp:LinkButton ID="btn_confirm_guardar_sm" OnClick="btn_confirm_guardar_sm_Click" Text="<i class='fas fa-check-circle mr-2'></i>Aceptar" CssClass="btn btn-success" runat="server" />
                                            <button type="button" class="btn btn-google-plus" data-dismiss="modal"><i class="fas fa-times-circle mr-2"></i>Cancelar</button>
                                        </div>
                            </div>
                        </div>
                    </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-7">
                <div class="card-wrapper">
                    <div class="card">
                        <div class="card-header">
                            <h3 class="mb-0">Procesos a Ejecutar</h3>
                        </div>
                        <!-- Card body -->
                        <div class="card-body">
                            <div class="timeline timeline-one-side" data-timeline-content="axis" data-timeline-axis-style="dashed">
                                <div class="timeline-block" runat="server" id="divExcluir" visible="false">
                                    <span class="timeline-step badge-info">1</span>
                                    <div class="timeline-content d-flex align-items-center">
                                        <p class="text-sm mb-0">Validaciones antes del proceso.</p>
                                        <div class="text-right ml-auto" >
                                            <asp:Button  ID="btnProceso1" Text="Ejecutar" CssClass="btn btn-secondary  btn-round btn-icon" OnClick="btnProceso0_Click" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div runat="server" id="divProceso2" visible="true" class="timeline-block">
                                    <span class="timeline-step badge-info">1</span>
                                    <div class="timeline-content d-flex align-items-center">
                                        <p class="text-sm mb-0">Proceso Inicial.</p>
                                        <div class="text-right ml-auto" >
                                            <asp:Button ID="btnProceso2" Text="Ejecutar" OnClick="btnProceso1_Click" runat="server"  CssClass="btn btn-secondary  btn-round btn-icon"  />
                                        </div>
                                    </div>
                                </div>
                                <div  runat="server" id="divProceso3"  visible="false" class="timeline-block">
                                    <span class="timeline-step badge-info">2</span>
                                    <div class="timeline-content d-flex align-items-center">
                                        <p class="text-sm mb-0">Cálculo de Cotizables</p>
                                        <div class="text-right ml-auto" >
                                            <asp:Button ID="btnProceso3" Text="Ejecutar" OnClick="btnProceso2_Click" runat="server"  CssClass="btn btn-secondary  btn-round btn-icon"  />
                                        </div>
                                    </div>
                                </div>
                                <div  runat="server" id="divProceso3_1_fake"  visible="false" class="timeline-block">
                                    <span class="timeline-step badge-info">3</span>
                                    <div class="timeline-content d-flex align-items-center">
                                        <p class="text-sm mb-0">Doble Percepción</p>
                                        <div class="text-right ml-auto" >
                                            <asp:Button ID="btDPfake" Text="Ejecutar"  runat="server"  CssClass="btn btn-secondary  btn-round btn-icon"  />
                                        </div>
                                    </div>
                                </div>

                                <div  runat="server" id="divProceso3_1"  visible="false" class="timeline-block">
                                    <span class="timeline-step badge-info">3</span>
                                    <div class="timeline-content d-flex align-items-center">
                                        <p class="text-sm mb-0">Doble Percepción</p>
                                     </div>
                                        <div class="row">
                                        <!-- Page content -->
                                                        <div class="card-header">
                                                            <div class="ct-page-title">
                                                                <h3 class="mb-0"> </h3>
                                                                <p class="text-sm mb-0">Seleccione el registro para ajustar la doble percepción</p>
                                                            </div>
                                                        </div>
                                        </div>
                                                        <div class="row">
                                                        <div class=" col-11 card-wrapper ml-1">

                                                            <!-- Placing GridView in UpdatePanel -->
                                                            <asp:GridView ID="GvLista" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="CBH_per_id, nombres_completo"  OnPreRender="GvLista_PreRender"  OnRowCommand="GvLista_RowCommand" runat="server">
                                                                <Columns>

                                                                    <asp:BoundField DataField="NOMBRES_COMPLETO" HeaderText="Nombres" />
                                                                    <asp:BoundField DataField="CI" HeaderText="CI" />
                                                                    <asp:TemplateField HeaderText="Ajustar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton CommandName="AjustarDPercepcion" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn bg-gradient-inst text-white btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-check'></i></span>" data-toggle="tooltip" data-placement="top"  runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                        </div>
                <br />
                <br />
                <br />
                <div class="row" runat="server" id="DivDoblePercepcion" visible="false">
                <div class="card-wrapper ml-3">
                    <div class="card card-profile">
                        <div class="card-body pt-0 bg-light2">
                                        <div class="h5 font-weight-400  text-center">
                                            <strong class="h5">FUNCIONARIO: </strong>
                                            <asp:Literal ID="ltl_cod_fun" runat="server" />
                                        </div>
                        <asp:GridView ID="gvDoblePercepcion"  OnRowDataBound="gvDoblePercepcion_RowDataBound" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="per_id, ca_id, ti_tipo, cbh_id, horas, hganado, esc_por, escalafon, bono, bono_frontera"  OnPreRender="GvLista_PreRender"  OnRowCommand="gvDoblePercepcion_RowCommand"  runat="server">
                            <Columns>
                                <asp:BoundField DataField="PLANTA_CONTRATO" HeaderText="" />
                                <asp:BoundField DataField="TI_TIPO" HeaderText="Tipo Cargo" />
<%--                                <asp:BoundField DataField="NOMBRES_COMPLETO" HeaderText="Nombres" />--%>
<%--                                <asp:BoundField DataField="CI" HeaderText="CI" />--%>
                                <asp:BoundField DataField="CARGO" HeaderText="Cargo" />
                                <asp:BoundField DataField="eo_descripcion" HeaderText="Unidad Organizacional" />
                                <asp:BoundField DataField="TOTAL_GANADO"  HeaderText="Total Ganado"  DataFormatString="{0:N2}"   />
                                <asp:TemplateField HeaderText="Ajustar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnCheck" CommandName="AjustarDPercepcion" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn bg-gradient-inst text-white btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-check'></i></span>" data-toggle="tooltip" data-placement="top"   runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                            <asp:Label Text="" ID="lblTotalDoblePercepcion" CssClass="h3 text-right text-red" runat="server"  DataFormatString="{0:N2}" />
                        </div>
                    </div>
                </div>
            </div>
                <div class="row" runat="server" id="DivAjuste" visible="false">
                <div class="card-wrapper col-12">
                    <div class="card card-profile">                    
                        <div class=" ct-page-title">
                        <h3 class="mb-0 text-org2">Ajuste de Doble Percepción</h3>
                        <div class="card-body pt-0">
                        <asp:GridView  ID="gvAjusteDoblePercepcion" OnRowDataBound="gvAjusteDoblePercepcion_RowDataBound" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="per_id, ca_id, total_ganado, cbh_id"  OnPreRender="GvLista_PreRender"    runat="server">
                            <Columns>
<%--                                <asp:BoundField DataField="PLANTA_CONTRATO" HeaderText="" />--%>
                                <asp:BoundField DataField="TI_TIPO" HeaderText="Tipo Cargo" />
<%--                                <asp:BoundField DataField="NOMBRES_COMPLETO" HeaderText="Nombres" />--%>
<%--                                <asp:BoundField DataField="CI" HeaderText="CI" />--%>
                                <asp:BoundField DataField="CARGO" HeaderText="Cargo" />
                                <asp:BoundField DataField="eo_descripcion" HeaderText="Unidad Organizacional" />
                                <asp:BoundField DataField="TOTAL_GANADO" HeaderText="Total Ganado"  DataFormatString="{0:N2}"  />
                                <asp:BoundField DataField="CBH_ID" HeaderText="cbh_id"   />

<%--                                <asp:TemplateField HeaderText="Ajustar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:LinkButton CommandName="AjustarDPercepcion" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn bg-gradient-inst text-white btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-check'></i></span>" data-toggle="tooltip" data-placement="top" title="Nuevo Registro"  runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                            <br />
                            <asp:Label Text="" ID="lblConceptoAjuste" CssClass="h4 text-right text-green" runat="server" Visible="false" />
                            
                            <asp:Label Text="" ID="lblAjusteDoblePercepcion" CssClass="h3 text-right text-green" runat="server"  />
                    </div> 
                            <asp:HiddenField ID="hdf_ti_tipo"  runat="server"/>
                            <asp:HiddenField ID="hdf_cbh_id"  runat="server"/>
                            <asp:HiddenField ID="hdf_horas"  runat="server"/>
                            <asp:HiddenField ID="hdf_ganado"  runat="server"/>
                            <asp:HiddenField ID="hdf_esc_por"  runat="server"/>
                            <asp:HiddenField ID="hdf_esc"  runat="server"/>
                            <asp:HiddenField ID="hdf_bono_a"  runat="server"/>
                            <asp:HiddenField ID="hdf_bono_f"  runat="server"/>
                        </div>
                    </div>
                </div>
                </div>
                                    
                <div class="form-group text-center">
                                        <asp:LinkButton ID="btnAplicarAjusteDPercepcion" OnClick="btnAplicarAjusteDPercepcion_Click" Text="<i class='fas fa-check mr-2'></i>Aplicar"  CssClass="btn btn-success"   runat="server" />
                                        <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                </div>


<%--                                        <div class="text-right ml-auto" >
                                            <asp:Button  ID="btnProceso3_1"  Text="Ejecutar" OnClick="btnProceso3_1_Click" runat="server"  CssClass="btn btn-secondary  btn-round btn-icon"  />
                                        </div>--%>
                                </div>

                                <div  runat="server" id="divSanciones"  visible="false" class="timeline-block">
                                    <span class="timeline-step badge-info">4</span>
                                    <div class="timeline-content d-flex align-items-center">
                                        <p class="text-sm mb-0">Sanciones</p>
                                        <div class="text-right ml-auto" >
                                            <asp:Button  ID="btnSanciones" Text="Ejecutar" OnClick="btnSanciones_Click" runat="server"  CssClass="btn btn-secondary  btn-round btn-icon"  />
                                        </div>
                                    </div>
                                </div>

                                <div  runat="server" id="divProceso4"  visible="false" class="timeline-block">
                                    <span class="timeline-step badge-info">5</span>
                                    <div class="timeline-content d-flex align-items-center">
                                        <p class="text-sm mb-0">Descuentos de Ley</p>
                                        <div class="text-right ml-auto" >
                                            <asp:Button  ID="btnProceso4" Text="Ejecutar" OnClick="btnProceso3_Click" runat="server"  CssClass="btn btn-secondary  btn-round btn-icon"  />
                                        </div>
                                    </div>
                                </div>
                                <div  runat="server" id="divProceso5"  visible="false" class="timeline-block">
                                    <span class="timeline-step badge-info">6</span>
                                    <div class="timeline-content d-flex align-items-center">
                                        <p class="text-sm mb-0">Otros Descuentos</p>
                                        <div class="text-right ml-auto" >
                                            <asp:Button  ID="btnProceso5" Text="Ejecutar" OnClick="btnProceso4_Click" runat="server"  CssClass="btn btn-secondary  btn-round btn-icon"  />
                                        </div>
                                    </div>
                                </div>
                                
                                <asp:LinkButton ID="btnAjustar" CssClass="btn btn-vimeo btn-block" Text="<i class='fas fa-check'></i> Finalizar"  OnClick="btnAjustar_Click" visible="false"  runat="server" />

                                <div  runat="server" id="divProceso6"  visible="false" class="timeline-block">
                                    <span class="timeline-step badge-info">7</span>
                                    <div class="timeline-content d-flex align-items-center">
                                        <p class="text-sm mb-0">Generar Planillas</p>
                                        <div class="text-right ml-auto" >
                                            <asp:Button  ID="btnProceso6" Text="Ejecutar" OnClick="btnProceso5_Click" runat="server"  CssClass="btn btn-secondary  btn-round btn-icon"  />
                                        </div>
                                    </div>
                                </div>
                                <div  runat="server" id="divProceso7"  visible="false" class="timeline-block">
                                    <span class="timeline-step badge-info">8</span>
                                    <div class="timeline-content d-flex align-items-center">
                                        <p class="text-sm mb-0">Habilitar funcionarios planilla programas.</p>
                                        <div class="text-right ml-auto" >
                                            <asp:Button  ID="btnProceso7" Text="Ejecutar" OnClick="btnProceso6_Click" runat="server"  CssClass="btn btn-secondary  btn-round btn-icon"  />
                                        </div>
                                    </div>
                                </div>
<%--                                <div class="timeline-block">
                                    <span class="timeline-step badge-info">8</span>
                                    <div class="timeline-content d-flex align-items-center">
                                        <p class="text-sm mb-0">Procesar planilla programas.</p>
                                        <div class="text-right ml-auto" >
                                            <asp:LinkButton ID="LinkButton8" CssClass="btn btn-secondary  btn-round btn-icon" data-toggle="tooltip" data-original-title="Ejecutar Paso 8" Text="<span class='btn-inner--icon'><i class='fas fa-cogs'></i></span><span class='btn-inner--text'>Ejecutar</span>" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="timeline-block">
                                    <span class="timeline-step badge-info">9</span>
                                    <div class="timeline-content d-flex align-items-center">
                                        <p class="text-sm mb-0">Asignar códigos de procesos planilla desconcentradas y programas.</p>
                                        <div class="text-right ml-auto" >
                                            <asp:LinkButton ID="LinkButton9" CssClass="btn btn-secondary  btn-round btn-icon" data-toggle="tooltip" data-original-title="Ejecutar Paso 9" Text="<span class='btn-inner--icon'><i class='fas fa-cogs'></i></span><span class='btn-inner--text'>Ejecutar</span>" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="timeline-block">
                                    <span class="timeline-step badge-info">10</span>
                                    <div class="timeline-content d-flex align-items-center">
                                        <p class="text-sm mb-0">Procesar descuentos IVA.</p>
                                        <div class="text-right ml-auto" >
                                            <asp:LinkButton ID="LinkButton10" CssClass="btn btn-secondary  btn-round btn-icon" data-toggle="tooltip" data-original-title="Ejecutar Paso 10" Text="<span class='btn-inner--icon'><i class='fas fa-cogs'></i></span><span class='btn-inner--text'>Ejecutar</span>" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="timeline-block">
                                    <span class="timeline-step badge-info">11</span>
                                    <div class="timeline-content d-flex align-items-center">
                                        <p class="text-sm mb-0">Importar sanciones.</p>
                                        <div class="text-right ml-auto" >
                                            <asp:LinkButton ID="LinkButton11" CssClass="btn btn-secondary  btn-round btn-icon" data-toggle="tooltip" data-original-title="Ejecutar Paso 11" Text="<span class='btn-inner--icon'><i class='fas fa-cogs'></i></span><span class='btn-inner--text'>Ejecutar</span>" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="timeline-block">
                                    <span class="timeline-step badge-info">12</span>
                                    <div class="timeline-content d-flex align-items-center">
                                        <p class="text-sm mb-0">Fin proceso de planillas</p>
                                        <div class="text-right ml-auto" >
                                            <asp:LinkButton ID="LinkButton12" CssClass="btn btn-secondary  btn-round btn-icon" data-toggle="tooltip" data-original-title="Ejecutar Paso 12" Text="<span class='btn-inner--icon'><i class='fas fa-cogs'></i></span><span class='btn-inner--text'>Ejecutar</span>" runat="server" />
                                        </div>
                                    </div>
                                </div>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="ConfirmacionProceso" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="glosaTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header border-bottom">
                    <div class="ct-page-title">
                        <h5  class="modal-title">Proceso de Planillas Completado</h5>
                        <p class="text-sm mb-0">Está seguro de finalizar el proceso de planillas y proseguir a la generación de Líquidos Pagables? Una vez confirmado este paso, no será posible volver a procesar.</p>
                    </div>
                </div>
                <div class="row">
                        <div class="col-4 ml-7">
                            <asp:LinkButton ID="btnVerificarCi" CssClass="btn btn-success" Text="<i class='fas fa-check'></i> Confirmar"  OnClick="btnVerificarCi_Click"  runat="server" />
                        </div>
                        <div class="col-4">
                            <asp:LinkButton ID="btnCancelarVerificacionCI" CssClass="btn btn-google-plus" Text="<i class='fas fa-times'></i> Cancelar"  OnClick="btnCancelarVerificacionCI_Click" runat="server" />
                        </div>
                </div>
            </div>
        </div>
    </div>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnProceso1" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnProceso2" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnProceso3" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnProceso4" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>    
    <asp:UpdateProgress AssociatedUpdatePanelID="UpdateProcesoSueldo" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress></asp:Content>

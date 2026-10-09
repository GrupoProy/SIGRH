<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="Asistencia.aspx.cs" Inherits="Salarios_Asistencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Generar Asistencia</h6>
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
                        <div class="ct-page-title">
                            <h3 class="mb-0">Datos a procesar</h3>
                            <p class="text-sm mb-0">Ingrese los datos solicitados para procesar la asistencia</p>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="Up_form" runat="server">
                        <ContentTemplate>
                            <div class="card-body">
                                <div class="row">
                            <!-- Tipo Funcionario -->

                                    <div class="form-group col-md-3">
                                        <label class="form-control-label" for="ddl_tipo_func">Tipo de Funcionario:</label>
                                        <asp:DropDownList ID="ddl_tipo_func" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_tipo_func" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                                    </div>  
                                    
                            <!-- Gestion -->

                                    <div class="form-group col-md-3">
                                        <label class="form-control-label" for="ddl_gestion">Gestion</label>
                                        <asp:DropDownList ID="ddl_gestion" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_gestion" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                                    </div>

                            <!-- Mes -->

                                    <div class="form-group col-md-3">
                                        <label class="form-control-label" for="ddl_mes">Mes</label>
                                        <asp:DropDownList ID="ddl_mes" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_mes" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-check">
                                        <asp:RadioButton ID="rdPla" GroupName="radios" CssClass="swal2-radio" Text="Personal por Planilla" runat="server" />
                                    </div>
                                    <div class="form-group col-md-3">
                                        <label class="form-control-label" for="ddl_planilla"></label>
                                        <asp:DropDownList ID="ddl_planilla" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_planilla" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                                    </div>
                                </div>
                                <div class="row">
                                    <!-- fecha inicio -->
                                    <div class="form-group col-md-4">
                                        <label class="form-control-label" for="txtFechaInicio">Fecha Inicio:</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-calendar-alt"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="txtFechaInicio" CssClass="form-control datepickerD" runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtFechaInicio" ValidationGroup="add" Display="Dynamic" runat="server" />
                                    </div>

                                    <!-- Fecha fin -->

                                    <div class="form-group col-md-4">
                                        <label class="form-control-label" for="txtFechaFin">Fecha Fin:</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-calendar-alt"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="txtFechaFin" CssClass="form-control datepickerD" runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtFechaFin" ValidationGroup="add" Display="Dynamic" runat="server" />
                                    </div>
                                </div>

                                <!-- Por fechas -->

                                <div class="row">
                                    <div class="form-check">
                                        <asp:RadioButton GroupName="radios" Text="Personal de acuerdo a rango de fechas" runat="server" />
                                    </div>
                                </div>
                                <br />

                                <!-- Codigos -->

                                <div class="row">
                                    <div class="form-group col-md-12">
                                        <label class="form-control-label">Ingrese los codigos a ser agregados:</label>
                                        <small class="small"> Separados por comas (,)</small>
                                        <div class="input-group input-group-merge">
                                            <textarea class="form-control" id="txtCod" rows="3"></textarea>
                                        </div>
                                    </div>
                                </div>

                                <!-- Boton de Listar -->

                                <div class="row">
                                    <div class="offset-lg-6 col-lg-6">
                                        <asp:LinkButton ID="BtnAgregar" OnClick="BtnAgregar_Click" CssClass="btn btn-success btn-block" Text="<i class='fas fa-plus'></i> Listar Funcionarios" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="BtnAgregar" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
            
             <!-- jornada de trabajo -->

            <div class="col-lg-5">
                <asp:UpdatePanel ID="Up_info" runat="server">
                    <ContentTemplate>

                        <div class="card card-profile text-uppercase"  runat="server" id="DivInfo" Visible="true">
                            <div class="row justify-content-center">
                                <div class="col-lg-3 order-lg-2">
                                    <div class="card-profile-image">
                                        <!-- fp_foto -->
                                        <a href="#">
                                            <asp:Image ID="Img_fp_foto" CssClass="rounded-circle" runat="server" />
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <!-- jornada de trabajo -->
                            <div class="col-4">
                                    <span><strong class="h5">TIPO JORNADA: </strong><h6><asp:Literal ID="ltl_jornada" runat="server"/></h6></span>
                            </div>

                            <div class="card-header text-center border-0 pt-8 pt-md-4 pb-0 pb-md-4">
                                <!-- as_estado -->
                                <asp:Label ID="Lbl_as_estado" CssClass="btn btn-sm btn-info float-right" runat="server" />
                            </div>
                            <div class="card-body pt-0">
                                <h5 class="h3 text-center">
                                    <!-- per_nombres -->
                                    <asp:Literal ID="Lt_per_nombres" runat="server" />
                                </h5>
                                <div class="h5 font-weight-400 text-center">
                                    <!-- per_num_doc -->
                                    <strong class="h5">CI:</strong>
                                    <asp:Literal ID="Lt_per_num_doc" runat="server" />
                                    <!-- per_id -->
                                    <strong class="h5">CÓDIGO:</strong>
                                    <asp:Literal ID="Lt_per_id" runat="server" />
                                    <!-- ca_num_item -->
                                    <strong class="h5">ÍTEM:</strong>
                                    <asp:Literal ID="Lt_ca_num_item" runat="server" />
                                </div>
                                <hr class="my-3" />
                                <h6 class="heading-small text-muted">Escalafón</h6>
                                <div class="row">
                                    <div class="col-lg-4">
                                        <!-- es_descripcion -->
                                        <div class="content-text-label">Cargo</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="Lt_es_descripcion" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <!-- p_descripcion -->
                                        <div class="content-text-label">Puesto</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="Lt_p_descripcion" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <!-- ca_basico_calculado -->
                                        <div class="content-text-label">Haber Básico (Bs)</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="Lt_ca_basico_calculado" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <!-- es_escalafon -->
                                        <div class="content-text-label">Código Escalafón</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="Lt_es_escalafon" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <!-- ns_clase -->
                                        <div class="content-text-label">Clase</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="Lt_ns_clase" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <!-- ns_nivel -->
                                        <div class="content-text-label">Nivel Salarial</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="Lt_ns_nivel" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <hr class="my-3">
                                <h6 class="heading-small text-muted">Información Fecha Asignación</h6>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <!-- as_fecha_inicio -->
                                        <div class="content-text-label">Fecha Alta</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="Lt_as_fecha_inicio" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <!-- as_fecha_fin -->
                                        <div class="content-text-label">Fecha Baja</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="Lt_as_fecha_fin" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <hr class="my-3">
                                <h6 class="heading-small text-muted">Categoría Administrativa</h6>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <!-- eo_descripcion -->
                                        <div class="content-text-label">Ubicación</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="Lt_eo_descripcion" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <!-- eo_prog -->
                                        <div class="content-text-label">Categoría</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="Lt_eo_prog" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <hr class="my-3">
                                <h6 class="heading-small text-muted">Categoría Programática</h6>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <!-- cp_descripcion -->
                                        <div class="content-text-label">Ubicación</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="Lt_cp_descripcion" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <!-- cp_da -->
                                        <div class="content-text-label">Categoría</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="Lt_cp_da" runat="server" />
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
    <asp:Timer ID="Timer" Enabled="false" OnTick="Timer_Tick" runat="server"/>

</asp:Content>


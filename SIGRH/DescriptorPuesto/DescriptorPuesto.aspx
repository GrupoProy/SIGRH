<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="DescriptorPuesto.aspx.cs" Inherits="DescriptorPuesto_DescriptorPuesto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="header pb-6" style="margin-top: -4em; margin-left: 3em; width: 81%">
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Identificación Nueva</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid mt--6">
        <div class="card mb-4">
            <div class="card-header">
                <div class=" ct-page-title">
                    <h1 class="mb-0">POAI</h1>
                </div>
                <div class=" ct-page-title text-center">
                    <h1 class="mb-0"><i class="fa fa-folder-open"></i>DESCRIPTOR DE PUESTO</h1>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-7">
                <div class="card">
                   
                            <div class="card-body">
                                <div class="row">
                                    <!-- Lista de Supervisores -->
                                   
                                    <div class="form-group col-md-12">
                                        <label class="form-control-label">Supervisor</label>
                                         <asp:DropDownList ID="List_Supervisores" AutoPostBack="true" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="List_Supervisores" ValidationGroup="search" InitialValue="0" Display="Dynamic" runat="server" />
                                     </div>

                                    <%--<div class="form-group col-md-12">
                                        <label class="form-control-label">CARACTERISTICAS INDIVIDUALES</label>
                                        <asp:DropDownList ID="List_CaracteristicasI" AutoPostBack="true" CssClass="form-control select2" OnSelectedIndexChanged="" AppendDataBoundItems="true" runat="server" />
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="List_CaracteristicasI" ValidationGroup="search" InitialValue="0" Display="Dynamic" runat="server" />
                                    </div>--%>

                                    <%--<div class="form-group col-md-12">
                                        <label class="form-control-label" >SUPERVISOR</label>
                                        <asp:DropDownList ID="DropDownList2" AutoPostBack="true" CssClass="form-control select2" AppendDataBoundItems="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"   runat="server"/>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="DropDownList2" ValidationGroup="search" InitialValue="0" Display="Dynamic" runat="server" />
                                    </div>

                                    <asp:TextBox ID="sss" CssClass="form-control" TextMode="MultiLine" runat="server" />--%>

                                    <!-- lj_motivo -->
                                    <div class="form-group col-md-12">
                                        <label class="form-control-label" for="Txt_ob_puesto">Objetivo del Puesto</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-edit"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="Txt_descrip_pu_objetivo" Rows="3" CssClass="form-control" TextMode="MultiLine" runat="server" style="text-transform:uppercase;"/>
                                        </div>
                                        <%--<asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_r_interinstitucional" ValidationGroup="add" Display="Dynamic" runat="server" />--%>
                                    </div>
                                    <!-- lj_lugar -->
                                   

                                </div>
                               
                                <div class="row">
                                    
                                </div>

                                <div class="row">
                                    <div class="form-group col-md-12">
                                       
                                        <asp:LinkButton ID="BtnGuardar_poai" CssClass="btn btn-success btn-block" Text="<i class='fas fa-save mr-2'></i> Guardar"  ValidationGroup="add" OnClick="Btn_guardar_descrip_p_Click" runat="server" style="border-bottom: none; box-shadow: none;" />

                                    </div>
                                </div>

                                <div class="row">
                                     <div class="form-group col-md-6">
                                         
                                        <asp:LinkButton ID="Btn_ir_TareasEspecificas" Enabled="false" Visible="false" CssClass="btn btn-primary btn-block"  Text="<i class='fas fa-arrow-right  mr-2'></i> Ver Tareas Especificas" OnClick="Btn_ir_TareasEspecificas_Click" runat="server" />
                                    </div>
                                     <div class="form-group col-md-6">
                                        
                                         <asp:LinkButton ID="Btn_ir_TareasRecurrentes" Enabled="false" Visible="false" CssClass="btn btn-warning btn-block"  Text="<i class='fas fa-arrow-right  mr-2'></i>Ver Tareas Recurrentes" OnClick="Btn_ir_TareasRecurrentes_Click" runat="server" />
                                     </div>
                                    <!--
                                     <div class="form-group col-md-4">
                                         <!--OnClick="Btn_ir_Formacion_Click"
                                          <asp:LinkButton ID="Btn_ir_Formacion" CssClass="btn btn-warning btn-block"  Text="<i class='fas fa-arrow-right  mr-2'></i> Ir a requisitos del puesto" runat="server" />
                                     </div>
                                -->
                              </div>
                                 
                                <div class="row">
                                    <div class="form-group col-md-6">

                                        <asp:LinkButton ID="Btn_ir_imprimirEva" CssClass="btn btn-info btn-block" Text="<i class='fas fa-print'></i> Imprimir Evaluacion" OnClick="Btn_imprimirEva_Click" runat="server" />
                                    </div>
                                </div>


                            </div>

                 
                   
                </div>

            </div>


            <div class="col-lg-5">
               
                    <contenttemplate>
                        <div class="card card-profile text-uppercase">
                            <div class="row justify-content-center">
                                <div class="col-lg-3 order-lg-2">
                                    <div class="card-profile-image">
                                        <!-- fp_foto -->
                                        <asp:Image ID="Img_fp_foto" CssClass="rounded-circle" runat="server" />
                                    </div>
                                </div>
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

                                        <asp:HiddenField ID="h_per_id" runat="server" />

                                        <asp:HiddenField ID="h_poai_id2" runat="server" />

                                        <asp:HiddenField ID="h_ca_id" runat="server" />
                                        <asp:HiddenField ID="h_pref_text" runat="server" />
                                        <asp:HiddenField ID="h_nombreC_text" runat="server" />
                                        <asp:HiddenField ID="h_numP_int" runat="server" />
                                        <asp:HiddenField ID="h_opai_id" runat="server" />
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
                                    <div class="col-lg-12">
                                        <!-- eo_descripcion -->
                                        <div class="content-text-label">Ubicación</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="Lt_eo_descripcion" runat="server" />
                                        </div>
                                    </div>

                                </div>

                            </div>
                        </div>
                    </contenttemplate>
               
            </div>

        </div>
        
                                    
    </div>
</asp:Content>


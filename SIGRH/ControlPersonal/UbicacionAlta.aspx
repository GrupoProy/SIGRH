<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="UbicacionAlta.aspx.cs" Inherits="ControlPersonal_Ubicacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Header -->
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Administración de Ubicación</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page content -->
    <div class="container-fluid mt--6">
        <div class="row">
            <div class="col-lg-7">
                <div class="card">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Datos para el registro de la Ubicación</h3>
                            <p class="text-sm mb-0"></p>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="Up_frm_u" runat="server">
                        <ContentTemplate>
                            <div class="card-body">
                                <div class="row">
                                    <!-- uf_edificio -->
                                    <div class="form-group col-md-6">
                                        <label class="form-control-label" for="Ddl_uf_edificio">Edificio</label>
                                        <asp:DropDownList ID="Ddl_uf_edificio" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_uf_edificio" ValidationGroup="alta_u" InitialValue="0" Display="Dynamic" runat="server" />
                                    </div>
                                    <!-- uf_bloque -->
                                    <div class="form-group col-md-6">
                                        <label class="form-control-label" for="Txt_uf_bloque">Número o Nombre del Bloque</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-edit"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="Txt_uf_bloque" CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                    <!-- uf_piso -->
                                    <div class="form-group col-md-6">
                                        <label class="form-control-label" for="Txt_uf_piso">Piso</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-edit"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="Txt_uf_piso" CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                    <!-- uf_telefono_oficina -->
                                    <div class="form-group col-md-6">
                                        <label class="form-control-label" for="Txt_uf_telefono_oficina">Número de Teléfono</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-edit"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="Txt_uf_telefono_oficina" CssClass="form-control numero" runat="server" />
                                        </div>
                                    </div>
                                    <!-- uf_telefono_interno -->
                                    <div class="form-group col-md-6">
                                        <label class="form-control-label" for="Txt_uf_telefono_interno">Número Interno</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-edit"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="Txt_uf_telefono_interno" CssClass="form-control numero" runat="server" />
                                        </div>
                                    </div>
                                    <!-- uf_nombre_oficina -->
                                    <div class="form-group col-md-6">
                                        <label class="form-control-label" for="Txt_uf_nombre_oficina">Nombre Oficina</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-edit"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="Txt_uf_nombre_oficina" CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                    <!-- uf_fecha_inicio -->
                                    <div class="form-group col-md-6">
                                        <label class="form-control-label" for="Txt_uf_fecha_inicio">Fecha Asignación</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-calendar-alt"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="Txt_uf_fecha_inicio" CssClass="form-control datepickerDefault" runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_uf_fecha_inicio" ValidationGroup="alta_u" Display="Dynamic" runat="server" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="offset-lg-6 col-lg-6">
                                        <asp:LinkButton ID="BtnGuardar" CssClass="btn btn-success btn-block" Text="<i class='fas fa-save mr-2'></i> Guardar" ValidationGroup="alta_u" OnClick="BtnGuardar_Click" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:UpdatePanel ID="Up_lt_u" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="P_lt_u" CssClass="card" Visible="false" runat="server">
                            <div class="card-header">
                                <div class="ct-page-title">
                                    <h3 class="mb-0">Historial de Registros</h3>
                                    <p class="text-sm mb-0"></p>
                                </div>
                            </div>
                            <div class="card-body">
                                <asp:GridView ID="Gv_lt_u" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="uf_id" OnPreRender="Gv_lt_u_PreRender" runat="server">
                                    <Columns>
                                        <asp:BoundField HeaderText="Edificio" DataField="cat_descripcion" />
                                        <asp:BoundField HeaderText="Fecha Asignación" DataField="uf_fecha_inicio" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField HeaderText="Estado" DataField="uf_estado" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-lg-5">
                <asp:UpdatePanel ID="Up_inf" runat="server">
                    <ContentTemplate>
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
                                <div id="diAcreedor" style="display: none;">
                                    <hr class="my-3" />
                                    <div style="background-color: #D2EEE0; border-radius: .375rem; padding: 0px 17px;">
                                        <h6 class="heading-small text-muted">Beneficiario</h6>
                                        <div class="row">
                                            <asp:HiddenField ID="Hf_acr_id" runat="server" />
                                            <asp:HiddenField ID="Hf_acr_tipo_entidad" runat="server" />
                                            <div class="col-lg-3">
                                                <!-- acr_tipo_entidad -->
                                                <div class="content-text-label">Tipo Entidad</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_acr_tipo_entidad" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <!-- acr_descripcion -->
                                                <div class="content-text-label">Descripción</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_acr_descripcion" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <!-- acr_documento -->
                                                <div class="content-text-label">Documento</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_acr_documento" runat="server" />
                                                </div>
                                            </div>
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

    <asp:UpdateProgress AssociatedUpdatePanelID="Up_frm_u" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_lt_u" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_inf" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

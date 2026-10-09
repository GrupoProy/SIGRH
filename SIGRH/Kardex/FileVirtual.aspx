<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="FileVirtual.aspx.cs" Inherits="Kardex_FileVirtual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">File Virtual</h6>
                    </div>
                    <div class="col-lg-6 col-5 text-right">
                        <asp:LinkButton ID="btnEliminar" OnClick="btnEliminar_Click"  CssClass="btn btn-circle sticky-top-btn2 icon-prs icon-shape-prs bg-gradient-orange text-white rounded-circle shadow" Text="<i class='fas fa-trash'></i>" data-toggle="tooltip" data-original-title="Eliminar Documento" runat="server" />
                        <asp:LinkButton ID="btn_nuevo" OnClick="btn_nuevo_Click" CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-inst text-white rounded-circle shadow" Text="<i class='fas fa-plus'></i>" data-toggle="tooltip" data-original-title="Adicionar Foto" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class="container-fluid mt--6">
        <div class="row">
           <div class="form-group col-md-11 ml-3">
              <label class="form-control-label" for="ddlCategoria">Categoría:</label>
              <asp:DropDownList ID="ddlCategoria" AutoPostBack="true"  OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
           </div>
         </div>
    </div>
<%--    <div class="container-fluid mt--6">
        <div class="row">
            <div class="col-4">
               <asp:LinkButton id="btnIncorporacion"  OnClick="btnIncorporacion_Click"  CssClass="btn bg-gradient-close text-white" runat="server" Text="<i class='fas fa-address-card mr-2'> Requisitos Mínimos de Incorporación</i>"  />
            </div>
            <div class="col-3">
               <asp:LinkButton id="btnLicencias" OnClick="btnLicencias_Click" CssClass="btn btn-block bg-gradient-close text-white" runat="server" Text="<i class='fas fa-address-card mr-2'> Licencias y Vacaciones</i>"  />
            </div>
            <div  class="col-5">
               <asp:LinkButton id="btnSeleccion" OnClick="btnSeleccion_Click" CssClass="btn btn-block bg-gradient-close text-white" runat="server" Text="<i class='fas fa-address-card mr-2'> Documentos del Proceso de Selección/Solicitud de  Incorporación</i>"  />
            </div>

        </div>
        <div class="row mt-1">
            <div class="col-4">
               <asp:LinkButton id="btnCertificados" OnClick="btnCertificados_Click" CssClass="btn btn-block bg-gradient-close text-white" runat="server" Text="<i class='fas fa-address-card mr-2'> Certificados de DJBR, CAS, Reliquidaciones y Finiquitos</i>"  />
            </div>
            <div class="col-4">
               <asp:LinkButton id="btnHistoria"  OnClick="btnHistoria_Click"  CssClass="btn btn-block bg-gradient-close text-white" runat="server" Text="<i class='fas fa-address-card mr-2'> Historia Laboral en la Entidad</i>"  />
            </div>
            <div class="col-4">
               <asp:LinkButton id="btnEvaluacion" OnClick="btnEvaluacion_Click" CssClass="btn btn-block bg-gradient-close text-white" runat="server" Text="<i class='fas fa-address-card mr-2'> Documentos de Evaluación, Inducción y Capacitación</i>"  />
            </div>
        </div>
    </div>--%>
    <div class="container-fluid mt-2">
        <div class="card">
        <div class="row">
            <div class="card-body col-12">
                <div class="media align-items-center">
                    <div class="media-body">
                                <div class="row mt--3">
                                    <div class="col-lg-2">
                                        <div class="content-text-label">Cód. Funcionario</div>
                                        <div class="h5 font-weight-400 content-text content-text">
                                            <asp:Literal ID="ltl_cod_fun" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="content-text-label">CI</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_num_doc" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <div class="content-text-label">Nombre funcionario</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_nombre_fun" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="content-text-label">Estado civil</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_estado_civil" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="content-text-label">Sexo</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_genero" runat="server" />
                                        </div>
                                    </div>
                                </div>

<%--                                <hr class="my-2 mt--3">--%>
<%--                                <h6 class="heading-small text-muted">Fecha y lugar de nacimiento</h6>--%>
                                <div class="row">
                                    <div class="col-lg-2">
                                        <div class="content-text-label">Fecha de nacimiento</div>
                                        <div class="h5 font-weight-400 content-text content-text">
                                            <asp:Literal ID="ltl_fecha_nac" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="content-text-label">País</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_pais" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="content-text-label">Departamento</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_departamento" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="content-text-label">Provincia</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_provincia" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="content-text-label">Localidad</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_localidad" runat="server" />
                                        </div>
                                    </div>

                                </div>
                    </div>
                </div>

            </div>
        </div>
        <hr class="mt--4" />
        <div class="row mt--2">
            <div class="col-12 mt--9">
                <div class="col-6">
                    <asp:LinkButton id="btnImagenAdelante" OnClick="btnImagenAdelante_Click"  CssClass="btn btn-circle rounded-cricle bg-blue text-white float-right mt-9" runat="server" Text="<i class='fas fa-forward'></i>"  />
                </div>
                <div class="col-6">
                    <asp:LinkButton  ID="btnImagenAtras"  OnClick="btnImagenAtras_Click" CssClass="btn btn-circle rounded-cricle bg-blue text-white float-right mt-9" runat="server" Text="<i class='fas fa-backward'></i>"  />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-12">
                    <asp:LinkButton  ID="btn50"   OnClick="btn50_Click"  CssClass="btn btn-circle rounded-cricle bg-success text-white float-right" runat="server" Text="50%"  />
                    <asp:LinkButton  ID="btn100" OnClick="btn100_Click"  CssClass="btn btn-circle rounded-cricle bg-success text-white float-right" runat="server" Text="100%"  />
            </div>
        </div>
    <asp:UpdatePanel runat="server" ID="FileVirtual">
        <ContentTemplate>
        <div class="row">
                <div class="col-12">        
                        <div class="card-body">
                            <asp:Image ID="imgDocumento"  Width="50%" Height="50%" class="avatar-xll img-center" runat="server" />
                        </div>
                </div>
        </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlCategoria" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="btnEliminar" EventName="CLick" />
        </Triggers>
    </asp:UpdatePanel>            
        </div>
   </div>
        <div class="modal fade" id="guardarCambios" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
            <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                <div class="modal-content bg-gradient-dark6">
                    <div class="modal-header">
                    </div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:HiddenField ID="hf_cb_id" runat="server" />
                            <div class="modal-body">
                                <div class="py-3 text-center">
                                    <i class="ni ni ni-album-2 ni-3x"></i>
                                    <h4 class="heading text-dark mt-4">¿Está seguro de eliminar el documento?</h4>
                                </div>
                            </div>
                            <div class="form-group text-center">
                                <asp:LinkButton ID="btn_guardar_cambios" Text="<i class='fas fa-check mr-2'></i>Si" CssClass="btn btn-success" OnClick="btn_guardar_cambios_Click" OnClientClick="MostrarMascara(true);" runat="server" />
                                <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>No</button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

    <asp:UpdateProgress AssociatedUpdatePanelID="FileVirtual" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>



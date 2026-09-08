<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="InformeActividadesEvaluacion.aspx.cs" Inherits="Evaluacion_InformeActividadesEvaluacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Informe de Actividades</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid mt--6">
        <div class="card mb-4">
            <div class="card-header">
                <div class=" ct-page-title">
                    <h2 class="mb-0">
                        <asp:TextBox ID="txtId" runat="server" Text="262" visible =" false"></asp:TextBox>
                        <asp:Label ID="lblTipoEvaluacion" runat="server" Text=""></asp:Label></h2>
                </div>
                <div class=" ct-page-title text-center ">
                        <h1 class="mb-0"><asp:Label ID="lblPeriodoEvaluado" runat="server" Text=""></asp:Label></h1>
                </div>
            </div>
        </div>
        
        <asp:HiddenField ID="h_poai_id" runat="server" />

        <div class="row py-4">
            <div class="col-lg-12">
                <div class="card mb-4">
                    <div class="card-header">
                        <div class=" ct-page-title text-left">
                                            <asp:UpdatePanel ID="PanelDatosGenerales" runat="server" Visible="false">
                                            <ContentTemplate>
                                                <div class="col-xl-12 col-md-12">
                                                <div class="card card-stats">
                                                    <div class="card-body">
                                                        <div class="row">
                                                            <div class="col">
                                                                <h5 class="card-title text-uppercase text-muted mb-0">Datos Generales de Item a ser Evaluado</h5>
                                                                <span class="h5">&nbsp</span>
                                                            </div>
                                                            <div class="col-auto">
                                                                <div class="icon icon-shape bg-gradient-green text-white rounded-circle shadow">
                                                                    <i class="fas fa-file fa-lg"></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-lg-7">
                                                                <div class="content-text-label">Nombre Completo</div>
                                                                <div class="h5 font-weight-400 content-text content-text">
                                                                    <asp:Literal ID="ltl_nombreCompleto" runat="server" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-lg-2">
                                                                <div class="content-text-label">Ítem</div>
                                                                <div class="h5 font-weight-400 content-text content-text">
                                                                    <asp:Literal ID="ltl_item" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-3">
                                                                <div class="content-text-label">Cargo</div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_cargo" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-7">
                                                                <div class="content-text-label">Puesto</div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_puesto" runat="server" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-lg-6">
                                                                <div class="content-text-label">Unidad Organizacional</div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_ubicacion" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-3">
                                                                <div class="content-text-label"></div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_fecha_inicio" runat="server" Visible="false" />
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-3">
                                                                <div class="content-text-label"></div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_fecha_fin" runat="server" Visible="false"/>
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
                <div class="card mb-4">
                    <div class="card-header">
                        <div class=" ct-page-title text-left">
                                            <asp:Label ID="lblMsgInforme" runat="server" Text=""></asp:Label>
                                            <asp:UpdatePanel ID="PanelPasosInforme" runat="server" Visible="false">
                                            <ContentTemplate>
                                                <div class="col-xl-12 col-md-12">
                                                <div class="card card">
                                                    <div class="card-body">
                                                        <div class="row">
                                                            <div class="col-lg-1">
                                                                <div class="icon icon-shape bg-gradient-info text-white rounded-circle shadow">
                                                                    
                                                                  1
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-11">

                                                                <div class="h5 font-weight content-text content-text">
                                                                    Para fines de evaluación usted debe descargar el modelo de INFORME DE ACTIVIDADES en el enlace.
                                                                    <asp:ImageButton ID="imgDescargarInforme"  OnClick="btnDescargarPdf_Click" runat="server"  ImageUrl="~/Evaluacion/imagenes/form_pdf.png" style="width:35px; height:35px"/>
                                                                    <br /><br />
                                                                </div>
                                                            </div>
                                                        </div>
                                                         <div class="row">
                                                            <div class="col-lg-1">
                                                                <div class="icon icon-shape bg-gradient-info text-white rounded-circle shadow">
                                                                  2
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-11">

                                                                <div class="h5 font-weight content-text content-text">
                                                                    Una vez haya descargado el modelo de informe de actividades, llene la informacion faltante como ser : Medio de Verificacion y Observaciones (si corresponde). Adicionalmente anexe al informe de actividades, y la documentación de respaldo si corresponde.
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-lg-1">
                                                                <div class="icon icon-shape bg-gradient-info text-white rounded-circle shadow">
                                                                  3
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-11">

                                                                <div class="h5 font-weight content-text content-text">
                                                                   Una vez tenga listo el Informe de Actividades con sus anexos correspondientes, proceda a 

                                                                </div>
                                                                <asp:LinkButton ID="btnAbrirPdf" OnClick="btnAbrirPdf_Click" CommandName="GetArchivo" CssClass="btn btn-info btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-file fa-lg'></i>&nbsp;Cargar o Subir el archivo PDF</span>" runat="server" />
                                                                
                                                                <asp:LinkButton ID="VerInforme" OnClick="VerInforme_Click" CssClass="btn btn-success btn-sm" Text="<span class='btn-inner--icon'>< Ver Informe de Actividades Cargado ></span>" runat="server" />

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

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div id="myModal3" class="modal fade" tabindex="-1" role="dialog">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title">Subir Informe de Actividades formato (PDF)</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body">
                                        <div id="textoHaypdf" class="row" visible="false" runat="server">
                                            <div class="col-sm-4 mt--4 center">
                                                <asp:Literal Text="YA EXISTE UN ARCHIVO CARGADO" runat="server" />
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-4 center">
                                                &nbsp;
                                            </div>
                                        </div>
                                        <div class="row">
                                            <asp:FileUpload ID="pdfUpload" accept=".pdf" runat="server" />
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <div class="row">
                                            <asp:Button ID="btnSubirPdf" runat="server" Text="Subir" OnClick="btnSubirPdf_Click" CssClass="btn btn-primary" />
                                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnSubirPdf" />
                    </Triggers>
                </asp:UpdatePanel>
<div class="modal fade" id="vwrpdf" tabindex="-1" role="dialog" aria-labelledby="modal-notification" aria-hidden="true" data-backdrop="static">
    <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document" style="max-width: 90%; width: auto;">
        <div class="modal-content bg-gradient-dark6">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="modal-body">
                        <iframe id="ID_pdfFrame" style="width: 100%; height: 500px;" type="application/pdf" runat="server" title="PDF Viewer"></iframe>
                    </div>
                    <div class="form-group text-center">
                        <button type="button" onclick="btn_cerrar_click();" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>cerrar</button>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</div>


        <div class="modal fade" id="vwrpdf2" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document" style="max-width: 90%; width: auto;">
                <div class="modal-content bg-gradient-dark6">
                    <asp:UpdatePanel runat="server">
                        <contenttemplate>
                            <div class="modal-body">
                                <h2 class="mb-0">No Tiene PDf Cargado</h2>
                            </div>
                            <div class="form-group text-center">
                                <button type="button" onclick="btn_cerrar_click" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>cerrar</button>
                            </div>
                        </contenttemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
         <div id="ModalPdf" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="glosaTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="modal-body p-0">
                            <div class="card bg-secondary border-0 mb-0">
                                <div class="card-header">
                                    <div class="text-muted text-center mt-2 mb-3">INFORME DE RESPALDO
                                         <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                          <span aria-hidden="true">&times;</span>
                                        </button>
                                         <asp:Label ID="lblIdPdf" runat="server" Text="" class="form-control-label"></asp:Label>

                                    </div>
    
                                </div>
                                <div class="card-body px-lg-11 py-lg-11">
                                    <div class="row">
                                        <div class="form-group col-md-11">

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

<script>
    function reloadPage() {
        window.location.reload();
    }
    type = "text/javascript" >
        function ShowModal() {
            $('#myModal').modal('show');
            return false;  // Este regreso falso evita el postback
        }
</script>

            </div>
        </div>
    </div>

</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="Seguimiento_evaluacion_desempenio.aspx.cs" Inherits="Evaluacion_Seguimiento_evaluacion_desempenio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="css/StyleSheet.css" rel="stylesheet" />

   <!-- Agrega esto a tu encabezado HTML -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/2.10.2/umd/popper.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/3.7.0/chart.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/chartjs-plugin-datalabels"></script>


    <div class="header bg-secondary pb-2">
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-3">
                   
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-8  pl-0 pr-0 pt-0" data-select2-id="9">
                <div class="card mb-4 ">
                    <!-- Card header -->
                    <div class="card-header">
                        <div class=" ct-page-title">
                            <div class="badge badge-success">
							<h3 class="mb-0">SEGUIMIENTO AL <asp:Label ID="lblEvaluacion" runat="server" Text=""></asp:Label></h3>
						    </div>
                            <p class="text-sm mb-0">
                               Unidades Organizacionales Habilitadas 
                            </p>
                        </div>
                    </div>

                    <div class="card-body   pl-0 pr-0 pt-0">

                    <asp:UpdatePanel ID="PanelUnidades" runat="server" EnableViewState="true">
                        <ContentTemplate> 
        
                            <asp:GridView ID="GvListaUnidades"   AutoGenerateColumns="false" runat="server" CssClass="table table-bordered table-hover table-striped" OnPreRender="GvListaUnidades_PreRender" OnRowCommand="GvListaUnidades_RowCommand" data-html="true" DataKeyNames="eva_pr_id,eva_periodo,eo_id, eo_descripcion,casos,casos_habilitado"  EmptyDataText="No existen unidades activas para evaluacion"   AllowSorting="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:LinkButton CommandName="Ver" CssClass="table-action" data-toggle='tooltip' data-original-title='Ver Unidad' CommandArgument="<%# Container.DataItemIndex %>" runat="server">
                                                <img src="imagenes/abrirDetalle.jpg" alt="Evaluar" style="width: 25px; height: 25px;" />
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="pl-0 pr-0 pt-0 pb-0" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="eo_descripcion" HeaderStyle-CssClass="text-center" HeaderText="UNIDAD ORGANIZACIONAL" ItemStyle-CssClass="text-left"   ItemStyle-Width="50%"  ItemStyle-Font-Size="8pt" ItemStyle-VerticalAlign="Middle"/>
                                    <asp:BoundField DataField="casos" HeaderStyle-CssClass="text-center" HeaderText="CASOS" ItemStyle-CssClass="text-center"  ItemStyle-Width="5%" />
                                    
                                    <asp:TemplateField HeaderText="Estado" ItemStyle-Width="10%" HeaderStyle-CssClass="text-center" >
                                        <ItemTemplate>
                                            <div class='<%# Eval("EstadoCssClass") %>' style="font-size: 12px;">
                                                <%# Eval("estado_evaluacion") %>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Progreso" ItemStyle-Width="15%">
                                          <ItemTemplate>
                                              <%# Eval("TarjetaInfo") %>
                                          </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <div class="col-lg-4">
                <div class="card-wrapper">
                    <div class="card">
                        <div class="card-header d-flex align-items-center">
                            <div class="d-flex align-items-center ct-page-title">
                                <div class="text-dark font-weight-600 text-sm">
                                    
                                    ESTADO DE LA EVALUACION                                 </div>
                            </div>
                        </div>
                        
<asp:UpdatePanel ID="PanelFactoresEvaluacion" runat="server">
    <ContentTemplate>
                          <asp:GridView ID="GridView1"   AutoGenerateColumns="false" runat="server" CssClass="table table-bordered table-hover table-striped" OnPreRender="GvListaUnidades_PreRender" OnRowCommand="GvListaUnidades_RowCommand" data-html="true" EmptyDataText="No existen unidades activas para evaluacion"   AllowSorting="false">
                                <Columns>
                                     <asp:TemplateField HeaderText="CASOS SIN INICIAR"  HeaderStyle-CssClass="text-center"  ItemStyle-Width="100%">
                                          <ItemTemplate>
                                              <%# Eval("TarjetaInfoT1") %>
                                          </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:GridView ID="GridView2"   AutoGenerateColumns="false" runat="server" CssClass="table table-bordered table-hover table-striped" OnPreRender="GvListaUnidades_PreRender" OnRowCommand="GvListaUnidades_RowCommand" data-html="true" EmptyDataText="No existen unidades activas para evaluacion"   AllowSorting="false">
                                <Columns>
                                     <asp:TemplateField HeaderText="CASOS EN PROCESO"  HeaderStyle-CssClass="text-center" ItemStyle-Width="100%">
                                          <ItemTemplate>
                                              <%# Eval("TarjetaInfoT2") %>
                                          </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:GridView ID="GridView3"   AutoGenerateColumns="false" runat="server" CssClass="table table-bordered table-hover table-striped" OnPreRender="GvListaUnidades_PreRender" OnRowCommand="GvListaUnidades_RowCommand" data-html="true" EmptyDataText="No existen unidades activas para evaluacion"   AllowSorting="false">
                                <Columns>                                    
                                    <asp:TemplateField HeaderText="CASOS FINALIZADOS"  HeaderStyle-CssClass="text-center" ItemStyle-Width="100%">
                                          <ItemTemplate>
                                              <%# Eval("TarjetaInfoT3") %>
                                          </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <div class="badge badge-secondary" >
                                 
                                     <asp:LinkButton ID="lnkCerrarEvaluacion" runat="server" ForeColor="Blue" OnClick="CerrarEvaluacion_OnClick">
                                     <img src="imagenes/cerrarEvaluacion.jpg" alt="Cerrar Evaluacion activa" style="width: 30px; height: 30px;" />Cerrar Evaluacion</asp:LinkButton>
                            </div>
    </ContentTemplate>
</asp:UpdatePanel>

                     
                    </div>


                </div>
            </div>
        </div>
    </div>
    <div id="ModalCerrarEvaluacion" class="modal fade " tabindex="-1" role="dialog" aria-labelledby="glosaTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="Up_glosa" runat="server">
                    <ContentTemplate>
                        <div class="modal-body p-0">
                            <div class="card bg-secondary border-0 mb-0">
                                <div class="card-header">
                                    <div class="text-muted text-center mt-2 mb-3">CERRAR EVALUACION
                                         <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                          <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
    
                                </div>
                                <div class="card-body px-lg-11 py-lg-11">
                                    <div class="row">
                                        <div class="form-group col-md-11">
                                            <asp:Label  runat="server" Text="ESTA SEGURO(A) QUE DESEA CERRAR TODA LA EVALUACION ACTIVA?"></asp:Label>
                                        </div>
                                    </div>

                                </div>
                                <div class="form-group text-center">
                                    <asp:LinkButton ID="BtnGuardarG" OnClick="CerrarEvaluacionGral_OnClick" CssClass="btn btn-success" Text="<i class='fas fa-save mr-2'></i> ACEPTAR" runat="server" />
                                    <asp:LinkButton ID="BtnCancelarG" CssClass="btn btn-warning" data-dismiss="modal" Text="<i class='fas fa-save mr-2'></i> CANCELAR" runat="server" />

                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
<script>
    /*
    function inicializarGrafico(totalSinIniciar, totalEnProceso, totalFinalizado) {
        // Obtén una referencia al elemento canvas y al contexto
        var ctx = document.getElementById('miGrafico').getContext('2d');

        // Configura los datos para el gráfico
        var datos = {
            labels: ['Sin Iniciar', 'En Proceso', 'Finalizado'],
            datasets: [{
                data: [totalSinIniciar, totalEnProceso, totalFinalizado],
                backgroundColor: ['#FF6384', '#36A2EB', '#FFCE56'],
                hoverBackgroundColor: ['#FF6384', '#36A2EB', '#FFCE56']
            }]
        };

        // Configura las opciones del gráfico
        var opciones = {
            responsive: true,
            maintainAspectRatio: false,
            cutoutPercentage: 50, // Ajusta el porcentaje de recorte para convertirlo en un gráfico de anillo
            plugins: {
                datalabels: {
                    color: '#fff', // Color del texto de la etiqueta
                    formatter: (value, context) => {
                        return value; // Muestra el valor en cada segmento del gráfico
                    }
                }
            }
        };

        // Crea el gráfico de anillo con etiquetas de datos
        var miGrafico = new Chart(ctx, {
            type: 'doughnut', // Cambia el tipo de gráfico a doughnut (anillo)
            data: datos,
            options: opciones
        });
    }*/
</script>

</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="HistorialEvaluacionRendimiento.aspx.cs" Inherits="Evaluacion_HistorialEvaluacionRendimiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="css/StyleSheet.css" rel="stylesheet" />
<style>

    .list-unstyled {
        list-style-type: none;
        padding-left: 0;
    }

    .list-unstyled li {
        margin-bottom: 2px;
            font-size: 12px; 
    }

    .img-icon {
        width: 30px;
        height: 35px;
        margin-right: 5px;
    }
</style>
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
            <div class="col-lg-6  pl-2 pr-2 pt-2" data-select2-id="9">
                <div class="card mb-4 ">
                    <!-- Card header -->
                    <div class="card-header">
                        <div class=" ct-page-title">
                            <div class="badge badge-success">
							<h3 class="mb-0">HISTORIAL <asp:Label ID="lblEvaluacion" runat="server" Text=""></asp:Label></h3>
						    </div>
                            
                        </div>
                    </div>

                    <div class="card-body   pl-0 pr-0 pt-0">

                    <asp:UpdatePanel ID="PanelEvaluaciones" runat="server" EnableViewState="true">
                        <ContentTemplate> 
        
                            <asp:GridView ID="GvListaEvaluaciones"   AutoGenerateColumns="false" runat="server" CssClass="table table-bordered table-hover table-striped" OnPreRender="GvListaEvaluaciones_PreRender" OnRowCommand="GvListaEvaluaciones_RowCommand" data-html="true" DataKeyNames="eva_pr_id,eva_periodo,casos,periodo_evaluacion"  EmptyDataText="No existen Evaluaciones Finalizadas"   AllowSorting="false">
                                <Columns>
                                    <asp:BoundField DataField="periodo_evaluacion" HeaderStyle-CssClass="text-center" HeaderText="PERIODO DE EVALUACION" ItemStyle-CssClass="text-left"   ItemStyle-Width="50%"  ItemStyle-Font-Size="12pt" ItemStyle-VerticalAlign="Middle"/>
                                    <asp:BoundField DataField="casos" HeaderStyle-CssClass="text-center" HeaderText="CASOS" ItemStyle-CssClass="text-center"  ItemStyle-Width="5%" />
                                    
                                    <asp:TemplateField HeaderText="" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:LinkButton CommandName="Ver" CssClass="table-action" data-toggle='tooltip' data-original-title='Ver Evaluaciones' CommandArgument="<%# Container.DataItemIndex %>" runat="server">
                                                <img src="imagenes/fineva.png" alt="Evaluar" style="width: 30px; height: 35px;" />
                                            </asp:LinkButton>
                                            <asp:LinkButton CommandName="Informe" CssClass="table-action" data-toggle='tooltip' data-original-title='Ver Informe' CommandArgument="<%# Container.DataItemIndex %>" runat="server">
                                                <img src="imagenes/menu_1.jpg" alt="Evaluar"  style="width: 30px; height: 35px;" />
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="pl-0 pr-0 pt-0 pb-0" />
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="card-wrapper">
                    <div class="card">
                        <div class="card-header d-flex align-items-center">
                            <div class="d-flex align-items-center ct-page-title">
                                <div class="text-dark font-weight-600 text-sm">
                                    
                                    REPORTES   <asp:Label ID="lblEvaluacionReporte" runat="server" Text="" Visible="true"></asp:Label>     </div>
                            </div>
                        </div>
                        
                         <asp:UpdatePanel ID="PanelChart" runat="server">
                         <ContentTemplate>
                            <div class="card">
                            <div class="card-header">
                                <span class="text-dark font-weight-600 text-sm">RESULTADOS</span>
                                    <ul class="list-unstyled">
                                    <li><asp:LinkButton ID="btnInforme1" runat="server" Visible ="false">
                                        <asp:Image src="imagenes/form_pdf.png" ID="Image7" runat="server" class="img-icon"/>INFORME
                                        </asp:LinkButton></li>
                                    <li><asp:LinkButton ID="btnInforme2" runat="server" Visible ="false">
                                        <asp:Image src="imagenes/form_pdf.png" ID="Image8" runat="server" class="img-icon" />RESUMEN
                                        </asp:LinkButton></li>
                                   </ul>
                            </div>
                            <div class="card-body">
                            <span class="text-dark font-weight-600 text-sm">ANEXOS</span>
                            <ul class="list-unstyled">
                                <li>
                                    <asp:LinkButton ID="btnAnexo1" runat="server" Visible ="false">
                                        <asp:Image src="imagenes/form_pdf.png" ID="Image1" runat="server" class="img-icon" />ANEXO 1 (PLANILLAS POR UNIDAD ORGANIZACIONAL)
                                    </asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="btnAnexo2" runat="server" Visible ="false">
                                        <asp:Image src="imagenes/form_pdf.png" ID="Image2" runat="server" class="img-icon" />ANEXO 2 (PLANILLAS DE CALIFICACIÓN POR TIPO DE FORMULARIO)
                                    </asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="btnAnexo3" runat="server" Visible ="false">    
                                        <asp:Image src="imagenes/form_pdf.png" ID="Image3" runat="server" class="img-icon"  />ANEXO 3 (LISTADO DE PERSONAL CON CALIFICACIÓN EXCELENTE)
                                    </asp:LinkButton></li>
                                <li><asp:LinkButton ID="btnAnexo4" runat="server" Visible ="false">
                                        <asp:Image src="imagenes/form_pdf.png" ID="Image4" runat="server" class="img-icon" />ANEXO 4 (LISTADO DE PERSONAL CON CALIFICACIÓN EN OBSERVACIÓN)
                                    </asp:LinkButton></li>
                                <li><asp:LinkButton ID="btnAnexo5" runat="server" Visible ="false">
                                        <asp:Image src="imagenes/form_pdf.png" ID="Image5" runat="server" class="img-icon"  />ANEXO 5 (GRAFICOS)
                                    </asp:LinkButton></li>
                                <li><asp:LinkButton ID="btnAnexo6" runat="server" Visible ="false">
                                        <asp:Image src="imagenes/form_pdf.png" ID="Image6" runat="server" class="img-icon"  />ANEXO 6 (DATOS COMPARATIVOS Y GLOBALES)
                                    </asp:LinkButton></li>
                                </ul>

                            </div>
                         </ContentTemplate>
                         </asp:UpdatePanel>
                     
                    </div>


                </div>
            </div>
        </div>
    </div>

</asp:Content>

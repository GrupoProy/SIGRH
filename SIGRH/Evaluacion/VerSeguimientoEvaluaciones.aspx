<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="VerSeguimientoEvaluaciones.aspx.cs" Inherits="Evaluacion_VerSeguimientoEvaluaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="css/StyleSheet.css" rel="stylesheet" />

   <!-- Agrega esto a tu encabezado HTML -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/2.10.2/umd/popper.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/3.7.0/chart.min.js"></script>

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
            <div class="col-lg-12 pl-0 pr-0 pt-0" data-select2-id="9">
                <div class="card mb-4 ">
                    <!-- Card header -->
                    <div class="card-header">
                        <div class=" ct-page-title">
                           <div class="badge badge-success">
							<h3 class="mb-0">SEGUIMIENTO AL <asp:Label ID="lblEvaluacion" runat="server" Text=""></asp:Label></h3>
						    </div>
                           <asp:ImageButton ID="imgbtnVolver" runat="server" ImageUrl="~/Evaluacion/imagenes/volver.jpg" Width="30px" Height="25px" ToolTip="Volver atras" OnClick="imgbtnVolver_Click" />
                            Volver
                            <h4 class="mb-0">UNIDAD ORGANIZACIONAL:&nbsp;&nbsp;  <<
                                <asp:Label ID="lblUnidadSeleccionada" Text="" class="h4  d-inline-block mb-0" runat="server" /> >> </h4>

                        </div>
                    </div>

                    <div class="card-body   pl-2 pr-2 pt-0">

                    <asp:UpdatePanel ID="PanelUnidades" runat="server" EnableViewState="true">
                        <ContentTemplate> 
                            <asp:GridView ID="GvListaItemsUnidad" OnRowDataBound="GvListaItemsUnidad_RowDataBound"   AutoGenerateColumns="false" runat="server" CssClass="table table-bordered table-hover table-striped" OnPreRender="GvListaItemsUnidad_PreRender" OnRowCommand="GvListaItemsUnidad_RowCommand" data-html="true" DataKeyNames="eva_pr_id, eva_periodo, eo_id, eo_descripcion,eva_id_evaluacion"  EmptyDataText="No existen unidades activas para evaluacion"  AllowPaging="false"  AllowSorting="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="DATOS EVALUADO" ItemStyle-Width="30%">
                                            <ItemTemplate>
                                                <%# Eval("TarjetaInfo") %>
                                            </ItemTemplate>
                                        <ItemStyle CssClass="pl-1 pr-0 pt-0 pb-0" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="EVALUADOR" ItemStyle-Width="30%">
                                            <ItemTemplate>
                                                <%# Eval("TarjetaInfoEV") %>
                                            </ItemTemplate>
                                        <ItemStyle CssClass="pl-1 pr-0 pt-0 pb-0" />
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="Estado" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <div class='<%# Eval("EstadoCssClass") %>' style="font-size: 11px;">
                                                &nbsp;&nbsp;&nbsp; <%# Eval("estado_evaluacion") %> &nbsp;&nbsp;&nbsp;
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Puntaje" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <div class='<%# Eval("EstadoCssClass2") %>' style="font-size: 14px;">
                                                <%# Eval("eva_calificacion") %>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Valoracion" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <div class='<%# Eval("EstadoCssClass2") %>' style="font-size: 12px;">
                                                <%# Eval("eva_valoracion") %>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" ItemStyle-Width="13%">
                                        <ItemTemplate>
                                            <asp:LinkButton CommandName="Formulario" CssClass="table-action" data-toggle='tooltip' data-original-title='Imprimir formulario' CommandArgument="<%# Container.DataItemIndex %>" OnClientClick="document.forms[0].target = '_blank';" runat="server">
                                                    <img src="imagenes/imprimir_1.png" alt="Imprimir" style="width: 30px; height: 30px;"/>
                                            </asp:LinkButton>
                                            <asp:LinkButton ID = "btnHabilitar" CommandName="Habilitar" CssClass="table-action" data-toggle='tooltip' data-original-title='Habilitar evaluacion' CommandArgument="<%# Container.DataItemIndex %>" runat="server">
                                                <!--<img src="imagenes/habilitadoNO.png" alt="Evaluar" style="width: 30px; height: 30px;" />-->
                                            </asp:LinkButton>
                                            <asp:LinkButton ID = "btnFinalizar" CommandName="Finalizar" CssClass="table-action" data-toggle='tooltip' data-original-title='Finalizar evaluacion' CommandArgument="<%# Container.DataItemIndex %>" runat="server">
                                                <!--<img src="imagenes/habilitadoOK.png" alt="Finalizar" style="width: 30px; height:35px;" />-->
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
<div class="modal fade" id="ModalAlerta1" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Habilitación/Deshabilitacion de Evaluacion</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        Se realizaron los cambios satisfactoriamente.
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-success" onclick="redirectToActivar()">Ok</button>

        <!--<button type="button" class="btn btn-success" data-dismiss="modal">Ok</button>-->
      </div>
    </div>
  </div>
</div>
            <!--
            <div class="col-lg-1">
                <div class="card-wrapper">
                    <div class="card">
                        <div class="card-header d-flex align-items-center">
                            <div class="d-flex align-items-center ct-page-title">
                                <div class="text-dark font-weight-600 text-sm">
                                    <p class="text-sm mb-0">Grafico de casos Evaluacion</p>
                                    jkjkljlj
                                </div>
                            </div>
                        </div>
                        
                         <asp:UpdatePanel ID="PanelChart" runat="server">
                         <ContentTemplate>
                            <div class="card">
                            <div class="card-header">
                                    
                            </div>
                            <div class="card-body pl-0 pr-0 pt-0">
                            xxx
 
                            </div>
                         </ContentTemplate>
                         </asp:UpdatePanel>
                     
                    </div>


                </div>
            </div>
            -->
        </div>
    </div>
    <script>
    function redirectToActivar() {
        window.location.href = 'VerSeguimientoEvaluaciones.aspx';
    }
</script>
</asp:Content>


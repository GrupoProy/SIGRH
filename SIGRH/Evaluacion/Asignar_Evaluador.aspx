<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="Asignar_Evaluador.aspx.cs" Inherits="Evaluacion_Asignar_Evaluador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <link href="css/StyleSheet.css" rel="stylesheet" />
   <style>
        .customCellStyle {
            Font-size: 1px;
            color: white;
        }
    .sinMargenIzquierdo {
        margin-left: 0;
    }
        .sinMargen {
        margin: 0;
    }
    </style>
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-5  pl-0 pr-0 pt-0" data-select2-id="9">
                <div class="card mb-4 ">
                    <!-- Card header -->
                    <div class="card-header">
                        <div class=" ct-page-title">
                            <div class="badge badge-info">
							<h3 class="mb-0">ASIGNAR EVALUADOR</h3>
						    </div></br>
                             <div class="badge badge-success">
							<h3 class="mb-0"><asp:Label ID="lblEvaluacion" runat="server" Text=""></asp:Label></h3>
						    </div>
                            
                            <p class="text-sm mb-0">
                               Realice la asignacion de Evaluador por cada Unidad.
                            </p>
                        </div>
                    </div>

                    <div class="card-body   pl-0 pr-0 pt-0">
                    <asp:UpdatePanel ID="PanelHabilitacion" runat="server">
                        <ContentTemplate>                            
                            <div class="card-body pl-0 pr-0 pt-0">
                                
                               <asp:GridView ID="GvListaUnidades"   OnRowDataBound="GvListaUnidades_RowDataBound" AutoGenerateColumns="false"  runat="server" CssClass="table table-bordered table-hover table-responsive text-left" OnPreRender="GvListaUnidades_PreRender" OnRowCommand ="GvListaUnidades_RowCommand"  data-html="true"  DataKeyNames="eva_pr_id, eva_periodo, eo_id,eo_descripcion"  EmptyDataText="No existen unidad para asignar evaluador" AllowSorting="true" AllowPaging="false" PageSize="20">
                               <Columns>
                                    <asp:TemplateField  ItemStyle-Width="2%">
                                        <HeaderTemplate></HeaderTemplate>
                                        <ItemTemplate >
                                            <!--<asp:ImageButton ID="imgAsignar" ImageUrl="~/Evaluacion/imagenes/evaluador_ok.png" runat="server" Style="width: 20px;" ItemStyle-Width="5%"/>-->
                                             <asp:LinkButton ID = "btnEvaluador" CommandName="Asignar" CssClass="table-action" data-toggle='tooltip' data-original-title='Ver Items' CommandArgument="<%# Container.DataItemIndex %>" runat="server">
                                              
                                    </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="pl-1 pr-0 pt-0 pb-0" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Unidad Organizacional" ItemStyle-Width="85%" ItemStyle-HorizontalAlign="Left">
                                         <ItemTemplate>
                                         <%# Eval("TarjetaInfo") %>
                                         </ItemTemplate>
                                         <ItemStyle CssClass="pl-1 pr-0 pt-0 pb-0 sinMargenIzquierdo" />
                                    </asp:TemplateField>         
                                    <asp:BoundField DataField="eo_id" HeaderText="" ItemStyle-CssClass="customCellStyle"  ItemStyle-Width="1%" ItemStyle-Font-Size="1pt"/>
                               </Columns>
                                   <HeaderStyle CssClass="header bg-light"  ForeColor="lightseagreen"/>
                               </asp:GridView>
                            </div>
                
                        </ContentTemplate>
      
                   </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <div class="col-lg-7">
                <div class="card-wrapper">
                    <div class="card">
                        <div class="card-header d-flex align-items-center">
                            <div class="d-flex align-items-center ct-page-title">
                                <div class="text-dark font-weight-600 text-sm">
                                    <p class="text-sm mb-0">Seleccione al Evaluador de acuerdo a su criterio.</p>
                                </div>
                            </div>
                        </div>
                         <asp:UpdatePanel ID="UpdatePanelEvaluador" runat="server">
                         <ContentTemplate>
                            <div class="card">
                         <div class="card-body pl-0 pr-0 pt-0">
                             <h4 class="mb-0">LISTADO DE ITEM'S POR: 
                             <asp:Label id="lblUnidadSeleccionada" runat="server" Text="" ForeColor="lightseagreen"></asp:Label></h4>
                            <asp:GridView ID="GvListaItemsUnidad"  OnRowDataBound="GvListaItemsUnidad_RowDataBound"  AutoGenerateColumns="false"  runat="server" CssClass="table table-bordered table-hover table-responsive text-center" OnPreRender="GvListaItemsUnidad_PreRender" OnRowCommand ="GvListaItemsUnidad_RowCommand"  data-html="true"  DataKeyNames="eva_pr_id, eva_periodo, eo_id,eva_ca_id,nombre_completo,cargo,puesto,nombre_completo_ev,eva_id_evaluacion"  EmptyDataText="No existen unidad para asignar evaluador" AllowPaging="false">
                           <Columns>
                                <asp:TemplateField HeaderText="Datos evaluado" ItemStyle-Width="45%" ItemStyle-HorizontalAlign="Left" >
                                     <ItemTemplate>
                                     <%# Eval("TarjetaInfo") %>
                                      <div style="font-size: 9px; text-align:right"> EVALUACION:
                                              <div class='<%# Eval("EstadoCssClassEvaluado") %> align-items-center' style="font-size: 9px; text-align:right">
                                                     <%# Eval("eva_estado") %>
                                              </div>
                                       </div>
                                     </ItemTemplate>
                                <ItemStyle CssClass="pl-0 pr-0 pt-0 pb-0" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Evaluador" ItemStyle-Width="45%" ItemStyle-HorizontalAlign="Left" >
                                     <ItemTemplate>
                                     <%# Eval("TarjetaInfoEV") %>
                                      <div style="font-size: 10px; text-align:right"> ->
                                          <div class='<%# Eval("EstadoCssClass") %>' style="font-size: 9px;">
                                                 <%# Eval("eva_estado_evaluador") %>
                                          </div>
                                      </div>
                                     </ItemTemplate>

                                <ItemStyle CssClass="pl-0 pr-0 pt-0 pb-0" />
                                </asp:TemplateField>      
                                
                                <asp:TemplateField  ItemStyle-Width="2%">
                                   <HeaderTemplate></HeaderTemplate>
                                   <ItemTemplate >
                                       <asp:LinkButton ID="btnEvaluadorItem" CommandName="Evaluador" CssClass="table-action" data-toggle='tooltip' data-original-title='Cambiar Evaluador' CommandArgument="<%# Container.DataItemIndex %>" runat="server">
                                             
                                       </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="pl-0 pr-0 sinMargenIzquierdo" />
                                </asp:TemplateField>
                                                               
                                <asp:BoundField DataField="eva_id_evaluacion" HeaderText="" ItemStyle-CssClass="customCellStyle"   ItemStyle-Width="1%" ItemStyle-Font-Size="1pt" />
                           </Columns>
                               <HeaderStyle CssClass="header bg-light"  ForeColor="lightseagreen"/>
                           </asp:GridView>

                            </div>
                         </ContentTemplate>
                   
                     </asp:UpdatePanel>

                    </div>


                </div>
            </div>
        </div>
    </div>

    <div id="ModalEvaluador" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="glosaTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="Up_glosa" runat="server">
                    <ContentTemplate>
                        <div class="modal-body p-0">
                            <div class="card bg-secondary border-0 mb-0">
                                <div class="card-header">
                                    <div class="text-muted text-center mt-2 mb-3"><small>ASIGNAR EVALUADOR</small>
                                         <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                          <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
    
                                </div>
                                <div class="card-body px-lg-11 py-lg-11">
                                    <div class="row">
                                        <div class="form-group col-md-11">

                                           <label class="form-control-label"><strong>NOMBRE DEL EVALUADO(A): </strong></label>
                                           <asp:Label ID="lblEvaluado" runat="server" Text="" class="form-control-label"></asp:Label>
                                            <asp:Label ID="lblEvaluadoId" runat="server" Text="" ForeColor="White" Font-Size="1px"></asp:Label>
                                            <asp:Label ID="lblEvaluadoEoId" runat="server" Text="" ForeColor="White" Font-Size="1px"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group col-md-6">
                                            <label class="form-control-label"><strong>CARGO:&nbsp;</strong></label>
                                            <asp:Label ID="lblEvaluadoCargo" runat="server" Text="" class="form-control-label"></asp:Label>
                                        </div>
                                        <div class="form-group col-md-6">
                                            <label class="form-control-label"><strong>PUESTO:&nbsp; </strong></label>
                                            <asp:Label ID="lblEvaluadoPuesto" runat="server" Text="" class="form-control-label"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group col-md-11">
                                            <label class="form-control-label"><strong>EVALUADOR ASIGNADO:&nbsp;  </strong></label>
                                            <asp:Label ID="lblEvaluadoEvaluador" runat="server" Text="" class="form-control-label"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group col-md-11">
                                          <label class="form-control-label">Seleccione un Evaluador</label>
                                          <asp:DropDownList ID="List_Supervisores" AutoPostBack="true" CssClass="form-control select2" runat="server" />

                                        </div>
                                    </div>

                                </div>
                                <div class="form-group text-center">
                                    <asp:LinkButton ID="BtnGuardarG" OnClick="BtnGuardarG_OnClick" CssClass="btn btn-success" Text="<i class='fas fa-save mr-2'></i> Guardar" runat="server" />
                                    <asp:LinkButton ID="BtnCancelarG" CssClass="btn btn-outline-github" data-dismiss="modal" Text="<i class='fas fa-times mr-2'></i> Cancelar" runat="server" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <script>
    function redirectToActivar() {
        window.location.href = 'Administrar_evaluacion_desempenio.aspx';
    }
    </script>

</asp:Content>


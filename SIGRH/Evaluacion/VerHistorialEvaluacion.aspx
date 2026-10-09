<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="VerHistorialEvaluacion.aspx.cs" Inherits="Evaluacion_VerHistorialEvaluacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="css/StyleSheet.css" rel="stylesheet" />


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
							<h3 class="mb-0">DETALLE DE HISTORIAL <asp:Label ID="lblEvaluacion" runat="server" Text=""></asp:Label></h3>
                            <h4 class="mb-0">  <<
                                <asp:Label ID="lblPeriodoEvaluacion" Text="" class="h4  d-inline-block mb-0" runat="server" /> >> </h4>
						    </div>
                            <asp:Image ID="Image1" ImageUrl="imagenes/volver.jpg" Width="30px" Height="25px" runat="server" />
                           <asp:LinkButton ID="imgbtnVolverH" runat="server" ToolTip="Volver atras" OnClick="imgbtnVolverH_OnClick" Text ="Volver"/>
                        </div>
                    </div>

                    <div class="card-body   pl-2 pr-2 pt-0">

                    <asp:UpdatePanel ID="PanelUnidades" runat="server" EnableViewState="true">
                        <ContentTemplate> 
                            <asp:GridView ID="GvListaItemsUnidad" OnRowDataBound="GvListaItemsUnidad_RowDataBound"   AutoGenerateColumns="false" runat="server" CssClass="table table-bordered table-hover table-striped" OnPreRender="GvListaItemsUnidad_PreRender" OnRowCommand="GvListaItemsUnidad_RowCommand" data-html="true" DataKeyNames="eva_pr_id, eva_periodo, eo_id, eo_descripcion,eva_id_evaluacion"  EmptyDataText="No existen unidades activas para evaluacion"  AllowPaging="false"  AllowSorting="false">
                                <Columns>
                                    <asp:BoundField DataField="eo_descripcion" HeaderStyle-CssClass="text-center" HeaderText="UNIDAD ORGANIZACIONAL" ItemStyle-CssClass="text-left"   ItemStyle-Width="20%"  ItemStyle-Font-Size="8pt" ItemStyle-VerticalAlign="Middle"/>

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
                                   
                                    <asp:TemplateField HeaderText="Estado" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <div class='<%# Eval("EstadoCssClass") %>' style="font-size: 10px;">
                                                &nbsp; <%# Eval("estado_evaluacion") %> &nbsp;
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Puntaje" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <div class='<%# Eval("EstadoCssClass2") %>' style="font-size: 12px;">
                                                <%# Eval("eva_calificacion") %>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Valoracion" ItemStyle-Width="8%">
                                        <ItemTemplate>
                                            <div class='<%# Eval("EstadoCssClass2") %>' style="font-size: 12px;">
                                                <%# Eval("eva_valoracion") %>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:LinkButton CommandName="Formulario" CssClass="table-action" data-toggle='tooltip' data-original-title='Imprimir formulario' CommandArgument="<%# Container.DataItemIndex %>" OnClientClick="document.forms[0].target = '_blank';" runat="server">
                                                    <img src="imagenes/imprimir_1.png" alt="Imprimir" style="width: 30px; height: 30px;"/>
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
</div>
        </div>


</asp:Content>


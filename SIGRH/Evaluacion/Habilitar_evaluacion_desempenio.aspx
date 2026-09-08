<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="Habilitar_evaluacion_desempenio.aspx.cs" Inherits="Evaluacion_Habilitar_evaluacion_desempenio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <link href="css/StyleSheet.css" rel="stylesheet" />
   <style>
        .customCellStyle {
            Font-size: 1px;
            color: white;
        }
    </style>
    <%--<asp:ScriptManager ID="ScriptManager" AsyncPostBackTimeout="36000" runat="server"></asp:ScriptManager>--%>
    <%-- colocar AsyncPostBackTimeout="36000" en el scriptmanager de la página maestra --%>
    <div class="header bg-secondary pb-2">
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-3">
                    ACTIVAR PERIODO DE EVALUACION &nbsp;<asp:Label ID="lbltipo" runat="server" Text="" ></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid">
        <asp:UpdatePanel ID="PanelHabilitacion" runat="server">
            <ContentTemplate>
                <div class="card">
                    <div class="card-header">
                        <div class="col-lg-6">
                            <asp:Label ID="Label1" runat="server" Text="Gestión :  "></asp:Label>
                            <asp:TextBox ID="txtGestionHabilitar" runat="server" ReadOnly="true" BorderColor="#3333FF" BorderStyle="Double" BackColor="#CCFFCC" />
                            <asp:Label ID="lblIdGestion" runat="server" Text="Label" Visible="false"></asp:Label>
                        </div>

                    </div>
                    <div class="card-header ">
                        <div class="col-lg-6">
                            <asp:Label ID="Label2" runat="server" Text="Periodo:  "></asp:Label>
                            <asp:TextBox ID="txtPeriodoHabilitar" runat="server" BorderColor="#3333FF" BorderStyle="Double" ReadOnly="true" BackColor="#CCFFCC" />
                            <asp:Label ID="lblIdperiodo" runat="server" Text="Label" Visible="false"></asp:Label>
                        </div>

                    </div>

                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" >
                    <ProgressTemplate>
                        <div id="Background">
                        </div>
                        <div id="Progress">
                            <img src="imagenes/waiting.gif" style="vertical-align:middle"/>
                        </div>
                    </ProgressTemplate>
                    </asp:UpdateProgress>

                    <div class="card-header">
                        <div class="col-lg-4">
                            <asp:Button ID="BtnGenerarHabilitados" CssClass="btn btn-primary btn-lg btn-block" Text="Habilitar periodo" runat="server" OnClick="BtnGenerarHabilitados_Click" Enabled="true" />
                        </div>   
                    </div>   
                    <div class="rowr">
                        <div class="col-lg-3"> 
                               <asp:Button ID="BtnRegistrar" Visible="false" CausesValidation="false"   class="btn btn-success btn-block"  Text="Activar Casos" OnClick="BtnRegistrar_Click"  runat="server" />            
                        </div>
                        <div class="col-lg-5">   
                            <asp:TextBox ID="txtPeriodoHabilitado" runat="server" BorderColor="#3333FF" BorderStyle="Double" ReadOnly="true" BackColor="#CCFFCC" Visible="false"  Style="width: 250px;"></asp:TextBox>
                        </div>
                    </div>
                    
                </div>
                <div class="card-body">
                    <div class =" badge badge-success" style="font-size: 11px;"> 
                        Total casos Cumple:
                        <asp:Label ID="lblTotalCumple" runat="server" Text="."></asp:Label>
                    </div>
                    <div class =" badge badge-danger" style="font-size: 11px;"> 
                        Total Acefalos:
                        <asp:Label ID="lblTotalAcefalos" runat="server" Text="."></asp:Label> 
                    </div>
                    <div class =" badge badge-warning" style="font-size: 11px;"> 
                        Total casos que No cumple:
                        <asp:Label ID="lblTotalNoCumple" runat="server" Text="."></asp:Label>
                    </div>
                    <div class =" badge badge-info" style="font-size: 11px;"> 
                        TOTAL DE CASOS PERSONAL >>>
                        <asp:Label ID="lblTotalCasos" runat="server" Text="."></asp:Label>
                    </div>
                    <!--
                    <button class="btn btn-secondary buttons-excel buttons-html5 btn-primary mr-1" tabindex="0" aria-controls="GvListaHabilitacion" type="button">
                        <span>Excel</span>
                    </button>-->
                   <asp:GridView ID="GvListaHabilitacion"  AutoGenerateColumns="false"  runat="server" CssClass="table table-bordered table-hover table-responsive text-center" OnPreRender="GvListaHabilitacion_PreRender" OnRowCommand ="GvListaHabilitacion_RowCommand"  data-html="true"  DataKeyNames="as_per_id, as_ca_id"  EmptyDataText="No existen funcionarios para ser evaluados" >
                   <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate></HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="ChkHabilitar" runat="server" Checked='<%# Eval("tipo").ToString() == "CUMPLE" %>' Enabled='<%# Eval("tipo").ToString() == "CUMPLE" %>' ItemStyle-Width="4%" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" ItemStyle-Width="7%">
                             <ItemTemplate>
                             <div class='<%# Eval("EstadoCssClass") %>' style="font-size: 11px;">
                                     <%# Eval("tipo") %>
                              </div>
                             </ItemTemplate>
                            <ItemStyle CssClass="pl-1 pr-0 pt-0 pb-0" />
                        </asp:TemplateField>
                                    <asp:BoundField DataField="item" HeaderStyle-CssClass="text-center" HeaderText="Ítem" ItemStyle-CssClass="text-center"  ItemStyle-Width="5%" ItemStyle-Font-Size="10px" ItemStyle-HorizontalAlign="Left"/>
                                    <asp:BoundField DataField="fecha_inicio" HeaderStyle-CssClass="text-center" HeaderText="Fecha Inicio" ItemStyle-Width="5%" ItemStyle-Font-Size="11px"/>
                                    <asp:BoundField DataField="fecha_fin" HeaderStyle-CssClass="text-center" HeaderText="Fecha Fin" ItemStyle-Width="5%" ItemStyle-Font-Size="11px"/>
                                    <asp:BoundField DataField="as_per_id" HeaderStyle-CssClass="text-center" HeaderText="Cod." ItemStyle-Width="3%" ItemStyle-Font-Size="11px"/>
                                    <asp:BoundField DataField="nombre_completo" HeaderStyle-CssClass="text-center" HeaderText="Nombre Completo" ItemStyle-Width="18%" ItemStyle-Font-Size="11px" ItemStyle-HorizontalAlign="Left"/>
                                    
                                   <asp:TemplateField HeaderText="Cargo - Puesto" ItemStyle-Width="28%" ItemStyle-HorizontalAlign="Left" ItemStyle-Font-Size="Smaller">
                                            <ItemTemplate>
                                                <%# Eval("TarjetaInfo") %>
                                            </ItemTemplate>
                                    <ItemStyle CssClass="pl-1 pr-0 pt-0 pb-0" />
                                   </asp:TemplateField>
                                    <asp:BoundField DataField="eo_descripcion" HeaderStyle-CssClass="text-center" HeaderText="Unidad Organizacional"  ItemStyle-Width="30%" ItemStyle-Font-Size="10px" ItemStyle-HorizontalAlign="Left"/>
                                   <asp:BoundField DataField="as_ca_id" HeaderText="" ItemStyle-CssClass="customCellStyle" ItemStyle-Width="1%"  ItemStyle-Font-Size="2px"/>



                   </Columns>
                       <HeaderStyle CssClass="header bg-light"  ForeColor="lightseagreen"/>
                   </asp:GridView>
                </div>
                
            </ContentTemplate>
           
            <Triggers> 
                    <asp:AsyncPostBackTrigger  ControlID="txtGestionHabilitar" EventName=""   />
                    <asp:AsyncPostBackTrigger   ControlID="txtPeriodoHabilitar" EventName="" />
                    <asp:AsyncPostBackTrigger ControlID="BtnGenerarHabilitados" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="BtnRegistrar" EventName="Click" />
            </Triggers>
       </asp:UpdatePanel>
    </div>

<div class="modal fade" id="ModalAlerta1" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Habilitación de Evaluaciones</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        Los ítems fueron habilitados satisfactoriamente.
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-success" onclick="redirectToActivar()">Ok</button>

        <!--<button type="button" class="btn btn-success" data-dismiss="modal">Ok</button>-->
      </div>
    </div>
  </div>
</div>
    <div id="modalProgress" class="modal fade" role="dialog">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title">Procesando...</h4>
            </div>
            <div class="modal-body">
                <div class="progress">
                    <div class="progress-bar progress-bar-striped active" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width:100%">
                        <span class="sr-only">Procesando...</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

    <script>
    function redirectToActivar() {
        window.location.href = 'Administrar_evaluacion_desempenio.aspx';
    }
</script>
    <script src="../../../app-assets/js/scripts/tables/datatables/datatable-advanced.min.js"></script>
</asp:Content>


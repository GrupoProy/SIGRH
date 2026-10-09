<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ListadoEvaluacion.aspx.cs" Inherits="Evaluacion_ListadoEvaluacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="css/StyleSheet.css" rel="stylesheet" />
   <!-- Agrega esto a tu encabezado HTML -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/2.10.2/umd/popper.min.js"></script>

     <div class="container-fluid">
        <div class="row">
                <div class="col-lg-12 " >
                    <div class="header bg-secondary pb-4 pt-2">
                                <div class="row">
                                    <div class="col-lg-3 ">
                                        <span class="h2 text-muted d-inline-block mb-0">EVALUACION DEL DESEMPEÑO</span>
                                        <h1 class="mb-0" style="color:dodgerblue"><asp:Label ID="Labeleva" style="color:dodgerblue" Text="" class="h2  d-inline-block mb-0" runat="server" /></h1>

                                    </div>

                                    <div class="col-lg-4 ">
                                        <span class="h2 text-muted d-inline-block mb-0">Evaluador:   </span>
                                        <asp:Label ID="LblEvaluador" style="color:dodgerblue" Text="" class="h3  d-inline-block mb-0" runat="server" />
                                        <br />
                                        <span class="h2 text-muted d-inline-block mb-0">Puesto:   </span>
                                        <asp:Label ID="LblPuesto"  style="color:dodgerblue" class="h3  d-inline-block mb-0" Text="" runat="server" />
                                        <asp:Label ID="LblUnidad" Text="" runat="server" Visible="false" />
                                        <br /> <span class="h4 text-muted d-inline-block mb-0 right--1">Personal dependiente a evaluar:   </span> <span class="badge bg-info"><asp:Label ID="lblcasosNoFinalizado" Text="" runat="server" style="font-size: 12px;" />/<asp:Label ID="lblcasosFinalizado" Text="" runat="server" style="font-size: 12px;" /></span>

                                    </div>
                                    <div class="col-lg-5">
                                        <div class='<%# Eval("FinalizadoCssClass") %>' role="alert">
                                          <asp:Label ID="lblMsgEvaluacion1" Text="" runat="server"  ></asp:Label>
                                          <asp:Label ID="lblMsgEvaluacion2" Text="" runat="server"  ></asp:Label>
                                        </div>
                                    </div>
                                </div>
                    </div>
                </div>
         </div>
        <div class="row">
            <div id="dResult" class="card">
                <div class="card-body">

                     <div class="table-responsive">
                        <asp:UpdatePanel ID="PanelDependientes" runat="server" EnableViewState="true">
                            <ContentTemplate>
                                <asp:GridView ID="GvLista"  OnRowDataBound="GvListaUnidades_RowDataBound" AutoGenerateColumns="false" runat="server" CssClass="table table-bordered table-hover table-striped" OnPreRender="GvLista_PreRender" OnRowCommand="GvLista_RowCommand" data-html="true" DataKeyNames="per_id, ca_id, ca_id_evaluador, pr_id, id_evaluacion, paterno, materno, nombres, cargo, puesto"  EmptyDataText="No existen funcionarios para ser evaluados" >
                                    <Columns>
                                        <asp:TemplateField HeaderText="Acciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" ItemStyle-Width="10%">
                                            <ItemTemplate>
                                                <asp:LinkButton ID ="btnEvaluar" CommandName ="Evaluar" CssClass="table-action" data-toggle='tooltip' data-original-title='Evaluar' CommandArgument="<%# Container.DataItemIndex %>" runat="server">
                                                    <img src="imagenes/evaluar_3.png" alt="Evaluar" style="width: 30px; height: 35px;" id="paso1"/>
                                                </asp:LinkButton>

                                                <asp:LinkButton ID ="btnImprimir" CommandName="Imprimir" CssClass="table-action" data-toggle='tooltip' data-original-title='Imprimir formulario' CommandArgument="<%# Container.DataItemIndex %>" OnClientClick="document.forms[0].target = '_blank';" runat="server">
                                                        <img src="imagenes/imprimir_1.png" alt="Imprimir" style="width: 30px; height: 35px;"/>
                                                </asp:LinkButton>
                                                <asp:LinkButton ID = "btnFinalizar" CommandName="Finalizar" CssClass="table-action" data-toggle='tooltip' data-original-title='Finalizar evaluacion' CommandArgument="<%# Container.DataItemIndex %>" runat="server">
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="pl-0 pr-0 pt-0 pb-0" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Datos del Evaluado        " ItemStyle-Width="43%">
                                                <ItemTemplate>
                                                    <%# Eval("TarjetaInfo") %>
                                                </ItemTemplate>
                                            <ItemStyle CssClass="pl-0 pr-0 pt-0 pb-0" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="unidad" HeaderStyle-CssClass="text-center" HeaderText="Unidad Organizacional"  ItemStyle-Width="32%"  ItemStyle-HorizontalAlign="Left"/>
                                    
                                        <asp:TemplateField HeaderText="Estado" ItemStyle-Width="10%">
                                            <ItemTemplate>
                                                <div class='<%# Eval("EstadoCssClass") %>' style="font-size: 12px;">
                                                    <%# Eval("ESTADO") %>
                                                </div>
                                                <asp:LinkButton ID = "btnJustificar" CommandName="Justificar" CssClass="table-action" data-toggle='tooltip' data-original-title='Justificar No Evaluar' CommandArgument="<%# Container.DataItemIndex %>" runat="server">
                                                </asp:LinkButton>
                                                <asp:LinkButton ID = "btnFinalizado" CommandName="Finalizado" CssClass="table-action" data-toggle='tooltip' data-original-title='' CommandArgument="<%# Container.DataItemIndex %>" runat="server">
                                                </asp:LinkButton>

                                            </ItemTemplate>
                                            <ItemStyle CssClass="pl-0 pr-0 pt-2 pb-2" />
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

    <div id="ModalAlerta1" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="glosaTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="Up_glosa" runat="server">
                    <ContentTemplate>
                        <div class="modal-body p-0">
                            <div class="card bg-secondary border-0 mb-0">
                                <div class="card-header">
                                    <div class="text-muted text-center mt-2 mb-3">FINALIZAR EVALUACION
                                         <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                          <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
    
                                </div>
                                <div class="card-body px-lg-11 py-lg-11">
                                    <div class="row">
                                        <div class="form-group col-md-11">
                                            <asp:Label ID="lblFinalizarEvaluacion" runat="server" Text=""></asp:Label>
                                            <asp:Label ID="lblEvaluacion" runat="server" Text="" ForeColor="White" Font-Size="1px"></asp:Label>
                                        </div>
                                    </div>

                                </div>
                                <div class="form-group text-center">
                                    <asp:LinkButton ID="BtnGuardarG" OnClick="BtnGuardarG_OnClick" CssClass="btn btn-success" Text="<i class='fas fa-save mr-2'></i> ACEPTAR" runat="server" />
                                    <asp:LinkButton ID="BtnCancelarG" CssClass="btn btn-warning" data-dismiss="modal" Text="<i class='fas fa-save mr-2'></i> CANCELAR" runat="server" />

                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div id="ModalJustificar" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="glosaTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="modal-body p-0">
                            <div class="card bg-secondary border-0 mb-0">
                                <div class="card-header">
                                    <div class="text-muted text-center mt-2 mb-3">JUSTIFICAR LA NO EVALUACION
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
                                          <label class="form-control-label">Seleccione ell motivo</label>
                                          <asp:DropDownList ID="List_Justificaciones" AutoPostBack="true" CssClass="form-control select2" runat="server" >
                                            <asp:ListItem Value="VACACION">VACACION</asp:ListItem>
                                            <asp:ListItem Value="BAJA, RENUNCIA Y/O RETIRO">BAJA, RENUNCIA Y/O RETIRO</asp:ListItem>
                                            <asp:ListItem Value="BAJA MEDICA">BAJA MEDICA</asp:ListItem>
                                            <asp:ListItem Value="MATERNIDAD">MATERNIDAD</asp:ListItem>
                                            <asp:ListItem Value="COMISION SINDICAL">COMISION SINDICAL</asp:ListItem>
                                            <asp:ListItem Value="COMISION">COMISION</asp:ListItem>
                                            <asp:ListItem Value="LICENCIA TEMPORAL">LICENCIA TEMPORAL</asp:ListItem>
                                            <asp:ListItem Value="FALLECIMIENTO">FALLECIMIENTO </asp:ListItem>
                                            <asp:ListItem Value="TRANSFERENCIA">TRANSFERENCIA</asp:ListItem>
                                            <asp:ListItem Value="A DISPOSICION DE RRHH">A DISPOSICION DE RRHH</asp:ListItem>  
                                          </asp:DropDownList> 
                                        </div>
                                    </div>

                                </div>
                                <div class="form-group text-center">
                                    <asp:LinkButton ID="btnGuardarJustificar" OnClick="BtnGuardarJustificacion_OnClick" CssClass="btn btn-success" Text="<i class='fas fa-save mr-2'></i> GUARDAR" runat="server" />
                                    <asp:LinkButton ID="btnCancelar2" CssClass="btn btn-outline-github" data-dismiss="modal" Text="<i class='fas fa-save mr-2'></i> CANCELAR" runat="server" />

                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="Evaluar.aspx.cs" Inherits="DescriptorPuesto_Evaluar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="header pb-6" style="margin-top: -4em; margin-left: 3em; width: 81%">

        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">

                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">LISTA EVALUACIONES</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid mt--6">
        <div class="card mb-4">
            <div class="row">
                <div class="col-lg-6 col-7">
                    <h6 id="Nom" style="color: black;" class="h2 text-light d-inline-block mb-0" runat="server"></h6>
                </div>
            </div>

            <div class="card-header">
                <div class=" ct-page-title">
                    <h2 class="mb-0">TAREAS POR EVALUAR</h2>
                </div>

                <div class=" ct-page-title text-center ">
                    <h1 class="mb-0"><i class="fa fa-folder-open"></i>//</h1>
                </div>
            </div>
            
            <div class="table-responsive py-4">
                <asp:UpdatePanel runat="server">
                    <contenttemplate>
                        <asp:GridView ID="GridView4" CssClass="table table-bordered table-hover table-striped" OnRowCommand="GridView4_RowCommand" DataKeyNames="des_p_result_id" AutoGenerateColumns="false" runat="server">
                            <columns>
                               <%-- <asp:BoundField DataField="result_indicador" HeaderText="Medio de verificacion" />--%>

                                <asp:TemplateField HeaderText="Medio de verificacion">
                                    <ItemTemplate>
                                        <%# String.IsNullOrEmpty(Eval("result_indicador").ToString()) ? "N/C" : Eval("result_indicador") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="result_resultado" HeaderText="Resultado" />
                                <asp:BoundField DataField="result_ponderacion" HeaderText="Ponderacion" />
                               <%-- <asp:TemplateField HeaderText="Calificar">
                                    <ItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                               <%-- <asp:BoundField DataField="descrip_pdf" HeaderText="PDF" />--%>

                                <asp:TemplateField HeaderText="PDF">
                                    <itemtemplate>
                                        <%# Eval("descrip_pdf").ToString() == "System.Byte[]" ? "Existe Archivo PDF" : Eval("descrip_pdf").ToString() == "" ? "N/C" : "" %>
                                    </itemtemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Recurrente/Especifico">
                                    <itemtemplate>
                                        <%# Eval("result_tipo").ToString() == "E" ? "ESPECIFICA" : Eval("result_tipo").ToString() == "R" ? "RECURRENTE" : "" %>
                                    </itemtemplate>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-CssClass="text-center">
                                   <itemtemplate>
                                    <asp:Panel Visible='<%# Eval("descrip_pdf") != DBNull.Value %>' runat="server">
                                  <asp:LinkButton CommandName="getViewPDF" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-primary btn-sm" runat="server" Text="<span class='btn-inner--icon'><i class='fas fa-eye'></i></span>Ver PDF" />
                                   </asp:Panel>
                                   <asp:LinkButton CommandName="Evaluar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-warning btn-sm" data-target="#evaluarModal" Text="<span class='btn-inner--icon'>&#128221;</span>" title="Evaluar" runat="server" />

                                 </itemtemplate>
                                </asp:TemplateField>

                            </columns>
                        </asp:GridView>


                        <asp:HiddenField ID="h_r_id" runat="server" />
                        <asp:HiddenField ID="aux_accion" runat="server" />
                        <asp:HiddenField ID="h_numE" runat="server" />


                    </contenttemplate>
                </asp:UpdatePanel>
            </div>




        </div>







        <%--Modal ver pdf--%>
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

        <div class="modal fade" id="modalEditarResultado" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-body p-0">
                        <div class="card bg-secondary border-0 mb-0">
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <%--Modal Poner Ponderacion--%>
                <div class="modal fade" id="evaluarModal" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
                    <div class="modal-dialog modal-dialog-centered modal-" role="document" style="max-width: 30%; width: auto;">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="evaluarModalLabel">Evaluar</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <label for="inputPonderacion">Ponderacion</label>
                                <asp:TextBox ID="inputPonderacion" runat="server" CssClass="form-control" TextMode="Number" step="0.01"></asp:TextBox>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                                <asp:Button ID="btnAdd_Eva" runat="server" OnClick="btnAdd_Click_Eva" CssClass="btn btn-primary" Text="Calificar"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnAdd_Eva" />
            </Triggers>
        </asp:UpdatePanel>

         <%--<div class="modal fade" id="1evaluarModal" tabindex="-1" role="dialog" aria-labelledby="evaluarModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="evaluarModalLabel">Evaluar</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <label for="inputPonderacion">Ponderacion</label>
                        <asp:TextBox ID="inputPonderacion" runat="server" CssClass="form-control" TextMode="Number" step="0.01"></asp:TextBox>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                        <asp:Button ID="btnAdd_Eva1" runat="server" OnClick="btnAdd_Click_Eva" CssClass="btn btn-primary" Text="Calificar"></asp:Button>
                    </div>

                </div>
            </div>
        </div>--%>







          <%--Grid Tareas Calificadas--%>
    </div>

       <div class="container-fluid mt--6">
        <div class="card mb-4">
            <div class="card-header">
                <div class=" ct-page-title">
                    <h2 class="mb-0">TAREAS EVALUADAS</h2>
                </div>
                <div class=" ct-page-title text-center ">
                    <h1 class="mb-0"><i class="fa fa-folder-open"></i>//</h1>
                </div>
            </div>


                <div class="table-responsive py-4">
                <asp:UpdatePanel runat="server">
                    <contenttemplate>
                        <asp:GridView ID="GridView5" CssClass="table table-bordered table-hover table-striped" OnRowCommand="GridView5_RowCommand" DataKeyNames="evalua_dp_id" AutoGenerateColumns="false" runat="server">
                            <columns>
                                 <asp:BoundField DataField="Resultdo_Ponderacion" HeaderText="Rsultado Poneracion" />
                                <asp:BoundField DataField="Resultdo_Evaluacion" HeaderText="Resultdo Evaluacion" />
                               
                                <asp:BoundField DataField="Resultado" HeaderText="Resultado" />
                              
                               
                                <asp:TemplateField ItemStyle-CssClass="text-center">
                                   <itemtemplate>
                                  

                          <%--         <asp:LinkButton CommandName="EditarEva" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-warning btn-sm"  Text="<span class='btn-inner--icon'><i class='fas fa-edit'></i></span>" title='Editar Resultado Evaluacion' runat="server" />--%>
                                 </itemtemplate>
                                </asp:TemplateField>

                            </columns>
                        </asp:GridView>


                        <asp:HiddenField ID="h_r_id1" runat="server" />
                        <asp:HiddenField ID="aux_accion1" runat="server" />
                        <asp:HiddenField ID="h_numE1" runat="server" />


                    </contenttemplate>
                </asp:UpdatePanel>
            </div>
                
            
                            <%--Modal Editar Resultado Evaluacion--%>
                <div class="modal fade" id="modalEditarResulEva" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
                        <div class="modal-dialog modal- modal-dialog-centered modal-md" role="document">
                            <div class="modal-content">
                                <div class="modal-body p-0">
                                    <div class="card bg-secondary border-0 mb-0">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <div class="card-header">
                                                    <div class="text-muted text-center mt-2 mb-3">
                                                        <h4 class="header-modal">
                                                            <asp:Literal ID="ltl_titulo" runat="server" /></h4>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <div class="card-body px-lg-5 py-lg-5">

                                                   
                                                    <div class="row" >
                                                        <div class="col-sm-4 col-md-2">
                                                            
                                                        </div>


                                                        <div class="col-sm-4 col-md-8">
                                                            <div class="form-group">
                                                                <label class="form-control-label" for="example4cols2Input">Resultado Evaluacion</label>
                                                                <div class="input-group input-group-merge">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                                    </div>
                                                                    <asp:TextBox ID="Eva_PonderacionText" class="form-control" runat="server" />
                                                                </div>
                                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="Eva_PonderacionText" ValidationGroup="factorAdd" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group text-center">
                                                     <asp:Button  runat="server" Text="Actualizar Resultado"   CssClass="btn btn-primary" ValidationGroup="factorAdd" />
                                                    <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                  
                            </div>
                        </div>
                  
                    </div>
            

        </div>



       </div>


    <div class="row">
        <div class="form-group col-md-4">

            
        </div>
        <div class="form-group col-md-4">

            <asp:LinkButton ID="Btn_ir_imprimirEva" Visible="false" CssClass="btn btn-info btn-block" Text="<i class='fas fa-print'></i> Imprimir Evaluacion" OnClick="Btn_imprimirEvalua_Click" runat="server" />
        </div>
    </div>
        
         

</asp:Content>


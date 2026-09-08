<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="RegistrarTareasEspecificas.aspx.cs" Inherits="DescriptorPuesto_RegistrarTareasEspecificas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Administrar Identificación</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid mt--6">
        <div class="card mb-4">
            <div class="card-header">
                <div class=" ct-page-title">
                    <h2 class="mb-0">POAI</h2>
                </div>
                <div class=" ct-page-title text-center ">
                        <h1 class="mb-0"> <i class="fa fa-folder-open"></i>Resultados Especificos</h1>
                </div>
            </div>
        </div>
        
        <asp:HiddenField ID="h_poai_id" runat="server" />
        
        
        <div class="row py-4">
            <div class="col-lg-12">
                <div class="card mb-4">                
                    <div class="card-body">
                        <div class="row py-3">
                            <div class="col-lg-2 pt-4"></div>
                            <div class="col-lg-8 pt-4">
                                <asp:Label ID="Label2" runat="server" Text="Label">Registro Resultados<i class="fa fa-exclamation-circle"></i></asp:Label>
                                <asp:TextBox ID="resultado_input" placeholder="Resultado " CssClass="form-control" runat="server" />
                            </div>
                            <div class="col-lg-2 pt-4"></div>
                        </div>
                        <div class="row py-2">
                            <div class="col-lg-2 pt-4"></div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="indicador_input" placeholder="Indicador " CssClass="form-control" runat="server" />
                            </div>
                            <div class="col-lg-2 pt-4"></div>
                        </div>
                        <div class="row py-2">
                            <div class="col-lg-2 pt-4"></div>
                            <div class="col-lg-8">
                                <asp:TextBox ID="ponderacion_input" type="number" placeholder="Ponderación " CssClass="form-control" runat="server" />
                                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                            </div>
                            <div class="col-lg-2 pt-4"></div>
                        </div>
                        <div class="row py-2">
                            <div class="col-lg-2 pt-4"></div>
                            <div class="col-lg-8 text-center">
                               
                                <asp:LinkButton ID="Btn_guardar_TaEs" Onclick="Btn_guardar_TaEs_Click" CssClass="btn btn-success btn-round btn-icon mt-4" data-toggle="tooltip"  Text="<span class='btn-inner--icon'><i class='fas fa-plus'></i></span><span class='btn-inner--text'>Agregar Resultado</span>"  runat="server" />  
                                
                                <asp:LinkButton  ID="Btn_RedireccionarATareasRecurrentes" OnClick="Btn_RedireccionarATareasRecurrentes_Click" Text="<i class='fas fa-check mr-2'></i>Continuar con las Tareas Recurrentes" CssClass="btn btn-warning btn-round btn-icon mt-4"   runat="server" />

                            </div>
                            <div class="col-lg-2 pt-4"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row py-4">
            <div class="col-lg-12">
                <div class="card mb-4">
                    <div class="card-header">
                        <div class=" ct-page-title text-center">
                            <h1 class="mb-0"><i class="fa fa-folder-open"></i>IDENTIFICACIÓN</h1>
                            <h3 class="mb-0"><i class="fa fa-calculator"></i>Total Acumulado: <asp:Literal id="TotalAcumulado" runat="server"></asp:Literal> / 70</h3>

                        </div>
                    </div>
                    
                    <div class="table-responsive py-4">
                         <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView1" CssClass="table table-bordered table-hover table-striped" OnRowCommand="GridView1_RowCommand" DataKeyNames="des_p_result_id" AutoGenerateColumns="false" runat="server">
                                    <Columns>
                                        <asp:BoundField  DataField="result_resultado" HeaderText="Resultado" />
                                        <asp:BoundField  DataField="result_indicador" HeaderText="Indicador" />
                                        <asp:BoundField  DataField="result_ponderacion" HeaderText="Ponderación" />
                                        <asp:TemplateField HeaderText="Controles" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                            <ItemTemplate>

                                                <asp:LinkButton CommandName="GetEdit" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-warning btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-edit'></i></span>" data-toggle='tooltip' data-placement='top' title='Editar' runat="server" />
                                                <asp:LinkButton CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-google-plus btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Eliminar' runat="server" />
                                             <asp:LinkButton ID="LinkButton1" CommandName="GetArchivo" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-info btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-file fa-lg'></i></span>" runat="server" />



                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:HiddenField ID="h_r_id" runat="server" />
                                <asp:HiddenField ID="aux_accion" runat="server" />
                                <asp:HiddenField ID="h_numE" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    
                </div>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div id="myModal3" class="modal fade" tabindex="-1" role="dialog">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title">Subir PDF</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body">
                                        <div id="textoHaypdf" class="row" visible="false" runat="server">
                                            <div class="col-sm-4 mt--4 center">
                                                <asp:Literal Text="YA EXISTE UN ARCHIVO SUBIDO" runat="server" />
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
                                            <asp:Button ID="SubmitButton" runat="server" Text="Subir" OnClick="SubmitButton_Click" CssClass="btn btn-primary" />
                                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="SubmitButton" />
                    </Triggers>
                </asp:UpdatePanel>


                <%--Modal Eliminar Resultado--%>
                <div class="modal fade" id="eliminarResultado" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                    <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                        <div class="modal-content bg-gradient-dark6">
                            <div class="modal-header">
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="modal-body">
                                        <div class="py-3 text-center">
                                            <i class="ni ni-fat-remove ni-3x"></i>
                                            <h4 class="heading text-dark mt-4">¿Esta seguro de eliminar el resultado?</h4>
                                        </div>
                                    </div>
                                    <div class="form-group text-center">
                                      <asp:LinkButton ID="btnDelete_DPR" OnClick="btnDelete_Click_DPR" Text="<i class='fas fa-check mr-2'></i>Eliminar" CssClass="btn btn-danger" runat="server" />
                                            <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>

                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <%--Modal Editar Resultado--%>
                <div class="modal fade" id="modalEditarResultado" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
                        <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
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
                                                    <div class="row">
                                                        <div class="col-sm-12 col-md-12">
                                                            <div class="form-group">
                                                                <label class="form-control-label" for="example4cols2Input">Descripción Resultado</label>
                                                                <div class="input-group input-group-merge">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                                    </div>
                                                                    <asp:TextBox ID="ResultadoText" class="form-control" runat="server" />
                                                                </div>
                                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="ResultadoText" ValidationGroup="factorAdd" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-12 col-md-12">
                                                            <div class="form-group">
                                                                <label class="form-control-label">Descripción Indicador</label>
                                                                <div class="input-group input-group-merge">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                                    </div>
                                                                    <asp:TextBox ID="IndicadorText" class="form-control" runat="server" />
                                                                </div>
                                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="IndicadorText" ValidationGroup="factorAdd" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row" >
                                                        <div class="col-sm-4 col-md-4">
                                                            <div class="form-group">
                                                                <label class="form-control-label" for="example4cols2Input">Descripción Ponderación</label>
                                                                <div class="input-group input-group-merge">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                                    </div>
                                                                    <asp:TextBox ID="PonderacionText" class="form-control" runat="server" />
                                                                </div>
                                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="PonderacionText" ValidationGroup="factorAdd" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group text-center">
                                                     <asp:Button ID="btnUpdate_DPR" runat="server" Text="Actualizar"  OnClick="btnUpdate_Click_DPR" CssClass="btn btn-primary" ValidationGroup="factorAdd" />
                                                    <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

<div id="myModal2" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="myModalLabel">Error</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="reloadPage()">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                La actualización falló. La suma total de ponderaciones excede 30.
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal" onclick="reloadPage()">Cerrar</button>
            </div>
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


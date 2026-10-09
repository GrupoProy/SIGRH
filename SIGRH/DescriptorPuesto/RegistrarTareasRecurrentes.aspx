<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="RegistrarTareasRecurrentes.aspx.cs" Inherits="DescriptorPuesto_RegistrarTareasRecurrentes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 

        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Administrar Tareas Recurrentes</h6>
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
                        <h1 class="mb-0"> <i class="fa fa-folder-open"></i>Tareas Recurrentes</h1>
                </div>
            </div>
        </div>
        
        <asp:HiddenField ID="h_poai_id" runat="server" />
        <asp:HiddenField ID="h_per_id" runat="server" />
        
        
        <div class="row py-2">
            <div class="col-lg-12 align-content-center" >
                <div class="card mb-4">                
                    <div class="card-body">
                        <div class="row py-4">
                          
                            <div class="col-lg-2">

                            </div>
                            <div class="col-lg-8 pt-2 text-center" >
                                <asp:Label ID="Label2" runat="server" Text="Label">Registro Resultados<i class="fa fa-exclamation-circle"></i></asp:Label>
                               
                            </div>
                            
                           
                        </div>
                        <div class="row py-1">
                             <div class="col-lg-2">

                            </div>
                            <div class="col-lg-8 pt-2">
                                 <asp:TextBox ID="resultado_input" placeholder="Medio de Verificacion" CssClass="form-control" runat="server" />

                            </div>
                        </div>
                        <div class="row py-2">
                            <div class="col-lg-2">

                            </div>
                            <div class="col-lg-8">
                                 <asp:TextBox ID="ponderacion_input" type="number" placeholder="Ponderación" CssClass="form-control" runat="server" />
                                  <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                            </div>

                            <div class="col-lg-12 text-center">
                                <asp:LinkButton ID="Btn_guardar_TaRE" Onclick="Btn_guardar_TaRE_Click"  CssClass="btn btn-success btn-round btn-icon mt-4" data-toggle="tooltip"  Text="<span class='btn-inner--icon'><i class='fas fa-plus'></i></span><span class='btn-inner--text'>Agregar Resultado</span>"  runat="server" />        
                              <%--  <asp:LinkButton  Text="<i class='fas fa-arrow-right mr-2'></i>Continuar con la Formación" CssClass="btn btn-warning btn-round btn-icon mt-4"  runat="server" />--%>
                                <asp:CheckBox ID="checkRegistroExitoso" runat="server" Text="Registro exitoso" Visible="false" />
                            </div>
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
                            <div class=" row">
                                <div class="col-7" align="right" >
                                    <h1 class="mb-0"><i class="fa fa-folder-open"></i>LISTA TAREAS RECURRENTES</h1>
                                    <h3 class="mb-0"><i class="fa fa-calculator"></i>Total Acumulado: <asp:Literal id="TotalAcumulado" runat="server"></asp:Literal> /  <asp:Literal ID="result_nese" runat="server"> </asp:Literal> </h3> 
                                </div>
                                <div class="col-md-5 my-2" align="right" >
                                    <asp:Label ID="ValidacionPoai"  runat="server" />
                                </div>
                            </div>
                            

                        </div>
                    </div>
                    
                    <div class="table-responsive py-4">
                       <asp:UpdatePanel runat="server">
    <ContentTemplate>
        <asp:GridView ID="GridView2" CssClass="table table-bordered table-hover table-striped" OnRowCommand="GridView2_RowCommand" DataKeyNames="des_p_result_id" AutoGenerateColumns="false" runat="server">
            <Columns>
                <asp:BoundField DataField="result_resultado" HeaderText="Resultado" />
                <asp:BoundField DataField="result_ponderacion" HeaderText="Ponderación" />
                <asp:TemplateField HeaderText="Controles" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                    <ItemTemplate>
                        <asp:LinkButton CommandName="GetEdit" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-warning btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-edit'></i></span>" data-toggle='tooltip' data-placement='top' title='Editar' runat="server" />
                        <asp:LinkButton CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-google-plus btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Eliminar' runat="server" />
                       
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
                                        <asp:LinkButton  ID="btnDelete_DPRR" OnClick="btnDelete_Click_DPRR"  Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" runat="server" />
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
                                                        <div>

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
                                                    <asp:LinkButton ID="btnUpdate" OnClick="btnUpdate_Click_DPER" Text="<i class='fas fa-check mr-2'></i>Guardar" ValidationGroup="factorAdd" CssClass="btn btn-success" runat="server" />
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
    </div>

</asp:Content>


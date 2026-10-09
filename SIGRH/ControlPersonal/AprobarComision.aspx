<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="AprobarComision.aspx.cs" Inherits="ControlPersonal_AprobarComision" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Header -->
   <%-- <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css">--%>

    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Aprobar Comisiones</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page content -->
   
   <div class="container-fluid mt--6">
        <div class="card">
            <div class="card-header">
                <div class="ct-page-title">
                    <h3 class="mb-0">Aprobar Comision</h3>
                    <p class="text-sm mb-0">En el siguiente formulario puede Aprobar Comisiones correspondiente a los parámetros ingresados.</p>
                </div>
            </div>
            <ContentTemplate>
                <div class="row">
                     <div class="form-group col-md-4">

                     </div>

                    <div class="form-group col-md-4">
                      <label class="form-control-label" >Codigo Boleta Comision</label>
                       <div class="input-group input-group-merge">
                             <div class="input-group-prepend">
                                 <span class="input-group-text">
                                      <i class="fas fa-edit"></i>
                                 </span>
                            </div>
                        <asp:TextBox  ID="codigoComisionInput" CssClass="form-control" TextMode="Number" runat="server" OnTextChanged="codigoComisionInput_TextChanged" />
                     </div>
                  </div>                 

                </div>
                <div class="row">
                    <div class="form-group col-md-4">

                     </div>
                    <div class="form-group col-md-3">
                          
                    </div>
                    <div class="form-group col-md-3">
                          
                    </div>

                </div>
                 <div class="row">
                    <div class="form-group col-md-3">

                     </div>
                    <div class="form-group col-md-3">
                      

                    </div>

                </div>
                <div class="row">
                    <div class="form-group col-md-5">
                      

                    </div>
                    
                     <div class="form-group col-md-2">
                        <asp:LinkButton ID="BtnMismoFuncionamiento" CssClass="btn btn-success" OnClick="BtnMismoFuncionamiento_Click" runat="server">
                             <i class='fas fa-check'></i> Aprobar Comision
                         </asp:LinkButton>
                        </div>
                        <!-- Modal -->
                    
                        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-hidden="true">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                     <div class="modal-body text-center" id="modalText" style="padding: 20px;">
                                    </div>
                                </div>
                            </div>
                        </div>


                     </div>
                  

                </div>

               
          </ContentTemplate>
       <script>
           function showModalAndClearInput(comisionCode) {
               $('#modalText').html('<h4><i class="fas fa-check-circle text-success"></i> Comisión Nro ' + comisionCode + ' aprobada con exito</h4>');
               $('#myModal').modal('show');
               setTimeout(function () { $('#myModal').modal('hide'); }, 2000);
           }
       </script>


            
   </div>
   


    
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ResultadosEspecificos.aspx.cs" Inherits="Evaluacion_ResultadosEspecificos" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="css/StyleSheet.css" rel="stylesheet" />
   <!-- Agrega esto a tu encabezado HTML -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/2.10.2/umd/popper.min.js"></script>
    <style>
        .tooltip-inner {
            background-color: #d5e1d8;
            font-size: 7.5pt;
            padding: 8px;
            text-align: left;
            max-width: 350px; /* Ajusta el tamaño máximo según tus preferencias */
                }

    </style>
<!--<nav class="navbar navbar-collapse-sm sticky-top  bg-gradient-lighter"  style="padding:0em">-->
<nav class="nav nav-pills flex-column flex-sm-row">
    <div class="container-fluid">
        <div class="navbar-header">
                <!-- Star Ver Datos Evaluado-->    
            <div class="box box-warning box-solid" id="myNavbar" role="navigation" >
                <div class="box-header with-border" >
                    <asp:Image ID="imgEvaluado" runat="server" style="width: 1.2cm; height: 1.2cm;" class="rounded-circle"/>
                     <span class="tag-label" style="font-size:8pt">EVALUADO(A) <span class="tag-label-content">
                     <asp:Literal ID="ltlEvaluado" Text="" runat="server" /></span></span>
                       &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <span class="tag-label" style="font-size:8pt">PUESTO EVALUADO<span class="tag-label-content">
                       <asp:Literal ID="ltlPuestoEvaluado" Text="" runat="server" /></span></span>
                       <asp:ImageButton ID="imgVerInforme" visible="false" runat="server" OnClick="VerInforme_Click" ImageUrl="imagenes/form_pdf.png" style="width: 30px; height: 35px;" ToolTip="Ver Informe de actividades" />

                </div>
            </div>
            <!-- End Ver Datos Evaluado-->
           <div class="row"  >
                <div  class="col-lg-2" >
                    <asp:ImageButton ID="imgListado" runat="server" ImageUrl="imagenes/usuarios.png"  OnClick="imgListado_Click" Width="1.2cm" Height="1.1cm"/>
                    <h6>Ver Evaluados</h6>
                </div>
               <div  class="col-lg-7" >
                   <div class="shadow p-3 mb-5 bg-body rounded">
                   <span class="border border-primary border-5">
                        <a href="ResultadosEspecificos.aspx"><asp:Label ID="lblResultados" runat="server" Text=""></asp:Label></a> 
                   </span>
                   <span class="border border-white border-3">
                        <asp:linkbutton runat="server" OnClick="Verificar_ResultadosEspecificos"><asp:Label ID="lblFactores" runat="server" Text=""></asp:Label></asp:linkbutton>
                   </span>
                   <span class="border border-white border-3">
                       <asp:linkbutton runat="server" OnClick="Verificar_ResultadosEspecificos"><asp:Label ID="lblPreguntas" runat="server" Text=""></asp:Label></asp:linkbutton>
                       
                   </span>
                   </div>
              </div>
               <div  class="col-lg-3" >
                   <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="imagenes/abrirDetalle.jpg"  OnClick="Verificar_ResultadosEspecificos" Width="1.2cm" Height="1.2cm"/>
               </div>
           </div>
        </div>                                           
    </div>
    <!--
    <div class="container-fluid">
        <div class="navbar-header">
          <button type="button" class="navbar-toggler" data-toggle="collapse" data-target="#myNavbar">
              <asp:Image ImageUrl="imagenes/flecha_abajo.png" runat="server" Width="40px" />
          </button>
              <span id="titulo" class="h2 text-muted d-inline-block mb-0">Resultados Específicos</span>
              <asp:Button Text="Siguiente" runat="server" class="btn btn-success"  OnClick="Verificar_ResultadosEspecificos" />
              <!--<asp:Button Text="Siguiente" runat="server" class="btn btn-success"  style="right:10em;position:fixed;top:42.2em" OnClick="Verificar_ResultadosEspecificos" />

        </div>-->
    
        <div id="Tool" class="col-7 p-0" >
            <div  class="row"  style="margin-top:-1.2em">
              <span id="ToolTip1" style="font-size:0.7em;margin-top:0.7em;margin-left:-3em;margin-bottom:0.2em"></span>
            </div>
            <div class="row" style="margin-top:-0.4em">
              <span id="ToolTip2" style="font-size:0.7em;margin-left:-3em;margin-bottom:0.2em"></span>
            </div>
            <div class="row"  style="margin-top:-0.4em">
              <span id="ToolTip3" style="font-size:0.7em;margin-left:-3em"></span>
            </div>
        </div>

<!-- ******************-->    
</nav>
    
    <div class="container-fluid">
        <div class="row"  >
           <div  class="col-lg-9" >
            </div>
                <%  
                    System.Data.DataSet DS = Solution_Framework_Evaluacion.BussinessLogicLayer.cls_ResultadosEspecificos.Bind_ResultadosEspecificos_Clasificacion();
                    %> 

        <div class="col-lg-1 ml--1">
            <h5 class="text-muted d-inline-block mb-0 text-indigo"><% Response.Write(DS.Tables[0].Rows[0][1].ToString()); %></h5>
        </div>
        <div class="col-lg-1 ml--3">
            <h5 class="text-muted d-inline-block mb-0 text-pink"><% Response.Write(DS.Tables[0].Rows[1][1].ToString()); %></h5>
        </div>
        <div class="col-lg-1 ml-3">
            <h5 class="text-muted d-inline-block mb-0 text-green"><% Response.Write(DS.Tables[0].Rows[2][1].ToString()); %></h5>
        </div> 
        </div>
        <asp:UpdatePanel ID="PanelResultadosEspecificos" runat="server">
            <ContentTemplate>
                <asp:Repeater ID="ResultadosEspecificos" OnItemDataBound="ResultadosEspecificos_ItemDataBound" runat="server">            
                        <ItemTemplate >
                        <div class="row">
                            <div  class="col-lg-9 mb--1" >
                                <div class="card  mb-1">
                                    <h5 class="ml-1" style="position:absolute"><strong><%# DataBinder.Eval(Container.DataItem, "Nro") %></strong></h5>

                                    <div class=" ct-page-title border-success" style="border-radius:5px">
                                        <p class="text-sm mb-0">
                                            <!--
                                        <asp:ImageButton ID="imgVerPdf" runat="server" OnClick="VerPdf_Click" ImageUrl="imagenes/form_pdf.png" style="width: 28px; height: 30px;" CommandArgument ='<%# Eval("res_id") %>'  />
                                            -->
                                            <%# DataBinder.Eval(Container.DataItem, "res_descripcion") %> 

                                            <asp:Label Visible="true" CssClass="id" ID="lblRes_Id" Text='<%# DataBinder.Eval(Container.DataItem, "res_id") %>' runat="server"  Font-Size="5px" style="font-size: smaller; color: white;"/>
                                        </p>
                            
                                    </div>
                                 </div>
                            </div>     
                            <div  class="col-lg-1 mb--0">
                                <div class="card p-1" id="calidad">
                                    <asp:DropDownList ID="ddlResCalidad"  runat="server" Width="40"  CssClass="ResultadosCalidad"        data-toggle="tooltip" data-html="true" data-placement="top" title="<div style='color: indigo;'>CALIDAD<br> <strong><u>A:</u></strong> El trabajo reúne las características predefinidas y no tiene errores.<br> <strong><u>B:</u></strong> El trabajo requiere una revisión de forma y tiene algunos errores.<br><strong><u>C:</u></strong> El trabajo ha sido rechazado por errores de fondo y forma. <br></div>">
                                    </asp:DropDownList>
                                </div>
                             </div>
                            <div  class="col-lg-1 mb--0">
                                <div class="card p-1" id="oportunidad">
                                    <asp:DropDownList ID="ddlResOportunidad" runat="server" Width="40" CssClass="ResultadosOportunidad" data-toggle="tooltip" data-html="true" data-placement="top" title="<div style='color:deeppink; max-width: 370px;'>OPORTUNIDAD<br> <strong><u>A:</u></strong> El resultado ha sido alcanzado en el tiempo y fechas previstas.<br> <strong><u>B:</u></strong> El resultado ha sido logrado con demora derivando en perjuicios para el desarrollo de las actividades.<br><strong><u>C:</u></strong> El resultado no ha sido alcanzado en el tiempo ni en las fechas previstas. <br></div>">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div  class="col-lg-1 mb--0">
                                <div class="card p-1" id="eficiencia">
                                    <asp:DropDownList ID="ddlResEficiencia"  runat="server" Width="40"  CssClass="ResultadosEficiencia" data-toggle="tooltip" data-html="true" data-placement="top" title="<div style='color: green'>EFICIENCIA<br> <strong><u>A:</u></strong> El resultado ha demandado el uso de los recursos previstos.<br> <strong><u>B:</u></strong> El resultado ha demandado más de los recursos previstos.<br><strong><u>C:</u></strong> El resultado ha sido costoso debido a la aplicación injustificada de recursos. <br></div>">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>            
                        </ItemTemplate>
                </asp:Repeater>
            </ContentTemplate>
       </asp:UpdatePanel>

    </div>
                 <asp:UpdateProgress ID="UpdateProgress1" runat="server" >
                    <ProgressTemplate>
                    <div id="Background"></div>
                    <div id="Progress">
                        <img src="imagenes/waiting.gif" style="vertical-align:middle"/>
                    </div>
                    </ProgressTemplate>
                    </asp:UpdateProgress>
<div class="modal fade" id="ModalAlerta1" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">COMPLETAR DE MANERA OBLIGATORIA:</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        Debe registrar la evaluacion de cada <strong>Resultado/Tarea Específico(a)</strong> antes de pasar a la siguiente instancia:
        <div class="col-lg-12">
            <h5 class="text-muted d-inline-block mb-0 text-indigo">* <% Response.Write(DS.Tables[0].Rows[0][1].ToString()); %>: (A, B, C)</h5>
        </div>
        <div class="col-lg-12">
            <h5 class="text-muted d-inline-block mb-0 text-pink">* <% Response.Write(DS.Tables[0].Rows[1][1].ToString()); %>: (A, B, C)</h5>
        </div>
        <div class="col-lg-12">
            <h5 class="text-muted d-inline-block mb-0 text-green">* <% Response.Write(DS.Tables[0].Rows[2][1].ToString()); %>: (A, B, C)</h5>
        </div> 
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-success" data-dismiss="modal">Ok</button>
      </div>
    </div>
  </div>
</div>
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
         <div id="ModalPdf" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="glosaTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="modal-body p-0">
                            <div class="card bg-secondary border-0 mb-0">
                                <div class="card-header">
                                    <div class="text-muted text-center mt-2 mb-3">INFORME DE RESPALDO
                                         <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                          <span aria-hidden="true">&times;</span>
                                        </button>
                                         <asp:Label ID="lblIdPdf" runat="server" Text="" class="form-control-label"></asp:Label>

                                    </div>
    
                                </div>
                                <div class="card-body px-lg-11 py-lg-11">
                                    <div class="row">
                                        <div class="form-group col-md-11">

                                        </div>
                                    </div>



                                </div>

                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
      
     <script>
         $(document).ready(function () {

             $(".ResultadosCalidad, .ResultadosOportunidad, .ResultadosEficiencia").change(function () {
                 switch ($(this).find("option:selected").text()) {
                     case "A":
                         $(this).css("background-color", "LightGreen");
                         break;
                     case "B":
                         $(this).css("background-color", "LemonChiffon");
                         break;
                     case "C":
                         $(this).css("background-color", "LightCoral");
                         break;
                 }
                 var index = $(this).attr("id");
                 index = index.substring(index.length - 2, index.length);
                 if (index.includes("_")) {
                     index = index.substring(index.length - 1, index.length);
                 }
                 var res_id = $("#ContentPlaceHolder1_ResultadosEspecificos_lblRes_Id_" + index).text();
                 PageMethods.Registrar($(this).find("option:selected").val(), $(this).attr("id"), res_id, onSuccess, onFailure);
                 $(this).find("option[value=-1]").remove();
             });

             function onSuccess(result) {
                 return true;
             }

             function onFailure(result) {
                 alert("No se pudo registrar, verifique su conexión de red!");
             }
         });
     </script>

</asp:Content>


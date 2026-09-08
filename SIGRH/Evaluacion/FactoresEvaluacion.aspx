<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="FactoresEvaluacion.aspx.cs" Inherits="Evaluacion_FactoresEvaluacion"  Debug="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!--<nav class="navbar navbar-collapse-sm sticky-top  bg-gradient-lighter"  style="padding:0em">-->
<nav class="nav nav-pills flex-column flex-sm-row">
<div class="container-fluid">
    <div class="navbar-header">
                <!-- Star Ver Datos Evaluado-->    
            <div class="box box-warning box-solid" id="myNavbar" role="navigation" >
                <div class="box-header with-border" >
                    <asp:Image ID="imgEvaluado" runat="server" style="width: 1.2cm; height: 1.2cm;" class="rounded-circle"/>
                     <span class="tag-label" style="font-size:8pt">EVALUADO(A)<span class="tag-label-content">
                     <asp:Literal ID="ltlEvaluado" Text="" runat="server" /></span></span>
                       &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <span class="tag-label" style="font-size:8pt">PUESTO EVALUADO<span class="tag-label-content">
                       <asp:Literal ID="ltlPuestoEvaluado" Text="" runat="server" /></span></span>
                </div>
            </div>
            <!-- End Ver Datos Evaluado-->
           <div class="row"  >
                <div  class="col-lg-2" >
                    <asp:ImageButton ID="imgListado" runat="server" ImageUrl="imagenes/menu_1.jpg"  OnClick="imgListado_Click" Width="1.2cm" Height="1cm"/>
                    <h6>Ver Evaluados</h6>
                </div>
               <div  class="col-lg-7" >
                   <div class="shadow p-3 mb-5 bg-body rounded">

                   <span class="border border-white border-3">
                   <a href="ResultadosEspecificos.aspx"><asp:Label ID="lblResultados" runat="server" Text=""></asp:Label></a> 

                   </span>
                   <span class="border border-primary border-10">
                   <a href="#"><asp:Label ID="lblFactores" runat="server" Text=""></asp:Label></a>
                   </span>
                   <span class="border border-white border-3">
                   <asp:linkbutton runat="server" OnClick="Verificar_FactoresEvaluacion"><asp:Label ID="lblPreguntas" runat="server" Text=""></asp:Label></asp:linkbutton>
                   </span>
                       </div>
               </div>
               <div  class="col-lg-3" >
                   <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="imagenes/abrirDetalle.jpg"  OnClick="Verificar_FactoresEvaluacion" Width="1.2cm" Height="1.2cm"/>
               </div>
        </div>
        <!--            <asp:Button Text="Siguiente" runat="server" class="btn btn-success"  style="right:24em;position:fixed;top:1.2em" OnClick="Verificar_FactoresEvaluacion" />
-->
        </div>
</div>
    <div class="col-7 p-0" >
        <div class="row"  style="margin-top:-0.7em">
          <span id="ToolTip1" style="font-size:0.65em;margin-top:0.7em;margin-left:-3em;margin-bottom:0.2em"></span>
        </div>
        <div class="row" style="margin-top:-0.35em">
          <span id="ToolTip2" style="font-size:0.65em;margin-left:-3em;margin-bottom:0.2em"></span>
        </div>
        <div class="row"  style="margin-top:-0.35em">
          <span id="ToolTip3" style="font-size:0.65em;margin-left:-3em"></span>
        </div>
        <div class="row"  style="margin-top:-0.25em">
          <span id="ToolTip4" style="font-size:0.65em;margin-left:-3em"></span>
        </div>

    </div>

</nav>
    <div class="container-fluid">
        <div class="row"  >
           <div  class="col-lg-9" >
                  <h6 style="color:darkblue">TAREAS RECURRENTES ASIGNADAS DEL EVALUADO(A) </h6> 

                  <div  class="box box-warning box-solid pt-0" id="collapseExample"  style=" background-color=#d5e1d8;"> 
                        <asp:DropDownList ID="ddlTareas" runat="server" style="color: darkblue; font-size: 7.5pt;  max-width: 90%;"></asp:DropDownList>
                 </div>
            </div>
            <div  class="col-lg-3" >      
                      <span data-html="true" style="font-size: 7pt; display: block; border-color:blue;">
                        <span style="color: green; margin-bottom: 0px;"><strong>EXCELENTE:</strong>CUMPLE CON EL TRABAJO Y SE VA MAS ALLA DE LAS EXPECTATIVAS.</span><br style="margin-bottom: 0px;"/>
                        <span style="color: dodgerblue; margin-bottom: 0px;"><strong>BUENO:</strong>CUMPLE CON LAS EXPECTATIVAS DE TRABAJO.</span><br style="margin-bottom: 0px;"/>
                        <span style="color: orange; margin-bottom: 0px;"><strong>SUFICIENTE:</strong>CUMPLE CON EL TRABAJO DE MANERA LIMITADA.</span><br style="margin-bottom: 0px;"/>
                        <span style="color: crimson; margin-bottom: 0px;"><strong>EN OBSERVACION:</strong> NO SE CUMPLE CON EL TRABAJO ASIGNADO.</span><br style="margin-bottom: 0px;"/>
                      </span>         

            </div>
        </div>
        <asp:UpdatePanel ID="PanelFactoresEvaluacion" runat="server">
            <ContentTemplate>
             <asp:Repeater ID="FactoresEvaluacion" runat="server" OnItemDataBound="FactoresEvaluacion_ItemDataBound">
            <ItemTemplate>
                <div class="row  pb-0 pt-0">
                    <div  class="col-lg-9  pb-0" >
                        <div class="card">
                            <h5 class="ml-1" style="position:absolute"><strong><%# DataBinder.Eval(Container.DataItem, "Nro") %></strong></h5>
                            <div class=" ct-page-title border-success" style="border-radius:5px">                            
                                <p id="fev" class="text-sm mb-0"><span class="text-sm mb-0 font-weight-bold"><%# DataBinder.Eval(Container.DataItem, "factor") %>:  </span>
                                    <%# DataBinder.Eval(Container.DataItem, "descripcion") %>                                   
                                    <asp:Label Visible="true" CssClass="id" ID="lblRfe_ci_id" Text='<%# DataBinder.Eval(Container.DataItem, "rfe_ci_id") %>' runat="server" style="font-size: 2px; color: white;" />
                                </p>
                            </div>
                         </div>
                    </div>     

                   <div class="col-lg-3 pb-0">
                      <div id="fev_ponderadores" class="card p-2">
                          <asp:RadioButtonList CssClass="p-1" Font-Size="0.7em" ID="rblPonderadoresFEV" runat="server" RepeatColumns="2" RepeatLayout="Table" RepeatDirection="Horizontal"></asp:RadioButtonList>
                          <!--<asp:Label ID="RespuestaAnteriorFa" runat="server" Visible="false"></asp:Label>-->
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
        Debe registrar todos los Factores de Evaluación, antes de pasar a la siguiente instancia.
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-success" data-dismiss="modal">Ok</button>
      </div>
    </div>
  </div>
</div>
     <script>
        $(document).ready(function () {
            $(".p-2 input").change(function () {
                //alert("ingresa al function!");
                var index = $(this).attr("id");
                index = index.substring(index.length - 2, index.length);
                
                if (index.includes("_"))
                { index = index.substring(index.length - 1, index.length); }
               /* // Modificación para obtener fev_ci_id de manera más robusta
                var fev_ci_id = $("#ContentPlaceHolder1_FactoresEvaluacion_lblRfe_ci_id_" + index).text().trim() ||
                                $("#ContentPlaceHolder1_FactoresEvaluacion_lblRfe_ci_id_" + index).val().trim();
                // Verificación de valores
                alert("rfe_pond_id: " + $(this).val());
                alert("fev_ci_id: " + fev_ci_id);

                   */
                  switch ($(this).closest("td").find("label").html())
                        {
                          case "EXCELENTE":
                              $("#ContentPlaceHolder1_FactoresEvaluacion_rblPonderadoresFEV_" + index).css("background-color", "LightGreen"); break;
                      case "BUENO":
                              $("#ContentPlaceHolder1_FactoresEvaluacion_rblPonderadoresFEV_" + index).css("background-color", "LightBlue"); break;
                      case "SUFICIENTE":
                          $("#ContentPlaceHolder1_FactoresEvaluacion_rblPonderadoresFEV_" + index).css("background-color", "Orange"); break;
                      case "EN OBSERVACIÓN":
                          $("#ContentPlaceHolder1_FactoresEvaluacion_rblPonderadoresFEV_" + index).css("background-color", "LightCoral"); break;
                }

                  var fev_ci_id = $("#ContentPlaceHolder1_FactoresEvaluacion_lblRfe_ci_id_" + index).text().trim();
                  //alert("fev_ci_id: " + fev_ci_id);
                  //alert("rfe_pond_id: " + $(this).val());
                
                  PageMethods.Registrar($(this).val(), fev_ci_id, onSuccess, onFailure);
                          function onSuccess(result) {
                              return true;
                          }

                          function onFailure(result) {
                              alert("No se pudo registrar, verifique su conexión de red!");
                          }
                    });

             });
        </script>
</asp:Content>


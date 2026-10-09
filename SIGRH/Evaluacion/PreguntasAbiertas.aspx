<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="PreguntasAbiertas.aspx.cs" Inherits="Evaluacion_PreguntasAbiertas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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
                </div>
            </div>
            <!-- End Ver Datos Evaluado-->

           <div class="row"  >
                <div  class="col-lg-2" >
                    <asp:ImageButton ID="imgListado" runat="server" ImageUrl="imagenes/usuarios2.png"  OnClick="imgListado_Click" Width="1.2cm" Height="1.2cm"/>
                    <a href=""><h6>Ver Evaluados</h6></a>
                </div>
               <div  class="col-lg-7" >
                   <div class="shadow p-3 mb-5 bg-body rounded">
                   <span class="border border-white border-3">
                   <a href="ResultadosEspecificos.aspx"><asp:Label ID="lblResultados" runat="server" Text=""></asp:Label></a> </span>
                   <span class="border border-white border-3">
                   <a href="FactoresEvaluacion.aspx" ><asp:Label ID="lblFactores" runat="server" Text=""></asp:Label></a></span>
                   <span class="border border-primary border-5">
                   <a href="PreguntasAbiertas.aspx" ><asp:Label ID="lblPreguntas" runat="server" Text=""></asp:Label></a></span>
                       </div>
               </div>
               <div  class="col-lg-3" >
               </div>
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

</div>
</nav>


<div class="container-fluid">
    <asp:Repeater ID="PreguntasAbiertas" runat="server" OnItemDataBound="PreguntasAbiertas_ItemDataBound" >
            <ItemTemplate>
        <div class="row mt-2">
           <p id="fev" class="text-sm mb-0"><span class="text-sm mb-0 font-weight-bold"><%# DataBinder.Eval(Container.DataItem, "cat_descripcion") %>:  </span></p>
            <div  class="col-lg-12" >
                <div class="card">
                   <asp:TextBox ID="txtPreguntasAbiertas" CssClass="form-control border-success" runat="server"></asp:TextBox>
                   <asp:Label Visible="true" CssClass="id" ID="lblPa_id" Text='<%# DataBinder.Eval(Container.DataItem, "pa_id") %>' runat="server" />
                </div>
             </div>
         </div>  
            </ItemTemplate>      
         </asp:Repeater>
</div>
         <asp:Button Text="Guardar y Generar Formulario" runat="server" class="btn btn-success" OnClick="Registrar_PreguntasAbiertas"  />
<asp:UpdatePanel ID="PanelDNC" runat="server" Visible ="false">
   <ContentTemplate>
<div class="container-fluid bg-gradient-lighter">
    <div class="navbar-header mt--4">
         <span  class="h2 text-muted d-inline-block mb-0">Necesidades de Capacitación</span>
    </div>    
    <div class="row">
             <div class="col-lg-10"></div>
             <div class="col-lg-2"><h5>Identificada por:</h5></div>
    </div>

    <div class ="card" id="DncNuevo">


               <div class="row">
                   <div class="col-lg-10">
                      <h5 class="ml-2 mt-3" style="position:absolute">1</h5>
                      <div class=" ct-page-title border-success" style="border-radius:5px">                            
                       <asp:TextBox ID="txtDnc1" CssClass="form-control border-success" runat="server" Text=""></asp:TextBox>
                       <asp:Label Visible="true" CssClass="id" ID="lblRdnc_id1" Text="" runat="server" />
                    </div>
                   </div>
                   <div class="col-lg-2" >
                            <asp:RadioButtonList   CssClass="p-2 mt-3"   Font-Size="0.7em" ID="rblDnc1" runat="server" RepeatColumns="2" RepeatLayout="Table" RepeatDirection="Horizontal">
                            </asp:RadioButtonList>                        
                   </div>
               </div>
               <div class="row mt-2">
                   <div class="col-lg-10">
                      <h5 class="ml-2 mt-3" style="position:absolute">2</h5>
                      <div class=" ct-page-title border-success" style="border-radius:5px">                            
                       <asp:TextBox ID="txtDnc2" CssClass="form-control border-success" runat="server" Text=""></asp:TextBox>
                       <asp:Label Visible="true" CssClass="id" ID="lblRdnc_id2" Text="" runat="server" />
                    </div>
                   </div>
                   <div class="col-lg-2" >
                            <asp:RadioButtonList   CssClass="p-2 mt-3"   Font-Size="0.7em" ID="rblDnc2" runat="server" RepeatColumns="2" RepeatLayout="Table" RepeatDirection="Horizontal">
                            </asp:RadioButtonList>                        
                   </div>
               </div>
    <div id="DncNavbar" role="navigation">
        <div class="row mt-2">
            <div class="col-lg-10">
                <h5 class="ml-2 mt-3" style="position:absolute">3</h5>
                <div class=" ct-page-title border-success" style="border-radius:5px">                            
                <asp:TextBox ID="txtDnc3" CssClass="form-control border-success" runat="server" Text=""></asp:TextBox>
                <asp:Label Visible="true" CssClass="id" ID="lblRdnc_id3" Text="" runat="server" />
            </div>
            </div>
            <div class="col-lg-2" >
                    <asp:RadioButtonList   CssClass="p-2 mt-3"   Font-Size="0.7em" ID="rblDnc3" runat="server" RepeatColumns="2" RepeatLayout="Table" RepeatDirection="Horizontal">
                    </asp:RadioButtonList>                        
            </div>
        </div>
        <div class="row mt-2">
            <div class="col-lg-10">
                <h5 class="ml-2 mt-3" style="position:absolute">4</h5>
                <div class=" ct-page-title border-success" style="border-radius:5px">                            
                <asp:TextBox ID="txtDnc4" CssClass="form-control border-success" runat="server" Text=""></asp:TextBox>
                <asp:Label Visible="true" CssClass="id" ID="lblRdnc_id4" Text="" runat="server" />
            </div>
            </div>
            <div class="col-lg-2" >
                    <asp:RadioButtonList   CssClass="p-2 mt-3"   Font-Size="0.7em" ID="rblDnc4" runat="server" RepeatColumns="2" RepeatLayout="Table" RepeatDirection="Horizontal">
                    </asp:RadioButtonList>                        
            </div>
        </div>
        <div class="row mt-2">
            <div class="col-lg-10">
                <h5 class="ml-2 mt-3" style="position:absolute">5</h5>
                <div class=" ct-page-title border-success" style="border-radius:5px">                            
                <asp:TextBox ID="txtDnc5" CssClass="form-control border-success" runat="server" Text=""></asp:TextBox>
                <asp:Label Visible="true" CssClass="id" ID="lblRdnc_id5" Text="" runat="server" />
            </div>
            </div>
            <div class="col-lg-2" >
                    <asp:RadioButtonList   CssClass="p-2 mt-3"   Font-Size="0.7em" ID="rblDnc5" runat="server" RepeatColumns="2" RepeatLayout="Table" RepeatDirection="Horizontal">
                    </asp:RadioButtonList>                        
            </div>
        </div>
        <div class="row mt-2">
            <div class="col-lg-10">
                <h5 class="ml-2 mt-3" style="position:absolute">6</h5>
                <div class=" ct-page-title border-success" style="border-radius:5px">                            
                <asp:TextBox ID="txtDnc6" CssClass="form-control border-success" runat="server" Text=""></asp:TextBox>
                <asp:Label Visible="true" CssClass="id" ID="lblRdnc_id6" Text="" runat="server" />
            </div>
            </div>
            <div class="col-lg-2" >
                    <asp:RadioButtonList   CssClass="p-2 mt-3"   Font-Size="0.7em" ID="rblDnc6" runat="server" RepeatColumns="2" RepeatLayout="Table" RepeatDirection="Horizontal">
                    </asp:RadioButtonList>                        
            </div>
        </div>
        <div class="row mt-2">
            <div class="col-lg-10">
                <h5 class="ml-2 mt-3" style="position:absolute">7</h5>
                <div class=" ct-page-title border-success" style="border-radius:5px">                            
                <asp:TextBox ID="txtDnc7" CssClass="form-control border-success" runat="server" Text=""></asp:TextBox>
                <asp:Label Visible="true" CssClass="id" ID="lblRdnc_id7" Text="" runat="server" />
            </div>
            </div>
            <div class="col-lg-2" >
                    <asp:RadioButtonList   CssClass="p-2 mt-3"   Font-Size="0.7em" ID="rblDnc7" runat="server" RepeatColumns="2" RepeatLayout="Table" RepeatDirection="Horizontal">
                    </asp:RadioButtonList>                        
            </div>
        </div>

    </div>
               
    </div>

        <a href="#">
    <asp:Image ID="adicionar" ImageUrl="imagenes/pngwing.com.png" runat="server" Width="25px" CssClass="image mt--4" />
        </a>
</div>
</ContentTemplate>
</asp:UpdatePanel>    
<script>
    $(document).ready(function () {
        $('.image').click(function () {
            $('#DncNavbar').show();
            $('image').hide();
        });
        var dnc_extras = '<%=HttpContext.Current.Session["respuestas_DNC"].ToString()%>';
        if (dnc_extras<=2){
            $('#DncNavbar').hide();
        }
        $(".id").hide();
    });
</script>
</asp:Content>


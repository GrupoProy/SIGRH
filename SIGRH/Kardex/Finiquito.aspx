<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="Finiquito.aspx.cs" Inherits="Kardex_Finiquito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Finiquito</h6>
                    </div>

                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid mt--6">
        <div class="row justify-content-center">
            <div class="col-lg-12">
                <div class="card-wrapper">
                    <!-- Sizes -->
                    <div class="card card-profile">
                        <div class="row justify-content-center">
                            <div class="col-lg-3 order-lg-2">
                                <div class="card-profile-image">
                                    <a href="#">
                                        <asp:Image Width="100px" ID="imgFun" class="rounded-circle mt--2" runat="server" />
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="card-header text-center border-0 pt-8 pt-md-4 pb-0 pb-md-4">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:LinkButton ID="btn_estado" class="btn btn-sm btn-info float-right" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                    <div class="row">
                        <div class="col-2"></div>
                        <div class="col-8">
                        <div class="card-header">
                            <h3 class="mb-0">I. DATOS GENERALES </h3>
                        </div>
                        </div>
                    </div>
                        </div>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                
                                <div class="row">
                                <div class="col-2"></div>
                                    <div class="col-8">
                                <div class="card-body">

                                    <div class="row align-items-center row-content">
                                        <div class="col-auto">
                                            <div class="content-icon">
                                                <i class="ni ni-briefcase-24"></i>
                                            </div>
                                        </div>
                                        <div class="col ml--2">
                                            <div class="content-text-label mb-0">Razón social o nombre de la empresa</div>
                                            <div class="h5 font-weight-400 content-text content-text">

                                                <asp:Literal ID="ltl_razon_social" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row row-content">
                                        <div class="col-lg-8">
                                            <div class="row align-items-center">
                                                <div class="col-auto">
                                                    <div class="content-icon">
                                                        <i class="ni ni-briefcase-24"></i>
                                                    </div>
                                                </div>
                                                <div class="col ml--2">
                                                    <div class="content-text-label mb-0">Rama de actividad económica</div>
                                                    <div class="h5 font-weight-400 content-text content-text">

                                                        <asp:Literal ID="ltl_rama_act" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="row align-items-center">
                                                <div class="col-auto">
                                                    <div class="content-icon">
                                                        <i class="ni ni-briefcase-24"></i>
                                                    </div>
                                                </div>
                                                <div class="col ml--2">
                                                    <div class="content-text-label mb-0">Domicilio</div>
                                                    <div class="h5 font-weight-400 content-text content-text">
                                                        <asp:Literal ID="ltl_domicilio_act" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row align-items-center row-content">
                                        <div class="col-auto">
                                            <div class="content-icon">
                                                <i class="ni ni-single-02"></i>
                                            </div>
                                        </div>
                                        <div class="col ml--2">
                                            <div class="content-text-label mb-0">Nombre del trabajador</div>
                                            <div class="h5 font-weight-400 content-text content-text">
                                                <asp:Literal ID="ltl_nombre_fun" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row row-content">
                                        <div class="col-lg-4">
                                            <div class="row align-items-center">
                                                <div class="col-auto">
                                                    <div class="content-icon">
                                                        <i class="ni ni-diamond"></i>
                                                    </div>
                                                </div>
                                                <div class="col ml--2">
                                                    <div class="content-text-label mb-0">Estado civil</div>
                                                    <div class="h5 font-weight-400 content-text content-text">
                                                        <asp:Literal ID="ltl_estado_civil" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="row align-items-center">
                                                <div class="col-auto">
                                                    <div class="content-icon">
                                                        <i class="ni ni-watch-time"></i>
                                                    </div>
                                                </div>
                                                <div class="col ml--2">
                                                    <div class="content-text-label mb-0">Edad </div>
                                                    <div class="h5 font-weight-400 content-text content-text">
                                                        <asp:Literal ID="ltl_edad" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="row align-items-center">
                                                <div class="col-auto">
                                                    <div class="content-icon">
                                                        <i class="ni ni-square-pin"></i>
                                                    </div>
                                                </div>
                                                <div class="col ml--2">
                                                    <div class="content-text-label mb-0">Domicilio</div>
                                                    <div class="h5 font-weight-400 content-text content-text">
                                                        <asp:Literal ID="ltl_domicilio" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row align-items-center row-content">
                                        <div class="col-auto">
                                            <div class="content-icon">
                                                <i class="ni ni-hat-3"></i>
                                            </div>
                                        </div>
                                        <div class="col ml--2">
                                            <div class="content-text-label mb-0">Profesión u ocupación</div>
                                            <div class="h5 font-weight-400 content-text content-text">
                                                <asp:Literal ID="ltl_profesion" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row row-content">
                                        <div class="col-lg-4">
                                            <div class="row align-items-center">
                                                <div class="col-auto">
                                                    <div class="content-icon">
                                                        <i class="ni ni-badge"></i>
                                                    </div>
                                                </div>
                                                <div class="col ml--2">
                                                    <div class="content-text-label mb-0">C.I.</div>
                                                    <div class="h5 font-weight-400 content-text content-text">
                                                        <asp:Literal ID="ltl_ci" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="row align-items-center">
                                                <div class="col-auto">
                                                    <div class="content-icon">
                                                        <i class="ni ni-calendar-grid-58"></i>
                                                    </div>
                                                </div>
                                                <div class="col ml--2">
                                                    <div class="content-text-label mb-0">Fecha de ingreso</div>
                                                    <div class="h5 font-weight-400 content-text content-text">
                                                        <asp:Literal ID="ltl_fecha_ingreso" runat="server" Visible="true" />
<%--                                                        <asp:TextBox runat="server"   ID="txtFechaIngreso" CssClass="datepicker" Visible="false"/>--%>
                                                            <asp:TextBox ID="txtFechaIngreso" CssClass="form-control datepickerD" runat="server"   />
                                                           <asp:LinkButton ID="btnActualizar" Visible="true" OnClick="btnActualizar_Click" CssClass="btn btn-success btn-block"    Text="<i class='fas fa-upload'></i>  1.  Actualizar"    runat="server" />
                                                            <asp:LinkButton ID="btnImprimir" OnClick="btnImprimir_Click" CssClass="btn btn-info btn-block mt-1" ValidationGroup="finalizar"  Text="<i class='fas fa-print'></i> Imprimir"  Visible="false"    runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="row align-items-center">
                                                <div class="col-auto">
                                                    <div class="content-icon">
                                                        <i class="ni ni-calendar-grid-58"></i>
                                                    </div>
                                                </div>
                                                <div class="col ml--2">
                                                    <div class="content-text-label mb-0">Fecha de retiro</div>
                                                    <div class="h5 font-weight-400 content-text content-text">
                                                        <asp:Literal ID="ltl_fecha_retiro" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row row-content">
                                        <div class="col-lg-6">
                                            <div class="row align-items-center">
                                                <div class="col-auto">
                                                    <div class="content-icon">
                                                        <i class="ni ni-archive-2"></i>
                                                    </div>
                                                </div>
                                                <div class="col ml--2">
                                                    <div class="content-text-label mb-0">Motivo de retiro</div>
                                                    <div class="h5 font-weight-400 content-text content-text">
                                                        <asp:Literal ID="ltl_motivo_retiro" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="row align-items-center">
                                                <div class="col-auto">
                                                    <div class="content-icon">
                                                        <i class="fas fa-dollar-sign"></i>
                                                    </div>
                                                </div>
                                                <div class="col ml--2">
                                                    <div class="content-text-label mb-0">Remuneración mensual</div>
                                                    <div class="h5 font-weight-400 content-text content-text">
                                                        <asp:Literal ID="ltl_remuneracion_mensual" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row row-content">
                                        <div class="col-lg-3">
                                            <div class="row align-items-center">
                                                <div class="col-auto">
                                                    <div class="content-icon">
                                                        <i class="ni ni-time-alarm"></i>
                                                    </div>
                                                </div>
                                                <div class="col ml--2">
                                                    <div class="content-text-label mb-0" style="font-size: 0.875rem">Tiempo de servicio</div>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="row align-items-center">
                                                <div class="col-auto">
                                                    <div class="content-icon">
                                                        <i class="fas fa-calculator"></i>
                                                    </div>
                                                </div>
                                                <div class="col ml--2">
                                                    <div class="h5 font-weight-400 content-text content-text">
                                                        <asp:Literal ID="ltl_anios" runat="server" />
                                                        Años
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="row align-items-center">
                                                <div class="col-auto">
                                                    <div class="content-icon">
                                                        <i class="fas fa-calculator"></i>
                                                    </div>
                                                </div>
                                                <div class="col ml--2">
                                                    <div class="h5 font-weight-400 content-text content-text">
                                                        <asp:Literal ID="ltl_meses" runat="server" />
                                                        Meses
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="row align-items-center">
                                                <div class="col-auto">
                                                    <div class="content-icon">
                                                        <i class="fas fa-calculator"></i>
                                                    </div>
                                                </div>
                                                <div class="col ml--2">
                                                    <div class="h5 font-weight-400 content-text content-text">
                                                        <asp:Literal ID="ltl_dias" runat="server" />
                                                        Días
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                                

                                    </div>
                                </div>
                                    </div>
                                <div class="col-2"></div>
                                    </div>
                                <asp:HiddenField ID="hf_as_tipo_baja" runat="server" />
                                <asp:HiddenField ID="hf_total_dias" runat="server" />
                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnActualizar" EventName="Click" />
                                            </Triggers>

                        </asp:UpdatePanel>
                    </div>
                </div>

                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
    <div class="container-fluid" runat="server" id="DivFiniquito" visible="true">
                <div class="card">
                    <div class="card-body">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class=" col-12 justify-content-center">
                                    <div class="card-header">
                                        <h4 class="mb-0">II. LIQUIDACIÓN DE LA REMUNERACIÓN PROMEDIO INDEMNIZABLE EN BASE A LOS 3 ÚLTIMOS MESES (Expresado en Bs) </h4>
                                    </div>
                                    <div class="row justify-content-center mt-1" style="border: 1px solid gray">
                                        <div class="col-12" style=" border-right: 1px solid gray">
                                            <asp:Label  Text="A) MESES" runat="server" />
                                        </div>
                                     </div>
                                    <div class="row justify-content-center mt-1"  style="border: 1px solid gray">
                                        <div class="col-2"  style=" border-right: 1px solid gray">
                                            <asp:Label  CssClass="ml--7" Text="" runat="server" />
                                        </div>
                                        <div class="col-2"  style=" border-right: 1px solid gray">
                                            <asp:Label  ID="lblMes1" Text="" runat="server" />
                                        </div>
                                        <div class="col-2"   style=" border-right: 1px solid gray">
                                            <asp:Label  ID="lblMes2" Text="" runat="server" />
                                        </div>
                                        <div class="col-2"   style=" border-right: 1px solid gray">
                                            <asp:Label  ID="lblMes3" Text="" runat="server" />
                                        </div>
                                        <div class="col-2">
                                            <asp:Label  Text="TOTAL" runat="server" />
                                        </div>
                                    </div>     
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>

                                    <div class="row justify-content-center mt-1" style="border: 1px solid gray">
                                        <div class="col-2" style=" border-right: 1px solid gray">
                                            <asp:Label  Text="REMUNERACIÓN MENSUAL" runat="server" />
                                        </div>
                                        <div class="col-2 text-center" style=" border-right: 1px solid gray">
<%--                                            <asp:Label ID="lblRem1" Text="" runat="server" />--%>
                                            <asp:TextBox    CssClass="form-control"  ID="txtRem1"  Width="100%" runat="server" />
                                        </div>
                                        <div class="col-2" style=" border-right: 1px solid gray">
<%--                                            <asp:Label ID="lblRem2" Text="" runat="server" />--%>
                                            <asp:TextBox    CssClass="form-control" ID="txtRem2"  Width="100%" runat="server" />

                                        </div>
                                        <div class="col-2" style=" border-right: 1px solid gray">
                                            <%--<asp:Label ID="lblRem3" Text="" runat="server" />--%>
                                            <asp:TextBox   CssClass="form-control" ID="txtRem3"  Width="100%" runat="server" />
                                        </div>
                                        <div class="col-2">
                                            <asp:Label ID="lblRemTotal" Text="" runat="server" />
                                        </div>
                                    </div>        
                                    <hr />
                                    <div class="row justify-content-center" style="border: 1px solid gray">
                                        <div class="col-12" style=" border-right: 1px solid gray">
                                            <asp:Label  Text="B) OTROS CONCEPTOS PERCIBIDOS EN EL MES" runat="server" />
                                        </div>
                                     </div>
                                    <div class="row justify-content-center mt-1" style="border: 1px solid gray">
                                        <div class="col-2" style=" border-right: 1px solid gray">
                                            <asp:Label  Text="BONO DE ANTIGÜEDAD" runat="server" />
                                        </div>
                                        <div class="col-2 text-center" style=" border-right: 1px solid gray">
<%--                                            <asp:Label ID="lblRem1" Text="" runat="server" />--%>
                                            <asp:TextBox    CssClass="form-control" ID="txtBa1"   Width="100%" runat="server" />
                                        </div>
                                        <div class="col-2" style=" border-right: 1px solid gray">
<%--                                            <asp:Label ID="lblRem2" Text="" runat="server" />--%>
                                            <asp:TextBox   CssClass="form-control" ID="txtBa2"  Width="100%" runat="server" />

                                        </div>
                                        <div class="col-2" style=" border-right: 1px solid gray">
                                            <%--<asp:Label ID="lblRem3" Text="" runat="server" />--%>
                                            <asp:TextBox   CssClass="form-control" ID="txtBa3"  Width="100%" runat="server" />
                                        </div>
                                        <div class="col-2">
                                            <asp:Label ID="lblBaTotal" Text="" runat="server" />
                                        </div>
                                    </div>                                    
                                    <div class="row justify-content-center mt-1" style="border: 1px solid gray">
                                        <div class="col-2" style=" border-right: 1px solid gray">
                                            <asp:Label  Text="BONO FRONTERA" runat="server" />
                                        </div>
                                        <div class="col-2 text-center" style=" border-right: 1px solid gray">
<%--                                            <asp:Label ID="lblRem1" Text="" runat="server" />--%>
                                            <asp:TextBox    CssClass="form-control" ID="txtBf1"  Width="100%" runat="server" />
                                        </div>
                                        <div class="col-2" style=" border-right: 1px solid gray">
<%--                                            <asp:Label ID="lblRem2" Text="" runat="server" />--%>
                                            <asp:TextBox   CssClass="form-control" ID="txtBf2" Width="100%" runat="server" />

                                        </div>
                                        <div class="col-2" style=" border-right: 1px solid gray">
                                            <%--<asp:Label ID="lblRem3" Text="" runat="server" />--%>
                                            <asp:TextBox   CssClass="form-control" ID="txtBf3" Width="100%" runat="server" />
                                        </div>
                                        <div class="col-2">
                                            <asp:Label ID="lblBfTotal" Text="" runat="server" />
                                        </div>
                                    </div>                                    
                                    <div class="row justify-content-center mt-1" style="border: 1px solid gray">
                                        <div class="col-2" style=" border-right: 1px solid gray">
                                            <asp:Label  Text="TOTAL" runat="server" />
                                        </div>
                                        <div class="col-2 text-center" style=" border-right: 1px solid gray">
                                            <asp:Label ID="lblTotal1" Text="" runat="server" />
                                        </div>
                                        <div class="col-2 text-center" style=" border-right: 1px solid gray">
                                            <asp:Label ID="lblTotal2" Text="" runat="server" />

                                        </div>
                                        <div class="col-2 text-center" style=" border-right: 1px solid gray">
                                            <asp:Label ID="lblTotal3" Text="" runat="server" />
                                        </div>
                                        <div class="col-2">
                                            <asp:Label ID="lblTotalGeneral" Text="" runat="server" />
                                        </div>
                                    </div>      

                                            
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                   <asp:LinkButton ID="btnCalcular1" CssClass="btn btn-success btn-block mt-1"   OnClick="btnCalcular1_Click" Text="<i class='fas fa-calculator'></i>  2.  Calcular"    runat="server" />
                                    
                                    <hr />
                                    <div class="row justify-content-center mt-1" style="border: 1px solid gray">
                                        <div class="col-8" style=" border-right: 1px solid gray">
                                            <asp:Label  Text="III. TOTAL REMUNERACIÓN PROMEDIO INDEMNIZABLE (A+B)/3" runat="server" />
                                        </div>
                                        <div class="col-2 text-left">
                                            <asp:TextBox  CssClass="form-control" ID="lblPromedioCotizable"  Enabled="false" Width="100%" runat="server" />
                                        </div>
                                     </div>
                                    <hr />
                                    <div class="row justify-content-center mt-1" style="border: 1px solid gray">
                                        <div class="col-8" style=" border-right: 1px solid gray">
                                            <asp:Label  Text="C) DESAHUCIO TRES MESES (EN CASO DE RETIRO FORZOSO):" runat="server" />
                                        </div>
                                        <div class="col-2 text-left">
                                            <asp:TextBox  CssClass="form-control" ID="txtDesahucio" Enabled="false"  Width="100%" runat="server" Visible="false" />
                                           <asp:LinkButton ID="btnHabilitarDesahucio" OnClick="btnHabilitarDesahucio_Click" CssClass="btn btn-success"  Text="<i class='fas fa-calculator'></i> Habilitar"  Visible="true"   runat="server" />
                                        </div>
                                     </div>
                                <hr />

                                    <div class="row justify-content-center mt-1" style="border: 1px solid gray;" >
                                        <div class="col-8" >
                                            <asp:Label  Text="D) INDEMNIZACIÓN POR TIEMPO DE TRABAJO:" runat="server" />
                                        </div>
                                    </div>

                                    <div class="row justify-content-center mt-1" >
                                        <div class="col-6 text-center" >
                                        </div>
                                        <div class="col-2 text-left">
                                            <asp:Label  Text="" ID="lblTiempoAnio" runat="server" />
                                        </div>
                                        <div class="col-2 text-left">
                                            <asp:Label  Text=""  ID="lblTiempoAnioMonto" runat="server" />
                                        </div>
                                    </div>
                                    <div class="row justify-content-center mt-1" >
                                        <div class="col-6 text-center" >
                                        </div>
                                        <div class="col-2 text-left">
                                            <asp:Label  Text="" ID="lblTiempoMes" runat="server" />
                                        </div>
                                        <div class="col-2 text-left">
                                            <asp:Label  Text=""  ID="lblTiempoMesMonto" runat="server" />
                                        </div>
                                    </div>
                                    <div class="row justify-content-center mt-1"  >
                                        <div class="col-6 text-center" >
                                        </div>
                                        <div class="col-2 text-left">
                                            <asp:Label  Text="" ID="lblTiempoDias" runat="server" />
                                        </div>
                                        <div class="col-2 text-left">
                                            <asp:Label  Text="" ID="lblTiempoDiasMonto" runat="server" />
                                        </div>
                                    </div>

                                    <div class="row justify-content-center mt-3" style="border: 1px solid gray">
                                        <div class="col-6" style=" border-right: 1px solid gray">
                                            <asp:Label  Text="VACACIONES" runat="server" />
                                        </div>
                                        <div class="col-2 text-left">
                                            <asp:TextBox  CssClass="form-control" ID="txtTotalVacacionesDias"  Width="100%" runat="server" />
                                        </div>
                                        <div class="col-2 text-left">
                                            <asp:TextBox  CssClass="form-control" ID="txtTotalVacacionesMonto" Enabled="false"  Width="100%" runat="server" />
                                        </div>
                                     </div>
                                    <div class="row justify-content-center mt-1" style="border: 1px solid gray">
                                        <div class="col-8" style=" border-right: 1px solid gray">
                                            <asp:Label  Text="AGUINALDO" runat="server" />
                                        </div>
                                        <div class="col-2 text-left">
                                            <asp:TextBox  CssClass="form-control" ID="txtTotalAguinaldo" Enabled="false"  Width="100%" runat="server" />
                                        </div>
                                     </div>

                                    <div class="row justify-content-center mt-1" style="border: 1px solid gray">
                                        <div class="col-8" style=" border-right: 1px solid gray">
                                            <asp:TextBox  CssClass="form-control" ID="txtIndemnExtra1"  Width="100%" runat="server" />
                                        </div>
                                        <div class="col-2 text-left">
                                            <asp:TextBox  CssClass="form-control" ID="txtIndemnExtra1Monto"  Width="100%" runat="server" />
                                        </div>
                                     </div>
                                    <div class="row justify-content-center mt-1" style="border: 1px solid gray">
                                        <div class="col-8" style=" border-right: 1px solid gray">
                                            <asp:TextBox  CssClass="form-control" ID="txtIndemnExtra2"  Width="100%" runat="server" />
                                        </div>
                                        <div class="col-2 text-left">
                                            <asp:TextBox  CssClass="form-control" ID="txtIndemnExtra2Mont"  Width="100%" runat="server" />
                                        </div>
                                     </div>

                                    <hr />
                                    <div class="row justify-content-center mt-1" style="border: 1px solid gray">
                                        <div class="col-12" style=" border-right: 1px solid gray">
                                            <asp:Label  Text="OTROS" runat="server" />
                                        </div>
                                     </div>
                                    <div class="row justify-content-center mt-1" style="border: 1px solid gray">
                                        <div class="col-8" style=" border-right: 1px solid gray">
                                            <asp:TextBox  CssClass="form-control" ID="txtIndemnExtra3"  Width="100%" runat="server" />
                                        </div>
                                        <div class="col-2 text-left">
                                            <asp:TextBox  CssClass="form-control" ID="txtIndemnExtra3Mont"  Width="100%" runat="server" />
                                        </div>
                                     </div>

                                    <hr />




                                    <div class="row justify-content-center mt-1" style="border: 1px solid gray">
                                        <div class="col-8" style=" border-right: 1px solid gray">
                                            <asp:Label  Text="IV. TOTAL BENEFICIOS SOCIALES (C+D)" runat="server" />
                                        </div>
                                        <div class="col-2 text-left">
                                            <asp:TextBox  CssClass="form-control" ID="txtTotalBeneficios"  Enabled="false" Width="100%" runat="server" />
                                        </div>
                                     </div>
                                    <hr />

                                    <div class="row justify-content-center mt-1" style="border: 1px solid gray">
                                        <div class="col-6" style=" border-right: 1px solid gray">
                                            <asp:Label  Text="NOTA.- SE ELABORAN LOS SIGUIENTES DOCUMENTOS" runat="server" />
                                        </div>
                                        <div class="col-3 text-left">
                                            <asp:Label  Text="HOJA DE RUTA: " runat="server" />
                                            <asp:TextBox  CssClass="form-control" ID="txtHR" Enabled="true"  Width="100%" runat="server" />
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtHR" ValidationGroup="finalizar" Display="Dynamic" runat="server" />
                                        </div>
                                        <div class="col-3 text-left">
                                            <asp:Label  Text="INFORME LEGAL: " runat="server" />
                                            <asp:TextBox  CssClass="form-control" ID="txtInformeLegal" Enabled="true"  Width="100%" runat="server" />
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtInformeLegal" ValidationGroup="finalizar" Display="Dynamic" runat="server" />
                                        </div>
                                     </div>
                                    <div class="row justify-content-center mt-1" style="border: 1px solid gray">
                                        <div class="col-12" style=" border-right: 1px solid gray">
                                            <asp:Label  Text="FECHA DE PAGO" runat="server" />
                                            <asp:TextBox  CssClass="form-control datepickerD" ID="txtFechaPago" Enabled="true"  Width="100%" runat="server" />
                                        </div>
                                     </div>
                                    <hr />
                                    <div class="row justify-content-LEFT mt-1" style="border: 1px solid gray;" >
                                        <div class="col-8" >
                                            <asp:Label  Text="DEDUCCIONES" runat="server" />
                                        </div>
                                    </div>

                                    <div class="row justify-content-center mt-1" >
                                        <div class="col-6 text-center" >
                                        </div>
                                        <div class="col-2 text-left">
                                            <asp:Label  Text="" ID="Label1" runat="server" />
                                        </div>
                                        <div class="col-2 text-left">
                                            <asp:Label  Text=""  ID="Label2" runat="server" />
                                        </div>
                                    </div>

                                   <div class="row justify-content-center mt-1" style="border: 1px solid gray">
                                        <div class="col-8" style=" border-right: 1px solid gray">
                                            <asp:TextBox  CssClass="form-control" ID="txtDeduccion1"  Width="100%" runat="server" />
                                        </div>
                                        <div class="col-2 text-left">
                                            <asp:TextBox  CssClass="form-control" ID="txtDeduccion1Monto"  Width="100%" runat="server" />
                                        </div>
                                     </div>
                                    <div class="row justify-content-center mt-1" style="border: 1px solid gray">
                                        <div class="col-8" style=" border-right: 1px solid gray">
                                            <asp:TextBox  CssClass="form-control" ID="txtDeduccion2"  Width="100%" runat="server" />
                                        </div>
                                        <div class="col-2 text-left">
                                            <asp:TextBox  CssClass="form-control" ID="txtDeduccion2Monto"  Width="100%" runat="server" />
                                        </div>
                                     </div>
                                   <div class="row mt-1" style="border: 1px solid gray" >
                                        <div class="col-9" style=" border-right: 1px solid gray">
                                            <asp:Label  CssClass="text-right" Text="TOTAL DEDUCCIONES"  ID="Label3" runat="server" />
                                        </div>
                                        <div class="col-2 text-left">
                                            <asp:TextBox  CssClass="form-control" ID="txtDeduccionesTotal" Enabled="false"  Width="100%" runat="server" />
                                        </div>
                                     </div>
                                   <asp:LinkButton ID="btnCalcularBeneficiosSociales" CssClass="btn btn-success btn-block mt-1"  OnClick="btnCalcularBeneficiosSociales_Click"   Text="<i class='fas fa-calculator'></i>  3.  Calcular"    runat="server" />
                                    <hr />
                                    <div class="row justify-content-LEFT mt-1" style="border: 1px solid gray;" >
                                        <div class="col-8 ml-9" >
                                            <asp:Label   Text="IMPORTE LÍQUIDO  A PAGAR (C+D-E)" runat="server" />
                                                <asp:Label ID="txtLiquidoPagable"  Text="" runat="server" CssClass="float-right" />
                                        </div>
                                    </div>
                               </div>
                                <hr />
                                   <asp:LinkButton ID="btnFinalizar" CssClass="btn btn-info btn-block mt-1" OnClick="btnFinalizar_Click"  Visible="true"   Text="<i class='fas fa-check'></i> Finalizar"    runat="server" />
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnHabilitarDesahucio" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
    </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

            
            </div>
        </div>
    </div>
</asp:Content>


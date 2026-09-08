<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="Finiquito__.aspx.cs" Inherits="Kardex_Finiquito__" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            <div class="col-lg-8">
                <div class="card-wrapper">
                    <!-- Sizes -->
                    <div class="card card-profile">
                        <div class="row justify-content-center">
                            <div class="col-lg-3 order-lg-2">
                                <div class="card-profile-image">
                                    <a href="#">
                                        <asp:Image ID="imgFun" class="rounded-circle" runat="server" />
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

                        </div>
                        <div class="card-header">
                            <h3 class="mb-0">DATOS GENERALES </h3>
                        </div>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
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
                                                        <asp:Literal ID="ltl_fecha_ingreso" runat="server" />
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

                                <asp:HiddenField ID="hf_as_tipo_baja" runat="server" />
                                <asp:HiddenField ID="hf_total_dias" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="accordion" id="accordionExample">
                    <div class="card">
                        <div class="card-header" id="headingThree" data-toggle="collapse" data-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                            <h5 class="mb-0">DETALLE TIEMPO DE SERVICIO</h5>
                        </div>
                        <div id="collapseThree" class="collapse" aria-labelledby="headingThree" data-parent="#accordionExample">
                            <div class="card-body">
                                <p>Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.</p>
                            </div>
                            <div class="table-responsive py-4">
                                <asp:UpdatePanel ID="up_gv_asignaciones" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="gv_asignaciones" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" OnPreRender="gv_asignaciones_PreRender" OnRowCommand="gv_asignaciones_RowCommand" DataKeyNames="as_id" runat="server">
                                            <Columns>
                                                <asp:BoundField DataField="as_fecha_inicio" HeaderText="Fecha inicio" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                <asp:BoundField DataField="as_fecha_fin" HeaderText="Fecha Fin" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                <asp:BoundField DataField="dias" HeaderText="Tiempo Calculado (En Días)" HeaderStyle-CssClass="text-center"  ItemStyle-CssClass="text-center grid-bold" />
                                                <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <asp:LinkButton CommandName="GetEdit" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-success btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-check fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Adicionar tiempo de servicio' Visible='<%# Eval("contar").ToString() == "1" ? false : true %>' runat="server" />
                                                        <asp:LinkButton CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-outline-github btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-times fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Quitar tiempo de servicio' Visible='<%# Eval("contar").ToString() == "1" ? true : false %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card">
                    <div class="card-body">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="table-responsive py-4">
                                    <table class="table table-bordered table-hover" style="border: 1px solid #e9ecef;">
                                        <tbody>
                                            <tr>
                                                <th colspan="5" class="text-nowrap" scope="row">LIQUIDACIÓN DE LA REMUNERACIÓN PROMEDIO INDEMNIZABLE EN BASE A LOS 3 ÚLTIMOS MESES (Expresado en Bs)</th>
                                            </tr>
                                            <tr>
                                                <th class="text-left">MESES</th>
                                                <th class="text-center grid-bc-success">
                                                    <asp:Literal ID="ltl_mes3" runat="server" /></th>
                                                <th class="text-center grid-bc-success">
                                                    <asp:Literal ID="ltl_mes2" runat="server" /></th>
                                                <th class="text-center grid-bc-success">
                                                    <asp:Literal ID="ltl_mes1" runat="server" /></th>
                                                <th class="text-center grid-bc-total">TOTALES</th>
                                            </tr>
                                            <tr>
                                                <td style="padding-left: 25px;">REMUNERACIÓN MENSUAL</td>
                                                <td class="text-right">
                                                    <asp:Literal ID="ltl_rem_men3" runat="server" /></td>
                                                <td class="text-right">
                                                    <asp:Literal ID="ltl_rem_men2" runat="server" /></td>
                                                <td class="text-right">
                                                    <asp:Literal ID="ltl_rem_men1" runat="server" /></td>
                                                <th class="text-right">
                                                    <asp:Literal ID="ltl_rem_sum" runat="server" /></th>

                                            </tr>
                                            <tr>
                                                <th colspan="5" class="text-nowrap" scope="row">OTROS CONCEPTOS PERCIBIDOS EN EL MES</th>


                                            </tr>
                                            <tr>
                                                <td style="padding-left: 25px;">BONO DE ANTIGÜEDAD</td>
                                                <td class="text-right">
                                                    <asp:Literal ID="ltl_bono_antiguedad3" runat="server" /></td>
                                                <td class="text-right">
                                                    <asp:Literal ID="ltl_bono_antiguedad2" runat="server" /></td>
                                                <td class="text-right">
                                                    <asp:Literal ID="ltl_bono_antiguedad1" runat="server" /></td>
                                                <th class="text-right">
                                                    <asp:Literal ID="ltl_bono_antiguedad_sum" runat="server" /></th>
                                            </tr>
                                            <tr>
                                                <td style="padding-left: 25px;">HORAS EXTRAS</td>
                                                <td class="text-right">
                                                    <asp:Literal ID="ltl_horas_extras3" runat="server" /></td>
                                                <td class="text-right">
                                                    <asp:Literal ID="ltl_horas_extras2" runat="server" /></td>
                                                <td class="text-right">
                                                    <asp:Literal ID="ltl_horas_extras1" runat="server" /></td>
                                                <th class="text-right">
                                                    <asp:Literal ID="ltl_horas_extras_sum" runat="server" /></th>
                                            </tr>
                                            <tr>
                                                <th class="text-nowrap text-center grid-bc-total" scope="row">TOTAL</th>
                                                <th class="text-right">
                                                    <asp:Literal ID="ltl_sum3" runat="server" />
                                                </th>
                                                <th class="text-right">
                                                    <asp:Literal ID="ltl_sum2" runat="server" />
                                                </th>
                                                <th class="text-right">
                                                    <asp:Literal ID="ltl_sum1" runat="server" />
                                                </th>
                                                <th class="text-right grid-bc-info">
                                                    <asp:Literal ID="ltl_suma_total" runat="server" />
                                                </th>
                                            </tr>

                                        </tbody>
                                    </table>
                                    <table class="table table-bordered table-hover" style="border: 1px solid #e9ecef;">
                                        <tbody>
                                            <tr>
                                                <th colspan="6" class="text-center grid-bc-total">TOTAL REMUNERACIÓN PROMEDIO INDEMNIZABLE</th>
                                                <th class="text-right grid-bc-info" style="font-size: 1rem !important">
                                                    <asp:Literal ID="ltl_rem_promedio" runat="server" /></th>
                                            </tr>
                                            <tr>
                                                <td colspan="6" class="text-left">DESAHUCIO TRES MESES (EN CASO RETIRO FORZOSO)</td>

                                                <td class="text-right">
                                                    <asp:Literal ID="ltl_desahucio" runat="server" /></td>
                                            </tr>
                                            <tr>
                                                <td class="text-left">INDEMNIZACIÓN POR TIEMPO DE TRABAJO</td>
                                                <td class="text-center">DE</td>
                                                <th class="text-center">
                                                    <asp:Literal ID="ltl_antiguedad_anios" runat="server" /></th>
                                                <td class="text-center">AÑOS</td>
                                                <td colspan="2" class="text-right">
                                                    <asp:Literal ID="ltl_indem_anios" runat="server" /></td>
                                                <td rowspan="3" class="text-right align-middle">
                                                    <asp:Literal ID="ltl_indem_sum" runat="server" /></td>
                                            </tr>
                                            <tr>
                                                <td class="text-left"></td>
                                                <td class="text-center">DE</td>
                                                <th class="text-center">
                                                    <asp:Literal ID="ltl_antiguedad_meses" runat="server" /></th>
                                                <td class="text-center">MESES</td>
                                                <td colspan="2" class="text-right" style="border-right-width: 1px!important">
                                                    <asp:Literal ID="ltl_indem_meses" runat="server" /></td>
                                            </tr>
                                            <tr>
                                                <td class="text-left"></td>
                                                <td class="text-center">DE</td>
                                                <th class="text-center">
                                                    <asp:Literal ID="ltl_antiguedad_dias" runat="server" /></th>
                                                <td class="text-center">DÍAS</td>
                                                <td colspan="2" class="text-right" style="border-right-width: 1px!important">
                                                    <asp:Literal ID="ltl_indem_dias" runat="server" /></td>
                                            </tr>
                                            <tr>
                                                <td class="text-left">AGUINALDO NAVIDAD</td>
                                                <td class="text-center">DE</td>
                                                <th class="text-center">
                                                    <asp:Literal ID="ltl_aguinaldo_mes" runat="server" /></th>
                                                <td class="text-center">MESES</td>
                                                <th class="text-center">
                                                    <asp:Literal ID="ltl_aguinaldo_dia" runat="server" /></th>
                                                <td class="text-center">DÍAS</td>
                                                <td class="text-right">
                                                    <asp:Literal ID="ltl_aguinaldo_sum" runat="server" /></td>
                                            </tr>
                                            <tr>
                                                <td class="text-left">VACACIONES</td>
                                                <td class="text-center">DE</td>
                                                <td class="text-center"></td>
                                                <td class="text-center">MESES</td>
                                                <th class="text-center">
                                                    <asp:Literal ID="ltl_vacacion_dias" runat="server" /></th>
                                                <td class="text-center">DÍAS</td>
                                                <td class="text-right">
                                                    <asp:Literal ID="ltl_vacacion_sum" runat="server" /></td>
                                            </tr>
                                            <tr>
                                                <td class="text-left">PRIMA LEGAL (SI CORRESPONDE)</td>
                                                <td class="text-center">DE</td>
                                                <td class="text-center"></td>
                                                <td class="text-center">MESES</td>
                                                <td class="text-center"></td>
                                                <td class="text-center">DÍAS</td>
                                                <td class="text-right">
                                                    <asp:Literal ID="ltl_prima_sum" runat="server" /></td>
                                            </tr>
                                            <tr>
                                                <td class="text-left">OTROS</td>
                                                <td class="text-center">DE</td>
                                                <td class="text-center"></td>
                                                <td class="text-center">MESES</td>
                                                <td class="text-center"></td>
                                                <td class="text-center">DÍAS</td>
                                                <td class="text-right">
                                                    <asp:Literal ID="ltl_otros_sum" runat="server" /></td>
                                            </tr>
                                            <tr>
                                                <th colspan="6" class="text-center grid-bc-total">TOTAL BENEFICIOS SOCIALES</th>

                                                <th class="text-right grid-bc-info" style="font-size: 1rem !important">
                                                    <asp:Literal ID="ltl_total_beneficios_soc" runat="server" /></th>
                                            </tr>
                                            <tr>
                                                <td colspan="7" class="text-left">DEDUCCIONES</td>

                                            </tr>
                                            <tr>
                                                <td colspan="6" class="text-left" style="padding-left: 25px;">RC-IVA VACACIONES</td>

                                                <td class="text-right">
                                                    <asp:Literal ID="ltl_deduc_vacaciones" runat="server" /></td>
                                            </tr>
                                            <tr>
                                                <th colspan="6" class="text-center grid-bc-total" style="border-bottom: 1px solid #dee2e6;">TOTAL</th>
                                                <th class="text-right grid-bc-info" style="font-size: 1rem !important">
                                                    <asp:Literal ID="ltl_deduc_vacaciones_sum" runat="server" /></th>
                                            </tr>
                                            <tr>
                                                <th colspan="6" class="text-center grid-bc-success2">IMPORTE LÍQUIDO A PAGAR</th>
                                                <th class="text-right grid-bc-success2" style="font-size: 1rem !important">
                                                    <asp:Literal ID="ltl_importe_liquido" runat="server" /></th>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


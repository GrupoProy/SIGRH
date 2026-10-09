<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="Retroactivo.aspx.cs" Inherits="Salarios_Retroactivo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Retroactivo</h6>
                    </div>
                    <div class="col-lg-6 col-5 text-right">
                    </div>
                </div>
            </div>
        </div>
    </div>
            <asp:UpdatePanel runat="server" ID="PanelMigradas">
                <ContentTemplate>

<div class="container-fluid mt--6"  >
    <div class="row justify-content-center">
        <div class="col-lg-6 card-wrapper" runat="server" id="divPlanillas">
            <div class="card">
                    <div class="card-header">
                        <div class=" ct-page-title">
<%--                            <h3 class="mb-0">Retroactivo</h3>--%>
                            <p class="text-sm mb-0">
                                Migrar las Planillas para el retroactivo
                            </p>
                        </div>
                    </div>

        <div class="card-body">
        <div class="table-responsive py-4 mt--4">
                <asp:GridView ID="gvPlanillas" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gvPlanillas_PreRender"  OnRowCommand="gvPlanillas_RowCommand" DataKeyNames="cbh_pc_id, nro" runat="server">
                    <Columns>
                        <asp:BoundField DataField="TITULO" HeaderText="MES" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="CANTIDAD" HeaderText="CASOS" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" />
                        <asp:BoundField DataField="TIPO_PLANILLA" HeaderText="TIPO PLANILLA" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                        <asp:TemplateField HeaderText="MIGRAR" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:LinkButton CommandName="Migrar" Visible="true" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-vimeo btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-check fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Migrar' runat="server" />
<%--                                <asp:LinkButton CommandName="GetPrint" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-facebook btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-print fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Imprimir' runat="server" />--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
        </div>
        </div>
            </div>
        </div>

        <div class="col-lg-6 card-wrapper" runat="server" id="divMigradas" visible="false">
            <div class="card">
                    <div class="card-header">
                        <div class=" ct-page-title">
<%--                            <h3 class="mb-0">Retroactivo</h3>--%>
                            <p class="text-sm mb-0">
                                Planillas Migradas
                            </p>
                        </div>
                    </div>

        <div class="card-body">
        <div class="table-responsive py-4 mt--4">
                <asp:GridView ID="gvMigradas" CssClass="table table-bordered table-hover table-striped table-success" AutoGenerateColumns="false" OnPreRender="gvMigradas_PreRender"   OnRowCommand="gvMigradas_RowCommand" DataKeyNames="cbh_pc_id, nro" runat="server">
                    <Columns>
                        <asp:BoundField DataField="TITULO" HeaderText="MES" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="CANTIDAD" HeaderText="CASOS" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" />
                        <asp:BoundField DataField="TIPO_PLANILLA" HeaderText="TIPO PLANILLA" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                        <asp:TemplateField Visible="false" HeaderText="ELIMINAR" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:LinkButton CommandName="Eliminar" Visible="false" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Eliminar' runat="server" />
<%--                                <asp:LinkButton CommandName="GetPrint" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-facebook btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-print fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Imprimir' runat="server" />--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
        </div>

        </div>
            </div>
        </div>
    </div>
    <div class="row justify-content-center" runat="server" id="divFinalizar" visible="false">
        <div class="card">
            <div class="col-12 card-wrapper">
                <div class="card-body">
                       <asp:LinkButton ID="btnFinalizar" CssClass="btn btn-success btn-block" Text="<i class='fas fa-check'></i> Finalizar Migración" OnClick="btnFinalizar_Click"   Visible="false"   runat="server"  />
                </div>
            </div>
        </div>
    </div>
    <div class="row justify-content-center" id="divIncremento" visible="false" runat="server">
        <div class="col-lg-6 card-body mt--5" runat="server" >
                    <div class="card-header">
                        <div class=" ct-page-title">
                            <h3 class="mb-0">Incremento</h3>
                            <p class="text-sm mb-0">
                               Introduzca el porcentaje
                            </p>
                            <asp:TextBox runat="server"  CssClass="form-control numero" ID="txtIncremento" />
                        </div>
        <asp:RequiredFieldValidator ErrorMessage="Debe Introducir un valor de incremento" ControlToValidate="txtIncremento" runat="server" ValidationGroup="incremento"/>

       <asp:LinkButton ID="btnCalcular" CssClass="btn btn-success btn-block" Text="<i class='fas fa-calculator'></i> Calcular" OnClick="btnCalcular_Click" ValidationGroup="incremento"   runat="server"  />
                    </div>
        </div>
        <div class="col-lg-6 card-body" runat="server" id="divProceso" visible="false">
        <div class="row justify-content-center" >
        <div class="card">
            <div class="card-body">
                <div class="timeline timeline-one-side" data-timeline-content="axis" data-timeline-axis-style="dashed">
                    <div runat="server" id="divProceso1" visible="true" class="timeline-block">
                        <span class="timeline-step badge-info">1</span>
                        <div class="timeline-content d-flex align-items-center">
                            <p class="text-sm mb-0">Proceso 1. Habilitación</p>
                            <div class="text-right ml-auto" >
                                <asp:Button ID="btnProceso1" Text="Ejecutar" OnClick="btnProceso1_Click"  runat="server"  CssClass="btn btn-secondary  btn-round btn-icon ml-3"  />
                            </div>
                        </div>
                    </div>
                    <div runat="server" id="divProceso2" visible="false" class="timeline-block">
                        <span class="timeline-step badge-info">2</span>
                        <div class="timeline-content d-flex align-items-center">
                            <p class="text-sm mb-0">Proceso 2. Cotizables</p>
                            <div class="text-right ml-auto" >
                                <asp:Button ID="btnProceso2" OnClick="btnProceso2_Click"   Text="Ejecutar" runat="server"  CssClass="btn btn-secondary  btn-round btn-icon"  />
                            </div>
                        </div>
                    </div>
                    <div runat="server" id="divProceso3" visible="false" class="timeline-block">
                        <span class="timeline-step badge-info">3</span>
                        <div class="timeline-content d-flex align-items-center">
                            <p class="text-sm mb-0">Proceso 3. Descuentos</p>
                            <div class="text-right ml-auto" >
                                <asp:Button ID="btnProceso3"  OnClick="btnProceso3_Click"  Text="Ejecutar" runat="server"  CssClass="btn btn-secondary  btn-round btn-icon"  />
                            </div>
                        </div>
                    </div>
                    <div runat="server" id="divProceso4" visible="false" class="timeline-block">
                        <span class="timeline-step badge-info">4</span>
                        <div class="timeline-content d-flex align-items-center">
                            <p class="text-sm mb-0">Proceso 4. Líquidos</p>
                            <div class="text-right ml-auto" >
                                <asp:Button ID="btnProceso4" OnClick="btnProceso4_Click"  Text="Ejecutar" runat="server"  CssClass="btn btn-secondary  btn-round btn-icon"  />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        </div>

        </div>
    </div>
</div>
            </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="gvPlanillas" />
                    <asp:AsyncPostBackTrigger ControlID="btnCalcular" />
                    <asp:PostBackTrigger ControlID="gvMigradas" />
                </Triggers> 
            </asp:UpdatePanel>


        <asp:UpdateProgress AssociatedUpdatePanelID="PanelMigradas" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>

</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="Consultores.aspx.cs" Inherits="Administración_Consultores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-blue d-inline-block mb-0">Consultores</h6>
                    </div>
                    <div class="col-lg-6 col-5 text-right">
                    </div>
                </div>
            </div>
        </div>
    </div>
            <asp:UpdatePanel runat="server" ID="PanelConsultores">
                <ContentTemplate>

<div class="container-fluid mt--6"  >
    <div class="row justify-content-center">
        <div class="col-lg-8 card-wrapper">
            <div class="card">
                <div class="card-header border-bottom">
                    <div class="row">
                        <div class="col-8">
                    <div class="ct-page-title">
    <%--                    <h3 class="mb-0">Planilla de Haberes</h3>--%>
                        <h3 class="mb-0">Seleccione el mes:</h3>
                        <asp:DropDownList ID="ddlMesPlanilla" CssClass="form-control select2" OnSelectedIndexChanged="ddlMesPlanilla_SelectedIndexChanged" AppendDataBoundItems="true" runat="server"  AutoPostBack="true"/>
                    </div>
                        </div>
                        <div class="col-4">
                    
                    <div class="ct-page-title">
    <%--                    <h3 class="mb-0">Planilla de Haberes</h3>--%>
                        <h3 class="mb-0">N° de Planilla:</h3>
                        <asp:Label Text="" runat="server" ID="lblNroPlanilla" />
                    </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-4 card-wrapper" runat="server" id="divProceso" visible="false">
        <div class="row justify-content-center" >
        <div class="card">
            <div class="card-body">
                <div class="timeline timeline-one-side" data-timeline-content="axis" data-timeline-axis-style="dashed">
                    <div runat="server" id="divProceso1" visible="false" class="timeline-block">
                        <span class="timeline-step badge-info">1</span>
                        <div class="timeline-content d-flex align-items-center">
                            <p class="text-sm mb-0">Proceso 1. Habilitación</p>
                            <div class="text-right ml-auto" >
                                <asp:Button ID="btnProceso1" Text="Ejecutar" onClick="btnProceso1_Click"  runat="server"  CssClass="btn btn-secondary  btn-round btn-icon ml-3"  />
                            </div>
                        </div>
                    </div>
                    <div runat="server" id="divProceso2" visible="false" class="timeline-block">
                        <span class="timeline-step badge-info">2</span>
                        <div class="timeline-content d-flex align-items-center">
                            <p class="text-sm mb-0">Proceso 2. Cotizables</p>
                            <div class="text-right ml-auto" >
                                <asp:Button ID="btnProceso2"  onClick="btnProceso2_Click" Text="Ejecutar" runat="server"  CssClass="btn btn-secondary  btn-round btn-icon"  />
                            </div>
                        </div>
                    </div>
                    <div runat="server" id="divProceso3" visible="false" class="timeline-block">
                        <span class="timeline-step badge-info">3</span>
                        <div class="timeline-content d-flex align-items-center">
                            <p class="text-sm mb-0">Proceso 3. Descuentos</p>
                            <div class="text-right ml-auto" >
                                <asp:Button ID="btnProceso3"  onClick="btnProceso3_Click" Text="Ejecutar" runat="server"  CssClass="btn btn-secondary  btn-round btn-icon"  />
                            </div>
                        </div>
                    </div>
                    <div runat="server" id="divProceso4" visible="false" class="timeline-block">
                        <span class="timeline-step badge-info">4</span>
                        <div class="timeline-content d-flex align-items-center">
                            <p class="text-sm mb-0">Proceso 4. Líquidos</p>
                            <div class="text-right ml-auto" >
                                <asp:Button ID="btnProceso4"  onClick="btnProceso4_Click" Text="Ejecutar" runat="server"  CssClass="btn btn-secondary  btn-round btn-icon"  />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        </div>

        </div>

    </div>

    <div class="row justify-content-center">
        <div class="col-lg-8 card-wrapper" runat="server" id="divGrilla" visible="false">
        <div class="card">
                    <div class="card-header">
                        <div class=" ct-page-title">
                            <h3 class="mb-0">Consultores</h3>
                            <p class="text-sm mb-0">
                                Casos de consultoría habilitados para el proceso de sueldos
                            </p>
                        </div>
                    </div>

        <div class="card-body">
        <div class="table-responsive py-4">
                <asp:GridView ID="gvFuncionario" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gvFuncionario_PreRender" OnRowCommand="gvFuncionario_RowCommand" DataKeyNames="ad_as_id" runat="server">
                    <Columns>
                        <asp:TemplateField ItemStyle-CssClass="text-center">
                            <HeaderTemplate>
                                <span class="">ELEGIR</span>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <label class="custom-toggle custom-toggle-yout">
                                    <asp:CheckBox ID="chk_select"  runat="server" />
                                    <span class="custom-toggle-slider rounded-circle" data-label-off="No" data-label-on="Si"></span>
                                </label>
                            </ItemTemplate>
                        </asp:TemplateField>
                <asp:BoundField DataField="ad_secuencial" HeaderText="NRO PLANILLA" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" />
                <asp:BoundField DataField="ITEM" HeaderText="ITEM" HeaderStyle-CssClass="text-center" />
                <asp:BoundField DataField="NOMBRE_COMPLETO" HeaderText="NOMBRE" HeaderStyle-CssClass="text-center" />
                <asp:BoundField DataField="ca_basico_calculado" DataFormatString="{0:C2}" HeaderText="BASICO CALCULADO" HeaderStyle-CssClass="text-center" />
<%--                        <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:LinkButton CommandName="GetDetail" Visible="false" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-vimeo btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-file fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Vista Previa' runat="server" />
                                <asp:LinkButton CommandName="GetPrint" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-facebook btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-print fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Imprimir' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>
        </div>
        </div>

        </div>
        </div>
        <div class="col-lg-8 card-wrapper"></div>
    </div>



</div>            </ContentTemplate>
            </asp:UpdatePanel>

    <asp:UpdateProgress AssociatedUpdatePanelID="PanelConsultores" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>


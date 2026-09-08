<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="PlanillaAdicional2.aspx.cs" Inherits="Administración_PlanillaAdicional2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
    <div class="container-fluid">
        <div class="header-body">
            <div class="row align-items-center py-4">
                <div class="col-lg-6 col-7">
                    <h6 class="h2 text-light d-inline-block mb-0">Planilla Adicional</h6>
                </div>
                <div class="col-lg-6 col-5 text-right">
                </div>
            </div>
        </div>
    </div>
</div>

    <asp:UpdatePanel runat="server" ID="PanelItems">
    <ContentTemplate>
            
    <div class="container-fluid">
        <div class="row justify-content-center" style="margin-top:-5em">
           <div class="col-lg-12 card-wrapper" runat="server" id="PanelBusqueda" visible="true">
                <div class="card">
                <div class="modal-body">
                   <div class="row">
                        <div class="form-group col-md-12">
                            <label class="form-control-label" for="Ddl_per_tipo_doc">Mes para la Planilla Adicional: </label>
                            <asp:DropDownList ID="ddlMes" AutoPostBack="true" OnSelectedIndexChanged="ddlMes_SelectedIndexChanged" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                        </div>
                   </div>
                </div>
                    <div class="card-header" style="margin-top:-2em">
                        <div class=" ct-page-title">
                            <h3 class="mb-0">Búsqueda de casos: </h3>

                        </div>
                    </div>
                    <div class="card-body">
                        <div class="row">
                        <div class="col-sm-6 col-md-5">
                            <div class="form-group" style="margin-top:-1.5em">
                                <label class="form-control-label">CI</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text border-default-2"><i class="fas fa-edit"></i></span>
                                    </div>
                                    <asp:TextBox ID="txt_ci" class="form-control border-default-2 numero"  runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="pl-lg-4" style="margin-top:-1.5em">
                                    <div class="form-group text-right">
                                        <label class="form-control-label">&nbsp</label>
                                        <asp:LinkButton ID="btnFiltrar" OnClick="btnFiltrar_Click" CssClass="btn btn-vimeo btn-block" Text="<i class='fas fa-search'></i> Buscar"   runat="server" />
                                    </div>
                        </div>

                        </div>

        <div id="grillaItems"  visible="false" runat="server" style="margin-top:-1em">
        <!-- Card header -->
        <div class="card-header d-flex align-items-center">
            <div class="d-flex align-items-center">
                <div class="text-dark font-weight-600 text-sm">
                    <h3 class="mb-0">Seleccione la asignación que irá a la planilla adicional</h3>
                </div>
            </div>
        </div>
        <div class="card-body">
            <div class="table-responsive py-4" style="margin-top:-2em" >
                        <asp:GridView ID="gvItems" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false"  OnRowCommand="gvItems_RowCommand" DataKeyNames="as_id" runat="server">
                            <Columns>
                                <asp:BoundField DataField="item" HeaderText="ITEM" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="as_fecha_inicio" DataFormatString="{0:dd/MM/yyyy}" HeaderText="INICIO" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="as_fecha_fin" DataFormatString="{0:dd/MM/yyyy}" HeaderText="FIN" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="nombreFunc" HeaderText="NOMBRE" HeaderStyle-CssClass="text-center" />
                                <asp:BoundField DataField="eo_descripcion" HeaderText="UNIDAD" HeaderStyle-CssClass="text-center" />
                                <asp:TemplateField HeaderText="Elegir" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:LinkButton CommandName="Elegir"  CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-vimeo btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-check fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Elegir' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
            </div>
        </div>
    </div>
            <div id="grillaAdicionales" visible="false" runat="server" style="margin-top:-3.5em" >
        <!-- Card header -->


        <div class="card-body">
            <div class="table-responsive py-4"  >

        <div class="card-header d-flex align-items-center">

            <div class="d-flex align-items-center">
                <div class="text-dark font-weight-600 text-sm">
                    <h3 class="mb-0">Casos Añadidos a Planilla Adicional</h3>
                </div>
            </div>
        </div>        
        <asp:GridView ID="gvAdicionales" OnRowCommand="gvAdicionales_RowCommand"   CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false"   DataKeyNames="ad_as_id, ad_pc_id, ad_secuencial" runat="server">
            <Columns>
                <asp:BoundField DataField="ad_secuencial" HeaderText="NRO PLANILLA" HeaderStyle-CssClass="text-center" />
                <asp:BoundField DataField="ITEM" HeaderText="ITEM" HeaderStyle-CssClass="text-center" />
                <asp:BoundField DataField="NOMBRE_COMPLETO" HeaderText="NOMBRE" HeaderStyle-CssClass="text-center" />
                <asp:BoundField DataField="ca_basico_calculado" DataFormatString="{0:C2}" HeaderText="BASICO CALCULADO" HeaderStyle-CssClass="text-center" />
                <asp:TemplateField HeaderText="Eliminar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                    <ItemTemplate>
                        <asp:LinkButton CommandName="Eliminar"  CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Eliminar' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>


        <div >
                    <div class="form-group text-right">
                        <label class="form-control-label">&nbsp</label>
                        <asp:LinkButton ID="btnProcesar"  OnClick="btnProcesar_Click" CssClass="btn btn-vimeo btn-block" Text="<i class='fas fa-search'></i> Procesar"   runat="server" />
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
                        <asp:AsyncPostBackTrigger ControlID="ddlMes" EventName="SelectedIndexChanged" />
                    </Triggers>

                </asp:UpdatePanel>

    <asp:UpdateProgress AssociatedUpdatePanelID="PanelItems" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>


</asp:Content>


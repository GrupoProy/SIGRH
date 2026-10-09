<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ListaFrecuencia.aspx.cs" Inherits="Precontratacion_Frecuencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Creación de Frecuencia(s)</h6>
                    </div>
             
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid mt--6">
        <div class="row">
            <div class="col">
                <div class="card">
                    <div class="card-header d-flex align-items-center">
                        <div class="d-flex align-items-center">
                            <div class="text-dark font-weight-600 text-sm">
                                <div class=" ct-page-title">
                                    <h3 class="mb-0">Lista de Categorías</h3>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <p class="text-sm mb-0">
                                                <asp:Literal ID="ltl_desc_gestion" Text="" runat="server" />
                                            </p>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <!-- Form groups used in grid -->
                        <asp:UpdatePanel ID="panelBuscar" runat="server">
                            <ContentTemplate>
                                <asp:Panel DefaultButton="btn_buscar_categorias" runat="server">

                                    <div class="row">
                                        <div class="col-sm-6 col-md-2">
                                            <div class="form-group">
                                                <label class="form-control-label" for="example4cols1Input">DA</label>
                                                <small>(Dirección Administrativa)</small>
                                                <div class="input-group input-group-merge">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text"><i class="fas fa-layer-group"></i></span>
                                                    </div>
                                                    <asp:TextBox ID="txt_da" class="form-control" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6 col-md-2">
                                            <div class="form-group">
                                                <label class="form-control-label" for="example4cols2Input">UE</label>
                                                <small>(Unidad Ejecutora)</small>
                                                <div class="input-group input-group-merge">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text"><i class="fas fa-layer-group"></i></span>
                                                    </div>
                                                    <asp:TextBox ID="txt_ue" class="form-control" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6 col-md-2">
                                            <div class="form-group">
                                                <label class="form-control-label" for="example4cols3Input">Prog</label>
                                                <small>(Programa) </small>
                                                <div class="input-group input-group-merge">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text"><i class="fas fa-layer-group"></i></span>
                                                    </div>
                                                    <asp:TextBox ID="txt_prog" class="form-control" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6 col-md-2">
                                            <div class="form-group">
                                                <label class="form-control-label" for="example4cols3Input">Proy</label>
                                                <small>(Proyecto)</small>
                                                <div class="input-group input-group-merge">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text"><i class="fas fa-layer-group"></i></span>
                                                    </div>
                                                    <asp:TextBox ID="txt_proy" class="form-control" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6 col-md-2">
                                            <div class="form-group">
                                                <label class="form-control-label" for="example4cols3Input">Act</label>
                                                <small>(Actividad)</small>
                                                <div class="input-group input-group-merge">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text"><i class="fas fa-layer-group"></i></span>
                                                    </div>
                                                    <asp:TextBox ID="txt_act" class="form-control" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6 col-md-2">
                                            <div class="form-group">
                                                <label class="form-control-label" for="example4cols3Input">&nbsp</label>
                                                <asp:LinkButton ID="btn_buscar_categorias" CssClass="btn btn-info btn-block" Text="<i class='fas fa-search'></i> Buscar" OnClick="btn_buscar_categorias_Click" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="table-responsive py-4" id="grillaCategorias" style="display: none">
                        <asp:UpdatePanel ID="up_gv_items" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gv_categorias" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_categorias_PreRender" OnRowCommand="gv_categorias_RowCommand" DataKeyNames="cp_id" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="cp_da" HeaderText="DA" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" />
                                        <asp:BoundField DataField="cp_ue" HeaderText="UE" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" />
                                        <asp:BoundField DataField="cp_programa" HeaderText="PROG" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" />
                                        <asp:BoundField DataField="cp_proyecto" HeaderText="PROY" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" />
                                        <asp:BoundField DataField="cp_actividad" HeaderText="ACT" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" />
                                        <asp:BoundField DataField="cp_descripcion" HeaderText="DESCRIPCIÓN PRESUPUESTO" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-left" />
                                        <asp:BoundField DataField="cp_fuente" HeaderText="FUENTE" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" />
                                        <asp:BoundField DataField="cp_organismo" HeaderText="ORIGEN" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" />
                                        <asp:BoundField DataField="cod_poa" HeaderText="COD POA" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" />
                                        <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                     <asp:LinkButton CommandName="GetAssign" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn bg-gradient-inst text-white btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-share fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Ver Categoría' runat="server" />
                                    
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

    </div>
     <asp:UpdateProgress ID="up" AssociatedUpdatePanelID="panelBuscar" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
         <asp:UpdateProgress ID="up1" AssociatedUpdatePanelID="up_gv_items" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>


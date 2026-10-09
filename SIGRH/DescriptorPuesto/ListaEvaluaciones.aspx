<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ListaEvaluaciones.aspx.cs" Inherits="DescriptorPuesto_ListaEvaluaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">LISTA EVALUACIONES</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid mt--6">
        <div class="card mb-4">
            <div class="card-header">
                <div class=" ct-page-title">
                    <h2 class="mb-0">DESCRIPTOR PUESTO</h2>
                </div>
                <div class=" ct-page-title text-center ">
                        <h1 class="mb-0"> <i class="fa fa-folder-open"></i>//</h1>
                </div>
            </div>

         <ContentTemplate>
        <asp:GridView ID="GridView3" CssClass="table table-bordered table-hover table-striped" OnRowCommand="GridView3_RowCommand" DataKeyNames="descrip_pu_id" AutoGenerateColumns="false" runat="server">
            <Columns>
                <asp:BoundField DataField="per_nombres" HeaderText="nombres" />
                <asp:BoundField DataField="per_ap_paterno" HeaderText="apellidopaterno" />
                <asp:BoundField DataField="per_ap_materno" HeaderText="apellidomaterno" />
                <asp:BoundField DataField="p_descripcion" HeaderText="puesto" />
                 <asp:BoundField DataField="descrip_pu_objetivo" HeaderText="objetivo" />
                <asp:TemplateField HeaderText="Controles" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                    <ItemTemplate>
                        <asp:LinkButton CommandName="getEvaluar"  CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-warning btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-edit'></i></span>" data-toggle='tooltip' data-placement='top' title='Evaluar' runat="server" />
                      
                       
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:HiddenField ID="h_r_id" runat="server" />
        <asp:HiddenField ID="aux_accion" runat="server" />
        <asp:HiddenField ID="h_numE" runat="server" />
    </ContentTemplate>

        </div>
      </div> 



</asp:Content>


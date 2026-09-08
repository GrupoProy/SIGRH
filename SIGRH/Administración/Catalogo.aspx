<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="Catalogo.aspx.cs" Inherits="Administración_Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Registro Catálogo</h6>
                    </div>
                    <div class="col-lg-6 col-5 text-right">
                    </div>
                </div>
            </div>
        </div>
    </div>


    <asp:UpdatePanel runat="server" ID="PanelCatalogo">
        <ContentTemplate>
    <div class="container-fluid">
        <div class="row justify-content-center" style="margin-top:-5em">
           <div class="col-lg-12 card-wrapper" runat="server" id="PanelBusqueda" visible="true">
                <div class="card">
                    <div class="card-body">
        <!-- cat_tabla -->
        <div class="form-group">
                <label class="form-control-label" for="Txt_per_nombres">Tipo de Catálogo</label>
                <asp:DropDownList ID="ddl_cat_tabla" OnSelectedIndexChanged="ddl_cat_tabla_SelectedIndexChanged" AutoPostBack="true"  CssClass ="form-control select2"  AppendDataBoundItems="true" runat="server" />
                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_cat_tabla"  ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
        </div>
    <!-- cat_descripcion -->
        <div class="form-group">
            <label class="form-control-label" for="Txt_per_nombres">Descripción</label>
            <div class="input-group input-group-merge">
                <div class="input-group-prepend">
                    <span class="input-group-text">
                        <i class="fas fa-edit"></i>
                    </span>
                </div>
                <asp:TextBox ID="txt_cat_descripcion" CssClass="form-control letras" runat="server" />
            </div>
            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_cat_descripcion" ValidationGroup="add" Display="Dynamic" runat="server" />
        </div>
    <!-- cat_abreviacion -->
        <div class="form-group">
            <label class="form-control-label" for="Txt_per_nombres">Abreviación</label>
            <div class="input-group input-group-merge">
                <div class="input-group-prepend">
                    <span class="input-group-text">
                        <i class="fas fa-edit"></i>
                    </span>
                </div>
                <asp:TextBox ID="txt_cat_abreviacion" CssClass="form-control letras" runat="server" />
            </div>
            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_cat_descripcion" ValidationGroup="add" Display="Dynamic" runat="server" />
        </div>
        <div class="form-group" runat="server" id="divDpto" >
                <label class="form-control-label" for="Txt_per_nombres">Dpto.-Provincia</label>
                <asp:DropDownList ID="ddlProvincia"  AutoPostBack="true"  CssClass ="form-control select2"  AppendDataBoundItems="true" runat="server" />
        </div>
        <div class="form-group">
            <asp:LinkButton ID="btnRegistrarCatalogo" CssClass="btn btn-success btn-block" Text="<i class='fas fa-edit'></i> Registrar" OnClick="btnRegistrarCatalogo_Click" runat="server" />
        </div>
                
    <div class="card">
        <asp:GridView ID="gvCatalogo" CssClass="table table-bordered table-hover table-striped"    runat="server"></asp:GridView>
    </div>
                        </div>
                  </div>
               </div>
        </div>
    </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddl_cat_tabla" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="btnRegistrarCatalogo" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress AssociatedUpdatePanelID="PanelCatalogo" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>                
</asp:Content>


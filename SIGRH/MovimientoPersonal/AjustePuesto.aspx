<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="AjustePuesto.aspx.cs" Inherits="MovimientoPersonal_AjustePuesto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Ajuste de Puestos</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid mt--6">
        <div class="row">
            <div class="col-lg-12">
                <div class="card-wrapper">
                    <div class="card">
                        <div class="card-header">
                            <div class="row align-items-center">
                                <div class="col-12">
                                    <div class=" ct-page-title">
<%--                                        <h3 class="mb-0">Búsqueda de Funcionario</h3>--%>
                                        <p class="text-sm mb-0">
                                           Utilice el Buscador para encontrar el funcionario al cual se ajustará el Puesto.                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card-body">
                            <asp:UpdatePanel ID="up_GvItems" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gv_puestos" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_puestos_PreRender" OnRowCancelingEdit="gv_puestos_RowCancelingEdit" OnRowEditing="gv_puestos_RowEditing" OnRowUpdating="gv_puestos_RowUpdating"  DataKeyNames="p_id, as_id, per_id" runat="server">
                                        <Columns>
                                            <asp:TemplateField >
                                                <ItemTemplate>
                                                    <asp:Button ID="btn_Edit" runat="server" Text="Editar" CssClass="btn btn-info" CommandName="Edit" />
                                                </ItemTemplate>
                                                <EditItemTemplate>  
                                                    <asp:Button ID="btn_Update" runat="server" Text="Actualizar" CssClass="btn btn-success" CommandName="Update"/>  
                                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancelar" CssClass="btn btn-warning" CommandName="Cancel"/>  
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="COD.FUN">  
                                                <ItemTemplate>  
                                                    <asp:Label ID="lbl_codfun" runat="server" Text='<%#Eval("per_id") %>'></asp:Label>  
                                                </ItemTemplate>  
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="CI">  
                                                <ItemTemplate>  
                                                    <asp:Label ID="lbl_ci" runat="server" Text='<%#Eval("per_num_doc") %>'></asp:Label>  
                                                </ItemTemplate>  
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PATERNO">  
                                                <ItemTemplate>  
                                                    <asp:Label ID="lbl_paterno" runat="server" Text='<%#Eval("per_ap_paterno") %>'></asp:Label>  
                                                </ItemTemplate>  
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="MATERNO">  
                                                <ItemTemplate>  
                                                    <asp:Label ID="lbl_materno" runat="server" Text='<%#Eval("per_ap_materno") %>'></asp:Label>  
                                                </ItemTemplate>  
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="NOMBRES">  
                                                <ItemTemplate>  
                                                    <asp:Label ID="lbl_nombres" runat="server" Text='<%#Eval("per_nombres") %>'></asp:Label>  
                                                </ItemTemplate>  
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="UBICACION">  
                                                <ItemTemplate>  
                                                    <asp:Label ID="lbl_ubicacion" runat="server" Text='<%#Eval("eo_descripcion") %>'></asp:Label>  
                                                </ItemTemplate>  
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PUESTO">  
                                                <ItemTemplate>  
                                                    <asp:Label ID="lbl_puesto" runat="server" Text='<%#Eval("p_descripcion") %>'></asp:Label>  
                                                </ItemTemplate>  
                                                <EditItemTemplate>  
                                                    <asp:TextBox ID="txt_puesto" runat="server" Text='<%#Eval("p_descripcion") %>'></asp:TextBox>  
                                                </EditItemTemplate>  
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
    </div>
    <asp:UpdateProgress AssociatedUpdatePanelID="up_GvItems" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>

</asp:Content>


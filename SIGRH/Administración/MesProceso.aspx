<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="MesProceso.aspx.cs" Inherits="Administración_MesProceso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Mes Proceso</h6>

                    </div>
                    <div class="col-lg-6 col-5 text-right">
                    </div>

                </div>
            </div>
        </div>
    </div>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>   
    <div class="container-fluid">
        <div class="row justify-content-center" style="margin-top:-5em">
                    <div class="card">
                    <div class="card-header ">
                        <div class=" ct-page-title">
                            <h3 class="mb-0">Mes Actual de Proceso:</h3>
                            <asp:Label ID="txt_pc_id" Text="" runat="server"  />
                        </div>
                    </div>
                <div class="modal-body">
                   <div class="row">
                        <div class="form-group col-md-12">
                            <label class="form-control-label" for="Ddl_per_tipo_doc">Actualizar a:</label>
                            <asp:DropDownList ID="ddlMes" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                        </div>
                   </div>
                    <div class="modal-footer border-top">
                        <asp:LinkButton ID="btnActualizarMesProceso" CssClass="btn btn-success" Text="<i class='fas fa-check'></i> Guardar" OnClick="btnActualizarMesProceso_Click"   runat="server" />
                        <asp:LinkButton ID="btnCancelar" CssClass="btn btn-google-plus" Text="<i class='fas fa-times'></i> Cancelar" OnClick="btnCancelar_Click"   runat="server" />
                    </div>
                </div>

        </div>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>


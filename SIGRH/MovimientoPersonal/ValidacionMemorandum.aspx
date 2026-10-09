<%@ Page Title="Validación de Memorándum" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ValidacionMemorandum.aspx.cs" Inherits="MovimientoPersonal_ValidacionMemorandum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Validación de Memorándum</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid mt--6">
        <div class="row">
            <div class="col-lg-7">
                <div class="card-wrapper">
                    <!-- Form controls -->
                    <div class="card">
                        <!-- Card header -->
                        <div class="card-header">
                            <div class=" ct-page-title">
                                <h3 class="mb-0">Registrar código QR</h3>
                                <p class="text-sm mb-0">Inserte el código QR en la caja de texto y valide. </p>
                            </div>
                        </div>
                        <!-- Card body -->
                        <asp:Panel runat="server" DefaultButton="btn_validar">
                            <div class="card-body">
                                <div class="media align-items-center">
                                    <img alt="Image placeholder" class="avatar avatar-xl img-fluid rounded mr-4" src="../Content/img/icon_qr.png">
                                    <div class="media-body">
                                        <div class="form-group row">
                                            <label for="example-text-input" class="col-md-2 col-form-label form-control-label">Código:</label>
                                            <div class="col-md-10">
                                                <asp:TextBox ID="txt_qr" CssClass="form-control" placeholder="Codigo QR Memorándum" runat="server" />
                                            </div>
                                        </div>
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>


                                                <div class="form-group row">
                                                    <label for="example-text-input" class="col-md-2 col-form-label form-control-label">Asignado a:</label>
                                                    <div class="col-md-10">
                                                        <asp:TextBox ID="txt_funcionario" CssClass="form-control" runat="server" disabled />
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label for="example-text-input" class="col-md-2 col-form-label form-control-label">Tenor asignado:</label>
                                                    <div class="col-md-10">
                                                        <asp:TextBox ID="txt_tenor_asignado" CssClass="form-control" runat="server" disabled />
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-9">
                                        <div class="form-group text-right">
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group text-right">
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <asp:LinkButton ID="btn_validar" CssClass="btn btn-vimeo btn-block" Text="<i class='fas fa-check'></i> Validar" OnClick="btn_validar_Click" runat="server" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>

                </div>
            </div>
            <div class="col-lg-5">
                <div class="card-wrapper">
                    <!-- Sizes -->
                    <div class="card">
                        <!-- Card header -->
                        <div class="card-header">
                            <div class=" ct-page-title">
                                <h3 class="mb-0">Memorándum validado por:</h3>

                            </div>
                        </div>
                        <div class="table-responsive py-4">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gv_seguimiento" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_seguimiento_PreRender" DataKeyNames="sm_qr" runat="server">
                                        <Columns>
                                            <asp:BoundField DataField="rol_descripcion" HeaderText="Validado por" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="sm_fecha_creacion" HeaderText="Fecha Validación " HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
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
</asp:Content>


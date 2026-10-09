<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="RegistroPuesto.aspx.cs" Inherits="Configuraciones_RegistroPuesto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Registro de Puesto</h6>

                    </div>
                    <div class="col-lg-6 col-5 text-right">
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid mt--6">
        <div class="row justify-content-center">
            <div class="col-lg-8 card-wrapper ct-example">
                <div class="card">
                    <div class="card-header ">
                        <div class=" ct-page-title">
                            <h3 class="mb-0">Formulario de Puesto mediante Escala Salarial </h3>
                            <p class="text-sm mb-0">
                                Llene los datos del formulario para realizar el registro.
                            </p>
                        </div>
                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="row">

                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label class="form-control-label">Escala salarial</label>
                                            <asp:DropDownList ID="ddl_escala_salarial" AppendDataBoundItems="true" CssClass="form-control select2" OnSelectedIndexChanged="ddl_escala_salarial_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_escala_salarial" Display="Dynamic" ValidationGroup="addPuesto" InitialValue="0" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label class="form-control-label">Descripción Puesto</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text border-default-2"><i class="fas fa-edit"></i></span>
                                                </div>
                                                <asp:TextBox ID="txt_descripcion_puesto" class="form-control border-default-2 " runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_descripcion_puesto" Display="Dynamic" ValidationGroup="addPuesto" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group text-right">
                                            <label class="form-control-label">&nbsp</label>
                                            <asp:LinkButton ID="btn_adicionar" CssClass="btn btn-vimeo btn-block" Text="<i class='fas fa-plus'></i> Adicionar" ValidationGroup="addPuesto" OnClick="btn_adicionar_Click"  runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="table-responsive py-4">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gv_puestos" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_puestos_PreRender" DataKeyNames="epu_id" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="es_descripcion" HeaderText="Escala salarial" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="p_descripcion" HeaderText="Puesto" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" />

                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div id="no_existe_puestos" class="card-body" runat="server">
                                <div class="row">
                                    <div class="col-md-12">
                                        <p class="text-sm grid-notify-success">No existen puestos registrados. </p>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

    </div>
    <div class="modal fade" id="adicionarPuesto" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
        <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
            <div class="modal-content bg-gradient-dark6">
                <div class="modal-header">
                </div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div class="py-3 text-center">
                                <i class="ni ni-books ni-3x"></i>
                                <h4 class="heading text-dark mt-4">¿Está seguro de registrar el Puesto?</h4>
                            </div>
                        </div>
                        <div class="form-group text-center">
                            <asp:LinkButton ID="btn_adicionar_puesto" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btn_adicionar_puesto_Click" OnClientClick="MostrarMascara(true);"  runat="server" />
                            <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>


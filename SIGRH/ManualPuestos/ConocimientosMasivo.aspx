<%@ Page Title="Manual de Puestos" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ConocimientosMasivo.aspx.cs" Inherits="ManualPuestos_frmPuestosCM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header bg-org2 pb-6" style="min-height: 170px; background-image: url(../Content/img/fondo_uap1.png); background-size: cover; background-position: center top;">
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h4 class="h2 text-bluedark d-inline-block mb-0"><i class="fas fa-table mr-3"></i>Cargado Masivo de Conocimientos Complementarios</h4>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page content -->
    <div class="container-fluid mt--6">
        <div class="card mb-4">
            <!-- Card header -->
            <div class="card-header">
                <h3 class="mb-0">Búsqueda </h3>
                <p class="text-sm mb-0">
                    Debe usar al menos uno de los filtros mostrados en la parte inferior para elegir los item a los cuales se hara el cargado masivo de la información.
                </p>
            </div>
            <!-- Card body -->
            <asp:panel runat="server" defaultbutton="btnFiltrar">
                <div class="card-body">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div class="form-group">
                                            <label class="form-control-label" for="exampleFormControlSelect1">Cargo</label>
                                            <asp:DropDownList ID="ddl_cargo" AppendDataBoundItems="true" CssClass="form-control select2"  runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div class="form-group">
                                            <label class="form-control-label" for="exampleFormControlSelect1">Unidad Organizacional</label>
                                            <asp:DropDownList ID="ddl_unidad_organizacional" AppendDataBoundItems="true" CssClass="form-control select2"  runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row"  hidden="true">
             
                                <div class="col-md-6" hidden="true">
                                    <div class="form-group">
                                        <div class="form-group">
                                            <label class="form-control-label" for="exampleFormControlSelect1">Unidad Ejecutora</label>
                                            <asp:DropDownList ID="ddl_unidad_ejecutiva" AppendDataBoundItems="true" CssClass="form-control select2"  runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                   <div class="col-md-6"  hidden="true">
                                    <div class="form-group">
                                        <div class="form-group">
                                            <label class="form-control-label" for="exampleFormControlSelect1">Dirección Administrativa</label>
                                            <asp:DropDownList ID="ddl_direccion_administrativa" AppendDataBoundItems="true" CssClass="form-control select2"  runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="row">
                        <div class="col-md-8">
                            <div class="form-group text-right">
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group text-right">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="btnLimpiar" CssClass="btn btn-warning btn-block" Text="<i class='fas fa-eraser'></i> Limpiar" OnClick="btnLimpiar_Click" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group text-right">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="btnFiltrar" CssClass="btn btn-vimeo btn-block" Text="<i class='fas fa-search'></i> Buscar" OnClick="btnFiltrar_Click" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:panel>
        </div>
        <div class="card" id="descripcionConocimiento" style="display: none;">
            <div class="card-body">
                <div class="row">
                    <div class="col-md-12 text-left">
                        <div class="form-group">
                            <label class="form-control-label" for="exampleFormControlSelect1">Descripción Conocimientos Complementarios</label>
                            <asp:dropdownlist id="ddl_conocimineto_add" appenddatabounditems="true" cssclass="form-control select2" runat="server"></asp:dropdownlist>
                            <asp:requiredfieldvalidator cssclass="text-danger display-5" errormessage="(*) Campo Obligatorio" controltovalidate="ddl_conocimineto_add" validationgroup="val_add_conocimiento" initialvalue="0" runat="server" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-10">
                        <div class="form-group text-right">
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group text-right">
                            <asp:updatepanel runat="server">
                                <ContentTemplate>
                                    <asp:LinkButton ID="modalGuardarConocimientoCM" CssClass="btn btn-success btn-block" ValidationGroup="add" Text="<i class='fas fa-save mr-2'></i>Guardar " OnClick="modalGuardarConocimientoCM_Click" runat="server" />
                                    <div class="modal fade" id="modalGuardarCM" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                                        <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                                            <div class="modal-content bg-gradient-warning">
                                                <div class="modal-header">

                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                        <span aria-hidden="true">×</span>
                                                    </button>
                                                </div>
                                                <div class="modal-body">
                                                    <div class="py-3 text-center">
                                                        <i class="ni ni-single-copy-04 ni-3x"></i>
                                                        <h4 class="heading mt-4">¿Esta seguro de guardar el conocimiento complementario a los items mostrados?</h4>
                                                    </div>
                                                </div>
                                                <div class="form-group text-center">
                                                    <asp:LinkButton ID="btnGuardarCM" CssClass="btn btn-success" Text="<i class='fas fa-check'></i>  Aceptar" OnClick="btnGuardarCM_Click" runat="server" ValidationGroup="add" />
                                                    <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:updatepanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="card" id="grillaTareasBlock" style="display: none;">
            <!-- Card header -->
            <div class="card-header">
                <div class="row">
                    <div class="col-6">
                        <h3 class="mb-0">Resultados de la Búsqueda</h3>
                    </div>
                </div>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:updatepanel runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="gvPuestoCM" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gvPuestoCM_PreRender" OnRowCommand="gvPuestoCM_RowCommand" DataKeyNames="idFicha" runat="server">
                                <Columns>
                                    <asp:BoundField DataField="item" HeaderText="Ítem" />
                                    <asp:BoundField DataField="puesto" HeaderText="Puesto" />
                                    <asp:BoundField DataField="cargo" HeaderText="Cargo" />
                                    <asp:BoundField DataField="est_org" HeaderText="Unidad Organizacional" />
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:updatepanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCheque.master" AutoEventWireup="true" CodeFile="ChequeDetallado.aspx.cs" Inherits="Cheques_ChequeDetallado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div class="container-fluid mt--7">
        <div class="ct-example  card" style="padding-bottom: unset">
            <div class="card-header">
                <h3 class="h2 text d-inline-block mb-0"><i class="fas fa-id-card-alt mr-2"></i>Detalles de Cheque</h3>
            </div>
            <div class="card-body">
                <div class="media align-items-center">
                    <div class="media-body">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <h6 class="heading-small text-muted">Datos</h6>
                                <div class="row">
                                    <div class="col-lg-2">
                                        <div class="content-text-label">Preventivo</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_preventivo" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="form-group">
                                            <label class="form-control-label">Compromiso</label>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_comp" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="form-group">
                                            <label class="form-control-label">Devengado</label>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_deve" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <div class="content-text-label"><i class="far fa-list-alt"></i>&nbsp Nombre del Proceso</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_nombre_proce" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="content-text-label">Nro Cheque</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_nro_cheque" runat="server" />
                                        </div>
                                    </div>
                                    
                                </div>
                                <hr class="my-2">
                                <div class="row">
                                    <div class="col-lg-2">
                                        <div class="content-text-label"><i class="far fa-calendar-alt"></i>&nbsp Fecha Adjudicacion</div>
                                        <div class="h5 font-weight-400 content-text content-text">
                                            <asp:Literal ID="ltl_adju_fech" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="content-text-label">Estado del Proceso</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_proce_esta" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="content-text-label"><i class="far fa-list-alt"></i>&nbsp Descripcion del Proceso</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_proce_descri" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="content-text-label">Benef_Razon_Social</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_ben_raz" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="content-text-label"><i class="far fa-calendar-alt"></i>&nbsp Fecha Inicio del Proceso</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_proc_fech_ini" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <i class="far fa-calendar-alt"></i>&nbsp<label class="form-control-label">Gestion</label>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_gesti" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            


            <div class="tab-content">
                <div id="nav-pills-tabs-component" class="tab-pane tab-example-result fade active show" role="tabpanel" aria-labelledby="nav-pills-tabs-component-tab">
                    <div class="nav-wrapper">
                        <ul class="nav nav-pills nav-fill flex-column flex-md-row" id="tabs-icons-text" role="tablist">
                            <li class="nav-item">
                                <a class="nav-link mb-sm-3 mb-md-0 active" id="tabs-icons-text-1-tab" data-toggle="tab" href="#tabs-icons-text-1" role="tab" aria-controls="tabs-icons-text-1" aria-selected="true"><i class="fas fa-address-card mr-2"></i>DETALLES DE CHEQUE</a>
                            </li>
                        </ul>
                    </div>
                    <div class="card shadow">
                        <div class="card-body">
                            <div class="tab-content" id="myTabContent">
                                <div class="tab-pane fade show active" id="tabs-icons-text-1" role="tabpanel" aria-labelledby="tabs-icons-text-1-tab">

                                    <div class="row">
                                        <div class="col-xl-12">
                                            <div class="card-body" style="padding-top: unset;">
                                               
                                                <asp:UpdatePanel ID="up_guardar_per_dom" runat="server">
                                                    <ContentTemplate>
                                                        <div class="row">
                                                            <div class="col-sm-6 col-md-3">
                                                                <div class="form-group">
                                                                    <i class="fas fa-user-alt"></i>&nbsp<label class="form-control-label">Nombre del solicitante</label>
                                                                    <div class="h5 font-weight-400 content-text">
                                                                        <asp:Literal ID="ltl_soli_nom" runat="server" />
                                                                        </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-6 col-md-3">
                                                                <div class="form-group">
                                                                    <i class="fas fa-id-card-alt"></i>&nbsp<label class="form-control-label">Cargo del solicitante</label>
                                                                    <div class="h5 font-weight-400 content-text">
                                                                        <asp:Literal ID="ltl_soli_carg" runat="server" />
                                                                        </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-6 col-md-3">
                                                                <div class="form-group">
                                                                    <i class="fas fa-id-card-alt"></i>&nbsp<label class="form-control-label">Puesto del solicitante</label>
                                                                    <div class="h5 font-weight-400 content-text">
                                                                        <asp:Literal ID="ltl_solpu" runat="server" />
                                                                        </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <div class="form-group">
                                                                    <label class="form-control-label text">Solicitante id</label>
                                                                    <div class="h5 font-weight-400 content-text">
                                                                        <asp:Literal ID="ltl_idsol" runat="server" />
                                                                </div>
                                                                    </div>
                                                            </div>
                                                        </div>

                                                        <hr class="my-2">

                                                        <div class="row">
                                                            <div class="col-md-3">
                                                                <div class="form-group">
                                                                    <i class="far fa-money-bill-alt"></i>&nbsp<label class="form-control-label">Monto Adjudicacion</label>
                                                                    <div class="h5 font-weight-400 content-text">
                                                                        <asp:Literal ID="ltl_adj_mont" runat="server" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-6 col-md-3">
                                                                <div class="form-group">
                                                                    <label class="form-control-label">Factura</label>
                                                                    <div class="h5 font-weight-400 content-text">
                                                                        <asp:Literal ID="ltl_factu" runat="server" />
                                                                        </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-6 col-md-3">
                                                                <div class="form-group">
                                                                    <i class="far fa-calendar-alt"></i>&nbsp<label class="form-control-label">Fecha pago de factura</label>
                                                                    <div class="h5 font-weight-400 content-text">
                                                                        <asp:Literal ID="ltl_pag_fech_fact" runat="server" />
                                                                        </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <div class="form-group">
                                                                    <label class="form-control-label text">Descripcion de pago</label>
                                                                    <div class="h5 font-weight-400 content-text">
                                                                        <asp:Literal ID="ltl_pagdes" runat="server" />
                                                                        </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <hr class="my-2">
                                                        <div class="row">
                                                            <div class="col-md-3">
                                                                <div class="form-group">
                                                                    <i class="far fa-money-bill-alt"></i>&nbsp<label class="form-control-label text">Pago_monto</label>
                                                                    <div class="h5 font-weight-400 content-text">
                                                                        <asp:Literal ID="ltl_pagmon" runat="server" />
                                                                        </div>
                                                                </div>
                                                            </div>
                                                            
                                                            <div class="col-md-3">
                                                                <div class="form-group">
                                                                    <label class="form-control-label">Nro contrato</label>
                                                                    <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_numcont" runat="server" />
                                                                        </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <div class="form-group">
                                                                    <i class="far fa-calendar-alt"></i>&nbsp<label class="form-control-label text">fecha pago</label>
                                                                    <div class="h5 font-weight-400 content-text">
                                                                        <asp:Literal ID="ltl_fechpago" runat="server" />
                                                                        </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-6 col-md-3">
                                                                <div class="form-group">
                                                                    <label class="form-control-label">Benefi. representacion legal</label>
                                                                    <div class="h5 font-weight-400 content-text">
                                                                        <asp:Literal ID="ltl_ben_rep" runat="server" />
                                                                        </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <hr class="my-2">
                                                        <div class="row">
                                                            <div class="col-sm-6 col-md-3">
                                                                <div class="content-text-label">Benef NIT/CI</div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_benf_ci" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-6 col-md-3">
                                                                <div class="form-group">
                                                                    <label class="form-control-label">Benef Id</label>
                                                                    <div class="h5 font-weight-400 content-text">
                                                                        <asp:Literal ID="ltl_bene_id" runat="server" />
                                                                        </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-6 col-md-3">
                                                                <div class="form-group">
                                                                    <label class="form-control-label">Gestion Id</label>
                                                                    <div class="h5 font-weight-400 content-text">
                                                                        <asp:Literal ID="ltl_gest_id" runat="server" />
                                                                        </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <div class="content-text-label">ID Pago</div>
                                                                <div class="h5 font-weight-400 content-text content-text">
                                                                    <asp:Literal ID="ltl_pago_id" runat="server" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <hr class="my-2">
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
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
    </div>
</asp:Content>


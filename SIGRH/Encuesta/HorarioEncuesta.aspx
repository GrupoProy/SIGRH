<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="HorarioEncuesta.aspx.cs" Inherits="MovimientoPersonal_DocenteAgre" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="header pb-6" style="margin-top: -4em; margin-left: 3em; width: 81%">
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Encuesta de Horarios</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid col-md-6">
        <div class="ct-example  card" style="padding-bottom: unset">
            <div class="card-body">
                <div class="media align-items-center">
                    <div class="media-body">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <h6 class="heading-title">ENCUESTA DE HORARIO</h6>
                                <div class="row">
                                    <h6 class="heading-small">OPCION 1:</h6>
                                </div>
                                <div class="row">
                                    <div class="col-lg-5">
                                        <asp:Literal ID="ltl_nombre" Text="De 7:30 a 12:00" runat="server" />
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:Literal ID="ltl2" Text="Y de 14:00 a 17:30" runat="server" />
                                    </div>
                                    <div class="col-md-3">
                                        <label class="custom-toggle custom-toggle-yout grid-check-item">
                                            <asp:CheckBox ID="cb1" OnCheckedChanged="cb1_CheckedChanged" AutoPostBack="true" runat="server" />
                                            <span class="custom-toggle-slider rounded-circle" data-label-off="No" data-label-on="Si" data-toggle='tooltip' data-placement='top' title='Elegir'></span>
                                        </label>
                                    </div>
                                </div>
                                <hr class="my-2">
                                <div class="row">
                                    <h6 class="heading-small">OPCION 2:</h6>
                                </div>
                                <div class="row">
                                    <div class="col-lg-5">
                                        <asp:Literal ID="Literal1" Text="De 8:00 a 12:00" runat="server" />
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:Literal ID="Literal2" Text="Y de 14:00 a 18:00" runat="server" />
                                    </div>
                                    <div class="col-md-3">
                                        <label class="custom-toggle custom-toggle-yout grid-check-item">
                                            <asp:CheckBox ID="cb2" OnCheckedChanged="cb2_CheckedChanged" AutoPostBack="true" runat="server" />
                                            <span class="custom-toggle-slider rounded-circle" data-label-off="No" data-label-on="Si" data-toggle='tooltip' data-placement='top' title='Elegir'></span>
                                        </label>
                                    </div>
                                </div>
                                <hr class="my-2">
                                <div class="row">
                                    <h6 class="heading-small">OPCION 3:</h6>
                                </div>
                                <div class="row">
                                    <div class="col-lg-5">
                                        <asp:Literal ID="Literal3" Text="De 8:00 a 12:30" runat="server" />
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:Literal ID="Literal4" Text="Y de 14:30 a 18:00" runat="server" />
                                    </div>
                                    <div class="col-md-3">
                                        <label class="custom-toggle custom-toggle-yout grid-check-item">
                                            <asp:CheckBox ID="cb3" OnCheckedChanged="cb3_CheckedChanged" AutoPostBack="true" runat="server" />
                                            <span class="custom-toggle-slider rounded-circle" data-label-off="No" data-label-on="Si" data-toggle='tooltip' data-placement='top' title='Elegir'></span>
                                        </label>
                                    </div>
                                </div>
                                <hr class="my-2">
                                <div class="row">
                                    <h6 class="heading-small">OPCION 4:</h6>
                                </div>
                                <div class="row">
                                    <div class="col-lg-5">
                                        <asp:Literal ID="Literal5" Text="De 8:00 a 12:30" runat="server" />
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:Literal ID="Literal6" Text="Y de 15:00 a 18:30" runat="server" />
                                    </div>
                                    <div class="col-md-3">
                                        <label class="custom-toggle custom-toggle-yout grid-check-item">
                                            <asp:CheckBox ID="cb4" OnCheckedChanged="cb4_CheckedChanged" AutoPostBack="true" runat="server" />
                                            <span class="custom-toggle-slider rounded-circle" data-label-off="No" data-label-on="Si" data-toggle='tooltip' data-placement='top' title='Elegir'></span>
                                        </label>
                                    </div>
                                </div>
                                <div class="form-group col-md-6">
                                    <asp:LinkButton ID="BtnAsig" OnClick="BtnAsig_Click" CssClass="btn btn-success btn-block top-4" Text="<i class='fas fa-save'></i> Enviar respuesta" data-toggle="tooltip" data-original-title="Enviar respuesta" runat="server" />
                                </div>
                            </contenttemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
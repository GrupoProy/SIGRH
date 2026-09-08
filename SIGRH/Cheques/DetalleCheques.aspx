<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCheque.master" AutoEventWireup="true" CodeFile="DetalleCheques.aspx.cs" Inherits="Cheques_DetalleCheques" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">File Virtual</h6>
                    </div>

                </div>
            </div>
        </div>
    </div>
                    <div class="col-lg-6 col-5 text-right">
                        <asp:LinkButton ID="btnEliminar" OnClick="btnEliminar_Click"  CssClass="btn btn-circle sticky-top-btn2 icon-prs icon-shape-prs bg-gradient-orange text-white rounded-circle shadow" Text="<i class='fas fa-trash'></i>" data-toggle="tooltip" data-original-title="Eliminar Documento" runat="server" />
                        <asp:LinkButton ID="btn_nuevo" OnClick="btn_nuevo_Click" CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-inst text-white rounded-circle shadow" Text="<i class='fas fa-plus'></i>" data-toggle="tooltip" data-original-title="Adicionar Pdf" runat="server" />
                    </div>
<div class="container-fluid mt--6">
    <div class="row">
        <div class="col-lg-7">
            <div class="card">
                <div class="card-body">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
        <div class="row">
            <div class="col-12 mt--9 ml-5">
                <div class="col-6 mt--3">
                    <asp:LinkButton id="btnImagenAdelante" OnClick="btnImagenAdelante_Click"  CssClass="btn btn-circle rounded-cricle bg-blue text-white float-right mt-9" runat="server" Text="<i class='fas fa-forward'></i>"  />
                </div>
                <div class="col-6">
                    <asp:LinkButton  ID="btnImagenAtras"  OnClick="btnImagenAtras_Click" CssClass="btn btn-circle rounded-cricle bg-blue text-white float-right mt-9" runat="server" Text="<i class='fas fa-backward'></i>"  />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-12 text-center ml--6" runat="server" visible="true">
                            <asp:Label Text="" ID="lblContador" Visible="false" runat="server" />
         </div>
        </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                        <ContentTemplate>
                                    <div class="text-center">



                                        <div class="mt--4">
                            <hr />
                                        <asp:Literal ID="ltEmbed"  runat="server" />
                                        </div>
                                    </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
            </div>
        </div>
        <div class="col-lg-5">
            <div class="card">
                <div class="card-body">
            <div class="row mt--3">
                <div class="col-lg-4">
                    <div class="content-text-label">Cód. Funcionario</div>
                    <div class="h5 font-weight-400 content-text content-text">
                        <asp:Literal ID="ltl_cod_fun" runat="server" />
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="content-text-label">CI</div>
                    <div class="h5 font-weight-400 content-text">
                        <asp:Literal ID="ltl_num_doc" runat="server" />
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="content-text-label">Fecha Nac.</div>
                    <div class="h5 font-weight-400 content-text content-text">
                        <asp:Literal ID="ltl_fecha_nac" runat="server" />
                    </div>
                </div>
            </div>
            <div class="row">
            <div class="col-lg-8">
                <div class="content-text-label">Nombre funcionario</div>
                <div class="h5 font-weight-400 content-text">
                    <asp:Literal ID="ltl_nombre_fun" runat="server" />
                </div>
            </div>
            <div class="col-lg-4">
                <div class="content-text-label">Estado civil</div>
                <div class="h5 font-weight-400 content-text">
                    <asp:Literal ID="ltl_estado_civil" runat="server" />
                </div>
            </div>
        </div>

        <div class="row mt--2">

            <div class="card col-12" runat="server" id="resultado">
                <div class="card-body">
        <asp:UpdatePanel runat="server" ID="panel1">
            <ContentTemplate>
              <label class="form-control-label" for="ddlCategoria">Categoría:</label>
              <asp:DropDownList ID="ddlCategoria" AutoPostBack="true"  OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />

              <label class="form-control-label" for="ddlDocs">Documento:</label>
              <asp:DropDownList ID="ddlDocs" AutoPostBack="true"  OnSelectedIndexChanged="ddlDocs_SelectedIndexChanged" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>

              <label class="form-control-label" for="ddlDocs">Búsqueda:</label>
              <asp:DropDownList ID="ddlFInd" AutoPostBack="true"  OnSelectedIndexChanged="ddlFInd_SelectedIndexChanged" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />

                </div>
            </div>

        </div>

                </div>
            </div>
        </div>


    </div>
</div>
        <div class="modal fade" id="guardarCambios" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
            <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                <div class="modal-content bg-gradient-dark6">
                    <div class="modal-header">
                    </div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:HiddenField ID="hf_cb_id" runat="server" />
                            <div class="modal-body">
                                <div class="py-3 text-center">
                                    <i class="ni ni ni-album-2 ni-3x"></i>
                                    <h4 class="heading text-dark mt-4">¿Está seguro de eliminar el documento?</h4>
                                </div>
                            </div>
                            <div class="form-group text-center">
                                <asp:LinkButton ID="btnEliminarDoc" Text="<i class='fas fa-trash mr-2'></i>Si" OnClick="btnEliminarDoc_Click" CssClass="btn btn-success"   runat="server" />
                                <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>No</button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>



    <asp:UpdateProgress AssociatedUpdatePanelID="panel1" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>

</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="FileVirtualNuevoPdf.aspx.cs" Inherits="Kardex_FileVirtualNuevoPdf" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">File Virtual</h6>
                    </div>
                    <div class="col-lg-6 col-5">
                        <asp:LinkButton ID="btnAtras" OnClick="btnAtras_Click"  CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-inst text-white rounded-circle shadow" Text="<i class='fas fa-backward'></i>" data-toggle="tooltip" data-original-title="Atrás" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>


<div class="container-fluid mt--6">
    <div class="row">
        <div class="col-lg-7">
            <div class="card">
                <div class="card-body">
                    <asp:UpdatePanel runat="server" ID="panel1">
                        <ContentTemplate>
                                    <div class="text-center">
                                        <div class="mt--4" style="position:relative;">
                            <hr />
                                        <asp:Literal ID="ltEmbed"  runat="server" />
                                        </div>
                                    </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div class="col-lg-5 mt--7">
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
        <div class="row">
            <div class="card col-6">
                <div class="card-body">
                    <asp:UpdatePanel runat="server" ID="panel2">
                        <ContentTemplate>
                    <label class="form-control-label" for="ddlCategoria">Categoría:</label>
                    <asp:DropDownList ID="ddlCategoria" AutoPostBack="true" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                <div class="row">
                                <div class="form-group col-md-11 ml-3">
                                    <label class="form-control-label" for="ddlDocumento">Tipo Documento:</label>
                                        <asp:DropDownList ID="ddlDocumento" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                </div>
                                </div>
                            <div class="row mt-4">
                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control mt--3" accept=".pdf" />

                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>             
                </div>

            </div>
        <div class="card col-6">
            <div class="card-body">
                        <asp:UpdatePanel runat="server" ID="panel3">
                            <ContentTemplate>
                    <label class="form-control-label" for="txt_fecha_doc">Fecha del Documento</label>
                    <div class="input-group input-group-merge">
                        <div class="input-group-prepend">
                            <span class="input-group-text" >
                                <i class="far fa-calendar-alt"></i>
                            </span>
                        </div>
                        <asp:TextBox ID="txt_fecha_doc" CssClass="form-control datepickerD" runat="server" />
                    </div>
                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_fecha_doc" ValidationGroup="edit" Display="Dynamic" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel> 
                <div class="row mt-3 mb-2">
                            <asp:Button Text="Guardar" Visible="true" ID="btnUpload" CssClass="btn btn-block bg-success text-white" OnClick="btnUpload_Click" runat="server" />

                </div>
                        <asp:UpdatePanel runat="server" ID="panel4">
                            <ContentTemplate>
                    <label class="form-control-label" for="txtObservaciones">Observaciones</label>
                    <div class="input-group input-group-merge">
                        <div class="input-group-prepend">
                            <span class="input-group-text">
                                <i class="far fa-calendar-alt"></i>
                            </span>
                        </div>
                        <asp:TextBox ID="txtObservaciones" CssClass="form-control" runat="server" />
                </div>
                <asp:Button Text="Actualizar" Visible="false" ID="btnActualizar" CssClass="btn btn-block bg-info text-white" OnClick="btnActualizar_Click" runat="server" />

                            </ContentTemplate>
                        </asp:UpdatePanel>  
            </div>

        </div>

        </div>
        <div class="row mt--4">
            <div class="card col-12" runat="server" id="resultado">
                <div class="card-body">
                <asp:UpdatePanel runat="server" ID="panel5">
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" CssClass="table table-bordered table-hover table-striped" OnPreRender="GvLista_PreRender" AutoGenerateColumns="false" runat="server" OnRowCommand="GridView1_RowCommand" DataKeyNames="pdf_id">
                            <Columns>
                                <asp:BoundField DataField="pdf_nombre" HeaderText="Documento" />
                                <asp:BoundField DataField="pdf_fecha_doc" DataFormatString="{0:d}" HeaderText="Fecha" />
                                <asp:BoundField DataField="pdf_observacion" ControlStyle-Width="50px" ItemStyle-Width="50px" HeaderText="OBS." />
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkView" runat="server" CommandName="pdf" Text="Ver" CommandArgument="<%# Container.DataItemIndex %>"></asp:LinkButton>
                                        <asp:LinkButton ID="lnkView1" runat="server" ForeColor="DarkGreen" CommandName="editar" Text="Editar" CommandArgument="<%# Container.DataItemIndex %>"></asp:LinkButton>
                                        <asp:LinkButton ID="lnkView2" ForeColor="Red" runat="server" CommandName="eliminar" Text="Eliminar" CommandArgument="<%# Container.DataItemIndex %>"></asp:LinkButton>
                                    </ItemTemplate>
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
                                <asp:LinkButton ID="btn_guardar_cambios" Text="<i class='fas fa-check mr-2'></i>Si" CssClass="btn btn-success"  OnClick="btn_guardar_cambios_Click" runat="server" />
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

    <asp:UpdateProgress AssociatedUpdatePanelID="panel2" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:UpdateProgress AssociatedUpdatePanelID="panel3" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:UpdateProgress AssociatedUpdatePanelID="panel4" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:UpdateProgress AssociatedUpdatePanelID="panel5" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>


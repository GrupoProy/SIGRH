<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="RegistroFaltasDocentes.aspx.cs" Inherits="Salarios_RegistroFaltasDocentes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Sanciones</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>   
    <asp:UpdatePanel ID="sanciones" runat="server">
        <ContentTemplate>
    <div class="container-fluid mt--6">
        <div class="card">
            <div class="card-header border-bottom">
                <div class="ct-page-title">
                    <h3 class="mb-0">Buscar</h3>
                    <p class="text-sm mb-0">Realice la búsqueda del funcionario a ser sancionado</p>
                </div>
            </div>
                    <asp:Panel CssClass="card-body" DefaultButton="BtnBuscar" runat="server">
                        <div class="row">
                            <!-- per_ap_paterno -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_per_ap_paterno_b">Apellido Paterno</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_ap_paterno_b" CssClass="form-control letras" runat="server" />
                                </div>
                            </div>
                            <!-- per_ap_materno -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_per_ap_materno_b">Apellido Materno</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_ap_materno_b" CssClass="form-control letras" runat="server" />
                                </div>
                            </div>
                            <!-- per_nombres -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_per_nombres_b">Nombre(s)</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_nombres_b" CssClass="form-control letras" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <!-- per_num_doc -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_per_num_doc_b">Carnet de Identidad</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_num_doc_b" CssClass="form-control numero" TextMode="Number" runat="server" />
                                </div>
                            </div>
                            <!-- per_id -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_per_id_b">Código de Funcionario</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_id_b" CssClass="form-control numero" TextMode="Number" runat="server" />
                                </div>
                            </div>
                            <!-- BtnBuscar -->
                            <div class="form-group offset-md-3 col-md-3 align-self-end">
                                <asp:LinkButton ID="BtnBuscar" CssClass="btn btn-info btn-block" Text="<i class='fas fa-search'></i> Buscar" OnClick="BtnBuscar_Click" runat="server" />
                            </div>
                        </div>
                    </asp:Panel>
        </div>

        <!-- Result Record Starts here -->
        <div id="dResult" class="card" style="display: none;">
            <div class="card-header border-bottom">
                <div class="ct-page-title">
                    <h3 class="mb-0">Lista de Personal</h3>
                    <p class="text-sm mb-0"></p>
                </div>
            </div>
            <div class="card-body">
                <!-- Placing GridView in UpdatePanel -->
                        <asp:GridView ID="GvLista" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="GvLista_PreRender" OnRowCommand="GvLista_RowCommand" runat="server" DataKeyNames="per_id, as_ca_id">
                            <Columns>
                                <asp:BoundField DataField="per_id" HeaderText="Código" />
                                <asp:BoundField DataField="per_ap_paterno" HeaderText="Apellido Paterno" />
                                <asp:BoundField DataField="per_ap_materno" HeaderText="Apellido Materno" />
                                <asp:BoundField DataField="per_nombres" HeaderText="Nombre(s)" />
                                <asp:BoundField DataField="per_ap_casada" HeaderText="Apellido Casada" />
                                <asp:BoundField DataField="per_num_doc" HeaderText="C.I." />
                                <asp:BoundField DataField="cargo" HeaderText="CARGO" />

                                <asp:TemplateField HeaderText="Controles" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:LinkButton CommandName="GetEdit" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<span class='btn-inner--icon'><i class=''>Sancionar</i></span>" data-toggle="tooltip" data-placement="top" title="Click para registrar sanción" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
            </div>
        </div>
    </div>

    
    <div class="modal fade" id="modalSancionInasistencia" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-body p-0">
                        <div class="card bg-secondary border-0 mb-0">
                <div class="col-lg-12">
                <div class="card-wrapper">
                    <div class="card card-profile">
                        <div class="row justify-content-center">
                            <div class="col-lg-3 order-lg-2">
                                <div class="card-profile-image">
                                    <a href="#">
                                        <asp:Image ID="imgFun" class="rounded-circle" runat="server" /> <asp:HiddenField  runat="server"  ID="hdf_per_id"  />
                                    </a>
                                </div>
                            </div>
                        </div>
                            <!-- jornada de trabajo -->
                            <div class="col-4">
                                    <span><strong class="h5">TIPO JORNADA: </strong><h6><asp:Literal ID="ltl_jornada" runat="server"/></h6></span>
                            </div>

                        <div class="card-header text-center border-0 pt-8 pt-md-4 pb-0 pb-md-4 mt--4">
                            <asp:LinkButton ID="btn_estado" class="btn btn-sm btn-info float-right" runat="server" />
                        </div>
                        <div class="card-body pt-0 mt--3">
                                    <div>
                                        <h5 class="h3 text-uppercase text-center">
                                            <asp:Literal ID="ltl_apellido_fun" runat="server" />
                                            <asp:Literal ID="ltl_nombre_fun" runat="server" />
                                        </h5>
                                        <div class="h5 font-weight-400  text-center">
                                            <strong class="h5">CI: </strong>
                                            <asp:Literal ID="ltl_ci" runat="server" />
                                            <strong class="h5">COD. FUN:</strong>
                                            <asp:Literal ID="ltl_cod_fun" runat="server" />
                                        </div>
                                        <%--<hr class="my-2">--%>
                                        <h6 class="heading-small text-muted" runat="server" visible="false">Información adicional </h6>
                                        <div class="row"  runat="server" visible="false">
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Ítem</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_item" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Cargo</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_cargo" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row"  runat="server" visible="false">
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Fecha asignación</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_fecha_inicio" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Fecha baja</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_fecha_fin" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <%--<hr class="my-2">--%>
                                        <h6 class="heading-small text-muted">Escalafón </h6>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Puesto</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_puesto" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Haber Básico (Bs)</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_haber_basico" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div class="content-text-label">Ubicación</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_ubicacion" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                        <div class="form-group col-md-12">
                                            <label class="form-control-label" for="ddl_asignacion">Asignaciones:</label>
                                            <asp:DropDownList ID="ddl_asignacion" CssClass="form-control select2" data-minimum-results-for-search="Infinity" AppendDataBoundItems="true"  runat="server" />
                                        </div>
                                        </div>
                                    </div>
                        </div>
                    </div>
                </div>
            </div>
                            <asp:HiddenField ID=hdf_ca_id runat="server" />
                <div class="col-lg-12">
                <div class="card-wrapper">
                    <div class="card card-profile">                    
                        <div class=" ct-page-title">
                        <h3 class="mb-0 text-org2">Faltas Docentes</h3>
                    <div class="row">
                    <div class="col-6" runat="server" visible="false">
                        <label class="form-control-label" for="exampleFormControlSelect1">Registre la cantidad de retrasos:</label>
                        <asp:TextBox runat="server" Text="" ID="txtRetrasos"  CssClass="form-control numero" TextMode="Number"  />
<%--                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtRetrasos" ValidationGroup="sancion" Display="Dynamic" runat="server" />--%>
                    </div>
                    <div class="col-5">
                        <label class="form-control-label" for="exampleFormControlSelect1">Registre la cantidad de días de inasistencia:</label>
                        <asp:TextBox runat="server" Text="" ID="txtInasistencia"  CssClass="form-control numero" TextMode="Number"  />
<%--                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtInasistencia" ValidationGroup="sancion" Display="Dynamic" runat="server" />--%>
                    </div>
                    </div> 
                            <asp:HiddenField    ID="hdf_sa_id56" runat="server" />
                            <asp:HiddenField  ID="hdf_retrasos" runat="server"/>
                            <asp:HiddenField    ID="hdf_sa_id57" runat="server" />
                            <asp:HiddenField   ID="hdf_inasistencia" runat="server"  />
                         <br />
                        </div>
                    </div>
                </div>
                </div>
                                    
                <div class="form-group text-center">
                                        <asp:LinkButton ID="btnAdicionarSancion" Text="<i class='fas fa-check mr-2'></i>Guardar" ValidationGroup="sancion" CssClass="btn btn-success"  OnClick="btnAdicionarSancion_Click" runat="server" />
                                        <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                    </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdicionarSancion" EventName="Click"  />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="up" AssociatedUpdatePanelID="sanciones" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>


</asp:Content>


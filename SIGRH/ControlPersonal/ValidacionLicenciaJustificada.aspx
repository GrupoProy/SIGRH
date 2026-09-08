<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ValidacionLicenciaJustificada.aspx.cs" Inherits="ControlPersonal_ValidacionLicenciaJustificada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Header -->
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Validación Comisiones</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page content -->
    <div class="container-fluid mt--6">
        <div class="card">
            <div class="card-header">
                <div class="ct-page-title">
                    <h3 class="mb-0">Búsqueda de Personal</h3>
                    <p class="text-sm mb-0">En el siguiente formulario puede buscar un registro correspondiente a los parámetros ingresados.</p>
                </div>
            </div>
            <asp:UpdatePanel ID="Up_busqueda" runat="server">
                <ContentTemplate>
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
                            <%--<!-- lj_ped_val -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Rbl_lj_ped_val">Licencia</label>
                                <div class="custom-control custom-radio">
                                    <asp:RadioButtonList ID="Rbl_lj_ped_val" CssClass="radios" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="Rbl_lj_ped_val_SelectedIndexChanged" runat="server">
                                        <asp:ListItem Value="P" Text="Pendiente" />
                                        <asp:ListItem Value="V" Text="Validado" />
                                    </asp:RadioButtonList>
                                </div>
                            </div>--%>
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
                                    <asp:TextBox ID="Txt_per_num_doc_b" CssClass="form-control" TextMode="Number" runat="server" />
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
                            <!-- lj_id -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_lj_id">Nº Papeleta</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_lj_id" CssClass="form-control numero" TextMode="Number" runat="server" />
                                </div>
                            </div>
                            <!-- BtnBuscar -->
                            <div class="form-group col-md-3 align-self-end">
                                <asp:LinkButton ID="BtnBuscar" CssClass="btn btn-info btn-block" Text="<i class='fas fa-search'></i> Buscar" OnClick="BtnBuscar_Click" runat="server" />
                            </div>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <!-- Result Record Starts here -->
        <asp:UpdatePanel ID="Up_lista_lj" runat="server">
            <ContentTemplate>
                <asp:Panel ID="P_lista_lj_p" CssClass="card" Visible="false" runat="server">
                    <div class="card-header border-bottom">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Lista de Licencias Justificadas Pendientes</h3>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="form-group col-md-5">
                                <label class="form-control-label">Codigo Boleta Comision</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="codigoComisionInput" onkeypress="Press(event);" CssClass="form-control" TextMode="Number" runat="server" />
                                </div>
                            </div>
                            <div class="form-group col-md-3 mt-4">
                                <asp:LinkButton ID="BtnMismoFuncionamiento" CssClass="btn btn-success" OnClick="BtnMismoFuncionamiento_Click" runat="server">
                                    <i class='fas fa-check'></i> Aprobar Comision
                                </asp:LinkButton>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">

                            </div>
                        </div>
                        <asp:GridView ID="Gv_lista_lj_p" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="lj_id" OnPreRender="Gv_lista_lj_p_PreRender" OnRowCommand="Gv_lista_lj_p_RowCommand" runat="server">
                            <Columns>
                                <%--<asp:BoundField DataField="lj_id" HeaderText="Nº Papeleta" />--%>
                                <asp:BoundField DataField="per_id" HeaderText="Código" />
                                <asp:BoundField DataField="per_funcionario" HeaderText="Funcionario(a)" />
                                <%--<asp:BoundField DataField="per_num_doc" HeaderText="C.I." />--%>
                                <%--<asp:BoundField DataField="cat_descripcion" HeaderText="Tipo Licencia" />--%>
                                <asp:BoundField DataField="lj_fecha_licencia" HeaderText="Fecha Licencia" />
                                <asp:BoundField DataField="lj_hora_licencia" HeaderText="Hora Licencia" />
                                <%--<asp:BoundField DataField="lj_estado" HeaderText="Estado" />--%>
                                <asp:TemplateField HeaderText="Acciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:LinkButton CommandName="BtnValidar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-success btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-check'></i></span>" data-toggle="tooltip" data-placement="top" title="Validar" runat="server" />
                                        <asp:LinkButton CommandName="BtnVer" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-info btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-eye'></i></span>" data-toggle="tooltip" data-placement="top" title="Ver licencia" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <!-- List Record Ends here -->
    </div>

    <!-- Modal component -->
    <!-- Validar Record Modal Starts here -->
    <div id="validarModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="validarTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content" style="margin-top: 50px;">
                <asp:UpdatePanel ID="Up_form_v" runat="server">
                    <ContentTemplate>
                        <asp:Panel CssClass="modal-body p-0" DefaultButton="BtnGuardarV" runat="server">
                            <asp:HiddenField ID="Hf_lj_id" runat="server" />
                            <div class="card bg-secondary border-0 mb-0">
                                <div class="row justify-content-center">
                                    <div class="col-lg-3 order-lg-2">
                                        <div class="card-profile-image">
                                            <!-- fp_foto -->
                                            <asp:Image ID="Img_fp_foto" CssClass="rounded-circle" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="card-header text-center border-0 pt-8 pt-md-4 pb-0 pb-md-4">
                                    <h4 class="mb-0 text-left">
                                        <i class="fas fa-file-alt mr-2"></i>
                                        <asp:Literal ID="Lt_titulo_modal_licencia" Text="Detalle de Licencia Justificada" runat="server" />
                                    </h4>
                                    <!-- as_estado -->
                                    <asp:Label ID="Lbl_as_estado" CssClass="btn btn-sm btn-info float-right" runat="server" />
                                </div>
                                <div class="card-body px-lg-5 py-lg-3">
                                    <h5 class="h3 text-center">
                                        <!-- per_nombres -->
                                        <asp:Literal ID="Lt_per_nombres" runat="server" />
                                    </h5>
                                    <div class="h5 font-weight-400 text-center">
                                        <!-- per_num_doc -->
                                        <strong class="h5">CI:</strong>
                                        <asp:Literal ID="Lt_per_num_doc" runat="server" />
                                        <!-- per_id -->
                                        <strong class="h5">CÓDIGO:</strong>
                                        <asp:Literal ID="Lt_per_id" runat="server" />
                                        <!-- ca_num_item -->
                                        <strong class="h5">ÍTEM:</strong>
                                        <asp:Literal ID="Lt_ca_num_item" runat="server" />
                                    </div>
                                    <hr class="my-2">
                                    <h6 class="heading-small text-muted">Información Fecha Asignación</h6>
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <!-- as_fecha_inicio -->
                                            <div class="content-text-label">Fecha Alta</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="Lt_as_fecha_inicio" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <!-- as_fecha_fin -->
                                            <div class="content-text-label">Fecha Baja</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="Lt_as_fecha_fin" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <hr class="my-3">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <h6 class="heading-small text-muted">Categoría Administrativa</h6>
                                            <!-- eo_descripcion -->
                                            <div class="content-text-label">Ubicación</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="Lt_eo_descripcion" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <h6 class="heading-small text-muted">Categoría Programática</h6>
                                            <!-- cp_descripcion -->
                                            <div class="content-text-label">Ubicación</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="Lt_cp_descripcion" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <hr class="my-3" />
                                    <div style="background-color: #D2EEE0; border-radius: .375rem; padding: 0px 17px;">
                                        <h6 class="heading-small text-muted">Datos Licencia Justificada</h6>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <!-- lj_tipo_licencia -->
                                                <div class="content-text-label">Tipo Licencia</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_lj_tipo_licencia" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <!-- lj_per_id_autoriza -->
                                                <div class="content-text-label">Autorizado Por</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_lj_per_id_autoriza" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <!-- lj_fecha_licencia -->
                                                <div class="content-text-label">Fecha Licencia</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_lj_fecha_licencia" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <!-- lj_hora_licencia -->
                                                <div class="content-text-label">Hora Licencia</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_lj_hora_licencia" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <!-- lj_motivo -->
                                                <div class="content-text-label">Motivo</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_lj_motivo" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <!-- lj_lugar -->
                                                <div class="content-text-label">Lugar</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_lj_lugar" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group text-center">
                                    <asp:LinkButton ID="BtnGuardarV" CssClass="btn btn-success" Text="<i class='fas fa-check mr-2'></i> Validar" OnClick="BtnGuardarV_Click" runat="server" />
                                    <asp:LinkButton ID="BtnCancelarV" CssClass="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i> Cancelar" OnClick="BtnCancelarV_Click" runat="server" />
                                </div>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- Validar Record Modal Ends here -->

    <script>
           function showModalAndClearInput(comisionCode) {
               $('#modalText').html('<h4><i class="fas fa-check-circle text-success"></i> Comisión Nro ' + comisionCode + ' aprobada con exito</h4>');
               $('#myModal').modal('show');
               setTimeout(function () { $('#myModal').modal('hide'); }, 2000);
           }
    </script>
    <%--<script>
        function handleKeyPress(event) {
            if (event.keyCode === 13) { // 13 es el código de tecla para "Enter"
                
                var targetId = event.target.id; // Obtiene el ID del elemento que disparó el evento
                if (targetId === '<%= codigoComisionInput.ClientID %>') {
                    document.getElementById('<%= BtnMismoFuncionamiento.ClientID %>').click(); // Ejecuta el evento click del botón
                }
            }
        }
    </script>--%>

    <script>
        var nav4 = window.Event ? true : false;
        function Press(evt) {
            // Nota: Enter = 13
            var key = nav4 ? evt.which : evt.keyCode;
            if (key == 13)
                document.getElementById('<%=BtnMismoFuncionamiento.ClientID%>').click();
        }
    </script>


    <%--<asp:UpdateProgress AssociatedUpdatePanelID="Up_busqueda" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>--%>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_lista_lj" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_v" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

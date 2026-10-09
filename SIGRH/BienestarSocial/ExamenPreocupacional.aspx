<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ExamenPreocupacional.aspx.cs" Inherits="BienestarSocial_ExamenPreocupacional" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Programación del Examen Preocupacional</h6>
                    </div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="col-lg-6 col-5 text-right">
                                <asp:LinkButton ID="btn_regitrar_ex" CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-inst text-white rounded-circle shadow" Text="<i class='fas fa-calendar-alt'></i>" data-toggle="tooltip" data-original-title="Programar Examen" OnClick="btn_regitrar_ex_Click" runat="server" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid mt--6">
        <div class="row">
            <div class="col-lg-6">
                <div class="card ">
                    <div class="card-header text-center align-items-center border-0">
                        <div class="align-items-center">
                            <div class="text-dark font-weight-600 text-sm">
                                <h3 class="mb-0">Exámenes Programados</h3>
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <!-- List group -->
                        <ul class="list-group list-group-flush list my--3">
                            <asp:UpdatePanel ID="up_lv_planilla" runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-12 text-center">
                                            <div class="list-view-item-title">
                                                Nro. de registros:
                                                <asp:Literal ID="ltl_total_reg" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                    </div>
                                    <asp:ListView ID="lv_examen" ClientIDMode="AutoID" OnItemCommand="lv_examen_ItemCommand" DataKeyNames="exp_id" runat="server">
                                        <ItemTemplate>

                                            <li class="list-group-item px-0 lv-item" style="margin-bottom: 0px" runat="server">
                                                <div class="row align-items-center px-3">
                                                    <div class="col-12 ml--2">
                                                        <asp:LinkButton ID="tDatail" CommandName="GetAssign" CommandArgument="<%# Container.DataItemIndex %>" runat="server">
                                                        <h2 class="mb-0 list-view-item-title-i">Nº Autorización: <%# Eval("exp_nro_autorizacion") %> </h2>
                                                        </asp:LinkButton>
                                                    </div>
                                                </div>
                                                <div class="row align-items-center px-3">
                                                    <div class="col-9">
                                                        <asp:LinkButton ID="tDatail1" CommandName="GetAssign" CommandArgument="<%# Container.DataItemIndex %>" data-toggle='tooltip' data-placement='top' title='' runat="server">
                                                            <div class="row ">
                                                                <div class="list-view-item-title" style="color: #0090C5;">Lugar:</div>
                                                                <div class="list-view-item-desc"><%# Eval("exp_lugar") %></div>
                                                            </div>
                                                            <div class="row ">
                                                                <div class="list-view-item-title">Convenio: </div>
                                                                <div class="list-view-item-desc"><%# Eval("exp_convenio") %></div>
                                                            </div>
                                                            <div class="row ">
                                                                <div class="list-view-item-title">Fecha examen: </div>
                                                                <div class="list-view-item-desc"><%# Eval("exp_fecha_examen") %></div>
                                                            </div>
                                                            <div class="row ">
                                                                <div class="list-view-item-title">Telf. Oficina: </div>
                                                                <div class="list-view-item-desc"><%# Eval("exp_tel_of_fun") %></div>
                                                            </div>
                                                            <div class="row ">
                                                                <div class="list-view-item-title">Estado: </div>
                                                                <div class="list-view-item-desc">
                                                                    <asp:Label ID="ltl_estado" CssClass='<%# (Eval("exp_estado").ToString() == "ENVIADO") ? "text-info font-weight-bold" : (Eval("exp_estado").ToString() == "APROBADO") ? "text-success font-weight-bold" :  (Eval("exp_estado").ToString() == "VALIDADO") ? "text-vimeo font-weight-bold" : (Eval("exp_estado").ToString() == "AJUSTAR") ? "text-warning font-weight-bold" : (Eval("exp_estado").ToString() == "ANULADO") ? "text-light4 font-weight-bold" :"list-view-item-desc" %>' Text='<%# Eval("exp_estado") %>' runat="server" />
                                                                </div>
                                                            </div>
                                                        </asp:LinkButton>
                                                    </div>
                                                    <div class="col-3 text-center">
                                                        <asp:LinkButton ID="tPrint" CommandName="GetPrint" CommandArgument="<%# Container.DataItemIndex %>" CssClass="table-action table-action-dark2 lv-action" Text=" <i class='fas fa-print'></i>" data-toggle='tooltip' data-original-title='Imprimir Examen' runat="server" />
                                                        <asp:LinkButton ID="tEdit" CommandName="GetEdit" CommandArgument="<%# Container.DataItemIndex %>" CssClass="table-action table-action-dark2 lv-action" Text=" <i class='fas fa-calendar-check'></i>" data-toggle='tooltip' data-original-title='Reprogramar Examen' runat="server" />
                                                        <asp:LinkButton ID="tDelete" CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="table-action table-action-delete lv-action" Text=" <i class='fas fa-times-circle'></i>" data-toggle='tooltip' data-original-title='Anular Examen' runat="server" />
                                                    </div>
                                                </div>
                                            </li>
                                        </ItemTemplate>

                                    </asp:ListView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="lv_examen" EventName="ItemCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </ul>

                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div id="no_existe_pla" class="row" runat="server">
                                    <div class="col-md-12">
                                        <p class="text-sm grid-notify-success">
                                            <asp:Literal ID="ltl_no_existe" Text="El funcionario no tiene exámenes programados." runat="server" />
                                        </p>
                                    </div>
                                </div>
                                <asp:HiddenField ID="hf_exp_id" runat="server" />
                                <asp:HiddenField ID="hf_perd_id" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="card-wrapper">
                    <!-- Sizes -->
                    <div class="card card-profile">
                        <div class="row justify-content-center">
                            <div class="col-lg-3 order-lg-2">
                                <div class="card-profile-image">
                                    <a href="#">
                                        <asp:Image ID="imgFun" class="rounded-circle" runat="server" />
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="card-header text-center border-0 pt-8 pt-md-4 pb-0 pb-md-4">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:LinkButton ID="btn_estado" class="btn btn-sm btn-info float-right" OnClick="btn_estado_Click" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                        <div class="card-body pt-0">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div>
                                        <h5 class="h3 text-uppercase text-center">
                                            <asp:Literal ID="ltl_nombre_fun" runat="server" />
                                        </h5>
                                        <div class="h5 font-weight-400  text-center">
                                            <strong class="h5">COD. FUN:</strong>
                                            <asp:Literal ID="ltl_cod_fun" runat="server" />
                                        </div>

                                        <hr class="my-3">
                                        <h6 class="heading-small text-muted d-inline-flex icon-title-h"><i class="fas fa-id-card icon-h"></i>Datos Personales</h6>
                                        <div class="icon-content-h">
                                            <div class="row">
                                                <div class="col-lg-3">
                                                    <div class="content-text-label">CI</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_ci" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="content-text-label">Nacionalidad</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_nacionalidad" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="content-text-label">Estado civil</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_estado_civil" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="content-text-label">Fecha de nacimiento</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_fecha_nac" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">

                                                <div class="col-lg-3">
                                                    <div class="content-text-label">Sexo/género</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_genero" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="content-text-label">Profesión</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_prefesion" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <hr class="my-2">
                                        <h6 class="heading-small text-muted d-inline-flex icon-title-h"><i class="fas fa-home icon-h"></i>Datos Domicilio</h6>
                                        <div class="icon-content-h">
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Dirección</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_direccion" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="content-text-label">Teléfono</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_telefono" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="content-text-label">Celular</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_cel" runat="server" />
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row" style="display: none">
                                                <div class="col-lg-4">
                                                    <div class="content-text-label">Departamento</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_departamento" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-4">
                                                    <div class="content-text-label">Provincia</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_provincia" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-4">
                                                    <div class="content-text-label">Ciudad</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_localidad" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <hr class="my-2">
                                        <h6 class="heading-small text-muted d-inline-flex icon-title-h"><i class="fas fa-briefcase icon-h"></i>Datos laborales</h6>
                                        <div class="icon-content-h">
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Ubicación</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_ubicacion" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Ítem</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_item" runat="server" />
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Cargo</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_cargo" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="content-text-label">Puesto</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_puesto" runat="server" />
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                        <hr class="my-2">
                                        <h6 class="heading-small text-muted d-inline-flex icon-title-h"><i class="fas fa-id-card-alt icon-h"></i>DATOS AFILIACIÓN AFP/E.G.S</h6>
                                        <div class="icon-content-h">
                                            <div class="row">
                                                <div class="col-lg-3">
                                                    <div class="content-text-label">Afp</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_afp" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="content-text-label">Nua</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_nua" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="content-text-label">E.G.S</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_egs" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="content-text-label">Nº seguro</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="ltl_seguro" runat="server" />
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>


                </div>
                <div class="card-wrapper">
                    <!-- Form controls -->
                    <div class="card">
                        <div class="card-header">
                            <div class="row align-items-center">
                                <div class="col-8">
                                    <div class=" ct-page-title">
                                        <h3 class="mb-0">Detalle Asignaciones</h3>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="table-responsive py-4">
                            <asp:UpdatePanel ID="panelGvHistoricoAsig" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gv_historicoAsig" CssClass="table table-bordered table-hover " AutoGenerateColumns="false" OnPreRender="gv_historicoAsig_PreRender" DataKeyNames="as_id" runat="server">
                                        <Columns>
                                            <asp:BoundField DataField="item" HeaderText="Detalle Ítem" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="as_fecha_inicio" HeaderText="Fecha Asignación" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="as_fecha_fin" HeaderText="Fecha Baja" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="cargo" HeaderText="Cargo" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="ubicacion" HeaderText="Ubicación" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="as_tipo_baja" HeaderText="Tipo movimiento" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="as_estado" HeaderText="Estado" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="col-md-12">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div id="block_HisAsignaciones" runat="server">
                                            <span class="badge badge-pill badge-info">El funcionario no tiene asignaciones.</span>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>


                </div>
            </div>
        </div>

        <div class="modal fade" id="modalNuevoExamen" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                <div class="modal-content">

                    <div class="modal-body p-0">
                        <div class="card bg-secondary border-0 mb-0">
                            <div class="card-header">
                                <div class="text-muted text-center mt-2 mb-3">
                                    <h4 class="header-modal">REGISTRO EXAMEN PREOCUPACIONAL</h4>
                                </div>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="card-body px-lg-5 py-lg-3">
                                        <div class="pb-5 text-center">
                                            <a href="javascript:;">
                                                <img src="../Content/img/theme/calendar-flat-21.png" alt="Circle image" class="img-fluid rounded-circle shadow" style="width: 100px;">
                                            </a>
                                        </div>
                                        <p class="description">
                                            Nº autorización: <strong>
                                                <asp:Literal ID="ltl_nro_aut" Text="text" runat="server" /></strong>
                                        </p>
                                        <div class="row">

                                            <div class="col-sm-6 col-md-2">
                                                <div class="form-group">
                                                    <label class="form-control-label">Convenio</label>
                                                    <asp:DropDownList ID="ddl_convenio" AppendDataBoundItems="true" CssClass="form-control select2" data-minimum-results-for-search="Infinity" runat="server">
                                                        <asp:ListItem Text="SI" Value="1" />
                                                        <asp:ListItem Text="NO" Value="0" />
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_convenio" Display="Dynamic" ValidationGroup="addExaPreo" runat="server" />

                                                </div>
                                            </div>
                                            <div class="col-sm-6 col-md-6">
                                                <div class="form-group">
                                                    <label class="form-control-label">Lugar</label>
                                                    <asp:DropDownList ID="ddl_lugar" CssClass="form-control select2" AppendDataBoundItems="true" data-minimum-results-for-search="Infinity" runat="server" />
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_lugar" Display="Dynamic" ValidationGroup="addExaPreo" InitialValue="0" runat="server" />

                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label class="form-control-label">Fecha prog.</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend  ">
                                                            <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_fecha_prog" class="form-control datepickerDefault" runat="server" />
                                                    </div>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_fecha_prog" Display="Dynamic" ValidationGroup="addExaPreo" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">

                                            <div class="col-sm-6 col-md-4">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="example4cols2Input">Teléfono of.</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="fas fa-phone"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_telf_of" class="form-control numero" runat="server" />
                                                    </div>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_telf_of" Display="Dynamic" ValidationGroup="addExaPreo" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-sm-6 col-md-4">
                                                <div class="form-group">
                                                    <label class="form-control-label">Teléfono fun.</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="fas fa-phone"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_telf_fun" class="form-control numero" runat="server" />
                                                    </div>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_telf_fun" Display="Dynamic" ValidationGroup="addExaPreo" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">

                                                    <label class="form-control-label">Celular fun.</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="fas fa-mobile-alt"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_cel_fun" class="form-control numero" runat="server" />
                                                    </div>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_cel_fun" ValidationGroup="addExaPreo" runat="server" />

                                                </div>
                                            </div>
                                        </div>

                                        <%--                                        <div class="row">
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label class="form-control-label">Función desempeña</label>
                                                    <asp:DropDownList ID="DropDownList3" CssClass="form-control select2" AppendDataBoundItems="true" data-minimum-results-for-search="Infinity" runat="server" />
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="DropDownList1" Display="Dynamic" ValidationGroup="addFamiliar" InitialValue="0" runat="server" />

                                                </div>
                                            </div>
                                            <div class="col-md-8">
                                                <div class="form-group">
                                                    <label class="form-control-label">Descripción</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend  ">
                                                            <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_fecha_nac_fam" class="form-control" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>--%>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="form-control-label">Actividad que realiza</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend  ">
                                                            <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_act_realiza" class="form-control" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="form-control-label">Observaciones</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="fas fa-eye"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_obs" class="form-control" runat="server" />
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-6 col-md-6">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="example4cols2Input">&nbsp</label>
                                                    <asp:LinkButton ID="btn_adicionar_prog" Text="<i class='fas fa-save mr-2'></i>Programar examen" ValidationGroup="addExaPreo" CssClass="btn btn-success btn-block" OnClick="btn_adicionar_prog_Click" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-sm-6 col-md-6">
                                                <div class="form-group">
                                                    <label class="form-control-label">&nbsp</label>
                                                    <asp:LinkButton ID="btn_cancelar_prog" CssClass="btn btn-outline-github btn-block" Text="<i class='fas fa-times mr-2'></i>Cancelar" OnClick="btn_cancelar_prog_Click" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        <div class="modal fade" id="reprogramarExamen" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
            <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                <div class="modal-content bg-gradient-dark6">
                    <div class="modal-header">
                    </div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>

                            <div class="modal-body">
                                <div class="py-3 text-center">
                                    <i class="ni ni-calendar-grid-58 ni-3x"></i>
                                    <h4 class="heading text-dark mt-4">¿Está seguro de reprogramar el examen?</h4>
                                </div>
                            </div>
                            <div class="form-group text-center">
                                <asp:LinkButton ID="btn_reprogramar_examen" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btn_reprogramar_examen_Click" runat="server" />
                                <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div class="modal fade" id="anularExamen" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
            <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                <div class="modal-content bg-gradient-dark6">
                    <div class="modal-header">
                    </div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>

                            <div class="modal-body">
                                <div class="py-3 text-center">
                                    <i class="ni ni-fat-remove ni-3x"></i>
                                    <h4 class="heading text-dark mt-4">¿Está seguro de anular el examen?</h4>
                                </div>
                            </div>
                            <div class="form-group text-center">
                                <asp:LinkButton ID="btn_anular_examen" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btn_anular_examen_Click" runat="server" />
                                <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div class="modal fade" id="modalGlosa" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                <div class="modal-content">
                    <asp:UpdatePanel ID="up_adicionar_cargo" runat="server">
                        <ContentTemplate>
                            <div class="modal-body p-0">
                                <div class="card bg-secondary border-0 mb-0">
                                    <div class="card-header">
                                        <div class="text-muted text-center mt-2 mb-3">
                                            <h4 class="header-modal">GLOSA</h4>
                                        </div>
                                    </div>
                                    <div class="card-body px-lg-5 py-lg-5">
                                        <div class="row">
                                            <div id="d_tipo_doc" class="col-md-6" runat="server">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="exampleFormControlSelect1">Tipo Documento</label>
                                                    <asp:DropDownList ID="ddl_tipo_documento" AppendDataBoundItems="true" CssClass="form-control select2" OnSelectedIndexChanged="ddl_tipo_documento_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_tipo_documento" Display="Dynamic" ValidationGroup="addGlosa" InitialValue="0" runat="server" />
                                                </div>
                                            </div>
                                            <div id="d_num_doc" class="col-md-4" visible="false" runat="server">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="exampleFormControlSelect1">Número de documento</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_num_doc" class="form-control numero" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="d_fecha_doc" class="col-md-6" runat="server">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="exampleFormControlSelect1">Fecha Documento</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_fechaMov" class="form-control datepickerDefault" runat="server" />
                                                    </div>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_fechaMov" Display="Dynamic" ValidationGroup="addGlosa" runat="server" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="example3cols1Input">Descripción </label>

                                                    <asp:TextBox ID="txt_descripcion_add" CssClass="form-control" placeholder="Descripción" TextMode="multiline" Rows="4" runat="server" />
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_descripcion_add" Display="Dynamic" ValidationGroup="addGlosa" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row pt-3">
                                            <div class="col-md-6">
                                                <asp:LinkButton ID="btn_adicionar_glosa" Text="<i class='fas fa-check mr-2'></i>Guardar" OnClick="btn_adicionar_glosa_Click" OnClientClick="if (Page_ClientValidate('addGlosa')) { MostrarMascara(true); }" ValidationGroup="addGlosa" CssClass="btn btn-success btn-block" runat="server" />
                                            </div>
                                            <div class="col-md-6">
                                                <asp:LinkButton ID="btn_cancelar_glosa" class="btn btn-outline-github btn-block" Text="<i class='fas fa-times mr-2'></i>Cancelar" OnClick="btn_cancelar_glosa_Click" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>


    </div>
</asp:Content>


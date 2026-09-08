<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="AsignacionBeneficio.aspx.cs" Inherits="BienestarSocial_frmAsignacionBeneficio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content">
        <div class="card">
            <div class="card-header border">
                <h3 class="card-title">Búsqueda de Personal</h3>
            </div>
            <asp:UpdatePanel ID="upSearch" runat="server">
                <ContentTemplate>
                    <asp:Panel DefaultButton="btnBuscar" runat="server">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-3">
                                    <!-- Diseño para el textbox carnet identidad -->
                                    <div class="form-group">
                                        <label class="control-label">Carnet de Identidad</label>
                                        <div class="input-group">
                                            <asp:TextBox ID="txt_per_num_doc" CssClass="form-control" TextMode="Number" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <!-- Diseño del textbox apellido paterno -->
                                    <div class="form-group">
                                        <label class="control-label">Apellido Paterno</label>
                                        <div class="input-group">
                                            <asp:TextBox ID="txt_per_ap_paterno" CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <!-- Diseño del textbox apellido materno -->
                                    <div class="form-group">
                                        <label class="control-label">Apellido Materno</label>
                                        <div class="input-group">
                                            <asp:TextBox ID="txt_per_ap_materno" CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <!-- Diseño del textbox nombre(s) -->
                                    <div class="form-group">
                                        <label class="control-label">Nombre(s)</label>
                                        <div class="input-group">
                                            <asp:TextBox ID="txt_per_nombres" CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <!-- Diseño para el textbox apellido esposo -->
                                    <div class="form-group">
                                        <label class="control-label">Apellido Esposo</label>
                                        <div class="input-group">
                                            <asp:TextBox ID="txt_per_ap_casada" CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <!-- Diseño para el textbox código funcionario -->
                                    <div class="form-group">
                                        <label class="control-label">Código Funcionario</label>
                                        <div class="input-group">
                                            <asp:TextBox ID="txt_per_id" CssClass="form-control" TextMode="Number" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <!-- Diseño de los botones de búsqueda y nuevo registro -->
                                    <div class="form-group fa-pull-left">
                                        <label class="control-label"></label>
                                        <div>
                                            <asp:LinkButton ID="btnBuscar" CssClass="btn btn-vimeo btn-block" Text="<i class='fas fa-search'></i> Buscar" OnClick="btnBuscar_Click" UseSubmitBehavior="false" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <!-- Result Record Starts here -->
        <div id="dResult" class="card" style="display: none;">
            <div class="card-header border">
                <h3 class="card-title">Lista de Funcionarios</h3>
            </div>
            <!-- Placing GridView in UpdatePanel -->
            <asp:UpdatePanel ID="upResultGrid" runat="server">
                <ContentTemplate>
                    <div class="card-body">
                        <asp:GridView ID="gvLista" CssClass="table table-bordered" runat="server" OnPreRender="gvLista_PreRender" OnRowCommand="gvLista_RowCommand" AutoGenerateColumns="false" DataKeyNames="per_id" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="per_id" HeaderText="Código" />
                                <asp:BoundField DataField="per_ap_paterno" HeaderText="Apellido Paterno" />
                                <asp:BoundField DataField="per_ap_materno" HeaderText="Apellido Materno" />
                                <asp:BoundField DataField="per_nombres" HeaderText="Nombre(s)" />
                                <asp:BoundField DataField="per_ap_casada" HeaderText="Apellido Casada" />
                                <asp:BoundField DataField="per_num_doc" HeaderText="C.I." />
                                <asp:TemplateField HeaderText="Controles" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="130px">
                                    <ItemTemplate>
                                        <asp:LinkButton CommandName="GetCodFun" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-info btn-flat btn-sm" Text="<span class='btn-inner--icon'>A</span>" runat="server" data-toggle="tooltip" data-placement="top" title="Asignar Subsidio" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="gvLista" EventName="RowCommand" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <!-- Result Record Ends here -->
    </section>
    <!-- Add Record Modal Starts here -->
    <div id="addModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-lg-kcpbxl" role="document">
            <div class="modal-content">
                <div class="modal-header border-bottom">
                    <div class="ct-page-title">
                        <h5 id="addTitle" class="modal-title">Asignacion Familiar</h5>
                        <p class="text-sm mb-0"></p>
                    </div>
                </div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <asp:HiddenField ID="Hf_per_id" runat="server" />
                            <asp:HiddenField ID="Hf_pf_id" runat="server" />
                            <div class="row">
                                <div class="col-md-4">
                                    <!-- per_id -->
                                    <div class="progress-info">
                                        <div class="tag-label">
                                            <span>Nombre(s) y Apellidos:
                                                <span class="tag-label-content">
                                                    <asp:Literal ID="Lt_per_id" runat="server" />
                                                </span>
                                            </span>
                                        </div>
                                    </div>
                                    <!-- per_id -->
                                    <div class="progress-info">
                                        <div class="tag-label">
                                            <span>CI:
                                                <span class="tag-label-content">
                                                    <asp:Literal ID="Lt_ci" runat="server" />
                                                </span>
                                            </span>
                                            <span>SEXO:
                                                <span class="tag-label-content">
                                                    <asp:Literal ID="Lt_sexo" runat="server" />
                                                </span>
                                            </span>
                                        </div>
                                    </div>
                                    <!-- ca_num_item -->
                                    <div class="progress-info">
                                        <div class="tag-label">
                                            <span>Item:
                                                <span class="tag-label-content">
                                                    <asp:Literal ID="Lt_ca_num_item" runat="server" />
                                                </span>
                                            </span>
                                             <span>Estado:
                                                <span class="tag-label-content">
                                                    <asp:Literal ID="Lt_as_estado" runat="server" />
                                                </span>
                                            </span>
                                        </div>
                                    </div>                                 
                                    <!-- as_fecha_inicio -->
                                    <div class="progress-info">
                                        <div class="tag-label">
                                            <span>F. Asig.:
                                                <span class="tag-label-content">
                                                    <asp:Literal ID="Lt_as_fecha_inicio" runat="server" />
                                                </span>
                                            </span>
                                            <span>F. Baja:
                                                <span class="tag-label-content">
                                                    <asp:Literal ID="Lt_as_fecha_fin" runat="server" />
                                                </span>
                                            </span>
                                        </div>
                                    </div>                                   
                                    <!-- es_descripcion -->
                                    <div class="progress-info">
                                        <div class="tag-label">
                                            <span>Escalafón:
                                                <span class="tag-label-content">
                                                    <asp:Literal ID="Lt_es_descripcion" runat="server" />
                                                </span>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-8">
                                    <div class="card">
                                        <div class="card-header border-bottom">
                                            <div class="ct-page-title">
                                                <h3 class="mb-0">Datos de la Asignacion Familiar</h3>
                                                <p class="text-sm mb-0"></p>
                                            </div>
                                        </div>
                                        <div class="card-body">
                                            <div class="row">
                                                <!-- lj_tipo_licencia -->
                                                <div class="form-group col-md-4">
                                                    <label class="form-control-label" for="Ddl_ab_fa_id">Tipo de Beneficio</label>
                                                    <asp:DropDownList ID="Ddl_ab_fa_id" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" OnSelectedIndexChanged="Ddl_ab_fa_id_SelectedIndexChanged" AutoPostBack="True" />
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_ab_fa_id" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                                                </div>
                                                <!-- lj_fecha_inicial -->
                                                <div class="form-group col-md-4">
                                                    <label class="form-control-label" for="Txt_ab_fecha_inicio">Fecha Inicio</label>
                                                    <div class="input-group">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text">
                                                                <i class="fas fa-edit"></i>
                                                            </span>
                                                        </div>
                                                        <asp:TextBox ID="Txt_ab_fecha_inicio" CssClass="form-control datepickerDefault" OnTextChanged="Txt_ab_fecha_inicio_TextChanged" AutoPostBack="true" runat="server" />
                                                    </div>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_ab_fecha_inicio" ValidationGroup="add" Display="Dynamic" runat="server" />
                                                </div>
                                                <!-- lj_fecha_final -->
                                                <div class="form-group col-md-4">
                                                    <label class="form-control-label" for="Txt_ab_fecha_fin">Fecha Fin</label>
                                                    <div class="input-group">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text">
                                                                <i class="fas fa-edit"></i>
                                                            </span>
                                                        </div>
                                                        <asp:TextBox ID="Txt_ab_fecha_fin" CssClass="form-control datepickerDefault" OnTextChanged="Txt_ab_fecha_fin_TextChanged" AutoPostBack="true" runat="server" />
                                                    </div>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_ab_fecha_fin" ValidationGroup="add" Display="Dynamic" runat="server" />
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col">                                                    
                                                    <asp:LinkButton ID="btnfamiliares" CssClass="btn btn-info btn-flat btn-sm" Text="<i class='fas fa-users'></i>" OnClick="BtnFamiliares_Click" runat="server" ToolTip="Agregar Beneficiario" Visible="false" />
                                                    <asp:Literal ID="ltbeneficiario" runat="server" />
                                                    <asp:Literal ID="Lbl_mes_gestion" runat="server" />
                                                    <asp:Literal ID="Lblmes" runat="server" /><asp:DropDownList ID="ddlmes" CssClass="form-control" data-toggle="select" AppendDataBoundItems="true" runat="server" Visible="False"  OnSelectedIndexChanged="ddlmes_SelectedIndexChanged" AutoPostBack="true"/>
                                                </div>
                                            </div>

                                        </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                          
                          <div id="dGvLBenef" class="card" style="display: none;">
                                <div class="card-header border-bottom">
                                    <div class="ct-page-title">
                                        <h3 class="mb-0">Lista de Beneficiarios</h3>
                                        <p class="text-sm mb-0"></p>
                                           <asp:HiddenField ID="Hf_ab_id" runat="server" />
                                    </div>
                                </div>
                                <div class="card-body">
                                    <asp:GridView ID="GvListaBenef" CssClass="table table-bordered table-hover table-striped table-responsive" AutoGenerateColumns="false" DataKeyNames="ab_id" OnPreRender="GvListaBenef_PreRender" OnRowCommand="GvListaBenef_RowCommand" runat="server">
                                         <Columns>
                                            <asp:BoundField DataField="ab_id" HeaderText="Cod. Asig." />
                                             <asp:BoundField DataField="ab_aeb_id" HeaderText="Cod. Benef" />                                            
                                            <asp:BoundField DataField="pf_paterno" HeaderText="Apellido Paterno" />
                                            <asp:BoundField DataField="pf_materno" HeaderText="Apellido Materno" />
                                            <asp:BoundField DataField="pf_nombres" HeaderText="Nombre(s)" />                                           
                                             <asp:BoundField DataField="pf_sexo" HeaderText="Sexo" />                                            
                                            <asp:BoundField DataField="pf_fecha_nac" HeaderText="Fecha Nacimiento" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" />
                                            <asp:BoundField DataField="pf_fecha_defuncion" HeaderText="Fecha Defuncion" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" />
                                             <asp:BoundField DataField="fa_descripcion" HeaderText="Subsidio" />
                                             <asp:BoundField DataField="ab_fecha_inicio" HeaderText="Fecha Inicio" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" />
                                             <asp:BoundField DataField="ab_fecha_fin" HeaderText="Fecha Fin" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" />
                                             <asp:BoundField DataField="ab_estado" HeaderText="Estado" />
                                            <asp:TemplateField HeaderText="Controles" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="130px" ShowHeader="True">
                                                <ItemTemplate>
                                                    <asp:LinkButton CommandName="Getab_id" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-primary btn-flat btn-sm" Text="<i class='ni ni-bulb-61'></i>" runat="server" />
                                                    <asp:LinkButton CommandName="Getab_id_eliminar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-flat btn-sm" Text="<i class='fa fa-trash'></i>" runat="server" />                                                
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="modal-footer border-top">
                            <asp:LinkButton ID="BtnGuardar" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Guardar" ValidationGroup="add" OnClick="BtnGuardar_Click" runat="server" />
                            <asp:LinkButton ID="BtnCancelar" CssClass="btn btn-google-plus" Text="<i class='fas fa-times'></i> Cancelar" OnClick="BtnCancelar_Click" runat="server" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- Add Record Modal Ends here -->


    <!-- Add Record Modal Starts here -->
    <div id="dGvBenef" class="modal fade" role="dialog" data-backdrop="static" data-keyboard="false">
        <div id="mbeneficiarios" class="modal-dialog modal-lg-kcpbxl" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="upbeneficiarios" runat="server">
                    <ContentTemplate>
                        <div class="modal-header">
                            <h4 class="modal-title">Lista de Beneficiarios</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md">
                                    <asp:GridView ID="GvListaFamily" CssClass="table table-bordered table-hover table-striped table-responsive " AutoGenerateColumns="false" DataKeyNames="pf_id" OnPreRender="GvListaFamily_PreRender" OnRowCommand="GvListaFamily_RowCommand" runat="server">
                                        <Columns>
                                            <asp:BoundField DataField="pf_nom_parentesco" HeaderText="Tipo Parentesco" />
                                            <asp:BoundField DataField="pf_paterno" HeaderText="Apellido Paterno" />
                                            <asp:BoundField DataField="pf_materno" HeaderText="Apellido Materno" />
                                            <asp:BoundField DataField="pf_nombres" HeaderText="Nombre(s)" />
                                            <asp:BoundField DataField="pf_ap_esposo" HeaderText="Apellido Esposo" />
                                            <asp:BoundField DataField="pf_fecha_nac" HeaderText="Fecha Nacimiento" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" />
                                            <asp:BoundField DataField="pf_sexo" HeaderText="Sexo" />
                                            <asp:BoundField DataField="Estado_Vivo" HeaderText="Estado Vivo" />
                                            <asp:BoundField DataField="pf_fecha_defuncion" HeaderText="Fecha Defuncion" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" />
                                            <asp:TemplateField HeaderText="" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="130px" ShowHeader="True">
                                            <ItemTemplate>
                                                <asp:LinkButton CommandName="Getpf_id" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-info btn-flat btn-sm" Text="<i class='ni ni-active-40'></i>" runat="server" />
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="modal-footer box-footer">
                                <asp:Button ID="btnCancelarBeneficiario" CssClass="btn btn-danger btn-flat" Text="CANCELAR" UseSubmitBehavior="false" OnClick="btnCancelarBeneficiario_Click" runat="server" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- Add Record Modal Ends here -->


    <!-- Add Record Modal Glosa -->

    <div id="addGlosa" class="modal fade" role="dialog" data-backdrop="static" data-keyboard="false">
        <div id="mAddDarBaja" class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="upGlosa" runat="server">
                    <ContentTemplate>
                        <div class="modal-header">
                            <h2 class="modal-title">ASIGNACION FAMILIAR - 
                            <asp:Label ID="lblaccionglosa" runat="server"></asp:Label>

                            </h2>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <!-- Diseño para el dropdownlist tipo documento -->
                                    <div class="form-group">
                                        <label class="control-label">Tipo de Documento</label>
                                        <div class="input-group">
                                            <asp:DropDownList ID="ddl_gl_tipo_doc" CssClass="form-control" data-toggle="select" AppendDataBoundItems="true" runat="server" />
                                            <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="El campo es obligatorio...!!" ControlToValidate="ddl_gl_tipo_doc" ValidationGroup="addglosa" InitialValue="0" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <!-- Diseño para el datetime fecha documento -->
                                    <div class="form-group">
                                        <label class="control-label">Fecha del Documento</label>
                                        <div class="input-group">
                                            <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                            <asp:TextBox ID="txt_gl_fecha_doc" CssClass="form-control datepicker inputmask" runat="server" />
                                            <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="El campo es obligatorio...!!" ControlToValidate="txt_gl_fecha_doc" ValidationGroup="addglosa" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <!-- Diseño para el textbox descripción glosa -->
                                    <div class="form-group">
                                        <label class="control-label">Descripción del Documento</label>
                                        <div class="input-group">
                                            <asp:TextBox ID="txt_gl_glosa" CssClass="form-control" runat="server" TextMode="MultiLine" />
                                            <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="El campo es obligatorio...!!" ControlToValidate="txt_gl_glosa" ValidationGroup="addglosa" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnRegistrarGlosa" CssClass="btn btn-success btn-flat" Text="REGISTRAR" ValidationGroup="addglosa" UseSubmitBehavior="false" OnClick="btnRegistrarGlosa_Click" runat="server" />
                            <asp:Button ID="btnCancelarGlosa" CssClass="btn btn-danger btn-flat" Text="CANCELAR" UseSubmitBehavior="false" OnClick="btnCancelarGlosa_Click" runat="server" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnRegistrarGlosa" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnCancelarGlosa" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <!-- Add Record Modal Ends here -->


</asp:Content>

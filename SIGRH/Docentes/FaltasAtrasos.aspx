<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="FaltasAtrasos.aspx.cs" Inherits="Docentes_FaltasAtrasos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="header pb-6" style="margin-top: -4em; margin-left: 3em; width: 81%">
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Faltas y Atrasos Docentes</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
    <div class="container-fluid mt--6">
        <div class="row">
            <div class="col">
                <div class="card-wrapper">
                    <div class="card">
                        <div class="card-header">
                            <div class=" ct-page-title">
                                <h3 class="mb-0">Registrar la cantidad de horas trabajadas por docente para el mes actual <asp:Literal ID="ltl_only_name" runat="server" /> </h3>
                                <p class="text-sm mb-0">
                                    Registrar la cantidad de horas trabajadas por docente para el mes actual
                                </p>
                            </div>
                        </div>
                        <div class="col">
                            <div class="row">
                                <div class="form-group col-md-4">
                                    <label class="form-control-label" for="Ddl_as_tipo_baja">Seleccione la Unidad Organizacional: </label>
                                    <asp:DropDownList ID="ddlUnidades1" CssClass="form-control select2" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlUnidades_SelectedIndexChanged" AutoPostBack="true" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="card-body" style="margin-top: 4em">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:HiddenField ID="f_h" runat="server" />
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                    <asp:GridView ID="gv_horas_docentes" OnRowDataBound="gv_horas_docentes_RowDataBound" CssClass="table table-bordered table-hover table-striped" PageSize="10" AutoGenerateColumns="false" OnPreRender="gv_horas_docentes_PreRender" DataKeyNames="mc_id, as_per_id, as_id, as_validacion" runat="server">
                                        <Columns>
                                            <asp:BoundField DataField="NOMBRE_COMPLETO" HeaderText="NOMBRE COMPLETO" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="MATERIA_TITULAR" HeaderText="MATERIA TITULAR" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="MATERIA_ASIGNADA" HeaderText="MATERIA ASIGNADA" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="UNIDAD" HeaderText="UNIDAD DE TRABAJO" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            
                                            <asp:TemplateField HeaderText="HORAS TRABAJADAS POR MES" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="130px">
                                                <ItemTemplate>
                                                    <asp:Label Text='<%# Eval("PDH_HORA").ToString() %>' ID="lblHoras" Visible="false" runat="server" />
                                                    <asp:TextBox ID="txtHoras" CssClass="form-control numero text-center" TextMode="Number" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="FALTAS POR MES" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="130px">
                                                <ItemTemplate>
                                                    <asp:Label Text='<%# Eval("ht_faltas").ToString() %>' ID="lblFaltas" Visible="false" runat="server" />
                                                    <asp:TextBox ID="txtFaltas" CssClass="form-control numero text-center" TextMode="Number" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ATRASOS POR MES" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="130px">
                                                <ItemTemplate>
                                                    <asp:Label Text='<%# Eval("ht_atrasos").ToString() %>' ID="lblAtrasos" Visible="false" runat="server" />
                                                    <asp:TextBox ID="txtAtrasos" CssClass="form-control numero text-center" TextMode="Number" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-CssClass="text-center">
                                                <HeaderTemplate>
                                                    <span class="">ESTADO</span>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <label class="custom-toggle custom-toggle-yout" ID="lblchk_select" Text='<%# Eval("as_validacion").ToString() %>' >
                                                        <asp:CheckBox ID="chk_select" runat="server" AutoPostBack="True" oncheckedchanged="OnChange_chk_select"/>
                                                        <span class="custom-toggle-slider rounded-circle" data-label-off="P" data-label-on="S"></span>
                                                    </label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ht_estado" HeaderText="ht_estado" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlUnidades1" EventName="SelectedIndexChanged" />
                                    
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                        <div class="form-group text-center">
                            <asp:LinkButton ID="btnGuardarHorasDocentes" CssClass="btn btn-success" Text="<i class='fas fa-save mr-2'></i> Guardar" OnClick="btnGuardarHorasDocentes_Click" ValidationGroup="Baja_as" runat="server" />
                            <asp:Button ID="btnValidar" Text="Validar" OnClick="BtnValidar_Click"  CssClass="btn btn-primary" runat="server" UseSubmitBehavior="false" />
                            <asp:LinkButton ID="btnDevalidar" Text="Desvalidar" OnClick="btnDevalidar_Click" CssClass="btn btn-danger" runat="server" />
                            <asp:LinkButton ID="btnAprobar" Text="Aprobar" OnClick="btnAprobar_Click" CssClass="btn btn-warning" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


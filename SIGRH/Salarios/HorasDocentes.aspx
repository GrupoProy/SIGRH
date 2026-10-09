<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="HorasDocentes.aspx.cs" Inherits="Salarios_HorasDocentes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
    <div class="container-fluid">
        <div class="header-body">
            <div class="row align-items-center py-4">
                <div class="col-lg-6 col-7">
                    <h6 class="h2 text-light d-inline-block mb-0">Registro de Horas de Docentes</h6>
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
                                <h3 class="mb-0">Registrar la cantidad de horas trabajadas por docente para el mes actual</h3>
                                <p class="text-sm mb-0">
                                    Registrar la cantidad de horas trabajadas por docente para el mes actual
                                </p>
                            </div>
                        </div>
                        <div class="col">
                            <div class="row">
                                <div class="form-group col-md-4">
                                    <label class="form-control-label" for="Ddl_as_tipo_baja">Seleccione la Unidad Organizacional: </label>
                                    <asp:DropDownList ID="ddlUnidades" CssClass="form-control select2"  AppendDataBoundItems="true"   OnSelectedIndexChanged="ddlUnidades_SelectedIndexChanged"  AutoPostBack="true" runat="server" />                                            
                                </div>
                                <div class="form-group col-md-4">
                                    <h3 class="mb-0">No registrados</h3>
                                    <label class="custom-toggle custom-toggle-warning">
                                    <asp:CheckBox ID="chkFaltantes" AutoPostBack="true"  OnCheckedChanged="chkFaltantes_CheckedChanged" runat="server" />
                                    <span class="custom-toggle-slider rounded-circle" data-label-off="No" data-label-on="Si"></span>
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="card-body" style="margin-top:4em" >
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gv_horas_docentes" OnRowDataBound="gv_horas_docentes_RowDataBound" CssClass="table table-bordered table-hover table-striped" PageSize="10" AutoGenerateColumns="false" OnPreRender="gv_horas_docentes_PreRender"  DataKeyNames="as_per_id, pdh_id, as_id" runat="server" >
                                        <Columns>
                                            <asp:BoundField DataField="NOMBRE_COMPLETO" HeaderText="NOMBRE COMPLETO" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="cargo_puesto" HeaderText="CARGO/PUESTO" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="UNIDAD" HeaderText="UNIDAD DE TRABAJO" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"  />
                                            <asp:TemplateField HeaderText="HORAS TRABAJADAS POR MES" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="130px">
                                                <ItemTemplate>
                                                    <asp:Label Text='<%# Eval("PDH_HORA").ToString() %>' ID="lblHoras" Visible="false" runat="server" />
                                                    <asp:TextBox ID="txtHoras"    CssClass="form-control numero text-center" TextMode="Number"  runat="server" />                                                    
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlUnidades" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="chkFaltantes" EventName="CheckedChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                            <div class="form-group text-center">
                                <asp:LinkButton ID="btnGuardarHorasDocentes" CssClass="btn btn-success" Text="<i class='fas fa-save mr-2'></i> Guardar" OnClick="btnGuardarHorasDocentes_Click" ValidationGroup="Baja_as"  runat="server" />
                                <asp:LinkButton ID="btnLimpiar" CssClass="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i> Limpiar" runat="server" />
                            </div>

                    </div>

                </div>

        </div>
    </div>

</div>
</asp:Content>


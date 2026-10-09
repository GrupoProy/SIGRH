<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ProcesarAsistencia.aspx.cs" Inherits="ControlPersonal_ProcesarAsistencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Procesar Asistencia</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid mt--6">
        <div class="row">
            <div class="col-lg-4">
                <div class="card-wrapper">
                    <div class="card">
                        <div class="card-header">
                            <div class="row align-items-center">
                                <div class="col-12">
                                    <div class=" ct-page-title">
                                        <h3 class="mb-0">Datos</h3>
                                        <p class="text-sm mb-0">
                                            Seleccione el tipo de funcionario, gestion y mes o personal de acuerdo a rango de fechas (personal vigente) y/o codigos de funcionario de la lista.
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="card-body">
                            <asp:Panel runat="server">
                                <div class="row">
                                    <h6 class="heading-small text-muted mb-1">Datos para procesar asistencia deacuerdo a fecha o por lista (*)</h6>
                                    <label class="form-control-label" for="example4cols7Input">&nbsp</label>
                                    <div class="row">
                                        <div class="form-check form-check">
                                            <asp:RadioButton ID="rdFechas" GroupName="rdPersonal" Text="Procesar asistencia por tipo de personal" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label class="form-control-label" for="exampleFormControlSelect1">Tipo de Personal</label>
                                            <asp:DropDownList ID="ddl_tipo" AppendDataBoundItems="true" CssClass="form-control select2" AutoPostBack="true" runat="server"></asp:DropDownList>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_tipo" InitialValue="0" Display="Dynamic" ValidationGroup="buscar_validacion" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class="form-group">
                                            <label class="form-control-label" for="exampleFormControlSelect1">Gestion</label>
                                            <asp:DropDownList ID="ddl_gestion" AppendDataBoundItems="true" CssClass="form-control select2" AutoPostBack="true" runat="server"></asp:DropDownList>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_gestion" InitialValue="0" Display="Dynamic" ValidationGroup="buscar_validacion" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="form-group">
                                            <%--<label class="form-control-label" for="example4cols7Input">&nbsp</label>--%>
                                            <div class="form-group">
                                                <label class="form-control-label" for="exampleFormControlSelect1">Mes</label>
                                                <asp:DropDownList ID="ddl_mes" AppendDataBoundItems="true" CssClass="form-control select2" AutoPostBack="true" runat="server"></asp:DropDownList>
                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_mes" InitialValue="0" Display="Dynamic" ValidationGroup="buscar_validacion" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                            <br />
                            
                            <div class="pl-lg-12">
                                <div class="row">
                                    <div class="form-check">
                                        <asp:RadioButton ID="rdLista" GroupName="rdPersonal" Text="Personal de la lista" runat="server" />
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <textarea id="txtLista" runat="server"></textarea>
                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtLista" InitialValue="0" Display="Dynamic" ValidationGroup="Listar" runat="server" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="pl-lg-6">
                                    <asp:LinkButton ID="btnListarFunc" OnClick="btnListarFunc_Click" CssClass="btn btn-info btn-block" Text="<i class='fas fa-search'></i> Listar" ValidationGroup="Listar" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <%-- Grid --%>
            <div class="col-lg-8">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="funcio_result" CssClass="card" Visible="false" runat="server">
                            <div class="card-header border-bottom">
                                <h3 class="mb-0">Lista de Funcionarios</h3>
                            </div>
                            <div class="card-body">
                                <asp:GridView ID="GvFuncionarios" EmptyDataText="No hay registros" OnPreRender="GvFuncionarios_PreRender" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="per_id" HeaderText="Codigo Funcionario" />
                                        <asp:BoundField DataField="NOMBRE_COMPLETO" HeaderText="Nombre" />

                                        <%--<asp:TemplateField HeaderText="Cambiar Estado" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="BtnModificar" CommandName="Eliminar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-ban'></i></span>" data-toggle='tooltip' data-placement='top' title='Cambiar Estado' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>
                                <div class="row">
                                    <div class="col-lg-3">

                                    </div>
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <label class="form-control-label" for="exampleFormControlSelect1">Fecha Inicio</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                </div>
                                                <asp:TextBox ID="txt_fecha_inicio" AutoComplete="off" CssClass="form-control datepickerDefault" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_fecha_inicio" ValidationGroup="Procesar" Display="Dynamic" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <label class="form-control-label" for="exampleFormControlSelect1">Fecha Fin</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                </div>
                                                <asp:TextBox ID="txt_fecha_fin" AutoComplete="off" CssClass="form-control datepickerDefault" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_fecha_fin" ValidationGroup="Procesar" Display="Dynamic" runat="server" />
                                        </div>
                                    </div>
                                    <div class="pl-lg-3">
                                        <label class="form-control-label" for="example4cols7Input">&nbsp</label>
                                        <asp:LinkButton ID="btnProcesar" OnClick="btnProcesar_Click" CssClass="btn btn-info btn-block" Text="<i class='fas fa-clock'></i> Procesar Asistencias" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnListarFunc" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
<%@ Page Title="Lista de Items" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ListaItems.aspx.cs" Inherits="MovimientoPersonal_Lista_Item" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <asp:UpdatePanel runat="server" ID="UpdateListaItems">
        <ContentTemplate>
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Creación de Items de Contrato o Consultoria</h6>

                    </div>
                    <div class="col-lg-6 col-5 text-right">
                        <asp:LinkButton ID="btn_nuevo_item" CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-inst text-white rounded-circle shadow" Text="<i class='fas fa-plus'></i>" data-toggle="tooltip" data-original-title="Crear Item" OnClick="btn_nuevo_item_Click" runat="server" />
                    </div>

                </div>
            </div>
        </div>
    </div>
    
    <div class="container-fluid mt--6">
        <div class="row">
            <div class="col">
                <div class="card">
            <div class="card-header">
                <div class=" ct-page-title">
                    <h3 class="mb-0"> </h3>
                    <p class="text-sm mb-0">
                        Listado de items libres
                    </p>
                </div>
            </div>

                    <div class="table-responsive py-4">
                                <asp:GridView ID="gv_items" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_items_PreRender" OnRowCommand="gv_items_RowCommand" DataKeyNames="ca_id, ca_es_id, ca_eo_id, ca_num_item" runat="server">
                                    <Columns>


                                        <asp:BoundField DataField="cod_item" HeaderText="Item" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="es_descripcion" HeaderText="Cargo" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-bold" />
                                        <asp:BoundField DataField="haber_basico" HeaderText="Haber Básico (Bs)" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:0.00}" />

                                        <asp:BoundField DataField="eo_descripcion" HeaderText="Unidad Organizacional" HeaderStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="fecha_creacion" HeaderText="Fecha Creación"  HeaderStyle-CssClass="text-center"  ItemStyle-CssClass="text-center" />
                                        <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="130px">
                                            <ItemTemplate>
                                                <asp:LinkButton CommandName="GetEdit" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-warning btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-edit fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Editar' runat="server" />
                                                <asp:LinkButton CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-google-plus btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Eliminar' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                    </div>

                    <div class="modal fade" id="EditarItem" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                        <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                            <div class="modal-content">
                                        <div class="modal-body p-0">
                                            <div class="card bg-secondary border-0 mb-0">
                                                <div class="card-header">
                                                    <div class="text-muted text-center mt-2 mb-3"><small>EDITAR REGISTRO</small></div>
                                                </div>
                                                <div class="card-body px-lg-5 py-lg-3">
                                                    <div id="detalleitem">
                                                        <div class="row">
                                                            <div class="progress-info" style="padding-left: 15px; padding-right: 15px;">
                                                                <div class="tag-label">
                                                                    <span>Código Escalafón:<span class="tag-label-content"><asp:Literal ID="ltl_codigo" Text="" runat="server" /></span></span>
                                                                    <span>Clase:<span class="tag-label-content"><asp:Literal ID="ltl_clase" Text="" runat="server" /></span></span>
                                                                    <span>Nivel Salarial:<span class="tag-label-content"><asp:Literal ID="ltl_nivel_salarial" Text="" runat="server" /></span></span>
                                                                    <span class="tag-span-success">Haber Básico (Bs):<span class="tag-label-content"><asp:Literal ID="ltl_haber_basico" Text="" runat="server" /></span></span>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="form-control-label" for="exampleFormControlSelect1">Unidad Organizacional</label>
                                                        <asp:DropDownList ID="ddl_uunidad_org" AppendDataBoundItems="true" CssClass="form-control select2" OnSelectedIndexChanged="ddl_uunidad_org_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>

                                                    </div>

                                                    <div class="form-group">
                                                        <label class="form-control-label" for="exampleFormControlSelect1">Tipo Item</label>
                                                        <asp:DropDownList ID="ddl_tipo_item" AppendDataBoundItems="true" CssClass="form-control select2" runat="server"></asp:DropDownList>

                                                    </div>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="ddl_tipo_item" ValidationGroup="addItem" runat="server" />

                                                    <div class="form-group">
                                                        <label class="form-control-label" for="exampleFormControlSelect1">Cargo</label>
                                                        <asp:DropDownList ID="ddl_cargo" AppendDataBoundItems="true" CssClass="form-control select2" OnSelectedIndexChanged="ddl_cargo_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>

                                                    </div>

                                                    <div class="form-group">
                                                        <label class="form-control-label" for="exampleFormControlSelect1">Tipo Jornada</label>
                                                        <asp:DropDownList ID="ddl_tipo_jornada" AppendDataBoundItems="true" CssClass="form-control select2" data-minimum-results-for-search="Infinity" runat="server">
                                                        </asp:DropDownList>

                                                    </div>

                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group text-right">
                                                            </div>
                                                        </div>

                                                        <div class="col-md-3">
                                                            <div class="form-group text-right">
                                                                <asp:UpdatePanel runat="server">
                                                                    <ContentTemplate>
                                                                        <div>
                                                                            <label class="form-control-label" for="exampleFormControlSelect1">&nbsp</label>
                                                                            <asp:LinkButton ID="btnModificarItem" OnClick="btnModificarItem_Click" ValidationGroup="addItem" CssClass="btn btn-warning btn-block" Text="<i class='fas fa-edit'></i> Modificar" runat="server" />

                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group text-right">
                                                                <label class="form-control-label" for="exampleFormControlSelect1">&nbsp</label>
                                                                <button type="button" class="btn btn-outline-github btn-block" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div style="display: none">
                                                        <asp:HiddenField ID="p_ca_id" runat="server" />
                                                        <asp:HiddenField ID="p_ca_es_id" runat="server" />
                                                        <asp:HiddenField ID="p_ca_eo_id" runat="server" />
                                                        <asp:HiddenField ID="p_ca_num_item" runat="server" />
                                                        <asp:HiddenField ID="p_ca_id_anterior" runat="server" />
                                                        <asp:HiddenField ID="p_ca_haber_basico" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal fade" id="EditarItemMasivamente" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
                        <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                            <div class="modal-content">
                                        <div class="modal-body p-0">
                                            <div class="card bg-secondary border-0 mb-0">
                                                <div class="card-header">
                                                    <div class="text-muted text-center mt-2 mb-3"><small>EDITAR REGISTROS MASIVO </small></div>
                                                </div>
                                                <div class="card-body px-lg-5 py-lg-3">
                                                    <div id="detalleitemMasivo" style="display: none">
                                                        <div class="row">
                                                            <div class="progress-info" style="padding-left: 15px; padding-right: 15px;">
                                                                <div class="tag-label">
                                                                    <span>Código Escalafón:<span class="tag-label-content"><asp:Literal ID="ltl_codigo_masivo" Text="" runat="server" /></span></span>
                                                                    <span>Clase:<span class="tag-label-content"><asp:Literal ID="ltl_clase_masivo" Text="" runat="server" /></span></span>
                                                                    <span>Nivel Salarial:<span class="tag-label-content"><asp:Literal ID="ltl_nivel_salarial_masivo" Text="" runat="server" /></span></span>
                                                                    <span>Haber Básico (Bs):<span class="tag-label-content"><asp:Literal ID="ltl_haber_basico_masivo" Text="" runat="server" /></span></span>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="form-control-label" for="exampleFormControlSelect1">Unidad Organizacional</label>
                                                        <asp:DropDownList ID="ddl_uunidad_org_masivo" AppendDataBoundItems="true" CssClass="form-control select2" OnSelectedIndexChanged="ddl_uunidad_org_masivo_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="form-control-label" for="exampleFormControlSelect1">Tipo Item</label>
                                                        <asp:DropDownList ID="ddl_tipo_item_masivo" AppendDataBoundItems="true" CssClass="form-control select2" runat="server"></asp:DropDownList>

                                                    </div>
                                                    <div class="form-group">
                                                        <label class="form-control-label" for="exampleFormControlSelect1">Cargo</label>
                                                        <asp:DropDownList ID="ddl_cargo_masivo" AppendDataBoundItems="true" CssClass="form-control select2" OnSelectedIndexChanged="ddl_cargo_masivo_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group text-right">
                                                            </div>
                                                        </div>

                                                        <div class="col-md-3">
                                                            <div class="form-group text-right">
                                                                <asp:UpdatePanel runat="server">
                                                                    <ContentTemplate>
                                                                        <div>
                                                                            <label class="form-control-label" for="exampleFormControlSelect1">&nbsp</label>
                                                                            <asp:LinkButton ID="btn_modificar_masivamente" CssClass="btn btn-warning btn-block" Text="<i class='fas fa-edit'></i> Modificar" OnClick="btn_modificar_masivamente_Click" runat="server" />

                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group text-right">
                                                                <label class="form-control-label" for="exampleFormControlSelect1">&nbsp</label>
                                                                <button type="button" class="btn btn-outline-github btn-block" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                            </div>
                        </div>
                    </div>
                    <!-- Modal Eliminar Item -->
                    <div class="modal fade" id="eliminarItem" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                        <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                            <div class="modal-content bg-gradient-dark6">
                                <div class="modal-header">

                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    </button>
                                </div>

                                        <div class="modal-body">
                                            <div class="py-3 text-center">
                                                <i class="ni ni-fat-remove ni-3x"></i>
                                                <h4 class="heading text-dark mt-4">¿Esta seguro de eliminar Item?</h4>
                                            </div>
                                        </div>
                                        <div class="form-group text-center">
                                            <asp:LinkButton ID="btnEliminarResultado" OnClick="btnEliminarResultado_Click" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" runat="server" />
                                            <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                        </div>
                            </div>
                        </div>
                    </div>
                    <!-- Modal Confirmacion Editar Item -->
                    <div class="modal fade" id="confirm_edit_item" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                        <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                            <div class="modal-content bg-gradient-dark6">
                                <div class="modal-header">
                                </div>
                                        <div class="modal-body">
                                            <div class="py-3 text-center">
                                                <i class="ni ni-single-copy-04 ni-3x"></i>
                                                <h4 class="heading text-dark mt-4">¿Está seguro de modificar el item?</h4>
                                            </div>
                                        </div>
                                        <div class="form-group text-center">
                                            <asp:LinkButton ID="btn_modificar_item" OnClick="btn_modificar_item_Click" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" runat="server" />
                                            <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                        </div>
                            </div>
                        </div>
                    </div>
                    <!-- Modal Confirmacion Masiva Editar Item -->
                    <div class="modal fade" id="confirm_edit_item_masivo" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                        <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                            <div class="modal-content bg-gradient-dark6">
                                <div class="modal-header">
                                </div>

                                        <div class="modal-body">
                                            <div class="py-3 text-center">
                                                <i class="ni ni-single-copy-04 ni-3x"></i>
                                                <h4 class="heading text-dark mt-4">¿Está seguro de modificar los item(s) seleccionado(s)?</h4>
                                            </div>
                                        </div>
                                        <div class="form-group text-center">
                                            <asp:LinkButton ID="btn_modificar_item_masivo" OnClick="btn_modificar_item_masivo_Click" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" runat="server" />
                                            <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                        </div>
                            </div>
                        </div>
                    </div>
    <div id="ConfirmacionModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="glosaTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header border-bottom">
                    <div class="ct-page-title">
                        <h5  class="modal-title">Creación de Items</h5>
                        <p class="text-sm mb-0">Seleccione el tipo de item que desea crear...</p>
                    </div>
                </div>
                <div class="modal-body">
                 <div class="form-group col-md-12">
                                    <div class="custom-control custom-radio">
                                        <asp:RadioButtonList ID="rblTipo" CssClass="radios" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblTipo_SelectedIndexChanged1" runat="server">
                                            <asp:ListItem  Value="C" Text="Contrato/Consultoria" />
                                            <asp:ListItem Value="P" Text="Planta" />
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                </div>
            </div>
        </div>
    </div>





                </div>

            </div>
        </div>



    </div>
        </ContentTemplate>
    </asp:UpdatePanel>    
    <asp:UpdateProgress  ID="UP" AssociatedUpdatePanelID="UpdateListaItems" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>


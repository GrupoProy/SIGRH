<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="AsignacionAdicionalDocentes.aspx.cs" Inherits="Administración_AsignacionAdicionalDocentes" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:-1em;width:75%">
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Planillas de Cursos de Temporada o Examenes de Mesa</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:UpdatePanel ID="Up_list" runat="server">
        <ContentTemplate>
            <asp:Panel ID="P_lista" CssClass="card  top--6"  runat="server">
                <div class="card-header">
                    <div class="ct-page-title">
                        <h3 class="mb-0">Listado de asignaciones</h3>
                        <p class="text-sm mb-0"></p>
                    </div>
                </div>
                <div class="card-body">
                    <asp:GridView ID="GvLista" CssClass="table table-bordered table-hover table-striped" EmptyDataText="No existen registros para procesar" OnPreRender="GvLista_PreRender" AutoGenerateColumns="false"  runat="server">
                        <Columns>
                            <asp:BoundField DataField="contador" HeaderText="No." />
                            <asp:BoundField DataField="per_num_doc" HeaderText="CI" />
                            <asp:BoundField DataField="NOMBRE_COMPLETO" HeaderText="Nombre" />
                            <asp:BoundField DataField="td_carrera" HeaderText="Carrera"  />
                            <asp:BoundField DataField="td_tipo_docente" HeaderText="Tipo" />
                            <asp:BoundField DataField="FECHAS" HeaderText="Inicio" />
                            <asp:BoundField DataField="td_horas" HeaderText="Horas"  ItemStyle-CssClass="text-center" />
                            <asp:BoundField DataField="td_total_ganado" HeaderText="Total Ganado"  DataFormatString="{0:C2}"  ItemStyle-CssClass=" text-right"/>
                            <asp:BoundField DataField="td_desc_asistencia" HeaderText="Desc. Asistencia"  DataFormatString="{0:C2}"  ItemStyle-CssClass="text-right"/>
                            <asp:BoundField DataField="td_desc_otros" HeaderText="Desc. Otros" DataFormatString="{0:C2}"  ItemStyle-CssClass="text-right"/>

<%--                            <asp:TemplateField HeaderText="Controles" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDelete" CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-warning btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash'></i></span>" data-toggle="tooltip" data-placement="top" title="Eliminar" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

   <div class="offset-lg-12 col-lg-12 top--7" >
        <asp:LinkButton ID="BtnProcesar" CssClass="btn btn-success btn-block"  Text="<i class='fas fa-save'></i> Procesar" OnClick="BtnProcesar_Click" runat="server" />
       <asp:LinkButton ID="BtnReporte" CssClass="btn btn-success btn-block"  Text="<i class='fas fa-cogs'></i> Ver Reporte" OnClick="BtnReporte_Click" runat="server" />
   </div>
</asp:Content>


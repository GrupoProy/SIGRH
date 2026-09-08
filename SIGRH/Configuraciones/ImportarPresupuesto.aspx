<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ImportarPresupuesto.aspx.cs" Inherits="Configuraciones_ImportarPresupuesto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Registro de Presupuesto</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid mt--6">
        <div class="row">
            <div class="col-xl-12">
                <div class="card">
                    <div class="card-body">
                        <div class="pb-2">
                            <label for="file-input" class="file-upload btn btn-vimeo btn-block">
                                <i class="fa fa-upload mr-2"></i>Importar Presupuesto
                                <input id="file-input" type="file" accept=".csv, application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/vnd.ms-excel">
                            </label>
                        </div>

                    </div>
                    <div class="table-responsive pt-4 pb-5" style="display: none">
                        <asp:UpdatePanel ID="up_gv_planilla" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gv_presup" CssClass="table table-bordered table-hover" OnPreRender="gv_presup_PreRender" OnRowCommand="gv_presup_RowCommand" runat="server">
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="table-responsive pt-4 pb-5">
                                               <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gv_presupuesto" CssClass="table table-bordered table-hover" OnPreRender="gv_presupuesto_PreRender" runat="server">
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
<%--                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gv_presupuesto" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" OnPreRender="gv_presupuesto_PreRender" DataKeyNames="pp_id" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="cp_da" HeaderText="DA" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="cp_ue" HeaderText="UE" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="cp_programa" HeaderText="PROGRAMA" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="cp_proyecto" HeaderText="PROYECTO" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="cp_actividad" HeaderText="ACTIVIDAD" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="cp_descripcion" HeaderText="Descripción" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-left" />
                                        <asp:BoundField DataField="cp_fuente" HeaderText="Fuente" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="cp_organismo" HeaderText="Organismo" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="pp_partida" HeaderText="Partida" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="pp_entidad_trans" HeaderText="E.T." HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="pp_monto" HeaderText="Monto" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:0.00}" />
                                        <asp:BoundField DataField="pp_saldo" HeaderText="Saldo" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:0.00}" />
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:LinkButton ID="btn_importar_grilla" Text="text" OnClick="btn_importar_grilla_Click" Style="display: none" runat="server" />
                            <asp:HiddenField ID="hf_data" runat="server" ClientIDMode="Static" />

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>

        </div>


    </div>
    <script>
        var input = document.getElementById('file-input')
        input.addEventListener('change', function () {
            alasql('SELECT * FROM FILE(?,{headers:true})', [event], function (data) {
                //console.log(data);
                hf_data.value = JSON.stringify(data);
                document.getElementById("<%=btn_importar_grilla.ClientID %>").click();
            });
        })
    </script>
</asp:Content>


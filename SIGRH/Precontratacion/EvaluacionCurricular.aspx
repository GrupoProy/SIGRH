<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" 
    AutoEventWireup="true" CodeFile="EvaluacionCurricular.aspx.cs" 
    Inherits="Precontrataciones_EvaluacionCurricular" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- ✅ SweetAlert2 CDN -->
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

    <asp:UpdatePanel runat="server" ID="UpdatePanelEval">
        <ContentTemplate>

            <!-- HEADER -->
            <div class="header pb-5" style="margin-top:-4em; margin-left:3em;width:81%">
                <div class="container-fluid">
                    <div class="header-body">
                        <div class="row align-items-center py-4">
                            <div class="col-lg-12">
                                <h6 class="h2 text-light d-inline-block mb-0">Evaluación Curricular</h6>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="container-fluid sig-card-wrap">

                <!-- ============ DATOS DEL POSTULANTE ============ -->
                <div class="sig-card sig-card-dark">
                    <div class="sig-card-head sig-head-dark">
                        <span class="sig-ico sig-ico-red"><i class="fas fa-user"></i></span>
                        <div>
                            <h4>Datos del postulante</h4>
                            <p>Información personal del candidato a evaluar.</p>
                        </div>
                        <span class="sig-head-badge">POSTULANTE</span>
                    </div>

                    <div class="sig-card-body-dark">
                        <div class="sig-panel-wrap">

                            <!-- Panel 1: datos personales -->
                            <div class="sig-panel">
                                <div class="sig-panel-head">
                                    <span class="sig-panel-label">Datos personales</span>
                                    <span class="sig-panel-ico sig-ico-red"><i class="fas fa-id-card"></i></span>
                                </div>
                                <div class="sig-panel-body">
                                    <div class="sig-fields-2">
                                        <div class="sig-field">
                                            <label>Nombre completo</label>
                                            <div class="sig-value"><asp:Literal ID="ltlNombre" runat="server" Text="—" /></div>
                                        </div>
                                        <div class="sig-field">
                                            <label>Carnet de identidad</label>
                                            <div class="sig-value"><asp:Literal ID="ltlCI" runat="server" Text="—" /></div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <!-- Panel 2: datos del cargo -->
                            <div class="sig-panel">
                                <div class="sig-panel-head">
                                    <span class="sig-panel-label">Datos del cargo</span>
                                    <span class="sig-panel-ico sig-ico-orange"><i class="fas fa-briefcase"></i></span>
                                </div>
                                <div class="sig-panel-body">
                                    <div class="sig-fields-1">
                                        <div class="sig-field">
                                            <label>Cargo postulado</label>
                                            <div class="sig-value sig-value-teal"><asp:Literal ID="ltlCargo" runat="server" Text="Sin cargo especificado" /></div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>

                <!-- ============ FORMACIÓN ACADÉMICA ============ -->
                <div class="sig-card">
                    <div class="sig-card-head">
                        <span class="sig-ico sig-ico-orange"><i class="fas fa-graduation-cap"></i></span>
                        <div>
                            <h4>Formación académica</h4>
                            <p>Marque con ✓ los títulos relacionados al cargo.</p>
                        </div>
                    </div>
                    <div class="sig-card-body">
                        <asp:GridView ID="gvFormacion" runat="server"
                            CssClass="sig-table"
                            AutoGenerateColumns="false"
                            DataKeyNames="CvForId"
                            GridLines="None"
                            EmptyDataText="Sin formación académica registrada">
                            <Columns>
                                <asp:BoundField DataField="GradoAcademico" HeaderText="Grado Académico" />
                                <asp:BoundField DataField="Carrera"        HeaderText="Carrera / Profesión" />
                                <asp:BoundField DataField="Institucion"    HeaderText="Institución" />
                                <asp:BoundField DataField="AnioEgreso"     HeaderText="Año" ItemStyle-CssClass="c" HeaderStyle-CssClass="c" />
                                <asp:TemplateField HeaderText="Relacionada" HeaderStyle-CssClass="c" ItemStyle-CssClass="c">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkEspecificaFor" runat="server"
                                            AutoPostBack="true"
                                            CssClass="sig-chk"
                                            Checked='<%# Eval("Especifica") %>'
                                            OnCheckedChanged="chkEspecificaFor_CheckedChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                        <div class="sig-foot">
                            <span class="sig-foot-label">Títulos relacionados al cargo</span>
                            <div class="sig-foot-stats">
                                <div class="sig-stat sig-stat-wide">
                                    <b><asp:Literal ID="ltlTotalForRel" runat="server" Text="0" /></b>
                                    <small>Total</small>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- ============ EXPERIENCIA GENERAL ============ -->
                <div class="sig-card">
                    <div class="sig-card-head">
                        <span class="sig-ico sig-ico-teal"><i class="fas fa-briefcase"></i></span>
                        <div>
                            <h4>Experiencia general</h4>
                            <p>Marque con ✓ las experiencias específicas al cargo.</p>
                        </div>
                    </div>
                    <div class="sig-card-body">
                        <asp:GridView ID="gvExpGeneral" runat="server"
                            CssClass="sig-table"
                            AutoGenerateColumns="false"
                            DataKeyNames="CvExpId"
                            GridLines="None"
                            EmptyDataText="Sin experiencias registradas">
                            <Columns>
                                <asp:BoundField DataField="Institucion" HeaderText="Institución" />
                                <asp:BoundField DataField="Cargo"       HeaderText="Cargo" />
                                <asp:BoundField DataField="Anios"       HeaderText="Años"  ItemStyle-CssClass="c" HeaderStyle-CssClass="c" />
                                <asp:BoundField DataField="Meses"       HeaderText="Meses" ItemStyle-CssClass="c" HeaderStyle-CssClass="c" />
                                <asp:BoundField DataField="Dias"        HeaderText="Días"  ItemStyle-CssClass="c" HeaderStyle-CssClass="c" />
                                <asp:TemplateField HeaderText="Específica" HeaderStyle-CssClass="c" ItemStyle-CssClass="c">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkEspecificaEval" runat="server"
                                            AutoPostBack="true"
                                            CssClass="sig-chk"
                                            Checked='<%# Eval("Especifica") %>'
                                            OnCheckedChanged="chkEspecificaEval_CheckedChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                        <div class="sig-foot">
                            <span class="sig-foot-label">Total experiencia general</span>
                            <div class="sig-foot-stats">
                                <div class="sig-stat"><b><asp:Literal ID="ltlTotalGenAnios" runat="server" Text="0" /></b><small>Años</small></div>
                                <div class="sig-stat"><b><asp:Literal ID="ltlTotalGenMeses" runat="server" Text="0" /></b><small>Meses</small></div>
                                <div class="sig-stat"><b><asp:Literal ID="ltlTotalGenDias"  runat="server" Text="0" /></b><small>Días</small></div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- ============ EXPERIENCIA ESPECÍFICA ============ -->
                <div class="sig-card">
                    <div class="sig-card-head">
                        <span class="sig-ico sig-ico-green"><i class="fas fa-bullseye"></i></span>
                        <div>
                            <h4>Experiencia específica</h4>
                            <p>Solo las experiencias marcadas arriba.</p>
                        </div>
                    </div>
                    <div class="sig-card-body">
                        <asp:GridView ID="gvExpEspecifica" runat="server"
                            CssClass="sig-table"
                            AutoGenerateColumns="false"
                            GridLines="None"
                            EmptyDataText="Marque las experiencias específicas en la tabla superior">
                            <Columns>
                                <asp:BoundField DataField="Institucion" HeaderText="Institución" />
                                <asp:BoundField DataField="Cargo"       HeaderText="Cargo" />
                                <asp:BoundField DataField="Anios"       HeaderText="Años"  ItemStyle-CssClass="c" HeaderStyle-CssClass="c" />
                                <asp:BoundField DataField="Meses"       HeaderText="Meses" ItemStyle-CssClass="c" HeaderStyle-CssClass="c" />
                                <asp:BoundField DataField="Dias"        HeaderText="Días"  ItemStyle-CssClass="c" HeaderStyle-CssClass="c" />
                            </Columns>
                        </asp:GridView>

                        <div class="sig-foot">
                            <span class="sig-foot-label">Total experiencia específica</span>
                            <div class="sig-foot-stats">
                                <div class="sig-stat"><b><asp:Literal ID="ltlTotalEspAnios" runat="server" Text="0" /></b><small>Años</small></div>
                                <div class="sig-stat"><b><asp:Literal ID="ltlTotalEspMeses" runat="server" Text="0" /></b><small>Meses</small></div>
                                <div class="sig-stat"><b><asp:Literal ID="ltlTotalEspDias"  runat="server" Text="0" /></b><small>Días</small></div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- ============ REQUISITO A EVALUAR ============ -->
                <asp:Panel ID="pnlRequisito" runat="server" Visible="false">
                    <div class="sig-card">
                        <div class="sig-card-head">
                            <span class="sig-ico sig-ico-navy"><i class="fas fa-clipboard-list"></i></span>
                            <div>
                                <h4>Requisito a evaluar</h4>
                                <p>Requisito normativo vinculado al cargo postulado.</p>
                            </div>
                        </div>
                        <div class="sig-card-body">

                            <asp:Panel ID="pnlMensajeAuto" runat="server" Visible="false">
                                <div class="sig-alert sig-alert-ok">
                                    <i class="fas fa-bolt"></i>
                                    <div>
                                        <strong>Requisito detectado automáticamente.</strong>
                                        <span>El sistema identificó el requisito correspondiente al cargo.</span>
                                    </div>
                                </div>
                            </asp:Panel>

                            <asp:Panel ID="pnlMensajeManual" runat="server" Visible="false">
                                <div class="sig-alert sig-alert-warn">
                                    <i class="fas fa-exclamation-triangle"></i>
                                    <div>
                                        <strong>Seleccione manualmente el requisito.</strong>
                                        <span>El cargo no tiene un requisito vinculado. Elija uno correspondiente.</span>
                                    </div>
                                </div>
                            </asp:Panel>

                            <div class="sig-field">
                                <label>Requisito</label>
                                <asp:DropDownList ID="ddlRequisito" runat="server"
                                    CssClass="form-control select2"
                                    AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlRequisito_SelectedIndexChanged" />
                            </div>
                        </div>
                    </div>
                </asp:Panel>

                <!-- ============ RESULTADO ============ -->
                <asp:Panel ID="pnlResultado" runat="server" Visible="false">

                    <div class="sig-card">
                        <div class="sig-card-head">
                            <span class="sig-ico sig-ico-navy"><i class="fas fa-list-check"></i></span>
                            <div>
                                <h4>Requisito seleccionado</h4>
                                <p>Parámetros de referencia para la evaluación.</p>
                            </div>
                        </div>
                        <div class="sig-card-body">
                            <div class="sig-req-grid">
                                <div class="sig-field span-2">
                                    <label>Formación requerida</label>
                                    <div class="sig-value"><asp:Literal ID="ltlReqFormacion" runat="server" Text="—" /></div>
                                </div>
                                <div class="sig-field">
                                    <label>Experiencia general requerida</label>
                                    <div class="sig-value"><asp:Literal ID="ltlReqExpGeneral" runat="server" Text="—" /></div>
                                </div>
                                <div class="sig-field">
                                    <label>Experiencia específica requerida</label>
                                    <div class="sig-value"><asp:Literal ID="ltlReqExpEspecifica" runat="server" Text="—" /></div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="sig-card">
                        <div class="sig-card-head">
                            <span class="sig-ico sig-ico-green"><i class="fas fa-check-double"></i></span>
                            <div>
                                <h4>Resultado de la evaluación</h4>
                                <p>Estado final de cada criterio.</p>
                            </div>
                        </div>
                        <div class="sig-card-body">
                            <div class="sig-eval-grid">
                                <div class="sig-eval-cell">
                                    <div class="sig-eval-title">Formación del postulante</div>
                                    <div class="sig-eval-body"><asp:Literal ID="ltlEvalFormacion" runat="server" Mode="PassThrough" Text="—" /></div>
                                </div>
                                <div class="sig-eval-cell">
                                    <div class="sig-eval-title">Experiencia general del postulante</div>
                                    <div class="sig-eval-body"><asp:Literal ID="ltlEvalExpGeneral" runat="server" Mode="PassThrough" Text="—" /></div>
                                </div>
                                <div class="sig-eval-cell">
                                    <div class="sig-eval-title">Experiencia específica del postulante</div>
                                    <div class="sig-eval-body"><asp:Literal ID="ltlEvalExpEspecifica" runat="server" Mode="PassThrough" Text="—" /></div>
                                </div>
                            </div>
                        </div>
                    </div>

                </asp:Panel>

                <!-- ACCIONES -->
                <div class="sig-actions">
                    <a href='ListaSolicitudes.aspx' class="btn btn-outline-secondary btn-md">
                        <i class="fas fa-arrow-left mr-1"></i> Atrás
                    </a>
                    <div class="sig-actions-right">
                        <a href='javascript:window.print()' class="btn btn-outline-primary btn-md">
                            <i class="fas fa-print mr-1"></i> Imprimir
                        </a>
                        <asp:LinkButton ID="btnGuardarEvaluacion" runat="server"
                            CssClass="btn sig-btn-save btn-md"
                            OnClick="btnGuardarEvaluacion_Click"
                            Visible="false">
                            <i class="fas fa-save mr-1"></i> Guardar Evaluación
                        </asp:LinkButton>
                    </div>
                </div>

            </div>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlRequisito" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>

    <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanelEval" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>

<style type="text/css">
    /* =========================================================
       SIGRH · Evaluación Curricular
       navy #1b2f55 · teal #00a8b5 · celeste tabla #dbe7f3
       texto #1e293b · muted #64748b · línea #e3e8ef
       ========================================================= */
    .sig-card-wrap {
        max-width: 1280px;
        padding-top: 2.2rem;
        padding-bottom: 5rem;
    }
    .sig-card-wrap * { box-sizing: border-box; }

    .sig-card {
        background: #fff;
        border: 1px solid #e3e8ef;
        border-radius: 6px;
        box-shadow: 0 2px 8px rgba(27,47,85,.08);
        margin-bottom: 1.1rem;
        overflow: hidden;
    }
    .sig-card-head {
        display: flex;
        align-items: center;
        gap: .85rem;
        padding: .9rem 1.4rem;
        border-bottom: 1px solid #e3e8ef;
        border-left: 4px solid #00a8b5;
        background: #fff;
    }
    .sig-card-head h4 { margin: 0; font-size: 1rem; font-weight: 700; color: #1b2f55; }
    .sig-card-head p  { margin: .1rem 0 0; font-size: .78rem; color: #64748b; }
    .sig-card-body { padding: 1.1rem 1.4rem 1.3rem; }

    .sig-card-dark {
        background: #1b2f55;
        border-color: #1b2f55;
        box-shadow: 0 4px 14px rgba(27,47,85,.22);
    }
    .sig-card-dark .sig-card-head {
        background: linear-gradient(180deg, #223a68 0%, #1b2f55 100%);
        border-bottom: 1px solid rgba(255,255,255,.10);
        border-left: 4px solid #00a8b5;
    }
    .sig-card-dark .sig-card-head h4 { color: #ffffff; }
    .sig-card-dark .sig-card-head p  { color: #b8c4da; }

    .sig-head-badge {
        margin-left: auto;
        padding: .35rem .8rem;
        background: #00a8b5;
        color: #ffffff;
        font-size: .66rem;
        font-weight: 800;
        letter-spacing: 1.2px;
        border-radius: 4px;
    }

    .sig-card-body-dark {
        background: #1b2f55;
        padding: 1.1rem 1.2rem 1.3rem;
    }
    .sig-panel-wrap {
        display: grid;
        grid-template-columns: 1.6fr 1fr;
        gap: 1rem;
    }
    .sig-panel {
        background: #ffffff;
        border-radius: 6px;
        overflow: hidden;
        box-shadow: 0 1px 3px rgba(0,0,0,.10);
    }
    .sig-panel-head {
        display: flex;
        align-items: center;
        justify-content: space-between;
        gap: .5rem;
        padding: .65rem 1rem;
        background: #f4f7fb;
        border-bottom: 1px solid #e7eef6;
    }
    .sig-panel-label {
        font-size: .68rem;
        font-weight: 700;
        letter-spacing: 1px;
        text-transform: uppercase;
        color: #64748b;
    }
    .sig-panel-ico {
        width: 26px; height: 26px;
        border-radius: 50%;
        display: inline-flex; align-items: center; justify-content: center;
        color: #fff; font-size: .68rem;
    }
    .sig-panel-body { padding: .95rem 1.1rem 1.1rem; }

    .sig-ico {
        width: 38px; height: 38px; flex: 0 0 38px;
        border-radius: 50%;
        display: inline-flex; align-items: center; justify-content: center;
        color: #fff; font-size: .9rem;
        box-shadow: 0 2px 6px rgba(0,0,0,.18);
    }
    .sig-ico-red    { background: #ef4b4b; }
    .sig-ico-orange { background: #f2842b; }
    .sig-ico-teal   { background: #00a8b5; }
    .sig-ico-green  { background: #1fbf8f; }
    .sig-ico-navy   { background: #2f4a7d; }

    .sig-grid-3 { display: grid; grid-template-columns: repeat(3, 1fr); gap: 1rem 1.5rem; }
    .sig-req-grid { display: grid; grid-template-columns: 1fr 1fr; gap: 1rem 1.5rem; }
    .sig-fields-1 { display: grid; grid-template-columns: 1fr; gap: .9rem; }
    .sig-fields-2 { display: grid; grid-template-columns: 1fr 1fr; gap: .9rem 1.2rem; }

    .sig-field { display: flex; flex-direction: column; gap: .25rem; }
    .sig-field.span-2 { grid-column: span 2; }
    .sig-field.span-3 { grid-column: span 3; }
    .sig-field label {
        margin: 0;
        font-size: .66rem;
        font-weight: 700;
        letter-spacing: .7px;
        text-transform: uppercase;
        color: #7b8aa0;
    }
    .sig-value {
        font-size: .92rem;
        font-weight: 600;
        color: #1b2f55;
        line-height: 1.35;
    }
    .sig-value-teal { color: #00899a; font-weight: 700; font-size: 1rem; }

    .sig-table { width: 100%; border-collapse: collapse; font-size: .84rem; margin: 0; }
    .sig-table > thead > tr > th {
        background: #dbe7f3;
        color: #1b2f55;
        font-weight: 700;
        font-size: .7rem;
        text-transform: uppercase;
        letter-spacing: .5px;
        padding: .7rem .85rem;
        border: 0;
        text-align: left;
    }
    .sig-table > tbody > tr > td {
        padding: .65rem .85rem;
        color: #1e293b;
        border-bottom: 1px solid #edf1f6;
        vertical-align: middle;
    }
    .sig-table > tbody > tr:nth-child(even) > td { background: #f7f9fc; }
    .sig-table > tbody > tr:hover > td { background: #eef6f8; }
    .sig-table .c { text-align: center; }
    .sig-table > tbody > tr > td[colspan] {
        text-align: center; color: #94a3b8; font-style: italic; padding: 1.4rem 1rem; background: #fff;
    }

    .sig-foot {
        display: flex;
        align-items: center;
        justify-content: space-between;
        gap: 1rem;
        flex-wrap: wrap;
        margin-top: .9rem;
        padding: .7rem 1rem;
        background: #f1f6fa;
        border: 1px solid #dbe7f3;
        border-left: 4px solid #00a8b5;
        border-radius: 6px;
    }
    .sig-foot-label { font-size: .8rem; font-weight: 700; color: #1b2f55; }
    .sig-foot-stats { display: flex; gap: .5rem; }
    .sig-stat {
        min-width: 74px;
        padding: .4rem .75rem;
        background: #1b2f55;
        border-radius: 6px;
        text-align: center;
        line-height: 1.1;
    }
    .sig-stat-wide { min-width: 90px; }
    .sig-stat b { display: block; font-size: 1.15rem; font-weight: 700; color: #fff; }
    .sig-stat small { display: block; font-size: .62rem; letter-spacing: .5px; text-transform: uppercase; color: #7fdbe4; margin-top: 2px; }

    .sig-chk { width: 17px; height: 17px; accent-color: #00a8b5; cursor: pointer; }

    .sig-alert {
        display: flex; gap: .7rem; align-items: flex-start;
        padding: .8rem 1rem; border-radius: 6px; font-size: .85rem;
        margin-bottom: 1rem; border-left: 4px solid transparent;
    }
    .sig-alert i { font-size: .95rem; margin-top: 1px; }
    .sig-alert strong { display: block; font-weight: 700; }
    .sig-alert span { display: block; font-size: .78rem; opacity: .85; margin-top: 2px; }
    .sig-alert-ok   { background: #ecfdf5; border-left-color: #1fbf8f; color: #065f46; }
    .sig-alert-warn { background: #fff7ed; border-left-color: #f2842b; color: #7c2d12; }

    .sig-eval-grid { display: grid; grid-template-columns: repeat(3, 1fr); gap: 1rem; }
    .sig-eval-cell {
        border: 1px solid #dbe7f3;
        border-top: 3px solid #1b2f55;
        border-radius: 6px;
        padding: 1rem;
        text-align: center;
        display: flex;
        flex-direction: column;
        gap: .65rem;
        background: #fff;
    }
    .sig-eval-title {
        font-size: .68rem; font-weight: 700; letter-spacing: .6px; text-transform: uppercase;
        color: #1b2f55; min-height: 2.4em; display: flex; align-items: center; justify-content: center;
    }
    .sig-eval-body { font-size: 1rem; }

    .sig-actions {
        display: flex; align-items: center; justify-content: space-between; gap: .75rem;
        margin-top: 1.25rem; padding: .9rem 1.4rem;
        background: #fff; border: 1px solid #e3e8ef; border-radius: 6px;
        box-shadow: 0 2px 8px rgba(27,47,85,.1);
        position: sticky; bottom: 1rem; z-index: 20;
    }
    .sig-actions-right { display: flex; gap: .5rem; }
    .sig-btn-save { background: #00a8b5; border-color: #00a8b5; color: #fff; }
    .sig-btn-save:hover { background: #00909b; border-color: #00909b; color: #fff; }

    .select2-container--open { z-index: 99999 !important; }
    .select2-dropdown { z-index: 99999 !important; }
    .select2-container--default .select2-selection--single .select2-selection__clear {
        margin-right: 18px !important; float: right !important;
    }

    @media (max-width: 991px) {
        .sig-panel-wrap { grid-template-columns: 1fr; }
        .sig-grid-3 { grid-template-columns: 1fr 1fr; }
        .sig-field.span-3 { grid-column: span 2; }
        .sig-eval-grid { grid-template-columns: 1fr; }
    }
    @media (max-width: 575px) {
        .sig-grid-3, .sig-req-grid, .sig-fields-2 { grid-template-columns: 1fr; }
        .sig-field.span-2, .sig-field.span-3 { grid-column: span 1; }
        .sig-foot { flex-direction: column; align-items: stretch; }
        .sig-foot-stats { justify-content: space-between; }
        .sig-stat { flex: 1; }
        .sig-actions { flex-direction: column-reverse; align-items: stretch; position: static; }
        .sig-actions-right { flex-direction: column-reverse; }
        .sig-actions .btn { width: 100%; }
    }

    @media print {
        .sig-actions, .load, .header { display: none !important; }
        .sig-card { box-shadow: none; break-inside: avoid; }
        .sig-stat { background: #fff; border: 1px solid #1b2f55; }
        .sig-stat b { color: #1b2f55; }
        .sig-stat small { color: #64748b; }
        .sig-card-dark { background: #fff; border: 1px solid #1b2f55; }
        .sig-card-dark .sig-card-head { background: #fff; border-bottom-color: #1b2f55; }
        .sig-card-dark .sig-card-head h4 { color: #1b2f55; }
        .sig-card-dark .sig-card-head p { color: #64748b; }
        .sig-card-body-dark { background: #fff; }
    }
</style>

<script type="text/javascript">
    function initSelect2() {
        var configs = [
            { id: '#<%= ddlRequisito.ClientID %>', placeholder: 'Seleccione Requisito...' }
        ];

        configs.forEach(function (cfg) {
            var $ddl = $(cfg.id);
            if ($ddl.length === 0) return;

            if ($ddl.hasClass('select2-hidden-accessible')) {
                $ddl.select2('destroy');
            }
            $ddl.next('.select2-container').remove();

            $ddl.select2({
                placeholder: cfg.placeholder,
                allowClear: true,
                width: '100%',
                language: { noResults: function () { return 'No se encontraron resultados'; } }
            });
        });
    }

    $(document).ready(function () { initSelect2(); });

    if (typeof Sys !== 'undefined' && Sys.WebForms && Sys.WebForms.PageRequestManager) {
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_pageLoaded(function () { initSelect2(); });
    }
</script>
</asp:Content>
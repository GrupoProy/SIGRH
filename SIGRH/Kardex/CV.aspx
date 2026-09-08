<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="CV.aspx.cs" Inherits="Kardex_CV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel runat="server" ID="panelCV">
        <ContentTemplate>    

    <div class="container-fluid">
        <div class="card">
            <div class="card-header border-bottom">
                <div class="ct-page-title">
                    <h3 class="mb-0">CURRICULUM</h3>
                    <p class="text-sm mb-0" runat="server" id="leyenda">Para Actualizar la información relacionada a su Hoja de Vida, haga click en comenzar</p>
                </div>
            </div>
            <br />
            <asp:Button ID="LinkButton1" OnClick="LinkButton1_Click"  CssClass="btn btn-block bg-gradient-green text-white" Height="50px" Text="COMENZAR" runat="server" />

            <div class="card-body" runat="server" id="divCV" visible="false">
        <div runat="server" ID="ViewDatosPersonales" >
            <div class="container-fluid mt--4">
                <div class="ct-example  card" style="padding-bottom: unset">
                    <div class="card-body">
                        <div class="card bg-light mb-4">
<%--                            <div class="row justify-content-center">
                                <div class="col-lg-3 order-lg-2">
                                    <div class="card-profile-image">
                                        <a href="#">
                                            <asp:Image ID="imgFun" class="rounded-circle" runat="server" />
                                        </a>
                                    </div>
                                </div>
                            </div>--%>
                            <div class="card-header bg-primary text-center border-0 pt-8 pt-md-4 pb-0 pb-md-4">
                                <h3 class="h2 text-white d-inline-block float-left mb-0"><i class="fas fa-id-card-alt mr-2"></i>Datos Personales</h3>
<%--                                <asp:LinkButton ID="btn_estado" class="btn btn-sm btn-info float-right" runat="server" />--%>
                            </div>
                            <div class="card-body">
                                <div class="media align-items-center">
                                    <div class="media-body">
                                                <div class="row">
                                                    <div class="col-xl-12 col-md-12">
                                                        <div class="card card-stats">
                                                            <div class="card-body">
                                                                <div class="row">
                                                                    <div class="col">
<%--                                                                        <h5 class="card-title text-uppercase text-muted mb-0">Información Personal</h5>
                                                                        <span class="h5">&nbsp</span>--%>
                                                                    </div>
                                                                    <div class="col-auto">
                                                                        <div class="icon icon-shape bg-gradient-red text-white rounded-circle shadow">
                                                                            <i class="ni ni-single-02"></i>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="row mt--5">
                                                                    <div class="col-lg-4">
                                                                        <div class="content-text-label">Nombre Completo</div>
                                                                        <div class="h5 font-weight-400 content-text">
                                                                            <asp:Literal ID="ltl_nombre_fun" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-3">
                                                                        <div class="content-text-label">Fecha de nacimiento</div>
                                                                        <div class="h5 font-weight-400 content-text content-text">
                                                                            <asp:Literal ID="ltl_fecha_nac" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-3">
                                                                        <div class="content-text-label">CI</div>
                                                                        <div class="h5 font-weight-400 content-text">
                                                                            <asp:Literal ID="ltl_num_doc" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-2">
                                                                        <div class="content-text-label">Sexo</div>
                                                                        <div class="h5 font-weight-400 content-text">
                                                                            <asp:Literal ID="ltl_genero" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-lg-4">
                                                                        <div class="content-text-label">Correo Electrónico</div>
                                                                        <div class="h5 font-weight-400 content-text">
                                                                            <asp:Literal ID="ltl_email" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-3">
                                                                        <div class="content-text-label">Teléfono Domicilio</div>
                                                                        <div class="h5 font-weight-400 content-text">
                                                                            <asp:Literal ID="ltl_telef_domicilio" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-3">
                                                                        <div class="content-text-label">Celular</div>
                                                                        <div class="h5 font-weight-400 content-text">
                                                                            <asp:Literal ID="ltl_telef_movil" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    </div>
                                                            <div class="row">
                                                                    <div class="col-lg-4">
                                                                        <div class="content-text-label">Ciudad de Residencia</div>
                                                                        <div class="h5 font-weight-400 content-text">
                                                                            <asp:Literal ID="ltl_residencia" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-3">
                                                                        <div class="content-text-label">Procedencia</div>
                                                                        <div class="h5 font-weight-400 content-text">
                                                                            <asp:Literal ID="ltl_pais" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-3">
                                                                        <div class="content-text-label">Estado civil</div>
                                                                        <div class="h5 font-weight-400 content-text">
                                                                            <asp:Literal ID="ltl_estado_civil" runat="server" />
                                                                        </div>
                                                                    </div>
                                                            </div>
                                                            <div class="row">
                                                                    <div class="col-lg-12">
                                                                        <div class="content-text-label">Dirección</div>
                                                                        <div class="h5 font-weight-400 content-text">
                                                                            <asp:Literal ID="ltl_direccion" runat="server" />
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
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
        <div runat="server" ID="ViewFormacion" >
        <div class="container-fluid">
                <div class="ct-example  card" style="padding-bottom: unset">
                    <div class="card-body">
                        <div class="card bg-light mb-4">
                            <div class="card-header bg-gradient-close text-center border-0 pt-8 pt-md-4 pb-0 pb-md-4">
                                <h3 class="h2 text-white d-inline-block float-left mb-0"><i class="fas fa-id-card-alt mr-2"></i>FORMACIÓN</h3>
                            </div>


                            <div class="card-body">
                                <div class="media align-items-center">
                                    <div class="media-body">
                                       <div class="row">
                                        <div class="form-group col-md-3">
                                            <label class="form-control-label" for="Txt_per_nombres">Nivel</label>
                                            <div class="input-group input-group-merge">
                                                <asp:DropDownList ID="ddlFormacionNivel" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlFormacionNivel" ValidationGroup="add" Display="Dynamic" runat="server" />
                                        </div>

                            <div class="form-group col-md-5">
                                <label class="form-control-label" for="Txt_per_ap_casada">Institución</label>
                                <div class="input-group input-group-merge">
                                    <asp:DropDownList Visible="true" ID="ddlFormacion_Institucion" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlFormacion_Institucion" ValidationGroup="add" Display="Dynamic" runat="server" />
                            </div>
                            <div class="form-group col-md-4">
                                <label class="form-control-label" for="Txt_per_ap_casada">Carrera</label>
                                <div class="input-group input-group-merge">
                                    <asp:DropDownList Visible="true" ID="ddlFormacionCarrera" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlFormacionCarrera" ValidationGroup="add" Display="Dynamic" runat="server" />
                            </div>


                                
                                    </div>

                            <div class="row">
                                <div class="col-3"></div>
                                <div class="col-5 text-right">
                                    <asp:LinkButton ID="btnFormacion_NuevaInst" CssClass="mb-lst-chk"  runat="server"  AutoPostBack="true" OnClick="btnFormacion_NuevaInst_Click" Text="<i class='fas fa-plus'> Nueva Institución</i>"/>
                              </div>
                                <div class="col-4 text-right">
                                    <asp:LinkButton ID="btnFormacion_NuevaCarrera" CssClass="mb-lst-chk"  runat="server"  AutoPostBack="true"  OnClick="btnFormacion_NuevaCarrera_Click" Text="<i class='fas fa-plus'> Nueva Carrera</i>"/>
                                </div>
                            </div>

                             <div class="row">
                            <div class="form-group col-md-2">
                                <label class="form-control-label" for="Txt_per_ap_casada">Año Inicio</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="txtFormacionAñoInicio" CssClass="form-control number" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtFormacionAñoInicio" ValidationGroup="add" Display="Dynamic" runat="server" />
                            </div>
                            <div class="form-group col-md-2">
                                <label class="form-control-label" for="Txt_per_ap_casada">Año Fin</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="txtFormacionAñoFin" CssClass="form-control number" runat="server" />
                                </div>
                            </div>

                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Rbl_per_sexo">Título Provisión Nacional</label>
                                <div class="custom-control custom-radio">
                                    <asp:RadioButtonList ID="rblFormacionProvision" CssClass="radios" RepeatDirection="Horizontal"  runat="server">
                                        <asp:ListItem Value="1" Text="Si" />
                                        <asp:ListItem Value="0" Text="No" />
                                    </asp:RadioButtonList>
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="rblFormacionProvision" ValidationGroup="add" Display="Dynamic" runat="server" />
                            </div>
                    <div class="form-group col-md-3">
                        <div class="card-body text-right">
                            <asp:LinkButton ID="btnAdicionarFormacion"   CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Registrar" ValidationGroup="add"  runat="server" OnClick="btnAdicionarFormacion_Click" />
                        </div>
                    </div>
                    </div>
                    </div>
                    </div>
                    </div>
                        <div class="card col-11 ml-4">
                            <div class="card-header border-bottom">
                                <div class="ct-page-title">
                                    <h3 class="mb-0">Formación Académica</h3>
                                    <p class="text-sm mb-0"></p>
                                </div>
                            </div>
                            <div class="card-body">
                                        <asp:GridView ID="gvFormacione" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="cv_form_id"  OnRowCommand="gvFormacion_RowCommand" runat="server">
                                            <Columns>
                                                <asp:BoundField DataField="ga_nombre" HeaderText="Grado Académico" />
                                                <asp:BoundField DataField="it_nombre" HeaderText="Institución" />
                                                <asp:BoundField DataField="carr_nombre" HeaderText="Carrera" />
                                                <asp:BoundField DataField="cv_form_año_inicio" HeaderText="Inicio" />
                                                <asp:BoundField DataField="cv_form_año_fin" HeaderText="Fin" />
                                                <asp:BoundField DataField="cv_form_prov_nal" HeaderText="Provisión Nal." />
                                                <asp:TemplateField HeaderText="Eliminar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash'></i></span>" data-toggle='tooltip' data-original-title='Eliminar'/>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        </div>
        <div runat="server" ID="ViewCursos" >
            <div class="container-fluid">
                <div class="ct-example  card" style="padding-bottom: unset">
                    <div class="card-body">
                        <div class="card bg-light mb-4">
                            <div class="card-header bg-success text-center border-0 pt-8 pt-md-4 pb-0 pb-md-4">
                                <h3 class="h2 text-white d-inline-block float-left mb-0"><i class="fas fa-id-card-alt mr-2"></i>Cursos</h3>
                            </div>
                            <div class="card-body">
                                <div class="media align-items-center">
                                    <div class="media-body">
                                       <div class="row">

                            <div class="form-group col-md-4">
                                <label class="form-control-label" for="ddlCursos_Institucion">Institución</label>
                                <div class="input-group input-group-merge">
                                    <asp:DropDownList Visible="true" ID="ddlCursos_Institucion" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlCursos_Institucion" ValidationGroup="add1" Display="Dynamic" runat="server" />
                            </div>
                            <div class="form-group col-md-5">
                                <label class="form-control-label" for="ddlCursos_Curso">Nombre del Curso</label>
                                <div class="input-group input-group-merge">
                                    <asp:DropDownList Visible="true" ID="ddlCursos_Curso" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlCursos_Curso" ValidationGroup="add1" Display="Dynamic" runat="server" />
                            </div>

                            <div class="form-group col-md-1">
                                <label class="form-control-label" for="txtCursosDias">Carga Horaria</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="txtCursosDias" CssClass="form-control number" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtCursosDias" ValidationGroup="add1" Display="Dynamic" runat="server" />
                            </div>


                    <div class="card-body text-right">
                        <asp:LinkButton ID="btnAdicionarCursos"   OnClick="btnAdicionarCursos_Click"  CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Registrar" ValidationGroup="add1"   runat="server" />
                    </div>



                                       </div>
                            <div class="row mt--4">
                                <div class="col-4 text-right">
                                    <asp:LinkButton ID="btnCursos_NuevaInstitucion" OnClick="btnCursos_NuevaInstitucion_Click" CssClass="mb-lst-chk"  runat="server"  AutoPostBack="true"  Text="<i class='fas fa-plus'> Nueva Institución</i>"/>
                              </div>
                                <div class="col-5 text-right">
                                    <asp:LinkButton ID="btnCursos_NuevoCurso" OnClick="btnCursos_NuevoCurso_Click" CssClass="mb-lst-chk"  runat="server"  AutoPostBack="true"   Text="<i class='fas fa-plus'> Nuevo Curso</i>"/>
                                </div>
                            </div>
                                    </div>
                                </div>
                            </div>
            <div class="card col-11 ml-4">
            <div class="card-header border-bottom">
                <div class="ct-page-title">
                    <h3 class="mb-0">Cursos Atendidos</h3>
                    <p class="text-sm mb-0"></p>
                </div>
            </div>
            <div class="card-body">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvCursos" EmptyDataText="No existen registros de Cursos" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="asig_curs_per_id, asig_curs_cv_curs_id"    OnRowCommand="gvCursos_RowCommand" runat="server">
                            <Columns>
                                <asp:BoundField DataField="it_nombre" HeaderText="Institución" />
                                <asp:BoundField DataField="cv_curs_nombre_curso" HeaderText="Nombre del Curso" />
                                <asp:BoundField DataField="asig_curs_carga_horaria" HeaderText="Carga Horaria" />
                                <asp:TemplateField HeaderText="Eliminar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash'></i></span>" data-toggle='tooltip' data-original-title='Eliminar'/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

                        </div>
                    </div>
                </div>

            </div>
        </div>
        <div runat="server" ID="ViewTrayectoria"  >
            <div class="container-fluid">
                <div class="ct-example  card" style="padding-bottom: unset">
                    <div class="card-body">
                        <div class="card bg-light mb-4">
                            <div class="card-header bg-danger text-center border-0 pt-8 pt-md-4 pb-0 pb-md-4">
                                <h3 class="h2 text-white d-inline-block float-left mb-0"><i class="fas fa-id-card-alt mr-2"></i>Trayectoria Laboral</h3>
                            </div>
                            <div class="card-body">
                                <div class="media align-items-center">
                                    <div class="media-body">
                            <div class="row">
                                <div class="col-2 text-center">
                                    <label class="h3" for="Txt_per_ap_casada">DESDE</label>                            
                                </div>
                                <div class="col-2 text-center">
                                    <label class="h3" for="Txt_per_ap_casada">HASTA</label>                            
                                </div>
                            </div>

                                       <div class="row">
                            <div class="form-group col-md-1 text-center">
                                <label class="form-control-label" for="Txt_per_ap_casada">Mes</label>
                                <div class="input-group input-group-merge">
                                    <asp:TextBox ID="txtTrayectoriaMesInicio" CssClass="form-control number" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtTrayectoriaMesInicio" ValidationGroup="add2" Display="Dynamic" runat="server" />
                            </div>
                            <div class="form-group col-md-1 text-center">
                                <label class="form-control-label" for="Txt_per_ap_casada">Año</label>
                                <div class="input-group input-group-merge">
                                    <asp:TextBox ID="txtTrayectoriaAñoInicio" CssClass="form-control number" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtTrayectoriaAñoInicio" ValidationGroup="add2" Display="Dynamic" runat="server" />
                            </div>
                            <div class="form-group col-md-1 text-center">
                                <label class="form-control-label" for="Txt_per_ap_casada">Mes</label>
                                <div class="input-group input-group-merge">
                                    <asp:TextBox ID="txtTrayectoriaMesFin" CssClass="form-control number" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtTrayectoriaMesFin" ValidationGroup="add2" Display="Dynamic" runat="server" />
                            </div>
                            <div class="form-group col-md-1 text-center">
                                <label class="form-control-label" for="Txt_per_ap_casada">Año</label>
                                <div class="input-group input-group-merge">
                                    <asp:TextBox ID="txtTrayectoriaAñoFin" CssClass="form-control number" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtTrayectoriaAñoFin" ValidationGroup="add2" Display="Dynamic" runat="server" />
                            </div>
                            <div class="form-group col-md-3 text-center">
                                <label class="form-control-label" for="ddlTrayectoria_NuevaInstitucion">Institución</label>
                                <div class="input-group input-group-merge">
                                    <asp:DropDownList Visible="true" ID="ddlTrayectoria_NuevaInstitucion" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlTrayectoria_NuevaInstitucion" ValidationGroup="add2" Display="Dynamic" runat="server" />
                            </div>

                            <div class="form-group col-md-3 text-center">
                                <label class="form-control-label" for="txtTrayectoriaEspecialidad">Área de Especialidad</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="txtTrayectoriaEspecialidad" CssClass="form-control" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtTrayectoriaEspecialidad" ValidationGroup="add2" Display="Dynamic" runat="server" />
                            </div>

                            <div class="form-group col-md-2 text-center">
                                <label class="form-control-label" for="Txt_per_ap_casada">Último Cargo</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="txtTrayectoriaUltimoCargo" CssClass="form-control number" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtTrayectoriaUltimoCargo" ValidationGroup="add2" Display="Dynamic" runat="server" />
                            </div>
                    <div class="card-body text-right">
                        <asp:LinkButton ID="btnAdicionarTrayectoria" OnClick="btnAdicionarTrayectoria_Click"   CssClass="btn btn-success" Text="<i class='fas fa-plus'></i> Registrar" ValidationGroup="add2"  runat="server" />
                    </div>

                                       </div>

                            <div class="row mt--7">
                                <div class="col-1"></div>
                                <div class="col-1"></div>
                                <div class="col-1"></div>
                                <div class="col-1"></div>
                                <div class="col-3 text-right">
                                    <asp:LinkButton ID="btnTrayectoria_NuevaInstitucion" OnClick="btnTrayectoria_NuevaInstitucion_Click" CssClass="mb-lst-chk"  runat="server"  AutoPostBack="true"  Text="<i class='fas fa-plus'> Nueva Institución</i>"/>
                              </div>
<%--                                <div class="col-3 text-right">
                                    <asp:LinkButton ID="btnTrayectoria_NuevaEspecialidad" OnClick="btnTrayectoria_NuevaEspecialidad_Click" CssClass="mb-lst-chk"  runat="server"  AutoPostBack="true"   Text="<i class='fas fa-plus'> Nueva especialidad</i>"/>
                                </div>--%>
                            </div>
                                    </div>
                                </div>
                            </div>

        <div class="card col-11 ml-4 mt-5">
            <div class="card-header border-bottom">
                <div class="ct-page-title">
                    <h3 class="mb-0">Experiencia</h3>
                    <p class="text-sm mb-0"></p>
                </div>
            </div>
            <div class="card-body">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvTrayectoria" EmptyDataText="No existen registros de Experiencia Laboral" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="cv_exp_id"    OnRowCommand="gvTrayectoria_RowCommand" runat="server">
                            <Columns>
                                <asp:BoundField DataField="it_nombre" HeaderText="Institución" />
                                <asp:BoundField DataField="cv_exp_area_esp" HeaderText="Área de Especialidad" />
                                <asp:BoundField DataField="cv_exp_ultimo_cargo" HeaderText="Último Cargo Desempeñado" />
                                <asp:BoundField DataField="desde" HeaderText="Desde" />
                                <asp:BoundField DataField="hasta" HeaderText="Hasta" />
                                <asp:TemplateField HeaderText="Eliminar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash'></i></span>" data-toggle='tooltip' data-original-title='Eliminar'/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>


                        </div>
                    </div>
                </div>

            </div>
        </div>
        <div runat="server" ID="ViewIdiomas">
            <div class="container-fluid">
                <div class="ct-example  card" style="padding-bottom: unset">
                    <div class="card-body">
                        <div class="card bg-light mb-4">
                            <div class="card-header text-center border-0 pt-8 pt-md-4 pb-0 pb-md-4" style="background-color:#F3BB45">
                                <h3 class="h2 text-white d-inline-block float-left mb-0"><i class="fas fa-id-card-alt mr-2"></i>Idiomas</h3>
                            </div>
                            <div class="card-body">
                                <div class="media align-items-center">
                                    <div class="media-body">
                           
                                       
                   <div class="row">
                            <div class="form-group col-md-6 text-center">
                                <label class="form-control-label" for="ddlIdiomas_Idioma">Idioma</label>
                                <div class="input-group input-group-merge">
                                    <asp:DropDownList Visible="true" ID="ddlIdiomas_Idioma" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlIdiomas_Idioma" ValidationGroup="add3" Display="Dynamic" runat="server" />
                            </div>
                            <div class="form-group col-md-3 text-center">
                                    <label class="form-control-label" for="Ddl_pf_tipo_parentesco">Nivel</label>
                                    <asp:DropDownList ID="ddlIdiomasNivel" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" >
                                        <asp:ListItem Text="Excelente" Value="excelente"></asp:ListItem>
                                        <asp:ListItem Text="Muy Bueno" Value="muy bueno"></asp:ListItem>
                                        <asp:ListItem Text="Bueno" Value="bueno"></asp:ListItem>
                                        <asp:ListItem Text="Regular" Value="regular"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlIdiomasNivel" ValidationGroup="add3" InitialValue="0" Display="Dynamic" runat="server" />
                                </div> 
                    <div class="card-body text-right">
                        <asp:LinkButton ID="btnAdicionarIdiomas" OnClick="btnAdicionarIdiomas_Click"   CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Registrar" ValidationGroup="add3"  runat="server" />
                    </div>

                                       </div>
                            <div class="row mt--3">
                                <div class="col-6 text-right">
                                    <asp:LinkButton ID="btnIdiomas_NuevoIdioma" OnClick="btnIdiomas_NuevoIdioma_Click" CssClass="mb-lst-chk"  runat="server"  AutoPostBack="true"  Text="<i class='fas fa-plus'> Nuevo Idioma</i>"/>
                              </div>
                            </div>
                                    </div>
                                </div>
                            </div>
        <div class="card col-11 ml-4">
            <div class="card-header border-bottom">
                <div class="ct-page-title">
                    <h3 class="mb-0">Idiomas</h3>
                    <p class="text-sm mb-0"></p>
                </div>
            </div>
            <div class="card-body">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvIdiomas" EmptyDataText="No existen registros de Idiomas" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="asig_idio_per_id, asig_idio_cv_idio_id"   OnRowCommand="gvIdiomas_RowCommand" runat="server">
                            <Columns>
                                <asp:BoundField DataField="idm_nombre" HeaderText="Nombre del Idioma" />
                                <asp:BoundField DataField="asig_idio_nivel" HeaderText="Nivel" />
                                <asp:TemplateField HeaderText="Eliminar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash'></i></span>" data-toggle='tooltip' data-original-title='Eliminar'/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

                                    </div>
                                </div>
                            </div>



                        </div>
        </div>
        <div runat="server" ID="ViewOtrosConocimientos" >
            <div class="container-fluid">
                <div class="ct-example  card" style="padding-bottom: unset">
                    <div class="card-body">
                        <div class="card bg-light mb-4">
                            <div class="card-header bg-info text-center border-0 pt-8 pt-md-4 pb-0 pb-md-4"z>
                                <h3 class="h2 text-white d-inline-block float-left mb-0"><i class="fas fa-id-card-alt mr-2"></i>Otros Conocimientos</h3>
                            </div>
                            <div class="card-body">
                                <div class="media align-items-center">
                                    <div class="media-body">
                            
                                       
                   <div class="row">
                            <div class="form-group col-md-10 text-center">
                                <label class="form-control-label" for="ddlOtrosC_nombre"></label>
                                <div class="input-group input-group-merge">
                                    <asp:DropDownList Visible="true" ID="ddlOtrosC_nombre" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlOtrosC_nombre" ValidationGroup="add4" Display="Dynamic" runat="server" />
                            </div>

                    <div class="card-body text-right">
                        <asp:LinkButton ID="btnAdicionarOtroConocimiento"  OnClick="btnAdicionarOtroConocimiento_Click"  CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Registrar" ValidationGroup="add3"  runat="server" />
                    </div>

                                       </div>

                            <div class="row mt--3">
                                <div class="col-10 text-right">
                                    <asp:LinkButton ID="btnOtrosC_NuevoConocimiento" OnClick="btnOtrosC_NuevoConocimiento_Click" CssClass="mb-lst-chk"  runat="server"  AutoPostBack="true"  Text="<i class='fas fa-plus'> Nuevo Conocimiento</i>"/>
                              </div>
                            </div>

                                    </div>
                                </div>
                            </div>

        <div class="card col-11 ml-4">
            <div class="card-header border-bottom">
                <div class="ct-page-title">
                    <h3 class="mb-0">Otros Conocimientos</h3>
                    <p class="text-sm mb-0"></p>
                </div>
            </div>
            <div class="card-body">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvOtrosConocimientos" EmptyDataText="No existen registros de Otros Conocimientos" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="asig_oc_per_id, asig_oc_cv_oc_id"   OnRowCommand="gvOtrosConocimientos_RowCommand" runat="server">
                            <Columns>
                                <asp:BoundField DataField="cv_oc_conocimiento" HeaderText="Conocimiento" />
                                <asp:TemplateField HeaderText="Eliminar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash'></i></span>" data-toggle='tooltip' data-original-title='Eliminar'/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
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
        <div class="col-12 text-center" runat="server" ID="DivImprimir" visible="false">
            <asp:Button ID="btnImprimirCv" OnClick="btnImprimirCv_Click"  CssClass="btn btn-block bg-gradient-green text-white" Height="70px" Text="IMPRIMIR" runat="server" />
        </div>

    <div id="ModalFormacion_InstitucionNueva" class="modal fade" tabindex="-1" role="dialog"  aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header border-bottom">
                    <div class="ct-page-title">
                        <h5 id="CatalogoTitle" class="modal-title">Nueva Institución de Formación</h5>
                        <p class="text-sm mb-0"></p>
                    </div>
                </div>
        <div class="form-group col-md-12">
            <label class="form-control-label" for="txtFormacion_NuevaInstitucion">Descripción</label>
            <div class="input-group input-group-merge">
                <div class="input-group-prepend">
                    <span class="input-group-text">
                        <i class="fas fa-edit"></i>
                    </span>
                </div>
                <asp:TextBox ID="txtFormacion_NuevaInstitucion" CssClass="form-control" runat="server" />
            </div>
        </div>
                        <div class="modal-footer border-top">
                            <asp:LinkButton ID="btnFormacion_AdicionarInstitucion" CssClass="btn btn-success" OnClick="btnFormacion_AdicionarInstitucion_Click" Text="<i class='fas fa-save'></i> Registrar"   runat="server" />
                            <asp:LinkButton ID="BotonCerrarCatalogo" OnClick="BotonCerrarCatalogo_Click" CssClass="btn btn-google-plus" Text="<i class='fas fa-times'></i> Cancelar"   runat="server" />
                        </div>
            </div>
        </div>
    </div>
    <div id="ModalFormacion_CarreraNueva" class="modal fade" tabindex="-1" role="dialog"  aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header border-bottom">
                    <div class="ct-page-title">
                        <h5  class="modal-title">Nueva Carrera de Formación</h5>
                        <p class="text-sm mb-0"></p>
                    </div>
                </div>
        <div class="form-group col-md-12">
            <label class="form-control-label" for="Txt_per_nombres">Descripción</label>
            <div class="input-group input-group-merge">
                <div class="input-group-prepend">
                    <span class="input-group-text">
                        <i class="fas fa-edit"></i>
                    </span>
                </div>
                <asp:TextBox ID="txtFormacion_NuevaCarrera" CssClass="form-control" runat="server" />
            </div>
        </div>
                        <div class="modal-footer border-top">
                            <asp:LinkButton ID="btnFormacion_AdicionarCarrera" OnClick="btnFormacion_AdicionarCarrera_Click" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Registrar"   runat="server" />
                            <asp:LinkButton ID="btnFormacion_Cerrar_AdicionarCarrera" OnClick="btnFormacion_Cerrar_AdicionarCarrera_Click"  CssClass="btn btn-google-plus" Text="<i class='fas fa-times'></i> Cancelar"   runat="server" />
                        </div>
            </div>
        </div>
    </div>


    <div id="ModalCursos_InstitucionNueva" class="modal fade" tabindex="-1" role="dialog"  aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header border-bottom">
                    <div class="ct-page-title">
                        <h5  class="modal-title">Nueva Institución de Cursos</h5>
                        <p class="text-sm mb-0"></p>
                    </div>
                </div>
        <div class="form-group col-md-12">
            <label class="form-control-label" for="Txt_per_nombres">Descripción</label>
            <div class="input-group input-group-merge">
                <div class="input-group-prepend">
                    <span class="input-group-text">
                        <i class="fas fa-edit"></i>
                    </span>
                </div>
                <asp:TextBox ID="txtCursos_NuevaInstitucion" CssClass="form-control" runat="server" />
            </div>
        </div>
                        <div class="modal-footer border-top">
                            <asp:LinkButton ID="btnCursos_AdicionarInstitucion" CssClass="btn btn-success"  OnClick="btnCursos_AdicionarInstitucion_Click" Text="<i class='fas fa-save'></i> Registrar"   runat="server" />
                            <asp:LinkButton ID="btnCursos_AdicionarInstitucionCerrar"   OnClick="btnCursos_AdicionarInstitucionCerrar_Click" CssClass="btn btn-google-plus" Text="<i class='fas fa-times'></i> Cancelar"   runat="server" />
                        </div>
            </div>
        </div>
    </div>
    <div id="ModalCursos_CursoNuevo" class="modal fade" tabindex="-1" role="dialog"  aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header border-bottom">
                    <div class="ct-page-title">
                        <h5  class="modal-title">Nueva Curso</h5>
                        <p class="text-sm mb-0"></p>
                    </div>
                </div>
        <div class="form-group col-md-12">
            <label class="form-control-label" for="Txt_per_nombres">Descripción</label>
            <div class="input-group input-group-merge">
                <div class="input-group-prepend">
                    <span class="input-group-text">
                        <i class="fas fa-edit"></i>
                    </span>
                </div>
                <asp:TextBox ID="txtCursos_NuevoCurso" CssClass="form-control" runat="server" />
            </div>
        </div>
                        <div class="modal-footer border-top">
                            <asp:LinkButton ID="btnCursos_AdicionarCurso" OnClick="btnCursos_AdicionarCurso_Click" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Registrar"   runat="server" />
                            <asp:LinkButton ID="btnCursos_AdicionarCursoCerrar" OnClick="btnCursos_AdicionarCursoCerrar_Click"   CssClass="btn btn-google-plus" Text="<i class='fas fa-times'></i> Cancelar"   runat="server" />
                        </div>
            </div>
        </div>
    </div>
        
    <div id="ModalTrayectoria_NuevaInstitucion" class="modal fade" tabindex="-1" role="dialog"  aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header border-bottom">
                    <div class="ct-page-title">
                        <h5 class="modal-title">Nueva Institución de Trayectoria Laboral</h5>
                        <p class="text-sm mb-0"></p>
                    </div>
                </div>
        <div class="form-group col-md-12">
            <label class="form-control-label" for="Txt_per_nombres">Descripción</label>
            <div class="input-group input-group-merge">
                <div class="input-group-prepend">
                    <span class="input-group-text">
                        <i class="fas fa-edit"></i>
                    </span>
                </div>
                <asp:TextBox ID="txtTrayectoria_NuevaInstitucion" CssClass="form-control" runat="server" />
            </div>
        </div>
                        <div class="modal-footer border-top">
                            <asp:LinkButton ID="btnTrayectoria_AdicionarNuevaInstitucion" OnClick="btnTrayectoria_AdicionarNuevaInstitucion_Click" CssClass="btn btn-success"  Text="<i class='fas fa-save'></i> Registrar"   runat="server" />
                            <asp:LinkButton ID="btnTrayectoria_AdicionarCerrar" OnClick="btnTrayectoria_AdicionarCerrar_Click" CssClass="btn btn-google-plus" Text="<i class='fas fa-times'></i> Cancelar"   runat="server" />
                        </div>
            </div>
        </div>
    </div>

    <div id="ModalIdioma_NuevoIdioma" class="modal fade" tabindex="-1" role="dialog"  aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header border-bottom">
                    <div class="ct-page-title">
                        <h5 class="modal-title">Nuevo Idioma</h5>
                        <p class="text-sm mb-0"></p>
                    </div>
                </div>
        <div class="form-group col-md-12">
            <label class="form-control-label" for="Txt_per_nombres">Descripción</label>
            <div class="input-group input-group-merge">
                <div class="input-group-prepend">
                    <span class="input-group-text">
                        <i class="fas fa-edit"></i>
                    </span>
                </div>
                <asp:TextBox ID="txtIdioma_NuevoIdioma" CssClass="form-control" runat="server" />
            </div>
        </div>
                        <div class="modal-footer border-top">
                            <asp:LinkButton ID="btnIdioma_NuevoIdioma"  OnClick="btnIdioma_NuevoIdioma_Click" CssClass="btn btn-success"  Text="<i class='fas fa-save'></i> Registrar"   runat="server" />
                            <asp:LinkButton ID="btnIdioma_NuevoCerrar"  OnClick="btnIdioma_NuevoCerrar_Click"  CssClass="btn btn-google-plus" Text="<i class='fas fa-times'></i> Cancelar"   runat="server" />
                        </div>
            </div>
        </div>
    </div>

    <div id="ModalOtrosC_NuevoC" class="modal fade" tabindex="-1" role="dialog"  aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header border-bottom">
                    <div class="ct-page-title">
                        <h5 class="modal-title">Nuevo Conocimiento</h5>
                        <p class="text-sm mb-0"></p>
                    </div>
                </div>
        <div class="form-group col-md-12">
            <label class="form-control-label" for="txtNuevoC_NuevoC">Descripción</label>
            <div class="input-group input-group-merge">
                <div class="input-group-prepend">
                    <span class="input-group-text">
                        <i class="fas fa-edit"></i>
                    </span>
                </div>
                <asp:TextBox ID="txtNuevoC_NuevoC" CssClass="form-control" runat="server" />
            </div>
        </div>
                        <div class="modal-footer border-top">
                            <asp:LinkButton ID="btnNuevoC_NuevoC" OnClick="btnNuevoC_NuevoC_Click"   CssClass="btn btn-success"  Text="<i class='fas fa-save'></i> Registrar"   runat="server" />
                            <asp:LinkButton ID="btnNuevoC_Cerrar" OnClick="btnNuevoC_Cerrar_Click"    CssClass="btn btn-google-plus" Text="<i class='fas fa-times'></i> Cancelar"   runat="server" />
                        </div>
            </div>
        </div>
    </div>

        </ContentTemplate>
        <Triggers>
<%--            <asp:AsyncPostBackTrigger ControlID="btnFormacion_NuevaInst" EventName="Click" />

            <asp:AsyncPostBackTrigger ControlID="btnFormacion_NuevaCarrera" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnAdicionarCursos" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnAdicionarIdiomas" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnAdicionarOtroConocimiento" EventName="Click" />--%>
        </Triggers>
    </asp:UpdatePanel>

    <asp:UpdateProgress ID="up1" AssociatedUpdatePanelID="panelCV" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
</asp:Content>


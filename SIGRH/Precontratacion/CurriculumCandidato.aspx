<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="CurriculumCandidato.aspx.cs" Inherits="Precontratacion_CurriculumCandidato" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel runat="server" ID="UpdatePanelCurriculum">
        <ContentTemplate>
            <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
                <div class="container-fluid">
                    <div class="header-body">
                        <div class="row align-items-center py-4">
                            <div class="col-lg-12">
                                <h6 class="h2 text-light d-inline-block mb-0">Curriculum del Candidato</h6>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="container-fluid mt--6">
                <!-- DATOS PERSONALES -->
                <div class="card">
                    <div class="card-header bg-primary text-white">
                        <h4 class="mb-0"><i class="fas fa-id-card-alt mr-2"></i> Datos Personales</h4>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-lg-4">
                                <div class="content-text-label font-weight-bold">Nombre Completo</div>
                                <div class="h5 font-weight-400 content-text">
                                    <asp:Literal ID="ltlNombreCompleto" runat="server" Text="Cargando..." />
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="content-text-label font-weight-bold">Fecha de Nacimiento</div>
                                <div class="h5 font-weight-400 content-text">
                                    <asp:Literal ID="ltlFechaNac" runat="server" Text="Cargando..." />
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="content-text-label font-weight-bold">Carnet de Identidad</div>
                                <div class="h5 font-weight-400 content-text">
                                    <asp:Literal ID="ltlCarnet" runat="server" Text="Cargando..." />
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <div class="content-text-label font-weight-bold">Sexo</div>
                                <div class="h5 font-weight-400 content-text">
                                    <asp:Literal ID="ltlSexo" runat="server" Text="Cargando..." />
                                </div>
                            </div>
                        </div>
                        <div class="row mt-3">
                            <div class="col-lg-4">
                                <div class="content-text-label font-weight-bold">Correo Electrónico</div>
                                <div class="h5 font-weight-400 content-text">
                                    <asp:Literal ID="ltlEmail" runat="server" Text="Cargando..." />
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="content-text-label font-weight-bold">Teléfono</div>
                                <div class="h5 font-weight-400 content-text">
                                    <asp:Literal ID="ltlTelefono" runat="server" Text="Cargando..." />
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="content-text-label font-weight-bold">Celular</div>
                                <div class="h5 font-weight-400 content-text">
                                    <asp:Literal ID="ltlCelular" runat="server" Text="Cargando..." />
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <div class="content-text-label font-weight-bold">Estado Civil</div>
                                <div class="h5 font-weight-400 content-text">
                                    <asp:Literal ID="ltlEstadoCivil" runat="server" Text="Cargando..." />
                                </div>
                            </div>
                        </div>
                        <div class="row mt-3">
                            <div class="col-lg-4">
                                <div class="content-text-label font-weight-bold">Ciudad de Residencia</div>
                                <div class="h5 font-weight-400 content-text">
                                    <asp:Literal ID="ltlCiudad" runat="server" Text="Cargando..." />
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="content-text-label font-weight-bold">Nacionalidad</div>
                                <div class="h5 font-weight-400 content-text">
                                    <asp:Literal ID="ltlNacionalidad" runat="server" Text="Cargando..." />
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="content-text-label font-weight-bold">Dirección</div>
                                <div class="h5 font-weight-400 content-text">
                                    <asp:Literal ID="ltlDireccion" runat="server" Text="Cargando..." />
                                </div>
                            </div>
                        </div>
                        <asp:HiddenField ID="hfPerId" runat="server" />
                    </div>
                </div>

               <!-- FORMACIÓN ACADÉMICA -->
                <div class="card">
                    <div class="card-header bg-success text-white">
                        <h4 class="mb-0"><i class="fas fa-graduation-cap mr-2"></i> Formación Académica</h4>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="form-group col-md-4">
                                <label class="form-control-label">Nivel Académico</label>
                                <asp:DropDownList ID="ddlFormacionNivel" CssClass="form-control select2" AppendDataBoundItems="true" runat="server">
                                    <asp:ListItem Text="Seleccione..." Value="0" />
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlFormacionNivel" ValidationGroup="addFormacion" InitialValue="0" Display="Dynamic" runat="server" />
                            </div>
                            <div class="form-group col-md-4">
                                <label class="form-control-label">Institución</label>
                                <div class="input-group">
                                    <asp:DropDownList ID="ddlFormacion_Institucion" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" style="width: 85%;" />
                                    <span class="input-group-append">
                                        <asp:LinkButton ID="btnFormacion_NuevaInst" CssClass="btn btn-warning" Text="<i class='fas fa-plus'></i>" runat="server" OnClick="btnFormacion_NuevaInst_Click" data-toggle="tooltip" title="Nueva Institución" />
                                    </span>
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlFormacion_Institucion" ValidationGroup="addFormacion" InitialValue="0" Display="Dynamic" runat="server" />
                            </div>
                            <div class="form-group col-md-4">
                                <label class="form-control-label">Carrera</label>
                                <div class="input-group">
                                    <asp:DropDownList ID="ddlFormacionCarrera" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" style="width: 85%;" />
                                    <span class="input-group-append">
                                        <asp:LinkButton ID="btnFormacion_NuevaCarrera" CssClass="btn btn-warning" Text="<i class='fas fa-plus'></i>" runat="server" OnClick="btnFormacion_NuevaCarrera_Click" data-toggle="tooltip" title="Nueva Carrera" />
                                    </span>
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlFormacionCarrera" ValidationGroup="addFormacion" InitialValue="0" Display="Dynamic" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group col-md-2">
                                <label class="form-control-label">Año Inicio</label>
                                <asp:TextBox ID="txtFormacionAñoInicio" CssClass="form-control number" placeholder="AAAA" MaxLength="4" runat="server" />
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtFormacionAñoInicio" ValidationGroup="addFormacion" Display="Dynamic" runat="server" />
                            </div>
                            <div class="form-group col-md-2">
                                <label class="form-control-label">Año Fin</label>
                                <asp:TextBox ID="txtFormacionAñoFin" CssClass="form-control number" placeholder="AAAA" MaxLength="4" runat="server" />
                            </div>
                            <div class="form-group col-md-4">
                                <label class="form-control-label">Título Provisión Nacional</label>
                                <div class="custom-controls-stacked">
                                    <asp:RadioButtonList ID="rblFormacionProvision" CssClass="radios-inline" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server">
                                        <asp:ListItem Value="1" Text="Si" />
                                        <asp:ListItem Value="0" Text="No" />
                                    </asp:RadioButtonList>
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="rblFormacionProvision" ValidationGroup="addFormacion" Display="Dynamic" runat="server" />
                            </div>
                            <div class="form-group col-md-4 text-right" style="padding-top: 25px;">
                                <asp:LinkButton ID="btnAdicionarFormacion" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Registrar" ValidationGroup="addFormacion" OnClick="btnAdicionarFormacion_Click" runat="server" />
                            </div>
                        </div>
                        <div class="table-responsive mt-4">
                            <asp:GridView ID="gvFormacione" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="cv_form_id" OnRowCommand="gvFormacion_RowCommand" OnPreRender="gvFormacione_PreRender" runat="server">
                                <Columns>
                                    <asp:BoundField DataField="ga_nombre" HeaderText="Grado Académico" />
                                    <asp:BoundField DataField="it_nombre" HeaderText="Institución" />
                                    <asp:BoundField DataField="carr_nombre" HeaderText="Carrera" />
                                    <asp:BoundField DataField="cv_form_año_inicio" HeaderText="Inicio" />
                                    <asp:BoundField DataField="cv_form_año_fin" HeaderText="Fin" />
                                    <asp:BoundField DataField="cv_form_prov_nal" HeaderText="Prov. Nal." />
                                    <asp:TemplateField HeaderText="Eliminar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<i class='fas fa-trash'></i>" data-toggle='tooltip' data-original-title='Eliminar'/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>

                <!-- CURSOS -->
                <div class="card">
                    <div class="card-header bg-info text-white">
                        <h4 class="mb-0"><i class="fas fa-certificate mr-2"></i> Cursos</h4>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="form-group col-md-4">
                                <label class="form-control-label">Institución</label>
                                <div class="input-group">
                                    <asp:DropDownList ID="ddlCursos_Institucion" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" style="width: 85%;" />
                                    <span class="input-group-append">
                                        <asp:LinkButton ID="btnCursos_NuevaInstitucion" CssClass="btn btn-warning" Text="<i class='fas fa-plus'></i>" runat="server" OnClick="btnCursos_NuevaInstitucion_Click" data-toggle="tooltip" title="Nueva Institución" />
                                    </span>
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlCursos_Institucion" ValidationGroup="addCursos" InitialValue="0" Display="Dynamic" runat="server" />
                            </div>
                            <div class="form-group col-md-4">
                                <label class="form-control-label">Nombre del Curso</label>
                                <div class="input-group">
                                    <asp:DropDownList ID="ddlCursos_Curso" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" style="width: 85%;" />
                                    <span class="input-group-append">
                                        <asp:LinkButton ID="btnCursos_NuevoCurso" CssClass="btn btn-warning" Text="<i class='fas fa-plus'></i>" runat="server" OnClick="btnCursos_NuevoCurso_Click" data-toggle="tooltip" title="Nuevo Curso" />
                                    </span>
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlCursos_Curso" ValidationGroup="addCursos" InitialValue="0" Display="Dynamic" runat="server" />
                            </div>
                            <div class="form-group col-md-2">
                                <label class="form-control-label">Carga Horaria</label>
                                <asp:TextBox ID="txtCursosDias" CssClass="form-control number" placeholder="Hs" runat="server" />
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtCursosDias" ValidationGroup="addCursos" Display="Dynamic" runat="server" />
                            </div>
                            <div class="form-group col-md-2 text-right" style="padding-top: 25px;">
                                <asp:LinkButton ID="btnAdicionarCursos" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Registrar" ValidationGroup="addCursos" OnClick="btnAdicionarCursos_Click" runat="server" />
                            </div>
                        </div>
                        <div class="table-responsive mt-4">
                            <asp:GridView ID="gvCursos" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="asig_curs_per_id, asig_curs_cv_curs_id" OnRowCommand="gvCursos_RowCommand" OnPreRender="gvCursos_PreRender" runat="server">
                                <Columns>
                                    <asp:BoundField DataField="it_nombre" HeaderText="Institución" />
                                    <asp:BoundField DataField="cv_curs_nombre_curso" HeaderText="Curso" />
                                    <asp:BoundField DataField="asig_curs_carga_horaria" HeaderText="Carga Horaria" />
                                    <asp:TemplateField HeaderText="Eliminar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<i class='fas fa-trash'></i>" data-toggle='tooltip' data-original-title='Eliminar'/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>

                <!-- EXPERIENCIA LABORAL -->
                <div class="card">
                    <div class="card-header bg-warning text-white">
                        <h4 class="mb-0"><i class="fas fa-briefcase mr-2"></i> Experiencia Laboral</h4>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="form-group col-md-4">
                                <label class="form-control-label">Institución</label>
                                <div class="input-group">
                                    <asp:DropDownList ID="ddlTrayectoria_NuevaInstitucion" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" style="width: 85%;" />
                                    <span class="input-group-append">
                                        <asp:LinkButton ID="btnTrayectoria_NuevaInstitucion" CssClass="btn btn-warning" Text="<i class='fas fa-plus'></i>" runat="server" OnClick="btnTrayectoria_NuevaInstitucion_Click" data-toggle="tooltip" title="Nueva Institución" />
                                    </span>
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlTrayectoria_NuevaInstitucion" ValidationGroup="addTrayectoria" InitialValue="0" Display="Dynamic" runat="server" />
                            </div>
                            <div class="form-group col-md-4">
                                <label class="form-control-label">Área de Especialidad</label>
                                <asp:TextBox ID="txtTrayectoriaEspecialidad" CssClass="form-control" placeholder="Área" runat="server" />
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtTrayectoriaEspecialidad" ValidationGroup="addTrayectoria" Display="Dynamic" runat="server" />
                            </div>
                            <div class="form-group col-md-4">
                                <label class="form-control-label">Último Cargo</label>
                                <asp:TextBox ID="txtTrayectoriaUltimoCargo" CssClass="form-control" placeholder="Cargo" runat="server" />
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtTrayectoriaUltimoCargo" ValidationGroup="addTrayectoria" Display="Dynamic" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <label class="form-control-label">Mes Inicio</label>
                                <asp:TextBox ID="txtTrayectoriaMesInicio" CssClass="form-control number" placeholder="MM" MaxLength="2" runat="server" />
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtTrayectoriaMesInicio" ValidationGroup="addTrayectoria" Display="Dynamic" runat="server" />
                            </div>
                            <div class="form-group col-md-2">
                                <label class="form-control-label">Año Inicio</label>
                                <asp:TextBox ID="txtTrayectoriaAñoInicio" CssClass="form-control number" placeholder="AAAA" MaxLength="4" runat="server" />
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtTrayectoriaAñoInicio" ValidationGroup="addTrayectoria" Display="Dynamic" runat="server" />
                            </div>
                            <div class="form-group col-md-2">
                                <label class="form-control-label">Mes Fin</label>
                                <asp:TextBox ID="txtTrayectoriaMesFin" CssClass="form-control number" placeholder="MM" MaxLength="2" runat="server" />
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtTrayectoriaMesFin" ValidationGroup="addTrayectoria" Display="Dynamic" runat="server" />
                            </div>
                            <div class="form-group col-md-2">
                                <label class="form-control-label">Año Fin</label>
                                <asp:TextBox ID="txtTrayectoriaAñoFin" CssClass="form-control number" placeholder="AAAA" MaxLength="4" runat="server" />
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtTrayectoriaAñoFin" ValidationGroup="addTrayectoria" Display="Dynamic" runat="server" />
                            </div>
                            <div class="form-group col-md-4 text-right" style="padding-top: 25px;">
                                <asp:LinkButton ID="btnAdicionarTrayectoria" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Registrar" ValidationGroup="addTrayectoria" OnClick="btnAdicionarTrayectoria_Click" runat="server" />
                            </div>
                        </div>
                        <div class="table-responsive mt-4">
                            <asp:GridView ID="gvTrayectoria" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="cv_exp_id" OnRowCommand="gvTrayectoria_RowCommand" OnPreRender="gvTrayectoria_PreRender" runat="server">
                                <Columns>
                                    <asp:BoundField DataField="it_nombre" HeaderText="Institución" />
                                    <asp:BoundField DataField="cv_exp_area_esp" HeaderText="Área de Especialidad" />
                                    <asp:BoundField DataField="cv_exp_ultimo_cargo" HeaderText="Último Cargo" />
                                    <asp:BoundField DataField="desde" HeaderText="Desde" />
                                    <asp:BoundField DataField="hasta" HeaderText="Hasta" />
                                    <asp:TemplateField HeaderText="Eliminar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<i class='fas fa-trash'></i>" data-toggle='tooltip' data-original-title='Eliminar'/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>

                <!-- IDIOMAS -->
                <div class="card">
                    <div class="card-header" style="background-color:#F3BB45; color:white;">
                        <h4 class="mb-0"><i class="fas fa-language mr-2"></i> Idiomas</h4>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="form-group col-md-5">
                                <label class="form-control-label">Idioma</label>
                                <div class="input-group">
                                    <asp:DropDownList ID="ddlIdiomas_Idioma" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" style="width: 85%;" />
                                    <span class="input-group-append">
                                        <asp:LinkButton ID="btnIdiomas_NuevoIdioma" CssClass="btn btn-warning" Text="<i class='fas fa-plus'></i>" runat="server" OnClick="btnIdiomas_NuevoIdioma_Click" data-toggle="tooltip" title="Nuevo Idioma" />
                                    </span>
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlIdiomas_Idioma" ValidationGroup="addIdiomas" InitialValue="0" Display="Dynamic" runat="server" />
                            </div>
                            <div class="form-group col-md-4">
                                <label class="form-control-label">Nivel</label>
                                <asp:DropDownList ID="ddlIdiomasNivel" CssClass="form-control select2" AppendDataBoundItems="true" runat="server">
                                    <asp:ListItem Text="Seleccione..." Value="0" />
                                    <asp:ListItem Text="Excelente" Value="Excelente" />
                                    <asp:ListItem Text="Muy Bueno" Value="Muy Bueno" />
                                    <asp:ListItem Text="Bueno" Value="Bueno" />
                                    <asp:ListItem Text="Regular" Value="Regular" />
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlIdiomasNivel" ValidationGroup="addIdiomas" InitialValue="0" Display="Dynamic" runat="server" />
                            </div>
                            <div class="form-group col-md-3 text-right" style="padding-top: 25px;">
                                <asp:LinkButton ID="btnAdicionarIdiomas" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Registrar" ValidationGroup="addIdiomas" OnClick="btnAdicionarIdiomas_Click" runat="server" />
                            </div>
                        </div>
                        <div class="table-responsive mt-4">
                            <asp:GridView ID="gvIdiomas" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="asig_idio_per_id, asig_idio_cv_idio_id" OnRowCommand="gvIdiomas_RowCommand" OnPreRender="gvIdiomas_PreRender" runat="server">
                                <Columns>
                                    <asp:BoundField DataField="idm_nombre" HeaderText="Idioma" />
                                    <asp:BoundField DataField="asig_idio_nivel" HeaderText="Nivel" />
                                    <asp:TemplateField HeaderText="Eliminar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<i class='fas fa-trash'></i>" data-toggle='tooltip' data-original-title='Eliminar'/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>

                <!-- OTROS CONOCIMIENTOS -->
                <div class="card">
                    <div class="card-header bg-secondary text-white">
                        <h4 class="mb-0"><i class="fas fa-tools mr-2"></i> Otros Conocimientos</h4>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="form-group col-md-9">
                                <label class="form-control-label">Conocimiento</label>
                                <div class="input-group">
                                    <asp:DropDownList ID="ddlOtrosC_nombre" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" style="width: 90%;" />
                                    <span class="input-group-append">
                                        <asp:LinkButton ID="btnOtrosC_NuevoConocimiento" CssClass="btn btn-warning" Text="<i class='fas fa-plus'></i>" runat="server" OnClick="btnOtrosC_NuevoConocimiento_Click" data-toggle="tooltip" title="Nuevo Conocimiento" />
                                    </span>
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlOtrosC_nombre" ValidationGroup="addOtrosC" InitialValue="0" Display="Dynamic" runat="server" />
                            </div>
                            <div class="form-group col-md-3 text-right" style="padding-top: 25px;">
                                <asp:LinkButton ID="btnAdicionarOtroConocimiento" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Registrar" ValidationGroup="addOtrosC" OnClick="btnAdicionarOtroConocimiento_Click" runat="server" />
                            </div>
                        </div>
                        <div class="table-responsive mt-4">
                            <asp:GridView ID="gvOtrosConocimientos" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="asig_oc_per_id, asig_oc_cv_oc_id" OnRowCommand="gvOtrosConocimientos_RowCommand" OnPreRender="gvOtrosConocimientos_PreRender" runat="server">
                                <Columns>
                                    <asp:BoundField DataField="cv_oc_conocimiento" HeaderText="Conocimiento" />
                                    <asp:TemplateField HeaderText="Eliminar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<i class='fas fa-trash'></i>" data-toggle='tooltip' data-original-title='Eliminar'/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>

                <!-- BOTONES -->
                <div class="card">
                    <div class="card-body text-right">
                        <a href='SolicitudContratacion.aspx?per_id=<%= hfPerId.Value %>' class="btn btn-default btn-lg"> <i class="fas fa-arrow-left"></i> Atrás</a>
                        <asp:LinkButton ID="btnGuardarCurriculum" CssClass="btn btn-success btn-lg" Text="<i class='fas fa-save'></i> Guardar Curriculum" OnClick="btnGuardarCurriculum_Click" runat="server" />
                    </div>
                </div>
            </div>

            <!-- ============================================================ -->
            <!-- MODALES -->
            <!-- ============================================================ -->
            
            <!-- Modal Nueva Institución de Formación -->
            <div class="modal fade" id="modalFormacion_InstitucionNueva" tabindex="-1" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="false">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Nueva Institución de Formación</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <label class="form-control-label">Descripción</label>
                                <asp:TextBox ID="txtFormacion_NuevaInstitucion" CssClass="form-control" placeholder="Ingrese el nombre de la institución" runat="server" />
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton ID="btnFormacion_AdicionarInstitucion" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> REGISTRAR" OnClick="btnFormacion_AdicionarInstitucion_Click" runat="server" />
                            <button type="button" class="btn btn-secondary" data-dismiss="modal"><i class="fas fa-times"></i> CANCELAR</button>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Modal Nueva Carrera -->
            <div class="modal fade" id="modalFormacion_CarreraNueva" tabindex="-1" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="false">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Nueva Carrera de Formación</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <label class="form-control-label">Descripción</label>
                                <asp:TextBox ID="txtFormacion_NuevaCarrera" CssClass="form-control" placeholder="Ingrese el nombre de la carrera" runat="server" />
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton ID="btnFormacion_AdicionarCarrera" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> REGISTRAR" OnClick="btnFormacion_AdicionarCarrera_Click" runat="server" />
                            <button type="button" class="btn btn-secondary" data-dismiss="modal"><i class="fas fa-times"></i> CANCELAR</button>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Modal Nueva Institución de Cursos -->
            <div class="modal fade" id="modalCursos_InstitucionNueva" tabindex="-1" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="false">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Nueva Institución de Cursos</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <label class="form-control-label">Descripción</label>
                                <asp:TextBox ID="txtCursos_NuevaInstitucion" CssClass="form-control" placeholder="Ingrese el nombre de la institución" runat="server" />
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton ID="btnCursos_AdicionarInstitucion" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> REGISTRAR" OnClick="btnCursos_AdicionarInstitucion_Click" runat="server" />
                            <button type="button" class="btn btn-secondary" data-dismiss="modal"><i class="fas fa-times"></i> CANCELAR</button>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Modal Nuevo Curso -->
            <div class="modal fade" id="modalCursos_CursoNuevo" tabindex="-1" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="false">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Nuevo Curso</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <label class="form-control-label">Descripción</label>
                                <asp:TextBox ID="txtCursos_NuevoCurso" CssClass="form-control" placeholder="Ingrese el nombre del curso" runat="server" />
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton ID="btnCursos_AdicionarCurso" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> REGISTRAR" OnClick="btnCursos_AdicionarCurso_Click" runat="server" />
                            <button type="button" class="btn btn-secondary" data-dismiss="modal"><i class="fas fa-times"></i> CANCELAR</button>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Modal Nueva Institución de Trayectoria -->
            <div class="modal fade" id="modalTrayectoria_NuevaInstitucion" tabindex="-1" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="false">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Nueva Institución de Trayectoria Laboral</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <label class="form-control-label">Descripción</label>
                                <asp:TextBox ID="txtTrayectoria_NuevaInstitucion" CssClass="form-control" placeholder="Ingrese el nombre de la institución" runat="server" />
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton ID="btnTrayectoria_AdicionarNuevaInstitucion" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> REGISTRAR" OnClick="btnTrayectoria_AdicionarNuevaInstitucion_Click" runat="server" />
                            <button type="button" class="btn btn-secondary" data-dismiss="modal"><i class="fas fa-times"></i> CANCELAR</button>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Modal Nuevo Idioma -->
            <div class="modal fade" id="modalIdioma_NuevoIdioma" tabindex="-1" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="false">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Nuevo Idioma</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <label class="form-control-label">Descripción</label>
                                <asp:TextBox ID="txtIdioma_NuevoIdioma" CssClass="form-control" placeholder="Ingrese el nombre del idioma" runat="server" />
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton ID="btnIdioma_NuevoIdioma" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> REGISTRAR" OnClick="btnIdioma_NuevoIdioma_Click" runat="server" />
                            <button type="button" class="btn btn-secondary" data-dismiss="modal"><i class="fas fa-times"></i> CANCELAR</button>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Modal Nuevo Conocimiento -->
            <div class="modal fade" id="modalOtrosC_NuevoC" tabindex="-1" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="false">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Nuevo Conocimiento</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <label class="form-control-label">Descripción</label>
                                <asp:TextBox ID="txtNuevoC_NuevoC" CssClass="form-control" placeholder="Ingrese el nombre del conocimiento" runat="server" />
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton ID="btnNuevoC_NuevoC" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> REGISTRAR" OnClick="btnNuevoC_NuevoC_Click" runat="server" />
                            <button type="button" class="btn btn-secondary" data-dismiss="modal"><i class="fas fa-times"></i> CANCELAR</button>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdicionarFormacion" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnAdicionarCursos" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnAdicionarTrayectoria" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnAdicionarIdiomas" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnAdicionarOtroConocimiento" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnGuardarCurriculum" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

    <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanelCurriculum" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <script>
        $(document).ready(function () {
            $('.select2').select2({
                placeholder: { id: '0', text: 'Seleccione...' }
            });
        });
    </script>
</asp:Content>

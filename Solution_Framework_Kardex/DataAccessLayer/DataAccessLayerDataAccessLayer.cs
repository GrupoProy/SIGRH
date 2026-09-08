using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

using Solution_Framework_Kardex.BussinessLogicLayer;

namespace Solution_Framework_Kardex.DataAccessLayer
{
	public abstract class DataAccessLayerDataAccessLayer
	{

		#region INSTANCIA PRINCIPAL DE CONEXION A UNA BD

		public Database CNXSIGRH3 = DatabaseFactory.CreateDatabase("CnxSigrh3");
        public Database CNXGENERAL = DatabaseFactory.CreateDatabase("CnxGeneral");
        public Database CNXCHEQUES = DatabaseFactory.CreateDatabase("CnxCheques");

        #endregion

        // INTERFACES
        #region _KD_FERIADOS
        public abstract bool Adicionar__kd_feriados(cls_kd_feriados _kd_feriados);
        public abstract bool Actualizar__kd_feriados(cls_kd_feriados _kd_feriados);
        public abstract bool Eliminar__kd_feriados(cls_kd_feriados _kd_feriados);
        public abstract bool ObtenerId__kd_feriados(cls_kd_feriados _kd_feriados);
        public abstract bool ObtenerRegistro__kd_feriados(cls_kd_feriados _kd_feriados);
        public abstract DataSet ObtenerTablaGrilla__kd_feriados(string fe_id,
                        string fe_fecha,
                        string fe_descripcion,
                        string fe_estado);
        public abstract DataSet ObtenerTablaCombo__kd_feriados();
        //(JQC)
        public abstract DataSet ObtenerGrillaFeriados(cls_kd_feriados _kd_feriados);
        public abstract DataSet ObtenerFeriadoX(cls_kd_feriados _kd_feriados);

        #endregion
        #region _KD_CERTIFICADO_SIPPASE
        public abstract int Adicionar__kd_certificado_sippase(cls_kd_certificado_sippase _kd_certificado_sippase);
        public abstract bool Actualizar__kd_certificado_sippase(cls_kd_certificado_sippase _kd_certificado_sippase);
        public abstract bool Eliminar__kd_certificado_sippase(cls_kd_certificado_sippase _kd_certificado_sippase);
        public abstract DataSet ObtenerRegistro__kd_certificado_sippase(cls_kd_certificado_sippase _kd_certificado_sippase);
        public abstract DataSet ObtenerTablaGrilla__kd_certificado_sippase(
            string sip_id,
            string sip_per_id,
            string sip_descripcion_cert,
            string sip_fecha_cert,
            string sip_fecha_pres,
            string sip_estado);
        public abstract DataSet ObtenerTablaCombo__kd_certificado_sippase();
        #endregion

        #region _KD_FINIQUITO
        //      public abstract DataSet Adicionar__kd_finiquito(cls_kd_finiquito _kd_finiquito);
        //public abstract bool Actualizar__kd_finiquito(cls_kd_finiquito _kd_finiquito);
        //public abstract bool Eliminar__kd_finiquito(cls_kd_finiquito _kd_finiquito);
        //public abstract bool ObtenerId__kd_finiquito(cls_kd_finiquito _kd_finiquito);
        //public abstract bool ObtenerRegistro__kd_finiquito(cls_kd_finiquito _kd_finiquito);
        //public abstract DataSet ObtenerTablaGrilla__kd_finiquito(string fin_id, 
        //				string fin_tiempo_servicio, 
        //				string fin_liquido_pagable);
        //public abstract DataSet ObtenerTablaCombo__kd_finiquito();
        //public abstract DataSet ObtenerAsignaciones(cls_kd_finiquito _kd_finiquito);
        public abstract string TiempoServicio(string fecha_ingreso, string accion);
        public abstract int Adicionar_FechaIngreso(cls_kd_finiquito2 _kd_finiquito2);
        public abstract DataSet CalcularGestiones(string fecha_baja);
        public abstract DataSet PromedioRemuneracion(double rem1, double rem2, double rem3, int ANIO, int MES, int DIA);
        public abstract int ActualizarTotalesRemuneracionFiniquito(double rem1, double rem2, double rem3, int p_Fi_id, double ba1, double ba2, double ba3, double bf1, double bf2, double bf3);
        public abstract DataSet ObtenerRegistro(int per_id, int as_id);
        public abstract double CalcularDesahucio(int fi_id);
        public abstract double CalcularVacacionesMonto(int fi_id, int meses, int dias, int per_id);
        public abstract double CalcularVacacionesDias(int fi_id, int meses, int dias, int per_id);
        public abstract double CalcularAguinaldo(int fi_id, string fecha_baja);
        public abstract int ActualizarInfoAdicional(int fi_id, int nro_finiquito, int cod_finiquito, string motivo, double liquido_pagable, string doc_autoriza, string fecha_doc, string estado);



        #endregion

        #region _KD_ASIGNACION_VACACIONES
        public abstract bool Adicionar__kd_asignacion_vacaciones(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones);
		public abstract bool Actualizar__kd_asignacion_vacaciones(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones);
		public abstract bool Eliminar__kd_asignacion_vacaciones(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones);
		public abstract bool ObtenerId__kd_asignacion_vacaciones(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones);
		public abstract bool ObtenerRegistro__kd_asignacion_vacaciones(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones);
		public abstract DataSet ObtenerTablaGrilla__kd_asignacion_vacaciones(string va_id, 
						string va_per_id, 
						string va_gestion, 
						string va_dias_ley, 
						string va_dias_restantes, 
						string va_horas_restantes, 
						string va_fecha_ingreso_r, 
						string va_anio, 
						string va_fecha_habilitacion_prescrito, 
						string va_autorizado_por, 
						string va_nro_documento, 
						string va_observaciones, 
						string va_fecha_registro_prescrito, 
						string va_fecha_validez_prescrito, 
						string va_estado, 
						string va_usuario_creacion, 
						string va_fecha_creacion);
		public abstract DataSet ObtenerTablaCombo__kd_asignacion_vacaciones();

        //(JQC)
        public abstract DataSet obtenerGrillaAsigVacaciones(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones);
        public abstract DataSet ObtenerVacacionAnualX(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones);
        public abstract DataSet ObtenerDatosFuncionarioP(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones);
        public abstract DataSet obtenerGrillaHistoricoVacaciones(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones);
        public abstract DataSet listaFiltradoTipoLicencia();
        public abstract int AdicionarVacacionLicencia(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones, int id_autoriza);
        public abstract DataSet ObtenerSumaTotalDiasV(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones);
        public abstract DataSet ObtenerCorrelativo();
        public abstract DataSet ObtenerNroDiasVacacionDisp(cls_kd_asignacion_vacaciones _kd_asignacion_vacacione);
        public abstract DataSet ObtenerNroHorasVacacionDisp(cls_kd_asignacion_vacaciones _kd_asignacion_vacacione);
        public abstract bool ActualizarSaldoDias(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones);
        public abstract DataSet obtenerGrillaHistoricoLicenciaVac(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones);
        public abstract DataSet ObtenerLicenciaCargoVacacionX(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones);
        public abstract bool EliminarVacacion(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones);
        public abstract DataSet obtenerGrillaHistoricoDocumentoCAS(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones);
        public abstract DataSet listaFiltradoTipoCas();
        public abstract bool AdicionarRegistroCas(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones);
        public abstract bool EliminarRegistroCas(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones);
        public abstract bool ActualizarSaldoHoras(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones);
        public abstract bool ActualizarSaldoDiasHoras(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones);
        public abstract DataSet obtenerGrillaHistoricoGestionPrescrito(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones);
        public abstract DataSet ObtenerVacacionX(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones);
        public abstract bool AdicionarGestionPrescrito(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones);
        public abstract DataSet obtenerGrillaFiliacion(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones);
        public abstract DataSet obtenerGrillaHistoricoAsig(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones);
        public abstract bool EliminarLicenciaVacacion(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones);
        public abstract DataSet ObtenerDiasAsignados(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones);
        public abstract bool RecuperarVacacion(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones);
        public abstract bool RecuperarVacacionHoras(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones);
        public abstract DataSet ObtenerDetalleLicencia(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones);
        public abstract DataSet ObtenerVacacionesAsignadas(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones);
        public abstract DataSet obtenerHistoricoAsigVacaciones(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones);
        public abstract string ObtenerVacaciones_ConDiasFeriados(string fechaInicio, string fechaFin);

        #endregion

        #region _KD_RESPUESTA_COMBO
        public abstract bool Adicionar__kd_respuesta_combo(cls_kd_respuesta_combo _kd_respuesta_combo);
		public abstract bool Actualizar__kd_respuesta_combo(cls_kd_respuesta_combo _kd_respuesta_combo);
		public abstract bool Eliminar__kd_respuesta_combo(cls_kd_respuesta_combo _kd_respuesta_combo);
		public abstract bool GuardarRequisitosPresentados(cls_kd_respuesta_combo _kd_respuesta_combo);
		public abstract bool GuardarRequisitosPresentadosUDEP(cls_kd_respuesta_combo _kd_respuesta_combo);
		public abstract bool ActualizarRequisitos(cls_kd_respuesta_combo _kd_respuesta_combo);
		public abstract bool EliminarRequisito(cls_kd_respuesta_combo _kd_respuesta_combo);
		public abstract bool ObtenerId__kd_respuesta_combo(cls_kd_respuesta_combo _kd_respuesta_combo);
		public abstract bool ObtenerRegistro__kd_respuesta_combo(cls_kd_respuesta_combo _kd_respuesta_combo);
		public abstract DataSet ObtenerTablaGrilla__kd_respuesta_combo(string rc_id, 
						string rc_rq_id, 
						string rc_desc, 
						string rc_equivalencia, 
						string rc_estado, 
						string rc_usuario_creacion, 
						string rc_fecha_creacion);
		public abstract DataSet ObtenerTablaCombo__kd_respuesta_combo();
		public abstract DataSet ListaRequisitos(cls_kd_respuesta_combo _kd_respuesta_combo);
		public abstract DataSet ComboRequisitos(cls_kd_respuesta_combo _kd_respuesta_combo);
		public abstract DataSet ObtenerDatosFuncioanrio(cls_kd_respuesta_combo _kd_respuesta_combo);
		public abstract DataSet ObtenerDatosPersonales(cls_kd_respuesta_combo _kd_respuesta_combo);
		public abstract DataSet RequisitosPresentadosFun(cls_kd_respuesta_combo _kd_respuesta_combo);
		public abstract DataSet ObtenerGrillaEducFormal(cls_kd_respuesta_combo _kd_respuesta_combo);
		public abstract DataSet ObtenerGrillaRequisitos(cls_kd_respuesta_combo _kd_respuesta_combo);
		public abstract DataSet ObtenerFiltradoCategoria(cls_kd_respuesta_combo _kd_respuesta_combo);
		public abstract bool AdicionarRequisito(cls_kd_respuesta_combo _kd_respuesta_combo);
		public abstract bool ActualizarRequisito(cls_kd_respuesta_combo _kd_respuesta_combo);
		public abstract DataSet ObtenerRequisitoX(cls_kd_respuesta_combo _kd_respuesta_combo);
		public abstract DataSet ValidarRequisitosPresentados(cls_kd_respuesta_combo _kd_respuesta_combo);
		public abstract DataSet RegistrarFormacion(cls_kd_respuesta_combo _kd_respuesta_combo);
		public abstract DataSet ObtenerFormacionX(cls_kd_respuesta_combo _kd_respuesta_combo);
        public abstract bool ActualizarFormacion(cls_kd_respuesta_combo _kd_respuesta_combo);
        public abstract bool ActualizarNivelInstruccion(cls_kd_respuesta_combo _kd_respuesta_combo);
        public abstract DataSet ObtenerNivelInstruccion(cls_kd_respuesta_combo _kd_respuesta_combo);
        public abstract bool EliminarTmp_ReporteFiliacion();

        #endregion

        #region KD_CURRICULUM
        public abstract bool Adicionar_CurriculumFormacion(cls_cv_formacion _cv_formacion);
        public abstract bool Eliminar_CurriculumFormacion(cls_cv_formacion _cv_formacion);
        
        public abstract DataSet ObtenerGrilla_Formacion(int per_id);
        public abstract bool InsertarFormacion_Insitucion(string nombre, int depto, string estado, int provincia, int ciudad, string observacion);
        public abstract bool InsertarFormacion_Carrera(string carrera_nombre, string carrera_estado);

        public abstract DataSet ListadoCursos(int per_id, string accion);
        public abstract bool InsertarCursos_Insitucion(string nombre, int depto, string estado, int provincia, int ciudad, string observacion);
        public abstract bool InsertarCursos_Curso(string nombre_curso, string estado);
        public abstract bool Adicionar_CurriculumCurso(int per_id, int curs_id, int inst_id, int carga_horaria, string estado);
        public abstract DataSet ObtenerGrilla_Cursos(int per_id);
        public abstract bool Eliminar_CurriculumCursos(int per_id, int curs_id);

        public abstract bool InsertarTrayectoria_Insitucion(string nombre, int depto, string estado, int provincia, int ciudad, string observacion);
        public abstract bool Adicionar_CurriculumTrayectoria(int inst_id, string area, string ultimo_cargo, int mes_inicio, int gestion_inicio, int mes_fin, int gestion_fin, string estado, int per_id);
        public abstract DataSet ObtenerGrilla_Trayectoria(int per_id);
        public abstract bool Eliminar_CurriculumTrayectoria(int exp_id);

        public abstract DataSet ListadoIdiomas();
        public abstract bool Adicionar_CurriculumIdioma(int per_id, int idioma_id, string estado, string nivel);
        public abstract bool Eliminar_CurriculumIdioma(int per_id, int idioma_di);
        public abstract DataSet ObtenerGrilla_Idiomas(int per_id);
        public abstract bool InsertarNuevoIdioma(string nombre_idioma, string estado);

        public abstract bool InsertarNuevoConocimiento(string nombre_conocimiento, string estado);
        public abstract DataSet ListadoConocimientos();
        public abstract DataSet ObtenerGrilla_OtrosC(int per_id);
        public abstract bool Adicionar_CurriculumOtrosC(int per_id, int conocimiento_id, string estado);
        public abstract bool Eliminar_CurriculumOtrosC(int per_id, int oc_id);
        public abstract DataSet ObtenerGradoAcademico_Reporte();
        public abstract DataSet ObtenerCarreras_Reporte(string grado_academico);


        #endregion
        #region CHEQUES
        public abstract DataSet Gestion();
        public abstract DataSet BuscarCheque(string preventivo, string proceso_nombre, int id_gestion, string beneficiario, string nit_ci, string num_cheque);
        public abstract DataSet DetalleCheque(int pago_id);
        public abstract DataSet ObtenerTipoDoc();
        public abstract bool AdicionarPDF(int tipoDoc_id, int proce_id, byte[] foto, string fecha_doc, int per_id, string obser);
        #endregion

        #region POAI

        public abstract DataSet ListarResultados(int poai_id, string r_tipo);

        //======================= FORMACION OBLIGATORIA =============
        public abstract DataSet ListarFormacionObligatoria(int pu_id, string fo_tipo);

        public abstract DataSet DevolverDatosFormacionObligatoria(int fo_id);

        public abstract bool ActualizarFormacionO(cls_kd_finiquito2 _kd_finiquito);
        //======================= /FORMACION OBLIGATORIA =============

        // ============= Experciencia ==============

        public abstract bool AdicionarExperciencia(cls_kd_finiquito2 _kd_finiquito);

        public abstract DataSet ListarExperiencia(int pu_id);

        // ------------- Experciencia --------------
        public abstract DataSet ListarActividades(int r_id);

        public abstract DataSet Listar_Supervisores();

        public abstract DataSet Listar_Caracteristicas();

        public abstract DataSet Listar_Complementarios();

        public abstract DataSet List_Gestion();

        public abstract int Adicionar_Poai(int per_id, int p_tipo, string inter, string intra, int ca_id, int super_id, int nro_puesto, string pu_nombre, string pu_pref, string pu_objetivo);

        public abstract int Devolver_tipo_Poai(int per_id);

        // ======== devolver cargo ==========

        public abstract int DevolverCargoXPer(int per_id);

        //-------- devolver cargo -----------

        public abstract DataSet DevolverGestionPerId(int per_id, int gestion);

        public abstract DataSet DevolverDatosResultadosEspecificos(int r_id);

        // ===== devolver datos poai ==========

        public abstract DataSet DevolverDatosPoai(int poai_id);

        // ----- devolver datos poai ----------

        public abstract DataSet DevolverDatosActividad(int actividad_id);

        public abstract bool ActualizarResultadoEspecifico(cls_kd_finiquito2 _kd_finiquito);

        public abstract bool ActualizarResultadoEspecifico2(cls_kd_finiquito2 _kd_finiquito);

        //============ POAI ============

        public abstract bool ActualizarPoai(cls_kd_finiquito2 _kd_finiquito);

        //----------- POAI ---------------

        public abstract bool ActualizarActividad(cls_kd_finiquito2 _kd_finiquito);


        public abstract bool AdicionarResultadoEspecifico(cls_kd_finiquito2 _kd_finiquito);

        // =========== cualidades ==========

        public abstract bool AdicionarCualidad(cls_kd_finiquito2 _kd_finiquito);

        public abstract DataSet ListarCualidades(int pu_id);

        public abstract DataSet DevolverDatosCualidad(int cu_id);

        public abstract bool ActualizarCualidad(cls_kd_finiquito2 _kd_finiquito);

        public abstract bool EliminarCualidad(cls_kd_finiquito2 _kd_finiquito);

        // ----------- cualidades ---------

        // =========== Normativa ==========

        public abstract bool AdicionarNormativa(cls_kd_finiquito2 _kd_finiquito);
        public abstract DataSet ListarNormas(int pu_id);
        public abstract DataSet DevolverDatosNorma(int nor_id);
        public abstract bool ActualizarNorma(cls_kd_finiquito2 _kd_finiquito);
        public abstract bool EliminarNorma(cls_kd_finiquito2 _kd_finiquito);
        // ----------- Nomrativa ----------


        public abstract bool AdicionarFormacion(cls_kd_finiquito2 _kd_finiquito);

        public abstract int AdicionarActividad(cls_kd_finiquito2 _kd_finiquito);

        public abstract int TotalActividad(int r_id);

        public abstract decimal TotalE(int result_pu_id);

        public abstract bool EliminarResultado(cls_kd_finiquito2 _kd_finiquito);

        public abstract bool EliminarActividad(cls_kd_finiquito2 _kd_finiquito);
        #endregion

        #region INFORMACION
        public abstract DataSet Cargos();
        public abstract DataSet Informacion(int es_id);
        public abstract DataSet UltimoCargo(int as_id, int per_id);
        public abstract DataSet GrillaInformacionFunc(
string per_id,
string per_tipo_doc,
string per_num_doc,
string per_lugar_exp,
string per_ap_paterno,
string per_ap_materno,
string per_nombres,
string per_ap_casada,
string per_sexo,
string per_fecha_nac,
string per_procedencia,
string per_serie_libreta_militar,
string per_lugar_nac,
string per_estado_civil);
        #endregion

        public abstract DataSet OBTENERGRIDASGINACIONES(cls_kd_asignacion_vacaciones _kd_asignacion_vacaciones, int nro);
    }
}


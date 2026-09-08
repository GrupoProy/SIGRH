using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

using Solution_Framework_Salarios.BussinessLogicLayer;

namespace Solution_Framework_Salarios.DataAccessLayer
{
	public abstract class DataAccessLayerDataAccessLayer
	{
		#region INSTANCIA PRINCIPAL DE CONEXION A UNA BD
		public Database CNXSIGRH3 = DatabaseFactory.CreateDatabase("CnxSigrh3");
		#endregion

		// INTERFACES
		#region _PLA_TRANSACCIONES_ACREEDOR
		public abstract bool Adicionar__pla_transacciones_acreedor(cls_pla_transacciones_acreedor _pla_transacciones_acreedor);
		public abstract bool Actualizar__pla_transacciones_acreedor(cls_pla_transacciones_acreedor _pla_transacciones_acreedor);
		public abstract bool Eliminar__pla_transacciones_acreedor(cls_pla_transacciones_acreedor _pla_transacciones_acreedor);
		public abstract DataSet ObtenerRegistro__pla_transacciones_acreedor(cls_pla_transacciones_acreedor _pla_transacciones_acreedor);
		public abstract DataSet ObtenerTablaGrilla__pla_transacciones_acreedor(
            string tra_acr_id, 
			string tra_tr_id, 
			string tra_estado);
		public abstract DataSet ObtenerTablaCombo__pla_transacciones_acreedor();
		#endregion

		#region _PLA_ACREEDOR_RETENCION
		public abstract int Adicionar__pla_acreedor_retencion(cls_pla_acreedor_retencion _pla_acreedor_retencion);
		public abstract bool Actualizar__pla_acreedor_retencion(cls_pla_acreedor_retencion _pla_acreedor_retencion);
		public abstract bool Eliminar__pla_acreedor_retencion(cls_pla_acreedor_retencion _pla_acreedor_retencion);
		public abstract DataSet ObtenerRegistro__pla_acreedor_retencion(cls_pla_acreedor_retencion _pla_acreedor_retencion);
		public abstract DataSet ObtenerTablaGrilla__pla_acreedor_retencion(
            string acr_id, 
			string acr_tipo_entidad, 
			string acr_descripcion, 
			string acr_documento, 
			string acr_estado);
		public abstract DataSet ObtenerTablaCombo__pla_acreedor_retencion();
        // (KCPB)
        public abstract DataSet ObtenerTablaGrillaF__pla_acreedor_retencion(string acr_per_id);
		#endregion

		#region _PLA_PROCESO
		public abstract bool Procesar_Sanciones_Adicional(int secuencial, int pc_id, int tipo);
		public abstract bool Procesar_Sanciones(int codigo);
		public abstract bool Adicionar__pla_proceso(cls_pla_proceso_salarios _pla_proceso);
		public abstract bool Actualizar__pla_proceso(cls_pla_proceso_salarios _pla_proceso);
		public abstract bool Eliminar__pla_proceso(cls_pla_proceso_salarios _pla_proceso);
		public abstract bool ObtenerId__pla_proceso(cls_pla_proceso_salarios _pla_proceso);
		public abstract bool ObtenerRegistro__pla_proceso(cls_pla_proceso_salarios _pla_proceso);
		public abstract DataSet ObtenerTablaGrilla__pla_proceso(string pc_id, 
						string pc_pr_id, 
						string pc_titulo, 
						string pc_fecha_inicio, 
						string pc_fecha_fin, 
						string pc_mn_id, 
						string pc_ufv, 
						string pc_ufv_fecha, 
						string pc_estado, 
						string pc_prefijo);
		public abstract DataSet ObtenerTablaCombo__pla_proceso();
		public abstract DataSet ObtenerUFVAnterior(cls_pla_proceso_salarios _pla_proceso);
		public abstract DataSet ObtenerUFVActual(cls_pla_proceso_salarios _pla_proceso);
		public abstract DataSet ObtenerSalarioMinimo(cls_pla_proceso_salarios _pla_proceso);
		public abstract DataSet ObtenerSalarioMinimoAdicional(cls_pla_proceso_salarios _pla_proceso);

		public abstract DataSet EjecutarProceso1(int cod_proceso);
		public abstract DataSet EjecutarProceso2(int cod_proceso);
		public abstract DataSet EjecutarProceso3(int cod_proceso);
		public abstract DataSet EjecutarProceso4(int cod_proceso);

		public abstract DataSet EjecutarProceso1_adicional(int cod_proceso, int secuencial);
		public abstract DataSet EjecutarProceso2_adicional(int cod_proceso, int secuencial);
		public abstract DataSet EjecutarProceso3_adicional(int cod_proceso, int secuencial);
		public abstract DataSet EjecutarProceso4_adicional(int cod_proceso, int secuencial);


		public abstract DataSet ObtenerMesesProceso();
		public abstract DataSet ObtenerMesesProceso_Liquidos();

		public abstract DataSet VerificarCasosDoblePercepcion(int cod_proceso, string accion);
		public abstract DataSet VerificarCasosDoblePercepcion_adicional(int cod_proceso, string accion, string secuencial);
		public abstract DataSet AjusteDoblePercepcion_adicional(string ti_tipo, int cbh_id, int horas, double ganado, double esc_por, double esc, double bono_a, double bono_f);
		public abstract bool AplicarAjusteDoblePercepcion_adicional(string ti_tipo, int cbh_id, int horas, double ganado, double esc_por, double esc, double bono_a, double bono_f);

		public abstract DataSet AjusteDoblePercepcion(string ti_tipo, int cbh_id, int horas, double ganado, double esc_por, double esc, double bono_a, double bono_f);
		public abstract bool AplicarAjusteDoblePercepcion(string ti_tipo, int cbh_id, int horas, double ganado, double esc_por, double esc, double bono_a, double bono_f);
		public abstract bool GenerarCarpetas_C31(int cod_proceso);
		public abstract DataSet Combos_C31(int cod_proceso, string accion);
		public abstract DataSet GenerarRegistroC31_4(string tipo_planilla, string archivos, int cod_proceso, string tipo_archivo);
		public abstract int ActualizarMesProceso(string cod_proceso);
		public abstract bool FinalizarProcesoPlanilla(string cod_proceso, string secuencial);
		public abstract DataSet VerificarPlanillasAdicionales(string cod_proceso);
		public abstract DataSet VerificarPlanillasRetroactivo();
		public abstract DataSet PlanillasMigradas_Retroactivo();
		public abstract bool FinalizarMigracion_Retroactivo();
		public abstract bool InsertarIncremento_Retroactivo(double incremento);

		public abstract bool MigrarPlanilla_Retroactivo(string cod_proceso, string nro, string id_usuario);
		public abstract string ObtenerConsultores_NumeroPlanilla(string cod_proceso);
		public abstract DataSet Insertar_MostrarCasos_Consultores(string cod_proceso, string secuencial);
		public abstract bool ProcesarConsultores_Paso1(string cod_proceso, string secuencial, string list_as_id);
		public abstract bool ProcesarConsultores_Paso2(string cod_proceso, string secuencial);
		public abstract bool ProcesarConsultores_Paso3(string cod_proceso, string secuencial);
		public abstract bool ProcesarConsultores_Paso4(string cod_proceso, string secuencial);
		public abstract DataSet VerificarPlanilla_Consultores(string cod_proceso, string secuencial);
		public  abstract DataSet NumeroPlanilla_Combo(string cod_proceso);
		public abstract DataSet NumeroPlanilla_ComboReportesAdicionales(string cod_proceso);


		#endregion

		#region _MP_ASIGNACION_TIPO_APORTANTE
		public abstract bool Adicionar__mp_asignacion_tipo_aportante(cls_mp_asignacion_tipo_aportante _mp_asignacion_tipo_aportante);
		public abstract bool Actualizar__mp_asignacion_tipo_aportante(cls_mp_asignacion_tipo_aportante _mp_asignacion_tipo_aportante);
		public abstract bool Eliminar__mp_asignacion_tipo_aportante(cls_mp_asignacion_tipo_aportante _mp_asignacion_tipo_aportante);
		public abstract bool ObtenerId__mp_asignacion_tipo_aportante(cls_mp_asignacion_tipo_aportante _mp_asignacion_tipo_aportante);
		public abstract DataSet ObtenerRegistro__mp_asignacion_tipo_aportante(cls_mp_asignacion_tipo_aportante _mp_asignacion_tipo_aportante);
		public abstract DataSet ObtenerTablaGrilla__mp_asignacion_tipo_aportante(
            string at_id, 
			string at_per_id, 
			string at_ta_id, 
			string at_estado);
		public abstract DataSet ObtenerTablaCombo__mp_asignacion_tipo_aportante();
        // (KCPB)
        public abstract DataSet ObtenerTablaGrillaC__mp_asignacion_tipo_aportante(
            string at_id,
            string at_per_id,
            string at_ta_id,
            string at_estado);
        // (KCPB)
        public abstract DataSet ObtenerRegistroTA__mp_asignacion_tipo_aportante(cls_mp_asignacion_tipo_aportante _mp_asignacion_tipo_aportante);
        // (KCPB)
        public abstract DataSet ObtenerTablaComboTA__mp_asignacion_tipo_aportante(
            int at_edad,
            bool at_jubilado);
        #endregion

        #region _PLA_CAS
        public abstract bool Adicionar__pla_cas(cls_pla_cas _pla_cas);
		public abstract bool Actualizar__pla_cas(cls_pla_cas _pla_cas);
		public abstract bool Eliminar__pla_cas(cls_pla_cas _pla_cas);
		public abstract bool ObtenerId__pla_cas(cls_pla_cas _pla_cas);
		public abstract DataSet ObtenerRegistro__pla_cas(cls_pla_cas _pla_cas);
		public abstract DataSet ObtenerTablaGrilla__pla_cas(
            string cs_id, 
			string cs_per_id, 
			string cs_res_adm, 
			string cs_nro_cas, 
			string cs_fecha_cas, 
			string cs_anos, 
			string cs_meses, 
			string cs_dias, 
			string cs_tipo_reg, 
			string cs_procesado, 
			string cs_estado);
		public abstract DataSet ObtenerTablaCombo__pla_cas();
        // (KCPB)
        public abstract DataSet ObtenerTablaGrillaC__pla_cas(
            string cs_id,
            string cs_per_id,
            string cs_res_adm,
            string cs_nro_cas,
            string cs_fecha_cas,
            string cs_anos,
            string cs_meses,
            string cs_dias,
            string cs_tipo_reg,
            string cs_procesado,
            string cs_estado);
        // (KCPB)
        public abstract DataSet ObtenerRegistroPB__pla_cas(cls_pla_cas _pla_cas);
		public abstract Double ObtenerHaberBasico_3Minimos();
        #endregion

        #region _ACREEDORES
        public abstract bool Adicionar__acreedores(cls_acreedores _acreedores);
		public abstract bool Actualizar__acreedores(cls_acreedores _acreedores);
        public abstract bool Eliminar__acreedores(cls_acreedores _acreedores);
		public abstract DataSet ObtenerRegistro__acreedores(cls_acreedores _acreedores);
		public abstract DataSet ObtenerTablaGrilla__acreedores(
            string ac_id, 
            string ac_per_id,
			string ac_descripcion, 
			string ac_tipo, 
			string ac_documento, 
			string ac_estado);
		public abstract DataSet ObtenerTablaCombo__acreedores();
		#endregion

		#region _PLA_TRANSACCIONES_CUOTAS
		public abstract bool Adicionar__pla_transacciones_cuotas(cls_pla_transacciones_cuotas _pla_transacciones_cuotas);
		public abstract bool Actualizar__pla_transacciones_cuotas(cls_pla_transacciones_cuotas _pla_transacciones_cuotas);
		public abstract bool Eliminar__pla_transacciones_cuotas(cls_pla_transacciones_cuotas _pla_transacciones_cuotas);
		public abstract DataSet ObtenerRegistro__pla_transacciones_cuotas(cls_pla_transacciones_cuotas _pla_transacciones_cuotas);
		public abstract DataSet ObtenerTablaGrilla__pla_transacciones_cuotas(
            string tc_id, 
			string tc_tr_id,
			string tc_cant_cuotas, 
			string tc_monto, 
			string tc_estado);
		public abstract DataSet ObtenerTablaCombo__pla_transacciones_cuotas();
		#endregion

		#region _PLA_TRANSACCIONES
		public abstract int Adicionar__pla_transacciones(cls_pla_transacciones _pla_transacciones);
		public abstract bool Actualizar__pla_transacciones(cls_pla_transacciones _pla_transacciones);
		public abstract bool Eliminar__pla_transacciones(cls_pla_transacciones _pla_transacciones);
		public abstract DataSet ObtenerRegistro__pla_transacciones(cls_pla_transacciones _pla_transacciones);
		public abstract DataSet ObtenerTablaGrilla__pla_transacciones(
            string tr_id, 
            string tr_pc_id, 
			string tr_per_id, 
			string tr_fa_id, 
			string tr_fecha_inicio, 
			string tr_fecha_fin, 
			string tr_monto, 
			string tr_estado);
		public abstract DataSet ObtenerTablaCombo__pla_transacciones();
        // (KCPB)
        public abstract DataSet ObtenerTablaGrillaRR__pla_transacciones(
            string tr_id,
            string tr_pc_id,
            string tr_per_id,
            string tr_fa_id,
            string tr_fecha_inicio,
            string tr_fecha_fin,
            string tr_monto,
            string tr_estado);
		public abstract DataSet ObtenerTransaccionesRetenciones(string as_id,
			string as_per_id,
			string as_ca_id,
			string as_fecha_inicio,
			string as_fecha_fin,
			string as_estado,
			string as_tipo_reg,
			string as_tipo_mov,
			string as_tipo_baja,
			string as_validacion,
			string as_fecha_validacion,
			string as_memo,
			string as_memo_baja,
			string as_pr_id);
		public abstract DataSet ListarTotalCuotas();
		public abstract bool QuitarDescuento(int tr_id);
		#endregion

		#region _PLA_FACTOR
		public abstract bool Adicionar__pla_factor(cls_pla_factor _pla_factor);
		public abstract bool Actualizar__pla_factor(cls_pla_factor _pla_factor);
		public abstract bool Eliminar__pla_factor(cls_pla_factor _pla_factor);
		public abstract bool ObtenerId__pla_factor(cls_pla_factor _pla_factor);
		public abstract DataSet ObtenerRegistro__pla_factor(cls_pla_factor _pla_factor);
		public abstract DataSet ObtenerTablaGrilla__pla_factor(
            string fa_id, 
			string fa_descripcion, 
			string fa_signo, 
			string fa_ac_id, 
			string fa_tipo_calculo, 
			string fa_valor, 
			string fa_estado);
		public abstract DataSet ObtenerTablaCombo__pla_factor();
        // (KCPB)
        public abstract DataSet ObtenerTablaComboX__pla_factor(cls_pla_factor _pla_factor);

        // Funciones (JQC)
        public abstract DataSet ObtenerTipoTrans(cls_pla_factor _pla_factor);
        public abstract DataSet ObtenerNroHorasExtras(cls_pla_factor _pla_factor);
        public abstract DataSet ObtenerCategoriaProg(cls_pla_factor _pla_factor);
        public abstract DataSet ObtenerPresupuesto(cls_pla_factor _pla_factor);
        public abstract DataSet ObtenerPagadoDevengado(cls_pla_factor _pla_factor);
        public abstract DataSet ObtenerProceso(cls_pla_factor _pla_factor);
        public abstract bool AdicionarTransaccion(cls_pla_factor _pla_factor);
		public abstract int AdicionarTransaccionMontoUnico(cls_pla_factor _pla_factor);
		public abstract bool AdicionarTransaccionPorCuotas(cls_pla_factor _pla_factor);


		public abstract DataSet ObtenerTransaccion(cls_pla_factor _pla_factor);
        public abstract DataSet ObtenerGrillaHE(cls_pla_factor _pla_factor);
        public abstract bool EliminarTransaccion(cls_pla_factor _pla_factor);
        public abstract bool EliminarTransaccionIVA(cls_pla_factor _pla_factor);
        public abstract DataSet ObtenerAporteIva(cls_pla_factor _pla_factor);
        public abstract DataSet ObtenerGrillaAporteIVA(cls_pla_factor _pla_factor);
        public abstract DataSet ObtenerGrillaMontoPresentar(cls_pla_factor _pla_factor);
        public abstract DataSet ObtenerTipoSindicato(cls_pla_factor _pla_factor);
        public abstract DataSet ListarGrillaAporteSindicato(cls_pla_factor _pla_factor);
        public abstract DataSet ObtenerTipoEstadoAporte(cls_pla_factor _pla_factor);
        public abstract DataSet ObtenerGrillaAporteSindicato(cls_pla_factor _pla_factor);
        public abstract DataSet ObtenerGrillaAsignacionHE(cls_pla_factor _pla_factor);
        public abstract DataSet ObtenerTipoEscalafon(cls_pla_factor _pla_factor);
        public abstract bool EliminarAsigHorasExtras(cls_pla_factor _pla_factor);
        public abstract bool AdicionarLimiteHorasExtras(cls_pla_factor _pla_factor);
        public abstract DataSet ObtenerGrillaLimiteHE(cls_pla_factor _pla_factor);
        public abstract DataSet listaFiltradoTipoDocHE(cls_pla_factor _pla_factor);
        public abstract DataSet ObtenerGrillaFactores(cls_pla_factor _pla_factor);
        public abstract DataSet ObtenerFactorX(cls_pla_factor _pla_factor);
        public abstract bool ActualizarFactor(cls_pla_factor _pla_factor);
        public abstract DataSet ObtenerGrillaHorasExtras(cls_pla_factor _pla_factor);
		public abstract DataSet ObtenerComboCovenios();
		public abstract DataSet ListarGrillaConvenios(cls_pla_factor _pla_factor);
		public abstract bool AdicionarTransaccionConvenios(cls_pla_factor _pla_factor);
		public abstract DataSet ListarGrillaDescuentos(cls_pla_factor _pla_factor);
		public abstract DataSet ObtenerComboOtrosDescuentos();
		public abstract DataSet ListaGrillaOtrosDescuentos(cls_pla_factor _pla_factor);
		public abstract DataSet ListarDescuentosMontosCuotas();
		public abstract bool ActivarDesactivarFNTUB(string estado, double valor, int fa_id);
		#endregion

		#region PLA_DOCENTE_HORAS
		public abstract bool Estadoimpreso(cls_pla_docentes_adicional adicional);
		public abstract DataSet ListarGrillaDocentesMes();
		public abstract bool AdicionarHorasDocentes(cls_pla_docente_horas _pla_docentes);
		public abstract bool ModificarHorasDocentes(cls_pla_docente_horas _pla_docentes);

		public abstract DataSet ObtenerUnidadesOrganizacionales();
		public abstract DataSet ObtenerUnidadesOrganizacionales_filtrado(int per_id);

		public abstract DataSet ListarGrillaDocentesMesPorUnidad(int eo_id);
		public abstract DataSet ObtenerAsignacionAdicionalDocentes();
		public abstract bool AdicionarAsignacionAdicionalDocentes(cls_pla_docentes_adicional _Pla_Docentes_Adicional);
		public abstract DataSet ListarAsignacionesAdicionalesDocentes(cls_pla_docentes_adicional _Pla_Docentes_Adicional);
		public abstract bool EliminarAsignacionAdicional(int td_id);
		public abstract String ObtenerIdEstructuraBaseParaAsignacionesadicionalesDocentes();
		public abstract DataSet ObtenerPeriodoAsignacionesAdicionales();
		public abstract DataSet ObtenerTodasAsignacionesAdicionalesDocentes();
		public abstract bool ProcesarAsignacionesAdicionales();
		public abstract DataSet UnidadesOrganizacionalesAltasBajas();
		#endregion

		#region REFRIGERIO
		public abstract DataSet ObtenerNroPlanilla(int pc_id);
		#endregion

		#region ASISTENCIA
		public abstract bool GenerarAsistenciaIndiv(cls_asistencia asisten);
		public abstract DataSet LlenarCombo();
		public abstract DataSet CargarGestiones(cls_asistencia asisten);
		#endregion

		#region RETROACTIVO
		public abstract bool ProcesoRetroactivo1(int pc_id, int secuencial);
		#endregion
	}
}


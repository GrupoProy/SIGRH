using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

using Solution_Framework_ManualPuestos.BussinessLogicLayer;

namespace Solution_Framework_ManualPuestos.DataAccessLayer
{
    public abstract class DataAccessLayerDataAccessLayer
    {
        #region INSTANCIA PRINCIPAL DE CONEXION A UNA BD

        public Database CnxSigrh3 = DatabaseFactory.CreateDatabase("CnxSigrh3");

        #endregion

        // INTERFACES
		#region SI_UDEP_IDIOMAORIG
		public abstract bool Adicionar_SI_UDEP_IdiomaOrig(clsSI_UDEP_IdiomaOrig SI_UDEP_IdiomaOrig);
		public abstract bool Actualizar_SI_UDEP_IdiomaOrig(clsSI_UDEP_IdiomaOrig SI_UDEP_IdiomaOrig);
		public abstract bool Eliminar_SI_UDEP_IdiomaOrig(clsSI_UDEP_IdiomaOrig SI_UDEP_IdiomaOrig);
		public abstract bool ObtenerId_SI_UDEP_IdiomaOrig(clsSI_UDEP_IdiomaOrig SI_UDEP_IdiomaOrig);
		public abstract bool ObtenerRegistro_SI_UDEP_IdiomaOrig(clsSI_UDEP_IdiomaOrig SI_UDEP_IdiomaOrig);
		public abstract DataSet ObtenerTablaGrilla_SI_UDEP_IdiomaOrig(string id, 
						string Cod_fun, 
						string P1_1, 
						string P1_2, 
						string P1_3, 
						string P1_4, 
						string P1_5, 
						string P1_6, 
						string P1_7, 
						string P1_8, 
						string P1_9, 
						string P1_10, 
						string P1_11, 
						string P1_12, 
						string P2, 
						string P3, 
						string P3_1, 
						string P3_2, 
						string P4, 
						string P4_1, 
						string P4_2, 
						string P5, 
						string P5_1, 
						string P6_1_Cual_Idioma, 
						string P6_1_Donde, 
						string P6_2);
		public abstract DataSet ObtenerTablaCombo_SI_UDEP_IdiomaOrig();
        #endregion

        #region _MDP_FORMACION
        public abstract bool Adicionar__mdp_formacion(cls_mdp_formacion _mdp_formacion);
        public abstract bool Actualizar__mdp_formacion(cls_mdp_formacion _mdp_formacion);
        public abstract bool Eliminar__mdp_formacion(cls_mdp_formacion _mdp_formacion);
        public abstract bool ObtenerId__mdp_formacion(cls_mdp_formacion _mdp_formacion);
        public abstract bool ObtenerRegistro__mdp_formacion(cls_mdp_formacion _mdp_formacion);
        public abstract DataSet ObtenerTablaGrilla__mdp_formacion(string fo_id,
                        string fo_tipo,
                        string fo_descripcion,
                        string fo_estado);
        public abstract DataSet ObtenerTablaCombo__mdp_formacion();

        public abstract DataSet ObtenerGrillaFormacion();

        public abstract bool EliminarFormacion(cls_mdp_formacion _mdp_formacion);
        public abstract bool ObtenerFormacionP(cls_mdp_formacion _mdp_formacion);
        #endregion

        #region _MDP_CARACTER_INDIVIDUAL
        public abstract bool Adicionar__mdp_caracter_individual(cls_mdp_caracter_individual _mdp_caracter_individual);
        public abstract bool Actualizar__mdp_caracter_individual(cls_mdp_caracter_individual _mdp_caracter_individual);
        public abstract bool Eliminar__mdp_caracter_individual(cls_mdp_caracter_individual _mdp_caracter_individual);
        public abstract bool ObtenerId__mdp_caracter_individual(cls_mdp_caracter_individual _mdp_caracter_individual);
        public abstract bool ObtenerRegistro__mdp_caracter_individual(cls_mdp_caracter_individual _mdp_caracter_individual);
        public abstract DataSet ObtenerTablaGrilla__mdp_caracter_individual(string ci_id,
                        string ci_orden,
                        string ci_factor,
                        string ci_descripcion,
                        string ci_puntaje,
                        string ci_estado);
        public abstract DataSet ObtenerTablaCombo__mdp_caracter_individual();

        public abstract DataSet ObtenerGrillaCaracterIndividual();

        public abstract bool EliminarCaracterInd(cls_mdp_caracter_individual _mdp_caracter_individual);
        public abstract bool ObtenerCaracterIndividualP(cls_mdp_caracter_individual _mdp_caracter_individual);
        #endregion

        #region _MDP_CONOCIMIENTO
        public abstract bool Adicionar__mdp_conocimiento(cls_mdp_conocimiento _mdp_conocimiento);
        public abstract bool Actualizar__mdp_conocimiento(cls_mdp_conocimiento _mdp_conocimiento);
        public abstract bool Eliminar__mdp_conocimiento(cls_mdp_conocimiento _mdp_conocimiento);
        public abstract bool ObtenerId__mdp_conocimiento(cls_mdp_conocimiento _mdp_conocimiento);
        public abstract bool ObtenerRegistro__mdp_conocimiento(cls_mdp_conocimiento _mdp_conocimiento);
        public abstract DataSet ObtenerTablaGrilla__mdp_conocimiento(string co_id,
                        string co_descripcion,
                        string co_estado);
        public abstract DataSet ObtenerTablaCombo__mdp_conocimiento();

        public abstract DataSet ObtenerGrillaConocimiento();

        public abstract bool EliminarConocimiento(cls_mdp_conocimiento _mdp_conocimiento);

        public abstract bool ObtenerConocimientoP(cls_mdp_conocimiento _mdp_conocimiento);
        #endregion

        #region _MDP_DISPOSICION_JURIDICA
        public abstract bool Adicionar__mdp_disposicion_juridica(cls_mdp_disposicion_juridica _mdp_disposicion_juridica);
        public abstract bool Actualizar__mdp_disposicion_juridica(cls_mdp_disposicion_juridica _mdp_disposicion_juridica);
        public abstract bool Eliminar__mdp_disposicion_juridica(cls_mdp_disposicion_juridica _mdp_disposicion_juridica);
        public abstract bool ObtenerId__mdp_disposicion_juridica(cls_mdp_disposicion_juridica _mdp_disposicion_juridica);
        public abstract bool ObtenerRegistro__mdp_disposicion_juridica(cls_mdp_disposicion_juridica _mdp_disposicion_juridica);
        public abstract DataSet ObtenerTablaGrilla__mdp_disposicion_juridica(string dj_id,
                        string dj_descripcion,
                        string dj_estado);
        public abstract DataSet ObtenerTablaCombo__mdp_disposicion_juridica();

        public abstract DataSet ObtenerGrillaDisposicion();

        public abstract bool EliminarDisposicion(cls_mdp_disposicion_juridica _mdp_disposicion_juridica);
        public abstract bool ObtenerDisposicionP(cls_mdp_disposicion_juridica _mdp_disposicion_juridica);
        #endregion

        #region _MDP_RESULTADOS_ESPECIFICOS
        public abstract bool Adicionar__mdp_resultados_especificos(cls_mdp_resultados_especificos _mdp_resultados_especificos);
        public abstract bool AdicionarConocimiento(cls_mdp_resultados_especificos _mdp_resultados_especificos);
        public abstract bool AdicionarDisposicion(cls_mdp_resultados_especificos _mdp_resultados_especificos);
        public abstract bool AdicionarCaracterIndividual(cls_mdp_resultados_especificos _mdp_resultados_especificos);
        public abstract bool AdicionarTarea(cls_mdp_resultados_especificos _mdp_resultados_especificos);
        public abstract bool AdicionarFormacionO(cls_mdp_resultados_especificos _mdp_resultados_especificos);
        public abstract bool AdicionarFormacionC(cls_mdp_resultados_especificos _mdp_resultados_especificos);
        public abstract bool AdicionarResponsabilidad(cls_mdp_resultados_especificos _mdp_resultados_especificos);
        public abstract bool AdicionarItem(cls_mdp_resultados_especificos _mdp_resultados_especificos);
        public abstract bool Actualizar__mdp_resultados_especificos(cls_mdp_resultados_especificos _mdp_resultados_especificos);
        public abstract bool ActualizarTarea(cls_mdp_resultados_especificos _mdp_resultados_especificos);
        public abstract bool ActualizarFormacionO(cls_mdp_resultados_especificos _mdp_resultados_especificos);
        public abstract bool ActualizarFormacionC(cls_mdp_resultados_especificos _mdp_resultados_especificos);
        public abstract bool ActualizarResponsabilidad(cls_mdp_resultados_especificos _mdp_resultados_especificos);
        public abstract bool ActualizarItem(cls_mdp_resultados_especificos _mdp_resultados_especificos);
        public abstract bool Eliminar__mdp_resultados_especificos(cls_mdp_resultados_especificos _mdp_resultados_especificos);
        public abstract bool ObtenerId__mdp_resultados_especificos(cls_mdp_resultados_especificos _mdp_resultados_especificos);
        public abstract bool ObtenerRegistro__mdp_resultados_especificos(cls_mdp_resultados_especificos _mdp_resultados_especificos);
        public abstract DataSet ObtenerTablaGrilla__mdp_resultados_especificos(string res_id,
                        string res_poai_id,
                        string res_descripcion,
                        string res_indicador,
                        string res_puntaje,
                        string res_estado);
        public abstract DataSet ObtenerTablaCombo__mdp_resultados_especificos();

        public abstract bool ObtenerFicha(cls_mdp_resultados_especificos _mdp_resultados_especificos);

        public abstract DataSet ObtenerGrillaSupervision(cls_mdp_resultados_especificos _mdp_resultados_especificos);
        public abstract DataSet ObtenerGrillaResultados(cls_mdp_resultados_especificos _mdp_resultados_especificos);

        public abstract DataSet ObtenerGrillaTareas(cls_mdp_resultados_especificos _mdp_resultados_especificos);

        public abstract DataSet ObtenerGrillaConocimiento(cls_mdp_resultados_especificos _mdp_resultados_especificos);

        public abstract DataSet ObtenerGrillaDisposicion(cls_mdp_resultados_especificos _mdp_resultados_especificos);

        public abstract DataSet ObtenerListaRespons();

        public abstract DataSet ObtenerResponsItem(cls_mdp_resultados_especificos _mdp_resultados_especificos);

        public abstract DataSet ObtenerListaFiltradoFormO();

        public abstract DataSet ObtenerFormOItem(cls_mdp_resultados_especificos _mdp_resultados_especificos);

        public abstract DataSet ObtenerListaFiltradoFormC();

        public abstract DataSet ObtenerFormCItem(cls_mdp_resultados_especificos _mdp_resultados_especificos);

        public abstract DataSet ObtenerListaFiltradoFormRequerida();
        public abstract DataSet ObtenerFormRequeridaItem(cls_mdp_resultados_especificos _mdp_resultados_especificos);

        public abstract DataSet ObtenerListaFiltradoAreaFormacion();

        public abstract DataSet ObtenerFiltradoConcocimiento(cls_mdp_resultados_especificos _mdp_resultados_especificos);
        public abstract DataSet ObtenerFiltradoDisposicion(cls_mdp_resultados_especificos _mdp_resultados_especificos);
        public abstract DataSet ObtenerFiltradoCaracterIndividual(cls_mdp_resultados_especificos _mdp_resultados_especificos);

        public abstract DataSet ObtenerGrillaCaracterI(cls_mdp_resultados_especificos _mdp_resultados_especificos);
        public abstract DataSet ObtenerSumaPuntaje(cls_mdp_resultados_especificos _mdp_resultados_especificos);
        public abstract DataSet ObtenerSumaPuntajeEditar(cls_mdp_resultados_especificos _mdp_resultados_especificos);
        public abstract DataSet ObtenerSiguienteItem(cls_mdp_resultados_especificos _mdp_resultados_especificos);
        public abstract DataSet ObtenerCodigo(cls_mdp_resultados_especificos _mdp_resultados_especificos);

        public abstract bool ObtenerTiempoExperiencia(cls_mdp_resultados_especificos _mdp_resultados_especificos);

        public abstract bool EliminarResultado(cls_mdp_resultados_especificos _mdp_resultados_especificos);

        public abstract bool ObtenerResultadoP(cls_mdp_resultados_especificos _mdp_resultados_especificos);

        public abstract bool EliminarTarea(cls_mdp_resultados_especificos _mdp_resultados_especificos);

        public abstract bool ObteneTareaP(cls_mdp_resultados_especificos _mdp_resultados_especificos);

        public abstract bool EliminarConocimiento(cls_mdp_resultados_especificos _mdp_resultados_especificos);

        public abstract bool EliminarDisposicion(cls_mdp_resultados_especificos _mdp_resultados_especificos);

        public abstract bool EliminarCaracterI(cls_mdp_resultados_especificos _mdp_resultados_especificos);
        public abstract DataSet ObtenerSumaPuntajeT(string id);
        public abstract bool BusquedaPuestoMP(cls_mdp_resultados_especificos _mdp_resultados_especificos);

        #endregion

        #region _MDP_PUESTO
        public abstract bool Adicionar__mdp_puesto(cls_mdp_puesto _mdp_puesto);
        public abstract bool Actualizar__mdp_puesto(cls_mdp_puesto _mdp_puesto);
        public abstract bool Eliminar__mdp_puesto(cls_mdp_puesto _mdp_puesto);
        public abstract bool ObtenerId__mdp_puesto(cls_mdp_puesto _mdp_puesto);
        public abstract bool ObtenerRegistro(cls_mdp_puesto _mdp_puesto);
        public abstract bool ObtenerRegistro__mdp_puesto(cls_mdp_puesto _mdp_puesto);
        public abstract DataSet ObtenerTablaGrilla__mdp_puesto(string pu_poai_id,
                        string pu_nro_puesto,
                        string pu_nombre_puesto,
                        string pu_pref_puesto,
                        string pu_objetivo,
                        string pu_id_puesto_anterior,
                        string pu_estado);
        public abstract DataSet ObtenerTablaCombo__mdp_puesto();
        public abstract DataSet ObtenerGrillaPuesto(cls_mdp_puesto _mdp_puesto);
        public abstract DataSet ObtenerGrillaFiltro(cls_mdp_puesto _mdp_puesto);
        public abstract DataSet ObtenerGrillaFiltroIntervalo(cls_mdp_puesto _mdp_puesto);
        public abstract DataSet ObtenerGrillaFiltroCM(cls_mdp_puesto _mdp_puesto);
        public abstract DataSet ObtenerGrillaFiltroConocimientoCM(cls_mdp_puesto _mdp_puesto);
        public abstract DataSet ObtenerFiltradoCargo(cls_mdp_puesto _mdp_puesto);
        public abstract DataSet ObtenerFiltradoDirAdm(cls_mdp_puesto _mdp_puesto);
        public abstract DataSet ObtenerFiltradoUnidadEjec(cls_mdp_puesto _mdp_puesto);
        public abstract DataSet ObtenerFiltradoUnidadOrg(cls_mdp_puesto _mdp_puesto);
        public abstract DataSet ObtenerFiltradoGestion();
        public abstract DataSet ObtenerGestion(cls_mdp_puesto _mdp_puesto);
        public abstract DataSet ObtenerNombreFun(cls_mdp_puesto _mdp_puesto);
        public abstract bool ObtenerDatosItem(cls_mdp_puesto _mdp_puesto);
        public abstract bool ObtenerDatosItemAnterior(cls_mdp_puesto _mdp_puesto);
        public abstract DataSet ObtenerFiltradoConcocimiento(cls_mdp_puesto _mdp_puesto);
        public abstract bool AdicionarTareaCM(cls_mdp_puesto _mdp_puesto);
        public abstract bool AdicionarConocimientoCM(cls_mdp_puesto _mdp_puesto);
        public abstract bool validaRegistroConocimiento(cls_mdp_puesto _mdp_puesto);
        public abstract DataSet ObtenerNivelOrg(cls_mdp_puesto _mdp_puesto);
        public abstract DataSet ObtenerNivelOrgItems(cls_mdp_puesto _mdp_puesto);
        public abstract DataSet ObtenerDetalleitem(cls_mdp_puesto _mdp_puesto);
        public abstract DataSet ObtenerFiltradoCargoUO(cls_mdp_puesto _mdp_puesto);
        public abstract DataSet ObtenerFiltradoTipoItem(cls_mdp_puesto _mdp_puesto);
        public abstract DataSet ObtenerDetalleUO(cls_mdp_puesto _mdp_puesto);
        public abstract DataSet ObtenerFiltradoTipoDoc();
        public abstract DataSet ObtenerIdCargo();
        public abstract DataSet ObtenerNroItem();
        public abstract bool AdicionarCargo(cls_mdp_puesto _mdp_puesto);
        public abstract bool AdicionarGlosa(cls_mdp_puesto _mdp_puesto);

        public abstract DataSet ObtenerGrillaItems(cls_mdp_puesto _mdp_puesto);
        public abstract DataSet ObtenerDetalleitemCargo(cls_mdp_puesto _mdp_puesto);
        public abstract DataSet ObtenerHistoricoItem(cls_mdp_puesto _mdp_puesto);
        public abstract bool ActualizarItem(cls_mdp_puesto _mdp_puesto);

        public abstract bool EliminarItem(cls_mdp_puesto _mdp_puesto);

        public abstract bool Adicionar_descriptor_puestos(int per_id);

        public abstract DataSet Listar_Supervisores();


        public abstract bool Add_descriptor_puestos(int per_id, int superv_id, String descrip_pu_objetivo);


        public abstract int Verificar_ca_id(int per_id);
        public abstract DataSet ObtenerRegistro_DescriptorPuesto(int descrip_pu_id);

        public abstract bool Add_DPR(string result_indicador, decimal result_ponderacion, String result_resultado, int dpr);

        public abstract DataSet ListarTareaEspecifica(int dpr, string result_tipo);

        public abstract DataSet DevolverDatosResultadosEspecificos(int dpr_id);

        public abstract DataSet ListarTareaE(int id_r);

       // public abstract bool Eliminar_TE(int des_p_result_id);

        public abstract decimal TotalE(int descrip_pu_id);

        public abstract DataSet ListarResltaE(int id_r);

         public abstract bool Update_DPR(int des_p_result_id, string result_indicador, decimal result_ponderacion, string result_resultado);
         public abstract bool Eliminar_DPR(int des_p_result_id, string result_estado);

        public abstract bool Actualizar_UPR(cls_mp_descriptor_puestos _mp_descriptor_puestos);

        public abstract bool Update_DPEE(int des_p_result_id, string result_indicador, decimal result_ponderacion, string result_resultado);
        public abstract string Add_TareaEspecifica(string result_indicador, decimal result_ponderacion, String result_resultado, int dpr);

        //============================ TAREAS RECURRENTES ================================================
        // public abstract bool Add_TareaRecurrente(decimal result_ponderacion, String result_resultado, int dpr);

        public abstract decimal TotalER(int descrip_pu_id, string result_tipo);

        public abstract string Add_TareaRecurrente(decimal result_ponderacion, String result_resultado, int dpr);

        public abstract bool Update_DPER(int des_p_result_id, string result_indicador, decimal result_ponderacion, string result_resultado);

        //==================================== AGREGAR PDF ======================== 
        public abstract int UpdateTER_PDF(int des_p_result_id, byte[] descrip_pdf);
        //======================== SUPERVISOR ====================================
        public abstract int Obtener_idSuperv(int per_id);
        public abstract int supervisor_id(int per_id);
        public abstract DataSet ListarTareaSuper(int superv_id);
        public abstract DataSet ListarTareaER(int dpr);

       // public abstract byte[] ObtenerPdf(int descrip_pu_id);
        public abstract DataSet ObtenerPdf(int des_p_result_id);
        //----------------------------- EVALUACION -------------------------------------------
        public abstract string Add_Eva(decimal ponderacion, int prdo, int result_id);

        public abstract decimal result_PonderacionTarea(int des_p_result_id);

        public abstract bool Update_EstadoResultado(int des_p_result_id, string result_estado);

        public abstract DataSet Listar_EvaluacionesCa(int descrip_pu_id);

        public abstract DataSet ResultEva(int evalua_dp_id);

        public abstract int devuelver_Si_hayPDF(int des_p_result_id);

        public abstract int ca_per(int per_id);

        public abstract int ne_secuencial(int ca_id);

        public abstract int devuelver_ca_id(int per_id);

        public abstract int ne_id(int ca_id);

        public abstract int result(int ca_id);

        public abstract bool Update_DP(int pu_id, string pu_objetivo);

        public abstract string Nom_Com(int pu_id);

        #endregion
        public abstract DataSet ObtenerTablaGrillaC__mp_asignacion(string per_id);
    }
}


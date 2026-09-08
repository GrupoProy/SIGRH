using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

using Solution_Framework_Precontratacion.BussinessLogicLayer;

namespace Solution_Framework_Precontratacion.DataAccessLayer
{
	public abstract class DataAccessLayerDataAccessLayer
	{
		#region INSTANCIA PRINCIPAL DE CONEXION A UNA BD
		public Database CNXSIGRH3 = DatabaseFactory.CreateDatabase("CnxSigrh3");
		#endregion

		// INTERFACES 
		#region _PERMISO_CATEGORIA_PROGRAMATICA
		public abstract bool Adicionar__permiso_categoria_programatica(cls_permiso_categoria_programatica _permiso_categoria_programatica);
		public abstract bool Actualizar__permiso_categoria_programatica(cls_permiso_categoria_programatica _permiso_categoria_programatica);
		public abstract bool Eliminar__permiso_categoria_programatica(cls_permiso_categoria_programatica _permiso_categoria_programatica);
		public abstract DataSet ObtenerRegistro__permiso_categoria_programatica(cls_permiso_categoria_programatica _permiso_categoria_programatica);
		public abstract DataSet ObtenerTablaGrilla__permiso_categoria_programatica(
            string pcp_id, 
			string pcp_rol, 
			string pcp_ue, 
			string pcp_cp_id, 
			string pcp_estado, 
			string pcp_us_id, 
			string pcp_pr_id);
        public abstract DataSet ObtenerTablaCombo__permiso_categoria_programatica(cls_permiso_categoria_programatica _permiso_categoria_programatica);
        #endregion

        #region _PC_PRECONTRATADO
        public abstract bool Adicionar__pc_precontratado(cls_pc_precontratado _pc_precontratado);
		public abstract bool AdicionarSeguimiento(cls_pc_precontratado _pc_precontratado);
		public abstract bool Actualizar__pc_precontratado(cls_pc_precontratado _pc_precontratado);
		public abstract bool ActualizarFecha(cls_pc_precontratado _pc_precontratado);
		public abstract bool Eliminar__pc_precontratado(cls_pc_precontratado _pc_precontratado);
		public abstract bool ObtenerId__pc_precontratado(cls_pc_precontratado _pc_precontratado);
		public abstract bool ObtenerRegistro__pc_precontratado(cls_pc_precontratado _pc_precontratado);
		public abstract DataSet ObtenerRegistroTipoItem(cls_pc_precontratado _pc_precontratado);
		public abstract DataSet ObtenerTablaGrilla__pc_precontratado(string pre_id, 
						string pre_paterno, 
						string pre_materno, 
						string pre_nombres, 
						string pre_ap_casada, 
						string pre_fecha_inicio, 
						string pre_fecha_fin, 
						string pre_tiempo, 
						string pre_val_aceptado_RRHH, 
						string pre_pl_id, 
						string pre_fr_id, 
						string pre_pu_id, 
						string pre_as_id, 
						string pre_presenta_djbr, 
						string pre_cod_carpeta, 
						string pre_afp, 
						string pre_obj_puesto, 
						string pre_tareas, 
						string pre_numero_item, 
						string pre_estado);
		public abstract DataSet ObtenerTablaCombo__pc_precontratado();
		public abstract DataSet ListarPlanillas(cls_pc_precontratado _pc_precontratado);
		public abstract DataSet DetallePrecontrato(cls_pc_precontratado _pc_precontratado);
		public abstract DataSet DatosDetallePrecontrato(cls_pc_precontratado _pc_precontratado);
		public abstract DataSet DetallePlanilla(cls_pc_precontratado _pc_precontratado);
		public abstract DataSet ListarUE(cls_pc_precontratado _pc_precontratado);
		public abstract DataSet AdicionarPlanilla(cls_pc_precontratado _pc_precontratado);
		public abstract DataSet EliminarPlanilla(cls_pc_precontratado _pc_precontratado);
		public abstract DataSet AdicionarPreContratadoPuesto(cls_pc_precontratado _pc_precontratado);
		public abstract DataSet ListarPrecontratos(cls_pc_precontratado _pc_precontratado);
		public abstract DataSet BuscarFuncionario(cls_pc_precontratado _pc_precontratado);
		public abstract DataSet ObtenerGestion(cls_pc_precontratado _pc_precontratado);
		public abstract DataSet ObtenerContrato(cls_pc_precontratado _pc_precontratado);
		public abstract DataSet ObtenerContratoEditar(cls_pc_precontratado _pc_precontratado);
		public abstract DataSet ObtenerUltimaFrec(cls_pc_precontratado _pc_precontratado);
		public abstract DataSet ObtenerUltimaFrecEditar(cls_pc_precontratado _pc_precontratado);
		public abstract DataSet ObtenerPrecontrato(cls_pc_precontratado _pc_precontratado);
		public abstract DataSet ObtenerPrecontratoEditar(cls_pc_precontratado _pc_precontratado);
		public abstract DataSet AsignarPersona(cls_pc_precontratado _pc_precontratado);
		public abstract DataSet ModificarPersona(cls_pc_precontratado _pc_precontratado);
		public abstract DataSet AsignarPersonaNueva(cls_pc_precontratado _pc_precontratado);
		public abstract DataSet ActualizarPersonaNueva(cls_pc_precontratado _pc_precontratado);
		public abstract DataSet ListarUsuarios(cls_pc_precontratado _pc_precontratado);
		public abstract DataSet ActualizarEstadoPlanilla(cls_pc_precontratado _pc_precontratado);
		public abstract DataSet ActualizarEstadoPlanillaUDEP(cls_pc_precontratado _pc_precontratado);
		public abstract bool ActualizarEstadoPrecontrato(cls_pc_precontratado _pc_precontratado);
		public abstract bool ActualizarEstadoPrecontratoEnvio(cls_pc_precontratado _pc_precontratado);
		public abstract bool EliminarAsignacion(cls_pc_precontratado _pc_precontratado);
		public abstract bool EliminarAsignacionNuevo(cls_pc_precontratado _pc_precontratado);
		public abstract bool ActualizarPuesto(cls_pc_precontratado _pc_precontratado);
		public abstract bool ActualizarPuestoDJBR(cls_pc_precontratado _pc_precontratado);
        public abstract DataSet DatosPuestoX(cls_pc_precontratado _pc_precontratado);
        public abstract DataSet ObtenerNroItem(cls_pc_precontratado _pc_precontratado);
        public abstract DataSet ObtenerListaFiltradoPlanilla(cls_pc_precontratado _pc_precontratado, string q);
        public abstract DataSet ListarPlanillasAprobar(cls_pc_precontratado _pc_precontratado);
        public abstract DataSet ObtenerEstadoPlanilla(cls_pc_precontratado _pc_precontratado);
        public abstract DataSet ObtenerCambiarEstadoPlanilla(cls_pc_precontratado _pc_precontratado);
        public abstract DataSet ListarAnulados(cls_pc_precontratado _pc_precontratado);
        public abstract DataSet ListarPlanillasValidar(cls_pc_precontratado _pc_precontratado);
        public abstract DataSet ObtenerValidacionFechas(cls_pc_precontratado _pc_precontratado);
        public abstract DataSet ObtenerCambiarFechas(cls_pc_precontratado _pc_precontratado);
        public abstract DataSet ListarPlanillasUDEP(cls_pc_precontratado _pc_precontratado);
        public abstract DataSet DatosPrecontratoUDEP(cls_pc_precontratado _pc_precontratado);
        public abstract bool PrecontratoEstadoUDEP(cls_pc_precontratado _pc_precontratado);
        public abstract DataSet ListarPlanillasObservadas(cls_pc_precontratado _pc_precontratado);
        public abstract DataSet ListarPlanillasBusqueda(cls_pc_precontratado _pc_precontratado);
        public abstract DataSet StockCargosUE(cls_pc_precontratado _pc_precontratado);
        public abstract DataSet DetalleCargo(cls_pc_precontratado _pc_precontratado);
        public abstract DataSet DetallePreFuncionario(cls_pc_precontratado _pc_precontratado);
        public abstract DataSet ObtenerDescendencia(cls_pc_precontratado _pc_precontratado);
        public abstract DataSet ListarPrecontratosValidados(cls_pc_precontratado _pc_precontratado);
        public abstract DataSet DetallePreFuncionarioNuevo(cls_pc_precontratado _pc_precontratado);
        public abstract DataSet EliminarPreFuncionarioNuevo(cls_pc_precontratado _pc_precontratado);
        public abstract DataSet ObtenerResumenPlanilla(cls_pc_precontratado _pc_precontratado);
        public abstract DataSet ActualizarDatosPersonaUDEP(cls_pc_precontratado _pc_precontratado);
        public abstract DataSet DetalleRestriccion(cls_pc_precontratado _pc_precontratado);
        public abstract DataSet DetalleContratados(cls_pc_precontratado _pc_precontratado);
        #endregion

        #region _PC_FRECUENCIA
        public abstract DataSet Adicionar__pc_frecuencia(cls_pc_frecuencia _pc_frecuencia);
		public abstract DataSet Actualizar__pc_frecuencia(cls_pc_frecuencia _pc_frecuencia);
		public abstract bool Eliminar__pc_frecuencia(cls_pc_frecuencia _pc_frecuencia);
		public abstract bool ObtenerId__pc_frecuencia(cls_pc_frecuencia _pc_frecuencia);
		public abstract bool ObtenerRegistro__pc_frecuencia(cls_pc_frecuencia _pc_frecuencia);
		public abstract DataSet ObtenerTablaGrilla__pc_frecuencia(string fr_id, 
						string fr_pr_id, 
						string fr_es_id, 
						string fr_tiempo, 
						string fr_cp_id, 
						string fr_fecha_creacion, 
						string fr_fecha_modificacion, 
						string fr_estado, 
						string fr_descrip_puesto, 
						string fr_cod_poa, 
						string fr_fecha_inicio, 
						string fr_fecha_fin, 
						string fr_id_anterior, 
						string fr_tiempooriginal, 
						string fr_tipo_jornada, 
						string fr_obj_puesto, 
						string fr_observaciones);
		public abstract DataSet ObtenerTablaCombo__pc_frecuencia();
		public abstract DataSet ObtenerEscalafonNS(cls_pc_frecuencia _pc_frecuencia);
		public abstract DataSet ObtenerFiltradoGestion();
		public abstract DataSet BuscarCategorias(cls_pc_frecuencia _pc_frecuencia);
		public abstract DataSet ListarrCategorias(cls_pc_frecuencia _pc_frecuencia);
		public abstract DataSet ListarOperaciones(cls_pc_frecuencia _pc_frecuencia);
		public abstract DataSet ActualizarFrecuencia(cls_pc_frecuencia _pc_frecuencia);
		public abstract DataSet EliminarFrecuencia(cls_pc_frecuencia _pc_frecuencia);
		public abstract DataSet VerEstadoCategoria(cls_pc_frecuencia _pc_frecuencia);
		public abstract DataSet ObtenerFrecuenciasCategorias(cls_pc_frecuencia _pc_frecuencia);
		public abstract DataSet ObtenerFrecuenciasOperacion(cls_pc_frecuencia _pc_frecuencia);
		public abstract DataSet ObtenerResumenFrecuenciasCategorias(cls_pc_frecuencia _pc_frecuencia);
		public abstract DataSet ObtenerResumenFrecuenciasCategoriasF(cls_pc_frecuencia _pc_frecuencia);
		public abstract DataSet ObtenerResumenFrecuenciasOperacion(cls_pc_frecuencia _pc_frecuencia);
		public abstract DataSet ObtenerResumenPresup(cls_pc_frecuencia _pc_frecuencia);
		public abstract DataSet ObtenerInformacionCategoria(cls_pc_frecuencia _pc_frecuencia);
		public abstract DataSet ObtenerHaberBasico(cls_pc_frecuencia _pc_frecuencia);
		public abstract DataSet ObtenerListaFiltradoPuesto(cls_pc_frecuencia _pc_frecuencia);
		public abstract DataSet ObtenerTiempoMeses(cls_pc_frecuencia _pc_frecuencia);
		public abstract DataSet ObtenerFrecuenciaX(cls_pc_frecuencia _pc_frecuencia);
		public abstract DataSet ObtenerCategorias(cls_pc_frecuencia _pc_frecuencia);
		public abstract DataSet ObtenerFrecuenciasLibres(cls_pc_frecuencia _pc_frecuencia);
		public abstract DataSet ObtenerFrecuenciasLibresX(cls_pc_frecuencia _pc_frecuencia);
		public abstract DataSet ObtenerListaFiltradoFrec(cls_pc_frecuencia _pc_frecuencia, string q = "");
		public abstract DataSet ObtenerListaFiltradoFrecuencia(cls_pc_frecuencia _pc_frecuencia, string q = "");
		public abstract DataSet ObtenerListaFiltradoFrecuenciaOperacion(cls_pc_frecuencia _pc_frecuencia, string q = "");
        public abstract DataSet ObtenerFrecuenciasLibresES(cls_pc_frecuencia _pc_frecuencia);
        public abstract DataSet ObtenerFrecuenciaOcupadoX(cls_pc_frecuencia _pc_frecuencia); 
        public abstract DataSet ObtenerFrecuenciaOcupadoX2(cls_pc_frecuencia _pc_frecuencia); 
        public abstract DataSet ObtenerDetalleReplicaX(cls_pc_frecuencia _pc_frecuencia); 
        public abstract DataSet ObtenerTiempoUso(cls_pc_frecuencia _pc_frecuencia); 
        public abstract DataSet ObtenerUsuarios(cls_pc_frecuencia _pc_frecuencia); 
        public abstract DataSet ObtenerRemitente(cls_pc_frecuencia _pc_frecuencia); 
        public abstract DataSet ObtenerListaFiltradoTipoItem(cls_pc_frecuencia _pc_frecuencia); 
        public abstract DataSet ObtenerCategoriasPresup(cls_pc_frecuencia _pc_frecuencia); 
        public abstract DataSet ObtenerCategoriasUE(cls_pc_frecuencia _pc_frecuencia); 
        public abstract DataSet ObtenerComprometidoOperacion(cls_pc_frecuencia _pc_frecuencia); 
        public abstract DataSet ObtenerComprometidoPorOperacion(cls_pc_frecuencia _pc_frecuencia); 
        public abstract DataSet ObtenerPresupuestoUE(cls_pc_frecuencia _pc_frecuencia); 
        public abstract DataSet ObtenerPermisosUE(cls_pc_frecuencia _pc_frecuencia); 
        public abstract DataSet ObtenerResumenGral(cls_pc_frecuencia _pc_frecuencia);
        public abstract bool ActualizarOperacion(cls_pc_frecuencia _pc_frecuencia);
        public abstract DataSet ObtenerSaldoCategoria(cls_pc_frecuencia _pc_frecuencia);
        #endregion

        #region _SP_PRECONTRATATCIONES_CS

        /// <summary>
        /// Verifica el estado de una persona (E1)
        /// </summary>
        public abstract DataSet VerificarEstadoPersona__precontrataciones_cs(cls_precontrataciones_cs obj);

        /// <summary>
        /// Crea un nuevo contrato (A2) y devuelve el AS_ID
        /// </summary>
        public abstract int CrearContrato__precontrataciones_cs(cls_precontrataciones_cs obj);

        /// <summary>
        /// Obtiene lista de contratos (PC1)
        /// </summary>
        public abstract DataSet ObtenerListaContratos__precontrataciones_cs(int us_id);

        /// <summary>
        /// Obtiene lista de escalas salariales (PC2)
        /// </summary>
        public abstract DataSet ObtenerEscalasSalariales__precontrataciones_cs();

        /// <summary>
        /// Obtiene los datos del contrato de una persona (C3)
        /// </summary>
        /// <param name="per_id">ID de la persona</param>
        /// <returns>DataSet con los datos del contrato</returns>
        public abstract DataSet ObtenerContratoPorPersona__precontrataciones_cs(int per_id);

        /// <summary>
        /// Da de baja una asignación (U1) - Para Modificación de Contrato
        /// </summary>
        /// <param name="obj">Objeto con los datos de la asignación a dar de baja</param>
        /// <returns>True si fue exitoso, False si no</returns>
        public abstract bool ActualizarBajaAsignacion__precontrataciones_cs(cls_precontrataciones_cs obj);

        #endregion
    }
}


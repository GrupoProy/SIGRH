using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_Precontratacion.DataAccessLayer;

namespace Solution_Framework_Precontratacion.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_pc_precontratado.
	/// </summary>
	public class cls_pc_precontratado
	{
		#region PROPIEDADES
		public int pre_id { get; set; }
		public int pre_per_id { get; set; }
        public string pre_ci { get; set; }
        public string pre_paterno { get; set; }
        public string pre_materno { get; set; }
        public string pre_nombres { get; set; }
        public string pre_ap_casada { get; set; }
        public string pre_fecha_inicio { get; set; }
        public string pre_fecha_fin { get; set; }
        public decimal pre_tiempo { get; set; }
        public bool pre_val_aceptado_RRHH { get; set; }
        public int pre_pl_id { get; set; }
        public int pre_fr_id { get; set; }
        public int pre_pu_id { get; set; }
        public int pre_presenta_djbr { get; set; }
        public int pre_cod_carpeta { get; set; }
        public string pre_afp { get; set; }
        public string pre_obj_puesto { get; set; }
        public string pre_tareas { get; set; }
        public int pre_numero_item { get; set; }
        public string pre_estado { get; set; }
        public string pre_estado_x { get; set; }

        public string pl_id { get; set; }
        public string pl_pr_id { get; set; }
        public string pl_observaciones { get; set; }
        public string pl_estado { get; set; }
        public string pl_estado_x { get; set; }
        public string pl_correlativo { get; set; }
        public int pl_ue { get; set; }

        public int seg_pk_id { get; set; }
        public int seg_us_id_remitente { get; set; }
        public int seg_us_id_recepcion { get; set; }
        public string seg_accion { get; set; }
        public string seg_observaciones { get; set; }
        public string seg_tabla { get; set; }

        public int tmp_id { get; set; }
        public string tmp_ci { get; set; }
        public string tmp_ap_paterno { get; set; }
        public string tmp_ap_materno { get; set; }
        public string tmp_nombres { get; set; }
        public string tmp_ap_casada { get; set; }
        public int tmp_mostrar_materno { get; set; }
        public string tmp_sexo { get; set; }
        public string tmp_afp { get; set; }
        public string tmp_estado { get; set; }

        public int usuario_per_id { get; set; }
        public int pr_id { get; set; }
        public string param { get; set; }
        public string accion { get; set; }
        public int es_id { get; set; }
        public int cp_id { get; set; }
        public string ti_item { get; set; }
        public int us_id { get; set; }
        public int pl_mes { get; set; }
        public string pre_fecha_sipasse { get; set; }
        public string pre_fecha_djbr { get; set; }

        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_pc_precontratado
        /// </summary>
        public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__pc_precontratado(this);
		}
        public bool AdicionarSeguimiento()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarSeguimiento(this);
        }

        /// <summary>
        /// Método que actualiza datos en la tabla tbl_pc_precontratado
        /// </summary>
        public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__pc_precontratado(this);
		}
        public bool ActualizarFecha()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarFecha(this);
        }
        /// <summary>
        /// Método que elimina datos en la tabla tbl_pc_precontratado
        /// </summary>
        public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__pc_precontratado(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_pc_precontratado
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__pc_precontratado(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_pc_precontratado
		/// </summary>
		/// <param name="pre_id">
		/// Clave primaria de la tabla _pc_precontratado
		/// </param>

		public bool ObtenerRegistro(int pre_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__pc_precontratado(this);
		}
        public DataSet ObtenerRegistroTipoItem()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerRegistroTipoItem(this);
        }
        /// <summary>
        /// Método que obtiene la tabla tbl_pc_precontratado para llenar una grilla
        /// </summary>
        /// <param name="pre_id">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pre_paterno">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pre_materno">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pre_nombres">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pre_ap_casada">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pre_fecha_inicio">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pre_fecha_fin">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pre_tiempo">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pre_val_aceptado_RRHH">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pre_pl_id">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pre_fr_id">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pre_pu_id">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pre_as_id">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pre_presenta_djbr">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pre_cod_carpeta">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pre_afp">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pre_obj_puesto">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pre_tareas">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pre_numero_item">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="pre_estado">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>

        public DataSet ObtenerTablaGrilla(string pre_id, 
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
						string pre_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__pc_precontratado(pre_id, pre_paterno, pre_materno, pre_nombres, pre_ap_casada, pre_fecha_inicio, pre_fecha_fin, pre_tiempo, pre_val_aceptado_RRHH, pre_pl_id, pre_fr_id, pre_pu_id, pre_as_id, pre_presenta_djbr, pre_cod_carpeta, pre_afp, pre_obj_puesto, pre_tareas, pre_numero_item, pre_estado);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_pc_precontratado para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__pc_precontratado();
		}
        public DataSet ListarPlanillas()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarPlanillas(this);
        }
        public DataSet DetallePlanilla()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.DetallePlanilla(this);
        }
        public DataSet ListarUE()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarUE(this);
        }
        public DataSet AdicionarPlanilla()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarPlanilla(this);
        }
        public DataSet EliminarPlanilla()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarPlanilla(this);
        }
        public DataSet AdicionarPreContratadoPuesto()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarPreContratadoPuesto(this);
        }
        public DataSet ListarPrecontratos ()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarPrecontratos(this);
        }
        public DataSet DetallePrecontrato()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.DetallePrecontrato(this);
        }
        public DataSet DatosDetallePrecontrato()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.DatosDetallePrecontrato(this);
        }
        public DataSet BuscarFuncionario ()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.BuscarFuncionario(this);
        }
        public DataSet ObtenerGestion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGestion(this);
        }
        public DataSet ObtenerContrato()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerContrato(this);
        }
        public DataSet ObtenerContratoEditar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerContratoEditar(this);
        }
        public DataSet ObtenerUltimaFrec()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerUltimaFrec(this);
        }
        public DataSet ObtenerUltimaFrecEditar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerUltimaFrecEditar(this);
        }
        public DataSet ObtenerPrecontrato()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerPrecontrato(this);
        }
        public DataSet ObtenerPrecontratoEditar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerPrecontratoEditar(this);
        }
        public DataSet AsignarPersona()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AsignarPersona(this);
        }
        public DataSet ModificarPersona()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ModificarPersona(this);
        }
        public DataSet AsignarPersonaNueva()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AsignarPersonaNueva(this);
        }
        public DataSet ActualizarPersonaNueva()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarPersonaNueva(this);
        }
        public DataSet ListarUsuarios()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarUsuarios(this);
        }
        public DataSet ActualizarEstadoPlanilla()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarEstadoPlanilla(this);
        }
        public DataSet ActualizarEstadoPlanillaUDEP()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarEstadoPlanillaUDEP(this);
        }
        public bool ActualizarEstadoPrecontrato()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarEstadoPrecontrato(this);
        }
        public bool ActualizarEstadoPrecontratoEnvio()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarEstadoPrecontratoEnvio(this);
        }
        public bool EliminarAsignacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarAsignacion(this);
        }
        public bool EliminarAsignacionNuevo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarAsignacionNuevo(this);
        }
        public bool ActualizarPuesto()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarPuesto(this);
        }
        public bool ActualizarPuestoDJBR()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarPuestoDJBR(this);
        }
        public DataSet DatosPuestoX()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.DatosPuestoX(this);
        }
        public DataSet ObtenerNroItem()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerNroItem(this);
        }
        public DataSet ObtenerListaFiltradoPlanilla(string q)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerListaFiltradoPlanilla(this, q);
        }
        public DataSet ListarPlanillasAprobar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarPlanillasAprobar(this);
        }
        public DataSet ObtenerEstadoPlanilla()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerEstadoPlanilla(this);
        }
        public DataSet ObtenerValidacionFechas()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerValidacionFechas(this);
        }
        public DataSet ObtenerCambiarEstadoPlanilla()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerCambiarEstadoPlanilla(this);
        }
        public DataSet ListarAnulados()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarAnulados(this);
        }
        public DataSet ListarPlanillasValidar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarPlanillasValidar(this);
        }

        public DataSet ObtenerCambiarFechas()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerCambiarFechas(this);
        }
        public DataSet ListarPlanillasUDEP()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarPlanillasUDEP(this);
        }
        public DataSet DatosPrecontratoUDEP()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.DatosPrecontratoUDEP(this);
        }
        public bool PrecontratoEstadoUDEP()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.PrecontratoEstadoUDEP(this);
        }
        public DataSet ListarPlanillasObservadas()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarPlanillasObservadas(this);
        }
        public DataSet ListarPlanillasBusqueda()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarPlanillasBusqueda(this);
        }
        public DataSet StockCargosUE()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.StockCargosUE(this);
        }
        public DataSet DetalleCargo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.DetalleCargo(this);
        }
        public DataSet DetallePreFuncionario()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.DetallePreFuncionario(this);
        }
        public DataSet ObtenerDescendencia()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDescendencia(this);
        }
        public DataSet ListarPrecontratosValidados()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarPrecontratosValidados(this);
        }
        public DataSet DetallePreFuncionarioNuevo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.DetallePreFuncionarioNuevo(this);
        }
        public DataSet EliminarPreFuncionarioNuevo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarPreFuncionarioNuevo(this);
        }
        public DataSet ObtenerResumenPlanilla()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerResumenPlanilla(this);
        }
        public DataSet ActualizarDatosPersonaUDEP()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarDatosPersonaUDEP(this);
        }
        public DataSet DetalleRestriccion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.DetalleRestriccion(this);
        }
        public DataSet DetalleContratados()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.DetalleContratados(this);
        }
        #endregion
    }
}

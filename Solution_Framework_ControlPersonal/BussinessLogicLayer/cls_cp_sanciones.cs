using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_ControlPersonal.BussinessLogicLayer;

namespace Solution_Framework_ControlPersonal.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_cp_sanciones.
	/// </summary>
	public class cls_cp_sanciones
	{
		#region PROPIEDADES
		public int sa_id { get; set; }
		public int sa_per_id { get; set; }
        public int sa_factor { get; set; }
        public int sa_minutos { get; set; }
        public DateTime sa_fecha_inicio { get; set; }
        public DateTime sa_fecha_fin { get; set; }
        public string sa_tipo_sancion { get; set; }
        public double sa_dias_sancion { get; set; }
        public string sa_estado { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_cp_sanciones
        /// </summary>
        public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__cp_sanciones(this);
		}
		public bool Adicionar__cp_sanciones_faltasDocentes()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__cp_sanciones_faltasDocentes(this);
		}
		/// <summary>
		/// Método que actualiza datos en la tabla tbl_cp_sanciones
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__cp_sanciones(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_cp_sanciones
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__cp_sanciones(this);
		}

        /// <summary>
        /// Método que obtiene ID para registros de tbl_cp_sanciones
        /// </summary>
        public bool ObtenerId()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerId__cp_sanciones(this);
        }

        /// <summary>
        /// Método que obtiene un registro de tbl_cp_sanciones
        /// </summary>
        /// <param name="sa_id">
        /// Clave primaria de la tabla _cp_sanciones
        /// </param>

        public DataSet ObtenerRegistro(int _sa_id)
		{
			sa_id = _sa_id;
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__cp_sanciones(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_cp_sanciones para llenar una grilla
		/// </summary>
		/// <param name="sa_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="sa_per_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="sa_factor">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="sa_minutos">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="sa_fecha_inicio">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="sa_fecha_fin">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="sa_tipo_sancion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="sa_dias_sancion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="sa_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		public DataSet ObtenerTablaGrilla(
            string p_sa_id, 
			string p_sa_per_id, 
			string p_sa_factor, 
			string p_sa_minutos, 
			string p_sa_fecha_inicio, 
			string p_sa_fecha_fin, 
			string p_sa_tipo_sancion, 
			string p_sa_dias_sancion, 
            string p_sa_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__cp_sanciones(p_sa_id, p_sa_per_id, p_sa_factor, p_sa_minutos, p_sa_fecha_inicio, p_sa_fecha_fin, p_sa_tipo_sancion, p_sa_dias_sancion, p_sa_estado);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_cp_sanciones para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__cp_sanciones();
		}

        // (KCPB)
        public DataSet ObtenerTablaGrillaC(
            //string p_cp_da,
            //string p_cp_ue,
            //string p_cp_programa,
            //string p_cp_proyecto,
            //string p_cp_actividad,
            string p_sa_per_id,
            string p_per_num_doc,
            string p_per_ap_paterno,
            string p_per_ap_materno,
            string p_per_nombres,
            string p_ps_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            //return DBLayer.ObtenerTablaGrillaC__cp_sanciones(p_cp_da, p_cp_ue, p_cp_programa, p_cp_proyecto, p_cp_actividad, p_ps_id);
            return DBLayer.ObtenerTablaGrillaC__cp_sanciones(p_sa_per_id, p_per_num_doc, p_per_ap_paterno, p_per_ap_materno, p_per_nombres, p_ps_id);
        }

        // (KCPB)
        public DataSet ObtenerRegistroDS(int _sa_minutos)
        {
            sa_minutos = _sa_minutos;
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerRegistroDS__cp_sanciones(this);
        }
		public bool ActualizarRegistroSanciones(cls_cp_sanciones _cp_sanciones)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ActualizarRegistroSanciones(this);
		}
		public  DataSet ListarAsignacionesParaSancion(int per_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ListarAsignacionesParaSancion(per_id);
		}
		public  DataSet ListarMesesParaSancion()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ListarMesesParaSancion();
		}
		public  int UpdateFaltas(int per_id, String fecha_ini, String fecha_fin)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.UpdateFaltas(per_id, fecha_ini, fecha_fin);
		}
		#endregion
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_ControlPersonal.DataAccessLayer;

namespace Solution_Framework_ControlPersonal.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_cp_sanciones_rel_cierre.
	/// </summary>
	public class cls_cp_sanciones_rel_cierre
	{
		#region PROPIEDADES
		public int src_sa_id { get; set; }
		public int src_cp_id { get; set; }
        public int src_cm_id { get; set; }
        public DateTime src_fecha_ejecucion { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_cp_sanciones_rel_cierre
        /// </summary>
        public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__cp_sanciones_rel_cierre(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_cp_sanciones_rel_cierre
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__cp_sanciones_rel_cierre(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_cp_sanciones_rel_cierre
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__cp_sanciones_rel_cierre(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_cp_sanciones_rel_cierre
		/// </summary>
		/// <param name="src_sa_id">
		/// Clave primaria de la tabla _cp_sanciones_rel_cierre
		/// </param>
		public DataSet ObtenerRegistro(int p_src_sa_id)
		{
			src_sa_id = p_src_sa_id;
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__cp_sanciones_rel_cierre(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_cp_sanciones_rel_cierre para llenar una grilla
		/// </summary>
		/// <param name="src_sa_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="src_cp_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="src_cm_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="src_fecha_ejecucion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		public DataSet ObtenerTablaGrilla(
            string p_src_sa_id, 
			string p_src_cp_id, 
			string p_src_cm_id, 
			string p_src_fecha_ejecucion)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__cp_sanciones_rel_cierre(p_src_sa_id, p_src_cp_id, p_src_cm_id, p_src_fecha_ejecucion);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_cp_sanciones_rel_cierre para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__cp_sanciones_rel_cierre();
		}
		#endregion
	}
}

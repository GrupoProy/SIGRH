using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_General.DataAccessLayer;

namespace Solution_Framework_General.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_pla_proceso.
	/// </summary>
	public class cls_pla_proceso
	{
		#region PROPIEDADES
		public int pc_id { get; set; }
		public int pc_pr_id { get; set; }
        public string pc_titulo { get; set; }
        public DateTime pc_fecha_inicio { get; set; }
        public DateTime pc_fecha_fin { get; set; }
        public int pc_mn_id { get; set; }
        public double pc_ufv { get; set; }
        public DateTime pc_ufv_fecha { get; set; }
        public string pc_estado { get; set; }
        public string pc_prefijo { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_pla_proceso
        /// </summary>
        public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__pla_proceso(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_pla_proceso
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__pla_proceso(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_pla_proceso
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__pla_proceso(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_pla_proceso
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__pla_proceso(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_pla_proceso
		/// </summary>
		/// <param name="pc_id">
		/// Clave primaria de la tabla _pla_proceso
		/// </param>

		public DataSet ObtenerRegistro(int p_pc_id)
		{
			pc_id = p_pc_id;
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__pla_proceso(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_pla_proceso para llenar una grilla
		/// </summary>
		/// <param name="pc_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pc_pr_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pc_titulo">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pc_fecha_inicio">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pc_fecha_fin">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pc_mn_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pc_ufv">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pc_ufv_fecha">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pc_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pc_prefijo">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		public DataSet ObtenerTablaGrilla(
            string p_pc_id, 
			string p_pc_pr_id, 
			string p_pc_titulo, 
			string p_pc_fecha_inicio, 
			string p_pc_fecha_fin, 
			string p_pc_mn_id, 
			string p_pc_ufv, 
			string p_pc_ufv_fecha, 
			string p_pc_estado, 
			string p_pc_prefijo)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__pla_proceso(p_pc_id, p_pc_pr_id, p_pc_titulo, p_pc_fecha_inicio, p_pc_fecha_fin, p_pc_mn_id, p_pc_ufv, p_pc_ufv_fecha, p_pc_estado, p_pc_prefijo);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_pla_proceso para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__pla_proceso();
		}
		#endregion
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_ControlPersonal.DataAccessLayer;

namespace Solution_Framework_ControlPersonal.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_cp_cierre_mensual.
	/// </summary>
	public class cls_cp_cierre_mensual
	{
		#region PROPIEDADES
		public int cm_id { get; set; }
		public DateTime cm_fecha_inicio { get; set; }
        public DateTime cm_fecha_final { get; set; }
        public string cm_estado { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_cp_cierre_mensual
        /// </summary>
        public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__cp_cierre_mensual(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_cp_cierre_mensual
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__cp_cierre_mensual(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_cp_cierre_mensual
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__cp_cierre_mensual(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_cp_cierre_mensual
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__cp_cierre_mensual(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_cp_cierre_mensual
		/// </summary>
		/// <param name="cm_id">
		/// Clave primaria de la tabla _cp_cierre_mensual
		/// </param>
		public DataSet ObtenerRegistro(int p_cm_id)
		{
			cm_id = p_cm_id;
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__cp_cierre_mensual(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_cp_cierre_mensual para llenar una grilla
		/// </summary>
		/// <param name="cm_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cm_fecha_inicio">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cm_fecha_final">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cm_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		public DataSet ObtenerTablaGrilla(
            string cm_id, 
			string cm_fecha_inicio, 
			string cm_fecha_final, 
			string cm_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__cp_cierre_mensual(cm_id, cm_fecha_inicio, cm_fecha_final, cm_estado);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_cp_cierre_mensual para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__cp_cierre_mensual();
		}
		#endregion
	}
}

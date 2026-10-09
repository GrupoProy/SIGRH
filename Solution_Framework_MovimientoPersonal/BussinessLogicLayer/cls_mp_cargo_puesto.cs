using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_MovimientoPersonal.DataAccessLayer;

namespace Solution_Framework_MovimientoPersonal.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_mp_cargo_puesto.
	/// </summary>
	public class cls_mp_cargo_puesto
	{
		#region PROPIEDADES
		public int cap_ca_id { get; set; }
        public int cap_p_id { get; set; }
        public string cap_estado { get; set; }
        public DateTime cap_fecha_modificacion { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_mp_cargo_puesto
        /// </summary>
        public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__mp_cargo_puesto(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_mp_cargo_puesto
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__mp_cargo_puesto(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_mp_cargo_puesto
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__mp_cargo_puesto(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_mp_cargo_puesto
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__mp_cargo_puesto(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_mp_cargo_puesto
		/// </summary>
		/// <param name="cap_ca_id">
		/// Clave primaria de la tabla _mp_cargo_puesto
		/// </param>
		public DataSet ObtenerRegistro(int p_cap_ca_id)
		{
			cap_ca_id = p_cap_ca_id;
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__mp_cargo_puesto(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_mp_cargo_puesto para llenar una grilla
		/// </summary>
		/// <param name="cap_ca_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cap_p_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cap_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cap_fecha_modificacion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		public DataSet ObtenerTablaGrilla(
            string p_cap_ca_id, 
			string p_cap_p_id, 
			string p_cap_estado, 
			string p_cap_fecha_modificacion)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__mp_cargo_puesto(p_cap_ca_id, p_cap_p_id, p_cap_estado, p_cap_fecha_modificacion);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_mp_cargo_puesto para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__mp_cargo_puesto();
		}
		#endregion
	}
}

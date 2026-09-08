using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_BienestarSocial.DataAccessLayer;

namespace Solution_Framework_BienestarSocial.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_bs_enfermedades_recurrentes.
	/// </summary>
	public class cls_bs_enfermedades_recurrentes
	{

		#region PROPIEDADES
		public int enfrec_id { get; set; }
        public int enfrec_exp_id { get; set; }
        public int enfrec_pat_id { get; set; }
        public int enfrec_esp_id { get; set; }
		public string enfrec_estado { get; set; }
		#endregion

		#region METODOS
		/// <summary>
		/// Método que adiciona una nuevo registro en tbl_bs_enfermedades_recurrentes
		/// </summary>
		public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__bs_enfermedades_recurrentes(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_bs_enfermedades_recurrentes
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__bs_enfermedades_recurrentes(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_bs_enfermedades_recurrentes
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__bs_enfermedades_recurrentes(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_bs_enfermedades_recurrentes
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__bs_enfermedades_recurrentes(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_bs_enfermedades_recurrentes
		/// </summary>
		/// <param name="enfrec_id">
		/// Clave primaria de la tabla _bs_enfermedades_recurrentes
		/// </param>

		public bool ObtenerRegistro(int enfrec_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__bs_enfermedades_recurrentes(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_bs_enfermedades_recurrentes para llenar una grilla
		/// </summary>
		/// <param name="enfrec_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="enfrec_exp_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="enfrec_enf_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="enfrec_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>

		public DataSet ObtenerTablaGrilla()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__bs_enfermedades_recurrentes(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_bs_enfermedades_recurrentes para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__bs_enfermedades_recurrentes();
		}
		#endregion
	}
}

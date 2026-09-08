using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_Salarios.DataAccessLayer;

namespace Solution_Framework_Salarios.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_pla_transacciones_acreedor.
	/// </summary>
	public class cls_pla_transacciones_acreedor
	{
		#region PROPIEDADES
		public int tra_acr_id { get; set; }
		public int tra_tr_id { get; set; }
        public string tra_estado { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_pla_transacciones_acreedor
        /// </summary>
        public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__pla_transacciones_acreedor(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_pla_transacciones_acreedor
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__pla_transacciones_acreedor(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_pla_transacciones_acreedor
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__pla_transacciones_acreedor(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_pla_transacciones_acreedor
		/// </summary>
		/// <param name="tra_acr_id">
		/// Clave primaria de la tabla _pla_transacciones_acreedor
		/// </param>
		public DataSet ObtenerRegistro(int p_tra_acr_id)
		{
			tra_acr_id = p_tra_acr_id;
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__pla_transacciones_acreedor(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_pla_transacciones_acreedor para llenar una grilla
		/// </summary>
		/// <param name="tra_acr_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="tra_tr_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="tra_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		public DataSet ObtenerTablaGrilla(
            string p_tra_acr_id, 
			string p_tra_tr_id, 
			string p_tra_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__pla_transacciones_acreedor(p_tra_acr_id, p_tra_tr_id, p_tra_estado);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_pla_transacciones_acreedor para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__pla_transacciones_acreedor();
		}
		#endregion
	}
}

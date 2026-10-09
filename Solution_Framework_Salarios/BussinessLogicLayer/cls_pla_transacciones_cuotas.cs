using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_Salarios.DataAccessLayer;

namespace Solution_Framework_Salarios.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_pla_transacciones_cuotas.
	/// </summary>
	public class cls_pla_transacciones_cuotas
	{
		#region PROPIEDADES
		public int tc_id { get; set; }
        public int tc_tr_id { get; set; }
        public int tc_cant_cuotas { get; set; }
        public string tc_monto { get; set; }
        public string tc_estado { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_pla_transacciones_cuotas
        /// </summary>
        public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__pla_transacciones_cuotas(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_pla_transacciones_cuotas
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__pla_transacciones_cuotas(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_pla_transacciones_cuotas
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__pla_transacciones_cuotas(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_pla_transacciones_cuotas
		/// </summary>
		/// <param name="tc_id">
		/// Clave primaria de la tabla _pla_transacciones_cuotas
		/// </param>
		public DataSet ObtenerRegistro(int p_tc_id)
		{
			tc_id = p_tc_id;
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__pla_transacciones_cuotas(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_pla_transacciones_cuotas para llenar una grilla
		/// </summary>
		/// <param name="tc_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="tc_tr_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="tc_cant_cuotas">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="tc_monto">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="tc_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		public DataSet ObtenerTablaGrilla(
            string p_tc_id, 
			string p_tc_tr_id, 
			string p_tc_cant_cuotas, 
			string p_tc_monto, 
			string p_tc_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__pla_transacciones_cuotas(p_tc_id, p_tc_tr_id, p_tc_cant_cuotas, p_tc_monto, p_tc_estado);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_pla_transacciones_cuotas para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__pla_transacciones_cuotas();
		}
		#endregion
	}
}

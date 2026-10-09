using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_General.DataAccessLayer;

namespace Solution_Framework_General.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_periodo.
	/// </summary>
	public class cls_periodo
	{
		#region PROPIEDADES
		public int pr_id { get; set; }
		public int pr_gestion { get; set; }
        public int pr_secuencial { get; set; }
        public string pr_estado { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_periodo
        /// </summary>
        public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__periodo(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_periodo
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__periodo(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_periodo
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__periodo(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_periodo
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__periodo(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_periodo
		/// </summary>
		/// <param name="pr_id">
		/// Clave primaria de la tabla _periodo
		/// </param>
		public DataSet ObtenerRegistro(int p_pr_id)
		{
			pr_id = p_pr_id;
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__periodo(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_periodo para llenar una grilla
		/// </summary>
		/// <param name="pr_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pr_gestion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pr_secuencial">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pr_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		public DataSet ObtenerTablaGrilla(
            string p_pr_id, 
			string p_pr_gestion, 
			string p_pr_secuencial, 
			string p_pr_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__periodo(p_pr_id, p_pr_gestion, p_pr_secuencial, p_pr_estado);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_periodo para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__periodo();
		}
		public  DataSet ObtenerPeriodoVigente()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerPeriodoVigente();
		}
		#endregion
	}
}

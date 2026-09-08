using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_MovimientoPersonal.DataAccessLayer;

namespace Solution_Framework_MovimientoPersonal.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_puestos.
	/// </summary>
	public class cls_puestos
	{
		#region PROPIEDADES
		public int p_id { get; set; }
		public string p_descripcion { get; set; }
        public string p_estado { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_puestos
        /// </summary>
        public DataSet Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__puestos(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_puestos
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__puestos(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_puestos
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__puestos(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_puestos
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__puestos(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_puestos
		/// </summary>
		/// <param name="p_id">
		/// Clave primaria de la tabla _puestos
		/// </param>
		public DataSet ObtenerRegistro(int p_p_id)
		{
			p_id = p_p_id;
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__puestos(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_puestos para llenar una grilla
		/// </summary>
		/// <param name="p_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="p_descripcion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="p_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		public DataSet ObtenerTablaGrilla(
            string p_p_id, 
			string p_p_descripcion, 
			string p_p_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__puestos(p_p_id, p_p_descripcion, p_p_estado);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_puestos para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__puestos();
		}
		public  DataSet ObtenerPuestosVigentes()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerPuestosVigentes();
		}

		#endregion
	}

}

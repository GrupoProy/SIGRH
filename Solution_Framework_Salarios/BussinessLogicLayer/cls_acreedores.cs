using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_Salarios.DataAccessLayer;

namespace Solution_Framework_Salarios.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_acreedores.
	/// </summary>
	public class cls_acreedores
	{
		#region PROPIEDADES
		public int ac_id { get; set; }
        public int ac_per_id { get; set; }
        public string ac_descripcion { get; set; }
        public int ac_tipo { get; set; }
        public string ac_documento { get; set; }
        public string ac_estado { get; set; }
        public string ac_usuario_creacion { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_acreedores
        /// </summary>
        public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__acreedores(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_acreedores
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__acreedores(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_acreedores
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__acreedores(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_acreedores
		/// </summary>
		/// <param name="ac_id">
		/// Clave primaria de la tabla _acreedores
		/// </param>
		public DataSet ObtenerRegistro(int p_ac_id)
		{
			ac_id = p_ac_id;
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__acreedores(this);
		}

        /// <summary>
        /// Método que obtiene la tabla tbl_acreedores para llenar una grilla
        /// </summary>
        /// <param name="ac_id">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ac_per_id">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ac_descripcion">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ac_tipo">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ac_documento">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ac_estado">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        public DataSet ObtenerTablaGrilla(
            string p_ac_id,
            string p_ac_per_id,
			string p_ac_descripcion, 
			string p_ac_tipo, 
			string p_ac_documento, 
			string p_ac_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__acreedores(p_ac_id, p_ac_per_id, p_ac_descripcion, p_ac_tipo, p_ac_documento, p_ac_estado);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_acreedores para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__acreedores();
		}
		#endregion
	}
}

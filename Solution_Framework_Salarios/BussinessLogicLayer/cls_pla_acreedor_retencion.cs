using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_Salarios.DataAccessLayer;

namespace Solution_Framework_Salarios.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_pla_acreedor_retencion.
	/// </summary>
	public class cls_pla_acreedor_retencion
	{
		#region PROPIEDADES
		public int acr_id { get; set; }
		public string acr_tipo_entidad { get; set; }
        public string acr_descripcion { get; set; }
        public string acr_documento { get; set; }
        public string acr_estado { get; set; }
        // (KCPB)
        public int acr_per_id { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_pla_acreedor_retencion
        /// </summary>
        public int Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__pla_acreedor_retencion(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_pla_acreedor_retencion
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__pla_acreedor_retencion(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_pla_acreedor_retencion
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__pla_acreedor_retencion(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_pla_acreedor_retencion
		/// </summary>
		/// <param name="acr_id">
		/// Clave primaria de la tabla _pla_acreedor_retencion
		/// </param>
		public DataSet ObtenerRegistro(int p_acr_id)
		{
			acr_id = p_acr_id;
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__pla_acreedor_retencion(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_pla_acreedor_retencion para llenar una grilla
		/// </summary>
		/// <param name="acr_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="acr_tipo_entidad">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="acr_descripcion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="acr_documento">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="acr_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		public DataSet ObtenerTablaGrilla(
            string p_acr_id, 
			string p_acr_tipo_entidad,  
			string p_acr_descripcion, 
			string p_acr_documento, 
			string p_acr_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__pla_acreedor_retencion(p_acr_id, p_acr_tipo_entidad, p_acr_descripcion, p_acr_documento, p_acr_estado);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_pla_acreedor_retencion para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__pla_acreedor_retencion();
		}

        // (KCPB) 
        public DataSet ObtenerTablaGrillaF(string p_acr_per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrillaF__pla_acreedor_retencion(p_acr_per_id);
        }
		#endregion
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_Seguridad.DataAccessLayer;

namespace Solution_Framework_Seguridad.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_seg_rol_menu.
	/// </summary>
	public class cls_seg_rol_menu
	{
		#region PROPIEDADES
		public int rolme_id { get; set; }
		public int rolme_rol_id { get; set; }
		public int rolme_me_id { get; set; }
        public string rolme_estado { get; set; }
        public DateTime rolme_fecha_creacion { get; set; }
        public string rolme_usuario_creacion { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_seg_rol_menu
        /// </summary>
        public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__seg_rol_menu(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_seg_rol_menu
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__seg_rol_menu(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_seg_rol_menu
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__seg_rol_menu(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_seg_rol_menu
		/// </summary>
		/// <param name="rolme_id">
		/// Clave primaria de la tabla _seg_rol_menu
		/// </param>
		public DataSet ObtenerRegistro(int p_rolme_id)
		{
			rolme_id = p_rolme_id;
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__seg_rol_menu(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_seg_rol_menu para llenar una grilla
		/// </summary>
		/// <param name="rolme_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="rolme_rol_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="rolme_me_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		public DataSet ObtenerTablaGrilla(
            string p_rolme_id, 
			string p_rolme_rol_id, 
			string p_rolme_me_id,
            string p_rolme_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__seg_rol_menu(p_rolme_id, p_rolme_rol_id, p_rolme_me_id, p_rolme_estado);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_seg_rol_menu para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__seg_rol_menu();
		}
        #endregion
    }
}

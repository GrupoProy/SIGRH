using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_Seguridad.DataAccessLayer;

namespace Solution_Framework_Seguridad.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_seg_menu_usuario.
	/// </summary>
	public class cls_seg_menu_usuario
	{
		#region PROPIEDADES
		public int meus_id { get; set; }
        public int meus_me_id { get; set; }
        public int meus_us_id { get; set; }
        public string meus_estado { get; set; }
        public DateTime meus_fecha_creacion { get; set; }
        public int meus_usuario_creacion { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_seg_menu_usuario
        /// </summary>
        public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__seg_menu_usuario(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_seg_menu_usuario
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__seg_menu_usuario(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_seg_menu_usuario
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__seg_menu_usuario(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_seg_menu_usuario
		/// </summary>
		/// <param name="meus_id">
		/// Clave primaria de la tabla _seg_menu_usuario
		/// </param>
		public DataSet ObtenerRegistro(int p_meus_id)
		{
			meus_id = p_meus_id;
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__seg_menu_usuario(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_seg_menu_usuario para llenar una grilla
		/// </summary>
		/// <param name="meus_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="meus_me_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="meus_us_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="meus_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="meus_fecha_creacion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="meus_usuario_creacion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		public DataSet ObtenerTablaGrilla(
            string p_meus_id, 
			string p_meus_me_id, 
			string p_meus_us_id, 
			string p_meus_estado, 
			string p_meus_fecha_creacion, 
			string p_meus_usuario_creacion)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__seg_menu_usuario(p_meus_id, p_meus_me_id, p_meus_us_id, p_meus_estado, p_meus_fecha_creacion, p_meus_usuario_creacion);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_seg_menu_usuario para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__seg_menu_usuario();
		}
		#endregion
	}
}

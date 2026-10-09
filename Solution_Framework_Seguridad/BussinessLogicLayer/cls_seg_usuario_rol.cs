using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_Seguridad.DataAccessLayer;

namespace Solution_Framework_Seguridad.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_usuario_rol.
	/// </summary>
	public class cls_seg_usuario_rol
	{
		#region PROPIEDADES
		public int usrol_id { get; set; }
        public int usrol_us_id { get; set; }
        public int usrol_rol_id { get; set; }
        public string usrol_estado { get; set; }
        public DateTime usrol_fecha_creacion { get; set; }
        public string usrol_usuario_creacion { get; set; }
        //auxiliares
        public string rol_descripcion { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_usuario_rol
        /// </summary>
        public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__seg_usuario_rol(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_usuario_rol
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__seg_usuario_rol(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_usuario_rol
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__seg_usuario_rol(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_usuario_rol
		/// </summary>
		/// <param name="usrol_id">
		/// Clave primaria de la tabla _usuario_rol
		/// </param>
		public DataSet ObtenerRegistro(int p_usrol_id)
		{
			usrol_id = p_usrol_id;
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__seg_usuario_rol(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_usuario_rol para llenar una grilla
		/// </summary>
		/// <param name="usrol_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="usrol_us_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="usrol_rol_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="usrol_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="usrol_fecha_creacion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		public DataSet ObtenerTablaGrilla(
            string p_usrol_id, 
			string p_usrol_us_id, 
			string p_usrol_rol_id, 
			string p_usrol_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__seg_usuario_rol(p_usrol_id, p_usrol_us_id, p_usrol_rol_id, p_usrol_estado);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_usuario_rol para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__seg_usuario_rol();
		}

        /// <summary>
		/// Método que obtiene la tabla tbl_usuario_rol para llenar un combo segun un usuario
		/// </summary>
		public DataSet ObtenerTablaUsuarioRol(int p_usrol_us_id)
        {
            usrol_us_id = p_usrol_us_id;
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaUsuarioRol__usuario_rol(this);
        }
        #endregion
    }
}

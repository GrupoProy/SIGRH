using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_Seguridad.DataAccessLayer;

namespace Solution_Framework_Seguridad.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_rol.
	/// </summary>
	public class cls_seg_rol
	{
		#region PROPIEDADES
		public int rol_id { get; set; }
        public string rol_descripcion { get; set; }
        public string rol_estado { get; set; }
        public DateTime rol_fecha_creacion { get; set; }
        public string rol_usuario_creacion { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_rol
        /// </summary>
        public int Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__seg_rol(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_rol
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__seg_rol(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_rol
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__seg_rol(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_rol
		/// </summary>
		/// <param name="rol_id">
		/// Clave primaria de la tabla _rol
		/// </param>
		public DataSet ObtenerRegistro(int p_rol_id)
		{
			rol_id = p_rol_id;
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__seg_rol(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_rol para llenar una grilla
		/// </summary>
		/// <param name="rol_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="rol_descripcion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="rol_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		public DataSet ObtenerTablaGrilla(
            string p_rol_id, 
			string p_rol_descripcion, 
			string p_rol_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__seg_rol(p_rol_id, p_rol_descripcion, p_rol_estado);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_rol para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__seg_rol();
		}
		#endregion
	}
}

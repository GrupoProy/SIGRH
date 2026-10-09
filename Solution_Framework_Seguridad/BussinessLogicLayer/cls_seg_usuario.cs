using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_Seguridad.DataAccessLayer;

namespace Solution_Framework_Seguridad.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_seg_usuario.
	/// </summary>
	public class cls_seg_usuario
	{
		#region PROPIEDADES
		public int us_id { get; set; }
		public string us_usuario { get; set; }
        public string us_contrasena { get; set; }
        public int us_per_id { get; set; }
        public bool us_estado_clave { get; set; }
        public bool us_estado_sesion { get; set; }
        public string us_correo_interno { get; set; }
        public string us_nombre_equipo { get; set; }
        public DateTime us_fecha_inicio { get; set; }
        public DateTime us_fecha_fin { get; set; }
        public int us_id_rol_sim { get; set; }
        public int us_id_usuario_sim { get; set; }
        public string us_estado { get; set; }
        public DateTime us_fecha_creacion { get; set; }
        public string us_usuario_creacion { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_seg_usuario
        /// </summary>
        public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__seg_usuario(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_seg_usuario
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__seg_usuario(this);
		}
		public int ActualizarPass()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ActualizarPass(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_seg_usuario
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__seg_usuario(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_seg_usuario
		/// </summary>
		/// <param name="us_id">
		/// Clave primaria de la tabla _seg_usuario
		/// </param>
		public DataSet ObtenerRegistro(int p_us_id)
		{
			us_id = p_us_id;
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__seg_usuario(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_seg_usuario para llenar una grilla
		/// </summary>
		/// <param name="us_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="us_usuario">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="us_contrasena">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="us_per_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="us_estado_clave">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="us_estado_sesion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="us_correo_interno">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="us_nombre_equipo">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="us_fecha_creacion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="us_fecha_inicio">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="us_fecha_fin">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="us_id_rol_sim">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="us_id_usuario_sim">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="us_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		public DataSet ObtenerTablaGrilla(
            string p_us_id, 
			string p_us_usuario, 
			string p_us_contrasena, 
			string p_us_per_id, 
			string p_us_estado_clave, 
			string p_us_estado_sesion, 
			string p_us_correo_interno, 
			string p_us_nombre_equipo,
			string p_us_fecha_inicio, 
			string p_us_fecha_fin, 
			string p_us_id_rol_sim, 
			string p_us_id_usuario_sim, 
			string p_us_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__seg_usuario(p_us_id, p_us_usuario, p_us_contrasena, p_us_per_id, p_us_estado_clave, p_us_estado_sesion, p_us_correo_interno, p_us_nombre_equipo, p_us_fecha_inicio, p_us_fecha_fin, p_us_id_rol_sim, p_us_id_usuario_sim, p_us_estado);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_seg_usuario para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__seg_usuario();
		}
        public DataSet ObtenerFuncionarioX()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFuncionarioX(this);
        }
        #endregion
    }
}

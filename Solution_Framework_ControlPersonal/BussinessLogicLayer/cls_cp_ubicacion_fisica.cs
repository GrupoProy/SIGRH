using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_ControlPersonal.DataAccessLayer;

namespace Solution_Framework_ControlPersonal.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_cp_ubicacion_fisica.
	/// </summary>
	public class cls_cp_ubicacion_fisica
	{
		#region PROPIEDADES
		public int uf_id { get; set; }
		public int uf_per_id { get; set; }
        public int uf_edificio { get; set; }
        public string uf_piso { get; set; }
        public string uf_bloque { get; set; }
        public int? uf_telefono_interno { get; set; }
        public int? uf_telefono_oficina { get; set; }
        public string uf_nombre_oficina { get; set; }
        public DateTime uf_fecha_inicio { get; set; }
        public DateTime? uf_fecha_final { get; set; }
        public string uf_estado { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_cp_ubicacion_fisica
        /// </summary>
        public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__cp_ubicacion_fisica(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_cp_ubicacion_fisica
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__cp_ubicacion_fisica(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_cp_ubicacion_fisica
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__cp_ubicacion_fisica(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_cp_ubicacion_fisica
		/// </summary>
		/// <param name="uf_id">
		/// Clave primaria de la tabla _cp_ubicacion_fisica
		/// </param>
		public DataSet ObtenerRegistro(int p_uf_id)
		{
			uf_id = p_uf_id;
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__cp_ubicacion_fisica(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_cp_ubicacion_fisica para llenar una grilla
		/// </summary>
		/// <param name="uf_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="uf_per_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="uf_edificio">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="uf_piso">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="uf_bloque">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="uf_telefono_interno">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="uf_telefono_oficina">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="uf_nombre_oficina">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="uf_fecha_inicio">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="uf_fecha_final">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="uf_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		public DataSet ObtenerTablaGrilla(
            string p_uf_id, 
			string p_uf_per_id, 
			string p_uf_edificio, 
			string p_uf_piso, 
			string p_uf_bloque, 
			string p_uf_telefono_interno, 
			string p_uf_telefono_oficina, 
			string p_uf_nombre_oficina, 
			string p_uf_fecha_inicio, 
			string p_uf_fecha_final, 
			string p_uf_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__cp_ubicacion_fisica(p_uf_id, p_uf_per_id, p_uf_edificio, p_uf_piso, p_uf_bloque, p_uf_telefono_interno, p_uf_telefono_oficina, p_uf_nombre_oficina, p_uf_fecha_inicio, p_uf_fecha_final, p_uf_estado);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_cp_ubicacion_fisica para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__cp_ubicacion_fisica();
		}

        // (KCPB) Obtiene todos los registros de la tabla
        public DataSet ObtenerTablaGrillaC(
            string p_uf_id,
            string p_uf_per_id,
            string p_uf_edificio,
            string p_uf_piso,
            string p_uf_bloque,
            string p_uf_telefono_interno,
            string p_uf_telefono_oficina,
            string p_uf_nombre_oficina,
            string p_uf_fecha_inicio,
            string p_uf_fecha_final,
            string p_uf_estado)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrillaC__cp_ubicacion_fisica(p_uf_id, p_uf_per_id, p_uf_edificio, p_uf_piso, p_uf_bloque, p_uf_telefono_interno, p_uf_telefono_oficina, p_uf_nombre_oficina, p_uf_fecha_inicio, p_uf_fecha_final, p_uf_estado);
        }
        #endregion
    }
}

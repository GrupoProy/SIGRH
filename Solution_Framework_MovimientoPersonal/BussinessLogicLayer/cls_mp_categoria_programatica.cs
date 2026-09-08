using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_MovimientoPersonal.DataAccessLayer;

namespace Solution_Framework_MovimientoPersonal.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_mp_categoria_programatica.
	/// </summary>
	public class cls_mp_categoria_programatica
	{
		#region PROPIEDADES
		public int cp_id { get; set; }
		public int cp_da { get; set; }
        public string cp_da_descripcion { get; set; }
        public int cp_ue { get; set; }
        public string cp_ue_descripcion { get; set; }
        public int cp_programa { get; set; }
        public string cp_proyecto { get; set; }
        public int cp_actividad { get; set; }
        public int cp_cod_poa { get; set; }
        public string cp_descripcion { get; set; }
        public string cp_estado { get; set; }
        public string cp_tipo_gasto { get; set; }
        public int cp_fuente { get; set; }
        public int cp_organismo { get; set; }
        public int cp_pr_id { get; set; }
        public DateTime cp_fecha_modificacion { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_mp_categoria_programatica
        /// </summary>
        public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__mp_categoria_programatica(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_mp_categoria_programatica
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__mp_categoria_programatica(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_mp_categoria_programatica
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__mp_categoria_programatica(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_mp_categoria_programatica
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__mp_categoria_programatica(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_mp_categoria_programatica
		/// </summary>
		/// <param name="cp_id">
		/// Clave primaria de la tabla _mp_categoria_programatica
		/// </param>
		public DataSet ObtenerRegistro()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__mp_categoria_programatica(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_mp_categoria_programatica para llenar una grilla
		/// </summary>
		/// <param name="cp_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cp_da">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cp_da_descripcion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cp_ue">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cp_ue_descripcion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cp_programa">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cp_proyecto">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cp_actividad">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cp_cod_poa">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cp_descripcion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cp_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cp_tipo_gasto">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cp_fuente">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cp_organismo">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cp_pr_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cp_fecha_modificacion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		public DataSet ObtenerTablaGrilla(
            string p_cp_id, 
			string p_cp_da, 
			string p_cp_da_descripcion, 
			string p_cp_ue, 
			string p_cp_ue_descripcion, 
			string p_cp_programa, 
			string p_cp_proyecto, 
			string p_cp_actividad, 
			string p_cp_cod_poa, 
			string p_cp_descripcion, 
			string p_cp_estado, 
			string p_cp_tipo_gasto, 
			string p_cp_fuente, 
			string p_cp_organismo, 
			string p_cp_pr_id, 
			string p_cp_fecha_modificacion)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__mp_categoria_programatica(p_cp_id, p_cp_da, p_cp_da_descripcion, p_cp_ue, p_cp_ue_descripcion, p_cp_programa, p_cp_proyecto, p_cp_actividad, p_cp_cod_poa, p_cp_descripcion, p_cp_estado, p_cp_tipo_gasto, p_cp_fuente, p_cp_organismo, p_cp_pr_id, p_cp_fecha_modificacion);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_mp_categoria_programatica para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__mp_categoria_programatica();
		}

        // (KCPB) Listado de UE vigentes
        public DataSet ObtenerTablaComboUE()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaComboUE__mp_categoria_programatica(this);
        }
		public  string ObtenerTipoGasto(int eo_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTipoGasto(eo_id);
		}
		#endregion
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_BienestarSocial.DataAccessLayer;

namespace Solution_Framework_BienestarSocial.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_bs_afp.
	/// </summary>
	public class cls_bs_afp
	{
		#region PROPIEDADES
		public int? afp_id { get; set; }
		public int? afp_per_id { get; set; }
        public string afp_previsora { get; set; }
        public string afp_nua { get; set; }
        public DateTime? afp_fecha_filiacion { get; set; }
        public DateTime? afp_fecha_modificacion { get; set; }
        public string afp_motivo_modificacion { get; set; }
        public DateTime? afp_fecha_registro { get; set; }
        public string afp_estado_carnet { get; set; }
        public DateTime? afp_fecha_carnet { get; set; }
        public int? afp_usuario { get; set; }
        public string afp_estado { get; set; }
        public int as_id { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_bs_afp
        /// </summary>
        public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__bs_afp(this);
		}
        public bool CompletarDatosAFP()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.CompletarDatosAFP(this);
        }
        /// <summary>
        /// Método que actualiza datos en la tabla tbl_bs_afp
        /// </summary>
        public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__bs_afp(this);
		}

        /// <summary>
        /// Método que elimina datos en la tabla tbl_bs_afp
        /// </summary>
        public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__bs_afp(this);
		}
        public bool ActualizarEstadoAFP()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarEstadoAFP(this);
        }
        /// <summary>
        /// Método que obtiene un registro de tbl_bs_afp
        /// </summary>
        /// <param name="afp_id">
        /// Clave primaria de la tabla _bs_afp
        /// </param>
        public DataSet ObtenerRegistro()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__bs_afp(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_bs_afp para llenar una grilla
		/// </summary>
		/// <param name="afp_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="afp_per_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="afp_previsora">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="afp_fecha_filiacion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="afp_fecha_modificacion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="afp_motivo_modificacion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="afp_fecha_registro">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="afp_estado_carnet">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="afp_fecha_carnet">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="afp_usuario">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="afp_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		public DataSet ObtenerTablaGrilla(
            string p_afp_id, 
			string p_afp_per_id, 
			string p_afp_previsora, 
			string p_afp_fecha_filiacion, 
			string p_afp_fecha_modificacion, 
			string p_afp_motivo_modificacion, 
			string p_afp_fecha_registro, 
			string p_afp_estado_carnet, 
			string p_afp_fecha_carnet, 
			string p_afp_usuario, 
			string p_afp_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__bs_afp(p_afp_id, p_afp_per_id, p_afp_previsora, p_afp_fecha_filiacion, p_afp_fecha_modificacion, p_afp_motivo_modificacion, p_afp_fecha_registro, p_afp_estado_carnet, p_afp_fecha_carnet, p_afp_usuario, p_afp_estado);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_bs_afp para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__bs_afp();
		}
        public DataSet ObtenerDetalleFuncionario()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDetalleFuncionario(this);
        }
        public DataSet ObtenerGrillaAFP()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaAFP(this);
        }
		public bool ActualizarCuaNua(cls_bs_afp _bs_afp)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ActualizarCuaNua(this);
		}
		public  bool ActualizarAfp(cls_bs_afp _bs_afp)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ActualizarAfp(this);
		}
		#endregion
	}
}

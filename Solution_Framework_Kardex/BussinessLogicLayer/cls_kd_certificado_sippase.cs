using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_Kardex.DataAccessLayer;

namespace Solution_Framework_Kardex.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_kd_certificado_sippase.
	/// </summary>
	public class cls_kd_certificado_sippase
	{
		#region PROPIEDADES
		public int sip_id { get; set; }
		public int sip_per_id { get; set; }
        public string sip_descripcion_cert { get; set; }
        public DateTime sip_fecha_cert { get; set; }
        public DateTime sip_fecha_pres { get; set; }
        public string sip_estado { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_kd_certificado_sippase
        /// </summary>
        public int Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__kd_certificado_sippase(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_kd_certificado_sippase
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__kd_certificado_sippase(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_kd_certificado_sippase
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__kd_certificado_sippase(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_kd_certificado_sippase
		/// </summary>
		/// <param name="sip_id">
		/// Clave primaria de la tabla _kd_certificado_sippase
		/// </param>
		public DataSet ObtenerRegistro(int p_sip_id)
		{
			sip_id = p_sip_id;
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__kd_certificado_sippase(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_kd_certificado_sippase para llenar una grilla
		/// </summary>
		/// <param name="sip_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="sip_per_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="sip_descripcion_cert">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="sip_fecha_cert">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="sip_fecha_pres">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="sip_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		public DataSet ObtenerTablaGrilla(
            string p_sip_id,
            string p_sip_per_id, 
			string p_sip_descripcion_cert, 
			string p_sip_fecha_cert, 
			string p_sip_fecha_pres, 
			string p_sip_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__kd_certificado_sippase(p_sip_id, p_sip_per_id, p_sip_descripcion_cert, p_sip_fecha_cert, p_sip_fecha_pres, p_sip_estado);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_kd_certificado_sippase para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__kd_certificado_sippase();
		}
		#endregion
	}
}

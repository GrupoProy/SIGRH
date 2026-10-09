using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_Salarios.DataAccessLayer;

namespace Solution_Framework_Salarios.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_pla_cas.
	/// </summary>
	public class cls_pla_cas
	{
		#region PROPIEDADES
		public int cs_id { get; set; }
		public int cs_per_id { get; set; }
        public string cs_res_adm { get; set; }
        public string cs_nro_cas { get; set; }
        public DateTime cs_fecha_cas { get; set; }
        public int cs_anos { get; set; }
        public int cs_meses { get; set; }
        public int cs_dias { get; set; }
        public string cs_tipo_reg { get; set; }
        public string cs_procesado { get; set; }
        public string cs_estado { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_pla_cas
        /// </summary>
        public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__pla_cas(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_pla_cas
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__pla_cas(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_pla_cas
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__pla_cas(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_pla_cas
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__pla_cas(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_pla_cas
		/// </summary>
		/// <param name="cs_id">
		/// Clave primaria de la tabla _pla_cas
		/// </param>
		public DataSet ObtenerRegistro(int p_cs_id)
		{
			cs_id = p_cs_id;
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__pla_cas(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_pla_cas para llenar una grilla
		/// </summary>
		/// <param name="cs_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cs_per_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cs_res_adm">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cs_nro_cas">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cs_fecha_cas">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cs_anos">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cs_meses">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cs_dias">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cs_tipo_reg">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cs_procesado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cs_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		public DataSet ObtenerTablaGrilla(
            string p_cs_id, 
			string p_cs_per_id, 
			string p_cs_res_adm, 
			string p_cs_nro_cas, 
			string p_cs_fecha_cas, 
			string p_cs_anos, 
			string p_cs_meses, 
			string p_cs_dias, 
			string p_cs_tipo_reg, 
			string p_cs_procesado, 
			string p_cs_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__pla_cas(p_cs_id, p_cs_per_id, p_cs_res_adm, p_cs_nro_cas, p_cs_fecha_cas, p_cs_anos, p_cs_meses, p_cs_dias, p_cs_tipo_reg, p_cs_procesado, p_cs_estado);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_pla_cas para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__pla_cas();
        }

        // (KCPB)
        public DataSet ObtenerTablaGrillaC(
            string p_cs_id,
            string p_cs_per_id,
            string p_cs_res_adm,
            string p_cs_nro_cas,
            string p_cs_fecha_cas,
            string p_cs_anos,
            string p_cs_meses,
            string p_cs_dias,
            string p_cs_tipo_reg,
            string p_cs_procesado,
            string p_cs_estado)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrillaC__pla_cas(p_cs_id, p_cs_per_id, p_cs_res_adm, p_cs_nro_cas, p_cs_fecha_cas, p_cs_anos, p_cs_meses, p_cs_dias, p_cs_tipo_reg, p_cs_procesado, p_cs_estado);
        }

        // (KCPB)
        public DataSet ObtenerRegistroPB(int p_cs_anos)
        {
            cs_anos = p_cs_anos;
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerRegistroPB__pla_cas(this);
        }
		public double ObtenerHaberBasico_3Minimos()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerHaberBasico_3Minimos();
		}
		#endregion
	}
}

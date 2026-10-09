using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_BienestarSocial.DataAccessLayer;

namespace Solution_Framework_BienestarSocial.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_bs_afiliacion_egs.
	/// </summary>
	public class cls_bs_afiliacion_egs
	{
		#region PROPIEDADES
		public int ae_id { get; set; }
		public int ae_per_id { get; set; }
        public int ae_as_id { get; set; }
        public int ae_egs_id { get; set; }
        public string ae_estado { get; set; }
		public string ae_matricula { get; set; }
        public DateTime ae_fecha_form { get; set; }
        public int ae_policlinico { get; set; }
        public DateTime ae_fecha_baja_form { get; set; }
        public DateTime ae_fecha_baja_elab { get; set; }
        public string ae_tipo_ingreso { get; set; }
        public string ae_tipo_proceso_baja { get; set; }
        public int ae_em_id { get; set; }
        #endregion

        #region METODOS
		public bool CambiarMatricula()
        {
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.CambiarMatricula(this);
        }

		public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__bs_afiliacion_egs(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_bs_afiliacion_egs
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__bs_afiliacion_egs(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_bs_afiliacion_egs
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__bs_afiliacion_egs(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_bs_afiliacion_egs
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__bs_afiliacion_egs(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_bs_afiliacion_egs
		/// </summary>
		/// <param name="ae_id">
		/// Clave primaria de la tabla _bs_afiliacion_egs
		/// </param>
		public DataSet ObtenerRegistro(int p_ae_id)
		{
			ae_id = p_ae_id;
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__bs_afiliacion_egs(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_bs_afiliacion_egs para llenar una grilla
		/// </summary>
		/// <param name="ae_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ae_per_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ae_as_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ae_egs_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ae_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ae_fecha_form">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ae_policlinico">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ae_fecha_baja_form">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ae_fecha_baja_elab">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ae_tipo_ingreso">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ae_tipo_proceso_baja">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ae_em_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		public DataSet ObtenerTablaGrilla(
            string p_ae_id, 
			string p_ae_per_id, 
			string p_ae_as_id, 
			string p_ae_egs_id, 
			string p_ae_estado, 
			string p_ae_fecha_form, 
			string p_ae_policlinico, 
			string p_ae_fecha_baja_form, 
			string p_ae_fecha_baja_elab, 
			string p_ae_tipo_ingreso, 
			string p_ae_tipo_proceso_baja, 
			string p_ae_em_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__bs_afiliacion_egs(p_ae_id, p_ae_per_id, p_ae_as_id, p_ae_egs_id, p_ae_estado, p_ae_fecha_form, p_ae_policlinico, p_ae_fecha_baja_form, p_ae_fecha_baja_elab, p_ae_tipo_ingreso, p_ae_tipo_proceso_baja, p_ae_em_id);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_bs_afiliacion_egs para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__bs_afiliacion_egs();
		}

		public bool Adicionar_2_bs_afiliacion_egs()
        {
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar_2_bs_afiliacion_egs(this);
        }
		#endregion
	}
}

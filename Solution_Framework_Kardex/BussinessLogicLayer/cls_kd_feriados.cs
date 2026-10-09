using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_Kardex.DataAccessLayer;

namespace Solution_Framework_Kardex.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_kd_feriados.
	/// </summary>
	public class cls_kd_feriados
	{
		#region PROPIEDADES
		public int fe_id { get; set; }
		public string fe_fecha { get; set; }
		public string fe_descripcion { get; set; }
		public string fe_estado { get; set; }

		#endregion

		#region METODOS
		/// <summary>
		/// Método que adiciona una nuevo registro en tbl_kd_feriados
		/// </summary>
		public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__kd_feriados(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_kd_feriados
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__kd_feriados(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_kd_feriados
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__kd_feriados(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_kd_feriados
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__kd_feriados(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_kd_feriados
		/// </summary>
		/// <param name="fe_id">
		/// Clave primaria de la tabla _kd_feriados
		/// </param>

		public bool ObtenerRegistro(int fe_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__kd_feriados(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_kd_feriados para llenar una grilla
		/// </summary>
		/// <param name="fe_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="fe_fecha">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="fe_descripcion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="fe_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>

		public DataSet ObtenerTablaGrilla(string fe_id, 
						string fe_fecha, 
						string fe_descripcion, 
						string fe_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__kd_feriados(fe_id, fe_fecha, fe_descripcion, fe_estado);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_kd_feriados para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__kd_feriados();
		}

        // (JQC)
        public DataSet ObtenerGrillaFeriados()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaFeriados(this);
        }
        public DataSet ObtenerFeriadoX()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFeriadoX(this);
        }
        #endregion
    }
}

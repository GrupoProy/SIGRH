using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_MovimientoPersonal.DataAccessLayer;

namespace Solution_Framework_MovimientoPersonal.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_escala_puesto.
	/// </summary>
	public class cls_escala_puesto
	{

		#region PROPIEDADES
		public int epu_id { get; set; }
		public int epu_es_id { get; set; }
		public int epu_p_id { get; set; }
		public string epu_tipo { get; set; }
		public string epu_estado { get; set; }
		public int es_pr_id { get; set; }

		#endregion

		#region METODOS
		/// <summary>
		/// Método que adiciona una nuevo registro en tbl_escala_puesto
		/// </summary>
		public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__escala_puesto(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_escala_puesto
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__escala_puesto(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_escala_puesto
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__escala_puesto(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_escala_puesto
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__escala_puesto(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_escala_puesto
		/// </summary>
		/// <param name="epu_id">
		/// Clave primaria de la tabla _escala_puesto
		/// </param>

		public bool ObtenerRegistro(int epu_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__escala_puesto(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_escala_puesto para llenar una grilla
		/// </summary>
		/// <param name="epu_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="epu_es_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="epu_p_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="epu_tipo">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="epu_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>

		public DataSet ObtenerTablaGrilla(string epu_id, 
						string epu_es_id, 
						string epu_p_id, 
						string epu_tipo, 
						string epu_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__escala_puesto(epu_id, epu_es_id, epu_p_id, epu_tipo, epu_estado);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_escala_puesto para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__escala_puesto();
		}
        public DataSet ObtenerGrillaEscalaPuesto()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaEscalaPuesto(this);
        }
        public DataSet ValidarEP()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ValidarEP(this);
        }
        public DataSet ObtenerPuestos()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerPuestos(this);
        }
        #endregion
    }
}

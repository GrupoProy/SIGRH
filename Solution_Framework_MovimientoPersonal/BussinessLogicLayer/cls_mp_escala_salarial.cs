using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_MovimientoPersonal.DataAccessLayer;

namespace Solution_Framework_MovimientoPersonal.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_mp_escala_salarial.
	/// </summary>
	public class cls_mp_escala_salarial
	{
		#region PROPIEDADES
		public int es_id { get; set; }
		public int es_pr_id { get; set; }
		public int es_ns_id { get; set; }
		public string es_escalafon { get; set; }
		public string es_descripcion { get; set; }
		public string es_estado { get; set; }
		public int es_ne_id { get; set; }
		public int es_rf_id { get; set; }
		public string es_categoria { get; set; }
		#endregion

		#region METODOS
		/// <summary>
		/// Método que adiciona una nuevo registro en tbl_mp_escala_salarial
		/// </summary>
		public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__mp_escala_salarial(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_mp_escala_salarial
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__mp_escala_salarial(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_mp_escala_salarial
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__mp_escala_salarial(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_mp_escala_salarial
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__mp_escala_salarial(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_mp_escala_salarial
		/// </summary>
		/// <param name="es_id">
		/// Clave primaria de la tabla _mp_escala_salarial
		/// </param>

		public bool ObtenerRegistro(int es_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__mp_escala_salarial(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_mp_escala_salarial para llenar una grilla
		/// </summary>
		/// <param name="es_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="es_pr_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="es_ns_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="es_escalafon">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="es_descripcion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="es_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="es_ne_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="es_rf_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="es_categoria">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>

		public DataSet ObtenerTablaGrilla(string es_id, 
						string es_pr_id, 
						string es_ns_id, 
						string es_escalafon, 
						string es_descripcion, 
						string es_estado, 
						string es_ne_id, 
						string es_rf_id, 
						string es_categoria)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__mp_escala_salarial(es_id, es_pr_id, es_ns_id, es_escalafon, es_descripcion, es_estado, es_ne_id, es_rf_id, es_categoria);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_mp_escala_salarial para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__mp_escala_salarial(this);
		}

		#endregion
	}
}

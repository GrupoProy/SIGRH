using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_MovimientoPersonal.DataAccessLayer;

namespace Solution_Framework_MovimientoPersonal.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_mp_presupuesto.
	/// </summary>
	public class cls_mp_presupuesto
	{
		#region PROPIEDADES
		public int pp_id { get; set; }
        public int pp_cp_id { get; set; }
		public int pp_partida { get; set; }
		public int pp_entidad_trans { get; set; }
		public DateTime pp_fecha_calculo { get; set; }
		public double pp_monto { get; set; }
		public double pp_saldo { get; set; }
		public string pp_estado { get; set; }
		public int cp_pr_id { get; set; }
		#endregion

		#region METODOS
		/// <summary>
		/// Método que adiciona una nuevo registro en tbl_mp_presupuesto
		/// </summary>
		public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__mp_presupuesto(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_mp_presupuesto
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__mp_presupuesto(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_mp_presupuesto
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__mp_presupuesto(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_mp_presupuesto
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__mp_presupuesto(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_mp_presupuesto
		/// </summary>
		/// <param name="pp_id">
		/// Clave primaria de la tabla _mp_presupuesto
		/// </param>

		public bool ObtenerRegistro(int pp_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__mp_presupuesto(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_mp_presupuesto para llenar una grilla
		/// </summary>
		/// <param name="pp_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pp_cp_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pp_partida">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pp_entidad_trans">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pp_fecha_calculo">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pp_monto">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pp_saldo">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pp_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>

		public DataSet ObtenerTablaGrilla()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__mp_presupuesto(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_mp_presupuesto para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__mp_presupuesto();
		}
		#endregion
	}
}

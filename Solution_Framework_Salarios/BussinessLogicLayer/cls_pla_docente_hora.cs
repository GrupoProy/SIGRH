using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Solution_Framework_Salarios.DataAccessLayer;

namespace Solution_Framework_Salarios.BussinessLogicLayer
{
    class cls_pla_docente_hora
	{
		#region ATRIBUTOS
		private int _pdh_id;
		private int _pdh_per_id;
		private int _pdh_horas;
		private string _pdh_estado;

		#endregion

		#region CONSTRUCTOR
		public cls_pla_docente_horas()
		{ }

		public cls_pla_docente_horas(int pdh_id,
				int pdh_per_id,
				int pdh_horas,
				string pdh_estado)
		{
			_pdh_id = pdh_id;
			_pdh_per_id = pdh_per_id;
			_pdh_horas = pdh_horas;
			_pdh_estado = pdh_estado;
		}
		#endregion

		#region PROPIEDADES
		public int pdh_id
		{
			get { return _pdh_id; }
			set { _pdh_id = value; }
		}
		public int pdh_per_id
		{
			get { return _pdh_per_id; }
			set { _pdh_per_id = value; }
		}
		public int pdh_horas
		{
			get { return _pdh_horas; }
			set { _pdh_horas = value; }
		}
		public string pdh_estado
		{
			get { return _pdh_estado; }
			set { _pdh_estado = value; }
		}

		#endregion

		#region METODOS
		/// <summary>
		/// Método que adiciona una nuevo registro en tbl_pla_docente_horas
		/// </summary>
		public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__pla_docente_horas(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_pla_docente_horas
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__pla_docente_horas(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_pla_docente_horas
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__pla_docente_horas(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_pla_docente_horas
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__pla_docente_horas(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_pla_docente_horas
		/// </summary>
		/// <param name="pdh_id">
		/// Clave primaria de la tabla _pla_docente_horas
		/// </param>

		public bool ObtenerRegistro(int pdh_id)
		{
			_pdh_id = pdh_id;

			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__pla_docente_horas(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_pla_docente_horas para llenar una grilla
		/// </summary>
		/// <param name="pdh_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pdh_per_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pdh_horas">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pdh_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>

		public DataSet ObtenerTablaGrilla(string pdh_id,
						string pdh_per_id,
						string pdh_horas,
						string pdh_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__pla_docente_horas(pdh_id, pdh_per_id, pdh_horas, pdh_estado);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_pla_docente_horas para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__pla_docente_horas();
		}
		#endregion
	}
}

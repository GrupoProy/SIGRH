using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Solution_Framework_Salarios.DataAccessLayer;

namespace Solution_Framework_Salarios.BussinessLogicLayer
{
	public class cls_pla_docente_horas
	{
		#region ATRIBUTOS
		private int _pdh_id;
		private int _pdh_per_id;
		private int _pdh_horas;
		private string _pdh_estado;
		private int _pdh_as_id;

		#endregion

		#region CONSTRUCTOR
		public cls_pla_docente_horas()
		{ }

		public cls_pla_docente_horas(int pdh_id,
				int pdh_per_id,
				int pdh_horas,
				string pdh_estado, int pdh_as_id)
		{
			_pdh_id = pdh_id;
			_pdh_per_id = pdh_per_id;
			_pdh_horas = pdh_horas;
			_pdh_estado = pdh_estado;
			_pdh_as_id = pdh_as_id;
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
		public int pdh_as_id
		{
			get { return _pdh_as_id; }
			set { _pdh_as_id = value; }
		}
		#endregion

		#region METODOS
		/// <summary>
		/// Método que adiciona una nuevo registro en tbl_pla_docente_horas
		/// </summary>
		public  DataSet ListarGrillaDocentesMes()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ListarGrillaDocentesMes();
		}
		public  bool AdicionarHorasDocentes(cls_pla_docente_horas _pla_docentes)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.AdicionarHorasDocentes(this);
		}
		public bool ModificarHorasDocentes(cls_pla_docente_horas _pla_docentes)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ModificarHorasDocentes(this);
		}
		public DataSet ObtenerUnidadesOrganizacionales()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerUnidadesOrganizacionales();
		}
		public DataSet ObtenerUnidadesOrganizacionales_filtrado(int per_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerUnidadesOrganizacionales_filtrado(per_id);
		}
		public DataSet ListarGrillaDocentesMesPorUnidad(int eo_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ListarGrillaDocentesMesPorUnidad(eo_id);
		}
		public  DataSet UnidadesOrganizacionalesAltasBajas()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.UnidadesOrganizacionalesAltasBajas();
		}

		#endregion
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Solution_Framework_Salarios.DataAccessLayer;

namespace Solution_Framework_Salarios.BussinessLogicLayer
{
    public class cls_pla_docentes_adicional
	{
		#region ATRIBUTOS
		private int _td_id;
		private int _td_per_id;
		private string _td_tipo_docente;
		private int _td_eo_id;
		private string _td_carrera;
		private DateTime _td_fecha_inicio;
		private DateTime _td_fecha_fin;
		private int _td_horas;
		private double _td_total_ganado;
		private double _td_iue;
		private double _td_desc_asistencia;
		private double _td_desc_otros;
		private string _td_procesado;
		private string _td_estado;
		private string _td_periodo;
		private string _td_glosa;
		private DateTime _td_fecha_proceso;

		#endregion

		#region CONSTRUCTOR
		public cls_pla_docentes_adicional()
		{ }

		public cls_pla_docentes_adicional(int td_id,
				int td_per_id,
				string td_tipo_docente,
				int td_eo_id,
				string td_carrera,
				DateTime td_fecha_inicio,
				DateTime td_fecha_fin,
				int td_horas,
				double td_total_ganado,
				double td_iue,
				double td_desc_asistencia,
				double td_desc_otros,
				string td_procesado,
				string td_estado, string td_periodo, string td_glosa, DateTime td_fecha_proceso)
		{
			_td_id = td_id;
			_td_per_id = td_per_id;
			_td_tipo_docente = td_tipo_docente;
			_td_eo_id = td_eo_id;
			_td_carrera = td_carrera;
			_td_fecha_inicio = td_fecha_inicio;
			_td_fecha_fin = td_fecha_fin;
			_td_horas = td_horas;
			_td_total_ganado = td_total_ganado;
			_td_iue = td_iue;
			_td_desc_asistencia = td_desc_asistencia;
			_td_desc_otros = td_desc_otros;
			_td_procesado = td_procesado;
			_td_estado = td_estado;
			_td_periodo = td_periodo;
			_td_glosa = td_glosa;
			_td_fecha_proceso = td_fecha_proceso;
		}
		#endregion

		#region PROPIEDADES
		public int td_id
		{
			get { return _td_id; }
			set { _td_id = value; }
		}
		public int td_per_id
		{
			get { return _td_per_id; }
			set { _td_per_id = value; }
		}
		public string td_tipo_docente
		{
			get { return _td_tipo_docente; }
			set { _td_tipo_docente = value; }
		}
		public int td_eo_id
		{
			get { return _td_eo_id; }
			set { _td_eo_id = value; }
		}
		public string td_carrera
		{
			get { return _td_carrera; }
			set { _td_carrera = value; }
		}
		public DateTime td_fecha_inicio
		{
			get { return _td_fecha_inicio; }
			set { _td_fecha_inicio = value; }
		}
		public DateTime td_fecha_fin
		{
			get { return _td_fecha_fin; }
			set { _td_fecha_fin = value; }
		}
		public int td_horas
		{
			get { return _td_horas; }
			set { _td_horas = value; }
		}
		public double td_total_ganado
		{
			get { return _td_total_ganado; }
			set { _td_total_ganado = value; }
		}
		public double td_iue
		{
			get { return _td_iue; }
			set { _td_iue = value; }
		}
		public double td_desc_asistencia
		{
			get { return _td_desc_asistencia; }
			set { _td_desc_asistencia = value; }
		}
		public double td_desc_otros
		{
			get { return _td_desc_otros; }
			set { _td_desc_otros = value; }
		}
		public string td_procesado
		{
			get { return _td_procesado; }
			set { _td_procesado = value; }
		}
		public string td_estado
		{
			get { return _td_estado; }
			set { _td_estado = value; }
		}
		public string td_periodo
		{
			get { return _td_periodo; }
			set { _td_periodo = value; }
		}
		public string td_glosa
		{
			get { return _td_glosa; }
			set { _td_glosa = value; }
		}
		public DateTime td_fecha_proceso
		{
			get { return _td_fecha_proceso; }
			set { _td_fecha_proceso = value; }
		}
		#endregion

		#region METODOS
		public bool Estadoimpreso(cls_pla_docentes_adicional adicional)
        {
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Estadoimpreso(adicional);
        }
		public  DataSet ObtenerAsignacionAdicionalDocentes()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerAsignacionAdicionalDocentes();
		}
		public  bool AdicionarAsignacionAdicionalDocentes(cls_pla_docentes_adicional _Pla_Docentes_Adicional)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.AdicionarAsignacionAdicionalDocentes(this);
		}
		public DataSet ListarAsignacionesAdicionalesDocentes(cls_pla_docentes_adicional _Pla_Docentes_Adicional)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ListarAsignacionesAdicionalesDocentes(this);
		}
		public bool EliminarAsignacionAdicional(int td_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.EliminarAsignacionAdicional(td_id);
		}
		public  string ObtenerIdEstructuraBaseParaAsignacionesadicionalesDocentes()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerIdEstructuraBaseParaAsignacionesadicionalesDocentes();
		}
		public DataSet ObtenerPeriodoAsignacionesAdicionales()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerPeriodoAsignacionesAdicionales();
		}
		public  DataSet ObtenerTodasAsignacionesAdicionalesDocentes()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTodasAsignacionesAdicionalesDocentes();
		}
		public  bool ProcesarAsignacionesAdicionales()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ProcesarAsignacionesAdicionales();
		}
		#endregion
	}
}
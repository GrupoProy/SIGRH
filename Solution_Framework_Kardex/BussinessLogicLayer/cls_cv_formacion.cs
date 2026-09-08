using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Solution_Framework_Kardex.DataAccessLayer;

namespace Solution_Framework_Kardex.BussinessLogicLayer
{
    public class cls_cv_formacion
	{
		#region ATRIBUTOS
		private int _cv_form_id;
		private int _cv_ga_id;
		private int _cv_inst_id;
		private int _cv_carr_id;
		private int _cv_form_año_inicio;
		private  int _cv_form_año_fin;
		private string _cv_form_prov_nal;
		private string _cv_form_estado;
		private int _cv_form_per_id;

		#endregion

		#region CONSTRUCTOR
		public cls_cv_formacion()
		{ }

		public cls_cv_formacion(int cv_form_id,
				int cv_ga_id,
				int cv_inst_id,
				int cv_carr_id,
				 int cv_form_año_inicio,
				 int cv_form_año_fin,
				string cv_form_prov_nal,
				string cv_form_estado,
				int cv_form_per_id)
		{
			_cv_form_id = cv_form_id;
			_cv_ga_id = cv_ga_id;
			_cv_inst_id = cv_inst_id;
			_cv_carr_id = cv_carr_id;
			_cv_form_año_inicio = cv_form_año_inicio;
			_cv_form_año_fin = cv_form_año_fin;
			_cv_form_prov_nal = cv_form_prov_nal;
			_cv_form_estado = cv_form_estado;
			_cv_form_per_id = cv_form_per_id;
		}
		#endregion

		#region PROPIEDADES
		public int cv_form_id
		{
			get { return _cv_form_id; }
			set { _cv_form_id = value; }
		}
		public int cv_ga_id
		{
			get { return _cv_ga_id; }
			set { _cv_ga_id = value; }
		}
		public int cv_inst_id
		{
			get { return _cv_inst_id; }
			set { _cv_inst_id = value; }
		}
		public int cv_carr_id
		{
			get { return _cv_carr_id; }
			set { _cv_carr_id = value; }
		}
		public  int cv_form_año_inicio
		{
			get { return _cv_form_año_inicio; }
			set { _cv_form_año_inicio = value; }
		}
		public int cv_form_año_fin
		{
			get { return _cv_form_año_fin; }
			set { _cv_form_año_fin = value; }
		}
		public string  cv_form_prov_nal
		{
			get { return _cv_form_prov_nal; }
			set { _cv_form_prov_nal = value; }
		}
		public string cv_form_estado
		{
			get { return _cv_form_estado; }
			set { _cv_form_estado = value; }
		}
		public int cv_form_per_id
		{
			get { return _cv_form_per_id; }
			set { _cv_form_per_id = value; }
		}

		#endregion

		#region METODOS
		/// <summary>
		/// Método que adiciona una nuevo registro en tbl_cv_formacion
		/// </summary>
		public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar_CurriculumFormacion(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_cv_formacion
		/// </summary>
		//public bool Actualizar()
		//{
		//	DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
		//	return DBLayer.Actualizar__cv_formacion(this);
		//}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_cv_formacion
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar_CurriculumFormacion(this);
		}



        public DataSet ObtenerGrilla_Formacion(int per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerGrilla_Formacion(per_id);
        }

		/// <summary>
		/// Método que obtiene la tabla tbl_cv_formacion para llenar un combo
		/// </summary>
		//public DataSet ObtenerTablaCombo()
		//{
		//	DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
		//	return DBLayer.ObtenerTablaCombo__cv_formacion();
		//}
		public  bool InsertarFormacion_Insitucion(string nombre, int depto, string estado, int provincia, int ciudad, string observacion)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.InsertarFormacion_Insitucion(nombre, depto, estado, provincia, ciudad, observacion);
		}
		public  bool InsertarFormacion_Carrera(string carrera_nombre, string carrera_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.InsertarFormacion_Carrera(carrera_nombre, carrera_estado);
		}
		public  DataSet ListadoCursos(int per_id, string accion)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ListadoCursos(per_id, accion);
		}
		public bool InsertarCursos_Insitucion(string nombre, int depto, string estado, int provincia, int ciudad, string observacion)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.InsertarCursos_Insitucion(nombre, depto, estado, provincia, ciudad, observacion);
		}
		public  bool InsertarCursos_Curso(string nombre_curso, string estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.InsertarCursos_Curso( nombre_curso, estado);
		}
		public  bool Adicionar_CurriculumCurso(int per_id, int curs_id, int inst_id, int carga_horaria, string estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar_CurriculumCurso(per_id, curs_id, inst_id, carga_horaria, estado);
		}
		public  DataSet ObtenerGrilla_Cursos(int per_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerGrilla_Cursos(per_id);
		}
		public bool Eliminar_CurriculumCursos(int per_id, int curs_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar_CurriculumCursos(per_id, curs_id);
		}
		public bool InsertarTrayectoria_Insitucion(string nombre, int depto, string estado, int provincia, int ciudad, string observacion)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.InsertarCursos_Insitucion(nombre, depto, estado, provincia, ciudad, observacion);
		}
		public  bool Adicionar_CurriculumTrayectoria(int inst_id, string area, string ultimo_cargo, int mes_inicio, int gestion_inicio, int mes_fin, int gestion_fin, string estado, int per_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar_CurriculumTrayectoria(inst_id, area, ultimo_cargo, mes_inicio, gestion_inicio, mes_fin, gestion_fin, estado, per_id);
		}
		public  DataSet ObtenerGrilla_Trayectoria(int per_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerGrilla_Trayectoria(per_id);
		}
		public  bool Eliminar_CurriculumTrayectoria(int exp_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar_CurriculumTrayectoria(exp_id);
		}
		public  DataSet ListadoIdiomas()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ListadoIdiomas();
		}
		public  bool Adicionar_CurriculumIdioma(int per_id, int idioma_id, string estado, string nivel)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar_CurriculumIdioma(per_id, idioma_id, estado, nivel);
		}
		public  bool Eliminar_CurriculumIdioma(int per_id, int idioma_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar_CurriculumIdioma(per_id, idioma_id);
		}
		public DataSet ObtenerGrilla_Idiomas(int per_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerGrilla_Idiomas(per_id);
		}
		public  bool InsertarNuevoIdioma(string nombre_idioma, string estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.InsertarNuevoIdioma(nombre_idioma, estado);
		}
		public  bool InsertarNuevoConocimiento(string nombre_conocimiento, string estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.InsertarNuevoConocimiento(nombre_conocimiento, estado);
		}
		public DataSet ListadoConocimientos()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ListadoConocimientos();
		}
		public DataSet ObtenerGrilla_OtrosC(int per_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerGrilla_OtrosC(per_id);
		}
		public  bool Adicionar_CurriculumOtrosC(int per_id, int conocimiento_id, string estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar_CurriculumOtrosC(per_id, conocimiento_id, estado);
		}
		public  bool Eliminar_CurriculumOtrosC(int per_id, int oc_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar_CurriculumOtrosC(per_id, oc_id);
		}
		public  DataSet ObtenerGradoAcademico_Reporte()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerGradoAcademico_Reporte();
		}
		public  DataSet ObtenerCarreras_Reporte(string grado_academico)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerCarreras_Reporte(grado_academico);
		}
	}

	#endregion
}
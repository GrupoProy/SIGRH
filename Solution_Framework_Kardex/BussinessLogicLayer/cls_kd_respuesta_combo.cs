using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
 

using Solution_Framework_Kardex.DataAccessLayer;

namespace Solution_Framework_Kardex.BussinessLogicLayer
{

	/// Proporciona funcionalidad para manejo de tbl_kd_respuesta_combo.
	
	public class cls_kd_respuesta_combo
	{

		#region PROPIEDADES
		public int rc_id { get; set; }
        public int rc_rq_id { get; set; }
        public string rc_desc { get; set; }
        public string rc_equivalencia { get; set; }
        public string rc_estado { get; set; }
        public int rc_usuario_creacion { get; set; }
        public string rc_fecha_creacion { get; set; }
        public int p_per_id { get; set; }

        public int rp_valor_pk { get; set; }
        public string rp_respuesta { get; set; }
        public int rp_rq_id { get; set; }
        public int rp_rc_id { get; set; }
        public string rp_fecha_presentacion { get; set; }
        public string rp_nombre_pk { get; set; }
        public int rp_usuario_creacion { get; set; }
        public string rp_fecha_creacion { get; set; }

        public int rq_id { get; set; }
        public string rq_descripcion { get; set; }
        public string rq_estado { get; set; }
        public int rq_usuario_creacion { get; set; }
        public string rq_categoria { get; set; }

        public int ef_id { get; set; }
        public int ef_per_id { get; set; }
        public int ef_nivel_instruccion { get; set; }
        public int ef_centro_form { get; set; }
        public int ef_carrera_especialidad { get; set; }
        public string ef_fecha_ini { get; set; }
        public string ef_fecha_fin { get; set; }
        public int ef_anios_estudio { get; set; }
        public int ef_titulo_obtenido { get; set; }
        public string ef_fecha_titulo_obtenido { get; set; }
        public string ef_nro_titulo { get; set; }
        public int ef_estado { get; set; }
        public string ef_descripcion { get; set; }
        public int ef_usuario_creacion { get; set; }
        public DateTime? ef_fecha_creacion { get; set; }
        public int ef_usuario_modificacion { get; set; }
        public DateTime? ef_fecha_modificacion { get; set; }
        #endregion

        #region METODOS
        
        /// Método que adiciona una nuevo registro en tbl_kd_respuesta_combo
        
        public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__kd_respuesta_combo(this);
		}

		
		/// Método que actualiza datos en la tabla tbl_kd_respuesta_combo
		
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__kd_respuesta_combo(this);
		}

		
		/// Método que elimina datos en la tabla tbl_kd_respuesta_combo
		
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__kd_respuesta_combo(this);
		}

		
		/// Método que obtiene ID para registros de tbl_kd_respuesta_combo
		
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__kd_respuesta_combo(this);
		}

		 
		/// Método que obtiene un registro de tbl_kd_respuesta_combo
		 
		/// <param name="rc_id">
		/// Clave primaria de la tabla _kd_respuesta_combo
		/// </param>

		public bool ObtenerRegistro(int rc_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__kd_respuesta_combo(this);
		}

		 
		/// Método que obtiene la tabla tbl_kd_respuesta_combo para llenar una grilla
		 
		/// <param name="rc_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="rc_rq_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="rc_desc">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="rc_equivalencia">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="rc_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="rc_usuario_creacion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="rc_fecha_creacion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>

		public DataSet ObtenerTablaGrilla(string rc_id, 
						string rc_rq_id, 
						string rc_desc, 
						string rc_equivalencia, 
						string rc_estado, 
						string rc_usuario_creacion, 
						string rc_fecha_creacion)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__kd_respuesta_combo(rc_id, rc_rq_id, rc_desc, rc_equivalencia, rc_estado, rc_usuario_creacion, rc_fecha_creacion);
		}

		 
		/// Método que obtiene la tabla tbl_kd_respuesta_combo para llenar un combo
		 
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__kd_respuesta_combo();
		}

        public DataSet ListaRequisitos()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListaRequisitos(this);
        }
        public DataSet ComboRequisitos()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ComboRequisitos(this);
        }
        public DataSet ObtenerDatosFuncioanrio()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDatosFuncioanrio(this);
        }
        public DataSet ObtenerDatosPersonales()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDatosPersonales(this);
        }
        public bool GuardarRequisitosPresentados()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.GuardarRequisitosPresentados(this);
        }
        public DataSet RequisitosPresentadosFun()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.RequisitosPresentadosFun(this);
        }
        public bool ActualizarRequisitos()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarRequisitos(this);
        }
        public DataSet ObtenerGrillaEducFormal()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaEducFormal(this);
        }
        public DataSet ObtenerGrillaRequisitos()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaRequisitos(this);
        }
        public DataSet ObtenerFiltradoCategoria()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFiltradoCategoria(this);
        }
        public bool AdicionarRequisito()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarRequisito(this);
        }
        public bool ActualizarRequisito()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarRequisito(this);
        }
        public bool EliminarRequisito()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarRequisito(this);
        }
        public DataSet ObtenerRequisitoX()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerRequisitoX(this);
        }
        public bool GuardarRequisitosPresentadosUDEP()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.GuardarRequisitosPresentadosUDEP(this);
        }
        public DataSet ValidarRequisitosPresentados()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ValidarRequisitosPresentados(this);
        }
        public DataSet RegistrarFormacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.RegistrarFormacion(this);
        }
        public DataSet ObtenerFormacionX()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFormacionX(this);
        }
        public bool ActualizarFormacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarFormacion(this);
        }
        public  DataSet ObtenerNivelInstruccion(cls_kd_respuesta_combo _kd_respuesta_combo)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerNivelInstruccion(this);
        }
        public  bool ActualizarNivelInstruccion(cls_kd_respuesta_combo _kd_respuesta_combo)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarNivelInstruccion(this);
        }
        public  bool EliminarTmp_ReporteFiliacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarTmp_ReporteFiliacion();
        }

        

         
        /// Registra una nueva formación académica (acción A1).
         
        public bool RegistrarFormacionKardex()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.RegistrarFormacionKardex(this);
        }

         
        /// Actualiza una formación existente (acción C25).
         
        public bool ActualizarFormacionKardex()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarFormacionKardex(this);
        }

         
        /// Elimina lógicamente una formación (acción C22).
         
        public bool EliminarFormacionKardex(int ef_id, int usuario_modificacion)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarFormacionKardex(ef_id, usuario_modificacion);
        }

         
        /// Obtiene la grilla de educación formal (acción C10).
         
        public DataSet ObtenerGrillaEducacionFormal(int per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaEducacionFormal(per_id);
        }

         
        /// Obtiene una formación por ID (acción C21).
         
        public DataSet ObtenerFormacionXKardex(int ef_id, int ef_per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFormacionXKardex(ef_id, ef_per_id);
        }

        
        #endregion
    }
}

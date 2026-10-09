using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_BienestarSocial.DataAccessLayer;

namespace Solution_Framework_BienestarSocial.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_bs_examen_preocupacional.
	/// </summary>
	public class cls_bs_examen_preocupacional
	{
		#region PROPIEDADES
		public int exp_id { get; set; }
        public int exp_per_id { get; set; }
        public int exp_lugar { get; set; }
        public DateTime exp_fecha_elab { get; set; }
		public string exp_carts_puesto { get; set; }
        public string exp_fecha_examen { get; set; }
        public string exp_estado { get; set; }
        public string exp_diagnostico { get; set; }
        public string exp_comentario { get; set; }
        public string exp_recomendaciones { get; set; }
        public string exp_actividad_realiza { get; set; }
        public DateTime exp_fecha_recep_Funcionario { get; set; }
        public int exp_nro_historia_clinica { get; set; }
        public string exp_medico { get; set; }
        public int exp_n_autorizacion { get; set; }
        public bool exp_convenio { get; set; }
        public string exp_fecha_prog { get; set; }
        public string exp_tel_of_fun { get; set; }
        public string exp_tel_dom_fun { get; set; }
        public string exp_obs_aut { get; set; }
        public double exp_importe { get; set; }
        public string exp_tipo_sangre { get; set; }
        public int exp_pr_id { get; set; }
        public DateTime exp_correlativo_fecha_registro_n_autorizacion { get; set; }
        public int exp_as_id { get; set; }
        public int as_id { get; set; }
        public int pr_id { get; set; }
        public string exp_caracteristica_puesto { get; set; }

        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_bs_examen_preocupacional
        /// </summary>
        public DataSet Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__bs_examen_preocupacional(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_bs_examen_preocupacional
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__bs_examen_preocupacional(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_bs_examen_preocupacional
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__bs_examen_preocupacional(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_bs_examen_preocupacional
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__bs_examen_preocupacional(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_bs_examen_preocupacional
		/// </summary>
		/// <param name="exp_id">
		/// Clave primaria de la tabla _bs_examen_preocupacional
		/// </param>

		public bool ObtenerRegistro(int exp_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__bs_examen_preocupacional(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_bs_examen_preocupacional para llenar una grilla
		/// </summary>
		/// <param name="exp_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="exp_per_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="exp_fecha_elab">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="exp_carts_puesto">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="exp_fecha_examen">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="exp_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="exp_diagnostico">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="exp_comentario">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="exp_recomendaciones">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="exp_fecha_recep_Funcionario">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="exp_n_historia_clinica">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="exp_medico">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="exp_n_autorizacion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="exp_convenio">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="exp_fecha_prog">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="exp_tel_of_fun">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="exp_tel_dom_fun">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="exp_obsaut">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="exp_importe">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="exp_tipo_sangre">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="exp_correlativo_gestion_n_autorizacion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="exp_correlativo_fecha_registro_n_autorizacion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="exp_as_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>

		public DataSet ObtenerTablaGrilla(string exp_id, 
						string exp_per_id, 
						string exp_fecha_elab, 
						string exp_carts_puesto, 
						string exp_fecha_examen, 
						string exp_estado, 
						string exp_diagnostico, 
						string exp_comentario, 
						string exp_recomendaciones, 
						string exp_fecha_recep_Funcionario, 
						string exp_n_historia_clinica, 
						string exp_medico, 
						string exp_n_autorizacion, 
						string exp_convenio, 
						string exp_fecha_prog, 
						string exp_tel_of_fun, 
						string exp_tel_dom_fun, 
						string exp_obsaut, 
						string exp_importe, 
						string exp_tipo_sangre, 
						string exp_correlativo_gestion_n_autorizacion, 
						string exp_correlativo_fecha_registro_n_autorizacion, 
						string exp_as_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__bs_examen_preocupacional(exp_id, exp_per_id, exp_fecha_elab, exp_carts_puesto, exp_fecha_examen, exp_estado, exp_diagnostico, exp_comentario, exp_recomendaciones, exp_fecha_recep_Funcionario, exp_n_historia_clinica, exp_medico, exp_n_autorizacion, exp_convenio, exp_fecha_prog, exp_tel_of_fun, exp_tel_dom_fun, exp_obsaut, exp_importe, exp_tipo_sangre, exp_correlativo_gestion_n_autorizacion, exp_correlativo_fecha_registro_n_autorizacion, exp_as_id);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_bs_examen_preocupacional para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__bs_examen_preocupacional();
		}
        public DataSet ObtenerDatosFuncionario()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDatosFuncionario(this);
        }
        public DataSet ObtenerDatosFuncionarioExamen()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDatosFuncionarioExamen(this);
        }
        public DataSet ObtenerNroAutorizacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerNroAutorizacion(this);
        }
        public DataSet ObtenerExamenesRealizados()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerExamenesRealizados(this);
        }
        public DataSet ObtenerTelefonos()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTelefonos(this);
        }
        public DataSet ObtenerExamenProgramado()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerExamenProgramado(this);
        }
        public bool ReprogramarExamen()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ReprogramarExamen(this);
        }
        public bool DeclararExamen()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.DeclararExamen(this);
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_ManualPuestos.DataAccessLayer;

namespace Solution_Framework_ManualPuestos.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_mdp_resultados_especificos.
	/// </summary>
	public class cls_mdp_resultados_especificos
	{


		#region PROPIEDADES
		public int eo_id { get; set; }
		public int res_id { get; set; }
		public int res_poai_id { get; set; }
		public string res_descripcion { get; set; }
		public string res_indicador { get; set; }
		public int res_puntaje { get; set; }
		public string res_estado { get; set; }

        public string prefijo { get; set; }

        public string item { get; set; }
        public string item_anterior { get; set; }

        public string puesto { get; set; }
        public string cargo { get; set; }
        public string est_org { get; set; }

        public string objetivo { get; set; }

        public string exp_general { get; set; }

        public string exp_especifica { get; set; }

        public string exp_general_mun { get; set; }

        public string exp_especifica_mun { get; set; }

        public int tar_id { get; set; }
        public int tar_poai_id { get; set; }
        public string tar_descripcion { get; set; }

        public int ico_co_id { get; set; }
        public int ico_poai_id { get; set; }

        public int idj_dj_id { get; set; }
        public int idj_poai_id { get; set; }

        public int ifo_fo_id { get; set; }

        public int ifo_fo_comp_id { get; set; }

        public int ifo_fo_id_before { get; set; }

        public int ifo_fo_comp_id_before { get; set; }
        public int ifo_poai_id { get; set; }

        public int irespons_poai_id { get; set; }

        public int irespons_cat_id { get; set; }

        public int ici_poai_id { get; set; }

        public int ici_ci_id { get; set; }

        public string ici_cat_abreviacion { get; set; }

        public int pu_nro_puesto { get; set; }
        public int pu_id_puesto_anterior { get; set; }
        public int pu_id { get; set; }
        public int pu_poai_id { get; set; }
        public string pu_pref_puesto { get; set; }
        public int ne_nivel_interno { get; set; }
        public string ne_categoria { get; set; }
        public string gestion { get; set; }
        public string p_Accion { get; set; }

        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_mdp_resultados_especificos
        /// </summary>
        public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__mdp_resultados_especificos(this);
		}

        public bool AdicionarConocimiento()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarConocimiento(this);
        }
        public bool AdicionarDisposicion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarDisposicion(this);
        }

        public bool AdicionarCaracterIndividual()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarCaracterIndividual(this);
        }

        public bool AdicionarTarea()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarTarea(this);
        }

        public bool AdicionarItem()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarItem(this);
        }

        public bool AdicionarFormacionO()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarFormacionO(this);
        }

        public bool AdicionarFormacionC()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarFormacionC(this);
        }

        public bool AdicionarResponsabilidad()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarResponsabilidad(this);
        }

        /// <summary>
        /// Método que actualiza datos en la tabla tbl_mdp_resultados_especificos
        /// </summary>
        public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__mdp_resultados_especificos(this);
		}

        public bool ActualizarTarea()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarTarea(this);
        }

        public bool ActualizarItem()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarItem(this);
        }

        public bool ActualizarFormacionO()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarFormacionO(this);
        }

        public bool ActualizarFormacionC()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarFormacionC(this);
        }

        public bool ActualizarResponsabilidad()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarResponsabilidad(this);
        }

        /// <summary>
        /// Método que elimina datos en la tabla tbl_mdp_resultados_especificos
        /// </summary>
        public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__mdp_resultados_especificos(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_mdp_resultados_especificos
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__mdp_resultados_especificos(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_mdp_resultados_especificos
		/// </summary>
		/// <param name="res_id">
		/// Clave primaria de la tabla _mdp_resultados_especificos
		/// </param>
		/// <param name="res_poai_id">
		/// Clave primaria de la tabla _mdp_resultados_especificos
		/// </param>

		public bool ObtenerRegistro(int p_res_id, int p_res_poai_id)
		{
			res_id = p_res_id;
			res_poai_id = p_res_poai_id;

			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__mdp_resultados_especificos(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_mdp_resultados_especificos para llenar una grilla
		/// </summary>
		/// <param name="res_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="res_poai_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="res_descripcion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="res_indicador">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="res_puntaje">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="res_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>

		public DataSet ObtenerTablaGrilla(string res_id, 
						string res_poai_id, 
						string res_descripcion, 
						string res_indicador, 
						string res_puntaje, 
						string res_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__mdp_resultados_especificos(res_id, res_poai_id, res_descripcion, res_indicador, res_puntaje, res_estado);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_mdp_resultados_especificos para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__mdp_resultados_especificos();
		}

        public bool ObtenerFicha(string p_res_poai_id)
        {
            res_poai_id = Convert.ToInt32(p_res_poai_id);
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFicha(this);
        }

        public DataSet ObtenerGrillaSupervision(string id)
        {
            res_poai_id = Convert.ToInt32(id);
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaSupervision(this);
        }

        public DataSet ObtenerGrillaResultados(string id)
        {
            res_poai_id = Convert.ToInt32(id);
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaResultados(this);
        }

        public DataSet ObtenerGrillaTareas(string id)
        {
            res_poai_id = Convert.ToInt32(id);
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaTareas(this);
        }

        public DataSet ObtenerGrillaConocimiento(string id)
        {
            res_poai_id = Convert.ToInt32(id);
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaConocimiento(this);
        }

        public DataSet ObtenerGrillaDisposicion(string id)
        {
            res_poai_id = Convert.ToInt32(id);
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaDisposicion(this);
        }

        public DataSet ObtenerListaRespons()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerListaRespons();
        }

        public DataSet ObtenerResponsItem(string id)
        {
            res_poai_id = Convert.ToInt32(id);
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerResponsItem(this);
        }

        public DataSet ObtenerListaFiltradoFormO()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerListaFiltradoFormO();
        }

        public DataSet ObtenerFormOItem(string id)
        {
            res_poai_id = Convert.ToInt32(id);
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFormOItem(this);
        }

        public DataSet ObtenerListaFiltradoFormC()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerListaFiltradoFormC();
        }

        public DataSet ObtenerListaFiltradoFormRequerida()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerListaFiltradoFormRequerida();
        }

        public DataSet ObtenerListaFiltradoAreaFormacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerListaFiltradoAreaFormacion();
        }

        public DataSet ObtenerFiltradoConcocimiento(string id)
        {
            ico_poai_id = Convert.ToInt32(id);
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFiltradoConcocimiento(this);
        }
        public DataSet ObtenerFiltradoDisposicion(string id)
        {
            idj_poai_id = Convert.ToInt32(id);
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFiltradoDisposicion(this);
        }

        public DataSet ObtenerFiltradoCaracterIndividual(string id)
        {
            ici_poai_id = Convert.ToInt32(id);
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFiltradoCaracterIndividual(this);
        }

        public DataSet ObtenerFormCItem(string id)
        {
            res_poai_id = Convert.ToInt32(id);
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFormCItem(this);
        }

        public DataSet ObtenerFormRequeridaItem(string id)
        {
            res_poai_id = Convert.ToInt32(id);
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFormRequeridaItem(this);
        }

        public DataSet ObtenerGrillaCaracterI(string id)
        {
            res_poai_id = Convert.ToInt32(id);
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaCaracterI(this);
        }

        public DataSet ObtenerSumaPuntaje()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerSumaPuntaje(this);
        }

        public DataSet ObtenerSumaPuntajeEditar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerSumaPuntajeEditar(this);
        }

        public bool ObtenerTiempoExperiencia(string p_res_poai_id)
        {
            res_poai_id = Convert.ToInt32(p_res_poai_id);
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTiempoExperiencia(this);
        }
        public bool EliminarResultado()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarResultado(this);
        }

        public bool ObtenerResultadoP(string p_res_id, string p_res_poai_id)
        {
            res_poai_id = Convert.ToInt32(p_res_poai_id);
            res_id = Convert.ToInt32(p_res_id);
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerResultadoP(this);
        }

        public bool EliminarTarea()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarTarea(this);
        }

        public bool EliminarConocimiento()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarConocimiento(this);
        }

        public bool EliminarDisposicion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarDisposicion(this);
        }

        public bool EliminarCaracterI()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarCaracterI(this);
        }

        public bool ObteneTareaP(string p_tar_id, string p_tar_poai_id)
        {
            tar_poai_id = Convert.ToInt32(p_tar_poai_id);
            tar_id = Convert.ToInt32(p_tar_id);
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObteneTareaP(this);
        }
        public DataSet ObtenerSiguienteItem()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerSiguienteItem(this);
        }
        public DataSet ObtenerCodigo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerCodigo(this);
        }
        public DataSet ObtenerSumaPuntajeT(string id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerSumaPuntajeT(id);
        }
        public bool BusquedaPuestoMP()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.BusquedaPuestoMP(this);
        }
        #endregion
    }
}

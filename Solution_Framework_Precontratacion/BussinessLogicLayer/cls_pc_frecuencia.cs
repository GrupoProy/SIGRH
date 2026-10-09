using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_Precontratacion.DataAccessLayer;

namespace Solution_Framework_Precontratacion.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_pc_frecuencia.
	/// </summary>
	public class cls_pc_frecuencia
	{
    
		#region PROPIEDADES
		public int fr_id { get; set; }
        public int fr_pr_id { get; set; }
        public int fr_es_id { get; set; }
        public decimal fr_tiempo { get; set; }
        public int fr_cp_id { get; set; }
        public int fr_usuario_creacion { get; set; }
        public string fr_fecha_creacion { get; set; }
        public string fr_fecha_modificacion { get; set; }
        public string fr_estado { get; set; }
        public string fr_descrip_puesto { get; set; }
        public int fr_cod_poa { get; set; }
        public string fr_fecha_inicio { get; set; }
        public string fr_fecha_fin { get; set; }
        public int fr_id_anterior { get; set; }
        public decimal fr_tiempooriginal { get; set; }
        public string fr_tipo_jornada { get; set; }
        public int fr_pu_id { get; set; }
        public string fr_obj_puesto { get; set; }
        public string fr_observaciones { get; set; }

        public int cp_da { get; set; }
        public int cp_ue { get; set; }
        public int cp_programa { get; set; }
        public int cp_proyecto { get; set; }
        public int cp_actividad { get; set; }
        public int perm_us_id { get; set; }
        public int perm_pr_id { get; set; }
        public int perm_ue { get; set; }
        public int es_id { get; set; }
        public string accion { get; set; }
        public string json { get; set; }
        public int ns_id { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_pc_frecuencia
        /// </summary>
        public DataSet Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__pc_frecuencia(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_pc_frecuencia
		/// </summary>
		public DataSet Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__pc_frecuencia(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_pc_frecuencia
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__pc_frecuencia(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_pc_frecuencia
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__pc_frecuencia(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_pc_frecuencia
		/// </summary>
		/// <param name="fr_id">
		/// Clave primaria de la tabla _pc_frecuencia
		/// </param>

		public bool ObtenerRegistro(int fr_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__pc_frecuencia(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_pc_frecuencia para llenar una grilla
		/// </summary>
		/// <param name="fr_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="fr_pr_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="fr_es_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="fr_tiempo">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="fr_cp_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="fr_fecha_creacion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="fr_fecha_modificacion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="fr_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="fr_descrip_puesto">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="fr_cod_poa">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="fr_fecha_inicio">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="fr_fecha_fin">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="fr_id_anterior">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="fr_tiempooriginal">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="fr_tipo_jornada">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="fr_obj_puesto">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="fr_observaciones">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>

		public DataSet ObtenerTablaGrilla(string fr_id, 
						string fr_pr_id, 
						string fr_es_id, 
						string fr_tiempo, 
						string fr_cp_id, 
						string fr_fecha_creacion, 
						string fr_fecha_modificacion, 
						string fr_estado, 
						string fr_descrip_puesto, 
						string fr_cod_poa, 
						string fr_fecha_inicio, 
						string fr_fecha_fin, 
						string fr_id_anterior, 
						string fr_tiempooriginal, 
						string fr_tipo_jornada, 
						string fr_obj_puesto, 
						string fr_observaciones)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__pc_frecuencia(fr_id, fr_pr_id, fr_es_id, fr_tiempo, fr_cp_id, fr_fecha_creacion, fr_fecha_modificacion, fr_estado, fr_descrip_puesto, fr_cod_poa, fr_fecha_inicio, fr_fecha_fin, fr_id_anterior, fr_tiempooriginal, fr_tipo_jornada, fr_obj_puesto, fr_observaciones);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_pc_frecuencia para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__pc_frecuencia();
		}
        public DataSet ObtenerEscalafonNS()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerEscalafonNS(this);
        }
        public DataSet ObtenerFiltradoGestion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFiltradoGestion();
        }
        public DataSet BuscarCategorias()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.BuscarCategorias(this);
        }
        public DataSet ListarrCategorias()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarrCategorias(this);
        }
        public DataSet ListarOperaciones()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarOperaciones(this);
        }
        public DataSet ActualizarFrecuencia()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarFrecuencia(this);
        }
        public DataSet EliminarFrecuencia()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarFrecuencia(this);
        }
        public DataSet VerEstadoCategoria()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.VerEstadoCategoria(this);
        }
        public DataSet ObtenerFrecuenciasCategorias()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFrecuenciasCategorias(this);
        }
        public DataSet ObtenerFrecuenciasOperacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFrecuenciasOperacion(this);
        }
        public DataSet ObtenerResumenFrecuenciasCategorias()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerResumenFrecuenciasCategorias(this);
        }
        public DataSet ObtenerResumenFrecuenciasCategoriasF()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerResumenFrecuenciasCategoriasF(this);
        }
        public DataSet ObtenerResumenFrecuenciasOperacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerResumenFrecuenciasOperacion(this);
        }
        public DataSet ObtenerResumenPresup()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerResumenPresup(this);
        }
        public DataSet ObtenerComprometidoOperacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerComprometidoOperacion(this);
        }
        public DataSet ObtenerComprometidoPorOperacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerComprometidoPorOperacion(this);
        }
        public DataSet ObtenerInformacionCategoria()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerInformacionCategoria(this);
        }
        public DataSet ObtenerHaberBasico()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerHaberBasico(this);
        }
        public DataSet ObtenerListaFiltradoPuesto()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerListaFiltradoPuesto(this);
        }
        public DataSet ObtenerTiempoMeses()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTiempoMeses(this);
        }
        public DataSet ObtenerFrecuenciaX()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFrecuenciaX(this);
        }

        public DataSet ObtenerCategorias()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerCategorias(this);
        }
        public DataSet ObtenerFrecuenciasLibres()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFrecuenciasLibres(this);
        }
        public DataSet ObtenerFrecuenciasLibresX()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFrecuenciasLibresX(this);
        }
        public DataSet ObtenerListaFiltradoFrec(string q = "")
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerListaFiltradoFrec(this, q);
        }
        public DataSet ObtenerListaFiltradoFrecuencia(string q = "")
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerListaFiltradoFrecuencia(this, q);
        }
        public DataSet ObtenerListaFiltradoFrecuenciaOperacion(string q = "")
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerListaFiltradoFrecuenciaOperacion(this, q);
        }
        public DataSet ObtenerFrecuenciasLibresES()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFrecuenciasLibresES(this);
        }
        public DataSet ObtenerFrecuenciaOcupadoX()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFrecuenciaOcupadoX(this);
        }
        public DataSet ObtenerFrecuenciaOcupadoX2()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFrecuenciaOcupadoX2(this);
        }
        public DataSet ObtenerDetalleReplicaX()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDetalleReplicaX(this);
        }
        public DataSet ObtenerTiempoUso()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTiempoUso(this);
        }
        public DataSet ObtenerUsuarios()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerUsuarios(this);
        }
        public DataSet ObtenerRemitente()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerRemitente(this);
        }
        public DataSet ObtenerListaFiltradoTipoItem()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerListaFiltradoTipoItem(this);
        }
        public DataSet ObtenerCategoriasPresup()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerCategoriasPresup(this);
        }
        public DataSet ObtenerCategoriasUE()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerCategoriasUE(this);
        }
        public DataSet ObtenerPresupuestoUE()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerPresupuestoUE(this);
        }
        public DataSet ObtenerPermisosUE()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerPermisosUE(this);
        }
        public DataSet ObtenerResumenGral()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerResumenGral(this);
        }
        public bool ActualizarOperacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarOperacion(this);
        }
        public DataSet ObtenerSaldoCategoria()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerSaldoCategoria(this);
        }
        #endregion
    }
}

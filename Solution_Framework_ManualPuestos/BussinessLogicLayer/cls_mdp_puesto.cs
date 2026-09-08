using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_ManualPuestos.DataAccessLayer;

namespace Solution_Framework_ManualPuestos.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_mdp_puesto.
	/// </summary>
	public class cls_mdp_puesto
	{

		#region PROPIEDADES
		public int pu_poai_id
		{
            get;
            set;
        }
		public int pu_nro_puesto
		{
            get;
            set;
        }
		public string pu_nombre_puesto
		{
            get;
            set;
        }
		public string pu_pref_puesto
		{
            get;
            set;
        }
		public string pu_objetivo
		{
            get;
            set;
        }
		public int pu_id_puesto_anterior
		{
            get;
            set;
        }
		public string pu_estado
		{
            get;
            set;
        }

        public string param1
        {
            get;
            set;
        }

        public string gestion
        {
            get;
            set;
        }

        public string gestion_selec
        {
            get;
            set;
        }

        public string param2
        {
            get;
            set;
        }

        public string param3
        {
            get;
            set;
        }

        public string param4
        {
            get;
            set;
        }

        public string param5
        {
            get;
            set;
        }
        public string param6
        {
            get;
            set;
        }

        public string nombreFun
        {
            get;
            set;
        }

        public string paternoFun
        {
            get;
            set;
        }

        public string maternoFun
        {
            get;
            set;
        }

        public string ci
        {
            get;
            set;
        }

        public string ci_exp
        {
            get;
            set;
        }

        public string fecha_inicio
        {
            get;
            set;
        }

        public string fecha_final
        {
            get;
            set;
        }

        public int ca_cod_cargo
        {
            get;
            set;
        }

        public string imagen
        {
            get;
            set;
        }

        public int co_id
        {
            get;
            set;
        }

        public int co_poai_id
        {
            get;
            set;
        }

        public int cod_fun_login
        {
            get;
            set;
        }

        public int eo_id { get; set; }
        public int es_cod_esc { get; set; }
        public int ca_id { get; set; }
        public int ca_es_id { get; set; }
        public int ca_eo_id { get; set; }
        public string ca_ti_item { get; set; }
        public int ca_num_item { get; set; }
        public string ca_estado { get; set; }
        public string ca_aplica_incremento { get; set; }
        public string ca_tipo_jornada { get; set; }
        public string ca_basico_calculado { get; set; }
        public string ca_fecha_modificacion { get; set; }
        public int ca_tipo_calculo { get; set; }

        public int gl_valor_pk { get; set; }
        public string gl_nombre_pk { get; set; }
        public string gl_tabla { get; set; }
        public int gl_tipo_mov { get; set; }
        public string gl_fecha_doc { get; set; }
        public int gl_tipo_doc { get; set; }
        public string gl_glosa { get; set; }
        public string gl_estado { get; set; }
        public int gl_usuario { get; set; }
        public int ca_id_anterior { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_mdp_puesto
        /// </summary>
        public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__mdp_puesto(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_mdp_puesto
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__mdp_puesto(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_mdp_puesto
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__mdp_puesto(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_mdp_puesto
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__mdp_puesto(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_mdp_puesto
		/// </summary>
		/// <param name="pu_poai_id">
		/// Clave primaria de la tabla _mdp_puesto
		/// </param>

		public bool ObtenerRegistro(int p_pu_poai_id)
		{
			pu_poai_id = p_pu_poai_id;

			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__mdp_puesto(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_mdp_puesto para llenar una grilla
		/// </summary>
		/// <param name="pu_poai_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pu_nro_puesto">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pu_nombre_puesto">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pu_pref_puesto">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pu_objetivo">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pu_id_puesto_anterior">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pu_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>

		public DataSet ObtenerTablaGrilla(string pu_poai_id, 
						string pu_nro_puesto, 
						string pu_nombre_puesto, 
						string pu_pref_puesto, 
						string pu_objetivo, 
						string pu_id_puesto_anterior, 
						string pu_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__mdp_puesto(pu_poai_id, pu_nro_puesto, pu_nombre_puesto, pu_pref_puesto, pu_objetivo, pu_id_puesto_anterior, pu_estado);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_mdp_puesto para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__mdp_puesto();
		}
        public DataSet ObtenerGrillaPuesto()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaPuesto(this);
        }

        public DataSet ObtenerGrillaFiltro()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaFiltro(this);
        }
        public DataSet ObtenerGrillaFiltroIntervalo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaFiltroIntervalo(this);
        }
        public DataSet ObtenerGrillaFiltroCM()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaFiltroCM(this);
        }

        public DataSet ObtenerGrillaFiltroConocimientoCM()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaFiltroConocimientoCM(this);
        }

        public DataSet ObtenerFiltradoCargo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFiltradoCargo(this);
        }
        public DataSet ObtenerFiltradoDirAdm()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFiltradoDirAdm(this);
        }

        public bool ObtenerRegistro()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerRegistro(this);
        }

        public DataSet ObtenerFiltradoUnidadEjec()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFiltradoUnidadEjec(this);
        }

        public DataSet ObtenerFiltradoUnidadOrg()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFiltradoUnidadOrg(this);
        }

        public DataSet ObtenerFiltradoGestion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFiltradoGestion();
        }

        public DataSet ObtenerGestion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGestion(this);
        }
        public DataSet ObtenerHistoricoItem()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerHistoricoItem(this);
        }
        public DataSet ObtenerNombreFun()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerNombreFun(this);
        }

        public bool ObtenerDatosItem()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDatosItem(this);
        }

        public bool ObtenerDatosItemAnterior()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDatosItemAnterior(this);
        }

        public DataSet ObtenerFiltradoConcocimiento()
        {
            //co_poai_id = Convert.ToInt32(id);
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFiltradoConcocimiento(this);
        }

        public bool AdicionarTareaCM()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarTareaCM(this);
        }

        public bool AdicionarConocimientoCM()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarConocimientoCM(this);
        }

        public bool validaRegistroConocimiento()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.validaRegistroConocimiento(this);
        }

        public DataSet ObtenerNivelOrg()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerNivelOrg(this);
        }
        public DataSet ObtenerNivelOrgItems()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerNivelOrgItems(this);
        }

        public DataSet ObtenerDetalleitem()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDetalleitem(this);
        }

        public DataSet ObtenerFiltradoCargoUO()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFiltradoCargoUO(this);
        }
        public DataSet ObtenerFiltradoTipoItem()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFiltradoTipoItem(this);
        }
        public DataSet ObtenerDetalleUO()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDetalleUO(this);
        }

        public DataSet ObtenerFiltradoTipoDoc()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFiltradoTipoDoc();
        }

        public DataSet ObtenerIdCargo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerIdCargo();
        }

        public DataSet ObtenerNroItem()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerNroItem();
        }

        public bool AdicionarCargo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarCargo(this);
        }

        public bool AdicionarGlosa()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarGlosa(this);
        }

        public DataSet ObtenerGrillaItems()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaItems(this);
        }

        public DataSet ObtenerDetalleitemCargo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDetalleitemCargo(this);
        }
        public bool ActualizarItem()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarItem(this);
        }

        public bool EliminarItem()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarItem(this);
        }
        #endregion
    }
}

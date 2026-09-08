using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_Salarios.DataAccessLayer;

namespace Solution_Framework_Salarios.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_pla_factor.
	/// </summary>
	public class cls_pla_factor
	{
		#region PROPIEDADES
		public int fa_id { get; set; }
        public string fa_descripcion { get; set; }
        public string fa_signo { get; set; }
        public int fa_ac_id { get; set; }
        public string fa_tipo_calculo { get; set; }
        public double fa_valor { get; set; }
        public string fa_estado { get; set; }

        // JQC
        public string tipo_trans { get; set; }
        public string gestion_selec { get; set; }
        public int es_id { get; set; }
        public int eo_id { get; set; }
        public int cp_id { get; set; }
        public int tr_fecha_creacion_nro { get; set; }

        public int tr_id { get; set; }
        public int tr_pc_id { get; set; }
        public int tr_per_id { get; set; }
        public int tr_ac_id { get; set; }
        public int tr_fa_id { get; set; }
        public string tr_fecha_inicio { get; set; }
        public string tr_fecha_fin { get; set; }
        public string tr_monto { get; set; }
        public string tr_estado { get; set; }
        public int tr_usuario_creacion { get; set; }
        public string tr_fecha_creacion { get; set; }
        public int lhx_id { get; set; }
        public int lhx_cat_id { get; set; }

        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_pla_factor
        /// </summary>
        public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__pla_factor(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_pla_factor
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__pla_factor(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_pla_factor
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__pla_factor(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_pla_factor
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__pla_factor(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_pla_factor
		/// </summary>
		/// <param name="fa_id">
		/// Clave primaria de la tabla _pla_factor
		/// </param>
		public DataSet ObtenerRegistro(int p_fa_id)
		{
			fa_id = p_fa_id;
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__pla_factor(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_pla_factor para llenar una grilla
		/// </summary>
		/// <param name="fa_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="fa_descripcion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="fa_signo">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="fa_ac_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="fa_tipo_calculo">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="fa_valor">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="fa_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>

		public DataSet ObtenerTablaGrilla(
            string p_fa_id, 
			string p_fa_descripcion, 
			string p_fa_signo, 
			string p_fa_ac_id, 
			string p_fa_tipo_calculo, 
			string p_fa_valor, 
			string p_fa_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__pla_factor(p_fa_id, p_fa_descripcion, p_fa_signo, p_fa_ac_id, p_fa_tipo_calculo, p_fa_valor, p_fa_estado);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_pla_factor para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__pla_factor();
		}

        // (KCPB)
        public DataSet ObtenerTablaComboX(string p_fa_descripcion)
        {
            fa_descripcion = p_fa_descripcion;
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaComboX__pla_factor(this);
        }

        // Funciones (JQC) 
        public DataSet ObtenerTipoTrans()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTipoTrans(this);
        }
        public DataSet ObtenerNroHorasExtras()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerNroHorasExtras(this);
        }
        public DataSet ObtenerCategoriaProg()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerCategoriaProg(this);
        }
        public DataSet ObtenerPresupuesto()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerPresupuesto(this);
        }
        public DataSet ObtenerPagadoDevengado()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerPagadoDevengado(this);
        }
        public DataSet ObtenerProceso()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerProceso(this);
        }
        public bool AdicionarTransaccion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarTransaccion(this);
        }
        public DataSet ObtenerTransaccion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTransaccion(this);
        }
        public DataSet ObtenerGrillaHE()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaHE(this);
        }
        public bool EliminarTransaccion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarTransaccion(this);
        }
        public bool EliminarTransaccionIVA()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarTransaccionIVA(this);
        }
        public DataSet ObtenerAporteIva()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerAporteIva(this);
        }
        public DataSet ObtenerGrillaAporteIVA()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaAporteIVA(this);
        }
        public DataSet ObtenerGrillaMontoPresentar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaMontoPresentar(this);
        }
        public DataSet ObtenerTipoSindicato()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTipoSindicato(this);
        }
        public DataSet ListarGrillaAporteSindicato()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarGrillaAporteSindicato(this);
        }
        public DataSet ObtenerTipoEstadoAporte()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTipoEstadoAporte(this);
        }
        public DataSet ObtenerGrillaAporteSindicato()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaAporteSindicato(this);
        }
        public DataSet ObtenerGrillaAsignacionHE()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaAsignacionHE(this);
        }
        public DataSet ObtenerTipoEscalafon()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTipoEscalafon(this);
        }
        public bool EliminarAsigHorasExtras()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarAsigHorasExtras(this);
        }
        public bool AdicionarLimiteHorasExtras()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarLimiteHorasExtras(this);
        }
        public DataSet ObtenerGrillaLimiteHE()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaLimiteHE(this);
        }
        public DataSet listaFiltradoTipoDocHE()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.listaFiltradoTipoDocHE(this);
        }
        public DataSet ObtenerGrillaFactores()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaFactores(this);
        }
        public DataSet ObtenerFactorX()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFactorX(this);
        }
        public bool ActualizarFactor()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarFactor(this);
        }
        public DataSet ObtenerGrillaHorasExtras()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaHorasExtras(this);
        }
        public  DataSet ObtenerComboCovenios()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerComboCovenios();
        }
        public DataSet ListarGrillaConvenios()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarGrillaConvenios(this);
        }
        public  bool AdicionarTransaccionConvenios(cls_pla_factor _pla_factor)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarTransaccionConvenios(this);
        }
        public DataSet ListarGrillaDescuentos()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarGrillaDescuentos(this);
        }
        public  DataSet ObtenerComboOtrosDescuentos()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerComboOtrosDescuentos();
        }
        public  DataSet ListaGrillaOtrosDescuentos()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListaGrillaOtrosDescuentos(this);
        }
        public  DataSet ListarDescuentosMontosCuotas()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarDescuentosMontosCuotas();
        }
        public  DataSet ListarTotalCuotas()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarTotalCuotas();
        }
        public  int AdicionarTransaccionMontoUnico()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarTransaccionMontoUnico(this);
        }
        public  bool AdicionarTransaccionPorCuotas(cls_pla_factor _pla_factor)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarTransaccionPorCuotas(this);
        }
        public  bool ActivarDesactivarFNTUB(string estado, double valor, int fa_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActivarDesactivarFNTUB(estado, valor, fa_id);
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_MovimientoPersonal.DataAccessLayer;

namespace Solution_Framework_MovimientoPersonal.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_mp_tipo_abono.
	/// </summary>
	public class cls_mp_tipo_abono
	{
		#region PROPIEDADES
		public int cb_id { get; set; }
        public int cb_cod_banco { get; set; }
		public int cb_per_id { get; set; }
		public string cb_num_cuenta { get; set; }
		public string cb_tipo_abono { get; set; }
		public DateTime cb_fecha_mod { get; set; }
		public string cb_estado { get; set; }
		public int cb_secuencial { get; set; }
		public string cb_fecha_formulario { get; set; }

		#endregion

		#region METODOS
		/// <summary>
		/// Método que adiciona una nuevo registro en tbl_mp_tipo_abono
		/// </summary>
		public DataSet Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__mp_tipo_abono(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_mp_tipo_abono
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__mp_tipo_abono(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_mp_tipo_abono
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__mp_tipo_abono(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_mp_tipo_abono
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__mp_tipo_abono(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_mp_tipo_abono
		/// </summary>
		/// <param name="cb_id">
		/// Clave primaria de la tabla _mp_tipo_abono
		/// </param>

		public bool ObtenerRegistro(int cb_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__mp_tipo_abono(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_mp_tipo_abono para llenar una grilla
		/// </summary>
		/// <param name="cb_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cb_cod_banco">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cb_per_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cb_num_cuenta">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cb_tipo_abono">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cb_fecha_mod">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cb_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cb_secuencial">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="cb_fecha_formulario">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
        public DataSet ObtenerGrillaCuentas()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaCuentas(this);
        }

        /// <summary>
        /// Método que obtiene la tabla tbl_mp_tipo_abono para llenar un combo
        /// </summary>
        public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__mp_tipo_abono();
		}

        public DataSet ObtenerUltimoTipoAbono(int p_cb_per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerUltimoTipoAbono__mp_tipoabono(this);
        }

        public DataSet VerificarCuentaExistente(int p_cb_per_id, string p_cb_num_cta)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.VerificarCuentaExistente__mp_tipoabono(this);
        }

        public DataSet ObteneTipoAbonoporPersona(int p_cb_per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObteneTipoAbonoporPersona__mp_tipoabono(this);
        }
        public DataSet ObteneTipoAbonoVigente()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObteneTipoAbonoVigente(this);
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_Salarios.DataAccessLayer;

namespace Solution_Framework_Salarios.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_pla_transacciones.
	/// </summary>
	public class cls_pla_transacciones
	{
		#region PROPIEDADES
		public int tr_id { get; set; }
        public int tr_pc_id { get; set; }
        public int tr_per_id { get; set; }
        public int tr_fa_id { get; set; }
        public DateTime tr_fecha_inicio { get; set; }
        public DateTime tr_fecha_fin { get; set; }
        public string tr_monto { get; set; }
        public string tr_estado { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_pla_transacciones
        /// </summary>
        public int Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__pla_transacciones(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_pla_transacciones
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__pla_transacciones(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_pla_transacciones
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__pla_transacciones(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_pla_transacciones
		/// </summary>
		/// <param name="tr_id">
		/// Clave primaria de la tabla _pla_transacciones
		/// </param>
		public DataSet ObtenerRegistro(int p_tr_id)
		{
			tr_id = p_tr_id;
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__pla_transacciones(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_pla_transacciones para llenar una grilla
		/// </summary>
		/// <param name="tr_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="tr_pc_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="tr_per_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="tr_fa_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="tr_fecha_inicio">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="tr_fecha_fin">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="tr_monto">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="tr_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		public DataSet ObtenerTablaGrilla(
            string p_tr_id, 
            string p_tr_pc_id, 
			string p_tr_per_id,  
			string p_tr_fa_id, 
			string p_tr_fecha_inicio, 
			string p_tr_fecha_fin, 
			string p_tr_monto, 
			string p_tr_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__pla_transacciones(p_tr_id, p_tr_pc_id, p_tr_per_id, p_tr_fa_id, p_tr_fecha_inicio, p_tr_fecha_fin, p_tr_monto, p_tr_estado);
		}

		public bool QuitarDescuento(int tr_id)
        {
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.QuitarDescuento(tr_id);
        }

		/// <summary>
		/// Método que obtiene la tabla tbl_pla_transacciones para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__pla_transacciones();
		}

        // (KCPB)
        public DataSet ObtenerTablaGrillaRR(
            string p_tr_id,
            string p_tr_pc_id,
            string p_tr_per_id,
            string p_tr_fa_id,
            string p_tr_fecha_inicio,
            string p_tr_fecha_fin,
            string p_tr_monto,
            string p_tr_estado)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrillaRR__pla_transacciones(p_tr_id, p_tr_pc_id, p_tr_per_id, p_tr_fa_id, p_tr_fecha_inicio, p_tr_fecha_fin, p_tr_monto, p_tr_estado);
        }
		public DataSet ObtenerTransaccionesRetenciones(
			string p_as_id,

			string p_as_per_id,

			string p_as_ca_id,

			string p_as_fecha_inicio,

			string p_as_fecha_fin,

			string p_as_estado,

			string p_as_tipo_reg,

			string p_as_tipo_mov,

			string p_as_tipo_baja,

			string p_as_validacion,

			string p_as_fecha_validacion,

			string p_as_memo,

			string p_as_memo_baja,

			string p_as_pr_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTransaccionesRetenciones(p_as_id, p_as_per_id, p_as_ca_id, p_as_fecha_inicio, p_as_fecha_fin, p_as_estado, p_as_tipo_reg, p_as_tipo_mov, p_as_tipo_baja, p_as_validacion, p_as_fecha_validacion, p_as_memo, p_as_memo_baja, p_as_pr_id);
		}

				#endregion
			}
		}

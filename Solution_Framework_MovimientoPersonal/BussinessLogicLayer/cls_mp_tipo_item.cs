using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_MovimientoPersonal.DataAccessLayer;

namespace Solution_Framework_MovimientoPersonal.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_mp_tipo_item.
	/// </summary>
	public class cls_mp_tipo_item
	{
		#region PROPIEDADES
		public string ti_item { get; set; }
		public string ti_descripcion { get; set; }
        public string ti_estado { get; set; }
        public string ti_tipo { get; set; }
        public string ti_item_suplencia { get; set; }
        public int ti_orden { get; set; }
        public string ti_tipo_pago { get; set; }
        public bool ti_control { get; set; }
        public string ti_tipo_item_gral { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_mp_tipo_item
        /// </summary>
        public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__mp_tipo_item(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_mp_tipo_item
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__mp_tipo_item(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_mp_tipo_item
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__mp_tipo_item(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_mp_tipo_item
		/// </summary>
		/// <param name="ti_item">
		/// Clave primaria de la tabla _mp_tipo_item
		/// </param>
		/// <param name="ti_tipo">
		/// Clave primaria de la tabla _mp_tipo_item
		/// </param>
		public bool ObtenerRegistro(
            string p_ti_item, 
            string p_ti_tipo)
		{
			ti_item = p_ti_item;
			ti_tipo = p_ti_tipo;
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__mp_tipo_item(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_mp_tipo_item para llenar una grilla
		/// </summary>
		/// <param name="ti_item">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ti_descripcion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ti_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ti_tipo">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ti_item_suplencia">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ti_orden">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ti_tipo_pago">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ti_control">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ti_tipo_item_gral">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		public DataSet ObtenerTablaGrilla(
            string p_ti_item, 
			string p_ti_descripcion, 
			string p_ti_estado, 
			string p_ti_tipo, 
			string p_ti_item_suplencia, 
			string p_ti_orden, 
			string p_ti_tipo_pago, 
			string p_ti_control, 
			string p_ti_tipo_item_gral)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__mp_tipo_item(p_ti_item, p_ti_descripcion, p_ti_estado, p_ti_tipo, p_ti_item_suplencia, p_ti_orden, p_ti_tipo_pago, p_ti_control, p_ti_tipo_item_gral);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_mp_tipo_item para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__mp_tipo_item();
		}
        // (Kevin Carlos Prado Bustillos) Obtiene todos los registros de tipo ítem
        public DataSet ObtenerTablaComboTI()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaComboTI__mp_tipo_item();
        }
        // (Kevin Carlos Prado Bustillos) Obtiene todos los registros de ítem suplencia
        public DataSet ObtenerTablaComboIS()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaComboIS__mp_tipo_item();
        }
        // (Kevin Carlos Prado Bustillos) Obtiene todos los registros de tipo ítem general
        public DataSet ObtenerTablaComboTIG()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaComboTIG__mp_tipo_item();
        }
        // (Kevin Carlos Prado Bustillos) Obtiene el orden máximo según el tipo ítem
        public int ObtenerRegistroOM()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerRegistroOM__mp_tipo_item(this);
        }
		public  DataSet TipoItemAltasBajas()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.TipoItemAltasBajas();
		}

		#endregion
	}
}

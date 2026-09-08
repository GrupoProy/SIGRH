using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_MovimientoPersonal.DataAccessLayer;

namespace Solution_Framework_MovimientoPersonal.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_mp_incompatibilidad_fun.
	/// </summary>
	public class cls_mp_incompatibilidad_fun
	{
		#region PROPIEDADES
		public int if_id { get; set; }
		public int if_per_id { get; set; }
        public int if_per_id_pariente { get; set; }
        public int if_parentesco { get; set; }
        public string if_estado { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_mp_incompatibilidad_fun
        /// </summary>
        public int Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__mp_incompatibilidad_fun(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_mp_incompatibilidad_fun
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__mp_incompatibilidad_fun(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_mp_incompatibilidad_fun
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__mp_incompatibilidad_fun(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_mp_incompatibilidad_fun
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__mp_incompatibilidad_fun(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_mp_incompatibilidad_fun
		/// </summary>
		/// <param name="if_id">
		/// Clave primaria de la tabla _mp_incompatibilidad_fun
		/// </param>
		public bool ObtenerRegistro(int p_if_id)
		{
			if_id = p_if_id;

			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__mp_incompatibilidad_fun(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_mp_incompatibilidad_fun para llenar una grilla
		/// </summary>
		/// <param name="if_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="if_per_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="if_per_id_pariente">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="if_parentesco">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="if_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		public DataSet ObtenerTablaGrilla(
            string p_if_id, 
			string p_if_per_id, 
			string p_if_per_id_pariente, 
			string p_if_parentesco, 
			string p_if_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__mp_incompatibilidad_fun(p_if_id, p_if_per_id, p_if_per_id_pariente, p_if_parentesco, p_if_estado);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_mp_incompatibilidad_fun para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__mp_incompatibilidad_fun();
		}
        // (Kevin Carlos Prado Bustillos) Obtiene todos los registros de coincidencias dependiendo del funcionario
        public DataSet ObtenerTablaGrillaC(
            string p_per_id,
            string p_per_ap_paterno,
            string p_per_ap_materno)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrillaC__mp_incompatibilidad_fun(p_per_id, p_per_ap_paterno, p_per_ap_materno);
        }
        #endregion
    }
}

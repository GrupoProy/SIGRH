using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_Salarios.DataAccessLayer;

namespace Solution_Framework_Salarios.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_mp_asignacion_tipo_aportante.
	/// </summary>
	public class cls_mp_asignacion_tipo_aportante
	{
		#region PROPIEDADES
		public int at_id { get; set; }
		public int at_per_id { get; set; }
        public int at_ta_id { get; set; }
        public string at_estado { get; set; }
        // (KCPB)
        public int at_edad { get; set; }
        public bool at_jubilado { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_mp_asignacion_tipo_aportante
        /// </summary>
        public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__mp_asignacion_tipo_aportante(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_mp_asignacion_tipo_aportante
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__mp_asignacion_tipo_aportante(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_mp_asignacion_tipo_aportante
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__mp_asignacion_tipo_aportante(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_mp_asignacion_tipo_aportante
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__mp_asignacion_tipo_aportante(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_mp_asignacion_tipo_aportante
		/// </summary>
		/// <param name="at_id">
		/// Clave primaria de la tabla _mp_asignacion_tipo_aportante
		/// </param>
		public DataSet ObtenerRegistro(int p_at_id)
		{
			at_id = p_at_id;
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__mp_asignacion_tipo_aportante(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_mp_asignacion_tipo_aportante para llenar una grilla
		/// </summary>
		/// <param name="at_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="at_per_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="at_ta_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="at_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		public DataSet ObtenerTablaGrilla(
            string p_at_id, 
			string p_at_per_id, 
			string p_at_ta_id, 
			string p_at_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__mp_asignacion_tipo_aportante(p_at_id, p_at_per_id, p_at_ta_id, p_at_estado);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_mp_asignacion_tipo_aportante para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__mp_asignacion_tipo_aportante();
		}

        // (KCPB)
        public DataSet ObtenerTablaGrillaC(
            string p_at_id,
            string p_at_per_id,
            string p_at_ta_id,
            string p_at_estado)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrillaC__mp_asignacion_tipo_aportante(p_at_id, p_at_per_id, p_at_ta_id, p_at_estado);
        }

        // (KCPB)
        public DataSet ObtenerRegistroTA(int p_at_ta_id)
        {
            at_ta_id = p_at_ta_id;
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerRegistroTA__mp_asignacion_tipo_aportante(this);
        }

        // (KCPB)
        public DataSet ObtenerTablaComboTA(
            int p_at_edad,
            bool p_at_jubilado)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaComboTA__mp_asignacion_tipo_aportante(p_at_edad, p_at_jubilado);
        }
        #endregion
    }
}

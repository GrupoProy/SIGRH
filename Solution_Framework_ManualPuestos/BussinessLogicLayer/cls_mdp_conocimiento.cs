using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_ManualPuestos.DataAccessLayer;

namespace Solution_Framework_ManualPuestos.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_mdp_conocimiento.
	/// </summary>
	public class cls_mdp_conocimiento
	{
		#region PROPIEDADES
		public int co_id
        {
            get;
            set;
        }
        public string co_descripcion
        {
            get;
            set;
        }
        public string co_estado
        {
            get;
            set;
        }

        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_mdp_conocimiento
        /// </summary>
        public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__mdp_conocimiento(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_mdp_conocimiento
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__mdp_conocimiento(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_mdp_conocimiento
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__mdp_conocimiento(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_mdp_conocimiento
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__mdp_conocimiento(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_mdp_conocimiento
		/// </summary>
		/// <param name="co_id">
		/// Clave primaria de la tabla _mdp_conocimiento
		/// </param>

		public bool ObtenerRegistro(int p_co_id)
		{
			co_id = p_co_id;

			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__mdp_conocimiento(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_mdp_conocimiento para llenar una grilla
		/// </summary>
		/// <param name="co_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="co_descripcion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="co_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>

		public DataSet ObtenerTablaGrilla(string co_id, 
						string co_descripcion, 
						string co_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__mdp_conocimiento(co_id, co_descripcion, co_estado);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_mdp_conocimiento para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__mdp_conocimiento();
		}

        public DataSet ObtenerGrillaConocimiento()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaConocimiento();
        }

        public bool EliminarConocimiento()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarConocimiento(this);
        }

        public bool ObtenerConocimientoP(string p_co_id)
        {
            co_id = Convert.ToInt32(p_co_id);
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerConocimientoP(this);
        }
        #endregion
    }
}


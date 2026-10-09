using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_ManualPuestos.DataAccessLayer;

namespace Solution_Framework_ManualPuestos.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_mdp_disposicion_juridica.
	/// </summary>
	public class cls_mdp_disposicion_juridica
	{
		#region PROPIEDADES
		public int dj_id
		{
            get;
            set;
        }
		public string dj_descripcion
		{
            get;
            set;
        }
		public string dj_estado
		{
            get;
            set;
        }

		#endregion

		#region METODOS
		/// <summary>
		/// Método que adiciona una nuevo registro en tbl_mdp_disposicion_juridica
		/// </summary>
		public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__mdp_disposicion_juridica(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_mdp_disposicion_juridica
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__mdp_disposicion_juridica(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_mdp_disposicion_juridica
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__mdp_disposicion_juridica(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_mdp_disposicion_juridica
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__mdp_disposicion_juridica(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_mdp_disposicion_juridica
		/// </summary>
		/// <param name="dj_id">
		/// Clave primaria de la tabla _mdp_disposicion_juridica
		/// </param>

		public bool ObtenerRegistro(int p_dj_id)
		{
			dj_id = p_dj_id;

			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__mdp_disposicion_juridica(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_mdp_disposicion_juridica para llenar una grilla
		/// </summary>
		/// <param name="dj_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="dj_descripcion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="dj_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>

		public DataSet ObtenerTablaGrilla(string dj_id, 
						string dj_descripcion, 
						string dj_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__mdp_disposicion_juridica(dj_id, dj_descripcion, dj_estado);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_mdp_disposicion_juridica para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__mdp_disposicion_juridica();
		}
        public DataSet ObtenerGrillaDisposicion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaDisposicion();
        }

        public bool EliminarDisposicion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarDisposicion(this);
        }

        public bool ObtenerDisposicionP(string p_dj_id)
        {
            dj_id = Convert.ToInt32(p_dj_id);
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDisposicionP(this);
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_ManualPuestos.DataAccessLayer;

namespace Solution_Framework_ManualPuestos.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_mdp_formacion.
	/// </summary>
	public class cls_mdp_formacion
	{

		#region PROPIEDADES
		public int fo_id
		{
            get;
            set;
		}
		public string fo_tipo
		{
            get;
            set;
        }
		public string fo_descripcion
		{
            get;
            set;
        }
		public string fo_estado
		{
            get;
            set;
        }

		#endregion

		#region METODOS
		/// <summary>
		/// Método que adiciona una nuevo registro en tbl_mdp_formacion
		/// </summary>
		public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__mdp_formacion(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_mdp_formacion
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__mdp_formacion(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_mdp_formacion
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__mdp_formacion(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_mdp_formacion
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__mdp_formacion(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_mdp_formacion
		/// </summary>
		/// <param name="fo_id">
		/// Clave primaria de la tabla _mdp_formacion
		/// </param>

		public bool ObtenerRegistro(int p_fo_id)
		{
			fo_id = p_fo_id;

			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__mdp_formacion(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_mdp_formacion para llenar una grilla
		/// </summary>
		/// <param name="fo_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="fo_tipo">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="fo_descripcion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="fo_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>

		public DataSet ObtenerTablaGrilla(string fo_id, 
						string fo_tipo, 
						string fo_descripcion, 
						string fo_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__mdp_formacion(fo_id, fo_tipo, fo_descripcion, fo_estado);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_mdp_formacion para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__mdp_formacion();
		}

        public DataSet ObtenerGrillaFormacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaFormacion();
        }

        public bool EliminarFormacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarFormacion(this);
        }

        public bool ObtenerFormacionP(string p_fo_id)
        {
            fo_id = Convert.ToInt32(p_fo_id);
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFormacionP(this);
        }
        #endregion
    }
}

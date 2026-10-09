using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_ManualPuestos.DataAccessLayer;

namespace Solution_Framework_ManualPuestos.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_mdp_caracter_individual.
	/// </summary>
	public class cls_mdp_caracter_individual
	{
		#region PROPIEDADES
		public int ci_id
		{
            get;
            set;
		}
		public int ci_orden
		{
            get;
            set;
        }
		public string ci_factor
		{
            get;
            set;
        }
		public string ci_descripcion
		{
            get;
            set;
        }
		public int ci_puntaje
		{
            get;
            set;
        }
		public string ci_estado
		{
            get;
            set;
        }

		#endregion

		#region METODOS
		/// <summary>
		/// Método que adiciona una nuevo registro en tbl_mdp_caracter_individual
		/// </summary>
		public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__mdp_caracter_individual(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_mdp_caracter_individual
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__mdp_caracter_individual(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_mdp_caracter_individual
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__mdp_caracter_individual(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_mdp_caracter_individual
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__mdp_caracter_individual(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_mdp_caracter_individual
		/// </summary>
		/// <param name="ci_id">
		/// Clave primaria de la tabla _mdp_caracter_individual
		/// </param>

		public bool ObtenerRegistro(int p_ci_id)
		{
			ci_id = p_ci_id;

			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__mdp_caracter_individual(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_mdp_caracter_individual para llenar una grilla
		/// </summary>
		/// <param name="ci_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ci_orden">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ci_factor">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ci_descripcion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ci_puntaje">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ci_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>

		public DataSet ObtenerTablaGrilla(string ci_id, 
						string ci_orden, 
						string ci_factor, 
						string ci_descripcion, 
						string ci_puntaje, 
						string ci_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__mdp_caracter_individual(ci_id, ci_orden, ci_factor, ci_descripcion, ci_puntaje, ci_estado);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_mdp_caracter_individual para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__mdp_caracter_individual();
		}

        public DataSet ObtenerGrillaCaracterIndividual()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaCaracterIndividual();
        }

        public bool EliminarCaracterInd()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarCaracterInd(this);
        }

        public bool ObtenerCaracterIndividualP(string p_ci_id)
        {
            ci_id = Convert.ToInt32(p_ci_id);
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerCaracterIndividualP(this);
        }
        #endregion
    }
}

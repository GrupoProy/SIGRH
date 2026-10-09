using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_BienestarSocial.DataAccessLayer;

namespace Solution_Framework_BienestarSocial.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_bs_agente_expuesto.
	/// </summary>
	public class cls_bs_agente_expuesto
	{
		#region PROPIEDADES
		public int agexp_id { get; set; }
		public int agexp_exp_id { get; set; }
		public string agexp_fisico { get; set; }
        public string agexp_quimico { get; set; }
		public string agexp_biologico { get; set; }
		public string agexp_psicosocial { get; set; }
		public string agexp_estado { get; set; }

		#endregion

		#region METODOS
		/// <summary>
		/// Método que adiciona una nuevo registro en tbl_bs_agente_expuesto
		/// </summary>
		public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__bs_agente_expuesto(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_bs_agente_expuesto
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__bs_agente_expuesto(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_bs_agente_expuesto
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__bs_agente_expuesto(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_bs_agente_expuesto
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__bs_agente_expuesto(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_bs_agente_expuesto
		/// </summary>
		/// <param name="agexp_id">
		/// Clave primaria de la tabla _bs_agente_expuesto
		/// </param>

		public DataSet ObtenerRegistro()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__bs_agente_expuesto(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_bs_agente_expuesto para llenar una grilla
		/// </summary>
		/// <param name="agexp_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="agexp_fisico">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="agexp_quimico">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="agexp_biologico">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="agexp_psicosocial">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="agexp_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>

		public DataSet ObtenerTablaGrilla(string agexp_id, 
						string agexp_fisico, 
						string agexp_quimico, 
						string agexp_biologico, 
						string agexp_psicosocial, 
						string agexp_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__bs_agente_expuesto(agexp_id, agexp_fisico, agexp_quimico, agexp_biologico, agexp_psicosocial, agexp_estado);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_bs_agente_expuesto para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__bs_agente_expuesto();
		}
        public DataSet ObtenerAgentesExpFisico()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerAgentesExpFisico(this);
        }
        public DataSet ObtenerAgentesExpQuimico()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerAgentesExpQuimico(this);
        }
        public DataSet ObtenerAgentesExpBilogico()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerAgentesExpBilogico(this);
        }
        public DataSet ObtenerAgentesExpPsicosocial()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerAgentesExpPsicosocial(this);
        }
        #endregion
    }
}

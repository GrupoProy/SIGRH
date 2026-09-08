using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_ControlPersonal.DataAccessLayer;

namespace Solution_Framework_ControlPersonal.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_cp_controles_personal.
	/// </summary>
	public class cls_cp_controles_personal
	{
		#region PROPIEDADES
		public int cp_id { get; set; }
		public int cp_per_id { get; set; }
		public int cp_edificio { get; set; }
		public string cp_fecha_inicio { get; set; }
		public string cp_fecha_final { get; set; }
		public string cp_estado { get; set; }
		#endregion

		#region METODOS
		/// <summary>
		/// Método que adiciona una nuevo registro en tbl_cp_controles_personal
		/// </summary>
		public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__cp_controles_personal(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_cp_controles_personal
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__cp_controles_personal(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_cp_controles_personal
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__cp_controles_personal(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_cp_controles_personal
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__cp_controles_personal(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_cp_controles_personal
		/// </summary>
		/// <param name="cp_id">
		/// Clave primaria de la tabla _cp_controles_personal
		/// </param>
		public DataSet ObtenerTablaGrilla(string cp_id, 
						string cp_per_id, 
						string cp_edificio, 
						string cp_fecha_inicio, 
						string cp_fecha_final, 
						string cp_estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__cp_controles_personal(cp_id, cp_per_id, cp_edificio, cp_fecha_inicio, cp_fecha_final, cp_estado);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_cp_controles_personal para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__cp_controles_personal();
		}

        //(JQC)
        public DataSet ListarGrillaEdificio()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarGrillaEdificio(this);
        }
        public DataSet ListarFiltradoEdificio()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarFiltradoEdificio(this);
        }
        public DataSet ObtieneAsignacionEdicioX()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtieneAsignacionEdicioX(this);
        }
        public bool AdicionarFechaBaja()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarFechaBaja(this);
        }
        public DataSet ListarFiltradoEdificioEditar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarFiltradoEdificioEditar(this);
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_MovimientoPersonal.DataAccessLayer;

namespace Solution_Framework_MovimientoPersonal.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_mp_estructura_organizacional.
	/// </summary>
	public class cls_mp_estructura_organizacional
	{
		#region PROPIEDADES
		public int eo_id { get; set; }
		public int eo_pr_id { get; set; }
		public int eo_cp_id { get; set; }
		public int eo_prog { get; set; }
		public int eo_sprog { get; set; }
		public int eo_proy { get; set; }
		public int eo_obract { get; set; }
		public int eo_unidad { get; set; }
		public string eo_descripcion { get; set; }
		public string eo_estado { get; set; }
		public int eo_cod_superior { get; set; }
		public int ca_num_item { get; set; }
		public int ca_id { get; set; }

		#endregion

		#region METODOS
		/// <summary>
		/// Método que adiciona una nuevo registro en tbl_mp_estructura_organizacional
		/// </summary>
		public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__mp_estructura_organizacional(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_mp_estructura_organizacional
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__mp_estructura_organizacional(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_mp_estructura_organizacional
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__mp_estructura_organizacional(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_mp_estructura_organizacional
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__mp_estructura_organizacional(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_mp_estructura_organizacional
		/// </summary>
		/// <param name="eo_id">
		/// Clave primaria de la tabla _mp_estructura_organizacional
		/// </param>

		public bool ObtenerRegistro(int eo_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__mp_estructura_organizacional(this);
		}
		public DataSet ObtenerRegistroX(int eo_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro(eo_id);
		}
		/// <summary>
		/// Método que obtiene la tabla tbl_mp_estructura_organizacional para llenar una grilla
		/// </summary>
		/// <param name="eo_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="eo_pr_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="eo_cp_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="eo_prog">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="eo_sprog">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="eo_proy">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="eo_obract">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="eo_unidad">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="eo_descripcion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="eo_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="eo_cod_superior">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>

		public DataSet ObtenerTablaGrilla(string eo_id, 
						string eo_pr_id, 
						string eo_cp_id, 
						string eo_prog, 
						string eo_sprog, 
						string eo_proy, 
						string eo_obract, 
						string eo_unidad, 
						string eo_descripcion, 
						string eo_estado, 
						string eo_cod_superior)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__mp_estructura_organizacional(eo_id, eo_pr_id, eo_cp_id, eo_prog, eo_sprog, eo_proy, eo_obract, eo_unidad, eo_descripcion, eo_estado, eo_cod_superior);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_mp_estructura_organizacional para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__mp_estructura_organizacional();
		}
        public DataSet ObtenerDescendencia()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDescendencia(this);
        }
        public DataSet ObtenerItemsLibres()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerItemsLibres(this);
        }
        public DataSet ObtenerListaFiltradoEstOrg()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerListaFiltradoEstOrg(this);
        }
        public DataSet BuscarItemUO()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.BuscarItemUO(this);
        }
        public DataSet ObtenerPOAI()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerPOAI(this);
        }
        public DataSet ObtenerOrgInicial()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerOrgInicial(this);
        }
		public DataSet ObtenerCpId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerCpId(this);
		}
		public DataSet ObtenerListaFiltradoEstOrgMP()
        {
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerListaFiltradoEstOrgMP(this);
        }
		#endregion
	}
}

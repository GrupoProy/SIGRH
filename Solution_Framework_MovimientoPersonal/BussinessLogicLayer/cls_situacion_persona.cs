using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_MovimientoPersonal.DataAccessLayer;

namespace Solution_Framework_MovimientoPersonal.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_situacion_persona.
	/// </summary>
	public class cls_situacion_persona
    {

		#region PROPIEDADES
        public int st_id { get; set; }
        public int st_per_id { get; set; }
        public string st_tipo_situacion { get; set; }
        public string st_fecha_inicio { get; set; }
        public string st_fecha_fin { get; set; }
        public string st_estado { get; set; }
        public int st_usuario_creacion { get; set; }

		#endregion

		#region METODOS
		/// <summary>
		/// Método que adiciona una nuevo registro en tbl_situacion_persona
		/// </summary>
		public DataSet Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__situacion_persona(this);
		}
        public DataSet ValidarSituacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ValidarSituacion(this);
        }
        /// <summary>
        /// Método que actualiza datos en la tabla tbl_situacion_persona
        /// </summary>
        public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__situacion_persona(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_situacion_persona
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__situacion_persona(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_situacion_persona
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__situacion_persona(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_situacion_persona
		/// </summary>
		/// <param name="st_id">
		/// Clave primaria de la tabla _situacion_persona
		/// </param>

		public bool ObtenerRegistro(int st_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__situacion_persona(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_situacion_persona para llenar una grilla
		/// </summary>
		/// <param name="st_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="st_per_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="st_tipo_situacion">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="st_fecha_inicio">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="st_fecha_fin">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="st_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>

		public DataSet ObtenerTablaGrilla()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__situacion_persona(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_situacion_persona para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__situacion_persona();
		}
        public DataSet ObtenerListaSituacionPer()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerListaSituacionPer();
        }
        #endregion
    }
}

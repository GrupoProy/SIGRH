using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_ControlPersonal.DataAccessLayer;

namespace Solution_Framework_ControlPersonal.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_cp_marcaciones.
	/// </summary>
	public class cls_cp_marcaciones
	{
		#region PROPIEDADES
		public int? ma_id { get; set; }
		public int? ma_per_id { get; set; }
        public DateTime? ma_fecha { get; set; }
        public DateTime? ma_fecha_f { get; set; }
        public int? ma_di_id { get; set; }
        public DateTime? ma_hora { get; set; }
        public string ma_estado { get; set; }
        public string ma_tipo { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_cp_marcaciones
        /// </summary>
        public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__cp_marcaciones(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_cp_marcaciones
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__cp_marcaciones(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_cp_marcaciones
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__cp_marcaciones(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_cp_marcaciones
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__cp_marcaciones(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_cp_marcaciones
		/// </summary>
		/// <param name="ma_id">
		/// Clave primaria de la tabla _cp_marcaciones
		/// </param>
		public DataSet ObtenerRegistro(int p_ma_id)
		{
			ma_id = p_ma_id;
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__cp_marcaciones(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_cp_marcaciones para llenar una grilla
		/// </summary>
		/// <param name="ma_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ma_per_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ma_fecha">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ma_di_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ma_hora">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ma_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ma_tipo">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		public DataSet ObtenerTablaGrilla(
            string p_ma_id, 
			string p_ma_per_id, 
			string p_ma_fecha, 
			string p_ma_di_id, 
			string p_ma_hora, 
			string p_ma_estado, 
			string p_ma_tipo)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__cp_marcaciones(p_ma_id, p_ma_per_id, p_ma_fecha, p_ma_di_id, p_ma_hora, p_ma_estado, p_ma_tipo);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_cp_marcaciones para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__cp_marcaciones();
		}

        // (KCPB)
        public DataSet ObtnerTablaGrillaM()
        {
            DataAccessLayerSQLDataAccessLayer DbLayer = new DataAccessLayerSQLDataAccessLayer();
            return DbLayer.ObtenerTablaGrillaM__cp_marcaciones(this);
        }
		#endregion

		public DataSet MesAsistencia()
        {
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.MesAsistencia();
        }

		public DataSet ListarFuncAsis(string lista)
        {
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ListarFuncAsis(lista);
        }

		public DataSet ListarPorFecha(string tipo, string mes)
        {
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ListarPorFecha(tipo, mes);
        }

		public bool Procesar(string lista_per_id, string fecha1, string fecha2)
        {
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Procesar(lista_per_id, fecha1, fecha2);
        }
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_MovimientoPersonal.DataAccessLayer;

namespace Solution_Framework_MovimientoPersonal.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_mp_asignacion_com_int.
	/// </summary>
	public class cls_mp_asignacion_com_int
	{
		#region PROPIEDADES
		public int ci_id
		{
            get; set;
        }
		public int ci_per_id
		{
            get; set;
        }
		public int ci_ca_id
		{
            get; set;
        }
		public int ci_secuencial
		{
            get; set;
        }
		public string ci_fecha_inicio
		{
            get; set;
        }
		public string ci_fecha_fin
		{
            get; set;
        }
		public string ci_estado
		{
            get; set;
        }
		public string ci_fecha_creacion
		{
            get; set;
        }
		public string ci_tipo_mov
		{
            get; set;
        }
		public string ci_tipo_reg
		{
            get; set;
        }
		public string ci_verificado
		{
            get; set;
        }
		public int ci_pr_id
		{
            get; set;
        }
		public string ci_tipo_mov_baja
		{
            get; set;
        }
		public int ci_ca_id_ant
		{
            get; set;
        }
		public int ci_secuencial_ant
		{
            get; set;
        }
		public string ci_nominal
		{
            get; set;
        }
		public int ci_ca_id_n
		{
            get; set;
        }
		public int ci_es_id_n
		{
            get; set;
        }
		public int ci_eo_id_n
		{
            get; set;
        }
		public int ci_per_id_interinato
		{
            get; set;
        }
		public string ci_fecha_conclusion
		{
            get; set;
        }
		public int ci_cod_valida
		{
            get; set;
        }
		public string ci_fecha_valida
		{
            get; set;
        }
        public int ci_usuario_creacion
        {
            get; set;
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_mp_asignacion_com_int
        /// </summary>
        public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__mp_asignacion_com_int(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_mp_asignacion_com_int
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__mp_asignacion_com_int(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_mp_asignacion_com_int
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__mp_asignacion_com_int(this);
		}

        public DataSet FinalizarAsignacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.FinalizarAsignacion(this);
        }

        /// <summary>
        /// Método que obtiene ID para registros de tbl_mp_asignacion_com_int
        /// </summary>
        public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__mp_asignacion_com_int(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_mp_asignacion_com_int
		/// </summary>
		/// <param name="ci_id">
		/// Clave primaria de la tabla _mp_asignacion_com_int
		/// </param>

		public DataSet ObtenerRegistro()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__mp_asignacion_com_int(this);
		}
        public DataSet ObtenerDatosFunCI()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDatosFunCI(this);
        }

        /// <summary>
        /// Método que obtiene la tabla tbl_mp_asignacion_com_int para llenar una grilla
        /// </summary>
        /// <param name="ci_id">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ci_per_id">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ci_ca_id">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ci_secuencial">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ci_fecha_inicio">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ci_fecha_fin">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ci_estado">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ci_fecha_creacion">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ci_tipo_mov">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ci_tipo_reg">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ci_verificado">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ci_pr_id">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ci_tipo_mov_baja">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ci_ca_id_ant">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ci_secuencial_ant">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ci_nominal">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ci_ca_id_n">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ci_es_id_n">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ci_eo_id_n">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ci_per_id_interinato">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ci_fecha_conclusion">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ci_cod_valida">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ci_fecha_valida">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>

        public DataSet ObtenerTablaGrilla(string ci_id, 
						string ci_per_id, 
						string ci_ca_id, 
						string ci_secuencial, 
						string ci_fecha_inicio, 
						string ci_fecha_fin, 
						string ci_estado, 
						string ci_fecha_creacion, 
						string ci_tipo_mov, 
						string ci_tipo_reg, 
						string ci_verificado, 
						string ci_pr_id, 
						string ci_tipo_mov_baja, 
						string ci_ca_id_ant, 
						string ci_secuencial_ant, 
						string ci_nominal, 
						string ci_ca_id_n, 
						string ci_es_id_n, 
						string ci_eo_id_n, 
						string ci_per_id_interinato, 
						string ci_fecha_conclusion, 
						string ci_cod_valida, 
						string ci_fecha_valida)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__mp_asignacion_com_int(ci_id, ci_per_id, ci_ca_id, ci_secuencial, ci_fecha_inicio, ci_fecha_fin, ci_estado, ci_fecha_creacion, ci_tipo_mov, ci_tipo_reg, ci_verificado, ci_pr_id, ci_tipo_mov_baja, ci_ca_id_ant, ci_secuencial_ant, ci_nominal, ci_ca_id_n, ci_es_id_n, ci_eo_id_n, ci_per_id_interinato, ci_fecha_conclusion, ci_cod_valida, ci_fecha_valida);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_mp_asignacion_com_int para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__mp_asignacion_com_int();
		}
		#endregion
	}
}

using System;
using System.Data;
using Solution_Framework_Kardex.DataAccessLayer;

namespace Solution_Framework_Kardex.BussinessLogicLayer
{
    public class cls_doblepercepcion
    {
        #region PROPIEDADES
        public int dp_id { get; set; }
        public int dp_per_id { get; set; }
        public bool dp_docente { get; set; }
        public string dp_universidad { get; set; }
        public decimal? dp_total_ganado_mes { get; set; }
        public decimal? dp_aguinaldo { get; set; }
        public decimal? dp_otros_ingresos { get; set; }
        public string dp_horario { get; set; }
        public int? dp_total_horas { get; set; }
        public DateTime? dp_fecha_ini { get; set; }
        public DateTime? dp_fecha_fin { get; set; }
        public int? dp_numero_materias { get; set; }
        public string dp_materias { get; set; }
        public int? dp_tipo_jornada { get; set; }
        public string dp_estado { get; set; }

        // ✅ NUEVAS PROPIEDADES
        public int? dp_dj_id { get; set; }
        public int dp_usuario_creacion { get; set; }
        public DateTime? dp_fecha_creacion { get; set; }
        public int dp_usuario_modificacion { get; set; }
        public DateTime? dp_fecha_modificacion { get; set; }
        #endregion

        #region METODOS

        /// <summary>
        /// Registra una nueva doble percepción (acción 'A').
        /// </summary>
        public bool Adicionar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Adicionar_DoblePercepcion(this);
        }

        /// <summary>
        /// Actualiza una doble percepción existente (acción 'C').
        /// </summary>
        public bool Actualizar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Actualizar_DoblePercepcion(this);
        }

        /// <summary>
        /// Elimina lógicamente (acción 'B').
        /// </summary>
        public bool Eliminar(int usuario_modificacion)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Eliminar_DoblePercepcion(this.dp_id, usuario_modificacion);
        }

        /// <summary>
        /// Obtiene la grilla de doble percepción (acción 'C1').
        /// </summary>
        public DataSet ObtenerGrillaDoblePercepcion(int per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaDoblePercepcion(per_id);
        }

        /// <summary>
        /// Obtiene un registro por ID (acción 'C3').
        /// </summary>
        public DataSet ObtenerDoblePercepcionX(int dp_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDoblePercepcionX(dp_id);
        }

        #endregion
    }
}
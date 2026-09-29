using System;
using System.Data;
using Solution_Framework_Kardex.DataAccessLayer;   // ⬅️ ESTE using es la clave

namespace Solution_Framework_Kardex.BussinessLogicLayer
{
    /// <summary>
    /// Clase de negocio para la gestión de la tabla tbl_declaracion_jurada.
    /// Sigue el mismo patrón que cls_cv_formacion y cls_persona.
    /// </summary>
    public class cls_declaracion_jurada
    {
        #region ATRIBUTOS
        private int _dj_id;
        private int _dj_persona_id;
        private DateTime _dj_fecha_inicio;
        private DateTime? _dj_fecha_fin;
        private int _dj_gestion;
        private string _dj_estado;
        private string _dj_usuario;
        private DateTime _dj_fecha_creacion;
        public int? dj_usuario_modificacion { get; set; }
        public DateTime? dj_fecha_modificacion { get; set; }
        #endregion

        #region CONSTRUCTOR
        public cls_declaracion_jurada() { }

        public cls_declaracion_jurada(
            int dj_id,
            int dj_persona_id,
            DateTime dj_fecha_inicio,
            DateTime? dj_fecha_fin,
            int dj_gestion,
            string dj_estado,
            string dj_usuario,
            DateTime dj_fecha_creacion)
        {
            _dj_id = dj_id;
            _dj_persona_id = dj_persona_id;
            _dj_fecha_inicio = dj_fecha_inicio;
            _dj_fecha_fin = dj_fecha_fin;
            _dj_gestion = dj_gestion;
            _dj_estado = dj_estado;
            _dj_usuario = dj_usuario;
            _dj_fecha_creacion = dj_fecha_creacion;
        }
        #endregion

        #region PROPIEDADES
        public int dj_id
        {
            get { return _dj_id; }
            set { _dj_id = value; }
        }

        public int dj_persona_id
        {
            get { return _dj_persona_id; }
            set { _dj_persona_id = value; }
        }

        public DateTime dj_fecha_inicio
        {
            get { return _dj_fecha_inicio; }
            set { _dj_fecha_inicio = value; }
        }

        public DateTime? dj_fecha_fin
        {
            get { return _dj_fecha_fin; }
            set { _dj_fecha_fin = value; }
        }

        public int dj_gestion
        {
            get { return _dj_gestion; }
            set { _dj_gestion = value; }
        }

        public string dj_estado
        {
            get { return _dj_estado; }
            set { _dj_estado = value; }
        }

        public string dj_usuario
        {
            get { return _dj_usuario; }
            set { _dj_usuario = value; }
        }

        public DateTime dj_fecha_creacion
        {
            get { return _dj_fecha_creacion; }
            set { _dj_fecha_creacion = value; }
        }
        #endregion

        #region METODOS

        /// <summary>
        /// Verifica si existe una declaración jurada vigente para la gestión indicada.
        /// </summary>
        public bool ExisteDeclaracionJurada(int persona_id, int gestion)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ExisteDeclaracionJurada(persona_id, gestion);
        }

        /// <summary>
        /// Adiciona una nueva declaración jurada.
        /// </summary>
        public bool Adicionar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Adicionar_DeclaracionJurada(this);
        }

        /// <summary>
        /// Obtiene la declaración jurada activa del funcionario.
        /// </summary>
        public DataSet ObtenerDeclaracionJuradaActiva(int persona_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDeclaracionJuradaActiva(persona_id);
        }

        /// <summary>
        /// Finaliza una declaración jurada (actualiza estado y fecha_fin).
        /// </summary>
        public bool FinalizarDeclaracionJurada(int dj_id, int usuario_modificacion)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.FinalizarDeclaracionJurada(dj_id, usuario_modificacion);
        }

        /// <summary>
        /// Obtiene el estado ('V'=Vigente, 'F'=Finalizada) y datos de la declaración
        /// jurada para una persona y gestión específicas.
        /// Devuelve un DataSet vacío si no existe ninguna declaración.
        /// </summary>
        public DataSet ObtenerEstadoDeclaracionPorGestion(int persona_id, int gestion)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerEstadoDeclaracionPorGestion(persona_id, gestion);
        }

        public int ObtenerGestionActualDesdeServidor()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGestionActualDesdeServidor();
        }

        #endregion
    }
}
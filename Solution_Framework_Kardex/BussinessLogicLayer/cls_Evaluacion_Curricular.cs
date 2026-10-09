using System;
using System.Data;
using Solution_Framework_Kardex.DataAccessLayer;

namespace Solution_Framework_Kardex.BussinessLogicLayer
{
    public class cls_Evaluacion_Curricular
    {
        #region ATRIBUTOS
        private int _ev_id;
        private int _as_id;
        private int _dias_exp_esp;
        private int _dias_exp_gral;
        private int _ev_us_id;
        private int _formacion_id;
        private DateTime _cv_fecha;
        #endregion

        #region CONSTRUCTOR
        public cls_Evaluacion_Curricular() { }

        public cls_Evaluacion_Curricular(int ev_id, int as_id, int dias_exp_esp,
            int dias_exp_gral, int ev_us_id, int formacion_id, DateTime cv_fecha)
        {
            _ev_id = ev_id;
            _as_id = as_id;
            _dias_exp_esp = dias_exp_esp;
            _dias_exp_gral = dias_exp_gral;
            _ev_us_id = ev_us_id;
            _formacion_id = formacion_id;
            _cv_fecha = cv_fecha;
        }
        #endregion

        #region PROPIEDADES
        public int ev_id { get { return _ev_id; } set { _ev_id = value; } }
        public int as_id { get { return _as_id; } set { _as_id = value; } }
        public int dias_exp_esp { get { return _dias_exp_esp; } set { _dias_exp_esp = value; } }
        public int dias_exp_gral { get { return _dias_exp_gral; } set { _dias_exp_gral = value; } }
        public int ev_us_id { get { return _ev_us_id; } set { _ev_us_id = value; } }
        public int formacion_id { get { return _formacion_id; } set { _formacion_id = value; } }
        public DateTime cv_fecha { get { return _cv_fecha; } set { _cv_fecha = value; } }
        #endregion

        #region MÉTODOS CRUD
        public int Insertar(int asId, int diasEsp, int diasGral, int usuarioId, int? formacionId)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.InsertarEvaluacionCurricular(asId, diasEsp, diasGral, usuarioId, formacionId);
        }

        public bool InsertarDetalle(int evId, int cvExpId, string tipo)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.InsertarDetalleEvTipoExp(evId, cvExpId, tipo);
        }

        public bool Actualizar(int evId, int diasEsp, int diasGral, int usuarioId, int? formacionId)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarEvaluacionCurricular(evId, diasEsp, diasGral, usuarioId, formacionId);
        }

        public bool Eliminar(int evId, bool completo)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarEvaluacionCurricular(evId, completo);
        }
        #endregion

        #region CONSULTAS
        public DataSet ObtenerEvaluacionCurricular(int perId, int cargoId)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerEvaluacionCurricular(perId, cargoId);
        }

        public DataSet ObtenerAsignacionVigente(int perId)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerAsignacionVigente(perId);
        }

        public DataSet ObtenerPorId(int evId)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerEvaluacionPorId(evId);
        }

        public DataSet ObtenerPorAsignacion(int asId)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerEvaluacionPorAsignacion(asId);
        }

        public DataSet ObtenerFiltradas(int? evId, int? asId, int? usuarioId, int? formacionId)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerEvaluacionesFiltradas(evId, asId, usuarioId, formacionId);
        }

        public DataSet ObtenerCombo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerComboEvaluaciones();
        }
        #endregion

        #region LÓGICA DE NEGOCIO

        // ============================================================
        //  Clase de resultado (con propiedad Detalle agregada)
        // ============================================================
        public class ResultadoEvaluacionCurricular
        {
            public bool CumpleGeneral { get; set; }
            public bool CumpleEspecifica { get; set; }
            public bool CumpleTodo => CumpleGeneral && CumpleEspecifica;

            public int TotalGenAnios { get; set; }
            public int TotalGenMeses { get; set; }
            public int TotalGenDias { get; set; }
            public int TotalEspAnios { get; set; }
            public int TotalEspMeses { get; set; }
            public int TotalEspDias { get; set; }

            public int ReqGenAnios { get; set; }
            public int ReqEspAnios { get; set; }

            public string NombreCargo { get; set; }

            // ✅ PROPIEDAD DETALLE AGREGADA
            public string Detalle
            {
                get
                {
                    return "General: " + TotalGenAnios + "a " + TotalGenMeses + "m " + TotalGenDias + "d" +
                           " · Específica: " + TotalEspAnios + "a " + TotalEspMeses + "m " + TotalEspDias + "d" +
                           " · Requerido: " + ReqGenAnios + "a gen / " + ReqEspAnios + "a esp";
                }
            }
        }

        // ============================================================
        //  ✅ MÉTODO EvaluarCumplimiento AGREGADO
        // ============================================================
        public ResultadoEvaluacionCurricular EvaluarCumplimiento(int perId, int cargoId)
        {
            var r = new ResultadoEvaluacionCurricular();

            DataSet ds = ObtenerEvaluacionCurricular(perId, cargoId);
            if (ds == null || ds.Tables.Count < 5) return r;

            // ---- RS 2: Acumular duración de experiencias ----
            int tgA = 0, tgM = 0, tgD = 0;
            int teA = 0, teM = 0, teD = 0;

            foreach (DataRow row in ds.Tables[1].Rows)
            {
                if (row["cv_exp_fecha_inicio"] == DBNull.Value ||
                    row["cv_exp_fecha_fin"] == DBNull.Value) continue;

                DateTime ini = Convert.ToDateTime(row["cv_exp_fecha_inicio"]);
                DateTime fin = Convert.ToDateTime(row["cv_exp_fecha_fin"]);

                var dur = CalcularDuracionPeriodo(ini, fin);
                tgA += dur.Item1;
                tgM += dur.Item2;
                tgD += dur.Item3;

                bool esEsp = row.Table.Columns.Contains("especifica")
                          && row["especifica"] != DBNull.Value
                          && Convert.ToBoolean(row["especifica"]);

                if (esEsp)
                {
                    teA += dur.Item1;
                    teM += dur.Item2;
                    teD += dur.Item3;
                }
            }

            // Normalización
            tgM += tgD / 30; tgD = tgD % 30;
            tgA += tgM / 12; tgM = tgM % 12;

            teM += teD / 30; teD = teD % 30;
            teA += teM / 12; teM = teM % 12;

            r.TotalGenAnios = tgA; r.TotalGenMeses = tgM; r.TotalGenDias = tgD;
            r.TotalEspAnios = teA; r.TotalEspMeses = teM; r.TotalEspDias = teD;

            // ---- RS 3: Requisito automático (o RS 4 como fallback) ----
            DataRow req = null;
            if (ds.Tables[2].Rows.Count > 0 && ds.Tables[2].Rows[0]["rf_id"] != DBNull.Value)
                req = ds.Tables[2].Rows[0];

            if (req == null && ds.Tables[3].Rows.Count > 0)
                req = ds.Tables[3].Rows[0];

            if (req != null)
            {
                r.ReqGenAnios = Convert.ToInt32(req["rf_exp_gral"]);
                r.ReqEspAnios = Convert.ToInt32(req["rf_exp_esp"]);
            }

            // ---- RS 5: Nombre del cargo ----
            if (ds.Tables[4].Rows.Count > 0)
            {
                r.NombreCargo = ds.Tables[4].Rows[0]["item_cargo"] != DBNull.Value
                              ? ds.Tables[4].Rows[0]["item_cargo"].ToString()
                              : "";
            }

            // ---- Comparar en días para precisión ----
            int totalGenDias = (tgA * 360) + (tgM * 30) + tgD;
            int totalEspDias = (teA * 360) + (teM * 30) + teD;
            int reqGenDias = r.ReqGenAnios * 360;
            int reqEspDias = r.ReqEspAnios * 360;

            r.CumpleGeneral = totalGenDias >= reqGenDias;
            r.CumpleEspecifica = totalEspDias >= reqEspDias;

            return r;
        }

        // ============================================================
        //  Cálculo de duración entre dos fechas
        // ============================================================
        public Tuple<int, int, int> CalcularDuracionPeriodo(DateTime ini, DateTime fin)
        {
            if (fin < ini) return Tuple.Create(0, 0, 0);

            int d = fin.Day - ini.Day;
            int m = fin.Month - ini.Month;
            int a = fin.Year - ini.Year;

            if (d < 0) { d += DateTime.DaysInMonth(ini.Year, ini.Month); m--; }
            if (m < 0) { m += 12; a--; }

            return Tuple.Create(a, m, d);
        }
        #endregion
    }
}
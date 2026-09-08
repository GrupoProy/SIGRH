using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Solution_Framework_Evaluacion.DataAccessLayer;


namespace Solution_Framework_Evaluacion.BussinessLogicLayer
{
    public class cls_FactoresEvaluacion
    {
        #region PROPIEDADES
        public int rfe_id { get; set; }
        public string factor { get; set; }
        public string descripcion { get; set; }
        #endregion
        #region METODOS
        public static DataSet Bind_FactoresEvaluacion(int ca_id, string filtro, int id_evaluacion)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.Bind_FactoresEvaluacion(ca_id, filtro, id_evaluacion);
        }
        public static DataSet Bind_FactoresEvaluacion_Ponderadores()
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.Bind_FactoresEvaluacion_Ponderadores();
        }
        public static int Registrar_FactoresEvaluacion(int id_evaluacion, int ci_id, int pond_id)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.Registrar_FactoresEvaluacion(id_evaluacion, ci_id, pond_id);
        }
        public static DataSet Bind_FactoresEvaluacion_Ponderadores_Respuestas(int id_evaluacion, int ci_id)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.Bind_FactoresEvaluacion_Ponderadores_Respuestas(id_evaluacion, ci_id);
        }
        public static DataSet ListarTareasRecurrentes(int id_evaluacion, string tipo)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.ListarTareasRecurrentes(id_evaluacion, tipo);
        }
        #endregion
    }
    }

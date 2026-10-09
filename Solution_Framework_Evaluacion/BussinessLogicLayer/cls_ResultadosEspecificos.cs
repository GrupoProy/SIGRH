using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Solution_Framework_Evaluacion.DataAccessLayer;

namespace Solution_Framework_Evaluacion.BussinessLogicLayer
{
    public class cls_ResultadosEspecificos
    {
        #region PROPIEDADES
        public int res_id { get; set; }
        public string res_descripcion { get; set; }
        #endregion
        #region METODOS
        public static DataSet Bind_ResultadosEspecificos(int ca_id, string filtro, int id_evaluacion)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.Bind_ResultadosEspecificos(ca_id, filtro, id_evaluacion);
        }
        public static DataSet Bind_ResultadosEspecificos_Clasificacion()
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.Bind_ResultadosEspecificos_Clasificacion();
        }
        public static DataSet Bind_ResultadosEspecificos_Ponderadores()
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.Bind_ResultadosEspecificos_Ponderadores();
        }
        public static DataSet Bind_ResultadosEspecificos_Ponderadores_Respuestas(int id_res, string filtro, string clasificador, int id_evaluacion)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.Bind_ResultadosEspecificos_Ponderadores_Respuestas(id_res, filtro, clasificador, id_evaluacion);
        }
        public static int Registrar_ResultadosEspecificos(int ca_id, int rres_id, int rres_id_evaluacion, int pr_id, string clasificador, int ponderador)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.Registrar_ResultadosEspecificos(ca_id, rres_id, rres_id_evaluacion,  pr_id, clasificador, ponderador);
        }
        public static int RespuestasEspecificasFactores(int id_evaluacion, string tabla)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.RespuestasEspecificasFactores(id_evaluacion, tabla);
        }
        #endregion
    }
}

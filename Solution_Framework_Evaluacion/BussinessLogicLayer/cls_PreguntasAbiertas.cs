using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Solution_Framework_Evaluacion.DataAccessLayer;
namespace Solution_Framework_Evaluacion.BussinessLogicLayer
{
    public class cls_PreguntasAbiertas
    {
        #region PROPIEDADES
        public int cat_id { get; set; }
        public int rpa_id { get; set; }
        public string descripcion { get; set; }
        public string rpa_respuesta { get; set; }
        #endregion
        #region METODOS
        public static int Registrar_PreguntasAbiertas(int rpa_id, int id_evaluacion, string respuesta)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.Registrar_PreguntasAbiertas(rpa_id, id_evaluacion, respuesta);
        }
        public static DataSet Bind_PreguntasAbiertas(int id_evaluacion)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.Bind_PreguntasAbiertas(id_evaluacion);
        }
        public static DataSet Bind_PreguntasAbiertas_Resupuestas(int id_evaluacion, int pa_id)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.Bind_PreguntasAbiertas_Respuestas(id_evaluacion, pa_id);
        }

        #endregion
    }
}

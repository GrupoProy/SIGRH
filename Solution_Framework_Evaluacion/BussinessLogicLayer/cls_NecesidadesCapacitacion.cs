using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Solution_Framework_Evaluacion.DataAccessLayer;


namespace Solution_Framework_Evaluacion.BussinessLogicLayer
{
    public class cls_NecesidadesCapacitacion
    {
        #region PROPIEDADES
        public int rdnc_id { get; set; }
        public int rdnc_id_dnc { get; set; }
        public int rdnc_id_evaluacion { get; set; }
        public string rdnc_respuesta { get; set; }
        #endregion
        #region METODOS
        public static DataSet Bind_Necesidades_Capacitacion_Respuestas(int id_evaluacion)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.Bind_Necesidades_Capacitacion_Respuestas(id_evaluacion);
        }
        public static DataSet Bind_Necesidades_Capacitacion()
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.Bind_Necesidades_Capacitacion();
        }
        public static int Registar_Dnc(int id, int id_dnc, int id_evaluacion, string respuesta)
        {
            {
                SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
                return dbLayer.Registar_Dnc(id, id_dnc, id_evaluacion, respuesta);
            }
        }
            #endregion
        }
    }

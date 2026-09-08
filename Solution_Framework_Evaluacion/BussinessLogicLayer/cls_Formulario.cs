using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Solution_Framework_Evaluacion.DataAccessLayer;

namespace Solution_Framework_Evaluacion.BussinessLogicLayer
{
    public class cls_Formulario
    {
        #region PROPIEDADES
        public int eva_id_evaluacion { get; set; }
        public byte[] eva_pdf { get; set; }
        #endregion
        #region METODOS
        public static int VerificarRespuestas_Evaluacion(int id_evaluacion, string tabla)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.VerificarRespuestas_Evaluacion(id_evaluacion, tabla);
        }
        public static DataSet GestionActual(string filtro,string tipo) {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.GestionActual(filtro, tipo);
        }
        public static DataSet FinalizarEvaluaciones(int pr_id, int periodo)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.FinalizarEvaluaciones(pr_id, periodo);
        }

        public static int Finalizar_Evaluacion(int id_evaluacion,string estado_evaluacion)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.Finalizar_Evaluacion(id_evaluacion, estado_evaluacion);
        }
        public static int Cerrar_Evaluacion(int id_evaluacion)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.Cerrar_Evaluacion(id_evaluacion);
        }
        public static int JustificarEvaluacion(int id_evaluacion, string justificacion)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.JustificarEvaluacion(id_evaluacion, justificacion);
        }
        public static DataSet ObtenerPdfInforme(int id_evaluacion)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.ObtenerPdfInforme(id_evaluacion);

        }
        public static DataSet ObtenerIdEvaluacionPdf(int per_id)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.ObtenerIdEvaluacionPdf(per_id);

        }

        public int devuelver_Si_hayPDF(int id_evaluacion)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.devuelver_Si_hayPDF(id_evaluacion);

        }
        public int UpdateTER_PDF(int id_evaluacion, byte[] eva_pdf)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.UpdateTER_PDF(id_evaluacion, eva_pdf);

        }
        #endregion
    }

}

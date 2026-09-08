using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Solution_Framework_Evaluacion.DataAccessLayer;

namespace Solution_Framework_Evaluacion.BussinessLogicLayer
{
    public class cls_Habilitados
    {
        #region PROPIEDADES
        public string tipo { get; set; }
        public int cod_fun { get; set; }
        public int cod_cargo { get; set; }
        public string tipo_item { get; set; }
        public string num_item { get; set; }
        public DateTime fecha_asignacion { get; set; }
        public DateTime fecha_baja { get; set; }
        public string estado { get; set; }
        public int meses { get; set; }
        public int ultimo_boleta { get; set; }
        public string cargo { get; set; }
        public string puesto { get; set; }
        public string unidad { get; set; }
        #endregion 
        #region METODOS
        public static DataSet ObtenerHabilitados(string busqueda, int gestion, int periodo, string tipo)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.ObtenerHabilitados(busqueda, gestion, periodo,tipo);
        }
        public static DataSet Insertar_Habilitados(int gestion, int periodo, int cod_fun, int cod_cargo, string tipo)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.Insertar_Habilitados(gestion, periodo, cod_fun, cod_cargo,tipo);
        }
        public static string VerificarHabilitacion(int cod_cargo)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.VerificarHabilitacion(cod_cargo);
        }
        public static DataSet TodasLasGestiones(int periodo)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.TodasLasGestiones(periodo);
        }
        public static int InhabilitarEvaluacionesAnteriores()
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.InhabilitarEvaluacionesAnteriores();
        }
        #endregion
        public static DataSet EvaluarSemestre(int periodo)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.EvaluarSemestre(periodo);
        }
        public static DataSet ActivarEvaluacionDesempenio(int valor, string tipo)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.ActivarEvaluacionDesempenio(valor,tipo);
        }
        public static DataSet AsignarEvaluadorDesempenio(string opcion, string tipo)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.AsignarEvaluadorDesempenio(opcion, tipo);
        }
        public static DataSet AsignarEvaluadorUnidadDesempenio(string opcion, int id_gestion, int id_periodo, int id_unidad, string tipo)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.AsignarEvaluadorUnidadDesempenio(opcion, id_gestion, id_periodo, id_unidad,  tipo);
        }
        public static DataSet SeguimientoEvaluacion(string opcion, int id_gestion, int id_periodo, string tipo)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.SeguimientoEvaluacion(opcion, id_gestion, id_periodo,  tipo);
        }
        public static DataSet SeguimientoEvaluacionItem(string opcion, int id_gestion, int id_periodo, int id_unidad, string tipo)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.SeguimientoEvaluacionItem(opcion, id_gestion, id_periodo,id_unidad,  tipo);
        }
        public static DataSet EvaluacionActiva(string tipo)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.EvaluacionActiva(tipo);
        }
        public static DataSet ParametrosEvaluacionActiva(string tipo)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.ParametrosEvaluacionActiva(tipo);
        }
        public static DataSet EvaluadoresHabilitados(string opcion, int id_gestion, int id_periodo, int id_cargo, string tipo)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.EvaluadoresHabilitados(opcion, id_gestion, id_periodo, id_cargo, tipo);
        }
        public static int EvaluadorAsignado(string opcion, int id_gestion, int id_periodo, int id_evaluacion, int id_cargo, string tipo)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.EvaluadorAsignado(opcion, id_gestion, id_periodo, id_evaluacion, id_cargo, tipo);
        }
        public static DataSet HistorialEvaluaciones(string opcion, string tipo)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.HistorialEvaluaciones(opcion, tipo);
        }
        public static DataSet HistorialEvaluacionesDetalle(string opcion, int id_gestion, int id_periodo, string tipo)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.HistorialEvaluacionesDetalle(opcion, id_gestion, id_periodo, tipo);
        }
        
        public static DataSet SeguimientoEvaluacionTotal(string opcion, int id_gestion, int id_periodo, string tipo)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.SeguimientoEvaluacionTotal(opcion, id_gestion, id_periodo, tipo);
        }
        public static int CerrarEvaluacionTotal(string opcion, int id_gestion, int id_periodo, string tipo)
        {
            SQLDataAccessLayer dbLayer = new SQLDataAccessLayer();
            return dbLayer.CerrarEvaluacionTotal(opcion, id_gestion, id_periodo, tipo);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Solution_Framework_Evaluacion.BussinessLogicLayer;


namespace Solution_Framework_Evaluacion.DataAccessLayer
{
    public abstract class DataAccessLayer
    {
        #region CONEXIÓN
        public Database Siev = DatabaseFactory.CreateDatabase("SIEV");  //conexión a la base de datos del Sistema de Evaluación del Desempeño
        //public Database Personal = DatabaseFactory.CreateDatabase("CnxPersonal");  //conexión a la base de datos Personal
                                                                                   //public Database General = DatabaseFactory.CreateDatabase("General");//conexión a la base de datos General
        #endregion

        #region HABILITACIÓN DE FUNCIONARIOS
        public abstract DataSet ObtenerHabilitados(string busqueda, int gestion, int periodo, string tipo);
        public abstract DataSet Insertar_Habilitados(int gestion, int periodo, int cod_fun, int cod_cargo,string tipo);
        public abstract string VerificarHabilitacion(int cod_cargo);
        public abstract DataSet TodasLasGestiones(int periodo);
        public abstract int InhabilitarEvaluacionesAnteriores();
        public abstract DataSet EvaluarSemestre(int periodo);
        public abstract DataSet ActivarEvaluacionDesempenio(int valor, string tipo);
        public abstract DataSet AsignarEvaluadorDesempenio(string opcion, string tipo);
        public abstract DataSet AsignarEvaluadorUnidadDesempenio(string opcion, int id_gestion, int id_periodo, int id_unidad, string tipo);
        public abstract DataSet SeguimientoEvaluacion(string opcion, int id_gestion, int id_periodo, string tipo);
        public abstract DataSet SeguimientoEvaluacionTotal(string opcion, int id_gestion, int id_periodo, string tipo);
        public abstract DataSet SeguimientoEvaluacionItem(string opcion, int id_gestion, int id_periodo, int id_unidad, string tipo);
        public abstract DataSet EvaluacionActiva(string tipo);
        public abstract DataSet ParametrosEvaluacionActiva(string tipo);
        public abstract DataSet EvaluadoresHabilitados(string opcion, int id_gestion, int id_periodo, int id_cargo, string tipo);
        public abstract int EvaluadorAsignado(string opcion, int id_gestion, int id_periodo, int id_evaluacion, int id_cargo, string tipo);
        public abstract int CerrarEvaluacionTotal(string opcion, int id_gestion, int id_periodo, string tipo);
        public abstract int JustificarEvaluacion(int id_evaluacion, string justificacion);
        public abstract DataSet ObtenerPdfInforme(int id_evaluacion);
        public abstract DataSet ObtenerIdEvaluacionPdf(int per_id);
        //==================================== AGREGAR PDF ======================== 
        public abstract int UpdateTER_PDF(int id_evaluacion, byte[] eva_pdf);
        public abstract int devuelver_Si_hayPDF(int id_evaluacion);
        #endregion

        #region GESTIÓN
        public abstract DataSet GestionActual(string filtro,string tipo);
        #endregion
        #region DATOS PERSONALES
        public abstract DataSet FuncionarioDatosPersonales(int per_id, int periodo, string tipo);
        public abstract DataSet FuncionarioDatosPersonalesEvaluador(int per_id, int periodo, string tipo);
        //public abstract DataSet BuscarIdDescriptor(int descrip_pu_id);
        //public abstract DataSet BuscarTareasDescriptor(int descrip_pu_id, string tipo);
        //public abstract int MigrarEspecificas(int descrip_pu_id, string tipo);
        //public abstract int RegistrarIdCargoDescriptor(int descrip_pu_id, int ca_id);
        #endregion
        #region PERSONAL A EVALUAR
        public abstract DataSet FuncionariosDependientes(int per_id, string unidad, int pr_id, int periodo, string tipo, int ca_id_evaluador);



        #endregion
        #region FORMULARIO
        #region RESULTADOS_ESPECIFICOS
        public abstract DataSet Bind_ResultadosEspecificos(int ca_id, string filtro, int id_evaluacion);
        public abstract DataSet Bind_ResultadosEspecificos_Clasificacion();
        public abstract DataSet Bind_ResultadosEspecificos_Ponderadores();
        public abstract DataSet Bind_ResultadosEspecificos_Ponderadores_Respuestas(int id_res, string filtro, string clasificador, int id_evaluacion);
        public abstract int Registrar_ResultadosEspecificos(int ca_id, int rres_id, int rres_id_evaluacion, int pr_id, string clasificador, int ponderador);
        public abstract int RespuestasEspecificasFactores(int id_evaluacion, string tabla);
        #endregion
        #region FACTORES_EVALUACION
        public abstract DataSet Bind_FactoresEvaluacion(int ca_id, string filtro, int id_evaluacion);
        public abstract DataSet Bind_FactoresEvaluacion_Ponderadores();
        public abstract int Registrar_FactoresEvaluacion(int id_evaluacion, int ci_id, int pond_id);
        public abstract DataSet Bind_FactoresEvaluacion_Ponderadores_Respuestas(int id_evaluacion, int ci_id);
        public abstract DataSet ListarTareasRecurrentes(int id_evaluacion, string tipo);
        #endregion
        #region PREGUNTAS ABIERTAS
        public abstract int Registrar_PreguntasAbiertas(int rpa_id, int id_evaluacion, string respuesta);
        public abstract DataSet Bind_PreguntasAbiertas_Respuestas(int id_evaluacion, int pa_id);
        public abstract DataSet Bind_PreguntasAbiertas(int id_evaluacion);
        #region NECESIDADES DE CAPACITACIÓN
        public abstract DataSet Bind_Necesidades_Capacitacion();
        public abstract DataSet Bind_Necesidades_Capacitacion_Respuestas(int id_evaluacion);
        public abstract int Registar_Dnc(int id, int id_dnc, int id_evaluacion, string respuesta);
        #endregion
        #endregion
        #endregion
        #region VERIFICACIÓN
        public abstract int VerificarRespuestas_Evaluacion(int id_evaluacion, string tabla);
        #endregion
        #region FINALIZAR EVALUACION 
        public abstract DataSet FinalizarEvaluaciones(int pr_id, int periodo);
        #endregion

        #region FINALIZAR EVALUACION DEL LISTADO 
        public abstract int Finalizar_Evaluacion(int id_evaluacion,string estado_evaluacions);
        #endregion

        #region CERRAR EVALUACION (ADM) 
        public abstract int Cerrar_Evaluacion(int id_evaluacion);
        #endregion
        #region HISTORIAL
        public abstract DataSet HistorialEvaluaciones(string opcion, string tipo);
        public abstract DataSet HistorialEvaluacionesDetalle(string opcion, int id_gestion, int id_periodo, string tipo);


        #endregion
    }
}

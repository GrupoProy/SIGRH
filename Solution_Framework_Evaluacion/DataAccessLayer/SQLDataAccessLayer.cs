using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using Solution_Framework_Evaluacion.DataAccessLayer;
using Solution_Framework_Evaluacion.BussinessLogicLayer;

namespace Solution_Framework_Evaluacion.DataAccessLayer
{
    public class SQLDataAccessLayer:DataAccessLayer
    {
        #region HABILITACIÓN DE FUNCIONARIOS
        public override int InhabilitarEvaluacionesAnteriores()
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_InhabilitarEvaluacionesAnteriores");
            return (Siev.ExecuteNonQuery(SP));
        }
        public override DataSet ObtenerHabilitados(string busqueda, int gestion, int periodo, string tipo)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_CargarInsumo_Habilitacion");
            Siev.AddInParameter(SP, "busqueda", DbType.String, busqueda);
            Siev.AddInParameter(SP, "p_pr_id", DbType.Int32, gestion);
            Siev.AddInParameter(SP, "p_periodo", DbType.Int32, periodo);
            Siev.AddInParameter(SP, "p_tipo", DbType.String, tipo);
            return (Siev.ExecuteDataSet(SP));
        }
        public override DataSet Insertar_Habilitados(int gestion, int periodo, int cod_fun, int cod_cargo, string tipo)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_RegistrarHabilitados");
            Siev.AddInParameter(SP, "gestion", DbType.Int32, gestion);
            Siev.AddInParameter(SP, "periodo", DbType.Int32, periodo);
            Siev.AddInParameter(SP, "cod_fun", DbType.Int32, cod_fun);
            Siev.AddInParameter(SP, "cod_cargo", DbType.Int32, cod_cargo);
            Siev.AddInParameter(SP, "tipo", DbType.String, tipo);
            return (Siev.ExecuteDataSet(SP));
        }
        public override string VerificarHabilitacion(int cod_cargo)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_VerificarHabilitación");
            Siev.AddInParameter(SP, "cod_cargo", DbType.Int32, cod_cargo);
            return Convert.ToString((Siev.ExecuteScalar(SP)));
        }
        public override DataSet ActivarEvaluacionDesempenio(int valor,string tipo)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_ActivarEvaluacionDesempenio");
            Siev.AddInParameter(SP, "valor", DbType.Int32, valor);
            Siev.AddInParameter(SP, "tipo", DbType.String, tipo);
            return (Siev.ExecuteDataSet(SP));
        }
        public override DataSet AsignarEvaluadorDesempenio(string opcion, string tipo)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_AsignarEvaluador");
            Siev.AddInParameter(SP, "opcion", DbType.String, opcion);
            Siev.AddInParameter(SP, "id_gestion", DbType.Int32, 0);
            Siev.AddInParameter(SP, "id_periodo", DbType.Int32, 0);
            Siev.AddInParameter(SP, "id_eo", DbType.Int32, 0);
            Siev.AddInParameter(SP, "id_ca", DbType.Int32, 0);
            Siev.AddInParameter(SP, "tipo_evaluador", DbType.Int32, 0);
            Siev.AddInParameter(SP, "tipo_evaluacion", DbType.String, tipo);
            return (Siev.ExecuteDataSet(SP));
        }
        public override DataSet AsignarEvaluadorUnidadDesempenio(string opcion,int id_gestion, int id_periodo, int id_unidad, string tipo)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_AsignarEvaluador");
            Siev.AddInParameter(SP, "opcion", DbType.String, opcion);
            Siev.AddInParameter(SP, "id_gestion", DbType.Int32, id_gestion);
            Siev.AddInParameter(SP, "id_periodo", DbType.Int32, id_periodo);
            Siev.AddInParameter(SP, "id_eo", DbType.Int32, id_unidad);
            Siev.AddInParameter(SP, "id_ca", DbType.Int32, 0);
            Siev.AddInParameter(SP, "tipo_evaluador", DbType.Int32, 0);
            Siev.AddInParameter(SP, "tipo_evaluacion", DbType.String, tipo);
            return (Siev.ExecuteDataSet(SP));
        }
        public override DataSet SeguimientoEvaluacion(string opcion, int id_gestion, int id_periodo, string tipo)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_AsignarEvaluador");
            Siev.AddInParameter(SP, "opcion", DbType.String, opcion);
            Siev.AddInParameter(SP, "id_gestion", DbType.Int32, id_gestion);
            Siev.AddInParameter(SP, "id_periodo", DbType.Int32, id_periodo);
            Siev.AddInParameter(SP, "id_eo", DbType.Int32, 0);
            Siev.AddInParameter(SP, "id_ca", DbType.Int32, 0);
            Siev.AddInParameter(SP, "tipo_evaluador", DbType.Int32, 0);
            Siev.AddInParameter(SP, "tipo_evaluacion", DbType.String, tipo);
            return (Siev.ExecuteDataSet(SP));
        }
        public override DataSet SeguimientoEvaluacionTotal(string opcion, int id_gestion, int id_periodo, string tipo)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_AsignarEvaluador");
            Siev.AddInParameter(SP, "opcion", DbType.String, opcion);
            Siev.AddInParameter(SP, "id_gestion", DbType.Int32, id_gestion);
            Siev.AddInParameter(SP, "id_periodo", DbType.Int32, id_periodo);
            Siev.AddInParameter(SP, "id_eo", DbType.Int32, 0);
            Siev.AddInParameter(SP, "id_ca", DbType.Int32, 0);
            Siev.AddInParameter(SP, "tipo_evaluador", DbType.Int32, 0);
            Siev.AddInParameter(SP, "tipo_evaluacion", DbType.String, tipo);
            return (Siev.ExecuteDataSet(SP));
        }
        public override DataSet SeguimientoEvaluacionItem(string opcion, int id_gestion, int id_periodo, int id_unidad, string tipo)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_AsignarEvaluador");
            Siev.AddInParameter(SP, "opcion", DbType.String, opcion);
            Siev.AddInParameter(SP, "id_gestion", DbType.Int32, id_gestion);
            Siev.AddInParameter(SP, "id_periodo", DbType.Int32, id_periodo);
            Siev.AddInParameter(SP, "id_eo", DbType.Int32, id_unidad);
            Siev.AddInParameter(SP, "id_ca", DbType.Int32, 0);
            Siev.AddInParameter(SP, "tipo_evaluador", DbType.Int32, 0);
            Siev.AddInParameter(SP, "tipo_evaluacion", DbType.String, tipo);
            return (Siev.ExecuteDataSet(SP));
        }
        
        public override DataSet EvaluacionActiva(string tipo)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_activa");
            Siev.AddInParameter(SP, "tipo_evaluacion", DbType.String, tipo);
            return (Siev.ExecuteDataSet(SP));
        }
        public override DataSet ParametrosEvaluacionActiva(string tipo)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_EvaluacionActiva");
            Siev.AddInParameter(SP, "tipo", DbType.String, tipo);
            return (Siev.ExecuteDataSet(SP));
        }
        public override DataSet EvaluadoresHabilitados(string opcion, int id_gestion, int id_periodo, int id_cargo, string tipo)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_AsignarEvaluador");
            Siev.AddInParameter(SP, "opcion", DbType.String, opcion);
            Siev.AddInParameter(SP, "id_gestion", DbType.Int32, id_gestion);
            Siev.AddInParameter(SP, "id_periodo", DbType.Int32, id_periodo);
            Siev.AddInParameter(SP, "id_eo", DbType.Int32, 0);
            Siev.AddInParameter(SP, "id_ca", DbType.Int32, id_cargo);
            Siev.AddInParameter(SP, "tipo_evaluador", DbType.Int32, 0);
            Siev.AddInParameter(SP, "tipo_evaluacion", DbType.String, tipo);
            return (Siev.ExecuteDataSet(SP));
        }
        public override int EvaluadorAsignado(string opcion, int id_gestion, int id_periodo, int id_evaluacion, int id_cargo, string tipo)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_AsignarEvaluador");
            Siev.AddInParameter(SP, "opcion", DbType.String, opcion);
            Siev.AddInParameter(SP, "id_gestion", DbType.Int32, id_gestion);
            Siev.AddInParameter(SP, "id_periodo", DbType.Int32, id_periodo);
            Siev.AddInParameter(SP, "id_eo", DbType.Int32, id_evaluacion);
            Siev.AddInParameter(SP, "id_ca", DbType.Int32, id_cargo);
            Siev.AddInParameter(SP, "tipo_evaluador", DbType.Int32, 0);
            Siev.AddInParameter(SP, "tipo_evaluacion", DbType.String, tipo);
            return (Siev.ExecuteNonQuery(SP));
        }

        public override int CerrarEvaluacionTotal(string opcion, int id_gestion, int id_periodo, string tipo)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_CerrarEvaluacionGral");
            Siev.AddInParameter(SP, "opcion", DbType.String, opcion);
            Siev.AddInParameter(SP, "id_gestion", DbType.Int32, id_gestion);
            Siev.AddInParameter(SP, "id_periodo", DbType.Int32, id_periodo);
            Siev.AddInParameter(SP, "tipo_evaluacion", DbType.String, tipo);
            return (Siev.ExecuteNonQuery(SP));
        }
        public override int JustificarEvaluacion(int id_evaluacion, string justificacion)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_Bind_Formulario");
            Siev.AddInParameter(SP, "ca_id", DbType.Int32, 0);
            Siev.AddInParameter(SP, "filtro", DbType.String, "justificacion");
            Siev.AddInParameter(SP, "opcional", DbType.String, justificacion);
            Siev.AddInParameter(SP, "id_evaluacion", DbType.Int32, id_evaluacion);
            return (Siev.ExecuteNonQuery(SP));
        }
        public override DataSet ObtenerPdfInforme(int id_evaluacion)
        {
            try
            {
                DbCommand SP = Siev.GetStoredProcCommand("sp_ev_Bind_Formulario");
                Siev.AddInParameter(SP, "ca_id", DbType.Int32, 0);
                Siev.AddInParameter(SP, "filtro", DbType.String, "InformePdf");
                Siev.AddInParameter(SP, "opcional", DbType.String, "");
                Siev.AddInParameter(SP, "id_evaluacion", DbType.Int32, id_evaluacion);

                DataSet result = Siev.ExecuteDataSet(SP);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en ObtenerPdf: " + ex.Message, ex);
            }
        }
        public override DataSet ObtenerIdEvaluacionPdf(int per_id)
        {

                DbCommand SP = Siev.GetStoredProcCommand("sp_ev_Bind_Formulario");
                Siev.AddInParameter(SP, "ca_id", DbType.Int32, per_id);
                Siev.AddInParameter(SP, "filtro", DbType.String, "ObtenerIdEvaluacionPdf");
                Siev.AddInParameter(SP, "opcional", DbType.String, "");
                Siev.AddInParameter(SP, "id_evaluacion", DbType.Int32, 0);
                return (Siev.ExecuteDataSet(SP));

        }
        public override int devuelver_Si_hayPDF(int id_evaluacion)
        {
            try
            {
                DbCommand SP = Siev.GetStoredProcCommand("sp_ev_BindPdf");
                Siev.AddInParameter(SP, "filtro", DbType.String, "BuscaInformePdf");
                Siev.AddInParameter(SP, "id_evaluacion", DbType.Int32, id_evaluacion);
                Siev.AddInParameter(SP, "ca_id", DbType.Int32, 0);
                Siev.AddInParameter(SP, "pdf", DbType.Binary, null);

                return Convert.ToInt32(Siev.ExecuteScalar(SP));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //---------------------- AGREGAR PDF A EVALUACION---------------------
        public override int UpdateTER_PDF(int id_evaluacion, byte[] eva_pdf)
        {
            try
            {
                DbCommand SP = Siev.GetStoredProcCommand("sp_ev_BindPdf");
                Siev.AddInParameter(SP, "filtro", DbType.String, "CargarInformePdf");
                Siev.AddInParameter(SP, "id_evaluacion", DbType.Int32, id_evaluacion);
                Siev.AddInParameter(SP, "ca_id", DbType.Int32, 0);
                Siev.AddInParameter(SP, "pdf", DbType.Binary, eva_pdf);
                
                     //int id = Convert.ToInt32(CnxSigrh3.ExecuteScalar(icom).ToString());
                return Convert.ToInt32(Siev.ExecuteScalar(SP));
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion
        #region GESTIÓN
        public override DataSet TodasLasGestiones(int periodo)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_Gestiones");
            Siev.AddInParameter(SP, "periodo", DbType.Int32, periodo);
            return Siev.ExecuteDataSet(SP);
        }
        public override DataSet GestionActual(string filtro, string tipo)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_GestionActual");
            Siev.AddInParameter(SP, "filtro", DbType.String, filtro);
            Siev.AddInParameter(SP, "tipo", DbType.String, tipo);
            return Siev.ExecuteDataSet(SP);
        }
        public override DataSet EvaluarSemestre(int periodo)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_Evaluar_Semestre");
            Siev.AddInParameter(SP, "periodo", DbType.Int32, periodo);
            return Siev.ExecuteDataSet(SP);
        }
        #endregion
        #region DATOS PERSONALES
        public override DataSet FuncionarioDatosPersonales(int per_id, int periodo, string tipo)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_Evaluado_DatosPersonales");
            Siev.AddInParameter(SP, "per_id", DbType.Int32, per_id);
            Siev.AddInParameter(SP, "periodo", DbType.Int32, periodo);
            Siev.AddInParameter(SP, "tipo", DbType.String, tipo);
            return Siev.ExecuteDataSet(SP);
        }
        public override DataSet FuncionarioDatosPersonalesEvaluador(int per_id, int periodo, string tipo)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_Evaluador_DatosPersonales");
            Siev.AddInParameter(SP, "per_id", DbType.Int32, per_id);
            Siev.AddInParameter(SP, "periodo", DbType.Int32, periodo);
            Siev.AddInParameter(SP, "tipo", DbType.String, tipo);
            return Siev.ExecuteDataSet(SP);
        }
        //public override DataSet BuscarIdDescriptor(int descrip_pu_id)
        //{
        //    DbCommand SP = Siev.GetStoredProcCommand("sp_mp_asignacionDescriptor");
        //    Siev.AddInParameter(SP, "opcion", DbType.String, "C2");
        //    Siev.AddInParameter(SP, "id_ca", DbType.Int32, 0);
        //    Siev.AddInParameter(SP, "descrip_pu_id", DbType.Int32, descrip_pu_id);
        //    Siev.AddInParameter(SP, "puesto", DbType.String, "");
        //    Siev.AddInParameter(SP, "tipo_resultado", DbType.String, "");
        //    return Siev.ExecuteDataSet(SP);
        //}
        //public override DataSet BuscarTareasDescriptor(int descrip_pu_id, string tipo)
        //{
        //    DbCommand SP = Siev.GetStoredProcCommand("sp_mp_asignacionDescriptor");
        //    Siev.AddInParameter(SP, "opcion", DbType.String, "C3");
        //    Siev.AddInParameter(SP, "id_ca", DbType.Int32, 0);
        //    Siev.AddInParameter(SP, "descrip_pu_id", DbType.Int32, descrip_pu_id);
        //    Siev.AddInParameter(SP, "puesto", DbType.String, "");
        //    Siev.AddInParameter(SP, "tipo_resultado", DbType.String, tipo);
        //    return Siev.ExecuteDataSet(SP);
        //}
        //public override int MigrarEspecificas(int descrip_pu_id, string tipo)
        //{
        //    DbCommand SP = Siev.GetStoredProcCommand("sp_mp_asignacionDescriptor");
        //    Siev.AddInParameter(SP, "opcion", DbType.String, "C4");
        //    Siev.AddInParameter(SP, "id_ca", DbType.Int32, 0);
        //    Siev.AddInParameter(SP, "descrip_pu_id", DbType.Int32, descrip_pu_id);
        //    Siev.AddInParameter(SP, "puesto", DbType.String, "");
        //    Siev.AddInParameter(SP, "tipo_resultado", DbType.String, tipo);
        //    return (Siev.ExecuteNonQuery(SP));
        //}
        //public override int RegistrarIdCargoDescriptor(int descrip_pu_id, int ca_id)
        //{
        //    DbCommand SP = Siev.GetStoredProcCommand("sp_mp_asignacionDescriptor");
        //    Siev.AddInParameter(SP, "opcion", DbType.String, "C5");
        //    Siev.AddInParameter(SP, "id_ca", DbType.Int32, ca_id);
        //    Siev.AddInParameter(SP, "descrip_pu_id", DbType.Int32, descrip_pu_id);
        //    Siev.AddInParameter(SP, "puesto", DbType.String, "");
        //    Siev.AddInParameter(SP, "tipo_resultado", DbType.String, "");
        //    return (Siev.ExecuteNonQuery(SP));
        //}
        #endregion
        #region PERSONAL A EVALUAR
        public override DataSet FuncionariosDependientes(int per_id, string unidad, int pr_id, int periodo, string tipo, int ca_id_evaluador)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_Evaluador_Dependientes");
            Siev.AddInParameter(SP, "per_id", DbType.Int32, per_id);
            Siev.AddInParameter(SP, "unidad", DbType.String, unidad);
            Siev.AddInParameter(SP, "pr_id", DbType.Int32, pr_id);
            Siev.AddInParameter(SP, "periodo", DbType.Int32, periodo);
            Siev.AddInParameter(SP, "tipo", DbType.String, tipo);
            Siev.AddInParameter(SP, "ca_id", DbType.Int32, ca_id_evaluador);
            return Siev.ExecuteDataSet(SP);
        }

        //(int )
        #endregion
        #region FORMULARIO
        #region RESULTADOS_ESPECIFICOS
        public override DataSet Bind_ResultadosEspecificos(int ca_id, string filtro, int id_evaluacion)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_Bind_Formulario");
            Siev.AddInParameter(SP, "ca_id", DbType.Int32,  ca_id);
            Siev.AddInParameter(SP, "filtro", DbType.String, filtro);
            Siev.AddInParameter(SP, "opcional", DbType.String, 0);
            Siev.AddInParameter(SP, "id_evaluacion", DbType.Int32, id_evaluacion);
            return Siev.ExecuteDataSet(SP);
        }
        public override DataSet Bind_ResultadosEspecificos_Clasificacion()
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_Bind_Formulario");
            Siev.AddInParameter(SP, "ca_id", DbType.Int32, 0);
            Siev.AddInParameter(SP, "filtro", DbType.String, "ResultadosEspecificos_Clasificacion");
            Siev.AddInParameter(SP, "opcional", DbType.String, 0);
            Siev.AddInParameter(SP, "id_evaluacion", DbType.Int32, 0);
            return Siev.ExecuteDataSet(SP);
        }
        public override DataSet Bind_ResultadosEspecificos_Ponderadores()
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_Bind_Formulario");
            Siev.AddInParameter(SP, "ca_id", DbType.Int32,0);
            Siev.AddInParameter(SP, "filtro", DbType.String, "ResultadosEspecificos_Ponderadores");
            Siev.AddInParameter(SP, "opcional", DbType.String, 0);
            Siev.AddInParameter(SP, "id_evaluacion", DbType.Int32, 0);
            return Siev.ExecuteDataSet(SP);
        }
        public override DataSet Bind_ResultadosEspecificos_Ponderadores_Respuestas(int id_res, string filtro, string clasificador, int id_evaluacion)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_Bind_Formulario");
            Siev.AddInParameter(SP, "ca_id", DbType.Int32, id_res);
            Siev.AddInParameter(SP, "filtro", DbType.String, "ResultadosEspecificos_Ponderadores_Respuestas");
            Siev.AddInParameter(SP, "opcional", DbType.String, clasificador);
            Siev.AddInParameter(SP, "id_evaluacion", DbType.Int32, id_evaluacion);
            return Siev.ExecuteDataSet(SP);
        }

        public override int Registrar_ResultadosEspecificos(int ca_id, int rres_id, int rres_id_evaluacion, int pr_id, string clasificador, int ponderador)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_Registrar_ResultadosEspecificos");
            Siev.AddInParameter(SP, "ca_id", DbType.Int32, ca_id);
            Siev.AddInParameter(SP, "rres_id", DbType.Int32, rres_id);
            Siev.AddInParameter(SP, "rres_id_evaluacion", DbType.Int32, rres_id_evaluacion);
            Siev.AddInParameter(SP, "pr_id", DbType.Int32,  pr_id);
            Siev.AddInParameter(SP, "clasificador", DbType.String, clasificador);
            Siev.AddInParameter(SP, "ponderador", DbType.Int32, ponderador);
            return Siev.ExecuteNonQuery(SP);
        }
        public override int RespuestasEspecificasFactores(int id_evaluacion, string tabla)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_VerificarEvaluacion");
            Siev.AddInParameter(SP, "id_evaluacion", DbType.Int32, id_evaluacion);
            Siev.AddInParameter(SP, "tabla", DbType.String, tabla);
            return Convert.ToInt32(Siev.ExecuteDataSet(SP).Tables[0].Rows[0][0].ToString());
        }
        #endregion

        #region FACTORES_EVALUACION
        public override DataSet Bind_FactoresEvaluacion(int ca_id, string filtro, int id_evaluacion)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_Bind_Formulario");
            Siev.AddInParameter(SP, "ca_id", DbType.Int32, ca_id);
            Siev.AddInParameter(SP, "filtro", DbType.String, filtro);
            Siev.AddInParameter(SP, "opcional", DbType.String, 0);
            Siev.AddInParameter(SP, "id_evaluacion", DbType.Int32, id_evaluacion);
            return Siev.ExecuteDataSet(SP);
        }
        public override DataSet Bind_FactoresEvaluacion_Ponderadores()
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_Bind_Formulario");
            Siev.AddInParameter(SP, "ca_id", DbType.Int32, 0);
            Siev.AddInParameter(SP, "filtro", DbType.String, "FactoresEvaluacion_Ponderadores");
            Siev.AddInParameter(SP, "opcional", DbType.String, 0);
            Siev.AddInParameter(SP, "id_evaluacion", DbType.Int32, 0);
            return Siev.ExecuteDataSet(SP);
        }
        public override int Registrar_FactoresEvaluacion(int id_evaluacion, int ci_id, int pond_id)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_Registrar_FactoresEvaluacion");
            Siev.AddInParameter(SP, "id_evaluacion", DbType.Int32, id_evaluacion);
            Siev.AddInParameter(SP, "ci_id", DbType.String, ci_id);
            Siev.AddInParameter(SP, "pond_id", DbType.String, pond_id);
            return Siev.ExecuteNonQuery(SP);
        }
        public override DataSet Bind_FactoresEvaluacion_Ponderadores_Respuestas(int id_evaluacion, int ci_id)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_Bind_Formulario");
            Siev.AddInParameter(SP, "ca_id", DbType.Int32, id_evaluacion);
            Siev.AddInParameter(SP, "filtro", DbType.String, "FactoresEvaluacion_Ponderadores_Respuestas");
            Siev.AddInParameter(SP, "opcional", DbType.String, ci_id);
            Siev.AddInParameter(SP, "id_evaluacion", DbType.Int32, 0);
            return Siev.ExecuteDataSet(SP);
        }
        public override DataSet ListarTareasRecurrentes(int id_evaluacion, string tipo)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_ListarTareasRecurrentes");
            Siev.AddInParameter(SP, "id_evaluacion", DbType.Int32, id_evaluacion);
            Siev.AddInParameter(SP, "tipo_evaluacion", DbType.String, tipo);
            return Siev.ExecuteDataSet(SP);
        }
        
        #endregion

        #region PREGUNTAS ABIERTAS
        public override int Registrar_PreguntasAbiertas(int rpa_id, int id_evaluacion, string respuesta)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_Registrar_PreguntasAbiertas");
            Siev.AddInParameter(SP, "pa_id", DbType.Int32, rpa_id);
            Siev.AddInParameter(SP, "id_evaluacion", DbType.Int32, id_evaluacion);
            Siev.AddInParameter(SP, "respuesta", DbType.String, respuesta);
            return Siev.ExecuteNonQuery(SP);
        }
        public override DataSet Bind_PreguntasAbiertas_Respuestas(int id_evaluacion, int pa_id)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_Bind_Formulario");
            Siev.AddInParameter(SP, "ca_id", DbType.Int32, id_evaluacion);
            Siev.AddInParameter(SP, "filtro", DbType.String, "Preguntas_Abiertas_Respuestas");
            Siev.AddInParameter(SP, "opcional", DbType.String, pa_id);
            Siev.AddInParameter(SP, "id_evaluacion", DbType.Int32, 0);
            return Siev.ExecuteDataSet(SP);
        }
        public override DataSet Bind_PreguntasAbiertas(int id_evaluacion)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_Bind_Formulario");
            Siev.AddInParameter(SP, "ca_id", DbType.Int32, id_evaluacion);
            Siev.AddInParameter(SP, "filtro", DbType.String, "Preguntas_Abiertas");
            Siev.AddInParameter(SP, "opcional", DbType.String, "");
            Siev.AddInParameter(SP, "id_evaluacion", DbType.Int32, 0);
            return Siev.ExecuteDataSet(SP);
        }
        #endregion
        #region NECESIDADES DE CAPACITACION
        public override DataSet Bind_Necesidades_Capacitacion()
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_Bind_Formulario");
            Siev.AddInParameter(SP, "ca_id", DbType.Int32, 0);
            Siev.AddInParameter(SP, "filtro", DbType.String, "Necesidades_Capacitacion");
            Siev.AddInParameter(SP, "opcional", DbType.String, "");
            Siev.AddInParameter(SP, "id_evaluacion", DbType.Int32, 0);
            return Siev.ExecuteDataSet(SP);
        }
        public override DataSet Bind_Necesidades_Capacitacion_Respuestas(int id_evaluacion)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_Bind_Formulario");
            Siev.AddInParameter(SP, "ca_id", DbType.Int32, id_evaluacion);
            Siev.AddInParameter(SP, "filtro", DbType.String, "Necesidades_Capacitacion_Respuestas");
            Siev.AddInParameter(SP, "opcional", DbType.String, "");
            Siev.AddInParameter(SP, "id_evaluacion", DbType.Int32, 0);
            return Siev.ExecuteDataSet(SP);
        }
        public override int Registar_Dnc(int id, int id_dnc, int id_evaluacion, string respuesta)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_RegistrarDnc");
            Siev.AddInParameter(SP, "rdnc_id", DbType.Int32, id);
            Siev.AddInParameter(SP, "id_dnc", DbType.Int32, id_dnc);
            Siev.AddInParameter(SP, "id_evaluacion", DbType.Int32, id_evaluacion);
            Siev.AddInParameter(SP, "respuesta", DbType.String, respuesta);
            return Siev.ExecuteNonQuery(SP);
        }
        #endregion
        #region VERIFICACIÓN
        public override int VerificarRespuestas_Evaluacion(int id_evaluacion, string tabla)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_VerificarEvaluacion");
            Siev.AddInParameter(SP, "id_evaluacion", DbType.Int32, id_evaluacion);
            Siev.AddInParameter(SP, "tabla", DbType.String, tabla);
            return Convert.ToInt32(Siev.ExecuteDataSet(SP).Tables[0].Rows[0][0].ToString());
        }
        #endregion

        #region FINALIZAR EVALUACION
        public override DataSet FinalizarEvaluaciones(int pr_id, int periodo)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_cargar_funcionarios_evafin");
            Siev.AddInParameter(SP, "pr_id", DbType.Int32, pr_id);
            Siev.AddInParameter(SP, "periodo", DbType.Int32, periodo);
            return Siev.ExecuteDataSet(SP);
        }
        #endregion

        #region FINALIZAR EVALUACION DEL LISTADO 
        public override int Finalizar_Evaluacion(int id_evaluacion, string estado_evaluacion)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_Finalizar_Evaluacion");
            Siev.AddInParameter(SP, "id_evaluacion", DbType.Int32, id_evaluacion); 
            Siev.AddInParameter(SP, "estado_evaluacion", DbType.String, estado_evaluacion);

            return (Siev.ExecuteNonQuery(SP));
        }

        #endregion

        #region CERRAR EVALUACION (ADM)
        public override int Cerrar_Evaluacion(int id_evaluacion)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_Cerrar_Evaluacion");
            Siev.AddInParameter(SP, "id_evaluacion", DbType.Int32, id_evaluacion);
            return (Siev.ExecuteNonQuery(SP));
        }
        #endregion
        #endregion
        #region HISTORIAL
        public override DataSet HistorialEvaluaciones(string opcion, string tipo)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_AsignarEvaluador");
            Siev.AddInParameter(SP, "opcion", DbType.String, opcion);
            Siev.AddInParameter(SP, "id_gestion", DbType.Int32, 0);
            Siev.AddInParameter(SP, "id_periodo", DbType.Int32, 0);
            Siev.AddInParameter(SP, "id_eo", DbType.Int32, 0);
            Siev.AddInParameter(SP, "id_ca", DbType.Int32, 0);
            Siev.AddInParameter(SP, "tipo_evaluador", DbType.Int32, 0);
            Siev.AddInParameter(SP, "tipo_evaluacion", DbType.String, tipo);
            return (Siev.ExecuteDataSet(SP));
        }
        public override DataSet HistorialEvaluacionesDetalle(string opcion, int id_gestion, int id_periodo, string tipo)
        {
            DbCommand SP = Siev.GetStoredProcCommand("sp_ev_AsignarEvaluador");
            Siev.AddInParameter(SP, "opcion", DbType.String, opcion);
            Siev.AddInParameter(SP, "id_gestion", DbType.Int32, id_gestion);
            Siev.AddInParameter(SP, "id_periodo", DbType.Int32, id_periodo);
            Siev.AddInParameter(SP, "id_eo", DbType.Int32, 0);
            Siev.AddInParameter(SP, "id_ca", DbType.Int32, 0);
            Siev.AddInParameter(SP, "tipo_evaluador", DbType.Int32, 0);
            Siev.AddInParameter(SP, "tipo_evaluacion", DbType.String, tipo);
            return (Siev.ExecuteDataSet(SP));
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

using Solution_Framework_ControlPersonal.BussinessLogicLayer;

namespace Solution_Framework_ControlPersonal.DataAccessLayer
{
    public abstract class DataAccessLayerDataAccessLayer
    {
        #region INSTANCIA PRINCIPAL DE CONEXION A UNA BD
        public Database CNXSIGRH3 = DatabaseFactory.CreateDatabase("CnxSigrh3");
        #endregion

        // INTERFACES
        #region _CP_CONTROLES_PERSONAL
        public abstract bool Adicionar__cp_controles_personal(cls_cp_controles_personal _cp_controles_personal);
        public abstract bool Actualizar__cp_controles_personal(cls_cp_controles_personal _cp_controles_personal);
        public abstract bool Eliminar__cp_controles_personal(cls_cp_controles_personal _cp_controles_personal);
        public abstract bool ObtenerId__cp_controles_personal(cls_cp_controles_personal _cp_controles_personal);
        public abstract bool ObtenerRegistro__cp_controles_personal(cls_cp_controles_personal _cp_controles_personal);
        public abstract DataSet ObtenerTablaGrilla__cp_controles_personal(string cp_id,
                        string cp_per_id,
                        string cp_edificio,
                        string cp_fecha_inicio,
                        string cp_fecha_final,
                        string cp_estado);
        public abstract DataSet ObtenerTablaCombo__cp_controles_personal();

        //(JQC)
        public abstract DataSet ListarGrillaEdificio(cls_cp_controles_personal _cp_controles_personal);
        public abstract DataSet ListarFiltradoEdificio(cls_cp_controles_personal _cp_controles_personal);
        public abstract DataSet ObtieneAsignacionEdicioX(cls_cp_controles_personal _cp_controles_personal);
        public abstract bool AdicionarFechaBaja(cls_cp_controles_personal _cp_controles_personal);
        public abstract DataSet ListarFiltradoEdificioEditar(cls_cp_controles_personal _cp_controles_personal);

        #endregion

        #region _CP_CIERRE_MENSUAL
        public abstract bool Adicionar__cp_cierre_mensual(cls_cp_cierre_mensual _cp_cierre_mensual);
        public abstract bool Actualizar__cp_cierre_mensual(cls_cp_cierre_mensual _cp_cierre_mensual);
        public abstract bool Eliminar__cp_cierre_mensual(cls_cp_cierre_mensual _cp_cierre_mensual);
        public abstract bool ObtenerId__cp_cierre_mensual(cls_cp_cierre_mensual _cp_cierre_mensual);
        public abstract DataSet ObtenerRegistro__cp_cierre_mensual(cls_cp_cierre_mensual _cp_cierre_mensual);
        public abstract DataSet ObtenerTablaGrilla__cp_cierre_mensual(
            string cm_id,
            string cm_fecha_inicio,
            string cm_fecha_final,
            string cm_estado);
        public abstract DataSet ObtenerTablaCombo__cp_cierre_mensual();
        #endregion

        #region _CP_SANCIONES_REL_CIERRE
        public abstract bool Adicionar__cp_sanciones_rel_cierre(cls_cp_sanciones_rel_cierre _cp_sanciones_rel_cierre);
        public abstract bool Actualizar__cp_sanciones_rel_cierre(cls_cp_sanciones_rel_cierre _cp_sanciones_rel_cierre);
        public abstract bool Eliminar__cp_sanciones_rel_cierre(cls_cp_sanciones_rel_cierre _cp_sanciones_rel_cierre);
        public abstract DataSet ObtenerRegistro__cp_sanciones_rel_cierre(cls_cp_sanciones_rel_cierre _cp_sanciones_rel_cierre);
        public abstract DataSet ObtenerTablaGrilla__cp_sanciones_rel_cierre(
            string src_sa_id,
            string src_cp_id,
            string src_cm_id,
            string src_fecha_ejecucion);
        public abstract DataSet ObtenerTablaCombo__cp_sanciones_rel_cierre();
        #endregion

        #region _CP_SANCIONES
        public abstract int UpdateFaltas(int per_id, string fecha_ini, string fecha_fin);
        public abstract bool Adicionar__cp_sanciones(cls_cp_sanciones _cp_sanciones);
        public abstract bool Adicionar__cp_sanciones_faltasDocentes(cls_cp_sanciones _cp_sanciones);
        public abstract bool Actualizar__cp_sanciones(cls_cp_sanciones _cp_sanciones);
        public abstract bool Eliminar__cp_sanciones(cls_cp_sanciones _cp_sanciones);
        public abstract bool ObtenerId__cp_sanciones(cls_cp_sanciones _cp_sanciones);
        public abstract DataSet ObtenerRegistro__cp_sanciones(cls_cp_sanciones _cp_sanciones);
        public abstract DataSet ObtenerTablaGrilla__cp_sanciones(
            string sa_id,
            string sa_per_id,
            string sa_factor,
            string sa_minutos,
            string sa_fecha_inicio,
            string sa_fecha_fin,
            string sa_tipo_sancion,
            string sa_dias_sancion,
            string sa_estado);
        public abstract DataSet ObtenerTablaCombo__cp_sanciones();
        // (Kevin Carlos Prado Bustillos)
        public abstract DataSet ObtenerTablaGrillaC__cp_sanciones(
            //string cp_da,
            //string cp_ue,
            //string cp_programa,
            //string cp_proyecto,
            //string cp_actividad,
            string sa_per_id,
            string per_num_doc,
            string per_ap_paterno,
            string per_ap_materno,
            string per_nombres,
            string ps_id);
        // (Kevin Carlos Prado Bustillos)
        public abstract DataSet ObtenerRegistroDS__cp_sanciones(cls_cp_sanciones _cp_sanciones);
        public abstract bool ActualizarRegistroSanciones(cls_cp_sanciones _cp_sanciones);
        public abstract DataSet ListarAsignacionesParaSancion(int per_id);
        public abstract DataSet ListarMesesParaSancion();
        #endregion

        #region _CP_ASIGNACION_HORARIO
        public abstract bool Actualizar__cp_asignacion_horario(cls_cp_asignacion_horario _cp_asignacion_horario);
        public abstract bool Eliminar__cp_asignacion_horario(cls_cp_asignacion_horario _cp_asignacion_horario);
        public abstract DataSet ObtenerTablaGrilla__cp_asignacion_horario(
            string ah_id,
            string ah_per_id,
            string ah_tipo_horario,
            string ah_fecha_inicial,
            string ah_fecha_final,
            string ah_lun_ing1,
            string ah_lun_sal1,
            string ah_lun_ing2,
            string ah_lun_sal2,
            string ah_mar_ing1,
            string ah_mar_sal1,
            string ah_mar_ing2,
            string ah_mar_sal2,
            string ah_mie_ing1,
            string ah_mie_sal1,
            string ah_mie_ing2,
            string ah_mie_sal2,
            string ah_jue_ing1,
            string ah_jue_sal1,
            string ah_jue_ing2,
            string ah_jue_sal2,
            string ah_vie_ing1,
            string ah_vie_sal1,
            string ah_vie_ing2,
            string ah_vie_sal2,
            string ah_sab_ing1,
            string ah_sab_sal1,
            string ah_sab_ing2,
            string ah_sab_sal2,
            string ah_dom_ing1,
            string ah_dom_sal1,
            string ah_dom_ing2,
            string ah_dom_sal2,
            string ah_json,
            string ah_estado);
        // (Kevin Carlos Prado Bustillos) Lista de todos los registros de la tabla
        public abstract DataSet ObtenerTablaGrillaC__cp_asignacion_horario(
            string ah_id,
            string ah_per_id,
            string ah_tipo_horario,
            string ah_fecha_inicial,
            string ah_fecha_final,
            string ah_estado);
        // (Kevin Carlos Prado Bustillos) Genera un calendario para horarios
        public abstract DataSet ObtenerTablaGrillaCH__cp_asignacion_horario(
            string tds_per_id,
            string tds_fecha_inicial,
            string tds_fecha_final);
        // (Kevin Carlos Prado Bustillos) Genera el horario que se mostrará en el calendario
        public abstract bool GenerarHorario__cp_asignacion_horario(
            string th_per_id,
            string th_ing1,
            string th_sal1,
            string th_ing2,
            string th_sal2,
            string th_tipo,
            string th_tipo_semana,
            string th_tipo_dia,
            string th_lunes,
            string th_martes,
            string th_miercoles,
            string th_jueves,
            string th_viernes,
            string th_sabado,
            string th_domingo,
            string th_tipo_p,
            string th_tipo_t1,
            string th_tipo_t2);
        // (Kevin Carlos Prado Bustillos) Obtiene todos los datos de horario para mostrar en la grilla
        public abstract DataSet ObtenerTablaGrillaHC__cp_asignacion_horario(
            string th_per_id,
            string th_semana,
            string th_dia);
        // (Kevin Carlos Prado Bustillos) Elimina todos los datos del calendario
        public abstract bool EliminarCH__cp_asignacion_horario(cls_cp_asignacion_horario _cp_asignacion_horario);
        // (Kevin Carlos Prado Bustillos) Elimina todos los datos de horario para mostrar en la grilla
        public abstract bool EliminarHC__cp_asignacion_horario(cls_cp_asignacion_horario _cp_asignacion_horario);
        // (Kevin Carlos Prado Bustillos) Adicionar los datos del horario que se encuentra en el calendario (grilla)
        public abstract bool AdicionarHC__cp_asignacion_horario(cls_cp_asignacion_horario _cp_asignacion_horario);
        // (Kevin Carlos Prado Bustillos) Modifica el horario que se mostrará en el calendario
        public abstract bool ModificarHC__cp_asignacion_horario(
            string th_per_id,
            string th_semana,
            string th_dia,
            string th_ing1,
            string th_sal1,
            string th_ing2,
            string th_sal2,
            string th_tipo_p,
            string th_tipo_t1,
            string th_tipo_t2);
        // (Kevin Carlos Prado Bustillos) Genera el horario que se mostrará en el calendario según rango de fechas
        public abstract bool ObtenerTablaGrillaVM__cp_asignacion_horario(
            string ah_per_id,
            string ah_fecha_inicial,
            string ah_fecha_final);
        // (Kevin Carlos Prado Bustillos) Obtener todos los registros según rango de fechas para mostrar el horario
        public abstract DataSet ObtenerTablaGrillaFH__cp_asignacion_horario(
            string ah_per_id,
            string ah_fecha_inicial,
            string ah_fecha_final);
        /**********************************************************************/
        /******************** MÉTODOS PROCESAMIENTO MASIVO ********************/
        /**********************************************************************/
        // (Kevin Carlos Prado Bustillos) Obtener todos los registros para llenar una grilla
        public abstract DataSet ObtenerTablaGrillaUFI__cp_asignacion_horario(
            string prma_id,
            string prma_tipo,
            string prma_descripcion,
            string prma_ei_id,
            string prma_ti_id,
            string prma_usuario);
        // (Kevin Carlos Prado Bustillos) Adicionar datos del edificio
        public abstract bool AdicionarEI__cp_asignacion_horario(cls_cp_asignacion_horario _cp_asignacion_horario);
        // (Kevin Carlos Prado Bustillos) Adicionar datos de los edificios (según el tipo item)
        public abstract bool AdicionarIEI__cp_asignacion_horario(cls_cp_asignacion_horario _cp_asignacion_horario);
        // (Kevin Carlos Prado Bustillos) Eliminar datos del edificio, funcionario o tipo ítem (seleccionado o todos)
        public abstract bool EliminarEIDFTI__cp_asignacion_horario(
            string prma_id,
            string prma_tipo,
            string prma_ei_id,
            string prma_ti_id,
            string prma_usuario);
        // (Kevin Carlos Prado Bustillos) LLenar datos de todos los edificios
        public abstract bool LLenarEI__cp_asignacion_horario(cls_cp_asignacion_horario _cp_asignacion_horario);
        // (Kevin Carlos Prado Bustillos) Adicionar datos del funcionario
        public abstract bool AdicionarDF__cp_asignacion_horario(cls_cp_asignacion_horario _cp_asignacion_horario);
        // (Kevin Carlos Prado Bustillos) Adicionar datos de los funcionario (según el edificio)
        public abstract bool AdicionarEDF__cp_asignacion_horario(cls_cp_asignacion_horario _cp_asignacion_horario);
        // (Kevin Carlos Prado Bustillos) Llenar datos de todos los funcionarios
        public abstract bool LlenarDF__cp_asignacion_horario(cls_cp_asignacion_horario _cp_asignacion_horario);
        // (Kevin Carlos Prado Bustillos) Adicionar datos del tipo de ítem
        public abstract bool AdicionarTI__cp_asignacion_horario(cls_cp_asignacion_horario _cp_asignacion_horario);
        // (Kevin Carlos Prado Bustillos) Llenar datos de todos los tipo de ítem
        public abstract DataSet LlenarTI__cp_asignacion_horario(cls_cp_asignacion_horario _cp_asignacion_horario);
        // (Kevin Carlos Prado Bustillos) Adiciona los datos del horario especial para cada funcionario (masivo)
        public abstract bool AdicionarHEM__cp_asignacion_horario(cls_cp_asignacion_horario _cp_asignacion_horario);
        // (Kevin Carlos Prado Bustillos) Adiciona los datos del horario que se encuentra en el calendario (grilla) para cada funcionario (masivo)
        public abstract bool AdicionarHCM__cp_asignacion_horario(cls_cp_asignacion_horario _cp_asignacion_horario);
        // (Kevin Carlos Prado Bustillos) Adiciona los datos de la licencia justificada para cada funcionario (masivo)
        public abstract DataSet AdicionarLJM__cp_asignacion_horario(cls_cp_asignacion_horario _cp_asignacion_horario);
        #endregion

        #region _CP_MARCACIONES
        public abstract bool Adicionar__cp_marcaciones(cls_cp_marcaciones _cp_marcaciones);
        public abstract bool Actualizar__cp_marcaciones(cls_cp_marcaciones _cp_marcaciones);
        public abstract bool Eliminar__cp_marcaciones(cls_cp_marcaciones _cp_marcaciones);
        public abstract bool ObtenerId__cp_marcaciones(cls_cp_marcaciones _cp_marcaciones);
        public abstract DataSet ObtenerRegistro__cp_marcaciones(cls_cp_marcaciones _cp_marcaciones);
        public abstract DataSet ObtenerTablaGrilla__cp_marcaciones(
            string ma_id,
            string ma_per_id,
            string ma_fecha,
            string ma_di_id,
            string ma_hora,
            string ma_estado,
            string ma_tipo);
        public abstract DataSet ObtenerTablaCombo__cp_marcaciones();
        // (Kevin Carlos Prado Bustillos)
        public abstract DataSet ObtenerTablaGrillaM__cp_marcaciones(cls_cp_marcaciones _cp_marcaciones);
        #endregion

        #region _CP_UBICACION_FISICA
        public abstract bool Adicionar__cp_ubicacion_fisica(cls_cp_ubicacion_fisica _cp_ubicacion_fisica);
        public abstract bool Actualizar__cp_ubicacion_fisica(cls_cp_ubicacion_fisica _cp_ubicacion_fisica);
        public abstract bool Eliminar__cp_ubicacion_fisica(cls_cp_ubicacion_fisica _cp_ubicacion_fisica);
        public abstract DataSet ObtenerRegistro__cp_ubicacion_fisica(cls_cp_ubicacion_fisica _cp_ubicacion_fisica);
        public abstract DataSet ObtenerTablaGrilla__cp_ubicacion_fisica(
            string uf_id,
            string uf_per_id,
            string uf_edificio,
            string uf_piso,
            string uf_bloque,
            string uf_telefono_interno,
            string uf_telefono_oficina,
            string uf_nombre_oficina,
            string uf_fecha_inicio,
            string uf_fecha_final,
            string uf_estado);
        public abstract DataSet ObtenerTablaCombo__cp_ubicacion_fisica();
        // (Kevin Carlos Prado Bustillos) Obtiene todos los registros de la tabla
        public abstract DataSet ObtenerTablaGrillaC__cp_ubicacion_fisica(
            string uf_id,
            string uf_per_id,
            string uf_edificio,
            string uf_piso,
            string uf_bloque,
            string uf_telefono_interno,
            string uf_telefono_oficina,
            string uf_nombre_oficina,
            string uf_fecha_inicio,
            string uf_fecha_final,
            string uf_estado);
        #endregion

        #region _CP_LICENCIA_JUSTIFICADA
        public abstract int Adicionar__cp_licencia_justificada(cls_cp_licencia_justificada _cp_licencia_justificada);
        public abstract bool Actualizar__cp_licencia_justificada(cls_cp_licencia_justificada _cp_licencia_justificada);
        public abstract int Eliminar__cp_licencia_justificada(cls_cp_licencia_justificada _cp_licencia_justificada);
        public abstract DataSet ObtenerRegistro__cp_licencia_justificada(cls_cp_licencia_justificada _cp_licencia_justificada);
        public abstract DataSet ObtenerTablaGrilla__cp_licencia_justificada(
            string lj_id,
            string lj_per_id,
            string lj_tipo_licencia,
            string lj_fecha_inicial,
            string lj_fecha_final,
            string lj_fecha_emision,
            string lj_hora_salida,
            string lj_hora_retorno,
            string lj_motivo,
            string lj_lugar,
            string lj_per_id_autoriza,
            string lj_estado);
        public abstract DataSet ObtenerTablaCombo__cp_licencia_justificada();
        // (Kevin Carlos Prado Bustillos) Obtiene todos los registros de la tabla para llenar una grilla
        public abstract DataSet ObtenerTablaGrillaC__cp_licencia_justificada(
            string lj_id,
            string lj_per_id,
            string per_num_doc,
            string per_ap_paterno,
            string per_ap_materno,
            string per_nombres,
            string lj_tipo_licencia,
            string lj_fecha_inicial,
            string lj_fecha_final,
            string lj_estado);
        public abstract DataSet ObtenerTablaGrillaC__VALIDAR_COMISION(
            string lj_id,
            string lj_per_id,
            string per_num_doc,
            string per_ap_paterno,
            string per_ap_materno,
            string per_nombres,
            string lj_tipo_licencia,
            string lj_fecha_inicial,
            string lj_fecha_final,
            string lj_estado);
        // (Kevin Carlos Prado Bustillos) Lista de inmediatos superiores
        public abstract DataSet ObtenerTablaComboIS__cp_licencia_justificada(cls_cp_licencia_justificada _cp_licencia_justificada);
        // (JQC)
        public abstract bool AdicionarLicenciaVacacion(cls_cp_licencia_justificada _cp_licencia_justificada);
        // (Kevin Carlos Prado Bustillos) Obtiene todos los registros de la tabla (licencias y suspensión sin goce de haberes)
        public abstract DataSet ObtenerTablaGrillaLS__cp_licencia_justificada();
        // (Kevin Carlos Prado Bustillos) Modificación de licencia / suspensión sin goce de haberes, bajas médicas
        public abstract bool ActualizarLSBM__cp_licencia_justificada(cls_cp_licencia_justificada _cp_licencia_justificada);
        public abstract DataSet ObtenerRegistroFun(cls_cp_licencia_justificada _cp_licencia_justificada);
        public abstract DataSet ObtenerLicenciasSGHFun(cls_cp_licencia_justificada _cp_licencia_justificada);
        // (Kevin Carlos Prado Bustillos) Obtiene todos los registros de la tabla (bajas médicas)
        public abstract DataSet ObtenerTablaGrillaBM__cp_licencia_justificada(
            string lj_per_id,
            string per_num_doc,
            string per_ap_paterno,
            string per_ap_materno,
            string per_nombres);
        //// (Kevin Carlos Prado Bustillos) Obtiene todos los registros de la tabla (validación licencias)
        //public abstract DataSet ObtenerTablaGrillaVLJ__cp_licencia_justificada(
        //    string lj_id,
        //    string lj_per_id,
        //    string per_num_doc,
        //    string per_ap_paterno,
        //    string per_ap_materno,
        //    string per_nombres,
        //    string lj_estado);
        public abstract DataSet VerificarSiCorrespondeBoletaComision(int per_id);
        public abstract DataSet AutoridadesParaValidarComisiones();
        public abstract DataSet Grilla_ComisionesSolicitadas(int autoridad_per_id);
        public abstract bool GenerarAsistencia_UpdateFaltas___LicenciasJustificadas(int per_id, string fecha_inicio, string fecha_fin);
        public abstract DataSet ObtenerSaldoLicencia(int perId, int tipoLicencia);
        #endregion

        #region Aprobar_comision
        public abstract bool ActualizarLC(int codigoComisionInput);
        #endregion

        public abstract DataSet MesAsistencia();
        public abstract DataSet ListarFuncAsis(string lista);
        public abstract DataSet ListarPorFecha(string tipo, string mes);
        public abstract bool Procesar(string lista_per_id, string fecha1, string fecha2);
        public abstract DataSet BuscarFuncionario(string ci);
        public abstract DataSet cargarDestino();
        public abstract DataSet cargarCategoria(string destino);
        public abstract bool LlenarGridViatico(int per_id, int ev_id, string tipo_cambio, string fecha1, string fecha2, int as_id, string monto_curso, string objeto, string dias);
        public abstract DataSet LlenarGridPlanillaViatico();
        public abstract bool Eliminar(int ev_id);
        public abstract bool ProcesarPlanillaViatico(int nro_planilla, int us_id);
        public abstract DataSet NroPlanillaCombo(int pr_id);
        public abstract bool EnviarEncuesta(int per_id, int op1, int op2, int op3, int op4);
        public abstract DataSet LlenarListaViatico();
        public abstract DataSet CargarInfoPlanilla(int nro_pla);
        public abstract int ReprobarPlanilla(int nro_pla);
        public abstract DataSet cargarMeses();
        public abstract DataSet LlenarViaticosMes(int mes);
        public abstract int ObtenerDiasViatico(string fecha1, string fecha2);
        public abstract decimal puntaje_evaluacion(int per_id);
    }
}


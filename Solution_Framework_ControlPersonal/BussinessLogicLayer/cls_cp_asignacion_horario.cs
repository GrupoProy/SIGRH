using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_ControlPersonal.DataAccessLayer;

namespace Solution_Framework_ControlPersonal.BussinessLogicLayer
{
    /// <summary>
    /// Proporciona funcionalidad para manejo de tbl_cp_asignacion_horario.
    /// </summary>
    public class cls_cp_asignacion_horario
    {
        #region PROPIEDADES
        public int ah_id { get; set; }
        public int ah_per_id { get; set; }
        public int ah_tipo_horario { get; set; }
        public DateTime ah_fecha_inicial { get; set; }
        public DateTime ah_fecha_final { get; set; }
        public DateTime ah_lun_ing1 { get; set; }
        public DateTime ah_lun_sal1 { get; set; }
        public DateTime ah_lun_ing2 { get; set; }
        public DateTime ah_lun_sal2 { get; set; }
        public DateTime ah_mar_ing1 { get; set; }
        public DateTime ah_mar_sal1 { get; set; }
        public DateTime ah_mar_ing2 { get; set; }
        public DateTime ah_mar_sal2 { get; set; }
        public DateTime ah_mie_ing1 { get; set; }
        public DateTime ah_mie_sal1 { get; set; }
        public DateTime ah_mie_ing2 { get; set; }
        public DateTime ah_mie_sal2 { get; set; }
        public DateTime ah_jue_ing1 { get; set; }
        public DateTime ah_jue_sal1 { get; set; }
        public DateTime ah_jue_ing2 { get; set; }
        public DateTime ah_jue_sal2 { get; set; }
        public DateTime ah_vie_ing1 { get; set; }
        public DateTime ah_vie_sal1 { get; set; }
        public DateTime ah_vie_ing2 { get; set; }
        public DateTime ah_vie_sal2 { get; set; }
        public DateTime ah_sab_ing1 { get; set; }
        public DateTime ah_sab_sal1 { get; set; }
        public DateTime ah_sab_ing2 { get; set; }
        public DateTime ah_sab_sal2 { get; set; }
        public DateTime ah_dom_ing1 { get; set; }
        public DateTime ah_dom_sal1 { get; set; }
        public DateTime ah_dom_ing2 { get; set; }
        public DateTime ah_dom_sal2 { get; set; }
        public string ah_autorizado { get; set; }
        public string ah_json { get; set; }
        public string ah_estado { get; set; }
        // (Kevin Carlos Prado Bustillos) Procesamiento Masivo
        public int prma_id { get; set; }
        public string prma_tipo { get; set; }
        public string prma_descripcion { get; set; }
        public int prma_ei_id { get; set; }
        public string prma_ti_id { get; set; }
        public int prma_usuario { get; set; }
        // (Kevin Carlos Prado Bustillos) Horario Especial
        public string he_tipo_marc { get; set; }
        public string he_autoriza { get; set; }
        public string he_documento { get; set; }
        public string he_descripcion { get; set; }
        public DateTime he_ing1 { get; set; }
        public DateTime he_sal1 { get; set; }
        public DateTime he_ing2 { get; set; }
        public DateTime he_sal2 { get; set; }
        // (Kevin Carlos Prado Bustillos) Licencias
        public int lj_tipo_licencia { get; set; }
        public string lj_tipo_funcionario { get; set; }
        public DateTime lj_hora_salida { get; set; }
        public DateTime lj_hora_retorno { get; set; }
        public string lj_motivo { get; set; }
        public string lj_lugar { get; set; }
        public string lj_per_id_autoriza { get; set; }
        // (Kevin Carlos Prado Bustillos) Glosa
        public DateTime gl_fecha_doc { get; set; }
        public int gl_tipo_doc { get; set; }
        public string gl_glosa { get; set; }
        public string gl_numero_doc { get; set; }
        public int gl_usuario { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que actualiza datos en la tabla tbl_cp_asignacion_horario
        /// </summary>
        public bool Actualizar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Actualizar__cp_asignacion_horario(this);
        }

        /// <summary>
        /// Método que elimina datos en la tabla tbl_cp_asignacion_horario
        /// </summary>
        public bool Eliminar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Eliminar__cp_asignacion_horario(this);
        }

        /// <summary>
        /// Método que obtiene la tabla tbl_cp_asignacion_horario para llenar una grilla
        /// </summary>
        /// <param name="ah_id">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_per_id">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_tipo_horario">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_fecha_inicial">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_fecha_final">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_lun_ing1">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_lun_sal1">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_lun_ing2">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_lun_sal2">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_mar_ing1">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_mar_sal1">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_mar_ing2">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_mar_sal2">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_mie_ing1">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_mie_sal1">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_mie_ing2">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_mie_sal2">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_jue_ing1">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_jue_sal1">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_jue_ing2">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_jue_sal2">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_vie_ing1">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_vie_sal1">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_vie_ing2">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_vie_sal2">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_sab_ing1">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_sab_sal1">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_sab_ing2">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_sab_sal2">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_dom_ing1">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_dom_sal1">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_dom_ing2">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_dom_sal2">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_json">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ah_estado">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        public DataSet ObtenerTablaGrilla(
            string p_ah_id,
            string p_ah_per_id,
            string p_ah_tipo_horario,
            string p_ah_fecha_inicial,
            string p_ah_fecha_final,
            string p_ah_lun_ing1,
            string p_ah_lun_sal1,
            string p_ah_lun_ing2,
            string p_ah_lun_sal2,
            string p_ah_mar_ing1,
            string p_ah_mar_sal1,
            string p_ah_mar_ing2,
            string p_ah_mar_sal2,
            string p_ah_mie_ing1,
            string p_ah_mie_sal1,
            string p_ah_mie_ing2,
            string p_ah_mie_sal2,
            string p_ah_jue_ing1,
            string p_ah_jue_sal1,
            string p_ah_jue_ing2,
            string p_ah_jue_sal2,
            string p_ah_vie_ing1,
            string p_ah_vie_sal1,
            string p_ah_vie_ing2,
            string p_ah_vie_sal2,
            string p_ah_sab_ing1,
            string p_ah_sab_sal1,
            string p_ah_sab_ing2,
            string p_ah_sab_sal2,
            string p_ah_dom_ing1,
            string p_ah_dom_sal1,
            string p_ah_dom_ing2,
            string p_ah_dom_sal2,
            string p_ah_json,
            string p_ah_estado)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrilla__cp_asignacion_horario(p_ah_id, p_ah_per_id, p_ah_tipo_horario, p_ah_fecha_inicial, p_ah_fecha_final, p_ah_lun_ing1, p_ah_lun_sal1, p_ah_lun_ing2, p_ah_lun_sal2, p_ah_mar_ing1, p_ah_mar_sal1, p_ah_mar_ing2, p_ah_mar_sal2, p_ah_mie_ing1, p_ah_mie_sal1, p_ah_mie_ing2, p_ah_mie_sal2, p_ah_jue_ing1, p_ah_jue_sal1, p_ah_jue_ing2, p_ah_jue_sal2, p_ah_vie_ing1, p_ah_vie_sal1, p_ah_vie_ing2, p_ah_vie_sal2, p_ah_sab_ing1, p_ah_sab_sal1, p_ah_sab_ing2, p_ah_sab_sal2, p_ah_dom_ing1, p_ah_dom_sal1, p_ah_dom_ing2, p_ah_dom_sal2, p_ah_json, p_ah_estado);
        }

        // (Kevin Carlos Prado Bustillos) Lista de todos los registros de la tabla
        public DataSet ObtenerTablaGrillaC(
            string p_ah_id,
            string p_ah_per_id,
            string p_ah_tipo_horario,
            string p_ah_fecha_inicial,
            string p_ah_fecha_final,
            string p_ah_estado)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrillaC__cp_asignacion_horario(p_ah_id, p_ah_per_id, p_ah_tipo_horario, p_ah_fecha_inicial, p_ah_fecha_final, p_ah_estado);
        }

        // (Kevin Carlos Prado Bustillos) Genera un calendario para horarios
        public DataSet ObtenerTablaGrillaCH(
            string p_tds_per_id,
            string p_tds_fecha_inicial,
            string p_tds_fecha_final)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrillaCH__cp_asignacion_horario(p_tds_per_id, p_tds_fecha_inicial, p_tds_fecha_final);
        }

        // (Kevin Carlos Prado Bustillos) Genera el horario que se mostrará en el calendario
        public bool GenerarHorario(
            string p_th_per_id,
            string p_th_ing1,
            string p_th_sal1,
            string p_th_ing2,
            string p_th_sal2,
            string p_th_tipo,
            string p_th_tipo_semana,
            string p_th_tipo_dia,
            string p_th_lunes,
            string p_th_martes,
            string p_th_miercoles,
            string p_th_jueves,
            string p_th_viernes,
            string p_th_sabado,
            string p_th_domingo,
            string p_th_tipo_p,
            string p_th_tipo_t1,
            string p_th_tipo_t2)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.GenerarHorario__cp_asignacion_horario(p_th_per_id, p_th_ing1, p_th_sal1, p_th_ing2, p_th_sal2, p_th_tipo, p_th_tipo_semana, p_th_tipo_dia, p_th_lunes, p_th_martes, p_th_miercoles, p_th_jueves, p_th_viernes, p_th_sabado, p_th_domingo, p_th_tipo_p, p_th_tipo_t1, p_th_tipo_t2);
        }

        // (Kevin Carlos Prado Bustillos) Obtiene todos los datos de horario para mostrar en la grilla
        public DataSet ObtenerTablaGrillaHC(
            string p_th_per_id,
            string p_th_semana,
            string p_th_dia)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrillaHC__cp_asignacion_horario(p_th_per_id, p_th_semana, p_th_dia);
        }

        // (Kevin Carlos Prado Bustillos) Elimina todos los datos del calendario
        public bool EliminarCH()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarCH__cp_asignacion_horario(this);
        }

        // (Kevin Carlos Prado Bustillos) Elimina todos los datos de horario para mostrar en la grilla
        public bool EliminarHC()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarHC__cp_asignacion_horario(this);
        }

        //(Kevin Carlos Prado Bustillos) Adicionar los datos del horario que se encuentra en el calendario (grilla)
        public bool AdicionarHC()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarHC__cp_asignacion_horario(this);
        }
        // (Kevin Carlos Prado Bustillos) Modifica el horario que se mostrará en el calendario
        public bool ModificarHC(
            string p_th_per_id,
            string p_th_semana,
            string p_th_dia,
            string p_th_ing1,
            string p_th_sal1,
            string p_th_ing2,
            string p_th_sal2,
            string p_th_tipo_p,
            string p_th_tipo_t1,
            string p_th_tipo_t2)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ModificarHC__cp_asignacion_horario(p_th_per_id, p_th_semana, p_th_dia, p_th_ing1, p_th_sal1, p_th_ing2, p_th_sal2, p_th_tipo_p, p_th_tipo_t1, p_th_tipo_t2);
        }
        // (Kevin Carlos Prado Bustillos) Genera el horario que se mostrará en el calendario según rango de fechas
        public bool ObtenerTablaGrillaVM(
            string p_ah_per_id,
            string p_ah_fecha_inicial,
            string p_ah_fecha_final)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrillaVM__cp_asignacion_horario(p_ah_per_id, p_ah_fecha_inicial, p_ah_fecha_final);
        }
        // (Kevin Carlos Prado Bustillos) Obtener todos los registros según rango de fechas para mostrar el horario
        public DataSet ObtenerTablaGrillaFH(
            string p_ah_per_id,
            string p_ah_fecha_inicial,
            string p_ah_fecha_final)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrillaFH__cp_asignacion_horario(p_ah_per_id, p_ah_fecha_inicial, p_ah_fecha_final);
        }
        /**********************************************************************/
        /******************** MÉTODOS PROCESAMIENTO MASIVO ********************/
        /**********************************************************************/
        // (Kevin Carlos Prado Bustillos) Obtener todos los registros para llenar una grilla
        public DataSet ObtenerTablaGrillaUFI(
            string p_prma_id,
            string p_prma_tipo,
            string p_prma_descripcion,
            string p_prma_ei_id,
            string p_prma_ti_id,
            string p_prma_usuario)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrillaUFI__cp_asignacion_horario(p_prma_id, p_prma_tipo, p_prma_descripcion, p_prma_ei_id, p_prma_ti_id, p_prma_usuario);
        }
        // (Kevin Carlos Prado Bustillos) Adicionar datos del edificio
        public bool AdicionarEI()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarEI__cp_asignacion_horario(this);
        }
        // (Kevin Carlos Prado Bustillos) Adicionar datos de los edificios (según el tipo item)
        public bool AdicionarIEI()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarIEI__cp_asignacion_horario(this);
        }
        // (Kevin Carlos Prado Bustillos) Eliminar datos del edificio, funcionario o tipo ítem (seleccionado o todos)
        public bool EliminarEIDFTI(
            string p_prma_id,
            string p_prma_tipo,
            string p_prma_ei_id,
            string p_prma_ti_id,
            string p_prma_usuario)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarEIDFTI__cp_asignacion_horario(p_prma_id, p_prma_tipo, p_prma_ei_id, p_prma_ti_id, p_prma_usuario);
        }
        // (Kevin Carlos Prado Bustillos) LLenar datos de todos los edificios
        public bool LLenarEI()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.LLenarEI__cp_asignacion_horario(this);
        }
        // (Kevin Carlos Prado Bustillos) Adicionar datos del funcionario
        public bool AdicionarDF()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarDF__cp_asignacion_horario(this);
        }
        // (Kevin Carlos Prado Bustillos) Adicionar datos de los funcionario (según el edificio)
        public bool AdicionarEDF()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarEDF__cp_asignacion_horario(this);
        }
        // (Kevin Carlos Prado Bustillos) Llenar datos de todos los funcionarios
        public bool LLenarDF()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.LlenarDF__cp_asignacion_horario(this);
        }
        // (Kevin Carlos Prado Bustillos) Adicionar datos del tipo de ítem
        public bool AdicionarTI()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarTI__cp_asignacion_horario(this);
        }
        // (Kevin Carlos Prado Bustillos) Llenar datos de todos los tipo de ítem
        public DataSet LLenarTI()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.LlenarTI__cp_asignacion_horario(this);
        }
        // (Kevin Carlos Prado Bustillos) Adiciona los datos del horario especial para cada funcionario (masivo)
        public bool AdicionarHEM()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarHEM__cp_asignacion_horario(this);
        }
        // (Kevin Carlos Prado Bustillos) Adiciona los datos del horario que se encuentra en el calendario (grilla) para cada funcionario (masivo)
        public bool AdicionarHCM()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarHCM__cp_asignacion_horario(this);
        }
        // (Kevin Carlos Prado Bustillos) Adiciona los datos de la licencia justificada para cada funcionario (masivo)
        public DataSet AdicionarLJM()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarLJM__cp_asignacion_horario(this);
        }
        #endregion
    }
}

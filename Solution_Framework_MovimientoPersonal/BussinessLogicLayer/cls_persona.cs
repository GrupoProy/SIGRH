using Solution_Framework_MovimientoPersonal.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace Solution_Framework_MovimientoPersonal.BussinessLogicLayer
{
    /// <summary>
    /// Proporciona funcionalidad para manejo de tbl_persona.
    /// </summary>
    public class cls_persona
    {
        #region PROPIEDADES
        public int as_id { get; set; }
        public int per_id { get; set; }
        public int per_tipo_doc { get; set; }
        public string per_num_doc { get; set; }
        public int per_lugar_exp { get; set; }
        public string per_ap_paterno { get; set; }
        public string per_ap_materno { get; set; }
        public string per_nombres { get; set; }
        public string per_ap_casada { get; set; }
        public string per_sexo { get; set; }
        public DateTime per_fecha_nac { get; set; }
        public int per_procedencia { get; set; }
        public string per_serie_libreta_militar { get; set; }
        public int per_lugar_nac { get; set; }
        public int per_estado_civil { get; set; }
        public string estado_asig { get; set; }

        public int fp_id { get; set; }
        public byte[] fp_foto { get; set; }
        public string fp_estado { get; set; }
        //MICM
        public string per_tipo_doc_literal { get; set; }

        #endregion

        #region METODOS

        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_persona
        /// </summary>
        public bool Adicionar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Adicionar__persona(this);
        }

        public bool AdicionarFoto()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarFoto(this);
        }

        public DataSet FileVirtual(int cod_file, byte[] foto, int req_id, string fecha_doc, string fecha_registro, int per_id, string obs, string estado, string accion)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.FileVirtual(cod_file, foto, req_id, fecha_doc, fecha_registro, per_id, obs, estado, accion);
        }

        public int AdicionarFileVirtualPDF(int cod_file, byte[] foto, int req_id, string fecha_doc, string fecha_registro, int per_id, string obs, string estado, string nombre, string accion)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarFileVirtualPDF(cod_file, foto, req_id, fecha_doc, fecha_registro, per_id, obs, estado, nombre, accion);
        }

        public bool ActualizarFileVirtualPDF(DateTime fecha_doc, string obs, int pdf_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarFileVirtualPDF(fecha_doc, obs, pdf_id);
        }

        public DataSet MostrarFileVirtualPDF(int per_id, string observacion)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.MostrarFileVirtualPDF(per_id, observacion);
        }

        public IDataReader MostrarFileVirtualPDF_DR(int per_id, string observacion)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.MostrarFileVirtualPDF_DR(per_id, observacion);
        }

        public DataSet MostrarFileVirtualPDF_PorPdf_id(int per_id, int pdf_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.MostrarFileVirtualPDF_PorPdf_id(per_id, pdf_id);
        }

        public DataSet MostrarFileVirtualPDF_PorPdf_Per_id(int per_id, int pdf_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.MostrarFileVirtualPDF_PorPdf_Per_id(per_id, pdf_id);
        }

        public DataSet EliminarFileVirtualPDF(int pdf_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarFileVirtualPDF(pdf_id);
        }

        /// <summary>
        /// Método que actualiza datos en la tabla tbl_persona
        /// </summary>
        public bool Actualizar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Actualizar__persona(this);
        }

        /// <summary>
        /// Método que elimina datos en la tabla tbl_persona
        /// </summary>
        public bool Eliminar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Eliminar__persona(this);
        }

        /// <summary>
        /// Método que obtiene ID para registros de tbl_persona
        /// </summary>
        public bool ObtenerId()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerId__persona(this);
        }

        /// <summary>
        /// Método que obtiene un registro de tbl_persona
        /// </summary>
        /// <param name="per_id">Clave primaria de la tabla _persona</param>
        public bool ObtenerRegistro(int p_per_id)
        {
            per_id = p_per_id;
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerRegistro__persona(this);
        }

        public DataSet ObtenerRegistroFoto()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerRegistroFoto(this);
        }

        /// <summary>
        /// Método que obtiene la tabla tbl_persona para llenar una grilla
        /// </summary>
        public DataSet ObtenerTablaGrilla(
            string p_per_id,
            string p_per_tipo_doc,
            string p_per_num_doc,
            string p_per_lugar_exp,
            string p_per_ap_paterno,
            string p_per_ap_materno,
            string p_per_nombres,
            string p_per_ap_casada,
            string p_per_sexo,
            string p_per_fecha_nac,
            string p_per_procedencia,
            string p_per_serie_libreta_militar,
            string p_per_lugar_nac,
            string p_per_estado_civil)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrilla__persona(p_per_id, p_per_tipo_doc, p_per_num_doc, p_per_lugar_exp, p_per_ap_paterno, p_per_ap_materno, p_per_nombres, p_per_ap_casada, p_per_sexo, p_per_fecha_nac, p_per_procedencia, p_per_serie_libreta_militar, p_per_lugar_nac, p_per_estado_civil);
        }

        public DataSet ObtenerTablaGrillaLicencias(
            string p_per_id,
            string p_per_tipo_doc,
            string p_per_num_doc,
            string p_per_lugar_exp,
            string p_per_ap_paterno,
            string p_per_ap_materno,
            string p_per_nombres,
            string p_per_ap_casada,
            string p_per_sexo,
            string p_per_fecha_nac,
            string p_per_procedencia,
            string p_per_serie_libreta_militar,
            string p_per_lugar_nac,
            string p_per_estado_civil)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrilla__personaLicencias(p_per_id, p_per_tipo_doc, p_per_num_doc, p_per_lugar_exp, p_per_ap_paterno, p_per_ap_materno, p_per_nombres, p_per_ap_casada, p_per_sexo, p_per_fecha_nac, p_per_procedencia, p_per_serie_libreta_militar, p_per_lugar_nac, p_per_estado_civil);
        }

        /// <summary>
        /// Método que obtiene la tabla tbl_persona para llenar un combo
        /// </summary>
        public DataSet ObtenerTablaCombo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaCombo__persona();
        }

        // (KCPB) Ayuda a obtener la lista de personal sin asignación
        public DataSet ObtenerTablaGrillaSA(
            string p_per_id,
            string p_per_num_doc,
            string p_per_ap_paterno,
            string p_per_ap_materno,
            string p_per_nombres,
            string p_per_ap_casada)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrillaSA__persona(p_per_id, p_per_num_doc, p_per_ap_paterno, p_per_ap_materno, p_per_nombres, p_per_ap_casada);
        }

        // (Kevin Carlos Prado Bustillos) Obtienen todos los registros de la tabla para llenar una grilla (filtrando varios datos)
        public DataSet ObtenerTablaGrillaHM(
            string p_per_id,
            string p_per_num_doc,
            string p_per_ap_paterno,
            string p_per_ap_materno,
            string p_per_nombres,
            string p_as_pr_id,
            string p_eo_id,
            string p_cp_ue,
            string p_ti_tipo,
            string p_as_estado)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrillaHM__persona(p_per_id, p_per_num_doc, p_per_ap_paterno, p_per_ap_materno, p_per_nombres, p_as_pr_id, p_eo_id, p_cp_ue, p_ti_tipo, p_as_estado);
        }

        // (KCPB) Consulta un registro de la tabla _persona
        public DataSet ObtenerRegistroX(int _per_id)
        {
            per_id = _per_id;
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerRegistroX__persona(this);
        }

        public DataSet ObtenerRegistroX_CV(int _per_id)
        {
            per_id = _per_id;
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerRegistroX__personaCV(this);
        }

        // (JQC) Funciones
        public DataSet ObtenerTablaGrilla__persona_planta(
            string p_per_id,
            string p_per_tipo_doc,
            string p_per_num_doc,
            string p_per_lugar_exp,
            string p_per_ap_paterno,
            string p_per_ap_materno,
            string p_per_nombres,
            string p_per_ap_casada,
            string p_per_sexo,
            string p_per_fecha_nac,
            string p_per_procedencia,
            string p_per_serie_libreta_militar,
            string p_per_lugar_nac,
            string p_per_estado_civil)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrilla__persona_planta(p_per_id, p_per_tipo_doc, p_per_num_doc, p_per_lugar_exp, p_per_ap_paterno, p_per_ap_materno, p_per_nombres, p_per_ap_casada, p_per_sexo, p_per_fecha_nac, p_per_procedencia, p_per_serie_libreta_militar, p_per_lugar_nac, p_per_estado_civil);
        }

        public DataSet ObtenerTablaGrilla__persona_plantaVacaciones(
            string p_per_id,
            string p_per_tipo_doc,
            string p_per_num_doc,
            string p_per_lugar_exp,
            string p_per_ap_paterno,
            string p_per_ap_materno,
            string p_per_nombres,
            string p_per_ap_casada,
            string p_per_sexo,
            string p_per_fecha_nac,
            string p_per_procedencia,
            string p_per_serie_libreta_militar,
            string p_per_lugar_nac,
            string p_per_estado_civil)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrilla__persona_plantaVacaciones(p_per_id, p_per_tipo_doc, p_per_num_doc, p_per_lugar_exp, p_per_ap_paterno, p_per_ap_materno, p_per_nombres, p_per_ap_casada, p_per_sexo, p_per_fecha_nac, p_per_procedencia, p_per_serie_libreta_militar, p_per_lugar_nac, p_per_estado_civil);
        }

        public DataSet ObtenerTablaGrilla__persona_concejo(
            string p_per_id,
            string p_per_tipo_doc,
            string p_per_num_doc,
            string p_per_lugar_exp,
            string p_per_ap_paterno,
            string p_per_ap_materno,
            string p_per_nombres,
            string p_per_ap_casada,
            string p_per_sexo,
            string p_per_fecha_nac,
            string p_per_procedencia,
            string p_per_serie_libreta_militar,
            string p_per_lugar_nac,
            string p_per_estado_civil,
            int gestion)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrilla__persona_concejo(p_per_id, p_per_tipo_doc, p_per_num_doc, p_per_lugar_exp, p_per_ap_paterno, p_per_ap_materno, p_per_nombres, p_per_ap_casada, p_per_sexo, p_per_fecha_nac, p_per_procedencia, p_per_serie_libreta_militar, p_per_lugar_nac, p_per_estado_civil, gestion);
        }

        public DataSet ObtenerTablaGrilla__persona_plantaContrato(
            string p_per_id,
            string p_per_tipo_doc,
            string p_per_num_doc,
            string p_per_lugar_exp,
            string p_per_ap_paterno,
            string p_per_ap_materno,
            string p_per_nombres,
            string p_per_ap_casada,
            string p_per_sexo,
            string p_per_fecha_nac,
            string p_per_procedencia,
            string p_per_serie_libreta_militar,
            string p_per_lugar_nac,
            string p_per_estado_civil,
            int gestion)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrilla__persona_plantaContrato(p_per_id, p_per_tipo_doc, p_per_num_doc, p_per_lugar_exp, p_per_ap_paterno, p_per_ap_materno, p_per_nombres, p_per_ap_casada, p_per_sexo, p_per_fecha_nac, p_per_procedencia, p_per_serie_libreta_militar, p_per_lugar_nac, p_per_estado_civil, gestion);
        }

        // (JRVS) Funciones
        public DataSet ObtenerTablaGrilla__persona_ejecutivo(
            string p_per_id,
            string p_per_tipo_doc,
            string p_per_num_doc,
            string p_per_lugar_exp,
            string p_per_ap_paterno,
            string p_per_ap_materno,
            string p_per_nombres,
            string p_per_ap_casada,
            string p_per_sexo,
            string p_per_fecha_nac,
            string p_per_procedencia,
            string p_per_serie_libreta_militar,
            string p_per_lugar_nac,
            string p_per_estado_civil)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrilla__persona_ejecutivo(p_per_id, p_per_tipo_doc, p_per_num_doc, p_per_lugar_exp, p_per_ap_paterno, p_per_ap_materno, p_per_nombres, p_per_ap_casada, p_per_sexo, p_per_fecha_nac, p_per_procedencia, p_per_serie_libreta_militar, p_per_lugar_nac, p_per_estado_civil);
        }

        //
        // ESTTOOOOOOOOOOOOOOOOOOO ES EL DE C7
        //
        public DataSet ObtenerTablaGrilla__persona_gamlp(
            string p_per_id,
            string p_per_tipo_doc,
            string p_per_num_doc,
            string p_per_lugar_exp,
            string p_per_ap_paterno,
            string p_per_ap_materno,
            string p_per_nombres,
            string p_per_ap_casada,
            string p_per_sexo,
            string p_per_fecha_nac,
            string p_per_procedencia,
            string p_per_serie_libreta_militar,
            string p_per_lugar_nac,
            string p_per_estado_civil)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrilla__persona_gamlp(p_per_id, p_per_tipo_doc, p_per_num_doc, p_per_lugar_exp, p_per_ap_paterno, p_per_ap_materno, p_per_nombres, p_per_ap_casada, p_per_sexo, p_per_fecha_nac, p_per_procedencia, p_per_serie_libreta_militar, p_per_lugar_nac, p_per_estado_civil);
        }

        public DataSet ObtenerTablaGrilla__persona_FechaIngreso(
            string p_per_id,
            string p_per_tipo_doc,
            string p_per_num_doc,
            string p_per_lugar_exp,
            string p_per_ap_paterno,
            string p_per_ap_materno,
            string p_per_nombres,
            string p_per_ap_casada,
            string p_per_sexo,
            string p_per_fecha_nac,
            string p_per_procedencia,
            string p_per_serie_libreta_militar,
            string p_per_lugar_nac,
            string p_per_estado_civil)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrilla__persona_FechaIngreso(p_per_id, p_per_tipo_doc, p_per_num_doc, p_per_lugar_exp, p_per_ap_paterno, p_per_ap_materno, p_per_nombres, p_per_ap_casada, p_per_sexo, p_per_fecha_nac, p_per_procedencia, p_per_serie_libreta_militar, p_per_lugar_nac, p_per_estado_civil);
        }

        //(JQC)
        public DataSet ObtenerTablaGrilla__personaGamlp_AfiliacionEGS(
            string p_per_id,
            string p_per_tipo_doc,
            string p_per_num_doc,
            string p_per_lugar_exp,
            string p_per_ap_paterno,
            string p_per_ap_materno,
            string p_per_nombres,
            string p_per_ap_casada,
            string p_per_sexo,
            string p_per_fecha_nac,
            string p_per_procedencia,
            string p_per_serie_libreta_militar,
            string p_per_lugar_nac,
            string p_per_estado_civil,
            string p_fa_id,
            string p_ae_estado)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrilla__personaGamlp_AfiliacionEGS(p_per_id, p_per_tipo_doc, p_per_num_doc, p_per_lugar_exp, p_per_ap_paterno, p_per_ap_materno, p_per_nombres, p_per_ap_casada, p_per_sexo, p_per_fecha_nac, p_per_procedencia, p_per_serie_libreta_militar, p_per_lugar_nac, p_per_estado_civil, p_fa_id, p_ae_estado);
        }

        public DataSet ObtenerTablaGrilla__persona_plantaTecLab(
            string p_per_id,
            string p_per_tipo_doc,
            string p_per_num_doc,
            string p_per_lugar_exp,
            string p_per_ap_paterno,
            string p_per_ap_materno,
            string p_per_nombres,
            string p_per_ap_casada,
            string p_per_sexo,
            string p_per_fecha_nac,
            string p_per_procedencia,
            string p_per_serie_libreta_militar,
            string p_per_lugar_nac,
            string p_per_estado_civil,
            int pr_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrilla__persona_plantaTecLab(p_per_id, p_per_tipo_doc, p_per_num_doc, p_per_lugar_exp, p_per_ap_paterno, p_per_ap_materno, p_per_nombres, p_per_ap_casada, p_per_sexo, p_per_fecha_nac, p_per_procedencia, p_per_serie_libreta_militar, p_per_lugar_nac, p_per_estado_civil, pr_id);
        }

        public DataSet ObtenerTablaGrilla__gamlp_vigente(
            string p_per_id,
            string p_per_tipo_doc,
            string p_per_num_doc,
            string p_per_lugar_exp,
            string p_per_ap_paterno,
            string p_per_ap_materno,
            string p_per_nombres,
            string p_per_ap_casada,
            string p_per_sexo,
            string p_per_fecha_nac,
            string p_per_procedencia,
            string p_per_serie_libreta_militar,
            string p_per_lugar_nac,
            string p_per_estado_civil,
            int pr_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrilla__gamlp_vigente(p_per_id, p_per_tipo_doc, p_per_num_doc, p_per_lugar_exp, p_per_ap_paterno, p_per_ap_materno, p_per_nombres, p_per_ap_casada, p_per_sexo, p_per_fecha_nac, p_per_procedencia, p_per_serie_libreta_militar, p_per_lugar_nac, p_per_estado_civil, pr_id);
        }

        public DataSet ObtenerTablaGrilla__gamlp_vigente_ex_preocupacional(
            string p_per_id,
            string p_per_tipo_doc,
            string p_per_num_doc,
            string p_per_lugar_exp,
            string p_per_ap_paterno,
            string p_per_ap_materno,
            string p_per_nombres,
            string p_per_ap_casada,
            string p_per_sexo,
            string p_per_fecha_nac,
            string p_per_procedencia,
            string p_per_serie_libreta_militar,
            string p_per_lugar_nac,
            string p_per_estado_civil,
            int pr_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrilla__gamlp_vigente_ex_preocupacional(p_per_id, p_per_tipo_doc, p_per_num_doc, p_per_lugar_exp, p_per_ap_paterno, p_per_ap_materno, p_per_nombres, p_per_ap_casada, p_per_sexo, p_per_fecha_nac, p_per_procedencia, p_per_serie_libreta_militar, p_per_lugar_nac, p_per_estado_civil, pr_id);
        }

        public DataSet ObtenerTablaGrilla__gamlp_finiquito(
            string p_per_id,
            string p_per_tipo_doc,
            string p_per_num_doc,
            string p_per_lugar_exp,
            string p_per_ap_paterno,
            string p_per_ap_materno,
            string p_per_nombres,
            string p_per_ap_casada,
            string p_per_sexo,
            string p_per_fecha_nac,
            string p_per_procedencia,
            string p_per_serie_libreta_militar,
            string p_per_lugar_nac,
            string p_per_estado_civil,
            int pr_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrilla__gamlp_finiquito(p_per_id, p_per_tipo_doc, p_per_num_doc, p_per_lugar_exp, p_per_ap_paterno, p_per_ap_materno, p_per_nombres, p_per_ap_casada, p_per_sexo, p_per_fecha_nac, p_per_procedencia, p_per_serie_libreta_militar, p_per_lugar_nac, p_per_estado_civil, pr_id);
        }

        public DataSet ObtenerTablaGrillaPCED(
            string p_per_id,
            string p_per_num_doc,
            string p_per_ap_paterno,
            string p_per_ap_materno,
            string p_per_nombres,
            string p_per_ap_casada)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrillaPCED__persona(p_per_id, p_per_num_doc, p_per_ap_paterno, p_per_ap_materno, p_per_nombres, p_per_ap_casada);
        }

        public DataSet VerificarNuevoFuncionario(string ci, int per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.VerificarNuevoFuncionario(ci, per_id);
        }

        public bool Actualizar__personaConLibreta()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Actualizar__personaConLibreta(this);
        }

        public DataSet ObtenerTablaGrilla__AsignacionesPersona(
            string p_per_id,
            string p_per_tipo_doc,
            string p_per_num_doc,
            string p_per_lugar_exp,
            string p_per_ap_paterno,
            string p_per_ap_materno,
            string p_per_nombres,
            string p_per_ap_casada,
            string p_per_sexo,
            string p_per_fecha_nac,
            string p_per_procedencia,
            string p_per_serie_libreta_militar,
            string p_per_lugar_nac,
            string p_per_estado_civil)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrilla__AsignacionesPersona(p_per_id, p_per_tipo_doc, p_per_num_doc, p_per_lugar_exp, p_per_ap_paterno, p_per_ap_materno, p_per_nombres, p_per_ap_casada, p_per_sexo, p_per_fecha_nac, p_per_procedencia, p_per_serie_libreta_militar, p_per_lugar_nac, p_per_estado_civil);
        }

        public DataSet ObtenerTablaGrilla__AsignacionesPersona_SoloDocentes(
            string p_per_id,
            string p_per_tipo_doc,
            string p_per_num_doc,
            string p_per_lugar_exp,
            string p_per_ap_paterno,
            string p_per_ap_materno,
            string p_per_nombres,
            string p_per_ap_casada,
            string p_per_sexo,
            string p_per_fecha_nac,
            string p_per_procedencia,
            string p_per_serie_libreta_militar,
            string p_per_lugar_nac,
            string p_per_estado_civil)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrilla__AsignacionesPersona_SoloDocentes(p_per_id, p_per_tipo_doc, p_per_num_doc, p_per_lugar_exp, p_per_ap_paterno, p_per_ap_materno, p_per_nombres, p_per_ap_casada, p_per_sexo, p_per_fecha_nac, p_per_procedencia, p_per_serie_libreta_militar, p_per_lugar_nac, p_per_estado_civil);
        }

        #endregion
    } 
}
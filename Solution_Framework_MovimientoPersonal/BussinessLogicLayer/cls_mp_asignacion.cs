using Solution_Framework_MovimientoPersonal.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
 
using System.Text;
using System.Threading.Tasks;

namespace Solution_Framework_MovimientoPersonal.BussinessLogicLayer
{
    /// <summary>
	/// Proporciona funcionalidad para manejo de tbl_mp_asignacion.
	/// </summary>
	public class cls_mp_asignacion
    {
        #region PROPIEDADES
        public int? as_id { get; set; }
        public int? as_per_id { get; set; }
        public int? as_ca_id { get; set; }
        public DateTime? as_fecha_inicio { get; set; }
        public DateTime? as_fecha_fin { get; set; }
        public string as_estado { get; set; }
        public string as_tipo_reg { get; set; }
        public string as_tipo_mov { get; set; }
        public string as_tipo_baja { get; set; }
        public string as_validacion { get; set; }
        public DateTime? as_fecha_validacion { get; set; }
        public int? as_memo { get; set; }
        public int? as_memo_baja { get; set; }
        public int? as_usuario_creacion { get; set; }
        public DateTime? as_fecha_creacion { get; set; }
        public int? as_pr_id { get; set; }
        public int pre_id { get; set; }
        public string ti_item { get; set; }
        public string ti_tipo { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_mp_asignacion
        /// </summary>
        public int Adicionar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Adicionar__mp_asignacion(this);
        }

        /// <summary>
        /// Método que actualiza datos en la tabla tbl_mp_asignacion
        /// </summary>
        public bool Actualizar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Actualizar__mp_asignacion(this);
        }

        /// <summary>
        /// Método que elimina datos en la tabla tbl_mp_asignacion
        /// </summary>
        public bool Eliminar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Eliminar__mp_asignacion(this);
        }

        /// <summary>
        /// Método que obtiene un registro de tbl_mp_asignacion
        /// </summary>
        /// <param name="as_id">
        /// Clave primaria de la tabla _mp_asignacion
        /// </param>
        public DataSet ObtenerRegistro()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerRegistro__mp_asignacion(this);
        }

        /// <summary>
        /// Método que obtiene la tabla tbl_mp_asignacion para llenar una grilla
        /// </summary>
        /// <param name="as_id">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="as_per_id">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="as_ca_id">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="as_fecha_inicio">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="as_fecha_fin">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="as_estado">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="as_tipo_reg">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="as_tipo_mov">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="as_tipo_baja">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        public DataSet ObtenerTablaGrilla(
            string p_as_id,
            string p_as_per_id,
            string p_as_ca_id,
            string p_as_fecha_inicio,
            string p_as_fecha_fin,
            string p_as_estado,
            string p_as_tipo_reg,
            string p_as_tipo_mov,
            string p_as_tipo_baja,
            string p_as_validacion,
            string p_as_fecha_validacion,
            string p_as_memo,
            string p_as_memo_baja,
            string p_as_pr_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrilla__mp_asignacion(p_as_id, p_as_per_id, p_as_ca_id, p_as_fecha_inicio, p_as_fecha_fin, p_as_estado, p_as_tipo_reg, p_as_tipo_mov, p_as_tipo_baja, p_as_validacion, p_as_fecha_validacion, p_as_memo, p_as_memo_baja, p_as_pr_id);
        }

        /// <summary>
        /// Método que obtiene la tabla tbl_mp_asignacion para llenar un combo
        /// </summary>
        public DataSet ObtenerTablaCombo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaCombo__mp_asignacion();
        }

        // (MICM) Método que obtiene Ultima Asignacion Laboral
        public DataSet ObtenerUltimaAsignacionLaboral(int p_as_per_id)
        {
            as_per_id = p_as_per_id;
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerUltimaAsignacionLaboral_mp_asignacion(this);
        }

        // (KCPB)
        public DataSet ObtenerTablaGrillaC(
            string p_as_id,
            string p_as_per_id,
            string p_as_ca_id,
            string p_as_fecha_inicio,
            string p_as_fecha_fin,
            string p_as_estado,
            string p_as_tipo_reg,
            string p_as_tipo_mov,
            string p_as_tipo_baja,
            string p_as_validacion,
            string p_as_fecha_validacion,
            string p_as_memo,
            string p_as_memo_baja,
            string p_as_pr_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrillaC__mp_asignacion(p_as_id, p_as_per_id, p_as_ca_id, p_as_fecha_inicio, p_as_fecha_fin, p_as_estado, p_as_tipo_reg, p_as_tipo_mov, p_as_tipo_baja, p_as_validacion, p_as_fecha_validacion, p_as_memo, p_as_memo_baja, p_as_pr_id);
        }
        public DataSet ObtenerTablaGrillaC2(
    string p_as_id,
    string p_as_per_id,
    string p_as_ca_id,
    string p_as_fecha_inicio,
    string p_as_fecha_fin,
    string p_as_estado,
    string p_as_tipo_reg,
    string p_as_tipo_mov,
    string p_as_tipo_baja,
    string p_as_validacion,
    string p_as_fecha_validacion,
    string p_as_memo,
    string p_as_memo_baja,
    string p_as_pr_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrillaC__mp_asignacion2(p_as_id, p_as_per_id, p_as_ca_id, p_as_fecha_inicio, p_as_fecha_fin, p_as_estado, p_as_tipo_reg, p_as_tipo_mov, p_as_tipo_baja, p_as_validacion, p_as_fecha_validacion, p_as_memo, p_as_memo_baja, p_as_pr_id);
        }
        public DataSet ObtenerTablaGrilla__AsignacionesPersonaComision(
            string p_as_id,
            string p_as_per_id,
            string p_as_ca_id,
            string p_as_fecha_inicio,
            string p_as_fecha_fin,
            string p_as_estado,
            string p_as_tipo_reg,
            string p_as_tipo_mov,
            string p_as_tipo_baja,
            string p_as_validacion,
            string p_as_fecha_validacion,
            string p_as_memo,
            string p_as_memo_baja,
            string p_as_pr_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaGrilla__AsignacionesPersonaComision(p_as_id, p_as_per_id, p_as_ca_id, p_as_fecha_inicio, p_as_fecha_fin, p_as_estado, p_as_tipo_reg, p_as_tipo_mov, p_as_tipo_baja, p_as_validacion, p_as_fecha_validacion, p_as_memo, p_as_memo_baja, p_as_pr_id);
        }
        // (Kevin Carlos Prado Bustillos) Realiza el registro de la baja de asignación del funcionario
        public bool ActualizarBaja()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarBaja__mp_asignacion(this);
        }
        //JRVS
        public DataSet ObtenerASignacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerASignacion(this);
        }
        //JRVS
        public DataSet ObtenerDetalleValidacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDetalleValidacion(this);
        }
        // (Kevin Carlos Prado Bustillos) Obtiene el detalle del puesto de un precontratado para su asignación
        public DataSet ObtenerPuestoPreContrato()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerPuestoPreContratado__mp_asignacion(this);
        }
        public DataSet ObtenerTiempoFuncionario()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTiempoFuncionario(this);
        }
        public DataSet ObtenerAsignacionesRealizadas()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerAsignacionesRealizadas(this);
        }
        public DataSet ObtenerTiempo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTiempo(this);
        }
        public DataSet ObtenerBoleta(string param)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerBoleta(this, param);
        }
        public DataSet ObtenerInformacionFiniquito()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerInformacionFiniquito(this);
        }
        public DataSet ObtenerCantidadVacacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerCantidadVacacion(this);
        }

        // (JQC)
        public DataSet ListaFiltradoTipoMovimiento()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListaFiltradoTipoMovimiento();
        }
        public DataSet ObtenerDatosInformacionAltaRector()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDatosInformacionAltaRector(this);
        }
        public DataSet ObtenerDatosInformacionAlta()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDatosInformacionAlta(this);
        }
        public DataSet ObtenerDatosInformacionBaja()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDatosInformacionBaja(this);
        }
        public DataSet ObtenerDatosInformacionRPT()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDatosInformacionRPT(this);
        }

        public bool ReprobarAlta()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ReprobarAlta(this);
        }
        public bool ReprobarBaja()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ReprobarBaja(this);
        }
        public bool ReprobarRPT()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ReprobarRPT(this);
        }
        public bool ReprobarRPTConcejo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ReprobarRPTConcejo(this);
        }
        public DataSet ObtenerGrillaReprobacionMov()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaReprobacionMov(this);
        }
        public  DataSet ObtenerEscalafonDocente()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerEscalafonDocente();
        }
        public  bool InsertarEscalafonDocente(int ed_id, int per_id , string accion)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.InsertarEscalafonDocente(ed_id, per_id, accion);
        }
        public bool InsertarTipoAportante(int per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.InsertarTipoAportante(per_id);
        }
        public  string ConsultarValidacion(int as_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ConsultarValidacion(as_id);
        }
        public bool ActualizarFechaInicioYBaja(cls_mp_asignacion _mp_asignacion)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarFechaInicioYBaja(this);
        }
        public  bool ActualizarEscalafonDocente(int per_id, int aed_ed_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarEscalafonDocente(per_id, aed_ed_id);
        }
        public DataSet ObtenerTodasLasAsignacionesVigentes(int per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTodasLasAsignacionesVigentes(per_id);
        }
        public  DataSet VerificarAsignacionEscalafon(int per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.VerificarAsignacionEscalafon(per_id);
        }
        public  DataSet VerificarItemAdministrativo(int ca_id, int per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.VerificarItemAdministrativo(ca_id, per_id);
        }
        public  bool InsertarFechaIngreso(int per_id, string fecha, string estado)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.InsertarFechaIngreso(per_id, fecha, estado);
        }
        public  DataSet MostrarFechasIngreso()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.MostrarFechasIngreso();
        }

       
        #endregion
    }
}

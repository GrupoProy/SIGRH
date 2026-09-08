using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_Kardex.DataAccessLayer;

namespace Solution_Framework_Kardex.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_kd_asignacion_vacaciones.
	/// </summary>
	public class cls_kd_asignacion_vacaciones
	{        
		#region PROPIEDADES
		public int va_id { get; set; }
        public int va_per_id { get; set; }
        public string va_gestion { get; set; }
        public int va_dias_ley { get; set; }
        public double va_dias_restantes { get; set; }
        public int va_horas_restantes { get; set; }
        public DateTime va_fecha_ingreso_r { get; set; }
        public int va_anio { get; set; }
        public DateTime va_fecha_habilitacion_prescrito { get; set; }
        public string va_autorizado_por { get; set; }
        public string va_nro_documento { get; set; }
        public string va_observaciones { get; set; }
        public DateTime va_fecha_registro_prescrito { get; set; }
        public DateTime va_fecha_validez_prescrito { get; set; }
        public string va_estado { get; set; }
        public int va_usuario_creacion { get; set; }
        public DateTime va_fecha_creacion { get; set; }
        public string gestion_selec { get; set; }
        // Variables Vacaciones
        public int vac_id { get; set; }
        public int vac_tipo_vacacion { get; set; }
        public string vac_a_partir { get; set; }
        public string vac_hasta { get; set; }
        public string vac_nro_dias_vacacion { get; set; }
        public string vac_va_id { get; set; }
        public string vac_observacion { get; set; }
        public string vac_estado { get; set; }
        public int vac_correlativo { get; set; }
        public int vac_usuario_creacion { get; set; }
        public string vac_motivo_anulado { get; set; }
        public string vac_usuario_anulado { get; set; }
        // Variables Doc CAS
        public int cs_id { get; set; }
        public int cs_tipo_cas { get; set; }
        public string cs_nro_cas { get; set; }
        public string cs_fecha_cas { get; set; }
        public int cs_anios_calif { get; set; }
        public int cs_meses_calif { get; set; }
        public int cs_dias_calif { get; set; }
        public int lj_id { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_kd_asignacion_vacaciones
        /// </summary>
        public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__kd_asignacion_vacaciones(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_kd_asignacion_vacaciones
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__kd_asignacion_vacaciones(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_kd_asignacion_vacaciones
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__kd_asignacion_vacaciones(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_kd_asignacion_vacaciones
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__kd_asignacion_vacaciones(this);
		}


		public DataSet ObtenerTablaGrilla(string va_id, 
						string va_per_id, 
						string va_gestion, 
						string va_dias_ley, 
						string va_dias_restantes, 
						string va_horas_restantes, 
						string va_fecha_ingreso_r, 
						string va_anio, 
						string va_fecha_habilitacion_prescrito, 
						string va_autorizado_por, 
						string va_nro_documento, 
						string va_observaciones, 
						string va_fecha_registro_prescrito, 
						string va_fecha_validez_prescrito, 
						string va_estado, 
						string va_usuario_creacion, 
						string va_fecha_creacion)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__kd_asignacion_vacaciones(va_id, va_per_id, va_gestion, va_dias_ley, va_dias_restantes, va_horas_restantes, va_fecha_ingreso_r, va_anio, va_fecha_habilitacion_prescrito, va_autorizado_por, va_nro_documento, va_observaciones, va_fecha_registro_prescrito, va_fecha_validez_prescrito, va_estado, va_usuario_creacion, va_fecha_creacion);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_kd_asignacion_vacaciones para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__kd_asignacion_vacaciones();
		}

        //(JQC)
        public DataSet obtenerGrillaAsigVacaciones()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerGrillaAsigVacaciones(this);
        }

        public DataSet ObtenerDatosFuncionarioP()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDatosFuncionarioP(this);
        }

        public DataSet obtenerGrillaHistoricoVacaciones()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerGrillaHistoricoVacaciones(this);
        }
            public DataSet ObtenerVacacionAnualX()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerVacacionAnualX(this);
        }
        public DataSet listaFiltradoTipoLicencia()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.listaFiltradoTipoLicencia();
        }
        public int AdicionarVacacionLicencia(int id_autoriza)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarVacacionLicencia(this, id_autoriza);
        }
        public DataSet ObtenerSumaTotalDiasV()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerSumaTotalDiasV(this);
        }
        public DataSet ObtenerCorrelativo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerCorrelativo();
        }
        public DataSet ObtenerNroDiasVacacionDisp()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerNroDiasVacacionDisp(this);
        }
        public DataSet ObtenerNroHorasVacacionDisp()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerNroHorasVacacionDisp(this);
        }
        public bool ActualizarSaldoDias()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarSaldoDias(this);
        }
        public DataSet obtenerGrillaHistoricoLicenciaVac()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerGrillaHistoricoLicenciaVac(this);
        }
        public DataSet ObtenerLicenciaCargoVacacionX()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerLicenciaCargoVacacionX(this);
        }
        public bool EliminarVacacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarVacacion(this);
        }
        public DataSet obtenerGrillaHistoricoDocumentoCAS()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerGrillaHistoricoDocumentoCAS(this);
        }
        public DataSet listaFiltradoTipoCas()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.listaFiltradoTipoCas();
        }
        public bool AdicionarRegistroCas()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarRegistroCas(this);
        }
        public bool EliminarRegistroCas()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarRegistroCas(this);
        }
        public bool ActualizarSaldoHoras()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarSaldoHoras(this);
        }
        public bool ActualizarSaldoDiasHoras()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarSaldoDiasHoras(this);
        }
        public DataSet obtenerGrillaHistoricoGestionPrescrito()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerGrillaHistoricoGestionPrescrito(this);
        }
        public DataSet ObtenerVacacionX()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerVacacionX(this);
        }
        public bool AdicionarGestionPrescrito()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarGestionPrescrito(this);
        }
        public DataSet obtenerGrillaFiliacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerGrillaFiliacion(this);
        }
        public DataSet obtenerGrillaHistoricoAsig()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerGrillaHistoricoAsig(this);
        }
        public bool EliminarLicenciaVacacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarLicenciaVacacion(this);
        }
        public DataSet ObtenerDiasAsignados()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDiasAsignados(this);
        }
        public bool RecuperarVacacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.RecuperarVacacion(this);
        }
        public bool RecuperarVacacionHoras()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.RecuperarVacacionHoras(this);
        }
        public DataSet ObtenerDetalleLicencia()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDetalleLicencia(this);
        }
        public DataSet ObtenerVacacionesAsignadas()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerVacacionesAsignadas(this);
        }
        public DataSet obtenerHistoricoAsigVacaciones()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerHistoricoAsigVacaciones(this);
        }
        public  string ObtenerVacaciones_ConDiasFeriados(string fechaInicio, string fechaFin)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerVacaciones_ConDiasFeriados(fechaInicio, fechaFin);
        }
        #endregion

        public DataSet OBTENERGRIDASGINACIONES(int nro)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.OBTENERGRIDASGINACIONES(this, nro);
        }
    }
}

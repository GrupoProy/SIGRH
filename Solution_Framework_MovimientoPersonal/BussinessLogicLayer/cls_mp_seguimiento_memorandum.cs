using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_MovimientoPersonal.DataAccessLayer;

namespace Solution_Framework_MovimientoPersonal.BussinessLogicLayer
{
    /// <summary>
    /// Proporciona funcionalidad para manejo de tbl_mp_seguimiento_memorandum.
    /// </summary>
    public class cls_mp_seguimiento_memorandum
    {
        #region PROPIEDADES
        public int mh_id { get; set; }
        public string mh_qr { get; set; }
        public int mh_per_id { get; set; }
        public int mh_te_id { get; set; }
        public int mh_nro_memo { get; set; }
        public string mh_contenido { get; set; }
        public string mh_validacion { get; set; }
        public string mh_fecha_validacion { get; set; }
        public int mh_usuario_creacion { get; set; }
        public int mh_pr_id { get; set; }

        public int mv_id { get; set; }
        public int mv_per_id { get; set; }
        public int mv_nro_memo { get; set; }
        public string mv_datos { get; set; }
        public string mv_validacion { get; set; }
        public string mv_fecha_validacion { get; set; }
        public string mv_estado { get; set; }
        public int mv_usuario_creacion { get; set; }
        public string mv_fecha_creacion { get; set; }
        public int mv_pr_id { get; set; }


        public string sm_qr { get; set; }
        public int sm_validado_por { get; set; }
        public int sm_usuario_creacion { get; set; }

        //(JQC)
        public string per_num_doc { get; set; }
        public int as_id { get; set; }
        public int as_pr_id { get; set; }
        public string as_fecha_inicio { get; set; }
        public string as_fecha_fin { get; set; }
        public int usuario_creacion { get; set; }

        public int ci_id { get; set; }
        public int ca_id { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_mp_seguimiento_memorandum
        /// </summary>
        public bool Adicionar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Adicionar__mp_seguimiento_memorandum(this);
        }

        public DataSet AdicionarTenorFunMV()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarTenorFunMV(this);
        }
        /// <summary>
        /// Método que actualiza datos en la tabla tbl_mp_seguimiento_memorandum
        /// </summary>
        public bool Actualizar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Actualizar__mp_seguimiento_memorandum(this);
        }

        /// <summary>
        /// Método que elimina datos en la tabla tbl_mp_seguimiento_memorandum
        /// </summary>
        public bool Eliminar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Eliminar__mp_seguimiento_memorandum(this);
        }

        public bool EliminarMemoAsignado()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarMemoAsignado(this);
        }

        /// <summary>
        /// Método que obtiene ID para registros de tbl_mp_seguimiento_memorandum
        /// </summary>
        public bool ObtenerId()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerId__mp_seguimiento_memorandum(this);
        }

        public bool ObtenerRegistro()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerRegistro__mp_seguimiento_memorandum(this);
        }

        public DataSet ObtenerTablaCombo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTablaCombo__mp_seguimiento_memorandum();
        }
        public DataSet ObtenerTenorFuncionario()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTenorFuncionario(this);
        }
        public DataSet ObtenerSeguimientoMemorandum()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerSeguimientoMemorandum(this);
        }
        public bool AdicionarSeguimientoMemorandum()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarSeguimientoMemorandum(this);
        }
        public DataSet ObtenerGrillaSM()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaSM(this);
        }
        public DataSet ObtenerGrillaMemosAsig()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaMemosAsig(this);
        }

        //(JQC)
        public DataSet listaFiltradoTipoValidacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.listaFiltradoTipoValidacion();
        }
        public DataSet obtenerDatosInformacionAlta()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerDatosInformacionAlta(this);
        }
        public bool ActualizarValidacionAlta()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarValidacionAlta(this);
        }
        public DataSet obtenerDatosInformacionBaja()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerDatosInformacionBaja(this);
        }
        public DataSet obtenerDatosInformacionRPT()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerDatosInformacionRPT(this);
        }
        public DataSet obtenerDatosInformacionAltasCI()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerDatosInformacionAltasCI(this);
        }
        public bool ActualizarValidacionAltaCI()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarValidacionAltaCI(this);
        }
        public DataSet obtenerDatosInformacionBajasCI()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerDatosInformacionBajasCI(this);
        }
        public DataSet obtenerDatosInformacionMemosVarios()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerDatosInformacionMemosVarios(this);
        }
        public bool ActualizarValidacionMemosVarios()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarValidacionMemosVarios(this);
        }
        public DataSet ObtenerGrillaAltaRector()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaAltaRector(this);
        }
        public DataSet obtenerGrillaValidaAlta()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerGrillaValidaAlta(this);
        }
        public DataSet obtenerCantidadValidaAlta()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerCantidadValidaAlta(this);
        }
        public DataSet obtenerGrillaValidaBaja()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerGrillaValidaBaja(this);
        }
        public DataSet obtenerCantidadValidaBaja()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerCantidadValidaBaja(this);
        }
        public DataSet obtenerGrillaValidaRPT()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerGrillaValidaRPT(this);
        }
        public DataSet obtenerCantidadValidaRPT()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerCantidadValidaRPT(this);
        }
        public DataSet obtenerGrillaValidaAltaCI()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerGrillaValidaAltaCI(this);
        }
        public DataSet obtenerCantidadValidaAltaCI()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerCantidadValidaAltaCI(this);
        }
        public DataSet obtenerGrillaValidaBajaCI()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerGrillaValidaBajaCI(this);
        }
        public DataSet obtenerCantidadValidaBajaCI()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerCantidadValidaBajaCI(this);
        }
        public DataSet obtenerGrillaValidaMemosVarios()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerGrillaValidaMemosVarios(this);
        }
        public DataSet obtenerCantidadValidaMemosVarios()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerCantidadValidaMemosVarios(this);
        }
        public bool EliminarRegistroValidacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarRegistroValidacion(this);
        }
        public bool EliminarRegistroValidacionCI()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarRegistroValidacionCI(this);
        }
        public bool EliminarRegistroValidacionMemosVarios()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarRegistroValidacionMemosVarios(this);
        }
        public bool ModificarValidacionAlta()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ModificarValidacionAlta(this);
        }
        public bool ModificarValidacionAltaCI()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ModificarValidacionAltaCI(this);
        }
        public bool ModificarValidacionMemosVarios()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ModificarValidacionMemosVarios(this);
        }
        public DataSet obtenerCantidadReprobarAlta()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerCantidadReprobarAlta(this);
        }
        public DataSet obtenerCantidadReprobarBaja()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerCantidadReprobarBaja(this);
        }
        public DataSet obtenerCantidadReprobarRPT()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerCantidadReprobarRPT(this);
        }
        public DataSet obtenerCantidadReprobarAltaCI()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerCantidadReprobarAltaCI(this);
        }
        public DataSet obtenerCantidadReprobarBajaCI()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerCantidadReprobarBajaCI(this);
        }
        public DataSet obtenerCantidadReprobarMemosVarios()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerCantidadReprobarMemosVarios(this);
        }
        public DataSet obtenerInformacionReprobarAlta()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerInformacionReprobarAlta(this);
        }
        public DataSet obtenerInformacionReprobarBaja()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerInformacionReprobarBaja(this);
        }
        public DataSet obtenerInformacionReprobarRPT()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerInformacionReprobarRPT(this);
        }
        public DataSet obtenerInformacionReprobarAltasCI()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerInformacionReprobarAltasCI(this);
        }
        public DataSet obtenerInformacionReprobarBajasCI()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerInformacionReprobarBajasCI(this);
        }
        public DataSet obtenerInformacionReprobarMemosVarios()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerInformacionReprobarMemosVarios(this);
        }
        public DataSet obtenerGrillaReprobarAlta()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerGrillaReprobarAlta(this);
        }
        public DataSet obtenerGrillaReprobarBaja()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerGrillaReprobarBaja(this);
        }
        public DataSet obtenerGrillaReprobarRPT()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerGrillaReprobarRPT(this);
        }
        public DataSet obtenerGrillaReprobarAltaCI()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerGrillaReprobarAltaCI(this);
        }
        public DataSet obtenerGrillaReprobarBajaCI()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerGrillaReprobarBajaCI(this);
        }
        public DataSet obtenerGrillaReprobarMemosVarios()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerGrillaReprobarMemosVarios(this);
        }
        public bool ActualizarReprobacionAlta()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarReprobacionAlta(this);
        }
        public bool ActualizarReprobacionAltaCI()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarReprobacionAltaCI(this);
        }
        public bool ActualizarReprobacionMemosVarios()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarReprobacionMemosVarios(this);
        }
        public DataSet ObtenerAltaID()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerAltaID(this);
        }
        public DataSet ObtenerBajaID()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerBajaID(this);
        }
        public DataSet ObtenerRPTID()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerRPTID(this);
        }
        public DataSet ObtenerAltaCIDID()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerAltaCIDID(this);
        }
        public DataSet ObtenerBajaCIDID()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerBajaCIDID(this);
        }
        public DataSet ObtenerMemoVarioID()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerMemoVarioID(this);
        }
        public DataSet ObtenerValidacionBaja()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerValidacionBaja(this);
        }
        public DataSet ObtenerMovimientosValidados()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerMovimientosValidados(this);
        }
        public DataSet obtenerDatosInformacionAltasCIGrilla()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerDatosInformacionAltasCIGrilla(this);
        }
        public DataSet obtenerDatosInformacionBajasCIGrilla()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerDatosInformacionBajasCIGrilla(this);
        }
        public DataSet obtenerDatosInformacionMemosVariosGrilla()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerDatosInformacionMemosVariosGrilla(this);

        }
        public  DataSet ObtenerInformacionValidar(int per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerInformacionValidar(per_id);
        }
        public  DataSet ListarMovimientosParaReprobar(int pr_id, int per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarMovimientosParaReprobar(pr_id, per_id);
        }
        #endregion
    }
}

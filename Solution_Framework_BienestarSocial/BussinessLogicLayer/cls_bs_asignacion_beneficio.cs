using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_BienestarSocial.DataAccessLayer;


namespace Solution_Framework_BienestarSocial.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_bs_asignacion_beneficio.
	/// </summary>
	public class cls_bs_asignacion_beneficio
	{
		#region PROPIEDADES
		public int ab_id { get; set; }
        public string ae_matricula { get; set; }
        public int ab_aeb_id { get; set; }
        public int ab_fa_id { get; set; }
        public string ab_fecha_inicio { get; set; }
        public string ab_fecha_fin { get; set; }
        public string ab_estado { get; set; }
        public string ab_tipo_beneficiario { get; set; }
        // (JQC)
        public int pf_id { get; set; }
        public int pf_per_id { get; set; }
        public string pf_tipo_parentesco { get; set; }
        public string pf_paterno { get; set; }
        public string pf_materno { get; set; }
        public string pf_nombres { get; set; }
        public string pf_ap_esposo { get; set; }
        public string pf_fecha_nac { get; set; }
        public string pf_estado_vivo { get; set; }
        public string pf_fecha_defuncion { get; set; }
        public string pf_sexo { get; set; }
        public int as_id { get; set; }
        public int ae_egs_id { get; set; }
        public string ae_fecha_form { get; set; }
        public int ae_policlinico { get; set; }
        public string ae_fecha_baja_form { get; set; }
        public string ae_fecha_baja_elab { get; set; }
        public string ae_tipo_ingreso { get; set; }
        public string ae_tipo_proceso_baja { get; set; }
        public int ae_em_id { get; set; }
        public int aeb_id { get; set; }
        public int aeb_ae_id { get; set; }
        public string aeb_afi_por { get; set; }
        public int perd_ciudad_residencia { get; set; }
        public int perd_zona { get; set; }
        public int perd_tipo_via { get; set; }
        public string perd_descripcion_via { get; set; }
        public string perd_numero { get; set; }
        public string param { get; set; }
        public string pf_ci { get; set; }
        public string nro_matri { get; set; }

        #endregion

        #region METODOS
        public DataSet DatosFuncionario(int codigo, string nombre, string paterno, string materno, string esposo, string ci)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.DatosFuncionario(codigo, nombre, paterno, materno, esposo, ci);
        }
        public DataSet ListarBenef(int per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarBenef(per_id);
        }
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_bs_asignacion_beneficio
        /// </summary>
        public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__bs_asignacion_beneficio(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_bs_asignacion_beneficio
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__bs_asignacion_beneficio(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_bs_asignacion_beneficio
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__bs_asignacion_beneficio(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_bs_asignacion_beneficio
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__bs_asignacion_beneficio(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_bs_asignacion_beneficio
		/// </summary>
		/// <param name="ab_id">
		/// Clave primaria de la tabla _bs_asignacion_beneficio
		/// </param>

		public bool ObtenerRegistro(int ab_id)
		{
			 int _ab_id = ab_id;

			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__bs_asignacion_beneficio(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_bs_asignacion_beneficio para llenar una grilla
		/// </summary>
		/// <param name="ab_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ab_aeb_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ab_fa_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ab_fecha_inicio">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ab_fecha_fin">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ab_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="ab_tipo_beneficiario">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>

		public DataSet ObtenerTablaGrilla(string ab_id, 
						string ab_aeb_id, 
						string ab_fa_id, 
						string ab_fecha_inicio, 
						string ab_fecha_fin, 
						string ab_estado, 
						string ab_tipo_beneficiario,                     
                        string pf_per_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__bs_asignacion_beneficio(ab_id, ab_aeb_id, ab_fa_id, ab_fecha_inicio, ab_fecha_fin, ab_estado, ab_tipo_beneficiario, pf_per_id);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_bs_asignacion_beneficio para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__bs_asignacion_beneficio();
		}

        public DataSet VerificarSubsidioenMes(string ab_aeb_id, string ab_fa_id, string ab_fecha_inicio, string ab_fecha_fin)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.VerificarSubsidioenMes__bs_asignacion_beneficio(ab_aeb_id, ab_fa_id, ab_fecha_inicio, ab_fecha_fin);
        }

        // (JQC)
        public DataSet listaFiltradoTipoBeneficio()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.listaFiltradoTipoBeneficio();
        }
        public DataSet listaFiltradoTipoMes()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.listaFiltradoTipoMes();
        }
        public DataSet listaFiltradoTipoParentesco()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.listaFiltradoTipoParentesco();
        }
        public DataSet listaFiltradoTipoGenero()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.listaFiltradoTipoGenero();
        }
        public DataSet listaFiltradoEstadoVivo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.listaFiltradoEstadoVivo();
        }
        public DataSet ObtenerFamiliar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFamiliar(this);
        }
        public DataSet ListarFamiliares()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarFamiliares(this);
        }
        public bool ActualizarDatosFamiliar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarDatosFamiliar(this);
        }
        public DataSet ObtenerTiempoMeses()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTiempoMeses(this);
        }
        public DataSet ListarFamiliarEsposa()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarFamiliarEsposa(this);
        }
        public DataSet ListarFamiliaresBeneficiarios()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarFamiliaresBeneficiarios(this);
        }
        public DataSet obtenerIdBeneficio()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerIdBeneficio(this);
        }
        public DataSet ObtenerDatosDetalleFuncionario()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDatosDetalleFuncionario(this);
        }
        public DataSet listaFiltradoCajaAseguradora()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.listaFiltradoCajaAseguradora();
        }
        public DataSet listaFiltradoPoliclinico()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.listaFiltradoPoliclinico();
        }
        public DataSet ListarFamiliaresAfiliados()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarFamiliaresAfiliados(this);
        }
        public bool ActualizarDatosAfiliacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarDatosAfiliacion(this);
        }
        public DataSet obtenerIdAfiliacionEGS()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerIdAfiliacionEGS(this);
        }
        public DataSet ObtenerAfiliacionX()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerAfiliacionX(this);
        }
        public DataSet obtenerIdEmpleador()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerIdEmpleador(this);
        }
        public bool AdicionarPoliclinico()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarPoliclinico(this);
        }
        public DataSet ObtenerDomicilio()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDomicilio(this);
        }
        public bool AdicionarAfiliacionFamiliar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarAfiliacionFamiliar(this);
        }
        public bool EliminarAfiliacionFamiliar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarAfiliacionFamiliar(this);
        }
        public DataSet ListarFamiliaresAfiliadosEGS()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarFamiliaresAfiliadosEGS(this);
        }
        public bool ActualizarDatosDomicilio()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarDatosDomicilio(this);
        }
        public DataSet VerificarAfiliacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.VerificarAfiliacion(this);
        }
        public DataSet ObtenerFechaNacFamiliar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFechaNacFamiliar(this);
        }
        public DataSet listaFiltradoEstadoAfiliacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.listaFiltradoEstadoAfiliacion();
        }
        public DataSet listaFiltradoTipoAvc()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.listaFiltradoTipoAvc();
        }
        public DataSet listaFiltradoTipoDocEsp()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.listaFiltradoTipoDocEsp();
        }
        public bool AdicionarFamiliar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarFamiliar(this);
        }
        public DataSet ListarGrillaBajas()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarGrillaBajas(this);
        }
        public DataSet ObtenerFuncionarioBajaX()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFuncionarioBajaX(this);
        }
        public bool AdicionarFechaBajaForm()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarFechaBajaForm(this);
        }
        public DataSet obtenerIdAsignacionEGS()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerIdAsignacionEGS(this);
        }
        public DataSet ObtenerCantidadBajasEGS()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerCantidadBajasEGS(this);
        }
        public DataSet listaFiltradoFamiliarBeneficio()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.listaFiltradoFamiliarBeneficio();
        }
        public DataSet ObtenerSubsidio()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerSubsidio(this);
        }
        public bool CancelarSubsidio()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.CancelarSubsidio(this);
        }
        public DataSet ListarGrillaValidacionBajas()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarGrillaValidacionBajas(this);
        }
        public bool AdicionarFechaRecepcionBaja()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarFechaRecepcionBaja(this);
        }
        public DataSet ObtenerFuncionarioValBajaX()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFuncionarioValBajaX(this);
        }
        public DataSet ObtenerCantidadRecepBajasEGS()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerCantidadRecepBajasEGS(this);
        }
        public DataSet ObtenerDatosAfiliacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDatosAfiliacion(this);
        }

        public bool AdicionarFamiliarNuevo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarFamiliarNuevo(this);
        }
        #endregion

        #region Nuevo
        public bool AdicionarAfiliacionFamiliarNuevo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarAfiliacionFamiliarNuevo(this);
        }

        public bool ActualizarDatosFamiliarNuevo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarAfiliacionFamiliarNuevo(this);
        }

        public DataSet ListarFamiliaresNuevo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarFamiliaresNuevo(this);
        }
        #endregion
    }
}

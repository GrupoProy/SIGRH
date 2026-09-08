using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_MovimientoPersonal.DataAccessLayer;

namespace Solution_Framework_MovimientoPersonal.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_mp_cargo.
	/// </summary>
	public class cls_mp_cargo
	{
		#region PROPIEDADES

        //Variables Tenor
        public int te_cod_tenor { get; set; }
        public int te_usuario_creacion { get; set; }
        public string te_descripcion { get; set; }
        public string te_contenido { get; set; }
        public string te_tipo_reg { get; set; }
        public string bat_estado { get; set; }
        public int bat_per_id { get; set; }
        public string gestion { get; set; }

        public int p_per_id { get; set; }
        public int p_nro_memo { get; set; }
        public int p_aux { get; set; }
        //Variable Puesto
        public int p_id { get; set; }
        public string p_descripcion { get; set; }

        //Variable Cargo
        public int eo_id { get; set; }
        public int es_cod_esc { get; set; }
        public int ca_id { get; set; }
        public int ca_es_id { get; set; }
        public int ca_eo_id { get; set; }
        public string ca_ti_item { get; set; }
        public int ca_num_item { get; set; }
        public string ca_estado { get; set; }
        public string ca_aplica_incremento { get; set; }
        public string ca_tipo_jornada { get; set; }
        public string ca_basico_calculado { get; set; }
        public string ca_fecha_modificacion { get; set; }
        public int ca_tipo_calculo { get; set; }
        public int ca_usuario_creacion { get; set; }
        public string ca_pr_id { get; set; }

        public int gl_valor_pk { get; set; }
        public string gl_nombre_pk { get; set; }
        public string gl_tabla { get; set; }
        public int gl_tipo_mov { get; set; }
        public string gl_fecha_doc { get; set; }
        public int gl_tipo_doc { get; set; }
        public string gl_numero_doc { get; set; }
        public string gl_glosa { get; set; }
        public string gl_estado { get; set; }
        public int gl_usuario { get; set; }
        public int ca_id_anterior { get; set; }
        public string gestion_selec { get; set; }

        //ATRIBUTOS JQC
        public int ep_cod_estp { get; set; }
        public string nro_item { get; set; }

        public string fu_paterno { get; set; }
        public string fu_materno { get; set; }
        public string fu_nombres { get; set; }
        public string fu_num_ident { get; set; }
        public string fu_tipo_ident { get; set; }
        public string fu_sexo { get; set; }
        public string haber_basico { get; set; }
        public string es_escalafon { get; set; }
        public string ns_clase { get; set; }
        public string ns_nivel { get; set; }
        public string as_fecha_asignacion { get; set; }
        public string as_fecha_baja { get; set; }
        public string ep_descripcion { get; set; }
        public string tipo_item { get; set; }
        public string num_item { get; set; }
        public string es_descripcion { get; set; }
        public string pu_nombre_puesto { get; set; }
        public int p_cat_id { get; set; }
        public int p_cat_id_superior { get; set; }


        public int as_ca_id { get; set; }
        public int as_per_id { get; set; }
        public string as_fecha_inicio { get; set; }
        public string as_fecha_fin { get; set; }
        public string as_estado { get; set; }
        public string as_tipo_reg { get; set; }
        public string as_tipo_mov { get; set; }
        public string as_tipo_baja { get; set; }
        public int as_usuario_creacion { get; set; }
        public string as_fecha_creacion { get; set; }
        public string as_pr_id { get; set; }

        public int as_id { get; set; }
        public int as_id_actual { get; set; }
        public string as_fecha_fin_actual { get; set; }
        public int ca_id_actual { get; set; }
        public int ca_es_id_actual { get; set; }
        public int ca_eo_id_actual { get; set; }
        public string ca_ti_item_actual { get; set; }
        public int ca_num_item_actual { get; set; }
        public string ca_estado_actual { get; set; }
        public string ca_aplica_incremento_actual { get; set; }
        public string ca_tipo_jornada_actual { get; set; }
        public string ca_basico_calculado_actual { get; set; }
        public int ca_tipo_calculo_actual { get; set; }
        public string ca_pr_id_actual { get; set; }
        public string ca_num_consulta { get; set; }

        public string imagen { get; set; }
        public int cp_id_actual { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_mp_cargo
        /// </summary>
        public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__mp_cargo(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_mp_cargo
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__mp_cargo(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_mp_cargo
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__mp_cargo(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_mp_cargo
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__mp_cargo(this);
		}

        /// <summary>
        /// Método que obtiene un registro de tbl_mp_cargo
        /// </summary>
        /// <param name="ca_id">
        /// Clave primaria de la tabla _mp_cargo
        /// </param>

        public DataSet ObtenerRegistro()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerRegistro__mp_cargo(this);
        }

        /// <summary>
        /// Método que obtiene la tabla tbl_mp_cargo para llenar una grilla
        /// </summary>
        /// <param name="ca_id">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ca_es_id">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ca_eo_id">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ca_ti_item">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ca_num_item">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ca_estado">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ca_aplica_incremento">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>
        /// <param name="ca_tipo_jornada">
        /// (Campo opcional) Introducir espacio vacio
        /// </param>

        public DataSet ObtenerTablaGrilla(string p_ca_id, 
						string p_ca_es_id, 
						string p_ca_eo_id, 
						string p_ca_ti_item, 
						string p_ca_num_item, 
						string p_ca_estado, 
						string p_ca_aplica_incremento, 
						string p_ca_tipo_jornada)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__mp_cargo(p_ca_id, p_ca_es_id, p_ca_eo_id, p_ca_ti_item, p_ca_num_item, p_ca_estado, p_ca_aplica_incremento, p_ca_tipo_jornada);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_mp_cargo para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__mp_cargo();
		}

        // FUNCIONES USADAS JRVS
        public bool AdicionarTenor()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarTenor(this);
        }

        public DataSet ObtenerDetalleTenor()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDetalleTenor(this);
        }

        public DataSet ObtenerDetalleFuncionario()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDetalleFuncionario(this);
        }
        public DataSet VerificarMemorandum()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.VerificarMemorandum(this);
        }
        public DataSet ObtenerDetalleFuncionarioBajas()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDetalleFuncionarioBajas(this);
        }

        public DataSet ObtenerDetalleFuncionarioPRTAcefalias()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDetalleFuncionarioPRTAcefalias(this);
        }
        public DataSet ObtenerDetalleFuncionarioPRTCargos()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDetalleFuncionarioPRTCargos(this);
        }
        public DataSet ObtenerDetalleFuncionarioAComInt()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDetalleFuncionarioAComInt(this);
        }
        public DataSet ObtenerDetalleFuncionarioBComInt()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDetalleFuncionarioBComInt(this);
        }
        public DataSet ObtenerDetalleFuncionarioADispPersonal()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDetalleFuncionarioADispPersonal(this);
        }
        public DataSet ObtenerDetalleFuncionarioBDispPersonal()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDetalleFuncionarioBDispPersonal(this);
        }
        public DataSet ObtenerDetalleFuncionarioMemosVarios()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDetalleFuncionarioMemosVarios(this);
        }
        public DataSet ObtenerDetalleFuncionarioTransicion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDetalleFuncionarioTransicion(this);
        }
        public DataSet ObtenerDetalleFuncionarioSancion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDetalleFuncionarioSancion(this);
        }
        public DataSet ObtenerGrillaTenor()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaTenor(this);
        }


        public DataSet ObtenerDatosTenor()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDatosTenor(this);
        }
        public bool ActualizacionTenor()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizacionTenor(this);
        }
        public bool EliminarTenor()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarTenor(this);
        }

        public DataSet ObtenerFiltradoTipoMov()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFiltradoTipoMov(this);
        }

        public DataSet ObtenerFiltradoTipoItem()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFiltradoTipoItem(this);
        }
        public DataSet ObtenerFiltradoTenor()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFiltradoTenor(this);
        }
        public DataSet ObtenerFiltradoTipoMemoV()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFiltradoTipoMemoV(this);
        }
        public DataSet ObtenerGestion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGestion(this);
        }
        public DataSet ObtenerGrillaFiltro()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaFiltro(this);
        }
        public DataSet ObtenerNivelOrg()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerNivelOrg(this);
        }
        public DataSet ObtenerDescripcionNivelOrg()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDescripcionNivelOrg(this);
        }
        public DataSet ObtenerNivelOrgEjecutivo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerNivelOrgEjecutivo(this);
        }
        public DataSet ObtenerFiltradoTipoDoc()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFiltradoTipoDoc();
        }
        public DataSet ObtenerNivelOrgItems()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerNivelOrgItems(this);
        }
        public DataSet ObtenerNivelOrgItemsEjecutivo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerNivelOrgItemsEjecutivo(this);
        }
        public DataSet ObtenerDetalleitem()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDetalleitem(this);
        }
        public DataSet ObtenerFiltradoCargoUO()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFiltradoCargoUO(this);
        }
        public DataSet ObtenerFiltradoTipoItemUO()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFiltradoTipoItemUO(this);
        }
        public DataSet ObtenerFiltradoTipoItemUOSuplencia()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFiltradoTipoItemUOSuplencia(this);
        }
        public DataSet ObtenerDetalleUO()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDetalleUO(this);
        }
        public DataSet ObtenerIdCargo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerIdCargo();
        }
        public DataSet ObtenerNroItem()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerNroItem(this);
        }
        public DataSet AdicionarCargoUO()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarCargoUO(this);
        }
        public bool AdicionarGlosa()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarGlosa(this);
        }
        public DataSet ObtenerGrillaItems()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaItems(this);
        }
        public DataSet ObtenerDetalleitemCargo(string p_gestion_selec)
        {
            string gestion_selec = p_gestion_selec;
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDetalleitemCargo(this, gestion_selec);
        }
        public bool ActualizarItem()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarItem(this);
        }
        public bool EliminarItem()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarItem(this);
        }
        public DataSet ObtenerFiltradoGestion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFiltradoGestion();
        }
        public DataSet ObtenerCargoX()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerCargoX(this);
        }
        public DataSet ObtenerFiltradoEstrucOrg()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFiltradoEstrucOrg(this);
        }
        public DataSet obtenerFiltradoTipoAsignacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerFiltradoTipoAsignacion();
        }
        public DataSet obtenerFiltradoTipoMovInterinato()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerFiltradoTipoMovInterinato(this);
        }
        public bool ActualizarMemoAsignacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarMemoAsignacion(this);
        }
        public DataSet ObtenerDatosDetalleFuncionario()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDatosDetalleFuncionario(this);
        }
        public DataSet ObtenerNivelItemsLibres()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerNivelItemsLibres(this);
        }
        public DataSet ObtenerDetalleItemsLibre()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDetalleItemsLibre(this);
        }
        public DataSet ObtenerFiltradoTipoItemUOCreacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFiltradoTipoItemUOCreacion(this);
        }
        //FUNCIONES JQC
        public DataSet ObtenerNivelOrganizacional()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerNivelOrganizacional(this);
        }

        public DataSet ObtenerNivelOrganizacionalItems()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerNivelOrganizacionalItems(this);
        }

        public DataSet ObtenerDetalleItem()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDetalleItem(this);
        }
        public DataSet ObtenerDetalleItemEjecutivo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDetalleItemEjecutivo(this);
        }
        public bool obtenerDatosFuncionario(string p_num_iden)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerDatosFuncionario(this);
        }
        public bool obtenerDatosFuncionarioConAsignaciones(string p_num_iden)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerDatosFuncionarioConAsignaciones(this);
        }
        public DataSet obtenerTipoMovPadre()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerTipoMovPadre(this);
        }

        public DataSet obtenerFiltradoTipoMov()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerFiltradoTipoMov(this);
        }

        public DataSet obtenerFiltradoTipoDoc()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerFiltradoTipoDoc();
        }

        public bool AdicionarPromocion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarPromocion(this);
        }

        public bool AdicionarNuevoCargo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarNuevoCargo(this);
        }

        public bool ActualizarAsignacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarAsignacion(this);
        }

        public bool ActualizarCargoActual()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarCargoActual(this);
        }

        public bool AdicionarCargoActual()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarCargoActual(this);
        }

        public DataSet ObtenerIdCargoA()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerIdCargoA();
        }
        public bool ActualizarCargoNuevo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarCargoNuevo(this);
        }

        public bool AdicionarCargoNuevo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarCargoNuevo(this);
        }

        public DataSet ObtenerAsignacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerAsignacion(this);
        }
        public DataSet ObtenerFiltradoCargoHB()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerFiltradoCargoHB(this);
        }
        public DataSet ObtenerNivelSalarial()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerNivelSalarial(this);
        }
        public DataSet ObtenerNivelOrgConcejo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerNivelOrgConcejo(this);
        }
        public DataSet obtenerNombreUO()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerNombreUO(this);
        }
        public DataSet ObtenerIdCargoPlantaC()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerIdCargoPlantaC();
        }
        public bool AdicionarCargoPlanta()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarCargoPlanta(this);
        }
        public DataSet ObtenerGrillaItemConsejo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaItemConsejo(this);
        }

        public bool obtenerDatosFuncionarioConsejo(string p_num_iden)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.obtenerDatosFuncionarioConsejo(this);
        }

        public DataSet ObtenerBusquedaItem()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerBusquedaItem(this);
        }

        public DataSet ObtenerAsignacionX()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerAsignacionX(this);
        }
        public DataSet ObtenerNivelOrganizacionalItemsMasAcefalia()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerNivelOrganizacionalItemsMasAcefalia(this);
        }
        public DataSet ObtenerDetalleItemPlanta()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDetalleItemPlanta(this);
        }
        public DataSet ObtenerListaItemPlanta()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerListaItemPlanta(this);
        }
        public DataSet ObtenerListaCargoPlanta()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerListaCargoPlanta(this);
        }
        public DataSet ObtenerListaPuestoPlanta()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerListaPuestoPlanta(this);
        }
        public DataSet ObtenerListaTipoItemPlanta()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerListaTipoItemPlanta(this);
        }
        public DataSet ObtenerPuestoPlanta()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerPuestoPlanta(this);
        }
        public DataSet ObtenerGrillaItem()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaItem(this);
        }
        public DataSet ModificarItemPlanta()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ModificarItemPlanta(this);
        }
        // Funciones KCPB
        // (KCPB) Ayuda a obtener una lista de items acefalos para personal de contrato
        public DataSet ObtenerGrillaItemsCP()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaItemsCP(this);
        }

        // (KCPB) Ayuda a obtener el detalle del item acefalo para la asignación del personal
        public DataSet ObtenerDetalleItemCP()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDetalleItemCP(this);
        }
        public DataSet ObtenerDetalleItemCP_num_item()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDetalleItemCP_num_item(this);
        }
        public DataSet ObtenerGrillaItemPlanta()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerGrillaItemPlanta(this);
        }
        public  DataSet ObtenerTipoJornada()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerTipoJornada();
        }
        public DataSet ObtenerInfoParaTenorMemorandums()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerInfoParaTenorMemorandums(this);
        }
        public  string Obtener_CaId(string num_item, string pr_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Obtener_CaId(num_item, pr_id);
        }
        public  DataSet ObtenerItem_MoverFuente(string ca_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerItem_MoverFuente(ca_id);
        }
        public DataSet ObtenerItem_MoverFuente_Grilla(string num_item, string pr_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerItem_MoverFuente_Grilla(num_item, pr_id);
        }
        public DataSet ObtenerUnidades_MoverFuente(string ca_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerUnidades_MoverFuente(ca_id);
        }
        public int Modificar_FuenteFinanciamiento(string eo_id, string cod_proceso, string ca_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Modificar_FuenteFinanciamiento(eo_id, cod_proceso, ca_id);
        }
        public DataSet TotalesFuenteFinanciamiento(string cod_proceso)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.TotalesFuenteFinanciamiento(cod_proceso);
        }
        public  DataSet ConsultaSiPlanillaEstaEjecutada(string cod_proceso)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ConsultaSiPlanillaEstaEjecutada(cod_proceso);
        }
        public DataSet ConsultaSiPlanillaEstaEjecutada_adicional(string cod_proceso, string secuencial)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ConsultaSiPlanillaEstaEjecutada_adicional(cod_proceso, secuencial);
        }

        public DataSet BuscarParaAdicionales(string ci, string cod_proceso)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.BuscarParaAdicionales(ci, cod_proceso);
        }
        public  bool InsertarCasosParaAdicionales(string cod_proceso, string as_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.InsertarCasosParaAdicionales(cod_proceso, as_id);
        }
        public  DataSet MostrarCasosAdicionales(string cod_proceso)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.MostrarCasosAdicionales(cod_proceso);
        }
        public  bool EliminarCasosAdicional(string ad_as_id, string cod_proceso, string secuencial)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarCasosAdicional(ad_as_id, cod_proceso, secuencial);
        }

        public DataSet ObtenerNivelOrgMP()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerNivelOrgMP(this);
        }
        #endregion
    }
}

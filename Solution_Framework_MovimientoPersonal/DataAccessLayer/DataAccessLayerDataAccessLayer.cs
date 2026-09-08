using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;

namespace Solution_Framework_MovimientoPersonal.DataAccessLayer
{
    public abstract class DataAccessLayerDataAccessLayer
    {
        #region INSTANCIA PRINCIPAL DE CONEXION A UNA BD
        public Database CNXSIGRH3 = DatabaseFactory.CreateDatabase("CnxSigrh3");
        #endregion

        // INTERFACES	
		#region _MP_ESTRUCTURA_ORGANIZACIONAL
		public abstract bool Adicionar__mp_estructura_organizacional(cls_mp_estructura_organizacional _mp_estructura_organizacional);
		public abstract bool Actualizar__mp_estructura_organizacional(cls_mp_estructura_organizacional _mp_estructura_organizacional);
		public abstract bool Eliminar__mp_estructura_organizacional(cls_mp_estructura_organizacional _mp_estructura_organizacional);
		public abstract bool ObtenerId__mp_estructura_organizacional(cls_mp_estructura_organizacional _mp_estructura_organizacional);
		public abstract bool ObtenerRegistro__mp_estructura_organizacional(cls_mp_estructura_organizacional _mp_estructura_organizacional);
        public abstract DataSet ObtenerRegistro(int eo_id);

        public abstract DataSet ObtenerTablaGrilla__mp_estructura_organizacional(string eo_id, 
						string eo_pr_id, 
						string eo_cp_id, 
						string eo_prog, 
						string eo_sprog, 
						string eo_proy, 
						string eo_obract, 
						string eo_unidad, 
						string eo_descripcion, 
						string eo_estado, 
						string eo_cod_superior);
		public abstract DataSet ObtenerTablaCombo__mp_estructura_organizacional();
		public abstract DataSet ObtenerDescendencia(cls_mp_estructura_organizacional _mp_estructura_organizacional);
		public abstract DataSet ObtenerItemsLibres(cls_mp_estructura_organizacional _mp_estructura_organizacional);
		public abstract DataSet ObtenerListaFiltradoEstOrg(cls_mp_estructura_organizacional _mp_estructura_organizacional);
		public abstract DataSet BuscarItemUO(cls_mp_estructura_organizacional _mp_estructura_organizacional);
		public abstract DataSet ObtenerPOAI(cls_mp_estructura_organizacional _mp_estructura_organizacional);
		public abstract DataSet ObtenerOrgInicial(cls_mp_estructura_organizacional _mp_estructura_organizacional);
        public abstract DataSet ObtenerCpId(cls_mp_estructura_organizacional _mp_estructura_organizacional);
        #endregion

        #region _MP_TIPO_ITEM
        public abstract bool Adicionar__mp_tipo_item(cls_mp_tipo_item _mp_tipo_item);
        public abstract bool Actualizar__mp_tipo_item(cls_mp_tipo_item _mp_tipo_item);
        public abstract bool Eliminar__mp_tipo_item(cls_mp_tipo_item _mp_tipo_item);
        public abstract bool ObtenerRegistro__mp_tipo_item(cls_mp_tipo_item _mp_tipo_item);
        public abstract DataSet ObtenerTablaGrilla__mp_tipo_item(
            string ti_item,
            string ti_descripcion,
            string ti_estado,
            string ti_tipo,
            string ti_item_suplencia,
            string ti_orden,
            string ti_tipo_pago,
            string ti_control,
            string ti_tipo_item_gral);
        public abstract DataSet ObtenerTablaCombo__mp_tipo_item();
        // (Kevin Carlos Prado Bustillos) Obtiene todos los registros de tipo ítem
        public abstract DataSet ObtenerTablaComboTI__mp_tipo_item();
        // (Kevin Carlos Prado Bustillos) Obtiene todos los registros de ítem suplencia
        public abstract DataSet ObtenerTablaComboIS__mp_tipo_item();
        // (Kevin Carlos Prado Bustillos) Obtiene todos los registros de tipo ítem general
        public abstract DataSet ObtenerTablaComboTIG__mp_tipo_item();
        // (Kevin Carlos Prado Bustillos) Obtiene el orden máximo según el tipo ítem
        public abstract int ObtenerRegistroOM__mp_tipo_item(cls_mp_tipo_item _mp_tipo_item);
        public abstract DataSet TipoItemAltasBajas();
        #endregion

        #region _MP_ESCALA_SALARIAL
        public abstract bool Adicionar__mp_escala_salarial(cls_mp_escala_salarial _mp_escala_salarial);
		public abstract bool Actualizar__mp_escala_salarial(cls_mp_escala_salarial _mp_escala_salarial);
		public abstract bool Eliminar__mp_escala_salarial(cls_mp_escala_salarial _mp_escala_salarial);
		public abstract bool ObtenerId__mp_escala_salarial(cls_mp_escala_salarial _mp_escala_salarial);
		public abstract bool ObtenerRegistro__mp_escala_salarial(cls_mp_escala_salarial _mp_escala_salarial);
		public abstract DataSet ObtenerTablaGrilla__mp_escala_salarial(string es_id, 
						string es_pr_id, 
						string es_ns_id, 
						string es_escalafon, 
						string es_descripcion, 
						string es_estado, 
						string es_ne_id, 
						string es_rf_id, 
						string es_categoria);
		public abstract DataSet ObtenerTablaCombo__mp_escala_salarial(cls_mp_escala_salarial _mp_escala_salarial);
		#endregion

		#region _ESCALA_PUESTO
		public abstract bool Adicionar__escala_puesto(cls_escala_puesto _escala_puesto);
		public abstract bool Actualizar__escala_puesto(cls_escala_puesto _escala_puesto);
		public abstract bool Eliminar__escala_puesto(cls_escala_puesto _escala_puesto);
		public abstract bool ObtenerId__escala_puesto(cls_escala_puesto _escala_puesto);
		public abstract bool ObtenerRegistro__escala_puesto(cls_escala_puesto _escala_puesto);
		public abstract DataSet ObtenerTablaGrilla__escala_puesto(string epu_id, 
						string epu_es_id, 
						string epu_p_id, 
						string epu_tipo, 
						string epu_estado);
		public abstract DataSet ObtenerTablaCombo__escala_puesto();
		public abstract DataSet ObtenerGrillaEscalaPuesto(cls_escala_puesto _escala_puesto);
		public abstract DataSet ValidarEP(cls_escala_puesto _escala_puesto);
		public abstract DataSet ObtenerPuestos(cls_escala_puesto _escala_puesto);
		#endregion

		#region _MP_PRESUPUESTO
		public abstract bool Adicionar__mp_presupuesto(cls_mp_presupuesto _mp_presupuesto);
		public abstract bool Actualizar__mp_presupuesto(cls_mp_presupuesto _mp_presupuesto);
		public abstract bool Eliminar__mp_presupuesto(cls_mp_presupuesto _mp_presupuesto);
		public abstract bool ObtenerId__mp_presupuesto(cls_mp_presupuesto _mp_presupuesto);
		public abstract bool ObtenerRegistro__mp_presupuesto(cls_mp_presupuesto _mp_presupuesto);
		public abstract DataSet ObtenerTablaGrilla__mp_presupuesto(cls_mp_presupuesto _mp_presupuesto);
		public abstract DataSet ObtenerTablaCombo__mp_presupuesto();
		#endregion

        #region _MP_CATEGORIA_PROGRAMATICA
        public abstract bool Adicionar__mp_categoria_programatica(cls_mp_categoria_programatica _mp_categoria_programatica);
        public abstract bool Actualizar__mp_categoria_programatica(cls_mp_categoria_programatica _mp_categoria_programatica);
        public abstract bool Eliminar__mp_categoria_programatica(cls_mp_categoria_programatica _mp_categoria_programatica);
        public abstract bool ObtenerId__mp_categoria_programatica(cls_mp_categoria_programatica _mp_categoria_programatica);
        public abstract DataSet ObtenerRegistro__mp_categoria_programatica(cls_mp_categoria_programatica _mp_categoria_programatica);
        public abstract DataSet ObtenerTablaGrilla__mp_categoria_programatica(
            string cp_id,
            string cp_da,
            string cp_da_descripcion,
            string cp_ue,
            string cp_ue_descripcion,
            string cp_programa,
            string cp_proyecto,
            string cp_actividad,
            string cp_cod_poa,
            string cp_descripcion,
            string cp_estado,
            string cp_tipo_gasto,
            string cp_fuente,
            string cp_organismo,
            string cp_pr_id,
            string cp_fecha_modificacion);
        public abstract DataSet ObtenerTablaCombo__mp_categoria_programatica();
        // (KCPB) Listado de UE vigentes
        public abstract DataSet ObtenerTablaComboUE__mp_categoria_programatica(cls_mp_categoria_programatica _mp_categoria_programatica);
        public abstract string ObtenerTipoGasto(int eo_id);
        #endregion

        #region _MP_CARGO_PUESTO
        public abstract bool Adicionar__mp_cargo_puesto(cls_mp_cargo_puesto _mp_cargo_puesto);
        public abstract bool Actualizar__mp_cargo_puesto(cls_mp_cargo_puesto _mp_cargo_puesto);
        public abstract bool Eliminar__mp_cargo_puesto(cls_mp_cargo_puesto _mp_cargo_puesto);
        public abstract bool ObtenerId__mp_cargo_puesto(cls_mp_cargo_puesto _mp_cargo_puesto);
        public abstract DataSet ObtenerRegistro__mp_cargo_puesto(cls_mp_cargo_puesto _mp_cargo_puesto);
        public abstract DataSet ObtenerTablaGrilla__mp_cargo_puesto(
            string cap_ca_id,
            string cap_p_id,
            string cap_estado,
            string cap_fecha_modificacion);
        public abstract DataSet ObtenerTablaCombo__mp_cargo_puesto();
        #endregion

        #region _PUESTOS
        public abstract DataSet Adicionar__puestos(cls_puestos _puestos);
        public abstract bool Actualizar__puestos(cls_puestos _puestos);
        public abstract bool Eliminar__puestos(cls_puestos _puestos);
        public abstract bool ObtenerId__puestos(cls_puestos _puestos);
        public abstract DataSet ObtenerRegistro__puestos(cls_puestos _puestos);
        public abstract DataSet ObtenerTablaGrilla__puestos(
            string p_id,
            string p_descripcion,
            string p_estado);
        public abstract DataSet ObtenerTablaCombo__puestos();
        public abstract DataSet ObtenerPuestosVigentes();
        #endregion

        #region _SITUACION_PERSONA
        public abstract DataSet Adicionar__situacion_persona(cls_situacion_persona _situacion_persona);
        public abstract bool Actualizar__situacion_persona(cls_situacion_persona _situacion_persona);
        public abstract bool Eliminar__situacion_persona(cls_situacion_persona _situacion_persona);
        public abstract bool ObtenerId__situacion_persona(cls_situacion_persona _situacion_persona);
        public abstract bool ObtenerRegistro__situacion_persona(cls_situacion_persona _situacion_persona);
        public abstract DataSet ObtenerTablaGrilla__situacion_persona(cls_situacion_persona _situacion_persona);
        public abstract DataSet ObtenerTablaCombo__situacion_persona();
        public abstract DataSet ObtenerListaSituacionPer();
        public abstract DataSet ValidarSituacion(cls_situacion_persona _situacion_persona);
        #endregion

        #region _MP_ASIGNACION_COM_INT
        public abstract bool Adicionar__mp_asignacion_com_int(cls_mp_asignacion_com_int _mp_asignacion_com_int);
        public abstract bool Actualizar__mp_asignacion_com_int(cls_mp_asignacion_com_int _mp_asignacion_com_int);
        public abstract bool Eliminar__mp_asignacion_com_int(cls_mp_asignacion_com_int _mp_asignacion_com_int);
        public abstract DataSet FinalizarAsignacion(cls_mp_asignacion_com_int _mp_asignacion_com_int);
        public abstract bool ObtenerId__mp_asignacion_com_int(cls_mp_asignacion_com_int _mp_asignacion_com_int);
        public abstract DataSet ObtenerRegistro__mp_asignacion_com_int(cls_mp_asignacion_com_int _mp_asignacion_com_int);
        public abstract DataSet ObtenerDatosFunCI(cls_mp_asignacion_com_int _mp_asignacion_com_int);
        public abstract DataSet ObtenerTablaGrilla__mp_asignacion_com_int(string ci_id,
                        string ci_per_id,
                        string ci_ca_id,
                        string ci_secuencial,
                        string ci_fecha_inicio,
                        string ci_fecha_fin,
                        string ci_estado,
                        string ci_fecha_creacion,
                        string ci_tipo_mov,
                        string ci_tipo_reg,
                        string ci_verificado,
                        string ci_pr_id,
                        string ci_tipo_mov_baja,
                        string ci_ca_id_ant,
                        string ci_secuencial_ant,
                        string ci_nominal,
                        string ci_ca_id_n,
                        string ci_es_id_n,
                        string ci_eo_id_n,
                        string ci_per_id_interinato,
                        string ci_fecha_conclusion,
                        string ci_cod_valida,
                        string ci_fecha_valida);
        public abstract DataSet ObtenerTablaCombo__mp_asignacion_com_int();
        public abstract DataSet ObtenerTiempoFuncionario(cls_mp_asignacion _mp_asignacion);
        public abstract DataSet ObtenerAsignacionesRealizadas(cls_mp_asignacion _mp_asignacion);
        public abstract DataSet ObtenerDetalleValidacion(cls_mp_asignacion _mp_asignacion);
        public abstract DataSet ObtenerTiempo(cls_mp_asignacion _mp_asignacion);
        public abstract DataSet ObtenerBoleta(cls_mp_asignacion _mp_asignacion, string param);
        public abstract DataSet ObtenerInformacionFiniquito(cls_mp_asignacion _mp_asignacion);
        public abstract DataSet ObtenerCantidadVacacion(cls_mp_asignacion _mp_asignacion);
        #endregion

        #region _MP_SEGUIMIENTO_MEMORANDUM
        public abstract DataSet ObtenerDatosInformacionAltaRector(cls_mp_asignacion _mp_asignacion);
        public abstract DataSet ObtenerGrillaAltaRector(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract bool Adicionar__mp_seguimiento_memorandum(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet AdicionarTenorFunMV(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract bool Actualizar__mp_seguimiento_memorandum(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract bool Eliminar__mp_seguimiento_memorandum(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract bool EliminarMemoAsignado(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract bool ObtenerId__mp_seguimiento_memorandum(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract bool ObtenerRegistro__mp_seguimiento_memorandum(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet ObtenerTablaCombo__mp_seguimiento_memorandum();
        public abstract DataSet ObtenerTenorFuncionario(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet ObtenerSeguimientoMemorandum(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet ObtenerGrillaSM(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet ObtenerGrillaMemosAsig(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract bool AdicionarSeguimientoMemorandum(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);

        //(JQC)
        public abstract DataSet listaFiltradoTipoValidacion();
        public abstract DataSet obtenerDatosInformacionAlta(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract bool ActualizarValidacionAlta(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerDatosInformacionBaja(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerDatosInformacionRPT(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerDatosInformacionAltasCI(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract bool ActualizarValidacionAltaCI(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerDatosInformacionBajasCI(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerDatosInformacionMemosVarios(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract bool ActualizarValidacionMemosVarios(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerGrillaValidaAlta(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerCantidadValidaAlta(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerCantidadValidaBaja(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerCantidadValidaRPT(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerCantidadValidaAltaCI(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerCantidadValidaBajaCI(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerCantidadValidaMemosVarios(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerGrillaValidaBaja(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerGrillaValidaRPT(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerGrillaValidaAltaCI(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerGrillaValidaBajaCI(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerGrillaValidaMemosVarios(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract bool EliminarRegistroValidacion(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract bool EliminarRegistroValidacionCI(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract bool EliminarRegistroValidacionMemosVarios(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract bool ModificarValidacionAlta(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract bool ModificarValidacionAltaCI(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract bool ModificarValidacionMemosVarios(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerCantidadReprobarAlta(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerCantidadReprobarBaja(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerCantidadReprobarRPT(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerCantidadReprobarAltaCI(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerCantidadReprobarBajaCI(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerCantidadReprobarMemosVarios(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerInformacionReprobarAlta(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerInformacionReprobarBaja(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerInformacionReprobarRPT(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerInformacionReprobarAltasCI(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerInformacionReprobarBajasCI(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerInformacionReprobarMemosVarios(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerGrillaReprobarAlta(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerGrillaReprobarBaja(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerGrillaReprobarRPT(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerGrillaReprobarAltaCI(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerGrillaReprobarBajaCI(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerGrillaReprobarMemosVarios(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract bool ActualizarReprobacionAlta(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract bool ActualizarReprobacionAltaCI(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract bool ActualizarReprobacionMemosVarios(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet ObtenerBajaID(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet ObtenerRPTID(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet ObtenerAltaCIDID(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet ObtenerBajaCIDID(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet ObtenerMemoVarioID(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet ObtenerValidacionBaja(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet ObtenerMovimientosValidados(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet ObtenerAltaID(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerDatosInformacionAltasCIGrilla(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerDatosInformacionBajasCIGrilla(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet obtenerDatosInformacionMemosVariosGrilla(cls_mp_seguimiento_memorandum _mp_seguimiento_memorandum);
        public abstract DataSet ObtenerInformacionValidar(int per_id);
        public abstract DataSet ListarMovimientosParaReprobar(int pr_id, int per_id);


        #endregion

        #region _PERSONA
        public abstract bool Adicionar__persona(cls_persona _persona);
        public abstract bool AdicionarFoto(cls_persona _persona);
        public abstract DataSet FileVirtual(int cod_file, byte[]foto, int req_id, string fecha_doc, string fecha_registro, int per_id, string obs, string estado, string accion);
        public abstract int AdicionarFileVirtualPDF(int cod_file, byte[] foto, int req_id, string fecha_doc, string fecha_registro, int per_id, string obs, string estado, string nombre, string accion);
        public abstract DataSet MostrarFileVirtualPDF(int per_id, string observacion);
        public abstract IDataReader MostrarFileVirtualPDF_DR(int per_id, string observacion);
        public abstract DataSet MostrarFileVirtualPDF_PorPdf_id(int per_id, int pdf_id);
        public abstract DataSet MostrarFileVirtualPDF_PorPdf_Per_id(int per_id, int pdf_id);
        public abstract DataSet EliminarFileVirtualPDF(int pdf_id);
        public abstract bool ActualizarFileVirtualPDF(DateTime fecha_doc, string obs, int pdf_id);


        public abstract bool Actualizar__persona(cls_persona _persona);
        public abstract bool Eliminar__persona(cls_persona _persona);
        public abstract bool ObtenerId__persona(cls_persona _persona);
        public abstract DataSet ObtenerRegistroFoto(cls_persona _persona);
        // (MICM) Consulta un registro de la tabla _persona
        public abstract bool ObtenerRegistro__persona(cls_persona _persona);
        public abstract DataSet ObtenerTablaGrilla__persona(
            string per_id,
            string per_tipo_doc,
            string per_num_doc,
            string per_lugar_exp,
            string per_ap_paterno,
            string per_ap_materno,
            string per_nombres,
            string per_ap_casada,
            string per_sexo,
            string per_fecha_nac,
            string per_procedencia,
            string per_serie_libreta_militar,
            string per_lugar_nac,
            string per_estado_civil);
        public abstract DataSet ObtenerTablaGrilla__personaLicencias(
    string per_id,
    string per_tipo_doc,
    string per_num_doc,
    string per_lugar_exp,
    string per_ap_paterno,
    string per_ap_materno,
    string per_nombres,
    string per_ap_casada,
    string per_sexo,
    string per_fecha_nac,
    string per_procedencia,
    string per_serie_libreta_militar,
    string per_lugar_nac,
    string per_estado_civil);
        public abstract DataSet ObtenerTablaCombo__persona();
        // (KCPB) Ayuda a obtener la lista de personal sin asignaci�n
        public abstract DataSet ObtenerTablaGrillaSA__persona(
            string per_id,
            string per_num_doc,
            string per_ap_paterno,
            string per_ap_materno,
            string per_nombres,
            string per_ap_casada);
        // (KCPB) Consulta un registro de la tabla _persona
        public abstract DataSet ObtenerRegistroX__persona(cls_persona _persona);
        // (Kevin Carlos Prado Bustillos) Obtienen todos los registros de la tabla para llenar una grilla (filtrando varios datos)
        public abstract DataSet ObtenerRegistroX__personaCV(cls_persona _persona);

        public abstract DataSet ObtenerTablaGrillaHM__persona(
            string per_id,
            string per_num_doc,
            string per_ap_paterno,
            string per_ap_materno,
            string per_nombres,
            string as_pr_id,
            string eo_id,
            string cp_ue,
            string ti_tipo,
            string as_estado);
        // (JQC) Consultas
        public abstract DataSet ObtenerTablaGrilla__persona_planta(
            string per_id,
            string per_tipo_doc,
            string per_num_doc,
            string per_lugar_exp,
            string per_ap_paterno,
            string per_ap_materno,
            string per_nombres,
            string per_ap_casada,
            string per_sexo,
            string per_fecha_nac,
            string per_procedencia,
            string per_serie_libreta_militar,
            string per_lugar_nac,
            string per_estado_civil);
        public abstract DataSet ObtenerTablaGrilla__persona_plantaVacaciones(
            string per_id,
            string per_tipo_doc,
            string per_num_doc,
            string per_lugar_exp,
            string per_ap_paterno,
            string per_ap_materno,
            string per_nombres,
            string per_ap_casada,
            string per_sexo,
            string per_fecha_nac,
            string per_procedencia,
            string per_serie_libreta_militar,
            string per_lugar_nac,
            string per_estado_civil);
        public abstract DataSet ObtenerTablaGrilla__persona_concejo(
            string per_id,
            string per_tipo_doc,
            string per_num_doc,
            string per_lugar_exp,
            string per_ap_paterno,
            string per_ap_materno,
            string per_nombres,
            string per_ap_casada,
            string per_sexo,
            string per_fecha_nac,
            string per_procedencia,
            string per_serie_libreta_militar,
            string per_lugar_nac,
            string per_estado_civil,
            int gestion);
        public abstract DataSet ObtenerTablaGrilla__persona_ejecutivo(
            string per_id,
            string per_tipo_doc,
            string per_num_doc,
            string per_lugar_exp,
            string per_ap_paterno,
            string per_ap_materno,
            string per_nombres,
            string per_ap_casada,
            string per_sexo,
            string per_fecha_nac,
            string per_procedencia,
            string per_serie_libreta_militar,
            string per_lugar_nac,
            string per_estado_civil);

        public abstract DataSet ObtenerTablaGrilla__persona_gamlp(
            string per_id,
            string per_tipo_doc,
            string per_num_doc,
            string per_lugar_exp,
            string per_ap_paterno,
            string per_ap_materno,
            string per_nombres,
            string per_ap_casada,
            string per_sexo,
            string per_fecha_nac,
            string per_procedencia,
            string per_serie_libreta_militar,
            string per_lugar_nac,
            string per_estado_civil);
        public abstract DataSet ObtenerTablaGrilla__persona_FechaIngreso(
            string per_id,
            string per_tipo_doc,
            string per_num_doc,
            string per_lugar_exp,
            string per_ap_paterno,
            string per_ap_materno,
            string per_nombres,
            string per_ap_casada,
            string per_sexo,
            string per_fecha_nac,
            string per_procedencia,
            string per_serie_libreta_militar,
            string per_lugar_nac,
            string per_estado_civil);
        public abstract DataSet ObtenerTablaGrilla__persona_plantaContrato(
            string per_id,
            string per_tipo_doc,
            string per_num_doc,
            string per_lugar_exp,
            string per_ap_paterno,
            string per_ap_materno,
            string per_nombres,
            string per_ap_casada,
            string per_sexo,
            string per_fecha_nac,
            string per_procedencia,
            string per_serie_libreta_militar,
            string per_lugar_nac,
            string per_estado_civil,
            int gestion);

        public abstract DataSet ObtenerTablaGrilla__personaGamlp_AfiliacionEGS(
            string per_id,
            string per_tipo_doc,
            string per_num_doc,
            string per_lugar_exp,
            string per_ap_paterno,
            string per_ap_materno,
            string per_nombres,
            string per_ap_casada,
            string per_sexo,
            string per_fecha_nac,
            string per_procedencia,
            string per_serie_libreta_militar,
            string per_lugar_nac,
            string per_estado_civil,
            string fa_id,
            string ae_estado);

        public abstract DataSet ObtenerTablaGrilla__persona_plantaTecLab(
        string per_id,
        string per_tipo_doc,
        string per_num_doc,
        string per_lugar_exp,
        string per_ap_paterno,
        string per_ap_materno,
        string per_nombres,
        string per_ap_casada,
        string per_sexo,
        string per_fecha_nac,
        string per_procedencia,
        string per_serie_libreta_militar,
        string per_lugar_nac,
        string per_estado_civil,
        int pr_id);
        public abstract DataSet ObtenerTablaGrillaPCED__persona(
            string per_id,
            string per_num_doc,
            string per_ap_paterno,
            string per_ap_materno,
            string per_nombres,
            string per_ap_casada);

        public abstract DataSet ObtenerTablaGrilla__persona_gamlpVigente(
        string per_id,
        string per_tipo_doc,
        string per_num_doc,
        string per_lugar_exp,
        string per_ap_paterno,
        string per_ap_materno,
        string per_nombres,
        string per_ap_casada,
        string per_sexo,
        string per_fecha_nac,
        string per_procedencia,
        string per_serie_libreta_militar,
        string per_lugar_nac,
        string per_estado_civil);
        public abstract DataSet ObtenerTablaGrilla__gamlp_vigente(
        string per_id,
        string per_tipo_doc,
        string per_num_doc,
        string per_lugar_exp,
        string per_ap_paterno,
        string per_ap_materno,
        string per_nombres,
        string per_ap_casada,
        string per_sexo,
        string per_fecha_nac,
        string per_procedencia,
        string per_serie_libreta_militar,
        string per_lugar_nac,
        string per_estado_civil,
        int pr_id);
        public abstract DataSet ObtenerTablaGrilla__gamlp_vigente_ex_preocupacional(
        string per_id,
        string per_tipo_doc,
        string per_num_doc,
        string per_lugar_exp,
        string per_ap_paterno,
        string per_ap_materno,
        string per_nombres,
        string per_ap_casada,
        string per_sexo,
        string per_fecha_nac,
        string per_procedencia,
        string per_serie_libreta_militar,
        string per_lugar_nac,
        string per_estado_civil,
        int pr_id);
        public abstract DataSet ObtenerTablaGrilla__gamlp_finiquito(
        string per_id,
        string per_tipo_doc,
        string per_num_doc,
        string per_lugar_exp,
        string per_ap_paterno,
        string per_ap_materno,
        string per_nombres,
        string per_ap_casada,
        string per_sexo,
        string per_fecha_nac,
        string per_procedencia,
        string per_serie_libreta_militar,
        string per_lugar_nac,
        string per_estado_civil,
        int pr_id);

        public abstract DataSet VerificarNuevoFuncionario(string ci, int per_id);
        public abstract bool Actualizar__personaConLibreta(cls_persona _persona);

        #endregion

        #region _PERSONA_DOMICILIO
        public abstract bool Adicionar__persona_domicilio(cls_persona_domicilio _persona_domicilio);
        public abstract bool AdicionarDomicilioKardex(cls_persona_domicilio _persona_domicilio, int file_id_cod, string per_num_lib);
        public abstract bool Actualizar__persona_domicilio(cls_persona_domicilio _persona_domicilio);
        public abstract bool Eliminar__persona_domicilio(cls_persona_domicilio _persona_domicilio);
        public abstract bool ObtenerRegistro__persona_domicilio(cls_persona_domicilio _persona_domicilio);
        public abstract DataSet ObtenerTablaGrilla__persona_domicilio(
            string perd_id,
            string perd_per_id,
            string perd_ciudad_residencia,
            string perd_zona,
            string perd_tipo_via,
            string perd_descripcion_via,
            string perd_numero,
            string perd_telefono,
            string perd_celular,
            string perd_email,
            string perd_estado);
        public abstract DataSet ObtenerTablaCombo__persona_domicilio();
        public abstract DataSet ObtenerDatosFile(cls_persona_domicilio _persona_domicilio);
        public abstract DataSet VerificarExisteFile(int file_id_cod);
        public abstract bool ActualizarTelefonosFun(cls_persona_domicilio _persona_domicilio);
        public abstract bool Actualizar__Informacion_persona_domicilio(cls_persona_domicilio _persona_domicilio);

        #endregion

        #region _PERSONA_FAMILIARES
        public abstract bool Adicionar__persona_familiares(cls_persona_familiares _persona_familiares);
        public abstract bool Actualizar__persona_familiares(cls_persona_familiares _persona_familiares);
        public abstract bool ActualizarEstadoFam(cls_persona_familiares _persona_familiares);
        public abstract bool Eliminar__persona_familiares(cls_persona_familiares _persona_familiares);
        public abstract bool ObtenerId__persona_familiares(cls_persona_familiares _persona_familiares);
        public abstract bool ObtenerRegistro__persona_familiares(cls_persona_familiares _persona_familiares);
        public abstract DataSet ObtenerTablaGrilla__persona_familiares(
            string pf_id,
            string pf_per_id,
            string pf_tipo_parentesco,
            string pf_paterno,
            string pf_materno,
            string pf_nombres,
            string pf_ap_esposo,
            string pf_fecha_nac,
            string pf_estado,
            string pf_estado_vivo,
            string pf_fecha_defuncion);
        public abstract DataSet ObtenerTablaCombo__persona_familiares();
        public abstract DataSet ObtenerGrillaFamiliares(cls_persona_familiares _persona_familiares);
        public abstract DataSet ObtenerFamilarX(cls_persona_familiares _persona_familiares);
        public abstract DataSet ObtenerPersonaFamilarX(cls_persona_familiares _persona_familiares);
        #endregion

        #region _MP_CARGO
        public abstract bool Adicionar__mp_cargo(cls_mp_cargo _mp_cargo);
        public abstract bool Actualizar__mp_cargo(cls_mp_cargo _mp_cargo);
        public abstract bool Eliminar__mp_cargo(cls_mp_cargo _mp_cargo);
        public abstract bool ObtenerId__mp_cargo(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerRegistro__mp_cargo(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerTablaGrilla__mp_cargo(string ca_id,
                        string ca_es_id,
                        string ca_eo_id,
                        string ca_ti_item,
                        string ca_num_item,
                        string ca_estado,
                        string ca_aplica_incremento,
                        string ca_tipo_jornada);
        public abstract DataSet ObtenerTablaCombo__mp_cargo();

        public abstract bool AdicionarTenor(cls_mp_cargo _mp_cargo);
        public abstract bool ActualizacionTenor(cls_mp_cargo _mp_cargo);
        public abstract bool EliminarTenor(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerDetalleTenor(cls_mp_cargo _mp_cargo);
        public abstract DataSet VerificarMemorandum(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerDetalleFuncionario(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerDetalleFuncionarioBajas(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerDetalleFuncionarioPRTAcefalias(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerDetalleFuncionarioPRTCargos(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerDetalleFuncionarioAComInt(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerDetalleFuncionarioBComInt(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerDetalleFuncionarioADispPersonal(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerDetalleFuncionarioBDispPersonal(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerDetalleFuncionarioMemosVarios(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerDetalleFuncionarioTransicion(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerDetalleFuncionarioSancion(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerGrillaTenor(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerDatosTenor(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerFiltradoTipoMov(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerFiltradoTipoItem(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerFiltradoTenor(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerFiltradoTipoMemoV(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerGestion(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerGrillaFiltro(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerNivelOrg(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerDescripcionNivelOrg(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerNivelOrgItems(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerFiltradoTipoDoc();
        public abstract DataSet ObtenerDetalleitem(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerFiltradoCargoUO(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerFiltradoTipoItemUO(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerFiltradoTipoItemUOCreacion(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerFiltradoTipoItemUOSuplencia(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerDetalleUO(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerIdCargo();
        public abstract DataSet ObtenerNroItem(cls_mp_cargo _mp_cargo);
        public abstract DataSet AdicionarCargoUO(cls_mp_cargo _mp_cargo);
        public abstract bool AdicionarGlosa(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerGrillaItems(cls_mp_cargo _mp_cargo);
        public abstract DataSet ModificarItemPlanta(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerDetalleitemCargo(cls_mp_cargo _mp_cargo, string gestion_selec);
        public abstract bool ActualizarItem(cls_mp_cargo _mp_cargo);
        public abstract bool ActualizarMemoAsignacion(cls_mp_cargo _mp_cargo);
        public abstract bool EliminarItem(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerCargoX(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerFiltradoGestion();
        public abstract DataSet ObtenerNivelOrgEjecutivo(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerDetalleItemEjecutivo(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerNivelOrgItemsEjecutivo(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerDatosDetalleFuncionario(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerNivelItemsLibres(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerDetalleItemsLibre(cls_mp_cargo _mp_cargo);

        //FUNCIONES JQC
        public abstract DataSet ObtenerNivelOrganizacional(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerFiltradoEstrucOrg(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerNivelOrganizacionalItems(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerDetalleItem(cls_mp_cargo _mp_cargo);
        public abstract bool obtenerDatosFuncionario(cls_mp_cargo _mp_cargo);
        public abstract bool obtenerDatosFuncionarioConAsignaciones(cls_mp_cargo _mp_cargo);
        public abstract DataSet obtenerTipoMovPadre(cls_mp_cargo _mp_cargo);
        public abstract DataSet obtenerFiltradoTipoMov(cls_mp_cargo _mp_cargo);
        public abstract DataSet obtenerFiltradoTipoDoc();
        public abstract bool AdicionarPromocion(cls_mp_cargo _mp_cargo);
        public abstract bool AdicionarNuevoCargo(cls_mp_cargo _mp_cargo);
        public abstract bool ActualizarAsignacion(cls_mp_cargo _mp_cargo);
        public abstract bool ActualizarCargoActual(cls_mp_cargo _mp_cargo);
        public abstract bool AdicionarCargoActual(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerIdCargoA();
        public abstract bool ActualizarCargoNuevo(cls_mp_cargo _mp_cargo);
        public abstract bool AdicionarCargoNuevo(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerAsignacion(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerGrillaItemPlanta(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerNivelOrgConcejo(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerFiltradoCargoHB(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerNivelSalarial(cls_mp_cargo _mp_cargo);
        public abstract DataSet obtenerNombreUO(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerIdCargoPlantaC();
        public abstract bool AdicionarCargoPlanta(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerGrillaItemConsejo(cls_mp_cargo _mp_cargo);
        public abstract DataSet obtenerFiltradoTipoAsignacion();
        public abstract DataSet obtenerFiltradoTipoMovInterinato(cls_mp_cargo _mp_cargo);
        public abstract bool obtenerDatosFuncionarioConsejo(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerBusquedaItem(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerAsignacionX(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerNivelOrganizacionalItemsMasAcefalia(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerDetalleItemPlanta(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerListaItemPlanta(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerListaCargoPlanta(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerListaPuestoPlanta(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerListaTipoItemPlanta(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerPuestoPlanta(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerGrillaItem(cls_mp_cargo _mp_cargo);

        // (KCPB) Ayuda a obtener una lista de items acefalos para personal de contrato
        public abstract DataSet ObtenerGrillaItemsCP(cls_mp_cargo _mp_cargo);
        // (KCPB) Ayuda a obtener el detalle del item acefalo para personal de contrato
        public abstract DataSet ObtenerDetalleItemCP(cls_mp_cargo _mp_cargo);
        public abstract DataSet ObtenerDetalleItemCP_num_item(cls_mp_cargo _mp_cargo);

        public abstract DataSet ObtenerTipoJornada();
        public abstract DataSet ObtenerInfoParaTenorMemorandums(cls_mp_cargo _mp_cargo);
        public abstract string Obtener_CaId(string num_item, string pr_id);
        public abstract DataSet ObtenerItem_MoverFuente(string ca_id);
        public abstract DataSet ObtenerItem_MoverFuente_Grilla(string num_item, string pr_id);

        public abstract DataSet ObtenerUnidades_MoverFuente(string ca_id);
        public abstract int Modificar_FuenteFinanciamiento(string eo_id, string cod_proceso, string ca_id);
        public abstract DataSet TotalesFuenteFinanciamiento(string cod_proceso);
        public abstract DataSet ConsultaSiPlanillaEstaEjecutada(string cod_proceso);
        public abstract DataSet ConsultaSiPlanillaEstaEjecutada_adicional(string cod_proceso, string secuencial);

        public abstract DataSet BuscarParaAdicionales(string ci, string cod_proceso);
        public abstract bool InsertarCasosParaAdicionales(string cod_proceso, string as_id);
        public abstract DataSet MostrarCasosAdicionales(string cod_proceso);
        public abstract bool EliminarCasosAdicional(string ad_as_id, string cod_proceso, string secuencial);
        //MP
        public abstract DataSet ObtenerListaFiltradoEstOrgMP(cls_mp_estructura_organizacional _mp_estructura_organizacional);
        public abstract DataSet ObtenerNivelOrgMP(cls_mp_cargo _mp_cargo);
        #endregion

        #region _MP_ASIGNACION
        public abstract int Adicionar__mp_asignacion(cls_mp_asignacion _mp_asignacion);
        public abstract bool Actualizar__mp_asignacion(cls_mp_asignacion _mp_asignacion);
        public abstract bool Eliminar__mp_asignacion(cls_mp_asignacion _mp_asignacion);
        public abstract DataSet ObtenerRegistro__mp_asignacion(cls_mp_asignacion _mp_asignacion);
        public abstract DataSet ObtenerTablaGrilla__mp_asignacion(
            string as_id,
            string as_per_id,
            string as_ca_id,
            string as_fecha_inicio,
            string as_fecha_fin,
            string as_estado,
            string as_tipo_reg,
            string as_tipo_mov,
            string as_tipo_baja,
            string as_validacion,
            string as_fecha_validacion,
            string as_memo,
            string as_memo_baja,
            string as_pr_id);
        public abstract DataSet ObtenerTablaCombo__mp_asignacion();
        // (MICM) Método que obtiene Ultima Asignacion Laboral
        public abstract DataSet ObtenerUltimaAsignacionLaboral_mp_asignacion(cls_mp_asignacion _mp_asignacion);
        // (KCPB)
        public abstract DataSet ObtenerTablaGrillaC__mp_asignacion(
            string as_id,
            string as_per_id,
            string as_ca_id,
            string as_fecha_inicio,
            string as_fecha_fin,
            string as_estado,
            string as_tipo_reg,
            string as_tipo_mov,
            string as_tipo_baja,
            string as_validacion,
            string as_fecha_validacion,
            string as_memo,
            string as_memo_baja,
            string as_pr_id);
        public abstract DataSet ObtenerTablaGrillaC__mp_asignacion2(
    string as_id,
    string as_per_id,
    string as_ca_id,
    string as_fecha_inicio,
    string as_fecha_fin,
    string as_estado,
    string as_tipo_reg,
    string as_tipo_mov,
    string as_tipo_baja,
    string as_validacion,
    string as_fecha_validacion,
    string as_memo,
    string as_memo_baja,
    string as_pr_id);

        // (Kevin Carlos Prado Bustillos) Realiza el registro de la baja de asignación del funcionario
        public abstract bool ActualizarBaja__mp_asignacion(cls_mp_asignacion _mp_asignacion);
        public abstract DataSet ObtenerASignacion(cls_mp_asignacion _mp_asignacion);
        // (Kevin Carlos Prado Bustillos) Obtiene el detalle del puesto de un precontratado para su asignación
        public abstract DataSet ObtenerPuestoPreContratado__mp_asignacion(cls_mp_asignacion _mp_asignacion);

        // (JQC)
        public abstract DataSet ListaFiltradoTipoMovimiento();
        public abstract DataSet ObtenerDatosInformacionAlta(cls_mp_asignacion _mp_asignacion);
        public abstract DataSet ObtenerDatosInformacionBaja(cls_mp_asignacion _mp_asignacion);
        public abstract DataSet ObtenerDatosInformacionRPT(cls_mp_asignacion _mp_asignacion);
        public abstract bool ReprobarAlta(cls_mp_asignacion _mp_asignacion);
        public abstract bool ReprobarBaja(cls_mp_asignacion _mp_asignacion);
        public abstract bool ReprobarRPT(cls_mp_asignacion _mp_asignacion);
        public abstract bool ReprobarRPTConcejo(cls_mp_asignacion _mp_asignacion);
        public abstract DataSet ObtenerGrillaReprobacionMov(cls_mp_asignacion _mp_asignacion);
        public abstract DataSet ObtenerEscalafonDocente();
        public abstract bool InsertarEscalafonDocente(int ed_id, int per_id, string accion);
        public abstract bool InsertarTipoAportante(int per_id);
        public abstract string ConsultarValidacion(int as_id);
        public abstract bool ActualizarFechaInicioYBaja(cls_mp_asignacion _mp_asignacion);
        public abstract bool ActualizarEscalafonDocente(int per_id, int aed_ed_id);
        public abstract DataSet ObtenerTodasLasAsignacionesVigentes(int per_id);
        public abstract DataSet VerificarAsignacionEscalafon(int per_id);
        public abstract DataSet VerificarItemAdministrativo(int ca_id, int per_id);
        public abstract DataSet ObtenerTablaGrilla__AsignacionesPersona(
            string per_id,
            string per_tipo_doc,
            string per_num_doc,
            string per_lugar_exp,
            string per_ap_paterno,
            string per_ap_materno,
            string per_nombres,
            string per_ap_casada,
            string per_sexo,
            string per_fecha_nac,
            string per_procedencia,
            string per_serie_libreta_militar,
            string per_lugar_nac,
            string per_estado_civil);
        public abstract DataSet ObtenerTablaGrilla__AsignacionesPersona_SoloDocentes(
            string per_id,
            string per_tipo_doc,
            string per_num_doc,
            string per_lugar_exp,
            string per_ap_paterno,
            string per_ap_materno,
            string per_nombres,
            string per_ap_casada,
            string per_sexo,
            string per_fecha_nac,
            string per_procedencia,
            string per_serie_libreta_militar,
            string per_lugar_nac,
            string per_estado_civil);

        public abstract DataSet ObtenerTablaGrilla__AsignacionesPersonaComision(
            string as_id,
            string as_per_id,
            string as_ca_id,
            string as_fecha_inicio,
            string as_fecha_fin,
            string as_estado,
            string as_tipo_reg,
            string as_tipo_mov,
            string as_tipo_baja,
            string as_validacion,
            string as_fecha_validacion,
            string as_memo,
            string as_memo_baja,
            string as_pr_id);
        public abstract bool InsertarFechaIngreso(int per_id, string fecha, string estado);
        public abstract DataSet MostrarFechasIngreso();

        #endregion

        #region _MP_INCOMPATIBILIDAD_FUN
        public abstract int Adicionar__mp_incompatibilidad_fun(cls_mp_incompatibilidad_fun _mp_incompatibilidad_fun);
        public abstract bool Actualizar__mp_incompatibilidad_fun(cls_mp_incompatibilidad_fun _mp_incompatibilidad_fun);
        public abstract bool Eliminar__mp_incompatibilidad_fun(cls_mp_incompatibilidad_fun _mp_incompatibilidad_fun);
        public abstract bool ObtenerId__mp_incompatibilidad_fun(cls_mp_incompatibilidad_fun _mp_incompatibilidad_fun);
        public abstract bool ObtenerRegistro__mp_incompatibilidad_fun(cls_mp_incompatibilidad_fun _mp_incompatibilidad_fun);
        public abstract DataSet ObtenerTablaGrilla__mp_incompatibilidad_fun(
            string if_id,
            string if_per_id,
            string if_per_id_pariente,
            string if_parentesco,
            string if_estado);
        public abstract DataSet ObtenerTablaCombo__mp_incompatibilidad_fun();
        // (Kevin Carlos Prado Bustillos) Obtiene todos los registros de coincidencias dependiendo del funcionario
        public abstract DataSet ObtenerTablaGrillaC__mp_incompatibilidad_fun(
            string per_id,
            string per_ap_paterno,
            string per_ap_materno);
        #endregion

        #region _MP_TIPO_ABONO
        public abstract DataSet Adicionar__mp_tipo_abono(cls_mp_tipo_abono _mp_tipo_abono);
        public abstract bool Actualizar__mp_tipo_abono(cls_mp_tipo_abono _mp_tipo_abono);
        public abstract bool Eliminar__mp_tipo_abono(cls_mp_tipo_abono _mp_tipo_abono);
        public abstract bool ObtenerId__mp_tipo_abono(cls_mp_tipo_abono _mp_tipo_abono);
        public abstract bool ObtenerRegistro__mp_tipo_abono(cls_mp_tipo_abono _mp_tipo_abono);
        public abstract DataSet ObtenerGrillaCuentas(cls_mp_tipo_abono _mp_tipo_abono);
        public abstract DataSet ObtenerTablaCombo__mp_tipo_abono();
        // (MICM) Ayuda a obtener el �ltimo tipo de abono
        public abstract DataSet ObtenerUltimoTipoAbono__mp_tipoabono(cls_mp_tipo_abono _mp_tipo_abono);
        // (MICM) Ayuda a verificar que el n�mero de cuenta exist
        public abstract DataSet VerificarCuentaExistente__mp_tipoabono(cls_mp_tipo_abono _mp_tipo_abono);
        // (MICM) Ayuda a obtener el tipo de abono por funcionario
        public abstract DataSet ObteneTipoAbonoporPersona__mp_tipoabono(cls_mp_tipo_abono _mp_tipo_abono);
        public abstract DataSet ObteneTipoAbonoVigente(cls_mp_tipo_abono _mp_tipo_abono);
        #endregion

        #region PLAN
        public abstract DataSet ObtenerArea__plan();
        public abstract bool AdicionarPlan__nuevo(cls_materia materia);
        public abstract DataSet ObtenerCarrera__plan(cls_materia materia);
        public abstract DataSet ObtenerPlan_C(cls_materia materia);
        public abstract DataSet ObtenerPlan__G();
        public abstract bool CambiarEstadoPlan(cls_materia materia);
        #endregion

        #region MATERIA
        public abstract bool AdicionarHoras(cls_materia materia);
        public abstract bool AddicionarMatCa(cls_materia materia);
        public abstract DataSet BuscarMateria2(cls_materia materia);
        public abstract DataSet ListarCargosDocente(cls_materia materia);
        public abstract bool AdicionarMateria(cls_materia materia);
        public abstract DataSet BuscarMateria(cls_materia materia);
        public abstract bool EliminarMateria(cls_materia materia);
        public abstract DataSet ObtenerEO(int per_id);
        public abstract string AdicionarAsignacion(cls_materia materia);
        public abstract string horas(int mat_id);
        public abstract DataSet Estructura(int asig, string carre);
        public abstract int ObtenerTablaGrilla__Doc(string as_per_id);
        public abstract int ObtenerEscalafon(int per_id);
        #endregion

        #region FALTAS Y ATRASOS
        public abstract DataSet ObtenerUnidadesOrganizacionales_filtrado_docentes(int per_id);
        public abstract DataSet DOCENTES_ListarGrillaDocentesMesPorUnidad(int eo_id);
        public abstract DataSet Docente_ModificarHorasFaltasAtrasos(cls_materia materia);
        public abstract string btnValidar(int per_id);
        public abstract bool CambiarEstadoHT(int eo_id);
        public abstract bool CambiarEstadoHT2(int eo_id);
        public abstract bool CambiarEstadoHT3(int eo_id);
        public abstract bool CambiarEstadoAsig(int as_id);
        public abstract bool CambiarEstadoAsig2(int as_id);

        #endregion
    }
}


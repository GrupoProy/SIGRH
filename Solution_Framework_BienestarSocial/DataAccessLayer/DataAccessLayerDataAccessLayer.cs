using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

using Solution_Framework_BienestarSocial.BussinessLogicLayer;

namespace Solution_Framework_BienestarSocial.DataAccessLayer
{
	public abstract class DataAccessLayerDataAccessLayer
	{
		#region INSTANCIA PRINCIPAL DE CONEXION A UNA BD
		public Database CNXSIGRH3 = DatabaseFactory.CreateDatabase("CnxSigrh3"); 
        #endregion

        // INTERFACES
		#region _BS_ENFERMEDADES_RECURRENTES
		public abstract bool Adicionar__bs_enfermedades_recurrentes(cls_bs_enfermedades_recurrentes _bs_enfermedades_recurrentes);
		public abstract bool Actualizar__bs_enfermedades_recurrentes(cls_bs_enfermedades_recurrentes _bs_enfermedades_recurrentes);
		public abstract bool Eliminar__bs_enfermedades_recurrentes(cls_bs_enfermedades_recurrentes _bs_enfermedades_recurrentes);
		public abstract bool ObtenerId__bs_enfermedades_recurrentes(cls_bs_enfermedades_recurrentes _bs_enfermedades_recurrentes);
		public abstract bool ObtenerRegistro__bs_enfermedades_recurrentes(cls_bs_enfermedades_recurrentes _bs_enfermedades_recurrentes);
        public abstract DataSet ObtenerTablaGrilla__bs_enfermedades_recurrentes(cls_bs_enfermedades_recurrentes _bs_enfermedades_recurrentes);
        public abstract DataSet ObtenerTablaCombo__bs_enfermedades_recurrentes();
		#endregion

		#region _BS_AGENTE_EXPUESTO
		public abstract bool Adicionar__bs_agente_expuesto(cls_bs_agente_expuesto _bs_agente_expuesto);
		public abstract bool Actualizar__bs_agente_expuesto(cls_bs_agente_expuesto _bs_agente_expuesto);
		public abstract bool Eliminar__bs_agente_expuesto(cls_bs_agente_expuesto _bs_agente_expuesto);
		public abstract bool ObtenerId__bs_agente_expuesto(cls_bs_agente_expuesto _bs_agente_expuesto);
		public abstract DataSet ObtenerRegistro__bs_agente_expuesto(cls_bs_agente_expuesto _bs_agente_expuesto);
		public abstract DataSet ObtenerTablaGrilla__bs_agente_expuesto(string agexp_id, 
						string agexp_fisico, 
						string agexp_quimico, 
						string agexp_biologico, 
						string agexp_psicosocial, 
						string agexp_estado);
		public abstract DataSet ObtenerTablaCombo__bs_agente_expuesto();
		public abstract DataSet ObtenerAgentesExpFisico(cls_bs_agente_expuesto _bs_agente_expuesto);
		public abstract DataSet ObtenerAgentesExpQuimico(cls_bs_agente_expuesto _bs_agente_expuesto);
		public abstract DataSet ObtenerAgentesExpBilogico(cls_bs_agente_expuesto _bs_agente_expuesto);
		public abstract DataSet ObtenerAgentesExpPsicosocial(cls_bs_agente_expuesto _bs_agente_expuesto);
		#endregion

		#region _BS_EXAMEN_PREOCUPACIONAL
		public abstract DataSet Adicionar__bs_examen_preocupacional(cls_bs_examen_preocupacional _bs_examen_preocupacional);
		public abstract bool Actualizar__bs_examen_preocupacional(cls_bs_examen_preocupacional _bs_examen_preocupacional);
		public abstract bool Eliminar__bs_examen_preocupacional(cls_bs_examen_preocupacional _bs_examen_preocupacional);
		public abstract bool ObtenerId__bs_examen_preocupacional(cls_bs_examen_preocupacional _bs_examen_preocupacional);
		public abstract bool ObtenerRegistro__bs_examen_preocupacional(cls_bs_examen_preocupacional _bs_examen_preocupacional);
		public abstract DataSet ObtenerTablaGrilla__bs_examen_preocupacional(string exp_id, 
						string exp_per_id, 
						string exp_fecha_elab, 
						string exp_carts_puesto, 
						string exp_fecha_examen, 
						string exp_estado, 
						string exp_diagnostico, 
						string exp_comentario, 
						string exp_recomendaciones, 
						string exp_fecha_recep_Funcionario, 
						string exp_n_historia_clinica, 
						string exp_medico, 
						string exp_n_autorizacion, 
						string exp_convenio, 
						string exp_fecha_prog, 
						string exp_tel_of_fun, 
						string exp_tel_dom_fun, 
						string exp_obsaut, 
						string exp_importe, 
						string exp_tipo_sangre, 
						string exp_correlativo_gestion_n_autorizacion, 
						string exp_correlativo_fecha_registro_n_autorizacion, 
						string exp_as_id);
		public abstract DataSet ObtenerTablaCombo__bs_examen_preocupacional();
		public abstract DataSet ObtenerDatosFuncionario(cls_bs_examen_preocupacional _bs_examen_preocupacional);
		public abstract DataSet ObtenerNroAutorizacion(cls_bs_examen_preocupacional _bs_examen_preocupacional);
		public abstract DataSet ObtenerExamenesRealizados(cls_bs_examen_preocupacional _bs_examen_preocupacional);
		public abstract DataSet ObtenerTelefonos(cls_bs_examen_preocupacional _bs_examen_preocupacional);
		public abstract DataSet ObtenerExamenProgramado(cls_bs_examen_preocupacional _bs_examen_preocupacional);
		public abstract bool ReprogramarExamen(cls_bs_examen_preocupacional _bs_examen_preocupacional);
		public abstract bool DeclararExamen(cls_bs_examen_preocupacional _bs_examen_preocupacional);
        public abstract DataSet ObtenerDatosFuncionarioExamen(cls_bs_examen_preocupacional _bs_examen_preocupacional);
		#endregion

		#region _BS_AFILIACION_EGS
		public abstract DataSet ListarBenef(int per_id);
		public abstract bool CambiarMatricula(cls_bs_afiliacion_egs afili);
		public abstract bool Adicionar__bs_afiliacion_egs(cls_bs_afiliacion_egs _bs_afiliacion_egs);
		public abstract bool Actualizar__bs_afiliacion_egs(cls_bs_afiliacion_egs _bs_afiliacion_egs);
		public abstract bool Eliminar__bs_afiliacion_egs(cls_bs_afiliacion_egs _bs_afiliacion_egs);
		public abstract bool ObtenerId__bs_afiliacion_egs(cls_bs_afiliacion_egs _bs_afiliacion_egs);
		public abstract DataSet ObtenerRegistro__bs_afiliacion_egs(cls_bs_afiliacion_egs _bs_afiliacion_egs);
		public abstract DataSet ObtenerTablaGrilla__bs_afiliacion_egs(
            string ae_id, 
			string ae_per_id, 
			string ae_as_id, 
			string ae_egs_id, 
			string ae_estado, 
			string ae_fecha_form, 
			string ae_policlinico, 
			string ae_fecha_baja_form, 
			string ae_fecha_baja_elab, 
			string ae_tipo_ingreso, 
			string ae_tipo_proceso_baja, 
			string ae_em_id);
		public abstract DataSet ObtenerTablaCombo__bs_afiliacion_egs();

		public abstract bool Adicionar_2_bs_afiliacion_egs(cls_bs_afiliacion_egs _bs_afiliacion_egs);
		#endregion

		#region _BS_ASIGNACION_BENEFICIO
		public abstract DataSet DatosFuncionario(int codigo, string nombre, string paterno, string materno, string esposo, string ci);
		public abstract bool Adicionar__bs_asignacion_beneficio(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
		public abstract bool Actualizar__bs_asignacion_beneficio(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
		public abstract bool Eliminar__bs_asignacion_beneficio(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
		public abstract bool ObtenerId__bs_asignacion_beneficio(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
		public abstract bool ObtenerRegistro__bs_asignacion_beneficio(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
		public abstract DataSet ObtenerTablaGrilla__bs_asignacion_beneficio(string ab_id, 
						string ab_aeb_id, 
						string ab_fa_id, 
						string ab_fecha_inicio, 
						string ab_fecha_fin, 
						string ab_estado, 
						string ab_tipo_beneficiario,
                        string pf_per_id);
		public abstract DataSet ObtenerTablaCombo__bs_asignacion_beneficio();

        public abstract DataSet VerificarSubsidioenMes__bs_asignacion_beneficio(
                       string ab_aeb_id,
                       string ab_fa_id,
                       string ab_fecha_inicio,
                       string ab_fecha_fin);

        // (JQC)
        public abstract DataSet listaFiltradoTipoBeneficio();
        public abstract DataSet listaFiltradoTipoMes();
        public abstract DataSet listaFiltradoTipoParentesco();
        public abstract DataSet listaFiltradoTipoGenero();
        public abstract DataSet listaFiltradoEstadoVivo();
        public abstract DataSet ObtenerFamiliar(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract DataSet ListarFamiliares(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract bool ActualizarDatosFamiliar(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract DataSet ObtenerTiempoMeses(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract DataSet ListarFamiliarEsposa(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract DataSet ListarFamiliaresBeneficiarios(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract DataSet obtenerIdBeneficio(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract DataSet ObtenerDatosDetalleFuncionario(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract DataSet listaFiltradoCajaAseguradora();
        public abstract DataSet listaFiltradoPoliclinico();
        public abstract DataSet ListarFamiliaresAfiliados(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract bool ActualizarDatosAfiliacion(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract DataSet obtenerIdAfiliacionEGS(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract DataSet ObtenerAfiliacionX(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract DataSet obtenerIdEmpleador(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract bool AdicionarPoliclinico(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract DataSet ObtenerDomicilio(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract bool AdicionarAfiliacionFamiliar(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract bool EliminarAfiliacionFamiliar(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract DataSet ListarFamiliaresAfiliadosEGS(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract bool ActualizarDatosDomicilio(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract DataSet VerificarAfiliacion(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract DataSet ObtenerFechaNacFamiliar(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract DataSet listaFiltradoEstadoAfiliacion();
        public abstract DataSet listaFiltradoTipoAvc();
        public abstract DataSet listaFiltradoTipoDocEsp();
        public abstract bool AdicionarFamiliar(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract DataSet ListarGrillaBajas(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract DataSet ObtenerFuncionarioBajaX(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract bool AdicionarFechaBajaForm(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract DataSet obtenerIdAsignacionEGS(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract DataSet ObtenerCantidadBajasEGS(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract DataSet listaFiltradoFamiliarBeneficio();
        public abstract DataSet ObtenerSubsidio(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract bool CancelarSubsidio(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract DataSet ListarGrillaValidacionBajas(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract bool AdicionarFechaRecepcionBaja(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract DataSet ObtenerFuncionarioValBajaX(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract DataSet ObtenerCantidadRecepBajasEGS(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
        public abstract DataSet ObtenerDatosAfiliacion(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
		public abstract bool AdicionarFamiliarNuevo(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
		#endregion

		#region _BS_AFP
		public abstract bool Adicionar__bs_afp(cls_bs_afp _bs_afp);
		public abstract bool Actualizar__bs_afp(cls_bs_afp _bs_afp);
		public abstract bool Eliminar__bs_afp(cls_bs_afp _bs_afp);
		public abstract DataSet ObtenerRegistro__bs_afp(cls_bs_afp _bs_afp);
		public abstract DataSet ObtenerTablaGrilla__bs_afp(string afp_id, 
						string afp_per_id, 
						string afp_previsora, 
						string afp_fecha_filiacion, 
						string afp_fecha_modificacion, 
						string afp_motivo_modificacion, 
						string afp_fecha_registro, 
						string afp_estado_carnet, 
						string afp_fecha_carnet, 
						string afp_usuario, 
						string afp_estado);
		public abstract DataSet ObtenerTablaCombo__bs_afp();
		public abstract DataSet ObtenerDetalleFuncionario(cls_bs_afp _bs_afp);
		public abstract DataSet ObtenerGrillaAFP(cls_bs_afp _bs_afp);
        public abstract bool CompletarDatosAFP(cls_bs_afp _bs_afp);
        public abstract bool ActualizarEstadoAFP(cls_bs_afp _bs_afp);
		public abstract bool ActualizarCuaNua(cls_bs_afp _bs_afp);
		public abstract bool ActualizarAfp(cls_bs_afp _bs_afp);

		#endregion

		#region BS_SUBSIDIO
		public abstract DataSet BuscarAfiliacionEGS(string per_id, string per_num_doc, string per_ap_paterno, string per_ap_materno, string per_nombres, string per_ap_casada);
		public abstract bool AdicionarAfiliacionFamiliarNuevo(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
		public abstract bool ActualizarDatosFamiliarNuevo(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
		public abstract DataSet ListarFamiliaresNuevo(cls_bs_asignacion_beneficio _bs_asignacion_beneficio);
		public abstract bool EditarDatosFamiliar(Subsidio familiar);
		public abstract DataSet ObtenerDatosPersona(int per_id);
		public abstract DataSet ObtenerDatosBeneficiario(int per_id);
		public abstract int VerificarAfiliacionFamiliar(int pf_id);
		#endregion
	}
}


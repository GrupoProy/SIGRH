using Microsoft.Practices.EnterpriseLibrary.Data;
using Solution_Framework_General.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
 
using System.Text;
using System.Threading.Tasks;

namespace Solution_Framework_General.DataAccessLayer
{
    public abstract class DataAccessLayerDataAccessLayer
    {
        #region INSTANCIA PRINCIPAL DE CONEXION A UNA BD
        public Database CNXGENERAL = DatabaseFactory.CreateDatabase("CnxGeneral");
        public Database CNXSIGRH3 = DatabaseFactory.CreateDatabase("CnxSigrh3");
        #endregion

        // INTERFACES
		#region _PERIODO
		public abstract bool Adicionar__periodo(cls_periodo _periodo);
		public abstract bool Actualizar__periodo(cls_periodo _periodo);
		public abstract bool Eliminar__periodo(cls_periodo _periodo);
		public abstract bool ObtenerId__periodo(cls_periodo _periodo);
		public abstract DataSet ObtenerRegistro__periodo(cls_periodo _periodo);
		public abstract DataSet ObtenerTablaGrilla__periodo(
            string pr_id, 
			string pr_gestion, 
			string pr_secuencial, 
			string pr_estado);
		public abstract DataSet ObtenerTablaCombo__periodo();
        public abstract DataSet ObtenerPeriodoVigente();
		#endregion

        #region _PLA_PROCESO
        public abstract bool Adicionar__pla_proceso(cls_pla_proceso _pla_proceso);
		public abstract bool Actualizar__pla_proceso(cls_pla_proceso _pla_proceso);
		public abstract bool Eliminar__pla_proceso(cls_pla_proceso _pla_proceso);
		public abstract bool ObtenerId__pla_proceso(cls_pla_proceso _pla_proceso);
		public abstract DataSet ObtenerRegistro__pla_proceso(cls_pla_proceso _pla_proceso);
		public abstract DataSet ObtenerTablaGrilla__pla_proceso(
            string pc_id, 
			string pc_pr_id, 
			string pc_titulo, 
			string pc_fecha_inicio, 
			string pc_fecha_fin, 
			string pc_mn_id, 
			string pc_ufv, 
			string pc_ufv_fecha, 
			string pc_estado, 
			string pc_prefijo);
		public abstract DataSet ObtenerTablaCombo__pla_proceso();
		#endregion

        #region HISTORICO
        public abstract bool Adicionar_historico(cls_historico historico);
        public abstract bool ObtenerId_historico(cls_historico historico);
        public abstract DataSet ObtenerRegistro_historico(cls_historico historico);
        public abstract DataSet ObtenerTablaGrilla_historico(
            string his_id,
            string his_tipo_abm,
            string his_nom_tabla,
            string his_nom_pk,
            string his_valor_pk,
            string his_campos,
            string his_fecha_creacion,
            string his_usuario_creacion);
        #endregion

        #region _CATALOGO
        public abstract bool Adicionar__catalogo(string cat_tabla, String cat_descripcion, string cat_abreviacion, string id_superior);
        public abstract bool AdicionarCatalogoSecuencial(cls_catalogo _catalogo);
        public abstract bool Actualizar__catalogo(cls_catalogo _catalogo);
        public abstract bool Eliminar__catalogo(cls_catalogo _catalogo);
        public abstract bool ObtenerId__catalogo(cls_catalogo _catalogo);
        public abstract DataSet ObtenerRegistro__catalogo(cls_catalogo _catalogo);
        public abstract DataSet ObtenerTablaGrilla__catalogo(
            string cat_id,
            string cat_tabla,
            string cat_secuencial,
            string cat_secuencial_op,
            string cat_descripcion,
            string cat_descripcion_op,
            string cat_abreviacion,
            string cat_id_superior,
            string cat_adicional,
            string cat_estado);
        public abstract DataSet ObtenerTablaCombo__catalogo(cls_catalogo _catalogo);
        // (KCPB) Ayuda a obtener el lugar de nacimiento
        public abstract DataSet ObtenerTablaComboSoloComision(cls_catalogo _catalogo);

        public abstract DataSet ObtenerLugarNacimiento__catalogo();
        // (MICM) Ayuda a obtener el banco autorizado vigente
        public abstract DataSet ObtenerBancoAutorizadoVigente__catalogo();
        // (MICM)
        public abstract DataSet ObtenerSancionesAisaVigente__catalogo();
        public abstract DataSet ObtenerRegistroPadre(cls_catalogo _catalogo);
        public abstract DataSet ObtenerCat_TablaPando(cls_catalogo _catalogo);
        public abstract DataSet ObtenerTablaCombo__catalogoFuncionario(cls_catalogo _catalogo);
        public abstract DataSet ObtenerDptoProvincia();
        #endregion

        #region _GLOSA
        public abstract bool Adicionar__glosa(cls_glosa _glosa);
        public abstract bool Actualizar__glosa(cls_glosa _glosa);
        public abstract bool Eliminar__glosa(cls_glosa _glosa);
        public abstract DataSet ObtenerRegistro__glosa(cls_glosa _glosa);
        public abstract DataSet ObtenerTablaGrilla__glosa(
            string gl_id,
            string gl_valor_pk,
            string gl_nombre_pk,
            string gl_tabla,
            string gl_tipo_mov,
            string gl_tipo_doc,
            string gl_glosa,
            string gl_numero_doc,
            string gl_fecha_doc,
            string gl_estado);
        public abstract DataSet ObtenerTablaCombo__glosa();
        // (Kevin Carlos Prado Bustillos) Obtiene todos los registros de la tabla para llenar una grilla
        public abstract DataSet ObtenerTablaGrillaC__glosa(
            string gl_id,
            string gl_valor_pk,
            string gl_nombre_pk,
            string gl_tabla,
            string gl_tipo_mov,
            string gl_tipo_doc,
            string gl_glosa,
            string gl_numero_doc,
            string gl_fecha_doc,
            string gl_estado);
        #endregion

        #region GRADO ACADEMICO
        public abstract DataSet ObtenerGradoAcademico();
        public abstract DataSet ComboFormacion(string accion);
        public abstract DataSet ComboFormacionCarreras(string accion);

        #endregion

        #region DISPOSITIVO
        public abstract int AdicionarDispositivo(string descrip, string ip, int edificio);
        public abstract DataSet ListarDispositivos();
        public abstract int EliminarDispositivo(int di_id);
        public abstract int EditarDispositivo(string descripcion, int edifi, string ip, int di_id);
        public abstract DataSet MostrarEdificios();
        #endregion
    }
}

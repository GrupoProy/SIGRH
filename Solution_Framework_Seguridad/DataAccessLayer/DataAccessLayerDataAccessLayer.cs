using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

using Solution_Framework_Seguridad.BussinessLogicLayer;

namespace Solution_Framework_Seguridad.DataAccessLayer
{
	public abstract class DataAccessLayerDataAccessLayer
	{
        #region INSTANCIA PRINCIPAL DE CONEXION A UNA BD
        public Database CNXGENERAL = DatabaseFactory.CreateDatabase("CnxGeneral");
        #endregion

        // INTERFACES
		#region _SEG_MENU_USUARIO
		public abstract bool Adicionar__seg_menu_usuario(cls_seg_menu_usuario _seg_menu_usuario);
		public abstract bool Actualizar__seg_menu_usuario(cls_seg_menu_usuario _seg_menu_usuario);
		public abstract bool Eliminar__seg_menu_usuario(cls_seg_menu_usuario _seg_menu_usuario);
		public abstract DataSet ObtenerRegistro__seg_menu_usuario(cls_seg_menu_usuario _seg_menu_usuario);
		public abstract DataSet ObtenerTablaGrilla__seg_menu_usuario(
            string meus_id, 
			string meus_me_id, 
			string meus_us_id, 
			string meus_estado, 
			string meus_fecha_creacion, 
			string meus_usuario_creacion);
		public abstract DataSet ObtenerTablaCombo__seg_menu_usuario();
		#endregion

		#region _SEG_USUARIO
        public abstract bool Adicionar__seg_usuario(cls_seg_usuario _seg_usuario);
		public abstract bool Actualizar__seg_usuario(cls_seg_usuario _seg_usuario);
		public abstract bool Eliminar__seg_usuario(cls_seg_usuario _seg_usuario);
		public abstract DataSet ObtenerRegistro__seg_usuario(cls_seg_usuario _seg_usuario);
		public abstract DataSet ObtenerTablaGrilla__seg_usuario(
            string us_id, 
			string us_usuario, 
			string us_contrasena, 
			string us_per_id, 
			string us_estado_clave, 
			string us_estado_sesion, 
			string us_correo_interno, 
			string us_nombre_equipo, 
			string us_fecha_inicio, 
			string us_fecha_fin, 
			string us_id_rol_sim, 
			string us_id_usuario_sim, 
			string us_estado);
		public abstract DataSet ObtenerTablaCombo__seg_usuario();
		public abstract DataSet ObtenerFuncionarioX(cls_seg_usuario _seg_usuario);
		public abstract int ActualizarPass(cls_seg_usuario _seg_usuario);

		#endregion

		#region _SEG_ROL_MENU
		public abstract bool Adicionar__seg_rol_menu(cls_seg_rol_menu _seg_rol_menu);
		public abstract bool Actualizar__seg_rol_menu(cls_seg_rol_menu _seg_rol_menu);
		public abstract bool Eliminar__seg_rol_menu(cls_seg_rol_menu _seg_rol_menu);
		public abstract DataSet ObtenerRegistro__seg_rol_menu(cls_seg_rol_menu _seg_rol_menu);
		public abstract DataSet ObtenerTablaGrilla__seg_rol_menu(
            string per_id, 
			string per_rol_id, 
			string per_me_id,
            string per_estado);
		public abstract DataSet ObtenerTablaCombo__seg_rol_menu();
        #endregion

        #region _SEG_MENU
        public abstract int Adicionar__seg_menu(cls_seg_menu _seg_menu);
        public abstract bool Actualizar__seg_menu(cls_seg_menu _seg_menu);
        public abstract bool Eliminar__seg_menu(cls_seg_menu _seg_menu);
        public abstract DataSet ObtenerRegistro__seg_menu(cls_seg_menu _seg_menu);
        public abstract DataSet ObtenerTablaGrilla__seg_menu(
            string me_id,
            string me_descripcion,
            string me_url,
            string me_icono,
            string me_id_padre,
            string me_estado);
        public abstract DataSet ObtenerTablaCombo__seg_menu();
        public abstract DataSet ObtenerMenuRol__seg_menu(cls_seg_menu _seg_menu);
		public abstract DataSet ObtenerMenuRol__seg_menuINVITADO(cls_seg_menu _seg_menu);

		public abstract bool ActualizarNodo__seg_menu(cls_seg_menu _seg_menu);
        #endregion

        #region _USUARIO_ROL
        public abstract bool Adicionar__seg_usuario_rol(cls_seg_usuario_rol _seg_usuario_rol);
		public abstract bool Actualizar__seg_usuario_rol(cls_seg_usuario_rol _seg_usuario_rol);
		public abstract bool Eliminar__seg_usuario_rol(cls_seg_usuario_rol _seg_usuario_rol);
		public abstract DataSet ObtenerRegistro__seg_usuario_rol(cls_seg_usuario_rol _seg_usuario_rol);
		public abstract DataSet ObtenerTablaGrilla__seg_usuario_rol(
            string usrol_id, 
			string usrol_us_id, 
			string usrol_rol_id, 
			string usrol_estado);
		public abstract DataSet ObtenerTablaCombo__seg_usuario_rol();
        public abstract DataSet ObtenerTablaUsuarioRol__usuario_rol(cls_seg_usuario_rol _seg_usuario_rol);
        #endregion

        #region _ROL
        public abstract int Adicionar__seg_rol(cls_seg_rol _seg_rol);
		public abstract bool Actualizar__seg_rol(cls_seg_rol _seg_rol);
		public abstract bool Eliminar__seg_rol(cls_seg_rol _seg_rol);
		public abstract DataSet ObtenerRegistro__seg_rol(cls_seg_rol _seg_rol);
		public abstract DataSet ObtenerTablaGrilla__seg_rol(
            string rol_id, 
			string rol_descripcion, 
			string rol_estado);
		public abstract DataSet ObtenerTablaCombo__seg_rol();
		#endregion
	}
}


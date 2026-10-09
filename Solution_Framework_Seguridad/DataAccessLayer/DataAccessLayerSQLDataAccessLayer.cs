using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;

using Solution_Framework_Seguridad.BussinessLogicLayer;
using Solution_Framework_Seguridad.DataAccessLayer;

namespace Solution_Framework_Seguridad.BussinessLogicLayer
{
	public class DataAccessLayerSQLDataAccessLayer : DataAccessLayerDataAccessLayer
	{
		#region CONSTANTES
		private string SP__SEG_MENU_USUARIO = "sp_seg_menu_usuario";
		private string SP__SEG_USUARIO = "sp_seg_usuario";
		private string SP__SEG_ROL_MENU = "sp_seg_rol_menu";
		private string SP__SEG_MENU = "sp_seg_menu";
		private string SP__SEG_USUARIO_ROL = "sp_seg_usuario_rol";
		private string SP__SEG_ROL = "sp_seg_rol";
		#endregion

		//INTERFACES
		#region _SEG_MENU_USUARIO
		public override bool Adicionar__seg_menu_usuario(cls_seg_menu_usuario _seg_menu_usuario)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_MENU_USUARIO);
				CNXGENERAL.AddInParameter(icom, "p_meus_me_id", DbType.Int32, _seg_menu_usuario.meus_me_id);
				CNXGENERAL.AddInParameter(icom, "p_meus_us_id", DbType.Int32, _seg_menu_usuario.meus_us_id);
				CNXGENERAL.AddInParameter(icom, "p_meus_usuario_creacion", DbType.Int32, _seg_menu_usuario.meus_usuario_creacion);
				CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "A");
				CNXGENERAL.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
        }

		public override bool Eliminar__seg_menu_usuario(cls_seg_menu_usuario _seg_menu_usuario)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_MENU_USUARIO);
				CNXGENERAL.AddInParameter(icom, "p_meus_id", DbType.Int32, _seg_menu_usuario.meus_id);
				CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "B");
				CNXGENERAL.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
        }

		public override bool Actualizar__seg_menu_usuario(cls_seg_menu_usuario _seg_menu_usuario)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_MENU_USUARIO);
				CNXGENERAL.AddInParameter(icom, "p_meus_id", DbType.Int32, _seg_menu_usuario.meus_id);
				CNXGENERAL.AddInParameter(icom, "p_meus_me_id", DbType.Int32, _seg_menu_usuario.meus_me_id);
				CNXGENERAL.AddInParameter(icom, "p_meus_us_id", DbType.Int32, _seg_menu_usuario.meus_us_id);
				CNXGENERAL.AddInParameter(icom, "p_meus_estado", DbType.String, _seg_menu_usuario.meus_estado);
				CNXGENERAL.AddInParameter(icom, "p_meus_fecha_creacion", DbType.DateTime, _seg_menu_usuario.meus_fecha_creacion);
				CNXGENERAL.AddInParameter(icom, "p_meus_usuario_creacion", DbType.Int32, _seg_menu_usuario.meus_usuario_creacion);
				CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C");
				CNXGENERAL.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
        }

		public override DataSet ObtenerRegistro__seg_menu_usuario(cls_seg_menu_usuario _seg_menu_usuario)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_MENU_USUARIO);
				CNXGENERAL.AddInParameter(icom, "p_meus_id", DbType.Int32, _seg_menu_usuario.meus_id);
				CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "R");
				DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
        }

		public override DataSet ObtenerTablaGrilla__seg_menu_usuario(
            string meus_id, 
			string meus_me_id, 
			string meus_us_id, 
			string meus_estado, 
			string meus_fecha_creacion, 
			string meus_usuario_creacion)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_MENU_USUARIO);

				if (meus_id.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_meus_id", DbType.Int32, Convert.ToInt32(meus_id)); }
				if (meus_me_id.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_meus_me_id", DbType.Int32, Convert.ToInt32(meus_me_id)); }
				if (meus_us_id.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_meus_us_id", DbType.Int32, Convert.ToInt32(meus_us_id)); }
				if (meus_estado.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_meus_estado", DbType.String, Convert.ToString(meus_estado)); }
				if (meus_fecha_creacion.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_meus_fecha_creacion", DbType.DateTime, Convert.ToDateTime(meus_fecha_creacion)); }
				if (meus_usuario_creacion.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_meus_usuario_creacion", DbType.Int32, Convert.ToInt32(meus_usuario_creacion)); } 
				CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C1");
				DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
        }

		public override DataSet ObtenerTablaCombo__seg_menu_usuario()
		{
			try
			{
				DbCommand icom = null;
				icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_MENU_USUARIO);
				CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C2");
				DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
        }
		#endregion 		

		#region _SEG_USUARIO
		public override bool Adicionar__seg_usuario(cls_seg_usuario _seg_usuario)
		{
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_USUARIO);
                CNXGENERAL.AddInParameter(icom, "p_us_usuario", DbType.String, _seg_usuario.us_usuario);
                CNXGENERAL.AddInParameter(icom, "p_us_contrasena", DbType.String, _seg_usuario.us_contrasena);
                CNXGENERAL.AddInParameter(icom, "p_us_per_id", DbType.Int32, _seg_usuario.us_per_id);
                CNXGENERAL.AddInParameter(icom, "p_us_correo_interno", DbType.String, _seg_usuario.us_correo_interno);
                CNXGENERAL.AddInParameter(icom, "p_us_nombre_equipo", DbType.String, _seg_usuario.us_nombre_equipo);
                //CNXGENERAL.AddInParameter(icom, "p_us_fecha_inicio", DbType.DateTime, _seg_usuario.us_fecha_inicio);
                //CNXGENERAL.AddInParameter(icom, "p_us_fecha_fin", DbType.DateTime, _seg_usuario.us_fecha_fin);
                //CNXGENERAL.AddInParameter(icom, "p_us_id_rol_sim", DbType.Int32, _seg_usuario.us_id_rol_sim);
                //CNXGENERAL.AddInParameter(icom, "p_us_id_usuario_sim", DbType.Int32, _seg_usuario.us_id_usuario_sim);
                CNXGENERAL.AddInParameter(icom, "p_us_usuario_creacion", DbType.String, _seg_usuario.us_usuario_creacion);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXGENERAL.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
		}

		public override bool Eliminar__seg_usuario(cls_seg_usuario _seg_usuario)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_USUARIO);
				CNXGENERAL.AddInParameter(icom, "p_us_id", DbType.Int32, _seg_usuario.us_id);
				CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "B");
				CNXGENERAL.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
        }

		public override bool Actualizar__seg_usuario(cls_seg_usuario _seg_usuario)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_USUARIO);
                CNXGENERAL.AddInParameter(icom, "p_us_estado_sesion", DbType.Boolean, _seg_usuario.us_estado_sesion);
				CNXGENERAL.AddInParameter(icom, "p_us_id", DbType.Int32, _seg_usuario.us_id);
				CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C");
				CNXGENERAL.ExecuteNonQuery(icom);
				return true;
			}
			catch (Exception ex) { throw ex; }
        }
        public override int ActualizarPass(cls_seg_usuario _seg_usuario)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_USUARIO);
                CNXGENERAL.AddInParameter(icom, "p_us_usuario", DbType.String, _seg_usuario.us_usuario);
                CNXGENERAL.AddInParameter(icom, "p_us_contrasena", DbType.String, _seg_usuario.us_contrasena);
                CNXGENERAL.AddInParameter(icom, "p_us_per_id", DbType.Int32, _seg_usuario.us_per_id);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "U1");
                //int id = Convert.ToInt32(CNXGENERAL.ExecuteScalar(icom).ToString());
                return CNXGENERAL.ExecuteNonQuery(icom);
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerRegistro__seg_usuario(cls_seg_usuario _seg_usuario)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_USUARIO);
				CNXGENERAL.AddInParameter(icom, "p_us_id", DbType.Int32, _seg_usuario.us_id);
				CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "R");
				DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
			}
			catch (Exception ex) { throw ex; }
        }

		public override DataSet ObtenerTablaGrilla__seg_usuario(string us_id, 
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
						string us_estado)
		{
			try
			{
				DbCommand icom = null;
				icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_USUARIO);

				if (us_id.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_us_id", DbType.Int32, Convert.ToInt32(us_id)); }
				if (us_usuario.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_us_usuario", DbType.String, Convert.ToString(us_usuario)); }
				if (us_contrasena.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_us_contrasena", DbType.String, Convert.ToString(us_contrasena)); }
				if (us_per_id.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_us_per_id", DbType.Int32, Convert.ToInt32(us_per_id)); }
				if (us_estado_clave.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_us_estado_clave", DbType.Boolean, Convert.ToBoolean(us_estado_clave)); }
				if (us_estado_sesion.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_us_estado_sesion", DbType.Boolean, Convert.ToBoolean(us_estado_sesion)); }
				if (us_correo_interno.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_us_correo_interno", DbType.String, Convert.ToString(us_correo_interno)); }
				if (us_nombre_equipo.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_us_nombre_equipo", DbType.String, Convert.ToString(us_nombre_equipo)); }
				if (us_fecha_inicio.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_us_fecha_inicio", DbType.DateTime, Convert.ToDateTime(us_fecha_inicio)); }
				if (us_fecha_fin.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_us_fecha_fin", DbType.DateTime, Convert.ToDateTime(us_fecha_fin)); }
				if (us_id_rol_sim.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_us_id_rol_sim", DbType.Int32, Convert.ToInt32(us_id_rol_sim)); }
				if (us_id_usuario_sim.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_us_id_usuario_sim", DbType.Int32, Convert.ToInt32(us_id_usuario_sim)); }
				if (us_estado.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_us_estado", DbType.String, Convert.ToString(us_estado)); } 
				CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C1");
				DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
        }

		public override DataSet ObtenerTablaCombo__seg_usuario()
		{
			try
			{
				DbCommand icom = null;
				icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_USUARIO);
				CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C2");
				DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
				return ds;
			}
			catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerFuncionarioX(cls_seg_usuario _seg_usuario)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_USUARIO);
                CNXGENERAL.AddInParameter(icom, "p_us_usuario", DbType.String, _seg_usuario.us_usuario);
                CNXGENERAL.AddInParameter(icom, "p_us_contrasena", DbType.String, _seg_usuario.us_contrasena);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region _seg_rol_menu 
        public override bool Adicionar__seg_rol_menu(cls_seg_rol_menu _seg_rol_menu)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_ROL_MENU);
                CNXGENERAL.AddInParameter(icom, "p_rolme_rol_id", DbType.Int32, _seg_rol_menu.rolme_rol_id);
                CNXGENERAL.AddInParameter(icom, "p_rolme_me_id", DbType.Int32, _seg_rol_menu.rolme_me_id);
                CNXGENERAL.AddInParameter(icom, "p_rolme_usuario_creacion", DbType.String, _seg_rol_menu.rolme_usuario_creacion);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXGENERAL.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Eliminar__seg_rol_menu(cls_seg_rol_menu _seg_rol_menu)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_ROL_MENU);
                CNXGENERAL.AddInParameter(icom, "p_rolme_id", DbType.Int32, _seg_rol_menu.rolme_id);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "B");
                CNXGENERAL.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Actualizar__seg_rol_menu(cls_seg_rol_menu _seg_rol_menu)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_ROL_MENU);
                CNXGENERAL.AddInParameter(icom, "p_rolme_id", DbType.Int32, _seg_rol_menu.rolme_id);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXGENERAL.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerRegistro__seg_rol_menu(cls_seg_rol_menu _seg_rol_menu)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_ROL_MENU);
                CNXGENERAL.AddInParameter(icom, "p_rolme_id", DbType.Int32, _seg_rol_menu.rolme_id);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaGrilla__seg_rol_menu(
            string rolme_id,
            string rolme_rol_id,
            string rolme_me_id,
            string rolme_estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_ROL_MENU);

                if (rolme_id.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_rolme_id", DbType.Int32, Convert.ToInt32(rolme_id)); }
                if (rolme_rol_id.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_rolme_rol_id", DbType.Int32, Convert.ToInt32(rolme_rol_id)); }
                if (rolme_me_id.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_rolme_me_id", DbType.Int32, Convert.ToInt32(rolme_me_id)); }
                if (rolme_estado.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_rolme_estado", DbType.String, Convert.ToString(rolme_estado)); }
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaCombo__seg_rol_menu()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_ROL_MENU);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region _SEG_MENU
        public override int Adicionar__seg_menu(cls_seg_menu _seg_menu)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_MENU);
                CNXGENERAL.AddInParameter(icom, "p_me_descripcion", DbType.String, _seg_menu.me_descripcion);
                CNXGENERAL.AddInParameter(icom, "p_me_url", DbType.String, _seg_menu.me_url);
                CNXGENERAL.AddInParameter(icom, "p_me_icono", DbType.String, _seg_menu.me_icono);
                CNXGENERAL.AddInParameter(icom, "p_me_id_padre", DbType.Int32, _seg_menu.me_id_padre);
                CNXGENERAL.AddInParameter(icom, "p_me_usuario_creacion", DbType.String, _seg_menu.me_usuario_creacion);
                CNXGENERAL.AddInParameter(icom, "p_me_vista", DbType.Boolean, _seg_menu.me_vista);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "A");
                int id = Convert.ToInt32(CNXGENERAL.ExecuteScalar(icom).ToString());
                return id;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Eliminar__seg_menu(cls_seg_menu _seg_menu)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_MENU);
                CNXGENERAL.AddInParameter(icom, "p_me_id", DbType.Int32, _seg_menu.me_id);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "B");
                CNXGENERAL.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Actualizar__seg_menu(cls_seg_menu _seg_menu)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_MENU);
                CNXGENERAL.AddInParameter(icom, "p_me_id", DbType.Int32, _seg_menu.me_id);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXGENERAL.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerRegistro__seg_menu(cls_seg_menu _seg_menu)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_MENU);
                CNXGENERAL.AddInParameter(icom, "p_me_id", DbType.Int32, _seg_menu.me_id);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaGrilla__seg_menu(
            string me_id,
            string me_descripcion,
            string me_url,
            string me_icono,
            string me_id_padre,
            string me_estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_MENU);

                if (me_id.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_me_id", DbType.Int32, Convert.ToInt32(me_id)); }
                if (me_descripcion.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_me_descripcion", DbType.String, Convert.ToString(me_descripcion)); }
                if (me_url.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_me_url", DbType.String, Convert.ToString(me_url)); }
                if (me_icono.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_me_icono", DbType.String, Convert.ToString(me_icono)); }
                if (me_id_padre.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_me_id_padre", DbType.Int32, Convert.ToInt32(me_id_padre)); }
                if (me_estado.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_me_estado", DbType.String, Convert.ToString(me_estado)); }
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaCombo__seg_menu()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_MENU);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerMenuRol__seg_menu(cls_seg_menu _seg_menu)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_MENU);
                CNXGENERAL.AddInParameter(icom, "p_me_id", DbType.Int32, _seg_menu.me_id);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override DataSet ObtenerMenuRol__seg_menuINVITADO(cls_seg_menu _seg_menu)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_MENU);
                CNXGENERAL.AddInParameter(icom, "p_me_id", DbType.Int32, _seg_menu.me_id);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C6");
                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        public override bool ActualizarNodo__seg_menu(cls_seg_menu _seg_menu)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_MENU);
                CNXGENERAL.AddInParameter(icom, "p_me_id", DbType.Int32, _seg_menu.me_id);
                CNXGENERAL.AddInParameter(icom, "p_me_id_padre", DbType.Int32, _seg_menu.me_id_padre);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C4");
                CNXGENERAL.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region _SEG_USUARIO_ROL
        public override bool Adicionar__seg_usuario_rol(cls_seg_usuario_rol _seg_usuario_rol)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_USUARIO_ROL);
                CNXGENERAL.AddInParameter(icom, "p_usrol_us_id", DbType.Int32, _seg_usuario_rol.usrol_us_id);
                CNXGENERAL.AddInParameter(icom, "p_usrol_rol_id", DbType.Int32, _seg_usuario_rol.usrol_rol_id);
                CNXGENERAL.AddInParameter(icom, "p_usrol_usuario_creacion", DbType.String, _seg_usuario_rol.usrol_usuario_creacion);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "A");
                CNXGENERAL.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Eliminar__seg_usuario_rol(cls_seg_usuario_rol _seg_usuario_rol)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_USUARIO_ROL);
                CNXGENERAL.AddInParameter(icom, "p_usrol_id", DbType.Int32, _seg_usuario_rol.usrol_id);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "B");
                CNXGENERAL.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Actualizar__seg_usuario_rol(cls_seg_usuario_rol _seg_usuario_rol)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_USUARIO_ROL);
                CNXGENERAL.AddInParameter(icom, "p_usrol_id", DbType.Int32, _seg_usuario_rol.usrol_id);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXGENERAL.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerRegistro__seg_usuario_rol(cls_seg_usuario_rol _seg_usuario_rol)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_USUARIO_ROL);
                CNXGENERAL.AddInParameter(icom, "p_usrol_id", DbType.Int32, _seg_usuario_rol.usrol_id);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaGrilla__seg_usuario_rol(
            string usrol_id,
            string usrol_us_id,
            string usrol_rol_id,
            string usrol_estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_USUARIO_ROL);

                if (usrol_id.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_usrol_id", DbType.Int32, Convert.ToInt32(usrol_id)); }
                if (usrol_us_id.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_usrol_us_id", DbType.Int32, Convert.ToInt32(usrol_us_id)); }
                if (usrol_rol_id.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_usrol_rol_id", DbType.Int32, Convert.ToInt32(usrol_rol_id)); }
                if (usrol_estado.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_usrol_estado", DbType.String, Convert.ToString(usrol_estado)); }
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaCombo__seg_usuario_rol()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_USUARIO_ROL);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
    
        public override DataSet ObtenerTablaUsuarioRol__usuario_rol(cls_seg_usuario_rol _seg_usuario_rol)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_USUARIO_ROL);
                CNXGENERAL.AddInParameter(icom, "p_usrol_us_id", DbType.Int32, _seg_usuario_rol.usrol_us_id);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C3");
                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region _SEG_ROL
        public override int Adicionar__seg_rol(cls_seg_rol _seg_rol)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_ROL);
                CNXGENERAL.AddInParameter(icom, "p_rol_descripcion", DbType.String, _seg_rol.rol_descripcion);
                CNXGENERAL.AddInParameter(icom, "p_rol_usuario_creacion", DbType.String, _seg_rol.rol_usuario_creacion);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "A");
                int id = Convert.ToInt32(CNXGENERAL.ExecuteScalar(icom).ToString());
                return id;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Eliminar__seg_rol(cls_seg_rol _seg_rol)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_ROL);
                CNXGENERAL.AddInParameter(icom, "p_rol_id", DbType.Int32, _seg_rol.rol_id);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "B");
                CNXGENERAL.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override bool Actualizar__seg_rol(cls_seg_rol _seg_rol)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_ROL);
                CNXGENERAL.AddInParameter(icom, "p_rol_id", DbType.Int32, _seg_rol.rol_id);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C");
                CNXGENERAL.ExecuteNonQuery(icom);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerRegistro__seg_rol(cls_seg_rol _seg_rol)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_ROL);
                CNXGENERAL.AddInParameter(icom, "p_rol_id", DbType.Int32, _seg_rol.rol_id);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "R");
                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }

        public override DataSet ObtenerTablaGrilla__seg_rol(
            string rol_id,
            string rol_descripcion,
            string rol_estado)
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_ROL);

                if (rol_id.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_rol_id", DbType.Int32, Convert.ToInt32(rol_id)); }
                if (rol_descripcion.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_rol_descripcion", DbType.String, Convert.ToString(rol_descripcion)); }
                if (rol_estado.ToString().Trim() != "") { CNXGENERAL.AddInParameter(icom, "p_rol_estado", DbType.String, Convert.ToString(rol_estado)); }
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C1");
                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        
        public override DataSet ObtenerTablaCombo__seg_rol()
        {
            try
            {
                DbCommand icom = null;
                icom = CNXGENERAL.GetStoredProcCommand(SP__SEG_ROL);
                CNXGENERAL.AddInParameter(icom, "p_accion", DbType.String, "C2");
                DataSet ds = CNXGENERAL.ExecuteDataSet(icom);
                return ds;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion
    }
}

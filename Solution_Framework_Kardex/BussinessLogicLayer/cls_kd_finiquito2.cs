using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_Kardex.DataAccessLayer;

namespace Solution_Framework_Kardex.BussinessLogicLayer
{
    public class cls_kd_finiquito2
	{

		#region PROPIEDADES
		public int Fi_id { get; set; }
        public int Fi2_id { get; set; }
        public int Fi_per_id { get; set; }
		public int Fi_as_id { get; set; }

		public int Fi_Nro_Finiquito { get; set; }
		public string Fi_Codigo_Finiquito { get; set; }
		public DateTime Fi_FechaIngerso { get; set; }
		public DateTime Fi_FechaRetiro { get; set; }
		public string Fi_MotivoFiniquito { get; set; }
		public int Fi_anioServicio { get; set; }
		public int Fi_MesServicio { get; set; }
		public int Fi_DiasServicio { get; set; }
		public double Fi_TotalPagado { get; set; }
		public DateTime Fi_FechaPago { get; set; }
		public int Fi_usuario { get; set; }
		public bool Fi_EstadoAnulado { get; set; }
		public DateTime Fi_finiquito_fecha { get; set; }
		public string Fi_liquidacion_nro { get; set; }
		public DateTime Fi_liquidacion_fecha { get; set; }
		public string Fi_estado { get; set; }
		public double Fi_remuneracion1 { get; set; }
		public double Fi_remuneracion2 { get; set; }
		public double Fi_remuneracion3 { get; set; }
		public string Fi_doc_autoriza { get; set; }
		public DateTime Fi_fecha_documento { get; set; }


		#endregion

		#region METODOS

		/// <summary>
		/// Método que obtiene un registro de tbl_kd_finiquito
		/// </summary>
		/// <param name="fin_id">
		/// Clave primaria de la tabla _kd_finiquito
		/// </param>


		/// <summary>
		/// Método que obtiene la tabla tbl_kd_finiquito para llenar una grilla
		/// </summary>
		/// <param name="fin_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="fin_tiempo_servicio">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="fin_liquido_pagable">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		public  string TiempoServicio(string fecha_ingreso, string  accion)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.TiempoServicio(fecha_ingreso, accion);
		}
		public  DataSet CalcularGestiones(string fecha_baja)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.CalcularGestiones(fecha_baja);
		}

		public int Adicionar_FechaIngreso()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar_FechaIngreso(this);
		}
		public  DataSet PromedioRemuneracion(double rem1, double rem2, double rem3, int ANIO, int MES, int DIA)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.PromedioRemuneracion(rem1, rem2, rem3, ANIO, MES, DIA);
		}
		public  int ActualizarTotalesRemuneracionFiniquito(double rem1, double rem2, double rem3, int p_Fi_id, double ba1, double ba2, double ba3, double bf1, double bf2, double bf3)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ActualizarTotalesRemuneracionFiniquito(rem1, rem2, rem3, p_Fi_id, ba1, ba2, ba3, bf1, bf2, bf3);
		}
		public  DataSet ObtenerRegistro(int per_id, int as_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro(per_id,as_id);
		}
		public  double CalcularDesahucio(int fi_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.CalcularDesahucio(fi_id);
		}
		public  double CalcularVacacionesMonto(int fi_id, int meses, int dias, int per_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.CalcularVacacionesMonto(fi_id, meses, dias, per_id);
		}
		public  double CalcularVacacionesDias(int fi_id, int meses, int dias, int per_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.CalcularVacacionesDias(fi_id, meses, dias, per_id);
		}
		public  double CalcularAguinaldo(int fi_id, string fecha_baja)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.CalcularAguinaldo(fi_id, fecha_baja);
		}
		public  int ActualizarInfoAdicional(int fi_id, int nro_finiquito, int cod_finiquito, string motivo, double liquido_pagable, string doc_autoriza, string fecha_doc, string estado)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ActualizarInfoAdicional(fi_id, nro_finiquito, cod_finiquito, motivo, liquido_pagable, doc_autoriza, fecha_doc, estado);
		}

		#endregion
		#region CHEQUES
		public DataSet gestion()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Gestion();
		}
		public  DataSet BuscarCheque(string preventivo, string proceso_nombre, int id_gestion, string beneficiario, string nit_ci, string num_cheque)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.BuscarCheque(preventivo, proceso_nombre, id_gestion, beneficiario, nit_ci, num_cheque);
		}
		public DataSet DetalleCheque(int pago_id)
        {
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.DetalleCheque(pago_id);
        }
		public DataSet GetTipDoc()
        {
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTipoDoc();
        }
		public bool AdicionarPDF(int tipoDoc_id, int proce_id, byte[] foto, string fecha_doc, int per_id, string obser)
        {
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.AdicionarPDF(tipoDoc_id, proce_id, foto, fecha_doc, per_id,obser);

		}
        #endregion

        #region PROPIEDADES
        public int fin_id { get; set; }
        public int fin_per_id { get; set; }
        public string fin_tiempo_servicio { get; set; }
        public string fin_estado { get; set; }
        public double fin_liquido_pagable { get; set; }

        public int id2 { get; set; }
        public string r_indicador { get; set; }
        public string r_resultado { get; set; }
        public string r_tipo { get; set; }
        public decimal r_ponderacion { get; set; }
        public int r_poai_id { get; set; }

        public int id3 { get; set; }
        public string r_indicador2 { get; set; }
        public string r_resultado2 { get; set; }
        public string r_tipo2 { get; set; }
        public decimal r_ponderacion2 { get; set; }

        public int id_actividad { get; set; }
        public string a_descripcion { get; set; }
        public string a_medio_verif { get; set; }
        public decimal a_puntaje { get; set; }
        public int r_id2 { get; set; }

        public int id_actividad2 { get; set; }
        public string actividad_descripcion { get; set; }
        public string actividad_medio_verificacion { get; set; }
        public int r_id3 { get; set; }
        public decimal actividad_puntaje { get; set; }

        public string p_descripcion { get; set; }
        public int pu_id { get; set; }
        public string fo_tipo { get; set; }

        public int fo_id { get; set; }
        public string p_descripcion2 { get; set; }
        public string fo_tipo2 { get; set; }

        //===Experiencia =========

        public decimal EXP_GRAL { get; set; }
        public decimal EXP_ESP { get; set; }
        public int Exp_pu_id { get; set; }

        //---Experiencia ---------

        //=== Cualidades =========
        public int cua_id { get; set; }
        public int cua_pu_id { get; set; }
        public string cu_descripcion { get; set; }

        //--- Cualidades ---------

        //=== Cualidades =========
        public int nor_id { get; set; }
        public int nor_pu_id { get; set; }
        public string nor_descripcion { get; set; }

        //--- Cualidades ---------


        //=== Cualidades =========
        public int i_id { get; set; }
        public int POAI_ID { get; set; }
        public string poai_i_inter { get; set; }
        public string poai_i_intra { get; set; }
        public int i_super_id { get; set; }
        public string poai_objetivo_p { get; set; }
        //--- Cualidades ---------
        #endregion

        #region METODOS
        public int id { get; set; }

        public DataSet ListarResultados(int poai_id, string r_tipo)
        {
            return new DataAccessLayerSQLDataAccessLayer().ListarResultados(poai_id, r_tipo);
        }

        //================ FORMACION OBLIGATORIA ==============
        public DataSet ListarFormacionObligatoria(int pu_id, string fo_tipo)
        {
            return new DataAccessLayerSQLDataAccessLayer().ListarFormacionObligatoria(pu_id, fo_tipo);
        }

        public DataSet DevolverDatosFormacionObligatoria(int fo_id)
        {
            DataAccessLayerSQLDataAccessLayer DBlayer = new DataAccessLayerSQLDataAccessLayer();
            return DBlayer.DevolverDatosFormacionObligatoria(fo_id);
        }

        public bool ActualizarFormacionO()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarFormacionO(this);
        }
        //================ /FORMACION OBLIGATORIA ==============

        public DataSet ListarActividades(int r_id)
        {
            return new DataAccessLayerSQLDataAccessLayer().ListarActividades(r_id);
        }


        public DataSet Listar_Supervisores()
        {
            DataAccessLayerSQLDataAccessLayer DBlayer = new DataAccessLayerSQLDataAccessLayer();
            return DBlayer.Listar_Supervisores();
        }

        public DataSet Listar_Caracteristicas()
        {
            DataAccessLayerSQLDataAccessLayer DBlayer = new DataAccessLayerSQLDataAccessLayer();
            return DBlayer.Listar_Caracteristicas();
        }

        public DataSet Listar_Complementarios()
        {
            DataAccessLayerSQLDataAccessLayer DBlayer = new DataAccessLayerSQLDataAccessLayer();
            return DBlayer.Listar_Complementarios();
        }

        public DataSet List_Gestion()
        {
            DataAccessLayerSQLDataAccessLayer DBlayer = new DataAccessLayerSQLDataAccessLayer();
            return DBlayer.List_Gestion();
        }

        public int Adicionar_Poai(int per_id, int p_tipo, string inter, string intra, int ca_id, int super_id, int nro_puesto, string pu_nombre, string pu_pref, string pu_objetivo)
        {
            DataAccessLayerSQLDataAccessLayer DBlayer = new DataAccessLayerSQLDataAccessLayer();
            return DBlayer.Adicionar_Poai(per_id, p_tipo, inter, intra, ca_id, super_id, nro_puesto, pu_nombre, pu_pref, pu_objetivo);
        }

        public int Devolver_tipo_Poai(int per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBlayer = new DataAccessLayerSQLDataAccessLayer();
            return DBlayer.Devolver_tipo_Poai(per_id);
        }

        public bool Adicionar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarResultadoEspecifico(this);
        }

        // ============= Cualidades=================
        public bool AdicionarCualidad()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarCualidad(this);
        }
        public DataSet ListarCualidades(int pu_id)
        {
            return new DataAccessLayerSQLDataAccessLayer().ListarCualidades(pu_id);
        }
        public DataSet DevolverDatosCualidad(int cu_id)
        {
            DataAccessLayerSQLDataAccessLayer DBlayer = new DataAccessLayerSQLDataAccessLayer();
            return DBlayer.DevolverDatosCualidad(cu_id);
        }

        public bool ActualizarCualidad()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarCualidad(this);
        }

        public bool EliminarCualidad()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarCualidad(this);
        }

        //-------------- Cualidades -----------------

        //============== Normativa ==================

        public bool AdicionarNormativa()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarNormativa(this);
        }
        public DataSet ListarNormas(int pu_id)
        {
            return new DataAccessLayerSQLDataAccessLayer().ListarNormas(pu_id);
        }
        public DataSet DevolverDatosNorma(int nor_id)
        {
            DataAccessLayerSQLDataAccessLayer DBlayer = new DataAccessLayerSQLDataAccessLayer();
            return DBlayer.DevolverDatosNorma(nor_id);
        }
        public bool ActualizarNorma()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarNorma(this);
        }
        public bool EliminarNorma()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarNorma(this);
        }

        //-------------- Normativa-----------------

        public bool AdicionarFormacion()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarFormacion(this);
        }

        // ============= Experiencia =================

        public bool AdicionarExperciencia()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarExperciencia(this);
        }

        public DataSet ListarExperiencia(int pu_id)
        {
            return new DataAccessLayerSQLDataAccessLayer().ListarExperiencia(pu_id);
        }

        //-------------- Experiencia -----------------

        public int AdicionarActividad()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarActividad(this);
        }

        public int TotalActividad(int r_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.TotalActividad(r_id);
        }

        public decimal TotalE(int result_pu_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.TotalE(result_pu_id);
        }

        public bool ActualizarResultadoEspecifico()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarResultadoEspecifico(this);
        }

        public bool ActualizarResultadoEspecifico2()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarResultadoEspecifico2(this);
        }

        //============ POAI ==========

        public bool ActualizarPoai()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarPoai(this);
        }

        //----------- POAI ------------

        public bool ActualizarActividad()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ActualizarActividad(this);
        }

        public DataSet DevolverGestionPerId(int per_id, int gestion)
        {
            DataAccessLayerSQLDataAccessLayer DBlayer = new DataAccessLayerSQLDataAccessLayer();
            return DBlayer.DevolverGestionPerId(per_id, gestion);
        }

        // ============ Devolver CARGO ==========

        public int DevolverCargoXPer(int per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBlayer = new DataAccessLayerSQLDataAccessLayer();
            return DBlayer.DevolverCargoXPer(per_id);
        }

        // ----------- Devolver Cargo -----------

        public DataSet DevolverDatosResultadosEspecificos(int r_id)
        {
            DataAccessLayerSQLDataAccessLayer DBlayer = new DataAccessLayerSQLDataAccessLayer();
            return DBlayer.DevolverDatosResultadosEspecificos(r_id);
        }

        // ========= devolver datos poai ===========

        public DataSet DevolverDatosPoai(int poai_id)
        {
            DataAccessLayerSQLDataAccessLayer DBlayer = new DataAccessLayerSQLDataAccessLayer();
            return DBlayer.DevolverDatosPoai(poai_id);
        }

        // -------- devolver datos poai *------------

        public DataSet DevolverDatosActividad(int actividad_id)
        {
            DataAccessLayerSQLDataAccessLayer DBlayer = new DataAccessLayerSQLDataAccessLayer();
            return DBlayer.DevolverDatosActividad(actividad_id);
        }

        public bool EliminarResultadoEspecifico()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarResultado(this);
        }

        public bool EliminarActividad()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarActividad(this);
        }
        #endregion
    }
}

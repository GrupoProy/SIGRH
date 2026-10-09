using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_Kardex.DataAccessLayer;

namespace Solution_Framework_Kardex.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_kd_finiquito.
	/// </summary>
	public class cls_kd_finiquito
	{

		//#region PROPIEDADES
		//public int fin_id { get; set; }
		//public int fin_per_id { get; set; }
		//public string fin_tiempo_servicio { get; set; }
		//public string fin_estado { get; set; }
		//public double fin_liquido_pagable { get; set; }

  //      public int id2 { get; set; }
  //      public string r_indicador { get; set; }
  //      public string r_resultado { get; set; }
  //      public string r_tipo { get; set; }
  //      public decimal r_ponderacion { get; set; }
  //      public int r_poai_id { get; set; }

  //      public int id3 { get; set; }
  //      public string r_indicador2 { get; set; }
  //      public string r_resultado2 { get; set; }
  //      public string r_tipo2 { get; set; }
  //      public decimal r_ponderacion2 { get; set; }

  //      public int id_actividad { get; set; }
  //      public string a_descripcion { get; set; }
  //      public string a_medio_verif { get; set; }
  //      public decimal a_puntaje { get; set; }
  //      public int r_id2 { get; set; }

  //      public int id_actividad2 { get; set; }
  //      public string actividad_descripcion { get; set; }
  //      public string actividad_medio_verificacion { get; set; }
  //      public int r_id3 { get; set; }
  //      public decimal actividad_puntaje { get; set; }

  //      public string p_descripcion { get; set; }
  //      public int pu_id { get; set; }
  //      public string fo_tipo { get; set; }

  //      public int fo_id { get; set; }
  //      public string p_descripcion2 { get; set; }
  //      public string fo_tipo2 { get; set; }

  //      //===Experiencia =========

  //      public decimal EXP_GRAL { get; set; }
  //      public decimal EXP_ESP { get; set; }
  //      public int Exp_pu_id { get; set; }

  //      //---Experiencia ---------

  //      //=== Cualidades =========
  //      public int cua_id { get; set; }
  //      public int cua_pu_id { get; set; }
  //      public string cu_descripcion { get; set; }

  //      //--- Cualidades ---------

  //      //=== Cualidades =========
  //      public int nor_id { get; set; }
  //      public int nor_pu_id { get; set; }
  //      public string nor_descripcion { get; set; }

  //      //--- Cualidades ---------


  //      //=== Cualidades =========
  //      public int i_id { get; set; }
  //      public int POAI_ID { get; set; }
  //      public string poai_i_inter { get; set; }
  //      public string poai_i_intra { get; set; }
  //      public int i_super_id { get; set; }
  //      public string poai_objetivo_p { get; set; }
  //      //--- Cualidades ---------
  //      #endregion

  //      #region METODOS
  //      public int id { get; set; }

  //      public DataSet ListarResultados(int poai_id, string r_tipo) 
  //      {
  //          return new DataAccessLayerSQLDataAccessLayer().ListarResultados(poai_id, r_tipo);
  //      }

  //      //================ FORMACION OBLIGATORIA ==============
  //      public DataSet ListarFormacionObligatoria(int pu_id, string fo_tipo)
  //      {
  //          return new DataAccessLayerSQLDataAccessLayer().ListarFormacionObligatoria(pu_id, fo_tipo);
  //      }

  //      public DataSet DevolverDatosFormacionObligatoria(int fo_id)
  //      {
  //          DataAccessLayerSQLDataAccessLayer DBlayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBlayer.DevolverDatosFormacionObligatoria(fo_id);
  //      }

  //      public bool ActualizarFormacionO()
  //      {
  //          DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBLayer.ActualizarFormacionO(this);
  //      }
  //      //================ /FORMACION OBLIGATORIA ==============

  //      public DataSet ListarActividades(int r_id)
  //      {
  //          return new DataAccessLayerSQLDataAccessLayer().ListarActividades(r_id);
  //      }


  //      public DataSet Listar_Supervisores()
  //      {
  //          DataAccessLayerSQLDataAccessLayer DBlayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBlayer.Listar_Supervisores();
  //      }

  //      public DataSet Listar_Caracteristicas()
  //      {
  //          DataAccessLayerSQLDataAccessLayer DBlayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBlayer.Listar_Caracteristicas();
  //      }

  //      public DataSet Listar_Complementarios()
  //      {
  //          DataAccessLayerSQLDataAccessLayer DBlayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBlayer.Listar_Complementarios();
  //      }

  //      public DataSet List_Gestion()
  //      {
  //          DataAccessLayerSQLDataAccessLayer DBlayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBlayer.List_Gestion();
  //      }

  //      public int Adicionar_Poai(int per_id, int p_tipo, string inter, string intra, int ca_id, int super_id, int nro_puesto, string pu_nombre, string pu_pref, string pu_objetivo)
  //      {
  //          DataAccessLayerSQLDataAccessLayer DBlayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBlayer.Adicionar_Poai( per_id,  p_tipo,  inter,  intra,  ca_id,  super_id,  nro_puesto,  pu_nombre,  pu_pref,  pu_objetivo);
  //      }

  //      public int Devolver_tipo_Poai(int per_id)
  //      {
  //          DataAccessLayerSQLDataAccessLayer DBlayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBlayer.Devolver_tipo_Poai(per_id);
  //      }

  //      public bool Adicionar()
  //      {
  //          DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBLayer.AdicionarResultadoEspecifico(this);
  //      }

  //      // ============= Cualidades=================
  //      public bool AdicionarCualidad()
  //      {
  //          DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBLayer.AdicionarCualidad(this);
  //      }
  //      public DataSet ListarCualidades(int pu_id)
  //      {
  //          return new DataAccessLayerSQLDataAccessLayer().ListarCualidades(pu_id);
  //      }
  //      public DataSet DevolverDatosCualidad(int cu_id)
  //      {
  //          DataAccessLayerSQLDataAccessLayer DBlayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBlayer.DevolverDatosCualidad(cu_id);
  //      }

  //      public bool ActualizarCualidad()
  //      {
  //          DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBLayer.ActualizarCualidad(this);
  //      }

  //      public bool EliminarCualidad()
  //      {
  //          DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBLayer.EliminarCualidad(this);
  //      }

  //      //-------------- Cualidades -----------------

  //      //============== Normativa ==================

  //      public bool AdicionarNormativa()
  //      {
  //          DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBLayer.AdicionarNormativa(this);
  //      }
  //      public DataSet ListarNormas(int pu_id)
  //      {
  //          return new DataAccessLayerSQLDataAccessLayer().ListarNormas(pu_id);
  //      }
  //      public DataSet DevolverDatosNorma(int nor_id)
  //      {
  //          DataAccessLayerSQLDataAccessLayer DBlayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBlayer.DevolverDatosNorma(nor_id);
  //      }
  //      public bool ActualizarNorma()
  //      {
  //          DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBLayer.ActualizarNorma(this);
  //      }
  //      public bool EliminarNorma()
  //      {
  //          DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBLayer.EliminarNorma(this);
  //      }

  //      //-------------- Normativa-----------------

  //      public bool AdicionarFormacion()
  //      {
  //          DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBLayer.AdicionarFormacion(this);
  //      }

  //      // ============= Experiencia =================

  //      public bool AdicionarExperciencia()
  //      {
  //          DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBLayer.AdicionarExperciencia(this);
  //      }

  //      public DataSet ListarExperiencia(int pu_id)
  //      {
  //          return new DataAccessLayerSQLDataAccessLayer().ListarExperiencia(pu_id);
  //      }

  //      //-------------- Experiencia -----------------

  //      public int AdicionarActividad()
  //      {
  //          DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBLayer.AdicionarActividad(this);
  //      }

  //      public int TotalActividad(int r_id)
  //      {
  //          DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBLayer.TotalActividad(r_id);
  //      }

  //      public decimal TotalE(int result_pu_id)
  //      {
  //          DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBLayer.TotalE(result_pu_id);
  //      }

  //      public bool ActualizarResultadoEspecifico()
  //      {
  //          DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBLayer.ActualizarResultadoEspecifico(this);
  //      }

  //      public bool ActualizarResultadoEspecifico2()
  //      {
  //          DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBLayer.ActualizarResultadoEspecifico2(this);
  //      }

  //      //============ POAI ==========

  //      public bool ActualizarPoai()
  //      {
  //          DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBLayer.ActualizarPoai(this);
  //      }

  //      //----------- POAI ------------

  //      public bool ActualizarActividad()
  //      {
  //          DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBLayer.ActualizarActividad(this);
  //      }

  //      public DataSet DevolverGestionPerId(int per_id, int gestion) {
  //          DataAccessLayerSQLDataAccessLayer DBlayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBlayer.DevolverGestionPerId(per_id, gestion);
  //      }

  //      // ============ Devolver CARGO ==========

  //      public int DevolverCargoXPer(int per_id)
  //      {
  //          DataAccessLayerSQLDataAccessLayer DBlayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBlayer.DevolverCargoXPer(per_id);
  //      }

  //      // ----------- Devolver Cargo -----------

  //      public DataSet DevolverDatosResultadosEspecificos(int r_id)
  //      {
  //          DataAccessLayerSQLDataAccessLayer DBlayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBlayer.DevolverDatosResultadosEspecificos(r_id);
  //      }

  //      // ========= devolver datos poai ===========

  //      public DataSet DevolverDatosPoai(int poai_id)
  //      {
  //          DataAccessLayerSQLDataAccessLayer DBlayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBlayer.DevolverDatosPoai(poai_id);
  //      }

  //      // -------- devolver datos poai *------------

  //      public DataSet DevolverDatosActividad(int actividad_id)
  //      {
  //          DataAccessLayerSQLDataAccessLayer DBlayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBlayer.DevolverDatosActividad(actividad_id);
  //      }

  //      public bool EliminarResultadoEspecifico()
  //      {
  //          DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBLayer.EliminarResultado(this);
  //      }

  //      public bool EliminarActividad()
  //      {
  //          DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
  //          return DBLayer.EliminarActividad(this);
  //      }


  //      /// <summary>
  //      /// Método que adiciona una nuevo registro en tbl_kd_finiquito
  //      /// </summary>
  //      //public DataSet Adicionar()
  //      //{
  //      //	DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
  //      //	return DBLayer.Adicionar__kd_finiquito(this);
  //      //}

  //      ///// <summary>
  //      ///// Método que actualiza datos en la tabla tbl_kd_finiquito
  //      ///// </summary>
  //      //public bool Actualizar()
  //      //{
  //      //	DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
  //      //	return DBLayer.Actualizar__kd_finiquito(this);
  //      //}

  //      ///// <summary>
  //      ///// Método que elimina datos en la tabla tbl_kd_finiquito
  //      ///// </summary>
  //      //public bool Eliminar()
  //      //{
  //      //	DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
  //      //	return DBLayer.Eliminar__kd_finiquito(this);
  //      //}

  //      ///// <summary>
  //      ///// Método que obtiene ID para registros de tbl_kd_finiquito
  //      ///// </summary>
  //      //public bool ObtenerId()
  //      //{
  //      //	DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
  //      //	return DBLayer.ObtenerId__kd_finiquito(this);
  //      //}

  //      ///// <summary>
  //      ///// Método que obtiene un registro de tbl_kd_finiquito
  //      ///// </summary>
  //      ///// <param name="fin_id">
  //      ///// Clave primaria de la tabla _kd_finiquito
  //      ///// </param>

  //      //public bool ObtenerRegistro(int fin_id)
  //      //{
  //      //	DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
  //      //	return DBLayer.ObtenerRegistro__kd_finiquito(this);
  //      //}

  //      ///// <summary>
  //      ///// Método que obtiene la tabla tbl_kd_finiquito para llenar una grilla
  //      ///// </summary>
  //      ///// <param name="fin_id">
  //      ///// (Campo opcional) Introducir espacio vacio
  //      ///// </param>
  //      ///// <param name="fin_tiempo_servicio">
  //      ///// (Campo opcional) Introducir espacio vacio
  //      ///// </param>
  //      ///// <param name="fin_liquido_pagable">
  //      ///// (Campo opcional) Introducir espacio vacio
  //      ///// </param>

  //      //public DataSet ObtenerTablaGrilla(string fin_id, 
  //      //				string fin_tiempo_servicio, 
  //      //				string fin_liquido_pagable)
  //      //{
  //      //	DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
  //      //	return DBLayer.ObtenerTablaGrilla__kd_finiquito(fin_id, fin_tiempo_servicio, fin_liquido_pagable);
  //      //}

  //      ///// <summary>
  //      ///// Método que obtiene la tabla tbl_kd_finiquito para llenar un combo
  //      ///// </summary>
  //      //public DataSet ObtenerTablaCombo()
  //      //{
  //      //	DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
  //      //	return DBLayer.ObtenerTablaCombo__kd_finiquito();
  //      //}
  //      //      public DataSet ObtenerAsignaciones()
  //      //      {
  //      //          DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
  //      //          return DBLayer.ObtenerAsignaciones(this);
  //      //      }
  //      #endregion
    }
}

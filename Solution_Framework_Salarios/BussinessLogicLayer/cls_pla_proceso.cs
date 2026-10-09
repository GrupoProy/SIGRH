using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_Salarios.DataAccessLayer;

namespace Solution_Framework_Salarios.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_pla_proceso.
	/// </summary>
	public class cls_pla_proceso_salarios
	{

		#region PROPIEDADES
		public int pc_id { get; set; }
		public int pc_pr_id { get; set; }
        public string pc_titulo { get; set; }
        public string pc_fecha_inicio { get; set; }
        public string pc_fecha_fin { get; set; }
        public int pc_mn_id { get; set; }
        public double pc_ufv { get; set; }
        public string pc_ufv_fecha { get; set; }
        public string pc_estado { get; set; }
        public string pc_prefijo { get; set; }


        public int sm_id { get; set; }
        public double sm_importe { get; set; }
        public string sm_operacion { get; set; }
        public string sm_fecha_vigencia { get; set; }
        public double sm_porcentaje_incremento { get; set; }
        #endregion

        #region METODOS
		public bool Procesar_Sanciones_Adicional(int secuencial, int pc_id, int tipo)
        {
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Procesar_Sanciones_Adicional(secuencial, pc_id, tipo);
        }
		public bool Procesar_Sanciones(int codigo)
        {
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Procesar_Sanciones(codigo);
        }
		/// <summary>
		/// Método que adiciona una nuevo registro en tbl_pla_proceso
		/// </summary>
		public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar__pla_proceso(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla tbl_pla_proceso
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar__pla_proceso(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla tbl_pla_proceso
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar__pla_proceso(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de tbl_pla_proceso
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId__pla_proceso(this);
		}

		/// <summary>
		/// Método que obtiene un registro de tbl_pla_proceso
		/// </summary>
		/// <param name="pc_id">
		/// Clave primaria de la tabla _pla_proceso
		/// </param>

		public bool ObtenerRegistro(int pc_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro__pla_proceso(this);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_pla_proceso para llenar una grilla
		/// </summary>
		/// <param name="pc_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pc_pr_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pc_titulo">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pc_fecha_inicio">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pc_fecha_fin">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pc_mn_id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pc_ufv">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pc_ufv_fecha">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pc_estado">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="pc_prefijo">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>

		public DataSet ObtenerTablaGrilla(string pc_id, 
						string pc_pr_id, 
						string pc_titulo, 
						string pc_fecha_inicio, 
						string pc_fecha_fin, 
						string pc_mn_id, 
						string pc_ufv, 
						string pc_ufv_fecha, 
						string pc_estado, 
						string pc_prefijo)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla__pla_proceso(pc_id, pc_pr_id, pc_titulo, pc_fecha_inicio, pc_fecha_fin, pc_mn_id, pc_ufv, pc_ufv_fecha, pc_estado, pc_prefijo);
		}

		/// <summary>
		/// Método que obtiene la tabla tbl_pla_proceso para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo__pla_proceso();
		}
        public DataSet ObtenerUFVAnterior()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerUFVAnterior(this);

        }
        public DataSet ObtenerUFVActual()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerUFVActual(this);
        }
        public DataSet ObtenerSalarioMinimo()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerSalarioMinimo(this);

        }
		public DataSet ObtenerSalarioMinimoAdicional()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerSalarioMinimoAdicional(this);

		}
		public  DataSet EjecutarProceso1(int cod_proceso)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.EjecutarProceso1(cod_proceso);
		}
		public  DataSet EjecutarProceso2(int cod_proceso)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.EjecutarProceso2(cod_proceso);
		}
		public  DataSet EjecutarProceso3(int cod_proceso)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.EjecutarProceso3(cod_proceso);
		}
		public DataSet EjecutarProceso4(int cod_proceso)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.EjecutarProceso4(cod_proceso);
		}



		public DataSet EjecutarProceso1_adicional(int cod_proceso, int secuencial)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.EjecutarProceso1_adicional(cod_proceso, secuencial);
		}
		public DataSet EjecutarProceso2_adicional(int cod_proceso, int secuencial)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.EjecutarProceso2_adicional(cod_proceso, secuencial);
		}
		public DataSet EjecutarProceso3_adicional(int cod_proceso, int secuencial)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.EjecutarProceso3_adicional(cod_proceso, secuencial);
		}
		public DataSet EjecutarProceso4_adicional(int cod_proceso, int secuencial)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.EjecutarProceso4_adicional(cod_proceso, secuencial);
		}



		public DataSet ObtenerMesesProceso()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerMesesProceso();
		}
		public DataSet ObtenerMesesProceso_Liquidos()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerMesesProceso_Liquidos();
		}

		public DataSet VerificarCasosDoblePercepcion(int cod_proceso, string accion)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.VerificarCasosDoblePercepcion(cod_proceso, accion);
		}
		public DataSet VerificarCasosDoblePercepcion_adicional(int cod_proceso, string accion, string secuencial)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.VerificarCasosDoblePercepcion_adicional(cod_proceso, accion, secuencial);
		}

		public DataSet AjusteDoblePercepcion(string ti_tipo, int cbh_id, int horas, double ganado, double esc_por, double esc, double bono_a, double bono_f)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.AjusteDoblePercepcion( ti_tipo,  cbh_id,  horas,  ganado,  esc_por,  esc,  bono_a,  bono_f);
		}
		public DataSet AjusteDoblePercepcion_adicional(string ti_tipo, int cbh_id, int horas, double ganado, double esc_por, double esc, double bono_a, double bono_f)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.AjusteDoblePercepcion_adicional(ti_tipo, cbh_id, horas, ganado, esc_por, esc, bono_a, bono_f);
		}
		public bool AplicarAjusteDoblePercepcion_adicional(string ti_tipo, int cbh_id, int horas, double ganado, double esc_por, double esc, double bono_a, double bono_f)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.AplicarAjusteDoblePercepcion_adicional(ti_tipo, cbh_id, horas, ganado, esc_por, esc, bono_a, bono_f);
		}

		public bool AplicarAjusteDoblePercepcion(string ti_tipo, int cbh_id, int horas, double ganado, double esc_por, double esc, double bono_a, double bono_f)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.AplicarAjusteDoblePercepcion(ti_tipo, cbh_id, horas, ganado, esc_por, esc, bono_a, bono_f);
		}
		public  bool GenerarCarpetas_C31(int cod_proceso)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.GenerarCarpetas_C31(cod_proceso);
		}
		public  DataSet Combos_C31(int cod_proceso, string accion)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Combos_C31(cod_proceso, accion);
		}
		public  DataSet GenerarRegistroC31_4(string tipo_planilla, string archivos, int cod_proceso, string tipo_archivo)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.GenerarRegistroC31_4(tipo_planilla, archivos, cod_proceso, tipo_archivo);
		}
		public  int ActualizarMesProceso(string cod_proceso)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ActualizarMesProceso(cod_proceso);
		}
		public  bool FinalizarProcesoPlanilla(string cod_proceso, string secuencial)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.FinalizarProcesoPlanilla(cod_proceso, secuencial);
		}
		public  DataSet VerificarPlanillasAdicionales(string cod_proceso)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.VerificarPlanillasAdicionales(cod_proceso);
		}
		public  DataSet VerificarPlanillasRetroactivo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.VerificarPlanillasRetroactivo();
		}
		public  DataSet PlanillasMigradas_Retroactivo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.PlanillasMigradas_Retroactivo();
		}
		public bool MigrarPlanilla_Retroactivo(string cod_proceso, string nro, string id_usuario)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.MigrarPlanilla_Retroactivo(cod_proceso, nro, id_usuario);
		}
		public  bool FinalizarMigracion_Retroactivo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.FinalizarMigracion_Retroactivo();
		}
		public  bool InsertarIncremento_Retroactivo(double incremento)
		{	
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.InsertarIncremento_Retroactivo(incremento);
		}
		public string ObtenerConsultores_NumeroPlanilla(string cod_proceso)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerConsultores_NumeroPlanilla(cod_proceso);
		}
		public DataSet Insertar_MostrarCasos_Consultores(string cod_proceso, string secuencial)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Insertar_MostrarCasos_Consultores(cod_proceso, secuencial);
		}
		public  bool ProcesarConsultores_Paso1(string cod_proceso, string secuencial, string list_as_id)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ProcesarConsultores_Paso1(cod_proceso, secuencial, list_as_id);
		}
		public bool ProcesarConsultores_Paso2(string cod_proceso, string secuencial)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ProcesarConsultores_Paso2(cod_proceso, secuencial);
		}
		public bool ProcesarConsultores_Paso3(string cod_proceso, string secuencial)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ProcesarConsultores_Paso3(cod_proceso, secuencial);
		}
		public bool ProcesarConsultores_Paso4(string cod_proceso, string secuencial)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ProcesarConsultores_Paso4(cod_proceso, secuencial);
		}
		public  DataSet VerificarPlanilla_Consultores(string cod_proceso, string secuencial)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.VerificarPlanilla_Consultores(cod_proceso, secuencial);
		}
		public  DataSet NumeroPlanilla_Combo(string cod_proceso)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.NumeroPlanilla_Combo(cod_proceso);
		}
		public  DataSet NumeroPlanilla_ComboReportesAdicionales(string cod_proceso)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.NumeroPlanilla_ComboReportesAdicionales(cod_proceso);
		}
		#endregion
	}
}

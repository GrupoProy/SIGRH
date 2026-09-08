using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Kardex.BussinessLogicLayer;

public partial class Kardex_Finiquito : System.Web.UI.Page
{
	private cls_mp_asignacion asignacion = null;
	private cls_kd_finiquito finiquito = null;
	private string sc = "";
	protected void Page_Load(object sender, EventArgs e)
	{
		//if (!Page.IsPostBack)
		//{
		//	int per_id = Convert.ToInt32(Request.QueryString["id"].ToString());
		//	int as_id = Convert.ToInt32(Request.QueryString["id2"].ToString());
		//	informacionFuncionario(per_id, as_id);
		//	MesesRemunerados();
		//	//obtenerGrillaAsginaciones(per_id);
		//	//obtenerTiempoServicio(per_id);
		//	//armarUltimosSueldos(per_id);
		//}
		if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
		{
			if (!Page.IsPostBack)
			{
				Session["Fi_id"] = "";
				Session["FiniquitoFinalizado"] = false;

				int per_id = Convert.ToInt32(Request.QueryString["id"].ToString());
					int as_id = Convert.ToInt32(Request.QueryString["id2"].ToString());
					informacionFuncionario(per_id, as_id);
					VerificarRegistro(per_id, as_id);

				if (HttpContext.Current.Session["FiniquitoFinalizado"].ToString() == "False")
				{
					MesesRemunerados();
					CalcularVacaciones();
					CalcularAguinaldo();
				}
				else
				{
					DivFiniquito.Visible = false;
					btnImprimir.Visible = true;
					btnActualizar.Visible = false;
				}
			}
		}
		else Response.Redirect("../Index");
}
	private void VerificarRegistro(int per_id, int as_id) {
		cls_kd_finiquito2 finiquito = new cls_kd_finiquito2();
		DataSet ds = finiquito.ObtenerRegistro(per_id, as_id);
		if (ds.Tables[0].Rows.Count > 0)
		{
			Session["Fi_id"] = ds.Tables[0].Rows[0]["Fi_id"].ToString();
			ltl_fecha_ingreso.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Fi_FechaIngerso"].ToString()).ToShortDateString();
			ltl_anios.Text = ds.Tables[0].Rows[0]["Fi_anioServicio"].ToString();
			ltl_meses.Text = ds.Tables[0].Rows[0]["Fi_MesServicio"].ToString();
			ltl_dias.Text = ds.Tables[0].Rows[0]["Fi_DiasServicio"].ToString();
			txtRem1.Text = ds.Tables[0].Rows[0]["Fi_Remuneracion1"].ToString();
			txtRem2.Text = ds.Tables[0].Rows[0]["Fi_Remuneracion2"].ToString();
			txtRem3.Text = ds.Tables[0].Rows[0]["Fi_Remuneracion3"].ToString();
			ltl_fecha_ingreso.Visible = true;
			txtFechaIngreso.Visible = false;
			if (ds.Tables[0].Rows[0]["Fi_TotalPagado"].ToString() != "")
				Session["FiniquitoFinalizado"] = true;
		}
	}
	private void MesesRemunerados() {
		cls_kd_finiquito2 finiquito = new cls_kd_finiquito2();
		DataSet ds = finiquito.CalcularGestiones(ltl_fecha_retiro.Text);
		lblMes1.Text = ds.Tables[0].Rows[0]["M1"].ToString();
		lblMes2.Text = ds.Tables[0].Rows[0]["M2"].ToString();
		lblMes3.Text = ds.Tables[0].Rows[0]["M3"].ToString();
	}
	private void SetScript(string val, string valS)
	{
		StringBuilder sb = new StringBuilder();
		sb.Append(@"<script type='text/javascript'>");
		sb.Append(val);
		sb.Append("$('.table').DataTable({" +
				"'language': {" +
					"'sProcessing': 'Procesando...'," +
					"'sLengthMenu': 'Mostrar _MENU_ registros'," +
					"'sZeroRecords': 'No se encontraron resultados'," +
					"'sEmptyTable': 'Ningún dato disponible en esta tabla'," +
					"'sInfo': 'Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros'," +
					"'sInfoEmpty': 'Mostrando registros del 0 al 0 de un total de 0 registros'," +
					"'sInfoFiltered': '(filtrado de un total de _MAX_ registros)'," +
					"'sInfoPostFix': ''," +
					"'sSearch': 'Buscar:'," +
					"'sUrl': ''," +
					"'sInfoThousands': ','," +
					"'sLoadingRecords': 'Cargando...'," +
					"'oPaginate': {" +
						"'sFirst': '«'," +
						"'sLast': '»'," +
						"'sNext': '<i class=\"fas fa-angle-right\"></i>'," +
						"'sPrevious': '<i class=\"fas fa-angle-left\"></i>'" +
					"}," +
					"'oAria': {" +
						"'sSortAscending': ': Activar para ordenar la columna de manera ascendente'," +
						"'sSortDescending': ': Activar para ordenar la columna de manera descendente'" +
					"}" +
				"}," +
				"'ordering': false," +
				"'searching': true," +
				"'autoWidth': false," +
				"'orderCellsTop': true," +
				"'fixedHeader': true" +
			"});");
        sb.Append("$('.numero').on('input', function (event) {" +
                "this.value = this.value.replace(/[^0-9]/g, '');" +
            "});");

        sb.Append("$('.letras').on('input', function () {" +
				"this.value = this.value.replace(/[^A-Z\u00F1\u00D1 ]+$/i, '');" +
			"});");
		sb.Append("$('.tooltip').css('display', 'none');" +
			"$('[data-toggle=\"tooltip\"]').tooltip({ trigger: 'hover' });");
		sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' }" + valS + " });");
		sb.Append("$(\".radios label\").addClass(\"custom-control-label mb-3\");" +
			"$(\".radios input[type='radio']\").addClass(\"custom-control-input mb-3\");");
		sb.Append("$(function () {" +
				"$(\"body\").delegate(\".datepickerD\", \"focusin\", function () {" +
					"$(this).datepicker({" +
						"format: \"dd/mm/yyyy\"," +
						"autoclose: true," +
						"language: 'es'" +
					"});" +
				"});" +
				"var me = $(\".datepickerD\");" +
				"me.mask('99/99/9999');" +
			"});");
		sb.Append(@"</script>");
		ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
	}

	//private void obtenerGrillaAsginaciones(int per_id = 0)
	//{
	//	try
	//	{
	//		finiquito = new cls_kd_finiquito();
	//		finiquito.fin_per_id = per_id;
	//		var detalle_asignaciones = finiquito.ObtenerAsignaciones();

	//		int total_dias = 0;
	//		for (int i = 0; i < detalle_asignaciones.Tables[0].Rows.Count; i++)
	//		{
	//			total_dias = total_dias + Convert.ToInt32(validarCampo(detalle_asignaciones.Tables[0].Rows[i]["dias"]));
	//		}

	//		if (total_dias > 0)
	//		{
	//			finiquito = new cls_kd_finiquito();
	//			finiquito.fin_per_id = per_id;
	//			finiquito.fin_tiempo_servicio = JsonConvert.SerializeObject(detalle_asignaciones.Tables[0]);
	//			finiquito.fin_estado = "V";
	//			var detalle_tiempo_servicio = finiquito.Adicionar();

	//			string str = validarCampo(detalle_tiempo_servicio.Tables[0].Rows[0]["fin_tiempo_servicio"]);
	//			var tiempo_servicio = JsonConvert.DeserializeObject<DataTable>(str);
	//			gv_asignaciones.DataSource = tiempo_servicio;
	//			gv_asignaciones.DataBind();

	//			calcularTiempoTotalDias(tiempo_servicio);
	//		}


	//	}
	//	catch (Exception e)
	//	{
	//		Console.Error.Write(e.Message);
	//	}
	//}

	private void calcularTiempoTotalDias(DataTable tiempo_servicio = null)
	{
		int total_dias = 0;
		for (int i = 0; i < tiempo_servicio.Rows.Count; i++)
		{
			if (validarCampo(tiempo_servicio.Rows[i]["contar"]) == "1")
			{
				total_dias = total_dias + Convert.ToInt32(validarCampo(tiempo_servicio.Rows[i]["dias"]));
			}
		}
		hf_total_dias.Value = total_dias + "";
	}
	private void informacionFuncionario(int per_id = 0, int as_id = 0)
	{
		cls_kd_finiquito2 finiquito = new cls_kd_finiquito2();
		asignacion = new cls_mp_asignacion();
		asignacion.as_per_id = per_id;
		asignacion.as_id = as_id;
		var detalleFuncionario = asignacion.ObtenerInformacionFiniquito();
		if (detalleFuncionario.Tables.Count > 0)
		{
			if (detalleFuncionario.Tables[0].Rows.Count > 0)
			{
				var funcionario = detalleFuncionario.Tables[0].Rows[0];
				ltl_razon_social.Text = validarCampo(funcionario["razon_social_act"]);
				ltl_rama_act.Text = validarCampo(funcionario["rama_act"]);
				ltl_domicilio_act.Text = validarCampo(funcionario["direccion_act"]);
				ltl_nombre_fun.Text = validarCampo(funcionario["nombre_fun"]);
				ltl_estado_civil.Text = validarCampo(funcionario["per_estado_civil"]);
				ltl_edad.Text = validarCampo(funcionario["edad"]);
				ltl_domicilio.Text = validarCampo(funcionario["domicilio"]);
				ltl_profesion.Text = validarCampo(funcionario["OCUPACION"]);
				ltl_ci.Text = validarCampo(funcionario["per_num_doc"]);
				ltl_fecha_ingreso.Text = validarCampo(funcionario["fehca_ingreso"]);
				ltl_fecha_retiro.Text = validarCampo(funcionario["fecha_retiro"]);
				ltl_motivo_retiro.Text = validarCampo(funcionario["motivo_retiro"]);
				ltl_remuneracion_mensual.Text = validarCampo(funcionario["haber_basico"]);
				hf_as_tipo_baja.Value = validarCampo(funcionario["as_tipo_baja"]);
				//ltl_tiempo_servicio.Text = validarCampo(funcionario["nombre_fun"]);
				//ltl_anios.Text = validarCampo(funcionario["nombre_fun"]);
				//ltl_meses.Text = validarCampo(funcionario["nombre_fun"]);
				//ltl_dias.Text = validarCampo(funcionario["nombre_fun"]);
				if (ltl_fecha_ingreso.Text != "")
				{
					ltl_anios.Text = finiquito.TiempoServicio(ltl_fecha_ingreso.Text, "anio");
					ltl_meses.Text = finiquito.TiempoServicio(ltl_fecha_ingreso.Text, "mes");
					ltl_dias.Text = finiquito.TiempoServicio(ltl_fecha_ingreso.Text, "dia");
					txtFechaIngreso.Text = ltl_fecha_ingreso.Text;
					ltl_fecha_ingreso.Visible = true;
					txtFechaIngreso.Visible = false;
					//btnActualizar.Visible = false;
				}
				else {
					ltl_fecha_ingreso.Visible = false;
					txtFechaIngreso.Visible = true;
					txtFechaIngreso.Text = "";
				}
				if (validarCampo(funcionario["as_estado"]) == "V")
				{
					btn_estado.Text = "Vigente";
					btn_estado.CssClass = "btn btn-sm btn-info float-right";
				}
				else
				{
					btn_estado.Text = "Pasivo";
					btn_estado.CssClass = "btn btn-sm btn-secondary float-right";
				}

				if (validarCampo(funcionario["fp_foto"]) != "")
				{
					imgFun.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])detalleFuncionario.Tables[0].Rows[0]["fp_foto"]);
				}
				else
				{
					if (validarCampo(funcionario["per_sexo"]) == "M")
					{
						imgFun.ImageUrl = "../Content/img/theme/user3.jpg";
					}
					else
					{
						imgFun.ImageUrl = "../Content/img/theme/user4.jpg";
					}
				}

			}
		}
	}
	//private void armarBeneficiosSociales(DataTable lista_asignaciones_reg)
	//{
	//	int per_id = Convert.ToInt32(Request.QueryString["id"].ToString());
	//	asignacion = new cls_mp_asignacion();
	//	asignacion.as_per_id = per_id;
	//	var detalle_vacacion = asignacion.ObtenerCantidadVacacion();

	//	ltl_antiguedad_anios.Text = "12";// ltl_anios.Text;
	//	ltl_antiguedad_meses.Text = "3";// ltl_meses.Text;
	//	ltl_antiguedad_dias.Text = "3";// ltl_dias.Text;

	//	if (hf_as_tipo_baja.Value == "D")
	//	{
	//		double desahucio = (Math.Round(Convert.ToDouble(ltl_rem_promedio.Text), 2)) * 3;
	//		ltl_desahucio.Text = String.Format("{0:0.00}", desahucio);
	//	}
	//	else
	//	{
	//		ltl_desahucio.Text = String.Format("{0:0.00}", 0);
	//	}

	//	double indem_anios = (Math.Round(Convert.ToDouble(ltl_antiguedad_anios.Text), 2)) * (Math.Round(Convert.ToDouble(ltl_rem_promedio.Text), 2));
	//	ltl_indem_anios.Text = String.Format("{0:0.00}", indem_anios);

	//	double indem_meses = (Math.Round(Convert.ToDouble(ltl_antiguedad_meses.Text), 2)) * ((Math.Round(Convert.ToDouble(ltl_rem_promedio.Text), 2)) / 12);
	//	ltl_indem_meses.Text = String.Format("{0:0.00}", indem_meses);

	//	double indem_dias = (Math.Round(Convert.ToDouble(ltl_antiguedad_dias.Text), 2)) * ((Math.Round(Convert.ToDouble(ltl_rem_promedio.Text), 2)) / 360);
	//	ltl_indem_dias.Text = String.Format("{0:0.00}", indem_dias);

	//	double indem_sum = (Math.Round(Convert.ToDouble(ltl_indem_anios.Text), 2)) + (Math.Round(Convert.ToDouble(ltl_indem_meses.Text), 2)) + (Math.Round(Convert.ToDouble(ltl_indem_dias.Text), 2));
	//	ltl_indem_sum.Text = String.Format("{0:0.00}", indem_sum);

	//	int vacacion_mes = 0;
	//	int vacacion_dia = 0;
	//	for (int i = 0; i < lista_asignaciones_reg.Rows.Count; i++)
	//	{
	//		if (validarCampo(lista_asignaciones_reg.Rows[i]["anio"]) == DateTime.Now.ToString("yyyy"))
	//		{
	//			if (validarCampo(lista_asignaciones_reg.Rows[i]["tiempo"]) == "30")
	//			{
	//				vacacion_mes = vacacion_mes + Convert.ToInt32(validarCampo(lista_asignaciones_reg.Rows[i]["tiempo"]));
	//			}
	//			else
	//			{
	//				vacacion_dia = Convert.ToInt32(validarCampo(lista_asignaciones_reg.Rows[i]["tiempo"]));
	//			}
	//		}
	//	}
	//	ltl_aguinaldo_mes.Text = (vacacion_mes / 30) + "";
	//	ltl_aguinaldo_dia.Text = vacacion_dia + "";

	//	double aguinaldo_sum = ((Math.Round(Convert.ToDouble(ltl_aguinaldo_mes.Text), 2)) * ((Math.Round(Convert.ToDouble(ltl_rem_promedio.Text), 2)) / 12)) + ((Math.Round(Convert.ToDouble(ltl_aguinaldo_dia.Text), 2)) * ((Math.Round(Convert.ToDouble(ltl_rem_promedio.Text), 2)) / 360));
	//	ltl_aguinaldo_sum.Text = String.Format("{0:0.00}", aguinaldo_sum);

	//	ltl_prima_sum.Text = String.Format("{0:0.00}", 0);
	//	ltl_otros_sum.Text = String.Format("{0:0.00}", 0);

	//	ltl_vacacion_dias.Text = validarCampo(detalle_vacacion.Tables[0].Rows[0]["cantidad"]);

	//	double vacacion_sum = ((Math.Round(Convert.ToDouble(ltl_vacacion_dias.Text), 2)) * ((Math.Round(Convert.ToDouble(ltl_rem_promedio.Text), 2)) / 30));
	//	ltl_vacacion_sum.Text = String.Format("{0:0.00}", vacacion_sum);

	//	double total_beneficios_soc = Math.Round(Convert.ToDouble(ltl_desahucio.Text), 2) + Math.Round(Convert.ToDouble(ltl_indem_sum.Text), 2) + Math.Round(Convert.ToDouble(ltl_aguinaldo_sum.Text), 2) + Math.Round(Convert.ToDouble(ltl_vacacion_sum.Text), 2) +
	//		Math.Round(Convert.ToDouble(ltl_prima_sum.Text), 2) + Math.Round(Convert.ToDouble(ltl_otros_sum.Text), 2);
	//	ltl_total_beneficios_soc.Text = String.Format("{0:0.00}", total_beneficios_soc);

	//	double deduc_vacaciones = (Math.Round(Convert.ToDouble(ltl_vacacion_sum.Text), 2)) * (0.13);
	//	ltl_deduc_vacaciones.Text = String.Format("{0:0.00}", deduc_vacaciones);
	//	ltl_deduc_vacaciones_sum.Text = String.Format("{0:0.00}", ltl_deduc_vacaciones.Text);

	//	double importe_liquido = (Math.Round(Convert.ToDouble(ltl_total_beneficios_soc.Text), 2)) - (Math.Round(Convert.ToDouble(ltl_deduc_vacaciones_sum.Text), 2));
	//	ltl_importe_liquido.Text = String.Format("{0:0.00}", importe_liquido);

	//}
	//private void armarliquidacionPromedio(DataTable lista_asignaciones_reg)
	//{
	//	string json = JsonConvert.SerializeObject(lista_asignaciones_reg);
	//	int per_id = Convert.ToInt32(Request.QueryString["id"].ToString());
	//	asignacion = new cls_mp_asignacion();
	//	asignacion.as_per_id = per_id;

	//	for (int i = 0; i < lista_asignaciones_reg.Rows.Count; i++)
	//	{
	//		if (Convert.ToInt32(validarCampo(lista_asignaciones_reg.Rows[i]["tiempo"])) == 30)
	//		{
	//			string mes_anio1 = "'" + validarCampo(lista_asignaciones_reg.Rows[i]["mes_anio"]) + "'";
	//			string mes_anio2 = "'" + validarCampo(lista_asignaciones_reg.Rows[i + 1]["mes_anio"]) + "'";
	//			string mes_anio3 = "'" + validarCampo(lista_asignaciones_reg.Rows[i + 2]["mes_anio"]) + "'";

	//			string desc_mes_anio1 = validarCampo(lista_asignaciones_reg.Rows[i]["desc_mes_anio"]);
	//			string desc_mes_anio2 = validarCampo(lista_asignaciones_reg.Rows[i + 1]["desc_mes_anio"]);
	//			string desc_mes_anio3 = validarCampo(lista_asignaciones_reg.Rows[i + 2]["desc_mes_anio"]);

	//			var detalle_boleta1 = obtenerDetalleBoleta(per_id, mes_anio1);
	//			var detalle_boleta2 = obtenerDetalleBoleta(per_id, mes_anio2);
	//			var detalle_boleta3 = obtenerDetalleBoleta(per_id, mes_anio3);

	//			if (detalle_boleta1.Rows.Count > 0)
	//			{
	//				var boleta1 = detalle_boleta1.Rows;

	//				for (int j = 0; j < boleta1.Count; j++)
	//				{
	//					double monto = 0;
	//					ltl_rem_men1.Text = (ltl_rem_men1.Text != "") ? ltl_rem_men1.Text : String.Format("{0:0.00}", monto);
	//					ltl_bono_antiguedad1.Text = (ltl_bono_antiguedad1.Text != "") ? ltl_bono_antiguedad1.Text : String.Format("{0:0.00}", monto);
	//					ltl_horas_extras1.Text = (ltl_horas_extras1.Text != "") ? ltl_horas_extras1.Text : String.Format("{0:0.00}", monto);

	//					if (Convert.ToInt32(validarCampo(boleta1[j]["dbh_fa_id"])) == 61)
	//					{
	//						monto = Math.Round(Convert.ToDouble(validarCampo(boleta1[j]["dbh_valor"])), 2);
	//						ltl_rem_men1.Text = String.Format("{0:0.00}", monto);
	//					}
	//					if (Convert.ToInt32(validarCampo(boleta1[j]["dbh_fa_id"])) == 24)
	//					{
	//						monto = Math.Round(Convert.ToDouble(validarCampo(boleta1[j]["dbh_valor"])), 2);
	//						ltl_bono_antiguedad1.Text = String.Format("{0:0.00}", monto);
	//					}
	//					if (Convert.ToInt32(validarCampo(boleta1[j]["dbh_fa_id"])) == 23)
	//					{
	//						monto = Math.Round(Convert.ToDouble(validarCampo(boleta1[j]["dbh_valor"])), 2);
	//						ltl_horas_extras1.Text = String.Format("{0:0.00}", monto);
	//					}
	//				}

	//			}

	//			if (detalle_boleta2.Rows.Count > 0)
	//			{
	//				var boleta2 = detalle_boleta2.Rows;

	//				for (int j = 0; j < boleta2.Count; j++)
	//				{
	//					double monto = 0;
	//					ltl_rem_men2.Text = (ltl_rem_men2.Text != "") ? ltl_rem_men2.Text : String.Format("{0:0.00}", monto);
	//					ltl_bono_antiguedad2.Text = (ltl_bono_antiguedad2.Text != "") ? ltl_bono_antiguedad2.Text : String.Format("{0:0.00}", monto);
	//					ltl_horas_extras2.Text = (ltl_horas_extras2.Text != "") ? ltl_horas_extras2.Text : String.Format("{0:0.00}", monto);

	//					if (Convert.ToInt32(validarCampo(boleta2[j]["dbh_fa_id"])) == 61)
	//					{
	//						monto = Math.Round(Convert.ToDouble(validarCampo(boleta2[j]["dbh_valor"])), 2);
	//						ltl_rem_men2.Text = String.Format("{0:0.00}", monto);
	//					}
	//					if (Convert.ToInt32(validarCampo(boleta2[j]["dbh_fa_id"])) == 24)
	//					{
	//						monto = Math.Round(Convert.ToDouble(validarCampo(boleta2[j]["dbh_valor"])), 2);
	//						ltl_bono_antiguedad2.Text = String.Format("{0:0.00}", monto);
	//					}
	//					if (Convert.ToInt32(validarCampo(boleta2[j]["dbh_fa_id"])) == 23)
	//					{
	//						monto = Math.Round(Convert.ToDouble(validarCampo(boleta2[j]["dbh_valor"])), 2);
	//						ltl_horas_extras2.Text = String.Format("{0:0.00}", monto);
	//					}
	//				}
	//			}

	//			if (detalle_boleta3.Rows.Count > 0)
	//			{
	//				var boleta3 = detalle_boleta3.Rows;

	//				for (int j = 0; j < boleta3.Count; j++)
	//				{
	//					double monto = 0;
	//					ltl_rem_men3.Text = (ltl_rem_men3.Text != "") ? ltl_rem_men3.Text : String.Format("{0:0.00}", monto);
	//					ltl_bono_antiguedad3.Text = (ltl_bono_antiguedad3.Text != "") ? ltl_bono_antiguedad3.Text : String.Format("{0:0.00}", monto);
	//					ltl_horas_extras3.Text = (ltl_horas_extras3.Text != "") ? ltl_horas_extras3.Text : String.Format("{0:0.00}", monto);

	//					if (Convert.ToInt32(validarCampo(boleta3[j]["dbh_fa_id"])) == 61)
	//					{
	//						monto = Math.Round(Convert.ToDouble(validarCampo(boleta3[j]["dbh_valor"])), 2);
	//						ltl_rem_men3.Text = String.Format("{0:0.00}", monto);
	//					}
	//					if (Convert.ToInt32(validarCampo(boleta3[j]["dbh_fa_id"])) == 24)
	//					{
	//						monto = Math.Round(Convert.ToDouble(validarCampo(boleta3[j]["dbh_valor"])), 2);
	//						ltl_bono_antiguedad3.Text = String.Format("{0:0.00}", monto);
	//					}
	//					if (Convert.ToInt32(validarCampo(boleta3[j]["dbh_fa_id"])) == 23)
	//					{
	//						monto = Math.Round(Convert.ToDouble(validarCampo(boleta3[j]["dbh_valor"])), 2);
	//						ltl_horas_extras3.Text = String.Format("{0:0.00}", monto);
	//					}
	//				}

	//			}

	//			double sum3 = Math.Round(Convert.ToDouble(ltl_rem_men3.Text), 2) + Math.Round(Convert.ToDouble(ltl_bono_antiguedad3.Text), 2) + Math.Round(Convert.ToDouble(ltl_horas_extras3.Text), 2);
	//			ltl_sum3.Text = String.Format("{0:0.00}", sum3);

	//			double sum2 = Math.Round(Convert.ToDouble(ltl_rem_men2.Text), 2) + Math.Round(Convert.ToDouble(ltl_bono_antiguedad2.Text), 2) + Math.Round(Convert.ToDouble(ltl_horas_extras2.Text), 2);
	//			ltl_sum2.Text = String.Format("{0:0.00}", sum2);

	//			double sum1 = Math.Round(Convert.ToDouble(ltl_rem_men1.Text), 2) + Math.Round(Convert.ToDouble(ltl_bono_antiguedad1.Text), 2) + Math.Round(Convert.ToDouble(ltl_horas_extras1.Text), 2);
	//			ltl_sum1.Text = String.Format("{0:0.00}", sum1);

	//			double rem_sum = Math.Round(Convert.ToDouble(ltl_rem_men1.Text), 2) + Math.Round(Convert.ToDouble(ltl_rem_men2.Text), 2) + Math.Round(Convert.ToDouble(ltl_rem_men3.Text), 2);
	//			ltl_rem_sum.Text = String.Format("{0:0.00}", rem_sum);

	//			double bono_antiguedad_sum = Math.Round(Convert.ToDouble(ltl_bono_antiguedad1.Text), 2) + Math.Round(Convert.ToDouble(ltl_bono_antiguedad2.Text), 2) + Math.Round(Convert.ToDouble(ltl_bono_antiguedad3.Text), 2);
	//			ltl_bono_antiguedad_sum.Text = String.Format("{0:0.00}", bono_antiguedad_sum);

	//			double horas_extras_sum = Math.Round(Convert.ToDouble(ltl_horas_extras1.Text), 2) + Math.Round(Convert.ToDouble(ltl_horas_extras2.Text), 2) + Math.Round(Convert.ToDouble(ltl_horas_extras3.Text), 2);
	//			ltl_horas_extras_sum.Text = String.Format("{0:0.00}", horas_extras_sum);

	//			double suma_total = Math.Round(Convert.ToDouble(ltl_rem_sum.Text), 2) + Math.Round(Convert.ToDouble(ltl_bono_antiguedad_sum.Text), 2) + Math.Round(Convert.ToDouble(ltl_horas_extras_sum.Text), 2);
	//			ltl_suma_total.Text = String.Format("{0:0.00}", suma_total);

	//			double rem_promedio = (Math.Round(Convert.ToDouble(ltl_suma_total.Text), 2)) / 3;
	//			ltl_rem_promedio.Text = String.Format("{0:0.00}", rem_promedio);

	//			ltl_mes1.Text = desc_mes_anio1;
	//			ltl_mes2.Text = desc_mes_anio2;
	//			ltl_mes3.Text = desc_mes_anio3;
	//			break;

	//		}

	//	}
	//}
	private void armarUltimosSueldos(int per_id = 0)
	{
		asignacion = new cls_mp_asignacion();
		asignacion.as_per_id = per_id;
		var detalle_asig = asignacion.ObtenerAsignacionesRealizadas();

		if (detalle_asig.Tables[0].Rows.Count > 0)
		{
			var asig_realizadas = detalle_asig.Tables[0].Rows;
			DataTable lista_mes_dias = armarAsginacionesReglamentaria(asig_realizadas);
			DataTable lista_asignaciones_reg = validarArrayDias(lista_mes_dias);

			if (validarArrayContinuidad(lista_asignaciones_reg))
			{
				//string param = "";
				//for (int i = 0; i < lista_asignaciones_reg.Rows.Count; i++)
				//{
				//    string mes_anio = validarCampo(lista_asignaciones_reg.Rows[i]["mes_anio"]);
				//    param = param + ", '" + mes_anio + "'";
				//}
				//param = param.Substring(1, param.Length - 1);
				//var detalle_boleta = obtenerDetalleBoleta(per_id, param);

				//armarliquidacionPromedio(lista_asignaciones_reg);
				//armarBeneficiosSociales(lista_mes_dias);

				//string json = JsonConvert.SerializeObject(lista_asignaciones_reg);

			}

		}
	}
	private DataTable obtenerDetalleBoleta(int per_id = 0, string param = "")
	{
		asignacion = new cls_mp_asignacion();
		asignacion.as_per_id = per_id;
		var detalle_asig = asignacion.ObtenerBoleta(param);

		return detalle_asig.Tables[0];
	}
	private bool validarArrayContinuidad(DataTable asig_realizadas = null)
	{
		bool sw = true;

		for (int i = 0; i < asig_realizadas.Rows.Count; i++)
		{
			var asig = asig_realizadas.Rows[i];
			int tiempo = Convert.ToInt32(validarCampo(asig["tiempo"]));

			if (tiempo == 30)
			{
				string fecha_inicio = validarCampo(asig_realizadas.Rows[i]["fecha_inicio"]);
				string fecha_inicio1 = validarCampo(asig_realizadas.Rows[i + 1]["fecha_inicio"]);
				string fecha_inicio2 = validarCampo(asig_realizadas.Rows[i + 2]["fecha_inicio"]);

				DateTime date = Convert.ToDateTime(fecha_inicio);
				DateTime date1 = Convert.ToDateTime(fecha_inicio1);
				DateTime date2 = Convert.ToDateTime(fecha_inicio2);

				var comp = date.AddMonths(-1);
				var comp1 = date1.AddMonths(-1);

				if ((date1.Month == comp.Month && date1.Year == comp.Year) && (date2.Month == comp1.Month && date2.Year == comp1.Year))
				{
					sw = true;
					break;
				}
				else
				{
					sw = false;
					break;
				}
			}
		}

		return sw;
	}
	private DataTable validarArrayDias(DataTable asig_realizadas = null)
	{
		DataTable array_validado = new DataTable();
		array_validado.Columns.Add("fecha_inicio");
		array_validado.Columns.Add("fecha_fin");
		array_validado.Columns.Add("mes");
		array_validado.Columns.Add("anio");
		array_validado.Columns.Add("mes_anio");
		array_validado.Columns.Add("desc_mes_anio");
		array_validado.Columns.Add("tiempo");
		DataRow dr = null;

		for (int i = 0; i < asig_realizadas.Rows.Count; i++)
		{
			var asig = asig_realizadas.Rows[i];
			int tiempo = Convert.ToInt32(validarCampo(asig["tiempo"]));

			if (tiempo == 30)
			{
				if (Convert.ToInt32(validarCampo(asig_realizadas.Rows[i]["tiempo"])) == 30 && Convert.ToInt32(validarCampo(asig_realizadas.Rows[i + 1]["tiempo"])) == 30 && Convert.ToInt32(validarCampo(asig_realizadas.Rows[i + 2]["tiempo"])) == 30)
				{
					if ((i - 1) >= 0)
					{
						array_validado.ImportRow(asig_realizadas.Rows[i - 1]);
					}
					array_validado.ImportRow(asig_realizadas.Rows[i]);
					array_validado.ImportRow(asig_realizadas.Rows[i + 1]);
					array_validado.ImportRow(asig_realizadas.Rows[i + 2]);
					break;
				}
			}
		}
		return array_validado;
	}
	private DataTable armarAsginacionesReglamentaria(DataRowCollection asig_realizadas = null)
	{
		asignacion = new cls_mp_asignacion();

		DataTable lista_mes_dias = new DataTable();
		lista_mes_dias.Columns.Add("fecha_inicio");
		lista_mes_dias.Columns.Add("fecha_fin");
		lista_mes_dias.Columns.Add("mes");
		lista_mes_dias.Columns.Add("anio");
		lista_mes_dias.Columns.Add("mes_anio");
		lista_mes_dias.Columns.Add("desc_mes_anio");
		lista_mes_dias.Columns.Add("tiempo");
		DataRow dr = null;

		for (int i = 0; i < asig_realizadas.Count; i++)
		{
			var asig = asig_realizadas[i];
			string fecha_inicio = validarCampo(asig["as_fecha_inicio"]);
			string fecha_fin = validarCampo(asig["as_fecha_fin"]);

			DateTime dateStart = Convert.ToDateTime("01/01/2021");// Convert.ToDateTime(fecha_inicio);
			DateTime dateEnd = Convert.ToDateTime("31/03/2021");// Convert.ToDateTime(fecha_fin);

			for (var month = dateEnd.Date; month >= dateStart; month = month.AddMonths(-1))
			{
				var startDate = new DateTime(month.Year, month.Month, 1);
				var endDate = startDate.AddMonths(1).AddDays(-1);


				var startDate_proc = (dateStart.Month == startDate.Month) ? (dateStart == startDate) ? startDate : dateStart : startDate;
				var endDate_proc = (dateEnd.Month == endDate.Month) ? (dateEnd == endDate) ? endDate : dateEnd : endDate;

				asignacion.as_fecha_inicio = startDate_proc;
				asignacion.as_fecha_fin = endDate_proc;
				var detalle_tiempo = asignacion.ObtenerTiempo();
				int tiempo = Convert.ToInt32(validarCampo(detalle_tiempo.Tables[0].Rows[0]["tiempo"]));

				dr = lista_mes_dias.NewRow();
				dr["fecha_inicio"] = startDate_proc.ToString("dd/MM/yyyy");
				dr["fecha_fin"] = endDate_proc.ToString("dd/MM/yyyy");
				dr["mes"] = month.ToString("MM");
				dr["anio"] = month.ToString("yyyy");
				dr["mes_anio"] = month.ToString("MM") + "-" + month.ToString("yyyy");
				dr["desc_mes_anio"] = month.ToString("MMMM").ToUpper() + " " + month.ToString("yyyy");
				dr["tiempo"] = tiempo;
				lista_mes_dias.Rows.Add(dr);
			}
		}

		return lista_mes_dias;
	}


	//private DataTable armarAsginacionesReglamentaria(DataRowCollection asig_realizadas = null, int dias_x = 0)
	//{
	//    asignacion = new cls_mp_asignacion();

	//    DataTable lista_asignaciones_reg = new DataTable();
	//    lista_asignaciones_reg.Columns.Add("as_fecha_inicio");
	//    lista_asignaciones_reg.Columns.Add("as_fecha_fin");
	//    lista_asignaciones_reg.Columns.Add("tiempo");
	//    DataRow dr = null;

	//    int tiempo = 0;
	//    int cont = 0;
	//    int dias_reglamentarios = 0;
	//    for (int i = 0; i < asig_realizadas.Count; i++)
	//    {
	//        var asig = asig_realizadas[i];
	//        string fecha_inicio = validarCampo(asig["as_fecha_inicio"]);
	//        string fecha_fin = validarCampo(asig["as_fecha_fin"]);

	//        DateTime dateStart = Convert.ToDateTime(fecha_inicio);
	//        DateTime dateEnd = Convert.ToDateTime(fecha_fin);

	//        for (var day = dateEnd.Date; day >= dateStart; day = day.AddDays(-1))
	//        {
	//            cont = cont + 1;

	//            if (cont >= dias_x)
	//            {
	//                asignacion.as_fecha_inicio = day;
	//                asignacion.as_fecha_fin = dateEnd;
	//                var detalle_tiempo = asignacion.ObtenerTiempo();

	//                tiempo = 0;
	//                tiempo = Convert.ToInt32(validarCampo(detalle_tiempo.Tables[0].Rows[0]["tiempo"]));
	//                tiempo = dias_reglamentarios + tiempo;

	//                if (tiempo == dias_x)
	//                {
	//                    dr = lista_asignaciones_reg.NewRow();
	//                    dr["as_fecha_inicio"] = day.ToString("dd/MM/yyyy");
	//                    dr["as_fecha_fin"] = dateEnd.ToString("dd/MM/yyyy");
	//                    dr["tiempo"] = Convert.ToInt32(validarCampo(detalle_tiempo.Tables[0].Rows[0]["tiempo"]));
	//                    lista_asignaciones_reg.Rows.Add(dr);
	//                    break;
	//                }
	//            }
	//            else
	//            {
	//                if (day == dateStart)
	//                {
	//                    asignacion.as_fecha_inicio = day;
	//                    asignacion.as_fecha_fin = dateEnd;
	//                    var detalle_tiempo = asignacion.ObtenerTiempo();
	//                    dias_reglamentarios = dias_reglamentarios + Convert.ToInt32(validarCampo(detalle_tiempo.Tables[0].Rows[0]["tiempo"]));

	//                    dr = lista_asignaciones_reg.NewRow();
	//                    dr["as_fecha_inicio"] = day.ToString("dd/MM/yyyy");
	//                    dr["as_fecha_fin"] = dateEnd.ToString("dd/MM/yyyy");
	//                    dr["tiempo"] = dias_reglamentarios;
	//                    lista_asignaciones_reg.Rows.Add(dr);
	//                    cont = dias_reglamentarios;
	//                }
	//            }
	//        }
	//        if (tiempo == dias_x)
	//        {
	//            break;
	//        }

	//    }

	//    return lista_asignaciones_reg;
	//}
	//private void obtenerTiempoServicio(int per_id = 0)
	//{
	//	asignacion = new cls_mp_asignacion();
	//	asignacion.as_per_id = per_id;
	//	var detalle_tiempo = asignacion.ObtenerTiempoFuncionario();

	//	if (detalle_tiempo.Tables[0].Rows.Count > 0)
	//	{
	//		//int dias = Convert.ToInt32(validarCampo(detalle_tiempo.Tables[0].Rows[0]["total_dias"]));
	//		int dias = 90;// Convert.ToInt32(hf_total_dias.Value);
	//		decimal total_dias_dec = Convert.ToDecimal(dias);

	//		//int anios = ((dias / 30) / 12);

	//		decimal meses = (total_dias_dec / 30);
	//		int anio_funcionario = (int)(meses / 12);
	//		decimal meses_aux = (meses % 12);
	//		decimal meses_aux1 = meses_aux * 30;
	//		int mes_funcionario = (int)(meses_aux1 / 30);
	//		int dias_funcionario = (int)(meses_aux1 % 30);

	//		ltl_anios.Text = anio_funcionario + "";
	//		ltl_meses.Text = mes_funcionario + "";
	//		ltl_dias.Text = dias_funcionario + "";
	//		//decimal meses_dec = Convert.ToDecimal((dias / 30) % 12);


	//		//int anios_aux = ((dias % 30) % 12);
	//	}
	//}
	private string validarCampo(object p_campo)
	{
		string campo = "";

		if (p_campo != DBNull.Value && p_campo.ToString().Trim() != "")
		{
			campo = p_campo.ToString().Trim();
		}
		return campo;
	}

	protected void gv_asignaciones_RowCommand(object sender, GridViewCommandEventArgs e)
	{

	}

    //protected void gv_asignaciones_PreRender(object sender, EventArgs e)
    //{
    //	base.OnPreRender(e);
    //	if (gv_asignaciones.Rows.Count > 0)
    //	{
    //		if (gv_asignaciones.HeaderRow != null)
    //		{
    //			gv_asignaciones.HeaderRow.TableSection = TableRowSection.TableHeader;
    //		}
    //		if (gv_asignaciones.FooterRow != null)
    //		{
    //			gv_asignaciones.FooterRow.TableSection = TableRowSection.TableFooter;
    //		}
    //	}
    //}




    protected void btnCalcular1_Click(object sender, EventArgs e)
    {
		SumatoriaRemuneraciones();
		cls_kd_finiquito2 finiquito = new cls_kd_finiquito2();
		DataSet ds = finiquito.PromedioRemuneracion(Convert.ToDouble(lblTotal1.Text), Convert.ToDouble(lblTotal2.Text), Convert.ToDouble(lblTotal3.Text), Convert.ToInt32(ltl_anios.Text), Convert.ToInt32(ltl_meses.Text), Convert.ToInt32(ltl_dias.Text));
		
		if (ds.Tables[0].Rows.Count>0)
			lblPromedioCotizable.Text = ds.Tables[0].Rows[0]["promedio_cotizable"].ToString();
		lblTiempoAnio.Text = ltl_anios.Text + " AÑOS";
		lblTiempoMes.Text = ltl_meses.Text + " MESES";
		lblTiempoDias.Text = ltl_dias.Text + " DÍAS";

		lblTiempoAnioMonto.Text= ds.Tables[0].Rows[0]["total_a"].ToString();
		lblTiempoMesMonto.Text = ds.Tables[0].Rows[0]["total_m"].ToString();
		lblTiempoDiasMonto.Text = ds.Tables[0].Rows[0]["total_d"].ToString();

		string rem1 = txtRem1.Text;
		string rem2 = txtRem2.Text;
		string rem3 = txtRem3.Text;
		if (txtRem1.Text == "") rem1 = "0";
		if (txtRem2.Text == "") rem2 = "0";
		if (txtRem3.Text == "") rem3 = "0";

		string ba1 = txtBa1.Text;
		string ba2 = txtBa2.Text;
		string ba3 = txtBa3.Text;
		if (txtBa1.Text == "") ba1 = "0";
		if (txtBa2.Text == "") ba2 = "0";
		if (txtBa3.Text == "") ba3 = "0";

		string bf1 = txtBf1.Text;
		string bf2 = txtBf2.Text;
		string bf3 = txtBf3.Text;
		if (txtBf1.Text == "") bf1 = "0";
		if (txtBf2.Text == "") bf2 = "0";
		if (txtBf3.Text == "") bf3 = "0";
		finiquito.ActualizarTotalesRemuneracionFiniquito(Convert.ToDouble(lblTotal1.Text), Convert.ToDouble(lblTotal2.Text), Convert.ToDouble(lblTotal3.Text), Convert.ToInt32(HttpContext.Current.Session["Fi_id"].ToString()), Convert.ToDouble(ba1), Convert.ToDouble(ba2), Convert.ToDouble(ba3), Convert.ToDouble(bf1), Convert.ToDouble(bf1), Convert.ToDouble(bf1));
		CalcularVacaciones();
		CalcularAguinaldo();
	}
	private void SumatoriaRemuneraciones()
	{
		string rem1 = txtRem1.Text;
		string rem2 = txtRem2.Text;
		string rem3 = txtRem3.Text;
		if (txtRem1.Text == "") rem1 = "0";
		if (txtRem2.Text == "") rem2 = "0";
		if (txtRem3.Text == "") rem3 = "0";

		string ba1 = txtBa1.Text;
		string ba2 = txtBa2.Text;
		string ba3 = txtBa3.Text;
		if (txtBa1.Text == "") ba1 = "0";
		if (txtBa2.Text == "") ba2 = "0";
		if (txtBa3.Text == "") ba3 = "0";

		string bf1 = txtBf1.Text;
		string bf2 = txtBf2.Text;
		string bf3 = txtBf3.Text;
		if (txtBf1.Text == "") bf1 = "0";
		if (txtBf2.Text == "") bf2 = "0";
		if (txtBf3.Text == "") bf3 = "0";

		lblRemTotal.Text = (Convert.ToDouble(rem1) + Convert.ToDouble(rem2) + Convert.ToDouble(rem3)).ToString();
		lblBaTotal.Text = (Convert.ToDouble(ba1) + Convert.ToDouble(ba2) + Convert.ToDouble(ba3)).ToString();
		lblBfTotal.Text = (Convert.ToDouble(bf1) + Convert.ToDouble(bf2) + Convert.ToDouble(bf3)).ToString();

		lblTotal1.Text = (Convert.ToDouble(rem1) + Convert.ToDouble(ba1) + Convert.ToDouble(bf1)).ToString();
		lblTotal2.Text = (Convert.ToDouble(rem2) + Convert.ToDouble(ba2) + Convert.ToDouble(bf2)).ToString();
		lblTotal3.Text = (Convert.ToDouble(rem3) + Convert.ToDouble(ba3) + Convert.ToDouble(bf3)).ToString();

		lblTotalGeneral.Text = (Convert.ToDouble(lblTotal1.Text) + Convert.ToDouble(lblTotal2.Text) + Convert.ToDouble(lblTotal3.Text)).ToString();

	}
	protected void btnActualizar_Click(object sender, EventArgs e)
    {
		cls_kd_finiquito2 finiquito = new cls_kd_finiquito2();
		if (txtFechaIngreso.Text != "")
		{

			ltl_anios.Text = finiquito.TiempoServicio(txtFechaIngreso.Text, "anio");
			ltl_meses.Text = finiquito.TiempoServicio(txtFechaIngreso.Text, "mes");
			ltl_dias.Text = finiquito.TiempoServicio(txtFechaIngreso.Text, "dia");

			ltl_fecha_ingreso.Visible = false;
			txtFechaIngreso.Visible = true;
			finiquito.Fi_per_id = Convert.ToInt32(Convert.ToInt32(Request.QueryString["id"].ToString()));
			finiquito.Fi_as_id = Convert.ToInt32(Convert.ToInt32(Request.QueryString["id2"].ToString()));
			finiquito.Fi_FechaIngerso = Convert.ToDateTime(txtFechaIngreso.Text);
			finiquito.Fi_anioServicio = Convert.ToInt32(ltl_anios.Text);
			finiquito.Fi_MesServicio = Convert.ToInt32(ltl_meses.Text);
			finiquito.Fi_DiasServicio = Convert.ToInt32(ltl_dias.Text);
			finiquito.Fi_estado = "P";
			finiquito.Fi_FechaRetiro= Convert.ToDateTime(ltl_fecha_retiro.Text);
			finiquito.Fi_MotivoFiniquito = ltl_motivo_retiro.Text;
			finiquito.Fi_usuario = Convert.ToInt32(Request.QueryString["id"].ToString());

			cls_kd_finiquito2 FQ = new cls_kd_finiquito2();
			asignacion = new cls_mp_asignacion();
			asignacion.as_per_id = finiquito.Fi_per_id;
			asignacion.as_id = finiquito.Fi_as_id;
			var detalleFuncionario = asignacion.ObtenerInformacionFiniquito();
			Session["Fi_id"]= finiquito.Adicionar_FechaIngreso();

		}
	}

    protected void btnHabilitarDesahucio_Click(object sender, EventArgs e)
    {
		if (ltl_meses.Text != "" && ltl_dias.Text != "" && HttpContext.Current.Session["Fi_id"] != null)
		{
			if (HttpContext.Current.Session["Fi_id"].ToString() != "")
			{

				cls_kd_finiquito2 finiquito = new cls_kd_finiquito2();
				txtDesahucio.Text = finiquito.CalcularDesahucio(Convert.ToInt32(HttpContext.Current.Session["Fi_id"].ToString())).ToString();
				txtDesahucio.Visible = true;
				btnHabilitarDesahucio.Visible = false;
			}
		}
    }
	private void CalcularVacaciones()
	{
		if (ltl_meses.Text != "" && ltl_dias.Text != "" && HttpContext.Current.Session["Fi_id"] != null)
			{
			if (HttpContext.Current.Session["Fi_id"].ToString() != "")
			{
				cls_kd_finiquito2 finiquito = new cls_kd_finiquito2();
				txtTotalVacacionesMonto.Text = finiquito.CalcularVacacionesMonto(Convert.ToInt32(HttpContext.Current.Session["Fi_id"].ToString()), Convert.ToInt32(ltl_meses.Text), Convert.ToInt32(ltl_dias.Text), Convert.ToInt32(Request.QueryString["id"].ToString())).ToString();
				txtTotalVacacionesDias.Text = finiquito.CalcularVacacionesDias(Convert.ToInt32(HttpContext.Current.Session["Fi_id"].ToString()), Convert.ToInt32(ltl_meses.Text), Convert.ToInt32(ltl_dias.Text), Convert.ToInt32(Request.QueryString["id"].ToString())).ToString() + " días";
			}
		}
	}
	private void CalcularAguinaldo() {
        if (ltl_fecha_retiro.Text != "" && HttpContext.Current.Session["Fi_id"] != null)
        {
            if (HttpContext.Current.Session["Fi_id"].ToString() != "")
            {

                cls_kd_finiquito2 finiquito = new cls_kd_finiquito2();
                txtTotalAguinaldo.Text = finiquito.CalcularAguinaldo(Convert.ToInt32(HttpContext.Current.Session["Fi_id"].ToString()), ltl_fecha_retiro.Text).ToString();
            }
        }
    }


    protected void btnCalcularBeneficiosSociales_Click(object sender, EventArgs e)
    {
		if (txtDesahucio.Text == "") txtDesahucio.Text = "0";
		if (lblTiempoAnioMonto.Text == "") lblTiempoAnioMonto.Text = "0";
		if (lblTiempoMesMonto.Text == "") lblTiempoMesMonto.Text = "0";
		if (lblTiempoDiasMonto.Text == "") lblTiempoDiasMonto.Text = "0";
		if (txtTotalVacacionesMonto.Text == "") txtTotalVacacionesMonto.Text = "0";
		if (txtTotalAguinaldo.Text == "") txtTotalAguinaldo.Text = "0";

		if (txtDeduccion1Monto.Text == "") txtDeduccion1Monto.Text = "0";
		if (txtDeduccion2Monto.Text == "") txtDeduccion2Monto.Text = "0";

		if (txtIndemnExtra1Monto.Text == "") txtIndemnExtra1Monto.Text = "0";
		if (txtIndemnExtra2Mont.Text == "") txtIndemnExtra2Mont.Text = "0";
		if (txtIndemnExtra3Mont.Text == "") txtIndemnExtra3Mont.Text = "0";

		txtTotalBeneficios.Text = (Convert.ToDouble(txtDesahucio.Text) + Convert.ToDouble(lblTiempoAnioMonto.Text) + Convert.ToDouble(lblTiempoMesMonto.Text) + Convert.ToDouble(lblTiempoDiasMonto.Text) + Convert.ToDouble(txtTotalVacacionesMonto.Text) + Convert.ToDouble(txtTotalAguinaldo.Text) + Convert.ToDouble(txtIndemnExtra1Monto.Text) + Convert.ToDouble(txtIndemnExtra2Mont.Text)+ Convert.ToDouble(txtIndemnExtra3Mont.Text)).ToString();
		txtDeduccionesTotal.Text = (Convert.ToDouble(txtDeduccion1Monto.Text) + Convert.ToDouble(txtDeduccion2Monto.Text)).ToString();

		if (txtTotalBeneficios.Text == "") txtTotalBeneficios.Text = "0";
		if (txtDeduccionesTotal.Text == "") txtDeduccionesTotal.Text = "0";
		txtLiquidoPagable.Text = (Convert.ToDouble(txtTotalBeneficios.Text) - Convert.ToDouble(txtDeduccionesTotal.Text)).ToString();
    }

    protected void btnFinalizar_Click(object sender, EventArgs e)
    {
		if(txtLiquidoPagable.Text!="" && txtFechaPago.Text!="" && (txtHR.Text!="" || txtInformeLegal.Text!=""))
        {
			cls_kd_finiquito2 finiquito = new cls_kd_finiquito2();
			finiquito.ActualizarTotalesRemuneracionFiniquito(Convert.ToDouble(lblTotal1.Text), Convert.ToDouble(lblTotal2.Text), Convert.ToDouble(lblTotal3.Text), Convert.ToInt32(HttpContext.Current.Session["Fi_id"].ToString()), Convert.ToDouble(txtBa1.Text), Convert.ToDouble(txtBa2.Text), Convert.ToDouble(txtBa3.Text), Convert.ToDouble(txtBf1.Text), Convert.ToDouble(txtBf2.Text), Convert.ToDouble(txtBf3.Text));
			if (HttpContext.Current.Session["Fi_id"].ToString() != "")
			{

				if (finiquito.ActualizarInfoAdicional(Convert.ToInt32(HttpContext.Current.Session["Fi_id"].ToString()), 0, 0, ltl_motivo_retiro.Text, Convert.ToDouble(txtLiquidoPagable.Text), (txtHR.Text + " / " + txtInformeLegal.Text), txtFechaPago.Text, "V") > 0)
				{
					Session["FiniquitoFinalizado"] = true;
					sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Se finalizó correctamente el finiquito' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });";
					btnImprimir.Visible = true;
					DivFiniquito.Visible = false;
					btnActualizar.Visible = false;
				}
				else
					sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se puede finalizar el finiquito, consulte al administrador del sistema' }, { type: 'danger', placement: { from: 'bottom', align: 'right'} });";
			}
		}
		else
			sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se puede finalizar el finiquito porque no existe monto a pagar o fecha de pago o Documento que autoriza' }, { type: 'danger', placement: { from: 'bottom', align: 'right'} });";
		SetScript(sc, "");
	}

    protected void btnImprimir_Click(object sender, EventArgs e)
    {
		sc = "window.open('ImprimirFiniquito.aspx', 'width=300,height=300', '_blank');";
		SetScript(sc, "");

	}
}
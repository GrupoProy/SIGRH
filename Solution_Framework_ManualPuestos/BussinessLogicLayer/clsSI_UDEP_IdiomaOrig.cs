using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_ManualPuestos.DataAccessLayer;

namespace Solution_Framework_ManualPuestos.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de SI_UDEP_IdiomaOrig.
	/// </summary>
	public class clsSI_UDEP_IdiomaOrig
	{
		#region ATRIBUTOS
		private int _id;
		private int _Cod_fun;
		private bool _P1_1;
		private bool _P1_2;
		private bool _P1_3;
		private bool _P1_4;
		private bool _P1_5;
		private bool _P1_6;
		private bool _P1_7;
		private bool _P1_8;
		private bool _P1_9;
		private bool _P1_10;
		private bool _P1_11;
		private bool _P1_12;
		private string _P2;
		private bool _P3;
		private string _P3_1;
		private int _P3_2;
		private bool _P4;
		private string _P4_1;
		private int _P4_2;
		private bool _P5;
		private string _P5_1;
		private string _P6_1_Cual_Idioma;
		private string _P6_1_Donde;
		private bool _P6_2;

		#endregion

		#region CONSTRUCTOR
		public clsSI_UDEP_IdiomaOrig()
		{}

		public clsSI_UDEP_IdiomaOrig(int id, 
				int Cod_fun, 
				bool P1_1, 
				bool P1_2, 
				bool P1_3, 
				bool P1_4, 
				bool P1_5, 
				bool P1_6, 
				bool P1_7, 
				bool P1_8, 
				bool P1_9, 
				bool P1_10, 
				bool P1_11, 
				bool P1_12, 
				string P2, 
				bool P3, 
				string P3_1, 
				int P3_2, 
				bool P4, 
				string P4_1, 
				int P4_2, 
				bool P5, 
				string P5_1, 
				string P6_1_Cual_Idioma, 
				string P6_1_Donde, 
				bool P6_2)
		{
			_id = id;
			_Cod_fun = Cod_fun;
			_P1_1 = P1_1;
			_P1_2 = P1_2;
			_P1_3 = P1_3;
			_P1_4 = P1_4;
			_P1_5 = P1_5;
			_P1_6 = P1_6;
			_P1_7 = P1_7;
			_P1_8 = P1_8;
			_P1_9 = P1_9;
			_P1_10 = P1_10;
			_P1_11 = P1_11;
			_P1_12 = P1_12;
			_P2 = P2;
			_P3 = P3;
			_P3_1 = P3_1;
			_P3_2 = P3_2;
			_P4 = P4;
			_P4_1 = P4_1;
			_P4_2 = P4_2;
			_P5 = P5;
			_P5_1 = P5_1;
			_P6_1_Cual_Idioma = P6_1_Cual_Idioma;
			_P6_1_Donde = P6_1_Donde;
			_P6_2 = P6_2;
		}
		#endregion

		#region PROPIEDADES
		public int id
		{
			get { return _id; }
			set { _id = value; }
		}
		public int Cod_fun
		{
			get { return _Cod_fun; }
			set { _Cod_fun = value; }
		}
		public bool P1_1
		{
			get { return _P1_1; }
			set { _P1_1 = value; }
		}
		public bool P1_2
		{
			get { return _P1_2; }
			set { _P1_2 = value; }
		}
		public bool P1_3
		{
			get { return _P1_3; }
			set { _P1_3 = value; }
		}
		public bool P1_4
		{
			get { return _P1_4; }
			set { _P1_4 = value; }
		}
		public bool P1_5
		{
			get { return _P1_5; }
			set { _P1_5 = value; }
		}
		public bool P1_6
		{
			get { return _P1_6; }
			set { _P1_6 = value; }
		}
		public bool P1_7
		{
			get { return _P1_7; }
			set { _P1_7 = value; }
		}
		public bool P1_8
		{
			get { return _P1_8; }
			set { _P1_8 = value; }
		}
		public bool P1_9
		{
			get { return _P1_9; }
			set { _P1_9 = value; }
		}
		public bool P1_10
		{
			get { return _P1_10; }
			set { _P1_10 = value; }
		}
		public bool P1_11
		{
			get { return _P1_11; }
			set { _P1_11 = value; }
		}
		public bool P1_12
		{
			get { return _P1_12; }
			set { _P1_12 = value; }
		}
		public string P2
		{
			get { return _P2; }
			set { _P2 = value; }
		}
		public bool P3
		{
			get { return _P3; }
			set { _P3 = value; }
		}
		public string P3_1
		{
			get { return _P3_1; }
			set { _P3_1 = value; }
		}
		public int P3_2
		{
			get { return _P3_2; }
			set { _P3_2 = value; }
		}
		public bool P4
		{
			get { return _P4; }
			set { _P4 = value; }
		}
		public string P4_1
		{
			get { return _P4_1; }
			set { _P4_1 = value; }
		}
		public int P4_2
		{
			get { return _P4_2; }
			set { _P4_2 = value; }
		}
		public bool P5
		{
			get { return _P5; }
			set { _P5 = value; }
		}
		public string P5_1
		{
			get { return _P5_1; }
			set { _P5_1 = value; }
		}
		public string P6_1_Cual_Idioma
		{
			get { return _P6_1_Cual_Idioma; }
			set { _P6_1_Cual_Idioma = value; }
		}
		public string P6_1_Donde
		{
			get { return _P6_1_Donde; }
			set { _P6_1_Donde = value; }
		}
		public bool P6_2
		{
			get { return _P6_2; }
			set { _P6_2 = value; }
		}

		#endregion

		#region METODOS
		/// <summary>
		/// Método que adiciona una nuevo registro en SI_UDEP_IdiomaOrig
		/// </summary>
		public bool Adicionar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Adicionar_SI_UDEP_IdiomaOrig(this);
		}

		/// <summary>
		/// Método que actualiza datos en la tabla SI_UDEP_IdiomaOrig
		/// </summary>
		public bool Actualizar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Actualizar_SI_UDEP_IdiomaOrig(this);
		}

		/// <summary>
		/// Método que elimina datos en la tabla SI_UDEP_IdiomaOrig
		/// </summary>
		public bool Eliminar()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.Eliminar_SI_UDEP_IdiomaOrig(this);
		}

		/// <summary>
		/// Método que obtiene ID para registros de SI_UDEP_IdiomaOrig
		/// </summary>
		public bool ObtenerId()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerId_SI_UDEP_IdiomaOrig(this);
		}

		/// <summary>
		/// Método que obtiene un registro de SI_UDEP_IdiomaOrig
		/// </summary>
		/// <param name="id">
		/// Clave primaria de la tabla SI_UDEP_IdiomaOrig
		/// </param>

		public bool ObtenerRegistro(int id)
		{
			_id = id;

			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerRegistro_SI_UDEP_IdiomaOrig(this);
		}

		/// <summary>
		/// Método que obtiene la tabla SI_UDEP_IdiomaOrig para llenar una grilla
		/// </summary>
		/// <param name="id">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="Cod_fun">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="P1_1">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="P1_2">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="P1_3">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="P1_4">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="P1_5">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="P1_6">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="P1_7">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="P1_8">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="P1_9">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="P1_10">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="P1_11">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="P1_12">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="P2">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="P3">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="P3_1">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="P3_2">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="P4">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="P4_1">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="P4_2">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="P5">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="P5_1">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="P6_1_Cual_Idioma">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="P6_1_Donde">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>
		/// <param name="P6_2">
		/// (Campo opcional) Introducir espacio vacio
		/// </param>

		public DataSet ObtenerTablaGrilla(string id, 
						string Cod_fun, 
						string P1_1, 
						string P1_2, 
						string P1_3, 
						string P1_4, 
						string P1_5, 
						string P1_6, 
						string P1_7, 
						string P1_8, 
						string P1_9, 
						string P1_10, 
						string P1_11, 
						string P1_12, 
						string P2, 
						string P3, 
						string P3_1, 
						string P3_2, 
						string P4, 
						string P4_1, 
						string P4_2, 
						string P5, 
						string P5_1, 
						string P6_1_Cual_Idioma, 
						string P6_1_Donde, 
						string P6_2)
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaGrilla_SI_UDEP_IdiomaOrig(id, Cod_fun, P1_1, P1_2, P1_3, P1_4, P1_5, P1_6, P1_7, P1_8, P1_9, P1_10, P1_11, P1_12, P2, P3, P3_1, P3_2, P4, P4_1, P4_2, P5, P5_1, P6_1_Cual_Idioma, P6_1_Donde, P6_2);
		}

		/// <summary>
		/// Método que obtiene la tabla SI_UDEP_IdiomaOrig para llenar un combo
		/// </summary>
		public DataSet ObtenerTablaCombo()
		{
			DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
			return DBLayer.ObtenerTablaCombo_SI_UDEP_IdiomaOrig();
		}
		#endregion
	}
}

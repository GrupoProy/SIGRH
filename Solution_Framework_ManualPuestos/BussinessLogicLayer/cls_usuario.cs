using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Solution_Framework_ManualPuestos.DataAccessLayer;

namespace Solution_Framework_ManualPuestos.BussinessLogicLayer
{
	/// <summary>
	/// Proporciona funcionalidad para manejo de tbl_seg_usuario.
	/// </summary>
	public class cls_seg_usuario
	{
		#region PROPIEDADES
		public int us_id { get; set; }
		public string us_usuario { get; set; }
        public string us_clave { get; set; }
        public int us_per_id { get; set; }
        public bool us_estado_clave { get; set; }
        public bool us_estado_sesion { get; set; }
        public string us_correo_interno { get; set; }
        public string us_nom_equipo { get; set; }
        public DateTime us_fecha_creacion { get; set; }
        public DateTime us_fecha_inicio { get; set; }
        public DateTime us_fecha_fin { get; set; }
        public int us_id_rol_sim { get; set; }
        public int us_id_usuario_sim { get; set; }
        public string us_estado { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que adiciona una nuevo registro en tbl_seg_usuario
        /// </summary>
  //      public bool Adicionar()
		//{
		//	DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
		//	return DBLayer.Adicionar__seg_usuario(this);
		//}
		#endregion
	}
}

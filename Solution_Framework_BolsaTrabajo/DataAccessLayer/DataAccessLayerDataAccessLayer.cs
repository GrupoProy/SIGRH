using Microsoft.Practices.EnterpriseLibrary.Data;
using Solution_Framework_BolsaTrabajo.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
 
using System.Text;
using System.Threading.Tasks;

namespace Solution_Framework_BolsaTrabajo.DataAccessLayer
{
    public abstract class DataAccessLayerDataAccessLayer
    {
        #region INSTANCIA PRINCIPAL DE CONEXION A UNA BD
        public Database CNXBOLSA = DatabaseFactory.CreateDatabase("CnxBolsa");

        #endregion

        #region _BT_POSTULANTE
        public abstract bool Adicionar__bt_postulante(cls_bt_postulante _bt_postulante);
        public abstract bool Actualizar__bt_postulante(cls_bt_postulante _bt_postulante);
        public abstract bool Eliminar__bt_postulante(cls_bt_postulante _bt_postulante);
        public abstract bool ObtenerId__bt_postulante(cls_bt_postulante _bt_postulante);
        public abstract DataSet ObtenerRegistros__bt_postulante(cls_bt_postulante _bt_postulante);
        public abstract DataSet ObtenerTablaGrilla__bt_postulante(
            string po_id,
            string po_primer_nombre,
            string po_segundo_nombre,
            string po_paterno,
            string po_materno,
            string po_ap_casada,
            string po_correo,
            string po_tipo_doc,
            string po_num_doc,
            string po_lugar_exp,
            string po_estado_civil,
            string po_fecha_nacimiento,
            string po_lugar_nacimiento,
            string po_nacionalidad,
            string po_sexo,
            string po_zona,
            string po_tipo_via,
            string po_descripcion_via,
            string po_numero,
            string po_telefono,
            string po_celular,
            string po_ciudad_residencia,
            string po_num_libreta_militar,
            string po_estado,
            string po_codigo_fun,
            string po_nro_libro);
        public abstract DataSet ObtenerTablaCombo__bt_postulante();
        #endregion
    }
}

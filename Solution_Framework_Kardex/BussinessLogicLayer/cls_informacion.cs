using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_Framework_Kardex.BussinessLogicLayer
{
    public class cls_informacion
    {
        public DataSet Cargos()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Cargos();
        }

        public DataSet Informacion(int es_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Informacion(es_id);
        }
        public DataSet UltimoCargo(int as_id, int per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.UltimoCargo(as_id, per_id);
        }
        public DataSet GrillaInformacionFunc(
string per_id,
string per_tipo_doc,
string per_num_doc,
string per_lugar_exp,
string per_ap_paterno,
string per_ap_materno,
string per_nombres,
string per_ap_casada,
string per_sexo,
string per_fecha_nac,
string per_procedencia,
string per_serie_libreta_militar,
string per_lugar_nac,
string per_estado_civil)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.GrillaInformacionFunc(per_id, per_tipo_doc, per_num_doc, per_lugar_exp, per_ap_paterno, per_ap_materno, per_nombres, per_ap_casada, per_sexo, per_fecha_nac, per_procedencia, per_serie_libreta_militar, per_lugar_nac, per_estado_civil);
        }
    }
}

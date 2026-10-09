using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_Framework_BienestarSocial.BussinessLogicLayer
{
    public class Subsidio
    {
        public string ap_paterno { get; set; }
        public string ap_materno { get; set; }
        public string ap_esposo { get; set; }
        public string pf_nombre { get; set; }
        public string pf_ci { get; set; }
        public string pf_sexo { get; set; }
        public string fecha_nac { get; set; }
        public int tipo_parentesco { get; set; }
        public int pf_id { get; set; }
        public int per_id { get; set; }

        public DataSet BuscarAfiliacionEGS(string per_id, string per_num_doc, string per_ap_paterno, string per_ap_materno, string per_nombres, string per_ap_casada)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.BuscarAfiliacionEGS(per_id, per_num_doc, per_ap_paterno, per_ap_materno, per_nombres, per_ap_casada);
        }
        public bool EditarDatosFamiliar()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EditarDatosFamiliar(this);
        }

        public DataSet ObtenerDatosPersona(int per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDatosPersona(per_id);
        }
        public DataSet ObtenerDatosBeneficiario(int per_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDatosBeneficiario(per_id);
        }
        public int VerificarAfiliacionFamiliar(int pf_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.VerificarAfiliacionFamiliar(pf_id);
        }
    }
}

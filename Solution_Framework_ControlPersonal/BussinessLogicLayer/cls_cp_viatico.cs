using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_Framework_ControlPersonal.BussinessLogicLayer
{
    public class cls_cp_viatico
    {
        public DataSet BuscarFuncionario(string ci)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.BuscarFuncionario(ci);
        }
        public DataSet cargarDestino()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.cargarDestino();
        }

        public DataSet cargarCategoria(string destino)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.cargarCategoria(destino);
        }
        public bool LlenarGridViatico(int per_id, int ev_id, string tipo_cambio, string fecha1, string fecha2, int as_id, string monto_curso, string objeto, string dias)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.LlenarGridViatico(per_id, ev_id, tipo_cambio, fecha1, fecha2, as_id, monto_curso, objeto, dias);
        }

        public DataSet LlenarGridPlanillaViatico()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.LlenarGridPlanillaViatico();
        }
        public bool Eliminar(int ev_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.Eliminar(ev_id);
        }

        public bool ProcesarPlanillaViatico(int nro_planilla, int us_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ProcesarPlanillaViatico(nro_planilla, us_id);
        }
        public DataSet NroPlanillaCombo(int pr_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.NroPlanillaCombo(pr_id);
        }

        public DataSet LlenarListaViatico()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.LlenarListaViatico();
        }
        public DataSet CargarInfoPlanilla(int nro_pla)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.CargarInfoPlanilla(nro_pla);
        }

        public int ReprobarPlanilla(int nro_pla)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ReprobarPlanilla(nro_pla);
        }

        public DataSet cargarMeses()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.cargarMeses();
        }

        public DataSet LlenarViaticosMes(int mes)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.LlenarViaticosMes(mes);
        }
        public int ObtenerDiasViatico(string fecha1, string fecha2)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerDiasViatico(fecha1, fecha2);
        }
    }
}

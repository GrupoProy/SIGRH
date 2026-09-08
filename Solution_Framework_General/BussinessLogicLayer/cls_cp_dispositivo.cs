using Solution_Framework_General.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_Framework_ControlPersonal.BussinessLogicLayer
{
    public class cls_cp_dispositivo
    {
        public int AdicionarDispositivo(string descrip, string ip, int edificio)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.AdicionarDispositivo(descrip, ip, edificio);
        }
        public DataSet ListarDispositivos()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ListarDispositivos();
        }
        public int EliminarDispositivo(int di_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EliminarDispositivo(di_id);
        }
        public int EditarDispositivo(string descripcion, int edifi, string ip, int di_id)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.EditarDispositivo(descripcion, edifi, ip, di_id);
        }
        public DataSet MostrarEdificios()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.MostrarEdificios();
        }
    }
}
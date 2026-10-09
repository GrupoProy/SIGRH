using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_Framework_Salarios.BussinessLogicLayer
{
    public class cls_asistencia
    {
        public int x { get; set; }
        public DateTime date { get; set; }
        public DateTime tim { get; set; }
        public string gestion { get; set; }

        public bool GenerarAsistenciaIndiv__()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.GenerarAsistenciaIndiv(this);
        }

        public DataSet LlenarCombo__()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.LlenarCombo();
        }

        public DataSet CargarGestiones__()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.CargarGestiones(this);
        }
    }
}

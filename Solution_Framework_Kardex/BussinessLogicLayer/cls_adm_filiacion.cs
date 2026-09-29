using System;
using System.Data;

namespace Solution_Framework_Kardex.BussinessLogicLayer
{

    /// Clase de negocio para la administración de Declaraciones Juradas (módulo Admin).

    public class cls_adm_filiacion
    {
        public DataSet BuscarPersonasConDDJJ(string nombre, string apPaterno, string apMaterno,
                                              string ci, string perId)
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.BuscarPersonasConDDJJ(nombre, apPaterno, apMaterno, ci, perId);
        }

        public bool CambiarEstado(int dj_id, string nuevoEstado, int usuario_modificacion)
        {
            if (dj_id <= 0)
                throw new Exception("El ID de la declaración no es válido.");

            if (nuevoEstado != "V" && nuevoEstado != "F")
                throw new Exception("El estado debe ser 'V' (Vigente) o 'F' (Finalizada).");

            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.CambiarEstadoDeclaracionJurada(dj_id, nuevoEstado, usuario_modificacion);
        }

        /// Obtiene el resumen estadístico de Declaraciones Juradas.
 
        public DataSet ObtenerResumenDDJJ()
        {
            DataAccessLayerSQLDataAccessLayer DBLayer = new DataAccessLayerSQLDataAccessLayer();
            return DBLayer.ObtenerResumenDDJJ();
        }

    }
}
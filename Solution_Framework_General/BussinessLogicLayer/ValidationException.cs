using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_Framework_General.BussinessLogicLayer
{
    public class ValidationException : Exception
    {
        public string Campo { get; set; }

        public ValidationException(string mensaje)
            : base(mensaje)
        {
        }

        public ValidationException(string campo, string mensaje)
            : base(mensaje)
        {
            Campo = campo;
        }

        public ValidationException(string mensaje, Exception innerException)
            : base(mensaje, innerException)
        {
        }
    }
}

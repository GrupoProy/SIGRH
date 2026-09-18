using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Solution_Framework_General.BussinessLogicLayer
{

    /// Clase de utilidades para validaciones comunes en el sistema.
    /// Proporciona métodos estáticos reutilizables para validar
    /// campos como CI, fechas, emails, teléfonos, etc.
    
    public static class cls_validador
    {
        #region EXPRESIONES REGULARES (Precompiladas para mejor rendimiento)

        private static readonly Regex REGEX_SOLO_NUMEROS = new Regex(@"^\d+$", RegexOptions.Compiled);
        private static readonly Regex REGEX_SOLO_LETRAS = new Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", RegexOptions.Compiled);
        private static readonly Regex REGEX_EMAIL = new Regex(@"^[\w\-\.]+@([\w\-]+\.)+[\w\-]{2,4}$", RegexOptions.Compiled);
        private static readonly Regex REGEX_TELEFONO = new Regex(@"^\d{7,8}$", RegexOptions.Compiled);
        private static readonly Regex REGEX_CELULAR = new Regex(@"^\d{8}$", RegexOptions.Compiled);

        #endregion

        #region VALIDACIONES DE CAMPOS OBLIGATORIOS

        /// Valida que un campo no sea nulo, vacío o solo espacios.

        /// <param name="valor">Valor a validar</param>
        /// <param name="nombreCampo">Nombre del campo para el mensaje de error</param>
        /// <exception cref="ValidationException">Si el campo está vacío</exception>
        public static void ValidarObligatorio(string valor, string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ValidationException(nombreCampo, $"El campo '{nombreCampo}' es obligatorio.");
        }

        /// Valida que un objeto no sea nulo.

        public static void ValidarNoNulo(object valor, string nombreCampo)
        {
            if (valor == null)
                throw new ValidationException(nombreCampo, $"El campo '{nombreCampo}' no puede ser nulo.");
        }

        /// Valida que un entero sea mayor a 0.

        public static void ValidarMayorQueCero(int valor, string nombreCampo)
        {
            if (valor <= 0)
                throw new ValidationException(nombreCampo, $"Debe seleccionar un valor válido en '{nombreCampo}'.");
        }

        #endregion

        #region VALIDACIONES DE LONGITUD

        /// Valida la longitud máxima de un texto.

        public static void ValidarLongitudMaxima(string valor, int maximo, string nombreCampo)
        {
            if (!string.IsNullOrEmpty(valor) && valor.Length > maximo)
                throw new ValidationException(nombreCampo,
                    $"El campo '{nombreCampo}' no puede tener más de {maximo} caracteres.");
        }

 
        /// Valida la longitud mínima de un texto.

        public static void ValidarLongitudMinima(string valor, int minimo, string nombreCampo)
        {
            if (!string.IsNullOrEmpty(valor) && valor.Length < minimo)
                throw new ValidationException(nombreCampo,
                    $"El campo '{nombreCampo}' debe tener al menos {minimo} caracteres.");
        }


        /// Valida que un texto esté dentro de un rango de longitud.

        public static void ValidarLongitudRango(string valor, int minimo, int maximo, string nombreCampo)
        {
            if (string.IsNullOrEmpty(valor)) return;

            if (valor.Length < minimo || valor.Length > maximo)
                throw new ValidationException(nombreCampo,
                    $"El campo '{nombreCampo}' debe tener entre {minimo} y {maximo} caracteres.");
        }

        #endregion

        #region VALIDACIONES DE FORMATO


        /// Valida que un texto contenga SOLO dígitos numéricos.

        public static void ValidarSoloNumeros(string valor, string nombreCampo)
        {
            if (string.IsNullOrEmpty(valor)) return;

            if (!REGEX_SOLO_NUMEROS.IsMatch(valor))
                throw new ValidationException(nombreCampo,
                    $"El campo '{nombreCampo}' solo debe contener números.");
        }

  
        /// Valida que un texto contenga SOLO letras y espacios.

        public static void ValidarSoloLetras(string valor, string nombreCampo)
        {
            if (string.IsNullOrEmpty(valor)) return;

            if (!REGEX_SOLO_LETRAS.IsMatch(valor))
                throw new ValidationException(nombreCampo,
                    $"El campo '{nombreCampo}' solo debe contener letras.");
        }

        /// Valida el formato de un email.
 
        public static void ValidarEmail(string email, string nombreCampo = "Email")
        {
            if (string.IsNullOrEmpty(email)) return;

            if (!REGEX_EMAIL.IsMatch(email))
                throw new ValidationException(nombreCampo,
                    $"El campo '{nombreCampo}' no tiene un formato válido.");
        }


        /// Valida el formato de un teléfono (7 u 8 dígitos).
        public static void ValidarTelefono(string telefono, string nombreCampo = "Teléfono")
        {
            if (string.IsNullOrEmpty(telefono)) return;

            if (!REGEX_TELEFONO.IsMatch(telefono))
                throw new ValidationException(nombreCampo,
                    $"El campo '{nombreCampo}' debe tener 7 u 8 dígitos.");
        }

        /// Valida el formato de un celular (8 dígitos).
    
        public static void ValidarCelular(string celular, string nombreCampo = "Celular")
        {
            if (string.IsNullOrEmpty(celular)) return;

            if (!REGEX_CELULAR.IsMatch(celular))
                throw new ValidationException(nombreCampo,
                    $"El campo '{nombreCampo}' debe tener exactamente 8 dígitos.");
        }

        #endregion

        #region VALIDACIONES DE CI (CÉDULA DE IDENTIDAD)


        /// Valida un CI: solo números, longitud mínima y máxima.
   
        /// <param name="ci">Número de CI a validar</param>
        /// <param name="obligatorio">Si es obligatorio (default: false)</param>
        /// <param name="minLength">Longitud mínima (default: 5)</param>
        /// <param name="maxLength">Longitud máxima (default: 10)</param>
        public static void ValidarCI(string ci, bool obligatorio = false, int minLength = 5, int maxLength = 10)
        {
            // Si es obligatorio y viene vacío → error
            if (obligatorio && string.IsNullOrWhiteSpace(ci))
                throw new ValidationException("CI", "El campo 'CI' es obligatorio.");

            // Si es opcional y viene vacío → OK
            if (string.IsNullOrWhiteSpace(ci)) return;

            // Verificar que solo contenga dígitos
            if (!REGEX_SOLO_NUMEROS.IsMatch(ci))
                throw new ValidationException("CI",
                    "El campo 'CI' solo debe contener dígitos numéricos.");

            // Verificar longitud mínima
            if (ci.Length < minLength)
                throw new ValidationException("CI",
                    $"El campo 'CI' debe tener al menos {minLength} dígitos.");

            // Verificar longitud máxima
            if (ci.Length > maxLength)
                throw new ValidationException("CI",
                    $"El campo 'CI' no puede tener más de {maxLength} dígitos.");
        }

        #endregion

        #region VALIDACIONES DE FECHAS

        /// Valida que una fecha sea MENOR a la fecha actual (útil para fecha de nacimiento).

        /// <param name="fecha">Fecha a validar</param>
        /// <param name="nombreCampo">Nombre del campo</param>
        /// <param name="permitirHoy">Si se permite la fecha de hoy (default: false)</param>
        public static void ValidarFechaMenorHoy(DateTime fecha, string nombreCampo, bool permitirHoy = false)
        {
            DateTime hoy = DateTime.Today;

            if (permitirHoy)
            {
                if (fecha > hoy)
                    throw new ValidationException(nombreCampo,
                        $"El campo '{nombreCampo}' debe ser igual o menor a la fecha actual.");
            }
            else
            {
                if (fecha >= hoy)
                    throw new ValidationException(nombreCampo,
                        $"El campo '{nombreCampo}' debe ser menor a la fecha actual.");
            }
        }


        /// Valida que una fecha sea MAYOR a otra (útil para fecha fin > fecha inicio).

        public static void ValidarFechaMayorQue(DateTime fecha, DateTime fechaComparacion,
            string nombreCampo, string nombreCampoComparacion = "")
        {
            if (fecha <= fechaComparacion)
            {
                string refCampo = string.IsNullOrEmpty(nombreCampoComparacion)
                    ? "la fecha de comparación"
                    : $"'{nombreCampoComparacion}'";

                throw new ValidationException(nombreCampo,
                    $"El campo '{nombreCampo}' debe ser mayor a {refCampo}.");
            }
        }

  
        /// Valida que una fecha esté dentro de un rango razonable (por defecto: 120 años atrás).

        public static void ValidarFechaRazonable(DateTime fecha, int aniosMaximos = 120,
            string nombreCampo = "Fecha")
        {
            DateTime hoy = DateTime.Today;

            if (fecha > hoy)
                throw new ValidationException(nombreCampo,
                    $"El campo '{nombreCampo}' no puede ser una fecha futura.");

            if (fecha < hoy.AddYears(-aniosMaximos))
                throw new ValidationException(nombreCampo,
                    $"El campo '{nombreCampo}' no puede ser mayor a {aniosMaximos} años atrás.");
        }


        /// Valida que una fecha se pueda convertir desde string.
        /// Devuelve la fecha convertida o lanza excepción.

        public static DateTime ParsearFecha(string fechaTexto, string nombreCampo)
        {
            DateTime fecha;

            if (!DateTime.TryParse(fechaTexto, out fecha))
                throw new ValidationException(nombreCampo,
                    $"El campo '{nombreCampo}' no tiene un formato de fecha válido.");

            return fecha;
        }

        /// Valida la edad mínima de una persona según su fecha de nacimiento.

        public static void ValidarEdadMinima(DateTime fechaNacimiento, int edadMinima,
            string nombreCampo = "Fecha de nacimiento")
        {
            int edad = DateTime.Today.Year - fechaNacimiento.Year;

            if (fechaNacimiento > DateTime.Today.AddYears(-edad))
                edad--;

            if (edad < edadMinima)
                throw new ValidationException(nombreCampo,
                    $"La persona debe tener al menos {edadMinima} años (actual: {edad}).");
        }

        #endregion

        #region VALIDACIONES NUMÉRICAS


        /// Valida que un número esté dentro de un rango.

        public static void ValidarRango(decimal valor, decimal minimo, decimal maximo,
            string nombreCampo)
        {
            if (valor < minimo || valor > maximo)
                throw new ValidationException(nombreCampo,
                    $"El campo '{nombreCampo}' debe estar entre {minimo} y {maximo}.");
        }

        /// Valida que un número sea positivo.

        public static void ValidarPositivo(decimal valor, string nombreCampo)
        {
            if (valor < 0)
                throw new ValidationException(nombreCampo,
                    $"El campo '{nombreCampo}' no puede ser negativo.");
        }


        /// Intenta convertir un string a decimal. Si falla, lanza excepción.

        public static decimal ParsearDecimal(string texto, string nombreCampo)
        {
            decimal valor;

            if (!decimal.TryParse(texto, out valor))
                throw new ValidationException(nombreCampo,
                    $"El campo '{nombreCampo}' debe ser un número válido.");

            return valor;
        }

        #endregion

        #region MÉTODOS AUXILIARES


        /// Convierte un string a int. Devuelve 0 si falla (sin lanzar excepción).

        public static int ToInt(string texto, int valorDefecto = 0)
        {
            int valor;
            return int.TryParse(texto, out valor) ? valor : valorDefecto;
        }


        /// Convierte un string a decimal?. Devuelve null si falla.

        public static decimal? ToDecimalNullable(string texto)
        {
            decimal valor;
            return decimal.TryParse(texto, out valor) ? valor : (decimal?)null;
        }

        /// Convierte un string a DateTime?. Devuelve null si falla.
        public static DateTime? ToDateTimeNullable(string texto)
        {
            DateTime fecha;
            return DateTime.TryParse(texto, out fecha) ? fecha : (DateTime?)null;
        }

        /// Valida que una fecha sea menor o igual a otra.
        public static void ValidarFechaMenorOIgual(
            DateTime fechaMenor,
            DateTime fechaMayor,
            string nombreCampoMenor,
            string nombreCampoMayor)
        {
            if (fechaMenor > fechaMayor)
            {
                throw new ValidationException(
                    nombreCampoMenor,
                    $"La '{nombreCampoMenor}' no puede ser mayor que la '{nombreCampoMayor}'.");
            }
        }

        /// Valida que una fecha sea mayor o igual a otra.
        public static void ValidarFechaMayorOIgual(
            DateTime fechaMayor,
            DateTime fechaMenor,
            string nombreCampoMayor,
            string nombreCampoMenor)
        {
            if (fechaMayor < fechaMenor)
            {
                throw new ValidationException(
                    nombreCampoMayor,
                    $"La '{nombreCampoMayor}' no puede ser menor que la '{nombreCampoMenor}'.");
            }
        }
        #endregion
    }
}

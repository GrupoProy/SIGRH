using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Solution_Framework_General.BussinessLogicLayer
{
    /// <summary>
    /// Clase de utilidades para paginación de GridViews.
    /// Proporciona métodos para configurar y aplicar paginación de forma reutilizable.
    /// </summary>
    public static class cls_paginador
    {
        #region CONSTANTES
        public const int TAMANIO_PAGINA_DEFAULT = 10;
        public const int TAMANIO_PAGINA_PEQUENIO = 5;
        public const int TAMANIO_PAGINA_MEDIANO = 15;
        public const int TAMANIO_PAGINA_GRANDE = 25;
        #endregion

        #region CONFIGURACIÓN DE PAGINACIÓN

        /// <summary>
        /// Configura un GridView con las propiedades de paginación estándar.
        /// </summary>
        /// <param name="grid">El GridView a configurar</param>
        /// <param name="tamanioPagina">Cantidad de filas por página (default: 10)</param>
        /// <param name="mostrarInfoPaginacion">Si se muestra "Mostrando X-Y de Z"</param>
        public static void Configurar(
     GridView grid,
     int tamanioPagina = TAMANIO_PAGINA_DEFAULT,
     bool mostrarInfoPaginacion = true)
        {
            if (grid == null)
                throw new ArgumentNullException(nameof(grid));

            grid.AllowPaging = true;
            grid.PageSize = tamanioPagina;
            grid.PagerSettings.Mode = PagerButtons.NumericFirstLast;
            grid.PagerSettings.Position = PagerPosition.Bottom;
            grid.PagerSettings.FirstPageText = "« Primera";
            grid.PagerSettings.LastPageText = "Última »";
            grid.PagerSettings.NextPageText = "Siguiente ›";
            grid.PagerSettings.PreviousPageText = "‹ Anterior";
            grid.PagerSettings.PageButtonCount = 5;

            grid.PagerStyle.CssClass = "pagination";
            grid.PagerStyle.HorizontalAlign = HorizontalAlign.Center;

            grid.UseAccessibleHeader = true;

            // ✅ Solo si existe HeaderRow
            if (grid.HeaderRow != null)
            {
                grid.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        /// <summary>
        /// Configura el GridView con estilo personalizado (Bootstrap 4/5).
        /// </summary>
        public static void ConfigurarConBootstrap(
    GridView grid,
    int tamanioPagina = TAMANIO_PAGINA_DEFAULT)
        {
            Configurar(grid, tamanioPagina);
            grid.PagerStyle.CssClass = "pagination justify-content-center";
        }

        #endregion

        #region PAGINACIÓN MANUAL (VIEWSTATE)

        /// <summary>
        /// Aplica paginación manual a un GridView cargando los datos desde ViewState.
        /// Usar cuando los datos están en un DataTable guardado en ViewState.
        /// </summary>
        /// <param name="grid">GridView a paginar</param>
        /// <param name="dataSource">DataTable con los datos completos</param>
        /// <param name="e">Argumento del evento PageIndexChanging</param>
        public static void PaginarDesdeViewState(
    GridView grid,
    DataTable dataSource,
    GridViewPageEventArgs e)
        {
            if (grid == null || dataSource == null)
                return;

            // ✅ Usar e.NewPageIndex (ya resuelto por ASP.NET)
            grid.PageIndex = e.NewPageIndex;
            grid.DataSource = dataSource;
            grid.DataBind();
        }

        /// <summary>
        /// Aplica paginación sobre un DataTable sin usar ViewState (data directa).
        /// </summary>
        public static DataTable Paginar(DataTable dataSource, int pageIndex, int pageSize)
        {
            if (dataSource == null || dataSource.Rows.Count == 0)
                return dataSource;

            DataTable pagina = dataSource.Clone();

            int inicio = pageIndex * pageSize;
            int fin = Math.Min(inicio + pageSize, dataSource.Rows.Count);

            for (int i = inicio; i < fin; i++)
            {
                pagina.ImportRow(dataSource.Rows[i]);
            }

            return pagina;
        }

        #endregion

        #region HELPERS

        /// <summary>
        /// Calcula el total de páginas para un total de filas.
        /// </summary>
        public static int TotalPaginas(int totalFilas, int tamanioPagina)
        {
            if (tamanioPagina <= 0) return 1;
            return (int)Math.Ceiling((double)totalFilas / tamanioPagina);
        }

        /// <summary>
        /// Ajusta el índice de página si está fuera de rango (ej. después de eliminar registros).
        /// </summary>
        public static void AjustarIndicePagina(GridView grid)
        {
            if (grid == null || grid.PageCount == 0) return;

            if (grid.PageIndex >= grid.PageCount)
            {
                grid.PageIndex = Math.Max(0, grid.PageCount - 1);
            }
        }

        /// <summary>
        /// Registra los eventos de paginación en un GridView.
        /// </summary>
        public static void RegistrarEventos(GridView grid, EventHandler handler)
        {
            if (grid == null || handler == null) return;
            grid.PageIndexChanging += new GridViewPageEventHandler((sender, e) =>
            {
                handler(sender, e);
            });
        }

        /// <summary>
        /// Obtiene el texto de información de paginación (ej: "Mostrando 1-10 de 45").
        /// </summary>
        public static string ObtenerInfoPaginacion(GridView grid, int totalFilas)
        {
            if (grid == null || totalFilas == 0)
                return "Sin registros";

            int inicio = (grid.PageIndex * grid.PageSize) + 1;
            int fin = Math.Min(inicio + grid.PageSize - 1, totalFilas);

            return $"Mostrando {inicio}-{fin} de {totalFilas} registros";
        }

        #endregion

        #region ESTILOS

        /// <summary>
        /// Aplica estilo CSS estándar al PagerStyle del GridView.
        /// </summary>
        public static void AplicarEstiloPager(GridView grid)
        {
            if (grid == null) return;

            grid.PagerStyle.CssClass = "pagination";
            grid.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
            grid.PagerStyle.Font.Bold = true;
        }

        /// <summary>
        /// Genera HTML para mostrar la info de paginación en un Literal.
        /// </summary>
        public static string GenerarHtmlInfo(GridView grid, int totalFilas)
        {
            // ✅ Validación de null
            if (grid == null || totalFilas == 0)
                return "<small class='text-muted'>Sin registros</small>";

            int inicio = (grid.PageIndex * grid.PageSize) + 1;
            int fin = Math.Min(inicio + grid.PageSize - 1, totalFilas);
            int paginaActual = grid.PageIndex + 1;
            int totalPaginas = grid.PageCount;

            return $"<small class='text-muted'>" +
                   $"Mostrando <b>{inicio}-{fin}</b> de <b>{totalFilas}</b> registros " +
                   $"(Página <b>{paginaActual}</b> de <b>{totalPaginas}</b>)" +
                   $"</small>";
        }

        #endregion
    }
}
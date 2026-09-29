using System;
using System.Text;
using System.Web.UI;

namespace Solution_Framework_General.BussinessLogicLayer
{
    
    /// Clase helper para inicializar Select2 con búsqueda en combos.
    /// Proporciona métodos reutilizables para aplicar Select2 a uno o varios DropDownList.
    
    public static class cls_select2_helper
    {
        #region CONSTANTES

        private const string PLACEHOLDER_DEFAULT = "🔍 Buscar...";
        private const string MENSAJE_NO_RESULTS = "No se encontraron resultados";
        private const string MENSAJE_SEARCHING = "Buscando...";
        private const string MENSAJE_INPUT_TOO_SHORT = "Ingrese al menos 1 carácter";

        #endregion

        #region MÉTODOS PRINCIPALES

        
        /// Inicializa Select2 con búsqueda en TODOS los controles con clase "select2".
        /// Registra un script que espera a que jQuery y Select2 estén disponibles.
        /// Re-intenta si no lo están (fallback con setTimeout).
        
        /// <param name="page">Página actual (this)</param>
        /// <param name="placeholder">Texto del placeholder (default: "🔍 Buscar...")</param>

        public static void InicializarSelect2(Page page, string placeholder = PLACEHOLDER_DEFAULT)
        {
            if (page == null) return;

            string script = $@"
        (function () {{
            'use strict';
            
            var PLACEHOLDER = '{placeholder}';
            
            function inicializarSelect2() {{
                if (typeof jQuery === 'undefined' || typeof jQuery.fn.select2 === 'undefined') {{
                    setTimeout(inicializarSelect2, 200);
                    return;
                }}
                
                jQuery('.select2').each(function () {{
                    var combo = jQuery(this);
                    
                    var totalOpciones = combo.find('option').length;
                    if (totalOpciones <= 1) {{
                        return; // Sin opciones aún
                    }}
                    
                    // ⚠️ SIEMPRE DESTRUIR y RE-INICIALIZAR con la config correcta
                    if (combo.hasClass('select2-hidden-accessible') || combo.data('select2')) {{
                        try {{
                            combo.select2('destroy');
                        }} catch(e) {{ /* ignorar */ }}
                    }}
                    
                    try {{
                        combo.select2({{
                            placeholder: {{ id: '', text: PLACEHOLDER }},
                            allowClear: false,
                            width: '100%',
                            minimumResultsForSearch: 0,  // ✅ CLAVE: Siempre mostrar búsqueda
                            language: {{
                                noResults: function () {{ return 'No se encontraron resultados'; }},
                                searching: function () {{ return 'Buscando...'; }},
                                inputTooShort: function () {{ return 'Ingrese al menos 1 carácter'; }}
                            }}
                        }});
                        
                        // ✅ Marcar como inicializado con nuestra configuración
                        combo.attr('data-select2-search', 'enabled');
                    }} catch (e) {{
                        console.error('❌ Error:', e);
                    }}
                }});
            }}
            
            // Ejecutar varias veces para asegurar
            if (typeof jQuery !== 'undefined') {{
                jQuery(document).ready(function() {{
                    setTimeout(inicializarSelect2, 50);
                    setTimeout(inicializarSelect2, 300);
                    setTimeout(inicializarSelect2, 800);
                }});
            }}
            
            // Re-ejecutar en postbacks
            if (typeof Sys !== 'undefined' && Sys.WebForms && Sys.WebForms.PageRequestManager) {{
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {{
                    setTimeout(inicializarSelect2, 50);
                    setTimeout(inicializarSelect2, 300);
                }});
            }}
        }})();
    ";

            RegistrarScript(page, script, "Select2InitHelper");
        }
        
        /// Inicializa Select2 en un DropDownList específico por su ID.
        
        public static void InicializarSelect2PorId(Page page, string clientId, string placeholder = PLACEHOLDER_DEFAULT)
        {
            if (page == null || string.IsNullOrEmpty(clientId)) return;

            string script = $@"
                (function () {{
                    function inicializar() {{
                        if (typeof jQuery === 'undefined' || typeof jQuery.fn.select2 === 'undefined') {{
                            setTimeout(inicializar, 300);
                            return;
                        }}

                        var combo = jQuery('#{clientId}');
                        if (combo.length > 0) {{
                            if (combo.data('select2')) {{
                                combo.select2('destroy');
                            }}
                            combo.select2({{
                                placeholder: {{ id: '', text: '{placeholder}' }},
                                allowClear: false,
                                width: '100%',
                                minimumResultsForSearch: 0,
                                language: {{
                                    noResults: function () {{ return '{MENSAJE_NO_RESULTS}'; }},
                                    searching: function () {{ return '{MENSAJE_SEARCHING}'; }}
                                }}
                            }});
                        }}
                    }}

                    if (typeof jQuery !== 'undefined') {{
                        jQuery(document).ready(inicializar);
                    }} else {{
                        setTimeout(inicializar, 300);
                    }}
                }})();
            ";

            RegistrarScript(page, script, "Select2Init_" + clientId.Replace(".", "_"));
        }

        
        /// Inicializa Select2 en los controles dentro de un modal (requiere dropdownParent).
        
        public static void InicializarSelect2EnModal(Page page, string modalId,
            string placeholder = PLACEHOLDER_DEFAULT)
        {
            if (page == null || string.IsNullOrEmpty(modalId)) return;

            string script = $@"
                (function () {{
                    function inicializar() {{
                        if (typeof jQuery === 'undefined' || typeof jQuery.fn.select2 === 'undefined') {{
                            setTimeout(inicializar, 300);
                            return;
                        }}

                        var modal = jQuery('#{modalId}');
                        if (modal.length > 0) {{
                            modal.find('.select2').each(function () {{
                                var combo = jQuery(this);
                                if (combo.data('select2')) {{
                                    combo.select2('destroy');
                                }}
                                combo.select2({{
                                    dropdownParent: modal,
                                    placeholder: {{ id: '', text: '{placeholder}' }},
                                    allowClear: false,
                                    width: '100%',
                                    minimumResultsForSearch: 0,
                                    language: {{
                                        noResults: function () {{ return '{MENSAJE_NO_RESULTS}'; }},
                                        searching: function () {{ return '{MENSAJE_SEARCHING}'; }}
                                    }}
                                }});
                            }});
                        }}
                    }}

                    if (typeof jQuery !== 'undefined') {{
                        jQuery(document).ready(inicializar);
                    }} else {{
                        setTimeout(inicializar, 300);
                    }}
                }})();
            ";

            RegistrarScript(page, script, "Select2Init_Modal_" + modalId);
        }

        
        /// Registra el handler global para postbacks parciales (UpdatePanel).
        /// Ya no es necesario llamarlo por separado porque InicializarSelect2 lo hace.
        /// Se mantiene por compatibilidad con código existente.
        
        public static void RegistrarReinicializacionPostback(Page page)
        {
            // Ya está incluido en InicializarSelect2. Método conservado por compatibilidad.
        }

        #endregion

        #region MÉTODOS AUXILIARES

        
        /// Registra un bloque de script en la página.
        
        private static void RegistrarScript(Page page, string script, string key)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type='text/javascript'>");
            sb.Append(script);
            sb.Append("</script>");

            // ✅ Registrar con un ID único para evitar duplicados
            if (!page.ClientScript.IsClientScriptBlockRegistered(key))
            {
                page.ClientScript.RegisterClientScriptBlock(page.GetType(), key, sb.ToString());
            }
        }

        #endregion
    }
}
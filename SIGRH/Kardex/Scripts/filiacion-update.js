/**
 * filiacion-update.js
 * Inicialización de Select2 y validaciones para el módulo Filiación.
 */

(function () {
    'use strict';

    // ═══════════════════════════════════════════════════════════
    // CONFIGURACIÓN GLOBAL DE SELECT2
    // ═══════════════════════════════════════════════════════════
    var SELECT2_CONFIG = {
        placeholder: { id: '', text: '🔍 Buscar...' },
        allowClear: false,
        width: '100%',
        minimumResultsForSearch: 0,
        language: {
            noResults: function () { return 'No se encontraron resultados'; },
            searching: function () { return 'Buscando...'; },
            inputTooShort: function () { return 'Ingrese al menos 1 carácter'; }
        }
    };

    // ═══════════════════════════════════════════════════════════
    // INICIALIZACIÓN DE SELECT2
    // ═══════════════════════════════════════════════════════════
    function initSelect2() {
        if (typeof jQuery === 'undefined' || typeof jQuery.fn.select2 === 'undefined') {
            setTimeout(initSelect2, 200);
            return;
        }

        var combos = jQuery('.select2');
        var inicializados = 0;

        combos.each(function () {
            var combo = jQuery(this);

            if (combo.hasClass('select2-hidden-accessible') || combo.data('select2')) {
                try { combo.select2('destroy'); } catch (e) { }
            }

            if (combo.find('option').length === 0) return;

            try {
                combo.select2(SELECT2_CONFIG);
                inicializados++;
            } catch (e) {
                console.error('❌ Error inicializando combo:', e);
            }
        });

        console.log('✅ Select2 inicializado en ' + inicializados + ' combos');
    }

    // ═══════════════════════════════════════════════════════════
    // VALIDACIONES NUMÉRICAS
    // ═══════════════════════════════════════════════════════════
    window.soloDecimalesInput = function (input, maxDecimales, maxEnteros) {
        var valor = input.value.replace(/[^0-9.]/g, '');
        var partes = valor.split('.');

        if (partes.length > 2) {
            valor = partes[0] + '.' + partes.slice(1).join('');
        }

        partes = valor.split('.');
        if (maxEnteros && partes[0].length > maxEnteros) {
            partes[0] = partes[0].substring(0, maxEnteros);
        }

        if (partes.length === 2) {
            partes[1] = partes[1].substring(0, maxDecimales || 2);
        }

        valor = partes.join('.');
        if (input.value !== valor) input.value = valor;
    };

    window.soloEnterosInput = function (input, maxDigitos) {
        var valor = input.value.replace(/[^0-9]/g, '');
        if (maxDigitos && valor.length > maxDigitos) {
            valor = valor.substring(0, maxDigitos);
        }
        if (input.value !== valor) input.value = valor;
    };

    window.soloDecimalesKey = function (evt) {
        var charCode = (evt.which) ? evt.which : evt.keyCode;
        if (charCode >= 48 && charCode <= 57) return true;
        if (charCode === 46 || charCode === 44) return true;
        if (charCode === 8 || charCode === 9 || charCode === 13 || charCode === 27 || charCode === 46) return true;
        if (charCode >= 35 && charCode <= 40) return true;
        if (evt.ctrlKey) return true;
        return false;
    };

    // ═══════════════════════════════════════════════════════════
    // INICIALIZACIÓN AUTOMÁTICA
    // ═══════════════════════════════════════════════════════════
    if (typeof jQuery !== 'undefined') {
        jQuery(document).ready(function () {
            initSelect2();
            setTimeout(initSelect2, 300);
            setTimeout(initSelect2, 800);
        });
    }

    if (typeof Sys !== 'undefined' && Sys.WebForms && Sys.WebForms.PageRequestManager) {
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
            setTimeout(initSelect2, 100);
            setTimeout(initSelect2, 500);
        });
    }

    window.initSelect2 = initSelect2;

})();

function validarFormularioEducacion() {
    var nivel = $('[id$="ddl_ef_nivel_instruccion"]').val();
    var centro = $('[id$="ddl_ef_centro_form"]').val();
    var carrera = $('[id$="ddl_ef_carrera_especialidad"]').val();
    var fechaIni = $('[id$="txt_ef_fecha_ini"]').val();
    var descripcion = $('[id$="txt_ef_descripcion"]').val();

    if (!nivel) {
        Swal.fire('Atención', 'Debe seleccionar un Nivel de Instrucción.', 'warning');
        return false;
    }
    if (!centro) {
        Swal.fire('Atención', 'Debe seleccionar una Formación.', 'warning');
        return false;
    }
    if (!carrera) {
        Swal.fire('Atención', 'Debe seleccionar una Carrera.', 'warning');
        return false;
    }
    if (!fechaIni) {
        Swal.fire('Atención', 'Debe ingresar la Fecha de Inicio.', 'warning');
        return false;
    }
    if (!fechaFin) {
        Swal.fire('Atención', 'Debe ingresar la Fecha de Fin.', 'warning');
        return false;
    }
    // ✅ Descripción obligatoria
    if (!descripcion || descripcion.trim() === '') {
        Swal.fire('Atención', 'Debe ingresar una Descripción.', 'warning');
        return false;
    }
    return true;
}
$('#ContentPlaceHolder1_gv_items thead tr').clone(true).appendTo('#ContentPlaceHolder1_gv_items thead');
$('#ContentPlaceHolder1_gv_items thead tr:eq(1) th').each(function (i) {
    var columnsLength = $('#ContentPlaceHolder1_gv_items thead tr:eq(1) th').length;
    columnsLength = columnsLength - 1;
    var title = $(this).text();
    if (i !== 0 && i < columnsLength) {
        $(this).html('<input type="text" class="form-control form-control-sm" placeholder="Buscar" />');
        console.log('filterDataTable', this, i, columnsLength);
        $('input', this).on('keyup change', function () {
            console.log('filterDataTable1');
            var table = $('#ContentPlaceHolder1_gv_items').DataTable();
            if (table.column(i).search() !== this.value) {
                table
                    .column(i)
                    .search(this.value)
                    .draw();
            }
        });
    } else {
        $(this).html('<div style="display: none;"><input type="text" class="form-control form-control-sm" placeholder="Buscar" /></div>');
    }
});

$('.table').DataTable({
    'language': {
        'sProcessing': 'Procesando...',
        'sLengthMenu': 'Mostrar _MENU_ registros',
        'sZeroRecords': 'No se encontraron resultados',
        'sEmptyTable': 'Ningún dato disponible en esta tabla',
        'sInfo': 'Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros',
        'sInfoEmpty': 'Mostrando registros del 0 al 0 de un total de 0 registros',
        'sInfoFiltered': '(filtrado de un total de _MAX_ registros)',
        'sInfoPostFix': '',
        'sSearch': 'Buscar:',
        'sUrl': '',
        'sInfoThousands': ',',
        'sLoadingRecords': 'Cargando...',
        'oPaginate': {
            'sFirst': '«',
            'sLast': '»',
            'sNext': '<i class="fas fa-angle-right"></i>',
            'sPrevious': '<i class="fas fa-angle-left"></i>'
        },
        'oAria': {
            'sSortAscending': ': Activar para ordenar la columna de manera ascendente',
            'sSortDescending': ': Activar para ordenar la columna de manera descendente'
        }
    },
    'ordering': false,
    'searching': true,
    'autoWidth': false,
    'orderCellsTop': true,
    'fixedHeader': true,
    'stateSave': true, 'stateDuration': 60 * 10
});

$(".checks label").addClass("custom-control-label mb-3");
$(".checks input[type='checkbox']").addClass("custom-control-input mb-3");

$(".radios label").addClass("custom-control-label mb-3");
$(".radios input[type='radio']").addClass("custom-control-input mb-3");

//$(".table").css("table-layout", "fixed");
$("td").css("white-space", "normal");
$("td").css("text-align", "justify");

$('.tooltip').css('display', 'none');
$('[data-toggle="tooltip"]').tooltip({ trigger: 'hover' });

$(".aspNetDisabled ").addClass("disabled");

$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } });
//$('.js-example-basic-multiple').select2({ tags: true });
//var data = ["Apple", "Banana", "Cherry", "Date", "ElderberriesElderberry"]; 
//$('.js-example-basic-hide-search-multi').select2({
//    data: data
//});

//$('.js-example-basic-hide-search-multi').on('select2:opening select2:closing', function (event) {
//    var $searchfield = $(this).parent().find('.select2-search__field');
//    $searchfield.prop('enabled', true);
//});

let seconds = 0;
let interval;
function verificaSS(x_time) {
    seconds = 0;
    seconds = x_time * 60;
    clearInterval(interval);
    interval = setInterval(function () {
        if (seconds > 0) {
            seconds--;
            //console.log(seconds);
        } else {
            console.log('expired');
            $('#modalExpired').modal('show');
            clearInterval(interval);
        }
    }, 1000);
}
$(function () {
    $("body").delegate(".datepickerDefault", "focusin", function () {
        $(this).datepicker({
            format: "dd/mm/yyyy",
            autoclose: true,
            language: 'es',
            forceParse: false
        });
    });

    var me = $(".datepickerDefault");
    me.mask('99/99/9999');
});
//Asignacion parametros componente DatePicker con fecha actual por defecto
$(function () {
    $("body").delegate(".datepicker", "focusin", function () {
        $(this).datepicker({
            format: "dd/mm/yyyy",
            autoclose: true,
            language: "es"
        });
    });
    $('.datepicker').datepicker('setDate', 'today');
    var me = $(".datepicker");
    me.mask("99/99/9999");
});


var me = $(".accountBank");
me.mask("999-99999999-9-99");

//CSS Height Dinamico
var height = window.innerHeight;
height = height - 300;
$('.scroll-static-prs').css('max-height', height + 'px');

//Wizard
$('.btnNext').click(function () {
    console.log('entrarNav');
    $('.nav-tabs > .active').next('li').find('a').trigger('click');
});

$('.btnPrevious').click(function () {
    $('.nav-tabs > .active').prev('li').find('a').trigger('click');
});

//Oculta el buscador General
$('#ContentPlaceHolder1_gv_items_filter').css({ display: 'none' });

//CSS Width Dinamico QuillJS
var width = window.innerWidth;
height = height - 219;
if (width > 1400) {
    //$('#customQuillCss').css('max-height', height + 'px');
    $("#customQuillCss").addClass("col-lg-9");
} else {
    //$('#quillDiv').css('max-width', '1000px');
    $("#customQuillCss").addClass("col-lg-12");
}

//Select2 Tenor
//$('#ContentPlaceHolder1_ddl_tipo_movimiento').select2({ placeholder: { id: '0', text: 'Selecciona una Opción' } });
////Select2 asignacion Tenor
//$('#ContentPlaceHolder1_ddl_tipo_movimiento_gral').select2({ placeholder: { id: '0', text: 'Seleccione...' } });
//$('#ContentPlaceHolder1_ddl_tenor').select2({ placeholder: { id: '0', text: 'Seleccione...' } });

// (KCPB) Ayuda a deshabilitar las teclas para las herramientas de desarrollador
//window.onload = function () {
//    document.addEventListener("keydown", function (e) {
//        //document.onkeydown = function(e) {
//        // "I" key
//        if (e.ctrlKey && e.shiftKey && e.keyCode == 73) {
//            disabledEvent(e);
//        }
//        // "J" key
//        if (e.ctrlKey && e.shiftKey && e.keyCode == 74) {
//            disabledEvent(e);
//        }
//        // "S" key + macOS
//        if (e.keyCode == 83 && (navigator.platform.match("Mac") ? e.metaKey : e.ctrlKey)) {
//            disabledEvent(e);
//        }
//        // "U" key
//        if (e.ctrlKey && e.keyCode == 85) {
//            disabledEvent(e);
//        }
//        // "F12" key
//        if (event.keyCode == 123) {
//            disabledEvent(e);
//        }
//    }, false);
//    function disabledEvent(e) {
//        if (e.stopPropagation) {
//            e.stopPropagation();
//        } else if (window.event) {
//            window.event.cancelBubble = true;
//        }
//        e.preventDefault();
//        $.notify({ icon: 'fas fa-times', message: 'La herramienta está deshabilitada...!!' }, { type: 'danger' });
//        return false;
//    }
//}
//edit: removed ";" from last "}" because of javascript error

// (KCPB) Asignación de parámetros componente DatePicker
$(function () {
    $("body").delegate(".datepickerD", "focusin", function () {
        $(this).datepicker({
            format: "dd/mm/yyyy",
            autoclose: true,
            language: "es"
        });
    });
    var me = $(".datepickerD");
    me.mask("99/99/9999");
});

// (KCPB) Asignación de parámetros componente DatePicker
$(function () {
    var me = $(".timepickerD");
    me.mask("99:99");
});

// (KCPB) Validar solo numeros
$('.numero').on('input', function (event) {
    this.value = this.value.replace(/[^0-9]/g, '');
});

// Validar solo letras
$('.letras').on('input', function () {
    this.value = this.value.replace(/[^A-Z\u00F1\u00D1 ]+$/i, '');
});

//Identifica el Navegador
let navegador = IdentificarNavegador();
if (navegador === 'msie') {
    $("body").removeClass("g-sidenav-hidden").addClass("g-sidenav-show g-sidenav-pinned")
}
console.log('navegador', navegador)
function IdentificarNavegador() {
    let ua = navigator.userAgent.match(/(opera|chrome|safari|firefox|Mozilla|msie)\/?\s*(\.?\d+(\.\d+)*)/i)
    let browser = ''
    if (navigator.userAgent.match(/Edge/i) || navigator.userAgent.match(/Trident.*rv[ :]*11\./i)) {
        browser = 'msie'
    } else {
        browser = ua[1].toLowerCase()
    }
    return browser
}




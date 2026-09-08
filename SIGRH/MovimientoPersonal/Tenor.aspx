<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="Tenor.aspx.cs" Inherits="MovimientoPersonal_Tenor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        /* El editor se presenta como una hoja A4 para que edición y vista previa coincidan. */
        #customQuillCss {
            width: 100%;
            max-width: 980px;
        }

        #quillDiv {
            padding: 0;
            background: #eef1f5;
            border: 1px solid #d8dee6;
        }

        #quillDiv .ql-toolbar.ql-snow {
            position: sticky;
            top: 0;
            z-index: 10;
            background: #15171a;
            border: 0;
            border-bottom: 1px solid #050505;
            color: #fff !important;
        }

        /* Barra oscura: evita que Argon deje los controles blancos sobre blanco. */
        #quillDiv .ql-toolbar.ql-snow button,
        #quillDiv .ql-toolbar.ql-snow .ql-picker-label {
            color: #fff !important;
        }

        #quillDiv .ql-snow .ql-stroke {
            stroke: #fff !important;
        }

        #quillDiv .ql-snow .ql-fill,
        #quillDiv .ql-snow .ql-stroke.ql-fill {
            fill: #fff !important;
        }

        #quillDiv .ql-snow .ql-picker-options,
        #quillDiv .ql-snow .ql-tooltip {
            color: #111 !important;
            background: #fff !important;
        }

        #quillDiv .ql-snow .ql-picker-item {
            color: #111 !important;
        }

        #quillDiv .ql-toolbar.ql-snow button:hover,
        #quillDiv .ql-toolbar.ql-snow button.ql-active,
        #quillDiv .ql-toolbar.ql-snow .ql-picker-label:hover,
        #quillDiv .ql-toolbar.ql-snow .ql-picker-label.ql-active {
            color: #26c6da !important;
        }

        #quillDiv .ql-toolbar.ql-snow button:hover .ql-stroke,
        #quillDiv .ql-toolbar.ql-snow button.ql-active .ql-stroke,
        #quillDiv .ql-toolbar.ql-snow .ql-picker-label:hover .ql-stroke,
        #quillDiv .ql-toolbar.ql-snow .ql-picker-label.ql-active .ql-stroke {
            stroke: #26c6da !important;
        }

        #quillDiv .ql-toolbar.ql-snow button:hover .ql-fill,
        #quillDiv .ql-toolbar.ql-snow button.ql-active .ql-fill {
            fill: #26c6da !important;
        }

        #customQuill.ql-container.ql-snow {
            width: 216mm;
            max-width: calc(100% - 30px);
            min-height: 279mm;
            margin: 15px auto;
            border: 0;
            background: #fff;
            box-shadow: 0 2px 12px rgba(31, 45, 61, .16);
        }

        #customQuill .ql-editor {
            min-height: 297mm;
            padding: 18mm 20mm 17mm;
            box-sizing: border-box;
            overflow: visible;
            color: #111;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 11pt;
            line-height: 1.35;
        }

        #customQuill .ql-editor p {
            margin: 0;
        }

        #customQuill .ql-editor img {
            display: inline-block;
            max-width: 100%;
            height: auto;
            object-fit: contain;
            vertical-align: middle;
        }

        #customQuill .ql-editor .ql-align-center { text-align: center; }
        #customQuill .ql-editor .ql-align-right { text-align: right; }
        #customQuill .ql-editor .ql-align-justify { text-align: justify; }

        /* Estructura visual de la cabecera institucional. */
        #customQuill .ql-editor .memo-title {
            margin-bottom: 5mm;
            text-align: center !important;
            font-weight: 700;
            text-decoration: underline;
        }

        /* CAMBIO: Eliminamos width/height fijos, solo flotación y márgenes */
        #customQuill .ql-editor img.memo-logo {
    float: left !important;
    display: block !important;
    margin: 0 12mm 3mm 3mm !important;
    box-sizing: border-box;
    max-width: 100%;
height: auto;
}

        #customQuill .ql-editor .memo-logo-line {
            text-align: left !important;
        }

        #customQuill .ql-editor .memo-after-header {
    clear: both;
    padding-top: 5mm;
}

        #customQuill .ql-editor .memo-reference {
            margin-top: 4mm;
            text-align: right !important;
            font-weight: 700;
            text-decoration: underline;
        }

        /* CAMBIO: Eliminamos width/height fijos, solo centrado */
        #customQuill .ql-editor img.memo-signature {
            float: none !important;
            display: inline-block !important;
            margin: 5mm auto 0 auto !important;
            padding: 0 !important;
            border: 0 !important;
            max-width: 100% !important;
            height: auto !important;
        }

        #customQuill .ql-editor .memo-signature-line {
            clear: both;
            text-align: center !important;
        }

        @media (max-width: 900px) {
            #customQuill.ql-container.ql-snow {
                width: calc(100% - 20px);
                max-width: none;
            }

            #customQuill .ql-editor {
                padding: 12mm;
            }
        }
    </style>

    <div class="header pb-6" style="margin-top: -4em; margin-left: 3em; width: 81%">
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Creaci&oacute;n de Tenor</h6>
                    </div>
                    <div class="col-lg-6 col-5 text-right">
                        <asp:LinkButton ID="btn_vista_previa"
                            CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-inst2 text-white rounded-circle shadow"
                            Text="<i class='fas fa-file-invoice'></i>"
                            data-toggle="tooltip"
                            data-original-title="Vista Previa"
                            CausesValidation="false"
                            OnClientClick="vistaPrevia(); return false;"
                            runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid mt--6">
        <asp:HiddenField ID="hf_var" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hf_containerQuill" runat="server" ClientIDMode="Static" />

        <div class="row justify-content-center">
            <div class="card-wrapper ct-example" id="customQuillCss">
                <div class="card">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Creaci&oacute;n de Tenor</h3>
                            <p class="text-sm mb-0">
                                Redacte el tenor que se utilizar&aacute; en los reportes de memor&aacute;ndums o contratos.
                                Al editar un registro, el contenido guardado se carga autom&aacute;ticamente en la hoja.
                            </p>
                        </div>
                    </div>

                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label class="form-control-label">Descripci&oacute;n del tenor</label>
                                    <div class="input-group input-group-merge">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text border-default-2"><i class="fas fa-edit"></i></span>
                                        </div>
                                        <asp:TextBox ID="txt_desc_tenor" CssClass="form-control" placeholder="Memo de designación" runat="server" />
                                    </div>
                                    <asp:RequiredFieldValidator CssClass="text-danger display-5"
                                        ErrorMessage="(*) Campo Obligatorio"
                                        ControlToValidate="txt_desc_tenor"
                                        Display="Dynamic"
                                        ValidationGroup="val_guardar_tenor"
                                        runat="server" />
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="form-control-label">Tipo Movimiento</label>
                                    <asp:DropDownList ID="ddl_tipo_movimiento"
                                        AppendDataBoundItems="true"
                                        CssClass="form-control select2"
                                        OnSelectedIndexChanged="ddl_tipo_movimiento_SelectedIndexChanged"
                                        runat="server" />
                                    <asp:RequiredFieldValidator CssClass="text-danger display-5"
                                        ErrorMessage="(*) Campo Obligatorio"
                                        ControlToValidate="ddl_tipo_movimiento"
                                        Display="Dynamic"
                                        ValidationGroup="val_guardar_tenor"
                                        InitialValue="0"
                                        runat="server" />
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="form-control-label">Contenido Tenor</label>
                            <div id="quillDiv">
                                <div id="customQuill"></div>
                            </div>
                            <small class="form-text text-muted">
                                Para ubicar el QR sin afectar el logotipo ni la firma, escriba <strong>[QR]</strong>
                                exactamente en la posición donde deba aparecer.
                            </small>
                        </div>

                        <div class="form-group text-right">
                            <asp:UpdatePanel ID="upAccionesTenor" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:LinkButton ID="btnAtras"
                                        CssClass="btn btn-info"
                                        Text="Atras"
                                        CausesValidation="false"
                                        OnClick="btnAtras_Click"
                                        runat="server" />

                                    <asp:LinkButton ID="modalGuardarTenor"
                                        CssClass="btn btn-success"
                                        Text="<i class='fas fa-save mr-2'></i>Guardar"
                                        OnClientClick="sincronizarTenor();"
                                        OnClick="modalGuardarTenor_Click"
                                        ValidationGroup="val_guardar_tenor"
                                        runat="server" />

                                    <div class="modal fade" id="modalGuardarT" tabindex="-1" role="dialog"
                                        aria-labelledby="modal-notification" aria-hidden="true" data-backdrop="static">
                                        <div class="modal-dialog modal-danger modal-dialog-centered" role="document">
                                            <div class="modal-content bg-gradient-warning">
                                                <div class="modal-header"></div>
                                                <div class="modal-body">
                                                    <div class="py-3 text-center">
                                                        <i class="ni ni-single-copy-04 ni-3x"></i>
                                                        <h4 class="heading mt-4">¿Desea guardar los cambios?</h4>
                                                    </div>
                                                </div>
                                                <div class="form-group text-center">
                                                    <asp:LinkButton ID="btnGuardarTenor"
                                                        Text="<i class='fas fa-check mr-2'></i>Aceptar"
                                                        CssClass="btn btn-success"
                                                        OnClientClick="sincronizarTenor();"
                                                        OnClick="btnGuardarTenor_Click"
                                                        runat="server" />
                                                    <button type="button" class="btn btn-outline-github" data-dismiss="modal">
                                                        <i class="fas fa-times mr-2"></i>Cancelar
                                                    </button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        var quill = null;

        (function () {
            "use strict";

            function obtenerVariables(callback) {
                if (Array.isArray(window.variablesResporte3)) {
                    callback(window.variablesResporte3);
                    return;
                }

                if (window.jQuery && $.getJSON) {
                    $.getJSON("../Content/js/JSON/VariablesQuill.json")
                        .done(function (data) { callback(Array.isArray(data) ? data : []); })
                        .fail(function () { callback([]); });
                    return;
                }

                callback([]);
            }

            function crearEditor(variables) {
                if (quill || typeof Quill === "undefined") {
                    return;
                }

                var nombres = [];
                for (var i = 0; i < variables.length; i++) {
                    if (variables[i] && variables[i].nombreVariable) {
                        nombres.push(variables[i].nombreVariable);
                    }
                }

                var Size = Quill.import("attributors/style/size");
                Size.whitelist = ["10px", "14px", "15px", "16px", "18px", "19px", "20px", "21px", "22px", "23px", "24px", "26px", "28px", "30px", "34px"];
                Quill.register(Size, true);

                var toolbarOptions = [
                    [{ "placeholder": nombres }],
                    [{ "size": Size.whitelist }],
                    ["bold", "italic", "underline", "strike"],
                    [{ "color": [] }, { "background": [] }],
                    [{ "align": "" }, { "align": "center" }, { "align": "right" }, { "align": "justify" }],
                    ["image"],
                    [{ "font": [] }],
                    [{ "list": "ordered" }, { "list": "bullet" }]
                ];

                quill = new Quill(document.getElementById("customQuill"), {
                    theme: "snow",
                    modules: {
                        imageResize: { displaySize: true },
                        toolbar: {
                            container: toolbarOptions,
                            handlers: {
                                "placeholder": function (value) {
                                    if (!value) { return; }
                                    var selection = this.quill.getSelection(true);
                                    var position = selection ? selection.index : this.quill.getLength();
                                    this.quill.insertText(position, value);
                                    this.quill.setSelection(position + value.length);
                                }
                            }
                        },
                        formula: false
                    },
                    placeholder: "Tenor"
                });

                var items = document.querySelectorAll(".ql-placeholder .ql-picker-item");
                for (var j = 0; j < items.length; j++) {
                    items[j].textContent = items[j].getAttribute("data-value");
                }

                var label = document.querySelector(".ql-placeholder .ql-picker-label");
                if (label) {
                    label.setAttribute("data-label", "Insertar Variable");
                    label.insertBefore(document.createTextNode("Insertar Variable"), label.firstChild);
                }

                restaurarTenorGuardado();
                quill.on("text-change", function () {
                    sincronizarTenor();
                    window.setTimeout(function () {
                        prepararDisenoMemorandum(document.querySelector("#customQuill .ql-editor"));
                    }, 0);
                });
            }

            function restaurarTenorGuardado() {
                var hidden = document.getElementById("hf_containerQuill");
                if (!quill || !hidden || !hidden.value) {
                    return;
                }

                try {
                    var delta = JSON.parse(hidden.value);
                    if (delta && Array.isArray(delta.ops)) {
                        quill.setContents(delta, "silent");
                        prepararDisenoMemorandum(document.querySelector("#customQuill .ql-editor"));
                    }
                } catch (error) {
                    console.error("El contenido guardado del tenor no es un Delta de Quill válido.", error);
                }
            }

            window.obtenerQuill = function () { return quill; };

            window.sincronizarTenor = function () {
                var hidden = document.getElementById("hf_containerQuill");
                if (quill && hidden) {
                    hidden.value = JSON.stringify(quill.getContents());
                }
                return true;
            };

            // CAMBIO: Eliminamos forzado de width/height, solo aplicamos clases y flotación
            function prepararDisenoMemorandum(editor) {
                if (!editor) { return; }

                var bloques = editor.querySelectorAll("p, h1, h2, h3");
                for (var i = 0; i < bloques.length; i++) {
                    bloques[i].classList.remove("memo-title", "memo-after-header", "memo-reference", "memo-logo-line", "memo-signature-line");
                    var texto = (bloques[i].textContent || "").replace(/\s+/g, " ").trim();
                    var textoMayuscula = texto.toUpperCase();

                    if (textoMayuscula === "MEMORANDUM" || textoMayuscula === "MEMORÁNDUM") {
                        bloques[i].classList.add("memo-title");
                    }

                    if (/^REF\s*[.:\-]/i.test(texto)) {
                        bloques[i].classList.add("memo-reference");
                    }

                    if (/\[FECHA_(ASIGNACION|MEMO|MEMORANDUM)\]/i.test(texto)) {
                        bloques[i].classList.add("memo-after-header");
                    }
                }

                var imagenes = editor.querySelectorAll("img");
                // Eliminar clases previas y estilos de flotación
                for (var j = 0; j < imagenes.length; j++) {
                    imagenes[j].classList.remove("memo-logo", "memo-signature");
                    imagenes[j].style.removeProperty("float");
                    //imagenes[j].style.removeProperty("width");
                    //imagenes[j].style.removeProperty("height");
                }

                // Asignar clase y flotación a la primera imagen (logo) sin forzar tamaño
                if (imagenes.length > 0) {
                    var logo = imagenes[0];
                    logo.classList.add("memo-logo");
                    logo.style.setProperty("float", "left", "important");
                    // No se setea width ni height
                    if (logo.parentElement) {
                        logo.parentElement.classList.add("memo-logo-line");
                    }
                }

                // Asignar clase a la última imagen (firma) sin forzar tamaño
                if (imagenes.length > 1) {
                    var firma = imagenes[imagenes.length - 1];
                    firma.classList.remove("memo-logo");
                    firma.classList.add("memo-signature");
                    // No se setea width ni height
                    if (firma.parentElement) {
                        firma.parentElement.classList.add("memo-signature-line");
                    }
                }
            }

            function clonarEditorParaImpresion(editor) {
                var copia = editor.cloneNode(true);
                prepararDisenoMemorandum(copia);
                return copia;
            }

            // CAMBIO: Eliminar width/height forzados en CSS de impresión
            function cssImpresion() {
                return "@page{size:A4 portrait;margin:14mm 18mm 14mm 18mm;}" +
                    "*{box-sizing:border-box;}" +
                    "html,body{margin:0;padding:0;background:#fff;color:#111;}" +
                    ".memo-sheet{width:auto;min-height:0;margin:0;padding:0;background:#fff;" +
                    "font-family:Arial,Helvetica,sans-serif;font-size:11pt;line-height:1.35;}" +
                    ".ql-editor{height:auto!important;min-height:0!important;padding:0!important;overflow:visible!important;white-space:pre-wrap;word-wrap:break-word;}" +
                    ".ql-editor p{margin:0;}" +
                    ".ql-editor img{display:inline-block;max-width:100%;height:auto;object-fit:contain;vertical-align:middle;break-inside:avoid;}" +
                    ".ql-align-center{text-align:center;}.ql-align-right{text-align:right;}.ql-align-justify{text-align:justify;}" +
                    ".memo-title{margin-bottom:5mm!important;text-align:center!important;font-weight:700;text-decoration:underline;}" +
                    "img.memo-logo{float:left!important;display:block!important;margin:0 12mm 3mm 3mm!important;max-width:100%!important;height:auto!important;}" +
                    ".memo-logo-line{text-align:left!important;}" +
                    ".memo-after-header{clear:both!important;padding-top:5mm!important;}" +
                    ".memo-reference{margin-top:4mm!important;text-align:right!important;font-weight:700;text-decoration:underline;}" +
                    "img.memo-signature{float:none!important;display:inline-block!important;margin:5mm auto 0 auto!important;padding:0!important;border:0!important;max-width:100%!important;height:auto!important;}" +
                    ".memo-signature-line{clear:both!important;text-align:center!important;}" +
                    ".ql-indent-1{padding-left:3em;}.ql-indent-2{padding-left:6em;}.ql-indent-3{padding-left:9em;}" +
                    ".ql-editor ol,.ql-editor ul{padding-left:1.5em;}" +
                    "@media print{.memo-sheet{margin:0;box-shadow:none;}a{color:inherit;text-decoration:none;}}";
            }

            function imprimirCuandoCargue(printWindow) {
                var imagenes = printWindow.document.images;
                var estilos = printWindow.document.querySelectorAll("link[rel='stylesheet']");
                var pendientes = [];

                for (var i = 0; i < imagenes.length; i++) {
                    if (!imagenes[i].complete) {
                        pendientes.push(new Promise(function (resolve) {
                            var image = imagenes[i];
                            image.onload = resolve;
                            image.onerror = resolve;
                        }));
                    }
                }

                for (var j = 0; j < estilos.length; j++) {
                    (function (link) {
                        try {
                            if (link.sheet) { return; }
                        } catch (ignore) { }

                        pendientes.push(new Promise(function (resolve) {
                            link.onload = resolve;
                            link.onerror = resolve;
                        }));
                    }(estilos[j]));
                }

                Promise.race([
                    Promise.all(pendientes),
                    new Promise(function (resolve) { setTimeout(resolve, 1500); })
                ]).then(function () {
                    printWindow.focus();
                    setTimeout(function () { printWindow.print(); }, 150);
                });
            }

            window.vistaPrevia = function () {
                if (!quill) {
                    alert("El editor todavía se está cargando.");
                    return;
                }

                sincronizarTenor();
                var editor = document.querySelector("#customQuill .ql-editor");
                if (!editor || quill.getText().trim() === "") {
                    alert("No existe contenido para mostrar en la vista previa.");
                    return;
                }

                var editorImpresion = clonarEditorParaImpresion(editor);

                var printWindow = window.open("", "_blank", "width=1000,height=800,scrollbars=yes");
                if (!printWindow) {
                    alert("El navegador bloqueó la vista previa. Habilite las ventanas emergentes para este sitio.");
                    return;
                }

                printWindow.document.open();
                printWindow.document.write("<!doctype html><html><head><meta charset='utf-8'><title>Vista previa del memorándum</title>" +
                    "<base href='" + document.baseURI + "'>" +
                    "<link rel='stylesheet' href='../Content/vendor/quill/dist/quill.snow.css'>" +
                    "<style>" + cssImpresion() + "</style></head><body>" +
                    "<section class='memo-sheet'>" + editorImpresion.outerHTML + "</section>" +
                    "</body></html>");
                printWindow.document.close();
                imprimirCuandoCargue(printWindow);
            };

            function iniciar() {
                obtenerVariables(crearEditor);
            }

            if (document.readyState === "loading") {
                document.addEventListener("DOMContentLoaded", iniciar);
            } else {
                iniciar();
            }
        }());
    </script>
</asp:Content>
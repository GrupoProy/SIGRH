<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="AsignacionTenor.aspx.cs" Inherits="MovimientoPersonal_AsignacionTenor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        /* Quill se usa solamente como renderizador fuera de pantalla. */
        #memoRenderHost {
            position: absolute;
            left: -10000px;
            top: 0;
            width: 794px;
            visibility: hidden;
            pointer-events: none;
        }
    </style>

    <div class="header pb-6" style="margin-top: -4em; margin-left: 3em; width: 81%">
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Asignacion de Tenor - Funcionario</h6>
                    </div>
                    <div class="col-lg-6 col-5 text-right"></div>
                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid mt--6">
        <div class="row justify-content-center">
            <div class="col-lg-8 card-wrapper ct-example">
                <div class="card">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Busqueda Funcionario - Tenor</h3>
                            <p class="text-sm mb-0">
                                Para realizar la asignacion del tenor, previamente debe buscar al funcionario
                                con los filtros que se muestran a continuacion.
                            </p>
                        </div>
                    </div>

                    <div class="card-body">
                        <asp:Panel runat="server" DefaultButton="btnFiltrar">
                            <asp:UpdatePanel ID="panelFuncionarios" runat="server">
                                <ContentTemplate>
                                    <div class="row ml-2">
                                        <div class="form-group col-md-4">
                                            <label class="form-control-label" for="Txt_per_num_doc">Numero de Documento</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><i class="far fa-id-card"></i></span>
                                                </div>
                                                <asp:TextBox ID="Txt_per_num_doc" CssClass="form-control numero" TextMode="Number" runat="server" />
                                            </div>
                                        </div>

                                        <div class="form-group col-md-6">
                                            <label class="form-control-label" for="Txt_per_ap_paterno">Apellido Paterno</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                </div>
                                                <asp:TextBox ID="Txt_per_ap_paterno" CssClass="form-control letras" runat="server" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="pl-lg-4">
                                        <div class="row">
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label class="form-control-label">Tipo de Item</label>
                                                    <asp:DropDownList ID="ddl_tipo_item" AppendDataBoundItems="true" CssClass="form-control select2" runat="server" />
                                                </div>
                                            </div>

                                            <div class="col-sm-6 col-md-4">
                                                <div class="form-group">
                                                    <label class="form-control-label">Desde el Item</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text border-default-2"><i class="fas fa-edit"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_desde_item" CssClass="form-control border-default-2 numero" placeholder="1" runat="server" />
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-sm-6 col-md-4">
                                                <div class="form-group">
                                                    <label class="form-control-label">Hasta el Item</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text border-default-2"><i class="fas fa-edit"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_hasta_item" CssClass="form-control border-default-2 numero" placeholder="100" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="pl-lg-4">
                                        <div class="row">
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label class="form-control-label">Tipo de Movimiento</label>
                                                    <asp:DropDownList ID="ddl_tipo_movimiento_gral"
                                                        OnSelectedIndexChanged="ddl_tipo_movimiento_gral_SelectedIndexChanged"
                                                        AppendDataBoundItems="true"
                                                        CssClass="form-control select2"
                                                        AutoPostBack="true"
                                                        runat="server" />
                                                </div>
                                            </div>

                                            <div class="col-md-4">
                                                <div class="form-group text-right">
                                                    <label class="form-control-label">&nbsp;</label>
                                                    <asp:LinkButton ID="btnFiltrar"
                                                        CssClass="btn btn-vimeo btn-block"
                                                        Text="<i class='fas fa-search'></i> Buscar"
                                                        OnClick="btnFiltrar_Click"
                                                        runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>

        <div id="grillaFunc" class="card" style="display: none;">
            <div class="card-header d-flex align-items-center">
                <div class="d-flex align-items-center">
                    <div class="text-dark font-weight-600 text-sm">
                        <h3 class="mb-0">Resultados de la Busqueda</h3>
                    </div>
                </div>

                <div class="text-right ml-auto">
                    <asp:UpdatePanel ID="panelImpresion" runat="server">
                        <ContentTemplate>
                            <asp:LinkButton ID="btn_imprimir_masivo"
                                CssClass="btn btn-slack btn-round btn-icon"
                                data-toggle="tooltip"
                                data-original-title="Imprimir"
                                Text="<span class='btn-inner--icon'><i class='fas fa-print'></i></span><span class='btn-inner--text'>Imprimir Varios</span>"
                                OnClick="btn_imprimir_masivo_Click"
                                runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>

            <div class="card-body">
                <h4 class="text-sm mb-0 text-blue">
                    (Impresion de Memorandums) Seleccione el tenor segun el tipo de movimiento y
                    posteriormente seleccione al funcionario que desee imprimir.
                </h4>

                <div class="table-responsive py-4">
                    <asp:UpdatePanel ID="upGrillaTenor" runat="server">
                        <ContentTemplate>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="form-control-label">Tenor</label>
                                    <asp:DropDownList ID="ddl_tenor"
                                        OnSelectedIndexChanged="ddl_tenor_SelectedIndexChanged"
                                        AutoPostBack="true"
                                        AppendDataBoundItems="true"
                                        CssClass="form-control select2"
                                        runat="server" />
                                </div>
                            </div>

                            <asp:GridView ID="gvFuncionario"
                                CssClass="table table-bordered table-hover table-striped"
                                AutoGenerateColumns="false"
                                OnPreRender="gvFuncionario_PreRender"
                                OnRowCommand="gvFuncionario_RowCommand"
                                DataKeyNames="per_id, as_id"
                                runat="server">
                                <Columns>
                                    <asp:TemplateField ItemStyle-CssClass="text-center">
                                        <HeaderTemplate>
                                            <span class="badge badge-lg badge-darkerw">Todos</span>
                                            <label class="custom-toggle custom-toggle-dark">
                                                <asp:CheckBox ID="chk_print_memo_all"
                                                    OnCheckedChanged="chk_print_memo_all_CheckedChanged"
                                                    AutoPostBack="true"
                                                    runat="server" />
                                                <span class="custom-toggle-slider rounded-circle" data-label-off="No" data-label-on="Si"></span>
                                            </label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <label class="custom-toggle custom-toggle-yout">
                                                <asp:CheckBox ID="chk_print_memo" OnCheckedChanged="chk_print_memo_CheckedChanged" runat="server" />
                                                <span class="custom-toggle-slider rounded-circle" data-label-off="No" data-label-on="Si"></span>
                                            </label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="ciFunc" HeaderText="CI" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="nombreFunc" HeaderText="Nombre Funcionario" HeaderStyle-CssClass="text-center" />
                                    <asp:BoundField DataField="item" HeaderText="Nro Item" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-bold" />
                                    <asp:BoundField DataField="eo_descripcion" HeaderText="Ubicacion Actual" HeaderStyle-CssClass="text-center" />
                                    <asp:BoundField DataField="tipo_mov" HeaderText="Movimiento" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />

                                    <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:LinkButton CommandName="GetDetail"
                                                Visible="false"
                                                CommandArgument="<%# Container.DataItemIndex %>"
                                                CssClass="btn btn-vimeo btn-sm"
                                                Text="<span class='btn-inner--icon'><i class='fas fa-file fa-lg'></i></span>"
                                                data-toggle="tooltip"
                                                title="Vista Previa"
                                                runat="server" />
                                            <asp:LinkButton CommandName="GetPrint"
                                                CommandArgument="<%# Container.DataItemIndex %>"
                                                CssClass="btn btn-facebook btn-sm"
                                                Text="<span class='btn-inner--icon'><i class='fas fa-print fa-lg'></i></span>"
                                                data-toggle="tooltip"
                                                title="Imprimir"
                                                runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                            <asp:HiddenField ID="hf_cod_tenor" runat="server" />
                            <asp:HiddenField ID="hf_var" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="hf_containerQuill" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="hf_resp" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="hf_respMasiva" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="hf_respMasivaQR" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="hf_qr_value" runat="server" ClientIDMode="Static" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

        <div id="memoRenderHost" aria-hidden="true">
            <div id="customQuill"></div>
        </div>

        <asp:UpdateProgress ID="up1" AssociatedUpdatePanelID="panelFuncionarios" runat="server">
            <ProgressTemplate><div class="load"></div></ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up2" AssociatedUpdatePanelID="panelImpresion" runat="server">
            <ProgressTemplate><div class="load"></div></ProgressTemplate>
        </asp:UpdateProgress>
    </div>

    <script type="text/javascript">
        var quill = null;
        var variablesResporte2 = [];

        (function () {
            "use strict";

            function iniciarRenderizador() {
                if (quill || typeof Quill === "undefined") {
                    return;
                }

                quill = new Quill(document.getElementById("customQuill"), {
                    theme: "snow",
                    readOnly: true,
                    modules: { toolbar: false }
                });

                cargarVariables();
            }

            function cargarVariables() {
                if (!window.jQuery || !$.getJSON) {
                    return;
                }

                $.getJSON("../Content/js/JSON/VariablesQuill.json")
                    .done(function (data) {
                        variablesResporte2 = Array.isArray(data) ? data : [];
                        var hidden = document.getElementById("hf_var");
                        if (hidden) {
                            hidden.value = JSON.stringify(variablesResporte2);
                        }
                    })
                    .fail(function () {
                        variablesResporte2 = [];
                        console.error("No se pudo cargar VariablesQuill.json.");
                    });
            }

            function restaurarVariablesTrasPostback() {
                var hidden = document.getElementById("hf_var");
                if (hidden && variablesResporte2.length > 0) {
                    hidden.value = JSON.stringify(variablesResporte2);
                }
            }

            function parsearJson(valor, valorPredeterminado) {
                if (!valor) {
                    return valorPredeterminado;
                }

                try {
                    return JSON.parse(valor);
                } catch (error) {
                    console.error("El contenido recibido no es JSON válido.", error);
                    return valorPredeterminado;
                }
            }

            // Función auxiliar para decodificar entidades HTML (por si el servidor escapa caracteres)
            function decodeHtmlEntities(texto) {
                if (!texto || typeof texto !== 'string') return texto;
                var elem = document.createElement('textarea');
                elem.innerHTML = texto;
                return elem.value;
            }

            function normalizarDelta(valor) {
                var delta = typeof valor === "string" ? parsearJson(valor, null) : valor;
                if (!delta || !Array.isArray(delta.ops)) {
                    return null;
                }
                // Recorremos las operaciones y decodificamos el texto por si contiene entidades HTML
                if (delta.ops) {
                    delta.ops.forEach(function (op) {
                        if (op.insert && typeof op.insert === 'string') {
                            op.insert = decodeHtmlEntities(op.insert);
                        }
                    });
                }
                return delta;
            }

            function reemplazarMarcadorQr(contenedor, qrSrc) {
                if (!contenedor || !qrSrc) {
                    return false;
                }

                var marcador = "[QR]";
                var walker = document.createTreeWalker(contenedor, NodeFilter.SHOW_TEXT, null, false);
                var nodos = [];
                var nodo;

                while ((nodo = walker.nextNode())) {
                    if (nodo.nodeValue && nodo.nodeValue.indexOf(marcador) >= 0) {
                        nodos.push(nodo);
                    }
                }

                for (var i = 0; i < nodos.length; i++) {
                    var fragmento = document.createDocumentFragment();
                    var partes = nodos[i].nodeValue.split(marcador);

                    for (var j = 0; j < partes.length; j++) {
                        if (partes[j]) {
                            fragmento.appendChild(document.createTextNode(partes[j]));
                        }
                        if (j < partes.length - 1) {
                            var img = document.createElement("img");
                            img.src = qrSrc;
                            img.className = "memo-qr";
                            img.alt = "Código QR";
                            fragmento.appendChild(img);
                        }
                    }

                    nodos[i].parentNode.replaceChild(fragmento, nodos[i]);
                }

                return nodos.length > 0;
            }

            function prepararDisenoMemorandum(editor) {
                if (!editor) { return; }

                var bloques = editor.querySelectorAll("p, h1, h2, h3");
                for (var i = 0; i < bloques.length; i++) {
                    bloques[i].classList.remove("memo-title", "memo-after-header", "memo-reference", "memo-logo-line", "memo-signature-line");
                    var texto = (bloques[i].textContent || "").replace(/\s+/g, " ").trim();
                    var textoMayuscula = texto.toUpperCase();

                    if (textoMayuscula === "MEMORANDUM" || textoMayuscula === "") {
                        bloques[i].classList.add("memo-title");
                    }

                    if (/^REF\s*[.:\-]/i.test(texto)) {
                        bloques[i].classList.add("memo-reference");
                    }

                    if (/\[FECHA_(ASIGNACION|MEMO|MEMORANDUM)\]/i.test(texto)) {
                        bloques[i].classList.add("memo-after-header");
                    }
                }

                var imagenes = editor.querySelectorAll("img:not(.memo-qr)");
                if (imagenes.length > 0) {
                    var logo = imagenes[0];
                    logo.classList.add("memo-logo");
                    // Solo aplicamos flotación y márgenes, NO forzamos width/height
                    logo.style.setProperty("float", "left", "important");
                    logo.style.setProperty("display", "block", "important");
                    logo.style.setProperty("margin", "0 12mm 3mm 3mm", "important");
                    if (logo.parentElement) {
                        logo.parentElement.classList.add("memo-logo-line");
                        logo.parentElement.style.setProperty("text-align", "left", "important");
                    }
                }

                if (imagenes.length > 1) {
                    var firma = imagenes[imagenes.length - 1];
                    firma.classList.remove("memo-logo");
                    firma.classList.add("memo-signature");
                    firma.style.setProperty("float", "none", "important");
                    firma.style.setProperty("display", "inline-block", "important");
                    firma.style.setProperty("margin", "5mm auto 0 auto", "important");
                    if (firma.parentElement) {
                        firma.parentElement.classList.add("memo-signature-line");
                    }
                }
            }

            function generarPagina(deltaValor, qrSrc) {
                var delta = normalizarDelta(deltaValor);
                if (!delta || !quill) {
                    return "";
                }

                quill.setContents(delta, "silent");
                var editor = document.querySelector("#customQuill .ql-editor");
                if (!editor) {
                    return "";
                }

                var copia = editor.cloneNode(true);
                copia.removeAttribute("contenteditable");
                prepararDisenoMemorandum(copia);

                reemplazarMarcadorQr(copia, qrSrc);

                return "<section class='memo-sheet'>" + copia.outerHTML + "</section>";
            }

            function cssDocumento() {
                return "@charset \"UTF-8\";" +
                    "@page{size:A4 portrait;margin:0;}" +
                    "*{box-sizing:border-box;}" +
                    "html,body{margin:0;padding:0;background:#fff;color:#111;-webkit-print-color-adjust:exact;print-color-adjust:exact;}" +
                    ".memo-sheet{width:210mm;margin:0 auto;padding:0;background:#fff;font-family:Arial,Helvetica,sans-serif;font-size:11pt;line-height:1.35;page-break-after:always;break-after:page;}" +
                    ".memo-sheet:last-child{page-break-after:auto;break-after:auto;}" +
                    ".ql-editor{height:auto!important;min-height:0!important;padding:18mm 20mm 17mm!important;overflow:visible!important;white-space:pre-wrap;word-wrap:break-word;color:#111;}" +
                    ".ql-editor p{margin:0;}" +
                    ".ql-editor img{display:inline-block;max-width:100%;height:auto;object-fit:contain;vertical-align:middle;break-inside:avoid;}" +
                    ".ql-editor .memo-qr{width:28mm!important;height:28mm!important;object-fit:contain;}" +
                    ".ql-align-center{text-align:center;}.ql-align-right{text-align:right;}.ql-align-justify{text-align:justify;}" +
                    ".memo-title{margin-bottom:5mm!important;text-align:center!important;font-weight:700;text-decoration:underline;}" +
                    "img.memo-logo{float:left!important;display:block!important;margin:0 12mm 3mm 3mm!important;}" +
                    ".memo-logo-line{text-align:left!important;}" +
                    ".memo-after-header{clear:both!important;padding-top:5mm!important;border-top:3px double #111;}" +
                    ".memo-reference{margin-top:4mm!important;text-align:right!important;font-weight:700;text-decoration:underline;}" +
                    "img.memo-signature{float:none!important;display:inline-block!important;margin:5mm auto 0 auto!important;padding:0!important;border:0!important;}" +
                    ".memo-signature-line{clear:both!important;text-align:center!important;}" +
                    ".ql-indent-1{padding-left:3em;}.ql-indent-2{padding-left:6em;}.ql-indent-3{padding-left:9em;}" +
                    ".ql-editor ol,.ql-editor ul{padding-left:1.5em;}" +
                    ".ql-editor li{padding-left:.25em;}" +
                    ".pagebreak{page-break-after:always;break-after:page;}" +
                    "@media print{.memo-sheet{margin:0;box-shadow:none;}a{color:inherit;text-decoration:none;}}";
            }

            function imprimirCuandoEsteListo(ventana) {
                var imagenes = ventana.document.images;
                var estilos = ventana.document.querySelectorAll("link[rel='stylesheet']");
                var pendientes = [];

                for (var i = 0; i < imagenes.length; i++) {
                    if (!imagenes[i].complete) {
                        (function (imagen) {
                            pendientes.push(new Promise(function (resolve) {
                                imagen.onload = resolve;
                                imagen.onerror = resolve;
                            }));
                        }(imagenes[i]));
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
                    ventana.focus();
                    setTimeout(function () { ventana.print(); }, 200);
                });
            }

            function abrirImpresion(paginas) {
                if (!paginas || paginas.length === 0) {
                    alert("No se pudo generar el memorándum.");
                    return;
                }

                var ventana = window.open("", "_blank", "width=1000,height=800,scrollbars=yes");
                if (!ventana) {
                    alert("El navegador bloqueó la impresión. Habilite las ventanas emergentes para este sitio.");
                    return;
                }

                ventana.document.open();
                ventana.document.write("<!doctype html><html><head><meta charset='utf-8'><title>Memorándum</title>" +
                    "<base href='" + document.baseURI + "'>" +
                    "<link rel='stylesheet' href='../Content/vendor/quill/dist/quill.snow.css'>" +
                    "<style>" + cssDocumento() + "</style></head><body>" +
                    paginas.join("") + "</body></html>");
                ventana.document.close();
                imprimirCuandoEsteListo(ventana);
            }

            window.obtenerQuill = function () { return quill; };

            window.armarQuill = function () {
                var hiddenContenido = document.getElementById("hf_containerQuill");
                var hiddenQr = document.getElementById("hf_respMasivaQR");
                var listaQr = parsearJson(hiddenQr ? hiddenQr.value : "", []);
                var qrSrc = listaQr.length > 0 ? listaQr[0].qr_id : "";
                var pagina = generarPagina(hiddenContenido ? hiddenContenido.value : "", qrSrc);
                abrirImpresion(pagina ? [pagina] : []);
            };

            window.armarRespMasiva = function () {
                var hiddenContenido = document.getElementById("hf_containerQuill");
                var hiddenQr = document.getElementById("hf_respMasivaQR");
                var funcionarios = parsearJson(hiddenContenido ? hiddenContenido.value : "", []);
                var listaQr = parsearJson(hiddenQr ? hiddenQr.value : "", []);
                var paginas = [];

                for (var i = 0; i < funcionarios.length; i++) {
                    var qrSrc = listaQr[i] && listaQr[i].qr_id ? listaQr[i].qr_id : "";
                    var pagina = generarPagina(funcionarios[i].resultado, qrSrc);
                    if (pagina) {
                        paginas.push(pagina);
                    }
                }

                abrirImpresion(paginas);
            };

            /* Compatibilidad con llamadas existentes del proyecto. */
            window.printPaper = function (contentQuill) {
                var hiddenQr = document.getElementById("hf_respMasivaQR");
                var listaQr = parsearJson(hiddenQr ? hiddenQr.value : "", []);
                var qrSrc = listaQr.length > 0 ? listaQr[0].qr_id : "";
                var pagina = generarPagina({ ops: contentQuill || [] }, qrSrc);
                abrirImpresion(pagina ? [pagina] : []);
            };

            window.validaPapel = function () { return false; };
            window.saltoPagina = function () { };

            window.armarCadena = function (valor, variables) {
                if (valor && typeof valor === "object" && valor.image) {
                    return valor;
                }

                var cadena = valor == null ? "" : String(valor);
                variables = variables || [];
                for (var i = 0; i < variables.length; i++) {
                    if (variables[i] && variables[i].contenido != null) {
                        var reemplazo = String(variables[i].contenido);
                        cadena = cadena.split(variables[i].nombreVariable).join(reemplazo);
                    }
                }
                return cadena;
            };

            if (document.readyState === "loading") {
                document.addEventListener("DOMContentLoaded", iniciarRenderizador);
            } else {
                iniciarRenderizador();
            }

            if (window.Sys && Sys.WebForms && Sys.WebForms.PageRequestManager) {
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(restaurarVariablesTrasPostback);
            }
        }());
    </script>
</asp:Content>
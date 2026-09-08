<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="TenorFuncionario.aspx.cs" Inherits="MovimientoPersonal_TenorFuncionario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header bg-light pb-4">
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">&nbsp</h6>
                    </div>
                    <div class="col-lg-6 col-5 text-right">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid mt--6">
        <div class="row justify-content-center">
            <div class="col-lg-8 card-wrapper ct-example">
                <div class="card">
                    <div class="card-header">
                        <h3 class="mb-0"><asp:Literal ID="ltl_descripcion_tenor" runat="server" />  </h3>
                    </div>
                    <div class="card-body">
                        <div class="form-group">
                            <div class="container">
                                <div id="customQuill">
                                </div>
                            </div>
                        </div>
                        <script>
                            let arrayNomVar = [];
                            for (let i in variablesResporte) {
                                arrayNomVar.push(variablesResporte[i].nombreVariable);
                            }
                            var Size = Quill.import('attributors/style/size');
                            Size.whitelist = ['12px', '18px', '19px', '20px', '21px', '22px', '23px', '24px', '26px', '28px', '30px', '34px'];
                            Quill.register(Size, true);

                            var toolbarOptions = [
                                [{ 'placeholder': arrayNomVar }],
                                [{ 'size': ['12px', '18px', '19px', '20px', '21px', '22px', '23px', '24px', '26px', '28px', '30px', '34px'] }],
                                ['bold', 'italic', 'underline', 'strike'],
                                [{ 'color': [] }, { 'background': [] }],
                                [{ align: '' }, { align: 'center' }, { align: 'right' }, { align: 'justify' }],
                                ['image'],
                                [{ 'font': [] }],
                                [{ 'list': 'ordered' }, { 'list': 'bullet' }]
                            ];

                            var options = {
                                theme: 'snow',
                                modules: {
                                    imageResize: {
                                        displaySize: true
                                    },
                                    toolbar: {
                                        container: toolbarOptions,
                                        handlers: {
                                            "placeholder": function (value) {
                                                if (value) {
                                                    const cursorPosition = this.quill.getSelection().index;
                                                    this.quill.insertText(cursorPosition, value);
                                                    this.quill.setSelection(cursorPosition + value.length);
                                                }
                                            }
                                        }
                                    },
                                    formula: false
                                },
                                placeholder: 'Tenor'
                            }

                            var container = document.getElementById('customQuill');
                            var quill = new Quill(container, options);
                            const placeholderPickerItems = Array.prototype.slice.call(document.querySelectorAll('.ql-placeholder .ql-picker-item'));
                            placeholderPickerItems.forEach(item => item.textContent = item.dataset.value);
                            document.querySelector('.ql-placeholder .ql-picker-label').innerHTML = 'Insertar Variable' + document.querySelector('.ql-placeholder .ql-picker-label').innerHTML;

                            function obtenerQuill() {
                                return quill;
                            }
                        </script>
                        <div class="form-group text-right">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:HiddenField ID="hf_containerQuill" runat="server" ClientIDMode="Static" />
                                    <asp:HiddenField ID="hf_resp" runat="server" ClientIDMode="Static" />

                                    <script>
                                        console.log('parseJSONBefore2', hf_containerQuill.value);
                                        var tenorParse = JSON.parse(hf_containerQuill.value);
                                        let arrayVarReport = variablesResporte;
                                        let contenidoVariables = JSON.parse(hf_resp.value);

                                        contenidoVariables = contenidoVariables.Table;

                                        for (let k in arrayVarReport) {
                                            let content = "";
                                            for (let i in contenidoVariables) {
                                                for (let j in contenidoVariables[i]) {
                                                    if (arrayVarReport[k].codigo === j) {
                                                        content = contenidoVariables[i][j];
                                                        if (typeof content === 'string') {
                                                            content = content.trim();
                                                        }
                                                        arrayVarReport[k].contenido = content;
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                        
                                        let arrayText = tenorParse.ops;
                                        for (let i in arrayText) {
                                            arrayText[i].insert = armarCadena(arrayText[i].insert);
                                        }

                                        function armarCadena(pValor = "") {
                                            if (pValor.image !== undefined && pValor.image !== null && pValor.image !== "") {
                                                let cadenaModificar = pValor;
                                                return cadenaModificar;
                                            } else {
                                                let cadenaModificar = pValor;
                                                for (let i in arrayVarReport) {
                                                    cadenaModificar = cadenaModificar.replace(arrayVarReport[i].nombreVariable, arrayVarReport[i].contenido);
                                                }
                                                return cadenaModificar;
                                            }
                                        }

                                        let objArmado = { ops: arrayText };
                                        quill.setContents(objArmado);
                                        $("#ContentPlaceHolder1_modalGuardarTenor").click(function () {
                                            var contentQuill = JSON.stringify(quill.getContents());
                                            console.log('contentQuillContent', quill.getContents());
                                            console.log('contentQuill', contentQuill);
                                            $("#hf_containerQuill").val(contentQuill);

                                        });
                                    </script>

                                    <asp:LinkButton ID="btnAtras" CssClass="btn btn-info" Text="Atrás" runat="server"  OnClick="btnAtras_Click"/>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


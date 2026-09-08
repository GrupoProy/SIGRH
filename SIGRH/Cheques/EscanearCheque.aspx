<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCheque.master" AutoEventWireup="true" CodeFile="EscanearCheque.aspx.cs" Inherits="Cheques_EscanearCheque" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div class="header pb-6" style="margin-top: -4em; margin-left: 3em; width: 81%">
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Registro de Documentos Digitalizados</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid mt--6">
        <div class="row">
            <div class="col-xl-7">
                <div class="card">
                    <div class="card-body">
                        <div class="pb-2">
                            <h2>Subir Imagen</h2>
                            <label for="file-input" class="file-upload w-100">

                                <div class="card" style="cursor: pointer; background: #fff; margin: 0; padding: 0; width: 100%; -webkit-transition: all 0.2s ease; transition: all 0.2s ease; border-radius: 5px; box-shadow: none; box-sizing: border-box; color: #000; background-color: #fff; border: 1px solid #eaeaea;">
                                    <div class="content " style="width: 100%; padding: 16pt 16pt;">
                                        <div class="content" style="text-align: center;">
                                            <i class="ni ni-album-2 ni-2x"></i>
                                        </div>
                                        <div style="font-size: 0.875rem; line-height: 1.571em; color: #666; margin: 1.3rem auto 0; text-align: center; max-width: 85%;">
                                            Seleccione el archivo
                                        </div>
                                    </div>
                                    <input id="file-input" type="file" accept="image/png, image/jpeg, image/jpg">
                                </div>
                            </label>
                        </div>
                        <div class="uploadPreviewParent">
                            <img id="image" alt="Image placeholder" src="" class="img-fluid rounded ">
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-xl-5">
                <div class="row">
                    <div class="col">
                        <div class="card">
                            <!-- Card header -->
                            <div class="row">
                                <div class="form-group col-md-11 ml-3">
                                    <label class="form-control-label">Tipo de Documento:</label>
                                    <asp:DropDownList ID="ddl_tipo_doc" AutoPostBack="true" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                </div>
                            </div>
                            <div class="form-group col-md-4">
                                <label class="form-control-label" for="txt_fecha_doc">Fecha del Documento</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="far fa-calendar-alt"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="txt_fecha_doc" CssClass="form-control datepickerD" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_fecha_doc" ValidationGroup="edit" Display="Dynamic" runat="server" />
                            </div>
                            <div class="form-group col-md-12">
                                <label class="form-control-label" for="txtObservaciones">Observaciones</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="far fa-calendar-alt"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="txtObservaciones" CssClass="form-control" runat="server" />
                                </div>
                            </div>
                            <div class="card-body">
                                <asp:UpdatePanel runat="server">
                                    <contenttemplate>
                                        <div class="pb-2">
                                            <asp:LinkButton ID="guardar_recorte" CssClass="btn btn-success btn-block btn-round btn-icon" Text="<span class='btn-inner--icon'><i class='fas fa-save'></i></span><span class='btn-inner--text'>Guardar Recorte</span>" runat="server" />
                                        </div>
                                        <asp:HiddenField ID="hf_img" runat="server" ClientIDMode="Static" />
                                    </contenttemplate>
                                </asp:UpdatePanel>
                                <img id="imageResult" alt="Image placeholder" src="" class="img-thumbnail img-fluid rounded mx-auto d-block">
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="guardarCambios" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
            <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                <div class="modal-content bg-gradient-dark6">
                    <div class="modal-header">
                    </div>
                    <asp:UpdatePanel runat="server">
                        <contenttemplate>
                            <asp:HiddenField ID="hf_cb_id" runat="server" />
                            <div class="modal-body">
                                <div class="py-3 text-center">
                                    <i class="ni ni ni-album-2 ni-3x"></i>
                                    <h4 class="heading text-dark mt-4">¿Está seguro de guardar los cambios?</h4>
                                </div>
                            </div>
                            <div class="form-group text-center">
                                <asp:LinkButton ID="btn_guardar_cambios" Text="<i class='fas fa-check mr-2'></i>Si" CssClass="btn btn-success" OnClientClick="MostrarMascara(true);" runat="server" />
                                <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>No</button>
                            </div>
                        </contenttemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

    </div>
    <script>
        //let image=document.getElementById("image");let upload=document.querySelector("#file-input");let cropper;let options={aspectRatio:1/1,strict:!1,background:!1,guides:!1,autoCropArea:0.6,rotatable:!1,minCropBoxWidth:50,minCropBoxHeight:50,zoomable:!1,zoomOnWhee:!0,responsive:!0,restore:!0,viewMode:2,cropmove:function(e){let imgSrc=cropper.getCroppedCanvas({}).toDataURL("image/jpeg");imageResult.src=imgSrc;hf_img.value=imgSrc},};upload.addEventListener("change",(e)=>{let width=600;MostrarMascara(!0);if(e.target.files.length){const reader=new FileReader();reader.onload=(e)=>{if(e.target.result){if(cropper!==undefined&&cropper!==null){cropper.destroy();cropper=null;hf_img.value=""}var img=new Image();img.onload=function(){if(img.width>width){var oc=document.createElement("canvas");var octx=oc.getContext("2d");oc.width=img.width;oc.height=img.height;octx.drawImage(img,0,0);while(oc.width*0.5>width){oc.width*=0.5;oc.height*=0.5;octx.drawImage(oc,0,0,oc.width,oc.height)}oc.width=width;oc.height=(oc.width*img.height)/img.width;octx.drawImage(img,0,0,oc.width,oc.height);image.src=oc.toDataURL();cropper=new Cropper(image,options)}else{image.src=img.src;cropper=new Cropper(image,options)}};img.src=event.target.result}};reader.readAsDataURL(e.target.files[0])}MostrarMascara(!1)})

        let image = document.getElementById("image");
        let upload = document.querySelector("#file-input");
        let cropper;
        let options = {
            aspectRatio: 2 / 3,
            strict: !1,
            background: !1,
            guides: !1,
            autoCropArea: 0.95,
            rotatable: !1,
            minCropBoxWidth: 50,
            minCropBoxHeight: 50,
            zoomable: !1,
            zoomOnWhee: !0,
            responsive: !0,
            restore: !0,
            viewMode: 2,
            cropmove: function (e) {
                let imgSrc = cropper.getCroppedCanvas({}).toDataURL("image/jpeg");
                imageResult.src = imgSrc;
                hf_img.value = imgSrc;
            },           
        };

        upload.addEventListener("change", (e) => {
            let width = 1500;
            MostrarMascara(!0);
            if (e.target.files.length) {
                const reader = new FileReader();
                reader.onload = (e) => {
                    if (e.target.result) {
                        if (cropper !== undefined && cropper !== null) {
                            cropper.destroy();
                            cropper = null;
                            hf_img.value = "";
                        }
                        var img = new Image();
                        img.onload = function () {
                            if (img.width > width) {
                                var oc = document.createElement("canvas");
                                var octx = oc.getContext("2d");
                                oc.width = img.width;
                                oc.height = img.height;
                                octx.drawImage(img, 0, 0);
                                while (oc.width * 0.5 > width) {
                                    oc.width *= 0.5;
                                    oc.height *= 0.5;
                                    octx.drawImage(oc, 0, 0, oc.width, oc.height);
                                }
                                oc.width = width;
                                oc.height = (oc.width * img.height) / img.width;
                                octx.drawImage(img, 0, 0, oc.width, oc.height);
                                image.src = oc.toDataURL();
                                cropper = new Cropper(image, options);
                            } else {
                                image.src = img.src;
                                cropper = new Cropper(image, options);
                            }
                        };
                        img.src = e.target.result;
                    }
                };
                reader.readAsDataURL(e.target.files[0]);
            }
            MostrarMascara(!1);
        });
    </script>

                        <%--<div class="row mt--4">
                            <div class="card col-12" runat="server" id="resultado">
                                <div class="card-body">
                                    <asp:UpdatePanel runat="server" ID="panel5">
                                        <contenttemplate>
                                            <asp:GridView ID="GridView1" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" runat="server" DataKeyNames="pdf_id">
                                                <columns>
                                                    <asp:BoundField DataField="pdf_nombre" HeaderText="Documento" />
                                                    <asp:BoundField DataField="pdf_fecha_doc" DataFormatString="{0:d}" HeaderText="Fecha" />
                                                    <asp:BoundField DataField="pdf_observacion" ControlStyle-Width="50px" ItemStyle-Width="50px" HeaderText="OBS." />
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                        <itemtemplate>
                                                            <asp:LinkButton ID="lnkView" runat="server" CommandName="pdf" Text="Ver" CommandArgument="<%# Container.DataItemIndex %>"></asp:LinkButton>
                                                            <asp:LinkButton ID="lnkView1" runat="server" ForeColor="DarkGreen" CommandName="editar" Text="Editar" CommandArgument="<%# Container.DataItemIndex %>"></asp:LinkButton>
                                                            <asp:LinkButton ID="lnkView2" ForeColor="Red" runat="server" CommandName="eliminar" Text="Eliminar" CommandArgument="<%# Container.DataItemIndex %>"></asp:LinkButton>
                                                        </itemtemplate>
                                                    </asp:TemplateField>
                                                </columns>
                                            </asp:GridView>
                                        </contenttemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>--%>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="Puntaje_evaluacion.aspx.cs" Inherits="Evaluacion_puntaje_Puntaje_evaluacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top: -4em; margin-left: 3em; width: 81%">
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Puntaje de la Evaluación</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid mt--6">
        <div class="card bg-default mb-4">
            <div class="row">
                <div class="col-md-12">
                    <div class="card-header bg-default text-center border-0 pt-8 pt-md-4 pb-0 pb-md-4">
                        <h3 class="h1 text-white d-inline-block float-noi mb-0">RESULTADO DE LA EVALUACION DE CONOCIMIENTO GENERAL AL PERSONAL ADMINISTRATIVO DE LA UNIVERSIDAD AMAZONICA DE PANDO</h3>
                    </div>
                </div>
            </div>

            <div class="row">
                
            </div>
            <div class="row">
                <div class="col-xl-11 col-md-11 center">
                    <div class="card card-stats">
                        <div class="card-body">
                            <div class="media align-items-center">
                                <div class="media-body">
                                    <div class="col-12">
                                        <div class="text-center">
                                            <h1 style="font-size: 50px;" class="mb-0">Puntaje</h1>
                                        </div>
                                    </div>
                                    <div class="col-12 text-center">
                                        <h1 id="ID_Puntaje1" style="font-size: 100px;" runat="server"></h1>
                                        <h1 style="font-size: 100px;"><asp:Literal ID="ID_Puntaje" Text="" runat="server" />/100</h1>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>


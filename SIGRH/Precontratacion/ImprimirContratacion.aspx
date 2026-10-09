<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ImprimirContratacion.aspx.cs" Inherits="Precontrataciones_ImprimirContratacion" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel runat="server" ID="PanelImprimirContratacion">
		<ContentTemplate>

			<div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%">
				<div class="container-fluid">
					<div class="header-body">
						<div class="row align-items-center py-4">
							<div class="col-lg-6 col-7">
								<h6 class="h2 text-light d-inline-block mb-0">Impresión de Contratación</h6>
							</div>
						</div>
					</div>
				</div>
			</div>

			<div class="container-fluid mt--6">
				<asp:Literal ID="ltlMensaje" runat="server" />
				<!-- Botón para volver en caso de error -->
				<asp:Button ID="btnVolver" runat="server" Text="Volver a la lista" 
					CssClass="btn btn-secondary mt-3" OnClick="btnVolver_Click" 
					Visible="false" />
			</div>

			<rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="100%" ZoomMode="Percent" ShowBackButton="True" ShowPrintButton="True" ShowExportControls="True">
			</rsweb:ReportViewer>

		</ContentTemplate>
	</asp:UpdatePanel>

	<asp:UpdateProgress AssociatedUpdatePanelID="PanelImprimirContratacion" runat="server">
		<ProgressTemplate>
			<div class="load"></div>
		</ProgressTemplate>
	</asp:UpdateProgress>
</asp:Content>
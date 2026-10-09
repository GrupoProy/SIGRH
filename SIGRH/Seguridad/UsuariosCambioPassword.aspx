<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="UsuariosCambioPassword.aspx.cs" Inherits="Seguridad_UsuariosCambioPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Cambio de Contraseña</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
<div class="container-fluid mt--6">
    <div class="row">
        <div class="col-6 card">

            <div class="card-body">
                <asp:ChangePassword ID="ChangePassword1" UserNameLabelText="Usuario" NewPasswordLabelText="Nueva Contraseña: " ConfirmNewPasswordLabelText="Confirme Nueva Contraseña: " PasswordLabelText="Contraseña: "   runat="server"  OnChangingPassword="ChangePassword1_ChangingPassword"
                    RenderOuterTable="false" NewPasswordRegularExpression="^[\s\S]{3,}$" NewPasswordRegularExpressionErrorMessage="La contraseña debe tener al menos 3 caracteres..." CancelDestinationPageUrl = "~/Index.aspx">
                    <ChangePasswordTemplate >
                        ACTUAL CONTRASEÑA:&nbsp;
<asp:TextBox ID="CurrentPassword" CssClass="form-control" runat="server" TextMode="Password" /><br />

NUEVA CONTRASEÑA:&nbsp;

<asp:TextBox ID="NewPassword" runat="server" CssClass="form-control" TextMode="Password" /><br />

CONFIRMACIÓN:&nbsp;

<asp:TextBox ID="ConfirmNewPassword" CssClass="form-control" runat="server" TextMode="Password" /><br />

<asp:Button ID="ChangePasswordButton" CommandName="ChangePassword" CssClass="btn btn-block btn-info" runat="server" Text="Cambiar" />

<asp:Button ID="CancelButton" CommandName="Cancel" runat="server" Text="Cancelar" CssClass="btn btn-block btn-warning" /><br />

<asp:Literal ID="FailureText" runat="server" EnableViewState="false" /> 
                    </ChangePasswordTemplate>
<SuccessTemplate>

Su contraseña se actualizó correctamente

<asp:Button ID="ContinuePushButton" CommandName="Continue" CssClass="btn btn-block btn-success" runat="server" Text="Continue" />

</SuccessTemplate>                </asp:ChangePassword>
                <br />
                <asp:Label ID="lblMessage" runat="server" />
            </div>
        </div>
    </div>
</div>

</asp:Content>


<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="false" CodeFile="ReprobacionViatico.aspx.vb" Inherits="ControlPersonal_ReprobacionViatico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Objeto" HeaderText="Objeto" />
            <asp:TemplateField HeaderText="Apellidos Paterno">
                <ItemTemplate>
                    <asp:Repeater ID="Repeater1" runat="server" DataSource='<%# Eval("Apellidos") %>'>
                        <ItemTemplate>
                            <%# Container.DataItem %><br />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>


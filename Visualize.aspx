<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Frontend.master" AutoEventWireup="true" CodeFile="Visualize.aspx.cs" Inherits="Visualize" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cpSideBar" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Detalhes"></asp:Label>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" Runat="Server">
    <div class="Conteudo">
        <asp:Label ID="LabelTitulo" runat="server" Text="Label" CssClass="Titulo"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" 
            TextMode="MultiLine" CssClass="CaixaEdicao"></asp:TextBox>
    </div>
</asp:Content>


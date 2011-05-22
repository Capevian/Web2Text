<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Frontend.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpSideBar" Runat="Server">
    <div class="Conteudo">
        <asp:Label ID="LabelTitulo" runat="server" Text="Label" CssClass="Titulo"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" 
            TextMode="MultiLine" CssClass="CaixaEdicao"></asp:TextBox>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpMainContent" Runat="Server">
    <div class="sideCont">
        <asp:Label ID="Label1" runat="server" Text="Detalhes" CssClass="Titulo side"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Username" 
            CssClass="labelTitle"></asp:Label><asp:Label ID="labelUser"
            runat="server" Text="Label" CssClass="labelTitle labelDetail"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Data Arquivação" 
            CssClass="labelTitle"></asp:Label><asp:Label ID="labelData"
            runat="server" Text="Label" CssClass="labelTitle labelDetail"></asp:Label>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Site de Origem"
            CssClass="labelTitle"></asp:Label>
        <br />
            <asp:HyperLink ID="linkWWW" runat="server" Target="_blank" 
                CssClass="labelTitle labelDetail">Link</asp:HyperLink>
        <br />
        <div class="imageButtons">
            <asp:ImageButton ID="dlButton" runat="server" AlternateText=""
                onclick="ImageButton1_Click" src="Styles/Images/fd.gif" Height="15px" Width="15px"/>
        </div>
        <br />            
            <asp:Button ID="Button1" runat="server"
                    Text="Activar Edição" onclick="Button1_Click" />
            
        </div>
</asp:Content>


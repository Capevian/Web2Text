<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Frontend.master" AutoEventWireup="true" CodeFile="Visualize.aspx.cs" Inherits="Visualize" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="menuPrincipal" runat="server">
    <div class="MainMenu">
        <ul>
            <li><a href="Default.aspx">Pesquisa</a></li>
            <li><a href="Edicao.aspx">Edição</a></li>
            <li><a href="Arquivo.aspx" id="arqNav">Arquivo</a></li>
        </ul>
    </div>
</asp:Content>

<%-- CONTEUDO DA BARRA LATERAL --%>
<asp:Content ID="Content3" ContentPlaceHolderID="cpSideBar" runat="server">

    <div class="sideCont">

        <%-- TITULO DA BARRA LATERAL --%>
        <asp:Label ID="Label1" runat="server" Text="Detalhes" CssClass="Titulo side"></asp:Label>
        <br />

        <%-- Username --%>
        <asp:Label ID="Label2" runat="server" Text="Username" 
            CssClass="labelTitle"></asp:Label><asp:Label ID="labelUser"
            runat="server" Text="Label" CssClass="labelTitle labelDetail"></asp:Label>
        <br />

        <%-- Data Arquivacao --%>
        <asp:Label ID="Label3" runat="server" Text="Data Arquivação" 
            CssClass="labelTitle"></asp:Label><asp:Label ID="labelData"
            runat="server" Text="Label" CssClass="labelTitle labelDetail"></asp:Label>
        <br />

        <%-- Site de Origem --%>
        <asp:Label ID="Label4" runat="server" Text="Site de Origem"
            CssClass="labelTitle"></asp:Label>
        <br />
            <asp:HyperLink ID="linkWWW" runat="server" Target="_blank" 
                CssClass="labelTitle labelDetail">Link</asp:HyperLink>
        <br />

        <%-- Seccao de operacoes --%>
        <div class="imageButtons">

            <%--DOWNLOAD DE FICHEIRO--%>
            <span class="space">
                <asp:ImageButton ID="dlButton" 
                            runat="server" 
                            AlternateText="Download"
                            onclick="ImageButton1_Click"  
                            Height="15px" 
                            Width="15px" 
                            ImageUrl="~/Styles/Images/dlb.png" 
                            CssClass="imgIcon" />
                <asp:LinkButton ID="LinkDownload" 
                            runat="server" 
                            onclick="LinkDownload_Click"
                            CssClass="labelTitle labelDetail imgLabel">
                            Download
                </asp:LinkButton>
            </span>
    
            <br />

            <%-- MOVER PARA ZONA DE EDICAO --%>
            <span class="space">
                <asp:ImageButton ID="edButton" 
                                runat="server" 
                                Height="15px" 
                                Width="15px" 
                                CssClass="imgIcon" 
                                ImageUrl="~/Styles/Images/edIcon.png" onclick="edButton_Click" 
                                />
                <asp:LinkButton ID="LinkEdit" 
                            runat="server"
                            CssClass="labelTitle labelDetail imgLabel" onclick="LinkEdit_Click"
                            >
                            Mover para Edição
                </asp:LinkButton>
            </span>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" Runat="Server">
    <div class="Conteudo">
        <asp:Label ID="LabelTitulo" runat="server" Text="Label" CssClass="Titulo"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" 
            TextMode="MultiLine" CssClass="CaixaEdicao"></asp:TextBox>
    </div>
</asp:Content>



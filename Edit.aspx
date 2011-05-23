<%@ Page Title="" validateRequest="false" Language="C#" MasterPageFile="~/MasterPages/Frontend.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<%-- CONTEUDO DA BARRA LATERAL --%>
<asp:Content ID="Content2" ContentPlaceHolderID="cpSideBar" Runat="Server">
    
    <div class="sideCont">
        
        <%-- TITULO DA BARRA LATERAL --%>
        <asp:Label ID="Label1" runat="server" Text="Detalhes" CssClass="Titulo side"></asp:Label>
        <br />

        <%-- Username --%>
        <asp:Label ID="Label2" runat="server" Text="Username" 
            CssClass="labelTitle"></asp:Label><asp:Label ID="labelUser"
            runat="server" Text="Label" CssClass="labelTitle labelDetail"></asp:Label>
        <br />

        <%-- Data de Ultima modificacao --%>
        <asp:Label ID="Label5" runat="server" Text="Última Modificação" 
            CssClass="labelTitle"></asp:Label><asp:Label ID="labelDtMod"
            runat="server" Text="Label" CssClass="labelTitle labelDetail"></asp:Label>
        <br />

        <%-- Site de Origem --%>
        <asp:Label ID="Label4" runat="server" Text="Site de Origem"
            CssClass="labelTitle"></asp:Label>
        <br />
            <asp:HyperLink ID="linkWWW" runat="server" Target="_blank" 
                CssClass="labelTitle labelDetail">Link</asp:HyperLink>
        <br />

        <%-- Data de Acesso ao Link --%>
        <asp:Label ID="Label3" runat="server" Text="Data Acesso Link" 
            CssClass="labelTitle"></asp:Label><asp:Label ID="labelDtAcess"
            runat="server" Text="Label" CssClass="labelTitle labelDetail"></asp:Label>
        <br />

        <%-- Seccao de operacoes --%>
        <div class="imageButtons">
            
            <%--DOWNLOAD DE FICHEIRO--%>
            <span class="space">
            <asp:ImageButton ID="dlButton" 
                            runat="server" 
                            Width="15px" 
                            Height="15px"
                            src="Styles/Images/dlb.png" 
                            CssClass="imgIcon"
                            onclick="dlButton_Click" 
                            /> 
                <asp:LinkButton ID="linkDownload" 
                                runat="server" 
                                CssClass="labelTitle labelDetail imgLabel" Style="display:inline" 
                                onclick="linkDownload_Click">
                                Download
                </asp:LinkButton>
            </span>
            <br />

            <%--LIMPAR HTML--%>
            <span class="space">
            <asp:ImageButton ID="clButton" 
                            runat="server" 
                            Width="15px" 
                            Height="15px"
                            src="Styles/Images/cll.png" 
                            CssClass="imgIcon" 
                            onclick="clButton_Click"
                            /> 
                <asp:LinkButton ID="LinkLimparHTML" 
                                runat="server" 
                                CssClass="labelTitle labelDetail imgLabel" 
                                Style="display:inline" 
                                onclick="LinkLimparHTML_Click">
                                Limpar HTML
                </asp:LinkButton>
            </span>
            <br />

            
            <%--GRAVAR ALTERACOES--%>
            <span class="space">
            <asp:ImageButton ID="svButton" 
                            runat="server" 
                            Width="15px" 
                            Height="15px"
                            src="Styles/Images/fd.gif"
                            CssClass="imgIcon" 
                            onclick="svButton_Click" 
                            /> 
                <asp:LinkButton ID="LinkGravar" 
                                runat="server" 
                                CssClass="labelTitle labelDetail imgLabel" 
                                Style="display:inline" 
                                onclick="LinkGravar_Click">
                                Gravar Alterações
                </asp:LinkButton>
            </span>
            <br />
            
            <%--ARQUIVAR TEXTO--%>
            <span class="space">
            <asp:ImageButton ID="ImageButton1" 
                            runat="server" 
                            Width="15px" 
                            Height="15px"
                            src="Styles/Images/arq.png" 
                            CssClass="imgIcon" 
                            onclick="ImageButton1_Click"
                            />
                <asp:LinkButton ID="LinkArquivar" 
                                runat="server" 
                                CssClass="labelTitle labelDetail imgLabel" 
                                Style="display:inline" 
                                onclick="LinkArquivar_Click">
                                Arquivar Texto
                </asp:LinkButton>
            </span>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpMainContent" Runat="Server">
    <div class="Conteudo">
        <asp:Label ID="LabelTitulo" runat="server" Text="Label" CssClass="Titulo"></asp:Label>
        <asp:TextBox ID="TextBox1" 
                    runat="server" 
                    TextMode="MultiLine" 
                    CssClass="CaixaEdicao"
                    Style="background-color : #F0F0F0">
        </asp:TextBox>
    </div>
</asp:Content>


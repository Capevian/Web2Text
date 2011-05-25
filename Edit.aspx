<%@ Page Title="" validateRequest="false" Language="C#" MasterPageFile="~/MasterPages/Frontend.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function DoOnclick() {
            document.getElementById('<%=HiddenField1.ClientID %>').value = window.showModalDialog("Popup.aspx", "", "dialogHeight: 150px; dialogWidth: 300px;"); ;
        }

        function ShowEditBox() {
            document.getElementById('EditContainerDiv').style.display = "block";
            document.getElementById('<%=LabelTitulo.ClientID %>').style.display = "none";
            document.getElementById('<%=TextBox3.ClientID %>').value = document.getElementById('<%=LabelTitulo.ClientID %>').innerHTML;
            return false;
        }

        function SaveEditBox() {
            document.getElementById('EditContainerDiv').style.display = "none";
            document.getElementById('<%=LabelTitulo.ClientID %>').style.display = "inline";
            document.getElementById('<%=HiddenField1.ClientID %>').value = document.getElementById('<%=TextBox3.ClientID %>').value;
            return false;
        }
        function HideEditBox() {
            document.getElementById('EditContainerDiv').style.display = "none";
            document.getElementById('<%=LabelTitulo.ClientID %>').style.display = "inline";
            return false;
        }
    </script>
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
                            CssClass="imgIcon"
                            onclick="dlButton_Click" 
                            ImageUrl="~/Styles/Images/dlb.png" 
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
                            CssClass="imgIcon" 
                            onclick="clButton_Click"
                            ImageUrl="~/Styles/Images/cll.png" 
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
                            CssClass="imgIcon" 
                            onclick="svButton_Click" 
                            ImageUrl="~/Styles/Images/fd.gif" 
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
                            CssClass="imgIcon" 
                            onclick="ImageButton1_Click"
                            ImageUrl="~/Styles/Images/arq.png" 
                            />
                <asp:LinkButton ID="LinkArquivar" 
                                runat="server" 
                                CssClass="labelTitle labelDetail imgLabel" 
                                Style="display:inline" 
                                onclick="LinkArquivar_Click"
                                OnClientClick="return confirm('Tem a certeza que deseja arquivar o texto?');">
                                Arquivar Texto
                </asp:LinkButton>
            </span>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpMainContent" Runat="Server">
    <div class="Conteudo">
        <div class="Titulo">
        <asp:Label ID="LabelTitulo" style="display: inline;" runat="server" Text="Titulo"></asp:Label>

            <div id="EditContainerDiv" class="ContainerStyle">
                <asp:TextBox ID="TextBox3" runat="server" Width="300px"></asp:TextBox> <br />
                <asp:Button ID="ButtonUpdate" runat="server" Text="Update"/>
                <asp:Button ID="ButtonClose" runat="server" Text="Fechar"/>
            </div>
            
            <asp:HiddenField ID="HiddenField1" runat="server" />
        </div>
        
        <asp:Label ID="Label6" runat="server" style="padding-left:10px; font-size: 10px;" Text="Clique no título para editar"></asp:Label>
        <asp:TextBox ID="TextBox1" 
                    runat="server" 
                    TextMode="MultiLine" 
                    CssClass="CaixaEdicao"
                    Style="background-color : #F0F0F0">
        </asp:TextBox>
    </div>
</asp:Content>


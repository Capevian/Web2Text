<%@ Page Title="Web2Text" Language="C#" MasterPageFile="~/MasterPages/Pesquisa.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%-- HEAD --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<%-- CONTEUDO CENTRAL - ZONA SUPERIOR --%>
<asp:Content ID="Content3" ContentPlaceHolderID="searhBoxContent" runat="server">
    
    <%-- ZONA DE PESQUISA - TOP --%>
    <div style="width:820px; margin-left: auto; margin-right: auto;">
    
        <%-- TEXT-BOX DE PESQUISA --%>
        <asp:TextBox ID="TextBox1" 
                     CssClass="boxPesquisa2"
                     runat="server">
        </asp:TextBox>

        <%-- BOTAO PESQUISAR--%>
        <asp:Button ID="ButtonPesquisar" runat="server" Text="Pesquisar" 
            onclick="ButtonPesquisar_Click" CssClass="botao"
            Style="height: 29px;
                   display: block;
                   float: left;
                   font-size: 14px;
                   margin-left:2px;"/>
    </div>
        <br />
    <%-- ZONA DE PESQUISA - DOWN --%>
    <div style="font-family: 'Lucida Grande',Tahoma,Verdana,Arial,sans-serif;
                font-weight: bold;
                font-size:10px;
                text-align: left;
                margin-left: 10px;
                margin-top: 15px;">

            <%-- CHECKBOX "IGNORAR PAGINAS REJEITADAS" --%>
            <asp:CheckBox ID="CheckBoxRejeitadas" runat="server"
                          Text="Ignorar Páginas Rejeitadas"
                          />
            <%-- CHECKBOX "TODOS OS TERMOS" (NAO USADA) --%>
            <%--<asp:CheckBox ID="CheckBoxTodosTermos" runat="server"
                          Text="Todos os termos"/>--%>

            <%-- BOTAO "LIMPAR HISTORICO" --%>
            <asp:Button ID="Button2" runat="server" Text="Limpar Histórico" 
                        onclick="ButtonLimparHistorico_Click" 
                        Style="font-size: 10px; margin-left:2px;"
                        OnClientClick="return confirm('Tem a certeza que deseja limpar o histórico?');"/>

            <%-- BOTAO LINK "CRAWLER CONFIG." --%>
            <asp:HyperLink ID="LinkCrawlerConfig" runat="server"
                           Text="Crawler Config."
                           Style="float:right; display: block; margin: 5px 12px 0px 2px;" 
                           NavigateUrl="~/Crawler.aspx"></asp:HyperLink>
    </div>

</asp:Content>

<%-- CONTEUDO CENTRAL - ZONA INFERIOR --%>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" Runat="Server">
    
    <%-- LISTA DE RESULTADOS --%>
    <asp:ListView ID="ListView1" 
        runat="server" 
        ItemPlaceholderID="myItemPlaceHolder"
        OnPagePropertiesChanging="listView1_PagePropertiesChanging"
        >
      
        <%-- TEMPLATE GERAL --%>
        <LayoutTemplate>
            <table id="tabPesquisa" width="100%">
                <thead>           
                    <tr>
                        <th>Resultados</th> 
                        <th width="80px"></th>
                    </tr>
                </thead>
                <tbody>
                    <asp:PlaceHolder ID="myItemPlaceHolder" runat="server">
                    </asp:PlaceHolder>
                </tbody>
                <tfoot>
                    <tr>
                        <td></td>
                        <td style="text-align: center;">
                            <asp:Button ID="ButtonEditItems" runat="server" 
                            Text="Seleccionar" 
                            onclick="ButtonEditItems_Click" 
                            Width="85px" 
                            CssClass="botao" />
                        </td>
                    </tr>
                </tfoot>
            </table>
        </LayoutTemplate>
      
        <%--  TEMPLATE DE CADA ITEM --%>
        <ItemTemplate>
            <tr>
                <td onmouseover="this.style.backgroundColor='#B8B8B8'" 
                    onmouseout="this.style.backgroundColor='#E1E1E1'"
                    style="margin-bottom: 8px; border: none"
                    width="500px">
                    
                    <%-- TITULO DO SITE --%>
                    <div class="tbpTitle">
                        
                        <asp:HyperLink ID="linkSite" runat="server" 
                                       Target="_blank" 
                                       NavigateUrl='<%# Eval("LinkContent") %>' 
                                       Text='<%# Eval("Titulo") %>'>
                        </asp:HyperLink>
                        <%--<a href="<%# Eval("LinkContent") %>" target="_blank"><%# Eval("Titulo") %></a>--%>
                    </div>

                    <%-- DESCRICAO DO SITE --%>
                    <div class="tbpDesc">
                        <asp:Label ID="linkIntro" runat="server" 
                                     Text='<%# Eval("LinkDesc") %>'>
                        </asp:Label>
                        <asp:Label ID="linkLiteral" runat="server" 
                                     CssClass="link" 
                                     Text='<%# Eval("LinkContent") %>'>
                        </asp:Label>
                    </div>

                </td>

                <%-- CHECKBOX SELECAO DO LINK --%>
                <td style="border-bottom: none; text-align: center;">
                    <asp:CheckBox ID="chkSelect" runat="server"/>
                </td>
            </tr>            
        </ItemTemplate>

    </asp:ListView>

    <%--Controlo das paginas
      -- PageSize: numero de resultados de cada pagina
      -- PagedControlID: id do componente que e' paginado
    --%>
    <div id="dtPager">
        
    <asp:DataPager ID="DtPager" runat="server" 
            PageSize="5" PagedControlID="ListView1" 
            >
            
            <Fields>
                <%--Link para pagina anterior--%>
                <asp:NextPreviousPagerField ButtonType="Link"
                    PreviousPageText="Anterior"
                    RenderDisabledButtonsAsLabels="true"
                    RenderNonBreakingSpacesBetweenControls="true"
                    ShowFirstPageButton="false"
                    ShowPreviousPageButton="true"
                    ShowNextPageButton="false"
                    ShowLastPageButton="false"/>
                
                <%--Numeros de paginas--%>
                <asp:NumericPagerField ButtonCount="10"
                    CurrentPageLabelCssClass="SelectedPage"
                    ButtonType="Link"
                    RenderNonBreakingSpacesBetweenControls="true"/>
                
                <%--Link para pagina seguinte--%>
                <asp:NextPreviousPagerField ButtonType="Link"
                    NextPageText="Próxima"
                    RenderDisabledButtonsAsLabels="true"
                    ShowFirstPageButton="false"
                    ShowPreviousPageButton="false"
                    ShowNextPageButton="true"
                    ShowLastPageButton="false" />
                
                <%--Lista de numeros para escolher pagina--%>
                <%--<asp:TemplatePagerField>
                    <PagerTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" 
                            OnSelectedIndexChanged="ddlPage_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </PagerTemplate>
                </asp:TemplatePagerField> --%>

            </Fields>
        </asp:DataPager>
    </div>
    <asp:Label ID="LabelResultados" runat="server" Text=""></asp:Label>
    
</asp:Content>


<%@ Page Title="Web2Text - Textos em Edição" Language="C#" MasterPageFile="~/MasterPages/Frontend.master" AutoEventWireup="true" CodeFile="Edicao.aspx.cs" Inherits="Edicao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function setbg(textId,setColor) 
        {
            document.getElementById(textId).style.backgroundColor=setColor;
        }
    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cpSideBar" runat="server">

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="menuPrincipal" runat="server">
    <div class="MainMenu">
        <ul>
            <li><a href="Default.aspx">Pesquisa</a></li>
            <li><a href="Edicao.aspx" id="ediNav">Edição</a></li>
            <li><a href="Arquivo.aspx">Arquivo</a></li>
        </ul>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" Runat="Server">
    
    <%-- Conteudo principal: Lista de Textos --%>    
    <div class="Conteudo">
    
    <asp:ListView ID="ListView1" 
        runat="server" 
        ItemPlaceholderID="myItemPlaceHolder"
        OnPagePropertiesChanging="listView1_PagePropertiesChanging"
        OnDataBound="listView1_DataBound">
      
        <LayoutTemplate>
            <table id="tabArquivo" width="100%">
                <thead>           
                    <tr>
                        <th>
                            <asp:LinkButton ID="LinkOrderTitulo" 
                                            Text="Título" 
                                            OnClick="sortTituloClick"
                                            runat="server"></asp:LinkButton>
                        </th> 
                        <th>
                            <asp:LinkButton ID="LinkOrderData" 
                                            Text="Data de Modificação" 
                                            OnClick="sortDataClick"
                                            runat="server"></asp:LinkButton>
                        </th>
                        <th></th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <asp:PlaceHolder ID="myItemPlaceHolder" runat="server">
                    </asp:PlaceHolder>
                </tbody>
            </table>
        </LayoutTemplate>
      
        <ItemTemplate>
            <tr>
                <td><a href="Edit.aspx?id=<%# Eval("IdTexto") %>"><%# Eval("Titulo") %></a></td>
                <td align="center"><%# Eval("DtMod") %></td>
                <td align="center"> 
                    <asp:LinkButton ID="LinkButton1" 
                                    runat="server"
                                    Text = "Download"
                                    OnCommand="linkDownloadClick"
                                    CommandArgument = '<%# Eval("IdTexto") %>'>
                    </asp:LinkButton>
                </td>
                <td align="center">
                    <asp:LinkButton ID="LinkRemover" 
                                runat="server" 
                                OnCommand="clicklinkRemover"
                                CommandArgument='<%# Eval("IdTexto") %>' 
                                Text="Remover"
                                OnClientClick="return confirm('Tem a certeza que deseja remover o texto?');">
                    </asp:LinkButton>
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
            PageSize="15" PagedControlID="ListView1">
            
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
                <asp:TemplatePagerField>
                    <PagerTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" 
                            OnSelectedIndexChanged="ddlPage_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </PagerTemplate>
                </asp:TemplatePagerField>

            </Fields>
        </asp:DataPager>
    </div>
    </div>
</asp:Content>


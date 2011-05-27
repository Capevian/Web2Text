<%@ Page Title="Web2Text" Language="C#" MasterPageFile="~/MasterPages/Pesquisa.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="searhBoxContent" runat="server">
        
        <asp:TextBox ID="TextBox1" 
                     CssClass="boxPesquisa2"
                     runat="server">
        </asp:TextBox>

        <asp:Button ID="Button1" runat="server" Text="Pesquisar" 
            onclick="Button1_Click" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" Runat="Server">
    
    <asp:ListView ID="ListView1" 
        runat="server" 
        ItemPlaceholderID="myItemPlaceHolder"
        OnPagePropertiesChanging="listView1_PagePropertiesChanging"
        OnDataBound="listView1_DataBound">
      
        <LayoutTemplate>
            <table id="tabPesquisa" width="100%">
                <thead>           
                    <tr>
                        <th>Resultados</th> 
                        <th style="text-align:center;">Selecção</th>
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
                <td style="margin-bottom: 8px; border: none">
                    <div class="tbpTitle">
                        <a href="<%# Eval("LinkContent") %>"><%# Eval("Titulo") %></a>
                    </div>
                    <div class="tbpDesc">
                        <%# Eval("LinkDesc") %>
                        <span class="link"><%# Eval("LinkContent") %></span>
                    </div>
                </td>
                <td style="border-bottom: none;">Seleccionar</td>
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
            OnPreRender="DataPager1_PreRender">
            
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

</asp:Content>


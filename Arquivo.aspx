﻿<%@ Page Title="Web2Text : Arquivo" Language="C#" MasterPageFile="~/MasterPages/Frontend.master" AutoEventWireup="true" CodeFile="Arquivo.aspx.cs" Inherits="Arquivo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cpSideBar" runat="server">
    <asp:TextBox ID="TextBox1" runat="server" Width="94px"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Pesquisar" 
        onclick="Button1_Click" />
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
        Height="14px">
        <asp:ListItem Selected="True" Value="0">Pesquisa todos os termos</asp:ListItem>
        <asp:ListItem Value="1">Algum dos termos</asp:ListItem>
        </asp:RadioButtonList>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" Runat="Server">
    <div class="Conteudo">
    <asp:ListView ID="ListView1" runat="server" 
        ItemPlaceholderID="myItemPlaceHolder"
        OnPagePropertiesChanging="listView1_PagePropertiesChanging"
        OnDataBound="listView1_DataBound" >
      
        <LayoutTemplate>
            <table id="tabarquivo" width="100%">
                <thead>           
                    <tr>
                        <th>
                            <asp:LinkButton ID="LinkButton3" 
                                            runat="server"
                                            Text="Título">
                            </asp:LinkButton> 
                        </th>
                        <th>Data Arquivação</th>
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
                <td><a href="Visualize.aspx?id=<%# Eval("IdTexto") %>"><%# Eval("Titulo") %></a></td>
                <td><%# Eval("DataArq") %></td>
                <td>
                    <asp:LinkButton ID="LinkButton2" 
                                    runat="server"
                                    Text = "Download"
                                    OnCommand="linkDownloadClick"
                                    CommandArgument = '<%# Eval("IdTexto") %>'
                                    >
                    </asp:LinkButton>
                </td>
                <td>
                    <asp:LinkButton ID="LinkButton1" 
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
    </div>
</asp:Content>




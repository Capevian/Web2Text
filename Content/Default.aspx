<%@ Page Title="Web2Text" Language="C#" MasterPageFile="~/MasterPages/Frontend.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" Runat="Server">
    <h1>Hi there visitor and welcome to Planet Wrox</h1>
    <p class="Introduction">We&#39;re glad you&#39;re paying a visit to
        <a href="http://www.PlanetWrox.com">www.PlanetWrox.com</a>, 
            the coolest music community site on the Internet.
    </p>
    <p>You can <a href="../Login.aspx">log in</a> here</p>
<p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource1" 
        EmptyDataText="There are no data records to display.">
        <Columns>
            <asp:BoundField DataField="idTexto" HeaderText="idTexto" 
                SortExpression="idTexto" />
            <asp:BoundField DataField="Titulo" HeaderText="Titulo" 
                SortExpression="Titulo" />
            <asp:BoundField DataField="Texto" HeaderText="Texto" SortExpression="Texto" />
            <asp:BoundField DataField="Intro" HeaderText="Intro" SortExpression="Intro" />
            <asp:BoundField DataField="DataArq" HeaderText="DataArq" 
                SortExpression="DataArq" />
            <asp:BoundField DataField="username" HeaderText="username" 
                SortExpression="username" />
            <asp:BoundField DataField="Link" HeaderText="Link" SortExpression="Link" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:web2textConnectionString1 %>" 
        ProviderName="<%$ ConnectionStrings:web2textConnectionString1.ProviderName %>" 
        SelectCommand="SELECT [idTexto], [Titulo], [Texto], [Intro], [DataArq], [username], [Link] FROM [Arquivo]">
    </asp:SqlDataSource>
</p>

</asp:Content>


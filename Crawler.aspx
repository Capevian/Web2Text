<%@ Page Title="Crawler Configuration" Language="C#" MasterPageFile="~/MasterPages/Pesquisa.master" AutoEventWireup="true" CodeFile="Crawler.aspx.cs" Inherits="Crawler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="searhBoxContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpMainContent" Runat="Server">
    
     <asp:Label ID="Label3" runat="server" Text="Configuração do Crawler" CssClass="Titulo side"></asp:Label>
        <br />
    <div>
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow>
                <asp:TableCell Style="text-align: right;">
                    <asp:Label ID="Label4" runat="server" Text="Modo Pesquisa"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                        <asp:ListItem Value="0">Bing</asp:ListItem>
                        <asp:ListItem Value="1">Crawler</asp:ListItem>
                    </asp:RadioButtonList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Style="text-align:  right;">
                    <asp:Label ID="Label1" runat="server" Text="Número de Links Semente" ></asp:Label> 
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxNlinks" runat="server" Width="40px" Style="margin-right:10px"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                        ErrorMessage="Introduza um número maior que 1" 
                                        MaximumValue="100" MinimumValue="1" Type="Integer" 
                                        ControlToValidate="TextBoxNlinks" CssClass="ErrorMessage">
                    </asp:RangeValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Style="text-align: right;">
                    <asp:Label ID="Label2" runat="server" Text="Profundidade de Pesquisa do Crawler"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxDepth" runat="server" Width="40px" Style="margin-right:10px"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator2" runat="server" 
                                        ErrorMessage="Introduza um número maior que 1" 
                                        MaximumValue="100" MinimumValue="1" Type="Integer" 
                                        ControlToValidate="TextBoxDepth" CssClass="ErrorMessage">
                    </asp:RangeValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" Style="text-align:right;">
                    <asp:Button ID="Button1" runat="server" 
                                Text="Gravar alterações"
                                OnClick="ButtonGravar_Click"
                                />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>        
    </div>
</asp:Content>


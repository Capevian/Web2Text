<%@ Page Title="Web2Text - Login" Language="C#" MasterPageFile="~/Account/Account.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Account_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="searhBoxContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpMainContent" Runat="Server">
    
    <div style="padding-top:20px; text-align:center;">
        <asp:Label ID="Label1" runat="server" Text="" CssClass="ErrorMessage"></asp:Label>

        <asp:Login ID="Login1" runat="server" BackColor="#EFF3FB" 
                   BorderColor="#B5C7DE" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" 
                   FailureText="A sua tentativa de Login não foi bem sucedida. Tente novamente." 
                   Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" 
                   onauthenticate="Login1_Authenticate" 
                   PasswordRequiredErrorMessage="É necessário escrever a Password." 
                   RememberMeText="Lembrar" UserNameLabelText="Nome de Utilizador"
                   UserNameRequiredErrorMessage="É necessário escrever o nome de utilizador." 
                   RememberMeSet="True"
                   Style="margin: 0 auto; 
                          margin-bottom: 10px;
                          margin-top: 10px;">
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" 
                              BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
            <TextBoxStyle Font-Size="0.8em" />
            <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.9em" 
                            ForeColor="White" />
        </asp:Login>
    
        <asp:HyperLink ID="HyperLink1" runat="server" 
                       NavigateUrl="~/Account/Register.aspx" 
                       Style="font-size:11px;">Registe-se aqui!</asp:HyperLink>            
    </div>
</asp:Content>


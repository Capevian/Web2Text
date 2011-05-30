<%@ Page Title="Login" Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login</title>
    <link href="../Styles/style.css" rel="stylesheet" type="text/css" />   
</head>
<body>
    <form id="form1" runat="server">
        <div id="PageWrapper">
            <div id="Header"><a id="A1" href="~/" runat="server"></a></div>
            <div id="MenuWrapper">
                <div class="MainMenu">
                </div>
                <div style="clear: left;"></div>
            </div>
            <div id="MainContentPesquisa">
                <asp:Login ID="Login1" runat="server" BackColor="#EFF3FB" 
                    BorderColor="#B5C7DE" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" 
                    FailureText="A sua tentativa de Login não foi bem sucedida. Tente novamente." 
                    Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" 
                    onauthenticate="Login1_Authenticate" 
                    PasswordRequiredErrorMessage="É necessário escrever a Password." 
                    RememberMeText="Lembrar" UserNameLabelText="Nome de Utilizador" 
                    UserNameRequiredErrorMessage="É necessário escrever o nome de utilizador.">
                        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                        <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" 
                            BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
                        <TextBoxStyle Font-Size="0.8em" />
                        <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.9em" 
                        ForeColor="White" />
                </asp:Login>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Account/Register.aspx">Registe-se aqui!</asp:HyperLink>
            </div>
            <div id="Footer" style="font-size: 10px;" >
            &copy; Capevian Team - Universidade do Minho 2011</div>
        </div>
    </form>
</body>
</html>



<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Account.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Account_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="searhBoxContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpMainContent" Runat="Server">
    <table cellpadding="0" cellspacing="4" 
           style="background-color: #EFF3FB;
                  border-color:#B5C7DE;
                  border-width:1px;
                  border-style:Solid;
                  border-collapse:collapse;
                  margin: 0 auto;
                  margin-bottom: 10px;
                  margin-top: 20px;
                  width: 90%">
        <tr>
            <td>
                <table style="width:100%">
                    
                    <%-- Titulo : REGISTO --%>
                    <tr>
                        <td align="center"
                            style="color:White; background-color:#507CD1; font-size:0.9em; font-weight:bold;" 
                            colspan="3">
                            Registo
                        </td>
                    </tr>

                    <%-- Username --%>
                    <tr>
                        
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
                        </td>
                        
                        <td>
                            <asp:TextBox ID="tbUsername" runat="server" 
                                         Style="font-size:0.9em;" Width="200px"></asp:TextBox>  
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                        ErrorMessage="Introduza o seu username" 
                                                        CssClass="ErrorMessage" 
                                                        Text="*" 
                                                        ControlToValidate="tbUsername">
                            </asp:RequiredFieldValidator>
                        </td>
                        
                        <td width="230px">
                            
                        </td>

                    </tr>

                    <%-- E-Mail --%>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label3" runat="server" Text="E-mail"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tbEmail1" runat="server" Style="font-size:0.9em;" 
                                Width="200px"></asp:TextBox>  
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                        ErrorMessage="Introduza o seu E-mail"
                                                        Text="*" CssClass="ErrorMessage" ControlToValidate="tbEmail1">
                            </asp:RequiredFieldValidator>
                        </td>
                        <td width="230px">
                            
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                            ErrorMessage="E-mail inválido"
                                                            ControlToValidate="tbEmail1" 
                                                            CssClass="ErrorMessage" 
                                                            
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>

                    <%-- Re-Escrever E-Mail --%>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label5" runat="server" Text="Re-escreva E-mail"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tbEmail2" runat="server" Style="font-size:0.9em;" 
                                         Width="200px">
                            </asp:TextBox>  
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                        ErrorMessage="Confirme o seu E-mail"
                                                        Text="*" CssClass="ErrorMessage" ControlToValidate="tbEmail2">
                            </asp:RequiredFieldValidator>
                        </td>
                        <td width="230px">
                            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                                  ErrorMessage="Os dois e-mails não coincidem" 
                                                  CssClass="ErrorMessage" ControlToCompare="tbEmail1" 
                                                  ControlToValidate="tbEmail2"></asp:CompareValidator>
                        </td>
                    </tr>
                    
                    <%-- Password --%>
                    <tr>
                        
                        <td align="right">
                            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                        </td>
                        
                        <td>
                            <asp:TextBox ID="tbPass1" runat="server" Style="font-size:0.9em;" 
                                TextMode="Password" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                        ErrorMessage="Introduza a sua Password"
                                                        Text="*" CssClass="ErrorMessage" ControlToValidate="tbPass1">
                            </asp:RequiredFieldValidator>
                        </td>

                        <td width="230px">
                        </td>

                    </tr>

                    <%-- Re-Escrever Password --%>
                    <tr>
                        
                        <td align="right">
                            <asp:Label ID="Label4" runat="server" Text="Re-escreva a Password"></asp:Label>
                        </td>
                        
                        <td>
                            <asp:TextBox ID="tbPass2" runat="server" Style="font-size:0.9em;" 
                                TextMode="Password" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                        ErrorMessage="Confirme a sua Password"
                                                        Text="*" CssClass="ErrorMessage" ControlToValidate="tbPass2">
                            </asp:RequiredFieldValidator>
                        </td>
                        
                        <td width="230px">
                            

                            <asp:CompareValidator ID="CompareValidator2" runat="server" 
                                                  ErrorMessage="As duas passwords não coincidem" 
                                                  CssClass="ErrorMessage" ControlToCompare="tbPass1" 
                                                  ControlToValidate="tbPass2"></asp:CompareValidator>
                        </td>

                    </tr>

                    <%-- BOTAO REGISTAR --%>
                    <tr>
                        
                        <td align="left" colspan="3">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                CssClass="ErrorMessage" HeaderText="Corrija os seguintes problemas:" 
                                ShowMessageBox="True" ShowSummary="False" />
                        </td>
                        
                    </tr>

                    <tr>
                        <td align="right">
                            <asp:Button ID="Button1" runat="server" Text="Registar" 
                                onclick="Button1_Click" />
                        </td>
                        <td colspan="2">
                            <asp:Label ID="fatalError" runat="server" Text="" CssClass="ErrorMessage"></asp:Label>
                        </td>
                    </tr>

                </table>
            </td>
        </tr>
    </table>
    <div style="text-align:center;">
        <asp:HyperLink ID="HyperLink1" runat="server" 
                       NavigateUrl="~/Account/Login.aspx">
            Voltar atrás
        </asp:HyperLink>
    </div>
</asp:Content>

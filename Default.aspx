<%@ Page Title="Web2Text" Language="C#" MasterPageFile="~/MasterPages/Frontend.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" Runat="Server">
<p>Ola fixe</p>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label><asp:Label ID="Label2"
        runat="server" Text=""></asp:Label>
    <asp:Button ID="Button1"
        runat="server" Text="Button" onclick="Button1_Click" />
</asp:Content>


<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Popup.aspx.cs" Inherits="Popup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function DoOnclick(arg) {
            if (arg.value == "Enter a value...") {
                alert("Do some kind of validation...");
                return false; // Make sure the user changes the value
            } else {
                window.returnValue = arg.value;
            }
            window.close();
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <strong>Novo título</strong><br />
        <input id="Text1" type="text" value="" /><br />
        <input id="Button1" type="button" value="Alterar" onclick="DoOnclick(Text1);" />
        </div>
    </form>
</body>
</html>

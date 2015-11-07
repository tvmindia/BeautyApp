<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadImages.aspx.cs" Inherits="BeautyAppWebServices.UploadImages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left: 40px">
        <div style="border:solid;border-color:teal;border-radius:10px;position:fixed;left:30%;top:25%">
    <table style="width:500px;height:300px;text-align:center;font-family:'Segoe UI';font-size:large">
        <tr><td style="width:50%"> Select Table</td><td style="width:50%"> <asp:DropDownList ID="ddlTable" runat="server"  Font-Names ="Segoe UI" Font-Size="Large">
        </asp:DropDownList></td></tr>
         <tr><td> Select Key</td><td>  <asp:DropDownList ID="ddlKey" runat="server" Font-Names ="Segoe UI" Font-Size="Large">
        </asp:DropDownList></td></tr>
         <tr><td colspan="2"> <asp:FileUpload ID="FileUpload1" runat="server"  Font-Names ="Segoe UI" Font-Size="Large"/></td></tr>
           <tr><td colspan="2">
               <asp:Button ID="Button1" runat="server" Text="Update"  Font-Names ="Segoe UI" Font-Size="Large"/></td></tr>
    </table>
    
    </div>
    </div>
    </form>
</body>
</html>

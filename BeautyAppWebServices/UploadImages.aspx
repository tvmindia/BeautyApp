<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadImages.aspx.cs" Inherits="BeautyAppWebServices.UploadImages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left: 40px;text-align:center">
            <div style="text-align: left; font-family: 'Segoe UI'; font-size: large;left:30%;position:fixed">
                <asp:RadioButton ID="rdMasters" Text="Masters" runat="server" Checked="true" GroupName="1" OnCheckedChanged="rdMasters_CheckedChanged" AutoPostBack="true"/><br />
                 <asp:RadioButton ID="rdProvidersnService" Text="Providers & services" runat="server"  GroupName="1" OnCheckedChanged="rdProvidersnService_CheckedChanged" AutoPostBack="true" />
                <br /> <asp:RadioButton ID="rdProvidersnStyle" Text="Providers & Styles" runat="server"  GroupName="1" OnCheckedChanged="rdProvidersnStyle_CheckedChanged" AutoPostBack="true"/>
            </div>
            <br />
            <table>
                <tr>

                    <td>
                        <div style="border: solid; border-color: teal; border-radius: 10px; width: 400px;position:fixed;top:25%;left:30%" id="divmasters" runat="server" visible="true">

                            <table style="width: 400px; height: 300px; text-align: center; font-family: 'Segoe UI'; font-size: large">
                                <tr>
                                    <td colspan="2">Masters</td>
                                </tr>
                                <tr>
                                    <td style="width: 50%">Select Table</td>
                                    <td style="width: 50%">
                                        <asp:DropDownList ID="ddlTable" runat="server" Font-Names="Segoe UI" Font-Size="Large" Width="90%" AutoPostBack="true" OnSelectedIndexChanged="ddlTable_SelectedIndexChanged">
                                            <asp:ListItem>Provider</asp:ListItem>
                                            <asp:ListItem>Services</asp:ListItem>
                                            <asp:ListItem>Styles</asp:ListItem>

                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td>Select Key</td>
                                    <td>
                                        <asp:DropDownList ID="ddlKey" runat="server" Font-Names="Segoe UI" Font-Size="Large" Width="90%">
                                            <asp:ListItem>Select a key</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:FileUpload ID="fumaster" runat="server" Font-Names="Segoe UI" Font-Size="Large" /></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btnmaster" runat="server" Text="Update" Font-Names="Segoe UI" Font-Size="Large" OnClick="btnmaster_Click" /></td>
                                </tr>
                            </table>

                        </div>

                    </td>
                    <td>
                        <div style="border: solid; border-color: teal; border-radius: 10px; width: 400px;position:fixed;top:25%;left:30%" runat="server" visible="false" id="divProvidersNServices">

                            <table style="width: 400px; height: 300px; text-align: center; font-family: 'Segoe UI'; font-size: large">
                                <tr>
                                    <td colspan="2">Provider and Service</td>
                                </tr>
                                <tr>
                                    <td style="width: 50%">Select Provider</td>
                                    <td style="width: 50%">
                                        <asp:DropDownList ID="ddlProvider" runat="server" Font-Names="Segoe UI" Font-Size="Large" Width="90%" AutoPostBack="true" OnSelectedIndexChanged="ddlProvider_SelectedIndexChanged">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td>Select Service</td>
                                    <td>
                                        <asp:DropDownList ID="ddlService" runat="server" Font-Names="Segoe UI" Font-Size="Large" Width="90%">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:FileUpload ID="fuProviderService" runat="server" Font-Names="Segoe UI" Font-Size="Large" /></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btnProviderService" runat="server" Text="Update" Font-Names="Segoe UI" Font-Size="Large" /></td>
                                </tr>
                            </table>

                        </div>

                    </td>
                                        <td>
                        <div style="border: solid; border-color: teal; border-radius: 10px; width: 400px;position:fixed;top:25%;left:30%" runat="server" visible="false" id="divProvidersnStyles" >

                            <table style="width: 400px; height: 300px; text-align: center; font-family: 'Segoe UI'; font-size: large">
                                <tr>
                                    <td colspan="2">Provider and Style</td>
                                </tr>
                                <tr>
                                    <td style="width: 50%">Select Provider</td>
                                    <td style="width: 50%">
                                        <asp:DropDownList ID="ddlProvider1" runat="server" Font-Names="Segoe UI" Font-Size="Large" Width="90%" AutoPostBack="true" OnSelectedIndexChanged="ddlTable_SelectedIndexChanged">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td>Select Service</td>
                                    <td>
                                        <asp:DropDownList ID="ddlService1" runat="server" Font-Names="Segoe UI" Font-Size="Large" Width="90%" AutoPostBack="true" OnSelectedIndexChanged="ddlService1_SelectedIndexChanged">
                                        </asp:DropDownList></td>
                                </tr>
                                   <tr>
                                    <td>Select Style</td>
                                    <td>
                                        <asp:DropDownList ID="ddlStyle" runat="server" Font-Names="Segoe UI" Font-Size="Large" Width="90%">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:FileUpload ID="fuProviderStyle" runat="server" Font-Names="Segoe UI" Font-Size="Large" /></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btnProviderStyle" runat="server" Text="Update" Font-Names="Segoe UI" Font-Size="Large" OnClick="btnProviderStyle_Click" /></td>
                                </tr>
                            </table>

                        </div>

                    </td>

                </tr>
            </table>

        </div>
    </form>
</body>
</html>

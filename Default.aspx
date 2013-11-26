<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="FreeChartTools.Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        table
        {
            border-collapse: collapse;
            overflow-x: auto;
            float: left;
        }
        table, th, td
        {
            border: 1px solid gray;
        }
        .hidden
        {
            visibility: collapse;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <table>
            <tr>
                <td colspan="2" style="text-align: center; font-weight: bold;">
                    Chart solution parameters
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Literal runat="server">Please enter amount of charts:</asp:Literal>
                </td>
                <td align="center">
                    <asp:TextBox ID="tbChartsCount" runat="server">20</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Literal runat="server">Please enter count of points:</asp:Literal>
                </td>
                <td align="center">
                    <asp:TextBox ID="tbDataPointsCount" runat="server">1000</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Literal runat="server">Please enter maximal axes value:</asp:Literal>
                </td>
                <td align="center">
                    <asp:TextBox ID="tbMaxValue" runat="server">5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Literal runat="server">Please enter image resolution:</asp:Literal>
                </td>
                <td align="center">
                    Width:
                    <asp:TextBox ID="tbWidth" Width="30" runat="server">400</asp:TextBox>
                    Height:
                    <asp:TextBox ID="tbHeight" Width="30" runat="server">300</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Literal runat="server">Select charting solution:</asp:Literal>
                </td>
                <td>
                    <asp:DropDownList ID="dblFactories" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="center">
                    <asp:Button runat="server" OnClick="BtnClick" ID="btnCheck" Text="Check" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center; font-weight: bold;">
                    Performance comparison parameters
                </td>
            </tr>
            <tr>
                <td>
                    Please select amount of iterations:
                </td>
                <td align="center">
                    <asp:TextBox runat="server" ID="tbIterationsCount">5</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="center">
                    <asp:Button runat="server" ID="btnCompareAll" OnClick="BtnCompareAllClick" Text="Compare all solutions" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Repeater ID="rpCheckAllResults" runat="server" Visible="False">
                        <HeaderTemplate>
                            <table>
                                <thead>
                                    <tr>
                                        <th>
                                            №
                                        </th>
                                        <th>
                                            Chart type
                                        </th>
                                        <th>
                                            Number of iterations
                                        </th>
                                        <th>
                                            Summary time (s)
                                        </th>
                                        <th>
                                            Average (s)
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# Container.ItemIndex + 1 %>
                                </td>
                                <td>
                                    <%# Eval("FactoryName")%>
                                </td>
                                <td>
                                    <%# Eval("Iterations")%>
                                </td>
                                <td>
                                    <%# Eval("Time")%>
                                </td>
                                <td>
                                    <%# Eval("Average")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody> </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </table>
    </div>
    <div style="clear: both;">
        &nbsp;</div>
    <asp:Label ID="lblTimeSpan" runat="server"></asp:Label>
    <input type="hidden" id="hdLastTimeSpan" value="0" runat="server" />
    <input type="hidden" id="hdIterate" value="false" runat="server" />
    <input type="hidden" id="hdTime" value="" runat="server" />
    <asp:Button runat="server" ID="btnIterateHidden" OnClick="BtnIterateHiddenClick"
        CssClass="hidden" />
    <asp:Panel ID="chartPanel" runat="server">
    </asp:Panel>
    <script type="text/javascript">
        var hdTime = document.getElementById('<%=hdTime.ClientID %>');

        function StoreTime() {
            var now = new Date();
            var ticks = now.getTime();
            hdTime.setAttribute('value', ticks);
        }

        var btnCheck = document.getElementById('<%=btnCheck.ClientID %>');
        var btnCompareAll = document.getElementById('<%=btnCompareAll.ClientID %>');
        var lastTimeSpan = document.getElementById('<%=hdLastTimeSpan.ClientID %>');
        var hdIterate = document.getElementById('<%=hdIterate.ClientID %>');
        btnCheck.addEventListener('click', StoreTime, false);
        btnCompareAll.addEventListener('click', StoreTime, false);

        function OnImagesLoaded() {
            var now = new Date();
            var ticks = now.getTime();
            var startTime = hdTime.getAttribute('value');
            if (startTime) {
                var generatingTime = (ticks - startTime);
                var s = generatingTime / 1000;
                var span = document.getElementById('<%=lblTimeSpan.ClientID %>');
                lastTimeSpan.setAttribute('value', s);
                if (hdIterate.getAttribute('value') == 'True') {
                    StoreTime();
                    document.getElementById('<%=btnIterateHidden.ClientID%>').click();
                } else {
                    span.innerHTML = "Generating " +
                    document.getElementById('<%=tbChartsCount.ClientID %>').getAttribute('value') + " charts each with " +
                    document.getElementById('<%=tbDataPointsCount.ClientID %>').getAttribute('value') + " points takes " + s + ' seconds';                    
                }
            }
        }

        var loadedImages = 0;
        var failedImages = 0;
        var images = document.images;
        var imageCount = images.length;

        function loaded() {
            loadedImages++;
            if (loadedImages == imageCount) {
                OnImagesLoaded();
            }
            else if ((loadedImages + failedImages) == imageCount) {
                OnImagesLoaded();
            }
        }

        function failed() {
            failedImages++;
            if ((loadedImages + failedImages) == imageCount) {
                OnImagesLoaded();
            }
        }
        for (var i = 0; i < imageCount; i++) {
            images[i].onload = loaded;
            images[i].onerror = failed;
        }
    </script>
</asp:Content>

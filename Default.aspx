<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="FreeChartTools._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table>
        <tr>
            <td style="width: 500px;">
                <asp:Literal runat="server">Please enter charts count:</asp:Literal>
            </td>
            <td style="width: 500px;">
                <asp:TextBox ID="tbChartsCount" runat="server">20</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 500px;">
                <asp:Literal runat="server">Please enter data points count:</asp:Literal>
            </td>
            <td style="width: 500px;">
                <asp:TextBox ID="tbDataPointsCount" runat="server">1000</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 500px;">
                <asp:Literal runat="server">Please enter max data point value:</asp:Literal>
            </td>
            <td style="width: 500px;">
                <asp:TextBox ID="tbMaxValue" runat="server">1000</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 500px;">
                <asp:Literal ID="Literal1" runat="server">Please chart resolution</asp:Literal>
            </td>
            <td style="width: 500px;">
                Width: <asp:TextBox ID="tbWidth" runat="server">400</asp:TextBox>
                Height: <asp:TextBox ID="tbHeight" runat="server">300</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 500px;">
                <asp:Literal runat="server">Select chart source:</asp:Literal>
            </td>
            <td style="width: 500px;">
                <asp:DropDownList ID="dblFactories" runat="server" />
            </td>
        </tr>
    </table>
    <asp:Button runat="server" OnClick="BtnClick" ID="btClick" Text="Check" />
    <br />
    <asp:Label ID="lblTimeSpan" runat="server"></asp:Label>
    <input type="hidden" id="hdTime" value="" runat="server" />
    <asp:Panel ID="chartPanel" runat="server">
    </asp:Panel>
    <script type="text/javascript">
        var button = document.getElementById('<%=btClick.ClientID %>');
        var hdTime = document.getElementById('<%=hdTime.ClientID %>');
        button.addEventListener('click', function () {
            var now = new Date();
            var ticks = now.getTime();
            hdTime.setAttribute('value', ticks);
        } , false);

        function OnImagesLoaded() {
            var now = new Date();
            var ticks = now.getTime();
            var startTime = hdTime.getAttribute('value');
            if (startTime) {
                var generatingTime = (ticks - startTime);
                var s = generatingTime / 1000;
                var span = document.getElementById('<%=lblTimeSpan.ClientID %>');
                span.innerHTML = "Generating " + 
                    document.getElementById('<%=tbChartsCount.ClientID %>').getAttribute('value') + " charts each with " + 
                    document.getElementById('<%=tbDataPointsCount.ClientID %>').getAttribute('value') + " points takes " + s + ' seconds';
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

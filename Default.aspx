<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ChartTests._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table>
        <tr>
            <td style="width: 500px;">
                <asp:Literal ID="Literal3" runat="server">Please enter charts count:</asp:Literal>
            </td>
            <td style="width: 500px;">
                <asp:TextBox ID="tbChartsCount" runat="server">20</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 500px;">
                <asp:Literal ID="Literal1" runat="server">Please enter data points count:</asp:Literal>
            </td>
            <td style="width: 500px;">
                <asp:TextBox ID="tbDataPointsCount" runat="server">1000</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 500px;">
                <asp:Literal ID="Literal2" runat="server">Please enter max data point value:</asp:Literal>
            </td>
            <td style="width: 500px;">
                <asp:TextBox ID="tbMaxValue" runat="server">1000</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 500px;">
                <asp:Literal ID="Literal4" runat="server">Select chart source:</asp:Literal>
            </td>
            <td style="width: 500px;">
                <asp:DropDownList ID="dblFactories" runat="server" />
            </td>
        </tr>
    </table>
    <asp:Button runat="server" OnClick="BtnClick" ID="btCLick" Text="Check" />
    <br />
    <asp:Label ID="ltrTimeSpan" runat="server"></asp:Label>
    <input type="hidden" id="hdTime" value="" runat="server" />
    <asp:Panel ID="chartPanel" runat="server">
    </asp:Panel>
    <script type="text/javascript">
        var button = document.getElementById('MainContent_btCLick');
        button.addEventListener('click', function () {
            var now = new Date();
            var ticks = now.getTime();
            var hiddenelement = document.getElementById('MainContent_hdTime');
            hiddenelement.setAttribute('value', ticks);
        } , false);

        function OnImagesLoaded() {
            var now = new Date();
            var ticks = now.getTime();
            var startTime = document.getElementById('MainContent_hdTime').getAttribute('value');
            if (startTime) {
                var generatingTime = (ticks - startTime);
                var s = generatingTime / 1000;
                var span = document.getElementById('MainContent_ltrTimeSpan');
                span.innerHTML = span.innerHTML + s + ' seconds';
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

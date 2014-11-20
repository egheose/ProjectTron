<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="download.aspx.cs" Inherits="DownloadApp.download" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div style="float:left">
        <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="FROM:" Theme="MetropolisBlue">
        </dx:ASPxLabel>
        <dx:ASPxDateEdit ID="ASPxDateEdit1" runat="server" EnableTheming="True" Theme="SoftOrange">
        </dx:ASPxDateEdit>
    </div>
    <div style="float:left">
            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="TO:" Theme="MetropolisBlue">
            </dx:ASPxLabel>
            <dx:ASPxDateEdit ID="ASPxDateEdit2" runat="server" EnableTheming="True" Theme="SoftOrange">
            </dx:ASPxDateEdit>
    </div>
    
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="ASPxLabel">
    </dx:ASPxLabel>
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <dx:ASPxButton ID="btnDownload" runat="server" OnClick="btnDownload_Click" Text="Download" Theme="SoftOrange">
    </dx:ASPxButton>
</asp:Content>

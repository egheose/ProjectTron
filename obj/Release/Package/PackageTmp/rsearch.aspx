<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="rsearch.aspx.cs" Inherits="DownloadApp.rsearch" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <p>
        <div class="rsearch">
            <asp:TextBox ID="txtRsearch" runat="server"></asp:TextBox><br />
            <dx:ASPxHyperLink NavigateUrl="#" ID="advSearch" runat="server" Text="Advanced Search"></dx:ASPxHyperLink><br /><br />
            
    <dx:ASPxButton ID="btnRsearch" runat="server" Text="SEARCH" >
    </dx:ASPxButton>
        </div>
    </p>
</asp:Content>

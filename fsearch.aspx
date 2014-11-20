<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="fsearch.aspx.cs" Inherits="DownloadApp.fsearch" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
     <p>
            <div class="search-heading"><h2>FILE SEARCH PORTAL</h2></div>
        <div class="search">
            <dx:ASPxTextBox ID="tbConfirmPassword" Password="true" runat="server" Width="600px" ></dx:ASPxTextBox>
            <dx:ASPxHyperLink NavigateUrl="#" ID="advSearch" runat="server" Text="Advanced Search"></dx:ASPxHyperLink><br /><br />
     <nav>
            <dx:ASPxButton ID="btnRsearch" runat="server" Text="SEARCH" Width="300px" >
            </dx:ASPxButton>
     </nav>       
    
        </div>
    </p>
</asp:Content>

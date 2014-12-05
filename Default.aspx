<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeBehind="Default.aspx.cs" Inherits="DownloadApp._Default" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="top-wrapper">
    <nav class="dashboard-heading">
        <h1>DASHBOARD</h1>
        <div class="report">
            <div class="order-box-text">
                <span><%--LAST STATUS--%></span>
                <H3>
                    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                </H3>
            </div>
        </div>
        <div class="report1">
            <div class="order-box-text">
                <span><%--LAST DOWNLOAD DATE--%></span><H3>
                <H3>
                    <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
                </H3>
            </div>
        </div>
        <div class="report2">
            <div class="order-box-text">
                <span><%--FILENAME--%></span>
                <H3>
                    <asp:Label ID="lblFilename" runat="server" Text=""></asp:Label>
                </H3>
            </div>
        </div>
        <%--<div class="report3">
            <div class="order-box-text">
                <span>LAST DOWNLOAD DATE</span>
                <H3>
                    <asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label>
                </H3>
            </div>
        </div>--%>
    </nav>
        <hr style="align-content:center;width:70%;" />
</div>
</asp:Content>
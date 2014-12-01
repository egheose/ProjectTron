<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="fsearch.aspx.cs" Inherits="DownloadApp.fsearch" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
     
            <div class="search-heading"><h2>FILE SEARCH PORTAL<br />
                <hr style="align-content:center;width:400px; float:left; left:550px;position:relative" /></h2>
            </div>
        <div class="search">
            <dx:ASPxTextBox ID="tbSearch" runat="server" Width="600px" ></dx:ASPxTextBox>
            <dx:ASPxHyperLink NavigateUrl="#" ID="advSearch" runat="server" Text="Advanced Search"></dx:ASPxHyperLink><br /><br />
     <nav>
            <dx:ASPxButton ID="btnRsearch" runat="server" Text="SEARCH" Width="300px" OnClick="btnRsearch_Click" >
            </dx:ASPxButton>
     </nav>       
    
        </div>
         
            <div class="search-result">
                <asp:GridView ID="resultGrid" PageSize="10" EmptyDataText="No data available." AllowPaging="true" AutoGenerateColumns="true"
                    runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnPageIndexChanging="resultGrid_PageIndexChanging">
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>

                <asp:Label ID="lblNotFound" runat="server" Text=""></asp:Label>
                
            </div>
</asp:Content>

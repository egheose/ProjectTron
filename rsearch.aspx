<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="rsearch.aspx.cs" Inherits="DownloadApp.rsearch" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit"  Namespace="AjaxControlToolkit"  TagPrefix="cc1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="content2">
        <asp:Panel ID="SearchPanel" runat="server">
            <div class="search-heading"><h2>RECORD SEARCH PORTAL<br />
                <hr style="align-content:center;width:400px; float:left; left:550px;position:relative" />
                <h2></h2>
                </h2>
            </div>
            <div class="search">
                <dx:ASPxTextBox ID="tbSearch" runat="server" Width="600px"></dx:ASPxTextBox>
                <asp:LinkButton runat="server" Text="Advanced Search" ID="lnkbtnAdvSearch" OnClick="lnkbtnAdvSearch_Click"></asp:LinkButton><br /><br />
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
            </asp:Panel>
        <!-- Advanced Search -->
        <asp:Panel runat="server" ID="advSearchPanel" Visible="false">
            <div class="search-heading"><h2>ADVANCED RECORD SEARCH<br />
                <hr style="align-content:center;width:400px; float:left; left:550px;position:relative" /></h2>
            </div>
            <div class="search">
                <asp:Table runat="server" BorderStyle="Dotted" BorderWidth="1px" CssClass="search-table">
                    <asp:TableRow>
                        <asp:TableCell>
                             <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Width="200px" NullText="SURNAME"></dx:ASPxTextBox>
                        </asp:TableCell>
                        <asp:TableCell>
                            <dx:ASPxTextBox ID="ASPxTextBox2" runat="server" Width="200px" NullText="FIRSTNAME"></dx:ASPxTextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <dx:ASPxTextBox ID="ASPxTextBox3" runat="server" Width="200px" NullText="MIDDLENAME">  </dx:ASPxTextBox>
                        </asp:TableCell>
                        <asp:TableCell>
                            <dx:ASPxTextBox ID="ASPxTextBox4" runat="server" Width="200px" NullText="OCCUPATION"></dx:ASPxTextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <dx:ASPxTextBox ID="ASPxTextBox5" runat="server" Width="200px" NullText="PHONE NUMBER"></dx:ASPxTextBox>
                        </asp:TableCell>
                        <asp:TableCell>
                            <dx:ASPxTextBox ID="ASPxTextBox6" runat="server" Width="200px" NullText="LOCAL GOVERNMENT"></dx:ASPxTextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <dx:ASPxTextBox ID="ASPxTextBox7" runat="server" Width="200px" NullText="DATE OF BIRTH"></dx:ASPxTextBox>
                        </asp:TableCell>
                        <asp:TableCell>
                            <dx:ASPxTextBox ID="ASPxTextBox8" runat="server" Width="200px" NullText="COMPANY"></dx:ASPxTextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">            
                            <asp:LinkButton runat="server" Text="Normal Search" ID="LinkButton1" OnClick="linkBtnNormalSearch_Click"></asp:LinkButton>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
             <nav>
                    <dx:ASPxButton ID="btnAdvSearch" runat="server" Text="SEARCH" Width="300px" >
                    </dx:ASPxButton>
             </nav>       
                </div>
        </asp:Panel>
    </div>
</asp:Content>

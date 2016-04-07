<%@ Page Title="" Language="C#" MasterPageFile="~/Zadaci.Master" AutoEventWireup="true" CodeBehind="Http404ErrorPage.aspx.cs" Inherits="Zadaci.ErrorPages.Http404ErrorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <asp:Label runat="server" CssClass="ErrorPageStyle" Text="<%$ Resources:Resource, Http404ErrorText %>"></asp:Label>     
    </p>
</asp:Content>

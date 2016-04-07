<%@ Page Title="" Language="C#" MasterPageFile="~/Zadaci.Master" AutoEventWireup="true" CodeBehind="DefaultRedirectErrorPage.aspx.cs" Inherits="Zadaci.ErrorPages.DefaultRedirectErrorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <asp:Label runat="server" CssClass="ErrorPageStyle" Text="<%$ Resources:Resource, GeneralErrorText %>"></asp:Label>
      </p>
</asp:Content>

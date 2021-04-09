<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UI.Web.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .modalContainer {
            display: block;
            position: absolute;
            z-index: 1;
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
            background-repeat: no-repeat;
            background-size: cover;
            background-position: bottom;
            opacity : 0.9;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel runat="server" class="modalContainer" id="modal" BackImageUrl="~/img/fondo_utn.jpg">
    </asp:Panel>
</asp:Content>

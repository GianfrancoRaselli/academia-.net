<%@ Page Title="Reporte Materias" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ReporteMaterias.aspx.cs" Inherits="UI.Web.ReporteMaterias" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <rsweb:ReportViewer ID="ReportViewerMaterias" runat="server" BackColor="" ClientIDMode="AutoID" Height="632px" 
        HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" 
        LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" 
        PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" 
        SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" 
        SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" 
        ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" 
        ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" 
        ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" 
        ToolBarItemPressedHoverBackColor="153, 187, 226" Width="900px" style="margin: auto;">
        <LocalReport ReportPath="ReportMaterias.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSourceMaterias" Name="DataSetMaterias" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSourceMaterias" runat="server" SelectMethod="GetAll" TypeName="Business.Logic.MateriaLogic"></asp:ObjectDataSource>
</asp:Content>
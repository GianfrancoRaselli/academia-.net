<%@ Page Title="Reporte Alumnos" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ReporteAlumnos.aspx.cs" Inherits="UI.Web.ReporteAlumnos" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <rsweb:ReportViewer ID="ReportViewerAlumnos" runat="server" BackColor="" ClientIDMode="AutoID" Height="632px" 
        HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" 
        LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" 
        PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" 
        SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" 
        SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" 
        ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" 
        ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" 
        ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" 
        ToolBarItemPressedHoverBackColor="153, 187, 226" Width="900px" style="margin: auto;" ExportContentDisposition="AlwaysAttachment">
        <LocalReport ReportPath="ReportAlumnos.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSourceAlumnos" Name="DataSetAlumnos" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSourceAlumnos" runat="server" SelectMethod="GetAlumnos" TypeName="Business.Logic.PersonaLogic"></asp:ObjectDataSource>
</asp:Content>
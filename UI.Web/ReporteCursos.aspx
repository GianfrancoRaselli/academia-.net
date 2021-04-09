<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ReporteCursos.aspx.cs" Inherits="UI.Web.ReporteCursos" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <rsweb:ReportViewer ID="ReportViewerCursos" runat="server" BackColor="" ClientIDMode="AutoID" Height="632px" 
        HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" 
        LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" 
        PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" 
        SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" 
        SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" 
        ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" 
        ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" 
        ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" 
        ToolBarItemPressedHoverBackColor="153, 187, 226" Width="900px" style="margin: auto;">
        <LocalReport ReportPath="ReportCursos.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSourceCursos" Name="DataSetCursos" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSourceCursos" runat="server" TypeName="Business.Logic.CursoLogic" SelectMethod="GetAll"></asp:ObjectDataSource>   
</asp:Content>

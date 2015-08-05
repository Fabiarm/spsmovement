<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" Src="~/_controltemplates/15/SPS.Movement/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" Src="~/_controltemplates/15/SPS.Movement/InputFormSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" Src="~/_controltemplates/15/SPS.Movement/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="Header" Src="~/_controltemplates/15/SPS.Movement/Header.ascx" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Export.aspx.cs" Inherits="SPS.Movement.Layouts.SPS.Movement.Export" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <wssuc:Header runat="server" />
    <script type="text/javascript" src="/_layouts/15/ScriptResx.ashx?culture=<SharePoint:EncodedLiteral runat='server' text='<%$Resources:wss,language_value%>' EncodeMethod='HtmlEncode' />&name=SPS.Movement"></script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <table cellpadding="0" width="100%" cellspacing="0" border="0">
        <wssuc:InputFormSection ID="InputFormSection1" Collapsible="false" runat="server">
            <template_title>
                <SharePoint:EncodedLiteral ID="ltlTitleSecurity" runat="server" Text="<%$Resources:SPS.Movement,Export_Page_SPIncludeSecurity%>" EncodeMethod='HtmlEncode' />
            </template_title>
            <template_description>&nbsp;</template_description>
            <template_inputformcontrols>
                <asp:DropDownList ID="ddlSecurity" runat="server">
                    <asp:ListItem Selected="True" Value="All" Text="<%$Resources:SPS.Movement,Export_Page_SPIncludeSecurity_All%>"></asp:ListItem>
                    <asp:ListItem Value="None" Text="<%$Resources:SPS.Movement,Export_Page_SPIncludeSecurity_None%>"></asp:ListItem>
                </asp:DropDownList>
            </template_inputformcontrols>
        </wssuc:InputFormSection>
        <wssuc:InputFormSection ID="InputFormSection2" Collapsible="false" runat="server">
            <template_title>
                <SharePoint:EncodedLiteral ID="ltlTitleVersions" runat="server" Text="<%$Resources:SPS.Movement,Export_Page_SPIncludeVersions%>" EncodeMethod='HtmlEncode' />
            </template_title>
            <template_description>&nbsp;</template_description>
            <template_inputformcontrols>
                <asp:DropDownList ID="ddlVersions" runat="server">
                    <asp:ListItem Value="All" Text="<%$Resources:SPS.Movement,Export_Page_SPIncludeVersions_All%>"></asp:ListItem>
                    <asp:ListItem Selected="True" Value="CurrentVersion" Text="<%$Resources:SPS.Movement,Export_Page_SPIncludeVersions_CurrentVersion%>"></asp:ListItem>
                    <asp:ListItem Value="LastMajor" Text="<%$Resources:SPS.Movement,Export_Page_SPIncludeVersions_LastMajor%>"></asp:ListItem>
                    <asp:ListItem Value="LastMajorAndMinor" Text="<%$Resources:SPS.Movement,Export_Page_SPIncludeVersions_LastMajorAndMinor%>"></asp:ListItem>
                </asp:DropDownList>
            </template_inputformcontrols>
        </wssuc:InputFormSection>
        <wssuc:InputFormSection ID="InputFormSection3" Collapsible="false" runat="server">
            <template_title>
                <SharePoint:EncodedLiteral ID="ltlTitleMethodType" runat="server" Text="<%$Resources:SPS.Movement,Export_Page_SPExportMethodType%>" EncodeMethod='HtmlEncode' />
            </template_title>
            <template_description>&nbsp;</template_description>
            <template_inputformcontrols>
                <asp:DropDownList ID="ddlMethodType" runat="server">
                    <asp:ListItem Selected="True" Value="ExportAll" Text="<%$Resources:SPS.Movement,Export_Page_SPExportMethodType_All%>"></asp:ListItem>
                    <asp:ListItem Value="ExportAll" Text="<%$Resources:SPS.Movement,Export_Page_SPExportMethodType_Changes%>"></asp:ListItem>
                </asp:DropDownList>
            </template_inputformcontrols>
        </wssuc:InputFormSection>
        <wssuc:InputFormSection ID="InputFormSection4" Collapsible="false" runat="server">
            <template_title>
                <SharePoint:EncodedLiteral ID="ltlTitleFileCompression" runat="server" Text="<%$Resources:SPS.Movement,Export_Page_FileCompression%>" EncodeMethod='HtmlEncode' />
            </template_title>
            <template_description>&nbsp;</template_description>
            <template_inputformcontrols>
                <asp:CheckBox ID="chbFileCompression" runat="server" Checked="false" />
            </template_inputformcontrols>
        </wssuc:InputFormSection>
        <wssuc:ButtonSection runat="server" ShowStandardCancelButton="false">
            <template_buttons>
                    <asp:Button ID="btnExport" runat="server" Text="Export" CssClass="ms-ButtonHeightWidth" OnClick="btnExport_Click" />
            </template_buttons>
        </wssuc:ButtonSection>
    </table>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server">
</asp:Content>

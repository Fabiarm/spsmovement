<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" %>
<SharePoint:ScriptLink ID="ScriptLink1" Name="SP.js" runat="server" OnDemand="true" LoadAfterUI="true" Localizable="false" />
<script type="text/javascript" src="/_layouts/15/ScriptResx.ashx?culture=<SharePoint:EncodedLiteral runat='server' text='<%$Resources:wss,language_value%>' EncodeMethod='HtmlEncode' />&name=SPS.Movement"></script>
<script>
    function ShowExportDlg(prms) {
        var options = {
            url: SP.Utilities.Utility.getLayoutsPageUrl('SPS.Movement/Export.aspx?' + prms),
            title: Res.export_Page_Title,
            allowMaximize: false,
            autoSize: true,
            showClose: true,
            dialogReturnValueCallback: function (dialogResult) {
                SP.UI.ModalDialog.RefreshPage(dialogResult)
            }
        };
        SP.SOD.execute('sp.ui.dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
    };
</script>
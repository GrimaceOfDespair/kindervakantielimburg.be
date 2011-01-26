<%@ Page MasterPageFile="../Shared/Site.Master" Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage<RegistrationPage>" %>
<asp:Content ID="cpc" ContentPlaceHolderID="PostContent" runat="server">
	<%=Html.DisplayContent(m => m.Registration)%>
</asp:Content>
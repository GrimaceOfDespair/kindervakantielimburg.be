<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.master" AutoEventWireup="true" 
	Inherits="System.Web.Mvc.ViewPage<GalleryItem>" Title="" %>
<%@ Import Namespace="N2.Collections"%>
<%@ Import Namespace="N2.Templates.Mvc.Models.Pages"%>

<asp:Content ContentPlaceHolderID="ContentAndSidebar" runat="server">
	<% Html.RenderAction<NavigationController>(c => c.Breadcrumb()); %>
	
	<%=Html.DisplayContent(m => m.Title)%>
	
	<img alt="<%=Model.Title%>" src="<%=ResolveUrl(Model.ResizedImageUrl)%>" />
	
	<%=Html.DisplayContent(m => m.Text)%>
</asp:Content>
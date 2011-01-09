﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
	Inherits="System.Web.Mvc.ViewPage<Event>" %>

<asp:Content ID="cpc" ContentPlaceHolderID="TextContent" runat="server">
	<%= Html.DisplayContent(m => m.Title)%>
	<%= Html.DisplayContent("EventDateString").WrapIn("span", new { @class = "date" }) %>
	<%= Html.DisplayContent(m => m.Introduction).WrapIn("p", new { @class = "introduction" }) %>
	<%= Html.DisplayContent(m => m.Text)%>
</asp:Content>
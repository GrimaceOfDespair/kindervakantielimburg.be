<%@ Control Language="C#" AutoEventWireup="true"
	Inherits="System.Web.Mvc.ViewUserControl<AbstractSearchBox>" %>
<%@ Import Namespace="N2.Templates.Mvc.Models.Parts"%>
<div class="uc">
	<h<%=Model.TitleLevel%>><%=Model.Title%></h<%=Model.TitleLevel%>>
	<div class="sidelist">
	<%using(Html.BeginForm<SearchController>(c => c.Index(null, null), FormMethod.Get)){%>
		<%=Html.TextBox("q")%>
		<%=Html.SubmitButton("", Model.Title)%>
	<%} %>
	</div>
</div>
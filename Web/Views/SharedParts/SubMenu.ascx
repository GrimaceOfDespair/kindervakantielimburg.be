<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl<SubMenu>" %>
<%@ Import Namespace="N2.Templates.Mvc.Models.Parts"%>

<%if(Model.Visible){%>
<div class="uc">
	<h4><a href="<%=Model.ParentItem.Url%>"><%=Model.ParentItem.Title%></a></h4>
	<div class="box">
		<div class="inner">
			<ul class="subMenu menu">
			<%foreach(var item in Model.Items){%>
				<li class="<%=item == Model.CurrentItem ? "current" : String.Empty %>"><a href="<%=item.Url%>"><%=item.Title%></a></li>
			<%}%>
			</ul>
		</div>
	</div>
</div>
<%}%>
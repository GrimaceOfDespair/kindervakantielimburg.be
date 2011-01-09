<%@ Page MasterPageFile="..\Framed.Master" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="N2.Edit.Versions.Default" Title="Previous Versions" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="Head" runat="server">
	<link rel="stylesheet" href="../../Resources/Css/Versions.css" type="text/css" />
</asp:Content>
<asp:Content ID="ContentToolbar" ContentPlaceHolderID="Toolbar" runat="server">
	<asp:HyperLink ID="hlCancel" runat="server" CssClass="cancel command" meta:resourceKey="hlCancel">cancel</asp:HyperLink>
</asp:Content>
<asp:Content ID="ContentContent" ContentPlaceHolderID="Content" runat="server">
	<asp:CustomValidator ID="cvVersionable" runat="server" Text="This item is not versionable." CssClass="validator info" meta:resourceKey="cvVersionable" Display="Dynamic" />
	<asp:GridView ID="gvHistory" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" CssClass="gv" AlternatingRowStyle-CssClass="alt" UseAccessibleHeader="true" BorderWidth="0" OnRowCommand="gvHistory_RowCommand" OnRowDeleting="gvHistory_RowDeleting">
		<Columns>
			<asp:TemplateField HeaderText="Version" meta:resourceKey="v" ItemStyle-CssClass="Version">
				<ItemTemplate>
					<%# IsPublished(Container.DataItem) ? "<img src='../../Resources/icons/bullet_star.png' alt='published' />" : string.Empty%>
					<%# ((N2.ContentItem)Container.DataItem)["FuturePublishDate"] is DateTime ? "<img src='../../Resources/icons/clock.png' title='" + ((N2.ContentItem)Container.DataItem)["FuturePublishDate"] + "'/>" : ""%>
					<span title='<%# Eval("State") %>'><%# ((N2.ContentItem)Container.DataItem).VersionIndex + 1 %></span>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="Title" meta:resourceKey="title" >
				<ItemTemplate>
				<a href="<%# GetPreviewUrl((N2.ContentItem)Container.DataItem) %>" title="<%# Eval("ID") %>"><img alt="icon" src='<%# VirtualPathUtility.ToAbsolute((string)Eval("IconUrl")) %>'/><%# string.IsNullOrEmpty(((N2.ContentItem)Container.DataItem).Title) ? "(untitled)" : ((N2.ContentItem)Container.DataItem).Title %></a></ItemTemplate>
			</asp:TemplateField>
			<asp:BoundField HeaderText="ID" DataField="ID" meta:resourceKey="id" />
			<asp:BoundField HeaderText="Published" DataField="Published" meta:resourceKey="published" />
			<asp:BoundField HeaderText="Expired" DataField="Expires" meta:resourceKey="expires" />
			<asp:BoundField HeaderText="Saved by" DataField="SavedBy" meta:resourceKey="savedBy" />
			<asp:TemplateField>
				<ItemTemplate>
					<asp:HyperLink runat="server" ID="hlEdit" meta:resourceKey="hlEdit" Text="Edit" NavigateUrl='<%# Engine.EditManager.GetEditExistingItemUrl((N2.ContentItem)Container.DataItem) %>' />
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField>
				<ItemTemplate>
					<asp:LinkButton runat="server" ID="btnPublish" meta:resourceKey="btnPublish" Text="Publish" CommandName="Publish" CommandArgument='<%# Eval("ID") %>' Visible="<%# IsVisible(Container.DataItem) %>" />
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField>
				<ItemTemplate>
					<asp:LinkButton runat="server" ID="btnDelete" meta:resourceKey="btnDelete" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("ID") %>' Visible="<%# IsVisible(Container.DataItem) %>"
						OnClientClick="return confirm('Are you sure you want to Delete this version?');" />
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	</asp:GridView>
</asp:Content>

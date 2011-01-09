using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using N2.Engine;

namespace N2.Templates.Mvc.Services
{
	/// <summary>
	/// Adds SEO title, keywords and description to the page.
	/// </summary>
	[Service(typeof(IViewConcern))]
	public class SeoConcern : IViewConcern
	{
		public const string HeadTitle = "HeadTitle";
		public const string MetaKeywords = "MetaKeywords";
		public const string MetaDescription = "MetaDescription";

		#region IViewConcern Members

		public void Apply(ContentItem item, Page page)
		{
			if (page.Header == null)
				return;

			page.Title = item[HeadTitle] as string ?? item.Title;
			AddMeta(page, "keywords", item[MetaKeywords] as string);
			AddMeta(page, "description", item[MetaDescription] as string);
		}

		private void AddMeta(Page page, string name, string content)
		{
			if (!string.IsNullOrEmpty(content))
			{
				HtmlGenericControl meta = new HtmlGenericControl("meta");
				meta.Attributes["name"] = name;
				meta.Attributes["content"] = content;
				page.Header.Controls.Add(meta);
			}
		}

		#endregion
	}
}
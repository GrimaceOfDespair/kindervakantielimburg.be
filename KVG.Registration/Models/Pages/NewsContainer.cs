using System.Collections.Generic;
using System.Linq;
using KVG.Core.Models.Pages;
using N2;
using N2.Collections;
using N2.Integrity;
using N2.Web.Mvc;
using N2.Definitions;

namespace KVG.Registration.Models.Pages
{
	[PageDefinition("News Container",
		Description = "A list of news. News items can be added to this page.",
		SortOrder = 150,
		IconUrl = "~/Content/Img/newspaper_link.png")]
	[RestrictParents(typeof (IStructuralPage))]
	[SortChildren(SortBy.PublishedDescending)]
	public class NewsContainer : AbstractContentPage
	{
		public IList<News> NewsItems
		{
			get { return GetChildren(new TypeFilter(typeof (News))).OfType<News>().ToList(); }
		}
	}
}
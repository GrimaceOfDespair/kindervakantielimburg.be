using N2;
using N2.Details;
using N2.Integrity;
using N2.Templates.Mvc.Models.Pages;
using N2.Web.UI.WebControls;

namespace N2.Templates.Mvc.Models.Parts
{
	[PartDefinition("Social bookmarks",
		IconUrl = "~/Content/Img/digg.png")]
	[RestrictParents(typeof (AbstractContentPage))]
	[AllowedZones(Zones.SiteRight, Zones.Right, Zones.RecursiveRight, Zones.SiteLeft)]
	[WithEditableTitle("Title", 90)]
	public class SocialBookmarks : AbstractItem
	{
		[Displayable(typeof (H4), "Text")]
		public override string Title
		{
			get { return base.Title; }
			set { base.Title = value; }
		}

		[EditableCheckBox("Show text", 100)]
		public virtual bool ShowText
		{
			get { return (bool) (GetDetail("ShowText") ?? true); }
			set { SetDetail("ShowText", value, true); }
		}
	}
}
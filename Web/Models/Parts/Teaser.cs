using System.Web.UI.WebControls;
using N2.Details;
using N2.Integrity;
using N2.Web.UI.WebControls;

namespace N2.Templates.Mvc.Models.Parts
{
	[PartDefinition("Teaser",
		IconUrl = "~/Content/Img/heart.png")]
	[AllowedZones(Zones.RecursiveRight, Zones.RecursiveLeft, Zones.Left, Zones.Right)]
	[WithEditableTitle("Title", 10)]
	public class Teaser : AbstractItem
	{
		[Displayable(typeof (H4), "Text")]
		public override string Title
		{
			get { return base.Title; }
			set { base.Title = value; }
		}

		[EditableTextBox("Linked text", 100, TextMode = TextBoxMode.MultiLine)]
		public virtual string LinkText
		{
			get { return (string) GetDetail("LinkText"); }
			set { SetDetail("LinkText", value, string.Empty); }
		}

		[EditableUrl("Link", 100)]
		public virtual string LinkUrl
		{
			get { return (string) GetDetail("LinkUrl"); }
			set { SetDetail("LinkUrl", value, string.Empty); }
		}
	}
}
using N2.Details;
using N2.Integrity;

namespace N2.Templates.Mvc.Models.Parts
{
	[PartDefinition("Boxed Text",
		Name = "BoxedText",
		IconUrl = "~/Content/Img/application_view_columns.png")]
	[AllowedZones(Zones.Left, Zones.Right, Zones.RecursiveLeft, Zones.RecursiveRight, Zones.SiteLeft, Zones.SiteRight)]
	[WithEditableTitle]
	public class BoxedTextItem : AbstractItem
	{
		[EditableFreeTextArea("Text", 100)]
		public virtual string Text
		{
			get { return (string) (GetDetail("Text") ?? string.Empty); }
			set { SetDetail("Text", value, string.Empty); }
		}
	}
}
using KVG.Core.Layout;
using KVG.Core.Models.Parts;
using N2;
using N2.Details;
using N2.Integrity;
using N2.Templates.Mvc;

namespace KVG.Registration.Models.Parts
{
	[PartDefinition("Rss List",
		Name = "RssAggregatorItem",
		Description = "A list of news items retrieved from an rss source.",
		SortOrder = 165,
		IconUrl = "~/Content/Img/rss.png")]
	[WithEditableTitle("Title", 10, Required = false)]
	[AllowedZones(Zones.RecursiveRight, Zones.RecursiveLeft, Zones.Right, Zones.Left, Zones.Content, Zones.ColumnLeft,
		Zones.ColumnRight)]
	public class RssAggregator : AbstractItem
	{
		[EditableFreeTextArea("Text", 100)]
		public virtual string Text
		{
			get { return (string) (GetDetail("Text") ?? string.Empty); }
			set { SetDetail("Text", value, string.Empty); }
		}

		[EditableUrl("Rss Url", 120)]
		public virtual string RssUrl
		{
			get { return (string) (GetDetail("RssUrl") ?? string.Empty); }
			set { SetDetail("RssUrl", value, string.Empty); }
		}

		[EditableTextBox("Max Count", 130)]
		public virtual int MaxCount
		{
			get { return (int) (GetDetail("MaxCount") ?? 5); }
			set { SetDetail("MaxCount", value, 5); }
		}
	}
}
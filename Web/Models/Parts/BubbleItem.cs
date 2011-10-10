using System;
using KVG.Core.Layout;
using KVG.Core.Models.Parts;
using N2;
using N2.Integrity;
using N2.Details;
using N2.Templates.Mvc;

namespace KVG.Registration.Models.Parts
{
	[PartDefinition("Bubble",
		IconUrl = "~/Content/Img/help.png")]
	[AllowedZones(Zones.Left, Zones.Right, Zones.ColumnLeft, Zones.ColumnRight)]
	public class BubbleItem : AbstractItem
	{
		[EditableFreeTextArea("Text", 100)]
		public virtual string Text
		{
			get { return (string) (GetDetail("Text") ?? string.Empty); }
			set { SetDetail("Text", value, string.Empty); }
		}
	}
}
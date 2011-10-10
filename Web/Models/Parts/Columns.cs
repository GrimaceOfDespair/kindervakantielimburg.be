using KVG.Core.Models.Parts;
using N2;
using N2.Integrity;

namespace KVG.Registration.Models.Parts
{
	[PartDefinition("Two column container",
		IconUrl = "~/Content/Img/text_columns.png")]
	[AvailableZone("Left", "ColumnLeft"), AvailableZone("Right", "ColumnRight")]
	[AllowedZones("Content")]
	public class Columns : AbstractItem
	{
	}
}
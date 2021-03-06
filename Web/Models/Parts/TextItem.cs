using KVG.Core.Models.Parts;
using N2;
using N2.Details;
using N2.Integrity;

namespace KVG.Registration.Models.Parts
{
	[PartDefinition("Text", Name = "Text",
		IconUrl = "~/Content/Img/text_align_left.png")]
	[AllowedZones(AllowedZones.AllNamed)]
	public class TextItem : AbstractItem
	{
		[EditableFreeTextArea("Text", 100)]
		public virtual string Text
		{
			get { return (string) (GetDetail("Text") ?? string.Empty); }
			set { SetDetail("Text", value, string.Empty); }
		}
	}
}
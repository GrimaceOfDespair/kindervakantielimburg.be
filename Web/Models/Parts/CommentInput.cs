using KVG.Core.Layout;
using KVG.Core.Models.Pages;
using KVG.Core.Models.Parts;
using N2;
using N2.Integrity;
using N2.Templates.Mvc;

namespace KVG.Registration.Models.Parts
{
	[PartDefinition("Comment Input Form",
		IconUrl = "~/Content/Img/comment_add.png")]
	[RestrictParents(typeof (AbstractPage))]
	[AllowedZones(Zones.Content, Zones.RecursiveBelow)]
	public class CommentInput : AbstractItem
	{
	}
}
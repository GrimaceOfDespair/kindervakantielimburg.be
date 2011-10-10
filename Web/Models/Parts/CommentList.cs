using KVG.Core.Models.Pages;
using KVG.Core.Models.Parts;
using N2;
using N2.Definitions;
using N2.Edit.Trash;
using N2.Integrity;

namespace KVG.Registration.Models.Parts
{
	[Disable] // This item is added by the CommentInput thus it's disabled
	[Throwable(AllowInTrash.No)]
	[Versionable(AllowVersions.No)]
	[PartDefinition("Comment List",
		IconUrl = "~/Content/Img/comments.png")]
	[RestrictParents(typeof (AbstractPage))]
	public class CommentList : AbstractItem
	{
	}
}
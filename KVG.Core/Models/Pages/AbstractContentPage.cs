using KVG.Core.Layout;
using N2.Details;
using N2.Integrity;
using N2.Definitions;
using N2.Web.UI;

namespace KVG.Core.Models.Pages
{
	/// <summary>
	/// A page item with a convenient set of properties defined by default.
	/// </summary>
	[WithEditableName("Name", 14, ContainerName = Tabs.Details),
	 WithEditablePublishedRange("Published Between", 16, ContainerName = Tabs.Details, BetweenText = " and ")]
	[AvailableZone("Right", Zones.Right),
	 AvailableZone("Recursive Right", Zones.RecursiveRight),
	 AvailableZone("Left", Zones.Left),
	 AvailableZone("Recursive Left", Zones.RecursiveLeft),
	 AvailableZone("Content", Zones.Content),
	 AvailableZone("Recursive Above", Zones.RecursiveAbove),
	 AvailableZone("Recursive Below", Zones.RecursiveBelow)]
	[RestrictParents(typeof (IStructuralPage))]
	[Separator("TitleSeparator", 15, ContainerName = Tabs.Details)]
	public abstract class AbstractContentPage : AbstractPage
	{
		[EditableFreeTextArea("Text", 100, ContainerName = Tabs.Content)]
		public virtual string Text
		{
			get { return (string) (GetDetail("Text") ?? string.Empty); }
			set { SetDetail("Text", value, string.Empty); }
		}

		[EditableCheckBox("Visible", 12, ContainerName = Tabs.Details)]
		public override bool Visible
		{
			get { return base.Visible; }
			set { base.Visible = value; }
		}
	}
}
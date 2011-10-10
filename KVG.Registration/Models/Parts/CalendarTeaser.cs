using KVG.Core.Layout;
using KVG.Core.Models.Parts;
using KVG.Registration.Models.Pages;
using N2;
using N2.Details;
using N2.Integrity;
using N2.Templates.Mvc;

namespace KVG.Registration.Models.Parts
{
	[PartDefinition("Calendar Teaser",
		IconUrl = "~/Content/Img/calendar_view_month.png")]
	[AllowedZones(Zones.RecursiveRight, Zones.RecursiveLeft, Zones.Right, Zones.Left)]
	public class CalendarTeaser : SidebarItem
	{
		[EditableLink("Calendar container", 100)]
		public virtual Calendar Container
		{
			get { return (Calendar) GetDetail("Container"); }
			set { SetDetail("Container", value); }
		}
	}
}
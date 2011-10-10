using System;
using KVG.Core.Layout;
using KVG.Core.Models.Parts;
using N2;
using N2.Definitions;
using N2.Details;
using N2.Integrity;
using N2.Templates.Mvc;

namespace KVG.Registration.Models.Parts
{
	[Disable]
	[Obsolete]
	[PartDefinition("Control Panel",
		IconUrl = "~/Content/Img/controller.png")]
	[AllowedZones(Zones.RecursiveRight, Zones.SiteLeft, Zones.SiteRight)]
	[WithEditableTitle("Title", 10)]
	[ItemAuthorizedRoles("Administrators")]
	public class ControlPanel : SidebarItem
	{
	}
}
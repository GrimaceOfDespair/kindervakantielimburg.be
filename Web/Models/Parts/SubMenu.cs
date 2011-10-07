using System;
using System.Collections.Generic;
using N2.Definitions;
using N2.Details;
using N2.Integrity;
using N2.Web.UI.WebControls;

namespace N2.Templates.Mvc.Models.Parts
{
    [PartDefinition("Subscribe",
        Description =
            "A submenu"
        ,
        SortOrder = 500)]
    [RestrictParents(typeof(IStructuralPage))]
    [AllowedZones(Zones.Right, Zones.Left, Zones.RecursiveRight, Zones.RecursiveLeft, Zones.SiteRight, Zones.SiteLeft)]
    public class SubMenu : AbstractItem
    {
		[EditableLink("Parent Menu Item", 135)]
		public virtual ContentItem ParentItem
        {
            get { return (ContentItem)GetDetail("ParentItem"); }
            set { SetDetail("ParentItem", value); }
        }

        [Editable]
        public string CssClass
        {
            get { return (string)(GetDetail("CssClass") ?? string.Empty); }
            set { SetDetail("CssClass", value, string.Empty); }
        }

        public IEnumerable<ContentItem> Items
        {
            get { return ParentItem.GetChildren(); }
        }

        public ContentItem CurrentItem { get; set; }

    }
}
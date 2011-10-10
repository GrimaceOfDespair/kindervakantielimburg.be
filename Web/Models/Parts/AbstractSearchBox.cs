using System;
using System.Collections.Generic;
using KVG.Core.Layout;
using KVG.Core.Models.Parts;
using N2;
using N2.Collections;
using N2.Definitions;
using N2.Details;
using N2.Integrity;
using N2.Templates.Mvc;

namespace KVG.Registration.Models.Parts
{
	/// <summary>
	/// A base class for item parts in the templates project.
	/// </summary>
    [Throwable(AllowInTrash.No)]
    [Versionable(AllowVersions.No)]
    [AllowedZones(Zones.RecursiveRight, Zones.RecursiveLeft, Zones.Right, Zones.Left, Zones.Content, Zones.ColumnLeft,
        Zones.ColumnRight, Zones.RecursiveAbove, Zones.RecursiveBelow)]
    public abstract class AbstractSearchBox : SidebarItem
	{
        public abstract ICollection<ContentItem> Search(string query, int pageSize, int pageNumber, out int totalRecords);

        public enum HeadingLevel
        {
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4
        }

        [EditableEnum("Title heading level", 90, typeof(HeadingLevel))]
        public virtual int TitleLevel
        {
            get { return (int)(GetDetail("TitleLevel") ?? 3); }
            set { SetDetail("TitleLevel", value, 3); }
        }

        [EditableLink("Search Root", 100)]
        public virtual ContentItem SearchRoot
        {
            get { return (ContentItem)GetDetail("SearchRoot"); }
            set { SetDetail("SearchRoot", value); }
        }

        protected virtual List<ItemFilter> GetFilters()
        {
            List<ItemFilter> filters = new List<ItemFilter>();
            filters.Add(new NavigationFilter());
            if (SearchRoot != null)
                filters.Add(new ParentFilter(SearchRoot));
            return filters;
        }
    }
}
using System;
using System.Collections.Generic;
using KVG.Core.Models.Pages;
using N2;
using N2.Collections;
using N2.Integrity;
using KVG.Registration.Models.Pages;
using N2.Definitions;

namespace KVG.Registration.Models.Pages
{
	[PageDefinition("Calendar", 
		Description = "A list of recent events.", 
		SortOrder = 120)]
	[RestrictParents(typeof (IStructuralPage))]
	[SortChildren(SortBy.Expression, SortExpression = "EventDate")]
	public class Calendar : AbstractContentPage
	{
		public virtual IEnumerable<Event> GetEvents()
		{
			foreach (Event child in GetChildren(new TypeFilter(typeof (Event)), new AccessFilter()))
				yield return child;
		}

		public virtual IList<Event> GetEvents(DateTime day)
		{
			return
				GetChildren(new TypeFilter(typeof (Event)), new AccessFilter(),
				            new DelegateFilter(c => ((Event) c).EventDate.HasValue && ((Event) c).EventDate.Value.Date == day.Date))
					.Cast<Event>();
		}
	}
}
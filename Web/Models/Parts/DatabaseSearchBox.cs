using System;
using System.Collections.Generic;
using System.Linq;
using N2;
using N2.Collections;
using N2.Details;
using N2.Persistence.Finder;

namespace KVG.Registration.Models.Parts
{
	/// <summary>
	/// A base class for item parts in the templates project.
	/// </summary>
    [PartDefinition("Database Search",
        IconUrl = "~/Content/Img/zoom.png")]
    public class DatabaseSearchBox : AbstractSearchBox
	{
        public virtual IQueryEnding CreateQuery(string query)
        {
            List<ItemFilter> filters = GetFilters();
            string like = '%' + query + '%';

            return Find.Items
                .Where.Title.Like(like)
                .Or.Name.Like(like)
                .Or.Detail().Like(like)
                .Filters(filters);
        }

        public override ICollection<ContentItem> Search(string query, int pageNumber, int pageSize, out int totalRecords)
        {
            var n2Query = CreateQuery(query);

            var records = n2Query.Select();

            totalRecords = records.Count;

            return n2Query
                .Select()
                .Skip(pageSize * pageNumber)
                .Take(pageSize)
                .ToList();
        }
    }
}
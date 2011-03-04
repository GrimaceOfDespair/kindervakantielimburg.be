using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using N2.Details;
using N2.Templates.Details;
using N2.Templates.Mvc.Models.Pages;
using N2.Templates.Mvc.Models.Parts;
using N2.Web;

namespace N2.Templates.Mvc.Details
{
    public class HolidaySelectorAttribute : ContentItemSelectorAttribute
    {
        public HolidaySelectorAttribute(string title, int sortOrder) : base(title, sortOrder)
        {
        }

        public override IEnumerable<ContentItem> GetContentItems()
        {
            var now = DateTime.UtcNow;

            var registrationRanges = N2.Find.Items.Where
                .Type.Eq(typeof(RegistrationRange))
                .And
                .OpenBracket()
                    .OpenBracket()
                        .Published.IsNull()
                        .Or
                        .Published.Lt(now)
                    .CloseBracket()
                    .And
                    .OpenBracket()
                        .Expires.IsNull()
                        .Or
                        .Expires.Gt(now)
                    .CloseBracket()
                 .CloseBracket();

            return registrationRanges.Select().Select(r => r.Parent);
        }
    }
}

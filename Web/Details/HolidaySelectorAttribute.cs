using System;
using System.Collections.Generic;
using System.Linq;
using N2.Templates.Mvc.Models.Pages;

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

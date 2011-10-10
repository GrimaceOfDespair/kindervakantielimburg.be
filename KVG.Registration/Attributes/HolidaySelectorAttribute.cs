using System;
using System.Collections.Generic;
using System.Linq;
using KVG.Core.Attributes;
using KVG.Registration.Models.Pages;
using N2;

namespace KVG.Registration.Attributes
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

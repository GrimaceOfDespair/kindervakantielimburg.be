using System.Collections.Generic;
using N2.Security.Items;

namespace N2.Templates.Mvc.Details
{
    public class UserSelectorAttribute : ContentItemSelectorAttribute
    {
        public UserSelectorAttribute(string title, int sortOrder) : base(title, sortOrder)
        {
        }

        public override IEnumerable<ContentItem> GetContentItems()
        {
            return N2.Find.Items.Where.Type.Eq(typeof(User)).Select();
        }
    }
}

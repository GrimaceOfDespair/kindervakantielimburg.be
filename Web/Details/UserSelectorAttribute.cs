using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using N2.Details;
using N2.Security.Items;
using N2.Templates.Details;
using N2.Templates.Mvc.Models.Pages;
using N2.Templates.Mvc.Models.Parts;
using N2.Web;

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

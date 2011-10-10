using N2.Security.Items;
using N2.Templates.Mvc.Details;

namespace N2.Templates.Mvc.Models.Parts
{
    [PartDefinition("SelectUser")]
    //[RemoveEditable("Title")]
    //[WithEditableTitle()]
    public class SelectUser : AbstractItem
    {
        [UserSelector("User", 10)]
        public virtual User User
        {
            get { return (User)(GetDetail("User")); }
            set { SetDetail("User", value); }
        }

    }
}

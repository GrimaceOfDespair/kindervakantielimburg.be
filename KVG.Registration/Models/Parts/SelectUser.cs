using KVG.Core.Models.Parts;
using N2;
using N2.Security.Items;
using KVG.Core.Attributes;

namespace KVG.Registration.Models.Parts
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

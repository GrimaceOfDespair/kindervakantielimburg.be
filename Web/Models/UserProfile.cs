using System;
using N2;
using N2.Definitions;
using N2.Details;
using N2.Integrity;
using N2.Security;
using N2.Security.Items;

namespace Web.Models
{
    [PartDefinition("User")]
    [RestrictParents(typeof(UserList))]
    [Throwable(AllowInTrash.No)]
    [Versionable(AllowVersions.No)]
    public class UserProfile : User
    {
        [EditableDate(Title = "Date of birth", SortOrder = 20, Required = false)]
        public virtual DateTime DateOfBirth { get; set; }

        //[EditableDate(Title = "Facebook ID", SortOrder = 10, Required = false, RequiredPermission = Permission.Administer)]
        //public long FacebookId { get; set; }
        public long FacebookId
        {
            get { return (long)GetMembershipUser("").ProviderUserKey; }
        }
    }
}
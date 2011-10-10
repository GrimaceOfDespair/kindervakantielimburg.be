using System;
using System.Web.UI.WebControls;
using N2.Details;
using N2.Templates.Mvc.Classes;
using N2.Web.UI;

namespace N2.Templates.Mvc.Models.Parts
{
    [PartDefinition("PersonalDetails")]
    [StyledFieldSetContainer(PersonalDetailsFieldSet, "PersonalDetails", 10, ImageUrl = "~/N2/Resources/icons/vcard.png")]
    public class PersonalDetails : AbstractItem
    {
        public const string PersonalDetailsFieldSet = "personalDetailsFieldSet";

        [EditableTextBox("IdNumber", 30, TextMode = TextBoxMode.SingleLine, Columns = 80, ContainerName = PersonalDetailsFieldSet)]
        public virtual string IdNumber
        {
            get { return (string)(GetDetail("IdNumber") ?? string.Empty); }
            set { SetDetail("IdNumber", value, string.Empty); }
        }

        [EditableTextBox("PlaceOfBirth", 40, TextMode = TextBoxMode.SingleLine, Columns = 80, ContainerName = PersonalDetailsFieldSet)]
        public virtual string PlaceOfBirth
        {
            get { return (string)(GetDetail("PlaceOfBirth") ?? string.Empty); }
            set { SetDetail("PlaceOfBirth", value, string.Empty); }
        }

        [EditableDate("DateOfBirth", 50, ShowTime = false, ContainerName = PersonalDetailsFieldSet)]
        public virtual DateTime DateOfBirth
        {
            get { return GetDetail("DateOfBirth", default(DateTime)); }
            set { SetDetail("DateOfBirth", value, default(DateTime)); }
        }
    }
}

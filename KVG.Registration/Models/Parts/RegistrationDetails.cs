using System;
using System.Web.UI.WebControls;
using KVG.Core.Models.Parts;
using KVG.Registration.Attributes;
using KVG.Registration.Models.Pages;
using N2;
using N2.Details;
using KVG.Core.Layout;
using KVG.Core.Attributes;
using N2.Web.UI;

namespace KVG.Registration.Models.Parts
{
    [PartDefinition("RegistrationDetails")]
    [StyledFieldSetContainer(RegistrationDetailsFieldSet, "RegistrationDetails", 10, ImageUrl = "~/N2/Resources/icons/report_user.png")]
    public class RegistrationDetails : AbstractItem, IHolidayProvider
    {
        public const string RegistrationDetailsFieldSet = "registrationDetailsFieldSet";

        [HolidaySelector("Holiday", 10, ContainerName = RegistrationDetailsFieldSet)]
        public virtual Holiday Holiday
        {
            get { return (Holiday)(GetDetail("Holiday")); }
            set { SetDetail("Holiday", value); }
        }

        [EditableCheckBox("HandicapFlag", 20, ContainerName = RegistrationDetailsFieldSet)]
        public virtual bool HandicapFlag
        {
            get { return (bool)(GetDetail("HandicapFlag") ?? false); }
            set { SetDetail("HandicapFlag", value, false); }
        }

        [EditableEnum("Participation", 30, typeof(Participation), ContainerName = RegistrationDetailsFieldSet)]
        public virtual Participation Participation
        {
            get { return (Participation)(GetDetail("Participation") ?? Participation.Conductor); }
            set { SetDetail("Participation", value, Participation.Conductor); }
        }

        [EditableCheckBox("IsKvgMember", 40, ContainerName = RegistrationDetailsFieldSet)]
        public virtual bool IsKvgMember
        {
            get { return (bool)(GetDetail("IsKvgMember") ?? false); }
            set { SetDetail("IsKvgMember", value, false); }
        }

        [EditableTextBox("KvgMembership", 50, TextMode = TextBoxMode.SingleLine, Columns = 80, ContainerName = RegistrationDetailsFieldSet)]
        public virtual string KvgMembership
        {
            get { return (string)(GetDetail("KvgMembership") ?? string.Empty); }
            set { SetDetail("KvgMembership", value, string.Empty); }
        }
    }

    //public enum Holiday
    //{
    //    Holiday1,
    //    Holiday2,
    //    Holiday3,
    //    Holiday4,
    //}

    public enum Participation
    {
        Participator,
        Conductor,
        Kitchen
    }
}

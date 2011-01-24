using System;
using System.Web.UI.WebControls;
using N2.Details;
using N2.Web.UI;

namespace N2.Templates.Mvc.Models.Parts
{
    [PartDefinition("RegistrationDetails")]
    [FieldSetContainer(RegistrationDetailsFieldSet, "RegistrationDetails", 10)]
    public class RegistrationDetails : AbstractItem
    {
        public const string RegistrationDetailsFieldSet = "registrationDetailsFieldSet";

        [EditableEnum("Holiday", 10, typeof(Holiday), ContainerName = RegistrationDetailsFieldSet)]
        public virtual Holiday Holiday
        {
            get { return (Holiday)(GetDetail("Holiday") ?? Holiday.Holiday1); }
            set { SetDetail("Holiday", value, Holiday.Holiday1); }
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

    public enum Holiday
    {
        Holiday1,
        Holiday2,
        Holiday3,
        Holiday4,
    }

    public enum Participation
    {
        Participator,
        Conductor,
        Kitchen
    }
}

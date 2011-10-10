using KVG.Core.Models.Parts;
using N2;
using N2.Details;
using KVG.Core.Layout;
using N2.Web.UI;

namespace KVG.Registration.Models.Parts
{
    [PartDefinition("Handicap")]
    [StyledFieldSetContainer(HandicapFieldSet, "Handicap", 10, ImageUrl = "~/N2/Resources/icons/error.png")]
    public class Handicap : AbstractItem
    {
        public const string HandicapFieldSet = "HandicapFieldSet";

        [EditableEnum("PhysicalHandicap", 10, typeof(HandicapDegree), ContainerName = HandicapFieldSet)]
        public virtual HandicapDegree PhysicalHandicap
        {
            get { return (HandicapDegree)(GetDetail("HandicapDegree") ?? HandicapDegree.None); }
            set { SetDetail("HandicapDegree", value, HandicapDegree.None); }
        }

        [EditableEnum("MentalHandicap", 20, typeof(HandicapDegree), ContainerName = HandicapFieldSet)]
        public virtual HandicapDegree MentalHandicap
        {
            get { return (HandicapDegree)(GetDetail("HandicapDegree") ?? HandicapDegree.None); }
            set { SetDetail("HandicapDegree", value, HandicapDegree.None); }
        }

        [EditableEnum("SocialHandicap", 30, typeof(HandicapDegree), ContainerName = HandicapFieldSet)]
        public virtual HandicapDegree SocialHandicap
        {
            get { return (HandicapDegree)(GetDetail("HandicapDegree") ?? HandicapDegree.None); }
            set { SetDetail("HandicapDegree", value, HandicapDegree.None); }
        }

        [EditableCheckBox("VisuallyImpaired", 40, ContainerName = HandicapFieldSet)]
        public virtual bool VisuallyImpaired
        {
            get { return GetDetail("VisuallyImpaired", false); }
            set { SetDetail("VisuallyImpaired", value, false); }
        }

        [EditableTextBox("IQ", 50, ContainerName = HandicapFieldSet)]
        public virtual string IQ
        {
            get { return GetDetail("IQ", ""); }
            set { SetDetail("IQ", value, ""); }
        }
    }

    public enum HandicapDegree
    {
        None,
        Slight,
        Moderate,
        Severe
    }
}

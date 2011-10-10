using System.Web.UI.WebControls;
using KVG.Core.Models.Parts;
using N2;
using N2.Details;
using KVG.Core.Layout;
using N2.Web.UI;

namespace KVG.Registration.Models.Parts
{
    [PartDefinition("Utilities")]
    [StyledFieldSetContainer(WheelChairFieldSet, "WheelChair", 10, ImageUrl = "~/N2/Resources/icons/wheelchair.png")]
    public class Utilities : AbstractItem
    {
        public const string WheelChairFieldSet = "wheelChairFieldSet";

        [EditableEnum("WheelChair", 110, typeof(WheelChair), ContainerName = WheelChairFieldSet)]
        public virtual WheelChair WheelChair
        {
            get { return (WheelChair)(GetDetail("WheelChair") ?? WheelChair.Never); }
            set { SetDetail("WheelChair", value, WheelChair.Never); }
        }

        [EditableEnum("OwnWheelChair", 120, typeof(OwnWheelChair), ContainerName = WheelChairFieldSet)]
        public virtual OwnWheelChair OwnWheelChair
        {
            get { return (OwnWheelChair)(GetDetail("OwnWheelChair") ?? OwnWheelChair.No); }
            set { SetDetail("OwnWheelChair", value, OwnWheelChair.No); }
        }

        [EditableTextBox("OtherUtilities", 100, TextMode = TextBoxMode.MultiLine, Columns = 80, Rows = 2)]
        public virtual string OtherUtilities
        {
            get { return (string)(GetDetail("OtherUtilities") ?? string.Empty); }
            set { SetDetail("OtherUtilities", value, string.Empty); }
        }
    }

    public enum WheelChair
    {
        Always,
        LongDistances,
        Never
    }

    public enum OwnWheelChair
    {
        No,
        Normal,
        Electric
    }

}

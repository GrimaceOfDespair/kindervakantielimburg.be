using System.Web.UI.WebControls;
using KVG.Core.Models.Parts;
using N2;
using N2.Details;
using KVG.Core.Layout;
using N2.Web.UI;

namespace KVG.Registration.Models.Parts
{
    [PartDefinition("Diet")]
    [StyledFieldSetContainer(DietFieldSet, "Diet", 10, ImageUrl = "~/N2/Resources/icons/pumpkin_pie.png")]
    public class Diet : AbstractItem
    {
        public const string DietFieldSet = "dietFieldSet";

        [EditableCheckBox("Vegetarian", 10, ContainerName = DietFieldSet)]
        public virtual bool Vegetarian
        {
            get { return GetDetail("Vegetarian", false); }
            set { SetDetail("Vegetarian", value, false); }
        }

        [EditableCheckBox("EatsNoFish", 20, ContainerName = DietFieldSet)]
        public virtual bool EatsNoFish
        {
            get { return GetDetail("EatsNoFish", false); }
            set { SetDetail("EatsNoFish", value, false); }
        }

        [EditableCheckBox("EatsNoMeat", 30, ContainerName = DietFieldSet)]
        public virtual bool EatsNoMeat
        {
            get { return GetDetail("EatsNoMeat", false); }
            set { SetDetail("EatsNoMeat", value, false); }
        }

        [EditableCheckBox("EatsNoEggs", 40, ContainerName = DietFieldSet)]
        public virtual bool EatsNoEggs
        {
            get { return GetDetail("EatsNoEggs", false); }
            set { SetDetail("EatsNoEggs", value, false); }
        }

        [EditableTextBox("EatsNo", 50, ContainerName = DietFieldSet)]
        public virtual string EatsNo
        {
            get { return GetDetail("EatsNo", ""); }
            set { SetDetail("EatsNo", value, ""); }
        }


    }
}

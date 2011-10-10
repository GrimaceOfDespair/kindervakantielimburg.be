using System;
using System.Web.UI.WebControls;
using KVG.Core.Models.Parts;
using N2;
using N2.Details;

namespace KVG.Registration.Models.Parts
{
	[PartDefinition("Phone")]
    public class Phone : AbstractItem
	{
        [EditableTextBox("PhoneNumber", 10, TextMode = TextBoxMode.SingleLine, Columns = 80)]
        public virtual string PhoneNumber
        {
            get { return (string)(GetDetail("PhoneNumber") ?? string.Empty); }
            set { SetDetail("PhoneNumber", value, string.Empty); }
        }

        [EditableTextBox("Owner", 20, TextMode = TextBoxMode.SingleLine, Columns = 80)]
        public virtual string Owner
        {
            get { return (string)(GetDetail("Owner") ?? string.Empty); }
            set { SetDetail("Owner", value, string.Empty); }
        }
    }
}
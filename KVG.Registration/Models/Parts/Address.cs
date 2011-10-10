using System;
using System.Web.UI.WebControls;
using KVG.Core.Models.Parts;
using N2;
using N2.Details;

namespace KVG.Registration.Models.Parts
{
	[PartDefinition("Address")]
    public class Address : AbstractItem
	{
        [EditableTextBox("Street", 10, TextMode = TextBoxMode.SingleLine, Columns = 80)]
        public virtual string Street
        {
            get { return (string)(GetDetail("Street") ?? string.Empty); }
            set { SetDetail("Street", value, string.Empty); }
        }

        [EditableTextBox("Number", 20, TextMode = TextBoxMode.SingleLine, Columns = 5)]
        public virtual string Number
        {
            get { return (string)(GetDetail("Number") ?? string.Empty); }
            set { SetDetail("Number", value, string.Empty); }
        }

        [EditableTextBox("Suffix", 30, TextMode = TextBoxMode.SingleLine, Columns = 5)]
        public virtual string Suffix
        {
            get { return (string)(GetDetail("Suffix") ?? string.Empty); }
            set { SetDetail("Suffix", value, string.Empty); }
        }

        [EditableTextBox("PostalCode", 40, TextMode = TextBoxMode.SingleLine, Columns = 10)]
        public virtual string PostalCode
        {
            get { return (string)(GetDetail("PostalCode") ?? string.Empty); }
            set { SetDetail("PostalCode", value, string.Empty); }
        }

        [EditableTextBox("Location", 40, TextMode = TextBoxMode.SingleLine, Columns = 80)]
        public virtual string Location
        {
            get { return (string)(GetDetail("Location") ?? string.Empty); }
            set { SetDetail("Location", value, string.Empty); }
        }
    }
}
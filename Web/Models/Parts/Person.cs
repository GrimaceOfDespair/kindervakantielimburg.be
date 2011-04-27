using System;
using System.Web.UI.WebControls;
using MvcContrib.FluentHtml.Elements;
using N2.Details;
using N2.Templates.Mvc.Classes;
using N2.Web.UI;
using Literal = System.Web.UI.WebControls.Literal;

namespace N2.Templates.Mvc.Models.Parts
{
	[PartDefinition("Person")]
    //[FieldSetContainer(GeneralDataFieldSet, "GeneralData", 10)]
    [StyledFieldSetContainer(TelephoneFieldSet, "Telephone", 40, ImageUrl = "~/N2/Resources/icons/telephone.png")]
    [StyledFieldSetContainer(MobileFieldSet, "Mobile", 50, ImageUrl = "~/N2/Resources/icons/phone.png")]
	public class Person : AbstractItem
	{
	    //public const string GeneralDataFieldSet = "generalDataFieldSet";
	    public const string TelephoneFieldSet = "telephoneFieldSet";
	    public const string MobileFieldSet = "mobileFieldSet";

        public virtual string Description
        {
            get { return CalculateTitle(); }
        }

        [EditableTextBox("FirstName", 10, TextMode = TextBoxMode.SingleLine, Columns = 80/*, ContainerName = GeneralDataFieldSet*/)]
        [Displayable(typeof(Literal), "Text")]
        public virtual string FirstName
        {
            get { return (string)(GetDetail("FirstName") ?? string.Empty); }
            set { SetDetail("FirstName", value, string.Empty); }
        }

        [EditableTextBox("LastName", 20, TextMode = TextBoxMode.SingleLine, Columns = 80/*, ContainerName = GeneralDataFieldSet*/)]
        [Displayable(typeof(Literal), "Text")]
        public virtual string LastName
        {
            get { return (string)(GetDetail("LastName") ?? string.Empty); }
            set { SetDetail("LastName", value, string.Empty); }
        }


        [EditableItem("Address", 30/*, ContainerName = GeneralDataFieldSet*/)]
        [Displayable(typeof(Literal), "Text")]
        public virtual Address Address
        {
            get { return (Address)GetChild("Address"); }
            set
            {
                if (value != null)
                {
                    value.Name = "Address";
                    value.AddTo(this);
                }
            }
        }
        [EditableItem("Telephone", 10, ContainerName = TelephoneFieldSet)]
        [Displayable(typeof(Literal), "Text")]
        public virtual Phone Telephone
        {
            get { return (Phone)GetChild("Telephone"); }
            set
            {
                if (value != null)
                {
                    value.Name = "Telephone";
                    value.AddTo(this);
                }
            }
        }

        [EditableItem("Mobile", 10, ContainerName = MobileFieldSet)]
        [Displayable(typeof(Literal), "Text")]
        public virtual Phone Mobile
        {
            get { return (Phone)GetChild("Mobile"); }
            set
            {
                if (value != null)
                {
                    value.Name = "Mobile";
                    value.AddTo(this);
                }
            }
        }

	    protected virtual string CalculateTitle()
	    {
	        var firstName = FirstName;
	        var lastName = LastName;
            if (string.IsNullOrEmpty(firstName) == false &&
                string.IsNullOrEmpty(lastName) == false)
            {
                return FirstName + " " + LastName;
            }
	        return string.IsNullOrEmpty(firstName) ? LastName : FirstName;
	    }
    }
}
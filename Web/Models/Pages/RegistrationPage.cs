using System;
using System.Web.UI.WebControls;
using N2;
using N2.Definitions;
using N2.Integrity;
using N2.Templates.Mvc.Models.Parts;
using N2.Templates.Mvc.Services;
using N2.Web;
using N2.Details;
using N2.Web.UI;

namespace N2.Templates.Mvc.Models.Pages
{
    [PageDefinition("Registration", Description = "A page with a registration.", SortOrder = 10,
        IconUrl = "~/Content/Img/registrations.png")]
    [RestrictParents(typeof(RegistrationContainer))]
    [TabContainer(RegistrationPage.RegistrationTab, "Registration", Tabs.ContentIndex - 1)]
    [RemoveEditable("Text")]
    [RemoveEditable("Title")]
    public class RegistrationPage : AbstractContentPage
    {
        public const string RegistrationTab = "registrationPanel";

        public RegistrationPage()
        {
        }

        public virtual string Description
        {
            get
            {
                var registration = Registration;
                if (registration == null) return "";
                return registration.Description;
            }
        }

        [EditableItem("Registration", 10, ContainerName = RegistrationTab)]
        public virtual Registration Registration
        {
            get { return (Registration)GetChild("Registration"); }
            set
            {
                if (value != null)
                {
                    value.Name = "Registration";
                    value.AddTo(this);
                }
            }
        }

        public override bool IsAuthorized(System.Security.Principal.IPrincipal user)
        {
            return true;
        }
    }
}

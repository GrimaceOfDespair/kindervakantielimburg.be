using System.Collections.Generic;
using System.Linq;
using KVG.Core.Models.Pages;
using N2;
using N2.Collections;
using N2.Integrity;
using N2.Definitions;

namespace KVG.Registration.Models.Pages
{
    [PageDefinition("Registration Container",
        Description = "A list of registrations.",
        SortOrder = 5,
        IconUrl = "~/Content/Img/registrations.png")]
    [RestrictParents(typeof(IStructuralPage))]
    [SortChildren(SortBy.PublishedDescending)]
    [AvailableZone("NotifiedUsers", "Users")]
    public class RegistrationContainer : AbstractContentPage
    {
        public IList<RegistrationPage> Registrations
        {
            get { return GetChildren(new TypeFilter(typeof(RegistrationPage))).OfType<RegistrationPage>().ToList(); }
        }

    }
}
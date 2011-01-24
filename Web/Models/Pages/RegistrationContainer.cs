using System.Collections.Generic;
using System.Linq;
using N2.Collections;
using N2.Integrity;
using N2.Web.Mvc;
using N2.Definitions;

namespace N2.Templates.Mvc.Models.Pages
{
	[PageDefinition("Registration Container",
		Description = "A list of registrations.",
		SortOrder = 5,
		IconUrl = "~/Content/Img/registrations.png")]
	[RestrictParents(typeof (IStructuralPage))]
	[SortChildren(SortBy.PublishedDescending)]
	public class RegistrationContainer : AbstractContentPage
	{
		public IList<RegistrationPage> Registrations
		{
			get { return GetChildren(new TypeFilter(typeof (RegistrationPage))).OfType<RegistrationPage>().ToList(); }
		}
	}
}
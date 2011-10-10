using System;
using System.Collections.Generic;
using KVG.Registration.Models.Parts;
using N2.Web.Mvc;
using N2.Web.UI;

namespace N2.Templates.Mvc.Models
{
	public class RegistrationModel : IItemContainer<Registration>
	{
        public RegistrationModel(Registration currentItem, IEnumerable<Person> contacts)
		{
			CurrentItem = currentItem;
            Contacts = contacts;
		}

		/// <summary>Gets the item associated with the item container.</summary>
		ContentItem IItemContainer.CurrentItem
		{
			get { return CurrentItem; }
		}

		public Registration CurrentItem { get; private set; }

		public IEnumerable<Person> Contacts { get; private set; }
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using N2.Engine;
using N2.Persistence;
using N2.Plugin;
using N2.Templates.Mvc.Models.Pages;
using N2.Templates.Mvc.Models.Parts;

namespace N2.Templates.Mvc.Services
{
    public class RegistrationTitleSetter : IAutoStart
    {
        private readonly IPersister _persister;

        public RegistrationTitleSetter(IPersister persister)
        {
            _persister = persister;
        }

        public void Start()
        {
            _persister.ItemSaving += OnItemSaving;
        }

        public void Stop()
        {
            _persister.ItemSaving -= OnItemSaving;
        }

        protected virtual void OnItemSaving(object sender, CancellableItemEventArgs cancellableItemEventArgs)
        {
            var registrationPage = cancellableItemEventArgs.AffectedItem as RegistrationPage;
            if (registrationPage != null)
            {
                registrationPage.Title = registrationPage.Description;
            }
        }
    }

}
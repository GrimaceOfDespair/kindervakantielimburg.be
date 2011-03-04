using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using N2.Definitions;
using N2.Plugin;

namespace N2.Templates.Mvc.Services
{
    public class DefinitionLocalizer : IAutoStart
    {
        private readonly IDefinitionManager _definitionManager;

        public DefinitionLocalizer(IDefinitionManager definitionManager)
        {
            _definitionManager = definitionManager;
        }

        public void Start()
        {
            var resourceManager = global::Resources.Definitions.ResourceManager;
            var resourceSet = resourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);

            foreach (var definitionResource in from DictionaryEntry resource in resourceSet
                                               let discriminator = Regex.Replace((string)resource.Key, @"\.Title$", "")
                                               let definition = _definitionManager.GetDefinition(discriminator)
                                               where definition != null && string.IsNullOrEmpty(discriminator) == false
                                               select new { discriminator, resource.Value })
            {
                var definition = _definitionManager.GetDefinition(definitionResource.discriminator);
                if (definition != null)
                {
                    definition.Title = (string) definitionResource.Value;
                }
            }

            resourceManager.ReleaseAllResources();
        }

        public void Stop()
        {
            foreach (var itemDefinition in _definitionManager.GetDefinitions())
            {
                itemDefinition.Title = itemDefinition.ItemType.Name;
            }
        }
    }
}

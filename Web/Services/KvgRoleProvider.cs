using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using N2.Plugin;
using N2.Security;

namespace N2.Templates.Mvc.Services
{
    public class KvgRoleProvider : ContentRoleProvider
    {
        private static readonly string[] KvgRoles = { "Deelnemer", "Begeleiding", "Team", "Trio", "Inschrijvingen", };
        private static readonly string[] ExcludeRoles = { "Members", "Writers", "Editors" };

        public override string[] GetAllRoles()
        {
            var roles = base.GetAllRoles().ToList();
            roles.AddRange(KvgRoles);
            roles.RemoveAll(role => ExcludeRoles.Contains(role));
            return roles.ToArray();
        }
    }
}

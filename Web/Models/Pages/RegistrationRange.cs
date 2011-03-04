using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using N2.Details;
using N2.Templates.Mvc.Models.Parts;

namespace N2.Templates.Mvc.Models.Pages
{
    [PartDefinition("RegistrationRange")]
    public class RegistrationRange : AbstractItem
    {
        public RegistrationRange()
        {
            base.Published = null;
        }

        [EditableDate("StartRegistration", 10)]
        public override DateTime? Published
        {
            get { return base.Published; }
            set { base.Published = value; }
        }

        [EditableDate("EndRegistration", 20)]
        public override DateTime? Expires
        {
            get { return base.Expires; }
            set { base.Expires = value; }
        }
    }
}

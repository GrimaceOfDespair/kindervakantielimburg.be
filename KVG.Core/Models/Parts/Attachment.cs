using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using N2.Details;
using N2.Persistence.Serialization;

namespace N2.Templates.Mvc.Models.Parts
{
    [PartDefinition("Attachment")]
    [WithEditableTitle(SortOrder = 10)]
    public class Attachment : AbstractItem
    {
        [FileAttachment, EditableFileUploadAttribute("File", 20)]
        public virtual string File
        {
            get { return (string)base.GetDetail("File"); }
            set { base.SetDetail("File", value); }
        }

    }
}

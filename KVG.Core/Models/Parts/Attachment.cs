using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KVG.Core.Models.Parts;
using N2;
using N2.Details;
using N2.Persistence.Serialization;

namespace KVG.Registration.Models.Parts
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

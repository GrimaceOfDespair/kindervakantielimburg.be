using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using N2.Definitions;
using N2.Web.UI.WebControls;

namespace N2.Templates.Mvc.Classes
{
    public class StyledFieldSetContainerAttribute : EditorContainerAttribute
    {
        // Methods
        public StyledFieldSetContainerAttribute(string name, string legend, int sortOrder)
            : base(name, sortOrder)
        {
            Legend = legend;
            ImageStyle = "vertical-align: bottom";
        }

        public override Control AddTo(Control container)
        {
            var child = new FieldSet
                            {
                                ID = Name,
                                Legend = GetLocalizedText("Legend") ?? Legend,
                                CssClass = CssClass
                            };
            if (string.IsNullOrEmpty(ImageUrl) == false)
            {
                var imageUrl = container.ResolveUrl(ImageUrl);

                var imageStyle = "";
                if (string.IsNullOrEmpty(ImageStyle) == false)
                {
                    imageStyle = string.Format(" style=\"{0}\"", ImageStyle.Replace('"', '\''));
                }

                child.Legend = string.Format("<img src=\"{0}\" alt=\"{1}\"{2} />&nbsp;{1}", imageUrl, child.Legend, imageStyle);
            }

            container.Controls.Add(child);
            return child;
        }

        // Properties
        public string Legend { get; set; }
        public string CssClass { get; set; }
        public string ImageUrl { get; set; }
        public string ImageStyle { get; set; }
    }

}

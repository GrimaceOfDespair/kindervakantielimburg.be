using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using N2;
using N2.Details;
using N2.Web.UI;

namespace Dinamico.Models
{
	[SidebarContainer(Defaults.Containers.Metadata, 100, HeadingText = "Metadada")]
	public abstract class PartModelBase : ContentItem
	{
	}
}
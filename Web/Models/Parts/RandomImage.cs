using System;
using System.Web.UI.WebControls;
using KVG.Core.Layout;
using KVG.Core.Models.Parts;
using N2;
using N2.Details;
using N2.Integrity;
using N2.Persistence;
using N2.Templates.Mvc;

namespace KVG.Registration.Models.Parts
{
	[PartDefinition("Random image",
		IconUrl = "~/Content/Img/photos.png")]
	[AllowedZones(Zones.Content, Zones.RecursiveAbove, Zones.Left, Zones.Right)]
	[NotVersionable]
	public class RandomImage : AbstractItem
	{
		[DisplayableImage(CssClass = "main")]
		public virtual string RandomImageUrl
		{
			get
			{
				string[] images = Images.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
				if (images.Length > 0)
					return images[(new Random()).Next(images.Length)];
				else
					return string.Empty;
			}
		}

		[EditableTextBox("Images", 100, Rows = 8, Columns = 40, TextMode = TextBoxMode.MultiLine)]
		public virtual string Images
		{
			get { return (string) (GetDetail("Images") ?? string.Empty); }
			set { SetDetail("Images", value, string.Empty); }
		}
	}
}
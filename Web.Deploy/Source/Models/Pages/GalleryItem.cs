using System;
using System.Web;
using N2.Integrity;
using N2.Details;
using N2.Web;
using N2.Web.Mvc;
using N2.Web.UI;
using N2.Persistence.Serialization;

namespace N2.Templates.Mvc.Models.Pages
{
	[PageDefinition("Gallery Item",
		IconUrl = "~/Content/Img/photo.png")]
	[RestrictParents(typeof (ImageGallery))]
	[TabContainer("advanced", "Advanced", 100)]
	public class GalleryItem : AbstractContentPage
	{
		public GalleryItem()
		{
			Visible = false;
		}

		[FileAttachment, EditableFileUploadAttribute("Image", 30, ContainerName = Tabs.Content)]
		public virtual string ImageUrl
		{
			get { return (string) base.GetDetail("ImageUrl"); }
			set { base.SetDetail("ImageUrl", value); }
		}

		public virtual string ResizedImageUrl
		{
			get { return GetResizedImageUrl(ImageUrl, Gallery.MaxImageWidth, Gallery.MaxImageHeight); }
		}

		public virtual string ThumbnailImageUrl
		{
			get { return GetResizedImageUrl(ImageUrl, Gallery.MaxThumbnailWidth, Gallery.MaxThumbnailHeight); }
		}

		/// <summary>Returns the path to an image handler that resizes the given image to the appropriate size.</summary>
		/// <param name="imageUrl">The image to resize.</param>
		/// <param name="width">The maximum width.</param>
		/// <param name="height">The maximum height.</param>
		/// <returns>The path to a handler that performs resizing of the image.</returns>
		public static string GetResizedImageUrl(string imageUrl, double width, double height)
		{
			// TODO: Refactor to HtmlHelper extension
			string fileExtension = VirtualPathUtility.GetExtension(N2.Web.Url.PathPart(imageUrl));
			bool isAlreadyImageHandler = string.Equals(fileExtension, ".ashx", StringComparison.OrdinalIgnoreCase);

			if (isAlreadyImageHandler) return N2.Web.Url.ToAbsolute(imageUrl);

			Url url = new Url("~/Image.ashx").SetQueryParameter("img", N2.Web.Url.ToAbsolute(imageUrl));
			if (width > 0) url = url.SetQueryParameter("w", (int) width);
			if (height > 0) url = url.SetQueryParameter("h", (int) height);

			return url;
		}

		public virtual ImageGallery Gallery
		{
			get { return Parent as ImageGallery; }
		}

		public override string Url
		{
			get { return N2.Web.Url.Parse(Parent.Url).AppendQuery(PathData.ItemQueryKey, ID).SetFragment("#t" + ID); }
		}
	}
}
using System.Collections.Generic;
using System.Linq;
using KVG.Core.Layout;
using KVG.Core.Models.Parts;
using N2;
using N2.Collections;
using N2.Details;
using N2.Integrity;
using KVG.Registration.Models.Pages;
using N2.Templates.Mvc;

namespace KVG.Registration.Models.Parts
{
	[PartDefinition("News List",
		Description = "A news list box that can be displayed in a column.",
		SortOrder = 160,
		IconUrl = "~/Content/Img/newspaper_go.png")]
	[WithEditableTitle("Title", 10, Required = false)]
	[AllowedZones(Zones.RecursiveRight, Zones.RecursiveLeft, Zones.Right, Zones.Left, Zones.Content, Zones.ColumnLeft,
		Zones.ColumnRight)]
	public class NewsList : SidebarItem
	{
		public enum HeadingLevel
		{
			One = 1,
			Two = 2,
			Three = 3,
			Four = 4
		}

		[EditableEnum("Title heading level", 90, typeof (HeadingLevel))]
		public virtual int TitleLevel
		{
			get { return (int) (GetDetail("TitleLevel") ?? 3); }
			set { SetDetail("TitleLevel", value, 3); }
		}

		[EditableLink("News container", 100)]
		public virtual NewsContainer Container
		{
			get { return (NewsContainer) GetDetail("Container"); }
			set { SetDetail("Container", value); }
		}

		[EditableTextBox("Max news", 120)]
		public virtual int MaxNews
		{
			get { return (int) (GetDetail("MaxNews") ?? 3); }
			set { SetDetail("MaxNews", value, 3); }
		}

		public IEnumerable<News> FilteredNewsItems
		{
			get { return Container.GetChildren(new TypeFilter(typeof (News)), new CountFilter(0, MaxNews)).Cast<News>(); }
		}

		//TODO: implement in controller
		//protected override string TemplateName
		//{
		//    get { return InTheMiddle() ? "NewsList" : "NewsBox"; }
		//}

		public bool IsCentered()
		{
			return ZoneName == Zones.Content || ZoneName == Zones.ColumnLeft || ZoneName == Zones.ColumnRight;
		}
	}
}
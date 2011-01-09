﻿#if DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using N2.Web;
using N2.Web.Mvc;
using N2.Templates.Mvc.Areas.Tests.Models;
using N2.Templates.Mvc.Models.Pages;

namespace N2.Templates.Mvc.Areas.Tests.Controllers
{
	[Controls(typeof(TestPage))]
	[Controls(typeof(TestPart))]
	public class TestContentController : ContentController<ContentItem>
    {
        //
        // GET: /Tests/TestContent/

        public override ActionResult Index()
        {
			if ("Tests" != RouteData.DataTokens["area"])
				throw new Exception("Incorrect area: " + RouteData.Values["area"]);

			if (CurrentItem.IsPage)
				return View();
			else
				return PartialView("Partial");
        }

		[HttpPost]
		public ActionResult Add(string name)
		{
			var part = Engine.Definitions.CreateInstance<TestPart>(CurrentItem);
			part.Name = name;
			part.Title = name;
			part.ZoneName = "TestParts";

			Engine.Persister.Save(part);

			return View("Index");
		}

		public ActionResult Remove()
		{
			Engine.Persister.Delete(CurrentItem);
			return RedirectToParentPage();
		}

		public ActionResult Create(string name, int width, int depth)
		{
			CreateChildren(CurrentPage, typeof(N2.Templates.Mvc.Models.Pages.TextPage), name, width, depth);
			Engine.Persister.Save(CurrentPage);
			return Content("<script type='text/javascript'>window.location = '" + CurrentPage.Url + "'</script>");
		}

		private void CreateChildren(ContentItem parent, Type type, string name, int width, int depth)
		{
			if (depth == 0) return;

			for (int i = 1; i <= width; i++)
			{
				TextPage item = Engine.Definitions.CreateInstance<TextPage>(parent);
				item.Name = name + i;
				item.Title = name + " " + i + " (" + depth + ")";
				item.Text = @"<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec sagittis mi. Donec pharetra vestibulum facilisis. Sed sodales risus vel nulla vulputate volutpat. Mauris vel arcu in purus porta dapibus. Aliquam erat volutpat. Maecenas suscipit tincidunt purus porttitor auctor. Quisque eget elit at justo facilisis malesuada sit amet sit amet eros. Duis convallis porta congue. Nulla commodo faucibus diam in mollis. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Donec ut nibh eu sapien ornare consectetur.</p>
<p>Aliquam id massa nec mi pellentesque rhoncus id vel neque. Pellentesque malesuada venenatis sollicitudin. Maecenas at nisl urna, vel feugiat ipsum. Integer imperdiet rhoncus libero sit amet ullamcorper. Vestibulum et purus et ipsum dignissim molestie id sed urna. Nulla vitae neque neque, tempor fermentum lectus. Proin pellentesque blandit diam, in vehicula ipsum suscipit vel. Pellentesque elementum feugiat egestas. Duis scelerisque metus suscipit massa mattis tempor. Vestibulum sed dolor sed felis pharetra semper eu sed quam. Nam vitae lectus nunc, in placerat dui. Vivamus massa lorem, faucibus in semper ac, tincidunt non massa.</p>";
				item.AddTo(parent);
				HttpContext.Response.Write(item.Title + "<br/>");

				CreateChildren(item, type, name, width, depth - 1);
			}
		}
    }
}
#endif
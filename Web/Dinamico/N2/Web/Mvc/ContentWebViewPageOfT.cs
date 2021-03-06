﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace N2.Web.Mvc
{
	/// <remarks>This code is here since it has dependencies on ASP.NET 3.0 which isn't a requirement for N2 in general.</remarks>
	public abstract class ContentWebViewPage<TModel> : WebViewPage<TModel> where TModel : class
	{
		private DynamicContentHelper content;

		public DynamicContentHelper Content
		{
			get { return content ?? (content = new DynamicContentHelper(Html)); }
			set { content = value; }
		}
	}
}
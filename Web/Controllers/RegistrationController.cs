using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using N2.Templates.Mvc.Models;
using N2.Templates.Mvc.Models.Parts;
using N2.Web;
using N2.Web.Mail;
using N2.Web.Mvc;

namespace N2.Templates.Mvc.Controllers
{
    /// <summary>
    /// This controller returns a view that displays the item created via the management interface
    /// </summary>
    [Controls(typeof(Registration))]
    public class RegistrationController : TemplatesControllerBase<Registration>
    {
		private readonly IMailSender _mailSender;

        public RegistrationController(IMailSender mailSender)
		{
			_mailSender = mailSender;
		}

		public override ActionResult Index()
		{
			return View(new RegistrationModel(CurrentItem, CurrentItem.Contacts));
		}
    }
}
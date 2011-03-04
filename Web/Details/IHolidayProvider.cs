using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using N2.Templates.Mvc.Models.Pages;

namespace N2.Templates.Mvc.Details
{
    public interface IHolidayProvider
    {
        Holiday Holiday { get; set; }
    }
}

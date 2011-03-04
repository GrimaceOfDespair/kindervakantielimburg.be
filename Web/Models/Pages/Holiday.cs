using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using N2.Definitions;
using N2.Details;

namespace N2.Templates.Mvc.Models.Pages
{
    [PageDefinition("Holiday",
        Description = "A KVG Holiday.",
        SortOrder = 110,
        IconUrl = "~/Content/Img/holiday.png")]
    public class Holiday : Event
    {
        [EditableDate("StartDate", 22, ContainerName = Tabs.Content)]
        public override DateTime? EventDate
        {
            get { return base.EventDate; }
            set { base.EventDate = value; }
        }

        [EditableDate("EndDate", 23, ContainerName = Tabs.Content)]
        public virtual DateTime? EndDate
        {
            get { return (DateTime?) GetDetail("EndDate"); }
            set { SetDetail("EndDate", value); }
        }

        [EditableItem("RegistrationRange", 24, ContainerName = Tabs.Content)]
        public virtual RegistrationRange RegistrationRange
        {
            get { return (RegistrationRange)GetChild("RegistrationRange"); }
            set
            {
                if (value != null)
                {
                    value.Name = "RegistrationRange";
                    value.AddTo(this);
                }
            }
        }

        [DisplayableLiteral]
        public override string EventDateString
        {
            get
            {
                if (!EventDate.HasValue && !EndDate.HasValue) return null;

                string format = "";
                string startValue = "", endValue = "";
                if (EventDate.HasValue)
                {
                    format = global::Resources.Common.From;
                    startValue = EventDate.Value.TimeOfDay.TotalSeconds == 0
                                 ? EventDate.Value.ToShortDateString()
                                 : EventDate.Value.ToString();
                }
                if (EndDate.HasValue)
                {
                    format = global::Resources.Common.Until;
                    endValue = EndDate.Value.TimeOfDay.TotalSeconds == 0
                                 ? EndDate.Value.ToShortDateString()
                                 : EndDate.Value.ToString();

                    if (!EventDate.HasValue) startValue = endValue;
                }
                if (EventDate.HasValue && EndDate.HasValue)
                {
                    format = global::Resources.Common.FromUntil;
                }
                

                return string.Format(format, startValue, endValue);
            }
        }

    }
}

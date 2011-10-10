using System;
using System.Collections.Generic;
using KVG.Core.Layout;
using N2;
using N2.Details;
using N2.Templates.Mvc;
using KVG.Registration.Models.Pages;
using KVG.Registration.Models.Parts;
using N2.Web.UI;

namespace KVG.Registration.Models.Pages
{
    [PageDefinition("Holiday",
        Description = "A KVG Holiday.",
        SortOrder = 110,
        IconUrl = "~/Content/Img/holiday.png")]
    [TabContainer(NotificationsTab, "Notify users", 20)]
    public class Holiday : Event
    {
        public const string NotificationsTab = "notificationsTab";

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


        [EditableChildren("NotifiedUsers", "Users", 10, ContainerName = NotificationsTab)]
        public virtual IList<SelectUser> NotifiedUsers
        {
            get { return GetChildren("NotifiedUsers").Cast<SelectUser>(); }
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
                    format = global::Resources.Strings.From;
                    startValue = EventDate.Value.TimeOfDay.TotalSeconds == 0
                                 ? EventDate.Value.ToShortDateString()
                                 : EventDate.Value.ToString();
                }
                if (EndDate.HasValue)
                {
                    format = global::Resources.Strings.Until;
                    endValue = EndDate.Value.TimeOfDay.TotalSeconds == 0
                                 ? EndDate.Value.ToShortDateString()
                                 : EndDate.Value.ToString();

                    if (!EventDate.HasValue) startValue = endValue;
                }
                if (EventDate.HasValue && EndDate.HasValue)
                {
                    format = global::Resources.Strings.FromUntil;
                }
                

                return string.Format(format, startValue, endValue);
            }
        }

    }
}

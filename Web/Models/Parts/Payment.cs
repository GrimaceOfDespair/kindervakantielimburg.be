using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using N2.Details;
using N2.Web.UI;

namespace N2.Templates.Mvc.Models.Parts
{
    [PartDefinition("Payment", Description = "Payment information.")]
    [FieldSetContainer(paymentFieldSet, "Payment", 10)]
    public class Payment : AbstractItem
    {
        public const string paymentFieldSet = "paymentFieldSet";

        [EditableCheckBox("Paid", 10, ContainerName = paymentFieldSet)]
        public virtual bool Paid
        {
            get { return (bool)(GetDetail("Paid") ?? false); }
            set { SetDetail("Paid", value, false); }
        }

        [EditableTextBox("PaymentInfo", 20, ContainerName = paymentFieldSet)]
        public virtual string PaymentInfo
        {
            get { return GetDetail("PaymentInfo", ""); }
            set { SetDetail("PaymentInfo", value, ""); }
        }

    }
}

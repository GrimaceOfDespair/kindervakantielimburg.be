using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using N2.Details;
using N2.Integrity;
using N2.Persistence.Serialization;
using N2.Templates.Mvc.Models.Pages;
using N2.Web.UI;

namespace N2.Templates.Mvc.Models.Parts
{
	[PartDefinition("Registration",
		Description = "A registration.",
		SortOrder = 250,
		IconUrl = "~/Content/Img/Registration.png")]
	[AllowedZones("Content", "ColumnLeft", "ColumnRight")]
	[RestrictParents(typeof (AbstractContentPage))]
	[AllowedChildren(typeof (Person), typeof(Attachment))]
	[AvailableZone("Contacts", "ContactData")]
    [TabContainer(PersonalDataTab, "PersonalData", 0, CssClass = "tabPanel registrationTab")]
    [TabContainer(ContactsTab, "Contacts", 10, CssClass = "tabPanel registrationTab")]
    [TabContainer(MoreInfoTab, "MoreInfo", 20, CssClass = "tabPanel registrationTab")]
    [TabContainer(MedicalSummaryTab, "MedicalSummary", 30, CssClass = "tabPanel registrationTab")]
    [TabContainer(MedicalDetailsTab, "MedicalDetails", 40, CssClass = "tabPanel registrationTab")]
    [TabContainer(AdministrationTab, "Administration", 50, CssClass = "tabPanel registrationTab")]
    [TabContainer(AttachmentsTab, "Attachments", 60, CssClass = "tabPanel registrationTab")]
	public class Registration : AbstractItem
	{
        public const string PersonalDataTab = "personalDataTab";
        public const string ContactsTab = "contactsTab";
        public const string MoreInfoTab = "moreInfoTab";
        public const string MedicalSummaryTab = "medicalSummaryTab";
        public const string MedicalDetailsTab = "medicalDetailsTab";
        public const string AdministrationTab = "administrationTab";
        public const string AttachmentsTab = "attachmentsTab";

        [EditableTextBox("Attn", 10, TextMode = TextBoxMode.SingleLine, Columns = 80, ContainerName = PersonalDataTab)]
        public virtual string Attn
        {
            get { return (string)(GetDetail("Attn") ?? string.Empty); }
            set { SetDetail("Attn", value, string.Empty); }
        }

        [EditableItem("Person", 20, ContainerName = PersonalDataTab)]
        public virtual Person Person
        {
            get { return (Person)(GetChild("Person")); }
            set { if (value != null)
            {
                value.Name = "Person";
                value.AddTo(this);
            }}
        }

        [EditableItem("PersonalDetails", 30, ContainerName = PersonalDataTab)]
        public virtual PersonalDetails PersonalDetails
        {
            get { return (PersonalDetails)(GetChild("PersonalDetails")); }
            set { if (value != null)
            {
                value.Name = "PersonalDetails";
                value.AddTo(this);
            }}
        }

        [EditableItem("RegistrationDetails", 40, ContainerName = PersonalDataTab)]
        public virtual RegistrationDetails RegistrationDetails
        {
            get { return (RegistrationDetails)(GetChild("RegistrationDetails")); }
            set { if (value != null)
            {
                value.Name = "RegistrationDetails";
                value.AddTo(this);
            }}
        }

        [EditableItem("Utilities", 50, ContainerName = PersonalDataTab)]
        public virtual Utilities Utilities
        {
            get { return (Utilities)(GetChild("Utilities")); }
            set
            {
                if (value != null)
                {
                    value.Name = "Utilities";
                    value.AddTo(this);
                }
            }
        }

        [EditableItem("Handicap", 60, ContainerName = PersonalDataTab)]
        public virtual Handicap Handicap
        {
            get { return (Handicap)(GetChild("Handicap")); }
            set
            {
                if (value != null)
                {
                    value.Name = "Handicap";
                    value.AddTo(this);
                }
            }
        }

        [EditableItem("Diet", 70, ContainerName = PersonalDataTab)]
        public virtual Diet Diet
        {
            get { return (Diet)(GetChild("Diet")); }
            set
            {
                if (value != null)
                {
                    value.Name = "Diet";
                    value.AddTo(this);
                }
            }
        }

        [EditableCheckBox("AllowPictures", 80, ContainerName = PersonalDataTab)]
        public virtual bool AllowPictures
        {
            get { return GetDetail("AllowPictures", false); }
            set { SetDetail("AllowPictures", value, false); }
        }

        [FileAttachment, EditableFileUploadAttribute("Picture", 90, ContainerName = PersonalDataTab)]
        public virtual string ImageUrl
        {
            get { return (string)base.GetDetail("Picture"); }
            set { base.SetDetail("Picture", value); }
        }

        public virtual string Description
        {
            get { return Person.Description; }
        }

        [EditableChildren("Contacts", "ContactData", "Contacts", 10, ContainerName = ContactsTab)]
	    public virtual IList<Person> Contacts
	    {
            get { return GetChildren("ContactData").Cast<Person>(); }
	    }

        [EditableChildren("Attachments", "AttachmentData", "Attachments", 20, ContainerName = AttachmentsTab)]
        public virtual IList<Attachment> Attachments
	    {
            get { return GetChildren("Attachments").Cast<Attachment>(); }
	    }

        [EditableItem("Payment", 10, ContainerName = AdministrationTab)]
        public virtual Payment Payment
        {
            get { return (Payment)(GetChild("Payment")); }
            set
            {
                if (value != null)
                {
                    value.Name = "Payment";
                    value.AddTo(this);
                }
            }
        }

        [EditableCheckBox("MedicalRecordOk", 20, ContainerName = AdministrationTab)]
        public virtual bool MedicalRecordOk
        {
            get { return (bool)(GetDetail("MedicalRecordOk") ?? false); }
            set { SetDetail("MedicalRecordOk", value, false); }
        }

        [EditableEnum("AcceptationStatus", 30, typeof(AcceptationStatus), ContainerName = AdministrationTab)]
        public virtual AcceptationStatus AcceptationStatus
        {
            get { return (AcceptationStatus)(GetDetail("AcceptationStatus") ?? AcceptationStatus.Unhandled); }
            set { SetDetail("AcceptationStatus", value, AcceptationStatus.Unhandled); }
        }

        [EditableDate("VisitDate", 40, ContainerName = AdministrationTab, ShowTime = false)]
        public virtual DateTime VisitDate
        {
            get { return (DateTime)(GetDetail("AcceptationStatus") ?? default(DateTime)); }
            set { SetDetail("VisitDate", value, default(DateTime)); }
        }

        [EditableTextBox("VisitReport", 50, ContainerName = AdministrationTab, TextMode = TextBoxMode.MultiLine, Columns = 80, Rows = 10)]
        public virtual string VisitReport
        {
            get { return GetDetail("VisitReport", ""); }
            set { SetDetail("VisitReport", value, ""); }
        }

        [EditableTextBox("Motivation", 60, ContainerName = AdministrationTab, TextMode = TextBoxMode.MultiLine, Columns = 80, Rows = 10)]
        public virtual string Motivation
        {
            get { return GetDetail("Motivation", ""); }
            set { SetDetail("Motivation", value, ""); }
        }
    }

    public enum AcceptationStatus
    {
        Unhandled,
        InProgress,
        Visited,
        Accepted,
        Rejected
    }
}
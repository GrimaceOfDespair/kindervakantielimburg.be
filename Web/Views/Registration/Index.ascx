<%@ Control Language="C#" AutoEventWireup="true" Inherits="N2.Web.Mvc.N2ModelViewUserControl<RegistrationModel, Registration>" %>

<div class="uc">
    <p>
        <%= Model.CurrentItem.Person.FirstName %>
        <%= Model.CurrentItem.Person.LastName %><br />
        <%= Model.CurrentItem.Person.Address.Street %>
        <%= Model.CurrentItem.Person.Address.Number %>
        <%= Model.CurrentItem.Person.Address.Suffix %><br />
        <%= Model.CurrentItem.Person.Address.PostalCode %>
        <%= Model.CurrentItem.Person.Address.Location %><br />
    </p>
    <p>
        Tel: <%= Model.CurrentItem.Person.Telephone.PhoneNumber %><br />
        GSM: <%= Model.CurrentItem.Person.Mobile.PhoneNumber %>
    </p>
    <p>
        Fysieke handicap? <%= Model.CurrentItem.Handicap.PhysicalHandicap %><br />
        Mentale handicap? <%= Model.CurrentItem.Handicap.MentalHandicap %><br />
        Sociale handicap? <%= Model.CurrentItem.Handicap.SocialHandicap %><br />
        Slechtziende? <%= Model.CurrentItem.Handicap.VisuallyImpaired %><br />
        IQ: <%= Model.CurrentItem.Handicap.IQ %>
    </p>
</div>
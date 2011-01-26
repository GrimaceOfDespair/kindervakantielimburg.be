<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.master" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage<RegistrationContainer>" Title="" %>

<asp:Content ContentPlaceHolderID="PostContent" runat="server">
    <table class="list registration-list tablesorter">
        <thead>
            <tr>
                <th><asp:Literal runat="server" Text="<%$ Resources: Editables, LastName.Title%>" /></th>
                <th><asp:Literal runat="server" Text="<%$ Resources: Editables, FirstName.Title%>" /></th>
                <th><asp:Literal runat="server" Text="<%$ Resources: Editables, DateOfBirth.Title%>" /></th>
                <th><asp:Literal runat="server" Text="<%$ Resources: Editables, Location.Title%>" /></th>
            </tr>
        </thead>
        <tbody>
    <%for(var i = 0; i < Model.Registrations.Count; i++){%>
            <tr>
                <td class="firstName item">
                    <%=Model.Registrations[i].Registration.Person.LastName %>
                </td>
                <td class="lastName item">
                    <%=Model.Registrations[i].Registration.Person.FirstName %>
                </td>
                <td class="dateOfBirgth item">
                    <%=Model.Registrations[i].Registration.PersonalDetails.DateOfBirth.ToShortDateString() %>
                </td>
                <td class="location item">
                    <%=Model.Registrations[i].Registration.Person.Address.Location %>
                </td>
            </tr>
    <%}%>
        </tbody>
    </table>
    <script type="text/javascript">
        // <![CDATA[
        $(function() {
            $('.registration-list').tablesorter({ widgets: ['zebra'] });
        });
        // ]>
    </script>
</asp:Content>
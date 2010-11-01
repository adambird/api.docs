<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<api.docs.admin.Models.ResourceViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Resource</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Id</div>
        <div class="display-field"><%= Model.Id %></div>
        
        <div class="display-label">Name</div>
        <div class="display-field"><%= Model.Name %></div>
        
    </fieldset>
    <p>
        <%= Html.ActionLink("Edit", "Edit", new { id=Model.Id}) %> |
        <%= Html.ActionLink("Back to List", "Index") %>
    </p>
        <%
       foreach (var doc in Model.ResourceDocs)
       {%>
       <div>
        <h4><%= doc.Language %></h4>
        <p>
            <%= doc.Summary %>
        </p>
        <p>
            <%= Html.ActionLink("Edit", "Edit", new { controller = "ResourceDocs", id = doc.Id })%> | <%= Html.ActionLink("Delete", "Delete", new { controller = "ResourceDocs", id = doc.Id })%>
        </p>
        </div>
    <%
       }%>

           <h3>Fields</h3>
    <table>
        <thead>
            <tr>
                <th>Name</th><th>Type</th><th>Description</th>
            </tr>
        </thead>
        <tbody>
    <% foreach (var field in Model.Fields)
       {%>
        <tr>
            <td><%=field.Name %></td><td><%=field.FieldType %></td><td><%=field.FieldDocs[0].Description %></td>
        </tr>
    <%
       }%>
        </tbody>
    </table>
</asp:Content>


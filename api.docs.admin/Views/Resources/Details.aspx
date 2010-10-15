<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<api.docs.admin.Models.ResourceViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Resource</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Id</div>
        <div class="display-field"><%: Model.Id %></div>
        
        <div class="display-label">Name</div>
        <div class="display-field"><%: Model.Name %></div>
        
    </fieldset>
    <p>
        <%: Html.ActionLink("Edit", "Edit", new { id=Model.Id}) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
        <%
       foreach (var doc in Model.ResourceDocs)
       {%>
       <div>
        <h4><%: doc.CultureString %></h4>
        <p>
            <%: doc.Summary %>
        </p>
        <p>
            <%= Html.ActionLink("Edit", "Edit", new { controller = "ResourceDocs", id = doc.Id })%> | <%= Html.ActionLink("Delete", "Delete", new { controller = "ResourceDocs", id = doc.Id })%>
        </p>
        </div>
    <%
       }%>
</asp:Content>


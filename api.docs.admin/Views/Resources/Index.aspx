<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<api.docs.admin.Models.ResourceViewModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Resources
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Resources</h2>
    
    <ul>
    <% foreach (var model in Model)
       {%>
       <li><%= Html.ActionLink(model.Name, "Details", new {id = model.Id}) %></li>
    <%
       }%>
    </ul>
    <%= Html.ActionLink("New Resource", "Create") %>
</asp:Content>

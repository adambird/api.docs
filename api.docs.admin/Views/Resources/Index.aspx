<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<api.docs.admin.Models.ResourcesViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Strings.ApplicationTitle %> / <%= Strings.Resources %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%= Strings.Resources %></h2>
    
    <ul>
    <% foreach (var resource in Model.Resources)
       {%>
       <li><%= Html.ActionLink(resource.Name, "Details", new { id = resource.Id })%></li>
    <%
       }%>
    </ul>
    <%= Html.ActionLink(Strings.NewResource, "Create") %>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<api.docs.Models.HomePageViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>
    <h2><%= Html.ActionLink("Resources", "Index", new { controller = "Resources" })%></h2>
    <ul>
        <% foreach (var resource in Model.Resources)
           {%>
        <li><%: Html.ActionLink(resource.Name, "Details", new { controller = "Resources", id = resource.Id})%></li>
        <%
           }%>
    </ul>
</asp:Content>

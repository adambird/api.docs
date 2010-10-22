<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<System.Collections.Generic.IEnumerable<api.docs.data.Resource>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Resources</h2>

    <ul>
    <% foreach (var resource in Model)
       {%>
       <li><%= Html.ActionLink(resource.Name, "Details", new {id = resource.Id}) %></li>
    <%
       }%>
    </ul>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>


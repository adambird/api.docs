<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ResourceViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%= Html.Encode(Model.Name)%></h2>

    <%
            foreach (var doc in Model.ResourceDocs)
            {%>
        <div class="lang <%= Html.Encode(doc.Language)%>">
            <%= doc.Summary%>
        </div>
    <%
            }
    %>
    <h3><%= Strings.Fields %></h3>
    <table>
        <thead>
            <tr><th><%= Strings.FieldName %></th><th><%= Strings.FieldType %></th><th><%= Strings.FieldDescription %></th></tr>
        </thead>
        <tbody>
<% foreach (var field in Model.Fields)
   {%>
            <tr><td><%= Html.Encode(field.Name) %></td><td><%= Html.Encode(field.FieldType) %></td><td>
            <% foreach (var doc in field.FieldDocs)
{%>
        <div class="lang <%= Html.Encode(doc.Language)%>">
            <%= doc.Description%>
        </div>
            <%
}%>
            </td></tr>
<%
   }%>
        </tbody>
    </table>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">

</asp:Content>
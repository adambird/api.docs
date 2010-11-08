<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<api.docs.admin.Models.ResourceViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%= Model.Name %></h2>  

    <h3>Documentation 
        <%
            foreach (var language in api.docs.data.Configuration.Languages)
            {%>
            <span class="<%= Model.LanguageStatus(language) %> <%= language %>"><%= language %></span>
       <%
            }%>    
    </h3>
    <div id="documentation">
        <%
            foreach (var language in api.docs.data.Configuration.Languages)
       {%>
       <div class="lang <%= language %>">
       <p>
       <% if (!Model.ResourceDocs.ContainsKey(language))
          {%>
          <%=Html.ActionLink(string.Format("Add {0} documentation", language), "Create", new { controller = "ResourceDocs", resourceId = Model.Id, language}) %>
       <%
           }
          else
{%>
            <%=Model.ResourceDocs[language].Summary%>
        </p>
        <p>
            <%=Html.ActionLink("Edit", "Edit",
                                      new {controller = "ResourceDocs", id = Model.ResourceDocs[language].Id})%> | <%=Html.ActionLink("Delete", "Delete",
                                      new {controller = "ResourceDocs", id = Model.ResourceDocs[language].Id})%>
    <%
}%>
        </p>
        </div>
    <%
       }%>
       </div>
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
            <td><%=field.Name %></td><td><%=field.FieldType %></td><td>
            <h4><%
            foreach (var language in api.docs.data.Configuration.Languages)
            {%>
            <span class="<%= field.LanguageStatus(language) %> <%= language %>"><%= language %></span>
       <%
            }%></h4>
            <% foreach (var doc in field.FieldDocs)
{%>
            <div class="lang <%=doc.Language%>">
                <%=doc.Description%>
            </div>
            <%
}%>
            </td>
        </tr>
    <%
       }%>
        </tbody>
    </table>
    <p>
        <%= Html.ActionLink("Edit", "Edit", new { id=Model.Id}) %> |
        <%= Html.ActionLink("Back to List", "Index") %>
    </p>
</asp:Content>


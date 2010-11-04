<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<api.docs.admin.Models.ResourceViewModel>" %>
<%@ Import Namespace="api.docs.admin.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Name) %>
                <%= Html.ValidationMessageFor(model => model.Name) %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
    <% } %>

    <h3>Documentation</h3>
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
       <%}%>
       
    <% using (Html.BeginForm("CreateResourceDoc", "Resources", FormMethod.Post, new { id = "createResourceDocForm" }))
       {%>
        <div class="editor-label">
            <%= Html.LabelFor(model => model.NewDoc.Language) %>
        </div>
        <div class="editor-field">
            <%= Html.DropDownListFor(model => model.NewDoc.Language, new SelectList( api.docs.data.Configuration.Languages)) %>
            <%= Html.ValidationMessageFor(model => model.NewDoc.Language) %>
        </div>
        <div class="editor-label">
            <%= Html.LabelFor(model => model.NewDoc.Summary) %>
        </div>
        <div class="editor-field">
            <%= Html.TextAreaFor(model => model.NewDoc.Summary, new { rows = 10, cols = 60 })%>
            <%= Html.ValidationMessageFor(model => model.NewDoc.Summary)%>
        </div>
        <p>
            <%= Html.HiddenFor(model => model.Id) %>
            <input type="submit" value="Add" />
        </p>
    <%}%>

    <h3>Fields</h3>
    <table>
        <thead>
            <tr>
                <th>Field</th><th>Type</th><th>Description</th>
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
    <% using (Html.BeginForm("CreateField", "Resources", FormMethod.Post, new { id = "createFieldForm" }))
       {
           %>
        <div class="editor-label">
            <%= Html.LabelFor(model => model.NewField.Name)%>
        </div>
        <div class="editor-field">
            <%= Html.TextBoxFor(model => model.NewField.Name)%>
            <%= Html.ValidationMessageFor(model => model.NewField.Name)%>
        </div>
        <div class="editor-label">
            <%= Html.LabelFor(model => model.NewField.FieldType)%>
        </div>
        <div class="editor-field">
            <%= Html.TextBoxFor(model => model.NewField.FieldType)%>
            <%= Html.ValidationMessageFor(model => model.NewField.FieldType)%>
        </div>
        <div class="editor-label">
            <%= Html.LabelFor(model => model.NewField.Description)%>
        </div>
        <div class="editor-field">
            <%= Html.TextAreaFor(model => model.NewField.Description, new { rows = 10, cols = 60 })%>
            <%= Html.ValidationMessageFor(model => model.NewField.Description)%>
        </div>
        <p>
            <%= Html.HiddenFor(model => model.Id)%>
            <input type="submit" value="Add" />
        </p>
    <%}%>
    <div>
        <%= Html.ActionLink("Back to List", "Index")%>
    </div>

</asp:Content>


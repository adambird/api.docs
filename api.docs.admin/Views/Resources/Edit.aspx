<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<api.docs.admin.Models.ResourceViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Name) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Name) %>
                <%: Html.ValidationMessageFor(model => model.Name) %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <h3>Documentation</h3>
    <% using (Html.BeginForm("CreateResourceDoc", "Resources", FormMethod.Post, new { id = "createResourceDocForm" }))
       {%>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.NewDoc.Language) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.NewDoc.Language) %>
            <%: Html.ValidationMessageFor(model => model.NewDoc.Language) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.NewDoc.Region) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.NewDoc.Region) %>
            <%: Html.ValidationMessageFor(model => model.NewDoc.Region) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.NewDoc.Summary) %>
        </div>
        <div class="editor-field">
            <%: Html.TextAreaFor(model => model.NewDoc.Summary) %>
            <%: Html.ValidationMessageFor(model => model.NewDoc.Summary)%>
        </div>
        <p>
            <%: Html.HiddenFor(model => model.Id) %>
            <input type="submit" value="Add" />
        </p>
    <%}%>
    <%
       foreach (var doc in Model.ResourceDocs)
       {%>
       <div>
        <h4><%: doc.CultureString %></h4>
        <p>
            <%: doc.Summary %>
        </p>
        </div>
    <%
       }%>
    <div>
        <%: Html.ActionLink("Back to List", "Index")%>
    </div>

</asp:Content>


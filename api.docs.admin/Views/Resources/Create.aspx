<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<api.docs.admin.Models.ResourceViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>

            <div class="editor-label">
                <%= Html.LabelFor(model => model.Name) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Name) %>
                <%= Html.ValidationMessageFor(model => model.Name) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.NewDoc.Language) %>
            </div>
            <div class="editor-field">
                <%= Html.DropDownListFor(model => model.NewDoc.Language, new SelectList( api.docs.data.Configuration.Languages))%>
                <%= Html.ValidationMessageFor(model => model.NewDoc.Language)%>
            </div>

            <div class="editor-label">
                <%= Html.LabelFor(model => model.NewDoc.Summary)%>
            </div>
            <div class="editor-field">
                <%= Html.TextAreaFor(model => model.NewDoc.Summary, new { rows = 10, cols = 60 })%>
                <%= Html.ValidationMessageFor(model => model.NewDoc.Summary)%>
            </div>

           <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%= Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>


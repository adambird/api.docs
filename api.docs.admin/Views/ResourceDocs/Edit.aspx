<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<api.docs.admin.Models.ResourceDocViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Id) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Id) %>
                <%= Html.ValidationMessageFor(model => model.Id) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Language) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Language) %>
                <%= Html.ValidationMessageFor(model => model.Language) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Region) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Region) %>
                <%= Html.ValidationMessageFor(model => model.Region) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Summary) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Summary) %>
                <%= Html.ValidationMessageFor(model => model.Summary) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.CultureString) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.CultureString) %>
                <%= Html.ValidationMessageFor(model => model.CultureString) %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%= Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>


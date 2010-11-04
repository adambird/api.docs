<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<api.docs.admin.Models.ResourceDocViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>


            <div class="editor-label">
                <%= Html.LabelFor(model => model.Language) %>
            </div>
            <div class="editor-field">
                <%= Html.DropDownListFor(model => model.Language, new SelectList(api.docs.data.Configuration.Languages))%>
                <%= Html.ValidationMessageFor(model => model.Language) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Summary) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.Summary) %>
                <%: Html.ValidationMessageFor(model => model.Summary) %>
            </div>
            <%= Html.HiddenFor(model => model.ResourceId) %>
            <p>
                <input type="submit" value="Create" />
            </p>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ResourceViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%= Html.Encode(Model.Name)%></h2>
    <div id="languageSelector">
        <%
            Html.RenderPartial("LanguageSelector"); %>
    </div>     
    <%
            foreach (var doc in Model.ResourceDocs)
            {
                var style = "";
                if (doc.Language != api.docs.data.Configuration.DefaultLanguage)
                {
                    style = "style=\"display:none\"";
                }

%>
        <div id="doc-<%= Html.Encode(doc.Language)%>" <%= style %>>
            <p>
                <%= Html.Encode(doc.Summary)%>
            </p>
        </div>
    <%
            }
    %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">

        function displayLanguage(language) {
            $('div[id^=doc-]').hide();
            $('div#doc-' + language).show();
        };

    </script>
</asp:Content>
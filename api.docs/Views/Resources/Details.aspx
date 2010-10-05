<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<api.docs.data.Resource>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%:Model.Name%></h2>

    <%
            foreach (var doc in Model.ResourceDocs)
            {
%>
        <div id="doc-<%:doc.CultureString%>">
            <p>
                <%:doc.Summary%>
            </p>
        </div>
    <%
            }
    %>
</asp:Content>

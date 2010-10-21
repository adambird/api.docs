<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<ul>
<% foreach (var language in api.docs.data.Configuration.Languages)
   {%>
       <li><a id="langswitch-<%= language %>" href="#" onclick="displayLanguage('<%= language %>');"><%= language %></a></li>
   <%}%>
   </ul>

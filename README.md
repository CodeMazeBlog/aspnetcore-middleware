# ASP.NET Core Middleware - Creating Flexible Application Flows
## https://code-maze.com/working-with-asp-net-core-middleware

ASP.NET Core Middleware is software integrated inside the application's pipeline that we can use to handle requests and responses. When we talk about the ASP.NET Core middleware, we can think of it as a code section that executes with every request. In this article, we are going to learn more about the ASP.NET Core middleware and how to use different methods (Run, Map, Use) during the configuration. Additionally, we are going to explain the process of creating custom middleware.

<p>We are going to divide this article into the following sections:</p>
<ul>
	<li><a href="#about-middleware">More About the ASP.NET Core Middleware and Pipeline</a></li>
	<li><a href="#middleware-order">Middleware Order in ASP.NET Core</a></li>
	<li><a href="#creating-first-middleware">Creating a First Middleware Component in ASP.NET Core</a></li>
	<li><a href="#using-map-mapwhen">Using the Map and MapWhen Methods for Branching</a></li>
	<li><a href="#middleware-separate-class">Creating a Middleware in a Separate Class</a></li>
</ul>

﻿using System;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using Autofac;
using Autofac.Integration.WebApi;
using BaseSPA.Core;
using BaseSPA.Core.Models;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Swashbuckle.Application;

[assembly: OwinStartup(typeof(BaseSPA.Web.Startup))]

namespace BaseSPA.Web
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			var containerBuilder = new ContainerBuilder();
			containerBuilder.RegisterModule(new ModuloCore());
			containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());
			var container = containerBuilder.Build();

			var config = new HttpConfiguration
			{
				DependencyResolver = new AutofacWebApiDependencyResolver(container)
			};

			var builder = new ODataConventionModelBuilder();
			builder.EntitySet<Survey>("Surveys");
			builder.EntitySet<Question>("Questions");
			config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());

			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			config
				.EnableSwagger(c => c.SingleApiVersion("v1", "BaseSPA"))
				.EnableSwaggerUi();

			var oAuthServerOptions = new OAuthAuthorizationServerOptions()
			{
				AllowInsecureHttp = true,
				TokenEndpointPath = new PathString("/token"),
				AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
				Provider = new SimpleAuthorizationServerProvider()
			};
			// Token Generation
			app.UseOAuthAuthorizationServer(oAuthServerOptions);
			app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

			app.UseWebApi(config);
		}
	}
}

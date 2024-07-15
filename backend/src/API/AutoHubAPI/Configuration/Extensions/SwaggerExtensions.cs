using System.Reflection;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AutoHub.API.Configuration.Extensions;

internal static class SwaggerExtensions
{
    internal static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "AutoHub API",
                Version = "v1",
                Description = "AutoHub API for modular monolith .NET application."
            });
            options.CustomSchemaIds(t => t.ToString());

            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var commentsFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var commentsFile = Path.Combine(baseDirectory, commentsFileName);
            options.IncludeXmlComments(commentsFile);

            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    Password = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = new Uri("https://localhost:7249/connect/authorize"),
                        TokenUrl = new Uri("https://localhost:7249/connect/token"),
                        Scopes = new Dictionary<string, string>
                        {
                            { "all", "Can Do All" }
                        }
                    }
                }
            });

            options.OperationFilter<AuthorizeCheckOperationFilter>();
        });

        return services;
    }

    internal static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
    {
        app.UseSwagger();

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "AutoHub API");
            c.OAuthClientId("AutoHubClientId");
            c.OAuthAppName("AutoHubUserAccess");
            c.OAuthClientSecret("AutoHubSecret");
        });

        return app;
    }

    internal class AuthorizeCheckOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var authorizeAttributes = context.MethodInfo
                .DeclaringType
                .GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true))
                .OfType<AuthorizeAttribute>();

            if (authorizeAttributes.Any())
            {
                operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });
                operation.Responses.Add("403", new OpenApiResponse { Description = "Forbidden" });

                operation.Security = new List<OpenApiSecurityRequirement>
                {
                    new OpenApiSecurityRequirement
                    {
                        [new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "oauth2"
                            }
                        }
                        ] = new[] { "all" }
                    }
                };
            }
        }
    }
}

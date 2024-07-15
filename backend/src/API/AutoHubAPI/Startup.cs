using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoHub.API.Configuration.Authorization;
using AutoHub.API.Configuration.ExecutionContext;
using AutoHub.API.Configuration.Extensions;
using AutoHub.API.Configuration.Validation;
using AutoHub.API.Modules.UserAccess;
using AutoHub.BuildingBlocks.Application;
using AutoHub.BuildingBlocks.Domain;
using AutoHub.BuildingBlocks.Infrastructure.Emails;
using AutoHub.Modules.UserAccess.Infrastructure.Configuration;
using AutoHub.Modules.UserAccess.Infrastructure.Configuration.Identity;
using AutoHub.Modules.UserRegistrations.Infrastructure.Configuration;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Authorization;
using Serilog;
using Serilog.Formatting.Compact;
using ILogger = Serilog.ILogger;

namespace AutoHub.API;

public class Startup
{
    private const string AutoHubConnectionString = "AutoHubConnectionString";
    private static ILogger _logger;
    private static ILogger _loggerForApi;
    private readonly IConfiguration _configuration;

    public Startup(IWebHostEnvironment env)
    {
        ConfigureLogger();

        _configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", false, reloadOnChange: true)
            .AddEnvironmentVariables("AutoHub_")
            .Build();

        _loggerForApi.Information("Connection string:" + _configuration.GetConnectionString(AutoHubConnectionString));
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddSwaggerDocumentation();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddSingleton<IExecutionContextAccessor, ExecutionContextAccessor>();

        services.AddProblemDetails(x =>
        {
            x.Map<InvalidCommandException>(ex => new InvalidCommandProblemDetails(ex));
            x.Map<BusinessRuleValidationException>(ex => new BusinessRuleValidationExceptionProblemDetails(ex));
        });

        services.ConfigureIdentityService();

        services.AddAuthorization(options =>
        {
            options.AddPolicy(HasPermissionAttribute.HasPermissionPolicyName, policyBuilder =>
            {
                policyBuilder.Requirements.Add(new HasPermissionAuthorizationRequirement());
                policyBuilder.AddAuthenticationSchemes("Bearer");
            });
        });

        services.AddScoped<IAuthorizationHandler, HasPermissionAuthorizationHandler>();
    }

    public void ConfigureContainer(ContainerBuilder containerBuilder)
    {
        containerBuilder.RegisterModule(new UserAccessAutofacModule());
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
    {
        var container = app.ApplicationServices.GetAutofacRoot();

        app.UseCors(builder =>
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

        InitializeModules(container);

        app.UseMiddleware<CorrelationMiddleware>();

        app.UseSwaggerDocumentation();

        if (env.IsDevelopment())
        {
            app.UseProblemDetails();
        }
        else
        {
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.AddIdentityService();

        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }

    private static void ConfigureLogger()
    {
        _logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console(
                outputTemplate:
                "`{Timestamp:HH:mm:ss} {Level:u3}` `{Module}` `{Context}` {Message:lj}{NewLine}{Exception}")
            .WriteTo.File(new CompactJsonFormatter(), "logs/logs")
        .CreateLogger();

        _loggerForApi = _logger.ForContext("Module", "API");

        _loggerForApi.Information("Logger configured");
    }

    private void InitializeModules(ILifetimeScope container)
    {
        var httpContextAccessor = container.Resolve<IHttpContextAccessor>();
        var executionContextAccessor = new ExecutionContextAccessor(httpContextAccessor);

        var emailsConfiguration = new EmailsConfiguration(
            _configuration["EmailConfiguration:FromEmail"],
            int.Parse(_configuration["EmailConfiguration:Port"]),
            _configuration["EmailConfiguration:SmtpServer"],
            _configuration["EmailConfiguration:Password"]);

        UserAccessStartup.Initialize(
            _configuration.GetConnectionString(AutoHubConnectionString),
            executionContextAccessor,
            _logger,
            emailsConfiguration,
            _configuration["Security:TextEncryptionKey"],
            null,
            null);

        RegistrationsStartup.Initialize(
            _configuration.GetConnectionString(AutoHubConnectionString),
            executionContextAccessor,
            _logger,
            emailsConfiguration,
            _configuration["Security:TextEncryptionKey"],
            null,
            null);
    }
}

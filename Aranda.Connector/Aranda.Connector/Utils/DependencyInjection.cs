// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Connector.Api.Interface.IService;
using Aranda.Connector.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Principal;

namespace Aranda.Connector.Api.Utils
{
    public static class DependencyInjection
    {
        public static void Dependency(IServiceCollection services)
        {
            services.AddScoped<IConectionService, ConectionService>();
            services.AddScoped<IManagmentCaseService, ManagmentCaseService>();
            services.AddScoped<IAuthenticationArandaService, AuthenticateService>();
            services.AddScoped<IConfigurationService, ConfigurationService>();
            services.AddScoped<IManagmentParameters, ManagmentParametersServices>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IPrincipal>(provider => provider.GetService<IHttpContextAccessor>().HttpContext.User);
        }
    }
}
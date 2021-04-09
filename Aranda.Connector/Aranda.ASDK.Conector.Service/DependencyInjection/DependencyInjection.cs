// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Connector.Service.Interface.ASDK_V9;
using Aranda.ASDK.Connector.Service.Interface.IService;
using Aranda.ASDK.Connector.Service.Services;
using Aranda.ASDK.Connector.Service.Services.ASDK_V9;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Principal;

namespace Aranda.ASDK.Connector.Service.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void Dependency(IServiceCollection services)
        {
            #region V9

            services.AddScoped<IManagmentCaseV9Service, ManagmentCaseAsdkV9Service>();
            services.AddScoped<IManagmentParametersV9Service, ManagmentParametersAsdkV9Service>();
            services.AddScoped<IManagmentUserAsdkV9Service, ManagmentUserAsdkV9Service>();
            services.AddScoped<IManagmentAdditionalFieldV9Service, ManagmentAdditionalFieldAsdkV9Service>();

            #endregion

            #region V8

            services.AddScoped<IConectionService, ConectionService>();
            services.AddScoped<IManagmentCaseService, ManagmentCaseAsdkV8Service>();
            services.AddScoped<IManagmentAdditionalFieldService, ManagmentAdditionalFieldAsdkV8Service>();
            services.AddScoped<IAuthenticationArandaService, AuthenticateAsdkV8Service>();
            services.AddScoped<IConfigurationEndPointService, ConfigurationEndPointService>();
            services.AddScoped<IManagmentParameters, ManagmentParametersAsdkV8Services>();

            #endregion

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IPrincipal>(provider => provider.GetService<IHttpContextAccessor>().HttpContext.User);
        }
    }
}
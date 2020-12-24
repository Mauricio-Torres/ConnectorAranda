// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Connector.Api.Helpers;
using Aranda.Connector.Api.Interface.IService;
using Microsoft.Extensions.Configuration;

namespace Aranda.Connector.Api.Services
{
    /// <summary>
    /// Retorna los parámetros de configuración de la aplicación
    /// </summary>
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfiguration Configuration;

        public ConfigurationService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string UrlCategories { get { return Constants.ParameterUrlCategories; } }
        public string UrlCreateCase { get { return Constants.ParameterUrlCreateCase; } }
        public string UrlGetCase { get { return Constants.ParameterUrlGetCase; } }
        public string UrlLogin { get { return Constants.ParameterUrlLogin; } }
        public string UrlProyects { get { return Constants.ParameterUrlProyects; } }
        public string UrlServiceDesk { get { return Configuration["APIService:ServiceDesk:UrlBase"]; } }
        public string UrlServices { get { return Constants.ParameterUrlServices; } }
        public string UrlUpdateCase { get { return Constants.ParameterUrlUpdateCase; } }
    }
}
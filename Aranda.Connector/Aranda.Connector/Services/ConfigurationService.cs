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

        private string urlServiceDesk;

        public ConfigurationService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string UrlAdditionalAdvancedFields { get { return Constants.ParameterUrlAdditionalAdvancedFields; } }
        public string UrlAdditionalBasicFields { get { return Constants.ParameterUrlAdditionalBasicFields; } }
        public string UrlCategories { get { return Constants.ParameterUrlCategories; } }
        public string UrlCreateCase { get { return Constants.ParameterUrlCreateCase; } }
        public string UrlGetCase { get { return Constants.ParameterUrlGetCase; } }
        public string UrlGroups { get { return Constants.ParameterUrlGroups; } }
        public string UrlItemType { get { return Constants.ParameterUrlItemType; } }
        public string UrlLogin { get { return Constants.ParameterUrlLogin; } }
        public string UrlProyects { get { return Constants.ParameterUrlProyects; } }
        public string UrlRegistryType { get { return Constants.ParameterUrlRegistryType; } }
        public string UrlResponsible { get { return Constants.ParameterUrlUrlResponsible; } }

        public string UrlServiceDesk
        {
            get { return GetUrlHost(urlServiceDesk); }
            set { urlServiceDesk = value; }
        }

        public string UrlServices { get { return Constants.ParameterUrlServices; } }

        public string UrlSLAs { get { return Constants.ParameterUrlUrlSLAs; } }
        public string UrlState { get { return Constants.ParameterUrlState; } }
        public string UrlUpdateAdditionalFields { get { return Constants.ParameterUrlUpdateAdditionalFields; } }
        public string UrlUpdateCase { get { return Constants.ParameterUrlUpdateCase; } }
        public string UrlUpdateState { get { return Constants.ParameterUrlUpdateState; } }
        public string UrlUrgency { get { return Constants.ParameterUrlUrlUrgency; } }

        private string GetUrlHost(string url)
        {
            return string.IsNullOrWhiteSpace(url) ? Configuration["APIService:ServiceDesk:UrlBase"] : url;
        }
    }
}
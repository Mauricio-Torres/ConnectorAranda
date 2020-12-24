// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Connector.Api.Helpers;
using Aranda.Connector.Api.Interface.IService;

namespace Aranda.Connector.Api.Services
{
    /// <summary>
    /// Retorna los parámetros de configuración de la aplicación
    /// </summary>
    public class ConfigurationService : IConfigurationService
    {
        public string UrlCreateCase { get { return Constants.ParameterUrlCreateCase; } }
        public string UrlGetCase { get { return Constants.ParameterUrlGetCase; } }
        public string UrlLogin { get { return Constants.ParameterUrlLogin; } }
        public string UrlUpdateCase { get { return Constants.ParameterUrlUpdateCase; } }
    }
}
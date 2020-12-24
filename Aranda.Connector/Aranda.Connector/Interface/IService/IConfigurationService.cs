// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
namespace Aranda.Connector.Api.Interface.IService
{
    /// <summary>
    /// Retorna los parámetros de configuración de la aplicación
    /// </summary>
    public interface IConfigurationService
    {
        string UrlCategories { get; }

        /// <summary>
        /// Uri Creación caso en Service Desk
        /// </summary>
        string UrlCreateCase { get; }

        /// <summary>
        /// Uri obtención casos en Service Desk
        /// </summary>
        string UrlGetCase { get; }

        /// <summary>
        /// Uri login Service Desk
        /// </summary>
        string UrlLogin { get; }

        string UrlProyects { get; }
        string UrlServiceDesk { get; }
        string UrlServices { get; }

        /// <summary>
        /// Uri actualizar Service Desk
        /// </summary>
        string UrlUpdateCase { get; }
    }
}
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
        /// <summary>
        /// Campos adicionales básicos
        /// </summary>
        string UrlAdditionalAdvancedFields { get; }

        /// <summary>
        /// Campos adicionales básicos
        /// </summary>
        string UrlAdditionalBasicFields { get; }

        string UrlCategories { get; }

        /// <summary>
        /// Uri Creación caso en Service Desk
        /// </summary>
        string UrlCreateCase { get; }

        /// <summary>
        /// Uri obtención casos en Service Desk
        /// </summary>
        string UrlGetCase { get; }

        string UrlGroups { get; }
        string UrlItemType { get; }

        /// <summary>
        /// Uri login Service Desk
        /// </summary>
        string UrlLogin { get; }

        string UrlProyects { get; }
        string UrlRegistryType { get; }
        string UrlResponsible { get; }
        string UrlServiceDesk { get; set; }
        string UrlServices { get; }

        string UrlSLAs { get; }

        /// <summary>
        /// estados de servicio
        /// </summary>
        string UrlState { get; }

        /// <summary>
        /// actualización de campos adicionales
        /// </summary>
        string UrlUpdateAdditionalFields { get; }

        /// <summary>
        /// Uri actualizar Service Desk
        /// </summary>
        string UrlUpdateCase { get; }

        string UrlUpdateState { get; }
        string UrlUrgency { get; }
    }
}
// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>

using System.Collections.Generic;

namespace Aranda.ASDK.Connector.Service.Interface.IService
{
    /// <summary>
    /// Retorna los parámetros de configuración de la aplicación
    /// </summary>
    public interface IConfigurationEndPointService
    {
        /// <summary>
        /// Campos adicionales avanzados
        /// </summary>
        string UrlAdditionalAdvancedFields { get; }

        /// <summary>
        /// Campos adicionales básicos
        /// </summary>
        string UrlAdditionalBasicFields { get; }

        /// <summary>
        /// Campos adicionales AsdkV9
        /// </summary>
        string UrlAdditionalFieldsAsdkV9 { get; }

        string UrlCategories { get; }
        string UrlCIs { get; }
        string UrlClients { get; }
        string UrlCompanies { get; }

        /// <summary>
        /// Uri Creación caso en Service Desk
        /// </summary>
        string UrlCreateCase { get; }

        /// <summary>
        /// Uri obtención casos en Service Desk
        /// </summary>
        string UrlGetCase { get; }

        string UrlGroups { get; }
        public string UrlImpactAsdkV9 { get; }
        string UrlItemType { get; }

        /// <summary>
        /// Uri login Service Desk
        /// </summary>
        string UrlLogin { get; }

        string UrlModelASDKV9 { get; }
        public string UrlOperativeLevelV9 { get; }
        public string UrlPriorityAsdkV9 { get; }
        string UrlProjects { get; }
        public string UrlProvidersV9 { get; }
        string UrlReasonsForState { get; }
        string UrlRegistryType { get; }
        string UrlResponsible { get; }

        string UrlServiceDesk { get; }
        string UrlServices { get; }

        //string UrlSlaByCi { get; }
        //string UrlSlaByClient { get; }
        //string UrlSlaByCompany { get; }
        List<string> UrlSlAs { get; }

        string UrlSLAs { get; }

        /// <summary>
        /// estados de servicio
        /// </summary>
        string UrlState { get; }

        string UrlUncV9 { get; }
        string UrlUnitsV9 { get; }

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
        string UrlUserAsdkV9 { get; }
    }
}
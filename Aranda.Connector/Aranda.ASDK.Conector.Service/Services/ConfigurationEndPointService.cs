// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Connector.Service.Extensions;
using Aranda.ASDK.Connector.Service.Interface.IService;
using Aranda.ASDK.Data.Objects.Utils;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace Aranda.ASDK.Connector.Service.Services
{
    /// <summary>
    /// Retorna los parámetros de configuración de la aplicación
    /// </summary>
    public class ConfigurationEndPointService : IConfigurationEndPointService
    {
        private readonly bool IsVersion8ASDK;
        private readonly string UrlServiceDeskV8;
        private readonly string UrlServiceDeskV9;

        public ConfigurationEndPointService(IOptions<Settings> settings)
        {
            UrlServiceDeskV8 = settings.Value.UrlServiceDeskV8;
            UrlServiceDeskV9 = settings.Value.UrlServiceDeskV9;

            IsVersion8ASDK = settings.Value.Version.Equals(Constants.Version8);
        }

        public string UrlAdditionalAdvancedFields { get { return Constants.ParameterUrlAdditionalAdvancedFields; } }
        public string UrlAdditionalBasicFields { get { return Constants.ParameterUrlAdditionalBasicFields; } }
        public string UrlAdditionalFieldsAsdkV9 { get { return Constants.ParameterUrlAdditionalFieldsV9; } }

        public string UrlCategories
        {
            get
            {
                string url;

                if (IsVersion8ASDK)
                {
                    url = Constants.ParameterUrlCategories;
                }
                else
                {
                    url = Constants.ParameterUrlCategoryByServiceAsdkV9;
                }
                return url;
            }
        }

        public string UrlCIs { get { return Constants.ParameterUrlCIsV9; } }
        public string UrlClients { get { return Constants.ParameterUrlClients; } }
        public string UrlCompanies { get { return Constants.ParameterUrlUrlCompaniesV9; } }

        public string UrlCreateCase
        {
            get
            {
                string url;

                if (IsVersion8ASDK)
                {
                    url = Constants.ParameterUrlCreateCaseV8;
                }
                else
                {
                    url = Constants.ParameterUrlCreateCaseV9;
                }
                return url;
            }
        }

        public string UrlGetCase
        {
            get
            {
                string url;

                if (IsVersion8ASDK.Equals(Constants.Version8))
                {
                    url = Constants.ParameterUrlGetCase;
                }
                else
                {
                    url = Constants.ParameterUrlGetCaseV9;
                }
                return url;
            }
        }

        public string UrlGroups
        {
            get
            {
                string url;

                if (IsVersion8ASDK.Equals(Constants.Version8))
                {
                    url = Constants.ParameterUrlGroups;
                }
                else
                {
                    url = Constants.ParameterUrlGroupsV9;
                }
                return url;
            }
        }

        public string UrlImpactAsdkV9 { get { return Constants.ParameterUrlImpactV9; } }

        public string UrlItemType
        {
            get
            {
                string url;

                if (IsVersion8ASDK.Equals(Constants.Version8))
                {
                    url = Constants.ParameterUrlItemType;
                }
                else
                {
                    url = Constants.ParameterUrlItemTypeV9;
                }
                return url;
            }
        }

        public string UrlLogin { get { return Constants.ParameterUrlLogin; } }
        public string UrlModelASDKV9 { get { return Constants.ParameterUrlModelByCategoryCaseV9; } }

        public string UrlOperativeLevelV9 { get { return Constants.ParameterUrlOperativeLevelV9; } }
        public string UrlPriorityAsdkV9 { get { return Constants.ParameterUrlPriorityV9; } }

        public string UrlProjects
        {
            get
            {
                string url;

                if (IsVersion8ASDK.Equals(Constants.Version8))
                {
                    url = Constants.ParameterUrlProyects;
                }
                else
                {
                    url = Constants.ParameterUrlProjectsAsdkV9;
                }
                return url;
            }
        }

        public string UrlProvidersV9 { get { return Constants.ParameterUrlProviderV9; } }
        public string UrlReasonsForState { get { return Constants.ParameterUrlReasonsForStateV9; } }

        public string UrlRegistryType
        {
            get
            {
                string url;

                if (IsVersion8ASDK.Equals(Constants.Version8))
                {
                    url = Constants.ParameterUrlRegistryType;
                }
                else
                {
                    url = Constants.ParameterUrlRegistryTypeV9;
                }
                return url;
            }
        }

        public string UrlResponsible
        {
            get
            {
                string url;

                if (IsVersion8ASDK.Equals(Constants.Version8))
                {
                    url = Constants.ParameterUrlUrlResponsible;
                }
                else
                {
                    url = Constants.ParameterUrlSpecialistByGroupAsdkV9;
                }
                return url;
            }
        }

        public string UrlServiceDesk
        {
            get
            {
                string url;

                if (IsVersion8ASDK.Equals(Constants.Version8))
                {
                    url = UrlServiceDeskV8.ValidationUrl();
                }
                else
                {
                    url = UrlServiceDeskV9.ValidationUrl();
                }
                return url;
            }
        }

        public string UrlServices
        {
            get
            {
                string url;

                if (IsVersion8ASDK.Equals(Constants.Version8))
                {
                    url = Constants.ParameterUrlServices;
                }
                else
                {
                    url = Constants.ParameterUrlServiceV9;
                }
                return url;
            }
        }

        public List<string> UrlSlAs
        {
            get
            {
                return new List<string> {
                    Constants.ParameterUrlSlaByCi,
                    Constants.ParameterUrlSlaByClient,
                    Constants.ParameterUrlSlaByCompany
                    };
            }
        }

        //public string UrlSlaByCi { get { return Constants.ParameterUrlSlaByCi; } }
        //public string UrlSlaByClient { get { return Constants.ParameterUrlSlaByClient; } }
        //public string UrlSlaByCompany { get { return Constants.ParameterUrlSlaByCompany; } }
        public string UrlSLAs { get { return Constants.ParameterUrlUrlSLAs; } }

        // public string UrlSpecialist { get { return Constants.ParameterUrlSpecialistByGroupAsdkV9; } }

        public string UrlState
        {
            get
            {
                string url;

                if (IsVersion8ASDK.Equals(Constants.Version8))
                {
                    url = Constants.ParameterUrlState;
                }
                else
                {
                    url = Constants.ParameterUrlStatesByModelV9;
                }
                return url;
            }
        }

        public string UrlUncV9 { get { return Constants.ParameterUrlUcV9; } }
        public string UrlUnitsV9 { get { return Constants.ParameterUrlUnitsV9; } }
        public string UrlUpdateAdditionalFields { get { return Constants.ParameterUrlUpdateAdditionalFields; } }
        public string UrlUpdateCase { get { return Constants.ParameterUrlUpdateCase; } }
        public string UrlUpdateState { get { return Constants.ParameterUrlUpdateState; } }

        public string UrlUrgency
        {
            get
            {
                string url;

                if (IsVersion8ASDK.Equals(Constants.Version8))
                {
                    url = Constants.ParameterUrlUrlUrgency;
                }
                else
                {
                    url = Constants.ParameterUrlUrgencyV9;
                }
                return url;
            }
        }

        public string UrlUserAsdkV9 { get { return Constants.ParameterUrlUserV9; } }
    }
}
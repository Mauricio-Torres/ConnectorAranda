// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Connector.Service.Extensions;
using Aranda.ASDK.Connector.Service.Interface.ASDK_V9;
using Aranda.ASDK.Connector.Service.Interface.IService;
using Aranda.ASDK.Data.Objects.Models;
using Aranda.ASDK.Data.Objects.Models.Models_ASDK_V9;
using Aranda.ASDK.Data.Objects.Models.ResponseApi;
using Aranda.ASDK.Data.Objects.Models.ResponseApi.ASDK_V9;
using Aranda.ASDK.Data.Objects.Utils;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Aranda.ASDK.Connector.Service.Services.ASDK_V9
{
    internal class ManagmentParametersAsdkV9Service : IManagmentParametersV9Service
    {
        private readonly IConfigurationEndPointService ConfigurationService;
        private readonly IConectionService ConnectionService;
        private readonly ClaimsPrincipal Principal;
        private readonly string token;

        public ManagmentParametersAsdkV9Service(IPrincipal principal,
                                      IConfigurationEndPointService configurationService,
                                      IConectionService conectionService)
        {
            Principal = principal as ClaimsPrincipal;
            ConfigurationService = configurationService;
            ConnectionService = conectionService;
            token = Principal.TokenAuthenticationASDK_V9();
        }

        public async Task<OutputParametersDto> GetAllItemType()
        {
            string uriItemType = ConfigurationService.UrlItemType;

            string endpoint = ConfigurationService.UrlServiceDesk + uriItemType;

            return await AnswerParameters(endpoint);
        }

        public async Task<OutputParametersDto> GetCategoryByService(int itemType, int serviceId)
        {
            string uriCategories = ConfigurationService.UrlCategories.ConvertUrl(new UrlParameters
            {
                itemType = itemType,
                serviceId = serviceId,
                dataType = "all"
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uriCategories;

            var answerGetCategory = await ConnectionService.GetAsync<AnswerGetCategoryByServiceV9Api>(token, endpoint, Constants.NameHeaderTokenASDK_V9);

            return new OutputParametersDto
            {
                Parameters = answerGetCategory.Content.MapperModelParameters()
            };
        }

        public async Task<OutputParametersDto> GetCIs(int projectId, int itemType, int serviceId)
        {
            string uri = ConfigurationService.UrlCIs.ConvertUrl(new UrlParameters
            {
                application = Constants.TypeApplication,
                projectId = projectId,
                itemType = itemType,
                serviceId = serviceId
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uri;
            return await AnswerParameters(endpoint);
        }

        public async Task<OutputParametersDto> GetCompanies(int itemType, int projectId, int? clientId, int? serviceId)
        {
            UrlParameters urlParameters = new UrlParameters
            {
                itemType = itemType,
                projectId = projectId,
                clientId = clientId,
                serviceId = serviceId
            };

            if (clientId != null && serviceId != null)
            {
                urlParameters.application = Constants.TypeApplication;
            }

            string uri = ConfigurationService.UrlCompanies.ConvertUrl(urlParameters, true);

            string endpoint = ConfigurationService.UrlServiceDesk + uri;

            return await AnswerParameters(endpoint);
        }

        public async Task<OutputParametersDto> GetCustomers(int itemType, int projectId, int? companyId, int? serviceId)
        {
            UrlParameters urlParameters = new UrlParameters
            {
                itemType = itemType,
                projectId = projectId,
                companyId = companyId,
                serviceId = serviceId
            };

            if (companyId != null && serviceId != null)
            {
                urlParameters.application = Constants.TypeApplication;
            }

            string uri = ConfigurationService.UrlClients.ConvertUrl(urlParameters, true);

            string endpoint = ConfigurationService.UrlServiceDesk + uri;

            return await AnswerParameters(endpoint);
        }

        /// <summary>
        /// Listado de grupos responsable por servicio y estado
        /// </summary>
        /// <param name="stateId"></param>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        public async Task<OutputParametersDto> GetGroupsByState(int stateId, int serviceId)
        {
            UrlParameters urlParameters = new UrlParameters
            {
                stateId = stateId,
                serviceId = serviceId
            };

            string uri = ConfigurationService.UrlGroups.ConvertUrl(urlParameters);

            string endpoint = ConfigurationService.UrlServiceDesk + uri;

            var answerGetGroups = await ConnectionService.GetAsync<AnswerGetGroupsV9Api>(token, endpoint, Constants.NameHeaderTokenASDK_V9);

            return new OutputParametersDto
            {
                Parameters = answerGetGroups.Content.MapperModelParameters()
            };
        }

        public async Task<OutputParametersDto> GetImpact()
        {
            string uri = ConfigurationService.UrlImpactAsdkV9;

            string endpoint = ConfigurationService.UrlServiceDesk + uri;

            return await AnswerPriority(endpoint);
        }

        public async Task<ModelByCategoryV9> GetModelByCategory(int itemType, int categoryId)
        {
            string uri = ConfigurationService.UrlModelASDKV9.ConvertUrl(new UrlParameters
            {
                categoryId = categoryId,
                itemType = itemType
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uri;

            return await ConnectionService.GetAsync<ModelByCategoryV9>(token, endpoint, Constants.NameHeaderTokenASDK_V9);
        }

        public async Task<OutputParametersDto> GetOla(int unitId, int serviceId)
        {
            string uri = ConfigurationService.UrlOperativeLevelV9.ConvertUrl(new UrlParameters
            {
                serviceId = serviceId,
                unitId = unitId
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uri;

            Parameters data = await ConnectionService.GetAsync<Parameters>(token, endpoint, Constants.NameHeaderTokenASDK_V9);

            return new OutputParametersDto
            {
                Parameters = data.ConvertToList()
            };
        }

        public async Task<OutputParametersDto> GetPriority()
        {
            string uri = ConfigurationService.UrlPriorityAsdkV9;

            string endpoint = ConfigurationService.UrlServiceDesk + uri;

            return await AnswerPriority(endpoint);
        }

        public async Task<OutputParametersDto> GetProject()
        {
            string uri = ConfigurationService.UrlProjects;
            string endpoint = ConfigurationService.UrlServiceDesk + uri;

            dynamic obj = new
            {
                consoleType = Constants.TypeConsole_Specialist
            };

            AnswerGetProjectV9Api projectAsdkV9 = await ConnectionService.PostAsync<AnswerGetProjectV9Api>(token, endpoint, obj, Constants.NameHeaderTokenASDK_V9);

            return new OutputParametersDto
            {
                Parameters = projectAsdkV9.Content.MapperModelParameters()
            };
        }

        public async Task<OutputParametersDto> GetProviders(int projectId, int serviceId)
        {
            string uri = ConfigurationService.UrlProvidersV9.ConvertUrl(new UrlParameters
            {
                serviceId = serviceId,
                projectId = projectId,
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uri;

            return await AnswerParameters(endpoint);
        }

        public async Task<OutputParametersDto> GetReasonsForState(int stateId)
        {
            string uri = ConfigurationService.UrlReasonsForState.ConvertUrl(new UrlParameters
            {
                stateId = stateId,
                language = "esp"
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uri;

            var answerGetGroups = await ConnectionService.GetAsync<AnswerGetReasonsByStateV9>(token, endpoint, Constants.NameHeaderTokenASDK_V9);

            return new OutputParametersDto
            {
                Parameters = answerGetGroups.Content.MapperModelParameters()
            };
        }

        public async Task<OutputParametersDto> GetRegistryType()
        {
            string uri = ConfigurationService.UrlRegistryType;

            string endpoint = ConfigurationService.UrlServiceDesk + uri;

            return await AnswerPriority(endpoint);
        }

        public async Task<OutputParametersDto> GetResponsible(int groupId, int projectId)
        {
            string uri = ConfigurationService.UrlResponsible.ConvertUrl(new UrlParameters
            {
                groupId = groupId,
                projectId = projectId,
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uri;

            return await AnswerParameters(endpoint);
        }

        public async Task<OutputParametersDto> GetServices(int projectId)
        {
            string uri = ConfigurationService.UrlServices.ConvertUrl(new UrlParameters
            {
                projectId = projectId,
                consoleType = Constants.TypeConsole_Specialist,
                application = Constants.TypeApplication
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uri;

            return await AnswerParameters(endpoint);
        }

        public async Task<OutputParametersDto> GetSLA(int serviceId, int itemType)
        {
            UrlParameters urlParameters = new UrlParameters
            {
                serviceId = serviceId,
                itemType = itemType
            };

            List<Parameters> listSla = new List<Parameters>();

            foreach (var url in ConfigurationService.UrlSlAs)
            {
                string uri = url.ConvertUrl(urlParameters);

                string endpoint = ConfigurationService.UrlServiceDesk + uri;

                Parameters parameter = await ConnectionService.GetAsync<Parameters>(token, endpoint, Constants.NameHeaderTokenASDK_V9);

                listSla.AddUnic(parameter);
            }

            return new OutputParametersDto
            {
                Parameters = listSla
            };
        }

        public async Task<OutputParametersDto> GetState(int itemType, int categoryId)
        {
            OutputParametersDto answerParametersApi = new OutputParametersDto();
            ModelByCategoryV9 model = await GetModelByCategory(itemType, categoryId);

            if (model.Id != null)
            {
                string uri = ConfigurationService.UrlState.ConvertUrl(new UrlParameters
                {
                    itemType = itemType,
                    modelId = model.Id
                });
                string endpoint = ConfigurationService.UrlServiceDesk + uri;

                AnswerGetStateByModelV9Api projectAsdkV9 = await ConnectionService.GetAsync<AnswerGetStateByModelV9Api>(token, endpoint, Constants.NameHeaderTokenASDK_V9);
                answerParametersApi.Parameters = projectAsdkV9.Content.MapperModelParameters();
            }

            return answerParametersApi;
        }

        public async Task<OutputParametersDto> GetUc(int providerId, int serviceId)
        {
            string uri = ConfigurationService.UrlUncV9.ConvertUrl(new UrlParameters
            {
                serviceId = serviceId,
                providerId = providerId,
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uri;

            Parameters data = await ConnectionService.GetAsync<Parameters>(token, endpoint, Constants.NameHeaderTokenASDK_V9);

            return new OutputParametersDto
            {
                Parameters = data.ConvertToList()
            };
        }

        public async Task<OutputParametersDto> GetUnits(int serviceId, int projectId)
        {
            string uri = ConfigurationService.UrlUnitsV9.ConvertUrl(new UrlParameters
            {
                serviceId = serviceId,
                projectId = projectId,
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uri;

            return await AnswerParameters(endpoint);
        }

        public async Task<OutputParametersDto> GetUrgency()
        {
            string uri = ConfigurationService.UrlUrgency;

            string endpoint = ConfigurationService.UrlServiceDesk + uri;

            return await AnswerPriority(endpoint);
        }

        private async Task<OutputParametersDto> AnswerParameters(string endpoint)
        {
            var answerGetCategoryApis = await ConnectionService.GetAsync<AnswerGeneralParametersV9>(token, endpoint, Constants.NameHeaderTokenASDK_V9);

            return new OutputParametersDto
            {
                Parameters = answerGetCategoryApis.Content.MapperModelParameters()
            };
        }

        private async Task<OutputParametersDto> AnswerPriority(string endpoint)
        {
            AnswerGetGeneralPriorityV9Api answerGetCategoryApis = await ConnectionService.GetAsync<AnswerGetGeneralPriorityV9Api>(token, endpoint, Constants.NameHeaderTokenASDK_V9);

            return new OutputParametersDto
            {
                Parameters = answerGetCategoryApis.Content.MapperModelParameters()
            };
        }
    }
}
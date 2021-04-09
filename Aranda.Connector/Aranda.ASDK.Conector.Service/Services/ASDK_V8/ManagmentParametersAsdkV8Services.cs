// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Connector.Service.Extensions;
using Aranda.ASDK.Connector.Service.Interface.IService;
using Aranda.ASDK.Data.Objects.Models;
using Aranda.ASDK.Data.Objects.Models.ResponseApi;
using Aranda.ASDK.Data.Objects.Models.ResponseApi.ASDK_V8;
using Aranda.ASDK.Data.Objects.Utils;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Aranda.ASDK.Connector.Service.Services
{
    public class ManagmentParametersAsdkV8Services : IManagmentParameters
    {
        private readonly IConfigurationEndPointService ConfigurationService;
        private readonly IConectionService ConnectionService;
        private readonly ClaimsPrincipal Principal;

        public ManagmentParametersAsdkV8Services(IConfigurationEndPointService configurationService,
                                           IConectionService conectionService,
                                           IPrincipal principal)
        {
            ConfigurationService = configurationService;
            ConnectionService = conectionService;
            Principal = principal as ClaimsPrincipal;
        }

        public OutputParametersDto GetAllItemType()
        {
            List<Parameters> parameters = new List<Parameters>
            {
               new Parameters
               {
                   Id=1,
                   Name = Constants.Incidente
               },
               new Parameters
               {
                   Id=2,
                   Name = Constants.Problema
               },
               new Parameters
               {
                   Id=3,
                   Name = Constants.Cambio
               },
               new Parameters
               {
                   Id=4,
                   Name = Constants.Requerimiento
               },
            };

            return new OutputParametersDto
            {
                Parameters = parameters
            };
        }

        public async Task<OutputParametersDto> GetCategory(int serviceId, int projectId)
        {
            // test

            string uriGetCase = ConfigurationService.UrlCategories.ConvertUrl(new UrlParameters
            {
                projectId = projectId,
                serviceId = serviceId
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<AnswerGetCategoryApi>(Principal.User().KeyAuthorization, endpoint);
        }

        public async Task<OutputParametersDto> GetGroups(int serviceId)
        {
            string uriGetCase = ConfigurationService.UrlGroups.ConvertUrl(new UrlParameters
            {
                serviceId = serviceId,
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<AnswerGeneralParametersApi>(Principal.User().KeyAuthorization, endpoint);
        }

        public async Task<OutputParametersDto> GetItemType(int categoryId, int projectId)
        {
            string uriGetCase = ConfigurationService.UrlItemType.ConvertUrl(new UrlParameters
            {
                categoryId = categoryId,
                projectId = projectId
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<AnswerGeneralParametersApi>(Principal.User().KeyAuthorization, endpoint);
        }

        public OutputParametersDto GetLevelDetail()
        {
            List<Parameters> parameters = new List<Parameters>
            {
               new Parameters
               {
                   Id=0,
                   Name = Constants.Bajo
               },
               new Parameters
               {
                   Id=1,
                   Name = Constants.Medio
               },
               new Parameters
               {
                   Id=2,
                   Name = Constants.Alto
               },
            };

            return new OutputParametersDto
            {
                Parameters = parameters
            };
        }

        public async Task<OutputParametersDto> GetProyect()
        {
            string uriGetCase = ConfigurationService.UrlProjects.ConvertUrl(new UrlParameters
            {
                userId = Principal.User().Id
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<Parameters>(Principal.User().KeyAuthorization, endpoint);
        }

        public async Task<OutputParametersDto> GetRegistryType()
        {
            string uriGetCase = ConfigurationService.UrlRegistryType;
            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<AnswerGeneralParametersApi>(Principal.User().KeyAuthorization, endpoint);
        }

        public async Task<OutputParametersDto> GetResponsible(int groupId, int projectId)
        {
            string uriGetCase = ConfigurationService.UrlResponsible.ConvertUrl(new UrlParameters
            {
                groupId = groupId,
                projectId = projectId
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<AnswerGeneralParametersApi>(Principal.User().KeyAuthorization, endpoint);
        }

        public async Task<OutputParametersDto> GetServices(int projectId)
        {
            string uriGetCase = ConfigurationService.UrlServices.ConvertUrl(new UrlParameters
            {
                userId = Principal.User().Id,
                projectId = projectId
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<AnswerGetServicesApi>(Principal.User().KeyAuthorization, endpoint);
        }

        public async Task<OutputParametersDto> GetSLAs(int serviceId, int itemType)
        {
            string uriGetCase = ConfigurationService.UrlSLAs.ConvertUrl(new UrlParameters
            {
                itemType = itemType,
                serviceId = serviceId
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<AnswerGeneralParametersApi>(Principal.User().KeyAuthorization, endpoint);
        }

        public async Task<OutputParametersDto> GetState(int itemType, int projectId)
        {
            string uriGetCase = ConfigurationService.UrlState.ConvertUrl(new UrlParameters
            {
                itemType = itemType,
                projectId = projectId
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<AnswerGeneralParametersApi>(Principal.User().KeyAuthorization, endpoint);
        }

        public async Task<OutputParametersDto> GetStateWhenUpdateCase(int itemType)
        {
            string uriGetCase = ConfigurationService.UrlUpdateState.ConvertUrl(new UrlParameters
            {
                itemType = itemType
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<AnswerGetStateApi>(Principal.User().KeyAuthorization, endpoint);
        }

        public async Task<OutputParametersDto> GetUrgency()
        {
            string uriGetCase = ConfigurationService.UrlUrgency;

            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<AnswerGeneralParametersApi>(Principal.User().KeyAuthorization, endpoint);
        }

        private async Task<OutputParametersDto> AnswerParameters<TModel>(string KeyAuthorization, string endpoint) where TModel : class
        {
            List<TModel> answerGetCategoryApis = await ConnectionService.GetAsync<List<TModel>>(KeyAuthorization, endpoint);

            return new OutputParametersDto
            {
                Parameters = answerGetCategoryApis.MapperModelParameters()
            };
        }
    }
}
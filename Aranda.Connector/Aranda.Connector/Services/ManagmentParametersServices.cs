// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Connector.Api.Interface.IService;
using Aranda.Connector.Api.Models;
using Aranda.Connector.Api.Models.ResponseApi;
using Aranda.Connector.Api.Utils.Extensions;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Aranda.Connector.Api.Services
{
    public class ManagmentParametersServices : IManagmentParameters
    {
        private readonly IConfigurationEndPointService ConfigurationService;
        private readonly IConectionService ConnectionService;
        private readonly ClaimsPrincipal Principal;

        public ManagmentParametersServices(IConfigurationEndPointService configurationService,
                                           IConectionService conectionService,
                                           IPrincipal principal)
        {
            ConfigurationService = configurationService;
            ConnectionService = conectionService;
            Principal = principal as ClaimsPrincipal;
        }

        public async Task<AnswerParameters> GetCategory(int serviceId, int projectId)
        {
            string uriGetCase = ConfigurationService.UrlCategories.ConvertUrl(new UrlParameters
            {
                projectId = projectId,
                serviceId = serviceId
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<AnswerGetCategoryApi>(Principal.User().KeyAuthorization, endpoint);
        }

        public async Task<AnswerParameters> GetGroups(int serviceId)
        {
            string uriGetCase = ConfigurationService.UrlGroups.ConvertUrl(new UrlParameters
            {
                serviceId = serviceId,
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<AnswerFieldParameters>(Principal.User().KeyAuthorization, endpoint);
        }

        public async Task<AnswerParameters> GetItemType(int categoryId, int projectId)
        {
            string uriGetCase = ConfigurationService.UrlItemType.ConvertUrl(new UrlParameters
            {
                categoryId = categoryId,
                projectId = projectId
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<AnswerFieldParameters>(Principal.User().KeyAuthorization, endpoint);
        }

        public async Task<AnswerParameters> GetProyect()
        {
            string uriGetCase = ConfigurationService.UrlProyects.ConvertUrl(new UrlParameters
            {
                userId = Principal.User().Id
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<Parameters>(Principal.User().KeyAuthorization, endpoint);
        }

        public async Task<AnswerParameters> GetRegistryType()
        {
            string uriGetCase = ConfigurationService.UrlRegistryType;
            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<AnswerFieldParameters>(Principal.User().KeyAuthorization, endpoint);
        }

        public async Task<AnswerParameters> GetResponsible(int groupId, int projectId)
        {
            string uriGetCase = ConfigurationService.UrlResponsible.ConvertUrl(new UrlParameters
            {
                groupId = groupId,
                projectId = projectId
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<AnswerFieldParameters>(Principal.User().KeyAuthorization, endpoint);
        }

        public async Task<AnswerParameters> GetServices(int projectId)
        {
            string uriGetCase = ConfigurationService.UrlServices.ConvertUrl(new UrlParameters
            {
                userId = Principal.User().Id,
                projectId = projectId
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<AnswerGetServices>(Principal.User().KeyAuthorization, endpoint);
        }

        public async Task<AnswerParameters> GetSLAs(int serviceId, int itemType)
        {
            string uriGetCase = ConfigurationService.UrlSLAs.ConvertUrl(new UrlParameters
            {
                itemType = itemType,
                serviceId = serviceId
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<AnswerFieldParameters>(Principal.User().KeyAuthorization, endpoint);
        }

        public async Task<AnswerParameters> GetState(int itemType, int projectId)
        {
            string uriGetCase = ConfigurationService.UrlState.ConvertUrl(new UrlParameters
            {
                itemType = itemType,
                projectId = projectId
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<AnswerFieldParameters>(Principal.User().KeyAuthorization, endpoint);
        }

        public async Task<AnswerParameters> GetStateWhenUpdateCase(int itemType)
        {
            string uriGetCase = ConfigurationService.UrlUpdateState.ConvertUrl(new UrlParameters
            {
                itemType = itemType
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<AnswerGetState>(Principal.User().KeyAuthorization, endpoint);
        }

        public async Task<AnswerParameters> GetUrgency()
        {
            string uriGetCase = ConfigurationService.UrlUrgency;

            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<AnswerFieldParameters>(Principal.User().KeyAuthorization, endpoint);
        }

        private async Task<AnswerParameters> AnswerParameters<TModel>(string KeyAuthorization, string endpoint) where TModel : class
        {
            List<TModel> answerGetCategoryApis = await ConnectionService.GetAsync<List<TModel>>(KeyAuthorization, endpoint);

            return new AnswerParameters
            {
                Parameters = answerGetCategoryApis.MapperModelParameters()
            };
        }
    }
}
// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Connector.Api.Interface.IService;
using Aranda.Connector.Api.Models;
using Aranda.Connector.Api.Models.ResponseApi;
using Aranda.Connector.Api.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aranda.Connector.Api.Services
{
    public class ManagmentParametersServices : IManagmentParameters
    {
        private readonly IConfigurationService ConfigurationService;
        private readonly IConectionService ConnectionService;

        public ManagmentParametersServices(IConfigurationService configurationService, IConectionService conectionService)
        {
            ConfigurationService = configurationService;
            ConnectionService = conectionService;
        }

        public async Task<AnswerParameters> GetCategory(UserServiceDesk user, int serviceId, int projectId)
        {
            string uriGetCase = ConfigurationService.UrlCategories.ConvertUrl(new UrlParameters
            {
                projectId = projectId,
                serviceId = serviceId
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<AnswerGetCategoryApi>(user.KeyAuthorizationAranda, endpoint);
        }

        public async Task<AnswerParameters> GetGroups(UserServiceDesk user, int serviceId)
        {
            string uriGetCase = ConfigurationService.UrlGroups.ConvertUrl(new UrlParameters
            {
                serviceId = serviceId,
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<AnswerFieldParameters>(user.KeyAuthorizationAranda, endpoint);
        }

        public async Task<AnswerParameters> GetItemType(UserServiceDesk user, int categoryId, int projectId)
        {
            string uriGetCase = ConfigurationService.UrlItemType.ConvertUrl(new UrlParameters
            {
                categoryId = categoryId,
                projectId = projectId
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<AnswerFieldParameters>(user.KeyAuthorizationAranda, endpoint);
        }

        public async Task<AnswerParameters> GetProyect(UserServiceDesk user)
        {
            string uriGetCase = ConfigurationService.UrlProyects.ConvertUrl(new UrlParameters
            {
                userId = user.UserId
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<Parameters>(user.KeyAuthorizationAranda, endpoint);
        }

        public async Task<AnswerParameters> GetRegistryType(UserServiceDesk user)
        {
            string uriGetCase = ConfigurationService.UrlRegistryType;
            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<AnswerFieldParameters>(user.KeyAuthorizationAranda, endpoint);
        }

        public async Task<AnswerParameters> GetResponsible(UserServiceDesk user, int groupId, int projectId)
        {
            string uriGetCase = ConfigurationService.UrlResponsible.ConvertUrl(new UrlParameters
            {
                groupId = groupId,
                projectId = projectId
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<AnswerFieldParameters>(user.KeyAuthorizationAranda, endpoint);
        }

        public async Task<AnswerParameters> GetServices(UserServiceDesk user, int projectId)
        {
            string uriGetCase = ConfigurationService.UrlServices.ConvertUrl(new UrlParameters
            {
                userId = user.UserId,
                projectId = projectId
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<AnswerGetServices>(user.KeyAuthorizationAranda, endpoint);
        }

        public async Task<AnswerParameters> GetSLAs(UserServiceDesk user, int serviceId, int itemType)
        {
            string uriGetCase = ConfigurationService.UrlSLAs.ConvertUrl(new UrlParameters
            {
                itemType = itemType,
                serviceId = serviceId
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<AnswerFieldParameters>(user.KeyAuthorizationAranda, endpoint);
        }

        public async Task<AnswerParameters> GetState(UserServiceDesk user, int itemType, int projectId)
        {
            string uriGetCase = ConfigurationService.UrlState.ConvertUrl(new UrlParameters
            {
                itemType = itemType,
                projectId = projectId
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<AnswerFieldParameters>(user.KeyAuthorizationAranda, endpoint);
        }

        public async Task<AnswerParameters> GetStateWhenUpdateCase(UserServiceDesk user, int itemType)
        {
            string uriGetCase = ConfigurationService.UrlUpdateState.ConvertUrl(new UrlParameters
            {
                itemType = itemType
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<AnswerGetState>(user.KeyAuthorizationAranda, endpoint);
        }

        public async Task<AnswerParameters> GetUrgency(UserServiceDesk user)
        {
            string uriGetCase = ConfigurationService.UrlUrgency;

            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await AnswerParameters<AnswerFieldParameters>(user.KeyAuthorizationAranda, endpoint);
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
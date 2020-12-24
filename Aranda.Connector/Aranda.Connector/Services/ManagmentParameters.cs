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
    public class ManagmentParameters : IManagmentParameters
    {
        private readonly IConfigurationService ConfigurationService;
        private readonly IConectionService ConnectionService;

        public ManagmentParameters(IConfigurationService configurationService, IConectionService conectionService)
        {
            ConfigurationService = configurationService;
            ConnectionService = conectionService;
        }

        public async Task<List<Parameters>> GetCategory(UserServiceDesk user, int projectId)
        {
            string uriGetCase = ConfigurationService.UrlCategories.ConvertUrl(null, null, user.UserId, null, projectId);

            string endpoint = ConfigurationService.UrlBase + uriGetCase;
            List<AnswerGetCategoryApi> answerGetCategoryApis = await ConnectionService.GetAsync<List<AnswerGetCategoryApi>>(user.KeyAuthorizationAranda, endpoint);

            return answerGetCategoryApis.ConvertModel();
        }

        public async Task<List<Parameters>> GetProyect(UserServiceDesk user)
        {
            string uriGetCase = ConfigurationService.UrlProyects.ConvertUrl(null, null, user.UserId);
            string endpoint = ConfigurationService.UrlBase + uriGetCase;

            List<Parameters> answerProjects = await ConnectionService.GetAsync<List<Parameters>>(user.KeyAuthorizationAranda, endpoint);

            return answerProjects;
        }

        public async Task<List<Parameters>> GetServices(UserServiceDesk user, int projectId)
        {
            string uriGetCase = ConfigurationService.UrlCategories.ConvertUrl(null, null, user.UserId, null, projectId);
            string endpoint = ConfigurationService.UrlBase + uriGetCase;

            List<AnswerGetServices> answerGetCategoryApis = await ConnectionService.GetAsync<List<AnswerGetServices>>(user.KeyAuthorizationAranda, endpoint);

            return answerGetCategoryApis.ConvertModel();
        }
    }
}
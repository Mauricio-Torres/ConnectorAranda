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

        public async Task<ResponseParameters> GetCategory(UserServiceDesk user, int projectId)
        {
            string uriGetCase = ConfigurationService.UrlCategories.ConvertUrl(null, null, user.UserId, null, projectId);

            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;
            List<AnswerGetCategoryApi> answerGetCategoryApis = await ConnectionService.GetAsync<List<AnswerGetCategoryApi>>(user.KeyAuthorizationAranda, endpoint);

            return new ResponseParameters { Parameters = answerGetCategoryApis.MapperModel() };
        }

        public async Task<ResponseParameters> GetProyect(UserServiceDesk user)
        {
            string uriGetCase = ConfigurationService.UrlProyects.ConvertUrl(null, null, user.UserId);
            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return new ResponseParameters { Parameters = await ConnectionService.GetAsync<List<Parameters>>(user.KeyAuthorizationAranda, endpoint) };
        }

        public async Task<ResponseParameters> GetServices(UserServiceDesk user, int projectId)
        {
            string uriGetCase = ConfigurationService.UrlServices.ConvertUrl(null, null, user.UserId, null, projectId);
            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            List<AnswerGetServices> answerGetCategoryApis = await ConnectionService.GetAsync<List<AnswerGetServices>>(user.KeyAuthorizationAranda, endpoint);

            return new ResponseParameters { Parameters = answerGetCategoryApis.MapperModel() };
        }
    }
}
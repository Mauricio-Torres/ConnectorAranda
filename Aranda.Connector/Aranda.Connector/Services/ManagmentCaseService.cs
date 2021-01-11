// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Connector.Api.Interface.IService;
using Aranda.Connector.Api.Models;
using Aranda.Connector.Api.Models.ConvertDataApi;
using Aranda.Connector.Api.Models.Input;
using Aranda.Connector.Api.Models.Response;
using Aranda.Connector.Api.Models.ResponseApi;
using Aranda.Connector.Api.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aranda.Connector.Api.Services
{
    public class ManagmentCaseService : IManagmentCaseService
    {
        private readonly IConfigurationService ConfigurationService;
        private readonly IConectionService ConnectionService;

        public ManagmentCaseService(IConfigurationService configurationService, IConectionService conectionService)
        {
            ConfigurationService = configurationService;
            ConnectionService = conectionService;
        }

        /// <summary>
        /// Adiciona un caso en la aplicación Service Desk
        /// </summary>
        /// <param name="input">Parámetros para crear un caso </param>
        /// <param name="user">Usuario autenticado</param>
        /// <returns>estado del caso creado</returns>
        public async Task<AnswerCreateCase> Create(InputCreateCaseDto input, UserServiceDesk user)
        {
            UrlParameters parameterUrl = new UrlParameters
            {
                itemType = input.CaseType
            };

            string uriCreateCase = ConfigurationService.UrlCreateCase.ConvertUrl(parameterUrl);
            string endpoint = ConfigurationService.UrlServiceDesk + uriCreateCase;

            CreateCase createCase = input.MapperModelCreate();
            createCase.AuthorId = user.UserId;

            List<AnswerApi> listProperty = new List<AnswerApi>();
            listProperty.FillProperties(createCase, true);

            List<AnswerApi> answerApi = await ConnectionService.PostAsync<List<AnswerApi>>(user.KeyAuthorizationAranda, endpoint, listProperty);
            AnswerCreateCase answerCreate = answerApi.ConvertModel(new AnswerCreateCase());

            List<UpdateFields> listAdditionalFields = input.AdditionalFields.MapperModelUpdateFields(user.UserId, answerCreate.ItemId, input.CaseType);

            string uriUpdateFields = ConfigurationService.UrlUpdateAdditionalFields;
            string endpointFields = ConfigurationService.UrlServiceDesk + uriUpdateFields;

            await ConnectionService.PostAsync(user.KeyAuthorizationAranda, endpointFields, listAdditionalFields);

            return answerCreate;
        }

        /// <summary>
        /// Retorna caso de la aplicación Service Desk
        /// </summary>
        /// <param name="input">Parámetros para solicitar información del caso a consultar</param>
        /// <param name="user">Usuario autenticado</param>
        /// <returns>información caso </returns>
        public async Task<AnswerGetCaseApi> Get(InputGetCaseDto input, UserServiceDesk user)
        {
            UrlParameters parameterUrl = new UrlParameters
            {
                itemType = input.CaseType,
                idCase = input.CaseId,
                userId = user.UserId,
                level = input.LevelId
            };

            string uriGetCase = ConfigurationService.UrlGetCase.ConvertUrl(parameterUrl);
            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await ConnectionService.GetAsync<AnswerGetCaseApi>(user.KeyAuthorizationAranda, endpoint);
        }

        /// <summary>
        /// Actualiza caso de la aplicación Service Desk
        /// </summary>
        /// <param name="input">Parámetros para actualizar caso </param>
        /// <param name="user">Usuario autenticado</param>
        /// <returns>estado caso actualizado</returns>
        public async Task<AnswerCreateCase> Update(InputUpdateCaseDto input, UserServiceDesk user)
        {
            UrlParameters parameterUrl = new UrlParameters
            {
                itemType = input.CaseType,
                idCase = input.CaseId,
                userId = user.UserId,
            };

            string uriCreateCase = ConfigurationService.UrlUpdateCase.ConvertUrl(parameterUrl);
            string endpoint = ConfigurationService.UrlServiceDesk + uriCreateCase;

            UpdateCase updateCase = input.MapperModelUpdate();

            List<AnswerApi> listProperty = new List<AnswerApi>();
            listProperty.FillProperties(updateCase, true);
            listProperty.AddProperties(input.Dynamic);

            List<AnswerApi> answerApi = await ConnectionService.PostAsync<List<AnswerApi>>(user.KeyAuthorizationAranda, endpoint, listProperty);

            return answerApi.ConvertModel(new AnswerCreateCase());
        }
    }
}
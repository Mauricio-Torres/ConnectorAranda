// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Connector.Api.Interface.IService;
using Aranda.Connector.Api.Models;
using Aranda.Connector.Api.Models.ConvertDataApi;
using Aranda.Connector.Api.Models.Input;
using Aranda.Connector.Api.Models.Response;
using Aranda.Connector.Api.Models.ResponseApi;
using Aranda.Connector.Api.Utils.Extensions;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Aranda.Connector.Api.Services
{
    public class ManagmentCaseService : IManagmentCaseService
    {
        private readonly IConfigurationService ConfigurationService;
        private readonly IConectionService ConnectionService;
        private readonly ClaimsPrincipal Principal;

        public ManagmentCaseService(IConfigurationService configurationService,
                                    IConectionService conectionService,
                                    IPrincipal principal)
        {
            ConfigurationService = configurationService;
            ConnectionService = conectionService;
            Principal = principal as ClaimsPrincipal;
        }

        /// <summary>
        /// Adiciona un caso en la aplicación Service Desk
        /// </summary>
        /// <param name="input">Parámetros para crear un caso </param>
        /// <param name="user">Usuario autenticado</param>
        /// <returns>estado del caso creado</returns>
        public async Task<AnswerCreateCase> Create(InputCreateCaseDto input)
        {
            UrlParameters parameterUrl = new UrlParameters
            {
                itemType = input.CaseType
            };

            string uriCreateCase = ConfigurationService.UrlCreateCase.ConvertUrl(parameterUrl);
            string endpoint = ConfigurationService.UrlServiceDesk + uriCreateCase;

            CreateCase createCase = input.MapperModelCreate();
            createCase.AuthorId = Principal.User().UserId;

            List<AnswerApi> listProperty = new List<AnswerApi>();
            listProperty.FillProperties(createCase, true);

            List<AnswerApi> answerApi = await ConnectionService.PostAsync<List<AnswerApi>>(Principal.User().KeyAuthorization, endpoint, listProperty);
            AnswerCreateCase answerCreate = answerApi.ConvertModel(new AnswerCreateCase());

            List<UpdateFields> listAdditionalFields = input.AdditionalFields.MapperModelUpdateFields(Principal.User().UserId, answerCreate.ItemId, input.CaseType);

            string uriUpdateFields = ConfigurationService.UrlUpdateAdditionalFields;
            string endpointFields = ConfigurationService.UrlServiceDesk + uriUpdateFields;

            await ConnectionService.PostAsync(Principal.User()?.KeyAuthorization, endpointFields, listAdditionalFields);

            return answerCreate;
        }

        /// <summary>
        /// Retorna caso de la aplicación Service Desk
        /// </summary>
        /// <param name="input">Parámetros para solicitar información del caso a consultar</param>
        /// <param name="user">Usuario autenticado</param>
        /// <returns>información caso </returns>
        public async Task<AnswerGetCaseApi> Get(InputGetCaseDto input)
        {
            UrlParameters parameterUrl = new UrlParameters
            {
                itemType = input.CaseType,
                idCase = input.CaseId,
                userId = Principal.User()?.UserId,
                level = input.LevelId
            };

            string uriGetCase = ConfigurationService.UrlGetCase.ConvertUrl(parameterUrl);
            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            return await ConnectionService.GetAsync<AnswerGetCaseApi>(Principal.User().KeyAuthorization, endpoint);
        }

        /// <summary>
        /// Actualiza caso de la aplicación Service Desk
        /// </summary>
        /// <param name="input">Parámetros para actualizar caso </param>
        /// <param name="user">Usuario autenticado</param>
        /// <returns>estado caso actualizado</returns>
        public async Task<AnswerCreateCase> Update(InputUpdateCaseDto input)
        {
            UrlParameters parameterUrl = new UrlParameters
            {
                itemType = input.CaseType,
                idCase = input.CaseId,
                userId = Principal.User()?.UserId,
            };

            string uriCreateCase = ConfigurationService.UrlUpdateCase.ConvertUrl(parameterUrl);
            string endpoint = ConfigurationService.UrlServiceDesk + uriCreateCase;

            UpdateCase updateCase = input.MapperModelUpdate();

            List<AnswerApi> listProperty = new List<AnswerApi>();
            listProperty.FillProperties(updateCase, true);
            listProperty.AddProperties(input.Dynamic);

            List<AnswerApi> answerApi = await ConnectionService.PostAsync<List<AnswerApi>>(Principal.User()?.KeyAuthorization, endpoint, listProperty);

            return answerApi.ConvertModel(new AnswerCreateCase());
        }
    }
}
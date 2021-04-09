// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Connector.Service.Extensions;
using Aranda.ASDK.Connector.Service.Interface.IService;
using Aranda.ASDK.Data.Objects.Models;
using Aranda.ASDK.Data.Objects.Models.Input.ASDK_V8;
using Aranda.ASDK.Data.Objects.Models.Input.InputBase;
using Aranda.ASDK.Data.Objects.Models.Models_ASDK_V8;
using Aranda.ASDK.Data.Objects.Models.Output.ASDK_V8;
using Aranda.ASDK.Data.Objects.Models.ResponseApi.ASDK_V8;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Aranda.ASDK.Connector.Service.Services
{
    public class ManagmentCaseAsdkV8Service : IManagmentCaseService
    {
        private readonly IConfigurationEndPointService ConfigurationService;
        private readonly IConectionService ConnectionService;
        private readonly ClaimsPrincipal Principal;

        public ManagmentCaseAsdkV8Service(IConfigurationEndPointService configurationService,
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
        public async Task<OutputResponseCaseAsdkV8Dto> Create(InputCreateCaseAsdkV8Dto input)
        {
            UrlParameters parameterUrl = new UrlParameters
            {
                itemType = input.CaseType
            };

            string uriCreateCase = ConfigurationService.UrlCreateCase.ConvertUrl(parameterUrl);
            string endpoint = ConfigurationService.UrlServiceDesk + uriCreateCase;

            CreateCaseV8 createCase = input.MapperModel(new CreateCaseV8());
            createCase.AuthorId = Principal.User().Id;

            List<AnswerGeneralV8Api> listProperty = new List<AnswerGeneralV8Api>();
            listProperty.FillProperties(createCase, true);

            List<AnswerGeneralV8Api> answerApi = await ConnectionService.PostAsync<List<AnswerGeneralV8Api>>(Principal.User().KeyAuthorization, endpoint, listProperty);
            OutputResponseCaseAsdkV8Dto answerCreate = answerApi.ConvertModel(new OutputResponseCaseAsdkV8Dto());

            if (input.AdditionalFields?.Count > 0 && answerCreate?.ItemId > 0)
            {
                await UpdateAdditionalFields(input.AdditionalFields, answerCreate.ItemId, input.CaseType);
            }

            return answerCreate;
        }

        /// <summary>
        /// Retorna caso de la aplicación Service Desk
        /// </summary>
        /// <param name="input">Parámetros para solicitar información del caso a consultar</param>
        /// <param name="user">Usuario autenticado</param>
        /// <returns>información caso </returns>
        public async Task<OutputGetCaseAsdkV8Dto> Get(InputGetCaseDto input)
        {
            UrlParameters parameterUrl = new UrlParameters
            {
                itemType = input.CaseType,
                idCase = input.CaseId,
                userId = Principal.User()?.Id,
                level = input.LevelId
            };

            string uriGetCase = ConfigurationService.UrlGetCase.ConvertUrl(parameterUrl);
            string endpoint = ConfigurationService.UrlServiceDesk + uriGetCase;

            AnswerGetCaseApi getCase = await ConnectionService.GetAsync<AnswerGetCaseApi>(Principal.User().KeyAuthorization, endpoint);

            return getCase.MapperModel(new OutputGetCaseAsdkV8Dto());
        }

        /// <summary>
        /// Actualiza caso de la aplicación Service Desk
        /// </summary>
        /// <param name="input">Parámetros para actualizar caso </param>
        /// <param name="user">Usuario autenticado</param>
        /// <returns>estado caso actualizado</returns>
        public async Task<OutputResponseCaseAsdkV8Dto> Update(InputUpdateCaseDto input)
        {
            UrlParameters parameterUrl = new UrlParameters
            {
                itemType = input.CaseType,
                idCase = input.CaseId,
                userId = Principal.User()?.Id,
            };

            string uriCreateCase = ConfigurationService.UrlUpdateCase.ConvertUrl(parameterUrl);
            string endpoint = ConfigurationService.UrlServiceDesk + uriCreateCase;

            UpdateCaseV8 updateCase = input.MapperModel(new UpdateCaseV8());

            List<AnswerGeneralV8Api> listProperty = new List<AnswerGeneralV8Api>();
            listProperty.FillProperties(updateCase, true);

            List<AnswerGeneralV8Api> answerApi = await ConnectionService.PostAsync<List<AnswerGeneralV8Api>>(Principal.User()?.KeyAuthorization, endpoint, listProperty);

            OutputResponseCaseAsdkV8Dto answerUpdate = answerApi.ConvertModel(new OutputResponseCaseAsdkV8Dto());

            if (input.AdditionalFields?.Count > 0 && answerUpdate?.ItemId > 0)
            {
                await UpdateAdditionalFields(input.AdditionalFields, answerUpdate.ItemId, input.CaseType);
            }

            return answerUpdate;
        }

        /// <summary>
        /// Actualiza los campos adicionales
        /// </summary>
        /// <param name="AdditionalFields">campos adicionales</param>
        /// <param name="idCase">id caso</param>
        /// <param name="idCaseType">id tipo de caso</param>
        /// <returns></returns>
        private async Task UpdateAdditionalFields(List<InputAdditionalFields> AdditionalFields, int idCase, int idCaseType)
        {
            List<UpdateFieldsV8> listAdditionalFields = AdditionalFields.MapperModelUpdateFields(Principal.User().Id, idCase, idCaseType);

            string uriUpdateFields = ConfigurationService.UrlUpdateAdditionalFields;
            string endpointFields = ConfigurationService.UrlServiceDesk + uriUpdateFields;

            await ConnectionService.PostAsync(Principal.User()?.KeyAuthorization, endpointFields, listAdditionalFields);
        }
    }
}
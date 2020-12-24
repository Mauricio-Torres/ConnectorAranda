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
using AutoMapper;
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
            string uriCreateCase = ConfigurationService.UrlCreateCase.ConvertUrl(input.CaseType);
            string endpoint = ConfigurationService.UrlServiceDesk + uriCreateCase;

            MapperConfiguration config = new MapperConfiguration(mc => mc.CreateMap<InputCreateCaseDto, CreateCase>());
            Mapper mapper = new Mapper(config);
            CreateCase createCase = mapper.Map<InputCreateCaseDto, CreateCase>(input);

            createCase.AuthorId = user.UserId;

            List<AnswerApi> listProperty = new List<AnswerApi>();
            listProperty.FillProperties(createCase, true);
            List<AnswerApi> answerApi = await ConnectionService.PostAsync<List<AnswerApi>>(user.KeyAuthorizationAranda, endpoint, listProperty);

            return answerApi.ConvertModel(new AnswerCreateCase());
        }

        /// <summary>
        /// Retorna caso de la aplicación Service Desk
        /// </summary>
        /// <param name="input">Parámetros para solicitar información del caso a consultar</param>
        /// <param name="user">Usuario autenticado</param>
        /// <returns>información caso </returns>
        public async Task<AnswerGetCaseApi> Get(InputGetCaseDto input, UserServiceDesk user)
        {
            string uriGetCase = ConfigurationService.UrlGetCase.ConvertUrl(input.CaseType, input.CaseId,
                                                                              user.UserId, input.LevelId);
            string endpoint = user.UrlServiceDesk + uriGetCase;

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
            string uriCreateCase = ConfigurationService.UrlUpdateCase.ConvertUrl(input.CaseType, input.CaseId, user.UserId);
            string endpoint = user.UrlServiceDesk + uriCreateCase;

            MapperConfiguration config = new MapperConfiguration(mc => mc.CreateMap<InputUpdateCaseDto, UpdateCase>());
            Mapper mapper = new Mapper(config);
            UpdateCase updateCase = mapper.Map<InputUpdateCaseDto, UpdateCase>(input);

            List<AnswerApi> listProperty = new List<AnswerApi>();
            listProperty.FillProperties(updateCase, true);

            List<AnswerApi> answerApi = await ConnectionService.PostAsync<List<AnswerApi>>(user.KeyAuthorizationAranda, endpoint, listProperty);

            return answerApi.ConvertModel(new AnswerCreateCase());
        }
    }
}
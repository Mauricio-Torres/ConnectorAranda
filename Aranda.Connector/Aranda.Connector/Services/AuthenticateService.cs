﻿// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Connector.Api.Interface.IService;
using Aranda.Connector.Api.Models.ConvertDataApi;
using Aranda.Connector.Api.Models.Input;
using Aranda.Connector.Api.Models.Response;
using Aranda.Connector.Api.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aranda.Connector.Api.Services
{
    public class AuthenticateService : IAuthenticationArandaService
    {
        private readonly IConectionService ConectionService;
        private readonly IConfigurationService ConfigurationService;

        public AuthenticateService(IConectionService conectionService, IConfigurationService configurationService)
        {
            ConectionService = conectionService;
            ConfigurationService = configurationService;
        }

        /// <summary>
        /// Establece la configuración para autenticar al usuario
        /// </summary>
        /// <param name="model">parámetros de autenticación</param>
        /// <returns>token</returns>
        public async Task<AnswerAuthentication> Authenticate(InputAuthenticateDto model)
        {
            List<AnswerApi> listProperty = new List<AnswerApi>();
            List<AnswerApi> properties = listProperty.FillProperties(model, false);

            string endpoint = ConfigurationService.UrlBase + ConfigurationService.UrlLogin;

            List<AnswerApi> answerApi = await ConectionService.PostAsync<List<AnswerApi>>(string.Empty, endpoint, properties);

            return answerApi.ConvertModel(new AnswerAuthentication());
        }
    }
}
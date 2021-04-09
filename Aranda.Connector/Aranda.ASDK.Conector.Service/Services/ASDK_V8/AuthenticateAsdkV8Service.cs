// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Connector.Service.Extensions;
using Aranda.ASDK.Connector.Service.Interface.IService;
using Aranda.ASDK.Data.Objects.Models.Input.ASDK_V8;
using Aranda.ASDK.Data.Objects.Models.ResponseApi;
using Aranda.ASDK.Data.Objects.Models.ResponseApi.ASDK_V8;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aranda.ASDK.Connector.Service.Services
{
    public class AuthenticateAsdkV8Service : IAuthenticationArandaService
    {
        private readonly IConectionService ConectionService;
        private readonly IConfigurationEndPointService ConfigurationService;

        public AuthenticateAsdkV8Service(IConectionService conectionService,
                                   IConfigurationEndPointService configurationService)
        {
            ConectionService = conectionService;
            ConfigurationService = configurationService;
        }

        /// <summary>
        /// Establece la configuración para autenticar al usuario
        /// </summary>
        /// <param name="model">parámetros de autenticación</param>
        /// <param name="urlServiceDesk">endpoint de Service Desk</param>
        /// <returns>token</returns>
        public async Task<AnswerAuthentication> AuthenticateV8(InputAuthenticateDto model)
        {
            List<AnswerGeneralV8Api> listProperty = new List<AnswerGeneralV8Api>();
            listProperty.FillProperties(model, true);

            string endpoint = ConfigurationService.UrlServiceDesk + ConfigurationService.UrlLogin;

            List<AnswerGeneralV8Api> answerApi = await ConectionService.PostAsync<List<AnswerGeneralV8Api>>(string.Empty, endpoint, listProperty);

            return answerApi.ConvertModel(new AnswerAuthentication());
        }
    }
}
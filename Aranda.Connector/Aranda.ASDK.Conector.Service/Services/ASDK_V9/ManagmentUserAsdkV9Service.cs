// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Connector.Service.Extensions;
using Aranda.ASDK.Connector.Service.Interface.ASDK_V9;
using Aranda.ASDK.Connector.Service.Interface.IService;
using Aranda.ASDK.Data.Objects.Models.Models_ASDK_V9;
using Aranda.ASDK.Data.Objects.Utils;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Aranda.ASDK.Connector.Service.Services.ASDK_V9
{
    public class ManagmentUserAsdkV9Service : IManagmentUserAsdkV9Service
    {
        private readonly IConfigurationEndPointService ConfigurationService;
        private readonly IConectionService ConnectionService;
        private readonly ClaimsPrincipal Principal;

        public ManagmentUserAsdkV9Service(IPrincipal principal,
                                      IConfigurationEndPointService configurationService,
                                      IConectionService conectionService)
        {
            Principal = principal as ClaimsPrincipal;
            ConfigurationService = configurationService;
            ConnectionService = conectionService;
        }

        public async Task<UserASDKV9> GetUser()
        {
            var token = Principal.TokenAuthenticationASDK_V9();

            string uriCreateCase = ConfigurationService.UrlUserAsdkV9;
            string endpoint = ConfigurationService.UrlServiceDesk + uriCreateCase;

            return await ConnectionService.GetAsync<UserASDKV9>(token, endpoint, Constants.NameHeaderTokenASDK_V9);
        }
    }
}
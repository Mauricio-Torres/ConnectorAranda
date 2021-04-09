// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Data.Objects.Models.Models_ASDK_V8;
using Aranda.ASDK.Data.Objects.Utils;
using System.Security.Claims;

namespace Aranda.ASDK.Connector.Service.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static string TokenAuthenticationASDK_V9(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirst(Constants.NameHeaderTokenASDK_V9)?.Value;
        }

        public static UserAsdkV8 User(this ClaimsPrincipal claimsPrincipal)
        {
            string token = claimsPrincipal.FindFirst(Constants.TypeClaimsTokenServiceDesk)?.Value;
            string userId = claimsPrincipal.FindFirst(Constants.TypeClaimsIdUser)?.Value;

            int.TryParse(userId, out int id);

            return new UserAsdkV8() { Id = id, KeyAuthorization = token };
        }
    }
}
// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Connector.Api.Models;
using System.Security.Claims;

namespace Aranda.Connector.Api.Helpers
{
    public static class ClaimsPrincipalExtension
    {
        public static UserServiceDesk User(this ClaimsPrincipal claimsPrincipal)
        {
            string token = claimsPrincipal.FindFirst(Constants.TypeClaimsTokenServiceDesk)?.Value;
            string userId = claimsPrincipal.FindFirst(Constants.TypeClaimsIdUser)?.Value;
            string urlServiceDesk = claimsPrincipal.FindFirst(Constants.TypeClaimsUrlBase)?.Value;

            int.TryParse(userId, out int id);

            return new UserServiceDesk() { UserId = id, KeyAuthorizationAranda = token, UrlServiceDesk = urlServiceDesk };
        }
    }
}
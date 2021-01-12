// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Connector.Api.Helpers;
using Aranda.Connector.Api.Models;
using System.Security.Claims;

namespace Aranda.Connector.Api.Utils.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static UserServiceDesk User(this ClaimsPrincipal claimsPrincipal)
        {
            string token = claimsPrincipal.FindFirst(Constants.TypeClaimsTokenServiceDesk)?.Value;
            string userId = claimsPrincipal.FindFirst(Constants.TypeClaimsIdUser)?.Value;

            int.TryParse(userId, out int id);

            return new UserServiceDesk() { UserId = id, KeyAuthorization = token };
        }
    }
}
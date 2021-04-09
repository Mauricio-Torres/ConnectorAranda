// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>

using Aranda.ASDK.Data.Objects.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Aranda.ASDK.Connector.V9.Authentication
{
    public class AuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public AuthenticationHandler(
           IOptionsMonitor<AuthenticationSchemeOptions> options,
           UrlEncoder encoder,
           ILoggerFactory logger,
           ISystemClock clock)
           : base(options, logger, encoder, clock)
        {
        }

        /// <summary>
        /// Valida las credenciales del usuario
        /// </summary>
        /// <returns></returns>
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            AuthenticationTicket ticket;
            try
            {
                var Token = Request.Headers[Constants.NameHeaderAuthorization];

                if (string.IsNullOrWhiteSpace(Token))
                {
                    Response.StatusCode = 401;
                    return AuthenticateResult.Fail(Constants.ResponseErro);
                }
                else
                {
                    var identity = new ClaimsIdentity(new[] {
                                   new Claim(Constants.NameHeaderTokenASDK_V9, Token)
                                   }, Constants.BasicAuthentication);

                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    ticket = new AuthenticationTicket(principal, Scheme.Name);
                    return AuthenticateResult.Success(ticket);
                }
            }
            catch (Exception ex)
            {
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = ex.Message;
                Response.StatusCode = 401;
                return AuthenticateResult.Fail(ex.Message);
            }
        }
    }
}
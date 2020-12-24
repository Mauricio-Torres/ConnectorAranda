// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Connector.Api.Interface.IService;
using Aranda.Connector.Api.Models.ConvertDataApi;
using Aranda.Connector.Api.Models.Input;
using Aranda.Connector.Api.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Aranda.Connector.Api.Helpers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IAuthenticationArandaService AuthenticationService;

        public BasicAuthenticationHandler(
           IOptionsMonitor<AuthenticationSchemeOptions> options,
           UrlEncoder encoder,
           ILoggerFactory logger,
           ISystemClock clock,
           IAuthenticationArandaService authenticationService)
           : base(options, logger, encoder, clock)
        {
            AuthenticationService = authenticationService;
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
                var urlBase = Request.Headers["urlBase"].ToString()?.ValidationUrl();
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);

                InputAuthenticateDto inputAuthenticateDto = new InputAuthenticateDto
                {
                    password = credentials[1],
                    username = credentials[0]
                };

                AnswerAuthentication user = await AuthenticationService.Authenticate(inputAuthenticateDto, urlBase);

                var identity = new ClaimsIdentity(new[] {
                    new Claim(Constants.TypeClaimsTokenServiceDesk, user.SessionId),
                    new Claim(Constants.TypeClaimsIdUser, user.UserId.ToString()),
                    new Claim(Constants.TypeClaimsUrlBase, urlBase)
                }, "BasicAuthentication");

                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                ticket = new AuthenticationTicket(principal, Scheme.Name);
            }
            catch (Exception ex)
            {
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = ex.Message;
                Response.StatusCode = 401;
                return AuthenticateResult.Fail(ex.Message);
            }

            return AuthenticateResult.Success(ticket);
        }
    }
}
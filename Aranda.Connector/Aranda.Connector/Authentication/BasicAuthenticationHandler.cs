// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Connector.Service.Interface.IService;
using Aranda.ASDK.Data.Objects.Models.Input.ASDK_V8;
using Aranda.ASDK.Data.Objects.Models.ResponseApi;
using Aranda.ASDK.Data.Objects.Utils;
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

namespace Aranda.Connector.Api.Authentication
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
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers[Constants.Authorization]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);

                InputAuthenticateDto inputAuthenticateDto = new InputAuthenticateDto
                {
                    password = credentials[1],
                    username = credentials[0]
                };

                AnswerAuthentication user = await AuthenticationService.AuthenticateV8(inputAuthenticateDto);

                var identity = new ClaimsIdentity(new[] {
                    new Claim(Constants.TypeClaimsTokenServiceDesk, user.SessionId),
                    new Claim(Constants.TypeClaimsIdUser, user.UserId.ToString())
                }, Constants.BasicAuthentication);

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
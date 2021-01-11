// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Connector.Api.Models.ConvertDataApi;
using Aranda.Connector.Api.Models.Input;
using System.Threading.Tasks;

namespace Aranda.Connector.Api.Interface.IService
{
    /// <summary>
    /// Establece la configuración para autenticar al usuario
    /// </summary>
    public interface IAuthenticationArandaService
    {
        /// <summary>
        /// Configura los parámetros para autenticar al usuario
        /// </summary>
        /// <param name="model">parámetros de autenticación</param>
        /// <param name="urlServiceDesk">endpoint de Service Desk</param>
        /// <returns>token cifrado</returns>
        Task<AnswerAuthentication> Authenticate(InputAuthenticateDto model);
    }
}
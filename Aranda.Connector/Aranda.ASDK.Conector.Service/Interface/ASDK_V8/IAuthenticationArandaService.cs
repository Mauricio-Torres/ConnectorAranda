// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Data.Objects.Models.Input.ASDK_V8;
using Aranda.ASDK.Data.Objects.Models.ResponseApi;
using System.Threading.Tasks;

namespace Aranda.ASDK.Connector.Service.Interface.IService
{
    /// <summary>
    /// Establece la configuración para autenticar al usuario
    /// </summary>
    public interface IAuthenticationArandaService
    {
        /// <summary>
        /// Configura los parámetros para autenticar al usuario para Service Desk V9
        /// </summary>
        /// <param name="model">parámetros de autenticación</param>
        /// <returns>token cifrado</returns>
        Task<AnswerAuthentication> AuthenticateV8(InputAuthenticateDto model);
    }
}
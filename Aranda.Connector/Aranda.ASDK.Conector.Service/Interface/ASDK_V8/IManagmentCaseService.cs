// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Data.Objects.Models.Input.ASDK_V8;
using Aranda.ASDK.Data.Objects.Models.Output.ASDK_V8;
using System.Threading.Tasks;

namespace Aranda.ASDK.Connector.Service.Interface.IService
{
    public interface IManagmentCaseService
    {
        /// <summary>
        /// Configura la solicitud para adicionar un caso en la aplicación Service Desk
        /// </summary>
        /// <param name="input">Parámetros para crear un caso  </param>
        /// <param name="user">Usuario autenticado en Service Desk</param>
        /// <returns>estado del caso creado</returns>
        Task<OutputResponseCaseAsdkV8Dto> Create(InputCreateCaseAsdkV8Dto input);

        /// <summary>
        /// Configura la solicitud para solicitar información de un caso creado en la aplicación Service Desk
        /// </summary>
        /// <param name="input">Parámetros para obtener información de un caso  </param>
        /// <param name="user">Usuario autenticado en Service Desk</param>
        /// <returns>Toda la información del caso</returns>
        Task<OutputGetCaseAsdkV8Dto> Get(InputGetCaseDto input);

        /// <summary>
        /// Configura la solicitud para actualizar un caso ya creado en la aplicación Service Desk
        /// </summary>
        /// <param name="input">Parámetros para actualizar un caso  </param>
        /// <param name="user">Usuario autenticado en Service Desk</param>
        /// <returns>estado del caso actualizado</returns>
        Task<OutputResponseCaseAsdkV8Dto> Update(InputUpdateCaseDto input);
    }
}
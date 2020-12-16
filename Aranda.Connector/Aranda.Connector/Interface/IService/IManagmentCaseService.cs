// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Connector.Api.Models;
using Aranda.Connector.Api.Models.ConvertDataApi;
using Aranda.Connector.Api.Models.Input;
using Aranda.Connector.Api.Models.ResponseApi;
using System.Threading.Tasks;

namespace Aranda.Connector.Api.Interface.IService
{
    public interface IManagmentCaseService
    {
        /// <summary>
        /// Configura la solicitud para adicionar un caso en la aplicación Service Desk
        /// </summary>
        /// <param name="input">Parámetros para crear un caso  </param>
        /// <param name="user">Usuario autenticado en Service Desk</param>
        /// <returns>estado del caso creado</returns>
        Task<AnswerCreateCase> Create(InputCreateCaseDto input, UserServiceDesk user);

        /// <summary>
        /// Configura la solicitud para solicitar información de un caso creado en la aplicación Service Desk
        /// </summary>
        /// <param name="input">Parámetros para obtener información de un caso  </param>
        /// <param name="user">Usuario autenticado en Service Desk</param>
        /// <returns>Toda la información del caso</returns>
        Task<AnswerGetCaseApi> GetCase(InputGetCaseDto input, UserServiceDesk user);

        /// <summary>
        /// Configura la solicitud para actualizar un caso ya creado en la aplicación Service Desk
        /// </summary>
        /// <param name="input">Parámetros para actualizar un caso  </param>
        /// <param name="user">Usuario autenticado en Service Desk</param>
        /// <returns>estado del caso actualizado</returns>
        Task<AnswerCreateCase> Update(InputUpdateCaseDto input, UserServiceDesk user);
    }
}
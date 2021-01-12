// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Connector.Api.Models.ResponseApi;
using System.Threading.Tasks;

namespace Aranda.Connector.Api.Interface.IService
{
    public interface IManagmentAdditionalFieldService
    {
        /// <summary>
        /// Campos avanzados
        /// </summary>
        /// <param name="user">usuario Service Desk</param>
        /// <param name="projectId">Id proyecto</param>
        /// <param name="itemType">tipo de caso</param>
        /// <param name="categoryId">id categoría </param>
        /// <param name="serviceId">id de servicio</param>
        /// <param name="stateId">id de estado</param>
        /// <returns></returns>
        public Task<AnswerAdditionalFields> GetAdditionalField(int projectId, int itemType, int categoryId, int serviceId, int stateId);
    }
}
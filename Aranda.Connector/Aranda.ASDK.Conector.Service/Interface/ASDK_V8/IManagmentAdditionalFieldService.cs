// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Data.Objects.Models.Output;
using System.Threading.Tasks;

namespace Aranda.ASDK.Connector.Service.Interface.IService
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
        public Task<OutputAdditionalFieldsDto> GetAdditionalField(int projectId, int itemType, int categoryId, int serviceId, int stateId);
    }
}
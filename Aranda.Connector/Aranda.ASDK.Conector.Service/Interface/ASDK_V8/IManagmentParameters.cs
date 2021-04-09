// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Data.Objects.Models.ResponseApi;
using System.Threading.Tasks;

namespace Aranda.ASDK.Connector.Service.Interface.IService
{
    public interface IManagmentParameters
    {
        OutputParametersDto GetAllItemType();

        Task<OutputParametersDto> GetCategory(int serviceId, int projectId);

        Task<OutputParametersDto> GetGroups(int serviceId);

        Task<OutputParametersDto> GetItemType(int categoryId, int projectId);

        OutputParametersDto GetLevelDetail();

        Task<OutputParametersDto> GetProyect();

        Task<OutputParametersDto> GetRegistryType();

        Task<OutputParametersDto> GetResponsible(int groupId, int projectId);

        Task<OutputParametersDto> GetServices(int projectId);

        Task<OutputParametersDto> GetSLAs(int serviceId, int itemType);

        Task<OutputParametersDto> GetState(int itemType, int projectId);

        Task<OutputParametersDto> GetStateWhenUpdateCase(int itemType);

        Task<OutputParametersDto> GetUrgency();
    }
}
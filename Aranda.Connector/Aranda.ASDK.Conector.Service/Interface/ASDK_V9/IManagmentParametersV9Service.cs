// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Data.Objects.Models.Models_ASDK_V9;
using Aranda.ASDK.Data.Objects.Models.ResponseApi;
using System.Threading.Tasks;

namespace Aranda.ASDK.Connector.Service.Interface.ASDK_V9
{
    public interface IManagmentParametersV9Service
    {
        public Task<OutputParametersDto> GetAllItemType();

        public Task<OutputParametersDto> GetCategoryByService(int itemType, int serviceId);

        public Task<OutputParametersDto> GetCIs(int projectId, int itemType, int serviceId);

        public Task<OutputParametersDto> GetCompanies(int itemType, int projectId, int? clientId, int? serviceId);

        public Task<OutputParametersDto> GetCustomers(int itemType, int projectId, int? companyId, int? serviceId);

        public Task<OutputParametersDto> GetGroupsByState(int stateId, int serviceId);

        public Task<OutputParametersDto> GetImpact();

        public Task<ModelByCategoryV9> GetModelByCategory(int itemType, int categoryId);

        public Task<OutputParametersDto> GetOla(int unitId, int serviceId);

        public Task<OutputParametersDto> GetPriority();

        public Task<OutputParametersDto> GetProject();

        public Task<OutputParametersDto> GetProviders(int projectId, int serviceId);

        public Task<OutputParametersDto> GetReasonsForState(int stateId);

        public Task<OutputParametersDto> GetRegistryType();

        public Task<OutputParametersDto> GetResponsible(int groupId, int projectId);

        public Task<OutputParametersDto> GetServices(int projectId);

        public Task<OutputParametersDto> GetSLA(int serviceId, int itemType);

        public Task<OutputParametersDto> GetState(int itemType, int categoryId);

        public Task<OutputParametersDto> GetUc(int providerId, int serviceId);

        public Task<OutputParametersDto> GetUnits(int serviceId, int projectId);

        public Task<OutputParametersDto> GetUrgency();
    }
}
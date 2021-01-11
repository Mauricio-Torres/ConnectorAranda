// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Connector.Api.Models;
using Aranda.Connector.Api.Models.ResponseApi;
using System.Threading.Tasks;

namespace Aranda.Connector.Api.Interface.IService
{
    public interface IManagmentParameters
    {
        Task<AnswerParameters> GetCategory(UserServiceDesk user, int serviceId, int projectId);

        Task<AnswerParameters> GetGroups(UserServiceDesk user, int serviceId);

        Task<AnswerParameters> GetItemType(UserServiceDesk user, int categoryId, int projectId);

        Task<AnswerParameters> GetProyect(UserServiceDesk user);

        Task<AnswerParameters> GetRegistryType(UserServiceDesk user);

        Task<AnswerParameters> GetResponsible(UserServiceDesk user, int groupId, int projectId);

        Task<AnswerParameters> GetServices(UserServiceDesk user, int projectId);

        Task<AnswerParameters> GetSLAs(UserServiceDesk user, int serviceId, int itemType);

        Task<AnswerParameters> GetState(UserServiceDesk user, int itemType, int projectId);

        Task<AnswerParameters> GetStateWhenUpdateCase(UserServiceDesk user, int itemType);

        Task<AnswerParameters> GetUrgency(UserServiceDesk user);
    }
}
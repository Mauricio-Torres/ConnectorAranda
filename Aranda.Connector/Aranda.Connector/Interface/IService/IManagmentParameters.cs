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
        Task<AnswerParameters> GetCategory( int serviceId, int projectId);

        Task<AnswerParameters> GetGroups( int serviceId);

        Task<AnswerParameters> GetItemType( int categoryId, int projectId);

        Task<AnswerParameters> GetProyect();

        Task<AnswerParameters> GetRegistryType();

        Task<AnswerParameters> GetResponsible( int groupId, int projectId);

        Task<AnswerParameters> GetServices( int projectId);

        Task<AnswerParameters> GetSLAs( int serviceId, int itemType);

        Task<AnswerParameters> GetState( int itemType, int projectId);

        Task<AnswerParameters> GetStateWhenUpdateCase( int itemType);

        Task<AnswerParameters> GetUrgency();
    }
}
// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Connector.Api.Models;
using System.Threading.Tasks;

namespace Aranda.Connector.Api.Interface.IService
{
    public interface IManagmentParameters
    {
        Task<ResponseParameters> GetCategory(UserServiceDesk user, int projectId);

        Task<ResponseParameters> GetProyect(UserServiceDesk user);

        Task<ResponseParameters> GetServices(UserServiceDesk user, int projectId);
    }
}
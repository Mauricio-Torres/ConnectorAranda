// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Connector.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aranda.Connector.Api.Interface.IService
{
    public interface IManagmentParameters
    {
        Task<List<Parameters>> GetCategory(UserServiceDesk user, int projectId);

        Task<List<Parameters>> GetProyect(UserServiceDesk user);

        Task<List<Parameters>> GetServices(UserServiceDesk user, int projectId);
    }
}
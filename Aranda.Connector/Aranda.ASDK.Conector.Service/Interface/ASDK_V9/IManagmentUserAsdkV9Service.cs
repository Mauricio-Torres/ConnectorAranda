// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Data.Objects.Models.Models_ASDK_V9;
using System.Threading.Tasks;

namespace Aranda.ASDK.Connector.Service.Interface.ASDK_V9
{
    public interface IManagmentUserAsdkV9Service
    {
        Task<UserASDKV9> GetUser();
    }
}
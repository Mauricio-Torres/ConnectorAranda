// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using System.Threading.Tasks;

namespace Aranda.ASDK.Connector.Service.Interface.IService
{
    public interface IConectionService
    {
        /// <summary>
        /// Deserializa la respuesta obtenida por el API Rest en el tipo de clase ingresada, verbo HTTP Get
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Token"> token of authorization Service Desk </param>
        /// <param name="restUrl">EndPoint</param>
        /// <returns></returns>
        Task<T> GetAsync<T>(string Token, string restUrl, string nameHeader = null) where T : new();

        /// <summary>
        /// Deserializa la respuesta obtenida por el API Rest en el tipo de clase ingresada, verbo HTTP  Post
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Token">token of authorization Service Desk</param>
        /// <param name="nameHeader">Adicionar key en el Header de la solicitud</param>

        /// <param name="restUrl">EndPoint </param>
        /// <param name="data">Body Request</param>
        /// <returns></returns>
        Task<T> PostAsync<T>(string Token, string restUrl, object data, string nameHeader = null) where T : new();

        /// <summary>
        /// Petición Post Asíncrona
        /// </summary>
        /// <param name="Token">token of authorization Service Desk</param>
        /// <param name="restUrl">EndPoint </param>
        /// <param name="data">Body Request</param>
        /// <returns></returns>
        Task PostAsync(string Token, string restUrl, object data = null, string nameHeader = null);
    }
}
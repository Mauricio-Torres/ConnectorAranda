// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Connector.Api.Helpers;
using Aranda.Connector.Api.Interface.IService;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Aranda.Connector.Api.Utils
{
    /// <summary>
    /// Establece y configura los servicios para consumir las Api de ServiceDesk
    /// </summary>
    public class ConectionService : IConectionService
    {
        private IRestResponse response;
        private IRestClient restClient;
        private IRestRequest restRequest;

        public ConectionService()
        {
        }

        /// <summary>
        /// Deserializa la respuesta obtenida por el API Rest en el tipo de clase ingresada, verbo HTTP Get
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Token"> token of authorization Service Desk </param>
        /// <param name="restUrl">EndPoint</param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(string Token, string restUrl) where T : new()
        {
            Initialization(restUrl, Token);

            response = await restClient.ExecuteGetAsync<T>(restRequest, CancellationToken.None);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                return JsonConvert.DeserializeObject<T>(response.Content);
            }
            else
            {
                throw new CustomException(string.IsNullOrWhiteSpace(response.Content) ? Constants.NoFound : response.Content);
            }
        }

        /// <summary>
        /// Deserializa la respuesta obtenida por el API Rest en el tipo de clase ingresada, verbo HTTP  Post
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// /// <param name="Token">Token of authorization Service Desk</param>
        /// <param name="restUrl">EndPoint </param>
        /// <param name="data">Body Request</param>
        /// <returns></returns>
        public async Task<T> PostAsync<T>(string Token, string restUrl, object data = null) where T : new()
        {
            Initialization(restUrl, Token);

            restRequest.AddJsonBody(data);

            response = await restClient.ExecutePostAsync(restRequest);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                return JsonConvert.DeserializeObject<T>(response.Content);
            }
            else
            {
                throw new CustomException(string.IsNullOrWhiteSpace(response.Content) ? Constants.ErrorServer : response.Content);
            }
        }

        public async Task PostAsync(string Token, string restUrl, object data = null)
        {
            Initialization(restUrl, Token);

            restRequest.AddJsonBody(data);

            response = await restClient.ExecutePostAsync(restRequest);

            if (!response.StatusCode.Equals(HttpStatusCode.OK))
            {
                throw new CustomException(string.IsNullOrWhiteSpace(response.Content) ? Constants.ErrorServer : response.Content);
            }
        }

        /// <summary>
        /// Establece la configuración inicial para realizar peticiones HTTP
        /// </summary>
        /// <param name="restUrl">endpoint petición</param>
        /// <param name="Token">Token validación</param>
        private void Initialization(string restUrl, string Token)
        {
            restClient = new RestClient();
            restRequest = new RestRequest();

            restClient.ThrowOnAnyError = true;
            restClient.FailOnDeserializationError = true;
            restClient.ThrowOnDeserializationError = true;

            restRequest.Resource = restUrl;

            if (!string.IsNullOrWhiteSpace(Token))
            {
                restRequest.AddHeader("Authorization", Token);
            }
        }
    }
}
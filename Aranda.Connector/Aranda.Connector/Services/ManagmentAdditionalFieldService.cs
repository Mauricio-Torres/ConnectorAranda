// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>

using Aranda.Connector.Api.Helpers;
using Aranda.Connector.Api.Interface.IService;
using Aranda.Connector.Api.Models;
using Aranda.Connector.Api.Models.ResponseApi;
using Aranda.Connector.Api.Utils.Extensions;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Aranda.Connector.Api.Services
{
    public class ManagmentAdditionalFieldService : IManagmentAdditionalFieldService
    {
        private readonly IConfigurationService ConfigurationService;
        private readonly IConectionService ConnectionService;
        private readonly ClaimsPrincipal Principal;

        public ManagmentAdditionalFieldService(IConfigurationService configurationService, IConectionService conectionService, IPrincipal principal)
        {
            ConfigurationService = configurationService;
            ConnectionService = conectionService;
            Principal = principal as ClaimsPrincipal;
        }

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
        public async Task<AnswerAdditionalFields> GetAdditionalField(int projectId, int itemType, int categoryId, int serviceId, int stateId)
        {
            List<AnwerGetAdditionalField> listAdditionalField = new List<AnwerGetAdditionalField>();

            UrlParameters parameterUrl = new UrlParameters
            {
                itemType = itemType,
                projectId = projectId,
                idCase = 0,
                KeyAuthorization = Principal.User().KeyAuthorizationAranda
            };

            //campos básicos
            if (projectId > 0)
            {
                List<AnwerGetAdditionalField> listBasicField = await GetBasicField(Principal.User(), projectId, itemType);
                listBasicField.ForEach(item => listAdditionalField.Add(item));
            }

            //campos por categoría
            if (categoryId > 0)
            {
                List<AnwerGetAdditionalField> listCategory = await GetAdditionalFieldsAdvanced(parameterUrl, categoryId, 0, 0, (int)FilterField.Category);
                listCategory.ForEach(item => listAdditionalField.Add(item));
            }

            //campos por categoría y servicio
            if (categoryId > 0 && serviceId > 0)
            {
                List<AnwerGetAdditionalField> listService = await GetAdditionalFieldsAdvanced(parameterUrl, categoryId, serviceId, 0, (int)FilterField.Service);
                listService.ForEach(item => listAdditionalField.Add(item));
            }

            //campos por estado
            if (stateId > 0)
            {
                List<AnwerGetAdditionalField> listState = await GetAdditionalFieldsAdvanced(parameterUrl, 0, 0, stateId, (int)FilterField.State);
                listState.ForEach(item => listAdditionalField.Add(item));
            }

            return new AnswerAdditionalFields
            {
                Parameters = listAdditionalField.MapperModelAdditionalFields()
            };
        }

        /// <summary>
        /// Campos adicionales avanzados por tipo (servicio, estado, categoría)
        /// </summary>
        /// <param name="Parameters"></param>
        /// <param name="categoryId">id categoría </param>
        /// <param name="serviceId">id de servicio</param>
        /// <param name="stateId">id de estado</param>
        /// <param name="filterField">tipo de campo</param>
        /// <returns></returns>
        private async Task<List<AnwerGetAdditionalField>> GetAdditionalFieldsAdvanced(UrlParameters Parameters, int categoryId, int serviceId,
                                                                                      int stateId, int filterField)
        {
            Parameters.categoryId = categoryId;
            Parameters.serviceId = serviceId;
            Parameters.stateId = stateId;
            Parameters.filterField = filterField;

            string uriGetBasicFields = ConfigurationService.UrlAdditionalAdvancedFields.ConvertUrl(Parameters);
            string endpoint = ConfigurationService.UrlServiceDesk + uriGetBasicFields;

            return await ConnectionService.GetAsync<List<AnwerGetAdditionalField>>(Parameters.KeyAuthorization, endpoint);
        }

        /// <summary>
        /// Campos básicos
        /// </summary>
        /// <param name="user">usuario Service Desk</param>
        /// <param name="projectId">id proyecto</param>
        /// <param name="itemType">tipo de caso</param>
        /// <returns></returns>
        private async Task<List<AnwerGetAdditionalField>> GetBasicField(UserServiceDesk user, int projectId, int itemType)
        {
            UrlParameters parameterUrl = new UrlParameters
            {
                itemType = itemType,
                projectId = projectId,
                idCase = 0,
                precaseId = 0
            };

            string uriGetBasicFields = ConfigurationService.UrlAdditionalBasicFields.ConvertUrl(parameterUrl);
            string endpoint = ConfigurationService.UrlServiceDesk + uriGetBasicFields;

            return await ConnectionService.GetAsync<List<AnwerGetAdditionalField>>(user.KeyAuthorizationAranda, endpoint);
        }
    }
}
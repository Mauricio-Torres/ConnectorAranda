// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>

using Aranda.ASDK.Connector.Service.Extensions;
using Aranda.ASDK.Connector.Service.Interface.IService;
using Aranda.ASDK.Data.Objects.Models;
using Aranda.ASDK.Data.Objects.Models.Models_ASDK_V8;
using Aranda.ASDK.Data.Objects.Models.Output;
using Aranda.ASDK.Data.Objects.Models.ResponseApi.ASDK_V8;
using Aranda.ASDK.Data.Objects.Utils;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Aranda.ASDK.Connector.Service.Services
{
    public class ManagmentAdditionalFieldAsdkV8Service : IManagmentAdditionalFieldService
    {
        private readonly IConfigurationEndPointService ConfigurationService;
        private readonly IConectionService ConnectionService;
        private readonly ClaimsPrincipal Principal;

        public ManagmentAdditionalFieldAsdkV8Service(IConfigurationEndPointService configurationService,
                                               IConectionService conectionService,
                                               IPrincipal principal)
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
        public async Task<OutputAdditionalFieldsDto> GetAdditionalField(int projectId, int itemType, int categoryId, int serviceId, int stateId)
        {
            List<AnwerGetAdditionalFieldV8Api> listAdditionalField = new List<AnwerGetAdditionalFieldV8Api>();

            UrlParameters parameterUrl = new UrlParameters
            {
                itemType = itemType,
                projectId = projectId,
                idCase = 0,
                KeyAuthorization = Principal.User().KeyAuthorization
            };

            //campos básicos
            if (projectId > 0)
            {
                List<AnwerGetAdditionalFieldV8Api> listBasicField = await GetBasicField(Principal.User(), projectId, itemType);
                listBasicField.ForEach(item => listAdditionalField.Add(item));
            }

            //campos por categoría
            if (categoryId > 0)
            {
                List<AnwerGetAdditionalFieldV8Api> listCategory = await GetAdditionalFieldsAdvanced(parameterUrl, categoryId, 0, 0, (int)FilterField.Category);
                listCategory.ForEach(item => listAdditionalField.Add(item));
            }

            //campos por categoría y servicio
            if (categoryId > 0 && serviceId > 0)
            {
                List<AnwerGetAdditionalFieldV8Api> listService = await GetAdditionalFieldsAdvanced(parameterUrl, categoryId, serviceId, 0, (int)FilterField.Service);
                listService.ForEach(item => listAdditionalField.Add(item));
            }

            //campos por estado
            if (stateId > 0)
            {
                List<AnwerGetAdditionalFieldV8Api> listState = await GetAdditionalFieldsAdvanced(parameterUrl, 0, 0, stateId, (int)FilterField.State);
                listState.ForEach(item => listAdditionalField.Add(item));
            }

            return new OutputAdditionalFieldsDto
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
        private async Task<List<AnwerGetAdditionalFieldV8Api>> GetAdditionalFieldsAdvanced(UrlParameters Parameters, int categoryId, int serviceId,
                                                                                      int stateId, int filterField)
        {
            Parameters.categoryId = categoryId;
            Parameters.serviceId = serviceId;
            Parameters.stateId = stateId;
            Parameters.filterField = filterField;

            string uriGetBasicFields = ConfigurationService.UrlAdditionalAdvancedFields.ConvertUrl(Parameters);
            string endpoint = ConfigurationService.UrlServiceDesk + uriGetBasicFields;

            return await ConnectionService.GetAsync<List<AnwerGetAdditionalFieldV8Api>>(Parameters.KeyAuthorization, endpoint);
        }

        /// <summary>
        /// Campos básicos
        /// </summary>
        /// <param name="user">usuario Service Desk</param>
        /// <param name="projectId">id proyecto</param>
        /// <param name="itemType">tipo de caso</param>
        /// <returns></returns>
        private async Task<List<AnwerGetAdditionalFieldV8Api>> GetBasicField(UserAsdkV8 user, int projectId, int itemType)
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

            return await ConnectionService.GetAsync<List<AnwerGetAdditionalFieldV8Api>>(user.KeyAuthorization, endpoint);
        }
    }
}
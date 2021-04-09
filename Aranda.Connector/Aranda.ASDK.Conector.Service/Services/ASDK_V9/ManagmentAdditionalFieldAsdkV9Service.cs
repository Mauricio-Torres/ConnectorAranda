// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Connector.Service.Extensions;
using Aranda.ASDK.Connector.Service.Interface.ASDK_V9;
using Aranda.ASDK.Connector.Service.Interface.IService;
using Aranda.ASDK.Data.Objects.Models.Input.ASDK_V9;
using Aranda.ASDK.Data.Objects.Models.Models_ASDK_V9;
using Aranda.ASDK.Data.Objects.Models.Output;
using Aranda.ASDK.Data.Objects.Models.ResponseApi.ASDK_V9;
using Aranda.ASDK.Data.Objects.Utils;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Aranda.ASDK.Connector.Service.Services.ASDK_V9
{
    public class ManagmentAdditionalFieldAsdkV9Service : IManagmentAdditionalFieldV9Service
    {
        private readonly IConfigurationEndPointService ConfigurationService;
        private readonly IConectionService ConnectionService;
        private readonly IManagmentParametersV9Service ManagmentParametersV9Service;
        private readonly ClaimsPrincipal Principal;

        public ManagmentAdditionalFieldAsdkV9Service(IPrincipal principal,
                                      IConfigurationEndPointService configurationService,
                                      IManagmentParametersV9Service managmentParametersV9Service,
                                      IConectionService conectionService)
        {
            Principal = principal as ClaimsPrincipal;
            ConfigurationService = configurationService;
            ConnectionService = conectionService;
            ManagmentParametersV9Service = managmentParametersV9Service;
        }

        public async Task<List<AdditionalFieldsV9>> GetAdditionalField(int itemType, int stateId, int categoryId)
        {
            var token = Principal.TokenAuthenticationASDK_V9();

            ModelByCategoryV9 modelByCategory = await ManagmentParametersV9Service.GetModelByCategory(itemType, categoryId);

            InputGetAdditionalFieldsAsdkV9Dto inputGetAdditionalFields = new InputGetAdditionalFieldsAsdkV9Dto
            {
                categoryId = categoryId,
                consoleType = Constants.TypeConsole_Specialist,
                itemType = itemType,
                modelId = modelByCategory.Id,
                stateId = stateId
            };

            string uriAdditionalFields = ConfigurationService.UrlAdditionalFieldsAsdkV9;
            string endpoint = ConfigurationService.UrlServiceDesk + uriAdditionalFields;

            AnswerAdditionalFieldsAsdkV9Api AdditionalFieldsAsdkV9 = await ConnectionService.PostAsync<AnswerAdditionalFieldsAsdkV9Api>(token, endpoint, inputGetAdditionalFields, Constants.NameHeaderTokenASDK_V9);

            return AdditionalFieldsAsdkV9.Content;
        }

        public async Task<OutputAdditionalFieldsDto> GetAdditionalFieldParameters(int itemType, int stateId, int categoryId)
        {
            List<AdditionalFields> Parameters = new List<AdditionalFields>();

            List<AdditionalFieldsV9> ListAdditionalFields = await GetAdditionalField(itemType, stateId, categoryId);

            foreach (var item in ListAdditionalFields.Where(item => item.fieldType != (int)AdditionalFiieldType.List
                                                                                   && item.fieldType != (int)AdditionalFiieldType.CatalogList
                                                                                   && item.fieldType != (int)AdditionalFiieldType.List2))
            {
                Parameters.Add(new AdditionalFields
                {
                    Id = JsonConvert.SerializeObject(item.MapperModel(new MapperAdditionalFieldsV9())),
                    Name = item.Name
                });
            }

            return new OutputAdditionalFieldsDto
            {
                Parameters = Parameters
            };
        }
    }
}
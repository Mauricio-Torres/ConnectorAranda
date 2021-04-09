// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Connector.Service.Extensions;
using Aranda.ASDK.Connector.Service.Interface.ASDK_V9;
using Aranda.ASDK.Connector.Service.Interface.IService;
using Aranda.ASDK.Data.Objects.Models;
using Aranda.ASDK.Data.Objects.Models.Input.ASDK_V9;
using Aranda.ASDK.Data.Objects.Models.Models_ASDK_V9;
using Aranda.ASDK.Data.Objects.Models.Output.ASDK_V8;
using Aranda.ASDK.Data.Objects.Models.Output.ASDK_V9;
using Aranda.ASDK.Data.Objects.Models.ResponseApi.ASDK_V9;
using Aranda.ASDK.Data.Objects.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Aranda.ASDK.Connector.Service.Services.ASDK_V9
{
    public class ManagmentCaseAsdkV9Service : IManagmentCaseV9Service
    {
        private readonly IConfigurationEndPointService ConfigurationService;
        private readonly IConectionService ConnectionService;
        private readonly IManagmentAdditionalFieldV9Service ManagmentAdditionalFieldV9Service;
        private readonly IManagmentParametersV9Service ManagmentParametersV9Service;
        private readonly IManagmentUserAsdkV9Service ManagmentUserAsdkV9Service;
        private readonly ClaimsPrincipal Principal;
        private readonly string token;

        public ManagmentCaseAsdkV9Service(IPrincipal principal,
                                      IConfigurationEndPointService configurationService,
                                      IManagmentParametersV9Service managmentParametersV9Service,
                                      IConectionService conectionService,
                                      IManagmentAdditionalFieldV9Service managmentAdditionalFieldV9Service,
                                      IManagmentUserAsdkV9Service managmentUserAsdkV9Service)
        {
            Principal = principal as ClaimsPrincipal;
            ConfigurationService = configurationService;
            ConnectionService = conectionService;
            ManagmentParametersV9Service = managmentParametersV9Service;
            ManagmentUserAsdkV9Service = managmentUserAsdkV9Service;
            ManagmentAdditionalFieldV9Service = managmentAdditionalFieldV9Service;

            token = Principal.TokenAuthenticationASDK_V9();
        }

        public async Task<OutputResponseCaseAsdkV9Dto> Create(InputCreateCaseAsdkV9Dto input)
        {
            string uriCreateCase = ConfigurationService.UrlCreateCase;
            string endpoint = ConfigurationService.UrlServiceDesk + uriCreateCase;

            ModelByCategoryV9 modelByCategory = await ManagmentParametersV9Service.GetModelByCategory(input.ItemType, input.CategoryId);
            UserASDKV9 userASDKV9 = await ManagmentUserAsdkV9Service.GetUser();

            CreateCaseV9 createCase = input.MapperModel(new CreateCaseV9());
            createCase.authorId = userASDKV9.Id;
            createCase.tempItemId = -2;
            createCase.consoleType = Constants.TypeConsole_Specialist;
            createCase.modelId = Convert.ToInt32(modelByCategory.Id);
            createCase.isFeeAvailable = true;

            // TimeZoneInfo.ConvertTimeToUtc(thisTime, TimeZoneInfo.Local)
            createCase.instance = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();

            List<AdditionalFieldsV9> listAdditionalFieldV9 = await ManagmentAdditionalFieldV9Service.GetAdditionalField(input.ItemType, input.StateId, input.CategoryId);

            List<AdditionalFieldsV9> addFieldsV9 = new List<AdditionalFieldsV9>();

            foreach (var item in input.AdditionalFields)
            {
                MapperAdditionalFieldsV9 additionalFieldsV9 = JsonConvert.DeserializeObject<MapperAdditionalFieldsV9>(item.AdvancedFieldId);
                AdditionalFieldsV9 itemInput = additionalFieldsV9.MapperModel(new AdditionalFieldsV9());
                AdditionalFieldsV9 itemAdditionalField = listAdditionalFieldV9.FirstOrDefault(x => x.Equals(itemInput));

                if (itemAdditionalField != null && !string.IsNullOrWhiteSpace(item.Value))
                {
                    listAdditionalFieldV9.Remove(itemAdditionalField);
                    AdditionalFiieldType fieldType = (AdditionalFiieldType)itemAdditionalField.fieldType;

                    if (fieldType == AdditionalFiieldType.ShortText || fieldType == AdditionalFiieldType.LongText || fieldType == AdditionalFiieldType.Link)
                    {
                        itemAdditionalField.stringValue = item.Value;
                    }

                    if (fieldType == AdditionalFiieldType.CheckBox)
                    {
                        bool.TryParse(item.Value, out bool result);
                        itemAdditionalField.boolValue = result;
                    }

                    if (fieldType == AdditionalFiieldType.Numeric || fieldType == AdditionalFiieldType.Decimal || fieldType == AdditionalFiieldType.Currency)
                    {
                        float.TryParse(item.Value, out float result);
                        itemAdditionalField.floatValue = result;
                    }

                    if (fieldType == AdditionalFiieldType.Datetime || fieldType == AdditionalFiieldType.Date)
                    {
                        DateTime.TryParse(item.Value, out DateTime dateTime);
                        DateTime time = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, DateTimeKind.Local);
                        itemAdditionalField.dateValue = new DateTimeOffset(time).ToUnixTimeMilliseconds();
                    }

                    if (fieldType == AdditionalFiieldType.Time)
                    {
                        Regex reguex = new Regex(Constants.Regex_ValidationTimeSpan);

                        if (reguex.IsMatch(item.Value))
                        {
                            TimeSpan.TryParse(item.Value, out TimeSpan time);
                            DateTime date = new DateTime(1970, 1, 1, time.Hours, time.Minutes, time.Seconds, DateTimeKind.Local);
                            itemAdditionalField.dateValue = new DateTimeOffset(date).ToUnixTimeMilliseconds();
                        }
                    }

                    if (fieldType == AdditionalFiieldType.CatalogTree)
                    {
                        int.TryParse(item.Value, out int result);
                        itemAdditionalField.catalogId = result;
                    }

                    if (fieldType == AdditionalFiieldType.Recursive)
                    {
                        InputMapperRecursiveFieldDto fieldRecursive = JsonConvert.DeserializeObject<InputMapperRecursiveFieldDto>(item.Value);
                        itemAdditionalField.intValue = fieldRecursive.Id;
                        itemAdditionalField.stringValue = fieldRecursive.Name;
                    }

                    //if (fieldType.Equals(Constants.List) || fieldType.Equals(Constants.CatalogList))
                    //{
                    //    int.TryParse(item.Value, out int result);
                    //    LookupValues selected = itemAdditionalField.LookupValues.FirstOrDefault(x => x.Id == result);
                    //    if (selected != null)
                    //    {
                    //        itemAdditionalField.Selected = selected;
                    //        itemAdditionalField.IntValue = selected.Id;
                    //        itemAdditionalField.StringValue = selected.Name;
                    //    }
                    //}
                }

                addFieldsV9.Add(itemAdditionalField);
            }

            listAdditionalFieldV9.ForEach(item => addFieldsV9.Add(item));

            createCase.listAdditionalField = addFieldsV9;
            AnswerCreateCaseApi answer = await ConnectionService.PostAsync<AnswerCreateCaseApi>(token, endpoint, createCase, Constants.NameHeaderTokenASDK_V9);

            return answer.MapperModel(new OutputResponseCaseAsdkV9Dto());
        }

        public async Task<OutputGetCaseAsdkV9Dto> GetCase(int idCase)
        {
            string uri = ConfigurationService.UrlGetCase.ConvertUrl(new UrlParameters
            {
                idCase = idCase,
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uri;
            AnswerGetCaseV9Api answerGetCaseV9Api = await ConnectionService.GetAsync<AnswerGetCaseV9Api>(token, endpoint, Constants.NameHeaderTokenASDK_V9);

            return answerGetCaseV9Api.MapperModel(new OutputGetCaseAsdkV9Dto());
        }

        public async Task<OutputResponseCaseAsdkV8Dto> Update(InputUpdateCaseAsdkV9Dto input)
        {
            string uri = ConfigurationService.UrlGetCase.ConvertUrl(new UrlParameters
            {
                idCase = input.ProjectId,
            });

            string endpoint = ConfigurationService.UrlServiceDesk + uri;
            AnswerGetCaseV9Api answerGetCaseV9Api = await ConnectionService.GetAsync<AnswerGetCaseV9Api>(token, endpoint, Constants.NameHeaderTokenASDK_V9);

            return null;
        }
    }
}
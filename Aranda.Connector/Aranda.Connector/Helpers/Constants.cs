// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>

using System.Collections.Generic;

namespace Aranda.Connector.Api.Helpers
{
    internal enum FilterField
    {
        State = 1,
        Category = 2,
        Service = 3
    }

    internal enum ItemType
    {
        Incidente = 1,
        Problema = 2,
        Cambio = 3,
        Requerimiento = 4
    }

    public static class Constants
    {
        #region ItemType

        private static List<string> itemType = new List<string> {
            "Incidente",
            "Problema",
            "Cambio",
            "Requerimiento"
        };

        public static string ItemType(int id)
        {
            return itemType[id];
        }

        #endregion

        #region Configuration Parameter

        public const string ParameterUrlAdditionalAdvancedFields = "api/v8.6/additionalfield/listadvanced/{itemType}/{projectId}/{filterField}?itemId={idCase}&categoryId={categoryId}&serviceId={serviceId}&stateId={stateId}";
        public const string ParameterUrlAdditionalBasicFields = "api/v8.6/additionalfield/listbasic/{projectId}/{itemType}?itemId={idCase}&precaseId={precaseId}";
        public const string ParameterUrlCategories = "api/v8.6/category/{projectId}/{serviceId}/byservice";
        public const string ParameterUrlCreateCase = "api/v8.6/item/add/{itemType}";
        public const string ParameterUrlGetCase = "api/v8.6/item/{idCase}/{itemType}/{userId}?level={level}";
        public const string ParameterUrlGroups = "api/v8.6/service/{serviceId}/groups";
        public const string ParameterUrlItemType = "api/v8.6/category/{categoryId}/{projectId}/enableditemtypes";
        public const string ParameterUrlLogin = "api/v8.6/user/login";
        public const string ParameterUrlProyects = "service/api/v8.6/client/{userId}/project/list";
        public const string ParameterUrlRegistryType = "api/v8.6/registrytype/list";
        public const string ParameterUrlServices = "api/v8.6/user/{userId}/{projectId}/enabledservice/detail/list";
        public const string ParameterUrlState = "api/v8.6/state/list/{itemType}?projectId={projectId}";
        public const string ParameterUrlUpdateAdditionalFields = "api/v8.6/additionalfield/update";
        public const string ParameterUrlUpdateCase = "api/v8.6/item/update/{idCase}/{itemType}/{userId}";
        public const string ParameterUrlUpdateState = "api/v8.6/state/detailslist/{itemType}";
        public const string ParameterUrlUrlResponsible = "api/v8.6/group/{groupId}/{projectId}/specialists";
        public const string ParameterUrlUrlSLAs = "api/v8.6/service/{serviceId}/{itemType}/SLAs";
        public const string ParameterUrlUrlUrgency = "api/v8.6/urgency/list";
        public const string TypeClaimsIdUser = "IdUser";
        public const string TypeClaimsTokenServiceDesk = "TokenServiceDesk";
        public const string TypeClaimsUrlBase = "urlBase";

        #endregion

        #region Validations EndPoint

        // general validation

        public const string ErrorServer = "ErrorConectionServer";
        public const string ErrorUrlBase = "RequiredUrlBase";
        public const string InvalidRangeCasetype = "InvalidRangeCasetype";

        // create case
        public const string InvalidRangeCategoryId = "InvalidRangeCategoryId";

        public const string InvalidRangeGroupId = "InvalidRangeGroupId";
        public const string InvalidRangeLevelId = "InvalidRangeLevelId";
        public const string InvalidRangeProjectId = "InvalidRangeProjectId";
        public const string InvalidRangeRegistryTypeId = "InvalidRangeRegistryTypeId";
        public const string InvalidRangeServiceId = "InvalidRangeServiceId";
        public const string InvalidRangeSlaId = "InvalidRangeSlaId";
        public const string NoFound = "NoFound";
        public const string RequiredCaseId = "RequiredCaseId";
        public const string RequiredCasetype = "RequiredCasetype";
        public const string RequiredCategoryId = "RequiredCategoryId";
        public const string RequiredDescription = "RequiredDescription";
        public const string RequiredGroupId = "RequiredGroupId";
        public const string RequiredPassword = "RequiredPassword";
        public const string RequiredProjectId = "RequiredProjectId";
        public const string RequiredRegistryTypeId = "RequiredRegistryTypeId";
        public const string RequiredServiceId = "RequiredServiceId";
        public const string RequiredSlaId = "RequiredSlaId";
        public const string RequiredStateId = "RequiredStateId";
        public const string RequiredUrgencyId = "RequiredUrgencyId";
        public const string RequiredUserName = "RequiredUserName";

        // update case

        #endregion
    }
}
// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>

namespace Aranda.Connector.Api.Helpers
{
    public static class Constants
    {
        #region Configuration Parameter

        public const string ParameterUrlCategories = "api/v8.6/category/{projectId}/{userId}/byservice";
        public const string ParameterUrlCreateCase = "api/v8.6/item/add/{itemType}";
        public const string ParameterUrlGetCase = "api/v8.6/item/{idCase}/{itemType}/{userId}?level={level}";
        public const string ParameterUrlLogin = "api/v8.6/user/login";
        public const string ParameterUrlProyects = "service/api/v8.6/client/{userId}/project/list";
        public const string ParameterUrlServices = "api/v8.6/user/{userId}/{projectId}/enabledservice/detail/list";
        public const string ParameterUrlUpdateCase = "api/v8.6/item/update/{idCase}/{itemType}/{userId}";

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
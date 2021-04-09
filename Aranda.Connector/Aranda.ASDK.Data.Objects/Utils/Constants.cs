// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
namespace Aranda.ASDK.Data.Objects.Utils
{
    public enum AdditionalFiieldType
    {
        None = 0,
        ShortText = 1,
        Datetime = 2,
        List = 3,
        LongText = 4,
        CheckBox = 5,
        Numeric = 6,
        Recursive = 7,
        List2 = 8,
        Decimal = 9,
        File = 10,
        CatalogList = 11,
        CatalogTree = 12,
        Date = 13,
        Time = 14,
        Currency = 15,
        Link = 16,
        Position = 17
    }

    #region Item Type V9

    public enum ArandaType
    {
        /// <summary>
        /// Incident service request
        /// </summary>
        Incidents = 1,

        /// <summary>
        /// Problem service request
        /// </summary>
        Problem = 2,

        /// <summary>
        /// Change service request
        /// </summary>
        Change = 3,

        /// <summary>
        /// Service call service request
        /// </summary>
        ServiceCall = 4,

        /// <summary>
        /// Service
        /// </summary>
        Service = 5,

        /// <summary>
        /// Task
        /// </summary>
        Task = 6,

        /// <summary>
        /// Knowledgebase Article
        /// </summary>
        Article = 7,

        ////SLAs = 7,
        /// <summary>
        /// Photos
        /// </summary>
        Photos = 8,

        /// <summary>
        /// Release Service request
        /// </summary>
        Release = 13,

        /// <summary>
        /// Service Level Agreement
        /// </summary>
        SLA = 14,

        /// <summary>
        /// Known Error
        /// </summary>
        KnownError = 16,

        /// <summary>
        /// Configuration Item
        /// </summary>
        Ci = 21,

        /// <summary>
        /// Service client
        /// </summary>
        Client = 37,

        /// <summary>
        /// Service client company
        /// </summary>
        Company = 38,

        /// <summary>
        /// Unkown entity
        /// </summary>
        Unknown = 40,

        ///// <summary>
        ///// Desk user
        ///// </summary>
        //User = 47,

        /// <summary>
        /// CI Packages
        /// </summary>
        Packages = 48,

        /// <summary>
        /// Specialist's group
        /// </summary>
        Group = 49,

        /// <summary>
        /// Events
        /// </summary>
        Events = 50,

        /// <summary>
        /// Business Area
        /// </summary>
        Area = 51,

        /// <summary>
        /// Provider
        /// </summary>
        Provider = 52,

        /// <summary>
        /// Specialist
        /// </summary>
        Specialist = 53,

        /// <summary>
        /// Underpinning Contract
        /// </summary>
        UC = 54,

        /// <summary>
        /// Operational Level Agreement
        /// </summary>
        OLA = 55,

        /// <summary>
        /// Entity model or type
        /// </summary>
        Model = 56,

        ///// <summary>
        ///// Service category
        ///// </summary>
        //Category = 57,

        /// <summary>
        /// Approvals
        /// </summary>
        Approvals = 58,

        /// <summary>
        /// Time
        /// </summary>
        Time = 59,

        /// <summary>
        /// Mail server
        /// </summary>
        MailServer = 60,

        /// <summary>
        /// User Interface
        /// </summary>
        Interface = 61,

        /// <summary>
        /// Additional field
        /// </summary>
        Additional = 62,

        /// <summary>
        /// Survey
        /// </summary>
        Survey = 63,

        /// <summary>
        /// Client's group
        /// </summary>
        ClientGroup = 64,

        /// <summary>
        /// Folder
        /// </summary>
        Folder = 65,

        /// <summary>
        /// Rule
        /// </summary>
        Rule = 66,

        /// <summary>
        /// GUI View
        /// </summary>
        View = 67,

        /// <summary>
        /// User license
        /// </summary>
        License = 68,

        /// <summary>
        /// Invoice
        /// </summary>
        Invoice = 69,

        /// <summary>
        /// Contract
        /// </summary>
        Contract = 70,

        /// <summary>
        /// Other financial document
        /// </summary>
        OtherDocument = 71,

        /// <summary>
        /// Business process
        /// </summary>
        BusinessProcess = 72,

        /// <summary>
        /// Cost or Income center
        /// </summary>
        CostCenter = 73,

        /// <summary>
        /// Catalog
        /// </summary>
        Catalog = 74,

        /// <summary>
        /// Maintenance
        /// </summary>
        Maintenance = 75,

        /// <summary>
        /// Auidt
        /// </summary>
        Audit = 76,

        /// <summary>
        /// Alert
        /// </summary>
        Alert = 77,

        /// <summary>
        /// Project
        /// </summary>
        Project = 78,

        /// <summary>
        /// Profile
        /// </summary>
        Profile = 79,

        /// <summary>
        /// Profile
        /// </summary>
        Supervisor = 80,

        /// <summary>
        /// Mail server
        /// </summary>
        MailTemplate = 81,

        /// <summary>
        /// Configuration chat
        /// </summary>
        Chat = 82,

        /// <summary>
        /// Category
        /// </summary>
        Category = 83,

        /// <summary>
        /// Tipo para guardar la ruta de la imagen del servicio.
        /// </summary>
        ServicePhoto = 84,

        /// <summary>
        /// Enlaces
        /// </summary>
        Link = 85,

        /// <summary>
        /// Estados
        /// </summary>
        Status = 86,

        /// <summary>
        /// LDAP
        /// </summary>
        Ldap = 87
    };

    #endregion

    public enum FilterField
    {
        State = 1,
        Category = 2,
        Service = 3
    }

    public static class Constants
    {
        #region Item Type V8

        public const string Cambio = "Cambio";
        public const string Incidente = "Incidente";
        public const string Problema = "Problema";
        public const string Releases = "Releases";
        public const string Requerimiento = "Requerimiento";

        #endregion

        #region Field Type

        public const string CatalogList = "CatalogList";
        public const string CatalogTree = "CatalogTree";
        public const string CheckBox = "CheckBox";
        public const string Currency = "Currency";
        public const string Date = "Date";
        public const string Datetime = "Datetime";
        public const string Decimal = "Decimal";
        public const string Link = "Link";
        public const string List = "List";
        public const string LongText = "LongText";
        public const string Numeric = "Numeric";
        public const string Recursive = "Recursive";
        public const string ShortText = "ShortText";
        public const string Time = "Time";

        #endregion

        #region Constantes Configuration

        public const string Authorization = "Authorization";
        public const string BasicAuthentication = "BasicAuthentication";
        public const string ContentType = "Content-Type";
        public const string FormatTypeJson = "application/json";
        public const string NameHeaderAuthorization = "token";
        public const string ResponseErro = "InvalidToken";
        public const string TypeApplication = "asdk";
        public const string TypeConsole_Specialist = "specialist";

        #endregion

        #region Level Detail

        public const string Alto = "Alto";
        public const string Bajo = "Bajo";
        public const string Medio = "Medio";

        #endregion

        #region Configuration EndPoint ASDK V9

        public const string ParameterUrlAdditionalFieldsV9 = "api/v9/item/additionalfields";
        public const string ParameterUrlCategoryByServiceAsdkV9 = "api/v9/item/{itemType}/services/{serviceId}/categories?dataType={dataType}";
        public const string ParameterUrlCIsV9 = "/api/v9/project/{projectId}/{itemType}/Cis/search?serviceId={serviceId}&application={application}&criteria=";
        public const string ParameterUrlClients = "api/v9/project/{projectId}/{itemType}/clients/search?";
        public const string ParameterUrlCreateCaseV9 = "api/v9/item";
        public const string ParameterUrlGetCaseV9 = "/api/v9/item/{idCase}?language=0";
        public const string ParameterUrlGroupsV9 = "api/v9/service/{serviceId}/state/{stateId}/group/list";
        public const string ParameterUrlImpactV9 = "api/v9/catalog/impact?language=0";
        public const string ParameterUrlItemTypeV9 = "api/v9/item/types/licenses";
        public const string ParameterUrlLoginV9 = "api/v9/authentication";
        public const string ParameterUrlModelByCategoryCaseV9 = "api/v9/item/{itemType}/categories/{categoryId}/model";
        public const string ParameterUrlOperativeLevelV9 = "api/v9/service/{serviceId}/units/{unitId}/ola";
        public const string ParameterUrlPriorityV9 = "/api/v9/catalog/priority?language=0";
        public const string ParameterUrlProjectsAsdkV9 = "api/v9/user/projects";
        public const string ParameterUrlProviderV9 = "api/v9/service/{serviceId}/providers/search?projectId={projectId}&criteria=";
        public const string ParameterUrlReasonsForStateV9 = "api/v9/state/{stateId}/reasons/list?language={language}";
        public const string ParameterUrlRegistryTypeV9 = "/api/v9/catalog/registry_type?language=0";
        public const string ParameterUrlServiceV9 = "api/v9/project/{projectId}/incidents/services/search?console={consoleType}&application={application}&criteria=";
        public const string ParameterUrlSlaByCi = "api/v9/service/{serviceId}/21/{itemType}/sla";
        public const string ParameterUrlSlaByClient = "api/v9/service/{serviceId}/37/{itemType}/sla";
        public const string ParameterUrlSlaByCompany = "api/v9/service/{serviceId}/38/{itemType}/sla";
        public const string ParameterUrlSpecialistByGroupAsdkV9 = "/api/v9/group/{groupId}/project/{projectId}/specialists?available=false";

        public const string ParameterUrlStatesByModelV9 = "api/v9/model/{modelId}/{itemType}/states";
        public const string ParameterUrlUcV9 = "api/v9/service/{serviceId}/providers/{providerId}/uc";
        public const string ParameterUrlUnitsV9 = "api/v9/service/{serviceId}/units/search?projectId={projectId}&criteria=";
        public const string ParameterUrlUpdateCaseV9 = "/api/v9/item/{projectId}"; // falta implementación
        public const string ParameterUrlUrgencyV9 = "api/v9/catalog/urgency?language=0";
        public const string ParameterUrlUrlCompaniesV9 = "api/v9/project/{projectId}/{itemType}/companies/search?";
        public const string ParameterUrlUserV9 = "api/v9/user/";

        #endregion

        #region Configuration EndPoint ASDK V8

        public const string ParameterUrlAdditionalAdvancedFields = "api/v8.6/additionalfield/listadvanced/{itemType}/{projectId}/{filterField}?itemId={idCase}&categoryId={categoryId}&serviceId={serviceId}&stateId={stateId}";
        public const string ParameterUrlAdditionalBasicFields = "api/v8.6/additionalfield/listbasic/{projectId}/{itemType}?itemId={idCase}&precaseId={precaseId}";
        public const string ParameterUrlCategories = "api/v8.6/category/{projectId}/{serviceId}/byservice";
        public const string ParameterUrlCreateCaseV8 = "api/v8.6/item/add/{itemType}";
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

        #endregion

        #region Configuration Parameter

        public const string NameHeaderTokenASDK_V9 = "X-Authorization";
        public const string TypeClaimsIdUser = "IdUser";
        public const string TypeClaimsTokenServiceDesk = "TokenServiceDesk";
        public const string TypeClaimsUrlBase = "UrlBaseServiceDeskV8";
        public const string Version8 = "ASDKV8";

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
        public const string RequiredSubject = "RequiredSubject";
        public const string RequiredUrgencyId = "RequiredUrgencyId";
        public const string RequiredUserName = "RequiredUserName";

        // update case

        #endregion

        #region RegexType

        public const string Regex_DateTimeBasic = @"^([0-2][0-9]|3[0-1])(\/|-)(0[1-9]|1[0-2])\2(\d{4})$";
        public const string Regex_DateTimeHrsMinSeg = @"^([0-2][0-9]|3[0-1])(\/|-)(0[1-9]|1[0-2])\2(\d{4})(\s)([0-1][0-9]|2[0-3])(:)([0-5][0-9])(:)([0-5][0-9])$";
        public const string Regex_DateTimeHsMin = @"^([0-2][0-9]|3[0-1])(\/|-)(0[1-9]|1[0-2])\2(\d{4})(\s)([0-1][0-9]|2[0-3])(:)([0-5][0-9])$";
        public const string Regex_ValidationTimeSpan = @"^([0-1]?\d|2[0-3])(?::([0-5]?\d))?(?::([0-5]?\d))?$";

        #endregion
    }
}
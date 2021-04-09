// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>

using Aranda.ASDK.Data.Objects.Models.ResponseApi.ASDK_V9;
using System.Collections.Generic;

namespace Aranda.ASDK.Data.Objects.Models.Models_ASDK_V9
{
    public class CreateCaseV9
    {
        public int authorId { set; get; }
        public int categoryId { get; set; }
        public string cause { set; get; }
        public int? ciId { set; get; }
        public int? companyId { get; set; }
        public string consoleType { set; get; }
        public string correctActions { get; set; }
        public object currentProgress { get; set; }
        public int currentTime { get; set; }
        public int? customerId { get; set; }
        public string description { set; get; }
        public int estimatedCost { get; set; }
        public int estimatedTime { get; set; }
        public string followUpActions { get; set; }
        public string foregroundColorRgb { set; get; }
        public int? groupId { set; get; }
        public bool hasMoreInformation { get; set; }
        public bool hasPendingSurvey { get; set; }
        public int impactId { get; set; }
        public string incorrectActions { get; set; }
        public long instance { get; set; }
        public bool isFeeAvailable { set; get; }
        public int itemType { get; set; }
        public int itemVersion { get; set; }
        public bool knownError { set; get; }
        public List<AdditionalFieldsV9> listAdditionalField { set; get; }
        public bool majorProblem { get; set; }
        public List<object> majorProblemInterface { set; get; }
        public int modelId { get; set; }
        public int priorityId { get; set; }
        public string priorityReason { set; get; }
        public int projectId { get; set; }
        public int realCost { get; set; }
        public int? reasonId { get; set; }
        public string recomendations { get; set; }
        public int? registryTypeId { set; get; }
        public int? responsibleId { set; get; }
        public int serviceId { get; set; }
        public int? slaId { set; get; }
        public int stateId { get; set; }
        public string subject { set; get; }
        public string surveyToken { set; get; }
        public int tempItemId { get; set; }
        public bool thirdParty { get; set; }
        public bool transformed { get; set; }
        public int urgencyId { get; set; }
    }
}
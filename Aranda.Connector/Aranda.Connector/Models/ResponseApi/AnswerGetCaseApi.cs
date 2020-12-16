// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using System;

namespace Aranda.Connector.Api.Models.ResponseApi
{
    public class AnswerGetCaseApi
    {
        public string Address { set; get; }
        public string Annulled { set; get; }
        public AttentionDate? AttentionDate { set; get; }
        public object AttentionDateExpected { set; get; }
        public object AttentionDateReal { set; get; }
        public int? AuthorId { set; get; }
        public string AuthorName { set; get; }
        public object BackOutPlan { set; get; }
        public object Building { set; get; }
        public Result BuildingDate { set; get; }
        public Result CABDate { set; get; }
        public int? CaseType { set; get; }
        public string CategoryHierarchy { set; get; }
        public int? CategoryId { set; get; }
        public string CategoryName { set; get; }
        public object CauseId { set; get; }
        public object CauseName { set; get; }
        public object CiId { set; get; }
        public object CiName { set; get; }
        public object City { set; get; }
        public object ClassifiedCaseIdByProject { set; get; }
        public object ClassifiedId { set; get; }
        public object ClassifiedIdByProject { set; get; }
        public object ClassifiedName { set; get; }
        public object ClassifiedTo { set; get; }
        public object ClassifiedType { set; get; }
        public object ClosedDate { set; get; }
        public int? ClosenessToExpiration { set; get; }
        public object Commentary { set; get; }
        public int? CompanyId { set; get; }
        public string CompanyName { set; get; }
        public string ComposedId { set; get; }
        public Constant Cost { set; get; }
        public object Country { set; get; }
        public int? CustomerId { set; get; }
        public string CustomerName { set; get; }
        public object Department { set; get; }
        public string Description { set; get; }
        public object Effort { set; get; }
        public object EmailDate { set; get; }
        public object Floor { set; get; }
        public int? FollowersCount { set; get; }
        public int? GroupId { set; get; }
        public string GroupName { set; get; }
        public bool? HasCurrentVoting { set; get; }
        public object HasKnownError { set; get; }
        public bool? HasSurvey { set; get; }
        public object HeadQuarter { set; get; }
        public int? Id { set; get; }
        public int? IdByProject { set; get; }
        public int? ImpactId { set; get; }
        public string ImpactName { set; get; }
        public Result ImplementationDate { set; get; }
        public object InterfaceId { set; get; }
        public object IsClosed { set; get; }
        public object IsConfidential { set; get; }
        public bool? IsFollowing { set; get; }
        public int? IsOpened { set; get; }
        public object IsStateProvider { set; get; }
        public object KnownError { set; get; }
        public int? Latitude { set; get; }
        public int? Longitude { set; get; }
        public object MatchContent { set; get; }
        public object Name { set; get; }
        public int? PriorityId { set; get; }
        public string PriorityName { set; get; }
        public object ProcedureId { set; get; }
        public object ProcedureName { set; get; }
        public int? Progress { set; get; }
        public int? ProjectId { set; get; }
        public string ProjectName { set; get; }
        public object ProviderId { set; get; }
        public object ProviderName { set; get; }
        public object PSA { set; get; }
        public object ReasonId { set; get; }
        public object ReasonName { set; get; }
        public int? ReceptorId { set; get; }
        public DateTime? RegistrationDate { set; get; }
        public int? RegistryTypeId { set; get; }
        public string RegistryTypeName { set; get; }
        public Result ReviewDate { set; get; }
        public Result RFCDate { set; get; }
        public object RoutingType { set; get; }
        public object Scope { set; get; }
        public int? ServiceId { set; get; }
        public string ServiceName { set; get; }
        public int? SlaId { set; get; }
        public string SlaName { set; get; }
        public AttentionDate SolutionDate { set; get; }
        public object SolutionDateExpected { set; get; }
        public object SolutionDateReal { set; get; }
        public object SpecialGroupId { set; get; }
        public int? SpecialistId { set; get; }
        public string SpecialistName { set; get; }
        public object StageId { set; get; }
        public object StageName { set; get; }
        public int? StateId { set; get; }
        public string StateName { set; get; }
        public string Subject { set; get; }
        public Result TestingDate { set; get; }
        public int? Time { set; get; }
        public int? UrgencyId { set; get; }
        public string UrgencyName { set; get; }
        public bool? UserCanEdit { set; get; }
        public object VotingProcessId { set; get; }
        public object VotingProcessName { set; get; }
    }

    public class AttentionDate
    {
        public DateTime? Expected { set; get; }
        public DateTime? Real { set; get; }
    }

    public class Constant
    {
        public object Current { set; get; }
        public object Expected { set; get; }
        public object Real { set; get; }
    }

    public class Result
    {
        public object Attention { set; get; }
        public object Solution { set; get; }
    }
}
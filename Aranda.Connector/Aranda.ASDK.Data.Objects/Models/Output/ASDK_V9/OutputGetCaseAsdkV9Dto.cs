// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Data.Objects.Models.ResponseApi.ASDK_V9;
using Aranda.ASDK.Data.Objects.Utils;
using System.Collections.Generic;

namespace Aranda.ASDK.Data.Objects.Models.Output.ASDK_V9
{
    public class OutputGetCaseAsdkV9Dto
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string BackgroundColorRgb { get; set; }
        public int CalendarOlaId { get; set; }
        public int CalendarSlaId { get; set; }
        public int CalendarUcId { get; set; }
        public bool CanClosed { get; set; }
        public string CategoryHierarchy { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Cause { get; set; }
        public string CauseNoHtml { get; set; }
        public int CiId { get; set; }
        public string CiName { get; set; }
        public long ClosedDate { get; set; }
        public string Commentary { get; set; }
        public string CommentaryNoHtml { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public long ConstructionFinalDate { get; set; }
        public long ConstructionInitialDate { get; set; }
        public string CorrectActions { get; set; }

        public double Cost { get; set; }

        public int CountFiles { get; set; }

        public double CurrentProgress { get; set; }

        public double CurrentTime { get; set; }

        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string Description { get; set; }

        public string DescriptionNoHtml { get; set; }

        public int Duration { get; set; }

        public double Effort { get; set; }
        public long EmailOriginationDate { get; set; }

        public double EstimatedCost { get; set; }
        public long EstimatedDate { get; set; }

        public double EstimatedTime { get; set; }
        public long FinalDate { get; set; }

        public int FinalStatus { get; set; }

        public string FollowUpActions { get; set; }

        public string ForegroundColorRgb { get; set; }

        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public bool HasMoreInformation { get; set; }

        public bool HasSurvey { get; set; }
        public bool HaveRisk { get; set; }

        public int Id { get; set; }

        public string IdByProject { get; set; }

        public int ImpactId { get; set; }

        public string ImpactName { get; set; }

        public string IncorrectActions { get; set; }

        public long InitialDate { get; set; }

        public long InstalationFinalDate { get; set; }

        public long InstalationInitialDate { get; set; }

        public string InterfaceId { get; set; }

        public bool IsClosed { get; set; }

        public bool IsFeeAvailable { get; set; }

        public bool IsVotingProcess { get; set; }

        public ArandaType ItemType { get; set; }

        public ArandaType ItemTypeId { get; set; }
        public string ItemTypeName { get; set; }
        public int ItemVersion { get; set; }
        public bool KnownError { get; set; }
        public bool MajorProblem { get; set; }
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public long ModifiedDate { get; set; }
        public int ModifierId { get; set; }
        public string ModifierName { get; set; }
        public int OlaId { get; set; }
        public string OlaName { get; set; }
        public long OpenedDate { get; set; }
        public int ParentId { get; set; }
        public string ParentIdByProject { get; set; }
        public string ParentItemType { get; set; }
        public int ParentItemTypeId { get; set; }
        public long ParentOpenedDate { get; set; }
        public int PreviousStateId { get; set; }
        public double Price { get; set; }
        public int PriorityId { get; set; }
        public string PriorityName { get; set; }
        public string PriorityReason { get; set; }
        public double Progress { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
        public long PSOFinalDate { get; set; }
        public long PSOInitialDate { get; set; }
        public double RealCost { get; set; }
        public long RealDate { get; set; }
        public int ReasonId { get; set; }
        public string ReasonName { get; set; }
        public int ReceptorId { get; set; }
        public string ReceptorName { get; set; }
        public string Recomendations { get; set; }
        public int RegistryTypeId { get; set; }
        public string RegistryTypeName { get; set; }
        public List<ResponseData> Relation { get; set; }
        public int ResponsibleId { get; set; }

        public string ResponsibleName { get; set; }

        public int Rev { get; set; }

        public int RiskId { get; set; }

        public string RiskName { get; set; }

        public int ServiceId { get; set; }

        public string ServiceName { get; set; }

        public int SlaId { get; set; }

        public string SlaName { get; set; }

        public int StateId { get; set; }

        public string StateName { get; set; }

        public string Subject { get; set; }

        public string SurveyToken { get; set; }

        public int TemplateId { get; set; }

        public long TestFinalDate { get; set; }

        public long TestInitialDate { get; set; }

        public bool ThirdParty { get; set; }

        public ArandaType Type { get; set; }

        public int UcId { get; set; }

        public string UcName { get; set; }

        public int UnitId { get; set; }

        public string UnitName { get; set; }

        public int UrgencyId { get; set; }

        public string UrgencyName { get; set; }
    }
}
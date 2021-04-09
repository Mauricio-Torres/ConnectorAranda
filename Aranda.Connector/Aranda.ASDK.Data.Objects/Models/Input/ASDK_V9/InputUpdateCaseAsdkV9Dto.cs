// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Data.Objects.Models.Input.InputBase;
using Aranda.ASDK.Data.Objects.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aranda.ASDK.Data.Objects.Models.Input.ASDK_V9
{
    public class InputUpdateCaseAsdkV9Dto
    {
        public List<InputAdditionalFields> AdditionalFields { set; get; }
        public int? CategoryId { set; get; }
        public int? CiId { set; get; }
        public string Commentary { set; get; }
        public string CommentaryNoHtml { set; get; }
        public int? CompanyId { set; get; }
        public int? CustomerId { set; get; }
        public string Description { set; get; }
        public string DescriptionNoHtml { set; get; }
        public int? GroupId { set; get; }
        public int? ImpactId { set; get; }
        public int? ItemType { set; get; }
        public int? ItemVersion { set; get; }
        public int? OlaId { set; get; }
        public int? PriorityId { set; get; }

        [Required(ErrorMessage = Constants.RequiredProjectId)]
        [Range(1, long.MaxValue, ErrorMessage = Constants.InvalidRangeProjectId)]
        public int ProjectId { set; get; }

        public int? ProviderId { set; get; }
        public int? ReasonId { get; set; }
        public int? RegistryTypeId { set; get; }
        public int? ResponsibleId { set; get; }
        public int? ServiceId { set; get; }
        public int? SlaId { set; get; }
        public int? StateId { set; get; }
        public string Subject { set; get; }
        public int? UcId { set; get; }
        public int? UnitId { set; get; }

        #region itemType problema

        public string Cause { set; get; }
        public string CorrectActions { set; get; }
        public string FollowUpActions { set; get; }
        public string IncorrectActions { set; get; }
        public bool? KnownError { set; get; }
        public bool? MajorProblem { get; set; }
        public string Recomendations { set; get; }

        #endregion

        public int? UrgencyId { set; get; }
    }
}
// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Data.Objects.Models.Input.InputBase;
using System.Collections.Generic;

namespace Aranda.ASDK.Data.Objects.Models.Input.ASDK_V9
{
    public class InputCreateCaseAsdkV9Dto : InputCreateCaseBaseDto
    {
        public List<InputAdditionalFields> AdditionalFields { set; get; }
        public string Commentary { set; get; }
        public string CommentaryNoHtml { set; get; }
        public string DescriptionNoHtml { set; get; }
        public int ImpactId { set; get; }
        public int ItemType { set; get; }
        public int? ItemVersion { set; get; }
        public int? OlaId { set; get; }
        public int PriorityId { set; get; }
        public int? ProviderId { set; get; }
        public int? ReasonId { get; set; }
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
    }
}
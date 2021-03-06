﻿// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Data.Objects.Models.Input.InputBase;
using Aranda.ASDK.Data.Objects.Utils;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aranda.ASDK.Data.Objects.Models.Input.ASDK_V8
{
    public class InputUpdateCaseDto
    {
        public List<InputAdditionalFields> AdditionalFields { set; get; }

        [Required(ErrorMessage = Constants.RequiredCaseId)]
        [Range(1, long.MaxValue, ErrorMessage = Constants.InvalidRangeCasetype)]
        public long CaseId { set; get; }

        [Required(ErrorMessage = Constants.RequiredCasetype)]
        [Range(1, 4, ErrorMessage = Constants.InvalidRangeCasetype)]
        public int CaseType { set; get; }

        public int? CategoryId { set; get; }
        public int? CompanyId { set; get; }
        public int? CustomerId { set; get; }
        public string Description { set; get; }
        public int? GroupId { set; get; }
        public int? ImpactId { set; get; }
        public int? ProjectId { set; get; } // no modifica
        public int? RegistryTypeId { set; get; }
        public int? ResponsibleId { set; get; } // no modifica
        public int? ServiceId { set; get; }
        public int? SlaId { set; get; }
        public int? SpecialistId { set; get; }
        public int? StateId { set; get; }
        public string Subject { set; get; } // UnauthorizedSubjectModification
        public int? UrgencyId { set; get; }
    }
}
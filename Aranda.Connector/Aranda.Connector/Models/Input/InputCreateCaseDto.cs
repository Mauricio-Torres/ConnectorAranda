// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Connector.Api.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aranda.Connector.Api.Models.Input
{
    /// <summary>
    /// Input para la creación de un caso en ServiceDesk
    /// </summary>
    public class InputCreateCaseDto
    {
        public List<InputAdditionalFields> AdditionalFields { set; get; }

        [Required(ErrorMessage = Constants.RequiredCasetype)]
        [Range(1, 4, ErrorMessage = Constants.InvalidRangeCasetype)]
        public int CaseType { set; get; }

        [Required(ErrorMessage = Constants.RequiredCategoryId)]
        public int CategoryId { set; get; }

        public int? CiId { set; get; }
        public int? CompanyId { set; get; }
        public int? CustomerId { set; get; }

        [Required(ErrorMessage = Constants.RequiredDescription)]
        public string Description { set; get; }

        [Required(ErrorMessage = Constants.RequiredGroupId)]
        public int GroupId { set; get; }

        [Required(ErrorMessage = Constants.RequiredProjectId)]
        [Range(1, long.MaxValue, ErrorMessage = Constants.InvalidRangeProjectId)]
        public int ProjectId { set; get; }

        [Required(ErrorMessage = Constants.RequiredRegistryTypeId)]
        public int RegistryTypeId { set; get; }

        public int? ResponsibleId { set; get; }

        [Required(ErrorMessage = Constants.RequiredServiceId)]
        public int ServiceId { set; get; }

        [Required(ErrorMessage = Constants.RequiredSlaId)]
        public int SlaId { set; get; }

        [Required(ErrorMessage = Constants.RequiredStateId)]
        public int? StateId { set; get; }

        public string Subject { set; get; }

        [Required(ErrorMessage = Constants.RequiredUrgencyId)]
        public int? UrgencyId { set; get; }
    }
}
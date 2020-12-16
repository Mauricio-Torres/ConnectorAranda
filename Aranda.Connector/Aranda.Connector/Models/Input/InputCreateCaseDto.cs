// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Connector.Api.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace Aranda.Connector.Api.Models.Input
{
    /// <summary>
    /// Input para la creación de un caso en ServiceDesk
    /// </summary>
    public class InputCreateCaseDto
    {
        [Required(ErrorMessage = Constants.RequiredCasetype)]
        [Range(1, 4, ErrorMessage = Constants.InvalidRangeCasetype)]
        public int CaseType { set; get; }

        [Required(ErrorMessage = Constants.RequiredCategoryId)]
        [Range(1, long.MaxValue, ErrorMessage = Constants.InvalidRangeCategoryId)]
        public int CategoryId { set; get; }

        public int? CiId { set; get; }
        public int? CompanyId { set; get; }
        public int? CustomerId { set; get; }

        [Required(ErrorMessage = Constants.RequiredDescription)]
        public string Description { set; get; }

        [Required(ErrorMessage = Constants.RequiredGroupId)]
        [Range(1, long.MaxValue, ErrorMessage = Constants.InvalidRangeGroupId)]
        public int GroupId { set; get; }

        [Required(ErrorMessage = Constants.RequiredProjectId)]
        [Range(1, long.MaxValue, ErrorMessage = Constants.InvalidRangeProjectId)]
        public int ProjectId { set; get; }

        [Required(ErrorMessage = Constants.RequiredRegistryTypeId)]
        [Range(1, long.MaxValue, ErrorMessage = Constants.InvalidRangeRegistryTypeId)]
        public int RegistryTypeId { set; get; }

        public int? ResponsibleId { set; get; }

        [Required(ErrorMessage = Constants.RequiredServiceId)]
        [Range(1, long.MaxValue, ErrorMessage = Constants.InvalidRangeServiceId)]
        public int ServiceId { set; get; }

        [Required(ErrorMessage = Constants.RequiredSlaId)]
        [Range(1, long.MaxValue, ErrorMessage = Constants.InvalidRangeSlaId)]
        public int SlaId { set; get; }

        public int? StateId { set; get; }
        public string Subject { set; get; }
        public int? UrgencyId { set; get; }
    }
}
// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Data.Objects.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace Aranda.ASDK.Data.Objects.Models.Input.InputBase
{
    public class InputCreateCaseBaseDto
    {
        [Required(ErrorMessage = Constants.RequiredCategoryId)]
        public int CategoryId { set; get; }

        public int? CiId { set; get; }
        public int? CompanyId { set; get; }

        public int? CustomerId { set; get; }

        [Required(ErrorMessage = Constants.RequiredDescription)]
        public string Description { set; get; }

        [Required(ErrorMessage = Constants.RequiredGroupId)]
        public int? GroupId { set; get; }

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
        public int StateId { set; get; }

        [Required(ErrorMessage = Constants.RequiredSubject)]
        public string Subject { set; get; }

        [Required(ErrorMessage = Constants.RequiredUrgencyId)]
        public int UrgencyId { set; get; }
    }
}
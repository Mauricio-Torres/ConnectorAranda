// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Connector.Api.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace Aranda.Connector.Api.Models.Input
{
    public class InputGetCaseDto
    {
        [Required(ErrorMessage = Constants.RequiredCaseId)]
        [Range(1, long.MaxValue, ErrorMessage = Constants.InvalidRangeCasetype)]
        public long CaseId { set; get; }

        [Required(ErrorMessage = Constants.RequiredCasetype)]
        [Range(1, 4, ErrorMessage = Constants.InvalidRangeCasetype)]
        public int CaseType { set; get; }

        [Range(0, 2, ErrorMessage = Constants.InvalidRangeLevelId)]
        public int? LevelId { set; get; }
    }
}
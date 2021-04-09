// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Data.Objects.Models.Input.InputBase;
using Aranda.ASDK.Data.Objects.Utils;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aranda.ASDK.Data.Objects.Models.Input.ASDK_V8
{
    /// <summary>
    /// Input para la creación de un caso en ServiceDesk V8
    /// </summary>
    public class InputCreateCaseAsdkV8Dto : InputCreateCaseBaseDto
    {
        public List<InputAdditionalFields> AdditionalFields { set; get; }

        [Required(ErrorMessage = Constants.RequiredCasetype)]
        [Range(1, 4, ErrorMessage = Constants.InvalidRangeCasetype)]
        public int CaseType { set; get; }
    }
}
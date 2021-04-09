// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Data.Objects.Utils;
using System.ComponentModel.DataAnnotations;

namespace Aranda.ASDK.Data.Objects.Models.Input.ASDK_V8
{
    public class InputAuthenticateDto
    {
        public int? ConsoleType { get; set; }

        [Required(ErrorMessage = Constants.RequiredPassword)]
        public string password { get; set; }

        [Required(ErrorMessage = Constants.RequiredUserName)]
        public string username { get; set; }
    }
}
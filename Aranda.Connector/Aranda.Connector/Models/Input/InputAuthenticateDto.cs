// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Connector.Api.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Aranda.Connector.Api.Models.Input
{
    public class InputAuthenticateDto
    {
        [Required(ErrorMessage = Constants.RequiredPassword)]
        public string password { get; set; }

        [Required(ErrorMessage = Constants.RequiredUserName)]
        public string username { get; set; }
    }
}
// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
namespace Aranda.Connector.Api.Models.ConvertDataApi
{
    public class AnswerAuthentication
    {
        public bool LicenseIsNamed { set; get; }
        public bool LicenseIsReadOnlyNamed { set; get; }
        public bool Result { set; get; }
        public string SessionId { set; get; }
        public int UserId { set; get; }
    }
}
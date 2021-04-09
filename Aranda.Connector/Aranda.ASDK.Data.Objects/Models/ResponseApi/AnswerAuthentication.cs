// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
namespace Aranda.ASDK.Data.Objects.Models.ResponseApi
{
    public class AnswerAuthentication
    {
        public bool LicenseIsNamed { set; get; }
        public bool LicenseIsReadOnlyNamed { set; get; }
        public bool Result { set; get; }
        public string SessionId { set; get; }
        public int UserId { set; get; }
    }

    public class AnswerAuthenticationV9
    {
        public string DefaultUrl { set; get; }
    }
}
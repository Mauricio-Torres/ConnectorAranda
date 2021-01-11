// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
namespace Aranda.Connector.Api.Models
{
    public class UpdateFields
    {
        public int CaseId { set; get; }
        public int CaseType { set; get; }
        public int Id { set; get; }
        public bool IsBasic { set; get; }
        public int UserId { set; get; }
        public object Value { set; get; }
        public int ValueType { set; get; }
    }
}
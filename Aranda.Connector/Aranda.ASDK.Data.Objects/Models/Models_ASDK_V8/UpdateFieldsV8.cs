// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
namespace Aranda.ASDK.Data.Objects.Models.Models_ASDK_V8
{
    public class UpdateFieldsV8
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
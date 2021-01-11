// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
namespace Aranda.Connector.Api.Models.ResponseApi
{
    public class AnwerGetAdditionalField
    {
        public int FieldOrder { set; get; }
        public int Id { set; get; }
        public object IdParentField { set; get; }
        public bool IsBasic { set; get; }
        public bool IsFieldMapped { set; get; }
        public bool Mandatory { set; get; }
        public object MaxValue { set; get; }
        public object MinValue { set; get; }
        public string Name { set; get; }
        public int Order { set; get; }
        public object PatternMask { set; get; }
        public bool RegHistory { set; get; }
        public int SectionId { set; get; }
        public int Type { set; get; }
        public object ValueField { set; get; }
        public object ValueLookup { set; get; }
        public object ValueLookups { set; get; }
        public bool VisibleUser { set; get; }
    }
}
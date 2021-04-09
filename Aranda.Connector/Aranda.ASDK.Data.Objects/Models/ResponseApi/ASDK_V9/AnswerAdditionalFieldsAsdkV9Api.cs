// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using System.Collections.Generic;
using System.IO;

namespace Aranda.ASDK.Data.Objects.Models.ResponseApi.ASDK_V9
{
    public class AdditionalFieldsV9
    {
        private string name;
        public bool? boolValue { set; get; }
        public int? catalogId { get; set; }
        public long? dateValue { set; get; }
        public string description { set; get; }
        public bool? editableUser { get; set; }
        public bool? enable { set; get; }
        public int? fieldId { set; get; }
        public int fieldType { set; get; }
        public string fieldTypeName { get; set; }
        public float? floatValue { set; get; }
        public string identifier { set; get; }
        public Stream inputStream { get; set; }
        public int? intValue { set; get; }
        public bool? isValid { get; set; }
        public int? itemId { set; get; }
        public List<LookupValues> lookupValues { get; set; }
        public bool? mandatory { set; get; }
        public bool? mandatoryUser { get; set; }

        public string Name
        {
            get
            {
                string modifyName;
                if (!name.Contains(string.Format("({0})", fieldTypeName)))
                {
                    modifyName = string.Format("{0} ({1})", name, fieldTypeName);
                }
                else
                {
                    modifyName = name;
                }
                return modifyName;
            }
            set { name = value; }
        }

        public int? order { set; get; }
        public int? projectId { get; set; }
        public LookupValues selected { get; set; }
        public string stringValue { set; get; }
        public int? templateField { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public long? valueDateField { get; set; }
        public int? valueIntField { get; set; }
        public bool? visible { set; get; }

        public override bool Equals(object obj)
        {
            return obj is AdditionalFieldsV9 &&
                ((AdditionalFieldsV9)obj).description == description &&
                ((AdditionalFieldsV9)obj).enable == enable &&
                ((AdditionalFieldsV9)obj).fieldId == fieldId &&
                ((AdditionalFieldsV9)obj).fieldType == fieldType &&
                ((AdditionalFieldsV9)obj).identifier == identifier &&
                ((AdditionalFieldsV9)obj).isValid == isValid &&
                ((AdditionalFieldsV9)obj).mandatory == mandatory &&
                ((AdditionalFieldsV9)obj).order == order &&
                ((AdditionalFieldsV9)obj).visible == visible;
            //((AdditionalFieldsV9)obj).ProjectId == ProjectId &&
            //((AdditionalFieldsV9)obj).StringValue == StringValue &&
            //((AdditionalFieldsV9)obj).Type == Type &&
            //((AdditionalFieldsV9)obj).Url == Url &&
            //((AdditionalFieldsV9)obj).ItemId == ItemId &&
            //((AdditionalFieldsV9)obj).InputStream == InputStream &&
            //((AdditionalFieldsV9)obj).IntValue == IntValue &&
            //((AdditionalFieldsV9)obj).FieldTypeName == FieldTypeName &&
            //((AdditionalFieldsV9)obj).FloatValue == FloatValue &&
            //((AdditionalFieldsV9)obj).BoolValue == BoolValue &&
            //((AdditionalFieldsV9)obj).CatalogId == CatalogId &&
            //((AdditionalFieldsV9)obj).DateValue == DateValue &&
        }
    }

    public class AnswerAdditionalFieldsAsdkV9Api
    {
        public List<AdditionalFieldsV9> Content { set; get; }
        public int TotalItems { set; get; }
    }

    public class LookupValues
    {
        public int? catalogId { get; set; }
        public int? fieldId { get; set; }
        public int? fieldType { get; set; }
        public int? id { get; set; }
        public string name { get; set; }
    }

    public class MapperAdditionalFieldsV9
    {
        public string Description { set; get; }
        public bool? Enable { set; get; }
        public int? FieldId { set; get; }
        public int? FieldType { set; get; }
        public string FieldTypeName { get; set; }
        public string Identifier { set; get; }
        public bool? IsValid { get; set; }
        public bool? Mandatory { set; get; }
        public string Name { get; set; }
        public int? Order { set; get; }
        public bool? Visible { set; get; }
    }
}
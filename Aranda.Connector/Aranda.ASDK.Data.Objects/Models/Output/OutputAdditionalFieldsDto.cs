// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using System.Collections.Generic;

namespace Aranda.ASDK.Data.Objects.Models.Output
{
    public class AdditionalFields
    {
        public string Id { set; get; }
        public string Name { set; get; }
    }

    public class OutputAdditionalFieldsDto
    {
        public List<AdditionalFields> Parameters { set; get; }
    }

    public class TransformAdditionalFields
    {
        public int Id { set; get; }
        public bool IsBasic { set; get; }
        public int ValueType { set; get; }
    }
}
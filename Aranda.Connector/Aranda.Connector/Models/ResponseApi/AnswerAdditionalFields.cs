// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using System.Collections.Generic;

namespace Aranda.Connector.Api.Models.ResponseApi
{
    public class AdditionalFields
    {
        public string Id { set; get; }
        public string Name { set; get; }
    }

    public class AnswerAdditionalFields
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
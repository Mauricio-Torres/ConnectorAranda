// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using System.Collections.Generic;

namespace Aranda.ASDK.Data.Objects.Models.ResponseApi.ASDK_V9
{
    public class AnswerGetGeneralPriorityV9Api
    {
        public List<UrgencyV9> Content { set; get; }
        public int TotalItems { set; get; }
    }

    public class UrgencyV9
    {
        public int? CatalogId { set; get; }
        public string Description { set; get; }
        public int? Id { set; get; }
        public string Key { set; get; }
        public string Name { set; get; }
        public int? Order { set; get; }
        public int? ParentId { set; get; }
        public int? StateId { set; get; }
    }
}
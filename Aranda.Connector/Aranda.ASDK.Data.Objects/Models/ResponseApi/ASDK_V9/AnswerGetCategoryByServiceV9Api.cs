// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using System.Collections.Generic;

namespace Aranda.ASDK.Data.Objects.Models.ResponseApi.ASDK_V9
{
    public class AnswerGetCategoryByServiceV9Api
    {
        public List<CategoryByService> Content { set; get; }
        public int TotalItems { set; get; }
    }

    public class CategoryByService
    {
        public int? ChildrenCount { set; get; }
        public bool? HasChild { set; get; }
        public string Hierarchy { set; get; }
        public object Hint { set; get; }
        public int? Id { set; get; }
        public int? ImageIndex { set; get; }
        public string Name { set; get; }
        public int? ParentId { set; get; }
    }
}
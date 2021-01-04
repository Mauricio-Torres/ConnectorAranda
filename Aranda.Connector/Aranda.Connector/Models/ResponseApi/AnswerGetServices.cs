// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>

namespace Aranda.Connector.Api.Models.ResponseApi
{
    public class AnswerGetServices
    {
        public int? AmountCategories { set; get; }
        public string Description { set; get; }
        public int Id { set; get; }
        public string Image { set; get; }
        public string ImpactName { set; get; }
        public bool? IsConfidential { set; get; }
        public bool? IsFolder { set; get; }
        public string Name { set; get; }
        public int? ParentId { set; get; }
        public int? ServiceCount { set; get; }
    }
}
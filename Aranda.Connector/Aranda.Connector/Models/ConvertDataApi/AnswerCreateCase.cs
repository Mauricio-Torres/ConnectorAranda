// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
namespace Aranda.Connector.Api.Models.ConvertDataApi
{
    public class AnswerCreateCase
    {
        public string ComposedItemId { set; get; }
        public bool IsClosed { set; get; }
        public int ItemId { set; get; }
        public string Qs { set; get; }
        public bool Result { set; get; }
    }
}
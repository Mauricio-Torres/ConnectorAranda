// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
namespace Aranda.Connector.Api.Models
{
    public class UpdateCase
    {
        public int? CategoryId { set; get; }
        public int? CompanyId { set; get; }
        public int? CustomerId { set; get; }
        public string Description { set; get; }
        public int? GroupId { set; get; }
        public int? ImpactId { set; get; }
        public int? ProjectId { set; get; }
        public int? RegistryTypeId { set; get; }
        public int? ResponsibleId { set; get; }
        public int? ServiceId { set; get; }
        public int? SlaId { set; get; }
        public int? SpecialistId { set; get; }
        public int? StateId { set; get; }
        public string Subject { set; get; }
        public int? UrgencyId { set; get; }
    }
}
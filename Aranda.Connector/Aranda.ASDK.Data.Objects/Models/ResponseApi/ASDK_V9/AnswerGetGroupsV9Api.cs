// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using System.Collections.Generic;

namespace Aranda.ASDK.Data.Objects.Models.ResponseApi.ASDK_V9
{
    public class AnswerGetGroupsV9Api
    {
        public List<GroupsV0> Content { set; get; }
        public int TotalItems { set; get; }
    }

    public class GroupsV0
    {
        public int? Active { set; get; }
        public object Cost { set; get; }
        public string Description { set; get; }
        public string GuidLDAP { set; get; }
        public int? Id { set; get; }
        public bool? IsEditable { set; get; }
        public bool? IsImported { set; get; }
        public string Name { set; get; }
        public object Price { set; get; }
        public int? UserId { set; get; }
        public object UserName { set; get; }
    }
}
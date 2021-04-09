// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using System.Collections.Generic;

namespace Aranda.ASDK.Data.Objects.Models.ResponseApi.ASDK_V9
{
    public class AnswerGetProjectV9Api
    {
        public List<Project> Content { set; get; }
        public int TotalItems { set; get; }
    }

    public class Project
    {
        public string Description { set; get; }
        public bool? HasActiveServices { set; get; }
        public int? Id { set; get; }
        public string Image { set; get; }
        public int ImageId { set; get; }
        public bool? IsActiveChat { set; get; }
        public string Name { set; get; }
    }
}
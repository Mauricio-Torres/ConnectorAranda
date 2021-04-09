// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using System.Collections.Generic;

namespace Aranda.ASDK.Data.Objects.Models.ResponseApi.ASDK_V9
{
    public class AnswerGetReasonsByStateV9
    {
        public List<ReasonsByStateV9> Content { set; get; }
        public int TotalItems { set; get; }
    }

    public class ReasonsByStateV9
    {
        public int? Id { set; get; }
        public string Name { set; get; }
        public int? TransitionId { set; get; }
    }
}
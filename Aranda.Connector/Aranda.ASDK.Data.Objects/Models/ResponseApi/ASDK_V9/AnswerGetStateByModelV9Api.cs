// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using System.Collections.Generic;

namespace Aranda.ASDK.Data.Objects.Models.ResponseApi.ASDK_V9
{
    public class AnswerGetStateByModelV9Api
    {
        public List<StateByModelV9> Content { set; get; }
        public int TotalItems { set; get; }
    }

    public class StateByModelV9
    {
        public string BackgroundColorRgb { set; get; }
        public string Description { set; get; }
        public string ForegroundColorRgb { set; get; }
        public bool? HaveRisk { set; get; }
        public int? Id { set; get; }
        public bool? IsFinal { set; get; }
        public bool? IsVotingProcess { set; get; }
        public string Name { set; get; }
    }
}
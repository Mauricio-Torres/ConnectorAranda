// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using System.Collections.Generic;

namespace Aranda.ASDK.Data.Objects.Models.ResponseApi.ASDK_V9
{
    public class AnswerGeneralParametersV9
    {
        public List<GeneralParameterV9> Content { set; get; }
        public int TotalItems { set; get; }
    }

    public class GeneralParameterV9
    {
        public int? Id { set; get; }
        public string Name { set; get; }
    }
}
// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using System.Collections.Generic;

namespace Aranda.ASDK.Data.Objects.Models.ResponseApi
{
    public class OutputParametersDto
    {
        public List<Parameters> Parameters { set; get; }
    }

    public class Parameters
    {
        public int? Id { set; get; }
        public string Name { set; get; }

        public override bool Equals(object obj)
        {
            return obj is Parameters && ((Parameters)obj).Id == Id && ((Parameters)obj).Name == Name;
        }
    }
}
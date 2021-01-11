// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Connector.Api.Models;
using System.Linq;

namespace Aranda.Connector.Api.Utils.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Reemplaza los valores correspondientes a los parámetros de los endpoint
        /// </summary>
        /// <param name="url">endpoint</param>
        /// <param name="urlParameters">parámetros a reemplazar en la URL</param>
        /// <returns></returns>
        public static string ConvertUrl(this string url, UrlParameters urlParameters)
        {
            var listPropertyCase = GenericPropertyEntity<UrlParameters>.ModelProperty(urlParameters).Where(x => x.Item2 != null).ToList();

            foreach (var item in listPropertyCase)
            {
                string parametro = "{" + item.Item1 + "}";
                url = url.Replace(parametro, item.Item2.ToString());
            }

            return url;
        }

        /// <summary>
        /// Valida endpoint ingresado
        /// </summary>
        /// <param name="urlServiceDesk">endpoint Service Desk</param>
        /// <returns></returns>
        public static string ValidationUrl(this string urlServiceDesk)
        {
            if (!string.IsNullOrWhiteSpace(urlServiceDesk) && !urlServiceDesk.EndsWith('/'))
            {
                urlServiceDesk = urlServiceDesk + '/';
            }

            return urlServiceDesk;
        }
    }
}
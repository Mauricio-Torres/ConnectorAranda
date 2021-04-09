// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Data.Objects.Models;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aranda.ASDK.Connector.Service.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Reemplaza los valores correspondientes a los parámetros de los endpoint
        /// </summary>
        /// <param name="url">endpoint</param>
        /// <param name="urlParameters">parámetros a reemplazar en la URL</param>
        /// <returns></returns>
        public static string ConvertUrl(this string url, UrlParameters urlParameters, bool? addField = null)
        {
            var listPropertyCase = GenericPropertyEntity<UrlParameters>.ModelProperty(urlParameters);
            List<Tuple<string, object>> tuples = new List<Tuple<string, object>>();
            string newUrl = string.Empty;

            foreach (var item in listPropertyCase.Where(x => x.Item2 != null))
            {
                string parametro = "{" + item.Item1 + "}";
                string value = item.Item2.ToString();

                if (!url.Contains(parametro) && addField == true)
                {
                    tuples.Add(item);
                }

                url = url.Replace(parametro, value);
            }

            newUrl = url;

            if (newUrl.Contains("?") && addField == true)
            {
                var param = new Dictionary<string, string>();

                foreach (var item in tuples)
                {
                    param.Add(item.Item1, item.Item2.ToString());
                }

                newUrl = new Uri(QueryHelpers.AddQueryString(url, param)).ToString();
            }
            return newUrl;
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
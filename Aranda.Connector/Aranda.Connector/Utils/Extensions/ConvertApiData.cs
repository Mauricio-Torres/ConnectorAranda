// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Connector.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Aranda.Connector.Api.Utils.Extensions
{
    public static class ExtensionConvers
    {
        /// <summary>
        /// Adiciona nuevas propiedades (campo-valor) a la lista de propiedades obligatorias
        /// </summary>
        /// <param name="requestApis">lista de propiedades inicial</param>
        /// <param name="newProperty">lista de propiedades a adicionar</param>
        /// <returns>lista de propiedades (campo-valor) modificada</returns>
        public static List<AnswerApi> AddProperties(this List<AnswerApi> requestApis, List<AnswerApi> newProperty)
        {
            foreach (var item in newProperty)
            {
                AnswerApi answerApi = requestApis.FirstOrDefault(x => x.Field.Equals(item.Field));
                if (!string.IsNullOrWhiteSpace(item.Field) && item.Value != null && answerApi == null)
                {
                    var value = item.Value.ToString();

                    if (Int32.TryParse(value, out int num))
                    {
                        requestApis.Add(new AnswerApi
                        {
                            Field = item.Field,
                            Value = num
                        });
                    }
                    else if (bool.TryParse(value, out bool response))
                    {
                        requestApis.Add(new AnswerApi
                        {
                            Field = item.Field,
                            Value = response
                        });
                    }
                    else
                    {
                        requestApis.Add(new AnswerApi
                        {
                            Field = item.Field,
                            Value = value
                        });
                    }
                }
            }

            return requestApis;
        }

        /// <summary>
        /// Convierte una lista de propiedades en la clase inicializada
        /// </summary>
        /// <param name="listPropeties">Lista de propiedades con su respectivo valor</param>
        /// <param name="parseClass">clase que se desea construir a partir de la lista</param>
        /// <returns>clase que se inicializa </returns>
        public static TModel ConvertModel<TModel>(this List<AnswerApi> listPropeties, TModel parseClass) where TModel : class
        {
            Type model = typeof(TModel);

            PropertyInfo[] propertiesClass = model.GetProperties();

            foreach (var item in listPropeties)
            {
                var propertyInstance = propertiesClass.FirstOrDefault(x => x.Name.ToLower().Equals(item.Field.ToLower()));
                if (propertyInstance != null)
                {
                    Type propertytype = propertyInstance.PropertyType;

                    if (propertytype.Equals(typeof(string)))
                    {
                        propertyInstance.SetValue(parseClass, item.Value);
                    }
                    else if (propertytype.Equals(typeof(int)))
                    {
                        propertyInstance.SetValue(parseClass, Convert.ToInt32(item.Value));
                    }
                    else if (propertytype.Equals(typeof(bool)))
                    {
                        propertyInstance.SetValue(parseClass, Convert.ToBoolean(item.Value));
                    }
                }
            }

            return parseClass;
        }

        /// <summary>
        /// Convierte los datos enviados desde la interfaz de implementación en los datos aceptados por la api de Service Desk
        /// </summary>
        /// <param name="tmodelObj">Clase que se desea transformar</param>
        /// <param name="validationProperty">clasifica si las propiedades vacías son incluidas en la lista</param>
        /// <returns>lista de propiedad-valor</returns>
        public static List<AnswerApi> FillProperties<TModel>(this List<AnswerApi> requestApis, TModel tmodelObj, bool validationProperty)
            where TModel : class
        {
            var listPropertyCase = GenericPropertyEntity<TModel>.ModelProperty(tmodelObj);

            if (validationProperty)
            {
                foreach (var item in listPropertyCase)
                {
                    if (item.Item2 != null)
                    {
                        Type itemType = item.Item2.GetType();

                        if (itemType.Equals(typeof(int)) && Convert.ToInt32(item.Item2) != 0)
                        {
                            requestApis.Add(new AnswerApi
                            {
                                Field = item.Item1,
                                Value = item.Item2
                            });
                        }
                        else if (itemType.Equals(typeof(string)) && !string.IsNullOrWhiteSpace(item.Item2.ToString()))
                        {
                            requestApis.Add(new AnswerApi
                            {
                                Field = item.Item1,
                                Value = item.Item2
                            });
                        }
                    }
                }
            }
            else
            {
                requestApis = listPropertyCase.Select(item => new AnswerApi
                {
                    Field = item.Item1,
                    Value = item.Item2
                }).ToList();
            }

            return requestApis;
        }
    }

    /// <summary>
    /// Obtiene los atributos de la clase y su valor
    /// </summary>
    /// <typeparam name="TModel">Clase para obtener los parámetros</typeparam>
    public static class GenericPropertyEntity<TModel> where TModel : class
    {
        /// <summary>
        /// Obtiene el nombre de los atributos de una clase y su valor
        /// </summary>
        /// <param name="tmodelObj">clase a extraer los atributos y valor</param>
        /// <returns>Tuple con nombre de atributo en la clase y valor correspondiente </returns>
        public static List<Tuple<string, object>> ModelProperty(TModel tmodelObj)
        {
            Type tModelType = tmodelObj.GetType();
            PropertyInfo[] arrayPropertyInfos = tModelType.GetProperties();

            return arrayPropertyInfos.Select(property =>
                new Tuple<string, object>(property.Name, property.GetValue(tmodelObj)))
                .ToList();
        }
    }
}
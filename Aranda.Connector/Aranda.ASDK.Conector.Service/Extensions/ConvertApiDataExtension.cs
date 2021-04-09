// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Data.Objects.Models.ResponseApi.ASDK_V8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Aranda.ASDK.Connector.Service.Extensions
{
    public static class ExtensionConvers
    {
        /// <summary>
        /// Adiciona un elemento único a una lista
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="list"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static List<TModel> AddUnic<TModel>(this List<TModel> list, TModel data) where TModel : class
        {
            if (data != null && list.Find(x => x.Equals(data)) == null)
            {
                list.Add(data);
            }

            return list;
        }

        /// <summary>
        /// Convierte una lista de propiedades-valor en la clase inicializada
        /// </summary>
        /// <param name="listPropeties">Lista de propiedades con su respectivo valor</param>
        /// <param name="parseClass">clase que se desea construir a partir de la lista</param>
        /// <returns>clase que se inicializa </returns>
        public static TModel ConvertModel<TModel>(this List<AnswerGeneralV8Api> listPropeties, TModel parseClass) where TModel : class
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
        /// Adiciona un objeto dentro de una lista del mismo tipo
        /// </summary>
        /// <typeparam name="TModel">Objeto adicionado dentro de una lista del mismo tipo</typeparam>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static List<TModel> ConvertToList<TModel>(this TModel parameter) where TModel : class
        {
            var listPropertyCase = GenericPropertyEntity<TModel>.ModelProperty(parameter);
            List<TModel> parameters = new List<TModel>();
            int control = 0;
            foreach (var item in listPropertyCase)
            {
                if (item.Item2 == null)
                {
                    control++;
                }
            }

            if (listPropertyCase.Count != control)
            {
                parameters.Add(parameter);
            }

            return parameters;
        }

        /// <summary>
        /// Convierte los datos enviados desde la interfaz de implementación en los datos aceptados por la api de Service Desk V8
        /// </summary>
        /// <param name="tmodelObj">Clase que se desea transformar</param>
        /// <param name="validationProperty">clasifica si las propiedades vacías son incluidas en la lista</param>
        /// <returns>lista de propiedad-valor</returns>
        public static List<AnswerGeneralV8Api> FillProperties<TModel>(this List<AnswerGeneralV8Api> requestApis, TModel tmodelObj, bool validationProperty)
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
                            requestApis.Add(new AnswerGeneralV8Api
                            {
                                Field = item.Item1,
                                Value = item.Item2
                            });
                        }
                        else if (itemType.Equals(typeof(string)) && !string.IsNullOrWhiteSpace(item.Item2.ToString()))
                        {
                            requestApis.Add(new AnswerGeneralV8Api
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
                requestApis = listPropertyCase.Select(item => new AnswerGeneralV8Api
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
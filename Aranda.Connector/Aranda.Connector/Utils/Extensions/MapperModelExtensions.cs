// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Connector.Api.Models;
using Aranda.Connector.Api.Models.Input;
using Aranda.Connector.Api.Models.ResponseApi;
using AutoMapper;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Aranda.Connector.Api.Utils.Extensions
{
    public static class MapperModelExtensions
    {
        /// <summary>
        /// Convierte una lista de parámetros enviados por Service Desk en una lista de parámetros usados por el conector
        /// </summary>
        /// <param name="listData"></param>
        /// <returns></returns>
        public static List<AdditionalFields> MapperModelAdditionalFields(this List<AnwerGetAdditionalField> listData)
        {
            List<AdditionalFields> listParameters = new List<AdditionalFields>();
            foreach (var item in listData)
            {
                listParameters.Add(new AdditionalFields
                {
                    Id = item.SerializeObject(),
                    Name = item.Name
                });
            }

            return listParameters;
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static CreateCase MapperModelCreate<TModel>(this TModel model) where TModel : class
        {
            MapperConfiguration config = new MapperConfiguration(mc => mc.CreateMap<TModel, CreateCase>());
            Mapper mapper = new Mapper(config);

            return mapper.Map<TModel, CreateCase>(model);
        }

        /// <summary>
        /// Convierte una lista de parámetros enviados por Service Desk en una lista de parámetros usados por el conector
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="listData"></param>
        /// <returns></returns>
        public static List<Parameters> MapperModelParameters<TModel>(this List<TModel> listData) where TModel : class
        {
            MapperConfiguration config = new MapperConfiguration(mc => mc.CreateMap<TModel, Parameters>());
            Mapper mapper = new Mapper(config);

            List<Parameters> listParameters = new List<Parameters>();
            foreach (var item in listData)
            {
                listParameters.Add(mapper.Map<TModel, Parameters>(item));
            }

            return listParameters;
        }

        /// <summary>
        /// Convierte
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static UpdateCase MapperModelUpdate<TModel>(this TModel model) where TModel : class
        {
            MapperConfiguration config = new MapperConfiguration(mc => mc.CreateMap<TModel, UpdateCase>());
            Mapper mapper = new Mapper(config);

            return mapper.Map<TModel, UpdateCase>(model);
        }

        /// <summary>
        /// Convierte una lista de parámetros enviados por el usuario en una lista que puede leer la interfaz de Service Desk
        /// </summary>
        /// <param name="listAdditionalFields"></param>
        /// <param name="userId"></param>
        /// <param name="CaseId"></param>
        /// <param name="CaseType"></param>
        /// <returns></returns>
        public static List<UpdateFields> MapperModelUpdateFields(this List<InputAdditionalFields> listAdditionalFields, int userId, int CaseId, int CaseType)
        {
            List<UpdateFields> listBasicFields = new List<UpdateFields>();

            foreach (var item in listAdditionalFields)
            {
                TransformAdditionalFields additionalFields = JsonConvert.DeserializeObject<TransformAdditionalFields>(item.AdvancedFieldId);
                UpdateFields updateFields = new UpdateFields
                {
                    CaseId = CaseId,
                    CaseType = CaseType,
                    Id = additionalFields.Id,
                    IsBasic = additionalFields.IsBasic,
                    UserId = userId,
                    Value = item.Value,
                    ValueType = additionalFields.ValueType
                };

                listBasicFields.Add(updateFields);
            }

            return listBasicFields;
        }

        private static string SerializeObject(this AnwerGetAdditionalField anwerGetAdditionalField)
        {
            return JsonConvert.SerializeObject(new TransformAdditionalFields
            {
                Id = anwerGetAdditionalField.Id,
                IsBasic = anwerGetAdditionalField.IsBasic,
                ValueType = anwerGetAdditionalField.Type
            });
        }
    }
}
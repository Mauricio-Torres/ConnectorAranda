// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Data.Objects.Models.Input.InputBase;
using Aranda.ASDK.Data.Objects.Models.Models_ASDK_V8;
using Aranda.ASDK.Data.Objects.Models.Output;
using Aranda.ASDK.Data.Objects.Models.ResponseApi;
using Aranda.ASDK.Data.Objects.Models.ResponseApi.ASDK_V8;
using AutoMapper;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Aranda.ASDK.Connector.Service.Extensions
{
    public static class MapperModelExtensions
    {
        /// <summary>
        /// Convierte una clase en otra siempre que tenga igualdad en sus atributos
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static TModel MapperModel<T, TModel>(this T model, TModel model1) where T : class
        {
            MapperConfiguration config = new MapperConfiguration(mc => mc.CreateMap<T, TModel>());
            Mapper mapper = new Mapper(config);

            return mapper.Map<T, TModel>(model);
        }

        /// <summary>
        /// Convierte una lista de parámetros enviados por Service Desk en una lista de parámetros usados por el conector
        /// </summary>
        /// <param name="listData"></param>
        /// <returns></returns>
        public static List<AdditionalFields> MapperModelAdditionalFields(this List<AnwerGetAdditionalFieldV8Api> listData)
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
        /// Convierte una lista de parámetros enviados por el usuario en una lista que puede leer la interfaz de Service Desk
        /// </summary>
        /// <param name="listAdditionalFields"></param>
        /// <param name="userId"></param>
        /// <param name="CaseId"></param>
        /// <param name="CaseType"></param>
        /// <returns></returns>
        public static List<UpdateFieldsV8> MapperModelUpdateFields(this List<InputAdditionalFields> listAdditionalFields, int userId, int CaseId, int CaseType)
        {
            List<UpdateFieldsV8> listBasicFields = new List<UpdateFieldsV8>();

            foreach (var item in listAdditionalFields)
            {
                TransformAdditionalFields additionalFields = JsonConvert.DeserializeObject<TransformAdditionalFields>(item.AdvancedFieldId);
                UpdateFieldsV8 updateFields = new UpdateFieldsV8
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

        private static string SerializeObject(this AnwerGetAdditionalFieldV8Api anwerGetAdditionalField)
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
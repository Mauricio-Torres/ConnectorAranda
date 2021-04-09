// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Data.Objects.Models.Output;
using Aranda.ASDK.Data.Objects.Models.ResponseApi.ASDK_V9;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aranda.ASDK.Connector.Service.Interface.ASDK_V9
{
    public interface IManagmentAdditionalFieldV9Service
    {
        public Task<List<AdditionalFieldsV9>> GetAdditionalField(int itemType, int stateId, int categoryId);

        public Task<OutputAdditionalFieldsDto> GetAdditionalFieldParameters(int itemType, int stateId, int categoryId);
    }
}
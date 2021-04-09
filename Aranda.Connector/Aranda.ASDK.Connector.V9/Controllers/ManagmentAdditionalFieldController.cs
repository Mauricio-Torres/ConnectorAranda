// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Connector.Service.Interface.ASDK_V9;
using Aranda.ASDK.Data.Objects.Models.Output;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Aranda.ASDK.Connector.V9.Controllers
{
    [Authorize]
    [Route("api/asdkv9")]
    [ApiController]
    public class ManagmentAdditionalFieldController : ControllerBase
    {
        private readonly IManagmentAdditionalFieldV9Service ManagmentAdditionalFieldService;

        public ManagmentAdditionalFieldController(IManagmentAdditionalFieldV9Service managmentAdditionalFieldService)
        {
            ManagmentAdditionalFieldService = managmentAdditionalFieldService;
        }

        /// <summary>
        /// Campos adicionales
        /// </summary>
        /// <param name="projectId">Id proyecto</param>
        /// <param name="itemType">Tipo caso</param>
        /// <param name="categoryId">Id de categoría</param>
        /// <param name="serviceId">Id de servicio</param>
        /// <param name="stateId">Id estado</param>
        /// <returns></returns>
        [HttpGet("additionalFields/{itemType}/{stateId:int?}/{categoryId:int?}")]
        public async Task<ActionResult<OutputAdditionalFieldsDto>> AdditionalFields(int itemType, int stateId = 0, int categoryId = 0)
        {
            ActionResult<OutputAdditionalFieldsDto> actionResult;
            try
            {
                actionResult = Ok(await ManagmentAdditionalFieldService.GetAdditionalFieldParameters(itemType, stateId, categoryId));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }
    }
}
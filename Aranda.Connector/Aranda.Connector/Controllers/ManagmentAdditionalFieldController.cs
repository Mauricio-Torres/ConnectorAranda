// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Connector.Service.Interface.IService;
using Aranda.ASDK.Data.Objects.Models.Output;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Aranda.Connector.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ManagmentAdditionalFieldController : ControllerBase
    {
        private readonly IManagmentAdditionalFieldService ManagmentAdditionalFieldService;

        public ManagmentAdditionalFieldController(IManagmentAdditionalFieldService managmentAdditionalFieldService)
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
        [HttpGet("AdvancedFields/{projectId}/{itemType}/{categoryId:int?}/{serviceId:int?}/{stateId:int?}")]
        public async Task<ActionResult<OutputAdditionalFieldsDto>> AdvancedFields(int projectId, int itemType, int categoryId = 0, int serviceId = 0, int stateId = 0)
        {
            ActionResult<OutputAdditionalFieldsDto> actionResult;
            try
            {
                actionResult = Ok(await ManagmentAdditionalFieldService.GetAdditionalField(projectId, itemType, categoryId, serviceId, stateId));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }
    }
}
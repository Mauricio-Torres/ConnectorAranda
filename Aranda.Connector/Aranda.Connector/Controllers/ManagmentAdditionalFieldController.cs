// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Connector.Api.Interface.IService;
using Aranda.Connector.Api.Models;
using Aranda.Connector.Api.Utils.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Aranda.Connector.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ManagmentAdditionalFieldController : ControllerBase
    {
        private readonly IManagmentAdditionalFieldService ManagmentAdditionalFieldService;
        private readonly ClaimsPrincipal Principal;

        public ManagmentAdditionalFieldController(IPrincipal principal, IManagmentAdditionalFieldService managmentAdditionalFieldService)
        {
            Principal = principal as ClaimsPrincipal;
            ManagmentAdditionalFieldService = managmentAdditionalFieldService;
        }

        [HttpGet("AdvancedFields/{projectId}/{itemType}/{categoryId:int?}/{serviceId:int?}/{stateId:int?}")]
        public async Task<IActionResult> AdvancedFields(int projectId, int itemType, int categoryId = 0, int serviceId = 0, int stateId = 0)
        {
            IActionResult actionResult;
            try
            {
                UserServiceDesk user = Principal.User();
                actionResult = Ok(await ManagmentAdditionalFieldService.GetAdditionalField(user, projectId, itemType, categoryId, serviceId, stateId));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }
    }
}
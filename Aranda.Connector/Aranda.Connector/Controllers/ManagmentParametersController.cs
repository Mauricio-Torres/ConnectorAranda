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
    public class ManagmentParametersController : ControllerBase
    {
        private readonly IManagmentParameters ManagmentParameters;
        private readonly ClaimsPrincipal Principal;

        public ManagmentParametersController(IPrincipal principal, IManagmentParameters managmentParameters)
        {
            ManagmentParameters = managmentParameters;
            Principal = principal as ClaimsPrincipal;
        }

        [HttpGet("Categories/{projectId}/{serviceId}")]
        public async Task<IActionResult> Categories(int projectId, int serviceId)
        {
            IActionResult actionResult;
            try
            {
                UserServiceDesk user = Principal.User();
                actionResult = Ok(await ManagmentParameters.GetCategory(user, serviceId, projectId));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        [HttpGet("Group/{serviceId}")]
        public async Task<IActionResult> Group(int serviceId)
        {
            IActionResult actionResult;
            try
            {
                UserServiceDesk user = Principal.User();
                actionResult = Ok(await ManagmentParameters.GetGroups(user, serviceId));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        [HttpGet("ItemType/{categoryId}/{projectId}")]
        public async Task<IActionResult> ItemType(int categoryId, int projectId)
        {
            IActionResult actionResult;
            try
            {
                UserServiceDesk user = Principal.User();
                actionResult = Ok(await ManagmentParameters.GetItemType(user, categoryId, projectId));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        [HttpGet("Projects")]
        public async Task<IActionResult> Projects()
        {
            IActionResult actionResult;
            try
            {
                UserServiceDesk user = Principal.User();
                actionResult = Ok(await ManagmentParameters.GetProyect(user));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        [HttpGet("RegistryType")]
        public async Task<IActionResult> RegistryType()
        {
            IActionResult actionResult;
            try
            {
                UserServiceDesk user = Principal.User();
                actionResult = Ok(await ManagmentParameters.GetRegistryType(user));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        [HttpGet("Responsible/{groupId}/{projectId}")]
        public async Task<IActionResult> Responsible(int groupId, int projectId)
        {
            IActionResult actionResult;
            try
            {
                UserServiceDesk user = Principal.User();
                actionResult = Ok(await ManagmentParameters.GetResponsible(user, groupId, projectId));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        [HttpGet("Services/{projectId}")]
        public async Task<IActionResult> Services(int projectId)
        {
            IActionResult actionResult;
            try
            {
                UserServiceDesk user = Principal.User();
                actionResult = Ok(await ManagmentParameters.GetServices(user, projectId));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        [HttpGet("SLAs/{serviceId}/{itemType}")]
        public async Task<IActionResult> SLAs(int serviceId, int itemType)
        {
            IActionResult actionResult;
            try
            {
                UserServiceDesk user = Principal.User();
                actionResult = Ok(await ManagmentParameters.GetSLAs(user, serviceId, itemType));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        [HttpGet("State/{itemType}/{projectId}")]
        public async Task<IActionResult> State(int itemType, int projectId)
        {
            IActionResult actionResult;
            try
            {
                UserServiceDesk user = Principal.User();
                actionResult = Ok(await ManagmentParameters.GetState(user, itemType, projectId));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        [HttpGet("StateWhenUpdate/{itemType}")]
        public async Task<IActionResult> StateWhenUpdate(int itemType)
        {
            IActionResult actionResult;
            try
            {
                UserServiceDesk user = Principal.User();
                actionResult = Ok(await ManagmentParameters.GetStateWhenUpdateCase(user, itemType));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        [HttpGet("Urgency")]
        public async Task<IActionResult> Urgency()
        {
            IActionResult actionResult;
            try
            {
                UserServiceDesk user = Principal.User();
                actionResult = Ok(await ManagmentParameters.GetUrgency(user));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }
    }
}
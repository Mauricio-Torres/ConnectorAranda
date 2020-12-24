// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Connector.Api.Helpers;
using Aranda.Connector.Api.Interface.IService;
using Aranda.Connector.Api.Models;
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

        [HttpGet("Categories/{projectId}")]
        public async Task<IActionResult> Categories(int projectId)
        {
            IActionResult actionResult;
            try
            {
                UserServiceDesk user = Principal.User();
                actionResult = Ok(await ManagmentParameters.GetCategory(user, projectId));
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
    }
}
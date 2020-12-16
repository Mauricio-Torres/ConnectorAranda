// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Connector.Api.Helpers;
using Aranda.Connector.Api.Interface.IService;
using Aranda.Connector.Api.Models;
using Aranda.Connector.Api.Models.Input;
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
    public class ManagmentCaseController : ControllerBase
    {
        private readonly IManagmentCaseService ManagmentService;
        private readonly ClaimsPrincipal Principal;

        public ManagmentCaseController(IPrincipal principal, IManagmentCaseService managmentCaseService)
        {
            ManagmentService = managmentCaseService;
            Principal = principal as ClaimsPrincipal;
        }

        [HttpPost("CreateCase")]
        public async Task<IActionResult> CreateCase(InputCreateCaseDto inputCreateCase)
        {
            IActionResult actionResult;
            try
            {
                UserServiceDesk user = Principal.User();
                actionResult = Ok(await ManagmentService.Create(inputCreateCase, user));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        [HttpPost("GetCase")]
        public async Task<IActionResult> GetCase(InputGetCaseDto inputGetCase)
        {
            IActionResult actionResult;
            try
            {
                UserServiceDesk user = Principal.User();
                actionResult = Ok(await ManagmentService.GetCase(inputGetCase, user));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        [HttpPost("UpdateCase")]
        public async Task<IActionResult> UpdateCase(InputUpdateCaseDto inputUpdateCase)
        {
            IActionResult actionResult;
            try
            {
                UserServiceDesk user = Principal.User();
                actionResult = Ok(await ManagmentService.Update(inputUpdateCase, user));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }
    }
}
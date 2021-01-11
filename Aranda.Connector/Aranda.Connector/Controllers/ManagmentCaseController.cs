// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Connector.Api.Interface.IService;
using Aranda.Connector.Api.Models;
using Aranda.Connector.Api.Models.Input;
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
    public class ManagmentCaseController : ControllerBase
    {
        private readonly IManagmentCaseService ManagmentService;
        private readonly ClaimsPrincipal Principal;

        public ManagmentCaseController(IPrincipal principal, IManagmentCaseService managmentCaseService)
        {
            ManagmentService = managmentCaseService;
            Principal = principal as ClaimsPrincipal;
        }

        /// <summary>
        /// Crea caso
        /// </summary>
        /// <param name="inputCreateCase"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<IActionResult> Create(InputCreateCaseDto inputCreateCase)
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

        /// <summary>
        /// Consulta información caso
        /// </summary>
        /// <param name="inputGetCase"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        public async Task<IActionResult> Get(InputGetCaseDto inputGetCase)
        {
            IActionResult actionResult;
            try
            {
                UserServiceDesk user = Principal.User();
                actionResult = Ok(await ManagmentService.Get(inputGetCase, user));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        /// <summary>
        /// Actualiza caso
        /// </summary>
        /// <param name="inputUpdateCase"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        public async Task<IActionResult> Update(InputUpdateCaseDto inputUpdateCase)
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
// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.Connector.Api.Interface.IService;
using Aranda.Connector.Api.Models.Input;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Aranda.Connector.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ManagmentCaseController : ControllerBase
    {
        private readonly IManagmentCaseService ManagmentService;

        public ManagmentCaseController(IManagmentCaseService managmentCaseService)
        {
            ManagmentService = managmentCaseService;
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
                actionResult = Ok(await ManagmentService.Create(inputCreateCase));
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
                actionResult = Ok(await ManagmentService.Get(inputGetCase));
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
                actionResult = Ok(await ManagmentService.Update(inputUpdateCase));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }
    }
}
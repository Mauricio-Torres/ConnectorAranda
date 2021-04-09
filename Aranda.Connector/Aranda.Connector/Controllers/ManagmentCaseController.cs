// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Connector.Service.Interface.IService;
using Aranda.ASDK.Data.Objects.Models.Input.ASDK_V8;
using Aranda.ASDK.Data.Objects.Models.Output.ASDK_V8;
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
        /// Crear caso en Service Desk V8
        /// </summary>
        /// <param name="inputCreateCase"></param>
        /// <returns>Información del caso</returns>
        [HttpPost("Create")]
        public async Task<ActionResult<OutputResponseCaseAsdkV8Dto>> Create(InputCreateCaseAsdkV8Dto inputCreateCase)
        {
            ActionResult<OutputResponseCaseAsdkV8Dto> actionResult;
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
        /// <returns>Información completa del caso</returns>
        [HttpPost("Get")]
        public async Task<ActionResult<OutputGetCaseAsdkV8Dto>> Get(InputGetCaseDto inputGetCase)
        {
            ActionResult<OutputGetCaseAsdkV8Dto> actionResult;
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
        /// <returns>Información del caso</returns>
        [HttpPut("Update")]
        public async Task<ActionResult<OutputResponseCaseAsdkV8Dto>> Update(InputUpdateCaseDto inputUpdateCase)
        {
            ActionResult<OutputResponseCaseAsdkV8Dto> actionResult;
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
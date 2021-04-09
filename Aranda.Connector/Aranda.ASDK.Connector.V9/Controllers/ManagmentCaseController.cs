// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Connector.Service.Interface.ASDK_V9;
using Aranda.ASDK.Data.Objects.Models.Input.ASDK_V9;
using Aranda.ASDK.Data.Objects.Models.Output.ASDK_V9;
using Aranda.ASDK.Data.Objects.Models.ResponseApi.ASDK_V9;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Aranda.ASDK.Connector.V9.Controllers
{
    [Authorize]
    [Route("api/asdkv9/managmentCase")]
    [ApiController]
    public class ManagmentCaseController : ControllerBase
    {
        private readonly IManagmentCaseV9Service ManagmentService;

        public ManagmentCaseController(IManagmentCaseV9Service managmentCaseService)
        {
            ManagmentService = managmentCaseService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<AnswerCreateCaseApi>> Create(InputCreateCaseAsdkV9Dto inputCreateCaseAsdkV9Dto)
        {
            ActionResult<AnswerCreateCaseApi> actionResult;
            try
            {
                actionResult = Ok(await ManagmentService.Create(inputCreateCaseAsdkV9Dto));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        [HttpGet("get/{idCase}")]
        public async Task<ActionResult<OutputGetCaseAsdkV9Dto>> Get(int idCase)
        {
            ActionResult<OutputGetCaseAsdkV9Dto> actionResult;
            try
            {
                actionResult = Ok(await ManagmentService.GetCase(idCase));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }
    }
}
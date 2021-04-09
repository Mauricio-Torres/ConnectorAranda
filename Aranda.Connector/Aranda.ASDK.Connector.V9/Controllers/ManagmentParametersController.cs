// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Connector.Service.Interface.ASDK_V9;
using Aranda.ASDK.Data.Objects.Models.ResponseApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Aranda.ASDK.Connector.V9.Controllers
{
    [Authorize]
    [Route("api/asdkv9/parameters")]
    [ApiController]
    public class ManagmentParametersController : ControllerBase
    {
        private readonly IManagmentParametersV9Service ManagmentParameters;

        public ManagmentParametersController(IManagmentParametersV9Service managmentParameters)
        {
            ManagmentParameters = managmentParameters;
        }

        [HttpGet("categories/{itemType:int?}/{serviceId:int?}")]
        public async Task<ActionResult<OutputParametersDto>> Categories(int itemType, int serviceId = 0)
        {
            ActionResult<OutputParametersDto> actionResult;
            try
            {
                actionResult = Ok(await ManagmentParameters.GetCategoryByService(itemType, serviceId));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        [HttpGet("cis/{projectId:int}/{itemType:int}/{serviceId:int}")]
        public async Task<ActionResult<OutputParametersDto>> CIs(int projectId, int itemType, int serviceId)
        {
            ActionResult<OutputParametersDto> actionResult;
            try
            {
                actionResult = Ok(await ManagmentParameters.GetCIs(projectId, itemType, serviceId));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        [HttpGet("companies/{itemType:int}/{projectId:int}/{serviceId:int?}")]
        public async Task<ActionResult<OutputParametersDto>> Companies(int itemType, int projectId, int? clientId = null, int? serviceId = null)
        {
            ActionResult<OutputParametersDto> actionResult;
            try
            {
                actionResult = Ok(await ManagmentParameters.GetCompanies(itemType, projectId, clientId, serviceId));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        // Solicitante
        [HttpGet("customers/{itemType:int?}/{projectId:int?}/{serviceId:int?}")]
        public async Task<ActionResult<OutputParametersDto>> Customer(int itemType = 0, int projectId = 0, int? companyId = null, int? serviceId = null)
        {
            ActionResult<OutputParametersDto> actionResult;
            try
            {
                actionResult = Ok(await ManagmentParameters.GetCustomers(itemType, projectId, companyId, serviceId));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        [HttpGet("groupsByState/{stateId:int?}/{serviceId:int?}")]
        public async Task<ActionResult<OutputParametersDto>> Groups(int stateId, int serviceId)
        {
            ActionResult<OutputParametersDto> actionResult;
            try
            {
                actionResult = Ok(await ManagmentParameters.GetGroupsByState(stateId, serviceId));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        [HttpGet("impact")]
        public async Task<ActionResult<OutputParametersDto>> Impact()
        {
            ActionResult<OutputParametersDto> actionResult;
            try
            {
                actionResult = Ok(await ManagmentParameters.GetImpact());
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        [HttpGet("itemType")]
        public async Task<ActionResult<OutputParametersDto>> ItemType()
        {
            ActionResult<OutputParametersDto> actionResult;
            try
            {
                actionResult = Ok(await ManagmentParameters.GetAllItemType());
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        [HttpGet("levelOperative/{unitId:int}/{serviceId:int}")]
        public async Task<ActionResult<OutputParametersDto>> LevelOperative(int unitId, int serviceId)
        {
            ActionResult<OutputParametersDto> actionResult;
            try
            {
                actionResult = Ok(await ManagmentParameters.GetOla(unitId, serviceId));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        [HttpGet("priority")]
        public async Task<ActionResult<OutputParametersDto>> Priority()
        {
            ActionResult<OutputParametersDto> actionResult;
            try
            {
                actionResult = Ok(await ManagmentParameters.GetPriority());
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        /// <summary>
        /// Proyectos del usuario de Service Desk v9
        /// </summary>
        /// <returns></returns>
        [HttpGet("projects")]
        public async Task<ActionResult<OutputParametersDto>> Projects()
        {
            ActionResult<OutputParametersDto> actionResult;
            try
            {
                actionResult = Ok(await ManagmentParameters.GetProject());
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        [HttpGet("providers/{projectId:int}/{serviceId:int}")]
        public async Task<ActionResult<OutputParametersDto>> Providers(int projectId, int serviceId)
        {
            ActionResult<OutputParametersDto> actionResult;
            try
            {
                actionResult = Ok(await ManagmentParameters.GetProviders(projectId, serviceId));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        [HttpGet("reasonsBySatate/{stateId:int}")]
        public async Task<ActionResult<OutputParametersDto>> ReasonsBySatate(int stateId)
        {
            ActionResult<OutputParametersDto> actionResult;
            try
            {
                actionResult = Ok(await ManagmentParameters.GetReasonsForState(stateId));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        [HttpGet("registryType")]
        public async Task<ActionResult<OutputParametersDto>> RegistryType()
        {
            ActionResult<OutputParametersDto> actionResult;
            try
            {
                actionResult = Ok(await ManagmentParameters.GetRegistryType());
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        [HttpGet("responsible/{projectId:int?}/{groupId:int?}")]
        public async Task<ActionResult<OutputParametersDto>> Responsible(int projectId, int groupId)
        {
            ActionResult<OutputParametersDto> actionResult;
            try
            {
                actionResult = Ok(await ManagmentParameters.GetResponsible(groupId, projectId));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        [HttpGet("services/{projectId:int?}")]
        public async Task<ActionResult<OutputParametersDto>> Services(int projectId)
        {
            ActionResult<OutputParametersDto> actionResult;
            try
            {
                actionResult = Ok(await ManagmentParameters.GetServices(projectId));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        [HttpGet("sla/{itemType:int}/{serviceId:int}")]
        public async Task<ActionResult<OutputParametersDto>> SLA(int itemType, int serviceId)
        {
            ActionResult<OutputParametersDto> actionResult;
            try
            {
                actionResult = Ok(await ManagmentParameters.GetSLA(serviceId, itemType));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        [HttpGet("states/{itemType:int}/{categoryId:int}")]
        public async Task<ActionResult<OutputParametersDto>> States(int itemType, int categoryId)
        {
            ActionResult<OutputParametersDto> actionResult;
            try
            {
                actionResult = Ok(await ManagmentParameters.GetState(itemType, categoryId));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        [HttpGet("uc/{providersId:int}/{serviceId:int}")]
        public async Task<ActionResult<OutputParametersDto>> Uc(int providersId, int serviceId)
        {
            ActionResult<OutputParametersDto> actionResult;
            try
            {
                actionResult = Ok(await ManagmentParameters.GetUc(providersId, serviceId));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        [HttpGet("units/{projectId:int}/{serviceId:int}")]
        public async Task<ActionResult<OutputParametersDto>> Units(int projectId, int serviceId)
        {
            ActionResult<OutputParametersDto> actionResult;
            try
            {
                actionResult = Ok(await ManagmentParameters.GetUnits(projectId, serviceId));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        [HttpGet("urgency")]
        public async Task<ActionResult<OutputParametersDto>> Urgency()
        {
            ActionResult<OutputParametersDto> actionResult;
            try
            {
                actionResult = Ok(await ManagmentParameters.GetUrgency());
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }
    }
}
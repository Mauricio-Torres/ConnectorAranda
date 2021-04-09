// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>
using Aranda.ASDK.Connector.Service.Interface.IService;
using Aranda.ASDK.Data.Objects.Models.ResponseApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Aranda.Connector.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ManagmentParametersController : ControllerBase
    {
        private readonly IManagmentParameters ManagmentParameters;

        public ManagmentParametersController(IManagmentParameters managmentParameters)
        {
            ManagmentParameters = managmentParameters;
        }

        /// <summary>
        /// Tipo de caso
        /// </summary>
        /// <returns>tipos de caso</returns>
        [HttpGet("AllItemType")]
        public ActionResult<OutputParametersDto> AllItemType()
        {
            ActionResult<OutputParametersDto> actionResult;
            try
            {
                actionResult = Ok(ManagmentParameters.GetAllItemType());
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        /// <summary>
        /// Categorías asociadas al proyecto y servicio
        /// </summary>
        /// <param name="projectId">Id de proyecto</param>
        /// <param name="serviceId">Id de servicio</param>
        /// <returns></returns>
        [HttpGet("Categories/{projectId:int?}/{serviceId:int?}")]
        public async Task<ActionResult<OutputParametersDto>> Categories(int projectId = 0, int serviceId = 0)
        {
            ActionResult<OutputParametersDto> actionResult;
            try
            {
                actionResult = Ok(await ManagmentParameters.GetCategory(serviceId, projectId));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        /// <summary>
        /// Grupos asociados al servicio
        /// </summary>
        /// <param name="serviceId">Id del servicio</param>
        /// <returns></returns>
        [HttpGet("Group/{serviceId:int?}")]
        public async Task<ActionResult<OutputParametersDto>> Group(int serviceId = 0)
        {
            ActionResult<OutputParametersDto> actionResult;
            try
            {
                actionResult = Ok(await ManagmentParameters.GetGroups(serviceId));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        /// <summary>
        /// Tipo de caso según el proyecto seleccionado y su categoría
        /// </summary>
        /// <param name="categoryId">Id de categoría</param>
        /// <param name="projectId">Id del proyecto</param>
        /// <returns></returns>
        [HttpGet("ItemType/{categoryId:int?}/{projectId:int?}")]
        public async Task<ActionResult<OutputParametersDto>> ItemType(int categoryId = 0, int projectId = 0)
        {
            ActionResult<OutputParametersDto> actionResult;
            try
            {
                actionResult = Ok(await ManagmentParameters.GetItemType(categoryId, projectId));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        /// <summary>
        /// Nivel de detalle con la que se extrae información del caso
        /// </summary>
        /// <returns></returns>
        [HttpGet("LevelDetail")]
        public ActionResult<OutputParametersDto> LevelDetail()
        {
            ActionResult<OutputParametersDto> actionResult;
            try
            {
                actionResult = Ok(ManagmentParameters.GetLevelDetail());
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        /// <summary>
        /// Proyectos del usuario de Service Desk v8
        /// </summary>
        /// <returns></returns>
        [HttpGet("Projects")]
        public async Task<ActionResult<OutputParametersDto>> Projects()
        {
            ActionResult<OutputParametersDto> actionResult;
            try
            {
                actionResult = Ok(await ManagmentParameters.GetProyect());
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        /// <summary>
        /// Tipo de registro de caso
        /// </summary>
        /// <returns></returns>
        [HttpGet("RegistryType")]
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

        /// <summary>
        /// Especialista del caso
        /// </summary>
        /// <param name="groupId">Id de grupo</param>
        /// <param name="projectId">Id proyecto</param>
        /// <returns></returns>
        [HttpGet("Responsible/{groupId:int?}/{projectId:int?}")]
        public async Task<ActionResult<OutputParametersDto>> Responsible(int groupId = 0, int projectId = 0)
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

        /// <summary>
        /// Servicios relacionados al proyecto
        /// </summary>
        /// <param name="projectId">Id del proyecto</param>
        /// <returns></returns>
        [HttpGet("Services/{projectId:int?}")]
        public async Task<ActionResult<OutputParametersDto>> Services(int projectId = 0)
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="itemType"></param>
        /// <returns></returns>
        [HttpGet("SLAs/{serviceId:int?}/{itemType:int?}")]
        public async Task<ActionResult<OutputParametersDto>> SLAs(int serviceId = 0, int itemType = 0)
        {
            ActionResult<OutputParametersDto> actionResult;
            try
            {
                actionResult = Ok(await ManagmentParameters.GetSLAs(serviceId, itemType));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        /// <summary>
        /// Estado del caso a crear relacionado al proyecto y tipo de caso
        /// </summary>
        /// <param name="itemType">id tipo de caso</param>
        /// <param name="projectId">id proyecto</param>
        /// <returns></returns>
        [HttpGet("State/{itemType:int?}/{projectId:int?}")]
        public async Task<ActionResult<OutputParametersDto>> State(int itemType = 0, int projectId = 0)
        {
            ActionResult<OutputParametersDto> actionResult;
            try
            {
                actionResult = Ok(await ManagmentParameters.GetState(itemType, projectId));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        /// <summary>
        /// Estados usados cuando se actualiza un caso
        /// </summary>
        /// <param name="itemType">id tipo de caso</param>
        /// <returns></returns>
        [HttpGet("StateWhenUpdate/{itemType:int?}")]
        public async Task<ActionResult<OutputParametersDto>> StateWhenUpdate(int itemType = 0)
        {
            ActionResult<OutputParametersDto> actionResult;
            try
            {
                actionResult = Ok(await ManagmentParameters.GetStateWhenUpdateCase(itemType));
            }
            catch (Exception ex)
            {
                actionResult = NotFound(ex.Message);
            }

            return actionResult;
        }

        /// <summary>
        /// Urgencia del caso
        /// </summary>
        /// <returns></returns>
        [HttpGet("Urgency")]
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
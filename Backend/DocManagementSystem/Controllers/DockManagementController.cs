using Azure.Core;
using DocManagementSystem.Comman;
using DocManagementSystem.DTOModel.DockManagement;
using DocManagementSystem.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;

namespace DocManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DockManagementController : ControllerBase
    {
        private readonly IDockManagementRepository _dockManagementRepository;

        public DockManagementController(IDockManagementRepository dockManagementRepository)
        {
            _dockManagementRepository = dockManagementRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReturnResponse>>> GetDocks()
        {
            var result = await _dockManagementRepository.GetDocks();
            return Ok(new ReturnResponse(StatusCodes.Status200OK, "Get successfully docks.", result));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnResponse>> GetDock(int id)
        {
            var dock = await _dockManagementRepository.GetDock(id);

            if (dock == null)
            {
                return NotFound($"Dock ID {id} not found.");
            }
            return Ok(new ReturnResponse(StatusCodes.Status200OK, "Get dock successfully.", dock));
        }

        [HttpPost]
        public async Task<ActionResult<ReturnResponse>> CreateDock([FromBody] CreateDockRequestDTO request)
        {
            if (request == null)
            {
                return BadRequest("Invalid dock data.");
            }

            var result = await _dockManagementRepository.CreateDock(request);
            return Ok(new ReturnResponse(StatusCodes.Status201Created, "Dock created successfully.", result));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ReturnResponse>> EditDock(int id, [FromBody] EditDockRequestDTO request)
        {
            if (request == null)
            {
                return BadRequest("Invalid dock data.");
            }

            var result = await _dockManagementRepository.EditDock(id, request);
            if (result == 0)
            {
                return NotFound($"Dock ID {id} not found");
            }

            return Ok(new ReturnResponse(StatusCodes.Status200OK, "Dock updated successfully.", result));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ReturnResponse>> DeleteDock(int id)
        {
            var result = await _dockManagementRepository.DeleteDock(id);
            if (result == 0)
            {
                return NotFound($"Dock ID {id} not found.");
            }

            return Ok(new ReturnResponse(StatusCodes.Status200OK, "Dock deleted successfully.", result));
        }

        [HttpPut("ChangeIsActive/{id}")]
        public async Task<ActionResult<ReturnResponse>> ChangeIsActive(int id,[FromQuery] bool isActive)
        {
           
            var result = await _dockManagementRepository.ChangeIsActive(id, isActive);
            if (result == 0)
            {
                return NotFound($"Dock ID {id} not found");
            }

            return Ok(new ReturnResponse(StatusCodes.Status200OK, "Update active successfully.", result));

        }
    }
}

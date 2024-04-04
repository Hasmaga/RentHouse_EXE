using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentHouse_EXE.Enum;
using RentHouse_EXE.Model;
using RentHouse_EXE.Model.Dto.Status;
using RentHouse_EXE.Service.Interface;

namespace RentHouse_EXE.Controllers
{
    [Route("statusapi")]
    [ApiController]
    public class StatusController : Controller
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusRepository)
        {
            _statusService = statusRepository;
        }

        // POST: statusapi/createstatus
        [Authorize]
        [HttpPost("createstatus")]
        public async Task<IActionResult> CreateStatus([FromBody] CreateStatus newStatus)
        {
            try
            {
                // Check valid dto CreateStatus
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                newStatus.StatusName = newStatus.StatusName.Trim();
                if (string.IsNullOrWhiteSpace(newStatus.StatusName))
                {
                    return BadRequest("StatusName is required.");
                }             
                var result = await _statusService.CreateStatusService(newStatus);
                if (result)
                {
                    return StatusCode(200, "Create status successfully!");
                }
                return StatusCode(500, "Create status failed!");
            } catch (Exception e)
            {
                if (e.Message == StatusErrorEnum.CREATE_STATUS_ERROR)
                {
                    return StatusCode(500, "Create status failed!");
                } else 
                if (e.Message == StatusErrorEnum.STATUS_EXIST)
                {
                    return StatusCode(400, "Status is exist!");
                } else
                {
                    return StatusCode(500, "Server Error");
                }
            }
        }

        // GET: statusapi/getstatusbyid/{id}
        [Authorize]
        [HttpGet("getstatusbyid/{id}")]
        public async Task<IActionResult> GetStatusById(Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (id == Guid.Empty)
                {
                    return BadRequest("Id is required.");
                }
                var result = await _statusService.GetStatusByIdService(id);
                if (result == null)
                {
                    return StatusCode(200, result);
                }
                else
                {
                    return StatusCode(404, "Status not found!");
                }                
            } catch (Exception e)
            {
                if (e.Message == StatusErrorEnum.STATUS_NOT_FOUND)
                {
                    return StatusCode(404, "Status not found!");
                } else
                {
                    return StatusCode(500, "Server Error");
                }
            }
        }

        // GET: statusapi/getallstatus
        [Authorize]
        [HttpGet("getallstatus")]
        public async Task<IActionResult> GetAllStatus()
        {
            try
            {
                var result = await _statusService.GetAllStatusService();
                if (result != null)
                {
                    return StatusCode(200, result);
                }
                return StatusCode(404, "Status list is empty");
            } catch (Exception e)
            {
                if (e.Message == StatusErrorEnum.LIST_STATUS_EMPTY)
                {
                    return StatusCode(404, "Status list is empty");
                } else
                {
                    return StatusCode(500, "Server Error");
                }
            }
        }

        // PUT: statusapi/updatestatus
        [Authorize]
        [HttpPut("updatestatus")]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdateStatus status)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                status.StatusName = status.StatusName.Trim().ToUpper();
                if (string.IsNullOrWhiteSpace(status.StatusName))
                {
                    return BadRequest("StatusName is required.");
                }
                var result = await _statusService.UpdateStatusService(status);
                if (result)
                {
                    return StatusCode(200, "Update status successfully!");
                } else
                {
                    return StatusCode(500, "Update status failed!");
                }                
            } catch (Exception e)
            {
                if (e.Message == StatusErrorEnum.UPDATE_STATUS_ERROR)
                {
                    return StatusCode(500, "Update status failed!");
                } else 
                if (e.Message == StatusErrorEnum.STATUS_NOT_FOUND)
                {
                    return StatusCode(404, "Status not found!");
                } else
                {
                    return StatusCode(500, "Server Error");
                }
            }
        }
    }
}

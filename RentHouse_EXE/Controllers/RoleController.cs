using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RentHouse_EXE.Enum;
using RentHouse_EXE.Model.Dto.Role;
using RentHouse_EXE.Model.Dto.Status;
using RentHouse_EXE.Service.Interface;

namespace RentHouse_EXE.Controllers
{
    [Route("roleapi")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleRepository)
        {
            _roleService = roleRepository;
        }

        // POST: roleapi/createrole
        [Authorize]
        [HttpPost("createrole")]
        public async Task<IActionResult> CreateRole([FromBody] CreateStatus role)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, "Invalid data!");
                }
                role.StatusName = role.StatusName.Trim();
                if (role.StatusName.IsNullOrEmpty())
                {
                    return StatusCode(400, "Status name is required!");
                }
                var result = await _roleService.CreateRoleService(role);
                if (result)
                {
                    return StatusCode(200, "Create role successfully!");
                }
                return StatusCode(500, "Create role failed!");
            } catch (Exception e)
            {
                if (e.Message.Equals(RoleErrorEnum.ROLE_IS_EXIST))
                {
                    return StatusCode(400, "Role is exist!");
                } else 
                if (e.Message.Equals(RoleErrorEnum.CREATE_ROLE_FAILED))
                {
                    return StatusCode(500, "Create role failed!");
                } else
                {
                    return StatusCode(500, "Server Error");
                }
            }
        }

        // GET: roleapi/getrolebyid/{id}
        [Authorize]
        [HttpGet("getrolebyid/{id}")]
        public async Task<IActionResult> GetRoleById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return StatusCode(400, "Invalid id!");
                }
                var result = await _roleService.GetRoleByIdService(id);
                if (result != null)
                {
                    return StatusCode(200, result);
                }
                return StatusCode(404, "Role not found!");
            } catch (Exception e)
            {
                if (e.Message.Equals(RoleErrorEnum.ROLE_NOT_FOUND))
                {
                    return StatusCode(404, "Role not found!");
                } else
                {
                    return StatusCode(500, "Server Error");
                }
            }
        }

        // GET: roleapi/getallrole
        [Authorize]
        [HttpGet("getallrole")]
        public async Task<IActionResult> GetAllRole()
        {
            try
            {
                var result = await _roleService.GetAllRoleService();
                if (result != null)
                {
                    return StatusCode(200, result);
                }
                return StatusCode(404, "List role is empty");
            } catch (Exception e)
            {
                if (e.Message.Equals(RoleErrorEnum.LIST_ROLE_EMPTY))
                {
                    return StatusCode(404, "List role is empty");
                } else
                {
                    return StatusCode(500, "Server Error");
                }
            }
        }

        // PUT: roleapi/updaterole
        [Authorize]
        [HttpPut("updaterole")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRole role)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, "Invalid data!");
                }
                if (role.RoleId == Guid.Empty)
                {
                    return StatusCode(400, "Invalid id!");
                }
                role.RoleName = role.RoleName.Trim().ToUpper();
                if (role.RoleName.IsNullOrEmpty())
                {
                    return StatusCode(400, "Role name is required!");
                }
                var result = await _roleService.UpdateRoleService(role);
                if (result)
                {
                    return StatusCode(200, "Update role successfully!");
                }
                return StatusCode(500, "Update role failed!");
            } catch (Exception e)
            {
                if (e.Message.Equals(RoleErrorEnum.ROLE_NOT_FOUND))
                {
                    return StatusCode(404, "Role not found!");
                } else
                if (e.Message.Equals(RoleErrorEnum.UPDATE_ROLE_FAILED))
                {
                    return StatusCode(500, "Update role failed!");
                } else
                {
                    return StatusCode(500, "Server Error");
                }                   
            }
        }
    }
}

using RentHouse_EXE.Enum;
using RentHouse_EXE.Model;
using RentHouse_EXE.Model.Dto.Role;
using RentHouse_EXE.Model.Dto.Status;
using RentHouse_EXE.Repository.Interface;
using RentHouse_EXE.Service.Interface;
using System.Security.Claims;

namespace RentHouse_EXE.Service
{
    public class RoleService(IRoleRepository roleRepository, IAccountService accountService, IHelperService helperService) : IRoleService
    {
        private readonly IRoleRepository _roleRepository = roleRepository;        
        private readonly IAccountService _accountService = accountService;
        private readonly IHelperService _helperService = helperService;

        public async Task<bool> CreateRoleService(CreateStatus role)
        {
            try
            {
                if (!_helperService.IsTokenValid())
                {
                    throw new Exception(AuthEnum.NOT_AUTHENTICATED);
                }
                var accLogged = await _accountService.GetAccountByIdService(_helperService.GetAccIdFromLogged()) ?? throw new Exception(AuthEnum.NOT_AUTHENTICATED);
                var roleAdmin = await _roleRepository.GetRoleByNameRepository("ADMIN");
                if (roleAdmin == null)
                {
                    throw new Exception(ServerErrorEnum.SERVER_ERROR);
                } else if (accLogged.RoleId == roleAdmin.Id)
                {
                    var isExist = await _roleRepository.GetRoleByNameRepository(role.StatusName);
                    if (isExist != null)
                    {
                        throw new Exception(RoleErrorEnum.ROLE_IS_EXIST);
                    }
                    else
                    {
                        Role newRole = new()
                        {
                            RoleName = role.StatusName.ToUpper(),
                            CreateDateTime = DateTime.Now
                        };
                        if (await _roleRepository.CreateRoleRepository(newRole))
                        {
                            return true;
                        }
                        else
                        {
                            throw new Exception(RoleErrorEnum.CREATE_ROLE_FAILED);
                        }
                    }
                }
                else
                {
                    throw new Exception(AuthEnum.NOT_AUTHORIZED);
                }                
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Role>?> GetAllRoleService()
        {
            try
            {
                if (!_helperService.IsTokenValid())
                {
                    throw new Exception(AuthEnum.NOT_AUTHENTICATED);
                }
                var accLogged = await _accountService.GetAccountByIdService(_helperService.GetAccIdFromLogged()) ?? throw new Exception(AuthEnum.NOT_AUTHENTICATED);
                var roleAdmin = await _roleRepository.GetRoleByNameRepository("ADMIN");
                if (roleAdmin == null)
                {
                    throw new Exception(ServerErrorEnum.SERVER_ERROR);
                }
                else if (accLogged.RoleId == roleAdmin.Id)
                {
                    if ((await _roleRepository.GetAllRoleRepository())?.Count == 0)
                    {
                        throw new Exception(RoleErrorEnum.LIST_ROLE_EMPTY);
                    }
                    else
                    {
                        return await _roleRepository.GetAllRoleRepository();
                    }
                } else
                {
                    throw new Exception(AuthEnum.NOT_AUTHORIZED);
                }
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<Role?> GetRoleByIdService(Guid id)
        {
            try
            {
                if (!_helperService.IsTokenValid())
                {
                    throw new Exception(AuthEnum.NOT_AUTHENTICATED);
                }
                var accLogged = await _accountService.GetAccountByIdService(_helperService.GetAccIdFromLogged()) ?? throw new Exception(AuthEnum.NOT_AUTHENTICATED);
                var roleAdmin = await _roleRepository.GetRoleByNameRepository("ADMIN");
                if (roleAdmin == null)
                {
                    throw new Exception(ServerErrorEnum.SERVER_ERROR);
                }
                else if (accLogged.RoleId == roleAdmin.Id)
                {
                    var result = await _roleRepository.GetRoleByIdRepository(id);
                    if (result == null)
                    {
                        throw new Exception(RoleErrorEnum.ROLE_NOT_FOUND);
                    } else
                    {
                        return result;
                    }
                }
                else
                {
                    throw new Exception(AuthEnum.NOT_AUTHORIZED);
                }
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateRoleService(UpdateRole role)
        {
            try
            {
                if(!_helperService.IsTokenValid())
                {
                    throw new Exception(AuthEnum.NOT_AUTHENTICATED);
                }
                var accLogged = await _accountService.GetAccountByIdService(_helperService.GetAccIdFromLogged()) ?? throw new Exception(AuthEnum.NOT_AUTHENTICATED);
                var roleAdmin = await _roleRepository.GetRoleByNameRepository("ADMIN");
                if (roleAdmin == null)
                {
                    throw new Exception(ServerErrorEnum.SERVER_ERROR);
                }
                else if (accLogged.RoleId == roleAdmin.Id)
                {
                    var oldRole = await _roleRepository.GetRoleByIdRepository(role.RoleId);
                    if (oldRole != null)
                    {
                        oldRole.RoleName = role.RoleName;
                        oldRole.UpdateDateTime = DateTime.Now;
                        if (await _roleRepository.UpdateRoleRepository(oldRole))
                        {
                            return true;
                        } else
                        {
                            throw new Exception(RoleErrorEnum.UPDATE_ROLE_FAILED);
                        }                    
                    } else
                    {
                        throw new Exception(RoleErrorEnum.ROLE_NOT_FOUND);
                    }
                }
                else
                {
                    throw new Exception(AuthEnum.NOT_AUTHORIZED);
                }
            } catch (Exception)
            {
                throw;
            }
        }
    }
}

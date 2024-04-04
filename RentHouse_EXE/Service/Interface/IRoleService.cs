using RentHouse_EXE.Model;
using RentHouse_EXE.Model.Dto.Role;
using RentHouse_EXE.Model.Dto.Status;

namespace RentHouse_EXE.Service.Interface
{
    public interface IRoleService
    {
        Task<bool> CreateRoleService(CreateStatus newRole);
        Task<List<Role>?> GetAllRoleService();
        Task<Role?> GetRoleByIdService(Guid id);
        Task<bool> UpdateRoleService(UpdateRole role);        
    }
}

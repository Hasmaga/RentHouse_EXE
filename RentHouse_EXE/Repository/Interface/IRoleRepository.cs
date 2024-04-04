using RentHouse_EXE.Model;

namespace RentHouse_EXE.Repository.Interface
{
    public interface IRoleRepository
    {
        Task<bool> CreateRoleRepository(Role role);
        Task<List<Role>?> GetAllRoleRepository();
        Task<Role?> GetRoleByIdRepository(Guid id);
        Task<bool> UpdateRoleRepository(Role role);
        Task<Role?> GetRoleByNameRepository (string roleName);
    }
}

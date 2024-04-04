using RentHouse_EXE.Model;

namespace RentHouse_EXE.Repository.Interface
{
    public interface IStatusRepository
    {
        Task<bool> CreateStatusRepository(Status status);
        Task<List<Status>?> GetAllStatusRepository();
        Task<Status?> GetStatusByIdRepository(Guid id);
        Task<bool> UpdateStatusRepository(Status status);
        Task<Status?> GetStatusByNameRepository (string statusName);
    }
}

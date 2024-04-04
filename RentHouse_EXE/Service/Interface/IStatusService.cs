using RentHouse_EXE.Model;
using RentHouse_EXE.Model.Dto.Status;

namespace RentHouse_EXE.Service.Interface
{
    public interface IStatusService
    {
        Task<bool> CreateStatusService(CreateStatus newStatus);
        Task<List<Status>?> GetAllStatusService();
        Task<Status?> GetStatusByIdService(Guid id);
        Task<bool> UpdateStatusService(UpdateStatus updateStatus);
    }
}

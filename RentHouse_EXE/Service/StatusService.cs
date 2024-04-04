using RentHouse_EXE.Enum;
using RentHouse_EXE.Model;
using RentHouse_EXE.Model.Dto.Status;
using RentHouse_EXE.Repository.Interface;
using RentHouse_EXE.Service.Interface;

namespace RentHouse_EXE.Service
{
    public class StatusService(IStatusRepository statusRepository) : IStatusService
    {
        private readonly IStatusRepository _statusRepository = statusRepository;

        public async Task<bool> CreateStatusService(CreateStatus newStatus)
        {
            try
            {                
                // Check status is exist
                var statusExist = await _statusRepository.GetStatusByNameRepository(newStatus.StatusName);
                if (statusExist != null)
                {
                    throw new Exception(StatusErrorEnum.STATUS_EXIST);
                }
                else
                {
                    Status status = new()
                    {
                        StatusName = newStatus.StatusName.ToUpper()
                    };
                    if (await _statusRepository.CreateStatusRepository(status))
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception(StatusErrorEnum.CREATE_STATUS_ERROR);
                    }
                }                
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Status>?> GetAllStatusService()
        {
            try
            {
                var listStatus = await _statusRepository.GetAllStatusRepository();
                if (listStatus != null)
                {
                    return listStatus;
                } else
                {
                    throw new Exception(StatusErrorEnum.LIST_STATUS_EMPTY);
                }
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<Status?> GetStatusByIdService(Guid id)
        {
            try
            {                
                var status = await _statusRepository.GetStatusByIdRepository(id);
                if (status != null)
                {
                    return status;
                } else
                {
                    throw new Exception(StatusErrorEnum.STATUS_NOT_FOUND);
                }
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateStatusService(UpdateStatus updateStatus)
        {
            try
            {
                var oldStatus = await _statusRepository.GetStatusByIdRepository(updateStatus.Id);
                if (oldStatus != null)
                {
                    oldStatus.StatusName = updateStatus.StatusName;
                    oldStatus.UpdateDateTime = DateTime.Now;
                    await _statusRepository.UpdateStatusRepository(oldStatus);
                    return true;
                } else
                {
                    throw new Exception(StatusErrorEnum.STATUS_NOT_FOUND);
                }
                throw new Exception(StatusErrorEnum.UPDATE_STATUS_ERROR);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

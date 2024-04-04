using RentHouse_EXE.Model;
using RentHouse_EXE.Model.ReqDto;
using RentHouse_EXE.Model.ResDto;
using RentHouse_EXE.Repository.Interface;
using RentHouse_EXE.Service.Interface;

namespace RentHouse_EXE.Service
{
    public class FurnitureService : IFurnitureService
    {
        private readonly IFurnitureRepository _furnitureRepository;

        public FurnitureService(IFurnitureRepository furnitureRepository)
        {
            _furnitureRepository = furnitureRepository;
        }

        public async Task<bool> CreateFurnitureAsync(CreateFurnitureReqDto createFurnitureReqDto)
        {
            try
            {
                var furniture = new Furniture
                {
                    Name = createFurnitureReqDto.Name
                };
                return await _furnitureRepository.CreateFurnitureAsync(furniture);
            } 
            catch (Exception)
            {
                return false;
            }
            
        }

        public async Task<List<FurnitureResDto>> GetAllListFurnitureAsync()
        {
            try
            {
                var furnitures = await _furnitureRepository.GetAllListFurnitureAsync();
                return furnitures.Select(furniture => new FurnitureResDto
                {
                    FurnitureId = furniture.Id,
                    Name = furniture.Name
                }).ToList();
            } 
            catch (Exception)
            {
                throw;
            }
           
        }
    }
}

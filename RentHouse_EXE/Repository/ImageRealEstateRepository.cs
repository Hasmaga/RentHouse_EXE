using Microsoft.EntityFrameworkCore;
using RentHouse_EXE.Model;
using RentHouse_EXE.RentHouseDatabaseContext;
using RentHouse_EXE.Repository.Interface;

namespace RentHouse_EXE.Repository
{
    public class ImageRealEstateRepository : IImageRealEstateRepository
    {
        private readonly RentHouseDbContext _db;

        public ImageRealEstateRepository(RentHouseDbContext db)
        {
            _db = db;
        }

        public async Task<List<byte[]>?> GetAllImageRealEstateAsync(Guid realEstateId)
        {
            try
            {
                return await _db.ImageRealEstates.Where(x => x.PostRealEstateId == realEstateId).Select(x => x.Image).ToListAsync();
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<byte[]?> GetTheFirstImageRealEstateAsync(Guid realEstateId)
        {
            try
            {
                var image = await _db.ImageRealEstates.FirstOrDefaultAsync(x => x.PostRealEstateId == realEstateId);
                if (image == null)
                {
                    return null;
                }
                return image.Image;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UploadImageRealEstateAsync(ImageRealEstate imageRealEstate)
        {
            try
            {
                await _db.ImageRealEstates.AddAsync(imageRealEstate);
                await _db.SaveChangesAsync();
                return true;
            } catch (Exception)
            {
                throw;
            }
        }
        
    }
}

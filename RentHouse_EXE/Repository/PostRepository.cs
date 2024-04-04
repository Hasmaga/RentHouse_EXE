using Microsoft.EntityFrameworkCore;
using RentHouse_EXE.Model;
using RentHouse_EXE.RentHouseDatabaseContext;
using RentHouse_EXE.Repository.Interface;

namespace RentHouse_EXE.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly RentHouseDbContext _db;

        public PostRepository(RentHouseDbContext db)
        {
            _db = db;
        }

        // Create Post
        public async Task<Guid> CreatePostAsync(PostRealEstate post)
        {
            try
            {
                await _db.PostRealEstates.AddAsync(post);
                await _db.SaveChangesAsync();
                return post.Id;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PostRealEstate>> GetAllPostsAsync()
        {
            try
            {
                return await _db.PostRealEstates.ToListAsync();
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PostRealEstate>> GetListPostsByCustomerPostId(Guid customerPostId)
        {
            try
            {
                return await _db.PostRealEstates.Where(x => x.CustomerPostId == customerPostId).ToListAsync();
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<PostRealEstate?> GetPostByIdAsync(Guid id)
        {
            try
            {
                return await _db.PostRealEstates.FindAsync(id);
            } catch (Exception)
            {
                throw;
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using RentHouse_EXE.Model;
using RentHouse_EXE.RentHouseDatabaseContext;
using RentHouse_EXE.Repository.Interface;

namespace RentHouse_EXE.Repository
{
    public class CommentRealEstateRepository : ICommentRealEstateRepository
    {
        private readonly RentHouseDbContext _context;

        public CommentRealEstateRepository(RentHouseDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateCommentAsync(CommentRealEstate commentRealEstate)
        {
            try
            {
                await _context.CommentRealEstates.AddAsync(commentRealEstate);
                await _context.SaveChangesAsync();
                return true;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteCommentAsync(CommentRealEstate comment)
        {
            try
            {
                _context.CommentRealEstates.Remove(comment);
                await _context.SaveChangesAsync();
                return true;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<CommentRealEstate?> GetCommentByIdAsync(Guid commentId)
        {
            try
            {
                return await _context.CommentRealEstates.FirstOrDefaultAsync(x => x.Id == commentId);
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<CommentRealEstate>> GetListCommentByPostIdAsync(Guid postId)
        {
            try
            {
                return await _context.CommentRealEstates.Where(x => x.PostRealEstateId == postId).ToListAsync();
            } catch (Exception)
            {
                throw;
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using RentHouse_EXE.Model;
using RentHouse_EXE.RentHouseDatabaseContext;
using RentHouse_EXE.Repository.Interface;

namespace RentHouse_EXE.Repository
{
    public class LikeCommentRepository : ILikeCommentRepository
    {
        private readonly RentHouseDbContext _context;

        public LikeCommentRepository(RentHouseDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateLikeCommentAsync(LikeComment likeComment)
        {
            try
            {
                await _context.LikeComments.AddAsync(likeComment);
                await _context.SaveChangesAsync();
                return true;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteLikeCommentAsync(LikeComment likeComment)
        {
            try
            {
                _context.LikeComments.Remove(likeComment);
                await _context.SaveChangesAsync();
                return true;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<LikeComment?> GetLikeCommentByIdAsync(Guid likeCommentId)
        {
            try
            {
                return await _context.LikeComments.FirstOrDefaultAsync(x => x.Id == likeCommentId);
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<LikeComment>> GetListLikeByCommentIdAsync(Guid commentId)
        {
            try
            {
                return await _context.LikeComments.Where(x => x.CommentId == commentId).ToListAsync();
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<LikeComment>> GetListLikeByReplyCommentId(Guid replyCommentId)
        {
            try
            {
                return await _context.LikeComments.Where(x => x.ReplyCommentId == replyCommentId).ToListAsync();
            } catch (Exception)
            {
                throw;
            }
        }
    }
}

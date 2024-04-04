using Microsoft.EntityFrameworkCore;
using RentHouse_EXE.Model;
using RentHouse_EXE.RentHouseDatabaseContext;
using RentHouse_EXE.Repository.Interface;

namespace RentHouse_EXE.Repository
{
    public class ReplyCommentRepository : IReplyCommentRepository
    {
        private readonly RentHouseDbContext _context;

        public ReplyCommentRepository(RentHouseDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateReplyCommentAsync(ReplyComment replyComment)
        {
            try
            {
                await _context.ReplyComments.AddAsync(replyComment);
                await _context.SaveChangesAsync();
                return true;
            } 
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteReplyCommentAsync(ReplyComment replyComment)
        {
            try
            {
                _context.ReplyComments.Remove(replyComment);
                await _context.SaveChangesAsync();
                return true;
            } 
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ReplyComment>> GetListReplyCommentByCommentIdAsync(Guid commentId)
        {
            try
            {
                return await _context.ReplyComments.Where(x => x.CommentId == commentId).ToListAsync();
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ReplyComment>> GetListReplyCommentByParentReplyCommentIdAsync(Guid parentReplyCommentId)
        {
            try
            {
                return await _context.ReplyComments.Where(x => x.ParentReplyCommentId == parentReplyCommentId).ToListAsync();
            } catch (Exception)
            {
                throw;
            }
        }
    }
}

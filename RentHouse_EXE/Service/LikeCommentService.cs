using RentHouse_EXE.Model;
using RentHouse_EXE.Repository.Interface;
using RentHouse_EXE.Service.Interface;

namespace RentHouse_EXE.Service
{
    public class LikeCommentService : ILikeCommentService
    {
        private readonly ICommentRealEstateRepository _commentRealEstateRepository;
        private readonly ILikeCommentRepository _likeCommentRepository;
        private readonly IHelperService _helperService;
        private readonly IAccountRepository _accountRepository;    

        public LikeCommentService(ICommentRealEstateRepository commentRealEstateRepository, ILikeCommentRepository likeCommentRepository, IHelperService helperService, IAccountRepository accountRepository)
        {
            _commentRealEstateRepository = commentRealEstateRepository;
            _likeCommentRepository = likeCommentRepository;
            _helperService = helperService;
            _accountRepository = accountRepository;            
        }

        public async Task<bool> LikeCommentAsync(Guid commentId)
        {
            try
            {
                if (_helperService.IsTokenValid())
                {
                    throw new Exception("Unthorized");
                }
                var account = await _accountRepository.GetAccountByIdRepository(_helperService.GetAccIdFromLogged()) ?? throw new Exception("Unthorized");
                var comment = await _commentRealEstateRepository.GetCommentByIdAsync(commentId) ?? throw new Exception("Comment not found");                
                var like = new LikeComment
                {
                    CommentId = commentId,
                    AccountLikeCommentId = account.Id                    
                };
                return await _likeCommentRepository.CreateLikeCommentAsync(like);
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UnlikeCommennAsync(Guid likeCommentId)
        {
            try
            {
                if (_helperService.IsTokenValid())
                {
                    throw new Exception("Unthorized");
                }
                var account = await _accountRepository.GetAccountByIdRepository(_helperService.GetAccIdFromLogged()) ?? throw new Exception("Unthorized");
                var like = await _likeCommentRepository.GetLikeCommentByIdAsync(likeCommentId) ?? throw new Exception("Like not found");
                if (like.AccountLikeCommentId == account.Id)
                {
                    return await _likeCommentRepository.DeleteLikeCommentAsync(like);
                }
                throw new Exception("Unthorized");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

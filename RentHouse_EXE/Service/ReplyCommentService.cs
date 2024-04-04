using RentHouse_EXE.Model;
using RentHouse_EXE.Model.ReqDto;
using RentHouse_EXE.Repository.Interface;
using RentHouse_EXE.Service.Interface;

namespace RentHouse_EXE.Service
{
    public class ReplyCommentService : IReplyCommentService
    {
        private readonly ICommentRealEstateRepository _commentRealEstateRepository;
        private readonly IReplyCommentRepository _replyCommentRepository;
        private readonly IHelperService _helperService;
        private readonly IAccountRepository _accountRepository;
        private readonly IStatusRepository _statusRepository;

        public ReplyCommentService(ICommentRealEstateRepository commentRealEstateRepository, IReplyCommentRepository replyCommentRepository, IHelperService helperService, IAccountRepository accountRepository, IStatusRepository statusRepository)
        {
            _commentRealEstateRepository = commentRealEstateRepository;
            _replyCommentRepository = replyCommentRepository;
            _helperService = helperService;
            _accountRepository = accountRepository;
            _statusRepository = statusRepository;
        }

        public async Task<bool> CreateChildReplyCommentAsync(CreateReplyCommentReqDto replyComment)
        {
            try
            {
                if(_helperService.IsTokenValid())
                {
                    throw new Exception("Unthorized");
                }
                var account = await _accountRepository.GetAccountByIdRepository(_helperService.GetAccIdFromLogged()) ?? throw new Exception("Unthorized");
                var comment = await _commentRealEstateRepository.GetCommentByIdAsync(replyComment.CommentId) ?? throw new Exception("Comment not found");
                var statusActive = await _statusRepository.GetStatusByNameRepository("ACTIVE") ?? throw new Exception("Status not found");
                var reply = new ReplyComment
                {
                    ParentReplyCommentId = replyComment.CommentId,
                    ReplyCommentContent = replyComment.ContentReply,
                    AccountReplyCommentId = account.Id                    
                };
                return await _replyCommentRepository.CreateReplyCommentAsync(reply);
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> CreateReplyCommentAsync(CreateReplyCommentReqDto replyComment)
        {
            try
            {
                if(_helperService.IsTokenValid())
                {
                    throw new Exception("Unthorized");
                }
                var account = await _accountRepository.GetAccountByIdRepository(_helperService.GetAccIdFromLogged()) ?? throw new Exception("Unthorized");
                var comment = await _commentRealEstateRepository.GetCommentByIdAsync(replyComment.CommentId) ?? throw new Exception("Comment not found");
                var statusActive = await _statusRepository.GetStatusByNameRepository("ACTIVE") ?? throw new Exception("Status not found");
                var reply = new ReplyComment
                {
                    CommentId = replyComment.CommentId,
                    ReplyCommentContent = replyComment.ContentReply,
                    AccountReplyCommentId = account.Id                    
                };
                return await _replyCommentRepository.CreateReplyCommentAsync(reply);
            } catch (Exception)
            {
                throw;
            }
        }
    }
}

using RentHouse_EXE.Model;
using RentHouse_EXE.Model.ReqDto;
using RentHouse_EXE.Model.ResDto;
using RentHouse_EXE.Repository.Interface;
using RentHouse_EXE.Service.Interface;
using System.Diagnostics;
using System.Security.Cryptography.Xml;

namespace RentHouse_EXE.Service
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRealEstateRepository _commentRealEstateRepository;
        private readonly IHelperService _helperService;
        private readonly IAccountRepository _accountRepository;
        private readonly IStatusRepository _statusRepository;
        private readonly ILikeCommentRepository _likeCommentRepository;
        private readonly IPostRepository _postepository;

        public CommentService(ICommentRealEstateRepository commentRealEstateRepository, IHelperService helperService, IAccountRepository accountRepository, IStatusRepository statusRepository, ILikeCommentRepository likeCommentRepository, IPostRepository postepository)
        {
            _commentRealEstateRepository = commentRealEstateRepository;
            _helperService = helperService;
            _accountRepository = accountRepository;
            _statusRepository = statusRepository;
            _likeCommentRepository = likeCommentRepository;
            _postepository = postepository;
        }

        public async Task<bool> CreateCommentAsync(CreateCommentReqDto commentRealEstate)
        {
            try
            {
                if (!_helperService.IsTokenValid())
                {
                    throw new Exception("Unthorized");
                }
                var account = await _accountRepository.GetAccountByIdRepository(_helperService.GetAccIdFromLogged()) ?? throw new Exception("Unthorized");
                var statusActive = await _statusRepository.GetStatusByNameRepository("ACTIVE") ?? throw new Exception("Status not found");
                var post = await _postepository.GetPostByIdAsync(commentRealEstate.PostRealEstateId) ?? throw new Exception("Post not found");
                var comment = new CommentRealEstate
                {
                    PostRealEstateId = post.Id,
                    ContentCommon = commentRealEstate.ContentCommon,
                    AccountCommentId = account.Id,
                    StatusId = statusActive.Id
                };
                return await _commentRealEstateRepository.CreateCommentAsync(comment);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<bool> DeleteCommentAsync(Guid commentId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetCommentResDto>> GetListCommentByPostIdAsync(Guid postId)
        {
            try
            {
                var comments = await _commentRealEstateRepository.GetListCommentByPostIdAsync(postId);                
                var result = new List<GetCommentResDto>();
                var likeCount = (await _likeCommentRepository.GetListLikeByCommentIdAsync(postId)).Count;
                foreach (var comment in comments)
                {
                    var account = await _accountRepository.GetAccountByIdRepository(comment.AccountCommentId) ?? new Account();
                    result.Add(new GetCommentResDto
                    {
                        Id = comment.Id,
                        ContentCommon = comment.ContentCommon,
                        RealEstateId = comment.PostRealEstateId,
                        CommentDateTime = comment.CreateDateTime,
                        AccountCommentName = account.FirstName,
                        LikeCount = likeCount                      
                    });
                }
                return result;
            } catch (Exception)
            {
                throw;
            }
        }
    }
}

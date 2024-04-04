using RentHouse_EXE.Model;
using RentHouse_EXE.Model.ReqDto;
using RentHouse_EXE.Model.ResDto;
using RentHouse_EXE.Repository.Interface;
using RentHouse_EXE.Service.Interface;

namespace RentHouse_EXE.Service
{
    public class TypeRealEstateService : ITypeRealEstateService
    {
        private readonly ITypeRealEstateRepository _typeRealEstateRepository;
        private readonly IHelperService _helperService;
        private readonly IAccountRepository _accountRepository;
        private readonly IRoleRepository _roleRepository;

        public TypeRealEstateService(ITypeRealEstateRepository typeRealEstateRepository, IHelperService helperService, IAccountRepository accountRepository, IRoleRepository roleRepository)
        {
            _typeRealEstateRepository = typeRealEstateRepository;
            _helperService = helperService;
            _accountRepository = accountRepository;
            _roleRepository = roleRepository;
        }

        public async Task<bool> CreateTypeRealEstateAsync(CreateTypeRealEstateResDto typeRealEstate)
        {
            try
            {
                if (!_helperService.IsTokenValid())
                {
                    throw new Exception("Unthentication");
                }
                var accLogged = await _accountRepository.GetAccountByIdRepository(_helperService.GetAccIdFromLogged()) ?? throw new Exception("Unthentication");
                var roleAdmin = await _roleRepository.GetRoleByNameRepository("ADMIN") ?? throw new Exception("Role not found");

                if (accLogged.RoleId != roleAdmin.Id)
                {
                    throw new Exception("Unthentication");
                }

                var newTypeRealEstate = new TypeRealEstate
                {
                    Name = typeRealEstate.Name,
                    Description = typeRealEstate.Description
                };

                return await _typeRealEstateRepository.CreateTypeRealEstateAsync(newTypeRealEstate);
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<GetTypeRealEstateResDto>> GetListTypeRealEstateAsync()
        {
            try
            {
                var listTypeRealEstate = await _typeRealEstateRepository.GetListTypeRealEstateAsync();
                return listTypeRealEstate.Select(x => new GetTypeRealEstateResDto
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
            } catch (Exception)
            {
                throw;
            }
        }
    }
}

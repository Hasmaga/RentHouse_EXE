using RentHouse_EXE.Model;
using RentHouse_EXE.Model.Provinces;
using RentHouse_EXE.Model.ReqDto;
using RentHouse_EXE.Model.ResDto;
using RentHouse_EXE.Repository.Interface;
using RentHouse_EXE.Service.Interface;

namespace RentHouse_EXE.Service
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IHelperService _helperService;
        private readonly IStatusRepository _statusRepository;
        private readonly IPlanRepository _planRepository;
        private readonly IImageRealEstateRepository _imageRealEstateRepository;
        private readonly ITypeRealEstateRepository _typeRealEstateRepository;
        private readonly IPriceUnitRepository _priceUnitRepository;
        private readonly IFurnitureRepository _furnitureRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IAccountRepository _accountRepository;

        public PostService(IPostRepository postRepository, IHelperService helperService, IStatusRepository statusRepository, IPlanRepository planRepository, IImageRealEstateRepository imageRealEstateRepository, ITypeRealEstateRepository typeRealEstateRepository, IPriceUnitRepository priceUnitRepository, IFurnitureRepository furnitureRepository, ILocationRepository locationRepository, IAccountRepository accountRepository)
        {
            _postRepository = postRepository;
            _helperService = helperService;
            _statusRepository = statusRepository;
            _planRepository = planRepository;
            _imageRealEstateRepository = imageRealEstateRepository;
            _typeRealEstateRepository = typeRealEstateRepository;
            _priceUnitRepository = priceUnitRepository;
            _furnitureRepository = furnitureRepository;
            _locationRepository = locationRepository;
            _accountRepository = accountRepository;
        }

        public async Task<Guid> CreatePostRealEstateAsync(CreatePostRealEstateReqDto post)
        {
            try
            {
                if (!_helperService.IsTokenValid())
                {
                    throw new Exception("Unthority");
                }
                var customer = await _accountRepository.GetAccountByIdRepository(_helperService.GetAccIdFromLogged()) ?? throw new Exception("Customer not found");                
                var status = await _statusRepository.GetStatusByNameRepository("PENDING") ?? throw new Exception("Status not found");
                var planPrice = await _planRepository.GetPlanPriceByPlanIdAsync(post.PlanId) ?? throw new Exception("Plan price not found");
                var planDay = await _planRepository.GetPlanDayByIdAsync(post.PlanDayId) ?? throw new Exception("Plan day not found");
                var discount = await _planRepository.GetPriceDecreasesByPlanDayIdAsync(post.PlanDayId) ?? throw new Exception("Discount not found");
                var totalPrice = (planPrice.Price * planDay.Day) * ((100 - discount.PercentageDecrease) / 100);
                // Check wallet of customer is enough to pay the post
                if (customer.Wallet < totalPrice)
                {
                    throw new Exception("Wallet is not enough");
                }
                PostRealEstate newPost = new()
                {
                    Name = post.Title,
                    TypeRealEstateId = post.TypeId,
                    Address = post.Address,
                    City = post.City,
                    District = post.District,
                    Ward = post.Ward,
                    Street = post.Street,
                    CustomerPostId = customer.Id,
                    StatusId = status.Id,
                    Description = post.Description,
                    Phone = post.ContactPhone,
                    Price = post.Price,
                    PriceUnitId = post.PriceUnitId,
                    FurnitureId = post.FurnitureId,
                    TotalRoom = post.BathRoom + post.BedRoom,
                    TotalBathRoom = post.BathRoom,
                    TotalBedRoom = post.BedRoom,
                    TotalFloor = post.Floor,
                    Area = post.Area,
                    PlanPriceId = planPrice.Id,
                    PlanDayId = post.PlanDayId,
                    PostDate = post.PostDate,
                    PostTime = post.PostTime,
                    ContactEmail = post.ContactEmail,
                    ContactName = post.ContactName,
                    TotalPrice = (planPrice.Price * planDay.Day) * ((100 - discount.PercentageDecrease) / 100)
                };
                // Update wallet of customer
                customer.Wallet -= totalPrice;
                await _accountRepository.UpdateAccountRepository(customer);
                return await _postRepository.CreatePostAsync(newPost);               
                
            } catch (Exception) 
            {
                throw;
            }
        }

        public async Task<List<GetTitlePostRealEstateResDto>> GetTitleRentPostRealEstateAsync()
        {
            try
            {
                var posts = await _postRepository.GetAllPostsAsync();
                // Check type of post is rent
                var RentType = await _typeRealEstateRepository.GetTypeRealEstateByNameAsync("Cho Thuê") ?? throw new Exception("Type not found");
                var rentPosts = posts.Where(p => p.TypeRealEstateId == RentType.Id).ToList();
                // Check plan day is not expired
                var planDays = await _planRepository.GetListPlanDayAsync();

                var currentDate = DateTime.Now;
                var currentDateTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, currentDate.Second);

                var validPosts = rentPosts.Where(post =>
                {
                    var postDateTime = new DateTime(post.PostDate.Year, post.PostDate.Month, post.PostDate.Day, post.PostTime.Hour, post.PostTime.Minute, post.PostTime.Second);
                    var planDay = planDays.FirstOrDefault(pd => pd.Id == post.PlanDayId);
                    if (planDay == null)
                    {
                        throw new Exception("Plan day not found");
                    }
                    var expiryDate = postDateTime.AddDays(planDay.Day);
                    return expiryDate > currentDateTime;
                }).ToList();
                // Change the index of the post following the oldest post to newest post 
                validPosts.Reverse();
                // Change the index of the post following the PlanPriceId which is most expensive to cheapest
                validPosts = validPosts.OrderBy(p => p.PlanPriceId).ToList();
                // PlanPrice have 3 top, up, tag, the top is on the top the list, the up is in the middle of the list, the tag is at the bottow at the list change the index 
                var topPlan = await _planRepository.GetPlanPriceByPlanNameAsync("TOP") ?? throw new Exception("Plan price not found");
                var upPlan = await _planRepository.GetPlanPriceByPlanNameAsync("UP") ?? throw new Exception("Plan price not found");
                var tagPlan = await _planRepository.GetPlanPriceByPlanNameAsync("TAG") ?? throw new Exception("Plan price not found");
                var topPosts = validPosts.Where(p => p.PlanPriceId == topPlan.Id).ToList();
                var upPosts = validPosts.Where(p => p.PlanPriceId == upPlan.Id).ToList();
                var tagPosts = validPosts.Where(p => p.PlanPriceId == tagPlan.Id).ToList();
                var validPlanPosts = new List<PostRealEstate>();
                validPlanPosts.AddRange(topPosts);
                validPlanPosts.AddRange(upPosts);
                validPlanPosts.AddRange(tagPosts);
                var listPost = new List<GetTitlePostRealEstateResDto>();
                foreach (var post in validPlanPosts)
                {
                    var city = (await _locationRepository.GetCityByIdAsync(post.City) ?? new Provinces()).Full_name;
                    var district = (await _locationRepository.GetDistrictByIdAsync(post.District) ?? new Districts()).Full_name;
                    var ward = (await _locationRepository.GetWardByIdAsync(post.Ward) ?? new Wards()).Full_name;
                    var postRes = new GetTitlePostRealEstateResDto
                    {
                        Id = post.Id,
                        Title = post.Name,
                        Address = post.Address,
                        City = city,
                        District = district,
                        Ward = ward,
                        Street = post.Street,
                        Price = post.Price,
                        PriceUnit = (await _priceUnitRepository.GetPriceUnitByIdAsync(post.PriceUnitId) ?? new PriceUnit()).Name,
                        Furniture = (await _furnitureRepository.GetFurnitureByIdAsync(post.FurnitureId) ?? new Furniture()).Name,
                        TotalBathRoom = post.TotalBathRoom,
                        TotalBedRoom = post.TotalBedRoom,
                        TotalFloor = post.TotalFloor,
                        Area = post.Area,
                        ImageCover = await _imageRealEstateRepository.GetTheFirstImageRealEstateAsync(post.Id)
                    };
                    listPost.Add(postRes);
                }
                return listPost;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<GetTitlePostRealEstateResDto>> GetTitleBuyPostRealEstateAsync()
        {
            try
            {
                var posts = await _postRepository.GetAllPostsAsync();
                // Check type of post is rent
                var RentType = await _typeRealEstateRepository.GetTypeRealEstateByNameAsync("Bán") ?? throw new Exception("Type not found");
                var rentPosts = posts.Where(p => p.TypeRealEstateId == RentType.Id).ToList();
                // Check plan day is not expired
                var planDays = await _planRepository.GetListPlanDayAsync();

                var currentDate = DateTime.Now;
                var currentDateTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, currentDate.Second);

                var validPosts = rentPosts.Where(post =>
                {
                    var postDateTime = new DateTime(post.PostDate.Year, post.PostDate.Month, post.PostDate.Day, post.PostTime.Hour, post.PostTime.Minute, post.PostTime.Second);
                    var planDay = planDays.FirstOrDefault(pd => pd.Id == post.PlanDayId);
                    if (planDay == null)
                    {
                        throw new Exception("Plan day not found");
                    }
                    var expiryDate = postDateTime.AddDays(planDay.Day);
                    return expiryDate > currentDateTime;
                }).ToList();
                // Change the index of the post following the oldest post to newest post 
                validPosts.Reverse();
                // Change the index of the post following the PlanPriceId which is most expensive to cheapest
                validPosts = validPosts.OrderBy(p => p.PlanPriceId).ToList();
                // PlanPrice have 3 top, up, tag, the top is on the top the list, the up is in the middle of the list, the tag is at the bottow at the list change the index 
                var topPlan = await _planRepository.GetPlanPriceByPlanNameAsync("TOP") ?? throw new Exception("Plan price not found");
                var upPlan = await _planRepository.GetPlanPriceByPlanNameAsync("UP") ?? throw new Exception("Plan price not found");
                var tagPlan = await _planRepository.GetPlanPriceByPlanNameAsync("TAG") ?? throw new Exception("Plan price not found");
                var topPosts = validPosts.Where(p => p.PlanPriceId == topPlan.Id).ToList();
                var upPosts = validPosts.Where(p => p.PlanPriceId == upPlan.Id).ToList();
                var tagPosts = validPosts.Where(p => p.PlanPriceId == tagPlan.Id).ToList();
                var validPlanPosts = new List<PostRealEstate>();
                validPlanPosts.AddRange(topPosts);
                validPlanPosts.AddRange(upPosts);
                validPlanPosts.AddRange(tagPosts);
                var listPost = new List<GetTitlePostRealEstateResDto>();
                foreach (var post in validPlanPosts)
                {
                    var city = (await _locationRepository.GetCityByIdAsync(post.City) ?? new Provinces()).Full_name;
                    var district = (await _locationRepository.GetDistrictByIdAsync(post.District) ?? new Districts()).Full_name;
                    var ward = (await _locationRepository.GetWardByIdAsync(post.Ward) ?? new Wards()).Full_name;
                    var postRes = new GetTitlePostRealEstateResDto
                    {
                        Id = post.Id,
                        Title = post.Name,
                        Address = post.Address,
                        City = city,
                        District = district,
                        Ward = ward,
                        Street = post.Street,
                        Price = post.Price,
                        PriceUnit = (await _priceUnitRepository.GetPriceUnitByIdAsync(post.PriceUnitId) ?? new PriceUnit()).Name,
                        Furniture = (await _furnitureRepository.GetFurnitureByIdAsync(post.FurnitureId) ?? new Furniture()).Name,
                        TotalBathRoom = post.TotalBathRoom,
                        TotalBedRoom = post.TotalBedRoom,
                        TotalFloor = post.TotalFloor,
                        Area = post.Area,
                        ImageCover = await _imageRealEstateRepository.GetTheFirstImageRealEstateAsync(post.Id)
                    };
                    listPost.Add(postRes);
                }
                return listPost;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetPostRealEstateResDto> GetPostRealEstateByIdAsync(Guid id)
        {
            try
            {
                var post = await _postRepository.GetPostByIdAsync(id);
                if (post == null)
                {
                    throw new Exception("Post not found");
                }

                var images = new List<GetListImagaeResDto>();
                foreach (var image in await _imageRealEstateRepository.GetAllImageRealEstateAsync(id) ?? new List<byte[]>())
                {
                    var imageRes = new GetListImagaeResDto
                    {
                        Image = image
                    };
                    images.Add(imageRes);
                }
                var city = (await _locationRepository.GetCityByIdAsync(post.City) ?? new Provinces()).Full_name;
                var district = (await _locationRepository.GetDistrictByIdAsync(post.District) ?? new Districts()).Full_name;
                var ward = (await _locationRepository.GetWardByIdAsync(post.Ward) ?? new Wards()).Full_name;
                var postRes = new GetPostRealEstateResDto
                {
                    TypeRealEstate = (await _typeRealEstateRepository.GetTypeRealEstateByIdAsync(post.TypeRealEstateId) ?? new TypeRealEstate()).Name,
                    Name = post.Name,
                    Address = post.Address,
                    City = city,
                    District = district,
                    Ward = ward,
                    Street = post.Street,
                    Description = post.Description,
                    ContactName = post.ContactName,
                    ContactEmail = post.ContactEmail,
                    Phone = post.Phone,
                    Price = post.Price,
                    PriceUnit = (await _priceUnitRepository.GetPriceUnitByIdAsync(post.PriceUnitId) ?? new PriceUnit()).Name,
                    Furniture = (await _furnitureRepository.GetFurnitureByIdAsync(post.FurnitureId) ?? new Furniture()).Name,
                    TotalRoom = post.TotalRoom,
                    TotalBathRoom = post.TotalBathRoom,
                    TotalBedRoom = post.TotalBedRoom,
                    TotalFloor = post.TotalFloor,
                    Area = post.Area,
                    PostDay = post.PostDate,
                    Images = images                    
                };
                
                
                return postRes;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<GetTitlePostRealEstateResDto>> GetTitleRentPostRealEstateByPlanTopAsync()
        {
            try
            {
                var posts = await _postRepository.GetAllPostsAsync();
                // Check type of post is rent
                var RentType = await _typeRealEstateRepository.GetTypeRealEstateByNameAsync("Cho Thuê") ?? throw new Exception("Type not found");
                var rentPosts = posts.Where(p => p.TypeRealEstateId == RentType.Id).ToList();
                // Check plan day is not expired
                var planDays = await _planRepository.GetListPlanDayAsync();

                var currentDate = DateTime.Now;
                var currentDateTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, currentDate.Second);

                var validPosts = rentPosts.Where(post =>
                {
                    var postDateTime = new DateTime(post.PostDate.Year, post.PostDate.Month, post.PostDate.Day, post.PostTime.Hour, post.PostTime.Minute, post.PostTime.Second);
                    var planDay = planDays.FirstOrDefault(pd => pd.Id == post.PlanDayId);
                    if (planDay == null)
                    {
                        throw new Exception("Plan day not found");
                    }
                    var expiryDate = postDateTime.AddDays(planDay.Day);
                    return expiryDate > currentDateTime;
                }).ToList();
                // Change the index of the post following the oldest post to newest post 
                validPosts.Reverse();
                // Change the index of the post following the PlanPriceId which is most expensive to cheapest
                validPosts = validPosts.OrderBy(p => p.PlanPriceId).ToList();
                // PlanPrice have 3 top, up, tag, the top is on the top the list, the up is in the middle of the list, the tag is at the bottow at the list change the index 
                var topPlan = await _planRepository.GetPlanPriceByPlanNameAsync("TOP") ?? throw new Exception("Plan price not found");
                var upPlan = await _planRepository.GetPlanPriceByPlanNameAsync("UP") ?? throw new Exception("Plan price not found");
                var tagPlan = await _planRepository.GetPlanPriceByPlanNameAsync("TAG") ?? throw new Exception("Plan price not found");
                var topPosts = validPosts.Where(p => p.PlanPriceId == topPlan.Id).ToList();
                var validPlanPosts = new List<PostRealEstate>();
                validPlanPosts.AddRange(topPosts);
                var listPost = new List<GetTitlePostRealEstateResDto>();
                foreach (var post in validPlanPosts)
                {
                    var city = (await _locationRepository.GetCityByIdAsync(post.City) ?? new Provinces()).Full_name;
                    var district = (await _locationRepository.GetDistrictByIdAsync(post.District) ?? new Districts()).Full_name;
                    var ward = (await _locationRepository.GetWardByIdAsync(post.Ward) ?? new Wards()).Full_name;
                    var postRes = new GetTitlePostRealEstateResDto
                    {
                        Id = post.Id,
                        Title = post.Name,
                        Address = post.Address,
                        City = city,
                        District = district,
                        Ward = ward,
                        Street = post.Street,
                        Price = post.Price,
                        PriceUnit = (await _priceUnitRepository.GetPriceUnitByIdAsync(post.PriceUnitId) ?? new PriceUnit()).Name,
                        Furniture = (await _furnitureRepository.GetFurnitureByIdAsync(post.FurnitureId) ?? new Furniture()).Name,
                        TotalBathRoom = post.TotalBathRoom,
                        TotalBedRoom = post.TotalBedRoom,
                        TotalFloor = post.TotalFloor,
                        Area = post.Area,
                        ImageCover = await _imageRealEstateRepository.GetTheFirstImageRealEstateAsync(post.Id)
                    };
                    listPost.Add(postRes);
                }
                return listPost;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<GetTitlePostRealEstateResDto>> GetTitleBuyPostRealEstateByPlanTopAsync()
        {
            try
            {
                var posts = await _postRepository.GetAllPostsAsync();
                // Check type of post is rent
                var RentType = await _typeRealEstateRepository.GetTypeRealEstateByNameAsync("Bán") ?? throw new Exception("Type not found");
                var rentPosts = posts.Where(p => p.TypeRealEstateId == RentType.Id).ToList();
                // Check plan day is not expired
                var planDays = await _planRepository.GetListPlanDayAsync();

                var currentDate = DateTime.Now;
                var currentDateTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, currentDate.Second);

                var validPosts = rentPosts.Where(post =>
                {
                    var postDateTime = new DateTime(post.PostDate.Year, post.PostDate.Month, post.PostDate.Day, post.PostTime.Hour, post.PostTime.Minute, post.PostTime.Second);
                    var planDay = planDays.FirstOrDefault(pd => pd.Id == post.PlanDayId);
                    if (planDay == null)
                    {
                        throw new Exception("Plan day not found");
                    }
                    var expiryDate = postDateTime.AddDays(planDay.Day);
                    return expiryDate > currentDateTime;
                }).ToList();
                // Change the index of the post following the oldest post to newest post 
                validPosts.Reverse();
                // Change the index of the post following the PlanPriceId which is most expensive to cheapest
                validPosts = validPosts.OrderBy(p => p.PlanPriceId).ToList();
                // PlanPrice have 3 top, up, tag, the top is on the top the list, the up is in the middle of the list, the tag is at the bottow at the list change the index 
                var topPlan = await _planRepository.GetPlanPriceByPlanNameAsync("TOP") ?? throw new Exception("Plan price not found");
                var upPlan = await _planRepository.GetPlanPriceByPlanNameAsync("UP") ?? throw new Exception("Plan price not found");
                var tagPlan = await _planRepository.GetPlanPriceByPlanNameAsync("TAG") ?? throw new Exception("Plan price not found");
                var topPosts = validPosts.Where(p => p.PlanPriceId == topPlan.Id).ToList();
                var validPlanPosts = new List<PostRealEstate>();
                validPlanPosts.AddRange(topPosts);
                var listPost = new List<GetTitlePostRealEstateResDto>();
                foreach (var post in validPlanPosts)
                {
                    var city = (await _locationRepository.GetCityByIdAsync(post.City) ?? new Provinces()).Name;
                    var district = (await _locationRepository.GetDistrictByIdAsync(post.District) ?? new Districts()).Name;
                    var ward = (await _locationRepository.GetWardByIdAsync(post.Ward) ?? new Wards()).Name;
                    var postRes = new GetTitlePostRealEstateResDto
                    {
                        Id = post.Id,
                        Title = post.Name,
                        Address = post.Address,
                        City = city,
                        District = district,
                        Ward = ward,
                        Street = post.Street,
                        Price = post.Price,
                        PriceUnit = (await _priceUnitRepository.GetPriceUnitByIdAsync(post.PriceUnitId) ?? new PriceUnit()).Name,
                        Furniture = (await _furnitureRepository.GetFurnitureByIdAsync(post.FurnitureId) ?? new Furniture()).Name,
                        TotalBathRoom = post.TotalBathRoom,
                        TotalBedRoom = post.TotalBedRoom,
                        TotalFloor = post.TotalFloor,
                        Area = post.Area,
                        ImageCover = await _imageRealEstateRepository.GetTheFirstImageRealEstateAsync(post.Id)
                    };
                    listPost.Add(postRes);
                }
                return listPost;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<GetTitlePostRealEstateResDto>> GetTitlePostRealEstateByCustomerIdAsync()
        {
            try
            {
                if (!_helperService.IsTokenValid())
                {
                    throw new Exception("Unthority");
                }
                var customerId = _helperService.GetAccIdFromLogged();
                var posts = await _postRepository.GetListPostsByCustomerPostId(customerId);
                var listPost = new List<GetTitlePostRealEstateResDto>();
                foreach (var post in posts)
                {
                    var city = (await _locationRepository.GetCityByIdAsync(post.City) ?? new Provinces()).Name;
                    var district = (await _locationRepository.GetDistrictByIdAsync(post.District) ?? new Districts()).Name;
                    var ward = (await _locationRepository.GetWardByIdAsync(post.Ward) ?? new Wards()).Name;
                    var postRes = new GetTitlePostRealEstateResDto
                    {
                        Id = post.Id,
                        Title = post.Name,
                        Address = post.Address,
                        City = city,
                        District = district,
                        Ward = ward,
                        Street = post.Street,
                        Price = post.Price,
                        PriceUnit = (await _priceUnitRepository.GetPriceUnitByIdAsync(post.PriceUnitId) ?? new PriceUnit()).Name,
                        Furniture = (await _furnitureRepository.GetFurnitureByIdAsync(post.FurnitureId) ?? new Furniture()).Name,
                        TotalBathRoom = post.TotalBathRoom,
                        TotalBedRoom = post.TotalBedRoom,
                        TotalFloor = post.TotalFloor,
                        Area = post.Area,
                        ImageCover = await _imageRealEstateRepository.GetTheFirstImageRealEstateAsync(post.Id)
                    };
                    listPost.Add(postRes);
                }
                return listPost;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetCustomerPostRealStateResDto> GetCustomerPostRealEstateByIdAsync(Guid id)
        {
            try
            {
                if (!_helperService.IsTokenValid())
                {
                    throw new Exception("Unthority");
                }
                var customerId = _helperService.GetAccIdFromLogged();
                var post = await _postRepository.GetPostByIdAsync(id);
                if (post == null)
                {
                    throw new Exception("Post not found");
                }
                if (post.CustomerPostId != customerId)
                {
                    throw new Exception("Unthority");
                }
                var city = (await _locationRepository.GetCityByIdAsync(post.City) ?? new Provinces()).Name;
                var district = (await _locationRepository.GetDistrictByIdAsync(post.District) ?? new Districts()).Name;
                var ward = (await _locationRepository.GetWardByIdAsync(post.Ward) ?? new Wards()).Name;
                var postRes = new GetCustomerPostRealStateResDto
                {
                    Name = post.Name,
                    TypeRealEstate = (await _typeRealEstateRepository.GetTypeRealEstateByIdAsync(post.TypeRealEstateId) ?? new TypeRealEstate()).Name,
                    Address = post.Address,
                    City = city,
                    District = district,
                    Ward = ward,
                    Street = post.Street,
                    Status = (await _statusRepository.GetStatusByIdRepository(post.StatusId) ?? new Status()).StatusName,
                    Description = post.Description,
                    ContactName = post.ContactName,
                    ContactEmail = post.ContactEmail,
                    Phone = post.Phone,
                    Price = post.Price,
                    PriceUnit = (await _priceUnitRepository.GetPriceUnitByIdAsync(post.PriceUnitId) ?? new PriceUnit()).Name,
                    Furniture = (await _furnitureRepository.GetFurnitureByIdAsync(post.FurnitureId) ?? new Furniture()).Name,
                    TotalRoom = post.TotalRoom,
                    TotalBathroom = post.TotalBathRoom,
                    TotalBedroom = post.TotalBedRoom,
                    TotalFloor = post.TotalFloor,
                    Area = post.Area,
                    Plan = (await _planRepository.GetPlanByPlanPriceIdAsync(post.PlanPriceId) ?? new Plan()).Name,
                    PlanDay = (await _planRepository.GetPlanDayByIdAsync(post.PlanDayId) ?? new PlanDay()).Day,
                    PostDate = post.PostDate,
                    PostTime = post.PostTime,
                    TotalPrice = post.TotalPrice
                };
                return postRes;
            } catch (Exception)
            {
                throw;
            }
        }
    }
}

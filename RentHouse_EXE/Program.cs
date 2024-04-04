using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RentHouse_EXE.RentHouseDatabaseContext;
using RentHouse_EXE.Repository;
using RentHouse_EXE.Repository.Interface;
using RentHouse_EXE.Service;
using RentHouse_EXE.Service.Interface;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

// SQL Server Connection
// local connection
builder.Services.AddDbContext<RentHouseDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnection")));

// server connection
//builder.Services.AddDbContext<RentHouseDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("ServerConnection")));


// AddScoped Services

builder.Services.AddScoped<IStatusService, StatusService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IHelperService, HelperService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IPlanService, PlanService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IPriceUnitService, PriceUnitService>();
builder.Services.AddScoped<IFurnitureService, FurnitureService>();
builder.Services.AddScoped<ITypeRealEstateService, TypeRealEstateService>();
builder.Services.AddScoped<IImageRealEstateService, ImageRealEstateService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ILikeCommentService, LikeCommentService>();
builder.Services.AddScoped<IReplyCommentService, ReplyCommentService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();



// AddScoped Repositories
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IPriceUnitRepository, PriceUnitRepository>();
builder.Services.AddScoped<IFurnitureRepository, FurnitureRepository>();
builder.Services.AddScoped<IImageRealEstateRepository, ImageRealEstateRepository>();
builder.Services.AddScoped<ITypeRealEstateRepository, TypeRealEstateRepository>();
builder.Services.AddScoped<IImageRealEstateRepository, ImageRealEstateRepository>();
builder.Services.AddScoped<ICommentRealEstateRepository, CommentRealEstateRepository>();
builder.Services.AddScoped<ILikeCommentRepository, LikeCommentRepository>();
builder.Services.AddScoped<IReplyCommentRepository, ReplyCommentRepository>();
builder.Services.AddScoped<IPaymentHistoryRepository, PaymentHistoryRepository>();

// JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {            
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetSection("AppSettings:Token")?.Value ?? throw new Exception("Invalid Token in configuration"))),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    option.OperationFilter<SecurityRequirementsOperationFilter>();
});

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowAnyOrigin();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rent_House"));

app.MapControllers();

app.UseCors("AllowAll");

app.Run();

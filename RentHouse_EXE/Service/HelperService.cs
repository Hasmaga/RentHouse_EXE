using Microsoft.IdentityModel.Tokens;
using RentHouse_EXE.Enum;
using RentHouse_EXE.Service.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RentHouse_EXE.Service
{
    public class HelperService(IConfiguration configuration, IHttpContextAccessor http) : IHelperService
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly IHttpContextAccessor _http = http;

        public bool CheckBearerTokenIsValidAndNotExpired(string token)
        {
            var securityKey = _configuration.GetSection("AppSettings:Token").Value ?? throw new Exception(ServerErrorEnum.SERVER_ERROR);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                }, out SecurityToken validatedToken);
                // Check Token Is Expired
                if (validatedToken.ValidTo < DateTime.Now)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public byte[] ConvertIFormFileToByteArray(IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            file.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }

        public Guid GetAccIdFromLogged()
        {
            var AccId = _http.HttpContext?.User.FindFirst(ClaimTypes.Sid)?.Value;
            return AccId == null ? throw new Exception(ServerErrorEnum.SERVER_ERROR) : Guid.Parse(AccId);
        }

        public bool IsTokenValid()
        {
            var token = _http.HttpContext?.Request.Headers.Authorization.ToString().Replace("Bearer ", "");
            if (token == null || !CheckBearerTokenIsValidAndNotExpired(token))
            {
                return false;
            }
            return true;
        }
    }
}

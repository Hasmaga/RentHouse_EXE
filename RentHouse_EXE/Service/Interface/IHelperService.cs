namespace RentHouse_EXE.Service.Interface
{
    public interface IHelperService
    {
        bool CheckBearerTokenIsValidAndNotExpired(string token);
        Guid GetAccIdFromLogged();
        bool IsTokenValid();
        byte[] ConvertIFormFileToByteArray(IFormFile file);
    }
}
